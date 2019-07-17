using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading;


namespace EVEJournal
{
    class EveJournalDatabaseException : Exception
    {
    }

    partial class Database
    {
        //private static readonly string m_dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"EVEJournal.Eve");
        private static readonly string m_dataPath = Path.Combine(Environment.CurrentDirectory, @"EVEJournal.Eve");
        private static readonly string m_DatabasePath = Path.Combine(m_dataPath, "journal.db");
        private static readonly string m_connectionString = "Data Source=" + m_DatabasePath;
        private static readonly string m_New = ";New=True";
        private static readonly string m_Compress = ";Compress=True";
        private static readonly string m_Sync = ";Synchronous=Off";
        protected SQLiteConnection m_conn = null;

        private IDBCollection[] m_Tables = 
            {
                new VersionCollection() as IDBCollection,
                new RequestCacheCollection() as IDBCollection,
                new CharacterCollection() as IDBCollection,
                new CharacterJournalCollection() as IDBCollection,
                new CharacterTransactionCollection() as IDBCollection,
                new ReferenceTypeCollection() as IDBCollection,
                new CharacterOrderCollection() as IDBCollection,
                new CharacterIndustryJobCollection() as IDBCollection,
                new CorpWalletNameCollection() as IDBCollection,
                new CorporationJournalCollection() as IDBCollection,
                new CorporationMemberTrackingCollection() as IDBCollection,
                new MemberTrackingSettingsCollection() as IDBCollection
            };

        public enum DatabaseError
        {
            NoError,
            Unexpected,
            UserAborted,
            InvalidDatabase,
            EmptyDatabase,
            IncorrectVersion,
            NoRecordsFound,
            ConversionUnavailable,
            ExceptionSQL,
            FailedDueToRestriction,
            CheckFailed_Unidentifiable,
            CheckFailed_IncorrectVersion,
            //CheckFailed_TableMissing,
            //CheckFailed_TableVersion,
            //CheckFailed_TableDefintion,
        }
        private DatabaseError m_ErrorCode = DatabaseError.NoError;

        public bool IsOpen()
        {
            return (m_conn != null);
        }

        public Database()
        {
            Open(m_DatabasePath);
        }

        public Database(string FileNameAndPath)
        {
            Open(FileNameAndPath);
        }

        // attempts to open a the database file
        //  throws EveJournalDatabaseException on inability to create object 
        private void Open(string FileNameAndPath)
        {
            if (!File.Exists(FileNameAndPath))
                CreateNewDBAndFile();

            m_conn = new SQLiteConnection();
            m_conn.ConnectionString = m_connectionString;
            try
            {
                m_conn.Open();
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                m_conn.Dispose();
                m_conn = null;
                if (e.ErrorCode == SQLiteErrorCode.CantOpen)
                {
                    Logger.ReportNotice("File Does Not Exist - " + FileNameAndPath);
                    CreateNewDBAndFile();
                }
                else
                {
                    Logger.ReportError(e.ToString());
                    throw new EveJournalDatabaseException();
                }
            }

            CheckVersion();
            if (DatabaseError.NoError != m_ErrorCode)
                RepairDatabaseVersion();

            if (DatabaseError.NoError != m_ErrorCode)
            {
                m_conn.Close();
                m_conn = null; // abort opening
            }

        }

        private void CreateNewDBAndFile()
        {
            if (!Directory.Exists(m_dataPath))
                Directory.CreateDirectory(m_dataPath);

            if (!File.Exists(m_DatabasePath))
            {
                FileStream fs = File.Open(m_DatabasePath, FileMode.Create);
                fs.Close();
            }

            CreateNewDB();
        }

        private void CreateNewDB()
        {
            try
            {
                m_conn = new SQLiteConnection();
                StringBuilder sql = new StringBuilder();
                sql.Append(m_connectionString);
                sql.Append(m_New);
                sql.Append(m_Compress);
                sql.Append(m_Sync);
                sql.Append(";");
                m_conn.ConnectionString = sql.ToString();
                m_conn.Open();
                InitializeDB(true);
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                Logger.ReportError(e.ToString());
                throw new EveJournalDatabaseException();
            }
        }

        private void MarkTableVersion(IDBCollection col)
        {

            VersionCollection vcol = new VersionCollection();
            IDBCollection ivcol = vcol as IDBCollection;

            ivcol.SetConstraint((long)Version.QueryValues.TableName, 
                new DBConstraint(DBConstraint.QueryConstraints.Equal, col.GetTableName()));

            if (Database.DatabaseError.NoError == this.ReadRecord(ivcol))
            {
                IDBCollectionContents icont = vcol as IDBCollectionContents;
                (icont.GetRecordInterface(0).GetDataObject() as VersionObjectInternal).VersionNumber = col.GetVersionNumber();
                InsertOrUpdateRecord(vcol);
            }
            else
            {
                IDBRecord irec = ivcol.CreateBlankRecord();
                VersionObjectInternal obj = irec.GetDataObject() as VersionObjectInternal;
                obj.TableName = col.GetTableName();
                obj.VersionNumber = col.GetVersionNumber();
                InsertOrUpdateRecord(irec);
            }
        }

        private void InitializeDB(bool deleteExisting)
        {
            if( null == m_conn )
                throw new EveJournalDatabaseException();

            SQLiteCommand cmd = null;
            try
            {
                StringBuilder sql = new StringBuilder();

                foreach (IDBCollection col in m_Tables)
                    sql.Append(col.CreateBlankRecord().GetDBCreateTable() + ";");

                cmd = new SQLiteCommand(sql.ToString(), m_conn);
                cmd.ExecuteNonQuery();

                foreach (IDBCollection col in m_Tables)
                    MarkTableVersion(col);
            }
            finally
            {
                if (null != cmd)
                    cmd.Dispose();
            }
        }

        public DatabaseError ReadRecord(IDBCollection record)
        {
            m_ErrorCode = DatabaseError.NoError;
            SQLiteCommand sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();
            sqlite_cmd.CommandText = record.GetDBQuery();
            try
            {
                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                if (sqlite_datareader.Read())
                    record.FillRecords(sqlite_datareader);
                else
                    m_ErrorCode = DatabaseError.NoRecordsFound;
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                string msg = e.Message;
                m_ErrorCode = DatabaseError.ExceptionSQL;
            }
            return m_ErrorCode;
        }

        public DatabaseError InsertRecord(IDBRecord record)
        {
            m_ErrorCode = DatabaseError.NoError;
            SQLiteCommand sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();

            try
            {
                sqlite_cmd.CommandText = record.GetDBInsert();
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "SELECT last_insert_rowid();";
                record.SetValueString(record.GetIDQueryValue(), sqlite_cmd.ExecuteScalar());
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                string msg = e.Message;
                m_ErrorCode = DatabaseError.ExceptionSQL;
            }
            return m_ErrorCode;
        }

        // collection indexes will not be updated with this call
        public DatabaseError InsertRecord(IDBCollectionContents contents)
        {
            m_ErrorCode = DatabaseError.NoError;
            SQLiteCommand sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();

            for (int i = 0; i < contents.Count(); ++i)
            {
                try
                {
                    sqlite_cmd.CommandText = contents.GetRecordInterface(i).GetDBInsert();
                    sqlite_cmd.ExecuteNonQuery();
                }
                catch (System.Data.SQLite.SQLiteException e)
                {
                    m_ErrorCode = DatabaseError.ExceptionSQL;
                    Logger.ReportError(sqlite_cmd.CommandText);
                    Logger.ReportError(e.Message);
                }
            }
            return m_ErrorCode;
        }

        // collection indexes will not be updated with this call
        public DatabaseError InsertRecord(ProcessingDlg ExternDlg, IDBCollectionContents contents)
        {
            throw new NotSupportedException();

            //m_ErrorCode = DatabaseError.NoError;

            //ProcessingDlg dlg = null;
            //if (null == ExternDlg)
            //    dlg = new ProcessingDlg(this);
            //else
            //    dlg = ExternDlg;
            //InsertRecordThread irt = new InsertRecordThread();
            //irt.dlg = dlg;
            //irt.contents = contents;
            //irt.sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();
            //Thread tr = new Thread(new ThreadStart(irt.ThreadRun));

            //if (null == ExternDlg)
            //{
            //    dlg.m_Thread = tr;
            //    dlg.ShowDialog();
            //}
            //else
            //    tr.Start();

            //m_ErrorCode = irt.error;
            //return m_ErrorCode;
        }

        public DatabaseError UpdateRecord(IDBRecord record)
        {
            m_ErrorCode = DatabaseError.NoError;
            SQLiteCommand sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();
            try
            {
                sqlite_cmd.CommandText = record.GetDBUpdate();
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                string msg = e.Message;
                m_ErrorCode = DatabaseError.ExceptionSQL;
            }
            return m_ErrorCode;
        }

        public DatabaseError InsertOrUpdateRecord(IDBRecord record)
        {
            ulong val = ulong.Parse(record.GetValueString(record.GetIDQueryValue()));
            if (val == 0)
                InsertRecord(record);
            else
                UpdateRecord(record);
            return m_ErrorCode;
        }

        public DatabaseError InsertOrUpdateRecord(IDBCollectionContents contents)
        {
            for (int i = 0; i < contents.Count(); ++i)
            {
                IDBRecord irec = contents.GetRecordInterface(i);
                ulong val = ulong.Parse(irec.GetValueString(irec.GetIDQueryValue()));
                if (val == 0)
                    InsertRecord(irec);
                else
                    UpdateRecord(irec);
            }
            return m_ErrorCode;
        }

        public DatabaseError ExecuteCommand(string sql)
        {
            m_ErrorCode = DatabaseError.NoError;
            SQLiteCommand sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();
            try
            {
                sqlite_cmd.CommandText = sql;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                string msg = e.Message;
                m_ErrorCode = DatabaseError.ExceptionSQL;
            }
            return m_ErrorCode;
        }

        public DatabaseError ExecuteCommandWithResult(string sql, ref SQLiteDataReader reader)
        {
            m_ErrorCode = DatabaseError.NoError;
            SQLiteCommand sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();
            sqlite_cmd.CommandText = sql;
            try
            {
                reader = sqlite_cmd.ExecuteReader();
                if (!reader.Read())
                {
                    m_ErrorCode = DatabaseError.NoRecordsFound;
                    reader = null;
                }
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                string msg = e.Message;
                m_ErrorCode = DatabaseError.ExceptionSQL;
            }
            return m_ErrorCode;
        }

        public DatabaseError CreateTable(IDBRecord record)
        {
            return ExecuteCommand(record.GetDBCreateTable() + ";");
        }

        public DatabaseError Vacuum()
        {
            return ExecuteCommand("VACUUM");
        }

        // TEST CODE FUNCTIONS...................
        public DatabaseError TestRead(string sql)
        {
            m_ErrorCode = DatabaseError.NoError;
            SQLiteCommand sqlite_cmd = (SQLiteCommand)m_conn.CreateCommand();
            sqlite_cmd.CommandText = sql;
            try
            {
                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                if (sqlite_datareader.Read())
                {
                    do
                    {
                        for (int i = 0; i < sqlite_datareader.FieldCount; ++i)
                        {
                            string field = sqlite_datareader.GetName(i);
                            string value = sqlite_datareader.GetValue(i).ToString();
                            Console.WriteLine(field + " ==> " + value);
                        }
                    } while (sqlite_datareader.Read());
                }
                else
                    m_ErrorCode = DatabaseError.NoRecordsFound;
            }
            catch (System.Data.SQLite.SQLiteException e)
            {
                string msg = e.Message;
                m_ErrorCode = DatabaseError.ExceptionSQL;
            }
            return m_ErrorCode;
        }
    }
}

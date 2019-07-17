using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading;


namespace EVEJournal
{
    partial class Database
    {
        public class DatabaseCommand
        {
            public class dbParam
            {
                public long id;
                public object val;
                public dbParam(long id, object val)
                {
                    this.id = id;
                    this.val = val;
                }
            }

            protected bool bDisposed = false;
            protected DbCommand m_dbCommand;
            protected Dictionary<long, DbParameter> m_dbParams = 
                        new Dictionary<long, DbParameter>();
            
            public DatabaseCommand(SQLiteConnection conn)
            {
                m_dbCommand = conn.CreateCommand();
            }

            public void SetCommand(string cmd)
            {
                if( bDisposed )
                    throw new ObjectDisposedException(typeof(dbParam).FullName);

                m_dbCommand.CommandText = cmd;
            }

            public void AddParameter(long id)
            {
                if (bDisposed)
                    throw new ObjectDisposedException(typeof(dbParam).FullName);

                DbParameter Field1 = m_dbCommand.CreateParameter();
                m_dbCommand.Parameters.Add(Field1);
                m_dbParams[id] = Field1;
            }

            public void SetParamValue(long id, object value)
            {
                if (bDisposed)
                    throw new ObjectDisposedException(typeof(dbParam).FullName);

                m_dbParams[id].Value = value;
            }

            public void DBWrite()
            {
                if (bDisposed)
                    throw new ObjectDisposedException(typeof(dbParam).FullName);

                m_dbCommand.ExecuteNonQuery();
            }

            public void DBWrite(params dbParam[] vals)
            {
                bool bAddParam = ( 0 == m_dbParams.Count );
                foreach (dbParam par in vals)
                {
                    if (bAddParam)
                        AddParameter(par.id);
                    SetParamValue(par.id, par.val);
                }
                DBWrite();
            }

            public void DBWrite(string cmd, params dbParam[] vals)
            {
                SetCommand(cmd);
                DBWrite(vals);
            }

            bool Dispose()
            {
                if (bDisposed)
                    return false;
                m_dbCommand.Dispose();
                m_dbCommand = null;
                return (bDisposed = true);
            }
        }

        public class DatabaseBulkLoader
        {
            private bool bUsable = true;
            private DbTransaction dbTrans = null;
            private DbCommand dbCommand = null;
            private List<DbParameter> dbParams = new List<DbParameter>();

            public DatabaseBulkLoader(Database db)
            {
                dbTrans = db.m_conn.BeginTransaction();
                dbCommand = db.m_conn.CreateCommand();
            }

            public void SetCommand(string cmd)
            {
                if (!bUsable)
                    return;
                dbCommand.CommandText = cmd;
            }

            public void AddParameter(long num)
            {
                if (!bUsable)
                    return;

                for(;num > 0; --num)
                {
                    DbParameter Field1 = dbCommand.CreateParameter();
                    dbCommand.Parameters.Add(Field1);
                    dbParams.Add(Field1);
                }
            }

            public void SetParamValue(long which, object value)
            {
                if (!bUsable)
                    return;

                dbParams[(int)which].Value = value;
            }

            public void DBWrite()
            {
                if (!bUsable)
                    return;

                try
                {
                    dbCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string str = e.Message;
                    string str2 = str;
                }
            }

            public void DBWrite(params object[] vals)
            {
                if (!bUsable)
                    return;

                int num = 0;
                foreach (object obj in vals)
                    SetParamValue(num++, obj);
                DBWrite();
            }

            public void EndTransaction()
            {
                dbTrans.Commit();
                bUsable = false;
            }
        }       
 

    }
}

// Jacob

//Security and stability first, you should be using Paramaterized Queries. Robert has an excellent write-up here http://sqlite.phxsoftware.com/forums/t/83.aspx.

//If you want unique values in a table, use unique indexes. And to avoid an sql error when attempting to insert, use "insert or ignore".

//Notice below I create a table with 3 cols, 2 of which together are a unique index. I use insert or ignore and I do not get an error when I attempt to insert a duplicate. It silently fails. If you remove "or ignore" you will get an sqliteexception.

//C:\sqlite>sqlite3.exe testdb.db
//SQLite version 3.5.1
//Enter ".help" for instructions
//sqlite> create table people (lastname text, firstname text, salary double);
//sqlite> create unique index people_unique_1 on people (lastname, firstname);
//sqlite> insert or ignore into people values ('smith', 'john', 44548.33);
//sqlite> select * from people;
//smith|john|44548.33
//sqlite> insert or ignore into people values ('smith', 'john', 44548.33);
//sqlite> select * from people;
//smith|john|44548.33
//sqlite> insert or ignore into people values ('smith', 'linda', 44548.33);
//sqlite> select * from people;
//smith|john|44548.33
//smith|linda|44548.33
//sqlite> 

//if not exists (select 1 from tblEmployeeToDelegateMapping where EmployeeID=@EmployeeID and DelegateEmployeeID = @DelegateEmployeeID)
//begin
// INSERT INTO tblEmployeeToDelegateMapping
//                  (    
//                  EmployeeID,
//                  DelegateEmployeeID
//                  )
//            VALUES
//                  (
//                  @EmployeeID,
//                  @DelegateEmployeeID
//                  )

//end

//internal static void FastInsertMany(DbConnection cnn)
//{
//    using (DbTransaction dbTrans = cnn.BeginTransaction())
//    {
//        using (DbCommand cmd = cnn.CreateCommand())
//        {
//            cmd.CommandText = "INSERT INTO TestCase(MyValue) VALUES(?)";
//            DbParameter Field1 = cmd.CreateParameter();
//            cmd.Parameters.Add(Field1);
//            for (int n = 0; n < 100000; n++)
//            {
//            Field1.Value = n + 100000;
//            cmd.ExecuteNonQuery();
//            }
//        }
//        dbTrans.Commit();
//    }
//}
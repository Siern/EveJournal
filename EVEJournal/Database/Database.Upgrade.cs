using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;


namespace EVEJournal
{
    partial class Database
    {
        //private DatabaseError RepairVersion()
        //{
        //    IDBRecord rec = new Version();
        //    return ExecuteCommand("DROP TABLE Version;" +
        //        rec.GetDBCreateTable() +
        //        ";INSERT INTO Version (TableName) SELECT name FROM sqlite_master;UPDATE Version SET VersionNumber=1;");
        //}

        readonly static string DBUpgradeWarning =
            "{0}\r\n" +
            "Should a recovery/update be attempted?\r\n" +
            "\r\n" +
            "WARNING: Please be sure to backup your database file before proceeding.  " +
            "if your file is not backed up it is highly suggested that you cancel and " +
            "restart after backing up.";
        private DatabaseError RepairDatabaseVersion()
        {
            DatabaseError err = m_ErrorCode;
            if (err != DatabaseError.CheckFailed_IncorrectVersion &&
                err != DatabaseError.CheckFailed_Unidentifiable
              )
                return m_ErrorCode = DatabaseError.Unexpected;

            DialogResult ret = DialogResult.No;
            if (err == DatabaseError.CheckFailed_Unidentifiable)
                ret = MessageBox.Show(String.Format(DBUpgradeWarning, "Your database version was not reconized.\r\n"),
                                      "Upgrade Database Version?", MessageBoxButtons.YesNo);
            else
                ret = MessageBox.Show(String.Format(DBUpgradeWarning, "Your database version is out-of-date."),
                                      "Upgrade Database Version?", MessageBoxButtons.YesNo);

            if (ret != DialogResult.Yes)
                return m_ErrorCode = DatabaseError.UserAborted;

            if (err == DatabaseError.CheckFailed_Unidentifiable)
            {
                this.ExecuteCommand("DROP TABLE " + Version.TableName);
                Version v = new Version();
                CreateTable(v);
                ExecuteCommand(String.Format(
                    "INSERT INTO Version (TableName) SELECT name FROM sqlite_master; " +
                    "UPDATE Version SET VersionNumber=0; " +
                    "UPDATE Version SET VersionNumber={0} WHERE TableName='{1}'",
                    Version.VersionNumber, Version.TableName));
            }

            foreach (IDBCollection col in m_Tables)
            {
                VersionCollection vercol = new VersionCollection();
                IDBCollection ivercol = vercol as IDBCollection;
                ivercol.SetConstraint((long)Version.QueryValues.TableName,
                        new DBConstraint(DBConstraint.QueryConstraints.Equal, col.GetTableName()));
                DatabaseError colErr = ReadRecord(vercol);

                if (DatabaseError.NoError == colErr)
                {
                    IDBCollectionContents iconVercol = vercol as IDBCollectionContents;
                    IDBRecord rec = iconVercol.GetRecordInterface(0);
                    VersionObjectInternal obj = rec.GetDataObject() as VersionObjectInternal;
                    if (obj.VersionNumber == col.GetVersionNumber())
                    {
                        Logger.ReportNotice(String.Format("Table '{0}' version is up to date.", col.GetTableName()));
                    }
                    else
                    {
                        Logger.ReportNotice(String.Format("Table '{0}' version mismatch ({1}!={2}). Recreating",
                            col.GetTableName(), obj.VersionNumber, col.GetVersionNumber()));
                        IDBUpgrade icolUpgrade = col as IDBUpgrade;
                        colErr = icolUpgrade.Upgrade(this, obj.VersionNumber);
                        if (colErr != DatabaseError.NoError)
                            return m_ErrorCode = DatabaseError.Unexpected;
                        obj.VersionNumber = col.GetVersionNumber();
                        this.UpdateRecord(rec);
                    }

                }
                else if (DatabaseError.NoRecordsFound == colErr)
                {
                    Logger.ReportNotice(String.Format("Table '{0}' missing. Creating new", col.GetTableName()));
                    colErr = this.CreateTable(col.CreateBlankRecord());
                    if (colErr != DatabaseError.NoError)
                        return m_ErrorCode = DatabaseError.Unexpected;

                    IDBRecord rec = ivercol.CreateBlankRecord();
                    VersionObjectInternal obj = rec.GetDataObject() as VersionObjectInternal;
                    obj.TableName = col.GetTableName();
                    obj.VersionNumber = col.GetVersionNumber();
                    InsertRecord(rec);
                }
                else
                    return m_ErrorCode = DatabaseError.Unexpected;
            }

            return m_ErrorCode = DatabaseError.NoError;
        }

    }
}

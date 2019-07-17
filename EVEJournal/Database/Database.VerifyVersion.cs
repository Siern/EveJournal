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
        private DatabaseError CheckVersion()
        {
            VersionCollection ver = new VersionCollection();
            IDBCollection icol = ver as IDBCollection;
            icol.SetConstraint((long)Version.QueryValues.TableName,
                        new DBConstraint(DBConstraint.QueryConstraints.Equal, "Version"));
            DatabaseError err = ReadRecord(icol);
            if (DatabaseError.NoRecordsFound == err || DatabaseError.ExceptionSQL == err)
                return m_ErrorCode = DatabaseError.CheckFailed_Unidentifiable;

            IDBCollectionContents icolcon = ver as IDBCollectionContents;
            VersionObject vobj = icolcon.GetRecordInterface(0).GetDataObject() as VersionObject;
            if (vobj.VersionNumber != Version.VersionNumber)
                return m_ErrorCode = DatabaseError.CheckFailed_IncorrectVersion;
            return m_ErrorCode = DatabaseError.NoError;
        }

        //private DatabaseError CheckVersion()
        //{
        //    VersionCollection ver = new VersionCollection();
        //    IDBCollection vcol = ver;
            
        //    DatabaseError err = this.ExecuteCommand(
        //        "SELECT name FROM sqlite_master WHERE name='" + vcol.GetTableName() +
        //        "' AND sql='" + vcol.CreateBlankRecord().GetDBCreateTable() + "';");

        //    if (DatabaseError.NoRecordsFound == err)
        //        return DatabaseError.CheckFailed_VersionMissing;
        //    else if (DatabaseError.NoError != err)
        //        return DatabaseError.CheckFailed_UnknownReason;

        //    err = this.ReadRecord(vcol);
        //    if (DatabaseError.NoRecordsFound == err)
        //        return DatabaseError.CheckFailed_VersionMissing;
        //    else if (DatabaseError.NoError != err)
        //        return DatabaseError.CheckFailed_UnknownReason;

        //    IDBCollectionContents vcon = ver;
        //    if (m_Tables.Length != vcon.Count())
        //        return DatabaseError.CheckFailed_TableMissing;

        //    foreach (IDBCollection col in m_Tables)
        //    {
        //        for (int i = 0; i < vcon.Count(); ++i)
        //        {
        //            VersionObject obj = vcon.GetRecordInterface(i).GetDataObject() as VersionObject;
        //            if( null == obj )
        //                return DatabaseError.CheckFailed_UnknownReason;

        //            if (0 == obj.TableName.CompareTo(col.GetTableName()))
        //            {
        //                if (obj.VersionNumber != col.GetVersionNumber())
        //                    return DatabaseError.CheckFailed_TableVersion;
        //            }
        //        }
                
        //        err = this.ExecuteCommand(
        //            "SELECT name FROM sqlite_master WHERE name='" +
        //            col.GetTableName() + "' AND sql ='" + 
        //            col.CreateBlankRecord().GetDBCreateTable() + "';");
        //        if (DatabaseError.NoRecordsFound == err)
        //            return DatabaseError.CheckFailed_TableDefintion;
        //        else if (DatabaseError.NoError != err)
        //            return DatabaseError.CheckFailed_UnknownReason; 
        //    }

        //    return DatabaseError.NoError;
        //}

        //private readonly string[] m_CheckPrompt =
        //{
        //    "Database is not valid.  Cause is unknown.",
        //    "Database's version information is missing or corrupt.",
        //    "Database is missing 1 or more tables.",
        //    "One or more database tables' version is out-of-date.",
        //    "One or more database tables' definition is incorrect.",
        //};

        //private readonly string[] m_CheckPromptExplain =
        //{
        //    "\n\nClicking Yes will result in an attempt to upgrade the DB.  NOTE: this will not backup DB prior to updating." +
        //        "\nClicking No will result in exit of application without upgrade",
        //    "\n\nApplication will now exit!",
        //};

        //private bool QueryToUpgrade(DatabaseError err)
        //{
        //    DialogResult ret = MessageBox.Show(
        //        m_CheckPrompt[(int)err-(int)DatabaseError.CheckFailed_UnknownReason] + 
        //        m_CheckPromptExplain[(DatabaseError.CheckFailed_UnknownReason == err)?1:0],
        //        "Database In Need Of Upgrade",
        //        (DatabaseError.CheckFailed_UnknownReason == err)?MessageBoxButtons.OK:MessageBoxButtons.YesNo);
        //    return (DialogResult.Yes == ret);
        //}
    }
}
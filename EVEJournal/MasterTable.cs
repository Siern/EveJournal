using System;
using System.Data.SQLite;

namespace EVEJournal
{

    public class DBMasterTable : IDBRecord, IDBRecordRead
    {
        public static string TableDefinition = ""; // Do Not Create this
        public static string TableName = "sqlite_master";

        public enum QueryValues : long
        {
        }

        string IDBRecord.GetFieldName(long which)
        {
            throw new NotImplementedException();
        }

        static protected string GetFieldName(QueryValues which)
        {
            throw new NotImplementedException();
        }

        string IDBRecord.TranslateQueryValue(long which)
        {
            throw new NotImplementedException();
        }

        object IDBRecord.GetDataObject()
        {
            return null;
        }

        RecordKey IDBRecord.GetRecordKey()
        {
            return null;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
        }

        string IDBRecord.GetDBCreateTable()
        {
            throw new NotImplementedException();
        }

        void IDBRecord.PrepareCommandInsert(Database.DatabaseCommand dbCommand)
        {
            throw new NotImplementedException();
        }

        void IDBRecord.FillCommandInsert(Database.DatabaseCommand dbCommand)
        {
            throw new NotImplementedException();
        }

        void IDBRecord.PrepareCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            throw new NotImplementedException();
        }

        void IDBRecord.FillCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            throw new NotImplementedException();
        }

        void IDBRecord.PrepareCommandDelete(Database.DatabaseCommand dbCommand)
        {
            throw new NotImplementedException();
        }

        void IDBRecord.FillCommandDelete(Database.DatabaseCommand dbCommand)
        {
            throw new NotImplementedException();
        }

        public DBMasterTable()
        {
        }

        public DBMasterTable(SQLiteDataReader reader)
        {
        }
    }

}
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Xml;

//CREATE TABLE Version (
//  TableName      nvarchar(50) PRIMARY KEY NOT NULL,
//  VersionNumber  integer NOT NULL DEFAULT 0
//);

namespace EVEJournal
{
    class Version : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4} ",
                // key
                GetFieldName(QueryValues.TableName), ColumnType.TXTKEY,
                // data
                GetFieldName(QueryValues.VersionNumber), ColumnType.INT);

        public static readonly string TableName = "Version";
        public static readonly long VersionNumber = 2;


        private VersionObjectInternal m_DataObject = 
            new VersionObjectInternal();

        public enum QueryValues : long
        {
            // key
            TableName,
            // data
            VersionNumber,
        }

        string IDBRecord.GetFieldName(long which)
        {
            return GetFieldName((QueryValues)which);
        }

        static protected string GetFieldName(QueryValues which)
        {
            return "fld_" + which.ToString();
        }

        string IDBRecord.TranslateQueryValue(long which)
        {
            return ((QueryValues)which).ToString();
        }

        object IDBRecord.GetDataObject()
        {
            return m_DataObject as object;
        }

        RecordKey IDBRecord.GetRecordKey()
        {
            return m_DataObject.Key as RecordKey;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                // key
                case QueryValues.TableName:
                    throw new NotSupportedException();
                // data
                case QueryValues.VersionNumber:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                // key
                case QueryValues.TableName:
                    m_DataObject.TableName = DBConvert.ToString(obj);
                    return;
                // data
                case QueryValues.VersionNumber:
                    m_DataObject.VersionNumber = DBConvert.ToLong(obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        string IDBRecord.GetDBCreateTable()
        {
            if (null == TableName)
                throw new NullReferenceException();
            return String.Format("CREATE TABLE {0} ({1})",
                TableName, TableDefinition);
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

        public Version()
        { 
        }

        public Version(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }
    }
}

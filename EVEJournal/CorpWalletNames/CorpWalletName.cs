using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

namespace EVEJournal
{
    partial class CorpWalletName : IDBRecord
    {
        //Name0,Name1,Name2,Name3,Name4,Name5,Name6
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, " +
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.Name0), ColumnType.TXT,
                GetFieldName(QueryValues.Name1), ColumnType.TXT,
                GetFieldName(QueryValues.Name2), ColumnType.TXT,
                GetFieldName(QueryValues.Name3), ColumnType.TXT,

                GetFieldName(QueryValues.Name4), ColumnType.TXT,
                GetFieldName(QueryValues.Name5), ColumnType.TXT,
                GetFieldName(QueryValues.Name6), ColumnType.TXT);

        public static readonly string TableName = "CorpWalletName";
        public static readonly long VersionNumber = 2;

        CorpWalletNameObjectInternal m_DataObject = 
            new CorpWalletNameObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            // data
            Name0,
            Name1,
            Name2,
            Name3,
            Name4,
            Name5,
            Name6,
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
                case QueryValues.CorpID:
                    throw new NotSupportedException();

                // data
                case QueryValues.Name0:
                case QueryValues.Name1:
                case QueryValues.Name2:
                case QueryValues.Name3:
                case QueryValues.Name4:
                case QueryValues.Name5:
                case QueryValues.Name6:
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
                case QueryValues.CorpID:
                    m_DataObject.CorpID = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.Name0:
                    m_DataObject.Name0 = DBConvert.ToString(obj);
                    return;
                case QueryValues.Name1:
                    m_DataObject.Name1 = DBConvert.ToString(obj);
                    return;
                case QueryValues.Name2:
                    m_DataObject.Name2 = DBConvert.ToString(obj);
                    return;
                case QueryValues.Name3:
                    m_DataObject.Name3 = DBConvert.ToString(obj);
                    return;
                case QueryValues.Name4:
                    m_DataObject.Name4 = DBConvert.ToString(obj);
                    return;
                case QueryValues.Name5:
                    m_DataObject.Name5 = DBConvert.ToString(obj);
                    return;
                case QueryValues.Name6:
                    m_DataObject.Name6 = DBConvert.ToString(obj);
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

        public CorpWalletName()
        {
        }

        public CorpWalletName(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        //public CorpWalletName(string CorpID, XmlNode xmlNode)
        //{
        //    this.m_DataObject.CorpID = long.Parse(CorpID);
        //    // should log hitting here as an error
        //}

        public CorpWalletName(long key, CorpWalletNameObjectWritable obj)
        {

            m_DataObject.CorpID = key;
            m_DataObject.Name0 = obj.Name0;
            m_DataObject.Name1 = obj.Name1;
            m_DataObject.Name2 = obj.Name2;
            m_DataObject.Name3 = obj.Name3;
            m_DataObject.Name4 = obj.Name4;
            m_DataObject.Name5 = obj.Name5;
            m_DataObject.Name6 = obj.Name6;
        }

    }
}
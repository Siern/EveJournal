using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpAccountBalances (
//  fld_CorpID      integer NOT NULL,
//  fld_AccountKey  integer NOT NULL,
//  fld_AccountID   integer,
//  fld_balance     real,
//  PRIMARY KEY (fld_CorpID, fld_AccountKey)
//);

namespace EVEJournal
{
    partial class CorpAccountBalances : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}" +
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.AccountKey), ColumnType.INTnNULL,
                // data
                GetFieldName(QueryValues.AccountID), ColumnType.INT,
                GetFieldName(QueryValues.balance), ColumnType.INT,
                "PRIMARY KEY (fld_CorpID, fld_AccountKey)");

        public static readonly string TableName = "CorpAccountBalances";
        public static readonly long VersionNumber = 2;

        CorpAccountBalancesObjectInternal m_DataObject = 
            new CorpAccountBalancesObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            AccountKey,
            // data
            AccountID,
            balance,
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
            return m_DataObject;
        }

        RecordKey IDBRecord.GetRecordKey()
        {
            return m_DataObject.Key as RecordKey;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.CorpID:
                case QueryValues.AccountKey:
                    throw new NotSupportedException();

                case QueryValues.AccountID:
                case QueryValues.balance:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                case QueryValues.CorpID:
                    m_DataObject.CorpID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.AccountKey:
                    m_DataObject.AccountKey = DBConvert.ToLong(obj);
                    return;
                case QueryValues.AccountID:
                    m_DataObject.AccountID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.balance:
                    m_DataObject.balance = DBConvert.ToLong(obj);
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

        public CorpAccountBalances()
        {
        }

        public CorpAccountBalances(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpAccountBalances(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpAccountBalances(CorpAccountBalancesObject obj)
        {
            m_DataObject = (CorpAccountBalancesObjectInternal)obj;
        }
    }
}

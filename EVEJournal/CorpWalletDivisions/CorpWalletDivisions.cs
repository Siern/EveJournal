using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpWalletDivisions (
//  fld_CorpID       integer NOT NULL,
//  fld_AccountKey   integer NOT NULL,
//  fld_description  nvarchar(50),
//  PRIMARY KEY (fld_CorpID, fld_AccountKey)
//);

namespace EVEJournal
{
    partial class CorpWalletDivisions : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6} " +
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.AccountKey), ColumnType.INTnNULL,
                // data
                GetFieldName(QueryValues.description), ColumnType.TXT,
                "PRIMARY KEY (fld_CorpID, fld_AccountKey)");

        public static readonly string TableName = "CorpWalletDivisions";
        public static readonly long VersionNumber = 2;

        CorpWalletDivisionsObjectInternal m_DataObject = 
            new CorpWalletDivisionsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            AccountKey,
            // data
            description,
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
                case QueryValues.AccountKey:
                    throw new NotSupportedException();

                // data
                case QueryValues.description:
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
                case QueryValues.AccountKey:
                    m_DataObject.AccountKey = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.description:
                    m_DataObject.description = DBConvert.ToString(obj);
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

        public CorpWalletDivisions()
        {
        }

        public CorpWalletDivisions(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpWalletDivisions(string aCorpID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = long.Parse(aCorpID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpWalletDivisions(CorpWalletDivisionsObject obj)
        {
            m_DataObject = (CorpWalletDivisionsObjectInternal)obj;
        }
    }
}

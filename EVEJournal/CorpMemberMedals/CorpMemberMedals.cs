using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpMemberMedals (
//  fld_CorpID    integer NOT NULL,
//  fld_MedalID   integer NOT NULL,
//  fld_CharID    integer NOT NULL,
//  fld_reason    nvarchar(50),
//  fld_status    nvarchar(50),
//  fld_issuerID  integer,
//  fld_issued    datetime,
//  PRIMARY KEY (fld_CorpID, fld_MedalID, fld_CharID)
//);

namespace EVEJournal
{
    partial class CorpMemberMedals : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} ",
            // key
            GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.MedalID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.CharID), ColumnType.INTnNULL,
            // data
            GetFieldName(QueryValues.reason), ColumnType.TXT,
            GetFieldName(QueryValues.status), ColumnType.TXT,

            GetFieldName(QueryValues.issuerID), ColumnType .INT,
            GetFieldName(QueryValues.issued), ColumnType .DT,
            "PRIMARY KEY (fld_CorpID, fld_MedalID, fld_CharID)");

        public static readonly string TableName = "CorpMemberMedals";
        public static readonly long VersionNumber = 2;

        CorpMemberMedalsObjectInternal m_DataObject = 
            new CorpMemberMedalsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            MedalID,
            CharID,
            // data
            reason,
            status,
            issuerID,
            issued,
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
                case QueryValues.MedalID:
                case QueryValues.CharID:
                    throw new NotSupportedException();

                // data
                case QueryValues.reason:
                case QueryValues.status:
                case QueryValues.issuerID:
                case QueryValues.issued:
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
                case QueryValues.MedalID:
                    m_DataObject.MedalID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.reason:
                    m_DataObject.reason = DBConvert.ToString(obj);
                    return;
                case QueryValues.status:
                    m_DataObject.status = DBConvert.ToString(obj);
                    return;
                case QueryValues.issuerID:
                    m_DataObject.issuerID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.issued:
                    m_DataObject.issued = DBConvert.ToDateTime(obj);
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

        public CorpMemberMedals()
        {
        }

        public CorpMemberMedals(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpMemberMedals(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpMemberMedals(CorpMemberMedalsObject obj)
        {
            m_DataObject = (CorpMemberMedalsObjectInternal)obj;
        }
    }
}

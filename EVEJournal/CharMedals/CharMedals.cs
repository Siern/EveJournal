using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharMedals (
//  fld_CharID         integer NOT NULL,
//  fld_MedalID        integer NOT NULL,
//  fld_issuerID       integer,
//  fld_corporationID  integer,
//  fld_issued         datetime,
//  fld_reason         nvarchar(50),
//  fld_status         nvarchar(50),
//  fld_title          nvarchar(50),
//  fld_description    nvarchar(50),
//  PRIMARY KEY (fld_CharID, fld_MedalID)
//);

namespace EVEJournal
{
    partial class CharMedals : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17},  {18}" +
            // key
            GetFieldName(QueryValues.CharID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.MedalID), ColumnType.INTnNULL,
            // data
            GetFieldName(QueryValues.issuerID), ColumnType.INT,
            GetFieldName(QueryValues.corporationID), ColumnType.INT,
            GetFieldName(QueryValues.issued), ColumnType.DT,

            GetFieldName(QueryValues.reason), ColumnType.TXT,
            GetFieldName(QueryValues.status), ColumnType.TXT,
            GetFieldName(QueryValues.title), ColumnType.TXT,
            GetFieldName(QueryValues.description), ColumnType.TXT,
            "PRIMARY KEY (fld_CharID, fld_MedalID)");

        public static readonly string TableName = "CharMedals";
        public static readonly long VersionNumber = 2;

        CharMedalsObjectInternal m_DataObject = 
            new CharMedalsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CharID,
            MedalID,
            // data
            issuerID,
            corporationID,
            issued,
            reason,
            status,
            title,
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
                case QueryValues.CharID:
                case QueryValues.MedalID:
                    throw new NotSupportedException();

                case QueryValues.issuerID:
                case QueryValues.corporationID:
                case QueryValues.issued:
                case QueryValues.reason:
                case QueryValues.status:
                case QueryValues.title:
                case QueryValues.description:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.MedalID:
                    m_DataObject.MedalID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.issuerID:
                    m_DataObject.issuerID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.corporationID:
                    m_DataObject.corporationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.issued:
                    m_DataObject.issued = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.reason:
                    m_DataObject.reason = DBConvert.ToString(obj);
                    return;
                case QueryValues.status:
                    m_DataObject.status = DBConvert.ToString(obj);
                    return;
                case QueryValues.title:
                    m_DataObject.title = DBConvert.ToString(obj);
                    return;
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

        public CharMedals()
        {
        }

        public CharMedals(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharMedals(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharMedals(CharMedalsObject obj)
        {
            m_DataObject = (CharMedalsObjectInternal)obj;
        }
    }
}



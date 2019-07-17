using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpMedals (
//  fld_CorpID       integer NOT NULL,
//  fld_MedalID      integer NOT NULL,
//  fld_title        nvarchar(50),
//  fld_description  nvarchar(50),
//  fld_creatorID    integer,
//  fld_created      datetime,
//  PRIMARY KEY (fld_CorpID, fld_MedalID)
//);

namespace EVEJournal
{
    partial class CorpMedals : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} " +
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.MedalID), ColumnType.INTnNULL,
                // data
                GetFieldName(QueryValues.title), ColumnType.TXT,
                GetFieldName(QueryValues.description), ColumnType.TXT,
                GetFieldName(QueryValues.creatorID), ColumnType.INT,

                GetFieldName(QueryValues.created), ColumnType.DT,
                "PRIMARY KEY (fld_CorpID, fld_MedalID)");

        public static readonly string TableName = "CorpMedals";
        public static readonly long VersionNumber = 2;

        CorpMedalsObjectInternal m_DataObject = 
            new CorpMedalsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            MedalID,
            // data
            title,
            description,
            creatorID,
            created,
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
                    throw new NotSupportedException();

                // data
                case QueryValues.title:
                case QueryValues.description:
                case QueryValues.creatorID:
                case QueryValues.created:
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
                // data
                case QueryValues.title:
                    m_DataObject.title = DBConvert.ToString(obj);
                    return;
                case QueryValues.description:
                    m_DataObject.description = DBConvert.ToString(obj);
                    return;
                case QueryValues.creatorID:
                    m_DataObject.creatorID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.created:
                    m_DataObject.created = DBConvert.ToDateTime(obj);
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

        public CorpMedals()
        {
        }

        public CorpMedals(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpMedals(string aCorpID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = long.Parse(aCorpID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpMedals(CorpMedalsObject obj)
        {
            m_DataObject = (CorpMedalsObjectInternal)obj;
        }
    }
}

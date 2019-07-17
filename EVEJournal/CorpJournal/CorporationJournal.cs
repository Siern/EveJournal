using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpJournal (
//  fld_CorpID      integer NOT NULL,
//  fld_Division    integer NOT NULL,
//  fld_date        datetime NOT NULL,
//  fld_refID       integer NOT NULL,
//  fld_ownerID1    integer NOT NULL,
//  fld_ownerID2    integer NOT NULL,
//  fld_argID1      integer NOT NULL,
//  fld_refTypeID   integer,
//  fld_ammount     real,
//  fld_balance     real,
//  fld_ownerName1  nvarchar(50),
//  fld_ownerName2  nvarchar(50),
//  fld_argName1    nvarchar(50),
//  fld_reason      nvarchar(50),
//  PRIMARY KEY (fld_CorpID, fld_Division, fld_date, fld_refID, fld_ownerID1, fld_ownerID2, fld_argID1)
//);

namespace EVEJournal
{
    partial class CorporationJournal : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} ",
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.Division), ColumnType.INTnNULL,
                GetFieldName(QueryValues.date), ColumnType.DTnNULL,
                GetFieldName(QueryValues.refID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.ownerID1), ColumnType.INTnNULL,

                GetFieldName(QueryValues.ownerID2), ColumnType.INTnNULL,
                GetFieldName(QueryValues.argID), ColumnType.INTnNULL,
                // data
                GetFieldName(QueryValues.refTypeID), ColumnType.INT,
                GetFieldName(QueryValues.amount), ColumnType.DEC,
                GetFieldName(QueryValues.balance), ColumnType.DEC,

                GetFieldName(QueryValues.ownerName1), ColumnType.TXT,
                GetFieldName(QueryValues.ownerName2), ColumnType.TXT,
                GetFieldName(QueryValues.argName1), ColumnType.TXT,
                GetFieldName(QueryValues.reason), ColumnType.TXT,
                "PRIMARY KEY (fld_CorpID, fld_Division, fld_date, fld_refID, fld_ownerID1, fld_ownerID2, fld_argID1)");

        public static readonly string TableName = "CorpJournal";
        public static readonly long VersionNumber = 2;

        CorporationJournalObjectInternal m_DataObject = 
            new CorporationJournalObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            Division,
            date,
            refID,
            ownerID1,
            ownerID2,
            argID,
            // data
            refTypeID,
            ownerName1,
            ownerName2,
            argName1,
            amount,
            balance,
            reason,
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
                case QueryValues.Division:
                case QueryValues.date:
                case QueryValues.refID:
                case QueryValues.ownerID1:
                case QueryValues.ownerID2:
                case QueryValues.argID:
                    throw new NotSupportedException();

                // data
                case QueryValues.refTypeID:
                case QueryValues.ownerName1:
                case QueryValues.ownerName2:
                case QueryValues.argName1:
                case QueryValues.amount:
                case QueryValues.balance:
                case QueryValues.reason:
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
                case QueryValues.Division:
                    m_DataObject.Division = DBConvert.ToLong(obj);
                    return;
                case QueryValues.date:
                    m_DataObject.date = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.refID:
                    m_DataObject.refID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ownerID1:
                    m_DataObject.ownerID1 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ownerID2:
                    m_DataObject.ownerID2 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.argID:
                    m_DataObject.argID = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.refTypeID:
                    m_DataObject.refTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ownerName1:
                    m_DataObject.ownerName1 = DBConvert.ToString(obj);
                    return;
                case QueryValues.ownerName2:
                    m_DataObject.ownerName2 = DBConvert.ToString(obj);
                    return;
                case QueryValues.argName1:
                    m_DataObject.argName1 = DBConvert.ToString(obj);
                    return;
                case QueryValues.amount:
                    m_DataObject.amount = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.balance:
                    m_DataObject.balance = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.reason:
                    m_DataObject.reason = DBConvert.ToString(obj);
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

        public CorporationJournal()
        {
        }

        public CorporationJournal(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorporationJournal(long CorpID, long Division, XmlNode xmlNode)
        {
            this.m_DataObject.CorpID = CorpID;
            this.m_DataObject.Division = Division;

            this.m_DataObject.date = DBConvert.FromCCPTime(xmlNode.Attributes["date"].InnerText);
            this.m_DataObject.refID = long.Parse(xmlNode.Attributes["refID"].InnerText);
            this.m_DataObject.refTypeID = long.Parse(xmlNode.Attributes["refTypeID"].InnerText);
            this.m_DataObject.ownerName1 = xmlNode.Attributes["ownerName1"].InnerText;
            this.m_DataObject.ownerID1 = long.Parse(xmlNode.Attributes["ownerID1"].InnerText);
            this.m_DataObject.ownerName2 = xmlNode.Attributes["ownerName2"].InnerText;
            this.m_DataObject.ownerID2 = long.Parse(xmlNode.Attributes["ownerID2"].InnerText);
            this.m_DataObject.argName1 = xmlNode.Attributes["argName1"].InnerText;
            this.m_DataObject.argID = long.Parse(xmlNode.Attributes["argID1"].InnerText);
            this.m_DataObject.amount = decimal.Parse(xmlNode.Attributes["amount"].InnerText);
            this.m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
            this.m_DataObject.reason = xmlNode.Attributes["reason"].InnerText;
        }
    }
}
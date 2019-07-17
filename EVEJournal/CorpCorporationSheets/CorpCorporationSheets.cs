using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpCorporationSheets (
//  fld_CorpID         integer PRIMARY KEY NOT NULL,
//  fld_ceoID          integer,
//  fld_stationID      integer,
//  fld_allianceID     integer,
//  fld_memberCount    integer,
//  fld_memberLimit    integer,
//  fld_shares         integer,
//  fld_logoGraphicID  integer,
//  fld_logoShape1     integer,
//  fld_logoShape2     integer,
//  fld_logoShape3     integer,
//  fld_logoColor1     integer,
//  fld_logoColor2     integer,
//  fld_logoColor3     integer
//  fld_taxRate        real,
//  fld_CorpName       nvarchar(50),
//  fld_ticker         nvarchar(50),
//  fld_ceoName        nvarchar(50),
//  fld_stationName    nvarchar(50),
//  fld_description    nvarchar(50),
//  fld_url            nvarchar(50),
//  fld_allianceName   nvarchar(50),
//);

namespace EVEJournal
{
    partial class CorpCorporationSheets : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                          "{30} {31}, {32} {33}, {34} {35}, {36} {37}, {38} {39}, " +
                          "{40} {41}, {42} {43}, ",
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.ceoID), ColumnType.INT,
                GetFieldName(QueryValues.stationID), ColumnType.INT,
                GetFieldName(QueryValues.allianceID), ColumnType.INT,
                GetFieldName(QueryValues.memberCount), ColumnType.INT,

                GetFieldName(QueryValues.memberLimit), ColumnType.INT,
                GetFieldName(QueryValues.shares), ColumnType.INT,
                GetFieldName(QueryValues.logoGraphicID), ColumnType.INT,
                GetFieldName(QueryValues.logoShape1), ColumnType.INT,
                GetFieldName(QueryValues.logoShape2), ColumnType.INT,

                GetFieldName(QueryValues.logoShape3), ColumnType.INT,
                GetFieldName(QueryValues.logoColor1), ColumnType.INT,
                GetFieldName(QueryValues.logoColor2), ColumnType.INT,
                GetFieldName(QueryValues.logoColor3), ColumnType.INT,
                GetFieldName(QueryValues.taxRate), ColumnType.DEC,

                GetFieldName(QueryValues.CorpName), ColumnType.TXT,
                GetFieldName(QueryValues.ticker), ColumnType.TXT,
                GetFieldName(QueryValues.ceoName), ColumnType.TXT,
                GetFieldName(QueryValues.stationName), ColumnType.TXT,
                GetFieldName(QueryValues.description), ColumnType.TXT,

                GetFieldName(QueryValues.url), ColumnType.TXT,
                GetFieldName(QueryValues.allianceName), ColumnType.TXT);

        public static readonly string TableName = "CorpCorporationSheets";
        public static readonly long VersionNumber = 2;

        CorpCorporationSheetsObjectInternal m_DataObject = 
            new CorpCorporationSheetsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            // data
            ceoID,
            stationID,
            allianceID,
            memberCount,
            memberLimit,
            shares,
            logoGraphicID,
            logoShape1,
            logoShape2,
            logoShape3,
            logoColor1,
            logoColor2,
            logoColor3,
            taxRate,
            CorpName,
            ticker,
            ceoName,
            stationName,
            description,
            url,
            allianceName,
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
                case QueryValues.ceoID:
                case QueryValues.stationID:
                case QueryValues.allianceID:
                case QueryValues.memberCount:
                case QueryValues.memberLimit:
                case QueryValues.shares:
                case QueryValues.logoGraphicID:
                case QueryValues.logoShape1:
                case QueryValues.logoShape2:
                case QueryValues.logoShape3:
                case QueryValues.logoColor1:
                case QueryValues.logoColor2:
                case QueryValues.logoColor3:
                case QueryValues.taxRate:
                case QueryValues.CorpName:
                case QueryValues.ticker:
                case QueryValues.ceoName:
                case QueryValues.stationName:
                case QueryValues.description:
                case QueryValues.url:
                case QueryValues.allianceName:
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
                case QueryValues.ceoID:
                    m_DataObject.ceoID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.stationID:
                    m_DataObject.stationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.allianceID:
                    m_DataObject.allianceID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.memberCount:
                    m_DataObject.memberCount = DBConvert.ToLong(obj);
                    return;
                case QueryValues.memberLimit:
                    m_DataObject.memberLimit = DBConvert.ToLong(obj);
                    return;
                case QueryValues.shares:
                    m_DataObject.shares = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logoGraphicID:
                    m_DataObject.logoGraphicID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logoShape1:
                    m_DataObject.logoShape1 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logoShape2:
                    m_DataObject.logoShape2 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logoShape3:
                    m_DataObject.logoShape3 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logoColor1:
                    m_DataObject.logoColor1 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logoColor2:
                    m_DataObject.logoColor2 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logoColor3:
                    m_DataObject.logoColor3 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.taxRate:
                    m_DataObject.taxRate = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.CorpName:
                    m_DataObject.CorpName = DBConvert.ToString(obj);
                    return;
                case QueryValues.ticker:
                    m_DataObject.ticker = DBConvert.ToString(obj);
                    return;
                case QueryValues.ceoName:
                    m_DataObject.ceoName = DBConvert.ToString(obj);
                    return;
                case QueryValues.stationName:
                    m_DataObject.stationName = DBConvert.ToString(obj);
                    return;
                case QueryValues.description:
                    m_DataObject.description = DBConvert.ToString(obj);
                    return;
                case QueryValues.url:
                    m_DataObject.url = DBConvert.ToString(obj);
                    return;
                case QueryValues.allianceName:
                    m_DataObject.allianceName = DBConvert.ToString(obj);
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

        public CorpCorporationSheets()
        {
        }

        public CorpCorporationSheets(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpCorporationSheets(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpCorporationSheets(CorpCorporationSheetsObject obj)
        {
            m_DataObject = (CorpCorporationSheetsObjectInternal)obj;
        }
    }
}

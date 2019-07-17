using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpTransactions (
//  fld_CorpID           integer NOT NULL,
//  fld_AccountKey       integer NOT NULL,
//  fld_date             datetime NOT NULL,
//  fld_transID          integer NOT NULL,
//  fld_stationID        integer NOT NULL,
//  quantity             integer,
//  fld_typeName         nvarchar(50),
//  fld_typeID           integer,
//  fld_price            real,
//  fld_clientID         integer,
//  fld_ClientName       nvarchar(50),
//  fld_CharName         nvarchar(50),
//  fld_stationName      nvarchar(50),
//  fld_transactionType  nvarchar(50),
//  fld_transactionFor   nvarchar(50),
//  PRIMARY KEY (fld_CorpID, fld_AccountKey, fld_date, fld_transID, fld_stationID)
//);

namespace EVEJournal
{
    partial class CorporationTransaction : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, ",
            // key
            GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.AccountKey), ColumnType.INTnNULL,
            GetFieldName(QueryValues.date), ColumnType.DTnNULL,
            GetFieldName(QueryValues.transID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.stationID), ColumnType.INTnNULL,

            // data
            GetFieldName(QueryValues.quantity), ColumnType.INT,
            GetFieldName(QueryValues.typeName), ColumnType.TXT,
            GetFieldName(QueryValues.typeID), ColumnType.INT,
            GetFieldName(QueryValues.price), ColumnType.DEC,
            GetFieldName(QueryValues.clientID), ColumnType.INT,

            GetFieldName(QueryValues.clientName), ColumnType.TXT,
            GetFieldName(QueryValues.stationName), ColumnType.TXT,
            GetFieldName(QueryValues.transactionType), ColumnType.TXT,
            GetFieldName(QueryValues.transactionFor), ColumnType.TXT);

        public static readonly string TableName = "CorpTrans";
        public static readonly long VersionNumber = 2;

        private CorporationTransactionObjectInternal m_DataObject = 
            new CorporationTransactionObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            AccountKey,
            date,
            transID,
            stationID,
            // data
            quantity,
            typeName,
            typeID,
            price,
            clientID,
            clientName,
            stationName,
            transactionType,
            transactionFor,
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
                case QueryValues.date:
                case QueryValues.transID:
                case QueryValues.stationID:
                    throw new NotSupportedException();

                // data
                case QueryValues.quantity:
                case QueryValues.typeName:
                case QueryValues.typeID:
                case QueryValues.price:
                case QueryValues.clientID:
                case QueryValues.clientName:
                case QueryValues.stationName:
                case QueryValues.transactionType:
                case QueryValues.transactionFor:
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
                    m_DataObject.Division = DBConvert.ToLong(obj);
                    return;
                case QueryValues.date:
                    m_DataObject.date = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.transID:
                    m_DataObject.transID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.stationID:
                    m_DataObject.stationID = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.quantity:
                    m_DataObject.quantity = DBConvert.ToLong(obj);
                    return;
                case QueryValues.typeName:
                    m_DataObject.typeName = DBConvert.ToString(obj);
                    return;
                case QueryValues.typeID:
                    m_DataObject.typeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.price:
                    m_DataObject.price = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.clientID:
                    m_DataObject.clientID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.clientName:
                    m_DataObject.clientName = DBConvert.ToString(obj);
                    return;
                case QueryValues.stationName:
                    m_DataObject.stationName = DBConvert.ToString(obj);
                    return;
                case QueryValues.transactionType:
                    m_DataObject.transactionType = DBConvert.ToString(obj);
                    return;
                case QueryValues.transactionFor:
                    m_DataObject.transactionFor = DBConvert.ToString(obj);
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

        public CorporationTransaction()
        { 
        }

        public CorporationTransaction(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorporationTransaction(string CorpID, string Division, XmlNode xmlNode)
        {
            this.m_DataObject.CorpID = long.Parse(CorpID);
            this.m_DataObject.Division = long.Parse(Division);

            this.m_DataObject.date = DBConvert.FromCCPTime(xmlNode.Attributes["transactionDateTime"].InnerText);
            this.m_DataObject.transID = long.Parse(xmlNode.Attributes["transactionID"].InnerText);
            this.m_DataObject.quantity = long.Parse(xmlNode.Attributes["quantity"].InnerText);
            this.m_DataObject.typeName = xmlNode.Attributes["typeName"].InnerText;
            this.m_DataObject.typeID = long.Parse(xmlNode.Attributes["typeID"].InnerText);
            this.m_DataObject.price = decimal.Parse(xmlNode.Attributes["price"].InnerText);
            this.m_DataObject.clientID = long.Parse(xmlNode.Attributes["clientID"].InnerText);
            this.m_DataObject.clientName = xmlNode.Attributes["clientName"].InnerText;
            this.m_DataObject.stationID = long.Parse(xmlNode.Attributes["stationID"].InnerText);
            this.m_DataObject.stationName = xmlNode.Attributes["stationName"].InnerText;
            this.m_DataObject.transactionType = xmlNode.Attributes["transactionType"].InnerText;
            this.m_DataObject.transactionFor = xmlNode.Attributes["transactionFor"].InnerText;

        }
    }
}
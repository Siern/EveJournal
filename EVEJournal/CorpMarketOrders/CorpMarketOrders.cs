using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpMarketOrders (
//  fld_CorpID        integer NOT NULL,
//  fld_charID        integer NOT NULL,
//  fld_orderID       integer NOT NULL,
//  fld_stationID     integer NOT NULL,
//  fld_typeID        integer NOT NULL,
//  fld_accountKey    integer NOT NULL,
//  fld_issued        datetime NOT NULL,
//  fld_ownerID       integer,
//  fld_volEntered    integer,
//  fld_volRemaining  integer,
//  fld_minVolume     integer,
//  fld_orderState    numeric(1),
//  fld_range         integer,
//  fld_duration      integer,
//  fld_escrow        real,
//  fld_price         real,
//  fld_bid           numeric(1),
//  PRIMARY KEY (fld_CorpID, fld_charID, fld_orderID, fld_stationID, fld_typeID, fld_accountKey, fld_issued)
//);

namespace EVEJournal
{
    partial class CorpMarketOrders : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                          "{30} {31}, {32} {33}, {34} " +
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.charID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.orderID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.stationID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.typeID), ColumnType.INTnNULL,

                GetFieldName(QueryValues.accountKey), ColumnType.INTnNULL,
                GetFieldName(QueryValues.issued), ColumnType.DTnNULL,
                // data
                GetFieldName(QueryValues.ownerID), ColumnType.INT,
                GetFieldName(QueryValues.volEntered), ColumnType.INT,
                GetFieldName(QueryValues.volRemaining), ColumnType.INT,

                GetFieldName(QueryValues.minVolume), ColumnType.INT,
                GetFieldName(QueryValues.orderState), ColumnType.INT,
                GetFieldName(QueryValues.range), ColumnType.INT,
                GetFieldName(QueryValues.duration), ColumnType.INT,
                GetFieldName(QueryValues.escrow), ColumnType.DEC,

                GetFieldName(QueryValues.price), ColumnType.DEC,
                GetFieldName(QueryValues.bid), ColumnType.INT,
                "PRIMARY KEY (fld_CorpID, fld_charID, fld_orderID, fld_stationID, fld_typeID, fld_accountKey, fld_issued)");

        public static readonly string TableName = "CorpMarketOrders";
        public static readonly long VersionNumber = 2;

        CorpMarketOrdersObjectInternal m_DataObject = 
            new CorpMarketOrdersObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            charID,
            orderID,
            typeID,
            stationID,
            accountKey,
            issued,
            // data
            ownerID,
            volEntered,
            volRemaining,
            minVolume,
            orderState,
            range,
            duration,
            escrow,
            price,
            bid,
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
                case QueryValues.charID:
                case QueryValues.orderID:
                case QueryValues.typeID:
                case QueryValues.stationID:
                case QueryValues.accountKey:
                case QueryValues.issued:
                    throw new NotSupportedException();

                // data
                case QueryValues.ownerID:
                case QueryValues.volEntered:
                case QueryValues.volRemaining:
                case QueryValues.minVolume:
                case QueryValues.orderState:
                case QueryValues.range:
                case QueryValues.duration:
                case QueryValues.escrow:
                case QueryValues.price:
                case QueryValues.bid:
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
                case QueryValues.charID:
                    m_DataObject.charID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.orderID:
                    m_DataObject.orderID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.typeID:
                    m_DataObject.typeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.stationID:
                    m_DataObject.stationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.accountKey:
                    m_DataObject.accountKey = DBConvert.ToLong(obj);
                    return;
                case QueryValues.issued:
                    m_DataObject.issued = DBConvert.ToDateTime(obj);
                    return;
                // data
                case QueryValues.ownerID:
                    m_DataObject.ownerID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.volEntered:
                    m_DataObject.volEntered = DBConvert.ToLong(obj);
                    return;
                case QueryValues.volRemaining:
                    m_DataObject.volRemaining = DBConvert.ToLong(obj);
                    return;
                case QueryValues.minVolume:
                    m_DataObject.minVolume = DBConvert.ToLong(obj);
                    return;
                case QueryValues.orderState:
                    m_DataObject.orderState = DBConvert.ToLong(obj);
                    return;
                case QueryValues.range:
                    m_DataObject.range = DBConvert.ToLong(obj);
                    return;
                case QueryValues.duration:
                    m_DataObject.duration = DBConvert.ToLong(obj);
                    return;
                case QueryValues.escrow:
                    m_DataObject.escrow = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.price:
                    m_DataObject.price = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.bid:
                    m_DataObject.bid = DBConvert.ToLong(obj);
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

        public CorpMarketOrders()
        {
        }

        public CorpMarketOrders(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpMarketOrders(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.charID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpMarketOrders(CorpMarketOrdersObject obj)
        {
            m_DataObject = (CorpMarketOrdersObjectInternal)obj;
        }
    }
}

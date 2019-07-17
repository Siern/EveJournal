//orderID 	 int 	Unique order ID for this order. Note that these are not guaranteed to be unique forever, they can recycle. But they are unique for the purpose of one data pull.
//charID 	int 	ID of the character that physically placed this order.
//stationID 	int 	ID of the station the order was placed in.
//volEntered 	int 	Quantity of items required/offered to begin with.
//volRemaining 	int 	Quantity of items still for sale or still desired.
//minVolume 	int 	For bids (buy orders), the minimum quantity that must be sold in one sale in order to be accepted by this order.
//orderState 	byte 	Valid states: 0 = open/active, 1 = closed, 2 = expired (or fulfilled), 3 = cancelled, 4 = pending, 5 = character deleted.
//typeID 	short 	ID of the type (references the invTypes table) of the items this order is buying/selling.
//range 	short 	The range this order is good for. For sell orders, this is always 32767. For buy orders, allowed values are: -1 = station, 0 = solar system, 1 = 1 jump, 2 = 2 jumps, ..., 32767 = region.
//accountKey 	short 	Which division this order is using as its account. Always 1000 for characters, but in the range 1000 to 1006 for corporations.
//duration 	short 	How many days this order is good for. Expiration is issued + duration in days.
//escrow 	decimal 	How much ISK is in escrow. Valid for buy orders only (I believe).
//price 	decimal 	The cost per unit for this order.
//bid 	bool 	If true, this order is a bid (buy order). Else, sell order.
//issued 	datetime 	When this order was issued. 

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharMarketOrders (
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
//  fld_range         integer,
//  fld_duration      integer,
//  fld_orderState    numeric(1),
//  fld_bid           numeric(1),
//  fld_escrow        real,
//  fld_price         real,
//  PRIMARY KEY (fld_charID, fld_orderID, fld_stationID, fld_typeID, fld_accountKey, fld_issued)
//);

namespace EVEJournal
{
    partial class CharacterOrderCollection : BaseCollection
    {
        private partial class CharacterOrder : IDBRecord
        {
            public static readonly string TableDefinition =
                //                  1   |      2   |      3   |      4   |      5   |
                String.Format("  {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                              " {10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                              " {20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                              " {30} {31}, " +
                              "PRIMARY KEY ({0}, {2}, {4}, {6}, {8}, {10})",
                // key
                    GetFieldName(QueryValues.charID), ColumnType.INTnNULL,
                    GetFieldName(QueryValues.orderID), ColumnType.INTnNULL,
                    GetFieldName(QueryValues.stationID), ColumnType.INTnNULL,
                    GetFieldName(QueryValues.typeID), ColumnType.INTnNULL,
                    GetFieldName(QueryValues.accountKey), ColumnType.INTnNULL,
                    GetFieldName(QueryValues.issued), ColumnType.DECnNULL,
                // data
                    GetFieldName(QueryValues.ownerID), ColumnType.INT,
                    GetFieldName(QueryValues.volEntered), ColumnType.INT,
                    GetFieldName(QueryValues.volRemaining), ColumnType.INT,
                    GetFieldName(QueryValues.minVolume), ColumnType.INT,
                    GetFieldName(QueryValues.orderState), ColumnType.INT,
                    GetFieldName(QueryValues.range), ColumnType.INT,
                    GetFieldName(QueryValues.duration), ColumnType.INT,
                    GetFieldName(QueryValues.escrow), ColumnType.DEC,
                    GetFieldName(QueryValues.bid), ColumnType.INT,
                    GetFieldName(QueryValues.price), ColumnType.DEC);

            public static readonly string TableName = "CharOrder";
            public static readonly long VersionNumber = 2;

            CharacterOrderObjectInternal m_DataObject = 
                new CharacterOrderObjectInternal();

            public enum QueryValues : long
            {
                // key
                charID,
                orderID,
                stationID,
                typeID,
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
                return m_DataObject as CharacterOrderObject;
            }

            RecordKey IDBRecord.GetRecordKey()
            {
                return m_DataObject.Key as RecordKey;
            }

            void IDBRecord.SetValue(long which, object obj)
            {
                switch ((QueryValues)which)
                {
                    case QueryValues.charID:
                    case QueryValues.orderID:
                    case QueryValues.stationID:
                    case QueryValues.typeID:
                    case QueryValues.accountKey:
                    case QueryValues.issued:
                        throw new NotSupportedException();

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
                    case QueryValues.charID:
                        m_DataObject.charID = DBConvert.ToLong(obj);
                        return;
                    case QueryValues.issued:
                        m_DataObject.issued = DBConvert.ToDateTime(obj);
                        return;
                    case QueryValues.orderID:
                        m_DataObject.orderID = DBConvert.ToLong(obj);
                        return;
                    case QueryValues.ownerID:
                        m_DataObject.charID = DBConvert.ToLong(obj);
                        return;
                    case QueryValues.stationID:
                        m_DataObject.stationID = DBConvert.ToLong(obj);
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
                        m_DataObject.orderState = DBConvert.ToOrderState(obj);
                        return;
                    case QueryValues.typeID:
                        m_DataObject.typeID = DBConvert.ToLong(obj);
                        return;
                    case QueryValues.range:
                        m_DataObject.range = DBConvert.ToMarketRange(obj);
                        return;
                    case QueryValues.accountKey:
                        m_DataObject.accountKey = DBConvert.ToAccountKey(obj);
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
                        m_DataObject.bid = DBConvert.ToBoolean(obj);
                        return;
                }
                throw new ArgumentOutOfRangeException("which", which, "");
            }

            string IDBRecord.GetDBCreateTable()
            {
                if (null == TableName)
                    throw new NullReferenceException();

                StringBuilder strbuild = new StringBuilder();
                strbuild.AppendFormat("CREATE TABLE {0} ({1})",
                    TableName, TableDefinition);
                return strbuild.ToString();
            }

            void IDBRecord.PrepareCommandInsert(Database.DatabaseCommand dbCommand)
            {
                dbCommand.SetCommand(String.Format(
                    "INSERT INTO {0} ( {1},  {2},  {3},  {4},  {5}, " +
                                     " {6},  {7},  {8},  {9}, {10}, " +
                                     "{11}, {12}, {13}, {14}, {15}, " +
                                     "{16}) " +
                    "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);",
                    TableName,
                    // key
                    GetFieldName(QueryValues.charID),
                    GetFieldName(QueryValues.orderID),
                    GetFieldName(QueryValues.stationID),
                    GetFieldName(QueryValues.typeID),
                    GetFieldName(QueryValues.accountKey),
                    GetFieldName(QueryValues.issued),
                    // data
                    GetFieldName(QueryValues.ownerID),
                    GetFieldName(QueryValues.volEntered),
                    GetFieldName(QueryValues.volRemaining),
                    GetFieldName(QueryValues.minVolume),
                    GetFieldName(QueryValues.orderState),
                    GetFieldName(QueryValues.range),
                    GetFieldName(QueryValues.duration),
                    GetFieldName(QueryValues.escrow),
                    GetFieldName(QueryValues.price),
                    GetFieldName(QueryValues.bid)));

                // key
                dbCommand.AddParameter((long)QueryValues.charID);
                dbCommand.AddParameter((long)QueryValues.orderID);
                dbCommand.AddParameter((long)QueryValues.stationID);
                dbCommand.AddParameter((long)QueryValues.typeID);
                dbCommand.AddParameter((long)QueryValues.accountKey);
                dbCommand.AddParameter((long)QueryValues.issued);
                // data
                dbCommand.AddParameter((long)QueryValues.ownerID);
                dbCommand.AddParameter((long)QueryValues.volEntered);
                dbCommand.AddParameter((long)QueryValues.volRemaining);
                dbCommand.AddParameter((long)QueryValues.minVolume);
                dbCommand.AddParameter((long)QueryValues.orderState);
                dbCommand.AddParameter((long)QueryValues.range);
                dbCommand.AddParameter((long)QueryValues.duration);
                dbCommand.AddParameter((long)QueryValues.escrow);
                dbCommand.AddParameter((long)QueryValues.price);
                dbCommand.AddParameter((long)QueryValues.bid);
            }

            void IDBRecord.FillCommandInsert(Database.DatabaseCommand dbCommand)
            {
                // key
                dbCommand.SetParamValue((long)QueryValues.charID, m_DataObject.charID);
                dbCommand.SetParamValue((long)QueryValues.orderID, m_DataObject.orderID);
                dbCommand.SetParamValue((long)QueryValues.stationID, m_DataObject.stationID);
                dbCommand.SetParamValue((long)QueryValues.typeID, m_DataObject.typeID);
                dbCommand.SetParamValue((long)QueryValues.accountKey, m_DataObject.accountKey);
                dbCommand.SetParamValue((long)QueryValues.issued, m_DataObject.issued);
                // data
                dbCommand.SetParamValue((long)QueryValues.ownerID, m_DataObject.ownerID);
                dbCommand.SetParamValue((long)QueryValues.volEntered, m_DataObject.volEntered);
                dbCommand.SetParamValue((long)QueryValues.volRemaining, m_DataObject.volRemaining);
                dbCommand.SetParamValue((long)QueryValues.minVolume, m_DataObject.minVolume);
                dbCommand.SetParamValue((long)QueryValues.orderState, m_DataObject.orderState);
                dbCommand.SetParamValue((long)QueryValues.range, m_DataObject.range);
                dbCommand.SetParamValue((long)QueryValues.duration, m_DataObject.duration);
                dbCommand.SetParamValue((long)QueryValues.escrow, m_DataObject.escrow);
                dbCommand.SetParamValue((long)QueryValues.price, m_DataObject.price);
                dbCommand.SetParamValue((long)QueryValues.bid, m_DataObject.bid);
            }

            void IDBRecord.PrepareCommandUpdate(Database.DatabaseCommand dbCommand)
            {
                dbCommand.SetCommand(String.Format(
                    "UPDATE {0} SET {1}=?, {2}=?, {3}=?, {4}=?, {5}=?, " +
                                   "{6}=?, {7}=?, {8}=?, {9}=?, {10}=? " +
                    "WHERE {11}=? AND {12}=? AND {13}=? AND {14}=? AND {15}=? AND {16}=?;",
                    TableName,
                    // data
                    GetFieldName(QueryValues.ownerID),
                    GetFieldName(QueryValues.volEntered),
                    GetFieldName(QueryValues.volRemaining),
                    GetFieldName(QueryValues.minVolume),
                    GetFieldName(QueryValues.orderState),
                    GetFieldName(QueryValues.range),
                    GetFieldName(QueryValues.duration),
                    GetFieldName(QueryValues.escrow),
                    GetFieldName(QueryValues.price),
                    GetFieldName(QueryValues.bid),
                    // key
                    GetFieldName(QueryValues.charID),
                    GetFieldName(QueryValues.orderID),
                    GetFieldName(QueryValues.stationID),
                    GetFieldName(QueryValues.typeID),
                    GetFieldName(QueryValues.accountKey),
                    GetFieldName(QueryValues.issued)));

                // data
                dbCommand.AddParameter((long)QueryValues.ownerID);
                dbCommand.AddParameter((long)QueryValues.volEntered);
                dbCommand.AddParameter((long)QueryValues.volRemaining);
                dbCommand.AddParameter((long)QueryValues.minVolume);
                dbCommand.AddParameter((long)QueryValues.orderState);
                dbCommand.AddParameter((long)QueryValues.range);
                dbCommand.AddParameter((long)QueryValues.duration);
                dbCommand.AddParameter((long)QueryValues.escrow);
                dbCommand.AddParameter((long)QueryValues.price);
                dbCommand.AddParameter((long)QueryValues.bid);
                // key
                dbCommand.AddParameter((long)QueryValues.charID);
                dbCommand.AddParameter((long)QueryValues.orderID);
                dbCommand.AddParameter((long)QueryValues.stationID);
                dbCommand.AddParameter((long)QueryValues.typeID);
                dbCommand.AddParameter((long)QueryValues.accountKey);
                dbCommand.AddParameter((long)QueryValues.issued);
            }

            void IDBRecord.FillCommandUpdate(Database.DatabaseCommand dbCommand)
            {
                // key
                dbCommand.SetParamValue((long)QueryValues.charID, m_DataObject.charID);
                dbCommand.SetParamValue((long)QueryValues.orderID, m_DataObject.orderID);
                dbCommand.SetParamValue((long)QueryValues.stationID, m_DataObject.stationID);
                dbCommand.SetParamValue((long)QueryValues.typeID, m_DataObject.typeID);
                dbCommand.SetParamValue((long)QueryValues.accountKey, m_DataObject.accountKey);
                dbCommand.SetParamValue((long)QueryValues.issued, m_DataObject.issued);
                // data
                dbCommand.SetParamValue((long)QueryValues.ownerID, m_DataObject.ownerID);
                dbCommand.SetParamValue((long)QueryValues.volEntered, m_DataObject.volEntered);
                dbCommand.SetParamValue((long)QueryValues.volRemaining, m_DataObject.volRemaining);
                dbCommand.SetParamValue((long)QueryValues.minVolume, m_DataObject.minVolume);
                dbCommand.SetParamValue((long)QueryValues.orderState, m_DataObject.orderState);
                dbCommand.SetParamValue((long)QueryValues.range, m_DataObject.range);
                dbCommand.SetParamValue((long)QueryValues.duration, m_DataObject.duration);
                dbCommand.SetParamValue((long)QueryValues.escrow, m_DataObject.escrow);
                dbCommand.SetParamValue((long)QueryValues.price, m_DataObject.price);
                dbCommand.SetParamValue((long)QueryValues.bid, m_DataObject.bid);
            }

            void IDBRecord.PrepareCommandDelete(Database.DatabaseCommand dbCommand)
            {
                dbCommand.SetCommand(String.Format(
                    "DELETE FROM {0} " +
                    "WHERE {1}=? AND {2}=? AND {3}=? AND {4}=? AND {5}=? AND {6}=?;",
                    TableName,
                    // key
                    GetFieldName(QueryValues.charID),
                    GetFieldName(QueryValues.orderID),
                    GetFieldName(QueryValues.stationID),
                    GetFieldName(QueryValues.typeID),
                    GetFieldName(QueryValues.accountKey),
                    GetFieldName(QueryValues.issued)));

                // key
                dbCommand.AddParameter((long)QueryValues.charID);
                dbCommand.AddParameter((long)QueryValues.orderID);
                dbCommand.AddParameter((long)QueryValues.stationID);
                dbCommand.AddParameter((long)QueryValues.typeID);
                dbCommand.AddParameter((long)QueryValues.accountKey);
                dbCommand.AddParameter((long)QueryValues.issued);
            }

            void IDBRecord.FillCommandDelete(Database.DatabaseCommand dbCommand)
            {
                // key
                dbCommand.SetParamValue((long)QueryValues.charID, m_DataObject.charID);
                dbCommand.SetParamValue((long)QueryValues.orderID, m_DataObject.orderID);
                dbCommand.SetParamValue((long)QueryValues.stationID, m_DataObject.stationID);
                dbCommand.SetParamValue((long)QueryValues.typeID, m_DataObject.typeID);
                dbCommand.SetParamValue((long)QueryValues.accountKey, m_DataObject.accountKey);
                dbCommand.SetParamValue((long)QueryValues.issued, m_DataObject.issued);
            }

            public CharacterOrder()
            {
            }

            public CharacterOrder(SQLiteDataReader reader)
            {
                foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
                {
                    SetValue(val, reader[GetFieldName(val)]);
                }//foreach
            }

            public CharacterOrder(long CharID, XmlNode xmlNode)
            {
                m_DataObject.charID = CharID;

                m_DataObject.issued = DBConvert.FromCCPTime(xmlNode.Attributes["issued"].InnerText);
                m_DataObject.orderID = long.Parse(xmlNode.Attributes["orderID"].InnerText);
                m_DataObject.ownerID = long.Parse(xmlNode.Attributes["charID"].InnerText);
                m_DataObject.stationID = long.Parse(xmlNode.Attributes["stationID"].InnerText);
                m_DataObject.volEntered = long.Parse(xmlNode.Attributes["volEntered"].InnerText);
                m_DataObject.volRemaining = long.Parse(xmlNode.Attributes["volRemaining"].InnerText);
                m_DataObject.minVolume = long.Parse(xmlNode.Attributes["minVolume"].InnerText);
                m_DataObject.orderState = DBConvert.ToOrderState(xmlNode.Attributes["orderState"].InnerText);
                m_DataObject.typeID = long.Parse(xmlNode.Attributes["typeID"].InnerText);
                m_DataObject.range = DBConvert.ToMarketRange(xmlNode.Attributes["range"].InnerText);
                m_DataObject.accountKey = DBConvert.ToAccountKey(xmlNode.Attributes["accountKey"].InnerText);
                m_DataObject.duration = long.Parse(xmlNode.Attributes["duration"].InnerText);
                m_DataObject.escrow = decimal.Parse(xmlNode.Attributes["escrow"].InnerText);
                m_DataObject.price = decimal.Parse(xmlNode.Attributes["price"].InnerText);
                m_DataObject.bid = DBConvert.ToBoolean(xmlNode.Attributes["bid"].InnerText);
            }
        }
    }
}


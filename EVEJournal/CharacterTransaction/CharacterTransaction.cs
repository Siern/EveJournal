using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharTrans (
//  fld_CharID           integer NOT NULL,
//  fld_transID          integer NOT NULL,
//  fld_date             datetime NOT NULL,
//  fld_clientID         integer NOT NULL,
//  fld_stationID        integer NOT NULL,
//  fld_typeID           integer NOT NULL,
//  fld_quantity         integer,
//  fld_price            real,
//  fld_typeName         nvarchar(50),
//  fld_clientName       nvarchar(50),
//  fld_stationName      nvarchar(50),
//  fld_transactionType  nvarchar(50),
//  fld_transactionFor   nvarchar(50),
//  PRIMARY KEY (fld_CharID, fld_transID, fld_date, fld_clientID, fld_stationID, fld_typeID)
//);

namespace EVEJournal
{
    partial class CharacterTransaction : IDBRecord
    {
        //date,transID,quantity,type,price,clientName,stationName,transactionType,transactionFor
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, " +
                          "PRIMARY KEY ({0}, {2}, {4}, {6}, {8}, {10})",

                // key
                GetFieldName(QueryValues.CharID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.transID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.date), ColumnType.DTnNULL,
                GetFieldName(QueryValues.clientID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.stationID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.typeID), ColumnType.INTnNULL,
                // data
                GetFieldName(QueryValues.quantity), ColumnType.INT,
                GetFieldName(QueryValues.price), ColumnType.DEC,
                GetFieldName(QueryValues.typeName), ColumnType.TXT,
                GetFieldName(QueryValues.clientName), ColumnType.TXT,
                GetFieldName(QueryValues.stationName), ColumnType.TXT,
                GetFieldName(QueryValues.transactionType), ColumnType.TXT,
                GetFieldName(QueryValues.transactionFor), ColumnType.TXT);
            
        public static readonly string TableName = "CharTrans";
        public static readonly long VersionNumber = 2;

        private CharacterTransactionObjectInternal m_DataObject = 
            new CharacterTransactionObjectInternal();

        public enum QueryValues : long
        {
            // key
            CharID,
            transID,
            date,
            clientID,
            stationID,
            typeID,
            // data
            quantity,
            typeName,
            price,
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
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.date:
                    m_DataObject.date = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.transID:
                    m_DataObject.transID = DBConvert.ToLong(obj);
                    return;
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
                case QueryValues.stationID:
                    m_DataObject.stationID = DBConvert.ToLong(obj);
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

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.date:
                    m_DataObject.date = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.transID:
                    m_DataObject.transID = DBConvert.ToLong(obj);
                    return;
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
                case QueryValues.stationID:
                    m_DataObject.stationID = DBConvert.ToLong(obj);
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

            StringBuilder strbuild = new StringBuilder();
            strbuild.AppendFormat("CREATE TABLE {0} ({1})",
                TableName, TableDefinition);
            return strbuild.ToString();
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

        public CharacterTransaction()
        { 
        }

        public CharacterTransaction(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharacterTransaction(long CharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = CharID;

            m_DataObject.date = DBConvert.FromCCPTime(xmlNode.Attributes["transactionDateTime"].InnerText);
            m_DataObject.transID = long.Parse(xmlNode.Attributes["transactionID"].InnerText);
            m_DataObject.quantity = long.Parse(xmlNode.Attributes["quantity"].InnerText);
            m_DataObject.typeName = xmlNode.Attributes["typeName"].InnerText;
            m_DataObject.typeID = long.Parse(xmlNode.Attributes["typeID"].InnerText);
            m_DataObject.price = decimal.Parse(xmlNode.Attributes["price"].InnerText);
            m_DataObject.clientID = long.Parse(xmlNode.Attributes["clientID"].InnerText);
            m_DataObject.clientName = xmlNode.Attributes["clientName"].InnerText;
            m_DataObject.stationID = long.Parse(xmlNode.Attributes["stationID"].InnerText);
            m_DataObject.stationName = xmlNode.Attributes["stationName"].InnerText;
            m_DataObject.transactionType = xmlNode.Attributes["transactionType"].InnerText;
            m_DataObject.transactionFor = xmlNode.Attributes["transactionFor"].InnerText;

        }
    }
}

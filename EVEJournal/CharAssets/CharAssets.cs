using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharAssets (
//  fld_CharID        integer,
//  fld_ItemID        integer,
//  fld_ItemParentID  integer NOT NULL DEFAULT 0,
//  fld_locationID    integer,
//  fld_typeID        integer,
//  fld_quantity      integer,
//  fld_flag          integer,
//  fld_singleton     integer
//);

namespace EVEJournal
{
    partial class CharAssets : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}",
                // key
                GetFieldName(QueryValues.Key_ID), ColumnType.INTnNULL,
                // data
                GetFieldName(QueryValues.CharID), ColumnType.INT,
                GetFieldName(QueryValues.ItemID), ColumnType.INT,
                GetFieldName(QueryValues.ItemParentID), ColumnType.INT,
                GetFieldName(QueryValues.locationID), ColumnType.INT,

                GetFieldName(QueryValues.typeID), ColumnType.INT,
                GetFieldName(QueryValues.quantity), ColumnType.INT,
                GetFieldName(QueryValues.flag), ColumnType.INT,
                GetFieldName(QueryValues.singleton), ColumnType.INT);

        public static readonly string TableName = "CharAssets";
        public static readonly long VersionNumber = 2;

        CharAssetsObjectInternal m_DataObject = 
            new CharAssetsObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // data
            CharID,
            ItemID,
            ItemParentID,
            locationID,
            typeID,
            quantity,
            flag,
            singleton,
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
                case QueryValues.Key_ID:
                    throw new NotSupportedException();

                case QueryValues.CharID:
                case QueryValues.ItemID:
                case QueryValues.ItemParentID:
                case QueryValues.locationID:
                case QueryValues.typeID:
                case QueryValues.quantity:
                case QueryValues.flag:
                case QueryValues.singleton:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.Key_ID:
                    m_DataObject.Key_ID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ItemID:
                    m_DataObject.ItemID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ItemParentID:
                    m_DataObject.ItemParentID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.locationID:
                    m_DataObject.locationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.typeID:
                    m_DataObject.typeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.quantity:
                    m_DataObject.quantity = DBConvert.ToLong(obj);
                    return;
                case QueryValues.flag:
                    m_DataObject.flag = DBConvert.ToLong(obj);
                    return;
                case QueryValues.singleton:
                    m_DataObject.singleton = DBConvert.ToLong(obj);
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

        public CharAssets()
        {
        }

        public CharAssets(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharAssets(long aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = aCharID;
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharAssets(CharAssetsObject obj)
        {
            m_DataObject = (CharAssetsObjectInternal)obj;
        }
    }
}

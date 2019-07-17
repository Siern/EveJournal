using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpContainerLogs (
//  fld_CorpID            integer NOT NULL,
//  fld_ItemID            integer NOT NULL,
//  fld_logTime           datetime NOT NULL,
//  fld_itemTypeID        integer,
//  fld_actorID           integer,
//  fld_flag              integer,
//  fld_locationID        integer,
//  fld_typeID            integer,
//  fld_quantity          integer,
//  fld_actorName         nvarchar(50),
//  fld_action            nvarchar(50),
//  fld_passwordType      nvarchar(50),
//  fld_oldConfiguration  nvarchar(50),
//  fld_newConfiguration  nvarchar(50),
//  PRIMARY KEY (fld_CorpID, fld_ItemID, fld_logTime)
//);

namespace EVEJournal
{
    partial class CorpContainerLogs : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18}  {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} ",
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.ItemID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.logTime), ColumnType.DTnNULL,
                // data
                GetFieldName(QueryValues.itemTypeID), ColumnType.INT,
                GetFieldName(QueryValues.actorID), ColumnType.INT,

                GetFieldName(QueryValues.flag), ColumnType.INT,
                GetFieldName(QueryValues.locationID), ColumnType.INT,
                GetFieldName(QueryValues.typeID), ColumnType.INT,
                GetFieldName(QueryValues.quantity), ColumnType.INT,
                GetFieldName(QueryValues.actorName), ColumnType.TXT,

                GetFieldName(QueryValues.action), ColumnType.TXT,
                GetFieldName(QueryValues.passwordType), ColumnType.TXT,
                GetFieldName(QueryValues.oldConfiguration), ColumnType.TXT,
                GetFieldName(QueryValues.newConfiguration), ColumnType.TXT,
                "PRIMARY KEY (fld_CorpID, fld_ItemID, fld_logTime)");

        public static readonly string TableName = "CorpContainerLogs";
        public static readonly long VersionNumber = 2;

        CorpContainerLogsObjectInternal m_DataObject = 
            new CorpContainerLogsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            ItemID,
            logTime,
            // data
            itemTypeID,
            actorID,
            flag,
            locationID,
            typeID,
            quantity,
            actorName,
            action,
            passwordType,
            oldConfiguration,
            newConfiguration,
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
                // key
                case QueryValues.CorpID:
                case QueryValues.ItemID:
                case QueryValues.logTime:
                    throw new NotSupportedException();

                // data
                case QueryValues.itemTypeID:
                case QueryValues.actorID:
                case QueryValues.flag:
                case QueryValues.locationID:
                case QueryValues.typeID:
                case QueryValues.quantity:
                case QueryValues.actorName:
                case QueryValues.action:
                case QueryValues.passwordType:
                case QueryValues.oldConfiguration:
                case QueryValues.newConfiguration:
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
                case QueryValues.ItemID:
                    m_DataObject.ItemID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.logTime:
                    m_DataObject.logTime = DBConvert.ToDateTime(obj);
                    return;

                // data
                case QueryValues.itemTypeID:
                    m_DataObject.itemTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.actorID:
                    m_DataObject.actorID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.flag:
                    m_DataObject.flag = DBConvert.ToLong(obj);
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
                case QueryValues.actorName:
                    m_DataObject.actorName = DBConvert.ToString(obj);
                    return;
                case QueryValues.action:
                    m_DataObject.action = DBConvert.ToString(obj);
                    return;
                case QueryValues.passwordType:
                    m_DataObject.passwordType = DBConvert.ToString(obj);
                    return;
                case QueryValues.oldConfiguration:
                    m_DataObject.oldConfiguration = DBConvert.ToString(obj);
                    return;
                case QueryValues.newConfiguration:
                    m_DataObject.newConfiguration = DBConvert.ToString(obj);
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

        public CorpContainerLogs()
        {
        }

        public CorpContainerLogs(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpContainerLogs(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpContainerLogs(CorpContainerLogsObject obj)
        {
            m_DataObject = (CorpContainerLogsObjectInternal)obj;
        }
    }
}

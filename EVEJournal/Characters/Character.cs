using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE Characters (
//  fld_UserID      integer NOT NULL,
//  fld_CharID      integer NOT NULL,
//  fld_CorpID      integer,
//  fld_CharName    nvarchar(50),
//  fld_CorpName    nvarchar(50),
//  fld_LimitedKey  nvarchar(50),
//  fld_FullKey     nvarchar(50),
//  fld_RegCode     nvarchar(50),
//  PRIMARY KEY (fld_UserID, fld_CharID)
//);

namespace EVEJournal
{
    partial class Character : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format("  {0}  {1},  {2}  {3},  {4}  {5}, " +
                          "  {6}  {7},  {8}  {9}, {10} {11}, " +
                          " {12} {13}, {14} {15}, " +
                          "PRIMARY KEY ({0}, {2})",
            // key
            GetFieldName(QueryValues.UserID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.CharID), ColumnType.INTnNULL,
            // data
            GetFieldName(QueryValues.CorpID), ColumnType.INT,
            GetFieldName(QueryValues.CharName), ColumnType.TXT,
            GetFieldName(QueryValues.CorpName), ColumnType.TXT,
            GetFieldName(QueryValues.LimitedKey), ColumnType.TXT,
            GetFieldName(QueryValues.FullKey), ColumnType.TXT,
            GetFieldName(QueryValues.RegCode), ColumnType.TXT);

        public static string TableName = "Characters";
        public static readonly long VersionNumber = 2;

        CharacterObjectInternal m_DataObject = 
            new CharacterObjectInternal();

        public enum QueryValues : long
        {
            // Key
            UserID,
            CharID,
            // Data
            CharName,
            CorpName,
            CorpID,
            LimitedKey,
            FullKey,
            RegCode,
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
                case QueryValues.UserID:
                case QueryValues.CharID:
                    throw new NotSupportedException();

                case QueryValues.CharName:
                case QueryValues.CorpName:
                case QueryValues.CorpID:
                case QueryValues.LimitedKey:
                case QueryValues.FullKey:
                case QueryValues.RegCode:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                case QueryValues.CharName:
                    m_DataObject.CharName = DBConvert.ToString(obj);
                    return;
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.CorpName:
                    m_DataObject.CorpName = DBConvert.ToString(obj);
                    return;
                case QueryValues.CorpID:
                    m_DataObject.CorpID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.UserID:
                    m_DataObject.UserID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.LimitedKey:
                    m_DataObject.LimitedKey = DBConvert.ToString(obj);
                    return;
                case QueryValues.FullKey:
                    m_DataObject.FullKey = DBConvert.ToString(obj);
                    return;
                case QueryValues.RegCode:
                    m_DataObject.RegCode = DBConvert.ToString(obj);
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
            dbCommand.SetCommand(String.Format(
                "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, " +
                                 "{6}, {7}, {8}) " +
                "VALUES(?,?,?,?,?,?,?,?);",
                TableName,
                // Key
                GetFieldName(QueryValues.UserID),
                GetFieldName(QueryValues.CharID),
                // Data
                GetFieldName(QueryValues.CharName),
                GetFieldName(QueryValues.CorpName),
                GetFieldName(QueryValues.CorpID),
                GetFieldName(QueryValues.LimitedKey),
                GetFieldName(QueryValues.FullKey),
                GetFieldName(QueryValues.RegCode)));

            // Key
            dbCommand.AddParameter((long)QueryValues.UserID);
            dbCommand.AddParameter((long)QueryValues.CharID);
            // Data
            dbCommand.AddParameter((long)QueryValues.CharName);
            dbCommand.AddParameter((long)QueryValues.CorpName);
            dbCommand.AddParameter((long)QueryValues.CorpID);
            dbCommand.AddParameter((long)QueryValues.LimitedKey);
            dbCommand.AddParameter((long)QueryValues.FullKey);
            dbCommand.AddParameter((long)QueryValues.RegCode);
        }

        void IDBRecord.FillCommandInsert(Database.DatabaseCommand dbCommand)
        {
            // Key
            dbCommand.SetParamValue((long)QueryValues.UserID, m_DataObject.UserID);
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
            // Data
            dbCommand.SetParamValue((long)QueryValues.CharName, m_DataObject.CharName);
            dbCommand.SetParamValue((long)QueryValues.CorpName, m_DataObject.CorpName);
            dbCommand.SetParamValue((long)QueryValues.CorpID, m_DataObject.CorpID);
            dbCommand.SetParamValue((long)QueryValues.LimitedKey, m_DataObject.LimitedKey);
            dbCommand.SetParamValue((long)QueryValues.FullKey, m_DataObject.FullKey);
            dbCommand.SetParamValue((long)QueryValues.RegCode, m_DataObject.RegCode);
        }

        void IDBRecord.PrepareCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetCommand(String.Format(
                "UPDATE {0} SET " +
                "{1}=?, {2}=?, {3}=?, {4}=?, {5}=?, {6}=? " +
                "WHERE {7}=? AND {8}=?;",
                TableName,
                // Data
                GetFieldName(QueryValues.CharName),
                GetFieldName(QueryValues.CorpName),
                GetFieldName(QueryValues.CorpID),
                GetFieldName(QueryValues.LimitedKey),
                GetFieldName(QueryValues.FullKey),
                GetFieldName(QueryValues.RegCode),
                // Key
                GetFieldName(QueryValues.UserID),
                GetFieldName(QueryValues.CharID)));

            // Data
            dbCommand.AddParameter((long)QueryValues.CharName);
            dbCommand.AddParameter((long)QueryValues.CorpName);
            dbCommand.AddParameter((long)QueryValues.CorpID);
            dbCommand.AddParameter((long)QueryValues.LimitedKey);
            dbCommand.AddParameter((long)QueryValues.FullKey);
            dbCommand.AddParameter((long)QueryValues.RegCode);
            // Key
            dbCommand.AddParameter((long)QueryValues.UserID);
            dbCommand.AddParameter((long)QueryValues.CharID);
        }

        void IDBRecord.FillCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            // Key
            dbCommand.SetParamValue((long)QueryValues.UserID, m_DataObject.UserID);
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
            // Data
            dbCommand.SetParamValue((long)QueryValues.CharName, m_DataObject.CharName);
            dbCommand.SetParamValue((long)QueryValues.CorpName, m_DataObject.CorpName);
            dbCommand.SetParamValue((long)QueryValues.CorpID, m_DataObject.CorpID);
            dbCommand.SetParamValue((long)QueryValues.LimitedKey, m_DataObject.LimitedKey);
            dbCommand.SetParamValue((long)QueryValues.FullKey, m_DataObject.FullKey);
            dbCommand.SetParamValue((long)QueryValues.RegCode, m_DataObject.RegCode);
        }

        void IDBRecord.PrepareCommandDelete(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetCommand(String.Format(
                "DELETE FROM {0} " +
                "WHERE {1}=? AND {2}=?;",
                TableName,
                // Key
                GetFieldName(QueryValues.UserID),
                GetFieldName(QueryValues.CharID)));

            // Key
            dbCommand.AddParameter((long)QueryValues.UserID);
            dbCommand.AddParameter((long)QueryValues.CharID);
        }

        void IDBRecord.FillCommandDelete(Database.DatabaseCommand dbCommand)
        {
            // Key
            dbCommand.SetParamValue((long)QueryValues.UserID, m_DataObject.UserID);
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
        }

        public Character()
        { 
        }

        public Character(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public Character(XmlNode xmlNode)
        {
            m_DataObject.CharName = xmlNode.Attributes["name"].InnerText;
            //m_CharObject.CharID = Convert.ToInt32(xmlNode.Attributes["characterID"].InnerText, CultureInfo.InvariantCulture);
            m_DataObject.CharID = long.Parse(xmlNode.Attributes["characterID"].InnerText);
            m_DataObject.CorpName = xmlNode.Attributes["corporationName"].InnerText;
            //m_CharObject.CorpID = Convert.ToInt32(xmlNode.Attributes["corporationID"].InnerText, CultureInfo.InvariantCulture);
            m_DataObject.CorpID = long.Parse(xmlNode.Attributes["corporationID"].InnerText);
        }

        public Character(CharacterObject obj)
        {
            m_DataObject = (CharacterObjectInternal)obj;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharAccountBalance (
//  fld_CharID      integer NOT NULL,
//  fld_AccountID   integer NOT NULL,
//  fld_AccountKey  integer NOT NULL,
//  fld_balance     real,
//  PRIMARY KEY (fld_CharID, fld_AccountID, fld_AccountKey)
//);

namespace EVEJournal
{
    partial class CharAccountBalance : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format("{0} {1}, {2} {3}, {4} {5}, {6} {7}, " +
                          "PRIMARY KEY ({0}, {2}, {4})",
            // key
            GetFieldName(QueryValues.CharID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.AccountID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.AccountKey), ColumnType.INTnNULL,
            // data
            GetFieldName(QueryValues.balance), ColumnType.DEC);
        public static string TableName = "CharAccountBalance";
        public static readonly long VersionNumber = 2;

        CharAccountBalanceObjectInternal m_DataObject =
            new CharAccountBalanceObjectInternal();

        public enum QueryValues : long
        {
            CharID,
            AccountID,
            AccountKey,
            balance,
        }

        string IDBRecord.GetFieldName(long which)
        {
            return GetFieldName((QueryValues)which);
        }

        static protected string GetFieldName(QueryValues which)
        {
            return "fld_" + which.ToString();
        }

        object IDBRecord.GetDataObject()
        {
            return m_DataObject as CharAccountBalanceObject;
        }

        string IDBRecord.TranslateQueryValue(long which)
        {
            return ((QueryValues)which).ToString();
        }

        RecordKey IDBRecord.GetRecordKey()
        {
            return m_DataObject.Key;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.CharID:
                case QueryValues.AccountID:
                case QueryValues.AccountKey:
                    throw new NotSupportedException();
                case QueryValues.balance:
                    SetValue((QueryValues)which, obj);
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
                case QueryValues.AccountID:
                    m_DataObject.AccountID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.AccountKey:
                    m_DataObject.AccountKey = DBConvert.ToLong(obj);
                    return;
                case QueryValues.balance:
                    m_DataObject.balance = DBConvert.ToDecimal(obj);
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
                "INSERT INTO {0} ({1}, {2}, {3}, {4}) " +
                "VALUES(?, ?, ?, ?);",
                TableName,
                GetFieldName(QueryValues.CharID),
                GetFieldName(QueryValues.AccountID),
                GetFieldName(QueryValues.AccountKey),
                GetFieldName(QueryValues.balance)));

            // key
            dbCommand.AddParameter((long)QueryValues.CharID);
            dbCommand.AddParameter((long)QueryValues.AccountID);
            dbCommand.AddParameter((long)QueryValues.AccountKey);
            // data
            dbCommand.AddParameter((long)QueryValues.balance);
        }

        void IDBRecord.FillCommandInsert(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
            dbCommand.SetParamValue((long)QueryValues.AccountID, m_DataObject.AccountID);
            dbCommand.SetParamValue((long)QueryValues.AccountKey, m_DataObject.AccountKey);
            dbCommand.SetParamValue((long)QueryValues.balance, m_DataObject.balance);
        }

        void IDBRecord.PrepareCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetCommand(String.Format(
                "UPDATE {0} SET {1}=? " +
                "WHERE {2}=? AND {3}=? AND {4}=?;",
                TableName,
                // data
                GetFieldName(QueryValues.balance),
                // key
                GetFieldName(QueryValues.CharID),
                GetFieldName(QueryValues.AccountID),
                GetFieldName(QueryValues.AccountKey)));

            // data
            dbCommand.AddParameter((long)QueryValues.balance);
            // key
            dbCommand.AddParameter((long)QueryValues.CharID);
            dbCommand.AddParameter((long)QueryValues.AccountID);
            dbCommand.AddParameter((long)QueryValues.AccountKey);
        }

        void IDBRecord.FillCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
            dbCommand.SetParamValue((long)QueryValues.AccountID, m_DataObject.AccountID);
            dbCommand.SetParamValue((long)QueryValues.AccountKey, m_DataObject.AccountKey);
            dbCommand.SetParamValue((long)QueryValues.balance, m_DataObject.balance);
        }

        void IDBRecord.PrepareCommandDelete(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetCommand(String.Format(
                "DELETE FROM {0} " +
                "WHERE {1}=? AND {2}=? AND {3}=?;",
                TableName,
                // key
                GetFieldName(QueryValues.CharID),
                GetFieldName(QueryValues.AccountID),
                GetFieldName(QueryValues.AccountKey)));

            // key
            dbCommand.AddParameter((long)QueryValues.CharID);
            dbCommand.AddParameter((long)QueryValues.AccountID);
            dbCommand.AddParameter((long)QueryValues.AccountKey);
        }

        void IDBRecord.FillCommandDelete(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
            dbCommand.SetParamValue((long)QueryValues.AccountID, m_DataObject.AccountID);
            dbCommand.SetParamValue((long)QueryValues.AccountKey, m_DataObject.AccountKey);
        }

        public CharAccountBalance()
        { 
        }

        public CharAccountBalance(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharAccountBalance(long aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = aCharID;
            m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharAccountBalance(CharAccountBalanceObject obj)
        {
            m_DataObject = (CharAccountBalanceObjectInternal)obj;
        }
    }
}

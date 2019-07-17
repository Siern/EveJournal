using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpStandings (
//  fld_CorpID        integer,
//  fld_standingType  integer,
//  fld_ID            integer,
//  fld_Name          nvarchar(50),
//  fld_standing      real
//);

namespace EVEJournal
{
    partial class CorpStandings : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format("{0} {1}, {2} {3}, {4} {5}, {6} {7}, {8} {9}," +
                          "{10} {11},",
                // key
                GetFieldName(QueryValues.Key_ID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.CorpID), ColumnType.INT,
                GetFieldName(QueryValues.standingType),  ColumnType.INT,
                GetFieldName(QueryValues.ID), ColumnType.INT,
                GetFieldName(QueryValues.Name), ColumnType.TXT,
                GetFieldName(QueryValues.standing), ColumnType.DEC);
        public static string TableName = "CorpStandings";
        public static readonly long VersionNumber = 1;

        CorpStandingsObjectInternal m_DataObject = 
            new CorpStandingsObjectInternal();

        public enum QueryValues : long
        {
            // Key
            Key_ID,
            // data
            CorpID,
            standingType,
            ID,
            Name,
            standing,
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
            return m_DataObject.Key;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.Key_ID:
                    throw new NotSupportedException();

                case QueryValues.CorpID:
                case QueryValues.standingType:
                case QueryValues.ID:
                case QueryValues.Name:
                case QueryValues.standing:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                case QueryValues.Key_ID:
                    m_DataObject.Key_ID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.CorpID:
                    m_DataObject.CorpID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.standingType:
                    m_DataObject.standingType = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ID:
                    m_DataObject.ID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.Name:
                    m_DataObject.Name = DBConvert.ToString(obj);
                    return;
                case QueryValues.standing:
                    m_DataObject.standing = DBConvert.ToDecimal(obj);
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
                "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}) " +
                "VALUES(?, ?, ?, ?, ?);",
                TableName,
                GetFieldName(QueryValues.CorpID),
                GetFieldName(QueryValues.standingType),
                GetFieldName(QueryValues.ID),
                GetFieldName(QueryValues.Name),
                GetFieldName(QueryValues.standing)));

            // data
            dbCommand.AddParameter((long)QueryValues.CorpID);
            dbCommand.AddParameter((long)QueryValues.standingType);
            dbCommand.AddParameter((long)QueryValues.ID);
            dbCommand.AddParameter((long)QueryValues.Name);
            dbCommand.AddParameter((long)QueryValues.standing);
        }

        void IDBRecord.FillCommandInsert(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetParamValue((long)QueryValues.CorpID, m_DataObject.CorpID);
            dbCommand.SetParamValue((long)QueryValues.standingType, m_DataObject.standingType);
            dbCommand.SetParamValue((long)QueryValues.ID, m_DataObject.ID);
            dbCommand.SetParamValue((long)QueryValues.Name, m_DataObject.Name);
            dbCommand.SetParamValue((long)QueryValues.standing, m_DataObject.standing);
        }

        void IDBRecord.PrepareCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetCommand(String.Format(
                "UPDATE {0} SET {1}=?, {2}=?, {3}=?, {4}=?, {5}=? " +
                "WHERE {6}=?;",
                TableName,
                // data
                GetFieldName(QueryValues.CorpID),
                GetFieldName(QueryValues.standingType),
                GetFieldName(QueryValues.ID),
                GetFieldName(QueryValues.Name),
                GetFieldName(QueryValues.standing),
                // key
                GetFieldName((long)QueryValues.Key_ID)));

            // data
            dbCommand.AddParameter((long)QueryValues.CorpID);
            dbCommand.AddParameter((long)QueryValues.standingType);
            dbCommand.AddParameter((long)QueryValues.ID);
            dbCommand.AddParameter((long)QueryValues.Name);
            dbCommand.AddParameter((long)QueryValues.standing);
            // key
            dbCommand.AddParameter((long)QueryValues.Key_ID);
        }

        void IDBRecord.FillCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            // data
            dbCommand.SetParamValue((long)QueryValues.CorpID, m_DataObject.CorpID);
            dbCommand.SetParamValue((long)QueryValues.standingType, m_DataObject.standingType);
            dbCommand.SetParamValue((long)QueryValues.ID, m_DataObject.ID);
            dbCommand.SetParamValue((long)QueryValues.Name, m_DataObject.Name);
            dbCommand.SetParamValue((long)QueryValues.standing, m_DataObject.standing);
            // key
            dbCommand.SetParamValue((long)QueryValues.Key_ID, m_DataObject.Key_ID);
        }

        void IDBRecord.PrepareCommandDelete(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetCommand(String.Format(
                "DELETE FROM {0} " +
                "WHERE {1}=?;",
                TableName,
                GetFieldName(QueryValues.Key_ID)));

            // key
            dbCommand.AddParameter((long)QueryValues.Key_ID);
        }

        void IDBRecord.FillCommandDelete(Database.DatabaseCommand dbCommand)
        {
            IDBRecord iobj = this as IDBRecord;

            dbCommand.SetParamValue((long)QueryValues.Key_ID, m_DataObject.Key_ID);
        }

        public CorpStandings()
        {
        }

        public CorpStandings(SQLiteDataReader reader)
        {
            IDBRecord iobj = (IDBRecord)this;
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                iobj.SetValue((long)val, reader[iobj.GetFieldName((long)val)]);
            }//foreach
        }

        public CorpStandings(long aCorpID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = aCorpID;
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpStandings(CorpStandingsObject obj)
        {
            m_DataObject = (CorpStandingsObjectInternal)obj;
        }
    }
}

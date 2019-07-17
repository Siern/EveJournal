using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharStandings (
//  fld_CharID        integer,
//  fld_standingType  integer,
//  fld_ID            integer,
//  fld_Name          nvarchar(50),
//  fld_standing      real
//);

namespace EVEJournal
{
    partial class CharStandings : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}",
                // key
                GetFieldName(QueryValues.Key_ID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.CharID), ColumnType.INT,
                GetFieldName(QueryValues.standingType), ColumnType.INT,
                GetFieldName(QueryValues.ID), ColumnType.INT,
                GetFieldName(QueryValues.Name), ColumnType.TXT,

                GetFieldName(QueryValues.standing), ColumnType.DEC);

        public static readonly string TableName = "CharStandings";
        public static readonly long VersionNumber = 2;

        CharStandingsObjectInternal m_DataObject = 
            new CharStandingsObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // data
            CharID,
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
            return m_DataObject.Key as RecordKey;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.Key_ID:
                    throw new NotSupportedException();

                case QueryValues.CharID:
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
            switch ((QueryValues)which)
            {
                case QueryValues.Key_ID:
                    m_DataObject.Key_ID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
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

        public CharStandings()
        {
        }

        public CharStandings(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharStandings(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharStandings(CharStandingsObject obj)
        {
            m_DataObject = (CharStandingsObjectInternal)obj;
        }
    }
}

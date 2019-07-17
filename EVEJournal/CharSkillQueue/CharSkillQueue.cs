using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharSkillQueue (
//  fld_CharID         integer,
//  fld_queuePosition  integer,
//  fld_typeID         integer,
//  fld_startSP        integer,
//  fld_endSP          integer,
//  fld_startTime      datetime,
//  fld_endTime        datetime,
//  fld_level          integer
//);

namespace EVEJournal
{
    partial class CharSkillQueue : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}",
                // key
                GetFieldName(QueryValues.Key_ID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.CharID), ColumnType.INT,
                GetFieldName(QueryValues.queuePosition), ColumnType.INT,
                GetFieldName(QueryValues.typeID), ColumnType.INT,
                GetFieldName(QueryValues.startSP), ColumnType.INT,

                GetFieldName(QueryValues.endSP), ColumnType.INT,
                GetFieldName(QueryValues.startTime), ColumnType.DT,
                GetFieldName(QueryValues.endTime), ColumnType.DT,
                GetFieldName(QueryValues.level), ColumnType.INT);

        public static readonly string TableName = "CharSkillQueue";
        public static readonly long VersionNumber = 2;

        CharSkillQueueObjectInternal m_DataObject = 
            new CharSkillQueueObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // data
            CharID,
            queuePosition,
            typeID,
            startSP,
            endSP,
            startTime,
            endTime,
            level,
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
                case QueryValues.queuePosition:
                case QueryValues.typeID:
                case QueryValues.startSP:
                case QueryValues.endSP:
                case QueryValues.startTime:
                case QueryValues.endTime:
                case QueryValues.level:
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
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.queuePosition:
                    m_DataObject.queuePosition = DBConvert.ToLong(obj);
                    return;
                case QueryValues.typeID:
                    m_DataObject.typeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.startSP:
                    m_DataObject.startSP = DBConvert.ToLong(obj);
                    return;
                case QueryValues.endSP:
                    m_DataObject.endSP = DBConvert.ToLong(obj);
                    return;
                case QueryValues.startTime:
                    m_DataObject.startTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.endTime:
                    m_DataObject.endTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.level:
                    m_DataObject.level = DBConvert.ToLong(obj);
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

        public CharSkillQueue()
        {
        }

        public CharSkillQueue(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharSkillQueue(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharSkillQueue(CharSkillQueueObject obj)
        {
            m_DataObject = (CharSkillQueueObjectInternal)obj;
        }
    }
}

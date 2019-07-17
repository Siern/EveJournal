using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharSkillInTraining (
//  fld_CharID           integer PRIMARY KEY NOT NULL,
//  fld_StartTime        datetime,
//  fld_EndTime          datetime,
//  fld_TypeID           integer,
//  fld_StartSP          integer,
//  fld_EndSP            integer,
//  fld_ToLevel          integer,
//  fld_SkillInTraining  integer
//);

namespace EVEJournal
{
    partial class CharSkillInTraining : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}",
                // key
                GetFieldName(QueryValues.CharID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.StartTime), ColumnType.DT,
                GetFieldName(QueryValues.EndTime), ColumnType.DT,
                GetFieldName(QueryValues.TypeID), ColumnType.INT,
                GetFieldName(QueryValues.StartSP), ColumnType.INT,

                GetFieldName(QueryValues.EndSP), ColumnType.INT,
                GetFieldName(QueryValues.ToLevel), ColumnType.INT,
                GetFieldName(QueryValues.SkillInTraining), ColumnType.INT);

        public static readonly string TableName = "CharSkillInTraining";
        public static readonly long VersionNumber = 2;

        CharSkillInTrainingObjectInternal m_DataObject = 
            new CharSkillInTrainingObjectInternal();

        public enum QueryValues : long
        {
            // key
            CharID,
            // data
            StartTime,
            EndTime,
            TypeID,
            StartSP,
            EndSP,
            ToLevel,
            SkillInTraining,
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
                case QueryValues.CharID:
                    throw new NotSupportedException();

                case QueryValues.StartTime:
                case QueryValues.EndTime:
                case QueryValues.TypeID:
                case QueryValues.StartSP:
                case QueryValues.EndSP:
                case QueryValues.ToLevel:
                case QueryValues.SkillInTraining:
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
                case QueryValues.StartTime:
                    m_DataObject.StartTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.EndTime:
                    m_DataObject.EndTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.TypeID:
                    m_DataObject.TypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.StartSP:
                    m_DataObject.StartSP = DBConvert.ToLong(obj);
                    return;
                case QueryValues.EndSP:
                    m_DataObject.EndSP = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ToLevel:
                    m_DataObject.ToLevel = DBConvert.ToLong(obj);
                    return;
                case QueryValues.SkillInTraining:
                    m_DataObject.SkillInTraining = DBConvert.ToLong(obj);
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

        public CharSkillInTraining()
        {
        }

        public CharSkillInTraining(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharSkillInTraining(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharSkillInTraining(CharSkillInTrainingObject obj)
        {
            m_DataObject = (CharSkillInTrainingObjectInternal)obj;
        }
    }
}

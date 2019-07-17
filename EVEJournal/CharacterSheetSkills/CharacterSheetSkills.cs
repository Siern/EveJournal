using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharacterSheetSkills (
//  fld_CharID       integer,
//  fld_typeID       integer,
//  fld_skillpoints  integer,
//  fld_level        integer,
//  fld_unpublished  integer
//);

namespace EVEJournal
{
    partial class CharacterSheetSkills : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format("{0} {1}, {2} {3}, {4} {5}, {6} {7}, {8} {9}, {10} {11}",
                // key
                GetFieldName(QueryValues.Key_ID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.CharID), ColumnType.INT,
                GetFieldName(QueryValues.typeID), ColumnType.INT,
                GetFieldName(QueryValues.skillpoints), ColumnType.INT,
                GetFieldName(QueryValues.level), ColumnType.INT,
                GetFieldName(QueryValues.unpublished), ColumnType.INT);
        public static string TableName = "CharacterSheetRoles";
        public static readonly long VersionNumber = 2;

        CharacterSheetSkillsObjectInternal m_DataObject =
            new CharacterSheetSkillsObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // data
            CharID,
            typeID,
            skillpoints,
            level,
            unpublished
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
                case QueryValues.typeID:
                case QueryValues.skillpoints:
                case QueryValues.level:
                case QueryValues.unpublished:
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
                case QueryValues.typeID:
                    m_DataObject.typeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.skillpoints:
                    m_DataObject.skillpoints = DBConvert.ToLong(obj);
                    return;
                case QueryValues.level:
                    m_DataObject.level = DBConvert.ToLong(obj);
                    return;
                case QueryValues.unpublished:
                    m_DataObject.unpublished = DBConvert.ToLong(obj);
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

        public CharacterSheetSkills()
        {
        }

        public CharacterSheetSkills(SQLiteDataReader reader)
        {
            IDBRecord iobj = (IDBRecord)this;
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                iobj.SetValue((long)val, reader[iobj.GetFieldName((long)val)]);
            }//foreach
        }

        public CharacterSheetSkills(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharacterSheetSkills(CharacterSheetSkillsObject obj)
        {
            m_DataObject = (CharacterSheetSkillsObjectInternal)obj;
        }
    }
}

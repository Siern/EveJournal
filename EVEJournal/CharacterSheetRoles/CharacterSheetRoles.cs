using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharacterSheetRoles (
//  fld_CharID    integer,
//  fld_RoleType  integer,
//  fld_RoleID    integer,
//  fld_RoleName  nvarchar(50)
//);

namespace EVEJournal
{
    partial class CharacterSheetRoles : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format("{0} {1}, {2} {3}, {4} {5}, {6} {7}, {8} {9}",
                // Key
                GetFieldName(QueryValues.Key_ID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.CharID), ColumnType.INT,
                GetFieldName(QueryValues.RoleType), ColumnType.INT,
                GetFieldName(QueryValues.RoleID), ColumnType.INT,
                GetFieldName(QueryValues.RoleName), ColumnType.TXT);
        public static string TableName = "CharacterSheetRoles";
        public static readonly long VersionNumber = 2;

        CharacterSheetRolesObjectInternal m_DataObject = 
            new CharacterSheetRolesObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // data
            CharID,
            RoleType,
            RoleID,
            RoleName
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
                case QueryValues.RoleType:
                case QueryValues.RoleID:
                case QueryValues.RoleName:
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
                case QueryValues.RoleType:
                    m_DataObject.RoleType = DBConvert.ToLong(obj);
                    return;
                case QueryValues.RoleID:
                    m_DataObject.RoleID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.RoleName:
                    m_DataObject.RoleName = DBConvert.ToString(obj);
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

        public CharacterSheetRoles()
        { 
        }

        public CharacterSheetRoles(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharacterSheetRoles(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharacterSheetRoles(CharacterSheetRolesObject obj)
        {
            m_DataObject = (CharacterSheetRolesObjectInternal)obj;
        }
    }
}

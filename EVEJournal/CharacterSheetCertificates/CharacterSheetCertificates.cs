using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharacterSheetCertificates (
//  fld_CharID         integer,
//  fld_CertificateID  integer
//);

namespace EVEJournal
{
    partial class CharacterSheetCertificates : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format("{0} {1}, {2} {3}, {4} {5}",
            // Key
            GetFieldName(QueryValues.Key_ID), ColumnType.INTKEY,
            // data
            GetFieldName(QueryValues.CharID),ColumnType.INT,
            GetFieldName(QueryValues.CertificateID), ColumnType.INT);
        public static string TableName = "CharacterSheetCertificates";
        public static readonly long VersionNumber = 2;

        CharacterSheetCertificatesObjectInternal m_DataObject = 
            new CharacterSheetCertificatesObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // Data
            CharID,
            CertificateID,
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
            return m_DataObject as CharacterSheetCertificatesObject;
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
                case QueryValues.CertificateID:
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
                case QueryValues.CertificateID:
                    m_DataObject.CertificateID = DBConvert.ToLong(obj);
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

        public CharacterSheetCertificates()
        { 
        }

        public CharacterSheetCertificates(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharacterSheetCertificates(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharacterSheetCertificates(CharacterSheetCertificatesObject obj)
        {
            m_DataObject = (CharacterSheetCertificatesObjectInternal)obj;
        }
    }
}

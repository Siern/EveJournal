using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE RequestCache (
//  fld_Id          integer PRIMARY KEY NOT NULL,
//  fld_UserID      nvarchar(50),
//  fld_url         nvarchar(50),
//  fld_ValidUntil  datetime,
//  fld_Response    nvarchar(5000)
//);

namespace EVEJournal
{
    class RequestCache : IDBRecord
    {
        public static string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9} ",
                GetFieldName(QueryValues.Id), ColumnType.INTKEY,
                GetFieldName(QueryValues.UserID), ColumnType.TXT,
                GetFieldName(QueryValues.url), ColumnType.TXT,
                GetFieldName(QueryValues.ValidUntil), ColumnType.DT,
                GetFieldName(QueryValues.Response), ColumnType.TXT);

        public static string TableName = "RequestCache";
        public static readonly long VersionNumber = 2;

        RequestObjectInternal m_DataObject = 
            new RequestObjectInternal();

        public enum QueryValues : long
        {
            Id,
            UserID,
            url,
            ValidUntil,
            Response,
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
            return m_DataObject as object;
        }

        RecordKey IDBRecord.GetRecordKey()
        {
            return m_DataObject.Key as RecordKey;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.Id:
                    throw new NotSupportedException();

                case QueryValues.UserID:
                case QueryValues.url:
                case QueryValues.ValidUntil:
                case QueryValues.Response:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                case QueryValues.Id:
                    m_DataObject.ID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.UserID:
                    m_DataObject.UserID = DBConvert.ToString(obj);
                    return;
                case QueryValues.url:
                    m_DataObject.url = DBConvert.ToString(obj);
                    return;
                case QueryValues.ValidUntil:
                    m_DataObject.ValidUntil = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.Response:
                    m_DataObject.Response = DBConvert.ToString(obj);
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

        public RequestCache()
        { 
        }

        public RequestCache(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public RequestCache(RequestID RequestID, string UserID, string url, string xml)
        {
            m_DataObject.RequestID = RequestID;
            m_DataObject.UserID = UserID;
            m_DataObject.url = url;
            m_DataObject.Response = Compression.Compress(xml);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(xml));
            m_DataObject.ValidUntil = 
                DBConvert.FromCCPTime(xmlDoc.SelectSingleNode("/eveapi/cachedUntil").InnerText);
        }
    }
}

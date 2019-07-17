using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE RefTypes (
//  fld_refID  integer PRIMARY KEY NOT NULL,
//  fld_Name   nvarchar(50)
//);

namespace EVEJournal
{
    partial class ReferenceType : IDBRecord
    {
        //refID,Name
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3} ",
                GetFieldName(QueryValues.refID), ColumnType.INTKEY,
                GetFieldName(QueryValues.Name), ColumnType.TXT);

        public static readonly string TableName = "RefTypes";
        public static readonly long VersionNumber = 2;

        ReferenceTypeObjectInternal m_DataObject = 
            new ReferenceTypeObjectInternal();

        public enum QueryValues : long
        {
            refID,
            Name,
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
                case QueryValues.refID:
                    throw new NotSupportedException();

                case QueryValues.Name:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                case QueryValues.refID:
                    m_DataObject.refTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.Name:
                    m_DataObject.refTypeName = DBConvert.ToString(obj);
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

        public ReferenceType()
        { 
        }

        public ReferenceType(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public ReferenceType(XmlNode xmlNode)
        {
            this.m_DataObject.refTypeID = long.Parse(xmlNode.Attributes["refTypeID"].InnerText);
            this.m_DataObject.refTypeName = xmlNode.Attributes["refTypeName"].InnerText;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

namespace EVEJournal
{
    partial class MemberTrackingSettings : IDBRecord
    {
        //
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15} ",
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.MemberOk), ColumnType.INT,
                GetFieldName(QueryValues.MemberCaution), ColumnType.INT,
                GetFieldName(QueryValues.MemberWarning), ColumnType.INT,
                GetFieldName(QueryValues.RecruitDefinition), ColumnType.INT,

                GetFieldName(QueryValues.RecruitOk), ColumnType.INT,
                GetFieldName(QueryValues.RecruitCaution), ColumnType.INT,
                GetFieldName(QueryValues.RecruitWarning), ColumnType.INT);

        public static readonly string TableName = "MemberTrackingSettings";
        public static readonly long VersionNumber = 2;

        MemberTrackingSettingsObjectInternal m_DataObject = 
            new MemberTrackingSettingsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            // data
            MemberOk,
            MemberCaution,
            MemberWarning,
            RecruitDefinition,
            RecruitOk,
            RecruitCaution,
            RecruitWarning,
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
                // key
                case QueryValues.CorpID:
                    throw new NotSupportedException();

                // data
                case QueryValues.MemberOk:
                case QueryValues.MemberCaution:
                case QueryValues.MemberWarning:
                case QueryValues.RecruitDefinition:
                case QueryValues.RecruitOk:
                case QueryValues.RecruitCaution:
                case QueryValues.RecruitWarning:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                // key
                case QueryValues.CorpID:
                    m_DataObject.CorpID = DBConvert.ToLong(obj);
                    return;

                // data
                case QueryValues.MemberOk:
                    m_DataObject.MemberOk = DBConvert.ToLong(obj);
                    return;
                case QueryValues.MemberCaution:
                    m_DataObject.MemberCaution = DBConvert.ToLong(obj);
                    return;
                case QueryValues.MemberWarning:
                    m_DataObject.MemberWarning = DBConvert.ToLong(obj);
                    return;
                case QueryValues.RecruitDefinition:
                    m_DataObject.RecruitDefinition = DBConvert.ToLong(obj);
                    return;
                case QueryValues.RecruitOk:
                    m_DataObject.RecruitOk = DBConvert.ToLong(obj);
                    return;
                case QueryValues.RecruitCaution:
                    m_DataObject.RecruitCaution = DBConvert.ToLong(obj);
                    return;
                case QueryValues.RecruitWarning:
                    m_DataObject.RecruitWarning = DBConvert.ToLong(obj);
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

        public MemberTrackingSettings()
        {
        }

        public MemberTrackingSettings(SQLiteDataReader reader)
        {
            IDBRecord iobj = (IDBRecord)this;
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                iobj.SetValue((long)val, reader[val.ToString()]);
            }//foreach
        }
    }
}
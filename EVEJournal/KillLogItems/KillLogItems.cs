using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE KillLogItems (
//  fld_KillID        integer,
//  fld_flag          numeric(1),
//  fld_qtyDropped    integer,
//  fld_qtyDestroyed  integer,
//  fld_typeID        integer,
//  /* Foreign keys */
//  FOREIGN KEY (fld_KillID)
//    REFERENCES KillLog(fld_KillID)
//);

//CREATE TRIGGER KillLogItems_bi_fk_KillLog
//  BEFORE INSERT
//  ON KillLogItems
//BEGIN
//  SELECT CASE
//    WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL
//    THEN RAISE(ABORT, 'INSERT statement conflicted with COLUMN REFERENCE constraint [KillLogItems -> KillLog].')
//  END;
//END;

//CREATE TRIGGER KillLogItems_bu_fk_KillLog
//  BEFORE UPDATE OF fld_KillID
//  ON KillLogItems
//BEGIN
//  SELECT CASE
//    WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL
//    THEN RAISE(ABORT, 'UPDATE statement conflicted with COLUMN REFERENCE constraint [KillLogItems -> KillLog].')
//  END;
//END;

namespace EVEJournal
{
    partial class KillLogItems : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} " +
            // key
            GetFieldName(QueryValues.Key_ID), ColumnType.INTnNULL,
            // data
            GetFieldName(QueryValues.KillID), ColumnType.INT,
            GetFieldName(QueryValues.flag), ColumnType.INT,
            GetFieldName(QueryValues.qtyDropped), ColumnType.INT,
            GetFieldName(QueryValues.qtyDestroyed), ColumnType.INT,

            GetFieldName(QueryValues.typeID), ColumnType.INT,
            "FOREIGN KEY (fld_KillID) REFERENCES KillLog(fld_KillID)");

        public static readonly string TableName = "KillLogItems";
        public static readonly long VersionNumber = 2;

        private static readonly string TableTrigger = "" +
        " CREATE TRIGGER KillLogItems_bi_fk_KillLog" +
          " BEFORE INSERT" +
          " ON KillLogItems" +
        " BEGIN" +
          " SELECT CASE" +
            " WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL" +
            " THEN RAISE(ABORT, 'INSERT statement conflicted with COLUMN REFERENCE constraint [KillLogItems -> KillLog].')" +
          " END;" +
        " END;" +
        " CREATE TRIGGER KillLogItems_bu_fk_KillLog" +
          " BEFORE UPDATE OF fld_KillID" +
          " ON KillLogItems" +
        " BEGIN" +
          " SELECT CASE" +
            " WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL" +
            " THEN RAISE(ABORT, 'UPDATE statement conflicted with COLUMN REFERENCE constraint [KillLogItems -> KillLog].')" +
          " END;" +
        " END;";

        KillLogItemsObjectInternal m_DataObject = 
            new KillLogItemsObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // data
            KillID,
            flag,
            qtyDropped,
            qtyDestroyed,
            typeID,
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
                case QueryValues.Key_ID:
                    throw new NotSupportedException();

                // data
                case QueryValues.KillID:
                case QueryValues.flag:
                case QueryValues.qtyDropped:
                case QueryValues.qtyDestroyed:
                case QueryValues.typeID:
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
                case QueryValues.Key_ID:
                    m_DataObject.Key_ID = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.KillID:
                    m_DataObject.KillID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.flag:
                    m_DataObject.flag = DBConvert.ToLong(obj);
                    return;
                case QueryValues.qtyDropped:
                    m_DataObject.qtyDropped = DBConvert.ToLong(obj);
                    return;
                case QueryValues.qtyDestroyed:
                    m_DataObject.qtyDestroyed = DBConvert.ToLong(obj);
                    return;
                case QueryValues.typeID:
                    m_DataObject.typeID = DBConvert.ToLong(obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        string IDBRecord.GetDBCreateTable()
        {
            if (null == TableName)
                throw new NullReferenceException();
            return String.Format("CREATE TABLE {0} ({1}); {2}",
                TableName, TableDefinition, TableTrigger);
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

        public KillLogItems()
        {
        }

        public KillLogItems(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public KillLogItems(XmlNode xmlNode)
        {
            //m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public KillLogItems(KillLogItemsObject obj)
        {
            m_DataObject = (KillLogItemsObjectInternal)obj;
        }
    }
}

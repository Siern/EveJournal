using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE KillLog (
//  fld_KillID               integer PRIMARY KEY NOT NULL,
//  fld_SolarSystemID        integer,
//  fld_KillTime             datetime,
//  fld_moonID               integer,
//  fld_vic_allianceID       integer,
//  fld_vic_allianceName     nvarchar(50),
//  fld_vic_characterID      integer,
//  fld_vic_characterName    nvarchar(50),
//  fld_vic_corporationID    integer,
//  fld_vic_corporationName  nvarchar(50),
//  fld_vic_damageTaken      integer,
//  fld_vic_factionID        integer,
//  fld_vic_factionName      nvarchar(50),
//  fld_vic_ShipTypeID       integer
//);

//CREATE TRIGGER KillLog_au_fkr_KillLogAttackers
//  AFTER UPDATE OF fld_KillID
//  ON KillLog
//BEGIN
//  UPDATE KillLogAttackers
//  SET fld_KillID = NEW.fld_KillID
//  WHERE fld_KillID = OLD.fld_KillID;
//END;

//CREATE TRIGGER KillLog_au_fkr_KillLogItems
//  AFTER UPDATE OF fld_KillID
//  ON KillLog
//BEGIN
//  UPDATE KillLogItems
//  SET fld_KillID = NEW.fld_KillID
//  WHERE fld_KillID = OLD.fld_KillID;
//END;

//CREATE TRIGGER KillLog_bd_fkr_KillLogAttackers
//  BEFORE DELETE
//  ON KillLog
//BEGIN
//  DELETE FROM KillLogAttackers
//  WHERE fld_KillID = OLD.fld_KillID;
//END;

//CREATE TRIGGER KillLog_bd_fkr_KillLogItems
//  BEFORE DELETE
//  ON KillLog
//BEGIN
//  DELETE FROM KillLogItems
//  WHERE fld_KillID = OLD.fld_KillID;
//END;

namespace EVEJournal
{
    partial class KillLog : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, " +
                // key
                GetFieldName(QueryValues.KillID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.SolarSystemID), ColumnType.INT,
                GetFieldName(QueryValues.moonID), ColumnType.INT,
                GetFieldName(QueryValues.vic_allianceID), ColumnType.INT,
                GetFieldName(QueryValues.vic_characterID), ColumnType.INT,

                GetFieldName(QueryValues.vic_corporationID), ColumnType.INT,
                GetFieldName(QueryValues.vic_damageTaken), ColumnType.INT,
                GetFieldName(QueryValues.vic_factionID), ColumnType.INT,
                GetFieldName(QueryValues.vic_ShipTypeID), ColumnType.INT,
                GetFieldName(QueryValues.KillTime), ColumnType.DT,

                GetFieldName(QueryValues.vic_allianceName), ColumnType.TXT,
                GetFieldName(QueryValues.vic_characterName), ColumnType.TXT,
                GetFieldName(QueryValues.vic_corporationName), ColumnType.TXT,
                GetFieldName(QueryValues.vic_factionName), ColumnType.TXT);

        public static readonly string TableName = "KillLog";
        public static readonly long VersionNumber = 2;

        private static readonly string TableTrigger = "" +
        " CREATE TRIGGER KillLog_au_fkr_KillLogAttackers" +
          " AFTER UPDATE OF fld_KillID" +
          " ON KillLog" +
        " BEGIN" +
          " UPDATE KillLogAttackers" +
          " SET fld_KillID = NEW.fld_KillID" +
          " WHERE fld_KillID = OLD.fld_KillID;" +
        " END;" +
        " CREATE TRIGGER KillLog_au_fkr_KillLogItems" +
          " AFTER UPDATE OF fld_KillID" +
          " ON KillLog" +
        " BEGIN" +
          " UPDATE KillLogItems" +
          " SET fld_KillID = NEW.fld_KillID" +
          " WHERE fld_KillID = OLD.fld_KillID;" +
        " END;" +
        " CREATE TRIGGER KillLog_bd_fkr_KillLogAttackers" +
          " BEFORE DELETE" +
          " ON KillLog" +
        " BEGIN" +
          " DELETE FROM KillLogAttackers" +
          " WHERE fld_KillID = OLD.fld_KillID;" +
        " END;" +
        " CREATE TRIGGER KillLog_bd_fkr_KillLogItems" +
          " BEFORE DELETE" +
          " ON KillLog" +
        " BEGIN" +
          " DELETE FROM KillLogItems" +
          " WHERE fld_KillID = OLD.fld_KillID;" +
        " END;";

        KillLogObjectInternal m_DataObject = new KillLogObjectInternal();
        
        public enum QueryValues : long
        {
            // key
            KillID,
            // data
            SolarSystemID,
            moonID,
            vic_allianceID,
            vic_characterID,
            vic_corporationID,
            vic_damageTaken,
            vic_factionID,
            vic_ShipTypeID,
            KillTime,
            vic_allianceName,
            vic_characterName,
            vic_corporationName,
            vic_factionName,
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
                case QueryValues.KillID:
                    m_DataObject.KillID = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.SolarSystemID:
                    m_DataObject.SolarSystemID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.moonID:
                    m_DataObject.moonID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_allianceID:
                    m_DataObject.vic_allianceID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_characterID:
                    m_DataObject.vic_characterID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_corporationID:
                    m_DataObject.vic_corporationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_damageTaken:
                    m_DataObject.vic_damageTaken = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_factionID:
                    m_DataObject.vic_factionID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_ShipTypeID:
                    m_DataObject.vic_ShipTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.KillTime:
                    m_DataObject.KillTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.vic_allianceName:
                    m_DataObject.vic_allianceName = DBConvert.ToString(obj);
                    return;
                case QueryValues.vic_characterName:
                    m_DataObject.vic_characterName = DBConvert.ToString(obj);
                    return;
                case QueryValues.vic_corporationName:
                    m_DataObject.vic_corporationName = DBConvert.ToString(obj);
                    return;
                case QueryValues.vic_factionName:
                    m_DataObject.vic_factionName = DBConvert.ToString(obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                // key
                case QueryValues.KillID:
                    m_DataObject.KillID = DBConvert.ToLong(obj);
                    return;
                // data
                case QueryValues.SolarSystemID:
                    m_DataObject.SolarSystemID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.moonID:
                    m_DataObject.moonID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_allianceID:
                    m_DataObject.vic_allianceID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_characterID:
                    m_DataObject.vic_characterID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_corporationID:
                    m_DataObject.vic_corporationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_damageTaken:
                    m_DataObject.vic_damageTaken = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_factionID:
                    m_DataObject.vic_factionID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.vic_ShipTypeID:
                    m_DataObject.vic_ShipTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.KillTime:
                    m_DataObject.KillTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.vic_allianceName:
                    m_DataObject.vic_allianceName = DBConvert.ToString(obj);
                    return;
                case QueryValues.vic_characterName:
                    m_DataObject.vic_characterName = DBConvert.ToString(obj);
                    return;
                case QueryValues.vic_corporationName:
                    m_DataObject.vic_corporationName = DBConvert.ToString(obj);
                    return;
                case QueryValues.vic_factionName:
                    m_DataObject.vic_factionName = DBConvert.ToString(obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        string IDBRecord.GetDBCreateTable()
        {
            if (null == TableName || null == TableTrigger)
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

        public KillLog()
        {
        }

        public KillLog(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public KillLog(XmlNode xmlNode)
        {
            //m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public KillLog(KillLogObject obj)
        {
            m_DataObject = (KillLogObjectInternal)obj;
        }
    }
}

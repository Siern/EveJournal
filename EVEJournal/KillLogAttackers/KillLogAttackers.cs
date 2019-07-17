using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE KillLogAttackers (
//  fld_KillID           integer,
//  fld_allianceID       integer,
//  fld_allianceName     nvarchar(50),
//  fld_characterID      integer,
//  fld_characterName    nvarchar(50),
//  fld_corporationID    integer,
//  fld_corporationName  nvarchar(50),
//  fld_damageDone       integer,
//  fld_factionID        integer,
//  fld_factionName      nvarchar(50),
//  fld_finalBlow        numeric(1),
//  fld_securityStatus   real,
//  fld_shipTypeID       integer,
//  fld_weaponTypeID     integer,
//  /* Foreign keys */
//  FOREIGN KEY (fld_KillID)
//    REFERENCES KillLog(fld_KillID)
//);

//CREATE TRIGGER KillLogAttackers_bi_fk_KillLog
//  BEFORE INSERT
//  ON KillLogAttackers
//BEGIN
//  SELECT CASE
//    WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL
//    THEN RAISE(ABORT, 'INSERT statement conflicted with COLUMN REFERENCE constraint [KillLogAttackers -> KillLog].')
//  END;
//END;

//CREATE TRIGGER KillLogAttackers_bu_fk_KillLog
//  BEFORE UPDATE OF fld_KillID
//  ON KillLogAttackers
//BEGIN
//  SELECT CASE
//    WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL
//    THEN RAISE(ABORT, 'UPDATE statement conflicted with COLUMN REFERENCE constraint [KillLogAttackers -> KillLog].')
//  END;
//END;

namespace EVEJournal
{
    partial class KillLogAttackers : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                          "{30} ",
            // key
            GetFieldName(QueryValues.Key_ID), ColumnType.INTnNULL,
            // data
            GetFieldName(QueryValues.KillID), ColumnType.INT,
            GetFieldName(QueryValues.allianceID), ColumnType.INT,
            GetFieldName(QueryValues.allianceName), ColumnType.TXT,
            GetFieldName(QueryValues.characterID), ColumnType.INT,

            GetFieldName(QueryValues.characterName), ColumnType.TXT,
            GetFieldName(QueryValues.corporationID), ColumnType.INT,
            GetFieldName(QueryValues.corporationName), ColumnType.TXT,
            GetFieldName(QueryValues.damageDone), ColumnType.INT,
            GetFieldName(QueryValues.factionID), ColumnType.INT,

            GetFieldName(QueryValues.factionName), ColumnType.TXT,
            GetFieldName(QueryValues.finalBlow), ColumnType.INT,
            GetFieldName(QueryValues.securityStatus), ColumnType.DEC,
            GetFieldName(QueryValues.shipTypeID), ColumnType.INT,
            GetFieldName(QueryValues.weaponTypeID), ColumnType.INT,

            "FOREIGN KEY (fld_KillID) REFERENCES KillLog(fld_KillID)");

        public static readonly string TableName = "KillLogAttackers";
        public static readonly long VersionNumber = 2;

        private static readonly string TableTrigger = "" +
        " CREATE TRIGGER KillLogAttackers_bi_fk_KillLog" +
          " BEFORE INSERT" +
          " ON KillLogAttackers" +
        " BEGIN" +
          " SELECT CASE" +
            " WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL" +
            " THEN RAISE(ABORT, 'INSERT statement conflicted with COLUMN REFERENCE constraint [KillLogAttackers -> KillLog].')" +
          " END;" +
        " END;" +
        " CREATE TRIGGER KillLogAttackers_bu_fk_KillLog" +
          " BEFORE UPDATE OF fld_KillID" +
          " ON KillLogAttackers" +
        " BEGIN" +
          " SELECT CASE" +
            " WHEN (SELECT 1 FROM KillLog WHERE KillLog.fld_KillID = NEW.fld_KillID) IS NULL" +
            " THEN RAISE(ABORT, 'UPDATE statement conflicted with COLUMN REFERENCE constraint [KillLogAttackers -> KillLog].')" +
          " END;" +
        " END;";

        KillLogAttackersObjectInternal m_DataObject = 
            new KillLogAttackersObjectInternal();

        public enum QueryValues : long
        {
            // key
            Key_ID,
            // data
            KillID,
            allianceID,
            allianceName,
            characterID,
            characterName,
            corporationID,
            corporationName,
            damageDone,
            factionID,
            factionName,
            finalBlow,
            securityStatus,
            shipTypeID,
            weaponTypeID,
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
                case QueryValues.allianceID:
                case QueryValues.allianceName:
                case QueryValues.characterID:
                case QueryValues.characterName:
                case QueryValues.corporationID:
                case QueryValues.corporationName:
                case QueryValues.damageDone:
                case QueryValues.factionID:
                case QueryValues.factionName:
                case QueryValues.finalBlow:
                case QueryValues.securityStatus:
                case QueryValues.shipTypeID:
                case QueryValues.weaponTypeID:
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
                case QueryValues.allianceID:
                    m_DataObject.allianceID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.allianceName:
                    m_DataObject.allianceName = DBConvert.ToString(obj);
                    return;
                case QueryValues.characterID:
                    m_DataObject.characterID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.characterName:
                    m_DataObject.characterName = DBConvert.ToString(obj);
                    return;
                case QueryValues.corporationID:
                    m_DataObject.corporationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.corporationName:
                    m_DataObject.corporationName = DBConvert.ToString(obj);
                    return;
                case QueryValues.damageDone:
                    m_DataObject.damageDone = DBConvert.ToLong(obj);
                    return;
                case QueryValues.factionID:
                    m_DataObject.factionID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.factionName:
                    m_DataObject.factionName = DBConvert.ToString(obj);
                    return;
                case QueryValues.finalBlow:
                    m_DataObject.finalBlow = DBConvert.ToLong(obj);
                    return;
                case QueryValues.securityStatus:
                    m_DataObject.securityStatus = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.shipTypeID:
                    m_DataObject.shipTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.weaponTypeID:
                    m_DataObject.weaponTypeID = DBConvert.ToLong(obj);
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

        public KillLogAttackers()
        {
        }

        public KillLogAttackers(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public KillLogAttackers(XmlNode xmlNode)
        {
            //m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public KillLogAttackers(KillLogAttackersObject obj)
        {
            m_DataObject = (KillLogAttackersObjectInternal)obj;
        }
    }
}

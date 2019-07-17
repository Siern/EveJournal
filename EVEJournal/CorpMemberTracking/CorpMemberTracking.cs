using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

namespace EVEJournal
{
    partial class CorporationMemberTracking : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                          "{30} ",
            // keys
            GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
            GetFieldName(QueryValues.CharID), ColumnType.INTnNULL,
            // data
            GetFieldName(QueryValues.BaseID), ColumnType.INT,
            GetFieldName(QueryValues.LocationID), ColumnType.INT,
            GetFieldName(QueryValues.ShipID), ColumnType.INT,

            GetFieldName(QueryValues.Roles), ColumnType.INT,
            GetFieldName(QueryValues.GrantableRoles), ColumnType.INT,
            GetFieldName(QueryValues.StartDate), ColumnType.DT,
            GetFieldName(QueryValues.LastLogon), ColumnType.DT,
            GetFieldName(QueryValues.LastLogoff), ColumnType.DT,

            GetFieldName(QueryValues.Name), ColumnType.TXT,
            GetFieldName(QueryValues.Title), ColumnType.TXT,
            GetFieldName(QueryValues.BaseName), ColumnType.TXT,
            GetFieldName(QueryValues.LocationName), ColumnType.TXT,
            GetFieldName(QueryValues.ShipType), ColumnType.TXT,

            "PRIMARY KEY (fld_CorpID, fld_CharID)");

        public static readonly string TableName = "CorporationMemberTracking";
        public static readonly long VersionNumber = 2;

        CorporationMemberTrackingObjectInternal m_DataObject = 
            new CorporationMemberTrackingObjectInternal();

        public enum QueryValues : long
        {
            // keys
            CorpID,
            CharID,

            // data
            Name,
            Title,
            StartDate,
            LastLogon,
            LastLogoff,
            BaseID,
            BaseName,
            LocationID,
            LocationName,
            ShipID,
            ShipType,
            Roles,
            GrantableRoles,
        }

        string IDBRecord.GetFieldName(long which)
        {
            return GetFieldName((QueryValues)which);
        }

        static protected string GetFieldName(QueryValues which)
        {
            return "fld_" + which.ToString();
        }

        object IDBRecord.GetDataObject()
        {
            return m_DataObject as object;
        }

        string IDBRecord.TranslateQueryValue(long which)
        {
            return ((QueryValues)which).ToString();
        }

        RecordKey IDBRecord.GetRecordKey()
        {
            return m_DataObject.Key;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                // keys
                case QueryValues.CorpID:
                case QueryValues.CharID:
                    throw new NotSupportedException();
                    return;

                // data
                case QueryValues.Name:
                case QueryValues.Title:
                case QueryValues.StartDate:
                case QueryValues.LastLogon:
                case QueryValues.LastLogoff:
                case QueryValues.BaseID:
                case QueryValues.BaseName:
                case QueryValues.LocationID:
                case QueryValues.LocationName:
                case QueryValues.ShipID:
                case QueryValues.ShipType:
                case QueryValues.Roles:
                case QueryValues.GrantableRoles:
                    SetValue((QueryValues)which, obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                // keys
                case QueryValues.CorpID:
                    m_DataObject.CorpID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;

                // data
                case QueryValues.Name:
                    m_DataObject.Name = DBConvert.ToString(obj);
                    return;
                case QueryValues.Title:
                    m_DataObject.Title = DBConvert.ToString(obj);
                    return;
                case QueryValues.StartDate:
                    m_DataObject.StartDate = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.LastLogon:
                    m_DataObject.LastLogon = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.LastLogoff:
                    m_DataObject.LastLogoff = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.BaseID:
                    m_DataObject.BaseID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.BaseName:
                    m_DataObject.BaseName = DBConvert.ToString(obj);
                    return;
                case QueryValues.LocationID:
                    m_DataObject.LocationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.LocationName:
                    m_DataObject.LocationName = DBConvert.ToString(obj);
                    return;
                case QueryValues.ShipID:
                    m_DataObject.ShipID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ShipType:
                    m_DataObject.ShipType = DBConvert.ToString(obj);
                    return;
                case QueryValues.Roles:
                    m_DataObject.Roles = DBConvert.ToLong(obj);
                    return;
                case QueryValues.GrantableRoles:
                    m_DataObject.GrantableRoles = DBConvert.ToLong(obj);
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

        public CorporationMemberTracking()
        {
        }

        public CorporationMemberTracking(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorporationMemberTracking(long CorpID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = CorpID;

            m_DataObject.CharID = long.Parse(xmlNode.Attributes["characterID"].InnerText);
            m_DataObject.Name = xmlNode.Attributes["name"].InnerText;
            m_DataObject.Title = xmlNode.Attributes["title"].InnerText;
            m_DataObject.StartDate = DBConvert.FromCCPTime(xmlNode.Attributes["startDateTime"].InnerText);
            m_DataObject.LastLogon = DBConvert.FromCCPTime(xmlNode.Attributes["logonDateTime"].InnerText);
            m_DataObject.LastLogoff = DBConvert.FromCCPTime(xmlNode.Attributes["logoffDateTime"].InnerText);
            m_DataObject.BaseID = long.Parse(xmlNode.Attributes["baseID"].InnerText);
            m_DataObject.BaseName = xmlNode.Attributes["base"].InnerText;
            m_DataObject.LocationID = long.Parse(xmlNode.Attributes["locationID"].InnerText);
            m_DataObject.LocationName = xmlNode.Attributes["location"].InnerText;
            m_DataObject.ShipID = long.Parse(xmlNode.Attributes["shipTypeID"].InnerText);
            m_DataObject.ShipType = xmlNode.Attributes["shipType"].InnerText;
            m_DataObject.Roles = long.Parse(xmlNode.Attributes["roles"].InnerText);
            m_DataObject.GrantableRoles = long.Parse(xmlNode.Attributes["grantableRoles"].InnerText);

        }
    }
}
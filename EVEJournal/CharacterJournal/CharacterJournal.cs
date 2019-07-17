using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharJournal (
//  fld_CharID      integer NOT NULL,
//  fld_refID       integer NOT NULL,
//  fld_refTypeID   integer NOT NULL,
//  fld_date        datetime NOT NULL,
//  fld_ownerID1    integer NOT NULL,
//  fld_ownerID2    integer NOT NULL,
//  fld_argID       integer NOT NULL,
//  fld_amount      real,
//  fld_balance     real,
//  fld_ownerName1  nvarchar(50),
//  fld_ownerName2  nvarchar(50),
//  fld_argName1    nvarchar(50),
//  fld_reason      nvarchar(50),
//  PRIMARY KEY (fld_CharID, fld_refID, fld_refTypeID, fld_date, fld_ownerID1, fld_ownerID2, fld_argID)
//);

namespace EVEJournal
{
    partial class CharacterJournal : IDBRecord
    {
        public static readonly string TableDefinition =
            //                      |          |          |          |          |          |
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, {10} {11}, " +
                          "{12} {13}, {14} {15}, {16} {17}, {18} {19}, {20} {21}, {22} {23}, " +
                          "{24} {25}, " +
                          "PRIMARY KEY ({0}, {2}, {4}, {6}, {8}, {10}, {12})",
                //key
                GetFieldName(QueryValues.CharID), "integer NOT NULL",
                GetFieldName(QueryValues.refID), "integer NOT NULL",
                GetFieldName(QueryValues.refTypeID), "integer NOT NULL",
                GetFieldName(QueryValues.date), "datetime NOT NULL",
                GetFieldName(QueryValues.ownerID1), "integer NOT NULL",
                GetFieldName(QueryValues.ownerID2), "integer NOT NULL",
                GetFieldName(QueryValues.argID), "integer NOT NULL",
                //data
                GetFieldName(QueryValues.amount), "real",
                GetFieldName(QueryValues.balance), "real",
                GetFieldName(QueryValues.ownerName1), "nvarchar(50)",
                GetFieldName(QueryValues.ownerName2), "nvarchar(50)",
                GetFieldName(QueryValues.argName1), "nvarchar(50)",
                GetFieldName(QueryValues.reason), "nvarchar(50)");
        public static readonly string TableName = "CharJournal";
        public static readonly long VersionNumber = 2;

        CharacterJournalObjectInternal m_DataObject = 
            new CharacterJournalObjectInternal();

        public enum QueryValues : long
        {   // key
            CharID,
            refID,
            refTypeID,
            date,
            ownerID1,
            ownerID2,
            argID,
            // data
            ownerName1,
            ownerName2,
            argName1,
            amount,
            balance,
            reason,
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
            return m_DataObject as CharacterJournalObject;
        }

        RecordKey IDBRecord.GetRecordKey()
        {
            return m_DataObject.Key;
        }

        void IDBRecord.SetValue(long which, object obj)
        {
            switch ((QueryValues)which)
            {
                case QueryValues.CharID:
                case QueryValues.date:
                case QueryValues.refID:
                case QueryValues.refTypeID:
                case QueryValues.ownerID1:
                case QueryValues.ownerID2:
                case QueryValues.argID:
                    throw new NotSupportedException();
                case QueryValues.ownerName1:
                case QueryValues.ownerName2:
                case QueryValues.argName1:
                case QueryValues.amount:
                case QueryValues.balance:
                case QueryValues.reason:
                    SetValue((QueryValues)which, obj);
                    return;

            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        void SetValue(QueryValues which, object obj)
        {
            switch (which)
            {
                case QueryValues.CharID:
                    m_DataObject.CharID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.date:
                    m_DataObject.date = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.refID:
                    m_DataObject.refID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.refTypeID:
                    m_DataObject.refTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ownerName1:
                    m_DataObject.ownerName1 = DBConvert.ToString(obj);
                    return;
                case QueryValues.ownerID1:
                    m_DataObject.ownerID1 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.ownerName2:
                    m_DataObject.ownerName2 = DBConvert.ToString(obj);
                    return;
                case QueryValues.ownerID2:
                    m_DataObject.ownerID2 = DBConvert.ToLong(obj);
                    return;
                case QueryValues.argName1:
                    m_DataObject.argName1 = DBConvert.ToString(obj);
                    return;
                case QueryValues.argID:
                    m_DataObject.argID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.amount:
                    m_DataObject.amount = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.balance:
                    m_DataObject.balance = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.reason:
                    m_DataObject.reason = DBConvert.ToString(obj);
                    return;
            }
            throw new ArgumentOutOfRangeException("which", which, "");
        }

        string IDBRecord.GetDBCreateTable()
        {
            if (null == TableName)
                throw new NullReferenceException();

            StringBuilder strbuild = new StringBuilder();
            strbuild.AppendFormat("CREATE TABLE {0} ({1})",
                TableName, TableDefinition);
            return strbuild.ToString();
        }

        void IDBRecord.PrepareCommandInsert(Database.DatabaseCommand dbCommand)
        {
            IDBRecord iobj = this as IDBRecord;

            dbCommand.SetCommand(String.Format(
                "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}" +
                                 "{9}, {10}, {11}, {12}, {13}) " +
                "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);",
                TableName,
                iobj.GetFieldName((long)QueryValues.CharID),
                iobj.GetFieldName((long)QueryValues.refID),
                iobj.GetFieldName((long)QueryValues.refTypeID),
                iobj.GetFieldName((long)QueryValues.date),
                iobj.GetFieldName((long)QueryValues.ownerID1),
                iobj.GetFieldName((long)QueryValues.ownerID2),
                iobj.GetFieldName((long)QueryValues.argID),
                iobj.GetFieldName((long)QueryValues.ownerName1),
                iobj.GetFieldName((long)QueryValues.ownerName2),
                iobj.GetFieldName((long)QueryValues.argName1),
                iobj.GetFieldName((long)QueryValues.amount),
                iobj.GetFieldName((long)QueryValues.balance),
                iobj.GetFieldName((long)QueryValues.reason)));


            // key
            dbCommand.AddParameter((long)QueryValues.CharID);
            dbCommand.AddParameter((long)QueryValues.refID);
            dbCommand.AddParameter((long)QueryValues.refTypeID);
            dbCommand.AddParameter((long)QueryValues.date);
            dbCommand.AddParameter((long)QueryValues.ownerID1);
            dbCommand.AddParameter((long)QueryValues.ownerID2);
            dbCommand.AddParameter((long)QueryValues.argID);
            // data
            dbCommand.AddParameter((long)QueryValues.ownerName1);
            dbCommand.AddParameter((long)QueryValues.ownerName2);
            dbCommand.AddParameter((long)QueryValues.argName1);
            dbCommand.AddParameter((long)QueryValues.amount);
            dbCommand.AddParameter((long)QueryValues.balance);
            dbCommand.AddParameter((long)QueryValues.reason);           
        }

        void IDBRecord.FillCommandInsert(Database.DatabaseCommand dbCommand)
        {
            dbCommand.SetParamValue((long)QueryValues.CharID,  m_DataObject.CharID);
            dbCommand.SetParamValue((long)QueryValues.refID, m_DataObject.refID);
            dbCommand.SetParamValue((long)QueryValues.refTypeID, m_DataObject.refTypeID);
            dbCommand.SetParamValue((long)QueryValues.date, m_DataObject.date);
            dbCommand.SetParamValue((long)QueryValues.ownerID1, m_DataObject.ownerID1);
            dbCommand.SetParamValue((long)QueryValues.ownerID2, m_DataObject.ownerID2);
            dbCommand.SetParamValue((long)QueryValues.argID, m_DataObject.argID);
            dbCommand.SetParamValue((long)QueryValues.ownerName1, m_DataObject.ownerName1);
            dbCommand.SetParamValue((long)QueryValues.ownerName2, m_DataObject.ownerName2);
            dbCommand.SetParamValue((long)QueryValues.argName1, m_DataObject.argName1);
            dbCommand.SetParamValue((long)QueryValues.amount, m_DataObject.amount);
            dbCommand.SetParamValue((long)QueryValues.balance, m_DataObject.balance);
            dbCommand.SetParamValue((long)QueryValues.reason, m_DataObject.reason);
        }

        void IDBRecord.PrepareCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            IDBRecord iobj = this as IDBRecord;

            dbCommand.SetCommand(String.Format(
                "UPDATE {0} SET {1}=?, {2}=?, {3}=?, {4}=?, {5}=?, {6}=? " +
                    "WHERE {7}=? AND {8}=? AND {9}=? AND {10}=? AND {11}=? AND {12}=? AND {13}=?;",
                TableName,
                // data
                iobj.GetFieldName((long)QueryValues.ownerName1),
                iobj.GetFieldName((long)QueryValues.ownerName2),
                iobj.GetFieldName((long)QueryValues.argName1),
                iobj.GetFieldName((long)QueryValues.amount),
                iobj.GetFieldName((long)QueryValues.balance),
                iobj.GetFieldName((long)QueryValues.reason),
                // key
                iobj.GetFieldName((long)QueryValues.CharID),
                iobj.GetFieldName((long)QueryValues.refID),
                iobj.GetFieldName((long)QueryValues.refTypeID),
                iobj.GetFieldName((long)QueryValues.date),
                iobj.GetFieldName((long)QueryValues.ownerID1),
                iobj.GetFieldName((long)QueryValues.ownerID2),
                iobj.GetFieldName((long)QueryValues.argID)));


            // data
            dbCommand.AddParameter((long)QueryValues.ownerName1);
            dbCommand.AddParameter((long)QueryValues.ownerName2);
            dbCommand.AddParameter((long)QueryValues.argName1);
            dbCommand.AddParameter((long)QueryValues.amount);
            dbCommand.AddParameter((long)QueryValues.balance);
            dbCommand.AddParameter((long)QueryValues.reason);
            // key
            dbCommand.AddParameter((long)QueryValues.CharID);
            dbCommand.AddParameter((long)QueryValues.refID);
            dbCommand.AddParameter((long)QueryValues.refTypeID);
            dbCommand.AddParameter((long)QueryValues.date);
            dbCommand.AddParameter((long)QueryValues.ownerID1);
            dbCommand.AddParameter((long)QueryValues.ownerID2);
            dbCommand.AddParameter((long)QueryValues.argID);
        }

        void IDBRecord.FillCommandUpdate(Database.DatabaseCommand dbCommand)
        {
            // key
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
            dbCommand.SetParamValue((long)QueryValues.refID, m_DataObject.refID);
            dbCommand.SetParamValue((long)QueryValues.refTypeID, m_DataObject.refTypeID);
            dbCommand.SetParamValue((long)QueryValues.date, m_DataObject.date);
            dbCommand.SetParamValue((long)QueryValues.ownerID1, m_DataObject.ownerID1);
            dbCommand.SetParamValue((long)QueryValues.ownerID2, m_DataObject.ownerID2);
            dbCommand.SetParamValue((long)QueryValues.argID, m_DataObject.argID);
            // data
            dbCommand.SetParamValue((long)QueryValues.ownerName1, m_DataObject.ownerName1);
            dbCommand.SetParamValue((long)QueryValues.ownerName2, m_DataObject.ownerName2);
            dbCommand.SetParamValue((long)QueryValues.argName1, m_DataObject.argName1);
            dbCommand.SetParamValue((long)QueryValues.amount, m_DataObject.amount);
            dbCommand.SetParamValue((long)QueryValues.balance, m_DataObject.balance);
            dbCommand.SetParamValue((long)QueryValues.reason, m_DataObject.reason);
        }

        void IDBRecord.PrepareCommandDelete(Database.DatabaseCommand dbCommand)
        {
            IDBRecord iobj = this as IDBRecord;

            dbCommand.SetCommand(String.Format(
                "DELETE FROM {0} " +
                    "WHERE {1}=? AND {2}=? AND {3}=? AND {4}=? AND {5}=? AND {6}=? AND {7}=?;",
                TableName,
                iobj.GetFieldName((long)QueryValues.CharID),
                iobj.GetFieldName((long)QueryValues.refID),
                iobj.GetFieldName((long)QueryValues.refTypeID),
                iobj.GetFieldName((long)QueryValues.date),
                iobj.GetFieldName((long)QueryValues.ownerID1),
                iobj.GetFieldName((long)QueryValues.ownerID2),
                iobj.GetFieldName((long)QueryValues.argID)));

        }

        void IDBRecord.FillCommandDelete(Database.DatabaseCommand dbCommand)
        {
            // key
            dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.CharID);
            dbCommand.SetParamValue((long)QueryValues.refID, m_DataObject.refID);
            dbCommand.SetParamValue((long)QueryValues.refTypeID, m_DataObject.refTypeID);
            dbCommand.SetParamValue((long)QueryValues.date, m_DataObject.date);
            dbCommand.SetParamValue((long)QueryValues.ownerID1, m_DataObject.ownerID1);
            dbCommand.SetParamValue((long)QueryValues.ownerID2, m_DataObject.ownerID2);
            dbCommand.SetParamValue((long)QueryValues.argID, m_DataObject.argID);
        }

        public CharacterJournal()
        {
        }

        public CharacterJournal(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
               SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharacterJournal(CharacterJournalObject obj)
        {
            CharacterJournalObjectInternal newObj = obj as CharacterJournalObjectInternal;
            m_DataObject = newObj;
        }

        public CharacterJournal(long CharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = CharID;

            m_DataObject.date = DBConvert.FromCCPTime(xmlNode.Attributes["date"].InnerText);
            m_DataObject.refID = long.Parse(xmlNode.Attributes["refID"].InnerText);
            m_DataObject.refTypeID = long.Parse(xmlNode.Attributes["refTypeID"].InnerText);
            m_DataObject.ownerName1 = xmlNode.Attributes["ownerName1"].InnerText;
            m_DataObject.ownerID1 = long.Parse(xmlNode.Attributes["ownerID1"].InnerText);
            m_DataObject.ownerName2 = xmlNode.Attributes["ownerName2"].InnerText;
            m_DataObject.ownerID2 = long.Parse(xmlNode.Attributes["ownerID2"].InnerText);
            m_DataObject.argName1 = xmlNode.Attributes["argName1"].InnerText;
            m_DataObject.argID = long.Parse(xmlNode.Attributes["argID1"].InnerText);
            m_DataObject.amount = decimal.Parse(xmlNode.Attributes["amount"].InnerText);
            m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
            m_DataObject.reason = xmlNode.Attributes["reason"].InnerText;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharacterSheet (
//  fld_CharID             integer PRIMARY KEY NOT NULL,
//  fld_CorporationID      integer,
//  fld_cloneSkillPoints   integer,
//  fld_attr_intelligence  integer,
//  fld_attr_memory        integer,
//  fld_attr_charisma      integer,
//  fld_attr_perception    integer,
//  fld_attr_willpower     integer,
//  fld_Implant_Int_Value  integer,
//  fld_Implant_Mem_Value  integer,
//  fld_Implant_Cha_Value  integer,
//  fld_Implant_Per_Value  integer,
//  fld_Implant_Wil_Value  integer,
//  fld_balance            real,
//  fld_Name               nvarchar(50),
//  fld_race               nvarchar(50),
//  fld_bloodLine          nvarchar(50),
//  fld_gender             nvarchar(50),
//  fld_CorporationName    nvarchar(50),
//  fld_cloneName          nvarchar(50),
//  fld_Implant_Int_Name   nvarchar(50),
//  fld_Implant_Mem_Name   nvarchar(50),
//  fld_Implant_Cha_Name   nvarchar(50),
//  fld_Implant_Per_Name   nvarchar(50),
//  fld_Implant_Wil_Name   nvarchar(50)
//);

namespace EVEJournal
{
    partial class CharacterSheet : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                          "{30} {31}, {32} {33}, {34} {35}, {36} {37}, {38} {39}, " +
                          "{40} {41}, {42} {43}, {44} {45}, {46} {47}, {48} {49}",
                // key
                GetFieldName(QueryValues.CharID), ColumnType.INTKEY,
                // data
                GetFieldName(QueryValues.CorporationID), ColumnType.INT,
                GetFieldName(QueryValues.cloneSkillPoints), ColumnType.INTnNULL,
                GetFieldName(QueryValues.attr_intelligence), ColumnType.INT,
                GetFieldName(QueryValues.attr_memory), ColumnType.INT,
                GetFieldName(QueryValues.attr_charisma), ColumnType.INT,
                GetFieldName(QueryValues.attr_perception), ColumnType.INT,
                GetFieldName(QueryValues.attr_willpower), ColumnType.INT,
                GetFieldName(QueryValues.Implant_Int_Value), ColumnType.INT,
                GetFieldName(QueryValues.Implant_Mem_Value), ColumnType.INT,
                GetFieldName(QueryValues.Implant_Cha_Value), ColumnType.INT,
                GetFieldName(QueryValues.Implant_Per_Value), ColumnType.INT,
                GetFieldName(QueryValues.Implant_Wil_Value), ColumnType.INT,
                GetFieldName(QueryValues.balance), ColumnType.DEC,
                GetFieldName(QueryValues.Name), ColumnType.TXT,
                GetFieldName(QueryValues.race), ColumnType.TXT,
                GetFieldName(QueryValues.bloodLine), ColumnType.TXT,
                GetFieldName(QueryValues.gender), ColumnType.TXT,
                GetFieldName(QueryValues.CorporationName), ColumnType.TXT,
                GetFieldName(QueryValues.cloneName), ColumnType.TXT,
                GetFieldName(QueryValues.Implant_Int_Name), ColumnType.TXT,
                GetFieldName(QueryValues.Implant_Mem_Name), ColumnType.TXT,
                GetFieldName(QueryValues.Implant_Cha_Name), ColumnType.TXT,
                GetFieldName(QueryValues.Implant_Per_Name), ColumnType.TXT,
                GetFieldName(QueryValues.Implant_Wil_Name), ColumnType.TXT);
        public static string TableName = "CharacterSheet";
        public static readonly long VersionNumber = 2;

        CharacterSheetObjectInternal m_DataObject = new CharacterSheetObjectInternal();

        public enum QueryValues : long
        {
            // key
            CharID,
            // data
            CorporationID,
            cloneSkillPoints,
            attr_intelligence,
            attr_memory,
            attr_charisma,
            attr_perception,
            attr_willpower,
            Implant_Int_Value,
            Implant_Mem_Value,
            Implant_Cha_Value,
            Implant_Per_Value,
            Implant_Wil_Value,
            balance,
            Name,
            race,
            bloodLine,
            gender,
            CorporationName,
            cloneName,
            Implant_Int_Name,
            Implant_Mem_Name,
            Implant_Cha_Name,
            Implant_Per_Name,
            Implant_Wil_Name,
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
                case QueryValues.CharID:
                    throw new NotSupportedException();

                case QueryValues.CorporationID:
                case QueryValues.cloneSkillPoints:
                case QueryValues.attr_intelligence:
                case QueryValues.attr_memory:
                case QueryValues.attr_charisma:
                case QueryValues.attr_perception:
                case QueryValues.attr_willpower:
                case QueryValues.Implant_Int_Value:
                case QueryValues.Implant_Mem_Value:
                case QueryValues.Implant_Cha_Value:
                case QueryValues.Implant_Per_Value:
                case QueryValues.Implant_Wil_Value:
                case QueryValues.balance:
                case QueryValues.Name:
                case QueryValues.race:
                case QueryValues.bloodLine:
                case QueryValues.gender:
                case QueryValues.CorporationName:
                case QueryValues.cloneName:
                case QueryValues.Implant_Int_Name:
                case QueryValues.Implant_Mem_Name:
                case QueryValues.Implant_Cha_Name:
                case QueryValues.Implant_Per_Name:
                case QueryValues.Implant_Wil_Name:
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
                case QueryValues.CorporationID:
                    m_DataObject.CorporationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.cloneSkillPoints:
                    m_DataObject.cloneSkillPoints = DBConvert.ToLong(obj);
                    return;
                case QueryValues.attr_intelligence:
                    m_DataObject.attr_intelligence = DBConvert.ToLong(obj);
                    return;
                case QueryValues.attr_memory:
                    m_DataObject.attr_memory = DBConvert.ToLong(obj);
                    return;
                case QueryValues.attr_charisma:
                    m_DataObject.attr_charisma = DBConvert.ToLong(obj);
                    return;
                case QueryValues.attr_perception:
                    m_DataObject.attr_perception = DBConvert.ToLong(obj);
                    return;
                case QueryValues.attr_willpower:
                    m_DataObject.attr_willpower = DBConvert.ToLong(obj);
                    return;
                case QueryValues.Implant_Int_Value:
                    m_DataObject.Implant_Int_Value = DBConvert.ToLong(obj);
                    return;
                case QueryValues.Implant_Mem_Value:
                    m_DataObject.Implant_Mem_Value = DBConvert.ToLong(obj);
                    return;
                case QueryValues.Implant_Cha_Value:
                    m_DataObject.Implant_Cha_Value = DBConvert.ToLong(obj);
                    return;
                case QueryValues.Implant_Per_Value:
                    m_DataObject.Implant_Per_Value = DBConvert.ToLong(obj);
                    return;
                case QueryValues.Implant_Wil_Value:
                    m_DataObject.Implant_Wil_Value = DBConvert.ToLong(obj);
                    return;
                case QueryValues.balance:
                    m_DataObject.balance = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.Name:
                    m_DataObject.Name = DBConvert.ToString(obj);
                    return;
                case QueryValues.race:
                    m_DataObject.race = DBConvert.ToString(obj);
                    return;
                case QueryValues.bloodLine:
                    m_DataObject.bloodLine = DBConvert.ToString(obj);
                    return;
                case QueryValues.gender:
                    m_DataObject.gender = DBConvert.ToString(obj);
                    return;
                case QueryValues.CorporationName:
                    m_DataObject.CorporationName = DBConvert.ToString(obj);
                    return;
                case QueryValues.cloneName:
                    m_DataObject.cloneName = DBConvert.ToString(obj);
                    return;
                case QueryValues.Implant_Int_Name:
                    m_DataObject.Implant_Int_Name = DBConvert.ToString(obj);
                    return;
                case QueryValues.Implant_Mem_Name:
                    m_DataObject.Implant_Mem_Name = DBConvert.ToString(obj);
                    return;
                case QueryValues.Implant_Cha_Name:
                    m_DataObject.Implant_Cha_Name = DBConvert.ToString(obj);
                    return;
                case QueryValues.Implant_Per_Name:
                    m_DataObject.Implant_Per_Name = DBConvert.ToString(obj);
                    return;
                case QueryValues.Implant_Wil_Name:
                    m_DataObject.Implant_Wil_Name = DBConvert.ToString(obj);
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

        public CharacterSheet()
        { 
        }

        public CharacterSheet(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CharacterSheet(string aCharID, XmlNode xmlNode)
        {
            m_DataObject.CharID = long.Parse(aCharID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CharacterSheet(CharacterSheetObject obj)
        {
            m_DataObject = (CharacterSheetObjectInternal)obj;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CorpIndustryJobs (
//  fld_CorpID                                        integer NOT NULL,
//  fld_jobID                                         integer NOT NULL,
//  fld_installerID                                   integer NOT NULL,
//  fld_installTime                                   datetime NOT NULL,
//  fld_assemblyLineID                                integer,
//  fld_containerID                                   integer,
//  fld_installedItemID                               integer,
//  fld_installedItemLocationID                       integer,
//  fld_installedItemQuantity                         integer,
//  fld_installedItemProductivityLevel                integer,
//  fld_installedItemMaterialLevel                    integer,
//  fld_installedItemLicensedProductionRunsRemaining  integer,
//  fld_outputLocationID                              integer,
//  fld_runs                                          integer,
//  fld_licensedProductionRuns                        integer,
//  fld_installedInSolarSystemID                      integer,
//  fld_containerLocationID                           integer,
//  fld_installedItemTypeID                           integer,
//  fld_outputTypeID                                  integer,
//  fld_containerTypeID                               integer,
//  fld_installedItemCopy                             integer,
//  fld_completed                                     integer,
//  fld_completedSuccessfully                         integer,
//  fld_installedItemFlag                             integer,
//  fld_outputFlag                                    integer,
//  fld_activityID                                    integer,
//  fld_completedStatus                               integer,
//  fld_materialMultiplier                            real,
//  fld_charMaterialMultiplier                        real,
//  fld_timeMultiplier                                real,
//  fld_charTimeMultiplier                            real,
//  fld_beginProductionTime                           datetime,
//  fld_endProductionTime                             datetime,
//  fld_pauseProductionTime                           datetime,
//  PRIMARY KEY (fld_CharID, fld_jobID, fld_installerID, fld_installTime)
//);

namespace EVEJournal
{
    partial class CorpIndustryJobs : IDBRecord
    {
        public static readonly string TableDefinition =
            String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                          "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                          "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                          "{30} {31}, {32} {33}, {34} {35}, {36} {37}, {38} {39}, " +
                          "{40} {41}, {42} {43}, {44} {45}, {46} {47}, {48} {49}, " +
                          "{50} {51}, {52} {53}, {54} {55}, {56} {57}, {58} {59}, " +
                          "{60} {61}, {62} {63}, {64} {65}, {66} {67}, {68} ",
                // key
                GetFieldName(QueryValues.CorpID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.jobID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.installerID), ColumnType.INTnNULL,
                GetFieldName(QueryValues.installTime), ColumnType.DTnNULL,
                // data
                GetFieldName(QueryValues.assemblyLineID), ColumnType.INT,

                GetFieldName(QueryValues.containerID), ColumnType.INT,
                GetFieldName(QueryValues.installedItemID), ColumnType.INT,
                GetFieldName(QueryValues.installedItemLocationID), ColumnType.INT,
                GetFieldName(QueryValues.installedItemQuantity), ColumnType.INT,
                GetFieldName(QueryValues.installedItemProductivityLevel), ColumnType.INT,

                GetFieldName(QueryValues.installedItemMaterialLevel), ColumnType.INT,
                GetFieldName(QueryValues.installedItemLicensedProductionRunsRemaining), ColumnType.INT,
                GetFieldName(QueryValues.outputLocationID), ColumnType.INT,
                GetFieldName(QueryValues.runs), ColumnType.INT,
                GetFieldName(QueryValues.licensedProductionRuns), ColumnType.INT,

                GetFieldName(QueryValues.installedInSolarSystemID), ColumnType.INT,
                GetFieldName(QueryValues.containerLocationID), ColumnType.INT,
                GetFieldName(QueryValues.installedItemTypeID), ColumnType.INT,
                GetFieldName(QueryValues.outputTypeID), ColumnType.INT,
                GetFieldName(QueryValues.containerTypeID), ColumnType.INT,

                GetFieldName(QueryValues.installedItemCopy), ColumnType.INT,
                GetFieldName(QueryValues.completed), ColumnType.INT,
                GetFieldName(QueryValues.completedSuccessfully), ColumnType.INT,
                GetFieldName(QueryValues.installedItemFlag), ColumnType.INT,
                GetFieldName(QueryValues.outputFlag), ColumnType.INT,

                GetFieldName(QueryValues.activityID), ColumnType.INT,
                GetFieldName(QueryValues.completedStatus), ColumnType.INT,
                GetFieldName(QueryValues.materialMultiplier), ColumnType.DEC,
                GetFieldName(QueryValues.charMaterialMultiplier), ColumnType.DEC,
                GetFieldName(QueryValues.timeMultiplier), ColumnType.DEC,

                GetFieldName(QueryValues.charTimeMultiplier), ColumnType.DEC,
                GetFieldName(QueryValues.beginProductionTime), ColumnType.DT,
                GetFieldName(QueryValues.endProductionTime), ColumnType.DT,
                GetFieldName(QueryValues.pauseProductionTime), ColumnType.DT,
                "PRIMARY KEY (fld_CharID, fld_jobID, fld_installerID, fld_installTime)");

        public static readonly string TableName = "CorpIndustryJobs";
        public static readonly long VersionNumber = 2;

        CorpIndustryJobsObjectInternal m_DataObject = 
            new CorpIndustryJobsObjectInternal();

        public enum QueryValues : long
        {
            // key
            CorpID,
            jobID,
            installerID,
            installTime,

            // data
            assemblyLineID,
            containerID,
            installedItemID,
            installedItemLocationID,
            installedItemQuantity,
            installedItemProductivityLevel,
            installedItemMaterialLevel,
            installedItemLicensedProductionRunsRemaining,
            outputLocationID,
            runs,
            licensedProductionRuns,
            installedInSolarSystemID,
            containerLocationID,
            installedItemTypeID,
            outputTypeID,
            containerTypeID,
            installedItemCopy,
            completed,
            completedSuccessfully,
            installedItemFlag,
            outputFlag,
            activityID,
            completedStatus,
            materialMultiplier,
            charMaterialMultiplier,
            timeMultiplier,
            charTimeMultiplier,
            beginProductionTime,
            endProductionTime,
            pauseProductionTime,
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
                case QueryValues.jobID:
                case QueryValues.installerID:
                case QueryValues.installTime:
                    throw new NotSupportedException();

                // data
                case QueryValues.assemblyLineID:
                case QueryValues.containerID:
                case QueryValues.installedItemID:
                case QueryValues.installedItemLocationID:
                case QueryValues.installedItemQuantity:
                case QueryValues.installedItemProductivityLevel:
                case QueryValues.installedItemMaterialLevel:
                case QueryValues.installedItemLicensedProductionRunsRemaining:
                case QueryValues.outputLocationID:
                case QueryValues.runs:
                case QueryValues.licensedProductionRuns:
                case QueryValues.installedInSolarSystemID:
                case QueryValues.containerLocationID:
                case QueryValues.installedItemTypeID:
                case QueryValues.outputTypeID:
                case QueryValues.containerTypeID:
                case QueryValues.installedItemCopy:
                case QueryValues.completed:
                case QueryValues.completedSuccessfully:
                case QueryValues.installedItemFlag:
                case QueryValues.outputFlag:
                case QueryValues.activityID:
                case QueryValues.completedStatus:
                case QueryValues.materialMultiplier:
                case QueryValues.charMaterialMultiplier:
                case QueryValues.timeMultiplier:
                case QueryValues.charTimeMultiplier:
                case QueryValues.beginProductionTime:
                case QueryValues.endProductionTime:
                case QueryValues.pauseProductionTime:
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
                case QueryValues.jobID:
                    m_DataObject.jobID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installerID:
                    m_DataObject.installerID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installTime:
                    m_DataObject.installTime = DBConvert.ToDateTime(obj);
                    return;

                // data
                case QueryValues.assemblyLineID:
                    m_DataObject.assemblyLineID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.containerID:
                    m_DataObject.containerID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemID:
                    m_DataObject.installedItemID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemLocationID:
                    m_DataObject.installedItemLocationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemQuantity:
                    m_DataObject.installedItemQuantity = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemProductivityLevel:
                    m_DataObject.installedItemProductivityLevel = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemMaterialLevel:
                    m_DataObject.installedItemMaterialLevel = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemLicensedProductionRunsRemaining:
                    m_DataObject.installedItemLicensedProductionRunsRemaining = DBConvert.ToLong(obj);
                    return;
                case QueryValues.outputLocationID:
                    m_DataObject.outputLocationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.runs:
                    m_DataObject.runs = DBConvert.ToLong(obj);
                    return;
                case QueryValues.licensedProductionRuns:
                    m_DataObject.licensedProductionRuns = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedInSolarSystemID:
                    m_DataObject.installedInSolarSystemID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.containerLocationID:
                    m_DataObject.containerLocationID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemTypeID:
                    m_DataObject.installedItemTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.outputTypeID:
                    m_DataObject.outputTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.containerTypeID:
                    m_DataObject.containerTypeID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemCopy:
                    m_DataObject.installedItemCopy = DBConvert.ToLong(obj);
                    return;
                case QueryValues.completed:
                    m_DataObject.completed = DBConvert.ToLong(obj);
                    return;
                case QueryValues.completedSuccessfully:
                    m_DataObject.completedSuccessfully = DBConvert.ToLong(obj);
                    return;
                case QueryValues.installedItemFlag:
                    m_DataObject.installedItemFlag = DBConvert.ToLong(obj);
                    return;
                case QueryValues.outputFlag:
                    m_DataObject.outputFlag = DBConvert.ToLong(obj);
                    return;
                case QueryValues.activityID:
                    m_DataObject.activityID = DBConvert.ToLong(obj);
                    return;
                case QueryValues.completedStatus:
                    m_DataObject.completedStatus = DBConvert.ToLong(obj);
                    return;
                case QueryValues.materialMultiplier:
                    m_DataObject.materialMultiplier = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.charMaterialMultiplier:
                    m_DataObject.charMaterialMultiplier = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.timeMultiplier:
                    m_DataObject.timeMultiplier = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.charTimeMultiplier:
                    m_DataObject.charTimeMultiplier = DBConvert.ToDecimal(obj);
                    return;
                case QueryValues.beginProductionTime:
                    m_DataObject.beginProductionTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.endProductionTime:
                    m_DataObject.endProductionTime = DBConvert.ToDateTime(obj);
                    return;
                case QueryValues.pauseProductionTime:
                    m_DataObject.pauseProductionTime = DBConvert.ToDateTime(obj);
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

        public CorpIndustryJobs()
        {
        }

        public CorpIndustryJobs(SQLiteDataReader reader)
        {
            foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
            {
                SetValue(val, reader[GetFieldName(val)]);
            }//foreach
        }

        public CorpIndustryJobs(string aCorpID, XmlNode xmlNode)
        {
            m_DataObject.CorpID = long.Parse(aCorpID);
            //m_DataObject.AccountID = long.Parse(xmlNode.Attributes["accountID"].InnerText);
            //m_DataObject.AccountKey = long.Parse(xmlNode.Attributes["accountKey"].InnerText);
            //m_DataObject.balance = decimal.Parse(xmlNode.Attributes["balance"].InnerText);
        }

        public CorpIndustryJobs(CorpIndustryJobsObject obj)
        {
            m_DataObject = (CorpIndustryJobsObjectInternal)obj;
        }
    }
}

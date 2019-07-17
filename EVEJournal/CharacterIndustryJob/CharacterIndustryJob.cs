using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

//CREATE TABLE CharIndustryJobs (
//  fld_CharID                                        integer NOT NULL,
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
    partial class CharacterIndustryJobCollection : BaseCollection
    {
        private partial class CharacterIndustryJob : IDBRecord
        {
            public static readonly string TableDefinition =
                //                  1   |      2   |      3   |      4   |      5   |
                String.Format(" {0}  {1},  {2}  {3},  {4}  {5},  {6}  {7},  {8}  {9}, " +
                              "{10} {11}, {12} {13}, {14} {15}, {16} {17}, {18} {19}, " +
                              "{20} {21}, {22} {23}, {24} {25}, {26} {27}, {28} {29}, " +
                              "{30} {31}, {32} {33}, {34} {35}, {36} {37}, {38} {39}, " +
                              "{40} {41}, {42} {43}, {44} {45}, {46} {47}, {48} {49}, " +
                              "{50} {51}, {52} {53}, {54} {55}, {56} {57}, {58} {59}, " +
                              "{60} {61}, {62} {63}, {64} {65}, {66} {67}, " +
                              "PRIMARY KEY ({0}, {2}, {4}, {6})",
                    // key
                    GetFieldName(QueryValues.CharID), ColumnType.INTnNULL,
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
                    GetFieldName(QueryValues.installedItemCopy), ColumnType.INT,
                    GetFieldName(QueryValues.completed), ColumnType.INT,
                    GetFieldName(QueryValues.completedSuccessfully), ColumnType.INT,
                    GetFieldName(QueryValues.installedItemFlag), ColumnType.INT,
                    GetFieldName(QueryValues.outputFlag), ColumnType.INT,
                    GetFieldName(QueryValues.activityID), ColumnType.INT,
                    GetFieldName(QueryValues.completedStatus), ColumnType.INT,
                    GetFieldName(QueryValues.installedItemTypeID), ColumnType.INT,
                    GetFieldName(QueryValues.outputTypeID), ColumnType.INT,
                    GetFieldName(QueryValues.containerTypeID), ColumnType.INT,
                    GetFieldName(QueryValues.materialMultiplier), ColumnType.DEC,
                    GetFieldName(QueryValues.charMaterialMultiplier), ColumnType.DEC,
                    GetFieldName(QueryValues.timeMultiplier), ColumnType.DEC,
                    GetFieldName(QueryValues.charTimeMultiplier), ColumnType.DEC,
                    GetFieldName(QueryValues.beginProductionTime), ColumnType.DT,
                    GetFieldName(QueryValues.endProductionTime), ColumnType.DT,
                    GetFieldName(QueryValues.pauseProductionTime), ColumnType.DT);
                
            public static readonly string TableName = "CharIndustryJob";
            public static readonly long VersionNumber = 1;

            CharacterIndustryJobObjectInternal m_DataObject = 
                new CharacterIndustryJobObjectInternal();

            public enum QueryValues : long
            {
                // key
                CharID,
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
                materialMultiplier,
                charMaterialMultiplier,
                timeMultiplier,
                charTimeMultiplier,
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
                beginProductionTime, 
                endProductionTime, 
                pauseProductionTime
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
                return m_DataObject as CharacterIndustryJobObject;
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
                    case QueryValues.jobID:
                    case QueryValues.installerID:
                    case QueryValues.installTime:
                        throw new NotSupportedException();

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
                    case QueryValues.materialMultiplier:
                    case QueryValues.charMaterialMultiplier:
                    case QueryValues.timeMultiplier:
                    case QueryValues.charTimeMultiplier:
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
                    case QueryValues.beginProductionTime:
                    case QueryValues.endProductionTime:
                    case QueryValues.pauseProductionTime:
                        SetValue((QueryValues)which, obj);
                        return;
                }//switch
                throw new ArgumentOutOfRangeException("which", which, "");
            }

            void SetValue(QueryValues which, object obj)
            {
                switch (which)
                {
                    case QueryValues.CharID:
                        m_DataObject.charID = DBConvert.ToLong(obj);
                        return;
                    case QueryValues.jobID:
                        m_DataObject.jobID = DBConvert.ToLong(obj);
                        return;
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
                    case QueryValues.installerID:
                        m_DataObject.installerID = DBConvert.ToLong(obj);
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
                    case QueryValues.installTime:
                        m_DataObject.installTime = DBConvert.ToDateTime(obj);
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
                }//switch
                throw new ArgumentOutOfRangeException("which", which, "");
            }

            string IDBRecord.GetDBCreateTable()
            {
                if (null == TableName)
                    throw new NullReferenceException();
                return "CREATE TABLE " + TableName + " (" + TableDefinition + ")";
            }

            void IDBRecord.PrepareCommandInsert(Database.DatabaseCommand dbCommand)
            {
                dbCommand.SetCommand(String.Format(
                    "INSERT INTO {0} ({1}, {2}, {3}, {4}, " +
                        "{5}, {6}, {7}, {8}, {9}, {10}, " +
                        "{11}, {12}, {13}, {14}, {15}, {16}, " +
                        "{17}, {18}, {19}, {20}, {21}, {22}, " +
                        "{23}, {24}, {25}, {26}, {27}, {28}, " +
                        "{29}, {30}, {31}, {32}, {33}, {34}) " +
                    "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);",
                    TableName,
                    // key
                    GetFieldName(QueryValues.CharID),
                    GetFieldName(QueryValues.jobID),
                    GetFieldName(QueryValues.installerID),
                    GetFieldName(QueryValues.installTime),
                    // data
                    GetFieldName(QueryValues.assemblyLineID),
                    GetFieldName(QueryValues.containerID),
                    GetFieldName(QueryValues.installedItemID),
                    GetFieldName(QueryValues.installedItemLocationID),
                    GetFieldName(QueryValues.installedItemQuantity),
                    GetFieldName(QueryValues.installedItemProductivityLevel),

                    GetFieldName(QueryValues.installedItemMaterialLevel),
                    GetFieldName(QueryValues.installedItemLicensedProductionRunsRemaining),
                    GetFieldName(QueryValues.outputLocationID),
                    GetFieldName(QueryValues.runs),
                    GetFieldName(QueryValues.licensedProductionRuns),
                    GetFieldName(QueryValues.installedInSolarSystemID),

                    GetFieldName(QueryValues.containerLocationID),
                    GetFieldName(QueryValues.materialMultiplier),
                    GetFieldName(QueryValues.charMaterialMultiplier),
                    GetFieldName(QueryValues.timeMultiplier),
                    GetFieldName(QueryValues.charTimeMultiplier),
                    GetFieldName(QueryValues.installedItemTypeID),

                    GetFieldName(QueryValues.outputTypeID),
                    GetFieldName(QueryValues.containerTypeID),
                    GetFieldName(QueryValues.installedItemCopy),
                    GetFieldName(QueryValues.completed),
                    GetFieldName(QueryValues.completedSuccessfully),
                    GetFieldName(QueryValues.installedItemFlag),

                    GetFieldName(QueryValues.outputFlag),
                    GetFieldName(QueryValues.activityID),
                    GetFieldName(QueryValues.completedStatus),
                    GetFieldName(QueryValues.beginProductionTime),
                    GetFieldName(QueryValues.endProductionTime),
                    GetFieldName(QueryValues.pauseProductionTime)));

                // key
                dbCommand.AddParameter((long)QueryValues.CharID);
                dbCommand.AddParameter((long)QueryValues.jobID);
                dbCommand.AddParameter((long)QueryValues.installerID);
                dbCommand.AddParameter((long)QueryValues.installTime);
                // data
                dbCommand.AddParameter((long)QueryValues.assemblyLineID);
                dbCommand.AddParameter((long)QueryValues.containerID);
                dbCommand.AddParameter((long)QueryValues.installedItemID);
                dbCommand.AddParameter((long)QueryValues.installedItemLocationID);
                dbCommand.AddParameter((long)QueryValues.installedItemQuantity);
                dbCommand.AddParameter((long)QueryValues.installedItemProductivityLevel);
                dbCommand.AddParameter((long)QueryValues.installedItemMaterialLevel);
                dbCommand.AddParameter((long)QueryValues.installedItemLicensedProductionRunsRemaining);
                dbCommand.AddParameter((long)QueryValues.outputLocationID);
                dbCommand.AddParameter((long)QueryValues.runs);
                dbCommand.AddParameter((long)QueryValues.licensedProductionRuns);
                dbCommand.AddParameter((long)QueryValues.installedInSolarSystemID);
                dbCommand.AddParameter((long)QueryValues.containerLocationID);
                dbCommand.AddParameter((long)QueryValues.materialMultiplier);
                dbCommand.AddParameter((long)QueryValues.charMaterialMultiplier);
                dbCommand.AddParameter((long)QueryValues.timeMultiplier);
                dbCommand.AddParameter((long)QueryValues.charTimeMultiplier);
                dbCommand.AddParameter((long)QueryValues.installedItemTypeID);
                dbCommand.AddParameter((long)QueryValues.outputTypeID);
                dbCommand.AddParameter((long)QueryValues.containerTypeID);
                dbCommand.AddParameter((long)QueryValues.installedItemCopy);
                dbCommand.AddParameter((long)QueryValues.completed);
                dbCommand.AddParameter((long)QueryValues.completedSuccessfully);
                dbCommand.AddParameter((long)QueryValues.installedItemFlag);
                dbCommand.AddParameter((long)QueryValues.outputFlag);
                dbCommand.AddParameter((long)QueryValues.activityID);
                dbCommand.AddParameter((long)QueryValues.completedStatus);
                dbCommand.AddParameter((long)QueryValues.beginProductionTime);
                dbCommand.AddParameter((long)QueryValues.endProductionTime);
                dbCommand.AddParameter((long)QueryValues.pauseProductionTime);
            }

            void IDBRecord.FillCommandInsert(Database.DatabaseCommand dbCommand)
            {
                // key
                dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.charID);
                dbCommand.SetParamValue((long)QueryValues.jobID, m_DataObject.jobID);
                dbCommand.SetParamValue((long)QueryValues.installerID, m_DataObject.installerID);
                dbCommand.SetParamValue((long)QueryValues.installTime, m_DataObject.installTime);
                // data
                dbCommand.SetParamValue((long)QueryValues.assemblyLineID, m_DataObject.assemblyLineID);
                dbCommand.SetParamValue((long)QueryValues.containerID, m_DataObject.containerID);
                dbCommand.SetParamValue((long)QueryValues.installedItemID, m_DataObject.installedItemID);
                dbCommand.SetParamValue((long)QueryValues.installedItemLocationID, m_DataObject.installedItemLocationID);
                dbCommand.SetParamValue((long)QueryValues.installedItemQuantity, m_DataObject.installedItemQuantity);
                dbCommand.SetParamValue((long)QueryValues.installedItemProductivityLevel, m_DataObject.installedItemProductivityLevel);
                dbCommand.SetParamValue((long)QueryValues.installedItemMaterialLevel, m_DataObject.installedItemMaterialLevel);
                dbCommand.SetParamValue((long)QueryValues.installedItemLicensedProductionRunsRemaining, m_DataObject.installedItemLicensedProductionRunsRemaining);
                dbCommand.SetParamValue((long)QueryValues.outputLocationID, m_DataObject.outputLocationID);
                dbCommand.SetParamValue((long)QueryValues.runs, m_DataObject.runs);
                dbCommand.SetParamValue((long)QueryValues.licensedProductionRuns, m_DataObject.licensedProductionRuns);
                dbCommand.SetParamValue((long)QueryValues.installedInSolarSystemID, m_DataObject.installedInSolarSystemID);
                dbCommand.SetParamValue((long)QueryValues.containerLocationID, m_DataObject.containerLocationID);
                dbCommand.SetParamValue((long)QueryValues.materialMultiplier, m_DataObject.materialMultiplier);
                dbCommand.SetParamValue((long)QueryValues.charMaterialMultiplier, m_DataObject.charMaterialMultiplier);
                dbCommand.SetParamValue((long)QueryValues.timeMultiplier, m_DataObject.timeMultiplier);
                dbCommand.SetParamValue((long)QueryValues.charTimeMultiplier, m_DataObject.charTimeMultiplier);
                dbCommand.SetParamValue((long)QueryValues.installedItemTypeID, m_DataObject.installedItemTypeID);
                dbCommand.SetParamValue((long)QueryValues.outputTypeID,  m_DataObject.outputTypeID);
                dbCommand.SetParamValue((long)QueryValues.containerTypeID, m_DataObject.containerTypeID);
                dbCommand.SetParamValue((long)QueryValues.installedItemCopy, m_DataObject.installedItemCopy);
                dbCommand.SetParamValue((long)QueryValues.completed, m_DataObject.completed);
                dbCommand.SetParamValue((long)QueryValues.completedSuccessfully, m_DataObject.completedSuccessfully);
                dbCommand.SetParamValue((long)QueryValues.installedItemFlag, m_DataObject.installedItemFlag);
                dbCommand.SetParamValue((long)QueryValues.outputFlag, m_DataObject.outputFlag);
                dbCommand.SetParamValue((long)QueryValues.activityID, m_DataObject.activityID);
                dbCommand.SetParamValue((long)QueryValues.completedStatus, m_DataObject.completedStatus);
                dbCommand.SetParamValue((long)QueryValues.beginProductionTime, m_DataObject.beginProductionTime);
                dbCommand.SetParamValue((long)QueryValues.endProductionTime, m_DataObject.endProductionTime);
                dbCommand.SetParamValue((long)QueryValues.pauseProductionTime, m_DataObject.pauseProductionTime);
            }

            void IDBRecord.PrepareCommandUpdate(Database.DatabaseCommand dbCommand)
            {
                dbCommand.SetCommand(String.Format(
                    "UPDATE {0} SET " +
                        " {5}=?,  {6}=?,  {7}=?,  {8}=?,  {9}=?, {10}=?, " +
                        "{11}=?, {12}=?, {13}=?, {14}=?, {15}=?, {16}=?, " +
                        "{17}=?, {18}=?, {19}=?, {20}=?, {21}=?, {22}=?, " +
                        "{23}=?, {24}=?, {25}=?, {26}=?, {27}=?, {28}=?, " +
                        "{29}=?, {30}=?, {31}=?, {32}=?, {33}=?, {34}=? " +
                    "WHERE {1}=? AND {2}=? AND {3}=? AND {4}=?;",
                    TableName,
                    // key
                    GetFieldName(QueryValues.CharID),
                    GetFieldName(QueryValues.jobID),
                    GetFieldName(QueryValues.installerID),
                    GetFieldName(QueryValues.installTime),
                    // data
                    GetFieldName(QueryValues.assemblyLineID),
                    GetFieldName(QueryValues.containerID),
                    GetFieldName(QueryValues.installedItemID),
                    GetFieldName(QueryValues.installedItemLocationID),
                    GetFieldName(QueryValues.installedItemQuantity),
                    GetFieldName(QueryValues.installedItemProductivityLevel),

                    GetFieldName(QueryValues.installedItemMaterialLevel),
                    GetFieldName(QueryValues.installedItemLicensedProductionRunsRemaining),
                    GetFieldName(QueryValues.outputLocationID),
                    GetFieldName(QueryValues.runs),
                    GetFieldName(QueryValues.licensedProductionRuns),
                    GetFieldName(QueryValues.installedInSolarSystemID),

                    GetFieldName(QueryValues.containerLocationID),
                    GetFieldName(QueryValues.materialMultiplier),
                    GetFieldName(QueryValues.charMaterialMultiplier),
                    GetFieldName(QueryValues.timeMultiplier),
                    GetFieldName(QueryValues.charTimeMultiplier),
                    GetFieldName(QueryValues.installedItemTypeID),

                    GetFieldName(QueryValues.outputTypeID),
                    GetFieldName(QueryValues.containerTypeID),
                    GetFieldName(QueryValues.installedItemCopy),
                    GetFieldName(QueryValues.completed),
                    GetFieldName(QueryValues.completedSuccessfully),
                    GetFieldName(QueryValues.installedItemFlag),

                    GetFieldName(QueryValues.outputFlag),
                    GetFieldName(QueryValues.activityID),
                    GetFieldName(QueryValues.completedStatus),
                    GetFieldName(QueryValues.beginProductionTime),
                    GetFieldName(QueryValues.endProductionTime),
                    GetFieldName(QueryValues.pauseProductionTime)));

                // data
                dbCommand.AddParameter((long)QueryValues.assemblyLineID);
                dbCommand.AddParameter((long)QueryValues.containerID);
                dbCommand.AddParameter((long)QueryValues.installedItemID);
                dbCommand.AddParameter((long)QueryValues.installedItemLocationID);
                dbCommand.AddParameter((long)QueryValues.installedItemQuantity);
                dbCommand.AddParameter((long)QueryValues.installedItemProductivityLevel);
                dbCommand.AddParameter((long)QueryValues.installedItemMaterialLevel);
                dbCommand.AddParameter((long)QueryValues.installedItemLicensedProductionRunsRemaining);
                dbCommand.AddParameter((long)QueryValues.outputLocationID);
                dbCommand.AddParameter((long)QueryValues.runs);
                dbCommand.AddParameter((long)QueryValues.licensedProductionRuns);
                dbCommand.AddParameter((long)QueryValues.installedInSolarSystemID);
                dbCommand.AddParameter((long)QueryValues.containerLocationID);
                dbCommand.AddParameter((long)QueryValues.materialMultiplier);
                dbCommand.AddParameter((long)QueryValues.charMaterialMultiplier);
                dbCommand.AddParameter((long)QueryValues.timeMultiplier);
                dbCommand.AddParameter((long)QueryValues.charTimeMultiplier);
                dbCommand.AddParameter((long)QueryValues.installedItemTypeID);
                dbCommand.AddParameter((long)QueryValues.outputTypeID);
                dbCommand.AddParameter((long)QueryValues.containerTypeID);
                dbCommand.AddParameter((long)QueryValues.installedItemCopy);
                dbCommand.AddParameter((long)QueryValues.completed);
                dbCommand.AddParameter((long)QueryValues.completedSuccessfully);
                dbCommand.AddParameter((long)QueryValues.installedItemFlag);
                dbCommand.AddParameter((long)QueryValues.outputFlag);
                dbCommand.AddParameter((long)QueryValues.activityID);
                dbCommand.AddParameter((long)QueryValues.completedStatus);
                dbCommand.AddParameter((long)QueryValues.beginProductionTime);
                dbCommand.AddParameter((long)QueryValues.endProductionTime);
                dbCommand.AddParameter((long)QueryValues.pauseProductionTime);
                // key
                dbCommand.AddParameter((long)QueryValues.CharID);
                dbCommand.AddParameter((long)QueryValues.jobID);
                dbCommand.AddParameter((long)QueryValues.installerID);
                dbCommand.AddParameter((long)QueryValues.installTime);
            }

            void IDBRecord.FillCommandUpdate(Database.DatabaseCommand dbCommand)
            {
                // key
                dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.charID);
                dbCommand.SetParamValue((long)QueryValues.jobID, m_DataObject.jobID);
                dbCommand.SetParamValue((long)QueryValues.installerID, m_DataObject.installerID);
                dbCommand.SetParamValue((long)QueryValues.installTime, m_DataObject.installTime);
                // data
                dbCommand.SetParamValue((long)QueryValues.assemblyLineID, m_DataObject.assemblyLineID);
                dbCommand.SetParamValue((long)QueryValues.containerID, m_DataObject.containerID);
                dbCommand.SetParamValue((long)QueryValues.installedItemID, m_DataObject.installedItemID);
                dbCommand.SetParamValue((long)QueryValues.installedItemLocationID, m_DataObject.installedItemLocationID);
                dbCommand.SetParamValue((long)QueryValues.installedItemQuantity, m_DataObject.installedItemQuantity);
                dbCommand.SetParamValue((long)QueryValues.installedItemProductivityLevel, m_DataObject.installedItemProductivityLevel);
                dbCommand.SetParamValue((long)QueryValues.installedItemMaterialLevel, m_DataObject.installedItemMaterialLevel);
                dbCommand.SetParamValue((long)QueryValues.installedItemLicensedProductionRunsRemaining, m_DataObject.installedItemLicensedProductionRunsRemaining);
                dbCommand.SetParamValue((long)QueryValues.outputLocationID, m_DataObject.outputLocationID);
                dbCommand.SetParamValue((long)QueryValues.runs, m_DataObject.runs);
                dbCommand.SetParamValue((long)QueryValues.licensedProductionRuns, m_DataObject.licensedProductionRuns);
                dbCommand.SetParamValue((long)QueryValues.installedInSolarSystemID, m_DataObject.installedInSolarSystemID);
                dbCommand.SetParamValue((long)QueryValues.containerLocationID, m_DataObject.containerLocationID);
                dbCommand.SetParamValue((long)QueryValues.materialMultiplier, m_DataObject.materialMultiplier);
                dbCommand.SetParamValue((long)QueryValues.charMaterialMultiplier, m_DataObject.charMaterialMultiplier);
                dbCommand.SetParamValue((long)QueryValues.timeMultiplier, m_DataObject.timeMultiplier);
                dbCommand.SetParamValue((long)QueryValues.charTimeMultiplier, m_DataObject.charTimeMultiplier);
                dbCommand.SetParamValue((long)QueryValues.installedItemTypeID, m_DataObject.installedItemTypeID);
                dbCommand.SetParamValue((long)QueryValues.outputTypeID, m_DataObject.outputTypeID);
                dbCommand.SetParamValue((long)QueryValues.containerTypeID, m_DataObject.containerTypeID);
                dbCommand.SetParamValue((long)QueryValues.installedItemCopy, m_DataObject.installedItemCopy);
                dbCommand.SetParamValue((long)QueryValues.completed, m_DataObject.completed);
                dbCommand.SetParamValue((long)QueryValues.completedSuccessfully, m_DataObject.completedSuccessfully);
                dbCommand.SetParamValue((long)QueryValues.installedItemFlag, m_DataObject.installedItemFlag);
                dbCommand.SetParamValue((long)QueryValues.outputFlag, m_DataObject.outputFlag);
                dbCommand.SetParamValue((long)QueryValues.activityID, m_DataObject.activityID);
                dbCommand.SetParamValue((long)QueryValues.completedStatus, m_DataObject.completedStatus);
                dbCommand.SetParamValue((long)QueryValues.beginProductionTime, m_DataObject.beginProductionTime);
                dbCommand.SetParamValue((long)QueryValues.endProductionTime, m_DataObject.endProductionTime);
                dbCommand.SetParamValue((long)QueryValues.pauseProductionTime, m_DataObject.pauseProductionTime);
            }

            void IDBRecord.PrepareCommandDelete(Database.DatabaseCommand dbCommand)
            {
                dbCommand.SetCommand(String.Format(
                    "DELETE FROM {0} " +
                    "WHERE {1}=? AND {1}=? AND {1}=? AND {1}=?;",
                    TableName,
                    // key
                    GetFieldName(QueryValues.CharID),
                    GetFieldName(QueryValues.jobID),
                    GetFieldName(QueryValues.installerID),
                    GetFieldName(QueryValues.installTime)));

                // key
                dbCommand.AddParameter((long)QueryValues.CharID);
                dbCommand.AddParameter((long)QueryValues.jobID);
                dbCommand.AddParameter((long)QueryValues.installerID);
                dbCommand.AddParameter((long)QueryValues.installTime);
            }

            void IDBRecord.FillCommandDelete(Database.DatabaseCommand dbCommand)
            {
                // key
                dbCommand.SetParamValue((long)QueryValues.CharID, m_DataObject.charID);
                dbCommand.SetParamValue((long)QueryValues.jobID, m_DataObject.jobID);
                dbCommand.SetParamValue((long)QueryValues.installerID, m_DataObject.installerID);
                dbCommand.SetParamValue((long)QueryValues.installTime, m_DataObject.installTime);
            }

            public CharacterIndustryJob()
            {
            }

            public CharacterIndustryJob(SQLiteDataReader reader)
            {
                foreach (QueryValues val in Enum.GetValues(typeof(QueryValues)))
                {
                    SetValue(val, reader[GetFieldName(val)]);
                }//foreach
            }

            public CharacterIndustryJob(long CharID, XmlNode xmlNode)
            {
                m_DataObject.charID = CharID;

                m_DataObject.jobID = long.Parse(xmlNode.Attributes["jobID"].InnerText);
                m_DataObject.assemblyLineID = long.Parse(xmlNode.Attributes["assemblyLineID"].InnerText);
                m_DataObject.containerID = long.Parse(xmlNode.Attributes["containerID"].InnerText);
                m_DataObject.installedItemID = long.Parse(xmlNode.Attributes["installedItemID"].InnerText);
                m_DataObject.installedItemLocationID = long.Parse(xmlNode.Attributes["installedItemLocationID"].InnerText);
                m_DataObject.installedItemQuantity = long.Parse(xmlNode.Attributes["installedItemQuantity"].InnerText);
                m_DataObject.installedItemProductivityLevel = long.Parse(xmlNode.Attributes["installedItemProductivityLevel"].InnerText);
                m_DataObject.installedItemMaterialLevel = long.Parse(xmlNode.Attributes["installedItemMaterialLevel"].InnerText);
                m_DataObject.installedItemLicensedProductionRunsRemaining = long.Parse(xmlNode.Attributes["installedItemLicensedProductionRunsRemaining"].InnerText);
                m_DataObject.outputLocationID = long.Parse(xmlNode.Attributes["outputLocationID"].InnerText);
                m_DataObject.installerID = long.Parse(xmlNode.Attributes["installerID"].InnerText);
                m_DataObject.runs = long.Parse(xmlNode.Attributes["runs"].InnerText);
                m_DataObject.licensedProductionRuns = long.Parse(xmlNode.Attributes["licensedProductionRuns"].InnerText);
                m_DataObject.installedInSolarSystemID = long.Parse(xmlNode.Attributes["installedInSolarSystemID"].InnerText);
                m_DataObject.containerLocationID = long.Parse(xmlNode.Attributes["containerLocationID"].InnerText);
                m_DataObject.installedItemTypeID = long.Parse(xmlNode.Attributes["installedItemTypeID"].InnerText);
                m_DataObject.outputTypeID = long.Parse(xmlNode.Attributes["outputTypeID"].InnerText);
                m_DataObject.containerTypeID = long.Parse(xmlNode.Attributes["containerTypeID"].InnerText);
                m_DataObject.installedItemCopy = long.Parse(xmlNode.Attributes["installedItemCopy"].InnerText);
                m_DataObject.completed = long.Parse(xmlNode.Attributes["completed"].InnerText);
                m_DataObject.completedSuccessfully = long.Parse(xmlNode.Attributes["completedSuccessfully"].InnerText);
                m_DataObject.installedItemFlag = long.Parse(xmlNode.Attributes["installedItemFlag"].InnerText);
                m_DataObject.outputFlag = long.Parse(xmlNode.Attributes["outputFlag"].InnerText);
                m_DataObject.activityID = long.Parse(xmlNode.Attributes["activityID"].InnerText);
                m_DataObject.completedStatus = long.Parse(xmlNode.Attributes["completedStatus"].InnerText);

                m_DataObject.materialMultiplier = decimal.Parse(xmlNode.Attributes["materialMultiplier"].InnerText);
                m_DataObject.charMaterialMultiplier = decimal.Parse(xmlNode.Attributes["charMaterialMultiplier"].InnerText);
                m_DataObject.timeMultiplier = decimal.Parse(xmlNode.Attributes["timeMultiplier"].InnerText);
                m_DataObject.charTimeMultiplier = decimal.Parse(xmlNode.Attributes["charTimeMultiplier"].InnerText);

                m_DataObject.installTime = DBConvert.FromCCPTime(xmlNode.Attributes["installTime"].InnerText);
                m_DataObject.beginProductionTime = DBConvert.FromCCPTime(xmlNode.Attributes["beginProductionTime"].InnerText);
                m_DataObject.endProductionTime = DBConvert.FromCCPTime(xmlNode.Attributes["endProductionTime"].InnerText);
                m_DataObject.pauseProductionTime = DBConvert.FromCCPTime(xmlNode.Attributes["pauseProductionTime"].InnerText);
            }
        }
    }
}
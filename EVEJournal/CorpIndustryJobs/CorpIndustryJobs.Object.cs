using System;

namespace EVEJournal
{
    class CorpIndustryJobsObject : DataObject
    {
        protected class CorpIndustryJobsKey : RecordKey
        {
            public long m_CorpID;
            public long m_jobID;
            public long m_installerID;
            public DateTime m_installTime;
        }
        protected CorpIndustryJobsKey m_Key;

        protected long m_assemblyLineID;
        protected long m_containerID;
        protected long m_installedItemID;
        protected long m_installedItemLocationID;
        protected long m_installedItemQuantity;
        protected long m_installedItemProductivityLevel;
        protected long m_installedItemMaterialLevel;
        protected long m_installedItemLicensedProductionRunsRemaining;
        protected long m_outputLocationID;
        protected long m_runs;
        protected long m_licensedProductionRuns;
        protected long m_installedInSolarSystemID;
        protected long m_containerLocationID;
        protected long m_installedItemTypeID;
        protected long m_outputTypeID;
        protected long m_containerTypeID;
        protected long m_installedItemCopy;
        protected long m_completed;
        protected long m_completedSuccessfully;
        protected long m_installedItemFlag;
        protected long m_outputFlag;
        protected long m_activityID;
        protected long m_completedStatus;
        protected decimal m_materialMultiplier;
        protected decimal m_charMaterialMultiplier;
        protected decimal m_timeMultiplier;
        protected decimal m_charTimeMultiplier;
        protected DateTime m_beginProductionTime;
        protected DateTime m_endProductionTime;
        protected DateTime m_pauseProductionTime;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long CorpID
            {
                get
                {
                    return m_Key.m_CorpID;
                }
            }
        public long jobID
            {
                get
                {
                    return m_Key.m_jobID;
                }
            }
        public long installerID
            {
                get
                {
                    return m_Key.m_installerID;
                }
            }
        public DateTime installTime
            {
                get
                {
                    return m_Key.m_installTime;
                }
            }

        public long assemblyLineID
            {
                get
                {
                    return m_assemblyLineID;
                }
            }
        public long containerID
            {
                get
                {
                    return m_containerID;
                }
            }
        public long installedItemID
            {
                get
                {
                    return m_installedItemID;
                }
            }
        public long installedItemLocationID
            {
                get
                {
                    return m_installedItemLocationID;
                }
            }
        public long installedItemQuantity
            {
                get
                {
                    return m_installedItemQuantity;
                }
            }
        public long installedItemProductivityLevel
            {
                get
                {
                    return m_installedItemProductivityLevel;
                }
            }
        public long installedItemMaterialLevel
            {
                get
                {
                    return m_installedItemMaterialLevel;
                }
            }
        public long installedItemLicensedProductionRunsRemaining
            {
                get
                {
                    return m_installedItemLicensedProductionRunsRemaining;
                }
            }
        public long outputLocationID
            {
                get
                {
                    return m_outputLocationID;
                }
            }
        public long runs
            {
                get
                {
                    return m_runs;
                }
            }
        public long licensedProductionRuns
            {
                get
                {
                    return m_licensedProductionRuns;
                }
            }
        public long installedInSolarSystemID
            {
                get
                {
                    return m_installedInSolarSystemID;
                }
            }
        public long containerLocationID
            {
                get
                {
                    return m_containerLocationID;
                }
            }
        public long installedItemTypeID
            {
                get
                {
                    return m_installedItemTypeID;
                }
            }
        public long outputTypeID
            {
                get
                {
                    return m_outputTypeID;
                }
            }
        public long containerTypeID
            {
                get
                {
                    return m_containerTypeID;
                }
            }
        public long installedItemCopy
            {
                get
                {
                    return m_installedItemCopy;
                }
            }
        public long completed
            {
                get
                {
                    return m_completed;
                }
            }
        public long completedSuccessfully
            {
                get
                {
                    return m_completedSuccessfully;
                }
            }
        public long installedItemFlag
            {
                get
                {
                    return m_installedItemFlag;
                }
            }
        public long outputFlag
            {
                get
                {
                    return m_outputFlag;
                }
            }
        public long activityID
            {
                get
                {
                    return m_activityID;
                }
            }
        public long completedStatus
            {
                get
                {
                    return m_completedStatus;
                }
            }
        public decimal materialMultiplier
            {
                get
                {
                    return m_materialMultiplier;
                }
            }
        public decimal charMaterialMultiplier
            {
                get
                {
                    return m_charMaterialMultiplier;
                }
            }
        public decimal timeMultiplier
            {
                get
                {
                    return m_timeMultiplier;
                }
            }
        public decimal charTimeMultiplier
            {
                get
                {
                    return m_charTimeMultiplier;
                }
            }
        public DateTime beginProductionTime
            {
                get
                {
                    return m_beginProductionTime;
                }
            }
        public DateTime endProductionTime
            {
                get
                {
                    return m_endProductionTime;
                }
            }
        public DateTime pauseProductionTime
            {
                get
                {
                    return m_pauseProductionTime;
                }
            }
    }
}
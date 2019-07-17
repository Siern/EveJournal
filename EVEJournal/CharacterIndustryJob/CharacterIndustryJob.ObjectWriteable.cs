using System;

namespace EVEJournal
{
    class CharacterIndustryJobObjectWriteable : CharacterIndustryJobObject
    {
        public new long charID
        {
            get
            {
                return m_Key.m_charID;
            }
            set
            {
                m_Key.m_charID = value;
            }
        }
        public new long jobID
        {
            get
            {
                return m_Key.m_jobID;
            }
            set
            {
                m_Key.m_jobID = value;
            }
        }
        public new long installerID
        {
            get
            {
                return m_Key.m_installerID;
            }
            set
            {
                m_Key.m_installerID = value;
            }
        }
        public new DateTime installTime
        {
            get
            {
                return m_Key.m_installTime;
            }
            set
            {
                m_Key.m_installTime = value;
            }
        }

        public new long assemblyLineID
        {
            get
            {
                return m_assemblyLineID;
            }
            set
            {
                m_assemblyLineID = value;
            }
        }
        public new long containerID
        {
            get
            {
                return m_containerID;
            }
            set
            {
                m_containerID = value;
            }
        }
        public new long installedItemID
        {
            get
            {
                return m_installedItemID;
            }
            set
            {
                m_installedItemID = value;
            }
        }
        public new long installedItemLocationID
        {
            get
            {
                return m_installedItemLocationID;
            }
            set
            {
                m_installedItemLocationID = value;
            }
        }
        public new long installedItemQuantity
        {
            get
            {
                return m_installedItemQuantity;
            }
            set
            {
                m_installedItemQuantity = value;
            }
        }
        public new long installedItemProductivityLevel
        {
            get
            {
                return m_installedItemProductivityLevel;
            }
            set
            {
                m_installedItemProductivityLevel = value;
            }
        }
        public new long installedItemMaterialLevel
        {
            get
            {
                return m_installedItemMaterialLevel;
            }
            set
            {
                m_installedItemMaterialLevel = value;
            }
        }
        public new long installedItemLicensedProductionRunsRemaining
        {
            get
            {
                return m_installedItemLicensedProductionRunsRemaining;
            }
            set
            {
                m_installedItemLicensedProductionRunsRemaining = value;
            }
        }
        public new long outputLocationID
        {
            get
            {
                return m_outputLocationID;
            }
            set
            {
                m_outputLocationID = value;
            }
        }
        public new long runs
        {
            get
            {
                return m_runs;
            }
            set
            {
                m_runs = value;
            }
        }
        public new long licensedProductionRuns
        {
            get
            {
                return m_licensedProductionRuns;
            }
            set
            {
                m_licensedProductionRuns = value;
            }
        }
        public new long installedInSolarSystemID
        {
            get
            {
                return m_installedInSolarSystemID;
            }
            set
            {
                m_installedInSolarSystemID = value;
            }
        }
        public new long containerLocationID
        {
            get
            {
                return m_containerLocationID;
            }
            set
            {
                m_containerLocationID = value;
            }
        }
        public new decimal materialMultiplier
        {
            get
            {
                return m_materialMultiplier;
            }
            set
            {
                m_materialMultiplier = value;
            }
        }
        public new decimal charMaterialMultiplier
        {
            get
            {
                return m_charMaterialMultiplier;
            }
            set
            {
                m_charMaterialMultiplier = value;
            }
        }
        public new decimal timeMultiplier
        {
            get
            {
                return m_timeMultiplier;
            }
            set
            {
                m_timeMultiplier = value;
            }
        }
        public new decimal charTimeMultiplier
        {
            get
            {
                return m_charTimeMultiplier;
            }
            set
            {
                m_charTimeMultiplier = value;
            }
        }
        public new long installedItemTypeID
        {
            get
            {
                return m_installedItemTypeID;
            }
            set
            {
                m_installedItemTypeID = value;
            }
        }
        public new long outputTypeID
        {
            get
            {
                return m_outputTypeID;
            }
            set
            {
                m_outputTypeID = value;
            }
        }
        public new long containerTypeID
        {
            get
            {
                return m_containerTypeID;
            }
            set
            {
                m_containerTypeID = value;
            }
        }
        public new long installedItemCopy
        {
            get
            {
                return m_installedItemCopy;
            }
            set
            {
                m_installedItemCopy = value;
            }
        }
        public new long completed
        {
            get
            {
                return m_completed;
            }
            set
            {
                m_completed = value;
            }
        }
        public new long completedSuccessfully
        {
            get
            {
                return m_completedSuccessfully;
            }
            set
            {
                m_completedSuccessfully = value;
            }
        }
        public new long installedItemFlag
        {
            get
            {
                return m_installedItemFlag;
            }
            set
            {
                m_installedItemFlag = value;
            }
        }
        public new long outputFlag
        {
            get
            {
                return m_outputFlag;
            }
            set
            {
                m_outputFlag = value;
            }
        }
        public new long activityID
        {
            get
            {
                return m_activityID;
            }
            set
            {
                m_activityID = value;
            }
        }
        public new long completedStatus
        {
            get
            {
                return m_completedStatus;
            }
            set
            {
                m_completedStatus = value;
            }
        }
        public new DateTime beginProductionTime
        {
            get
            {
                return m_beginProductionTime;
            }
            set
            {
                m_beginProductionTime = value;
            }
        }
        public new DateTime endProductionTime
        {
            get
            {
                return m_endProductionTime;
            }
            set
            {
                m_endProductionTime = value;
            }
        }
        public new DateTime pauseProductionTime
        {
            get
            {
                return m_pauseProductionTime;
            }
            set
            {
                m_pauseProductionTime = value;
            }
        }
    }

}
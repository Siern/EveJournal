using System;

namespace EVEJournal
{
    class CharSkillInTrainingObjectWriteable : CharSkillInTrainingObject
    {
        public new long CharID
        {
            get
            {
                return m_Key.m_CharID;
            }
            set
            {
                m_Key.m_CharID = value;
            }
        }

        public new DateTime StartTime
        {
            get
            {
                return m_StartTime;
            }
            set
            {
                m_StartTime = value;
            }
        }
        public new DateTime EndTime
        {
            get
            {
                return m_EndTime;
            }
            set
            {
                m_EndTime = value;
            }
        }
        public new long TypeID
        {
            get
            {
                return m_TypeID;
            }
            set
            {
                m_TypeID = value;
            }
        }
        public new long StartSP
        {
            get
            {
                return m_StartSP;
            }
            set
            {
                m_StartSP = value;
            }
        }
        public new long EndSP
        {
            get
            {
                return m_EndSP;
            }
            set
            {
                m_EndSP = value;
            }
        }
        public new long ToLevel
        {
            get
            {
                return m_ToLevel;
            }
            set
            {
                m_ToLevel = value;
            }
        }
        public new long SkillInTraining
        {
            get
            {
                return m_SkillInTraining;
            }
            set
            {
                m_SkillInTraining = value;
            }
        }
    }
}

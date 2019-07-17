using System;

namespace EVEJournal
{
    class CharSkillInTrainingObject : DataObject
    {
        protected class CharSkillInTrainingKey : RecordKey
        {
            public long m_CharID;
        }
        protected CharSkillInTrainingKey m_Key;

        protected DateTime m_StartTime;
        protected DateTime m_EndTime;
        protected long m_TypeID;
        protected long m_StartSP;
        protected long m_EndSP;
        protected long m_ToLevel;
        protected long m_SkillInTraining;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long CharID
            {
                get
                {
                    return m_Key.m_CharID;
                }
            }

        public DateTime StartTime
            {
                get
                {
                    return m_StartTime;
                }
            }
        public DateTime EndTime
            {
                get
                {
                    return m_EndTime;
                }
            }
        public long TypeID
            {
                get
                {
                    return m_TypeID;
                }
            }
        public long StartSP
            {
                get
                {
                    return m_StartSP;
                }
            }
        public long EndSP
            {
                get
                {
                    return m_EndSP;
                }
            }
        public long ToLevel
            {
                get
                {
                    return m_ToLevel;
                }
            }
        public long SkillInTraining
            {
                get
                {
                    return m_SkillInTraining;
                }
            }
    }
}

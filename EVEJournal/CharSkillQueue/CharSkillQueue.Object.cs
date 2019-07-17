using System;

namespace EVEJournal
{
    class CharSkillQueueObject : DataObject
    {
        protected class CharSkillQueueKey : RecordKey
        {
            public long m_Key_ID;
        }
        protected CharSkillQueueKey m_Key;

        protected long m_CharID;
        protected long m_queuePosition;
        protected long m_typeID;
        protected long m_startSP;
        protected long m_endSP;
        protected DateTime m_startTime;
        protected DateTime m_endTime;
        protected long m_level;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long Key_ID
        {
            get
            {
                return m_Key.m_Key_ID;
            }
        }

        public long CharID
            {
                get
                {
                    return m_CharID;
                }
            }
        public long queuePosition
            {
                get
                {
                    return m_queuePosition;
                }
            }
        public long typeID
            {
                get
                {
                    return m_typeID;
                }
            }
        public long startSP
            {
                get
                {
                    return m_startSP;
                }
            }
        public long endSP
            {
                get
                {
                    return m_endSP;
                }
            }
        public DateTime startTime
            {
                get
                {
                    return m_startTime;
                }
            }
        public DateTime endTime
            {
                get
                {
                    return m_endTime;
                }
            }
        public long level
            {
                get
                {
                    return m_level;
                }
            }
    }
}

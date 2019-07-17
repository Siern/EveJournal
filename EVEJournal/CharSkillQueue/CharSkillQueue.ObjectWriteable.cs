using System;

namespace EVEJournal
{
    class CharSkillQueueObjectWriteable : CharSkillQueueObject
    {
        public new long Key_ID
        {
            get
            {
                return m_Key.m_Key_ID;
            }
            set
            {
                m_Key.m_Key_ID = value;
            }
        }

        public new long CharID
        {
            get
            {
                return m_CharID;
            }
            set
            {
                m_CharID = value;
            }
        }
        public new long queuePosition
        {
            get
            {
                return m_queuePosition;
            }
            set
            {
                m_queuePosition = value;
            }
        }
        public new long typeID
        {
            get
            {
                return m_typeID;
            }
            set
            {
                m_typeID = value;
            }
        }
        public new long startSP
        {
            get
            {
                return m_startSP;
            }
            set
            {
                m_startSP = value;
            }
        }
        public new long endSP
        {
            get
            {
                return m_endSP;
            }
            set
            {
                m_endSP = value;
            }
        }
        public new DateTime startTime
        {
            get
            {
                return m_startTime;
            }
            set
            {
                m_startTime = value;
            }
        }
        public new DateTime endTime
        {
            get
            {
                return m_endTime;
            }
            set
            {
                m_endTime = value;
            }
        }
        public new long level
        {
            get
            {
                return m_level;
            }
            set
            {
                m_level = value;
            }
        }
    }
}

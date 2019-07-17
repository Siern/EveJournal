
namespace EVEJournal
{
    class CharStandingsObject : DataObject
    {
        protected class CharStandingsKey : RecordKey
        {
            public long m_Key_ID;
        }
        protected CharStandingsKey m_Key;

        protected long m_CharID;
        protected long m_standingType;
        protected long m_ID;
        protected string m_Name;
        protected decimal m_standing;

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
        public long standingType
            {
                get
                {
                    return m_standingType;
                }
            }
        public long ID
            {
                get
                {
                    return m_ID;
                }
            }
        public string Name
            {
                get
                {
                    return m_Name;
                }
            }
        public decimal standing
            {
                get
                {
                    return m_standing;
                }
            }
    }
}


namespace EVEJournal
{
    class CorpStandingsObject : DataObject
    {
        protected class CorpStandingsKey : RecordKey
        {
            public long m_KeyID;
        }
        protected CorpStandingsKey m_Key;

        protected long m_CorpID;
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
                return m_Key.m_KeyID;
            }
        }

        public long CorpID
        {
            get
            {
                return m_CorpID;
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

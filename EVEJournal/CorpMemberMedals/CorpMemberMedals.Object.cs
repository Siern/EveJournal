using System;

namespace EVEJournal
{
    class CorpMemberMedalsObject : DataObject
    {
        protected class CorpMemberMedalsKey : RecordKey
        {
            public long m_CorpID;
            public long m_MedalID;
            public long m_CharID;
        }
        protected CorpMemberMedalsKey m_Key;

        protected string m_reason;
        protected string m_status;
        protected long m_issuerID;
        protected DateTime m_issued;

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
        public long MedalID
            {
                get
                {
                    return m_Key.m_MedalID;
                }
            }
        public long CharID
            {
                get
                {
                    return m_Key.m_CharID;
                }
            }

        public string reason
            {
                get
                {
                    return m_reason;
                }
            }
        public string status
            {
                get
                {
                    return m_status;
                }
            }
        public long issuerID
            {
                get
                {
                    return m_issuerID;
                }
            }
        public DateTime issued
            {
                get
                {
                    return m_issued;
                }
            }
    }
}

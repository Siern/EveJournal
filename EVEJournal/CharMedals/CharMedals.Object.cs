using System;

namespace EVEJournal
{
    class CharMedalsObject : DataObject
    {
        protected class CharMedalsKey : RecordKey
        {
            public long m_CharID;
            public long m_MedalID;
        }
        protected CharMedalsKey m_Key;

        protected long m_issuerID;
        protected long m_corporationID;
        protected DateTime m_issued;
        protected string m_reason;
        protected string m_status;
        protected string m_title;
        protected string m_description;

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
        public long MedalID
            {
                get
                {
                    return m_Key.m_MedalID;
                }
            }

        public long issuerID
            {
                get
                {
                    return m_issuerID;
                }
            }
        public long corporationID
            {
                get
                {
                    return m_corporationID;
                }
            }
        public DateTime issued
            {
                get
                {
                    return m_issued;
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
        public string title
            {
                get
                {
                    return m_title;
                }
            }
        public string description
            {
                get
                {
                    return m_description;
                }
            }
    }
}

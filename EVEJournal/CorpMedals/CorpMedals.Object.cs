using System;

namespace EVEJournal
{
    class CorpMedalsObject : DataObject
    {
        protected class CorpMedalsKey : RecordKey
        {
            public long m_CorpID;
            public long m_MedalID;
        }
        protected CorpMedalsKey m_Key;

        protected string m_title;
        protected string m_description;
        protected long m_creatorID;
        protected DateTime m_created;

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
        public long creatorID
            {
                get
                {
                    return m_creatorID;
                }
            }
        public DateTime created
            {
                get
                {
                    return m_created;
                }
            }
    }
}


namespace EVEJournal
{
    class CorpHangarDivisionsObject : DataObject
    {
        protected class CorpHangarDivisionsKey : RecordKey
        {
            public long m_CorpID;
            public long m_AccountKey;
        }
        protected CorpHangarDivisionsKey m_Key;

        protected string m_Description;

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
        public long AccountKey
            {
                get
                {
                    return m_Key.m_AccountKey;
                }
            }
        public string Description
            {
                get
                {
                    return m_Description;
                }
            }
    }
}

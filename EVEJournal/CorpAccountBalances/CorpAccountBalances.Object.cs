
namespace EVEJournal
{
    class CorpAccountBalancesObject : DataObject
    {
        protected class CorpAccountBalanceKey : RecordKey
        {
            public long m_CorpID;
            public long m_AccountKey;
        }
        protected CorpAccountBalanceKey m_Key;

        protected long m_AccountID;
        protected long m_balance;

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

        public long AccountID
            {
                get
                {
                    return m_AccountID;
                }
            }
        public long balance
            {
                get
                {
                    return m_balance;
                }
            }
    }
}

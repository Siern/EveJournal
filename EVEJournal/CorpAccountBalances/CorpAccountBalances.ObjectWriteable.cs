
namespace EVEJournal
{
    class CorpAccountBalancesObjectWriteable : CorpAccountBalancesObject
    {
        public new long CorpID
        {
            get
            {
                return m_Key.m_CorpID;
            }
            set
            {
                m_Key.m_CorpID = value;
            }
        }
        public new long AccountKey
        {
            get
            {
                return m_Key.m_AccountKey;
            }
            set
            {
                m_Key.m_AccountKey = value;
            }
        }

        public new long AccountID
        {
            get
            {
                return m_AccountID;
            }
            set
            {
                m_AccountID = value;
            }
        }
        public new long balance
        {
            get
            {
                return m_balance;
            }
            set
            {
                m_balance = value;
            }
        }
    }
}

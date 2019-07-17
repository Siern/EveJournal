
namespace EVEJournal
{
    class CorpWalletDivisionsObjectWriteable : CorpWalletDivisionsObject
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

        public new string description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }
    }
}

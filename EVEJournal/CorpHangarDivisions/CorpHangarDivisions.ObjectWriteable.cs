
namespace EVEJournal
{
    class CorpHangarDivisionsObjectWriteable : CorpHangarDivisionsObject
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

        public new string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }
    }
}

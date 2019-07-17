namespace EVEJournal
{
    class CharAccountBalanceObjectWriteable : CharAccountBalanceObject
    {
        public new long CharID
        {
            get
            {
                return m_Key.m_CharID;
            }
            set
            {
                m_Key.m_CharID = value;
            }
        }

        public new long AccountID
        {
            get
            {
                return m_Key.m_AccountID;
            }
            set
            {
                m_Key.m_AccountID = value;
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

        public new decimal balance
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
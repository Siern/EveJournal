namespace EVEJournal
{
    class CharAccountBalanceObject : DataObject
    {
        protected class CharAccountBalanceKey : RecordKey
        {
            public long m_CharID;
            public long m_AccountID;
            public long m_AccountKey;
        }
        protected CharAccountBalanceKey m_Key;

        protected decimal m_balance;

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

        public long AccountID
        {
            get
            {
                return m_Key.m_AccountID;
            }
        }

        public long AccountKey
        {
            get
            {
                return m_Key.m_AccountKey;
            }
        }

        public decimal balance
        {
            get
            {
                return m_balance;
            }
        }
    }
}

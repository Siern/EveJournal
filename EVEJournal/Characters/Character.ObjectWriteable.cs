namespace EVEJournal
{
    class CharacterObjectWriteable : CharacterObject
    {
        public new long UserID
        {
            get
            {
                return m_Key.m_UserID;
            }
            set
            {
                m_Key.m_UserID = value;
            }
        }
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

        public new string CharName
        {
            get
            {
                return m_CharName;
            }
            set
            {
                m_CharName = value;
            }
        }
        public new string CorpName
        {
            get
            {
                return m_CorpName;
            }
            set
            {
                m_CorpName = value;
            }
        }
        public new long CorpID
        {
            get
            {
                return m_CorpID;
            }
            set
            {
                m_CorpID = value;
            }
        }
        public new string LimitedKey
        {
            get
            {
                return m_LimitedKey;
            }
            set
            {
                m_LimitedKey = value;
            }
        }
        public new string FullKey
        {
            get
            {
                return m_FullKey;
            }
            set
            {
                m_FullKey = value;
            }
        }
        public new string RegCode
        {
            get
            {
                return m_RegCode;
            }
            set
            {
                m_RegCode = value;
            }
        }
    }
}

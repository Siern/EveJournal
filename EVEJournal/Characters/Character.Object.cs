namespace EVEJournal
{
    class CharacterObject : DataObject
    {
        protected class CharacterObjectKey : RecordKey
        {
            public long m_UserID;
            public long m_CharID;
        }

        protected CharacterObjectKey m_Key;
        protected long m_CorpID;
        protected string m_CharName;
        protected string m_CorpName;
        protected string m_LimitedKey;
        protected string m_FullKey;
        protected string m_RegCode;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long UserID
        {
            get
            {
                return m_Key.m_UserID;
            }
        }
        public long CharID
        {
            get
            {
                return m_Key.m_CharID;
            }
        }

        public string CharName
        {
            get
            {
                return m_CharName;
            }
        }
        
        public string CorpName
        {
            get
            {
                return m_CorpName;
            }
        }
        public long CorpID
        {
            get
            {
                return m_CorpID;
            }
        }
        public string LimitedKey
        {
            get
            {
                return m_LimitedKey;
            }
        }
        public string FullKey
        {
            get
            {
                return m_FullKey;
            }
        }
        public string RegCode
        {
            get
            {
                return m_RegCode;
            }
        }

        public override string ToString()
        {
            if (null == CharName)
                return "";
            return CharName;
        }
    }
}

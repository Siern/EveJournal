﻿
namespace EVEJournal
{
    class CorpWalletDivisionsObject : DataObject
    {
        protected class CorpWalletDivisionsKey : RecordKey
        {
            public long m_CorpID;
            public long m_AccountKey;
        }
        protected CorpWalletDivisionsKey m_Key;

        protected string m_description;

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
        public string description
            {
                get
                {
                    return m_description;
                }
            }
    }
}

using System;

namespace EVEJournal
{
    class CorpWalletNameObject : DataObject
    {
        protected class CharAssetsKey : RecordKey
        {
            public long m_CorpID;
        }
        protected CharAssetsKey m_Key;

        protected string m_Name0;
        protected string m_Name1;
        protected string m_Name2;
        protected string m_Name3;
        protected string m_Name4;
        protected string m_Name5;
        protected string m_Name6;

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

        public string Name0
        {
            get
            {
                return m_Name0;
            }
        }
        public string Name1
        {
            get
            {
                return m_Name1;
            }
        }
        public string Name2
        {
            get
            {
                return m_Name2;
            }
        }
        public string Name3
        {
            get
            {
                return m_Name3;
            }
        }
        public string Name4
        {
            get
            {
                return m_Name4;
            }
        }
        public string Name5
        {
            get
            {
                return m_Name5;
            }
        }
        public string Name6
        {
            get
            {
                return m_Name6;
            }
        }
    }
}
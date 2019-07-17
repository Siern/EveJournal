using System;

namespace EVEJournal
{
    class CorpWalletNameObjectWritable : CorpWalletNameObject
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

        public new string Name0
        {
            get
            {
                return m_Name0;
            }
            set
            {
                m_Name0 = value;
            }
        }
        public new string Name1
        {
            get
            {
                return m_Name1;
            }
            set
            {
                m_Name1 = value;
            }
        }
        public new string Name2
        {
            get
            {
                return m_Name2;
            }
            set
            {
                m_Name2 = value;
            }
        }
        public new string Name3
        {
            get
            {
                return m_Name3;
            }
            set
            {
                m_Name3 = value;
            }
        }
        public new string Name4
        {
            get
            {
                return m_Name4;
            }
            set
            {
                m_Name4 = value;
            }
        }
        public new string Name5
        {
            get
            {
                return m_Name5;
            }
            set
            {
                m_Name5 = value;
            }
        }
        public new string Name6
        {
            get
            {
                return m_Name6;
            }
            set
            {
                m_Name6 = value;
            }
        }
    }
}
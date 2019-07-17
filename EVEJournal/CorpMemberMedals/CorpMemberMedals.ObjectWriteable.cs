using System;

namespace EVEJournal
{
    class CorpMemberMedalsObjectWriteable : CorpMemberMedalsObject
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
        public new long MedalID
        {
            get
            {
                return m_Key.m_MedalID;
            }
            set
            {
                m_Key.m_MedalID = value;
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

        public new string reason
        {
            get
            {
                return m_reason;
            }
            set
            {
                m_reason = value;
            }
        }
        public new string status
        {
            get
            {
                return m_status;
            }
            set
            {
                m_status = value;
            }
        }
        public new long issuerID
        {
            get
            {
                return m_issuerID;
            }
            set
            {
                m_issuerID = value;
            }
        }
        public new DateTime issued
        {
            get
            {
                return m_issued;
            }
            set
            {
                m_issued = value;
            }
        }
    }
}

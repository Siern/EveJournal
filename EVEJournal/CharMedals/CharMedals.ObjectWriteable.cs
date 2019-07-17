using System;

namespace EVEJournal
{
    class CharMedalsObjectWriteable : CharMedalsObject
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
        public new long corporationID
        {
            get
            {
                return m_corporationID;
            }
            set
            {
                m_corporationID = value;
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
        public new string title
        {
            get
            {
                return m_title;
            }
            set
            {
                m_title = value;
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

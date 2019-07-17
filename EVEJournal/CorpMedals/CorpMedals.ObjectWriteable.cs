using System;

namespace EVEJournal
{
    class CorpMedalsObjectWriteable : CorpMedalsObject
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
        public new long creatorID
        {
            get
            {
                return m_creatorID;
            }
            set
            {
                m_creatorID = value;
            }
        }
        public new DateTime created
        {
            get
            {
                return m_created;
            }
            set
            {
                m_created = value;
            }
        }
    }
}

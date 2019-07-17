
namespace EVEJournal
{
    class CorpStandingsObjectWriteable : CorpStandingsObject
    {
        public new long Key_ID
        {
            get
            {
                return m_Key.m_KeyID;
            }
            set
            {
                m_Key.m_KeyID = value;
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
        public new long standingType
        {
            get
            {
                return m_standingType;
            }
            set
            {
                m_standingType = value;
            }
        }
        public new long ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }
        public new string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public new decimal standing
        {
            get
            {
                return m_standing;
            }
            set
            {
                m_standing = value;
            }
        }
    }
}

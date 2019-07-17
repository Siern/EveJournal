
namespace EVEJournal
{
    class CharStandingsObjectWriteable : CharStandingsObject
    {
        public new long Key_ID
        {
            get
            {
                return m_Key.m_Key_ID;
            }
            set
            {
                m_Key.m_Key_ID = value;
            }
        }

        public new long CharID
        {
            get
            {
                return m_CharID;
            }
            set
            {
                m_CharID = value;
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

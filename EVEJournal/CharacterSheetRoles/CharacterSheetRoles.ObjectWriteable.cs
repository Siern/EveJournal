namespace EVEJournal
{
    class CharacterSheetRolesObjectWriteable : CharacterSheetRolesObject
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
        public new long RoleType
        {
            get
            {
                return m_RoleType;
            }
            set
            {
                m_RoleType = value;
            }
        }
        public new long RoleID
        {
            get
            {
                return m_RoleID;
            }
            set
            {
                m_RoleID = value;
            }
        }
        public new long RoleName
        {
            get
            {
                return m_RoleName;
            }
            set
            {
                m_RoleName = value;
            }
        }
    }
}
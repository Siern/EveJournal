namespace EVEJournal
{
    class CharacterSheetRolesObject : DataObject
    {
        protected class CharacterSheetRolesKey : RecordKey
        {
            public long m_Key_ID;
        }

        protected CharacterSheetRolesKey m_Key;
        protected long m_CharID;
        protected long m_RoleType;
        protected long m_RoleID;
        protected string m_RoleName;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long Key_ID
        {
            get
            {
                return m_Key.m_Key_ID;
            }
        }

        public long CharID
        {
            get
            {
                return m_CharID;
            }
        }
        public long RoleType
        {
            get
            {
                return m_RoleType;
            }
        }
        public long RoleID
        {
            get
            {
                return m_RoleID;
            }
        }
        public string RoleName
        {
            get
            {
                return m_RoleName;
            }
        }
    }
}
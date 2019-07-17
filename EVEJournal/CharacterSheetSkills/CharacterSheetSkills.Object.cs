namespace EVEJournal
{
    class CharacterSheetSkillsObject : DataObject
    {
        protected class CharacterSheetSkillsKey : RecordKey
        {
            public long m_Key_ID;
        }

        protected CharacterSheetSkillsKey m_Key;
        protected long m_CharID;
        protected long m_typeID;
        protected long m_skillpoints;
        protected long m_level;
        protected long m_unpublished;

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
        public long typeID
            {
                get
                {
                    return m_typeID;
                }
            }
        public long skillpoints
            {
                get
                {
                    return m_skillpoints;
                }
            }
        public long level
            {
                get
                {
                    return m_level;
                }
            }
        public long unpublished
            {
                get
                {
                    return m_unpublished;
                }
            }
    }
}
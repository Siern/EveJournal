namespace EVEJournal
{
    class CharacterSheetSkillsObjectWriteable : CharacterSheetSkillsObject
    {
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
        public new long typeID
        {
            get
            {
                return m_typeID;
            }
            set
            {
                m_typeID = value;
            }
        }
        public new long skillpoints
        {
            get
            {
                return m_skillpoints;
            }
            set
            {
                m_skillpoints = value;
            }
        }
        public new long level
        {
            get
            {
                return m_level;
            }
            set
            {
                m_level = value;
            }
        }
        public new long unpublished
        {
            get
            {
                return m_unpublished;
            }
            set
            {
                m_unpublished = value;
            }
        }
    }
}
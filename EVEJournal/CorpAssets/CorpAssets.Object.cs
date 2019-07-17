
namespace EVEJournal
{
    class CorpAssetsObject : object
    {
        protected class CorpAssetsKey : RecordKey
        {
            public long m_Key_ID;
        }
        protected CorpAssetsKey m_Key;

        protected long m_CorpID;
        protected long m_ItemID;
        protected long m_ItemParentID;
        protected long m_locationID;
        protected long m_typeID;
        protected long m_quantity;
        protected long m_flag;
        protected long m_singleton;

        public long Key_ID
        {
            get
            {
                return m_Key.m_Key_ID;
            }
        }

        public long CorpID
            {
                get
                {
                    return m_CorpID;
                }
            }
        public long ItemID
            {
                get
                {
                    return m_ItemID;
                }
            }
        public long ItemParentID
            {
                get
                {
                    return m_ItemParentID;
                }
            }
        public long locationID
            {
                get
                {
                    return m_locationID;
                }
            }
        public long typeID
            {
                get
                {
                    return m_typeID;
                }
            }
        public long quantity
            {
                get
                {
                    return m_quantity;
                }
            }
        public long flag
            {
                get
                {
                    return m_flag;
                }
            }
        public long singleton
            {
                get
                {
                    return m_singleton;
                }
            }
    }
}

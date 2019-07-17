
namespace EVEJournal
{
    class CharAssetsObject : DataObject
    {
        protected class CharAssetsKey : RecordKey
        {
            public long m_Key_ID;
        }
        protected CharAssetsKey m_Key;

        protected long m_Key_ID;
        protected long m_CharID;
        protected long m_ItemID;
        protected long m_ItemParentID;
        protected long m_locationID;
        protected long m_typeID;
        protected long m_quantity;
        protected long m_flag;
        protected long m_singleton;

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

namespace EVEJournal
{
    class KillLogItemsObject : DataObject
    {
        protected class KillLogItemsKey : RecordKey
        {
            public long m_Key_ID;
        }
        protected KillLogItemsKey m_Key;

        protected long m_KillID;
        protected long m_flag;
        protected long m_qtyDropped;
        protected long m_qtyDestroyed;
        protected long m_typeID;

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

        public long KillID
            {
                get
                {
                    return m_KillID;
                }
            }
        public long flag
            {
                get
                {
                    return m_flag;
                }
            }
        public long qtyDropped
            {
                get
                {
                    return m_qtyDropped;
                }
            }
        public long qtyDestroyed
            {
                get
                {
                    return m_qtyDestroyed;
                }
            }
        public long typeID
            {
                get
                {
                    return m_typeID;
                }
            }
    }
}
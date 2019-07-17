
namespace EVEJournal
{
    class KillLogItemsObjectWriteable : KillLogItemsObject
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

        public new long KillID
        {
            get
            {
                return m_KillID;
            }
            set
            {
                m_KillID = value;
            }
        }

        public new long flag
        {
            get
            {
                return m_flag;
            }
            set
            {
                m_flag = value;
            }
        }
        public new long qtyDropped
        {
            get
            {
                return m_qtyDropped;
            }
            set
            {
                m_qtyDropped = value;
            }
        }
        public new long qtyDestroyed
        {
            get
            {
                return m_qtyDestroyed;
            }
            set
            {
                m_qtyDestroyed = value;
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
    }
}
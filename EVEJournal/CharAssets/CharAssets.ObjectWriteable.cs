
namespace EVEJournal
{
    class CharAssetsObjectWriteable : CharAssetsObject
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
        public new long ItemID
        {
            get
            {
                return m_ItemID;
            }
            set
            {
                m_ItemID = value; 
            }
        }
        public new long ItemParentID
        {
            get
            {
                return m_ItemParentID;
            }
            set
            {
                m_ItemParentID = value; 
            }
        }
        public new long locationID
        {
            get
            {
                return m_locationID;
            }
            set
            {
                m_locationID = value; 
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
        public new long quantity
        {
            get
            {
                return m_quantity;
            }
            set
            {
                m_quantity = value; 
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
        public new long singleton
        {
            get
            {
                return m_singleton;
            }
            set
            {
                m_singleton = value; 
            }
        }
    }
}
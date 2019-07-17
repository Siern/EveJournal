using System;

namespace EVEJournal
{
    class CorpContainerLogsObjectWriteable : CorpContainerLogsObject
    {
        public new long CorpID
        {
            get
            {
                return m_Key.m_CorpID;
            }
            set
            {
                m_Key.m_CorpID = value;
            }
        }
        public new long ItemID
        {
            get
            {
                return m_Key.m_ItemID;
            }
            set
            {
                m_Key.m_ItemID = value;
            }
        }
        public new DateTime logTime
        {
            get
            {
                return m_Key.m_logTime;
            }
            set
            {
                m_Key.m_logTime = value;
            }
        }

        public new long itemTypeID
        {
            get
            {
                return m_itemTypeID;
            }
            set
            {
                m_itemTypeID = value;
            }
        }
        public new long actorID
        {
            get
            {
                return m_actorID;
            }
            set
            {
                m_actorID = value;
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
        public new string actorName
        {
            get
            {
                return m_actorName;
            }
            set
            {
                m_actorName = value;
            }
        }
        public new string action
        {
            get
            {
                return m_action;
            }
            set
            {
                m_action = value;
            }
        }
        public new string passwordType
        {
            get
            {
                return m_passwordType;
            }
            set
            {
                m_passwordType = value;
            }
        }
        public new string oldConfiguration
        {
            get
            {
                return m_oldConfiguration;
            }
            set
            {
                m_oldConfiguration = value;
            }
        }
        public new string newConfiguration
        {
            get
            {
                return m_newConfiguration;
            }
            set
            {
                m_newConfiguration = value;
            }
        }
    }
}

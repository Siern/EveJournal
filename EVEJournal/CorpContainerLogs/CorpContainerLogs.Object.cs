using System;

namespace EVEJournal
{
    class CorpContainerLogsObject : DataObject
    {
        protected class CorpContainerLogsKey : RecordKey
        {       
            public long m_CorpID;
            public long m_ItemID;
            public DateTime m_logTime;
        }
        protected CorpContainerLogsKey m_Key;

        protected long m_itemTypeID;
        protected long m_actorID;
        protected long m_flag;
        protected long m_locationID;
        protected long m_typeID;
        protected long m_quantity;
        protected string m_actorName;
        protected string m_action;
        protected string m_passwordType;
        protected string m_oldConfiguration;
        protected string m_newConfiguration;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long CorpID
            {
                get
                {
                    return m_Key.m_CorpID;
                }
            }
        public long ItemID
            {
                get
                {
                    return m_Key.m_ItemID;
                }
            }
        public DateTime logTime
            {
                get
                {
                    return m_Key.m_logTime;
                }
            }

        public long itemTypeID
            {
                get
                {
                    return m_itemTypeID;
                }
            }
        public long actorID
            {
                get
                {
                    return m_actorID;
                }
            }
        public long flag
            {
                get
                {
                    return m_flag;
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
        public string actorName
            {
                get
                {
                    return m_actorName;
                }
            }
        public string action
            {
                get
                {
                    return m_action;
                }
            }
        public string passwordType
            {
                get
                {
                    return m_passwordType;
                }
            }
        public string oldConfiguration
            {
                get
                {
                    return m_oldConfiguration;
                }
            }
        public string newConfiguration
            {
                get
                {
                    return m_newConfiguration;
                }
            }
    }
}

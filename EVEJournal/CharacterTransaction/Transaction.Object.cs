using System;

namespace EVEJournal
{
    class CharacterTransactionObject : DataObject
    {
        protected class CharacterTransactionKey : RecordKey
        {
            public long m_CharID;
            public long m_transID;
            public DateTime m_date;
            public long m_clientID;
            public long m_stationID;
            public long m_typeID;
        }
        protected CharacterTransactionKey m_Key;

        protected long m_quantity;
        protected string m_typeName;
        protected decimal m_price;
        protected string m_clientName;
        protected string m_stationName;
        protected string m_transactionType;
        protected string m_transactionFor;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long CharID
        {
            get
            {
                return m_Key.m_CharID;
            }
        }

        public DateTime date
        {
            get
            {
                return m_Key.m_date;
            }
        }

        public long transID
        {
            get
            {
                return m_Key.m_transID;
            }
        }

        public long typeID
        {
            get
            {
                return m_Key.m_typeID;
            }
        }

        public long clientID
        {
            get
            {
                return m_Key.m_clientID;
            }
        }

        public long stationID
        {
            get
            {
                return m_Key.m_stationID;
            }
        }

        public long quantity
        {
            get
            {
                return m_quantity;
            }
        }

        public string typeName
        {
            get
            {
                return m_typeName;
            }
        }

        public decimal price
        {
            get
            {
                return m_price;
            }
        }

        public string clientName
        {
            get
            {
                return m_clientName;
            }
        }

        public string stationName
        {
            get
            {
                return m_stationName;
            }
        }

        public string transactionType
        {
            get
            {
                return m_transactionType;
            }
        }

        public string transactionFor
        {
            get
            {
                return m_transactionFor;
            }
        }

    }
}

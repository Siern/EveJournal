using System;

namespace EVEJournal
{
    class CorporationTransactionObject : DataObject
    {
        protected class CorporationTransactionKey : RecordKey
        {
            public long m_CorpID;
            public long m_Division;
            public DateTime m_date;
            public long m_transID;
            public long m_stationID;
        }
        protected CorporationTransactionKey m_Key;

        protected long m_quantity;
        protected string m_typeName;
        protected long m_typeID;
        protected decimal m_price;
        protected long m_clientID;
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

        public long CorpID
        {
            get
            {
                return m_Key.m_CorpID;
            }
        }

        public long Division
        {
            get
            {
                return m_Key.m_Division;
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

        public long typeID
        {
            get
            {
                return m_typeID;
            }
        }

        public decimal price
        {
            get
            {
                return m_price;
            }
        }

        public long clientID
        {
            get
            {
                return m_clientID;
            }
        }

        public string clientName
        {
            get
            {
                return m_clientName;
            }
        }

        public long stationID
        {
            get
            {
                return m_Key.m_stationID;
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

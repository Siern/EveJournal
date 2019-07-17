using System;

namespace EVEJournal
{
    class CorporationTransactionObjectWriteable : CorporationTransactionObject
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

        public new long Division
        {
            get
            {
                return m_Key.m_Division;
            }
            set
            {
                m_Key.m_Division = value;
            }
        }

        public new DateTime date
        {
            get
            {
                return m_Key.m_date;
            }
            set
            {
                m_Key.m_date = value;
            }
        }

        public new long transID
        {
            get
            {
                return m_Key.m_transID;
            }
            set
            {
                m_Key.m_transID = value;
            }
        }

        public new long stationID
        {
            get
            {
                return m_Key.m_stationID;
            }
            set
            {
                m_Key.m_stationID = value;
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

        public new string typeName
        {
            get
            {
                return m_typeName;
            }
            set
            {
                m_typeName = value;
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

        public new decimal price
        {
            get
            {
                return m_price;
            }
            set
            {
                m_price = value;
            }
        }

        public new long clientID
        {
            get
            {
                return m_clientID;
            }
            set
            {
                m_clientID = value;
            }
        }

        public new string clientName
        {
            get
            {
                return m_clientName;
            }
            set
            {
                m_clientName = value;
            }
        }

        public new string stationName
        {
            get
            {
                return m_stationName;
            }
            set
            {
                m_stationName = value;
            }
        }

        public new string transactionType
        {
            get
            {
                return m_transactionType;
            }
            set
            {
                m_transactionType = value;
            }
        }

        public new string transactionFor
        {
            get
            {
                return m_transactionFor;
            }
            set
            {
                m_transactionFor = value;
            }
        }
    }
}
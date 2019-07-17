using System;

namespace EVEJournal
{
    class CorpMarketOrdersObject : DataObject
    {
        protected class CorpMarketOrdersKey : RecordKey
        {
            public long m_CorpID;
            public long m_charID;
            public long m_orderID;
            public long m_typeID;
            public long m_stationID;
            public long m_accountKey;
            public DateTime m_issued;
        }
        protected CorpMarketOrdersKey m_Key;

        protected long m_ownerID;
        protected long m_volEntered;
        protected long m_volRemaining;
        protected long m_minVolume;
        protected long m_orderState;
        protected long m_range;
        protected long m_duration;
        protected decimal m_escrow;
        protected decimal m_price;
        protected long m_bid;

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
        public long charID
            {
                get
                {
                    return m_Key.m_charID;
                }
            }
        public long orderID
            {
                get
                {
                    return m_Key.m_orderID;
                }
            }
        public long typeID
            {
                get
                {
                    return m_Key.m_typeID;
                }
            }
        public long stationID
            {
                get
                {
                    return m_Key.m_stationID;
                }
            }
        public long accountKey
            {
                get
                {
                    return m_Key.m_accountKey;
                }
            }
        public DateTime issued
            {
                get
                {
                    return m_Key.m_issued;
                }
            }

        public long ownerID
            {
                get
                {
                    return m_ownerID;
                }
            }
        public long volEntered
            {
                get
                {
                    return m_volEntered;
                }
            }
        public long volRemaining
            {
                get
                {
                    return m_volRemaining;
                }
            }
        public long minVolume
            {
                get
                {
                    return m_minVolume;
                }
            }
        public long orderState
            {
                get
                {
                    return m_orderState;
                }
            }
        public long range
            {
                get
                {
                    return m_range;
                }
            }
        public long duration
            {
                get
                {
                    return m_duration;
                }
            }
        public decimal escrow
            {
                get
                {
                    return m_escrow;
                }
            }
        public decimal price
            {
                get
                {
                    return m_price;
                }
            }
        public long bid
            {
                get
                {
                    return m_bid;
                }
            }
    }
}

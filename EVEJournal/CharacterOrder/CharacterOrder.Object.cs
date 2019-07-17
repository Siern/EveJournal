using System;

namespace EVEJournal
{
    class CharacterOrderObject : DataObject
    {
        protected class CharacterOrderObjectKey : RecordKey
        {
            public long m_charID;
            public long m_orderID;
            public long m_stationID;
            public long m_typeID;
            public AccountKey m_accountKey;
            public DateTime m_issued;
        }

        protected CharacterOrderObjectKey m_Key;
        protected long m_ownerID;
        protected long m_volEntered;
        protected long m_volRemaining;
        protected long m_minVolume;
        protected OrderState m_orderState;
        protected MarketRange m_range;
        protected long m_duration;
        protected decimal m_escrow;
        protected decimal m_price;
        protected Boolean m_bid;

        public override RecordKey Key
        {
            get { return m_Key as RecordKey; }
        }

        public long charID
        {
            get
            {
                return m_Key.m_charID;
            }
        }

        public DateTime issued
        {
            get
            {
                return m_Key.m_issued;
            }
        }
        public long orderID
        {
            get{
                return m_Key.m_orderID;
            }
        }
        public long ownerID
        {
            get
            {
                return m_ownerID;
            }
        }
        public long stationID
        {
            get
            {
                return m_Key.m_stationID;
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
        public OrderState orderState
        {
            get
            {
                return m_orderState;
            }
        }
        public long typeID
        {
            get
            {
                return m_Key.m_typeID;
            }
        }
        public MarketRange range
        {
            get
            {
                return m_range;
            }
        }
        public AccountKey accountKey
        {
            get
            {
                return m_Key.m_accountKey;
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
        public Boolean bid
        {
            get
            {
                return m_bid;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

namespace EVEJournal
{
    class CharacterOrderObjectWriteable : CharacterOrderObject
    {
        public new long charID
        {
            get
            {
                return m_Key.m_charID;
            }
            set
            {
                m_Key.m_charID = value;
            }
        }
        public new DateTime issued
        {
            get
            {
                return m_Key.m_issued;
            }
            set
            {
                m_Key.m_issued = value;
            }
        }
        public new long orderID
        {
            get
            {
                return m_Key.m_orderID;
            }
            set
            {
                m_Key.m_orderID = value;
            }
        }
        public new long ownerID
        {
            get
            {
                return m_ownerID;
            }
            set
            {
                m_ownerID = value;
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
        public new long volEntered
        {
            get
            {
                return m_volEntered;
            }
            set
            {
                m_volEntered = value;
            }
        }
        public new long volRemaining
        {
            get
            {
                return m_volRemaining;
            }
            set
            {
                m_volRemaining = value;
            }
        }
        public new long minVolume
        {
            get
            {
                return m_minVolume;
            }
            set
            {
                m_minVolume = value;
            }
        }
        public new OrderState orderState
        {
            get
            {
                return m_orderState;
            }
            set
            {
                m_orderState = value;
            }
        }
        public new long typeID
        {
            get
            {
                return m_Key.m_typeID;
            }
            set
            {
                m_Key.m_typeID = value;
            }
        }
        public new MarketRange range
        {
            get
            {
                return m_range;
            }
            set
            {
                m_range = value;
            }
        }
        public new AccountKey accountKey
        {
            get
            {
                return m_Key.m_accountKey;
            }
            set
            {
                m_Key.m_accountKey = value;
            }
        }
        public new long duration
        {
            get
            {
                return m_duration;
            }
            set
            {
                m_duration = value;
            }
        }
        public new decimal escrow
        {
            get
            {
                return m_escrow;
            }
            set
            {
                m_escrow = value;
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
        public new Boolean bid
        {
            get
            {
                return m_bid;
            }
            set
            {
                m_bid = value;
            }
        }
    }
}
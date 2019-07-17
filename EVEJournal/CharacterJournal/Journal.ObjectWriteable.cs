using System;

namespace EVEJournal
{
    class CharacterJournalObjectWriteable : CharacterJournalObject
    {
        public long CharID
        {
            get
            {
                return m_Key.m_CharID;
            }
            set
            {
                m_Key.m_CharID = value;
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
        public new long refID
        {
            get
            {
                return m_Key.m_refID;
            }
            set
            {
                m_Key.m_refID = value;
            }
        }
        public new long refTypeID
        {
            get
            {
                return m_Key.m_refTypeID;
            }
            set
            {
                m_Key.m_refTypeID = value;
            }
        }
        public new string ownerName1
        {
            get
            {
                return m_ownerName1;
            }
            set
            {
                m_ownerName1 = value;
            }
        }
        public new long ownerID1
        {
            get
            {
                return m_Key.m_ownerID1;
            }
            set
            {
                m_Key.m_ownerID1 = value;
            }
        }
        public new string ownerName2
        {
            get
            {
                return m_ownerName2;
            }
            set
            {
                m_ownerName2 = value;
            }
        }
        public new long ownerID2
        {
            get
            {
                return m_Key.m_ownerID2;
            }
            set
            {
                m_Key.m_ownerID2 = value;
            }
        }
        public new string argName1
        {
            get
            {
                return m_argName1;
            }
            set
            {
                m_argName1 = value;
            }
        }
        public new long argID
        {
            get
            {
                return m_Key.m_argID;
            }
            set
            {
                m_Key.m_argID = value;
            }
        }
        public new decimal amount
        {
            get
            {
                return m_amount;
            }
            set
            {
                m_amount = value;
            }
        }
        public new decimal balance
        {
            get
            {
                return m_balance;
            }
            set
            {
                m_balance = value;
            }
        }
        public new string reason
        {
            get
            {
                return m_reason;
            }
            set
            {
                m_reason = value;
            }
        }
    }
}
using System;

namespace EVEJournal
{
    class CorporationJournalObject : DataObject
    {
        protected class CorporationJournalKey : RecordKey
        {
            public long m_CorpID;
            public long m_Division;
            public long m_refID;
            public DateTime m_date;
            public long m_ownerID1;
            public long m_ownerID2;
            public long m_argID;
        }
        protected CorporationJournalKey m_Key;

        protected long m_refTypeID;
        protected string m_ownerName1;
        protected string m_ownerName2;
        protected string m_argName1;
        protected decimal m_amount;
        protected decimal m_balance;
        protected string m_reason;


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
        public long refID
        {
            get
            {
                return m_Key.m_refID;
            }
        }
        public long refTypeID
        {
            get
            {
                return m_refTypeID;
            }
        }
        public string ownerName1
        {
            get
            {
                return m_ownerName1;
            }
        }
        public long ownerID1
        {
            get
            {
                return m_Key.m_ownerID1;
            }
        }
        public string ownerName2
        {
            get
            {
                return m_ownerName2;
            }
        }
        public long ownerID2
        {
            get
            {
                return m_Key.m_ownerID2;
            }
        }
        public string argName1
        {
            get
            {
                return m_argName1;
            }
        }
        public long argID
        {
            get
            {
                return m_Key.m_argID;
            }
        }
        public decimal amount
        {
            get
            {
                return m_amount;
            }
        }
        public decimal balance
        {
            get
            {
                return m_balance;
            }
        }
        public string reason
        {
            get
            {
                return m_reason;
            }
        }
    }
}

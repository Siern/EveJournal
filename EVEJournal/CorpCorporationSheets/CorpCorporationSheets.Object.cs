
namespace EVEJournal
{
    class CorpCorporationSheetsObject : DataObject
    {
        protected class CorpCorporationSheetsKey : RecordKey
        {
            public long m_CorpID;
        }
        protected CorpCorporationSheetsKey m_Key;

        protected long m_ceoID;
        protected long m_stationID;
        protected long m_allianceID;
        protected long m_memberCount;
        protected long m_memberLimit;
        protected long m_shares;
        protected long m_logoGraphicID;
        protected long m_logoShape1;
        protected long m_logoShape2;
        protected long m_logoShape3;
        protected long m_logoColor1;
        protected long m_logoColor2;
        protected long m_logoColor3;
        protected decimal m_taxRate;
        protected string m_CorpName;
        protected string m_ticker;
        protected string m_ceoName;
        protected string m_stationName;
        protected string m_description;
        protected string m_url;
        protected string m_allianceName;

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

        public long ceoID
            {
                get
                {
                    return m_ceoID;
                }
            }
        public long stationID
            {
                get
                {
                    return m_stationID;
                }
            }
        public long allianceID
            {
                get
                {
                    return m_allianceID;
                }
            }
        public long memberCount
            {
                get
                {
                    return m_memberCount;
                }
            }
        public long memberLimit
            {
                get
                {
                    return m_memberLimit;
                }
            }
        public long shares
            {
                get
                {
                    return m_shares;
                }
            }
        public long logoGraphicID
            {
                get
                {
                    return m_logoGraphicID;
                }
            }
        public long logoShape1
            {
                get
                {
                    return m_logoShape1;
                }
            }
        public long logoShape2
            {
                get
                {
                    return m_logoShape2;
                }
            }
        public long logoShape3
            {
                get
                {
                    return m_logoShape3;
                }
            }
        public long logoColor1
            {
                get
                {
                    return m_logoColor1;
                }
            }
        public long logoColor2
            {
                get
                {
                    return m_logoColor2;
                }
            }
        public long logoColor3
            {
                get
                {
                    return m_logoColor3;
                }
            }
        public decimal taxRate
            {
                get
                {
                    return m_taxRate;
                }
            }
        public string CorpName
            {
                get
                {
                    return m_CorpName;
                }
            }
        public string ticker
            {
                get
                {
                    return m_ticker;
                }
            }
        public string ceoName
            {
                get
                {
                    return m_ceoName;
                }
            }
        public string stationName
            {
                get
                {
                    return m_stationName;
                }
            }
        public string description
            {
                get
                {
                    return m_description;
                }
            }
        public string url
            {
                get
                {
                    return m_url;
                }
            }
        public string allianceName
            {
                get
                {
                    return m_allianceName;
                }
            }
    }
}

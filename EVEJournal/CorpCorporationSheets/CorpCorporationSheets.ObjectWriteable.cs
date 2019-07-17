
namespace EVEJournal
{
    class CorpCorporationSheetsObjectWriteable : CorpCorporationSheetsObject
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

        public new long ceoID
        {
            get
            {
                return m_ceoID;
            }
            set
            {
                m_ceoID = value;
            }
        }
        public new long stationID
        {
            get
            {
                return m_stationID;
            }
            set
            {
                m_stationID = value;
            }
        }
        public new long allianceID
        {
            get
            {
                return m_allianceID;
            }
            set
            {
                m_allianceID = value;
            }
        }
        public new long memberCount
        {
            get
            {
                return m_memberCount;
            }
            set
            {
                m_memberCount = value;
            }
        }
        public new long memberLimit
        {
            get
            {
                return m_memberLimit;
            }
            set
            {
                m_memberLimit = value;
            }
        }
        public new long shares
        {
            get
            {
                return m_shares;
            }
            set
            {
                m_shares = value;
            }
        }
        public new long logoGraphicID
        {
            get
            {
                return m_logoGraphicID;
            }
            set
            {
                m_logoGraphicID = value;
            }
        }
        public new long logoShape1
        {
            get
            {
                return m_logoShape1;
            }
            set
            {
                m_logoShape1 = value;
            }
        }
        public new long logoShape2
        {
            get
            {
                return m_logoShape2;
            }
            set
            {
                m_logoShape2 = value;
            }
        }
        public new long logoShape3
        {
            get
            {
                return m_logoShape3;
            }
            set
            {
                m_logoShape3 = value;
            }
        }
        public new long logoColor1
        {
            get
            {
                return m_logoColor1;
            }
            set
            {
                m_logoColor1 = value;
            }
        }
        public new long logoColor2
        {
            get
            {
                return m_logoColor2;
            }
            set
            {
                m_logoColor2 = value;
            }
        }
        public new long logoColor3
        {
            get
            {
                return m_logoColor3;
            }
            set
            {
                m_logoColor3 = value;
            }
        }
        public new decimal taxRate
        {
            get
            {
                return m_taxRate;
            }
            set
            {
                m_taxRate = value;
            }
        }
        public new string CorpName
        {
            get
            {
                return m_CorpName;
            }
            set
            {
                m_CorpName = value;
            }
        }
        public new string ticker
        {
            get
            {
                return m_ticker;
            }
            set
            {
                m_ticker = value;
            }
        }
        public new string ceoName
        {
            get
            {
                return m_ceoName;
            }
            set
            {
                m_ceoName = value;
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
        public new string description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }
        public new string url
        {
            get
            {
                return m_url;
            }
            set
            {
                m_url = value;
            }
        }
        public new string allianceName
        {
            get
            {
                return m_allianceName;
            }
            set
            {
                m_allianceName = value;
            }
        }
    }
}

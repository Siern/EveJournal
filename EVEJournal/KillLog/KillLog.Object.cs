using System;

namespace EVEJournal
{
    class KillLogObject : DataObject
    {
        protected class KillLogKey : RecordKey
        {
            public long m_KillID;
        }
        protected KillLogKey m_Key;

        protected long m_SolarSystemID;
        protected long m_moonID;
        protected long m_vic_allianceID;
        protected long m_vic_characterID;
        protected long m_vic_corporationID;
        protected long m_vic_damageTaken;
        protected long m_vic_factionID;
        protected long m_vic_ShipTypeID;
        protected DateTime m_KillTime;
        protected string m_vic_allianceName;
        protected string m_vic_characterName;
        protected string m_vic_corporationName;
        protected string m_vic_factionName;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long KillID
            {
                get
                {
                    return m_Key.m_KillID;
                }
            }
        public long SolarSystemID
            {
                get
                {
                    return m_SolarSystemID;
                }
            }
        public long moonID
            {
                get
                {
                    return m_moonID;
                }
            }
        public long vic_allianceID
            {
                get
                {
                    return m_vic_allianceID;
                }
            }
        public long vic_characterID
            {
                get
                {
                    return m_vic_characterID;
                }
            }
        public long vic_corporationID
            {
                get
                {
                    return m_vic_corporationID;
                }
            }
        public long vic_damageTaken
            {
                get
                {
                    return m_vic_damageTaken;
                }
            }
        public long vic_factionID
            {
                get
                {
                    return m_vic_factionID;
                }
            }
        public long vic_ShipTypeID
            {
                get
                {
                    return m_vic_ShipTypeID;
                }
            }
        public DateTime KillTime
            {
                get
                {
                    return m_KillTime;
                }
            }
        public string vic_allianceName
            {
                get
                {
                    return m_vic_allianceName;
                }
            }
        public string vic_characterName
            {
                get
                {
                    return m_vic_characterName;
                }
            }
        public string vic_corporationName
            {
                get
                {
                    return m_vic_corporationName;
                }
            }
        public string vic_factionName
            {
                get
                {
                    return m_vic_factionName;
                }
            }
    }
}
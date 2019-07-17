using System;

namespace EVEJournal
{
    class KillLogObjectWriteable : KillLogObject
    {
        public new long KillID
        {
            get
            {
                return m_Key.m_KillID;
            }
            set
            {
                m_Key.m_KillID = value;
            }
        }

        public new long SolarSystemID
        {
            get
            {
                return m_SolarSystemID;
            }
            set
            {
                m_SolarSystemID = value;
            }
        }
        public new long moonID
        {
            get
            {
                return m_moonID;
            }
            set
            {
                m_moonID = value;
            }
        }
        public new long vic_allianceID
        {
            get
            {
                return m_vic_allianceID;
            }
            set
            {
                m_vic_allianceID = value;
            }
        }
        public new long vic_characterID
        {
            get
            {
                return m_vic_characterID;
            }
            set
            {
                m_vic_characterID = value;
            }
        }
        public new long vic_corporationID
        {
            get
            {
                return m_vic_corporationID;
            }
            set
            {
                m_vic_corporationID = value;
            }
        }
        public new long vic_damageTaken
        {
            get
            {
                return m_vic_damageTaken;
            }
            set
            {
                m_vic_damageTaken = value;
            }
        }
        public new long vic_factionID
        {
            get
            {
                return m_vic_factionID;
            }
            set
            {
                m_vic_factionID = value;
            }
        }
        public new long vic_ShipTypeID
        {
            get
            {
                return m_vic_ShipTypeID;
            }
            set
            {
                m_vic_ShipTypeID = value;
            }
        }
        public new DateTime KillTime
        {
            get
            {
                return m_KillTime;
            }
            set
            {
                m_KillTime = value;
            }
        }
        public new string vic_allianceName
        {
            get
            {
                return m_vic_allianceName;
            }
            set
            {
                m_vic_allianceName = value;
            }
        }
        public new string vic_characterName
        {
            get
            {
                return m_vic_characterName;
            }
            set
            {
                m_vic_characterName = value;
            }
        }
        public new string vic_corporationName
        {
            get
            {
                return m_vic_corporationName;
            }
            set
            {
                m_vic_corporationName = value;
            }
        }
        public new string vic_factionName
        {
            get
            {
                return m_vic_factionName;
            }
            set
            {
                m_vic_factionName = value;
            }
        }
    }
}
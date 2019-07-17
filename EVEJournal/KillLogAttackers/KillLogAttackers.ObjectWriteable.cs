
namespace EVEJournal
{
    class KillLogAttackersObjectWriteable : KillLogAttackersObject
    {
        public new long Key_ID
        {
            get
            {
                return m_Key.Key_ID;
            }
            set
            {
                m_Key.Key_ID = value;
            }
        }

        public new long KillID
        {
            get
            {
                return m_KillID;
            }
            set
            {
                m_KillID = value;
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
        public new long characterID
        {
            get
            {
                return m_characterID;
            }
            set
            {
                m_characterID = value;
            }
        }
        public new string characterName
        {
            get
            {
                return m_characterName;
            }
            set
            {
                m_characterName = value;
            }
        }
        public new long corporationID
        {
            get
            {
                return m_corporationID;
            }
            set
            {
                m_corporationID = value;
            }
        }
        public new string corporationName
        {
            get
            {
                return m_corporationName;
            }
            set
            {
                m_corporationName = value;
            }
        }
        public new long damageDone
        {
            get
            {
                return m_damageDone;
            }
            set
            {
                m_damageDone = value;
            }
        }
        public new long factionID
        {
            get
            {
                return m_factionID;
            }
            set
            {
                m_factionID = value;
            }
        }
        public new string factionName
        {
            get
            {
                return m_factionName;
            }
            set
            {
                m_factionName = value;
            }
        }
        public new long finalBlow
        {
            get
            {
                return m_finalBlow;
            }
            set
            {
                m_finalBlow = value;
            }
        }
        public new decimal securityStatus
        {
            get
            {
                return m_securityStatus;
            }
            set
            {
                m_securityStatus = value;
            }
        }
        public new long shipTypeID
        {
            get
            {
                return m_shipTypeID;
            }
            set
            {
                m_shipTypeID = value;
            }
        }
        public new long weaponTypeID
        {
            get
            {
                return m_weaponTypeID;
            }
            set
            {
                m_weaponTypeID = value;
            }
        }
    }
}


namespace EVEJournal
{
    class KillLogAttackersObject : DataObject
    {
        protected class KillLogAttackersKey : RecordKey
        {
            public long Key_ID;
        }
        protected KillLogAttackersKey m_Key;

        protected long m_KillID;
        protected long m_allianceID;
        protected string m_allianceName;
        protected long m_characterID;
        protected string m_characterName;
        protected long m_corporationID;
        protected string m_corporationName;
        protected long m_damageDone;
        protected long m_factionID;
        protected string m_factionName;
        protected long m_finalBlow;
        protected decimal m_securityStatus;
        protected long m_shipTypeID;
        protected long m_weaponTypeID;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long Key_ID
        {
            get
            {
                return m_Key.Key_ID;
            }
        }

        public long KillID
            {
                get
                {
                    return m_KillID;
                }
            }
        public long allianceID
            {
                get
                {
                    return m_allianceID;
                }
            }
        public string allianceName
            {
                get
                {
                    return m_allianceName;
                }
            }
        public long characterID
            {
                get
                {
                    return m_characterID;
                }
            }
        public string characterName
            {
                get
                {
                    return m_characterName;
                }
            }
        public long corporationID
            {
                get
                {
                    return m_corporationID;
                }
            }
        public string corporationName
            {
                get
                {
                    return m_corporationName;
                }
            }
        public long damageDone
            {
                get
                {
                    return m_damageDone;
                }
            }
        public long factionID
            {
                get
                {
                    return m_factionID;
                }
            }
        public string factionName
            {
                get
                {
                    return m_factionName;
                }
            }
        public long finalBlow
            {
                get
                {
                    return m_finalBlow;
                }
            }
        public decimal securityStatus
            {
                get
                {
                    return m_securityStatus;
                }
            }
        public long shipTypeID
            {
                get
                {
                    return m_shipTypeID;
                }
            }
        public long weaponTypeID
            {
                get
                {
                    return m_weaponTypeID;
                }
            }
    }
}
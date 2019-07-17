using System;

namespace EVEJournal
{
    class CorporationMemberTrackingObject : DataObject
    {
        protected class CorporationMemberTrackingKey : RecordKey
        {
            public long m_CorpID;
            public long m_CharID;
        }
        protected CorporationMemberTrackingKey m_Key;

        protected string m_Name;
        protected string m_Title;
        protected DateTime m_StartDate;
        protected DateTime m_LastLogon;
        protected DateTime m_LastLogoff;
        protected long m_BaseID;
        protected string m_BaseName;
        protected long m_LocationID;
        protected string m_LocationName;
        protected long m_ShipID;
        protected string m_ShipType;
        protected long m_Roles;
        protected long m_GrantableRoles;

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
        public long CharID
        {
            get
            {
                return m_Key.m_CharID;
            }
        }
        public string Name
        {
            get
            {
                return m_Name;
            }
        }
        public string Title
        {
            get
            {
                return m_Title;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return m_StartDate;
            }
        }
        public DateTime LastLogon
        {
            get
            {
                return m_LastLogon;
            }
        }
        public DateTime LastLogoff
        {
            get
            {
                return m_LastLogoff;
            }
        }
        public long BaseID
        {
            get
            {
                return m_BaseID;
            }
        }
        public string BaseName
        {
            get
            {
                return m_BaseName;
            }
        }
        public long LocationID
        {
            get
            {
                return m_LocationID;
            }
        }
        public string LocationName
        {
            get
            {
                return m_LocationName;
            }
        }
        public long ShipID
        {
            get
            {
                return m_ShipID;
            }
        }
        public string ShipType
        {
            get
            {
                return m_ShipType;
            }
        }
        public long Roles
        {
            get
            {
                return m_Roles;
            }
        }
        public long GrantableRoles
        {
            get
            {
                return m_GrantableRoles;
            }
        }
    }
}

using System;

namespace EVEJournal
{
    class CorporationMemberTrackingObjectWritable : CorporationMemberTrackingObject
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
        public new long CharID
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

        public new string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public new string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }
        public new DateTime StartDate
        {
            get
            {
                return m_StartDate;
            }
            set
            {
                m_StartDate = value;
            }
        }
        public new DateTime LastLogon
        {
            get
            {
                return m_LastLogon;
            }
            set
            {
                m_LastLogon = value;
            }
        }
        public new DateTime LastLogoff
        {
            get
            {
                return m_LastLogoff;
            }
            set
            {
                m_LastLogoff = value;
            }
        }
        public new long BaseID
        {
            get
            {
                return m_BaseID;
            }
            set
            {
                m_BaseID = value;
            }
        }
        public new string BaseName
        {
            get
            {
                return m_BaseName;
            }
            set
            {
                m_BaseName = value;
            }
        }
        public new long LocationID
        {
            get
            {
                return m_LocationID;
            }
            set
            {
                m_LocationID = value;
            }
        }
        public new string LocationName
        {
            get
            {
                return m_LocationName;
            }
            set
            {
                m_LocationName = value;
            }
        }
        public new long ShipID
        {
            get
            {
                return m_ShipID;
            }
            set
            {
                m_ShipID = value;
            }
        }
        public new string ShipType
        {
            get
            {
                return m_ShipType;
            }
            set
            {
                m_ShipType = value;
            }
        }
        public new long Roles
        {
            get
            {
                return m_Roles;
            }
            set
            {
                m_Roles = value;
            }
        }
        public new long GrantableRoles
        {
            get
            {
                return m_GrantableRoles;
            }
            set
            {
                m_GrantableRoles = value;
            }
        }
    }
}

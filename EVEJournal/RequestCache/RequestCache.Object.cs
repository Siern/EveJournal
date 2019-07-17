using System;

namespace EVEJournal
{
    enum RequestID : long
    {
        CharacterList = 0,
        CharacterJournal,
        CorporationJournal,
        CharacterTransaction = 9,
        RefTypes = 17,
        CharacterOrder,
        CorpMemberTracking,
    }

    class RequestObject : object
    {
        protected RequestID m_RequestID;
        protected string m_UserID;
        protected string m_url;
        protected DateTime m_ValidUntil = DateTime.Now;
        protected string m_Response;

        public RequestID RequestID
        {
            get
            {
                return m_RequestID;
            }
        }
        public string UserID
        {
            get
            {
                return m_UserID;
            }
        }
        public string url
        {
            get
            {
                return m_url;
            }
        }
        public DateTime ValidUntil
        {
            get
            {
                return m_ValidUntil;
            }
        }
        public string Response
        {
            get
            {
                return m_Response;
            }
        }
    }

    class RequestObjectInternal : RequestObject
    {
        protected long m_Id;

        public long ID
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }

        public new RequestID RequestID
        {
            get
            {
                return m_RequestID;
            }
            set
            {
                m_RequestID = value;
            }
        }
        public new string UserID
        {
            get
            {
                return m_UserID;
            }
            set
            {
                m_UserID = value;
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
        public new DateTime ValidUntil
        {
            get
            {
                return m_ValidUntil;
            }
            set
            {
                m_ValidUntil = value;
            }
        }
        public new string Response
        {
            get
            {
                return m_Response;
            }
            set
            {
                m_Response = value;
            }
        }
    }
}
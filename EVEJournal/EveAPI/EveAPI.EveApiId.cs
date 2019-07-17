using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;

namespace EVEJournal
{
    internal class EveApiId
    {
        private string m_UserId = null;
        private string m_LimitedKey = null;
        private string m_FullKey = null;
        private string m_CharName = null;

        public EveApiId(string UserId, string Key)
        {
            m_UserId = UserId;
            m_FullKey = Key;
        }

        public EveApiId(string UserId, string Key, bool bIsLimitedKey)
        {
            m_UserId = UserId;
            if (bIsLimitedKey)
                m_LimitedKey = Key;
            else
                m_FullKey = Key;
        }

        public EveApiId(string UserId, string Key, bool bIsLimitedKey, string CharName)
        {
            m_UserId = UserId;
            m_CharName = CharName;
            if (bIsLimitedKey)
                m_LimitedKey = Key;
            else
                m_FullKey = Key;
        }

        public bool HasKey()
        {
            return (null != m_LimitedKey || null != m_FullKey);
        }

        public bool IsFullKey()
        {
            return (null != m_FullKey);
        }

        public bool HasUserName()
        {
            return (null != m_CharName);
        }

        public string UserId
        {
            get
            {
                if (null == this.m_UserId)
                    throw new NullReferenceException();
                return this.m_UserId;
            }
        }
        public string Key
        {
            get
            {
                if (IsFullKey())
                    return this.m_FullKey;
                if (null == this.m_LimitedKey)
                    throw new NullReferenceException();
                return this.m_LimitedKey;
            }
        }

        public string CharName
        {
            get
            {
                if (null == this.m_CharName)
                    throw new NullReferenceException();
                return this.m_CharName;
            }
        }
    }
}

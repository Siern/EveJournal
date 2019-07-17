using System;
using System.Collections.Generic;
using System.Text;

namespace EVEJournal
{
    class VersionObject
    {
        // initial version number
        public static readonly long DefaultVersion = 1;

        protected string m_TableName;
        protected long m_Version = DefaultVersion;

        public string TableName
        {
            get
            {
                return m_TableName;
            }
        }
        public long VersionNumber
        {
            get
            {
                return m_Version;
            }
        }
    }

    class VersionObjectInternal : VersionObject
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
        public new string TableName
        {
            get
            {
                return m_TableName;
            }
            set
            {
                m_TableName = value;
            }
        }
        public new long VersionNumber
        {
            get
            {
                return m_Version;
            }
            set
            {
                m_Version = value;
            }
        }
    }


}

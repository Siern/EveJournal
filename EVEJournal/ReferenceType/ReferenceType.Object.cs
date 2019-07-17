using System;

namespace EVEJournal
{
    class ReferenceTypeObject : object
    {
        protected long m_refTypeID;
        protected string m_refTypeName;

        public long refTypeID
        {
            get
            {
                return m_refTypeID;
            }
        }

        public string refTypeName
        {
            get
            {
                return m_refTypeName;
            }
        }
    }

    class ReferenceTypeObjectInternal : ReferenceTypeObject
    {
        protected long m_Id = 0;

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

        public new long refTypeID
        {
            get
            {
                return m_refTypeID;
            }
            set
            {
                m_refTypeID = value;
            }
        }

        public new string refTypeName
        {
            get
            {
                return m_refTypeName;
            }
            set
            {
                m_refTypeName = value;
            }
        }
    }

}

using System;

namespace EVEJournal
{
    class MemberTrackingSettingsObjectInternal : MemberTrackingSettingsObjectWritable
    {
        public new long CorpID
        {
            get
            {
                return m_CorpID;
            }
            set
            {
                m_CorpID = value;
            }
        }
    }
}
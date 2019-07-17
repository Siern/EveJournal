using System;

namespace EVEJournal
{
    class MemberTrackingSettingsObject
    {
        protected long m_CorpID;

        protected long m_MemberOk;
        protected long m_MemberCaution;
        protected long m_MemberWarning;

        protected long m_RecruitDefinition;
        protected long m_RecruitOk;
        protected long m_RecruitCaution;
        protected long m_RecruitWarning;

        public long CorpID
        {
            get
            {
                return m_CorpID;
            }
        }
        public long MemberOk
        {
            get
            {
                return m_MemberOk;
            }
        }
        public long MemberCaution
        {
            get
            {
                return m_MemberCaution;
            }
        }
        public long MemberWarning
        {
            get
            {
                return m_MemberWarning;
            }
        }

        public long RecruitDefinition
        {
            get
            {
                return m_RecruitDefinition;
            }
        }
        public long RecruitOk
        {
            get
            {
                return m_RecruitOk;
            }
        }
        public long RecruitCaution
        {
            get
            {
                return m_RecruitCaution;
            }
        }
        public long RecruitWarning
        {
            get
            {
                return m_RecruitWarning;
            }
        }
    }

    class MemberTrackingSettingsObjectWritable : MemberTrackingSettingsObject
    {
        public new long MemberOk
        {
            get
            {
                return m_MemberOk;
            }
            set
            {
                m_MemberOk = value;
            }
        }
        public new long MemberCaution
        {
            get
            {
                return m_MemberCaution;
            }
            set
            {
                m_MemberCaution = value;
            }
        }
        public new long MemberWarning
        {
            get
            {
                return m_MemberWarning;
            }
            set
            {
                m_MemberWarning = value;
            }
        }

        public new long RecruitDefinition
        {
            get
            {
                return m_RecruitDefinition;
            }
            set
            {
                m_RecruitDefinition = value;
            }
        }
        public new long RecruitOk
        {
            get
            {
                return m_RecruitOk;
            }
            set
            {
                m_RecruitOk = value;
            }
        }
        public new long RecruitCaution
        {
            get
            {
                return m_RecruitCaution;
            }
            set
            {
                m_RecruitCaution = value;
            }
        }
        public new long RecruitWarning
        {
            get
            {
                return m_RecruitWarning;
            }
            set
            {
                m_RecruitWarning = value;
            }
        }
    }
}
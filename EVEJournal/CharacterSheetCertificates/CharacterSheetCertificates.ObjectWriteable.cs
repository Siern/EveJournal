namespace EVEJournal
{
    class CharacterSheetCertificatesObjectWriteable : CharacterSheetCertificatesObject
    {
        public new long Key_ID
        {
            get
            {
                return m_Key.m_Key_ID;
            }
            set
            {
                m_Key.m_Key_ID = value;
            }
        }

        public new long CharID
        {
            get
            {
                return m_CharID;
            }
            set
            {
                m_CharID = value;
            }
        }

        public new long CertificateID
        {
            get
            {
                return m_CertificateID;
            }
            set
            {
                m_CertificateID = value;
            }
        }
    }
}

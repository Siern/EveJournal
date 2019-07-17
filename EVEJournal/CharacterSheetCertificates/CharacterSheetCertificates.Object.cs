namespace EVEJournal
{
    class CharacterSheetCertificatesObject : DataObject
    {
        protected class CharacterSheetCertificatesKey : RecordKey
        {
            public long m_Key_ID;
        }

        protected CharacterSheetCertificatesKey m_Key;
        protected long m_CharID;
        protected long m_CertificateID;

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
                return m_Key.m_Key_ID;
            }
        }
        public long CharID
        {
            get
            {
                return m_CharID;
            }
        }
        public long CertificateID
        {
            get
            {
                return m_CertificateID;
            }
        }
    }
}

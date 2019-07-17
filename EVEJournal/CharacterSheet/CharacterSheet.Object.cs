namespace EVEJournal
{
    class CharacterSheetObject : DataObject
    {
        protected class CharacterSheetKey : RecordKey
        {
            public long m_CharID;
        }

        protected CharacterSheetKey m_Key;
        protected long m_CorporationID;
        protected long m_cloneSkillPoints;
        protected long m_attr_intelligence;
        protected long m_attr_memory;
        protected long m_attr_charisma;
        protected long m_attr_perception;
        protected long m_attr_willpower;
        protected long m_Implant_Int_Value;
        protected long m_Implant_Mem_Value;
        protected long m_Implant_Cha_Value;
        protected long m_Implant_Per_Value;
        protected long m_Implant_Wil_Value;
        protected decimal m_balance;
        protected string m_Name;
        protected string m_race;
        protected string m_bloodLine;
        protected string m_gender;
        protected string m_CorporationName;
        protected string m_cloneName;
        protected string m_Implant_Int_Name;
        protected string m_Implant_Mem_Name;
        protected string m_Implant_Cha_Name;
        protected string m_Implant_Per_Name;
        protected string m_Implant_Wil_Name;

        public override RecordKey Key
        {
            get
            {
                return m_Key as RecordKey;
            }
        }

        public long CharID
        {
            get
            {
                return m_Key.m_CharID;
            }
        }

        public long CorporationID
            {
                get
                {
                    return m_CorporationID;
                }
            }
        public long cloneSkillPoints
            {
                get
                {
                    return m_cloneSkillPoints;
                }
            }
        public long attr_intelligence
            {
                get
                {
                    return m_attr_intelligence;
                }
            }
        public long attr_memory
            {
                get
                {
                    return m_attr_memory;
                }
            }
        public long attr_charisma
            {
                get
                {
                    return m_attr_charisma;
                }
            }
        public long attr_perception
            {
                get
                {
                    return m_attr_perception;
                }
            }
        public long attr_willpower
            {
                get
                {
                    return m_attr_willpower;
                }
            }
        public long Implant_Int_Value
            {
                get
                {
                    return m_Implant_Int_Value;
                }
            }
        public long Implant_Mem_Value
            {
                get
                {
                    return m_Implant_Mem_Value;
                }
            }
        public long Implant_Cha_Value
            {
                get
                {
                    return m_Implant_Cha_Value;
                }
            }
        public long Implant_Per_Value
            {
                get
                {
                    return m_Implant_Per_Value;
                }
            }
        public long Implant_Wil_Value
            {
                get
                {
                    return m_Implant_Wil_Value;
                }
            }
        public decimal balance
            {
                get
                {
                    return m_balance;
                }
            }
        public string Name
            {
                get
                {
                    return m_Name;
                }
            }
        public string race
            {
                get
                {
                    return m_race;
                }
            }
        public string bloodLine
            {
                get
                {
                    return m_bloodLine;
                }
            }
        public string gender
            {
                get
                {
                    return m_gender;
                }
            }
        public string CorporationName
            {
                get
                {
                    return m_CorporationName;
                }
            }
        public string cloneName
            {
                get
                {
                    return m_cloneName;
                }
            }
        public string Implant_Int_Name
            {
                get
                {
                    return m_Implant_Int_Name;
                }
            }
        public string Implant_Mem_Name
            {
                get
                {
                    return m_Implant_Mem_Name;
                }
            }
        public string Implant_Cha_Name
            {
                get
                {
                    return m_Implant_Cha_Name;
                }
            }
        public string Implant_Per_Name
            {
                get
                {
                    return m_Implant_Per_Name;
                }
            }
        public string Implant_Wil_Name
            {
                get
                {
                    return m_Implant_Wil_Name;
                }
            }
    }
}

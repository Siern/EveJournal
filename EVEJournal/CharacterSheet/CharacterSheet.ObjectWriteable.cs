namespace EVEJournal
{
    class CharacterSheetObjectWriteable : CharacterSheetObject
    {
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

        public new long CorporationID
        {
            get
            {
                return m_CorporationID;
            }
            set
            {
                m_CorporationID = value;
            }
        }
        public new long cloneSkillPoints
        {
            get
            {
                return m_cloneSkillPoints;
            }
            set
            {
                m_cloneSkillPoints = value;
            }
        }
        public new long attr_intelligence
        {
            get
            {
                return m_attr_intelligence;
            }
            set
            {
                m_attr_intelligence = value;
            }
        }
        public new long attr_memory
        {
            get
            {
                return m_attr_memory;
            }
            set
            {
                m_attr_memory = value;
            }
        }
        public new long attr_charisma
        {
            get
            {
                return m_attr_charisma;
            }
            set
            {
                m_attr_charisma = value;
            }
        }
        public new long attr_perception
        {
            get
            {
                return m_attr_perception;
            }
            set
            {
                m_attr_perception = value;
            }
        }
        public new long attr_willpower
        {
            get
            {
                return m_attr_willpower;
            }
            set
            {
                m_attr_willpower = value;
            }
        }
        public new long Implant_Int_Value
        {
            get
            {
                return m_Implant_Int_Value;
            }
            set
            {
                m_Implant_Int_Value = value;
            }
        }
        public new long Implant_Mem_Value
        {
            get
            {
                return m_Implant_Mem_Value;
            }
            set
            {
                m_Implant_Mem_Value = value;
            }
        }
        public new long Implant_Cha_Value
        {
            get
            {
                return m_Implant_Cha_Value;
            }
            set
            {
                m_Implant_Cha_Value = value;
            }
        }
        public new long Implant_Per_Value
        {
            get
            {
                return m_Implant_Per_Value;
            }
            set
            {
                m_Implant_Per_Value = value;
            }
        }
        public new long Implant_Wil_Value
        {
            get
            {
                return m_Implant_Wil_Value;
            }
            set
            {
                m_Implant_Wil_Value = value;
            }
        }
        public new decimal balance
        {
            get
            {
                return m_balance;
            }
            set
            {
                m_balance = value;
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
        public new string race
        {
            get
            {
                return m_race;
            }
            set
            {
                m_race = value;
            }
        }
        public new string bloodLine
        {
            get
            {
                return m_bloodLine;
            }
            set
            {
                m_bloodLine = value;
            }
        }
        public new string gender
        {
            get
            {
                return m_gender;
            }
            set
            {
                m_gender = value;
            }
        }
        public new string CorporationName
        {
            get
            {
                return m_CorporationName;
            }
            set
            {
                m_CorporationName = value;
            }
        }
        public new string cloneName
        {
            get
            {
                return m_cloneName;
            }
            set
            {
                m_cloneName = value;
            }
        }
        public new string Implant_Int_Name
        {
            get
            {
                return m_Implant_Int_Name;
            }
            set
            {
                m_Implant_Int_Name = value;
            }
        }
        public new string Implant_Mem_Name
        {
            get
            {
                return m_Implant_Mem_Name;
            }
            set
            {
                m_Implant_Mem_Name = value;
            }
        }
        public new string Implant_Cha_Name
        {
            get
            {
                return m_Implant_Cha_Name;
            }
            set
            {
                m_Implant_Cha_Name = value;
            }
        }
        public new string Implant_Per_Name
        {
            get
            {
                return m_Implant_Per_Name;
            }
            set
            {
                m_Implant_Per_Name = value;
            }
        }
        public new string Implant_Wil_Name
        {
            get
            {
                return m_Implant_Wil_Name;
            }
            set
            {
                m_Implant_Wil_Name = value;
            }
        }
    }
}
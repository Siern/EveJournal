using System;

namespace EVEJournal
{
    public class DBConstraint
    {
        private QueryConstraints m_Constraint = QueryConstraints.None;
        private Object m_Value1 = null;
        private Object m_Value2 = null;
        private static string[] m_ConstraintStrings = { "", "=", "<", ">", "BETWEEN" };

        public enum QueryConstraints : ulong
        {
            None = 0,
            Equal,
            Less,
            Greater,
            Between,
        }

        public DBConstraint()
        {
            this.Constraint = QueryConstraints.None;
        }

        public DBConstraint(QueryConstraints Constraint, Object StartValue)
        {
            this.Constraint = Constraint;
            this.StartValue = StartValue;
        }

        public DBConstraint(QueryConstraints Constraint, Object StartValue, Object EndValue)
        {
            this.Constraint = Constraint;
            this.StartValue = StartValue;
            this.EndValue = EndValue;
        }

        public QueryConstraints Constraint
        {
            get
            {
                return m_Constraint;
            }

            set
            {
                m_Constraint = value;
            }
        }

        public Object StartValue
        {
            get
            {
                return m_Value1;
            }
            set
            {
                m_Value1 = value;
            }
        }
        public Object EndValue
        {
            get
            {
                return m_Value2;
            }
            set
            {
                m_Value2 = value;
            }
        }

        public bool IsValid()
        {
            if (QueryConstraints.None != m_Constraint && null != m_Value1)
                return true;
            return false;
        }

        public string BuildQueryString(string FieldName)
        {
            if (QueryConstraints.None == m_Constraint)
                return "";

            string ret = FieldName + " " + m_ConstraintStrings[(ulong)m_Constraint] + " ";
            //if (typeof(Int32) == m_Value1.GetType())
            //    ret += ((Int32)m_Value1).ToString();
            //else if (typeof(long) == m_Value1.GetType())
            //    ret += ((long)m_Value1).ToString();
            //else if (typeof(Double) == m_Value1.GetType())
            //    ret += ((Double)m_Value1).ToString();
            //else if (typeof(Decimal) == m_Value1.GetType())
            //    ret += ((Decimal)m_Value1).ToString();
            //else if (typeof(Boolean) == m_Value1.GetType())
            //    ret += ((Boolean)m_Value1) ? 1 : 0;
            //else
            //    ret += "\"" + m_Value1.ToString() + "\"";
            ret += DBConvert.ToDBString(m_Value1);

            if (QueryConstraints.Between == m_Constraint)
                ret += " AND ";
            else
                return ret;

            //if (typeof(Int32) == m_Value2.GetType())
            //    ret += ((Int32)m_Value2).ToString();
            //else if (typeof(long) == m_Value2.GetType())
            //    ret += ((long)m_Value2).ToString();
            //else if (typeof(Double) == m_Value2.GetType())
            //    ret += ((Double)m_Value2).ToString();
            //else if (typeof(Decimal) == m_Value2.GetType())
            //    ret += ((Decimal)m_Value2).ToString();
            //else if (typeof(Boolean) == m_Value2.GetType())
            //    ret += ((Boolean)m_Value2) ? 1 : 0;
            //else
            //    ret += "\"" + m_Value2.ToString() + "\"";
            ret += DBConvert.ToDBString(m_Value2);
            return ret;
        }
    }
}
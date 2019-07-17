using System;
using System.Collections.Generic;
using System.Text;

namespace EVEJournal
{
    class DBSortConstraint
    {
        private SortConstraints m_Constraint = SortConstraints.None;
        private static string[] m_ConstraintStrings = { "", "ASC", "DESC" };

        public enum SortConstraints : ulong
        {
            None = 0,
            Ascending,
            Descending,
        }

        public DBSortConstraint()
        {
            this.Constraint = SortConstraints.None;
        }

        public DBSortConstraint(bool bAscending)
        {
            this.Constraint = bAscending ? SortConstraints.Ascending :
                                            SortConstraints.Descending;
        }

        public DBSortConstraint(SortConstraints Constraint)
        {
            this.Constraint = Constraint;
        }

        public SortConstraints Constraint
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

        public bool IsValid()
        {
            if (SortConstraints.None != m_Constraint)
                return true;
            return false;
        }

        public string BuildQueryString(string FieldName)
        {
            if (SortConstraints.None == m_Constraint)
                return "";

            string ret = FieldName + " " + m_ConstraintStrings[(ulong)m_Constraint] + " ";
            return ret;
        }
    }
}

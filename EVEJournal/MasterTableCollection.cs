using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace EVEJournal
{
    class DBMasterTableCollection : IDBRecordRead, IDBCollection
    {
        public event DBEventHandler OnRecordRead;
        public event DBEventHandler OnRecordCollectionAdd;
        public bool bEventOnly = false;

        private Dictionary<DBMasterTable.QueryValues, DBConstraint> m_Constraints =
                    new Dictionary<DBMasterTable.QueryValues, DBConstraint>();

        private Dictionary<ulong, IDBRecord> m_Collection =
                    new Dictionary<ulong, IDBRecord>();

        // IDBCollection
        void IDBCollection.Clear()
        {
            m_Collection.Clear();
        }

        void IDBCollection.FillRecords(SQLiteDataReader reader)
        {
            DBMasterTable empty = new DBMasterTable();
            do
            {
                OnRecordRead(this, new DBEventArgs(empty, reader));
                if (!bEventOnly)
                {
                    DBMasterTable obj = new DBMasterTable(reader);
                    IDBRecord iobj = (IDBRecord)obj;
                    m_Collection.Add(0, iobj);
                    OnRecordCollectionAdd(this, new DBEventArgs(iobj, null));
                }
            } while (reader.Read());
        }

        void IDBCollection.SetEventHandler(enDBEventHandler which, DBEventHandler handler)
        {
            OnRecordRead += handler;
        }

        void IDBCollection.SetEventOnly(bool EventOnly)
        {
            bEventOnly = EventOnly;
        }

        void IDBCollection.SetConstraint(long Op, DBConstraint constraint)
        {
            DBMasterTable.QueryValues which = (DBMasterTable.QueryValues)Op;
            if (DBMasterTable.QueryValues.All == which &&
                DBConstraint.QueryConstraints.None == constraint.Constraint)
            {
                m_Constraints.Clear();
                return;
            }

            if (DBMasterTable.QueryValues.All != which)
            {
                if (DBConstraint.QueryConstraints.None == constraint.Constraint)
                    m_Constraints.Remove(which);
                else
                    m_Constraints.Add(which, constraint);
            }
            else
            {
                foreach (DBMasterTable.QueryValues val in Enum.GetValues(typeof(DBMasterTable.QueryValues)))
                {
                    if (DBMasterTable.QueryValues.All == val)
                        continue;
                    m_Constraints.Add(val, constraint);
                }//foreach                
            }
        }

        void IDBCollection.SetSortConstraint(long which, DBSortConstraint constraint)
        {
            throw new NotImplementedException();
        }

        string IDBCollection.GetDBQuery()
        {
            string str = "SELECT * FROM " + ((IDBCollection)this).GetTableName();
            if (0 != m_Constraints.Count)
            {
                str += " WHERE (";
                bool bFirst = true;
                foreach (KeyValuePair<DBMasterTable.QueryValues, DBConstraint> pair in m_Constraints)
                {
                    str += (bFirst ? "" : ", ") +
                        pair.Value.BuildQueryString(((DBMasterTable.QueryValues)pair.Key).ToString());
                }//foreach
                str += ")";
            }
            str += ";";
            return str;
        }

        string IDBCollection.GetTableName()
        {
            return DBMasterTable.TableName;
        }

        Database.DatabaseError IDBCollection.CreateTable(Database db)
        {
            throw new NotSupportedException();
        }

        IDBRecord IDBCollection.CreateBlankRecord()
        {
            throw new NotSupportedException();
        }

        public override string ToString()
        {
            return ((IDBCollection)this).GetTableName();
        }

        long IDBCollection.GetVersionNumber()
        {
            throw new NotImplementedException();
        }
    }
}
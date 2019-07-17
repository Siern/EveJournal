using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    class VersionCollection : BaseCollection
    {
        public VersionCollection()
            : base()
        {
        }

        protected override string SelectNodeString()
        {
            throw new NotImplementedException();
        }

        protected override IDBRecord CreateRecord()
        {
            return new Version() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new Version(reader) as IDBRecord;
        }

        public override string ToString()
        {
            return Version.TableName;
        }

        //protected override long GetVersionNumber()
        //{
        //    return Version.VersionNumber;
        //}

        protected override long GetVersionNumber()
        {
            return Version.VersionNumber;
        }
    }

    //class VersionCollection : IDBRecordRead, IDBCollection, IDBCollectionContents
    //{
    //    public event DBEventHandler OnRecordRead = null;
    //    public event DBEventHandler OnRecordCollectionAdd = null;
    //    public bool bEventOnly = false;
    //    public bool bKeyAreFake = false;

    //    private Dictionary<Version.QueryValues, DBConstraint> m_Constraints =
    //                new Dictionary<Version.QueryValues, DBConstraint>();

    //    private Dictionary<Version.QueryValues, DBSortConstraint> m_SortConstraint =
    //                new Dictionary<Version.QueryValues, DBSortConstraint>();

    //    private Dictionary<ulong, IDBRecord> m_Collection =
    //                new Dictionary<ulong, IDBRecord>();

    //    public VersionCollection()
    //    {
    //    }

    //    // IDBCollectionContents
    //    long IDBCollectionContents.Count()
    //    {
    //        return m_Collection.Count;
    //    }

    //    IDBRecord IDBCollectionContents.GetRecordInterface(long which)
    //    {
    //        if (0 > which && m_Collection.Count <= which)
    //            throw new ArgumentOutOfRangeException("which", which, "");
    //        // this is a crappy way to do this, but no better way exists under .NET 2.0
    //        Dictionary<ulong, IDBRecord>.KeyCollection.Enumerator enumerator =
    //            m_Collection.Keys.GetEnumerator();
    //        enumerator.MoveNext();
    //        for (; 0 != which; --which)
    //            enumerator.MoveNext();
    //        return m_Collection[enumerator.Current];

    //        // better way to do this, but requires .NET 3.5
    //        //return m_Collection[m_Collection.Keys.ElementAt((int)which)];

    //    }

    //    IDBRecord IDBCollectionContents.GetRecordInterfaceByKey(object key)
    //    {
    //        try
    //        {
    //            return m_Collection[(ulong)DBConvert.ToLong(key)];
    //        }
    //        catch (KeyNotFoundException)
    //        {
    //            return null;
    //        }
    //    }

    //    // IDBCollection
    //    void IDBCollection.Clear()
    //    {
    //        m_Collection.Clear();
    //    }

    //    void IDBCollection.FillRecords(SQLiteDataReader reader)
    //    {
    //        Version empty = new Version();
    //        do
    //        {
    //            if (null != OnRecordRead)
    //                OnRecordRead(this, new DBEventArgs(empty, reader));
    //            if (!bEventOnly)
    //            {
    //                Version obj = new Version(reader);
    //                IDBRecord iobj = (IDBRecord)obj;
    //                m_Collection.Add(ulong.Parse(iobj.GetValueString(iobj.GetIDQueryValue())), iobj);
    //                if (null != OnRecordCollectionAdd)
    //                    OnRecordCollectionAdd(this, new DBEventArgs(iobj, null));
    //            }
    //        } while (reader.Read());
    //    }

    //    void IDBCollection.SetEventHandler(enDBEventHandler which, DBEventHandler handler)
    //    {
    //        switch (which)
    //        {
    //            case enDBEventHandler.OnRecordRead:
    //                OnRecordRead += handler;
    //                break;
    //            case enDBEventHandler.OnRecordCollectionAdd:
    //                OnRecordCollectionAdd += handler;
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    void IDBCollection.SetEventOnly(bool EventOnly)
    //    {
    //        bEventOnly = EventOnly;
    //    }

    //    void IDBCollection.SetConstraint(long Op, DBConstraint constraint)
    //    {
    //        Version.QueryValues which = (Version.QueryValues)Op;
    //        if (Version.QueryValues.All == which &&
    //            DBConstraint.QueryConstraints.None == constraint.Constraint)
    //        {
    //            m_Constraints.Clear();
    //            return;
    //        }

    //        if (Version.QueryValues.All != which)
    //        {
    //            if (DBConstraint.QueryConstraints.None == constraint.Constraint)
    //                m_Constraints.Remove(which);
    //            else
    //                m_Constraints.Add(which, constraint);
    //        }
    //        else
    //        {
    //            foreach (Version.QueryValues val in Enum.GetValues(typeof(Version.QueryValues)))
    //            {
    //                if (Version.QueryValues.All == val)
    //                    continue;
    //                m_Constraints.Add(val, constraint);
    //            }//foreach                
    //        }
    //    }

    //    void IDBCollection.SetSortConstraint(long which, DBSortConstraint constraint)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    string IDBCollection.GetDBQuery()
    //    {
    //        string str = "SELECT * FROM " + ((IDBCollection)this).GetTableName();
    //        if (0 != m_Constraints.Count)
    //        {
    //            str += " WHERE (";
    //            bool bFirst = true;
    //            foreach (KeyValuePair<Version.QueryValues, DBConstraint> pair in m_Constraints)
    //            {
    //                str += (bFirst ? "" : " AND ") +
    //                    pair.Value.BuildQueryString(((Version.QueryValues)pair.Key).ToString());
    //                bFirst = false;
    //            }//foreach
    //            str += ")";
    //        }
    //        if (0 != m_SortConstraint.Count)
    //        {
    //            bool bFirst = true;
    //            str += " ORDER BY ";
    //            //str += "(";
    //            foreach (KeyValuePair<Version.QueryValues, DBSortConstraint> pair in m_SortConstraint)
    //            {
    //                str += (bFirst ? "" : ", ") +
    //                    pair.Value.BuildQueryString(((Version.QueryValues)pair.Key).ToString());
    //                bFirst = false;
    //            }//foreach
    //            //str += ")";
    //        }
    //        str += ";";
    //        return str;
    //    }

    //    string IDBCollection.GetTableName()
    //    {
    //        return Version.TableName;
    //    }

    //    Database.DatabaseError IDBCollection.CreateTable(Database db)
    //    {
    //        return db.CreateTable((IDBRecord)new Version());
    //    }

    //    IDBRecord IDBCollection.CreateBlankRecord()
    //    {
    //        return new Version() as IDBRecord;
    //    }

    //    public override string ToString()
    //    {
    //        return ((IDBCollection)this).GetTableName();
    //    }
    //}
}

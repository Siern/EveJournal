using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;
using System.Data;

#if (USEDOTNET2)
#else
using System.Linq;
#endif

namespace EVEJournal
{
    abstract class BaseCollection :
        IDBCollection, IDBCollectionContents
    {
        #region Event Handlers

        public event DBEventHandler OnRecordRead = null;
        public event DBEventHandler OnRecordCollectionAdd = null;

        #endregion

        #region Data Members

        protected bool bEventOnly = false;
        protected Dictionary<long, DBConstraint> m_Constraints =
                                new Dictionary<long, DBConstraint>();

        protected Dictionary<long, DBSortConstraint> m_SortConstraint =
                                new Dictionary<long, DBSortConstraint>();

        protected Hashtable m_Collection = new Hashtable();

        #endregion

        #region Constructor

        public BaseCollection() { }
        public BaseCollection(XmlDocument xmlDoc, params object[] ids)
        {
            ReadCollectionFromXmlDoc(xmlDoc, ids);
        }

        #endregion

        public virtual void AppendList(XmlDocument xmlDoc, params object[] ids)
        {
            ReadCollectionFromXmlDoc(xmlDoc, ids);
        }

        protected abstract string SelectNodeString();
        protected abstract IDBRecord CreateRecord();
        protected abstract IDBRecord CreateRecord(SQLiteDataReader reader);

        protected virtual IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            throw new NotImplementedException();
        }

        protected virtual long GetVersionNumber()
        {
            throw new NotImplementedException();
        }

        protected virtual void ReadCollectionFromXmlDoc(XmlDocument xmlDoc, params object[] ids)
        {
            foreach (XmlNode row in xmlDoc.SelectNodes(SelectNodeString()))
            {
                IDBRecord rec = CreateRecordFromXmlNode(row, ids);
                m_Collection.Add(rec.GetRecordKey(), rec);
            }
        }

        protected virtual string BuildQuery()
        {
            throw new NotImplementedException();
        }

        #region IDBCollectionContents

        long IDBCollectionContents.Count()
        {
            return m_Collection.Count;
        }

        IDBRecord IDBCollectionContents.GetRecord(RecordKey key)
        {
            return m_Collection[key] as IDBRecord;
        }

        #endregion

        #region IDBCollection

        void IDBCollection.Clear()
        {
            m_Collection.Clear();
        }

        void IDBCollection.FillRecords(SQLiteDataReader reader)
        {
            IDBRecord empty = CreateRecord();
            do
            {
                if (null != OnRecordRead)
                    OnRecordRead(this, new DBEventArgs(empty, reader));

                if (!bEventOnly)
                {
                    IDBRecord iobj = CreateRecord(reader);
                    m_Collection.Add(iobj.GetRecordKey(), iobj);
                    if (null != OnRecordCollectionAdd)
                        OnRecordCollectionAdd(this, new DBEventArgs(iobj, null));
                }
            } while (reader.Read());
        }

        void IDBCollection.SetEventHandler(enDBEventHandler which, DBEventHandler handler)
        {
            switch (which)
            {
                case enDBEventHandler.OnRecordRead:
                    OnRecordRead += handler;
                    break;
                case enDBEventHandler.OnRecordCollectionAdd:
                    OnRecordCollectionAdd += handler;
                    break;
                default:
                    break;
            }
        }

        void IDBCollection.SetEventOnly(bool EventOnly)
        {
            bEventOnly = EventOnly;
        }

        void IDBCollection.SetConstraint(long which, DBConstraint constraint)
        {
            if (-1 == which && DBConstraint.QueryConstraints.None == constraint.Constraint)
            {
                m_Constraints.Clear();
                return;
            }

            if (-1 != which)
            {
                if (DBConstraint.QueryConstraints.None == constraint.Constraint)
                    m_Constraints.Remove(which);
                else
                    m_Constraints.Add(which, constraint);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        void IDBCollection.SetSortConstraint(long which, DBSortConstraint constraint)
        {
            if (-1 == which && DBSortConstraint.SortConstraints.None == constraint.Constraint)
            {
                m_SortConstraint.Clear();
                return;
            }

            if (-1 != which)
            {
                if (DBSortConstraint.SortConstraints.None == constraint.Constraint)
                    m_SortConstraint.Remove(which);
                else
                    m_SortConstraint.Add(which, constraint);
            }
            else
                throw new NotImplementedException();
        }

        string IDBCollection.GetDBQuery()
        {
            return BuildQuery();
        }

        string IDBCollection.GetTableName()
        {
            return this.ToString();
        }

        long IDBCollection.GetVersionNumber()
        {
            return this.GetVersionNumber();
        }

        Database.DatabaseError IDBCollection.CreateTable(Database db)
        {
            return db.CreateTable(CreateRecord());
        }

        IDBRecord IDBCollection.CreateBlankRecord()
        {
            return CreateRecord() as IDBRecord;
        }

        #endregion
    }
}




//namespace EVEJournal
//{
//    abstract class BaseCollection :
//        IDBCollection, IDBCollectionContents, IDBUpgrade
//    {
//        #region Event Handlers

//        public event DBEventHandler OnRecordRead = null;
//        public event DBEventHandler OnRecordCollectionAdd = null;

//        #endregion

//        //=======================================================

//        #region Data Members

//        protected bool bEventOnly = false;

//        //protected Dictionary<long, DBConstraint> m_InsertConstraints = null;

//        protected Dictionary<long, DBConstraint> m_Constraints =
//                                new Dictionary<long, DBConstraint>();

//        protected Dictionary<long, DBSortConstraint> m_SortConstraint =
//                                new Dictionary<long, DBSortConstraint>();

//        protected Dictionary<long, IDBRecord> m_Collection =
//                                new Dictionary<long, IDBRecord>();
//        protected int m_limit = 0;
//        protected int m_offset = 0;
        
//        #endregion

//        //=======================================================

//        public BaseCollection() { }
//        public BaseCollection(XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(xmlDoc);
//        }
//        public BaseCollection(long ID1, XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(ID1, xmlDoc);
//        }
//        public BaseCollection(string ID1, XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(ID1, xmlDoc);
//        }
//        public BaseCollection(long ID1, long ID2, XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(ID1, ID2, xmlDoc);
//        }
//        public BaseCollection(string ID1, string ID2, XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(ID1, ID2, xmlDoc);
//        }

//        //=======================================================

//        #region Protected, virtual & Abstract Methods

//        protected abstract string SelectNodeString();
//        //protected abstract long GetQueryValueAll();
//        protected abstract long GetFirstQueryValue();
//        //protected virtual long GetEndQueryValue()
//        //{
//        //    return GetQueryValueAll();
//        //}
//        protected virtual long GetNextQueryValue(long val)
//        {
//            return (val + 1);
//        }
//        protected abstract string GetQueryValueString(long val);
//        protected abstract long GetQueryValueCount();
//        protected abstract IDBRecord CreateRecord();
//        protected abstract IDBRecord CreateRecord(SQLiteDataReader reader);
//        protected virtual IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode)
//        {
//            throw new NotImplementedException();
//        }
//        protected virtual IDBRecord CreateRecordFromXmlNode(long ID1, XmlNode xmlNode)
//        {
//            throw new NotImplementedException();
//        }
//        protected virtual IDBRecord CreateRecordFromXmlNode(string ID1, XmlNode xmlNode)
//        {
//            throw new NotImplementedException();
//        }
//        protected virtual IDBRecord CreateRecordFromXmlNode(long ID1, long ID2, XmlNode xmlNode)
//        {
//            throw new NotImplementedException();
//        }
//        protected virtual IDBRecord CreateRecordFromXmlNode(string ID1, string ID2, XmlNode xmlNode)
//        {
//            throw new NotImplementedException();
//        }
//        protected virtual IDBRecord CreateRecordFromObject(bool bUseObjKey, long key, object obj)
//        {
//            throw new NotImplementedException();
//        }
//        protected virtual void ReadCollectionFromXmlDoc(XmlDocument xmlDoc)
//        {
//            long i = m_Collection.Count;
//            foreach (XmlNode row in xmlDoc.SelectNodes(SelectNodeString()))
//                m_Collection.Add(i++, CreateRecordFromXmlNode(row));
//        }
//        public virtual void AppendList(XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(xmlDoc);
//        }
//        protected virtual void ReadCollectionFromXmlDoc(long ID1, XmlDocument xmlDoc)
//        {
//            long i = m_Collection.Count;
//            foreach (XmlNode row in xmlDoc.SelectNodes(SelectNodeString()))
//                m_Collection.Add(i++, CreateRecordFromXmlNode(ID1, row));
//        }
//        protected virtual void ReadCollectionFromXmlDoc(string ID1, XmlDocument xmlDoc)
//        {
//            long i = m_Collection.Count;
//            foreach (XmlNode row in xmlDoc.SelectNodes(SelectNodeString()))
//                m_Collection.Add(i++, CreateRecordFromXmlNode(ID1, row));
//        }
//        public virtual void AppendList(string ID1, XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(ID1, xmlDoc);
//        }
//        protected virtual void ReadCollectionFromXmlDoc(long ID1, long ID2, XmlDocument xmlDoc)
//        {
//            long i = m_Collection.Count;
//            foreach (XmlNode row in xmlDoc.SelectNodes(SelectNodeString()))
//                m_Collection.Add(i++, CreateRecordFromXmlNode(ID1, ID2, row));
//        }
//        protected virtual void ReadCollectionFromXmlDoc(string ID1, string ID2, XmlDocument xmlDoc)
//        {
//            long i = m_Collection.Count;
//            foreach (XmlNode row in xmlDoc.SelectNodes(SelectNodeString()))
//                m_Collection.Add(i++, CreateRecordFromXmlNode(ID1, ID2, row));
//        }
//        public virtual void AppendList(string ID1, string ID2, XmlDocument xmlDoc)
//        {
//            ReadCollectionFromXmlDoc(ID1, ID2, xmlDoc);
//        }

//        public virtual void AppendList(bool bUseObjKey, long key, object obj)
//        {
//            long i = m_Collection.Count;
//            m_Collection.Add(i++, CreateRecordFromObject(bUseObjKey, key, obj));
//        }

//        // need to override to use IDBInsertContraintProvider
//        protected virtual bool HasInsertContraintProvider()
//        {
//            return false;
//        }
//        protected virtual void FillInsertConstraintValues(IDBRecord rec)
//        {
//            throw new NotImplementedException();
//        }
//        protected virtual string BuildQuery(Dictionary<long, DBConstraint> constraints,
//            Dictionary<long, DBSortConstraint> sortConstraints, int limit, int offset)
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.Append("SELECT * FROM ");
//            sql.Append(((IDBCollection)this).GetTableName());
//            if (null != constraints && 0 != constraints.Count)
//            {
//                sql.Append(" WHERE (");
//                bool bFirst = true;
//                foreach (KeyValuePair<long, DBConstraint> pair in constraints)
//                {
//                    sql.Append((bFirst ? "" : " AND "));
//                    sql.Append(pair.Value.BuildQueryString(GetQueryValueString(pair.Key)));
//                    bFirst = false;
//                }//foreach
//                sql.Append(")");
//            }

//            if (null != sortConstraints && 0 != sortConstraints.Count)
//            {
//                bool bFirst = true;
//                sql.Append(" ORDER BY ");
//                foreach (KeyValuePair<long, DBSortConstraint> pair in sortConstraints)
//                {
//                    sql.Append((bFirst ? "" : ", "));
//                    sql.Append(pair.Value.BuildQueryString(GetQueryValueString(pair.Key)));
//                    bFirst = false;
//                }//foreach
//            }

//            if (0 != limit)
//            {
//                sql.Append(" LIMIT ");
//                sql.Append(m_limit.ToString());
//            }

//            if (0 != offset)
//            {
//                sql.Append(" OFFSET ");
//                sql.Append(m_offset.ToString());
//            }

//            sql.Append(";");
//            return sql.ToString();
//        }

//        public virtual void DoBulkLoader(Database db)
//        {
//            Database.DatabaseBulkLoader loader =
//                new Database.DatabaseBulkLoader(db);

//            loader.SetCommand(GetGeneralDBInsert());
//            long count = GetQueryValueCount();
//            loader.AddParameter(count);

//            foreach (IDBRecord rec in m_Collection.Values)
//            {
//                for (long i = 0; i < count; ++i)
//                {
//                    loader.SetParamValue(i, rec.GetValueDBFormat(i));
//                }
//                loader.DBWrite();
//            }
//            loader.EndTransaction();
//        }

//        protected virtual long GetVersionNumber()
//        {
//            throw new NotImplementedException();
//        }

//        protected virtual string GetGeneralDBInsert()
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        //=======================================================


//        #region IDBCollectionContents

//        long IDBCollectionContents.Count()
//        {
//            return m_Collection.Count;
//        }

//        IDBRecord IDBCollectionContents.GetRecordInterface(long which)
//        {
//        #if (USEDOTNET2)
//            // .NET 2.0 method
//            if (0 > which && m_Collection.Count <= which)
//                throw new ArgumentOutOfRangeException("which", which, "");
//            // this is a crappy way to do this, but no better way exists under .NET 2.0
//            Dictionary<ulong, IDBRecord>.KeyCollection.Enumerator enumerator =
//                m_Collection.Keys.GetEnumerator();
//            enumerator.MoveNext();
//            for (; 0 != which; --which)
//                enumerator.MoveNext();
//            return m_Collection[enumerator.Current];
//        #else
//            // better way to do this, but requires .NET 3.5
//            return m_Collection[m_Collection.Keys.ElementAt((int)which)];
//        #endif
//        }

//        IDBRecord IDBCollectionContents.GetRecordInterfaceByKey(object key)
//        {
//            try
//            {
//                return m_Collection[DBConvert.ToLong(key)];
//            }
//            catch (KeyNotFoundException)
//            {
//                return null;
//            }
//        }

//        string IDBCollectionContents.GetGeneralDBInsert()
//        {
//            return GetGeneralDBInsert();
//        }

//        #endregion

//        //=======================================================

//        #region IDBCollection

//        void IDBCollection.Clear()
//        {
//            m_Collection.Clear();
//        }

//        void IDBCollection.FillRecords(SQLiteDataReader reader)
//        {
//            IDBRecord empty = CreateRecord();
//            do
//            {
//                if (null != OnRecordRead)
//                    OnRecordRead(this, new DBEventArgs(empty, reader));
//                if (!bEventOnly)
//                {
//                    IDBRecord iobj = CreateRecord(reader);
//                    m_Collection.Add(ulong.Parse(iobj.GetValueString(iobj.GetIDQueryValue())), iobj);
//                    if (null != OnRecordCollectionAdd)
//                        OnRecordCollectionAdd(this, new DBEventArgs(iobj, null));
//                }
//            } while (reader.Read());
//        }

//        void IDBCollection.SetEventHandler(enDBEventHandler which, DBEventHandler handler)
//        {
//            switch (which)
//            {
//                case enDBEventHandler.OnRecordRead:
//                    OnRecordRead += handler;
//                    break;
//                case enDBEventHandler.OnRecordCollectionAdd:
//                    OnRecordCollectionAdd += handler;
//                    break;
//                default:
//                    break;
//            }
//        }

//        void IDBCollection.SetEventOnly(bool EventOnly)
//        {
//            bEventOnly = EventOnly;
//        }

//        void IDBCollection.SetConstraint(long which, DBConstraint constraint)
//        {
//            if (GetQueryValueAll() == which &&
//                DBConstraint.QueryConstraints.None == constraint.Constraint)
//            {
//                m_Constraints.Clear();
//                return;
//            }

//            if (GetQueryValueAll() != which)
//            {
//                if (DBConstraint.QueryConstraints.None == constraint.Constraint)
//                    m_Constraints.Remove(which);
//                else
//                    m_Constraints.Add(which, constraint);
//            }
//            else
//            {
//                for (long val = GetFirstQueryValue(); val != GetEndQueryValue(); val = GetNextQueryValue(val))
//                    m_Constraints.Add(val, constraint);
//            }
//        }

//        void IDBCollection.SetSortConstraint(long which, DBSortConstraint constraint)
//        {
//            if (GetQueryValueAll() == which &&
//                DBSortConstraint.SortConstraints.None == constraint.Constraint)
//            {
//                m_SortConstraint.Clear();
//                return;
//            }

//            if (GetQueryValueAll() != which)
//            {
//                if (DBSortConstraint.SortConstraints.None == constraint.Constraint)
//                    m_SortConstraint.Remove(which);
//                else
//                    m_SortConstraint.Add(which, constraint);
//            }
//        }

//        string IDBCollection.GetDBQuery()
//        {
//            return BuildQuery(m_Constraints, m_SortConstraint, m_limit, m_offset);
//        }

//        string IDBCollection.GetTableName()
//        {
//            return this.ToString();
//        }

//        long IDBCollection.GetVersionNumber()
//        {
//            return this.GetVersionNumber();
//        }

//        Database.DatabaseError IDBCollection.CreateTable(Database db)
//        {
//            return db.CreateTable(CreateRecord());
//        }

//        IDBRecord IDBCollection.CreateBlankRecord()
//        {
//            return CreateRecord() as IDBRecord;
//        }

//        #endregion

//        //=======================================================

//        #region IDBUpgrade

//        Database.DatabaseError IDBUpgrade.Upgrade(Database db, long prevVersion)
//        {
//            Database.DatabaseError err;
//            Logger.ReportNotice(String.Format("Table '{0}': Renaming Table to Temporary Backup Table", this.ToString()));
//            err = db.ExecuteCommand(String.Format("ALTER TABLE {0} RENAME TO {0}2", this.ToString()));
//            if (err != Database.DatabaseError.NoError)
//                return Database.DatabaseError.Unexpected;

//            Logger.ReportNotice(String.Format("Table '{0}': Creating new table", this.ToString()));
//            err = db.CreateTable(this.CreateRecord());
//            if (err != Database.DatabaseError.NoError)
//                return Database.DatabaseError.Unexpected;

//            Logger.ReportNotice(String.Format("Table '{0}': Copying records Temporary Backup Table", this.ToString()));
//            err = db.ExecuteCommand(String.Format("INSERT INTO {0} SELECT * FROM {0}2", this.ToString()));
//            if (err != Database.DatabaseError.NoError)
//                return Database.DatabaseError.Unexpected;

//            Logger.ReportNotice(String.Format("Table '{0}': Deleting Temporary Backup Table", this.ToString()));
//            err = db.ExecuteCommand(String.Format("DROP TABLE {0}2", this.ToString()));
//            if (err != Database.DatabaseError.NoError)
//                return Database.DatabaseError.Unexpected;

//            return Database.DatabaseError.NoError;
//        }

//        #endregion
//    }
//}

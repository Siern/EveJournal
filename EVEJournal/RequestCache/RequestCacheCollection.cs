using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    class RequestCacheCollection : BaseCollection
    {
        public RequestCacheCollection()
        { }
        public RequestCacheCollection(RequestID RequestID, string UserID, string url, string xml)
        {
            m_Collection.Add((long)m_Collection.Count,
                (IDBRecord)new RequestCache(RequestID, UserID, url, xml));
        }
        public RequestCacheCollection(RequestID RequestID, string UserID, string url, TextReader s)
        {
            m_Collection.Add((long)m_Collection.Count,
                (IDBRecord)new RequestCache(RequestID, UserID, url, s.ReadToEnd()));
        }
        protected override string SelectNodeString()
        {
            throw new NotImplementedException();
        }

        protected override IDBRecord CreateRecord()
        {
            return new RequestCache();
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return (IDBRecord)new RequestCache(reader);
        }
        public override string ToString()
        {
            return RequestCache.TableName;
        }
        protected override long GetVersionNumber()
        {
            return RequestCache.VersionNumber;
        }
    }
}

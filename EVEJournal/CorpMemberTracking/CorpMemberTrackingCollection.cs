using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    class CorporationMemberTrackingCollection : BaseCollection
    {
        public CorporationMemberTrackingCollection()
            : base()
        {
        }

        public CorporationMemberTrackingCollection(XmlDocument xmlDoc, params object[] ids)
            : base(xmlDoc, ids)
        {
        }

        protected override string SelectNodeString()
        {
            return "rowset[@name='members']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CorporationMemberTracking() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CorporationMemberTracking(reader) as IDBRecord;
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return new CorporationMemberTracking((long)ids[0], xmlNode) as IDBRecord;
        }

        public override string ToString()
        {
            return CorporationMemberTracking.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CorporationMemberTracking.VersionNumber;
        }
    }
}
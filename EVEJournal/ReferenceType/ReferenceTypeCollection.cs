using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    class ReferenceTypeCollection : BaseCollection
    {
        public ReferenceTypeCollection()
            : base()
        { }
        public ReferenceTypeCollection(XmlDocument xmlDoc)
            : base(xmlDoc)
        { }

        protected override string SelectNodeString()
        {
            return "rowset[@name='refTypes']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new ReferenceType() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new ReferenceType(reader) as IDBRecord;
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return (IDBRecord)new ReferenceType(xmlNode);
        }

        public override string ToString()
        {
            return ReferenceType.TableName;
        }

        protected override long GetVersionNumber()
        {
            return ReferenceType.VersionNumber;
        }
    }
}

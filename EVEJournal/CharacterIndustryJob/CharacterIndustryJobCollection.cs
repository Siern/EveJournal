using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

namespace EVEJournal
{

    partial class CharacterIndustryJobCollection : BaseCollection
    {
        public CharacterIndustryJobCollection()
            : base()
        { }

        public CharacterIndustryJobCollection(XmlDocument xmlDoc, params object[] ids)
            : base(xmlDoc, ids)
        { }

        protected override string SelectNodeString()
        {
            return "rowset[@name='jobs']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CharacterIndustryJob() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CharacterIndustryJob(reader) as IDBRecord;
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return new CharacterIndustryJob((long)ids[0], xmlNode) as IDBRecord;
        }

        public override string ToString()
        {
            return CharacterIndustryJob.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CharacterIndustryJob.VersionNumber;
        }
    }

}

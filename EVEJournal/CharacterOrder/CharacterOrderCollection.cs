using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    partial class CharacterOrderCollection : BaseCollection
    {
        public CharacterOrderCollection()
            : base()
        { }

        public CharacterOrderCollection(string CharID, XmlDocument xmlDoc)
            : base(CharID, xmlDoc)
        { }

        protected override string SelectNodeString()
        {
            return "rowset[@name='orders']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CharacterOrder() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CharacterOrder(reader) as IDBRecord;
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return new CharacterOrder(ids[0], xmlNode) as IDBRecord;
        }

        public override string ToString()
        {
            return CharacterOrder.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CharacterOrder.VersionNumber;
        }

    }
}
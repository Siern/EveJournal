using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;
using System.Text;

namespace EVEJournal
{
    class CharacterCollection : BaseCollection
    {
        public CharacterCollection() : base()
        { }
        public CharacterCollection(XmlDocument xmlDoc) : base(xmlDoc)
        { }
        protected override string SelectNodeString()
        {
            return "rowset[@name='characters']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return (IDBRecord)new Character();
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return (IDBRecord)new Character(reader);
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return (IDBRecord)new Character(xmlNode);
        }
        public override string ToString()
        {
            return Character.TableName;
        }

        protected override long GetVersionNumber()
        {
            return Character.VersionNumber;
        }
    }
}
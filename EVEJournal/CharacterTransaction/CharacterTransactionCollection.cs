using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{

    class CharacterTransactionCollection : BaseCollection
        //IDBRecordRead, IDBCollection, IDBCollectionContents, IDBInsertContraintProvider
    {
        public CharacterTransactionCollection()
            : base()
        { }

        public CharacterTransactionCollection(string CharID, XmlDocument xmlDoc)
            : base(CharID, xmlDoc)
        { }

        protected override string SelectNodeString()
        {
            return "rowset[@name='transactions']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CharacterTransaction() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CharacterTransaction(reader) as IDBRecord;
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return new CharacterTransaction(ids[0], xmlNode) as IDBRecord;
        }

        public override string ToString()
        {
            return CharacterTransaction.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CharacterTransaction.VersionNumber;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SQLite;

namespace EVEJournal
{
    partial class CharAccountBalanceCollection : BaseCollection
    {
        public CharAccountBalanceCollection()
            : base()
        { }

        public CharAccountBalanceCollection(long CharID, XmlDocument xmlDoc)
            : base(CharID, xmlDoc)
        {
        }

        protected override string SelectNodeString()
        {
            return "rowset[@name='accounts']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CharAccountBalance() as IDBRecord;
        }

        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CharAccountBalance(reader);
        }

        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return new CharAccountBalance(ids[0], xmlNode);
        }

        public override string ToString()
        {
            return CharAccountBalance.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CharAccountBalance.VersionNumber;
        }

    }
}

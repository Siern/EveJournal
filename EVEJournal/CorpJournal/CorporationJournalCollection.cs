﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    class CorporationJournalCollection : BaseCollection
    {
        public CorporationJournalCollection()
            : base()
        {
        }

        public CorporationJournalCollection(string CorpID, string Division, XmlDocument xmlDoc)
            : base(CorpID, Division, xmlDoc)
        {
        }

        protected override string SelectNodeString()
        {
            return "rowset[@name='entries']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CorporationJournal() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CorporationJournal(reader) as IDBRecord;
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return new CorporationJournal(ids[0], ids[1], xmlNode) as IDBRecord;
        }

        private void BuildInsertConstraints()
        {
            throw new NotSupportedException();
        }

        public override string ToString()
        {
            return CorporationJournal.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CorporationJournal.VersionNumber;
        }
    }
}

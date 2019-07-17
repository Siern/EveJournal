﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    partial class CharacterJournalCollection : BaseCollection
    {
        public CharacterJournalCollection()
            : base()
        { }

        public CharacterJournalCollection(string CharID, XmlDocument xmlDoc)
            : base(CharID, xmlDoc)
        { }

        protected override string SelectNodeString()
        {
            return "rowset[@name='entries']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CharacterJournal() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CharacterJournal(reader) as IDBRecord;
        }
        protected override IDBRecord CreateRecordFromXmlNode(XmlNode xmlNode, params object[] ids)
        {
            return new CharacterJournal(ids[0], xmlNode) as IDBRecord;
        }

        public override string ToString()
        {
            return CharacterJournal.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CharacterJournal.VersionNumber;
        }

    }
}
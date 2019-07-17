using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    class MemberTrackingSettingsCollection : BaseCollection
    {
        public MemberTrackingSettingsCollection()
            : base()
        {
        }

        protected override string SelectNodeString()
        {
            throw new NotImplementedException();
        }

        protected override IDBRecord CreateRecord()
        {
            return new MemberTrackingSettings() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new MemberTrackingSettings(reader) as IDBRecord;
        }

        public override string ToString()
        {
            return MemberTrackingSettings.TableName;
        }

        protected override long GetVersionNumber()
        {
            return MemberTrackingSettings.VersionNumber;
        }

    }
}
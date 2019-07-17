using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    partial class CorpWalletNameCollection : BaseCollection
    {
        public CorpWalletNameCollection()
            : base()
        { }

        protected override string SelectNodeString()
        {
            return "rowset[@name='entries']/row";
        }

        protected override IDBRecord CreateRecord()
        {
            return new CorpWalletName() as IDBRecord;
        }
        protected override IDBRecord CreateRecord(SQLiteDataReader reader)
        {
            return new CorpWalletName(reader) as IDBRecord;
        }

        //protected override IDBRecord CreateRecordFromObject(bool bUseObjKey, long key, object obj)
        //{
        //    CorpWalletNameObjectInternal CorpObj = obj as CorpWalletNameObjectInternal;
        //    if( null != CorpObj )
        //        return new CorpWalletName(bUseObjKey ? CorpObj.CorpID : key, CorpObj);

        //    if( bUseObjKey )
        //        throw new NotSupportedException();
        //    CorpWalletNameObjectWritable CorpObjWrite = obj as CorpWalletNameObjectWritable;
        //    return new CorpWalletName(key, CorpObjWrite);
        //}

        public override string ToString()
        {
            return CorpWalletName.TableName;
        }

        protected override long GetVersionNumber()
        {
            return CorpWalletName.VersionNumber;
        }

    }
}
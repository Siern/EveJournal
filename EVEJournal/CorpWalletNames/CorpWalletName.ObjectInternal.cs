using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml;

namespace EVEJournal
{
    partial class CorpWalletName : IDBRecord
    {
        private class CorpWalletNameObjectInternal : CorpWalletNameObjectWritable
        {
            public CorpWalletNameObjectInternal() { }
        }
    }
}

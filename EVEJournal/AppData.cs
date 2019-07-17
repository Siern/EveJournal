using System;
using System.Collections;
using System.Collections.Generic;

namespace EVEJournal
{
    static class AppData
    {
        public static bool bDEBUG = false;
        public static bool bAutoFetch = false;
        public static bool bFetchOnlyDefault = false;
        public static int DefaultChar = -1;
        public static bool bUseBulkLoader = true;

        public enum enFetchFields : int
        {
            W       = 0x0001,
            T       = 0x0002,
            CW0     = 0x0004,
            CW1     = 0x0008,
            CW2     = 0x0010,
            CW3     = 0x0020,
            CW4     = 0x0040,
            CW5     = 0x0080,
            CW6     = 0x0100,
            CWA     = (CW0 | CW1 | CW2 | CW3 | CW4 | CW5 | CW6),
            CT0     = 0x0200,
            CT1     = 0x0400,
            CT2     = 0x0800,
            CT3     = 0x1000,
            CT4     = 0x2000,
            CT5     = 0x4000,
            CT6     = 0x8000,
            CTA     = (CT0 | CT1 | CT2 | CT3 | CT4 | CT5 | CT6),
        };

        public static enFetchFields AutoFetchFields;

        static private Dictionary<int, string> m_RefValues = new Dictionary<int, string>();

        public static Dictionary<int, string> ReferenceName
        {
            get
            {
                return m_RefValues;
            }
        }

        public static void InitConstants(Database db)
        {
            ReferenceTypeCollection col = new ReferenceTypeCollection();
            db.ReadRecord(col as IDBCollection);
            IDBCollectionContents icol = col as IDBCollectionContents;
            for (long i = 0; i < icol.Count(); ++i)
            {
                IDBRecord rec = icol.GetRecordInterface(i);
                ReferenceTypeObject obj = rec.GetDataObject() as ReferenceTypeObject;
                m_RefValues.Add((int)obj.refTypeID, obj.refTypeName);
            }
        }

        private static CommandLineDlg dlg = null;
        public static void ShowCommandLineDlg()
        {
            if (null != dlg && !dlg.IsDisposed )
            {
                BringCommandLineDlgToFront();
                return;
            }

            dlg = new CommandLineDlg();
            dlg.Show();
        }

        public static void BringCommandLineDlgToFront()
        {
            if (null != dlg && !dlg.IsDisposed)
                dlg.BringToFront();
        }
    }
}
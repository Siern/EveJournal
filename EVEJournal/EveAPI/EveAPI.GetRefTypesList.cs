using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;

namespace EVEJournal
{
    internal partial class EveApi
    {
        public static ReferenceTypeCollection GetRefTypesList(Database db)
        {
            return GetRefTypesList(db, false);
        }

        public static ReferenceTypeCollection GetRefTypesList(Database db, bool bUseCache)
        {
            string url = String.Format("{0}{1}", ApiSite, EveApi.RefTypesList);
            string str = CheckRequestCache(db, RequestID.RefTypes, "0", url);
            if (null == str)
            {
                Stream s = openUrl(url);
                if (null == s)
                    return new ReferenceTypeCollection();
                str = new StreamReader(s).ReadToEnd();
                WriteRequestCache(db, RequestID.RefTypes, "0", url, str);
            }
            else if (!bUseCache)
                return new ReferenceTypeCollection();

            XmlDocument xmlDoc = GetXml(new StringReader(str));
            if (null == xmlDoc)
                return new ReferenceTypeCollection();
            return new ReferenceTypeCollection(xmlDoc);
        }
    }
}

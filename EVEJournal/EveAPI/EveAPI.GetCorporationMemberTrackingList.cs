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
        public static CorporationMemberTrackingCollection GetCorporationMemberTrackingList(Database db, EveApiId id,
                            string CharID, bool bUseCache)
        {
            if (!id.IsFullKey())
                return new CorporationMemberTrackingCollection(); // return empty

            string url = String.Format("{0}{1}?userID={2}&characterID={3}&apiKey={4}",
                    ApiSite, EveApi.MemberTracking, id.UserId, CharID, id.Key);
            string str = CheckRequestCache(db, RequestID.CorpMemberTracking, id.UserId, url);
            if (null == str)
            {
                str = new StreamReader(openUrl(url)).ReadToEnd();
                WriteRequestCache(db, RequestID.CorpMemberTracking, id.UserId, url, str);
            }
            else if (!bUseCache)
            {
                return new CorporationMemberTrackingCollection(); // not allowed to use caching 
            }

            XmlDocument xmlDoc = GetXml(new StringReader(str));
            if (null == xmlDoc)
                return new CorporationMemberTrackingCollection(); // error
            return new CorporationMemberTrackingCollection(CharID, xmlDoc);
        }
    }
}
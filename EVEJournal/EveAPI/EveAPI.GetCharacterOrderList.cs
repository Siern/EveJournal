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
        public static CharacterOrderCollection GetCharacterOrderList(Database db, EveApiId id,
                            string CharID)
        {
            return GetCharacterOrderList(db, id, CharID, false);
        }

        public static CharacterOrderCollection GetCharacterOrderList(Database db, EveApiId id,
                            string CharID, bool bUseCache)
        {
            if (!id.IsFullKey())
                return new CharacterOrderCollection(); // return empty

            string url = String.Format("{0}{1}?userID={2}&characterID={3}&apiKey={4}",
                    ApiSite, EveApi.CharMarketOrders, id.UserId, CharID, id.Key);
            string str = CheckRequestCache(db, RequestID.CharacterOrder, id.UserId, url);
            if (null == str)
            {
                str = new StreamReader(openUrl(url)).ReadToEnd();
                WriteRequestCache(db, RequestID.CharacterOrder, id.UserId, url, str);
            }
            else if (!bUseCache)
            {
                return new CharacterOrderCollection(); // not allowed to use caching 
            }

            XmlDocument xmlDoc = GetXml(new StringReader(str));
            if (null == xmlDoc)
                return new CharacterOrderCollection(); // error
            return new CharacterOrderCollection(CharID, xmlDoc);
        }
    }
}
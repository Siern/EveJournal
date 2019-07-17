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
        public static CharacterCollection GetCharacterList(Database db, EveApiId id)
        {
            string url = String.Format("{0}{1}?userID={2}&apiKey={3}",
                                        ApiSite, CharacterList, id.UserId, id.Key);

            string str = CheckRequestCache(db, RequestID.CharacterList, id.UserId, url);
            if (null != str)
                return new CharacterCollection(GetXml(new StringReader(str)));

            str = new StreamReader(openUrl(url)).ReadToEnd();

            XmlDocument xmlDoc = GetXml(new StringReader(str));
            if (null == xmlDoc)
                return new CharacterCollection();

            WriteRequestCache(db, RequestID.CharacterList, id.UserId, url, str);
            return new CharacterCollection(xmlDoc);
        }
    }
}

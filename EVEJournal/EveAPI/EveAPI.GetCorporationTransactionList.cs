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
        public static CorporationTransactionCollection GetCorporationTransactionList(
            Database db, EveApiId id, string CharID, string CorpID, 
            string beforeTransId, string CorpDivision, bool bAutoWalk,
            bool bAllDivisions, bool bUseCache)
        {
            if (!id.IsFullKey())
                return new CorporationTransactionCollection(); // return empty

            string url = String.Format("{0}{1}?userID={2}&characterID={3}&apiKey={4}&version=2",
                                ApiSite, CorpWalletTransactions, id.UserId, CharID, id.Key);
            if (null != beforeTransId && 0 < long.Parse(beforeTransId))
            {
                url += String.Format("&beforeTransID={0}", beforeTransId);
            }
            XmlDocument xmlDoc = GetXml(url);
            return new CorporationTransactionCollection(CorpID, CorpDivision, xmlDoc);
        }
    }
}
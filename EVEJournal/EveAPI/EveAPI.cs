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
        // documentation.... sort of...
        // http://wiki.eve-id.net/APIv2_Page_Index

        /// This is the main domain name that is the prefix for all requests.
        private static readonly string ApiSite = "http://api.eve-online.com";
        /// The location of the character account balance xml file
        private static readonly string CharacterAccountBalance = "/char/AccountBalance.xml.aspx";
        /// The location of the corporation account balance xml file
        private static readonly string CorpAccountBalance = "/corp/AccountBalance.xml.aspx";
        /// The location of the character list xml file
        private static readonly string CharacterList = "/account/Characters.xml.aspx";
        /// The location of the corporation's starbase details xml file
        private static readonly string StarbaseDetails = "/corp/StarbaseDetail.xml.aspx";
        /// The location of the corporation's starbase list xml file
        private static readonly string StarbaseList = "/corp/StarbaseList.xml.aspx";
        /// The location of the error list
        private static readonly string ErrorList = "/eve/ErrorList.xml.aspx";
        /// The location of the character's asset list xml file
        private static readonly string CharAssetList = "/char/AssetList.xml.aspx";
        /// The location of the corporation asset list xml file
        private static readonly string CorpAssetList = "/corp/AssetList.xml.aspx";
        /// The location of the character's industrial jobs xml file
        private static readonly string CharIndustryJobs = "/char/IndustryJobs.xml.aspx";
        /// The location of the corporation's industrial jobs xml file
        private static readonly string CorpIndustryJobs = "/corp/IndustryJobs.xml.aspx";
        /// The location of the character's journal entries xml file
        //private static readonly string CharJournalEntries = "/char/JournalEntries.xml.aspx";
        private static readonly string CharJournalEntries = "/char/WalletJournal.xml.aspx";
        /// The location of the corporation's journal entries xml file
        private static readonly string CorpJournalEntries = "/corp/WalletJournal.xml.aspx";
        /// The location of the character's wallet transaction xml file
        private static readonly string CharWalletTransactions = "/char/WalletTransactions.xml.aspx";
        /// The location of the corporation's wallet transactions xml file
        private static readonly string CorpWalletTransactions = "/corp/WalletTransactions.xml.aspx";
        /// The location of the character's market order xml file
        private static readonly string CharMarketOrders = "/char/MarketOrders.xml.aspx";
        /// The location of the corporation's market order xml file
        private static readonly string CorpMarketOrders = "/corp/MarketOrders.xml.aspx";
        /// The location of the reference type list xml file
        private static readonly string RefTypesList = "/eve/RefTypes.xml.aspx";
        /// The location of the member tracking xml file
        private static readonly string MemberTracking = "/corp/MemberTracking.xml.aspx";
        /// The location of the characterid and name conversion xml file
        private static readonly string CharacterIdName = "/eve/CharacterID.xml.aspx";
        /// The location of the character sheet xml file
        private static readonly string CharacterSheet = "/char/CharacterSheet.xml.aspx";
        /// The location of the alliance list xml file
        private static readonly string AllianceList = "/eve/AllianceList.xml.aspx";
        /// The location of the map jump statistics xml file
        private static readonly string MapJumps = "/map/Jumps.xml.aspx";
        /// The location of the map kills statistics xml file
        private static readonly string MapKills = "/map/Kills.xml.aspx";
        /// The location of the map sovernty statistics xml file
        private static readonly string MapSoveignty = "/map/Sovereignty.xml.aspx";
        /// The location of the conquerable stations and outpost statistics xml file
        private static readonly string ConquerableStationOutpost = "/eve/ConquerableStationList.xml.aspx";
        /// The location of the coporation sheet xml file
        private static readonly string CorporationSheet = "/corp/CorporationSheet.xml.aspx";
        /// The location of the characters killlog xml file
        private static readonly string CharKillLog = "/char/Killlog.xml.aspx";
        /// The location of the corporation killlog xml file
        private static readonly string CorpKillLog = "/corp/Killlog.xml.aspx";
        /// The location of the characters current skill in training xml file
        private static readonly string SkillInTraining = "/char/SkillInTraining.xml.aspx";
        /// The location of the current eve skill tree xml file
        private static readonly string SkillTree = "/eve/SkillTree.xml.aspx";

        private static readonly string userAgent = "EveJournal/1";
        private static WebProxy proxy = null;

        private static Stream openUrl(string url)
        {
            try
            {
                Logger.ReportNotice("Accessing - " + url);
                WebClient wc = new WebClient();
                wc.Headers.Add("user-agent", userAgent);
                if (proxy != null)
                    wc.Proxy = proxy;
                return wc.OpenRead(url);
            }
            catch (System.Net.WebException e)
            {
                Logger.ReportError(String.Format("Web Service Reported: [{0}] {1}", url, e.Message));
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        private static XmlDocument GetXml(string url)
        {
            Stream s = openUrl(url);
            if (null == s)
                return null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(s);

            XmlNode node = xmlDoc.SelectSingleNode("eveapi/error");
            if (null != node)
            {
                // error code
                Logger.ReportError(string.Format("EVEApi Error #{0} - \"{1}\"",
                    xmlDoc.SelectSingleNode("eveapi/error").Attributes["code"].Value,
                    xmlDoc.SelectSingleNode("eveapi/error").InnerText));
            }
            return xmlDoc;
        }

        private static XmlDocument GetXml(Stream s)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(s);

            XmlNode node = xmlDoc.SelectSingleNode("eveapi/error");
            if (null != node)
            {
                // error code
                Logger.ReportError(string.Format("EVEApi Error #{0} - \"{1}\"",
                    xmlDoc.SelectSingleNode("eveapi/error").Attributes["code"].Value,
                    xmlDoc.SelectSingleNode("eveapi/error").InnerText));
                return null;
            }

            return xmlDoc;
        }

        private static XmlDocument GetXml(TextReader s)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(s);

            XmlNode node = xmlDoc.SelectSingleNode("eveapi/error");
            if (null != node)
            {
                // error code
                Logger.ReportError(string.Format("EVEApi Error #{0} - \"{1}\"",
                    xmlDoc.SelectSingleNode("eveapi/error").Attributes["code"].Value,
                    xmlDoc.SelectSingleNode("eveapi/error").InnerText));
                return null;
            }

            return xmlDoc;
        }

        private static string CheckRequestCache(Database db, RequestID rid, string UserID, string url)
        {
            DateTime dt = TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.Now);
            RequestCacheCollection col = new RequestCacheCollection();
            IDBCollection icol = (IDBCollection)col;
            icol.SetConstraint((long)RequestCache.QueryValues.UserID,
                new DBConstraint(DBConstraint.QueryConstraints.Equal, UserID));
            icol.SetConstraint((long)RequestCache.QueryValues.ValidUntil,
                new DBConstraint(DBConstraint.QueryConstraints.Greater, dt.ToOADate().ToString()));
            icol.SetConstraint((long)RequestCache.QueryValues.url,
                new DBConstraint(DBConstraint.QueryConstraints.Equal, url));

            db.ReadRecord((IDBCollection)col);
            IDBCollectionContents ccol = (IDBCollectionContents)col;
            if (0 == ccol.Count())
                return null;
            IDBRecord rec = ccol.GetRecordInterface(0);
            RequestObject obj = (RequestObject)rec.GetDataObject();
            Logger.ReportNotice("Using cached response, can make a new call after " + obj.ValidUntil.ToString());
            return Compression.Decompress(obj.Response);
        }

        private static void WriteRequestCache(Database db, RequestID rid, string UserID, string url, string s)
        {
            RequestCacheCollection col =
                new RequestCacheCollection(rid, UserID, url, s);
            IDBCollectionContents ccol = (IDBCollectionContents)col;
            for (int i = 0; i < ccol.Count(); ++i)
            { // this loop should normally have only 1 iteration
                Logger.ReportNotice("Response Cached.");
                db.InsertRecord(ccol.GetRecordInterface(i));
            }
        }

    }
}

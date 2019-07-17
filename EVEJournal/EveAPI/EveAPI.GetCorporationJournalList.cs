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
        public static CorporationJournalCollection GetCorporationJournalList(
            Database db, EveApiId id, string CharID, string CorpID, 
            string beforeRefID, string CorpDivision, bool bAutoWalk, 
            bool bAllDivisions, bool bUseCache)
        {
            if (!id.IsFullKey())
                return new CorporationJournalCollection(); // return empty

            CorporationJournalCollection journal = null;
            long division = 1000;
            if (null != CorpDivision && !bAllDivisions)
                division = long.Parse(CorpDivision);

            long lastDivisionCount = 0;
            do
            {
                long remainder = 0;
                long lastCount = 0;
                do
                {
                    StringBuilder BuildUrl = new StringBuilder();
                    BuildUrl.AppendFormat("{0}{1}?userID={2}&characterID={3}&apiKey={4}",
                                        ApiSite, CorpJournalEntries, id.UserId, CharID, id.Key);
                    BuildUrl.AppendFormat("&accountKey={0}", division.ToString());
                    if (null != beforeRefID && 0 < long.Parse(beforeRefID))
                    {
                        BuildUrl.AppendFormat("&beforeRefID={0}", beforeRefID);
                    }

                    string url = BuildUrl.ToString();
                    string str = CheckRequestCache(db, RequestID.CorporationJournal, id.UserId, url);
                    if (null == str)
                    {
                        Stream s = openUrl(url);
                        if (null == s)
                            return (null != journal) ? journal : (new CorporationJournalCollection());
                        str = new StreamReader(s).ReadToEnd();
                        WriteRequestCache(db, RequestID.CorporationJournal, id.UserId, url, str);
                    }
                    else if (!bUseCache)
                    {
                        break; // not allowed to use caching 
                    }

                    XmlDocument xmlDoc = GetXml(new StringReader(str));
                    if (null != xmlDoc)
                    {
                        if (null == journal)
                            journal = new CorporationJournalCollection(CorpID, division.ToString(), xmlDoc);
                        else
                            journal.AppendList(CorpID, division.ToString(), xmlDoc);
                    }
                    if (null == journal)
                        remainder = -1;
                    else
                    {
                        IDBCollectionContents con = (IDBCollectionContents)journal;
                        if (0 == con.Count() - lastDivisionCount)
                            remainder = -1;
                        else if (lastCount == con.Count() - lastDivisionCount)
                            remainder = -1;
                        else
                        {
                            lastCount = con.Count() - lastDivisionCount;
                            remainder = lastCount % 1000;
                            if (0 == remainder)
                            {
                                IDBRecord rec1 = con.GetRecordInterface(con.Count() - 1000);
                                JournalObject obj1 = (JournalObject)rec1.GetDataObject();
                                IDBRecord rec2 = con.GetRecordInterface(con.Count() - 1);
                                JournalObject obj2 = (JournalObject)rec2.GetDataObject();
                                beforeRefID = Math.Min(obj1.refID, obj2.refID).ToString();
                                TimeSpan span = obj2.date.Subtract(obj1.date);
                                if (span.Days >= 7)
                                    remainder = -1; // more than a week, so no more accessable
                            }
                        }
                    }
                } while (0 == remainder && bAutoWalk);
                lastDivisionCount += lastCount;
                if (bAllDivisions)
                    ++division;
                else
                    division = 1007;
            } while (division <= 1006);
            return journal;
        }
    }
}
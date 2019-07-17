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
        public static CharacterJournalCollection GetCharacterJournalList(Database db, EveApiId id,
                                    string CharID, string beforeRefID, bool bAutoWalk)
        {
            return GetCharacterJournalList(db, id, CharID, beforeRefID, bAutoWalk, false);
        }

        public static CharacterJournalCollection GetCharacterJournalList(Database db, EveApiId id,
                                    string CharID, string beforeRefID, bool bAutoWalk, bool bUseCache)
        {
            if (!id.IsFullKey())
                return new CharacterJournalCollection(); // return empty

            CharacterJournalCollection journal = null;
            long remainder = 0;
            long lastCount = 0;
            do
            {
                string url = String.Format("{0}{1}?userID={2}&characterID={3}&apiKey={4}&accountKey=1000",
                                            ApiSite, CharJournalEntries, id.UserId, CharID, id.Key);
                if (null != beforeRefID && 0 < long.Parse(beforeRefID))
                {
                    url += String.Format("&beforeRefID={0}", beforeRefID);
                }

                string str = CheckRequestCache(db, RequestID.CharacterJournal, id.UserId, url);
                if (null == str)
                {
                    Stream s = openUrl(url);
                    if (null == s)
                        return (null != journal) ? journal : (new CharacterJournalCollection());
                    str = new StreamReader(s).ReadToEnd();
                    WriteRequestCache(db, RequestID.CharacterJournal, id.UserId, url, str);
                }
                else if (!bUseCache)
                {
                    break; // not allowed to use caching 
                }

                XmlDocument xmlDoc = GetXml(new StringReader(str));
                if (null == xmlDoc)
                    break;

                if (null == journal)
                    journal = new CharacterJournalCollection(CharID, xmlDoc);
                else
                    journal.AppendList(CharID, xmlDoc);

                if (null == journal)
                    remainder = -1;
                else
                {
                    IDBCollectionContents con = (IDBCollectionContents)journal;
                    if (0 == con.Count())
                        remainder = -1;
                    else if (lastCount == con.Count())
                        remainder = -1;
                    else
                    {
                        lastCount = con.Count();
                        remainder = con.Count() % 1000;
                        if (0 == remainder)
                        {
                            IDBRecord rec1 = con.GetRecordInterface(con.Count() - 1000);
                            JournalObject obj1 = (JournalObject)rec1.GetDataObject();
                            IDBRecord rec2 = con.GetRecordInterface(con.Count() - 1);
                            JournalObject obj2 = (JournalObject)rec2.GetDataObject();
                            beforeRefID = Math.Min(obj1.refID, obj2.refID).ToString();
                            TimeSpan span = (obj2.date > obj1.date) ? obj2.date.Subtract(obj1.date) : 
                                                                      obj1.date.Subtract(obj2.date);
                            if (span.Days >= 7)
                                remainder = -1; // more than a week, so no more accessable
                        }
                    }
                }
            } while (0 == remainder && bAutoWalk);

            if (null == journal)
                return new CharacterJournalCollection(); // create empty
            return journal;
        }

    }
}
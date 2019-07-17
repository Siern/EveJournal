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
        public static CharacterTransactionCollection GetCharacterTransactionList(Database db, EveApiId id,
                            string CharID, string beforeTransId, bool bAutoWalk)
        {
            return GetCharacterTransactionList(db, id, CharID, beforeTransId, bAutoWalk, false);
        }

        public static CharacterTransactionCollection GetCharacterTransactionList(Database db, EveApiId id,
                            string CharID, string beforeTransId, bool bAutoWalk, bool bUseCache)
        {
            if (!id.IsFullKey())
                return new CharacterTransactionCollection(); // return empty

            CharacterTransactionCollection journal = null;
            long remainder = 0;
            long lastCount = 0;
            do
            {
                string url = String.Format("{0}{1}?userID={2}&characterID={3}&apiKey={4}&accountKey=1000",
                                            ApiSite, CharWalletTransactions, id.UserId, CharID, id.Key);
                if (null != beforeTransId && 0 < long.Parse(beforeTransId))
                {
                    url += String.Format("&beforeTransID={0}", beforeTransId);
                }

                string str = CheckRequestCache(db, RequestID.CharacterJournal, id.UserId, url);
                if (null == str)
                {
                    str = new StreamReader(openUrl(url)).ReadToEnd();
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
                    journal = new CharacterTransactionCollection(CharID, xmlDoc);
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
                            TransactionObject obj1 = (TransactionObject)rec1.GetDataObject();
                            IDBRecord rec2 = con.GetRecordInterface(con.Count() - 1);
                            TransactionObject obj2 = (TransactionObject)rec2.GetDataObject();
                            beforeTransId = Math.Min(obj1.transID, obj2.transID).ToString();
                            TimeSpan span = (obj2.date > obj1.date) ? obj2.date.Subtract(obj1.date) : 
                                                                      obj1.date.Subtract(obj2.date);

                            if (span.Days >= 7)
                                remainder = -1; // more than a week, so no more accessable
                        }
                    }
                }
            } while (0 == remainder && bAutoWalk);

            if (null == journal)
                return new CharacterTransactionCollection();
            return journal;
        }
    }
}
/char/MailMessages.xml.aspx
[edit] Overview

Returns the message headers for mail.
[edit] Data Caching

This method is cached according to the Modified Long Cache Style.

    * The first request returns the latest 50 mails/200 notifications received by the character within the last week. Older items are skipped.
    * Subsequent requests return only the new items recieved since the last request.
    * You can request new items every 30 minutes.
    * If you want to re-set the timer and get the first-request bulk again, you'll have to wait 6 hours. 

[edit] Input Arguments
Name 	Type 	Description
apiKey 	char(64) 	Full access API key of account.
characterID 	int 	CharacterID of character for authentication.
userID 	int 	userID of account for authentication.


[edit] Output XML

 
<?xml version='1.0' encoding='UTF-8'?>
<eveapi version="2">
  <currentTime>2009-12-02 00:46:10</currentTime>
  <result>
    <rowset name="mailMessages" key="messageID" columns="messageID,senderID,sentDate,title,toCorpOrAllianceID,toCharacterIDs,toListIDs,read">
      <row messageID="290285276" senderID="999999999" sentDate="2009-12-01 01:04:00" title="Corp mail" toCorpOrAllianceID="999999999" toCharacterIDs="" toListIDs="" read="1" />
      <row messageID="290285275" senderID="999999999" sentDate="2009-12-01 01:04:00" title="Personal mail" toCorpOrAllianceID="" toCharacterIDs="999999999" toListIDs="" read="1" />
      <row messageID="290285274" senderID="999999999" sentDate="2009-12-01 01:04:00" title="Message to mailing list" toCorpOrAllianceID="" toCharacterIDs="" toListIDs="999999999" read="0" />
    </rowset>
  </result>
  <cachedUntil>2009-12-02 01:16:10</cachedUntil>
</eveapi>
 

[edit] Output Rowset Columns
Name 	Type 	Description
messageID 	int 	The unique message ID number.
senderID 	int 	The character ID of the message originator.
sentDate 	date string 	The date the message was sent.
title 	string 	The title of the message
toCorpOrAllianceID 	int 	The ID of a corporation/alliance that the message was sent to.
toCharacterIDs 	string 	Comma-separated list of character IDs of the characters that received the message.
toListIDs 	string 	Comma-separated list of mailing lists that the mail was sent to. Currently you can only send a mail to one list but that might change so we made this a list instead of a single ID. The IDs of lists the character is subscribed to can be resolved using the [mailinglists API].
read 	bool 	Whether the mail/notification has been read in the EVE client. This does not change when you get it through the API. This is a boolean, values will be 0 or 1. 
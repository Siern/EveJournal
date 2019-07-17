/char/mailinglists.xml.aspx
[edit] Overview

Returns an XML document listing all mailing lists the character is currently a member of.
[edit] Data Caching

This method is cached according to the Short Cache Style.
[edit] Input Arguments
Name 	Type 	Description
apiKey 	char(64) 	Full access API key of account.
characterID 	int 	Character you wish to request data from.
userID 	int 	userID of account for authentication.
[edit] Output XML

 
<?xml version='1.0' encoding='UTF-8'?>
<eveapi version="2">
  <currentTime>2009-12-02 06:29:32</currentTime>
  <result>
    <rowset name="mailingLists" key="listID" columns="listID,displayName">
      <row listID="128250439" displayName="EVETycoonMail" />
      <row listID="128783669" displayName="EveMarketScanner" />
      <row listID="141157801" displayName="Exploration Wormholes" />
    </rowset>
  </result>
  <cachedUntil>2009-12-02 12:29:32</cachedUntil>
</eveapi>
 

[edit] Output Rowset Columns
Name 	Type 	Description
listID 	int 	The ID of the mailing list.
displayName 	string 	The name of the mailing list
Retrieved from "http://wiki.eve-id.net/APIv2_Char_mailinglists_XML"


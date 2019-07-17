/char/FacWarStats.xml.aspx
[edit] Overview

If the character is enlisted in Factional Warfare, this will return the faction the character is enlisted in, the current rank and the highest rank the character ever had attained, and how many kills and victory points the character obtained yesterday, in the last week, and total. Otherwise returns an error code.
[edit] Data Caching

This method is cached according to the Modified Short Cache Style. However, the data is only calculated on TQ once a day during downtime. [1]
[edit] Input Arguments
Name 	Type 	Description
apiKey 	char(64) 	limited API key of account.
characterID 	int 	characterID of character whose factional warfare stats you want to retrieve.
userID 	int 	userID of account for authentication.


[edit] Sample

 
<?xml version='1.0' encoding='UTF-8'?>
<eveapi version="2">
  <currentTime>2008-07-10 13:12:49</currentTime>
  <result>
    <factionID>500001</factionID>
    <factionName>Caldari State</factionName>
    <enlisted>2008-06-10 22:10:00</enlisted>
    <currentRank>4</currentRank>
 
    <highestRank>4</highestRank>
    <killsYesterday>0</killsYesterday>
    <killsLastWeek>0</killsLastWeek>
    <killsTotal>0</killsTotal>
    <victoryPointsYesterday>0</victoryPointsYesterday>
    <victoryPointsLastWeek>1044</victoryPointsLastWeek>
 
    <victoryPointsTotal>0</victoryPointsTotal>
  </result>
  <cachedUntil>2008-07-10 14:12:49</cachedUntil>
</eveapi>
 
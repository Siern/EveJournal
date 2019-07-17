/corp/FacWarStats.xml.aspx
[edit] Overview

If the corporation is enlisted in Factional Warfare, this will return the faction the corporation is enlisted in, the current rank and the highest rank the corporation ever had attained, and how many kills and victory points the corporation obtained yesterday, in the last week, and total. Otherwise returns an error code (125).
[edit] Data Caching

This method is cached according to the Modified Short Cache Style. However, the data is only calculated on TQ once a day during downtime. [1]
[edit] Input Arguments
Name 	Type 	Description
apiKey 	char(64) 	limited API key of account.
characterID 	int 	characterID of a character in the corp of which you want to retrieve the factional warfare stats.
userID 	int 	userID of account for authentication.


[edit] Sample

 
<?xml version='1.0' encoding='UTF-8'?>
<eveapi version="2">
  <currentTime>2008-07-10 13:13:28</currentTime>
  <result>
    <factionID>500001</factionID>
    <factionName>Caldari State</factionName>
    <enlisted>2008-06-10 22:10:00</enlisted>
    <pilots>6</pilots>
 
    <killsYesterday>0</killsYesterday>
    <killsLastWeek>0</killsLastWeek>
    <killsTotal>0</killsTotal>
    <victoryPointsYesterday>0</victoryPointsYesterday>
    <victoryPointsLastWeek>1144</victoryPointsLastWeek>
    <victoryPointsTotal>0</victoryPointsTotal>
 
  </result>
  <cachedUntil>2008-07-10 14:13:28</cachedUntil>
</eveapi>

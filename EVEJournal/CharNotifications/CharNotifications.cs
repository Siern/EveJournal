/char/Notifications.xml.aspx
[edit] Overview

Returns the message headers for notifications.
[edit] Data Caching

This method is cached according to the Modified Short Cache Style.

    * The first request returns the latest 200 notifications received by the character within the last week.
    * Subsequent requests return only the new items recieved since the last request.
    * You can request new items every 30 minutes.
    * If you want to re-set the timer and get the first-request bulk again, you'll have to wait 6 hours. 

[edit] Input Arguments
Name 	Type 	Description
apiKey 	char(64) 	Full access API key of account.
characterID 	int 	CharacterID of character for authentication.
userID 	int 	userID of account for authentication.


[edit] Output XML
[edit] Output Rowset Columns
Name 	Type 	Description
notificationID 	int 	The unique notification ID number.
typeID 	int 	The notification type indicates what has happened but not who performed the action in question nor upon whom the action was performed. For a list of type IDs and descriptions, see the appendix below.
senderID 	int 	The ID of the entity that sent the notification.
sentDate 	date string 	The date the notification was sent.
read 	int 	Whether the notification has been read in the EVE client. This does not change when you get it through the API. This is a boolean, values will be 0 or 1.
[edit] Notification Types
State 	Description 		State 	Description


2 	Character deleted 		44 	Sovereignty claim aquired (corporation)
3 	Give medal to character 		45 	Alliance anchoring alert
4 	Alliance maintenance bill 		46 	Alliance structure turns vulnerable
5 	Alliance war declared 		47 	Alliance structure turns invulnerable
6 	Alliance war surrender 		48 	Sovereignty disruptor anchored
7 	Alliance war retracted 		49 	Structure won/lost
8 	Alliance war invalidated by Concord 		50 	Corp office lease expiration notice
9 	Bill issued to a character 		51 	Clone contract revoked by station manager
10 	Bill issued to corporation or alliance 		52 	Corp member clones moved between stations
11 	Bill not paid because there's not enough ISK available 		53 	Clone contract revoked by station manager
12 	Bill, issued by a character, paid 		54 	Insurance contract expired
13 	Bill, issued by a corporation or alliance, paid 		55 	Insurance contract issued
14 	Bounty claimed 		56 	Jump clone destroyed
15 	Clone activated 		57 	Jump clone destroyed
16 	New corp member application 		58 	Corporation joining factional warfare
17 	Corp application rejected 		59 	Corporation leaving factional warfare
18 	Corp application accepted 		60 	Corporation kicked from factional warfare on startup because of too low standing to the faction
19 	Corp tax rate changed 		61 	Character kicked from factional warfare on startup because of too low standing to the faction
20 	Corp news report, typically for shareholders 		62 	Corporation in factional warfare warned on startup because of too low standing to the faction
21 	Player leaves corp 		63 	Character in factional warfare warned on startup because of too low standing to the faction
22 	Corp news, new CEO 		64 	Character loses factional warfare rank
23 	Corp dividend/liquidation, sent to shareholders 		65 	Character gains factional warfare rank
24 	Corp dividend payout, sent to shareholders 		66 	Agent has moved
25 	Corp vote created 		67 	Mass transaction reversal message
26 	Corp CEO votes revoked during voting 		68 	Reimbursement message
27 	Corp declares war 		69 	Agent locates a character
28 	Corp war has started 		70 	Research mission becomes available from an agent
29 	Corp surrenders war 		71 	Agent mission offer expires
30 	Corp retracts war 		72 	Agent mission times out
31 	Corp war invalidated by Concord 		73 	Agent offers a storyline mission
32 	Container password retrieval 		74 	Tutorial message sent on character creation
33 	Contraband or low standings cause an attack or items being confiscated 		75 	Tower alert
34 	First ship insurance 		76 	Tower resource alert
35 	Ship destroyed, insurance payed 		77 	Station aggression message
36 	Insurance contract invalidated/runs out 		78 	Station state change message
37 	Sovereignty claim fails (alliance) 		79 	Station conquered message
38 	Sovereignty claim fails (corporation) 		80 	Station aggression message
39 	Sovereignty bill late (alliance) 		81 	Corporation requests joining factional warfare
40 	Sovereignty bill late (corporation) 		82 	Corporation requests leaving factional warfare
41 	Sovereignty claim lost (alliance) 		83 	Corporation withdrawing a request to join factional warfare
42 	Sovereignty claim lost (corporation) 		84 	Corporation withdrawing a request to leave factional warfare
43 	Sovereignty claim aquired (alliance) 
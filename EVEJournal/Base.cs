
namespace EVEJournal
{
    class ColumnType
    {
        public static readonly string INT = "integer";
        public static readonly string INTKEY = "integer PRIMARY KEY";
        public static readonly string INTnNULL = "integer NOT NULL";
        public static readonly string TXT = "nvarchar(50)";
        public static readonly string TXTKEY = "nvarchar(50) PRIMARY KEY NOT NULL";
        public static readonly string TXTnNULL = "nvarchar(50) NOT NULL";
        public static readonly string DEC = "real";
        public static readonly string DECnNULL = "real NOT NULL";
        public static readonly string DT = "datetime";
        public static readonly string DTnNULL = "datetime NOT NULL";
    }

    class RecordKey
    {
    }

    abstract class DataObject : object
    {
        public abstract RecordKey Key
        {
            get;
        }
    }

    //orderState 	byte 	Valid states: 0 = open/active, 1 = closed, 
    //2 = expired (or fulfilled), 3 = cancelled, 4 = pending, 5 = character deleted.
    public enum OrderState : long
    {
        open = 0,
        closed,
        expired,
        cancelled,
        pending,
        character_deleted
    }

    //range 	short 	The range this order is good for. For sell orders, 
    //this is always 32767. For buy orders, allowed values are: -1 = station, 
    //0 = solar system, 1 = 1 jump, 2 = 2 jumps, ..., 32767 = region.
    public enum MarketRange : long
    {
        Station = -1,
        System,
        Jump_1,
        Jump_2,
        Jump_3,
        Jump_4,
        Jump_5,
        Jump_6,
        Jump_7,
        Jump_8,
        Jump_9,
        Jump_10,
        Jump_11,
        Jump_12,
        Jump_13,
        Jump_14,
        Jump_15,
        Jump_16,
        Jump_17,
        Jump_18,
        Jump_19,
        Jump_20,
        Region = 32767,
    }

    //accountKey 	short 	Which division this order is using as its account. 
    //Always 1000 for characters, but in the range 1000 to 1006 for corporations.
    public enum AccountKey : long
    {
        Character = 1000,
        CorpDivision1 = 1000,
        CorpDivision2,
        CorpDivision3,
        CorpDivision4,
        CorpDivision5,
        CorpDivision6,
        CorpDivision7,
    }
}
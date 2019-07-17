using System;

namespace EVEJournal
{

    class DBConvert
    {
        private object obj;

        public DBConvert(object o)
        {
            obj = o;
        }

        public long ToLong()
        {
            return ToLong(obj);
        }

        public override string ToString()
        {
            return ToString(obj);
        }

        public static long ToLong(object obj)
        {
            if (typeof(long) == obj.GetType())
                return (long)obj;
            if (typeof(string) == obj.GetType())
                return long.Parse((string)obj);
            throw new InvalidCastException();
        }

        public static string ToString(object obj)
        {
            if (typeof(long) == obj.GetType())
                return ((long)obj).ToString();
            if (typeof(int) == obj.GetType())
                return ((int)obj).ToString();
            if (typeof(double) == obj.GetType())
                return ((double)obj).ToString();
            if (typeof(float) == obj.GetType())
                return ((float)obj).ToString();
            if (typeof(decimal) == obj.GetType())
                return ((decimal)obj).ToString();
            if (typeof(DateTime) == obj.GetType())
                return ((DateTime)obj).ToOADate().ToString();
            if (typeof(Boolean) == obj.GetType())
                return ((Boolean)obj) ? "1" : "0";
            if (typeof(string) == obj.GetType())
                return (string)obj;

            try
            {
                long val = (long)obj;
                return val.ToString();
            }
            catch (InvalidCastException)
            {}
            throw new InvalidCastException();
        }

        public static DateTime ToDateTime(object obj)
        {
            if (typeof(DateTime) == obj.GetType())
                return (DateTime)obj;
            if (typeof(long) == obj.GetType())
                return new DateTime((long)obj);
            if (typeof(string) == obj.GetType())
                return DateTime.FromOADate(Double.Parse((string)obj));
            if (typeof(Decimal) == obj.GetType())
                return DateTime.FromOADate((double)((Decimal)obj));
            if (typeof(double) == obj.GetType())
                return DateTime.FromOADate((double)obj);
            throw new InvalidCastException();
        }

        public static Boolean ToBoolean(object obj)
        {
            if (typeof(Boolean) == obj.GetType())
                return (Boolean)obj;
            if (typeof(long) == obj.GetType())
                return (0 != (long)obj) ? true : false;
            if (typeof(string) == obj.GetType())
            {
                Boolean val;
                if (Boolean.TryParse((string)obj, out val))
                    return val;
                return (0 != long.Parse((string)obj)) ? true : false;
            }
            throw new InvalidCastException();
        }

        public static Decimal ToDecimal(object obj)
        {
            if (typeof(long) == obj.GetType())
                return new decimal((long)obj);
            if (typeof(int) == obj.GetType())
                return new decimal((int)obj);
            if (typeof(double) == obj.GetType())
                return new decimal((double)obj);
            if (typeof(float) == obj.GetType())
                return new decimal((float)obj);
            if (typeof(string) == obj.GetType())
                return decimal.Parse((string)obj);
            if (typeof(Decimal) == obj.GetType())
                return (decimal)obj;
            throw new InvalidCastException();
        }

        public static DateTime FromCCPTime(string timeVal)
        {
            // timeUTC  = yyyy-mm-dd hh:mm:ss
            if (timeVal == null || timeVal == "")
                return DateTime.MinValue;

            DateTime dt = new DateTime(
                            Int32.Parse(timeVal.Substring(0, 4)),
                            Int32.Parse(timeVal.Substring(5, 2)),
                            Int32.Parse(timeVal.Substring(8, 2)),
                            Int32.Parse(timeVal.Substring(11, 2)),
                            Int32.Parse(timeVal.Substring(14, 2)),
                            Int32.Parse(timeVal.Substring(17, 2)),
                            0,
                            DateTimeKind.Utc);
            return dt;
        }

        public static string ToDBString(object obj)
        {
            if (typeof(string) == obj.GetType())
                return "\"" + (string)obj + "\"";
            return ToString(obj);
        }


        public static OrderState ToOrderState(object obj)
        {
            return (OrderState)ToLong(obj);
        }

        public static MarketRange ToMarketRange(object obj)
        {
            return (MarketRange)ToLong(obj);
        }

        public static AccountKey ToAccountKey(object obj)
        {
            return (AccountKey)ToLong(obj);
        }
    }

}

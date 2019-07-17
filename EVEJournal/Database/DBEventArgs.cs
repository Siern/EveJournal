using System;
using System.Data.SQLite;

namespace EVEJournal
{
    public delegate void DBEventHandler(object sender, DBEventArgs e);

    public class DBEventArgs : EventArgs
    {
        private IDBRecord m_record;
        private SQLiteDataReader m_reader;

        DBEventArgs(IDBRecord record, SQLiteDataReader reader)
        {
            m_record = record;
            m_reader = reader;
        }

        public double GetDouble(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetDouble(i);
            throw new IndexOutOfRangeException();
        }

        public Decimal GetDecimal(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetDecimal(0);
            throw new IndexOutOfRangeException();
        }

        public Byte GetByte(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetByte(0);
            throw new IndexOutOfRangeException();
        }

        public DateTime GetDateTime(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetDateTime(0);
            throw new IndexOutOfRangeException();
        }

        public Int32 GetInt32(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetInt32(0);
            throw new IndexOutOfRangeException();
        }

        public Int64 GetInt64(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetInt64(0);
            throw new IndexOutOfRangeException();
        }

        public Boolean GetBoolean(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetBoolean(0);
            throw new IndexOutOfRangeException();
        }

        public String GetString(ulong which)
        {
            string str = m_record.TranslateQueryValue(which);
            int i;
            for (i = 0; i < m_reader.FieldCount; ++i)
                if (m_reader.GetName(i).Equals(str))
                    break;

            if (i < m_reader.FieldCount)
                return m_reader.GetString(0);
            throw new IndexOutOfRangeException();
        }

        public object GetValue(ulong which)
        {
            return m_reader[m_record.TranslateQueryValue(which)];
        }

        public object GetValueByIndex(int index)
        {
            if (index < m_reader.FieldCount)
                return m_reader[index];
            throw new IndexOutOfRangeException();
        }

        public int GetColumnCount()
        {
            return m_reader.FieldCount;
        }

        public string GetColumnName(int index)
        {
            if (index < m_reader.FieldCount)
                return m_reader.GetName(index);
            throw new IndexOutOfRangeException();
        }
    }
}
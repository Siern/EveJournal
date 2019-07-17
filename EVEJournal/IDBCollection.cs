
using System.Data.SQLite;

namespace EVEJournal
{
    enum enDBEventHandler
    {
        OnRecordRead,
        OnRecordCollectionAdd,
    }

    interface IDBCollection
    {
        void Clear();
        void FillRecords(SQLiteDataReader reader);
        void SetConstraint(long which, DBConstraint constraint);
        void SetSortConstraint(long which, DBSortConstraint constraint);
        string GetDBQuery();

        void SetEventHandler(enDBEventHandler which, DBEventHandler handler);
        void SetEventOnly(bool EventOnly);
        string GetTableName();
        long GetVersionNumber();

        Database.DatabaseError CreateTable(Database db);
        IDBRecord CreateBlankRecord();
    }

    interface IDBCollectionContents
    {
        long Count();
        IDBRecord GetRecord(RecordKey key);
    }

    interface IDBUpgrade
    {
        Database.DatabaseError Upgrade(Database db, long prevVersion);
    }
}
namespace EVEJournal
{
    //public interface IDBRecord
    //{
    //    object GetDataObject();
    //    ulong GetIDQueryValue();
    //    object GetValueDBFormat(long which);
    //    string GetValueString(ulong which);
    //    void SetValueString(ulong which, object obj);
    //    string TranslateQueryValue(ulong which);
    //    string GetDBCreateTable();
    //    string GetDBInsert();
    //    string GetDBUpdate();
    //}

    //public interface IDBRecord
    //{
    //    string GetFieldName(long which);
    //    object GetDataObject();
    //    long GetIDQueryValue();
    //    string GetValueDBString(long which);
    //    object GetValueDBFormat(long which);
    //    void SetValue(long which, object obj);
    //    string TranslateQueryValue(long which);
    //    string GetDBCreateTable();
    //    string GetDBInsert();
    //    string GetDBUpdate();
    //}

    interface IDBRecord
    {
        string GetFieldName(long which);
        object GetDataObject();
        RecordKey GetRecordKey();
        void SetValue(long which, object obj);
        string GetDBCreateTable();
        string TranslateQueryValue(long which);

        void PrepareCommandInsert(Database.DatabaseCommand dbCommand);
        void FillCommandInsert(Database.DatabaseCommand dbCommand);
        void PrepareCommandUpdate(Database.DatabaseCommand dbCommand);
        void FillCommandUpdate(Database.DatabaseCommand dbCommand);
        void PrepareCommandDelete(Database.DatabaseCommand dbCommand);
        void FillCommandDelete(Database.DatabaseCommand dbCommand);
    }
}
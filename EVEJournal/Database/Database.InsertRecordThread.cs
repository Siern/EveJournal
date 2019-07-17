using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading;


namespace EVEJournal
{
    partial class Database
    {
        //public class InsertRecordThread
        //{
        //    public IDBCollectionContents contents = null;
        //    public ProcessingDlg dlg = null;
        //    public DatabaseError error = DatabaseError.NoError;
        //    public SQLiteCommand sqlite_cmd = null;

        //    public class IRT_EventObj : EventArgs
        //    {
        //        private int m_val;
        //        public IRT_EventObj(int val)
        //        {
        //            m_val = val;
        //        }
        //        public int StepValue
        //        {
        //            get
        //            {
        //                return m_val;
        //            }
        //        }
        //    }

        //    public void ThreadRun()
        //    {
        //        long count = contents.Count();
        //        long j = 0;
        //        dlg.Invoke(dlg.m_DelegateSetEnd, new object[] { (int)count });
        //        dlg.Invoke(dlg.m_DelegateSetStart, new object[] { (int)j });
        //        bool bError = true;

        //        try
        //        {
        //            for (; j < count; ++j)
        //            {
        //                bool bOk = true;
        //                if (null != constraintProvider)
        //                {
        //                    sqlite_cmd.CommandText = constraintProvider.RestrictionQuery(contents.GetRecordInterface(j));
        //                    object obj = sqlite_cmd.ExecuteScalar();
        //                    if (null != obj)
        //                        bOk = false;
        //                }
        //                if (bOk)
        //                {
        //                    try
        //                    {
        //                        sqlite_cmd.CommandText = contents.GetRecordInterface(j).GetDBInsert();
        //                        sqlite_cmd.ExecuteNonQuery();
        //                        dlg.Invoke(dlg.m_DelegateStepIt, new object[] { 1 });
        //                    }
        //                    catch (System.Data.SQLite.SQLiteException e)
        //                    {
        //                        bError = false;
        //                        if (e.ErrorCode == SQLiteErrorCode.Error)
        //                        {
        //                            if (!e.Message.Contains("syntax error"))
        //                                throw e;
        //                            dlg.Invoke(dlg.m_DelegateReport, new object[] { "SQL Syntax Error" });
        //                            dlg.Invoke(dlg.m_DelegateReport, new object[] { e.Message.Clone() });
        //                            dlg.Invoke(dlg.m_DelegateReport, new object[] { sqlite_cmd.CommandText.Clone() });
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    //dlg.Invoke(dlg.m_DelegateReport, new object[] { "Duplicate Entry Skipped." });
        //                    dlg.Invoke(dlg.m_DelegateSkipIt, new object[] { 1 });
        //                }
        //            } 
        //        }
        //        catch (System.Data.SQLite.SQLiteException e)
        //        {
        //            string msg = e.Message;
        //            error = DatabaseError.ExceptionSQL;
        //            dlg.Invoke(dlg.m_DelegateReport, new object[] { "Fatal SQL Error" });
        //            dlg.Invoke(dlg.m_DelegateReport, new object[] { e.Message.Clone() });
        //            dlg.Invoke(dlg.m_DelegateReport, new object[] { sqlite_cmd.CommandText.Clone() });
        //        }

        //        #if (DEBUG)
        //            bError = false; // force pause in debug
        //        #else
        //            dlg.Invoke(dlg.m_DelegateReport, new object[] { "" });
        //            dlg.Invoke(dlg.m_DelegateReport, new object[] { "Errors Detected" });
        //            dlg.Invoke(dlg.m_DelegateReport, new object[] { "Please Report Errors by Right Clicking here!" });
        //            dlg.Invoke(dlg.m_DelegateReport, new object[] { "Compressed version can be emailed to Author!" });
        //        #endif
        //            dlg.Invoke(dlg.m_DelegateDone, new object[] { bError });
        //    }
        //}
    }
}

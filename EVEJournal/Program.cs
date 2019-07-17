using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EVEJournal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #if DEBUG
                AppData.bDEBUG = true;
            #endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            foreach (string arg in Environment.GetCommandLineArgs())
            {
                string prefix = arg.Substring(0, 2).ToUpper();
                if (0 == prefix.CompareTo("-D"))
                {
                    prefix = arg.Substring(2).ToUpper();
                    if ( 0 == prefix.CompareTo(":OFF"))
                        AppData.bDEBUG = false;
                    else
                        AppData.bDEBUG = true;
                    continue;
                }

                if (0 == prefix.CompareTo("-A"))
                {
                    AppData.bAutoFetch = true;
                    if (arg.Length > 2)
                    {
                        int idx = arg.IndexOf(':', 2);
                        if (idx == -1)
                            prefix = arg.Substring(2).ToUpper();
                        else
                            prefix = arg.Substring(2, idx - 2).ToUpper();

                        String[] FetchTypes = prefix.Split(new char[]{','});
                        
                        foreach (string str in FetchTypes)
                        {
                        }

                        prefix = arg.Substring(2 + idx).ToUpper();
                        if (0 == prefix.CompareTo(":Default"))
                            AppData.bFetchOnlyDefault = true;
                    }
                }

                if (0 == prefix.CompareTo("-C"))
                {
                    if (0 == arg.Substring(2, 1).CompareTo(":"))
                        AppData.DefaultChar = int.Parse(arg.Substring(3));
                }

                if (0 == prefix.CompareTo("-?"))
                    AppData.ShowCommandLineDlg();
            }

            Application.Run(new Form1());
        }
    }
}

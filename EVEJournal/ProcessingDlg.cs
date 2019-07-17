using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;

namespace EVEJournal
{
    public delegate void DelegateSetStart(int val);
    public delegate void DelegateSetEnd(int val);
    public delegate void DelegateStepIt(int val);
    public delegate void DelegateSkipIt(int val);
    public delegate void DelegateReport(string txt);
    public delegate void DelegateDone(bool bOk);

    partial class ProcessingDlg : Form
    {
        public DelegateSetStart m_DelegateSetStart = null;
        public DelegateSetEnd m_DelegateSetEnd = null;
        public DelegateStepIt m_DelegateStepIt = null;
        public DelegateSkipIt m_DelegateSkipIt = null;
        public DelegateReport m_DelegateReport = null;
        public DelegateDone m_DelegateDone = null;

        public Thread m_Thread = null;
        private bool m_bThreadStarted = false;
        private Database m_db;
        private int m_nSkiped = 0;

        public ProcessingDlg(Database db)
        {
            InitializeComponent();
            m_db = db;
            m_DelegateSetStart = new DelegateSetStart(this.SetStart);
            m_DelegateSetEnd = new DelegateSetEnd(this.SetEnd);
            m_DelegateStepIt = new DelegateStepIt(this.StepIt);
            m_DelegateSkipIt = new DelegateSkipIt(this.SkipIt);
            m_DelegateReport = new DelegateReport(this.Report);
            m_DelegateDone = new DelegateDone(this.Done);
        }

        public void SetResults(string txt)
        {
            this.listBoxResults.Items.Add(txt);
        }

        public int ProgressStart
        {
            set
            {
                this.progressBar1.Minimum = value;
                this.progressBar1.Value = value;
            }
        }

        public int ProgressEnd
        {
            set
            {
                this.progressBar1.Maximum = value;
            }
        }

        public void Step()
        {
            Step(1);
        }

        public void Step(int val)
        {
            this.progressBar1.Value = this.progressBar1.Value + val;
            UpdateText();
        }

        private void SetStart(int val)
        {
            ProgressStart = val;
        }
        private void SetEnd(int val)
        {
            ProgressEnd = val;
        }
        private void StepIt(int val)
        {
            Step(val);
        }

        private void SkipIt(int val)
        {
            ++m_nSkiped;
            UpdateText();
        }

        private string SkipedText()
        {
            if (0 == m_nSkiped)
                return "";
            return String.Format(" and Skipped {0} of {1}", m_nSkiped, this.progressBar1.Maximum);
        }

        private void UpdateText()
        {
            this.labelProgressText.Text = String.Format("Recorded {0} of {1}{2}",
                this.progressBar1.Value, this.progressBar1.Maximum, this.SkipedText());
        }

        private void Report(string txt)
        {
            this.listBoxResults.Items.Add(txt);
            this.listBoxResults.TopIndex = this.listBoxResults.Items.Count - 1;
        }
        private void Done(bool bOk)
        {
            if (bOk)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                this.buttonExit.Visible = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void listBoxResults_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void listBoxResults_Click(object sender, EventArgs e)
        {
            
        }

        private void listBoxResults_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add(new MenuItem("Export To Clipboard", listBoxResults_CM_Click));
                cm.MenuItems.Add(new MenuItem("Export To Clipboard (Compressed/base64)", listBoxResults_CM_ClickEmail));
                if (this.buttonExit.Visible)
                {
                    cm.MenuItems.Add(new MenuItem("Export API XML", ExportAPIxml));
                    cm.MenuItems.Add(new MenuItem("Export API XML (Compressed/base64)", ExportAPIxmlEmail));
                }
                cm.Show(sender as Control, new Point(e.X, e.Y));
            }
        }

        private void CopyResultsToClipboard(bool bCompress)
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("<ImportErrorList>");
            foreach (string str in this.listBoxResults.Items)
            {
                txt.Append("<ErrorLine>");
                txt.Append(str);
                txt.Append("<\\ErrorLine>\r\n");
            }
            txt.Append("<\\ImportErrorList>");
            if( bCompress )
                Clipboard.SetText(Compression.Compress(txt.ToString()));
            else
                Clipboard.SetText(txt.ToString());
        }

        private void listBoxResults_CM_Click(object sender, System.EventArgs e)
        {
            CopyResultsToClipboard(false);
        }

        private void listBoxResults_CM_ClickEmail(object sender, System.EventArgs e)
        {
            CopyResultsToClipboard(true);
        }

        private void FetchLastAPIxml(bool bCompress)
        {
            SQLiteDataReader reader = null;
            if (Database.DatabaseError.NoError == m_db.ExecuteCommandWithResult("SELECT Response FROM RequestCache WHERE Id=(SELECT max(Id) FROM RequestCache);", ref reader))
            {
                if (bCompress)
                    Clipboard.SetText(reader.GetString(0));
                else
                    Clipboard.SetText(Compression.Decompress(reader.GetString(0)));
            }
        }
        private void ExportAPIxml(object sender, System.EventArgs e)
        {
            FetchLastAPIxml(false);
        }
        private void ExportAPIxmlEmail(object sender, System.EventArgs e)
        {
            FetchLastAPIxml(true);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.BringToFront();

            if (!m_bThreadStarted && null != m_Thread)
            {
                m_bThreadStarted = true;
                m_Thread.Start();
            }
        }
    }
}

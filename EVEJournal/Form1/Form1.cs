using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEJournal
{
    public partial class Form1 : Form
    {
        Database m_db = null;

        public Form1()
        {
            InitializeComponent();

            //if (!AppData.bDEBUG)
            //    this.debugToolStripMenuItem.Visible = false;

            Logger.SetLogger(this.richTextBoxLogging);
            m_db = new Database();
            if (!m_db.IsOpen())
                return;

            CharacterCollection charcol = new CharacterCollection();
            m_db.ReadRecord(charcol);
            IDBCollectionContents col = (IDBCollectionContents)charcol;
            for (long idx = 0; idx < col.Count(); idx++)
            {
                IDBRecord rec = col.GetRecordInterface(idx);
                this.toolStripComboBoxCharacterSelection.Items.Add(rec.GetDataObject());
            }
            if( 0 != this.toolStripComboBoxCharacterSelection.Items.Count )
                this.toolStripComboBoxCharacterSelection.SelectedIndex = 0;

            Logger.ReportNotice("Initializing Reference Types Collection");
            ReferenceTypeCollection refCol = EveApi.GetRefTypesList(m_db, false);
            //m_db.InsertRecord(refCol);
            Logger.ReportNotice("Using BulkLoader");
            refCol.DoBulkLoader(m_db);
            Logger.ReportNotice("Done With BulkLoader");

            AppData.InitConstants(m_db);
            CharJournalInit();
            CharTransactionInit();
            CorpJournalInit();
            CorpTransInit();

            if (AppData.bAutoFetch)
            {

            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterEditorDlg ce = new CharacterEditorDlg(m_db);
            DialogResult result = ce.ShowDialog();
        }

        private void showMasterTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLDump dump = new SQLDump(m_db);
            dump.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            #if DEBUG
            #else
                Logger.ReportNotice("Cleaning old cached results");
                m_db.ExecuteCommand(String.Format("DELETE FROM {0} WHERE ValidUntil < {1};", RequestCache.TableName,
                                    DateTime.Now.ToUniversalTime().ToOADate()));
                // Cleans unused space from the db file.
                Logger.ReportNotice("Removing deleted record space from DB file.");
                m_db.Vacuum();
            #endif
        }

        private void commandLineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppData.ShowCommandLineDlg();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!m_db.IsOpen())
            {
                MessageBox.Show("Database Failed to Open");
                this.Close();
                return;
            }
            AppData.BringCommandLineDlgToFront();
        }

        private void richTextBoxLogging_TextChanged(object sender, EventArgs e)
        {           
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataImportDlg dlg = new DataImportDlg();
            dlg.ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataExportDlg dlg = new DataExportDlg();
            dlg.ShowDialog();
        }

        private void exportSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataExportSelectionDlg dlg = new DataExportSelectionDlg();
            dlg.ShowDialog();
        }
        
    }
}

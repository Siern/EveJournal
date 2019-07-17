using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEJournal
{
    internal partial class SQLDump : Form
    {
        private Database m_db = null;
        private List<IDBCollection> m_tables = new List<IDBCollection>();


        public SQLDump(Database db)
        {
            m_db = db;
            InitializeComponent();
            m_tables.Add((IDBCollection)new DBMasterTableCollection());
            m_tables.Add((IDBCollection)new VersionCollection());
            m_tables.Add((IDBCollection)new RequestCacheCollection());
            m_tables.Add((IDBCollection)new CharacterCollection());
            m_tables.Add((IDBCollection)new CharacterJournalCollection());
            m_tables.Add((IDBCollection)new CharacterTransactionCollection());
            m_tables.Add((IDBCollection)new ReferenceTypeCollection());
            m_tables.Add((IDBCollection)new CharacterOrderCollection());
            m_tables.Add((IDBCollection)new CharacterIndustryJobCollection());
            m_tables.Add((IDBCollection)new CorpWalletNameCollection());
            m_tables.Add((IDBCollection)new CorporationJournalCollection());
            m_tables.Add((IDBCollection)new CorporationMemberTrackingCollection());
            m_tables.Add((IDBCollection)new MemberTrackingSettingsCollection());
        }

        private void SQLDump_Shown(object sender, EventArgs e)
        {
            foreach (IDBCollection col in m_tables)
            {
                this.tabControl1.TabPages.Add(col.GetTableName());
                this.toolStripComboBoxTableList.Items.Add(col);
                TabPage tb = this.tabControl1.TabPages[this.tabControl1.TabPages.Count - 1];
                SetupListView(tb);
                col.SetEventHandler(enDBEventHandler.OnRecordRead, new DBEventHandler(OnRecordRead));
                col.SetEventOnly(true);
                bFirst = true;
                CurLv = (ListView)this.tabControl1.TabPages[this.tabControl1.TabPages.Count - 1].Controls[0];
                this.m_db.ReadRecord(col);
            }
        }

        //TabPage curPage = null;
        bool bFirst;
        ListView CurLv = null;
        private void OnRecordRead(object sender, DBEventArgs e)
        {
            //ListView lv = (ListView)this.tabControl1.TabPages[this.tabControl1.TabPages.Count-1].Controls[0];
            ListView lv = CurLv;
            int n = e.GetColumnCount();
            if (bFirst)
            {
                bFirst = false;
                int width = lv.Size.Width / n;
                for (int i = 0; i < n; ++i)
                    lv.Columns.Add(e.GetColumnName(i), width);
            }
            ListViewItem item = new ListViewItem();
            for (int i = 0; i < n; ++i)
            {
                if (0 == i)
                    item.Text = e.GetValueByIndex(i).ToString();
                else
                {
                    Object obj = e.GetValueByIndex(i);
                    item.SubItems.Add(obj.ToString());
                    //item.SubItems.Add(e.GetValueByIndex(i).ToString());
                }
            }
            lv.Items.Add(item);
        }

        private void SetupListView(TabPage tb)
        {
            ListView lv = new ListView();
            tb.Controls.Add(lv);
            lv.Dock = DockStyle.Fill;
            lv.FullRowSelect = true;
            lv.MultiSelect = false;
            lv.GridLines = true;
            lv.HeaderStyle = ColumnHeaderStyle.Clickable;
            lv.View = View.Details;
            lv.ShowItemToolTips = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.m_db.ExecuteCommand(this.toolStripTextBox1.Text);
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            foreach (IDBCollection col in m_tables)
            {
                foreach (TabPage tb in this.tabControl1.TabPages)
                {
                    if (0 == tb.Text.CompareTo(col.GetTableName()))
                    {
                        ListView lv = tb.Controls[0] as ListView;
                        if (null == lv)
                            break;
                        lv.Items.Clear();
                        lv.Columns.Clear();
                        col.Clear();
                        bFirst = true;
                        CurLv = lv;
                        this.m_db.ReadRecord(col);
                        break;
                    }
                }
            }
        }

        private void toolStripButtonCreateTable_Click(object sender, EventArgs e)
        {
            if (-1 == this.toolStripComboBoxTableList.SelectedIndex)
                return;

            IDBCollection col = this.toolStripComboBoxTableList.SelectedItem as IDBCollection;
            if (null != col)
                col.CreateTable(m_db);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            m_db.TestRead(this.toolStripTextBox1.Text);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            TabPage tb = this.tabControl1.SelectedTab;
            if (null == tb)
                return;

            ListView lv = tb.Controls[0] as ListView;
            Clipboard.SetText(Compression.Decompress(lv.SelectedItems[0].SubItems[4].Text));
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            TabPage tb = this.tabControl1.SelectedTab;
            if (null == tb)
                return;

            ListView lv = tb.Controls[0] as ListView;
            OpenFileDialog dlg = new OpenFileDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                System.IO.FileStream file = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Open);
                System.IO.StreamReader reader = new System.IO.StreamReader(file);
                string injectCode = Compression.Compress(reader.ReadToEnd());
                m_db.ExecuteCommand(string.Format("UPDATE RequestCache SET Response = \"{0}\" WHERE Id={1}", 
                                    injectCode, lv.SelectedItems[0].Text));
                file.Close();
            }

        }
    }
}

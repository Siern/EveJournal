using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEJournal
{
    partial class CorpEditWalletNamesDlg : Form
    {
        public CorpEditWalletNamesDlg()
        {
            InitializeComponent();
        }

        private bool bCanAdd = true;
        private List<string> m_OriginalNames = new List<string>();

        public void SetObject(CorpWalletNameObject obj)
        {
            m_OriginalNames.Clear();
            AddName(obj.Name0);
            AddName(obj.Name1);
            AddName(obj.Name2);
            AddName(obj.Name3);
            AddName(obj.Name4);
            AddName(obj.Name5);
            AddName(obj.Name6);
        }

        public void GetObject(CorpWalletNameObjectWritable obj)
        {
            obj.Name0 = GetName(0);
            obj.Name1 = GetName(1);
            obj.Name2 = GetName(2);
            obj.Name3 = GetName(3);
            obj.Name4 = GetName(4);
            obj.Name5 = GetName(5);
            obj.Name6 = GetName(6);
        }

        public void AddName(string name)
        {
            if (bCanAdd)
                m_OriginalNames.Add(name);
        }

        public string GetName(int idx)
        {
            switch (idx)
            {
                case 0: return this.textBox1.Text;
                case 1: return this.textBox2.Text;
                case 2: return this.textBox3.Text;
                case 3: return this.textBox4.Text;
                case 4: return this.textBox5.Text;
                case 5: return this.textBox6.Text;
                case 6: return this.textBox7.Text;
            }
            throw new IndexOutOfRangeException();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            this.textBox1.Text = m_OriginalNames[0];
            this.textBox2.Text = m_OriginalNames[1];
            this.textBox3.Text = m_OriginalNames[2];
            this.textBox4.Text = m_OriginalNames[3];
            this.textBox5.Text = m_OriginalNames[4];
            this.textBox6.Text = m_OriginalNames[5];
            this.textBox7.Text = m_OriginalNames[6];
        }

        private void CorpEditWalletNames_Shown(object sender, EventArgs e)
        {
            bCanAdd = false;
            LoadList();
        }

    }
}

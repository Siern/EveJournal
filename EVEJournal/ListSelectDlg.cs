using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEJournal
{
    public partial class ListSelectDlg : Form
    {
        public ListSelectDlg()
        {
            InitializeComponent();
        }

        public ListBox List
        {
            get
            {
                return this.listBox1;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if( -1 != e.Index )
            {
                string test = ((CharacterObject)((ListBox)sender).Items[e.Index]).ToString();
                string test2 = e.ToString();
                e.Graphics.DrawString(test, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
            e.DrawFocusRectangle();
        }
    }
}

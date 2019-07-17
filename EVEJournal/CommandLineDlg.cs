using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace EVEJournal
{
    partial class CommandLineDlg : Form
    {
        public CommandLineDlg()
        {
            InitializeComponent();
            this.richTextBox1.Text =
                "" +
                "parts [] in backets are option (brackets are omitted in actual parameter)\n" +
                "\n" +
                "Debug Option: -D[:OFF]\n" +
                "  Forces debug mode on, :OFF causes it to force debug mode off.\n" +
                "\n" +
                "Default Character: -C:####\n" +
                "  Sets the default character, where ### is the character's EVE id number\n" +
                "  (not account number).\n" +
                "\n" +
                "Auto Fetch Data: -A[W,T,CW0,CW1,CW2,CW3,CW4,CW5,CW6,CWA,CT0,CT1,CT2,CT3,CT4,CT5,CT6,CTA][:Default]\n" +
                "  Automatically starts download of new data.\n" +
                "  :Default indicates that only the character defined with -C is auto fetched, otherwise all chars are fetched\n" +
                "  The values after the A are which data elemet to fetch.  If omitted, then all are fetched.\n" +
                "  Definition for fetch types:\n" +
                "    W = Character Wallet\n" +
                "    T = Character Transaction Journal\n" +
                "    CW0-CW6 = Corporation Wallet (with number indicated which wallet)\n" +
                "    CWA = All 7 Corporation Wallets\n" +
                "    CT0-CT6 = Corporation Transaction Journal\n" +
                "    CTA = All 7 Corporation Transaction Journals\n" +
                "";
        }

        private void CommandLineDlg_Resize(object sender, EventArgs e)
        {
        }

        private void PosContents()
        {
            this.richTextBox1.Width = this.ClientSize.Width - 24;
            this.okButton.Left = (this.ClientSize.Width - this.okButton.Width) / 2;
            this.okButton.Top = this.ClientRectangle.Bottom - (this.okButton.Size.Height + 6);
            this.richTextBox1.Height = (this.okButton.Top - 6) - this.richTextBox1.Top;
            //this.Text = this.Location.ToString() + this.ClientSize.ToString() +
            //    "Edit" + this.richTextBox1.Location.ToString() + this.richTextBox1.Size.ToString() +
            //    "OK" + this.okButton.Location.ToString() + this.okButton.Size.ToString();
        }

        private void CommandLineDlg_Layout(object sender, LayoutEventArgs e)
        {
            PosContents();
        }

        private void CommandLineDlg_Shown(object sender, EventArgs e)
        {
            PosContents();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

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
        private void CorpTransInit()
        {
            int idx2 = this.comboBoxCorpTrans.SelectedIndex;

            comboBoxCorpTrans.Items.Clear();
            CorpWalletNameObject wallet = ReadWalletNames() as CorpWalletNameObject;
            comboBoxCorpTrans.Items.Add(new JournalFilterObject("All", (long[])null));
            comboBoxCorpTrans.Items.Add(new JournalFilterObject(wallet.Name0, new long[] { 1000 }));
            comboBoxCorpTrans.Items.Add(new JournalFilterObject(wallet.Name1, new long[] { 1001 }));
            comboBoxCorpTrans.Items.Add(new JournalFilterObject(wallet.Name2, new long[] { 1002 }));
            comboBoxCorpTrans.Items.Add(new JournalFilterObject(wallet.Name3, new long[] { 1003 }));
            comboBoxCorpTrans.Items.Add(new JournalFilterObject(wallet.Name4, new long[] { 1004 }));
            comboBoxCorpTrans.Items.Add(new JournalFilterObject(wallet.Name5, new long[] { 1005 }));
            comboBoxCorpTrans.Items.Add(new JournalFilterObject(wallet.Name6, new long[] { 1006 }));
            if (-1 == idx2)
                idx2 = 0;
            this.comboBoxCorpTrans.SelectedIndex = idx2;
        }

        private void buttonCorpTransFetch_Click(object sender, EventArgs e)
        {

        }

        private void buttonCorpTransFilter_Click(object sender, EventArgs e)
        {

        }
    }
}

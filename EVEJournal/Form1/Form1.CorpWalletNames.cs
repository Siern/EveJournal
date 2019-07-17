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
        private CorpWalletNameObjectWritable CreateDefaultWalletNames()
        {
            CorpWalletNameObjectWritable wallet = new CorpWalletNameObjectWritable();
            wallet.Name0 = "0";
            wallet.Name1 = "1";
            wallet.Name2 = "2";
            wallet.Name3 = "3";
            wallet.Name4 = "4";
            wallet.Name5 = "5";
            wallet.Name6 = "6";
            return wallet;
        }

        private CorpWalletNameObjectWritable ReadWalletNames()
        {
            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return CreateDefaultWalletNames();

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            CorpWalletNameCollection col = new CorpWalletNameCollection();
            IDBCollection icol = col as IDBCollection;
            icol.SetConstraint((long)CorpWalletName.QueryValues.CorpID,
                        new DBConstraint(DBConstraint.QueryConstraints.Equal, charObj.CorpID));

            Database.DatabaseError dbErr = this.m_db.ReadRecord(icol);
            if (dbErr != Database.DatabaseError.NoError &&
                dbErr != Database.DatabaseError.NoRecordsFound
               )
            {
                // should report to logging
                return CreateDefaultWalletNames();
            }

            IDBCollectionContents icolcon = col as IDBCollectionContents;
            if (0 == icolcon.Count())
                return CreateDefaultWalletNames();

            return icolcon.GetRecordInterface(0).GetDataObject() as CorpWalletNameObjectWritable;
        }

        private void toolStripMenuItemCorpEditWalletName_Click(object sender, EventArgs e)
        {
            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;
            CorpWalletNameObjectWritable wallet = ReadWalletNames();

            CorpEditWalletNamesDlg dlg = new CorpEditWalletNamesDlg();
            dlg.SetObject(wallet);
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                dlg.GetObject(wallet);
                CorpWalletNameCollection newCol = new CorpWalletNameCollection();
                newCol.AppendList(false, long.Parse(charObj.CorpID), wallet);
                m_db.InsertOrUpdateRecord(newCol);
            }
        }
    }
}
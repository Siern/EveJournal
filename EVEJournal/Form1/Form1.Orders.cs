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
        private void buttonOrdersFetch_Click(object sender, EventArgs e)
        {
            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            EveApiId id = new EveApiId(charObj.UserID, charObj.FullKey);
            CharacterOrderCollection collection =
                EveApi.GetCharacterOrderList(m_db, id, charObj.CharID, true);
            m_db.InsertRecord(null as ProcessingDlg, collection);
        }

        private void buttonOrdersDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
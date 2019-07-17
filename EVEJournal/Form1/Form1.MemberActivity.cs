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
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        List<CorporationMemberTrackingObject> m_MemberActivityList = new List<CorporationMemberTrackingObject>();
        private void buttonMemberActivityFetch_Click(object sender, EventArgs e)
        {
            m_MemberActivityList.Clear();

            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            EveApiId id = new EveApiId(charObj.UserID.ToString(), charObj.FullKey);
            CorporationMemberTrackingCollection collection =
                EveApi.GetCorporationMemberTrackingList(m_db, id, charObj.CharID, true);

            IDBCollectionContents contents = collection as IDBCollectionContents;
            if (null != contents && 0 != contents.Count())
            {
                for (int idx = 0; idx < contents.Count(); ++idx)
                {
                    CorporationMemberTrackingObject obj = contents.GetRecordInterface(idx).GetDataObject() as CorporationMemberTrackingObject;
                    if( null != obj)
                        m_MemberActivityList.Add(obj);
                }
            }

        }

        private void buttonMemberActivityFromCache_Click(object sender, EventArgs e)
        {

        }

        private void buttonMemberActivitySettings_Click(object sender, EventArgs e)
        {
            MemberActivitySettingsDlg dlg = new MemberActivitySettingsDlg();
            DialogResult ret = dlg.ShowDialog();
        }

        private void comboBoxMemberActivitySort_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

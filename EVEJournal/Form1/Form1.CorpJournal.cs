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

        private void CorpJournalInit()
        {
            int idx = comboBoxCorpJournalFilter.SelectedIndex;

            comboBoxCorpJournalFilter.Items.Clear();
            comboBoxCorpJournalFilter.Items.Add(new JournalFilterObject("None", (long[])null));
            foreach (int key in AppData.ReferenceName.Keys)
            {
                comboBoxCorpJournalFilter.Items.Add(
                    new JournalFilterObject(AppData.ReferenceName[key],
                                            new Int32[] { key }));
            }
            if (-1 == idx)
                idx = 0;
            comboBoxCorpJournalFilter.SelectedIndex = idx;

            int idx2 = comboBoxCorpJournal.SelectedIndex;
            comboBoxCorpJournal.Items.Clear();
            CorpWalletNameObject wallet = ReadWalletNames() as CorpWalletNameObject;
            comboBoxCorpJournal.Items.Add(new JournalFilterObject("All", (long[])null));
            comboBoxCorpJournal.Items.Add(new JournalFilterObject(wallet.Name0, new long[] {1000}));
            comboBoxCorpJournal.Items.Add(new JournalFilterObject(wallet.Name1, new long[] {1001}));
            comboBoxCorpJournal.Items.Add(new JournalFilterObject(wallet.Name2, new long[] {1002}));
            comboBoxCorpJournal.Items.Add(new JournalFilterObject(wallet.Name3, new long[] {1003}));
            comboBoxCorpJournal.Items.Add(new JournalFilterObject(wallet.Name4, new long[] {1004}));
            comboBoxCorpJournal.Items.Add(new JournalFilterObject(wallet.Name5, new long[] {1005}));
            comboBoxCorpJournal.Items.Add(new JournalFilterObject(wallet.Name6, new long[] {1006}));
            if (-1 == idx2)
                idx2 = 0;
            comboBoxCorpJournal.SelectedIndex = idx2;
        }

        private void buttonCorpJournalFetch_Click(object sender, EventArgs e)
        {
            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            EveApiId id = new EveApiId(charObj.UserID, charObj.FullKey);
            CorporationJournalCollection collection =
                EveApi.GetCorporationJournalList(m_db, id, charObj.CharID, charObj.CorpID, null, "1000", true, true, true);
            if (null == collection)
                return;

            Logger.ReportNotice("Using BulkLoader");
            collection.DoBulkLoader(m_db);
            Logger.ReportNotice("Done With BulkLoader");
        }

        private void buttonCorpJournalFilter_Click(object sender, EventArgs e)
        {
            listViewCorpJournal.Items.Clear();

            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            CorporationJournalCollection col = new CorporationJournalCollection();
            IDBCollection icol = col as IDBCollection;
            JournalFilterObject obj = comboBoxCorpJournalFilter.SelectedItem as JournalFilterObject;
            if (null != obj)
            {
                if (1 == obj.Count)
                {
                    icol.SetConstraint((long)CorporationJournal.QueryValues.refType,
                        new DBConstraint(DBConstraint.QueryConstraints.Equal, obj.Value(0)));
                }
                else if (0 != obj.Count)
                    throw new NotImplementedException();
            }

            JournalFilterObject WalletObj = comboBoxCorpJournal.SelectedItem as JournalFilterObject;
            if (null != WalletObj)
            {
                if (1 == WalletObj.Count)
                {
                    icol.SetConstraint((long)CorporationJournal.QueryValues.Division,
                        new DBConstraint(DBConstraint.QueryConstraints.Equal, WalletObj.Value(0)));
                }
                else if (0 != WalletObj.Count)
                    throw new NotImplementedException();
            }

            DateTime start = dateTimePickerCorpJournalStart.Value;
            DateTime end = dateTimePickerCorpJournalEnd.Value;

            if (!checkBoxCorpJournalStartUseTime.Checked)
                start = start.Date;
            if (!checkBoxCorpJournalEndUseTime.Checked)
                end = end.Date.AddDays(1).AddSeconds(-1);

            icol.SetConstraint((long)CorporationJournal.QueryValues.CorpID,
                new DBConstraint(DBConstraint.QueryConstraints.Equal, long.Parse(charObj.CorpID)));
            icol.SetConstraint((long)CorporationJournal.QueryValues.date,
                new DBConstraint(DBConstraint.QueryConstraints.Between,
                                 start.ToOADate(), end.ToOADate()));

            icol.SetSortConstraint((long)CorporationJournal.QueryValues.date,
                                    new DBSortConstraint(DBSortConstraint.SortConstraints.Ascending));

            if (Database.DatabaseError.NoError == this.m_db.ReadRecord(icol))
            {
                IDBCollectionContents icolcon = col as IDBCollectionContents;
                for (long i = 0; i < icolcon.Count(); ++i)
                {
                    listViewCorpJournal.Items.Add(new JournalListViewItem(icolcon.GetRecordInterface(i).GetDataObject() as JournalObject));
                }
            }
        }

        private void listViewCorpJournal_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void listViewCorpJournal_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            e.DrawFocusRectangle();
        }

        private void listViewCorpJournal_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            JournalListViewItem obj = e.Item as JournalListViewItem;
            //e.DrawBackground();
            //e.DrawText();
            switch (e.ColumnIndex)
            {
                case 0: // Date
                    if (null == obj.obj)
                        e.Graphics.DrawString("-- Total -- ", e.Item.Font, new SolidBrush(e.Item.ForeColor), e.Bounds);
                    else
                    {
                        e.Graphics.DrawString(obj.obj.date.ToShortDateString() + " " +
                            obj.obj.date.ToShortTimeString(), e.Item.Font,
                            new SolidBrush(e.Item.ForeColor), e.Bounds,
                            new StringFormat(StringFormatFlags.LineLimit));
                    }
                    break;
                case 1: // ammount
                    {
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Center;
                        format.FormatFlags = StringFormatFlags.NoWrap;
                        e.Graphics.DrawString(String.Format("{0:C}", Math.Abs(obj.obj.amount)),
                            e.Item.Font, new SolidBrush(obj.obj.amount < 0 ? Color.Red : Color.Green), e.Bounds,
                            format);
                    }
                    break;
                case 2: // type
                    {
                        e.Graphics.DrawString(String.Format("[{0:2}] {1}", obj.obj.refType.ToString(),
                                                            AppData.ReferenceName[(int)obj.obj.refType]),
                            e.Item.Font, new SolidBrush(e.Item.ForeColor),
                            e.Bounds, new StringFormat(StringFormatFlags.LineLimit));
                    }
                    break;
                case 3: // Name1
                    {
                        e.Graphics.DrawString(String.Format("{0} [{1}]", obj.obj.ownerName1, obj.obj.ownerID1),
                            e.Item.Font, new SolidBrush(e.Item.ForeColor),
                            e.Bounds, new StringFormat(StringFormatFlags.LineLimit));
                    }
                    break;
                case 4: // Name2
                    {
                        e.Graphics.DrawString(String.Format("{0} [{1}]", obj.obj.ownerName2, obj.obj.ownerID2),
                            e.Item.Font, new SolidBrush(e.Item.ForeColor),
                            e.Bounds, new StringFormat(StringFormatFlags.LineLimit));
                    }
                    break;
                case 5: // Arg1
                    {
                        e.Graphics.DrawString(String.Format("{0} [{1}]", obj.obj.argName1, obj.obj.argID),
                            e.Item.Font, new SolidBrush(e.Item.ForeColor),
                            e.Bounds, new StringFormat(StringFormatFlags.LineLimit));
                    }
                    break;
                case 6: // reason
                    {
                        e.Graphics.DrawString(obj.obj.reason,
                            e.Item.Font, new SolidBrush(e.Item.ForeColor),
                            e.Bounds, new StringFormat(StringFormatFlags.LineLimit));
                    }
                    break;
            }
            e.DrawFocusRectangle(e.Bounds);
        }
    }
}

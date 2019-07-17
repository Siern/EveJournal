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
        class JournalFilterObject
        {
            private string m_Name = "";
            private List<long> m_Values = new List<long>();

            public JournalFilterObject(string Name, Int32[] val)
            {
                m_Name = Name;
                if (null != val)
                {
                    foreach (Int32 i in val)
                        m_Values.Add((long)i);
                }
            }
            public JournalFilterObject(string Name, long[] val)
            {
                m_Name = Name;
                if (null != val)
                {
                    foreach (long i in val)
                        m_Values.Add(i);
                }
            }
            public override string ToString()
            {
                return m_Name;
            }

            public int Count
            {
                get
                {
                    return m_Values.Count;
                }
            }
            public long Value(int idx)
            {
                return m_Values[idx];
            }
        }

        private void CharJournalInit()
        {
            int idx = comboBoxJournalFilter.SelectedIndex;
            comboBoxJournalFilter.Items.Add(new JournalFilterObject("None", (long[])null));

            foreach (int key in AppData.ReferenceName.Keys)
            {
                comboBoxJournalFilter.Items.Add(
                    new JournalFilterObject(AppData.ReferenceName[key], 
                                            new Int32[] { key }));
            }

            if (-1 == idx)
                idx = 0;

            comboBoxJournalFilter.SelectedIndex = idx;
        }
        private void buttonJournalFetch_Click(object sender, EventArgs e)
        {
            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            EveApiId id = new EveApiId(charObj.UserID, charObj.FullKey);
            CharacterJournalCollection collection = 
                EveApi.GetCharacterJournalList(m_db, id, charObj.CharID, null, true, true);
            if (null == collection)
                return;

            Logger.ReportNotice("Using BulkLoader");
            collection.DoBulkLoader(m_db);
            Logger.ReportNotice("Done With BulkLoader");
        }

        class JournalListViewItem : ListViewItem
        {
            public CharacterJournalObject obj = null;
            public JournalListViewItem(CharacterJournalObject o)
                : base(new string[] { "", "", "", "", "", "", "" })
            {
                obj = o;
            }

        }

        private void buttonJournalFilter_Click(object sender, EventArgs e)
        {
            listViewJournal.Items.Clear();

            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;
            
            CharacterJournalCollection col = new CharacterJournalCollection();
            IDBCollection icol = col as IDBCollection;
            JournalFilterObject obj = comboBoxJournalFilter.SelectedItem as JournalFilterObject;
            if (null != obj )
            {
                if (1 == obj.Count)
                {
                    icol.SetConstraint((long)CharacterJournal.QueryValues.refType,
                        new DBConstraint(DBConstraint.QueryConstraints.Equal, obj.Value(0)));
                }
                else if (0 != obj.Count)
                    throw new NotImplementedException();
            }

            DateTime start = dateTimePickerCharJournalStart.Value;
            DateTime end = dateTimePickerCharJournalEnd.Value;

            if( !checkBoxCharJournalStartUseTime.Checked )
                start = start.Date;
            if( !checkBoxCharJournalEndUseTime.Checked )
                end = end.Date.AddDays(1).AddSeconds(-1);

            icol.SetConstraint((long)CharacterJournal.QueryValues.CharID,
                new DBConstraint(DBConstraint.QueryConstraints.Equal, long.Parse(charObj.CharID)));
            icol.SetConstraint((long)CharacterJournal.QueryValues.date,
                new DBConstraint(DBConstraint.QueryConstraints.Between,
                                 start.ToOADate(), end.ToOADate()));

            icol.SetSortConstraint((long)CharacterJournal.QueryValues.date,
                new DBSortConstraint(DBSortConstraint.SortConstraints.Ascending));

            if (Database.DatabaseError.NoError == this.m_db.ReadRecord(icol))
            {
                IDBCollectionContents icolcon = col as IDBCollectionContents;
                for (long i = 0; i < icolcon.Count(); ++i)
                {
                    listViewJournal.Items.Add(new JournalListViewItem(icolcon.GetRecordInterface(i).GetDataObject() as JournalObject));
                }
                //listViewJournal.Items.Add(new JournalListViewItem(null));
            }
        }

        private void listViewJournal_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void listViewJournal_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            e.DrawFocusRectangle();
        }

        private void listViewJournal_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

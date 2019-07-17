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

        class TransactionFilterObject
        {
            private string m_Name = "";
            private List<string> m_Values = new List<string>();

            public TransactionFilterObject(string Name, string[] val)
            {
                m_Name = Name;
                if (null != val)
                {
                    foreach (string i in val)
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
            public string Value(int idx)
            {
                return m_Values[idx];
            }
        }

        private void CharTransactionInit()
        {
            comboBoxTransactionFilter.Items.Add(new TransactionFilterObject("None", null));
            comboBoxTransactionFilter.Items.Add(new TransactionFilterObject("Purchases", new string[] { "buy" }));
            comboBoxTransactionFilter.Items.Add(new TransactionFilterObject("Sales", new string[] { "sell" }));
            comboBoxTransactionFilter.SelectedIndex = 0;
        }

        private void buttonTransactionFetch_Click(object sender, EventArgs e)
        {
            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            EveApiId id = new EveApiId(charObj.UserID, charObj.FullKey);
            CharacterTransactionCollection collection =
                EveApi.GetCharacterTransactionList(m_db, id, charObj.CharID, null, true);

            if (null == collection)
                return;

            Logger.ReportNotice("Using BulkLoader");
            collection.DoBulkLoader(m_db);
            Logger.ReportNotice("Done With BulkLoader");
        }

        class TransactionListViewItem : ListViewItem
        {
            public CharacterTransactionObject obj = null;
            public TransactionListViewItem(CharacterTransactionObject o)
                : base(new string[] { "", "", "", "", "", "", "" })
            {
                obj = o;
            }

        }

        private void buttonTransactionFilter_Click(object sender, EventArgs e)
        {
            this.listViewTransactions.Items.Clear();

            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            CharacterObject charObj = (CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            CharacterTransactionCollection col = new CharacterTransactionCollection();
            IDBCollection icol = col as IDBCollection;
            TransactionFilterObject obj = comboBoxTransactionFilter.SelectedItem as TransactionFilterObject;
            if (null != obj)
            {
                if (1 == obj.Count)
                {
                    icol.SetConstraint((long)CharacterTransaction.QueryValues.transactionType,
                        new DBConstraint(DBConstraint.QueryConstraints.Equal, obj.Value(0)));
                }
                else if (0 != obj.Count)
                    throw new NotImplementedException();
            }

            DateTime start = dateTimePickerCharTransactionStart.Value;
            DateTime end = dateTimePickerCharTransactionEnd.Value;

            if (!checkBoxCharTransactionStartUseTime.Checked)
                start = start.Date;
            if (!checkBoxCharTransactionEndUseTime.Checked)
                end = end.Date.AddDays(1).AddSeconds(-1);

            icol.SetConstraint((long)CharacterTransaction.QueryValues.CharID,
                new DBConstraint(DBConstraint.QueryConstraints.Equal, long.Parse(charObj.CharID)));
            icol.SetConstraint((long)CharacterTransaction.QueryValues.date,
                new DBConstraint(DBConstraint.QueryConstraints.Between,
                                    start.ToOADate(), end.ToOADate()));

            icol.SetSortConstraint((long)CharacterTransaction.QueryValues.date,
                new DBSortConstraint(DBSortConstraint.SortConstraints.Ascending));

            if (Database.DatabaseError.NoError == this.m_db.ReadRecord(icol))
            {
                IDBCollectionContents icolcon = col as IDBCollectionContents;
                for (long i = 0; i < icolcon.Count(); ++i)
                {
                    listViewTransactions.Items.Add(new TransactionListViewItem(icolcon.GetRecordInterface(i).GetDataObject() as TransactionObject));
                }
            }
        }

        private void listViewTransactions_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void listViewTransactions_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            e.DrawFocusRectangle();
        }

        private void listViewTransactions_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TransactionListViewItem obj = e.Item as TransactionListViewItem;
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Graphics.DrawString(obj.obj.date.ToShortDateString() + " " +
                            obj.obj.date.ToShortTimeString(), e.Item.Font,
                            new SolidBrush(e.Item.ForeColor), e.Bounds,
                            new StringFormat(StringFormatFlags.LineLimit));
                    break;
                case 1:
                    e.Graphics.DrawString(String.Format("{0} [{1}]", obj.obj.typeName, obj.obj.typeID),
                        e.Item.Font, new SolidBrush(e.Item.ForeColor), e.Bounds,
                        new StringFormat(StringFormatFlags.LineLimit));
                    break;
                case 2:
                    {
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Center;
                        format.FormatFlags = StringFormatFlags.NoWrap;
                        e.Graphics.DrawString(String.Format("{0:C}", Math.Abs(obj.obj.price)),
                            e.Item.Font, new SolidBrush(e.Item.ForeColor),
                            e.Bounds, format);
                    }
                    break;
                case 3:
                    {
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Center;
                        format.FormatFlags = StringFormatFlags.NoWrap;
                        e.Graphics.DrawString(obj.obj.quantity.ToString(),
                            e.Item.Font, new SolidBrush(e.Item.ForeColor), e.Bounds,
                            format);
                    }
                    break;
                case 4:
                    {
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Center;
                        format.FormatFlags = StringFormatFlags.NoWrap;
                        e.Graphics.DrawString(String.Format("{0:C}", Math.Abs(obj.obj.price*obj.obj.quantity)),
                            e.Item.Font, new SolidBrush(obj.obj.transactionType.CompareTo("buy") == 0 ? Color.Red : Color.Green),
                            e.Bounds, format);
                    }
                    break;
                case 5:
                        e.Graphics.DrawString(String.Format("{0} [{1}]", obj.obj.clientName, obj.obj.clientID),
                            e.Item.Font, new SolidBrush(e.Item.ForeColor), e.Bounds,
                            new StringFormat(StringFormatFlags.LineLimit));
                    break;
                case 6:
                    e.Graphics.DrawString(String.Format("{0} [{1}]", obj.obj.stationName, obj.obj.stationID),
                        e.Item.Font, new SolidBrush(e.Item.ForeColor), e.Bounds,
                        new StringFormat(StringFormatFlags.LineLimit));
                    break;
            }
        }
    }
}

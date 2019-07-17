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
        decimal CorpMissionerTotal = 0;
        long CorpMissionerRuns = 0;
        class CorpMissionerPerson
        {
            public long id = 0;
            public string Name = "";
            public long Runs = 0;
            public decimal Total = 0;
        }
        List<CorpMissionerPerson> CorpMissionerPeople = new List<CorpMissionerPerson>();

        private void InsertMissionerRecord(CharacterJournalObject obj, int typ)
        {
            if (null == obj)
                return;

            foreach (CorpMissionerPerson person in CorpMissionerPeople)
            {
                if (person.id == obj.ownerID2)
                {
                    if (typ == 33)
                    {
                        ++person.Runs;
                        ++CorpMissionerRuns;
                    }
                    person.Total += obj.amount;
                    CorpMissionerTotal += obj.amount;
                    return;
                }
            }

            // new Person for the list
            CorpMissionerPerson newPerson = new CorpMissionerPerson();
            newPerson.id = obj.ownerID2;
            newPerson.Name = obj.ownerName2;
            if (typ == 33)
            {
                ++newPerson.Runs;
                ++CorpMissionerRuns;
            }
            newPerson.Total += obj.amount;
            CorpMissionerTotal += obj.amount;
            CorpMissionerPeople.Add(newPerson);
            return;
        }

        private void buttonCorpMissioner_Click(object sender, EventArgs e)
        {
            CorpMissionerTotal = 0;
            CorpMissionerRuns = 0;
            CorpMissionerPeople.Clear();

            if (-1 == this.toolStripComboBoxCharacterSelection.SelectedIndex)
                return;

            Character.CharacterObject charObj = (Character.CharacterObject)
                this.toolStripComboBoxCharacterSelection.SelectedItem;

            DateTime start = dateTimePickerCorpMissionerStart.Value;
            DateTime end = dateTimePickerCorpMissionerEnd.Value;

            start = start.Date;
            end = end.Date.AddDays(1).AddSeconds(-1);

            int[] types = {33,34,85};
            foreach (int typ in types)
            {
                CorporationJournalCollection col = new CorporationJournalCollection();
                IDBCollection icol = col as IDBCollection;
                icol.SetConstraint((long)CorporationJournal.QueryValues.CorpID,
                            new DBConstraint(DBConstraint.QueryConstraints.Equal, charObj.CorpID));
                icol.SetConstraint((long)CorporationJournal.QueryValues.Division,
                            new DBConstraint(DBConstraint.QueryConstraints.Equal, 1000));
                // set date range
                icol.SetConstraint((long)CorporationJournal.QueryValues.date,
                    new DBConstraint(DBConstraint.QueryConstraints.Between,
                                     start.ToOADate(), end.ToOADate()));
                // set Sorting
                icol.SetSortConstraint((long)CorporationJournal.QueryValues.ownerName2,
                    new DBSortConstraint(DBSortConstraint.SortConstraints.Ascending));

                // do Agent Rewards
                icol.SetConstraint((long)CorporationJournal.QueryValues.refType,
                            new DBConstraint(DBConstraint.QueryConstraints.Equal, typ));
                if (Database.DatabaseError.NoError == m_db.ReadRecord(icol))
                {
                    IDBCollectionContents icolcon = col as IDBCollectionContents;
                    for (long i = 0; i < icolcon.Count(); ++i)
                    {
                        InsertMissionerRecord(icolcon.GetRecordInterface(i).GetDataObject() as JournalObject, typ);
                    }
                }
            }

            CorpMissionerPeople.Sort(delegate(CorpMissionerPerson p1, CorpMissionerPerson p2) { return p2.Total.CompareTo(p1.Total); });
            this.listViewCorpMissioner.Items.Clear();
            foreach (CorpMissionerPerson person in CorpMissionerPeople)
            {
                ListViewItem item = new ListViewItem();
                item.Text = person.Name;
                item.SubItems.Add(person.Runs.ToString());
                item.SubItems.Add(string.Format("{0:#,##0.00;(#,##0.00);''}", person.Total));
                this.listViewCorpMissioner.Items.Add(item);
            }

            ListViewItem itemTotal = new ListViewItem();
            itemTotal.Text = "Total";
            itemTotal.SubItems.Add(CorpMissionerRuns.ToString());
            itemTotal.SubItems.Add(string.Format("{0:#,##0.00;(#,##0.00);''}",CorpMissionerTotal));
            this.listViewCorpMissioner.Items.Add(itemTotal);
        }

        private void buttonCorpMissionerGenReport_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table width=\"500\" cellspacing=\"1\" cellpadding=\"1\" border=\"1\">");
            DateTime dtStart = this.dateTimePickerCorpMissionerStart.Value;
            DateTime dtEnd = this.dateTimePickerCorpMissionerEnd.Value;
            str.AppendFormat("<caption>Corp Missioning For {0} to {1}</caption>", dtStart.ToShortDateString(), dtEnd.ToShortDateString());
            str.Append("<tbody>");
            str.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Name", "# Missions", "ISK");
            foreach(CorpMissionerPerson person in CorpMissionerPeople)
                str.AppendFormat("<tr><td>{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td></tr>", 
                    person.Name, person.Runs.ToString(), 
                    string.Format("{0:#,##0.00;(#,##0.00);''}", person.Total));
            str.AppendFormat("<tr></tr>");
            str.AppendFormat("<tfoot bgcolor=\"#cccccc\"><tr><td>{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td></tr></tfoot>", "Total", 
                CorpMissionerRuns.ToString(), 
                string.Format("{0:#,##0.00;(#,##0.00);''}", CorpMissionerTotal));
            str.Append("</tbody></table>");

            str.Append("<table width=\"500\" cellspacing=\"1\" cellpadding=\"1\" border=\"1\">");
            str.Append("<caption>Payouts</caption>");
            str.Append("<tbody>");
            str.AppendFormat("<tr><td>{0}</td><td>{1}</td></tr>", "Name", "ISK");
            if (CorpMissionerPeople.Count > 0)
                str.AppendFormat("<tr><td>{0}</td><td align=\"right\">{1}</td></tr>", CorpMissionerPeople[0].Name,
                    string.Format("{0:#,##0.00;(#,##0.00);''}", (CorpMissionerTotal * (decimal)0.15)));
            if (CorpMissionerPeople.Count > 1)
                str.AppendFormat("<tr><td>{0}</td><td align=\"right\">{1}</td></tr>", CorpMissionerPeople[1].Name,
                    string.Format("{0:#,##0.00;(#,##0.00);''}", (CorpMissionerTotal * (decimal)0.10)));
            if (CorpMissionerPeople.Count > 2)
                str.AppendFormat("<tr><td>{0}</td><td align=\"right\">{1}</td></tr>", CorpMissionerPeople[2].Name,
                    string.Format("{0:#,##0.00;(#,##0.00);''}", (CorpMissionerTotal * (decimal)0.05)));
            str.Append("</tbody></table>");
            Clipboard.SetText(str.ToString());
        }
    }
}
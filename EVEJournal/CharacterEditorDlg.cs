using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace EVEJournal
{
    internal partial class CharacterEditorDlg : Form
    {
        private Database m_db = null;
        private CharacterObject m_SelectedObject = null;

        public CharacterEditorDlg(Database db)
        {
            if (null == db)
                throw new NullReferenceException();
            m_db = db;
            InitializeComponent();
        }

        private void CharacterEditor_Load(object sender, EventArgs e)
        {
            CharacterCollection charcol = new CharacterCollection();
            m_db.ReadRecord(charcol);
            IDBCollectionContents col = (IDBCollectionContents)charcol;
            for (long idx = 0; idx < col.Count(); idx++)
            {
                IDBRecord rec = col.GetRecordInterface(idx);
                this.listBoxCharacters.Items.Add(rec.GetDataObject());
            }
        }

        private void buttonSelectCharacter_Click(object sender, EventArgs e)
        {
            if (0 == this.textBoxUserID.Text.Length ||
                (0 == this.textBoxLimitedKey.Text.Length && 0 == this.textBoxFullKey.Text.Length)
              )
            {
                MessageBox.Show("You must enter a UserID, and a Key before selecting a character.");
                return;
            }
            EveApiId id = new EveApiId(this.textBoxUserID.Text,
                            (0 != textBoxFullKey.Text.Length) ? textBoxFullKey.Text : textBoxLimitedKey.Text);
            CharacterCollection col = EveApi.GetCharacterList(m_db, id);
            IDBCollectionContents con = (IDBCollectionContents)col;
            if (1 > con.Count())
                return;

            ListSelectDlg ls = new ListSelectDlg();
            for (int i = 0; i < con.Count(); ++i)
            {
                IDBRecord rec = con.GetRecordInterface(i);
                rec.SetValueString((ulong)Character.QueryValues.UserID, this.textBoxUserID.Text);
                rec.SetValueString((ulong)Character.QueryValues.LimitedKey, this.textBoxLimitedKey.Text);
                rec.SetValueString((ulong)Character.QueryValues.FullKey, this.textBoxFullKey.Text);
                rec.SetValueString((ulong)Character.QueryValues.RegCode, this.textBoxRegCode.Text);
                CharacterObject obj = (CharacterObject)rec.GetDataObject();
                string test = obj.ToString();
                ls.List.Items.Add(obj);
            }
            
            Button btn = (Button)sender;
            ls.Location = this.PointToScreen(new Point(btn.Location.X, btn.Location.Y + btn.Height));
            DialogResult ret = ls.ShowDialog();
            if (DialogResult.OK == ret)
            {
                CharacterObject newObj = (CharacterObject)ls.List.SelectedItem;
                foreach (CharacterObject obj in this.listBoxCharacters.Items)
                {
                    if (0 == obj.ToString().CompareTo(newObj.ToString()))
                    {
                        this.listBoxCharacters.SelectedItem = obj;
                        this.textBoxLimitedKey.Text = this.textBoxLimitedKey.Text;
                        this.textBoxFullKey.Text = this.textBoxFullKey.Text;
                        return;
                    }
                }
                this.listBoxCharacters.SelectedIndex = -1;
                m_SelectedObject = newObj;
                FillFromNewCharacter();
            }
        }

        private void FillFromNewCharacter()
        {
            this.textBoxUserName.Text = m_SelectedObject.CharName;
            this.textBoxUserID.Text = m_SelectedObject.UserID.ToString();
            this.textBoxLimitedKey.Text = m_SelectedObject.LimitedKey;
            this.textBoxFullKey.Text = m_SelectedObject.FullKey;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (0 == this.textBoxUserID.Text.Length ||
                (0 == this.textBoxLimitedKey.Text.Length && 0 == this.textBoxFullKey.Text.Length) ||
                0 == this.textBoxUserName.Text.Length
              )
            {
                MessageBox.Show("You must enter a UserID, a Limited or Full Key, and select a character.");
                return;
            }

            if (-1 != this.listBoxCharacters.SelectedIndex)
            { // update
                Character ch = new Character((CharacterObject)this.listBoxCharacters.SelectedItem);
                IDBRecord rec = (IDBRecord)ch;
                rec.SetValueString((ulong)Character.QueryValues.UserID, this.textBoxUserID.Text);
                rec.SetValueString((ulong)Character.QueryValues.LimitedKey, this.textBoxLimitedKey.Text);
                rec.SetValueString((ulong)Character.QueryValues.FullKey, this.textBoxFullKey.Text);
                rec.SetValueString((ulong)Character.QueryValues.RegCode, this.textBoxRegCode.Text);
                this.m_db.UpdateRecord(ch);
            }
            else if( null != this.m_SelectedObject )
            { // insert new
                Character ch = new Character(this.m_SelectedObject);
                IDBRecord rec = (IDBRecord)ch;
                rec.SetValueString((ulong)Character.QueryValues.UserID, this.textBoxUserID.Text);
                rec.SetValueString((ulong)Character.QueryValues.LimitedKey, this.textBoxLimitedKey.Text);
                rec.SetValueString((ulong)Character.QueryValues.FullKey, this.textBoxFullKey.Text);
                rec.SetValueString((ulong)Character.QueryValues.RegCode, this.textBoxRegCode.Text);
                this.m_db.InsertRecord(ch);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (-1 == lb.SelectedIndex)
                return;
            DialogResult result = 
            MessageBox.Show("Warning! Removing a character will delete all " +
                            " data currently stored that is bound to this " +
                            "character.\n Continue and delete data?",  
                            "Deleting all Character Data", 
                            MessageBoxButtons.YesNo);

            if (DialogResult.Yes == result)
            {
                int idx = lb.SelectedIndex;
                lb.Items.RemoveAt(idx);
                if (0 != lb.Items.Count)
                {
                    if (0 != idx)
                        --idx;
                    lb.SelectedIndex = idx;
                }
                else
                    lb.SelectedIndex = -1;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start(this.label5.Text);
        }

        private void listBoxCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (-1 == lb.SelectedIndex)
            {
                this.textBoxUserName.Text = "";
                this.textBoxUserID.Text = "";
                this.textBoxLimitedKey.Text = "";
                this.textBoxFullKey.Text = "";
                this.textBoxRegCode.Text = "";
            }
            else
            {
                CharacterObject obj = (CharacterObject)lb.SelectedItem;
                this.textBoxUserName.Text = obj.CharName;
                this.textBoxUserID.Text = obj.UserID.ToString();
                this.textBoxLimitedKey.Text = obj.LimitedKey;
                this.textBoxFullKey.Text = obj.FullKey;
                this.textBoxRegCode.Text = obj.RegCode;
            }
            
        }
    }
}

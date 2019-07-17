namespace EVEJournal
{
    partial class CharacterEditorDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCharacters = new System.Windows.Forms.ListBox();
            this.buttonSelectCharacter = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLimitedKey = new System.Windows.Forms.TextBox();
            this.textBoxFullKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRegCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxCharacters
            // 
            this.listBoxCharacters.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxCharacters.FormattingEnabled = true;
            this.listBoxCharacters.Location = new System.Drawing.Point(0, 0);
            this.listBoxCharacters.Name = "listBoxCharacters";
            this.listBoxCharacters.Size = new System.Drawing.Size(330, 199);
            this.listBoxCharacters.TabIndex = 0;
            this.listBoxCharacters.SelectedIndexChanged += new System.EventHandler(this.listBoxCharacters_SelectedIndexChanged);
            // 
            // buttonSelectCharacter
            // 
            this.buttonSelectCharacter.Location = new System.Drawing.Point(12, 231);
            this.buttonSelectCharacter.Name = "buttonSelectCharacter";
            this.buttonSelectCharacter.Size = new System.Drawing.Size(66, 23);
            this.buttonSelectCharacter.TabIndex = 1;
            this.buttonSelectCharacter.Text = "Select ...";
            this.buttonSelectCharacter.UseVisualStyleBackColor = true;
            this.buttonSelectCharacter.Click += new System.EventHandler(this.buttonSelectCharacter_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(84, 234);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(234, 20);
            this.textBoxUserName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "UserID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(84, 260);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(234, 20);
            this.textBoxUserID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Limited Key";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLimitedKey
            // 
            this.textBoxLimitedKey.Location = new System.Drawing.Point(84, 286);
            this.textBoxLimitedKey.Name = "textBoxLimitedKey";
            this.textBoxLimitedKey.Size = new System.Drawing.Size(234, 20);
            this.textBoxLimitedKey.TabIndex = 6;
            // 
            // textBoxFullKey
            // 
            this.textBoxFullKey.Location = new System.Drawing.Point(84, 312);
            this.textBoxFullKey.Name = "textBoxFullKey";
            this.textBoxFullKey.Size = new System.Drawing.Size(234, 20);
            this.textBoxFullKey.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Full Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(12, 366);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(93, 366);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(243, 366);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Get Your Key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(81, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "http://myeve.eve-online.com/api/default.asp";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Reg. Code";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Visible = false;
            // 
            // textBoxRegCode
            // 
            this.textBoxRegCode.Enabled = false;
            this.textBoxRegCode.Location = new System.Drawing.Point(84, 338);
            this.textBoxRegCode.Name = "textBoxRegCode";
            this.textBoxRegCode.Size = new System.Drawing.Size(234, 20);
            this.textBoxRegCode.TabIndex = 15;
            // 
            // CharacterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 395);
            this.Controls.Add(this.textBoxRegCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFullKey);
            this.Controls.Add(this.textBoxLimitedKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonSelectCharacter);
            this.Controls.Add(this.listBoxCharacters);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CharacterEditor";
            this.ShowInTaskbar = false;
            this.Text = "CharacterEditor";
            this.Load += new System.EventHandler(this.CharacterEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCharacters;
        private System.Windows.Forms.Button buttonSelectCharacter;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLimitedKey;
        private System.Windows.Forms.TextBox textBoxFullKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRegCode;
    }
}
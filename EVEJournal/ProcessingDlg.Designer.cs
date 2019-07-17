namespace EVEJournal
{
    partial class ProcessingDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgressText = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Querying EVE API..";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please Wait A Moment As Some Request May Take Some Time.";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 129);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(399, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // labelProgressText
            // 
            this.labelProgressText.Location = new System.Drawing.Point(12, 155);
            this.labelProgressText.Name = "labelProgressText";
            this.labelProgressText.Size = new System.Drawing.Size(399, 20);
            this.labelProgressText.TabIndex = 4;
            this.labelProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(176, 129);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Visible = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.HorizontalScrollbar = true;
            this.listBoxResults.Location = new System.Drawing.Point(12, 44);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxResults.Size = new System.Drawing.Size(399, 82);
            this.listBoxResults.TabIndex = 6;
            this.listBoxResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxResults_MouseClick);
            this.listBoxResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxResults_MouseDown);
            this.listBoxResults.Click += new System.EventHandler(this.listBoxResults_Click);
            // 
            // ProcessingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 180);
            this.ControlBox = false;
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelProgressText);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessingDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Processing Request...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgressText;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox listBoxResults;
    }
}
namespace RadioClient
{
    partial class RecordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordForm));
            this.gbNavigation = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPausePlay = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rcRecorder = new RadioClient.Recorder();
            this.sfdSaveAs = new System.Windows.Forms.SaveFileDialog();
            this.gbNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNavigation
            // 
            this.gbNavigation.Controls.Add(this.btnStop);
            this.gbNavigation.Controls.Add(this.btnPausePlay);
            this.gbNavigation.Controls.Add(this.btnRecord);
            this.gbNavigation.Location = new System.Drawing.Point(12, 377);
            this.gbNavigation.Name = "gbNavigation";
            this.gbNavigation.Size = new System.Drawing.Size(366, 100);
            this.gbNavigation.TabIndex = 5;
            this.gbNavigation.TabStop = false;
            this.gbNavigation.Text = "Řízení";
            // 
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(151, 24);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 64);
            this.btnStop.TabIndex = 0;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPausePlay
            // 
            this.btnPausePlay.Enabled = false;
            this.btnPausePlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPausePlay.Image")));
            this.btnPausePlay.Location = new System.Drawing.Point(276, 24);
            this.btnPausePlay.Name = "btnPausePlay";
            this.btnPausePlay.Size = new System.Drawing.Size(64, 64);
            this.btnPausePlay.TabIndex = 0;
            this.btnPausePlay.UseVisualStyleBackColor = true;
            this.btnPausePlay.Click += new System.EventHandler(this.btnPausePlay_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Image = global::RadioClient.Properties.Resources.record;
            this.btnRecord.Location = new System.Drawing.Point(26, 24);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(64, 64);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(12, 501);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(103, 32);
            this.btnSaveAs.TabIndex = 7;
            this.btnSaveAs.Text = "Uložit jako...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(275, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zavřít";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rcRecorder
            // 
            this.rcRecorder.FillColor = System.Drawing.Color.Black;
            this.rcRecorder.FrontColor = System.Drawing.Color.Lime;
            this.rcRecorder.InputBufferMilisec = -1;
            this.rcRecorder.Location = new System.Drawing.Point(12, 12);
            this.rcRecorder.Name = "rcRecorder";
            this.rcRecorder.Size = new System.Drawing.Size(366, 359);
            this.rcRecorder.TabIndex = 8;
            // 
            // sfdSaveAs
            // 
            this.sfdSaveAs.DefaultExt = "*.wav";
            this.sfdSaveAs.Filter = "Zvukové soubory *.wav|*.wav";
            this.sfdSaveAs.Title = "Uložit hlášení jako";
            // 
            // RecordForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(390, 545);
            this.Controls.Add(this.rcRecorder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.gbNavigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nahrát hlášení";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecordForm_FormClosed);
            this.Load += new System.EventHandler(this.RecordForm_Load);
            this.gbNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbNavigation;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPausePlay;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnClose;
        private Recorder rcRecorder;
        private System.Windows.Forms.SaveFileDialog sfdSaveAs;
    }
}

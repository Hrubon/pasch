namespace RadioClient
{
    partial class BroadcastForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BroadcastForm));
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDuration = new System.Windows.Forms.Label();
            this.dtpDuration = new System.Windows.Forms.DateTimePicker();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.rbLiveBroadcast = new System.Windows.Forms.RadioButton();
            this.rbFromFile = new System.Windows.Forms.RadioButton();
            this.rbRecordNew = new System.Windows.Forms.RadioButton();
            this.gbTargetDateTime = new System.Windows.Forms.GroupBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbStartDateTime = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.ofdBrowseAudioFile = new System.Windows.Forms.OpenFileDialog();
            this.tlCalendar = new RadioClient.TimeLine();
            this.gbSource.SuspendLayout();
            this.gbTargetDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.label1);
            this.gbSource.Controls.Add(this.lbDuration);
            this.gbSource.Controls.Add(this.dtpDuration);
            this.gbSource.Controls.Add(this.btnRecord);
            this.gbSource.Controls.Add(this.btnBrowse);
            this.gbSource.Controls.Add(this.txtFilePath);
            this.gbSource.Controls.Add(this.rbLiveBroadcast);
            this.gbSource.Controls.Add(this.rbFromFile);
            this.gbSource.Controls.Add(this.rbRecordNew);
            this.gbSource.Location = new System.Drawing.Point(11, 12);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(670, 139);
            this.gbSource.TabIndex = 1;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Zdroj hlášení";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "(mm:ss)";
            // 
            // lbDuration
            // 
            this.lbDuration.AutoSize = true;
            this.lbDuration.Location = new System.Drawing.Point(193, 94);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(76, 13);
            this.lbDuration.TabIndex = 10;
            this.lbDuration.Text = "Délka hlášení:";
            // 
            // dtpDuration
            // 
            this.dtpDuration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDuration.CustomFormat = "mm:ss";
            this.dtpDuration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDuration.Location = new System.Drawing.Point(272, 92);
            this.dtpDuration.Name = "dtpDuration";
            this.dtpDuration.ShowUpDown = true;
            this.dtpDuration.Size = new System.Drawing.Size(85, 20);
            this.dtpDuration.TabIndex = 9;
            this.dtpDuration.Value = new System.DateTime(1753, 1, 1, 0, 1, 0, 0);
            // 
            // btnRecord
            // 
            this.btnRecord.Enabled = false;
            this.btnRecord.Location = new System.Drawing.Point(196, 31);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(85, 24);
            this.btnRecord.TabIndex = 8;
            this.btnRecord.Text = "Nahrát";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(577, 64);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(79, 21);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Procházet...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(196, 65);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(375, 20);
            this.txtFilePath.TabIndex = 4;
            // 
            // rbLiveBroadcast
            // 
            this.rbLiveBroadcast.AutoSize = true;
            this.rbLiveBroadcast.Enabled = false;
            this.rbLiveBroadcast.Location = new System.Drawing.Point(27, 92);
            this.rbLiveBroadcast.Name = "rbLiveBroadcast";
            this.rbLiveBroadcast.Size = new System.Drawing.Size(146, 17);
            this.rbLiveBroadcast.TabIndex = 2;
            this.rbLiveBroadcast.Text = "Rezervace - živé hlášení:";
            this.rbLiveBroadcast.UseVisualStyleBackColor = true;
            this.rbLiveBroadcast.CheckedChanged += new System.EventHandler(this.rbLiveBroadcast_CheckedChanged);
            // 
            // rbFromFile
            // 
            this.rbFromFile.AutoSize = true;
            this.rbFromFile.Enabled = false;
            this.rbFromFile.Location = new System.Drawing.Point(26, 64);
            this.rbFromFile.Name = "rbFromFile";
            this.rbFromFile.Size = new System.Drawing.Size(82, 17);
            this.rbFromFile.TabIndex = 1;
            this.rbFromFile.Text = "Ze souboru:";
            this.rbFromFile.UseVisualStyleBackColor = true;
            this.rbFromFile.CheckedChanged += new System.EventHandler(this.rbFromFile_CheckedChanged);
            // 
            // rbRecordNew
            // 
            this.rbRecordNew.AutoSize = true;
            this.rbRecordNew.Checked = true;
            this.rbRecordNew.Enabled = false;
            this.rbRecordNew.Location = new System.Drawing.Point(26, 35);
            this.rbRecordNew.Name = "rbRecordNew";
            this.rbRecordNew.Size = new System.Drawing.Size(125, 17);
            this.rbRecordNew.TabIndex = 0;
            this.rbRecordNew.TabStop = true;
            this.rbRecordNew.Text = "Nahrát nové hlášení:";
            this.rbRecordNew.UseVisualStyleBackColor = true;
            this.rbRecordNew.CheckedChanged += new System.EventHandler(this.rbRecordNew_CheckedChanged);
            // 
            // gbTargetDateTime
            // 
            this.gbTargetDateTime.Controls.Add(this.lbDescription);
            this.gbTargetDateTime.Controls.Add(this.lbStartDateTime);
            this.gbTargetDateTime.Controls.Add(this.txtDescription);
            this.gbTargetDateTime.Controls.Add(this.dtpDate);
            this.gbTargetDateTime.Controls.Add(this.dtpTime);
            this.gbTargetDateTime.Location = new System.Drawing.Point(12, 157);
            this.gbTargetDateTime.Name = "gbTargetDateTime";
            this.gbTargetDateTime.Size = new System.Drawing.Size(669, 72);
            this.gbTargetDateTime.TabIndex = 3;
            this.gbTargetDateTime.TabStop = false;
            this.gbTargetDateTime.Text = "Parametry plánovaného hlášení";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(30, 35);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(36, 13);
            this.lbDescription.TabIndex = 8;
            this.lbDescription.Text = "Popis:";
            // 
            // lbStartDateTime
            // 
            this.lbStartDateTime.AutoSize = true;
            this.lbStartDateTime.Location = new System.Drawing.Point(268, 35);
            this.lbStartDateTime.Name = "lbStartDateTime";
            this.lbStartDateTime.Size = new System.Drawing.Size(113, 13);
            this.lbStartDateTime.TabIndex = 7;
            this.lbStartDateTime.Text = "Čas a datum spuštění:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(72, 32);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(190, 20);
            this.txtDescription.TabIndex = 6;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Location = new System.Drawing.Point(387, 32);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(151, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // dtpTime
            // 
            this.dtpTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTime.CustomFormat = "HH:mm:ss";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(544, 32);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(85, 20);
            this.dtpTime.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(575, 494);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Zrušit";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(463, 494);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(106, 36);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ofdBrowseAudioFile
            // 
            this.ofdBrowseAudioFile.Filter = "Zvukové soubory formátu MP3|*.mp3";
            this.ofdBrowseAudioFile.Title = "Vyberte soubor zvukového záznamu hlášení:";
            // 
            // tlCalendar
            // 
            this.tlCalendar.BodyBackColor = System.Drawing.Color.Transparent;
            this.tlCalendar.ContentFont = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tlCalendar.ContentFontColor = System.Drawing.Color.White;
            this.tlCalendar.ContentOffset = 10;
            this.tlCalendar.DrawLines = true;
            this.tlCalendar.HeaderBackColor = System.Drawing.Color.Transparent;
            this.tlCalendar.LabelFontColor = System.Drawing.Color.Black;
            this.tlCalendar.LabelsCount = 4;
            this.tlCalendar.LabelsFont = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tlCalendar.LabelsOffset = 0;
            this.tlCalendar.LinesColor = System.Drawing.Color.Black;
            this.tlCalendar.Location = new System.Drawing.Point(12, 235);
            this.tlCalendar.MinutesInterval = 2;
            this.tlCalendar.Name = "tlCalendar";
            this.tlCalendar.ReadOnly = false;
            this.tlCalendar.SelectedTask = null;
            this.tlCalendar.SelectedTaskAlpha = 255;
            this.tlCalendar.SelectedTaskColor = System.Drawing.Color.Red;
            this.tlCalendar.Size = new System.Drawing.Size(669, 248);
            this.tlCalendar.StartTime = new System.DateTime(2015, 8, 8, 20, 44, 58, 127);
            this.tlCalendar.TabIndex = 1;
            this.tlCalendar.TaskAlpha = 128;
            this.tlCalendar.TaskColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // BroadcastForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(693, 542);
            this.Controls.Add(this.tlCalendar);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbTargetDateTime);
            this.Controls.Add(this.gbSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BroadcastForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Naplánovat hlášení";
            this.Load += new System.EventHandler(this.CalendarForm_Load);
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.gbTargetDateTime.ResumeLayout(false);
            this.gbTargetDateTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.RadioButton rbLiveBroadcast;
        private System.Windows.Forms.RadioButton rbFromFile;
        private System.Windows.Forms.RadioButton rbRecordNew;
        private System.Windows.Forms.GroupBox gbTargetDateTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbStartDateTime;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.OpenFileDialog ofdBrowseAudioFile;
        private System.Windows.Forms.Label lbDuration;
        private System.Windows.Forms.DateTimePicker dtpDuration;
        private System.Windows.Forms.Label label1;
        private TimeLine tlCalendar;
    }
}
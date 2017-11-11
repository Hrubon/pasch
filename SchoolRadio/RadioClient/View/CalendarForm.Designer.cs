namespace RadioClient
{
    partial class CalendarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarForm));
            this.gbTargetDateTime = new System.Windows.Forms.GroupBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbStartDateTime = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.ofdBrowseAudioFile = new System.Windows.Forms.OpenFileDialog();
            this.btnDeleteBroadcast = new System.Windows.Forms.Button();
            this.tlCalendar = new RadioClient.TimeLine();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbTargetDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTargetDateTime
            // 
            this.gbTargetDateTime.Controls.Add(this.lbDescription);
            this.gbTargetDateTime.Controls.Add(this.lbStartDateTime);
            this.gbTargetDateTime.Controls.Add(this.txtDescription);
            this.gbTargetDateTime.Controls.Add(this.dtpDate);
            this.gbTargetDateTime.Controls.Add(this.dtpTime);
            this.gbTargetDateTime.Location = new System.Drawing.Point(12, 12);
            this.gbTargetDateTime.Name = "gbTargetDateTime";
            this.gbTargetDateTime.Size = new System.Drawing.Size(669, 72);
            this.gbTargetDateTime.TabIndex = 3;
            this.gbTargetDateTime.TabStop = false;
            this.gbTargetDateTime.Text = "Parametry plánovaného hlášení";
            this.gbTargetDateTime.Visible = false;
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
            // ofdBrowseAudioFile
            // 
            this.ofdBrowseAudioFile.Filter = "Zvukové soubory formátu MP3|*.mp3";
            this.ofdBrowseAudioFile.Title = "Vyberte soubor zvukového záznamu hlášení:";
            // 
            // btnDeleteBroadcast
            // 
            this.btnDeleteBroadcast.Enabled = false;
            this.btnDeleteBroadcast.Image = global::RadioClient.Properties.Resources.delete;
            this.btnDeleteBroadcast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteBroadcast.Location = new System.Drawing.Point(12, 347);
            this.btnDeleteBroadcast.Name = "btnDeleteBroadcast";
            this.btnDeleteBroadcast.Size = new System.Drawing.Size(149, 49);
            this.btnDeleteBroadcast.TabIndex = 5;
            this.btnDeleteBroadcast.Text = "Odstranit hlášení";
            this.btnDeleteBroadcast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteBroadcast.UseVisualStyleBackColor = true;
            this.btnDeleteBroadcast.Visible = false;
            this.btnDeleteBroadcast.Click += new System.EventHandler(this.btnDeleteBroadcast_Click);
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
            this.tlCalendar.Location = new System.Drawing.Point(12, 90);
            this.tlCalendar.MinutesInterval = 2;
            this.tlCalendar.Name = "tlCalendar";
            this.tlCalendar.ReadOnly = true;
            this.tlCalendar.SelectedTask = null;
            this.tlCalendar.SelectedTaskAlpha = 255;
            this.tlCalendar.SelectedTaskColor = System.Drawing.Color.Red;
            this.tlCalendar.Size = new System.Drawing.Size(669, 248);
            this.tlCalendar.StartTime = new System.DateTime(2015, 8, 8, 20, 44, 58, 127);
            this.tlCalendar.TabIndex = 1;
            this.tlCalendar.TaskAlpha = 128;
            this.tlCalendar.TaskColor = System.Drawing.Color.DeepSkyBlue;
            this.tlCalendar.SelectionChanged += new RadioClient.TimeLine.SelectionChangedEventHandler(this.tlCalendar_SelectionChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::RadioClient.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(167, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 49);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Přeplánovat hlášení";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(532, 347);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 49);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zavřít";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(693, 408);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tlCalendar);
            this.Controls.Add(this.btnDeleteBroadcast);
            this.Controls.Add(this.gbTargetDateTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendarForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Procházet hlášení";
            this.Load += new System.EventHandler(this.CalendarForm_Load);
            this.gbTargetDateTime.ResumeLayout(false);
            this.gbTargetDateTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbTargetDateTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbStartDateTime;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.OpenFileDialog ofdBrowseAudioFile;
        private System.Windows.Forms.Button btnDeleteBroadcast;
        private TimeLine tlCalendar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}
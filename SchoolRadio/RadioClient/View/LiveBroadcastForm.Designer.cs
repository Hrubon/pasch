namespace RadioClient
{
    partial class LiveBroadcastForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveBroadcastForm));
            this.gbNavigation = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rcRecorder = new RadioClient.Recorder();
            this.gbNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNavigation
            // 
            this.gbNavigation.Controls.Add(this.btnStop);
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
            this.btnStop.Location = new System.Drawing.Point(263, 24);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 64);
            this.btnStop.TabIndex = 0;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
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
            // LiveBroadcastForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(390, 545);
            this.Controls.Add(this.rcRecorder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbNavigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LiveBroadcastForm";
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
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnClose;
        private Recorder rcRecorder;
    }
}

namespace RadioClient
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbOrganizer = new System.Windows.Forms.GroupBox();
            this.btnPlanBroadcast = new System.Windows.Forms.Button();
            this.btnShowCalendar = new System.Windows.Forms.Button();
            this.btnRecordBroadcast = new System.Windows.Forms.Button();
            this.gbLiveBroadcast = new System.Windows.Forms.GroupBox();
            this.btnLiveBroadcast = new System.Windows.Forms.Button();
            this.gbOrganizer.SuspendLayout();
            this.gbLiveBroadcast.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOrganizer
            // 
            this.gbOrganizer.Controls.Add(this.btnPlanBroadcast);
            this.gbOrganizer.Controls.Add(this.btnShowCalendar);
            this.gbOrganizer.Controls.Add(this.btnRecordBroadcast);
            this.gbOrganizer.Location = new System.Drawing.Point(12, 12);
            this.gbOrganizer.Name = "gbOrganizer";
            this.gbOrganizer.Size = new System.Drawing.Size(353, 135);
            this.gbOrganizer.TabIndex = 0;
            this.gbOrganizer.TabStop = false;
            this.gbOrganizer.Text = "Naplánovaná hlášení";
            // 
            // btnPlanBroadcast
            // 
            this.btnPlanBroadcast.Image = global::RadioClient.Properties.Resources.add;
            this.btnPlanBroadcast.Location = new System.Drawing.Point(113, 33);
            this.btnPlanBroadcast.Name = "btnPlanBroadcast";
            this.btnPlanBroadcast.Size = new System.Drawing.Size(80, 80);
            this.btnPlanBroadcast.TabIndex = 0;
            this.btnPlanBroadcast.Text = "Naplánovat";
            this.btnPlanBroadcast.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlanBroadcast.UseVisualStyleBackColor = true;
            this.btnPlanBroadcast.Click += new System.EventHandler(this.btnPlanBroadcast_Click);
            // 
            // btnShowCalendar
            // 
            this.btnShowCalendar.Image = global::RadioClient.Properties.Resources.calendar;
            this.btnShowCalendar.Location = new System.Drawing.Point(211, 33);
            this.btnShowCalendar.Name = "btnShowCalendar";
            this.btnShowCalendar.Size = new System.Drawing.Size(127, 80);
            this.btnShowCalendar.TabIndex = 0;
            this.btnShowCalendar.Text = "Zobrazit kalendář";
            this.btnShowCalendar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnShowCalendar.UseVisualStyleBackColor = true;
            this.btnShowCalendar.Click += new System.EventHandler(this.btnShowCalendar_Click);
            // 
            // btnRecordBroadcast
            // 
            this.btnRecordBroadcast.Image = global::RadioClient.Properties.Resources.record;
            this.btnRecordBroadcast.Location = new System.Drawing.Point(17, 33);
            this.btnRecordBroadcast.Name = "btnRecordBroadcast";
            this.btnRecordBroadcast.Size = new System.Drawing.Size(80, 80);
            this.btnRecordBroadcast.TabIndex = 0;
            this.btnRecordBroadcast.Text = "Nahrát nové";
            this.btnRecordBroadcast.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecordBroadcast.UseVisualStyleBackColor = true;
            this.btnRecordBroadcast.Click += new System.EventHandler(this.btnRecordBroadcast_Click);
            // 
            // gbLiveBroadcast
            // 
            this.gbLiveBroadcast.Controls.Add(this.btnLiveBroadcast);
            this.gbLiveBroadcast.Location = new System.Drawing.Point(371, 12);
            this.gbLiveBroadcast.Name = "gbLiveBroadcast";
            this.gbLiveBroadcast.Size = new System.Drawing.Size(117, 135);
            this.gbLiveBroadcast.TabIndex = 3;
            this.gbLiveBroadcast.TabStop = false;
            this.gbLiveBroadcast.Text = "Živá hlášení";
            // 
            // btnLiveBroadcast
            // 
            this.btnLiveBroadcast.Image = global::RadioClient.Properties.Resources.microphone;
            this.btnLiveBroadcast.Location = new System.Drawing.Point(20, 33);
            this.btnLiveBroadcast.Name = "btnLiveBroadcast";
            this.btnLiveBroadcast.Size = new System.Drawing.Size(79, 80);
            this.btnLiveBroadcast.TabIndex = 2;
            this.btnLiveBroadcast.Text = "Hlásit";
            this.btnLiveBroadcast.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLiveBroadcast.UseVisualStyleBackColor = true;
            this.btnLiveBroadcast.Click += new System.EventHandler(this.btnLiveBroadcast_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 164);
            this.Controls.Add(this.gbLiveBroadcast);
            this.Controls.Add(this.gbOrganizer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Školní rozhlas";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbOrganizer.ResumeLayout(false);
            this.gbLiveBroadcast.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrganizer;
        private System.Windows.Forms.Button btnPlanBroadcast;
        private System.Windows.Forms.Button btnShowCalendar;
        private System.Windows.Forms.Button btnRecordBroadcast;
        private System.Windows.Forms.Button btnLiveBroadcast;
        private System.Windows.Forms.GroupBox gbLiveBroadcast;
    }
}
namespace RadioClient
{
    partial class Recorder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recorder));
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.tbTime = new RadioClient.TimeBanner();
            this.gbLevels = new System.Windows.Forms.GroupBox();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.chbFeedback = new System.Windows.Forms.CheckBox();
            this.lbVolume = new System.Windows.Forms.Label();
            this.vmLevel = new NAudio.Gui.VolumeMeter();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.cbInput = new System.Windows.Forms.ComboBox();
            this.gbWaveform = new System.Windows.Forms.GroupBox();
            this.wfpLevel = new NAudio.Gui.WaveformPainter();
            this.gbTime.SuspendLayout();
            this.gbLevels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.gbInput.SuspendLayout();
            this.gbWaveform.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.tbTime);
            this.gbTime.Location = new System.Drawing.Point(3, 179);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(363, 75);
            this.gbTime.TabIndex = 9;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "Čas";
            // 
            // tbTime
            // 
            this.tbTime.BackColor = System.Drawing.Color.Black;
            this.tbTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbTime.BackgroundImage")));
            this.tbTime.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTime.ForeColor = System.Drawing.Color.Red;
            this.tbTime.Location = new System.Drawing.Point(44, 19);
            this.tbTime.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbTime.Name = "tbTime";
            this.tbTime.NAString = "--";
            this.tbTime.Size = new System.Drawing.Size(277, 45);
            this.tbTime.Splitter = ':';
            this.tbTime.Step = 100;
            this.tbTime.TabIndex = 0;
            // 
            // gbLevels
            // 
            this.gbLevels.Controls.Add(this.tbVolume);
            this.gbLevels.Controls.Add(this.chbFeedback);
            this.gbLevels.Controls.Add(this.lbVolume);
            this.gbLevels.Controls.Add(this.vmLevel);
            this.gbLevels.Location = new System.Drawing.Point(3, 91);
            this.gbLevels.Name = "gbLevels";
            this.gbLevels.Size = new System.Drawing.Size(363, 82);
            this.gbLevels.TabIndex = 8;
            this.gbLevels.TabStop = false;
            this.gbLevels.Text = "Úrovně";
            // 
            // tbVolume
            // 
            this.tbVolume.LargeChange = 10;
            this.tbVolume.Location = new System.Drawing.Point(230, 32);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(130, 45);
            this.tbVolume.SmallChange = 5;
            this.tbVolume.TabIndex = 1;
            this.tbVolume.TickFrequency = 10;
            this.tbVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbVolume.Value = 75;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            // 
            // chbFeedback
            // 
            this.chbFeedback.AutoSize = true;
            this.chbFeedback.Location = new System.Drawing.Point(17, 19);
            this.chbFeedback.Name = "chbFeedback";
            this.chbFeedback.Size = new System.Drawing.Size(77, 17);
            this.chbFeedback.TabIndex = 5;
            this.chbFeedback.Text = "Odposlech";
            this.chbFeedback.UseVisualStyleBackColor = true;
            this.chbFeedback.CheckedChanged += new System.EventHandler(this.chbFeedback_CheckedChanged);
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(227, 16);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(50, 13);
            this.lbVolume.TabIndex = 4;
            this.lbVolume.Text = "Hlasitost:";
            // 
            // vmLevel
            // 
            this.vmLevel.Amplitude = 0F;
            this.vmLevel.ForeColor = System.Drawing.Color.OrangeRed;
            this.vmLevel.Location = new System.Drawing.Point(17, 41);
            this.vmLevel.MaxDb = 18F;
            this.vmLevel.MinDb = -60F;
            this.vmLevel.Name = "vmLevel";
            this.vmLevel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.vmLevel.Size = new System.Drawing.Size(207, 23);
            this.vmLevel.TabIndex = 2;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.cbInput);
            this.gbInput.Location = new System.Drawing.Point(3, 3);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(363, 82);
            this.gbInput.TabIndex = 7;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Vstupní zařízení";
            // 
            // cbInput
            // 
            this.cbInput.FormattingEnabled = true;
            this.cbInput.Location = new System.Drawing.Point(6, 33);
            this.cbInput.Name = "cbInput";
            this.cbInput.Size = new System.Drawing.Size(351, 21);
            this.cbInput.TabIndex = 0;
            this.cbInput.SelectedIndexChanged += new System.EventHandler(this.cbInput_SelectedIndexChanged);
            // 
            // gbWaveform
            // 
            this.gbWaveform.Controls.Add(this.wfpLevel);
            this.gbWaveform.Location = new System.Drawing.Point(3, 260);
            this.gbWaveform.Name = "gbWaveform";
            this.gbWaveform.Size = new System.Drawing.Size(363, 97);
            this.gbWaveform.TabIndex = 10;
            this.gbWaveform.TabStop = false;
            this.gbWaveform.Text = "Stopa";
            // 
            // wfpLevel
            // 
            this.wfpLevel.BackColor = System.Drawing.Color.Black;
            this.wfpLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wfpLevel.Location = new System.Drawing.Point(3, 16);
            this.wfpLevel.Name = "wfpLevel";
            this.wfpLevel.Size = new System.Drawing.Size(357, 78);
            this.wfpLevel.TabIndex = 0;
            // 
            // Recorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbWaveform);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.gbLevels);
            this.Controls.Add(this.gbInput);
            this.Name = "Recorder";
            this.Size = new System.Drawing.Size(372, 363);
            this.Load += new System.EventHandler(this.Recorder_Load);
            this.gbTime.ResumeLayout(false);
            this.gbLevels.ResumeLayout(false);
            this.gbLevels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbWaveform.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.GroupBox gbLevels;
        private System.Windows.Forms.Label lbVolume;
        private NAudio.Gui.VolumeMeter vmLevel;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.ComboBox cbInput;
        private System.Windows.Forms.CheckBox chbFeedback;
        private System.Windows.Forms.TrackBar tbVolume;
        private TimeBanner tbTime;
        private System.Windows.Forms.GroupBox gbWaveform;
        private NAudio.Gui.WaveformPainter wfpLevel;
    }
}

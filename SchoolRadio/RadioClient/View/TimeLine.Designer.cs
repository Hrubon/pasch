namespace RadioClient
{
    partial class TimeLine
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
            this.gbDateTimeSelection = new System.Windows.Forms.GroupBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnMinus10Minutes = new System.Windows.Forms.Button();
            this.btnMinus1Hour = new System.Windows.Forms.Button();
            this.tlpButtonsLeft = new System.Windows.Forms.TableLayoutPanel();
            this.btnMinus1Day = new System.Windows.Forms.Button();
            this.tlpButtonsRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnPlus10Minutes = new System.Windows.Forms.Button();
            this.btnPlus1Hour = new System.Windows.Forms.Button();
            this.btnPlus1Day = new System.Windows.Forms.Button();
            this.pnlLabels = new System.Windows.Forms.Panel();
            this.pnlTimeLine = new System.Windows.Forms.Panel();
            this.gbDateTimeSelection.SuspendLayout();
            this.tlpButtonsLeft.SuspendLayout();
            this.tlpButtonsRight.SuspendLayout();
            this.pnlTimeLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDateTimeSelection
            // 
            this.gbDateTimeSelection.Controls.Add(this.btnGoto);
            this.gbDateTimeSelection.Controls.Add(this.dtpDate);
            this.gbDateTimeSelection.Controls.Add(this.dtpTime);
            this.gbDateTimeSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDateTimeSelection.Location = new System.Drawing.Point(0, 0);
            this.gbDateTimeSelection.Name = "gbDateTimeSelection";
            this.gbDateTimeSelection.Size = new System.Drawing.Size(640, 64);
            this.gbDateTimeSelection.TabIndex = 3;
            this.gbDateTimeSelection.TabStop = false;
            this.gbDateTimeSelection.Text = "Přejít na zvolené datum a čas:";
            // 
            // btnGoto
            // 
            this.btnGoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGoto.Location = new System.Drawing.Point(409, 26);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(85, 24);
            this.btnGoto.TabIndex = 2;
            this.btnGoto.Text = "Přejít";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Location = new System.Drawing.Point(159, 28);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(151, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // dtpTime
            // 
            this.dtpTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTime.CustomFormat = "HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(316, 28);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(85, 20);
            this.dtpTime.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(482, 132);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlContent_MouseClick);
            // 
            // btnMinus10Minutes
            // 
            this.btnMinus10Minutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinus10Minutes.Location = new System.Drawing.Point(3, 3);
            this.btnMinus10Minutes.Name = "btnMinus10Minutes";
            this.btnMinus10Minutes.Size = new System.Drawing.Size(72, 52);
            this.btnMinus10Minutes.TabIndex = 3;
            this.btnMinus10Minutes.Text = "< 10 minut";
            this.btnMinus10Minutes.UseVisualStyleBackColor = true;
            this.btnMinus10Minutes.Click += new System.EventHandler(this.btnMinus10Minutes_Click);
            // 
            // btnMinus1Hour
            // 
            this.btnMinus1Hour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinus1Hour.Location = new System.Drawing.Point(3, 61);
            this.btnMinus1Hour.Name = "btnMinus1Hour";
            this.btnMinus1Hour.Size = new System.Drawing.Size(72, 52);
            this.btnMinus1Hour.TabIndex = 5;
            this.btnMinus1Hour.Text = "< 1 hodina";
            this.btnMinus1Hour.UseVisualStyleBackColor = true;
            this.btnMinus1Hour.Click += new System.EventHandler(this.btnMinus1Hour_Click);
            // 
            // tlpButtonsLeft
            // 
            this.tlpButtonsLeft.ColumnCount = 1;
            this.tlpButtonsLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonsLeft.Controls.Add(this.btnMinus10Minutes, 0, 0);
            this.tlpButtonsLeft.Controls.Add(this.btnMinus1Hour, 0, 1);
            this.tlpButtonsLeft.Controls.Add(this.btnMinus1Day, 0, 2);
            this.tlpButtonsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpButtonsLeft.Location = new System.Drawing.Point(0, 64);
            this.tlpButtonsLeft.Name = "tlpButtonsLeft";
            this.tlpButtonsLeft.RowCount = 3;
            this.tlpButtonsLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtonsLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtonsLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtonsLeft.Size = new System.Drawing.Size(78, 176);
            this.tlpButtonsLeft.TabIndex = 6;
            // 
            // btnMinus1Day
            // 
            this.btnMinus1Day.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinus1Day.Location = new System.Drawing.Point(3, 119);
            this.btnMinus1Day.Name = "btnMinus1Day";
            this.btnMinus1Day.Size = new System.Drawing.Size(72, 54);
            this.btnMinus1Day.TabIndex = 7;
            this.btnMinus1Day.Text = "< 1 den";
            this.btnMinus1Day.UseVisualStyleBackColor = true;
            this.btnMinus1Day.Click += new System.EventHandler(this.btnMinus1Day_Click);
            // 
            // tlpButtonsRight
            // 
            this.tlpButtonsRight.ColumnCount = 1;
            this.tlpButtonsRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonsRight.Controls.Add(this.btnPlus10Minutes, 0, 0);
            this.tlpButtonsRight.Controls.Add(this.btnPlus1Hour, 0, 1);
            this.tlpButtonsRight.Controls.Add(this.btnPlus1Day, 0, 2);
            this.tlpButtonsRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpButtonsRight.Location = new System.Drawing.Point(562, 64);
            this.tlpButtonsRight.Name = "tlpButtonsRight";
            this.tlpButtonsRight.RowCount = 3;
            this.tlpButtonsRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtonsRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtonsRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtonsRight.Size = new System.Drawing.Size(78, 176);
            this.tlpButtonsRight.TabIndex = 6;
            // 
            // btnPlus10Minutes
            // 
            this.btnPlus10Minutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlus10Minutes.Location = new System.Drawing.Point(3, 3);
            this.btnPlus10Minutes.Name = "btnPlus10Minutes";
            this.btnPlus10Minutes.Size = new System.Drawing.Size(72, 52);
            this.btnPlus10Minutes.TabIndex = 4;
            this.btnPlus10Minutes.Text = "10 minut >";
            this.btnPlus10Minutes.UseVisualStyleBackColor = true;
            this.btnPlus10Minutes.Click += new System.EventHandler(this.btnPlus10Minutes_Click);
            // 
            // btnPlus1Hour
            // 
            this.btnPlus1Hour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlus1Hour.Location = new System.Drawing.Point(3, 61);
            this.btnPlus1Hour.Name = "btnPlus1Hour";
            this.btnPlus1Hour.Size = new System.Drawing.Size(72, 52);
            this.btnPlus1Hour.TabIndex = 6;
            this.btnPlus1Hour.Text = "1 hodina >";
            this.btnPlus1Hour.UseVisualStyleBackColor = true;
            this.btnPlus1Hour.Click += new System.EventHandler(this.btnPlus1Hour_Click);
            // 
            // btnPlus1Day
            // 
            this.btnPlus1Day.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlus1Day.Location = new System.Drawing.Point(3, 119);
            this.btnPlus1Day.Name = "btnPlus1Day";
            this.btnPlus1Day.Size = new System.Drawing.Size(72, 54);
            this.btnPlus1Day.TabIndex = 8;
            this.btnPlus1Day.Text = "1 den >";
            this.btnPlus1Day.UseVisualStyleBackColor = true;
            this.btnPlus1Day.Click += new System.EventHandler(this.btnPlus1Day_Click);
            // 
            // pnlLabels
            // 
            this.pnlLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLabels.Location = new System.Drawing.Point(0, 0);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.Size = new System.Drawing.Size(482, 42);
            this.pnlLabels.TabIndex = 1;
            // 
            // pnlTimeLine
            // 
            this.pnlTimeLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimeLine.Controls.Add(this.pnlContent);
            this.pnlTimeLine.Controls.Add(this.pnlLabels);
            this.pnlTimeLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTimeLine.Location = new System.Drawing.Point(78, 64);
            this.pnlTimeLine.Name = "pnlTimeLine";
            this.pnlTimeLine.Size = new System.Drawing.Size(484, 176);
            this.pnlTimeLine.TabIndex = 7;
            // 
            // TimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTimeLine);
            this.Controls.Add(this.tlpButtonsRight);
            this.Controls.Add(this.tlpButtonsLeft);
            this.Controls.Add(this.gbDateTimeSelection);
            this.Name = "TimeLine";
            this.Size = new System.Drawing.Size(640, 240);
            this.Load += new System.EventHandler(this.TimeLine_Load);
            this.gbDateTimeSelection.ResumeLayout(false);
            this.tlpButtonsLeft.ResumeLayout(false);
            this.tlpButtonsRight.ResumeLayout(false);
            this.pnlTimeLine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDateTimeSelection;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnMinus10Minutes;
        private System.Windows.Forms.Button btnMinus1Hour;
        private System.Windows.Forms.TableLayoutPanel tlpButtonsLeft;
        private System.Windows.Forms.Button btnMinus1Day;
        private System.Windows.Forms.TableLayoutPanel tlpButtonsRight;
        private System.Windows.Forms.Button btnPlus10Minutes;
        private System.Windows.Forms.Button btnPlus1Hour;
        private System.Windows.Forms.Button btnPlus1Day;
        private System.Windows.Forms.Panel pnlLabels;
        private System.Windows.Forms.Panel pnlTimeLine;
    }
}

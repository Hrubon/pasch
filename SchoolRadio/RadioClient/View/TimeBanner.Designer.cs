﻿namespace RadioClient
{
    partial class TimeBanner
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
            this.SuspendLayout();
            // 
            // TimeBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "TimeBanner";
            this.Size = new System.Drawing.Size(208, 40);
            this.Load += new System.EventHandler(this.TimeBanner_Load);
            this.ForeColorChanged += new System.EventHandler(this.TimeBanner_ForeColorChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

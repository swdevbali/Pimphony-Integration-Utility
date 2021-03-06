﻿namespace DesktopNotifier.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.chkRuntAtStartup = new System.Windows.Forms.CheckBox();
            this.numCheckInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkPlayNotificationSound = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRuntAtStartup
            // 
            this.chkRuntAtStartup.AutoSize = true;
            this.chkRuntAtStartup.Location = new System.Drawing.Point(25, 42);
            this.chkRuntAtStartup.Name = "chkRuntAtStartup";
            this.chkRuntAtStartup.Size = new System.Drawing.Size(137, 17);
            this.chkRuntAtStartup.TabIndex = 1;
            this.chkRuntAtStartup.Text = "Run at windows startup";
            this.chkRuntAtStartup.UseVisualStyleBackColor = true;
            // 
            // numCheckInterval
            // 
            this.numCheckInterval.Location = new System.Drawing.Point(171, 15);
            this.numCheckInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numCheckInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCheckInterval.Name = "numCheckInterval";
            this.numCheckInterval.Size = new System.Drawing.Size(45, 20);
            this.numCheckInterval.TabIndex = 0;
            this.numCheckInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Check new message interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "minute(s)";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(196, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkPlayNotificationSound
            // 
            this.chkPlayNotificationSound.AutoSize = true;
            this.chkPlayNotificationSound.Location = new System.Drawing.Point(25, 65);
            this.chkPlayNotificationSound.Name = "chkPlayNotificationSound";
            this.chkPlayNotificationSound.Size = new System.Drawing.Size(132, 17);
            this.chkPlayNotificationSound.TabIndex = 2;
            this.chkPlayNotificationSound.Text = "Play notification sound";
            this.chkPlayNotificationSound.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 139);
            this.Controls.Add(this.chkPlayNotificationSound);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCheckInterval);
            this.Controls.Add(this.chkRuntAtStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numCheckInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRuntAtStartup;
        private System.Windows.Forms.NumericUpDown numCheckInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkPlayNotificationSound;
    }
}
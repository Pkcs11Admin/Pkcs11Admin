/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2015 Jaroslav Imrich <jimrich@jimrich.sk>
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License version 3 
 *  as published by the Free Software Foundation.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    partial class WaitDialog
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
            this.WaitDialogProgressBar = new System.Windows.Forms.ProgressBar();
            this.WaitDialogPanel = new System.Windows.Forms.Panel();
            this.WaitDialogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WaitDialogProgressBar
            // 
            this.WaitDialogProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaitDialogProgressBar.Location = new System.Drawing.Point(0, 0);
            this.WaitDialogProgressBar.Name = "WaitDialogProgressBar";
            this.WaitDialogProgressBar.Size = new System.Drawing.Size(414, 29);
            this.WaitDialogProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.WaitDialogProgressBar.TabIndex = 0;
            // 
            // WaitDialogPanel
            // 
            this.WaitDialogPanel.Controls.Add(this.WaitDialogProgressBar);
            this.WaitDialogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaitDialogPanel.Location = new System.Drawing.Point(10, 10);
            this.WaitDialogPanel.Name = "WaitDialogPanel";
            this.WaitDialogPanel.Size = new System.Drawing.Size(414, 29);
            this.WaitDialogPanel.TabIndex = 1;
            // 
            // WaitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 49);
            this.ControlBox = false;
            this.Controls.Add(this.WaitDialogPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WaitDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Operation in progress...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitDialog_FormClosing);
            this.Load += new System.EventHandler(this.WaitDialog_Load);
            this.WaitDialogPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar WaitDialogProgressBar;
        private System.Windows.Forms.Panel WaitDialogPanel;
    }
}
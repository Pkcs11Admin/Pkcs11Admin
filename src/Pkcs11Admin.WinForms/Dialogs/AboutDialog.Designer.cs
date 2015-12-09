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
    partial class AboutDialog
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
            this.ButtonClose = new System.Windows.Forms.Button();
            this.RichTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.ButtonWebsite = new System.Windows.Forms.Button();
            this.TabControlAbout = new System.Windows.Forms.TabControl();
            this.TabPageLicense = new System.Windows.Forms.TabPage();
            this.TabPageLicenses = new System.Windows.Forms.TabPage();
            this.RichTextBoxLicenses = new System.Windows.Forms.RichTextBox();
            this.TabPageContributors = new System.Windows.Forms.TabPage();
            this.RichTextBoxContributors = new System.Windows.Forms.RichTextBox();
            this.TabControlAbout.SuspendLayout();
            this.TabPageLicense.SuspendLayout();
            this.TabPageLicenses.SuspendLayout();
            this.TabPageContributors.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonClose.Location = new System.Drawing.Point(346, 285);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            // 
            // RichTextBoxLicense
            // 
            this.RichTextBoxLicense.DetectUrls = false;
            this.RichTextBoxLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxLicense.Location = new System.Drawing.Point(3, 3);
            this.RichTextBoxLicense.Name = "RichTextBoxLicense";
            this.RichTextBoxLicense.ReadOnly = true;
            this.RichTextBoxLicense.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBoxLicense.Size = new System.Drawing.Size(394, 234);
            this.RichTextBoxLicense.TabIndex = 0;
            this.RichTextBoxLicense.TabStop = false;
            this.RichTextBoxLicense.Text = "";
            // 
            // ButtonWebsite
            // 
            this.ButtonWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonWebsite.Location = new System.Drawing.Point(12, 285);
            this.ButtonWebsite.Name = "ButtonWebsite";
            this.ButtonWebsite.Size = new System.Drawing.Size(75, 23);
            this.ButtonWebsite.TabIndex = 2;
            this.ButtonWebsite.Text = "Website";
            this.ButtonWebsite.UseVisualStyleBackColor = true;
            this.ButtonWebsite.Click += new System.EventHandler(this.ButtonWebsite_Click);
            // 
            // TabControlAbout
            // 
            this.TabControlAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlAbout.Controls.Add(this.TabPageLicense);
            this.TabControlAbout.Controls.Add(this.TabPageLicenses);
            this.TabControlAbout.Controls.Add(this.TabPageContributors);
            this.TabControlAbout.Location = new System.Drawing.Point(13, 13);
            this.TabControlAbout.Name = "TabControlAbout";
            this.TabControlAbout.SelectedIndex = 0;
            this.TabControlAbout.Size = new System.Drawing.Size(408, 266);
            this.TabControlAbout.TabIndex = 3;
            // 
            // TabPageLicense
            // 
            this.TabPageLicense.Controls.Add(this.RichTextBoxLicense);
            this.TabPageLicense.Location = new System.Drawing.Point(4, 22);
            this.TabPageLicense.Name = "TabPageLicense";
            this.TabPageLicense.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLicense.Size = new System.Drawing.Size(400, 240);
            this.TabPageLicense.TabIndex = 0;
            this.TabPageLicense.Text = "License";
            this.TabPageLicense.UseVisualStyleBackColor = true;
            // 
            // TabPageLicenses
            // 
            this.TabPageLicenses.Controls.Add(this.RichTextBoxLicenses);
            this.TabPageLicenses.Location = new System.Drawing.Point(4, 22);
            this.TabPageLicenses.Name = "TabPageLicenses";
            this.TabPageLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLicenses.Size = new System.Drawing.Size(400, 240);
            this.TabPageLicenses.TabIndex = 1;
            this.TabPageLicenses.Text = "3rd party components";
            this.TabPageLicenses.UseVisualStyleBackColor = true;
            // 
            // RichTextBoxLicenses
            // 
            this.RichTextBoxLicenses.DetectUrls = false;
            this.RichTextBoxLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxLicenses.Location = new System.Drawing.Point(3, 3);
            this.RichTextBoxLicenses.Name = "RichTextBoxLicenses";
            this.RichTextBoxLicenses.ReadOnly = true;
            this.RichTextBoxLicenses.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBoxLicenses.Size = new System.Drawing.Size(394, 234);
            this.RichTextBoxLicenses.TabIndex = 0;
            this.RichTextBoxLicenses.TabStop = false;
            this.RichTextBoxLicenses.Text = "";
            // 
            // TabPageContributors
            // 
            this.TabPageContributors.Controls.Add(this.RichTextBoxContributors);
            this.TabPageContributors.Location = new System.Drawing.Point(4, 22);
            this.TabPageContributors.Name = "TabPageContributors";
            this.TabPageContributors.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageContributors.Size = new System.Drawing.Size(400, 240);
            this.TabPageContributors.TabIndex = 2;
            this.TabPageContributors.Text = "Contributors";
            this.TabPageContributors.UseVisualStyleBackColor = true;
            // 
            // RichTextBoxContributors
            // 
            this.RichTextBoxContributors.BackColor = System.Drawing.SystemColors.Control;
            this.RichTextBoxContributors.DetectUrls = false;
            this.RichTextBoxContributors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxContributors.Location = new System.Drawing.Point(3, 3);
            this.RichTextBoxContributors.Name = "RichTextBoxContributors";
            this.RichTextBoxContributors.ReadOnly = true;
            this.RichTextBoxContributors.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBoxContributors.Size = new System.Drawing.Size(394, 234);
            this.RichTextBoxContributors.TabIndex = 0;
            this.RichTextBoxContributors.TabStop = false;
            this.RichTextBoxContributors.Text = "";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 321);
            this.Controls.Add(this.TabControlAbout);
            this.Controls.Add(this.ButtonWebsite);
            this.Controls.Add(this.ButtonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 360);
            this.Name = "AboutDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabControlAbout.ResumeLayout(false);
            this.TabPageLicense.ResumeLayout(false);
            this.TabPageLicenses.ResumeLayout(false);
            this.TabPageContributors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.RichTextBox RichTextBoxLicense;
        private System.Windows.Forms.Button ButtonWebsite;
        private System.Windows.Forms.TabControl TabControlAbout;
        private System.Windows.Forms.TabPage TabPageLicense;
        private System.Windows.Forms.TabPage TabPageLicenses;
        private System.Windows.Forms.RichTextBox RichTextBoxLicenses;
        private System.Windows.Forms.TabPage TabPageContributors;
        private System.Windows.Forms.RichTextBox RichTextBoxContributors;
    }
}
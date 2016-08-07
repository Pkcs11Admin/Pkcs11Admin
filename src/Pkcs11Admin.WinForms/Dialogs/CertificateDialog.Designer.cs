/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2016 Jaroslav Imrich <jimrich@jimrich.sk>
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
    partial class CertificateDialog
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
            this.CertificateTabControl = new System.Windows.Forms.TabControl();
            this.TabPageDetails = new System.Windows.Forms.TabPage();
            this.LabelDetails = new System.Windows.Forms.Label();
            this.ListViewDetails = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.TabPageAsn1 = new System.Windows.Forms.TabPage();
            this.LabelAsn1 = new System.Windows.Forms.Label();
            this.TreeViewAsn1 = new Net.Asn1.Forms.TreeView.Asn1TreeView();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.CertificateTabControl.SuspendLayout();
            this.TabPageDetails.SuspendLayout();
            this.TabPageAsn1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CertificateTabControl
            // 
            this.CertificateTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CertificateTabControl.Controls.Add(this.TabPageDetails);
            this.CertificateTabControl.Controls.Add(this.TabPageAsn1);
            this.CertificateTabControl.Location = new System.Drawing.Point(13, 13);
            this.CertificateTabControl.Name = "CertificateTabControl";
            this.CertificateTabControl.SelectedIndex = 0;
            this.CertificateTabControl.Size = new System.Drawing.Size(471, 296);
            this.CertificateTabControl.TabIndex = 0;
            // 
            // TabPageDetails
            // 
            this.TabPageDetails.Controls.Add(this.LabelDetails);
            this.TabPageDetails.Controls.Add(this.ListViewDetails);
            this.TabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.TabPageDetails.Name = "TabPageDetails";
            this.TabPageDetails.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageDetails.Size = new System.Drawing.Size(463, 270);
            this.TabPageDetails.TabIndex = 0;
            this.TabPageDetails.Text = "Details";
            this.TabPageDetails.UseVisualStyleBackColor = true;
            // 
            // LabelDetails
            // 
            this.LabelDetails.AutoSize = true;
            this.LabelDetails.Location = new System.Drawing.Point(10, 10);
            this.LabelDetails.Name = "LabelDetails";
            this.LabelDetails.Size = new System.Drawing.Size(90, 13);
            this.LabelDetails.TabIndex = 1;
            this.LabelDetails.Text = "Certificate details:";
            // 
            // ListViewDetails
            // 
            this.ListViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewDetails.FullRowSelect = true;
            this.ListViewDetails.HideSelection = false;
            this.ListViewDetails.Location = new System.Drawing.Point(13, 26);
            this.ListViewDetails.Name = "ListViewDetails";
            this.ListViewDetails.Size = new System.Drawing.Size(437, 231);
            this.ListViewDetails.Sortable = true;
            this.ListViewDetails.TabIndex = 0;
            this.ListViewDetails.UseCompatibleStateImageBehavior = false;
            this.ListViewDetails.View = System.Windows.Forms.View.Details;
            // 
            // TabPageAsn1
            // 
            this.TabPageAsn1.Controls.Add(this.LabelAsn1);
            this.TabPageAsn1.Controls.Add(this.TreeViewAsn1);
            this.TabPageAsn1.Location = new System.Drawing.Point(4, 22);
            this.TabPageAsn1.Name = "TabPageAsn1";
            this.TabPageAsn1.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageAsn1.Size = new System.Drawing.Size(463, 270);
            this.TabPageAsn1.TabIndex = 1;
            this.TabPageAsn1.Text = "ASN.1";
            this.TabPageAsn1.UseVisualStyleBackColor = true;
            // 
            // LabelAsn1
            // 
            this.LabelAsn1.AutoSize = true;
            this.LabelAsn1.Location = new System.Drawing.Point(10, 10);
            this.LabelAsn1.Name = "LabelAsn1";
            this.LabelAsn1.Size = new System.Drawing.Size(101, 13);
            this.LabelAsn1.TabIndex = 1;
            this.LabelAsn1.Text = "Certificate structure:";
            // 
            // TreeViewAsn1
            // 
            this.TreeViewAsn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewAsn1.Location = new System.Drawing.Point(13, 26);
            this.TreeViewAsn1.Name = "TreeViewAsn1";
            this.TreeViewAsn1.Size = new System.Drawing.Size(437, 231);
            this.TreeViewAsn1.TabIndex = 0;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonClose.Location = new System.Drawing.Point(409, 315);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSave.Location = new System.Drawing.Point(13, 315);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CertificateDialog
            // 
            this.AcceptButton = this.ButtonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 351);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.CertificateTabControl);
            this.Name = "CertificateDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Certificate details";
            this.CertificateTabControl.ResumeLayout(false);
            this.TabPageDetails.ResumeLayout(false);
            this.TabPageDetails.PerformLayout();
            this.TabPageAsn1.ResumeLayout(false);
            this.TabPageAsn1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl CertificateTabControl;
        private System.Windows.Forms.TabPage TabPageDetails;
        private System.Windows.Forms.TabPage TabPageAsn1;
        private System.Windows.Forms.Button ButtonClose;
        private Asn1.Forms.TreeView.Asn1TreeView TreeViewAsn1;
        private System.Windows.Forms.Label LabelAsn1;
        private System.Windows.Forms.Label LabelDetails;
        private Controls.EnhancedListView ListViewDetails;
        private System.Windows.Forms.Button ButtonSave;
    }
}
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
    partial class GenerateKeysDialog
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonAsn1 = new System.Windows.Forms.Button();
            this.LabelKeyType = new System.Windows.Forms.Label();
            this.ComboBoxKeyType = new System.Windows.Forms.ComboBox();
            this.GenerateKeysTabControl = new System.Windows.Forms.TabControl();
            this.TabPagePrivateKey = new System.Windows.Forms.TabPage();
            this.ListViewPrivateKeyAttributes = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.ColumnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabPagePublicKey = new System.Windows.Forms.TabPage();
            this.ListViewPublicKeyAttributes = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabPageSecretKey = new System.Windows.Forms.TabPage();
            this.ListViewSecretKeyAttributes = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GenerateKeysTabControl.SuspendLayout();
            this.TabPagePrivateKey.SuspendLayout();
            this.TabPagePublicKey.SuspendLayout();
            this.TabPageSecretKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(596, 325);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGenerate.Location = new System.Drawing.Point(515, 325);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
            this.ButtonGenerate.TabIndex = 2;
            this.ButtonGenerate.Text = "Generate";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEdit.Location = new System.Drawing.Point(13, 325);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 3;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonAsn1
            // 
            this.ButtonAsn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAsn1.Location = new System.Drawing.Point(94, 325);
            this.ButtonAsn1.Name = "ButtonAsn1";
            this.ButtonAsn1.Size = new System.Drawing.Size(75, 23);
            this.ButtonAsn1.TabIndex = 4;
            this.ButtonAsn1.Text = "ASN.1";
            this.ButtonAsn1.UseVisualStyleBackColor = true;
            this.ButtonAsn1.Click += new System.EventHandler(this.ButtonAsn1_Click);
            // 
            // LabelKeyType
            // 
            this.LabelKeyType.AutoSize = true;
            this.LabelKeyType.Location = new System.Drawing.Point(10, 10);
            this.LabelKeyType.Name = "LabelKeyType";
            this.LabelKeyType.Size = new System.Drawing.Size(51, 13);
            this.LabelKeyType.TabIndex = 5;
            this.LabelKeyType.Text = "Key type:";
            // 
            // ComboBoxKeyType
            // 
            this.ComboBoxKeyType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxKeyType.FormattingEnabled = true;
            this.ComboBoxKeyType.Location = new System.Drawing.Point(13, 26);
            this.ComboBoxKeyType.Name = "ComboBoxKeyType";
            this.ComboBoxKeyType.Size = new System.Drawing.Size(658, 21);
            this.ComboBoxKeyType.TabIndex = 6;
            this.ComboBoxKeyType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxKeyType_SelectedIndexChanged);
            // 
            // GenerateKeysTabControl
            // 
            this.GenerateKeysTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateKeysTabControl.Controls.Add(this.TabPagePrivateKey);
            this.GenerateKeysTabControl.Controls.Add(this.TabPagePublicKey);
            this.GenerateKeysTabControl.Controls.Add(this.TabPageSecretKey);
            this.GenerateKeysTabControl.Location = new System.Drawing.Point(13, 53);
            this.GenerateKeysTabControl.Name = "GenerateKeysTabControl";
            this.GenerateKeysTabControl.SelectedIndex = 0;
            this.GenerateKeysTabControl.Size = new System.Drawing.Size(658, 266);
            this.GenerateKeysTabControl.TabIndex = 7;
            // 
            // TabPagePrivateKey
            // 
            this.TabPagePrivateKey.Controls.Add(this.ListViewPrivateKeyAttributes);
            this.TabPagePrivateKey.Location = new System.Drawing.Point(4, 22);
            this.TabPagePrivateKey.Name = "TabPagePrivateKey";
            this.TabPagePrivateKey.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePrivateKey.Size = new System.Drawing.Size(650, 240);
            this.TabPagePrivateKey.TabIndex = 0;
            this.TabPagePrivateKey.Text = "Private key";
            this.TabPagePrivateKey.UseVisualStyleBackColor = true;
            // 
            // ListViewPrivateKeyAttributes
            // 
            this.ListViewPrivateKeyAttributes.CheckBoxes = true;
            this.ListViewPrivateKeyAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderType,
            this.ColumnHeaderAttribute});
            this.ListViewPrivateKeyAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewPrivateKeyAttributes.FullRowSelect = true;
            this.ListViewPrivateKeyAttributes.HideSelection = false;
            this.ListViewPrivateKeyAttributes.Location = new System.Drawing.Point(3, 3);
            this.ListViewPrivateKeyAttributes.MultiSelect = false;
            this.ListViewPrivateKeyAttributes.Name = "ListViewPrivateKeyAttributes";
            this.ListViewPrivateKeyAttributes.Size = new System.Drawing.Size(644, 234);
            this.ListViewPrivateKeyAttributes.Sortable = true;
            this.ListViewPrivateKeyAttributes.TabIndex = 0;
            this.ListViewPrivateKeyAttributes.UseCompatibleStateImageBehavior = false;
            this.ListViewPrivateKeyAttributes.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeaderType
            // 
            this.ColumnHeaderType.Text = "Attribute";
            this.ColumnHeaderType.Width = 136;
            // 
            // ColumnHeaderAttribute
            // 
            this.ColumnHeaderAttribute.Text = "Value";
            this.ColumnHeaderAttribute.Width = 496;
            // 
            // TabPagePublicKey
            // 
            this.TabPagePublicKey.Controls.Add(this.ListViewPublicKeyAttributes);
            this.TabPagePublicKey.Location = new System.Drawing.Point(4, 22);
            this.TabPagePublicKey.Name = "TabPagePublicKey";
            this.TabPagePublicKey.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePublicKey.Size = new System.Drawing.Size(650, 240);
            this.TabPagePublicKey.TabIndex = 1;
            this.TabPagePublicKey.Text = "Public key";
            this.TabPagePublicKey.UseVisualStyleBackColor = true;
            // 
            // ListViewPublicKeyAttributes
            // 
            this.ListViewPublicKeyAttributes.CheckBoxes = true;
            this.ListViewPublicKeyAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ListViewPublicKeyAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewPublicKeyAttributes.FullRowSelect = true;
            this.ListViewPublicKeyAttributes.HideSelection = false;
            this.ListViewPublicKeyAttributes.Location = new System.Drawing.Point(3, 3);
            this.ListViewPublicKeyAttributes.MultiSelect = false;
            this.ListViewPublicKeyAttributes.Name = "ListViewPublicKeyAttributes";
            this.ListViewPublicKeyAttributes.Size = new System.Drawing.Size(644, 234);
            this.ListViewPublicKeyAttributes.Sortable = true;
            this.ListViewPublicKeyAttributes.TabIndex = 1;
            this.ListViewPublicKeyAttributes.UseCompatibleStateImageBehavior = false;
            this.ListViewPublicKeyAttributes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Attribute";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 496;
            // 
            // TabPageSecretKey
            // 
            this.TabPageSecretKey.Controls.Add(this.ListViewSecretKeyAttributes);
            this.TabPageSecretKey.Location = new System.Drawing.Point(4, 22);
            this.TabPageSecretKey.Name = "TabPageSecretKey";
            this.TabPageSecretKey.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSecretKey.Size = new System.Drawing.Size(650, 240);
            this.TabPageSecretKey.TabIndex = 2;
            this.TabPageSecretKey.Text = "Secret key";
            this.TabPageSecretKey.UseVisualStyleBackColor = true;
            // 
            // ListViewSecretKeyAttributes
            // 
            this.ListViewSecretKeyAttributes.CheckBoxes = true;
            this.ListViewSecretKeyAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.ListViewSecretKeyAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewSecretKeyAttributes.FullRowSelect = true;
            this.ListViewSecretKeyAttributes.HideSelection = false;
            this.ListViewSecretKeyAttributes.Location = new System.Drawing.Point(3, 3);
            this.ListViewSecretKeyAttributes.MultiSelect = false;
            this.ListViewSecretKeyAttributes.Name = "ListViewSecretKeyAttributes";
            this.ListViewSecretKeyAttributes.Size = new System.Drawing.Size(644, 234);
            this.ListViewSecretKeyAttributes.Sortable = true;
            this.ListViewSecretKeyAttributes.TabIndex = 1;
            this.ListViewSecretKeyAttributes.UseCompatibleStateImageBehavior = false;
            this.ListViewSecretKeyAttributes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Attribute";
            this.columnHeader3.Width = 136;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Value";
            this.columnHeader4.Width = 496;
            // 
            // GenerateKeysDialog
            // 
            this.AcceptButton = this.ButtonGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.GenerateKeysTabControl);
            this.Controls.Add(this.ComboBoxKeyType);
            this.Controls.Add(this.LabelKeyType);
            this.Controls.Add(this.ButtonAsn1);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.ButtonGenerate);
            this.Controls.Add(this.ButtonCancel);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "GenerateKeysDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate keys";
            this.Shown += new System.EventHandler(this.GenerateKeysDialog_Shown);
            this.GenerateKeysTabControl.ResumeLayout(false);
            this.TabPagePrivateKey.ResumeLayout(false);
            this.TabPagePublicKey.ResumeLayout(false);
            this.TabPageSecretKey.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonAsn1;
        private System.Windows.Forms.Label LabelKeyType;
        private System.Windows.Forms.ComboBox ComboBoxKeyType;
        private System.Windows.Forms.TabControl GenerateKeysTabControl;
        private System.Windows.Forms.TabPage TabPagePrivateKey;
        private System.Windows.Forms.TabPage TabPagePublicKey;
        private System.Windows.Forms.TabPage TabPageSecretKey;
        private Controls.EnhancedListView ListViewPrivateKeyAttributes;
        private System.Windows.Forms.ColumnHeader ColumnHeaderType;
        private System.Windows.Forms.ColumnHeader ColumnHeaderAttribute;
        private Controls.EnhancedListView ListViewPublicKeyAttributes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Controls.EnhancedListView ListViewSecretKeyAttributes;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
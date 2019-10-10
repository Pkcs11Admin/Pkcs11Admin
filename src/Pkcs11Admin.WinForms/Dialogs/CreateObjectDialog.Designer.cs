/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2019 Jaroslav Imrich <jimrich@jimrich.sk>
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
    partial class CreateObjectDialog
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
            this.ListViewAttributes = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.ColumnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonCreate = new System.Windows.Forms.Button();
            this.ButtonAsn1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewAttributes
            // 
            this.ListViewAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewAttributes.CheckBoxes = true;
            this.ListViewAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderType,
            this.ColumnHeaderValue});
            this.ListViewAttributes.FullRowSelect = true;
            this.ListViewAttributes.HideSelection = false;
            this.ListViewAttributes.Location = new System.Drawing.Point(13, 13);
            this.ListViewAttributes.MultiSelect = false;
            this.ListViewAttributes.Name = "ListViewAttributes";
            this.ListViewAttributes.Size = new System.Drawing.Size(658, 306);
            this.ListViewAttributes.Sortable = true;
            this.ListViewAttributes.TabIndex = 3;
            this.ListViewAttributes.UseCompatibleStateImageBehavior = false;
            this.ListViewAttributes.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeaderType
            // 
            this.ColumnHeaderType.Text = "Attribute";
            this.ColumnHeaderType.Width = 146;
            // 
            // ColumnHeaderValue
            // 
            this.ColumnHeaderValue.Text = "Value";
            this.ColumnHeaderValue.Width = 506;
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEdit.Location = new System.Drawing.Point(12, 325);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 4;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(597, 325);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreate.Location = new System.Drawing.Point(516, 325);
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.Size = new System.Drawing.Size(75, 23);
            this.ButtonCreate.TabIndex = 1;
            this.ButtonCreate.Text = "Create";
            this.ButtonCreate.UseVisualStyleBackColor = true;
            this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // ButtonAsn1
            // 
            this.ButtonAsn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAsn1.Location = new System.Drawing.Point(93, 325);
            this.ButtonAsn1.Name = "ButtonAsn1";
            this.ButtonAsn1.Size = new System.Drawing.Size(75, 23);
            this.ButtonAsn1.TabIndex = 5;
            this.ButtonAsn1.Text = "ASN.1";
            this.ButtonAsn1.UseVisualStyleBackColor = true;
            this.ButtonAsn1.Click += new System.EventHandler(this.ButtonAsn1_Click);
            // 
            // CreateObjectDialog
            // 
            this.AcceptButton = this.ButtonCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.ButtonAsn1);
            this.Controls.Add(this.ButtonCreate);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.ListViewAttributes);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "CreateObjectDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create object";
            this.ResumeLayout(false);

        }

        #endregion

        private Net.Pkcs11Admin.WinForms.Controls.EnhancedListView ListViewAttributes;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonCreate;
        private System.Windows.Forms.ColumnHeader ColumnHeaderType;
        private System.Windows.Forms.ColumnHeader ColumnHeaderValue;
        private System.Windows.Forms.Button ButtonAsn1;
    }
}
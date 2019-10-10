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
    partial class CsrDialog
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
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.CsrTabControl = new System.Windows.Forms.TabControl();
            this.TabPageSubject = new System.Windows.Forms.TabPage();
            this.ListViewSubject = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.ColumnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonDown = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.TextBoxValue = new System.Windows.Forms.TextBox();
            this.ComboBoxType = new System.Windows.Forms.ComboBox();
            this.LabelValue = new System.Windows.Forms.Label();
            this.LabelType = new System.Windows.Forms.Label();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.CsrTabControl.SuspendLayout();
            this.TabPageSubject.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGenerate.Location = new System.Drawing.Point(515, 325);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
            this.ButtonGenerate.TabIndex = 0;
            this.ButtonGenerate.Text = "Generate";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
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
            // CsrTabControl
            // 
            this.CsrTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CsrTabControl.Controls.Add(this.TabPageSubject);
            this.CsrTabControl.Location = new System.Drawing.Point(13, 13);
            this.CsrTabControl.Name = "CsrTabControl";
            this.CsrTabControl.SelectedIndex = 0;
            this.CsrTabControl.Size = new System.Drawing.Size(658, 306);
            this.CsrTabControl.TabIndex = 2;
            // 
            // TabPageSubject
            // 
            this.TabPageSubject.Controls.Add(this.ListViewSubject);
            this.TabPageSubject.Controls.Add(this.ButtonDown);
            this.TabPageSubject.Controls.Add(this.ButtonUp);
            this.TabPageSubject.Controls.Add(this.TextBoxValue);
            this.TabPageSubject.Controls.Add(this.ComboBoxType);
            this.TabPageSubject.Controls.Add(this.LabelValue);
            this.TabPageSubject.Controls.Add(this.LabelType);
            this.TabPageSubject.Controls.Add(this.ButtonDelete);
            this.TabPageSubject.Controls.Add(this.ButtonAdd);
            this.TabPageSubject.Location = new System.Drawing.Point(4, 22);
            this.TabPageSubject.Name = "TabPageSubject";
            this.TabPageSubject.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSubject.Size = new System.Drawing.Size(650, 280);
            this.TabPageSubject.TabIndex = 0;
            this.TabPageSubject.Text = "Subject";
            this.TabPageSubject.UseVisualStyleBackColor = true;
            // 
            // ListViewSubject
            // 
            this.ListViewSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewSubject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderType,
            this.ColumnHeaderValue});
            this.ListViewSubject.FullRowSelect = true;
            this.ListViewSubject.HideSelection = false;
            this.ListViewSubject.Location = new System.Drawing.Point(6, 46);
            this.ListViewSubject.MultiSelect = false;
            this.ListViewSubject.Name = "ListViewSubject";
            this.ListViewSubject.Size = new System.Drawing.Size(638, 199);
            this.ListViewSubject.Sortable = false;
            this.ListViewSubject.TabIndex = 9;
            this.ListViewSubject.UseCompatibleStateImageBehavior = false;
            this.ListViewSubject.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeaderType
            // 
            this.ColumnHeaderType.Text = "Type";
            this.ColumnHeaderType.Width = 200;
            // 
            // ColumnHeaderValue
            // 
            this.ColumnHeaderValue.Text = "Value";
            this.ColumnHeaderValue.Width = 430;
            // 
            // ButtonDown
            // 
            this.ButtonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDown.Location = new System.Drawing.Point(168, 251);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(75, 23);
            this.ButtonDown.TabIndex = 8;
            this.ButtonDown.Text = "Down";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonUp.Location = new System.Drawing.Point(87, 251);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(75, 23);
            this.ButtonUp.TabIndex = 7;
            this.ButtonUp.Text = "Up";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // TextBoxValue
            // 
            this.TextBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxValue.Location = new System.Drawing.Point(212, 19);
            this.TextBoxValue.Name = "TextBoxValue";
            this.TextBoxValue.Size = new System.Drawing.Size(351, 20);
            this.TextBoxValue.TabIndex = 6;
            // 
            // ComboBoxType
            // 
            this.ComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxType.FormattingEnabled = true;
            this.ComboBoxType.Location = new System.Drawing.Point(6, 19);
            this.ComboBoxType.Name = "ComboBoxType";
            this.ComboBoxType.Size = new System.Drawing.Size(200, 21);
            this.ComboBoxType.TabIndex = 5;
            // 
            // LabelValue
            // 
            this.LabelValue.AutoSize = true;
            this.LabelValue.Location = new System.Drawing.Point(209, 3);
            this.LabelValue.Name = "LabelValue";
            this.LabelValue.Size = new System.Drawing.Size(60, 13);
            this.LabelValue.TabIndex = 4;
            this.LabelValue.Text = "Entry value";
            // 
            // LabelType
            // 
            this.LabelType.AutoSize = true;
            this.LabelType.Location = new System.Drawing.Point(3, 3);
            this.LabelType.Name = "LabelType";
            this.LabelType.Size = new System.Drawing.Size(54, 13);
            this.LabelType.TabIndex = 3;
            this.LabelType.Text = "Entry type";
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDelete.Location = new System.Drawing.Point(6, 251);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 2;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAdd.Location = new System.Drawing.Point(569, 17);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // CsrDialog
            // 
            this.AcceptButton = this.ButtonGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.CsrTabControl);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonGenerate);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "CsrDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate certificate signing request";
            this.CsrTabControl.ResumeLayout(false);
            this.TabPageSubject.ResumeLayout(false);
            this.TabPageSubject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TabControl CsrTabControl;
        private System.Windows.Forms.TabPage TabPageSubject;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.TextBox TextBoxValue;
        private System.Windows.Forms.ComboBox ComboBoxType;
        private System.Windows.Forms.Label LabelValue;
        private System.Windows.Forms.Label LabelType;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonAdd;
        private Controls.EnhancedListView ListViewSubject;
        private System.Windows.Forms.ColumnHeader ColumnHeaderType;
        private System.Windows.Forms.ColumnHeader ColumnHeaderValue;
    }
}
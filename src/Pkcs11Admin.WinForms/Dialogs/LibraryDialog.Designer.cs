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
    partial class LibraryDialog
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
            this.LabelPkcs11Library = new System.Windows.Forms.Label();
            this.TextBoxPkcs11Library = new System.Windows.Forms.TextBox();
            this.ButtonBrowsePkcs11Library = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.CheckBoxOverwriteLogFile = new System.Windows.Forms.CheckBox();
            this.TextBoxLogFile = new System.Windows.Forms.TextBox();
            this.ButtonBrowsePkcs11Logger = new System.Windows.Forms.Button();
            this.TextBoxPkcs11Logger = new System.Windows.Forms.TextBox();
            this.ButtonBrowseLogFile = new System.Windows.Forms.Button();
            this.LabelLogFile = new System.Windows.Forms.Label();
            this.LabelPkcs11Logger = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckBoxEnableLogging = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelPkcs11Library
            // 
            this.LabelPkcs11Library.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelPkcs11Library.AutoSize = true;
            this.LabelPkcs11Library.Location = new System.Drawing.Point(10, 23);
            this.LabelPkcs11Library.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LabelPkcs11Library.Name = "LabelPkcs11Library";
            this.LabelPkcs11Library.Size = new System.Drawing.Size(266, 13);
            this.LabelPkcs11Library.TabIndex = 0;
            this.LabelPkcs11Library.Text = "Relative name or absolute path of {0} PKCS#11 library:";
            // 
            // TextBoxPkcs11Library
            // 
            this.TextBoxPkcs11Library.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPkcs11Library.Location = new System.Drawing.Point(13, 42);
            this.TextBoxPkcs11Library.Name = "TextBoxPkcs11Library";
            this.TextBoxPkcs11Library.Size = new System.Drawing.Size(551, 20);
            this.TextBoxPkcs11Library.TabIndex = 0;
            // 
            // ButtonBrowsePkcs11Library
            // 
            this.ButtonBrowsePkcs11Library.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonBrowsePkcs11Library.Location = new System.Drawing.Point(570, 40);
            this.ButtonBrowsePkcs11Library.Name = "ButtonBrowsePkcs11Library";
            this.ButtonBrowsePkcs11Library.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowsePkcs11Library.TabIndex = 1;
            this.ButtonBrowsePkcs11Library.Text = "Browse...";
            this.ButtonBrowsePkcs11Library.UseVisualStyleBackColor = true;
            this.ButtonBrowsePkcs11Library.Click += new System.EventHandler(this.ButtonBrowsePkcs11Library_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(596, 240);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 9;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.Location = new System.Drawing.Point(515, 240);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 8;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // CheckBoxOverwriteLogFile
            // 
            this.CheckBoxOverwriteLogFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CheckBoxOverwriteLogFile.AutoSize = true;
            this.CheckBoxOverwriteLogFile.Checked = true;
            this.CheckBoxOverwriteLogFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxOverwriteLogFile.Location = new System.Drawing.Point(13, 189);
            this.CheckBoxOverwriteLogFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.CheckBoxOverwriteLogFile.Name = "CheckBoxOverwriteLogFile";
            this.CheckBoxOverwriteLogFile.Size = new System.Drawing.Size(142, 17);
            this.CheckBoxOverwriteLogFile.TabIndex = 7;
            this.CheckBoxOverwriteLogFile.Text = "Overwrite existing log file";
            this.CheckBoxOverwriteLogFile.UseVisualStyleBackColor = true;
            // 
            // TextBoxLogFile
            // 
            this.TextBoxLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxLogFile.Location = new System.Drawing.Point(13, 163);
            this.TextBoxLogFile.Name = "TextBoxLogFile";
            this.TextBoxLogFile.Size = new System.Drawing.Size(551, 20);
            this.TextBoxLogFile.TabIndex = 5;
            // 
            // ButtonBrowsePkcs11Logger
            // 
            this.ButtonBrowsePkcs11Logger.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonBrowsePkcs11Logger.Location = new System.Drawing.Point(570, 112);
            this.ButtonBrowsePkcs11Logger.Name = "ButtonBrowsePkcs11Logger";
            this.ButtonBrowsePkcs11Logger.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowsePkcs11Logger.TabIndex = 4;
            this.ButtonBrowsePkcs11Logger.Text = "Browse...";
            this.ButtonBrowsePkcs11Logger.UseVisualStyleBackColor = true;
            this.ButtonBrowsePkcs11Logger.Click += new System.EventHandler(this.ButtonBrowsePkcs11Logger_Click);
            // 
            // TextBoxPkcs11Logger
            // 
            this.TextBoxPkcs11Logger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPkcs11Logger.Location = new System.Drawing.Point(13, 114);
            this.TextBoxPkcs11Logger.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.TextBoxPkcs11Logger.Name = "TextBoxPkcs11Logger";
            this.TextBoxPkcs11Logger.Size = new System.Drawing.Size(551, 20);
            this.TextBoxPkcs11Logger.TabIndex = 3;
            // 
            // ButtonBrowseLogFile
            // 
            this.ButtonBrowseLogFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonBrowseLogFile.Location = new System.Drawing.Point(570, 161);
            this.ButtonBrowseLogFile.Name = "ButtonBrowseLogFile";
            this.ButtonBrowseLogFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowseLogFile.TabIndex = 6;
            this.ButtonBrowseLogFile.Text = "Browse...";
            this.ButtonBrowseLogFile.UseVisualStyleBackColor = true;
            this.ButtonBrowseLogFile.Click += new System.EventHandler(this.ButtonBrowseLogFile_Click);
            // 
            // LabelLogFile
            // 
            this.LabelLogFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelLogFile.AutoSize = true;
            this.LabelLogFile.Location = new System.Drawing.Point(10, 144);
            this.LabelLogFile.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LabelLogFile.Name = "LabelLogFile";
            this.LabelLogFile.Size = new System.Drawing.Size(138, 13);
            this.LabelLogFile.TabIndex = 8;
            this.LabelLogFile.Text = "Absolute path of the log file:";
            // 
            // LabelPkcs11Logger
            // 
            this.LabelPkcs11Logger.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelPkcs11Logger.AutoSize = true;
            this.LabelPkcs11Logger.Location = new System.Drawing.Point(10, 95);
            this.LabelPkcs11Logger.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LabelPkcs11Logger.Name = "LabelPkcs11Logger";
            this.LabelPkcs11Logger.Size = new System.Drawing.Size(303, 13);
            this.LabelPkcs11Logger.TabIndex = 9;
            this.LabelPkcs11Logger.Text = "Relative name or absolute path of {0} PKCS#11 logging library:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.CheckBoxEnableLogging);
            this.groupBox3.Controls.Add(this.CheckBoxOverwriteLogFile);
            this.groupBox3.Controls.Add(this.LabelPkcs11Library);
            this.groupBox3.Controls.Add(this.TextBoxLogFile);
            this.groupBox3.Controls.Add(this.TextBoxPkcs11Library);
            this.groupBox3.Controls.Add(this.ButtonBrowseLogFile);
            this.groupBox3.Controls.Add(this.ButtonBrowsePkcs11Logger);
            this.groupBox3.Controls.Add(this.ButtonBrowsePkcs11Library);
            this.groupBox3.Controls.Add(this.LabelLogFile);
            this.groupBox3.Controls.Add(this.TextBoxPkcs11Logger);
            this.groupBox3.Controls.Add(this.LabelPkcs11Logger);
            this.groupBox3.Location = new System.Drawing.Point(13, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(658, 226);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // CheckBoxEnableLogging
            // 
            this.CheckBoxEnableLogging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CheckBoxEnableLogging.AutoSize = true;
            this.CheckBoxEnableLogging.Location = new System.Drawing.Point(13, 68);
            this.CheckBoxEnableLogging.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.CheckBoxEnableLogging.Name = "CheckBoxEnableLogging";
            this.CheckBoxEnableLogging.Size = new System.Drawing.Size(96, 17);
            this.CheckBoxEnableLogging.TabIndex = 2;
            this.CheckBoxEnableLogging.Text = "Enable logging";
            this.CheckBoxEnableLogging.UseVisualStyleBackColor = true;
            this.CheckBoxEnableLogging.CheckedChanged += new System.EventHandler(this.CheckBoxEnableLogging_CheckedChanged);
            // 
            // LibraryDialog
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(684, 276);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.ButtonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LibraryDialog";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load PKCS#11 library";
            this.Shown += new System.EventHandler(this.LibraryDialog_Shown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelPkcs11Library;
        private System.Windows.Forms.TextBox TextBoxPkcs11Library;
        private System.Windows.Forms.Button ButtonBrowsePkcs11Library;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.CheckBox CheckBoxOverwriteLogFile;
        private System.Windows.Forms.TextBox TextBoxLogFile;
        private System.Windows.Forms.Button ButtonBrowsePkcs11Logger;
        private System.Windows.Forms.TextBox TextBoxPkcs11Logger;
        private System.Windows.Forms.Button ButtonBrowseLogFile;
        private System.Windows.Forms.Label LabelLogFile;
        private System.Windows.Forms.Label LabelPkcs11Logger;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CheckBoxEnableLogging;
    }
}
/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014 Jaroslav Imrich <jimrich@jimrich.sk>
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
    partial class UriDialog
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
            this.PropertyGridPkcs11Uri = new System.Windows.Forms.PropertyGrid();
            this.ButtonCopy = new System.Windows.Forms.Button();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.TextBoxPkcs11Uri = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PropertyGridPkcs11Uri
            // 
            this.PropertyGridPkcs11Uri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGridPkcs11Uri.HelpVisible = false;
            this.PropertyGridPkcs11Uri.Location = new System.Drawing.Point(13, 13);
            this.PropertyGridPkcs11Uri.Name = "PropertyGridPkcs11Uri";
            this.PropertyGridPkcs11Uri.Size = new System.Drawing.Size(658, 260);
            this.PropertyGridPkcs11Uri.TabIndex = 2;
            this.PropertyGridPkcs11Uri.ToolbarVisible = false;
            this.PropertyGridPkcs11Uri.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGridPkcs11Uri_PropertyValueChanged);
            // 
            // ButtonCopy
            // 
            this.ButtonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonCopy.Location = new System.Drawing.Point(12, 325);
            this.ButtonCopy.Name = "ButtonCopy";
            this.ButtonCopy.Size = new System.Drawing.Size(75, 23);
            this.ButtonCopy.TabIndex = 4;
            this.ButtonCopy.Text = "Copy";
            this.ButtonCopy.UseVisualStyleBackColor = true;
            this.ButtonCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRefresh.Location = new System.Drawing.Point(93, 325);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefresh.TabIndex = 5;
            this.ButtonRefresh.Text = "Refresh";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonClose.Location = new System.Drawing.Point(597, 325);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            // 
            // TextBoxPkcs11Uri
            // 
            this.TextBoxPkcs11Uri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPkcs11Uri.Location = new System.Drawing.Point(13, 279);
            this.TextBoxPkcs11Uri.Multiline = true;
            this.TextBoxPkcs11Uri.Name = "TextBoxPkcs11Uri";
            this.TextBoxPkcs11Uri.ReadOnly = true;
            this.TextBoxPkcs11Uri.Size = new System.Drawing.Size(658, 40);
            this.TextBoxPkcs11Uri.TabIndex = 3;
            // 
            // UriDialog
            // 
            this.AcceptButton = this.ButtonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.TextBoxPkcs11Uri);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.ButtonCopy);
            this.Controls.Add(this.PropertyGridPkcs11Uri);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "UriDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Build PKCS#11 URI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PropertyGridPkcs11Uri;
        private System.Windows.Forms.Button ButtonCopy;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TextBox TextBoxPkcs11Uri;
    }
}
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
    partial class ProtectedInitTokenDialog
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
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.NumLockLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CapsLockLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.KeyboardLayoutLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextBoxTokenLabel = new System.Windows.Forms.TextBox();
            this.LabelTokenLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainStatusStrip.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NumLockLabel,
            this.CapsLockLabel,
            this.KeyboardLayoutLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 146);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(400, 22);
            this.MainStatusStrip.SizingGrip = false;
            this.MainStatusStrip.TabIndex = 0;
            // 
            // NumLockLabel
            // 
            this.NumLockLabel.Name = "NumLockLabel";
            this.NumLockLabel.Size = new System.Drawing.Size(84, 17);
            this.NumLockLabel.Text = "Num Lock: On";
            // 
            // CapsLockLabel
            // 
            this.CapsLockLabel.Name = "CapsLockLabel";
            this.CapsLockLabel.Size = new System.Drawing.Size(83, 17);
            this.CapsLockLabel.Text = "Caps Lock: On";
            // 
            // KeyboardLayoutLabel
            // 
            this.KeyboardLayoutLabel.Name = "KeyboardLayoutLabel";
            this.KeyboardLayoutLabel.Size = new System.Drawing.Size(117, 17);
            this.KeyboardLayoutLabel.Text = "Keyboard Layout: EN";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.Location = new System.Drawing.Point(231, 89);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(312, 89);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // TextBoxTokenLabel
            // 
            this.TextBoxTokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTokenLabel.Location = new System.Drawing.Point(13, 56);
            this.TextBoxTokenLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.TextBoxTokenLabel.Name = "TextBoxTokenLabel";
            this.TextBoxTokenLabel.Size = new System.Drawing.Size(374, 20);
            this.TextBoxTokenLabel.TabIndex = 1;
            // 
            // LabelTokenLabel
            // 
            this.LabelTokenLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelTokenLabel.AutoSize = true;
            this.LabelTokenLabel.Location = new System.Drawing.Point(10, 30);
            this.LabelTokenLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.LabelTokenLabel.Name = "LabelTokenLabel";
            this.LabelTokenLabel.Size = new System.Drawing.Size(124, 13);
            this.LabelTokenLabel.TabIndex = 5;
            this.LabelTokenLabel.Text = "Please enter token label:";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ButtonOk);
            this.MainPanel.Controls.Add(this.ButtonCancel);
            this.MainPanel.Controls.Add(this.TextBoxTokenLabel);
            this.MainPanel.Controls.Add(this.LabelTokenLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10, 30, 10, 30);
            this.MainPanel.Size = new System.Drawing.Size(400, 146);
            this.MainPanel.TabIndex = 6;
            // 
            // ProtectedInitTokenDialog
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(400, 168);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 207);
            this.Name = "ProtectedInitTokenDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialize token/card";
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.ProtectedInitTokenDialog_InputLanguageChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProtectedInitTokenDialog_KeyDown);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel NumLockLabel;
        private System.Windows.Forms.ToolStripStatusLabel CapsLockLabel;
        private System.Windows.Forms.ToolStripStatusLabel KeyboardLayoutLabel;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox TextBoxTokenLabel;
        private System.Windows.Forms.Label LabelTokenLabel;
        private System.Windows.Forms.Panel MainPanel;
    }
}
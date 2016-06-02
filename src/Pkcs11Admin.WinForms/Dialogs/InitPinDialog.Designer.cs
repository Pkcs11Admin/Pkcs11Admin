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
    partial class InitPinDialog
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TextBoxNewPin = new System.Windows.Forms.TextBox();
            this.LabelNewPin = new System.Windows.Forms.Label();
            this.TextBoxConfirmNewPin = new System.Windows.Forms.TextBox();
            this.CheckBoxDisplayPins = new System.Windows.Forms.CheckBox();
            this.LabelConfirmNewPin = new System.Windows.Forms.Label();
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
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 202);
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
            this.ButtonOk.Location = new System.Drawing.Point(231, 145);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(312, 145);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.TextBoxNewPin);
            this.MainPanel.Controls.Add(this.LabelNewPin);
            this.MainPanel.Controls.Add(this.TextBoxConfirmNewPin);
            this.MainPanel.Controls.Add(this.CheckBoxDisplayPins);
            this.MainPanel.Controls.Add(this.LabelConfirmNewPin);
            this.MainPanel.Controls.Add(this.ButtonOk);
            this.MainPanel.Controls.Add(this.ButtonCancel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10, 30, 10, 30);
            this.MainPanel.Size = new System.Drawing.Size(400, 202);
            this.MainPanel.TabIndex = 6;
            // 
            // TextBoxNewPin
            // 
            this.TextBoxNewPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNewPin.Location = new System.Drawing.Point(13, 56);
            this.TextBoxNewPin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.TextBoxNewPin.Name = "TextBoxNewPin";
            this.TextBoxNewPin.Size = new System.Drawing.Size(374, 20);
            this.TextBoxNewPin.TabIndex = 1;
            this.TextBoxNewPin.UseSystemPasswordChar = true;
            // 
            // LabelNewPin
            // 
            this.LabelNewPin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelNewPin.AutoSize = true;
            this.LabelNewPin.Location = new System.Drawing.Point(10, 30);
            this.LabelNewPin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.LabelNewPin.Name = "LabelNewPin";
            this.LabelNewPin.Size = new System.Drawing.Size(136, 13);
            this.LabelNewPin.TabIndex = 10;
            this.LabelNewPin.Text = "Please enter new user PIN:";
            // 
            // TextBoxConfirmNewPin
            // 
            this.TextBoxConfirmNewPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxConfirmNewPin.Location = new System.Drawing.Point(13, 112);
            this.TextBoxConfirmNewPin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.TextBoxConfirmNewPin.Name = "TextBoxConfirmNewPin";
            this.TextBoxConfirmNewPin.Size = new System.Drawing.Size(374, 20);
            this.TextBoxConfirmNewPin.TabIndex = 2;
            this.TextBoxConfirmNewPin.UseSystemPasswordChar = true;
            // 
            // CheckBoxDisplayPins
            // 
            this.CheckBoxDisplayPins.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CheckBoxDisplayPins.AutoSize = true;
            this.CheckBoxDisplayPins.Location = new System.Drawing.Point(13, 145);
            this.CheckBoxDisplayPins.Name = "CheckBoxDisplayPins";
            this.CheckBoxDisplayPins.Size = new System.Drawing.Size(86, 17);
            this.CheckBoxDisplayPins.TabIndex = 3;
            this.CheckBoxDisplayPins.Text = "Display PINs";
            this.CheckBoxDisplayPins.UseVisualStyleBackColor = true;
            this.CheckBoxDisplayPins.CheckedChanged += new System.EventHandler(this.CheckBoxDisplayPins_CheckedChanged);
            // 
            // LabelConfirmNewPin
            // 
            this.LabelConfirmNewPin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelConfirmNewPin.AutoSize = true;
            this.LabelConfirmNewPin.Location = new System.Drawing.Point(10, 86);
            this.LabelConfirmNewPin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.LabelConfirmNewPin.Name = "LabelConfirmNewPin";
            this.LabelConfirmNewPin.Size = new System.Drawing.Size(146, 13);
            this.LabelConfirmNewPin.TabIndex = 8;
            this.LabelConfirmNewPin.Text = "Please confirm new user PIN:";
            // 
            // InitPinDialog
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(400, 224);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 263);
            this.MinimizeBox = false;
            this.Name = "InitPinDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialize/unblock user PIN";
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.InitPinDialog_InputLanguageChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InitPinDialog_KeyDown);
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
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TextBox TextBoxNewPin;
        private System.Windows.Forms.Label LabelNewPin;
        private System.Windows.Forms.TextBox TextBoxConfirmNewPin;
        private System.Windows.Forms.CheckBox CheckBoxDisplayPins;
        private System.Windows.Forms.Label LabelConfirmNewPin;
    }
}
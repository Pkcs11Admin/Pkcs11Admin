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

using Net.Pkcs11Interop.Common;
using System;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class ChangePinDialog : Form
    {
        private Pkcs11Slot _slot = null;

        private CKU _userType = CKU.CKU_USER;

        public ChangePinDialog(Pkcs11Slot slot, CKU userType)
        {
            InitializeComponent();

            _slot = slot;
            _userType = userType;

            Text = ((_userType == CKU.CKU_USER) || (_userType == CKU.CKU_CONTEXT_SPECIFIC)) ? "Change user PIN" : "Change SO PIN";

            UpdateStatusStrip();
        }

        private void CheckBoxDisplayPins_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxCurrentPin.UseSystemPasswordChar = !CheckBoxDisplayPins.Checked;
            TextBoxNewPin.UseSystemPasswordChar = !CheckBoxDisplayPins.Checked;
            TextBoxConfirmNewPin.UseSystemPasswordChar = !CheckBoxDisplayPins.Checked;
        }

        private void UpdateStatusStrip()
        {
            NumLockLabel.Text = "Num lock: ";
            NumLockLabel.Text += (Control.IsKeyLocked(Keys.NumLock)) ? "ON" : "OFF";

            CapsLockLabel.Text = "Caps lock: ";
            CapsLockLabel.Text += (Control.IsKeyLocked(Keys.CapsLock)) ? "ON" : "OFF";

            KeyboardLayoutLabel.Text = "Keyboard layout: " + InputLanguage.CurrentInputLanguage.Culture;
        }

        private void ChangePinDialog_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            UpdateStatusStrip();
        }

        private void ChangePinDialog_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateStatusStrip();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (TextBoxNewPin.Text != TextBoxConfirmNewPin.Text)
            {
                WinFormsUtils.ShowInfo(this, "New PIN entries do not match");
                return;
            }

            try
            {
                _slot.ChangePin(TextBoxCurrentPin.Text, TextBoxNewPin.Text);
                WinFormsUtils.ShowInfo(this, (_userType == CKU.CKU_SO) ? "SO PIN successfuly changed" : "PIN successfuly changed");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }
    }
}

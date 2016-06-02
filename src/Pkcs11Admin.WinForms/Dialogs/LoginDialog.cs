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

using Net.Pkcs11Interop.Common;
using System;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class LoginDialog : Form
    {
        private Pkcs11Slot _slot = null;

        private CKU _userType = CKU.CKU_USER;

        public LoginDialog(Pkcs11Slot slot, CKU userType)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            _slot = slot;
            _userType = userType;

            Text = ((_userType == CKU.CKU_USER) || (_userType == CKU.CKU_CONTEXT_SPECIFIC)) ? "User login" : "SO login";

            UpdateStatusStrip();
        }

        private void CheckBoxDisplayPin_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxPin.UseSystemPasswordChar = !CheckBoxDisplayPin.Checked;
        }

        private void UpdateStatusStrip()
        {
            NumLockLabel.Text = "Num lock: ";
            NumLockLabel.Text += (Control.IsKeyLocked(Keys.NumLock)) ? "ON" : "OFF";

            CapsLockLabel.Text = "Caps lock: ";
            CapsLockLabel.Text += (Control.IsKeyLocked(Keys.CapsLock)) ? "ON" : "OFF";

            KeyboardLayoutLabel.Text = "Keyboard layout: " + InputLanguage.CurrentInputLanguage.Culture;
        }

        private void LoginDialog_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            UpdateStatusStrip();
        }

        private void LoginDialog_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateStatusStrip();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                _slot.Login(_userType, TextBoxPin.Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }
    }
}

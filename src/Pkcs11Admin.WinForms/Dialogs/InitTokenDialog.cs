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

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class InitTokenDialog : Form
    {
        private Pkcs11Slot _slot = null;

        public InitTokenDialog(Pkcs11Slot slot)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            _slot = slot;

            UpdateStatusStrip();
        }

        private void CheckBoxDisplayPins_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxPin.UseSystemPasswordChar = !CheckBoxDisplayPins.Checked;
            TextBoxConfirmPin.UseSystemPasswordChar = !CheckBoxDisplayPins.Checked;
        }

        private void UpdateStatusStrip()
        {
            NumLockLabel.Text = "Num lock: ";
            NumLockLabel.Text += (Control.IsKeyLocked(Keys.NumLock)) ? "ON" : "OFF";

            CapsLockLabel.Text = "Caps lock: ";
            CapsLockLabel.Text += (Control.IsKeyLocked(Keys.CapsLock)) ? "ON" : "OFF";

            KeyboardLayoutLabel.Text = "Keyboard layout: " + InputLanguage.CurrentInputLanguage.Culture;
        }

        private void InitTokenDialog_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            UpdateStatusStrip();
        }

        private void InitTokenDialog_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateStatusStrip();
        }

        private async void ButtonOk_Click(object sender, EventArgs e)
        {
            if (TextBoxPin.Text != TextBoxConfirmPin.Text)
            {
                WinFormsUtils.ShowInfo(this, "New PIN entries do not match");
                return;
            }

            try
            {
                await WaitDialog.Execute(this, () => _slot.InitToken(TextBoxPin.Text, TextBoxTokenLabel.Text));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }
    }
}

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

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class ProtectedInitTokenDialog : Form
    {
        private Pkcs11Slot _slot = null;

        public ProtectedInitTokenDialog(Pkcs11Slot slot)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            _slot = slot;

            if (!slot.TokenInfo.TokenInitialized)
            {
                Text = "Initialize token/card";
            }
            else
            {
                Text = "Reinitialize token/card";
                TextBoxTokenLabel.Text = slot.TokenInfo.Label;
            }

            UpdateStatusStrip();
        }

        private void UpdateStatusStrip()
        {
            NumLockLabel.Text = "Num lock: ";
            NumLockLabel.Text += (Control.IsKeyLocked(Keys.NumLock)) ? "ON" : "OFF";

            CapsLockLabel.Text = "Caps lock: ";
            CapsLockLabel.Text += (Control.IsKeyLocked(Keys.CapsLock)) ? "ON" : "OFF";

            KeyboardLayoutLabel.Text = "Keyboard layout: " + InputLanguage.CurrentInputLanguage.Culture;
        }

        private void ProtectedInitTokenDialog_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            UpdateStatusStrip();
        }

        private void ProtectedInitTokenDialog_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateStatusStrip();
        }

        private async void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                await WaitDialog.Execute(this, () => _slot.InitToken(null, TextBoxTokenLabel.Text));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }
    }
}

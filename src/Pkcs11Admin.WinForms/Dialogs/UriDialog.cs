/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2022 Jaroslav Imrich <jimrich@jimrich.sk>
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
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class UriDialog : Form
    {
        private Pkcs11Library _pkcs11Library = null;

        private Pkcs11Slot _pkcs11Slot = null;

        private Pkcs11ObjectInfo _pkcs11ObjectInfo = null;

        private Pkcs11Uri _viewableUri = null;

        public UriDialog(Pkcs11Library pkcs11Library, Pkcs11Slot pkcs11Slot, Pkcs11ObjectInfo pkcs11ObjectInfo)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            _pkcs11Library = pkcs11Library;
            _pkcs11Slot = pkcs11Slot;
            _pkcs11ObjectInfo = pkcs11ObjectInfo;

            RefreshUri();
        }

        private void RefreshUri()
        {
            _viewableUri = new Pkcs11Uri(_pkcs11Library, _pkcs11Slot, _pkcs11ObjectInfo);
            PropertyGridPkcs11Uri.SelectedObject = _viewableUri;
            TextBoxPkcs11Uri.Text = _viewableUri.ToString();
        }

        private void PropertyGridPkcs11Uri_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TextBoxPkcs11Uri.Text = _viewableUri.ToString();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshUri();
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxPkcs11Uri.Text);
        }
    }
}

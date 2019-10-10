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

using Net.Pkcs11Admin.WinForms.Controls;
using Net.Pkcs11Interop.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class CertificateDialog : Form
    {
        private byte[] _bytes = null;

        private X509Certificate2 _cert = null;

        public CertificateDialog(byte[] bytes)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            if (bytes == null)
                throw new ArgumentNullException("bytes");

            _bytes = bytes;
            _cert = new X509Certificate2(bytes);

            ButtonMore.Visible = Platform.IsWindows;

            LoadListViewDetails();
            LoadTreeViewAsn1();
        }

        private void LoadListViewDetails()
        {
            ListViewDetails.BeginUpdate();

            ListViewDetails.Columns.Clear();
            ListViewDetails.Items.Clear();
            ListViewDetails.Groups.Clear();

            ListViewDetails.AddColumn("Field", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewDetails.AddColumn("Value", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);

            List<KeyValuePair<object, string[]>> data = new List<KeyValuePair<object, string[]>>();
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Issuer", _cert.Issuer }));
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Subject", _cert.Subject }));
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Serial number", _cert.SerialNumber }));
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Invalid before", _cert.NotBefore.ToString("R") }));
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Invalid after", _cert.NotAfter.ToString("R") }));
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Public key type", _cert.PublicKey.Oid.FriendlyName ?? _cert.PublicKey.Oid.Value }));
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Signature algorithm", _cert.SignatureAlgorithm.FriendlyName ?? _cert.SignatureAlgorithm.Value }));
            data.Add(new KeyValuePair<object, string[]>(null, new string[] { "Thumbprint", _cert.Thumbprint }));

            WinFormsUtils.AppendToListView(ListViewDetails, null, data);

            ListViewDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewDetails.EndUpdate();
        }

        private void LoadTreeViewAsn1()
        {
            using (MemoryStream memoryStream = new MemoryStream(_bytes))
                TreeViewAsn1.LoadContent(memoryStream);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "certificate.cer";

                saveFileDialog.Filter = "All files (*.*)|*.*|DER encoded X.509 certificate (*.cer)|*.cer";
                saveFileDialog.FilterIndex = 2;

                saveFileDialog.AddExtension = true;
                saveFileDialog.CreatePrompt = false;
                saveFileDialog.OverwritePrompt = true;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, _bytes);
                    WinFormsUtils.ShowInfo(this, "Certificate successfully exported");
                }
            }
        }

        private void ButtonMore_Click(object sender, EventArgs e)
        {
            X509Certificate2 x509Cert = new X509Certificate2(_bytes);
            X509Certificate2UI.DisplayCertificate(x509Cert, this.Handle);
        }
    }
}

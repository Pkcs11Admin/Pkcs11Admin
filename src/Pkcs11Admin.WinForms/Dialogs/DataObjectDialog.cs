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

using Be.Windows.Forms;
using Net.Pkcs11Interop.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class DataObjectDialog : Form
    {
        private string _name = null;

        private byte[] _content = null;

        public DataObjectDialog(string name, byte[] content)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (content == null)
                throw new ArgumentNullException("bytes");

            _name = name;
            _content = content;

            LoadHexBoxContent();
            LoadTextBoxContent();
            LoadAsn1TreeViewContent();
        }

        private void LoadHexBoxContent()
        {
            HexBoxContent.ByteProvider = new DynamicByteProvider(_content);
        }

        private void LoadTextBoxContent()
        {
            TextBoxContent.Text = ConvertUtils.BytesToUtf8String(_content);
        }

        private void LoadAsn1TreeViewContent()
        {
            using (MemoryStream memoryStream = new MemoryStream(_content))
                Asn1TreeViewContent.LoadContent(memoryStream);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = _name;

                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                saveFileDialog.CreatePrompt = false;
                saveFileDialog.OverwritePrompt = true;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, _content);
                    WinFormsUtils.ShowInfo(this, "Data object successfully exported");
                }
            }
        }
    }
}

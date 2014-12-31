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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class LibraryDialog : Form
    {
        public LibraryDialog()
        {
            InitializeComponent();

            EnableLoggingControls();

            LabelPkcs11Library.Text = string.Format(LabelPkcs11Library.Text, (Platform.Uses32BitRuntime) ? "32" : "64");
            LabelPkcs11Logger.Text = string.Format(LabelPkcs11Logger.Text, (Platform.Uses32BitRuntime) ? "32" : "64");
            TextBoxLogFile.Text = Pkcs11Admin.Instance.GetDefaultLogPath();
            TextBoxPkcs11Logger.Text = Pkcs11Admin.Instance.GetDefaultLoggerPath();
        }

        private void EnableLoggingControls()
        {
            LabelPkcs11Library.Enabled = true;
            TextBoxPkcs11Library.Enabled = true;
            ButtonBrowsePkcs11Library.Enabled = true;
            CheckBoxEnableLogging.Enabled = true;

            LabelLogFile.Enabled = CheckBoxEnableLogging.Checked;
            TextBoxLogFile.Enabled = CheckBoxEnableLogging.Checked;
            ButtonBrowseLogFile.Enabled = CheckBoxEnableLogging.Checked;
            CheckBoxOverwriteLogFile.Enabled = CheckBoxEnableLogging.Checked;

            LabelPkcs11Logger.Enabled = CheckBoxEnableLogging.Checked && CheckBoxEnablePkcs11Logger.Checked;
            TextBoxPkcs11Logger.Enabled = CheckBoxEnableLogging.Checked && CheckBoxEnablePkcs11Logger.Checked;
            ButtonBrowsePkcs11Logger.Enabled = CheckBoxEnableLogging.Checked && CheckBoxEnablePkcs11Logger.Checked;
            CheckBoxEnablePkcs11Logger.Enabled = CheckBoxEnableLogging.Checked;
        }

        private async void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                WaitDialog.ShowInstance(this);
                await Task.Run(() =>
                    Pkcs11Admin.Instance.LoadLibrary(
                        TextBoxPkcs11Library.Text,
                        CheckBoxEnableLogging.Checked,
                        TextBoxLogFile.Text,
                        CheckBoxOverwriteLogFile.Checked,
                        TextBoxPkcs11Logger.Text,
                        CheckBoxEnablePkcs11Logger.Checked
                    )
                );
                WaitDialog.CloseInstance();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                WaitDialog.CloseInstance();
                WinFormsUtils.ShowError(this, ex);
            }
        }

        private void CheckBoxEnableLogging_CheckedChanged(object sender, EventArgs e)
        {
            EnableLoggingControls();
        }

        private void CheckBoxEnablePkcs11Logger_CheckedChanged(object sender, EventArgs e)
        {
            EnableLoggingControls();
        }

        private void ButtonBrowsePkcs11Library_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    TextBoxPkcs11Library.Text = openFileDialog.FileName;
                }
            }
        }

        private void ButtonBrowseLogFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    TextBoxLogFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void ButtonBrowsePkcs11Logger_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    TextBoxPkcs11Logger.Text = openFileDialog.FileName;
                }
            }
        }
    }
}

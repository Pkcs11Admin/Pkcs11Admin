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
using System.IO;
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

        private void LibraryDialog_Shown(object sender, EventArgs e)
        {
            TextBoxPkcs11Library.Focus();
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
            if (string.IsNullOrEmpty(TextBoxPkcs11Library.Text))
            {
                WinFormsUtils.ShowError(this, "PKCS#11 library is not specified");
                return;
            }

            if (CheckBoxEnableLogging.Checked)
            {
                if (string.IsNullOrEmpty(TextBoxLogFile.Text))
                {
                    WinFormsUtils.ShowError(this, "Log file is not specified");
                    return;
                }

                if (!Path.IsPathRooted(TextBoxLogFile.Text))
                {
                    WinFormsUtils.ShowError(this, "Path to log file is not absolute path");
                    return;
                }
            }

            if ((CheckBoxEnablePkcs11Logger.Checked) && (string.IsNullOrEmpty(TextBoxPkcs11Logger.Text)))
            {
                WinFormsUtils.ShowError(this, "PKCS#11 logging library is not specified");
                return;
            }

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
                // Set path components
                string path = TextBoxPkcs11Library.Text;
                if (Path.IsPathRooted(path))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(path);
                    openFileDialog.FileName = Path.GetFileName(path);
                }
                else
                {
                    openFileDialog.InitialDirectory = Pkcs11AdminInfo.ExecutingAssemblyDirectory;
                    openFileDialog.FileName = path;
                }

                // Set filters
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (Platform.IsWindows)
                {
                    openFileDialog.Filter += "|Shared libraries (*.dll)|*.dll";
                    openFileDialog.FilterIndex = (string.IsNullOrEmpty(path) || (Path.GetExtension(path) == ".dll")) ? 2 : 1;
                }
                else if (Platform.IsLinux)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so)|*.so";
                    openFileDialog.FilterIndex = (string.IsNullOrEmpty(path) || (Path.GetExtension(path) == ".so")) ? 2 : 1;
                }
                else if (Platform.IsMacOsX)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so;*.dylib)|*.so;*.dylib";
                    openFileDialog.FilterIndex = (string.IsNullOrEmpty(path) || (Path.GetExtension(path) == ".so") || (Path.GetExtension(path) == ".dylib")) ? 2 : 1;
                }

                // Open dialog
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    TextBoxPkcs11Library.Text = openFileDialog.FileName;
            }
        }

        private void ButtonBrowseLogFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set path components
                string path = TextBoxLogFile.Text;
                if (Path.IsPathRooted(path))
                {
                    saveFileDialog.InitialDirectory = Path.GetDirectoryName(path);
                    saveFileDialog.FileName = Path.GetFileName(path);
                }
                else
                {
                    saveFileDialog.InitialDirectory = Pkcs11AdminInfo.ExecutingAssemblyDirectory;
                    saveFileDialog.FileName = path;
                }

                // Set filters
                saveFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = (string.IsNullOrEmpty(path) || (Path.GetExtension(path) == ".txt")) ? 2 : 1;

                // Set dialog properties
                saveFileDialog.CreatePrompt = false;
                saveFileDialog.OverwritePrompt = false;

                // Open dialog
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    TextBoxLogFile.Text = saveFileDialog.FileName;
            }
        }

        private void ButtonBrowsePkcs11Logger_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set path components
                string path = TextBoxPkcs11Logger.Text;
                if (Path.IsPathRooted(path))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(path);
                    openFileDialog.FileName = Path.GetFileName(path);
                }
                else
                {
                    openFileDialog.InitialDirectory = Pkcs11AdminInfo.ExecutingAssemblyDirectory;
                    openFileDialog.FileName = path;
                }

                // Set filters
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (Platform.IsWindows)
                {
                    openFileDialog.Filter += "|Shared libraries (*.dll)|*.dll";
                    openFileDialog.FilterIndex = (string.IsNullOrEmpty(path) || (Path.GetExtension(path) == ".dll")) ? 2 : 1;
                }
                else if (Platform.IsLinux)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so)|*.so";
                    openFileDialog.FilterIndex = (string.IsNullOrEmpty(path) || (Path.GetExtension(path) == ".so")) ? 2 : 1;
                }
                else if (Platform.IsMacOsX)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so;*.dylib)|*.so;*.dylib";
                    openFileDialog.FilterIndex = (string.IsNullOrEmpty(path) || (Path.GetExtension(path) == ".so") || (Path.GetExtension(path) == ".dylib")) ? 2 : 1;
                }

                // Open dialog
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    TextBoxPkcs11Logger.Text = openFileDialog.FileName;
            }
        }
    }
}

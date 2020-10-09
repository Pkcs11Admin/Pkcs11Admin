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
            this.Icon = Properties.Resources.Pkcs11Admin;

            EnableLoggingControls();

            LabelPkcs11Library.Text = string.Format(LabelPkcs11Library.Text, Pkcs11AdminInfo.RuntimeBitness);
            LabelPkcs11Logger.Text = string.Format(LabelPkcs11Logger.Text, Pkcs11AdminInfo.RuntimeBitness);
            TextBoxPkcs11Logger.Text = Pkcs11Admin.Instance.GetDefaultLoggerPath();
            TextBoxLogFile.Text = Pkcs11Admin.Instance.GetDefaultLogPath();


            string userPkcs11Library = Properties.Settings.Default.UserPkcs11Library;
            if (!string.IsNullOrEmpty(userPkcs11Library))
            {
                TextBoxPkcs11Library.Text = userPkcs11Library;
            }
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

            LabelPkcs11Logger.Enabled = CheckBoxEnableLogging.Checked;
            TextBoxPkcs11Logger.Enabled = CheckBoxEnableLogging.Checked;
            ButtonBrowsePkcs11Logger.Enabled = CheckBoxEnableLogging.Checked;

            LabelLogFile.Enabled = CheckBoxEnableLogging.Checked;
            TextBoxLogFile.Enabled = CheckBoxEnableLogging.Checked;
            ButtonBrowseLogFile.Enabled = CheckBoxEnableLogging.Checked;
            CheckBoxOverwriteLogFile.Enabled = CheckBoxEnableLogging.Checked;
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
                if (string.IsNullOrEmpty(TextBoxPkcs11Logger.Text))
                {
                    WinFormsUtils.ShowError(this, "PKCS#11 logging library is not specified");
                    return;
                }

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

            try
            {
                await WaitDialog.Execute(
                    this,
                    () => Pkcs11Admin.Instance.LoadLibrary(
                        TextBoxPkcs11Library.Text,
                        TextBoxPkcs11Logger.Text,
                        TextBoxLogFile.Text,
                        CheckBoxEnableLogging.Checked,
                        CheckBoxOverwriteLogFile.Checked
                    )
                );
                DialogResult = DialogResult.OK;
                Properties.Settings d = Properties.Settings.Default;
                d.UserPkcs11Library = TextBoxPkcs11Library.Text;
                d.Save();
            }
            catch (Exception ex)
            {
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
                openFileDialog.Title = string.Format("Please select {0} PKCS#11 library", Pkcs11AdminInfo.RuntimeBitness);

                openFileDialog.Filter = "All files (*.*)|*.*";
                if (Platform.IsWindows)
                {
                    openFileDialog.Filter += "|Shared libraries (*.dll)|*.dll";
                    openFileDialog.FilterIndex = 2;
                }
                else if (Platform.IsLinux)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so)|*.so";
                    openFileDialog.FilterIndex = 2;
                }
                else if (Platform.IsMacOsX)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so;*.dylib)|*.so;*.dylib";
                    openFileDialog.FilterIndex = 2;
                }

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    TextBoxPkcs11Library.Text = openFileDialog.FileName;
            }
        }

        private void ButtonBrowseLogFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Please select log file";

                saveFileDialog.Filter = "All files (*.*)|*.*|Log files (*.log)|*.log";
                saveFileDialog.FilterIndex = 2;

                saveFileDialog.AddExtension = true;
                saveFileDialog.CreatePrompt = false;
                saveFileDialog.OverwritePrompt = false;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    TextBoxLogFile.Text = saveFileDialog.FileName;
            }
        }

        private void ButtonBrowsePkcs11Logger_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = string.Format("Please select {0} PKCS#11 logging library", Pkcs11AdminInfo.RuntimeBitness);

                openFileDialog.Filter = "All files (*.*)|*.*";
                if (Platform.IsWindows)
                {
                    openFileDialog.Filter += "|Shared libraries (*.dll)|*.dll";
                    openFileDialog.FilterIndex = 2;
                }
                else if (Platform.IsLinux)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so)|*.so";
                    openFileDialog.FilterIndex = 2;
                }
                else if (Platform.IsMacOsX)
                {
                    openFileDialog.Filter += "|Shared libraries (*.so;*.dylib)|*.so;*.dylib";
                    openFileDialog.FilterIndex = 2;
                }

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    TextBoxPkcs11Logger.Text = openFileDialog.FileName;
            }
        }
    }
}

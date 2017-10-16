/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2017 Jaroslav Imrich <jimrich@jimrich.sk>
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
using System.Drawing;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            Text = string.Format("About {0}", Pkcs11AdminInfo.AppTitle);

            SetLicenseText();
            SetLicensesText();
            SetContributorsText();
        }

        private void ButtonWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.pkcs11admin.net");
        }

        private void SetLicenseText()
        {
            FontFamily fontFamily = RichTextBoxLicense.Font.FontFamily;
            float fontSize = RichTextBoxLicense.Font.Size;

            RichTextBoxLicense.SelectionFont = new System.Drawing.Font(fontFamily, fontSize * 2, FontStyle.Bold);
            RichTextBoxLicense.AppendText(string.Format("{0} {1} {2}", Pkcs11AdminInfo.AppTitle, Pkcs11AdminInfo.AppVersion, Environment.NewLine));
            RichTextBoxLicense.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicense.AppendText(Pkcs11AdminInfo.AppDescription + Environment.NewLine);
            RichTextBoxLicense.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicense.AppendText(Pkcs11AdminInfo.AppCopyright + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicense.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicense.AppendText(@"This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License version 3 as published by the Free Software Foundation." + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicense.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicense.AppendText(@"This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details." + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicense.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicense.AppendText(@"You should have received a copy of the GNU General Public License along with this program. If not, see <http://www.gnu.org/licenses/>.");

            RichTextBoxLicense.SelectionStart = 0;
            RichTextBoxLicense.ScrollToCaret();
        }

        private void SetLicensesText()
        {
            FontFamily fontFamily = RichTextBoxLicenses.Font.FontFamily;
            float fontSize = RichTextBoxLicenses.Font.Size;

            RichTextBoxLicenses.AppendText(@"Pkcs11Admin uses following 3rd party components (in alphabetical order):" + Environment.NewLine);
            RichTextBoxLicenses.AppendText(Environment.NewLine);
            RichTextBoxLicenses.AppendText(@"- Asn1Net.Forms.TreeView" + Environment.NewLine);
            RichTextBoxLicenses.AppendText(@"- Asn1Reader" + Environment.NewLine);
            RichTextBoxLicenses.AppendText(@"- Be.Windows.Forms.HexBox" + Environment.NewLine);
            RichTextBoxLicenses.AppendText(@"- Pkcs11Interop" + Environment.NewLine);
            RichTextBoxLicenses.AppendText(@"- PKCS11-LOGGER" + Environment.NewLine);
            RichTextBoxLicenses.AppendText(@"- Portable.BouncyCastle" + Environment.NewLine);
            RichTextBoxLicenses.AppendText(Environment.NewLine);
            RichTextBoxLicenses.AppendText(@"Full license text for each of these components can be found in the installation directory.");
            
            RichTextBoxLicenses.SelectionStart = 0;
            RichTextBoxLicenses.ScrollToCaret();
        }

        private void SetContributorsText()
        {
            RichTextBoxContributors.AppendText(@"Following people have significantly contributed to Pkcs11Admin development:" + Environment.NewLine + Environment.NewLine);
            RichTextBoxContributors.AppendText(@"Florent Deybach - testing" + Environment.NewLine);
            RichTextBoxContributors.AppendText(@"Tomáš Haluška - application icon design" + Environment.NewLine + Environment.NewLine);
            RichTextBoxContributors.AppendText(@"Numerous other people have contributed by reporting bugs, requesting new features or suggesting improvements. Thank you!");

            RichTextBoxContributors.SelectionStart = 0;
            RichTextBoxContributors.ScrollToCaret();
        }
    }
}

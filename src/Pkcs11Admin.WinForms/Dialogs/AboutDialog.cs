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
using System.Drawing;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

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

            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize * 2, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Pkcs11Interop" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Managed .NET wrapper for unmanaged PKCS#11 libraries" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Copyright (c) 2012-2015 JWC s.r.o. <http://www.jwc.sk>" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Author: Jaroslav Imrich <jimrich@jimrich.sk>" + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Licensing for open source projects:" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Pkcs11Interop is available under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation. Please see <http://www.gnu.org/licenses/agpl-3.0.html> for more details." + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Licensing for other types of projects:" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Pkcs11Interop is available under the terms of flexible commercial license. Please contact JWC s.r.o. at <info@pkcs11interop.net> for more details." + Environment.NewLine + Environment.NewLine);

            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize * 2, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Be.Windows.Forms.HexBox" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"HEX editor control for Windows Forms" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Copyright (c) 2011 Bernhard Elbl" + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:" + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software." + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE." + Environment.NewLine + Environment.NewLine);

            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize * 2, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"PKCS11-LOGGER" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"PKCS#11 logging proxy module" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Copyright (c) 2011-2015 JWC s.r.o. <http://www.jwc.sk>" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Author: Jaroslav Imrich <jimrich@jimrich.sk>" + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Licensing for open source projects:" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"PKCS11-LOGGER is available under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation. Please see <http://www.gnu.org/licenses/agpl-3.0.html> for more details." + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Licensing for other types of projects:" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"PKCS11-LOGGER is available under the terms of flexible commercial license. Please contact JWC s.r.o. at <info@pkcs11interop.net> for more details." + Environment.NewLine + Environment.NewLine);

            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize * 2, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Asn1Reader" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Managed ASN.1 Parsing library. Part of Asn1Net utilities." + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Copyright (c) 2014-2015 Peter Polacko" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Author: Peter Polacko <peter.polacko+asn1net@gmail.com>" + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Licensing for open source projects:" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Asn1Reader is available under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation. Please see < http://www.gnu.org/licenses/agpl-3.0.html> for more details." + Environment.NewLine + Environment.NewLine);

            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize * 2, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Asn1Net.Forms.TreeView" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"User control for visualizing ASN.1 objects. Part of Asn1Net utilities." + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Copyright (c) 2014-2015 Peter Polacko" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Bold);
            RichTextBoxLicenses.AppendText(@"Author: Peter Polacko <peter.polacko+asn1net@gmail.com>" + Environment.NewLine + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Licensing for open source projects:" + Environment.NewLine);
            RichTextBoxLicenses.SelectionFont = new System.Drawing.Font(fontFamily, fontSize, FontStyle.Regular);
            RichTextBoxLicenses.AppendText(@"Asn1Net.Forms.TreeView is available under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation. Please see < http://www.gnu.org/licenses/agpl-3.0.html> for more details." + Environment.NewLine + Environment.NewLine);

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

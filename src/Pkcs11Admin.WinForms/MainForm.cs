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

using Net.Pkcs11Admin.Configuration;
using Net.Pkcs11Admin.WinForms.Controls;
using Net.Pkcs11Admin.WinForms.Dialogs;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms
{
    public partial class MainForm : Form
    {
        private Pkcs11Library _selectedLibrary = null;

        private Pkcs11Slot _selectedSlot = null;

        #region MainForm

        public MainForm()
        {
            InitializeComponent();

            Text = string.Format("{0} {1} {2} on {3}", Pkcs11AdminInfo.AppTitle, Pkcs11AdminInfo.AppVersion, Pkcs11AdminInfo.RuntimeBitness, Pkcs11AdminInfo.OperatingSystem);

            // Set DoubleBuffered property of ListViews
            PropertyInfo property = typeof(ListView).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            property.SetValue(ListViewBasicInfo, true, null);
            property.SetValue(ListViewMechanisms, true, null);
            property.SetValue(ListViewHwFeatures, true, null);
            property.SetValue(ListViewDataObjects, true, null);
            property.SetValue(ListViewCertificates, true, null);
            property.SetValue(ListViewKeys, true, null);
            property.SetValue(ListViewDomainParams, true, null);

            SetComboBoxBasicInfoItems();
            SetComboBoxMechanismsItems();
            SetComboBoxHwFeaturesItems();
            SetComboBoxDataObjectsItems();
            SetComboBoxCertificatesItems();
            SetComboBoxKeysItems();
            SetComboBoxDomainParamsItems();

            ReloadForm();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
#if !DEBUG
            WinFormsUtils.ShowInfo(this, "This version of application represents work in progress and therefore may miss important features or contain critical bugs." + Environment.NewLine + Environment.NewLine + "Please visit project website - www.pkcs11admin.net - for more information on how to report problems or request new features.");
#endif
            ShowLibraryDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Pkcs11Admin.Instance.Dispose();
        }

        #endregion

        #region MainFormMenuStrip

        #region MenuItemApplication

        private void ReloadMenuItemApplication()
        {
            if (_selectedLibrary == null)
            {
                MenuItemLoadLibrary.Enabled = true;
                MenuItemOpenLogFile.Enabled = false;
                MenuItemReloadLibrary.Enabled = false;
                MenuItemRefreshSlot.Enabled = false;
                MenuItemExit.Enabled = true;
            }
            else
            {
                MenuItemLoadLibrary.Enabled = true;
                MenuItemOpenLogFile.Enabled = (!string.IsNullOrEmpty(Pkcs11Admin.Instance.LogFile));
                MenuItemReloadLibrary.Enabled = true;
                MenuItemRefreshSlot.Enabled = (_selectedSlot != null);
                MenuItemExit.Enabled = true;
            }
        }

        private void MenuItemLoadLibrary_Click(object sender, EventArgs e)
        {
            ShowLibraryDialog();
        }

        private void MenuItemOpenLogFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Pkcs11Admin.Instance.LogFile))
                System.Diagnostics.Process.Start(Pkcs11Admin.Instance.LogFile); // TODO - Create own viewer ???
        }

        private async void MenuItemReloadLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                await WaitDialog.Execute(this, Pkcs11Admin.Instance.ReloadLibrary);
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
                return;
            }

            SetupLoadedLibrary();
        }

        private async void MenuItemRefreshSlot_Click(object sender, EventArgs e)
        {
            await ReloadFormAfter(_selectedSlot.Reload);
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region MenuItemSlot

        private void ReloadMenuItemSlot()
        {
            MenuItemSlot.Enabled = ((_selectedLibrary != null) && (_selectedLibrary.Slots.Count > 0));
        }

        private void InitializeMenuItemSlot(List<Pkcs11Slot> slots)
        {
            ToolStripItem[] menuItems = new ToolStripItem[slots.Count];

            for (int i = 0; i < slots.Count; i++)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = (slots[i].SlotInfo != null) ? slots[i].SlotInfo.SlotDescription : "Unknown slot";
                menuItem.Tag  = slots[i];
                menuItem.CheckOnClick = true;
                menuItem.Click += new EventHandler(MenuItemSlot_Click);

                menuItems[i] = menuItem;
            }

            MenuItemSlot.DropDownItems.Clear();
            MenuItemSlot.DropDownItems.AddRange(menuItems);

            _selectedSlot = null;

            if (MenuItemSlot.DropDownItems.Count == 0)
                ReloadForm();
            else
                MenuItemSlot.DropDownItems[0].PerformClick();
        }

        private async void MenuItemSlot_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedMenuItem = (ToolStripMenuItem)sender;

            foreach (ToolStripMenuItem menuItem in MenuItemSlot.DropDownItems)
                menuItem.Checked = (menuItem == selectedMenuItem);

            _selectedSlot = (Pkcs11Slot)selectedMenuItem.Tag;

            await ReloadFormAfter(_selectedSlot.Reload);
        }

        #endregion

        #region MenuItemToken

        private void ReloadMenuItemToken()
        {
            if ((_selectedSlot == null) || (_selectedSlot.SessionInfo == null))
            {
                MenuItemToken.Enabled = false;

                MenuItemLogin.Enabled = false;
                MenuItemUserLogin.Enabled = false;
                MenuItemProtectedUserLogin.Enabled = false;
                MenuItemSoLogin.Enabled = false;
                MenuItemProtectedSoLogin.Enabled = false;

                MenuItemLogout.Enabled = false;

                MenuItemChangePin.Enabled = false;
                MenuItemUserChange.Enabled = false;
                MenuItemProtectedUserChange.Enabled = false;
                MenuItemSoChange.Enabled = false;
                MenuItemProtectedSoChange.Enabled = false;

                MenuItemInitToken.Enabled = false;
                MenuItemTokenInit.Enabled = false;
                MenuItemProtectedTokenInit.Enabled = false;

                MenuItemInitPin.Enabled = false;
                MenuItemUserInit.Enabled = false;
                MenuItemProtectedUserInit.Enabled = false;
            }
            else
            {
                MenuItemToken.Enabled = true;

                MenuItemLogin.Enabled = (_selectedSlot.SessionInfo.UserCanLogin || _selectedSlot.SessionInfo.SoCanLogin);
                MenuItemUserLogin.Enabled = _selectedSlot.SessionInfo.UserCanLogin;
                MenuItemProtectedUserLogin.Enabled = _selectedSlot.SessionInfo.UserCanLoginProtected;
                MenuItemSoLogin.Enabled = _selectedSlot.SessionInfo.SoCanLogin;
                MenuItemProtectedSoLogin.Enabled = _selectedSlot.SessionInfo.SoCanLoginProtected;

                MenuItemLogout.Enabled = _selectedSlot.SessionInfo.CanLogout;

                MenuItemChangePin.Enabled = (_selectedSlot.SessionInfo.UserCanChangePin || _selectedSlot.SessionInfo.SoCanChangePin);
                MenuItemUserChange.Enabled = _selectedSlot.SessionInfo.UserCanChangePin;
                MenuItemProtectedUserChange.Enabled = _selectedSlot.SessionInfo.UserCanChangePinProtected;
                MenuItemSoChange.Enabled = _selectedSlot.SessionInfo.SoCanChangePin;
                MenuItemProtectedSoChange.Enabled = _selectedSlot.SessionInfo.SoCanChangePinProtected;

                MenuItemInitToken.Enabled = (_selectedSlot.SessionInfo.CanInitToken || _selectedSlot.SessionInfo.CanInitTokenProtected);
                MenuItemTokenInit.Enabled = _selectedSlot.SessionInfo.CanInitToken;
                MenuItemProtectedTokenInit.Enabled = _selectedSlot.SessionInfo.CanInitTokenProtected;

                MenuItemInitPin.Enabled = _selectedSlot.SessionInfo.SoCanSetUserPin;
                MenuItemUserInit.Enabled = _selectedSlot.SessionInfo.SoCanSetUserPin;
                MenuItemProtectedUserInit.Enabled = _selectedSlot.SessionInfo.SoCanSetUserPinProtected;
            }
        }

        private async void MenuItemUserLogin_Click(object sender, EventArgs e)
        {
            using (LoginDialog pinDialog = new LoginDialog(_selectedSlot, CKU.CKU_USER))
                if (pinDialog.ShowDialog() == DialogResult.OK)
                    await ReloadFormAfter(_selectedSlot.Reload);
        }

        private async void MenuItemProtectedUserLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedSlot.Login(CKU.CKU_USER, null);
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
                return;
            }

            await ReloadFormAfter(_selectedSlot.Reload);
        }

        private async void MenuItemSoLogin_Click(object sender, EventArgs e)
        {
            using (LoginDialog pinDialog = new LoginDialog(_selectedSlot, CKU.CKU_SO))
                if (pinDialog.ShowDialog() == DialogResult.OK)
                    await ReloadFormAfter(_selectedSlot.Reload);
        }

        private async void MenuItemProtectedSoLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedSlot.Login(CKU.CKU_SO, null);
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
                return;
            }

            await ReloadFormAfter(_selectedSlot.Reload);
        }

        private async void MenuItemLogout_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedSlot.Logout();
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }

            await ReloadFormAfter(_selectedSlot.Reload);
        }

        private void MenuItemUserChange_Click(object sender, EventArgs e)
        {
            using (ChangePinDialog changePinDialog = new ChangePinDialog(_selectedSlot, CKU.CKU_USER))
                changePinDialog.ShowDialog();
        }

        private void MenuItemProtectedUserChange_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedSlot.ChangePin(null, null);
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        private void MenuItemSoChange_Click(object sender, EventArgs e)
        {
            using (ChangePinDialog changePinDialog = new ChangePinDialog(_selectedSlot, CKU.CKU_SO))
                changePinDialog.ShowDialog();
        }

        private void MenuItemProtectedSoChange_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedSlot.ChangePin(null, null);
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        private async void MenuItemTokenInit_Click(object sender, EventArgs e)
        {
            string question = "Token initialization destroys all token objects and disables normal user access until SO initializes normal user's PIN." + Environment.NewLine +
            "Are you sure you want to continue?";

            if (DialogResult.Yes != WinFormsUtils.AskQuestion(this, question))
                return;

            if (!_selectedSlot.TokenInfo.TokenInitialized)
            {
                using (InitTokenDialog initTokenDialog = new InitTokenDialog(_selectedSlot))
                    if (initTokenDialog.ShowDialog() == DialogResult.OK)
                        await ReloadFormAfter(_selectedSlot.Reload);
            }
            else
            {
                using (ReInitTokenDialog reInitTokenDialog = new ReInitTokenDialog(_selectedSlot))
                    if (reInitTokenDialog.ShowDialog() == DialogResult.OK)
                        await ReloadFormAfter(_selectedSlot.Reload);
            }
        }

        private async void MenuItemProtectedTokenInit_Click(object sender, EventArgs e)
        {
            string question = "Token initialization destroys all token objects and disables normal user access until SO initializes normal user's PIN." + Environment.NewLine +
            "Are you sure you want to continue?";

            if (DialogResult.Yes != WinFormsUtils.AskQuestion(this, question))
                return;

            using (ProtectedInitTokenDialog protectedInitTokenDialog = new ProtectedInitTokenDialog(_selectedSlot))
                if (protectedInitTokenDialog.ShowDialog() == DialogResult.OK)
                    await ReloadFormAfter(_selectedSlot.Reload);
        }

        private void MenuItemUserInit_Click(object sender, EventArgs e)
        {
            using (InitPinDialog initPinDialog = new InitPinDialog(_selectedSlot))
                initPinDialog.ShowDialog();
        }

        private void MenuItemProtectedUserInit_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedSlot.InitPin(null);
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        #endregion

        #region MenuItemHelp

        private async void MenuItemCheckUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                await WaitDialog.Execute(this, Pkcs11Admin.Instance.DownloadCurrentVersionInfo);

                CurrentVersionInfo currentVersionInfo = Pkcs11Admin.Instance.CurrentVersionInfo;

                Version thisVersion = new Version(Pkcs11AdminInfo.AppVersion);
                Version currentVersion = new Version(currentVersionInfo.Version);

                if (0 > thisVersion.CompareTo(currentVersion))
                {
                    if (WinFormsUtils.AskQuestion(this, "Application update is available." + Environment.NewLine + "Do you want to open downloads page?") == DialogResult.Yes)
                    {
                        Uri uri = new Uri(currentVersionInfo.DownloadUrl, UriKind.Absolute);
                        if ((!uri.IsAbsoluteUri) || ((uri.Scheme != Uri.UriSchemeHttp) && (uri.Scheme != Uri.UriSchemeHttps)))
                            throw new Exception("Invalid update URL");

                        System.Diagnostics.Process.Start(currentVersionInfo.DownloadUrl);
                    }
                }
                else
                {
                    WinFormsUtils.ShowInfo(this, "Application is up to date.");
                }
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
                return;
            }
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            using (AboutDialog aboutDialog = new AboutDialog())
                aboutDialog.ShowDialog();
        }

        #endregion

        #endregion

        #region MainFormTabControl

        private void MainFormTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadMainFormStatusStripLabel();
        }

        #region TabPageBasicInfo

        private void ReloadTabPageBasicInfo()
        {
            bool controlsEnabled = (!((_selectedLibrary == null) || (_selectedSlot == null)));
            TabPageBasicInfo.Enabled = controlsEnabled;
            ListViewBasicInfo.HeaderStyle = (controlsEnabled) ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            ReloadListViewBasicInfo();
        }

        private void ReloadListViewBasicInfo()
        {
            ListViewBasicInfo.BeginUpdate();

            ListViewBasicInfo.Columns.Clear();
            ListViewBasicInfo.Items.Clear();
            ListViewBasicInfo.Groups.Clear();

            ListViewBasicInfo.AddColumn("Property name", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewBasicInfo.AddColumn("Property value", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);

            List<KeyValuePair<object, string[]>> data = null;

            // Library info
            if (_selectedLibrary != null)
            {
                data = new List<KeyValuePair<object, string[]>>();
                data.Add(new KeyValuePair<object, string[]>(_selectedLibrary.Info, new string[] { "Library path", _selectedLibrary.Info.LibraryPath }));
                data.Add(new KeyValuePair<object, string[]>(_selectedLibrary.Info, new string[] { "Cryptoki version", _selectedLibrary.Info.CryptokiVersion }));
                data.Add(new KeyValuePair<object, string[]>(_selectedLibrary.Info, new string[] { "Manufacturer", _selectedLibrary.Info.ManufacturerId }));
                data.Add(new KeyValuePair<object, string[]>(_selectedLibrary.Info, new string[] { "Flags", _selectedLibrary.Info.Flags.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedLibrary.Info, new string[] { "Library description", _selectedLibrary.Info.LibraryDescription }));
                data.Add(new KeyValuePair<object, string[]>(_selectedLibrary.Info, new string[] { "Library version", _selectedLibrary.Info.LibraryVersion }));

                WinFormsUtils.AppendToListView(ListViewBasicInfo, "Library info", data);
            }

            // Slot info
            if ((_selectedSlot != null) && (_selectedSlot.SlotInfo != null))
            {
                data = new List<KeyValuePair<object, string[]>>();
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Slot description", _selectedSlot.SlotInfo.SlotDescription }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Manufacturer", _selectedSlot.SlotInfo.ManufacturerId }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Flags", _selectedSlot.SlotInfo.Flags.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Token present", _selectedSlot.SlotInfo.TokenPresent.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Removable device", _selectedSlot.SlotInfo.RemovableDevice.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Hardware slot", _selectedSlot.SlotInfo.HardwareSlot.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Hardware version", _selectedSlot.SlotInfo.HardwareVersion }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.SlotInfo, new string[] { "Firmware version", _selectedSlot.SlotInfo.FirmwareVersion }));

                WinFormsUtils.AppendToListView(ListViewBasicInfo, "Slot info", data);
            }

            // Token info
            if ((_selectedSlot != null) && (_selectedSlot.TokenInfo != null))
            {
                data = new List<KeyValuePair<object, string[]>>();
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Label", _selectedSlot.TokenInfo.Label }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Manufacturer", _selectedSlot.TokenInfo.ManufacturerId }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Model", _selectedSlot.TokenInfo.Model }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Serial number", _selectedSlot.TokenInfo.SerialNumber }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Flags", _selectedSlot.TokenInfo.Flags.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "RNG", _selectedSlot.TokenInfo.Rng.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Write protected", _selectedSlot.TokenInfo.WriteProtected.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Login required", _selectedSlot.TokenInfo.LoginRequired.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "User PIN initialized", _selectedSlot.TokenInfo.UserPinInitialized.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Restore key not needed", _selectedSlot.TokenInfo.RestoreKeyNotNeeded.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Clock on token", _selectedSlot.TokenInfo.ClockOnToken.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Protected authentication path", _selectedSlot.TokenInfo.ProtectedAuthenticationPath.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Dual crypto operations", _selectedSlot.TokenInfo.DualCryptoOperations.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Token initialized", _selectedSlot.TokenInfo.TokenInitialized.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Secondary authentication", _selectedSlot.TokenInfo.SecondaryAuthentication.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "User PIN count low", _selectedSlot.TokenInfo.UserPinCountLow.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "User PIN final try", _selectedSlot.TokenInfo.UserPinFinalTry.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "User PIN locked", _selectedSlot.TokenInfo.UserPinLocked.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "User PIN to be changed", _selectedSlot.TokenInfo.UserPinToBeChanged.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "SO PIN count low", _selectedSlot.TokenInfo.SoPinCountLow.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "SO PIN final try", _selectedSlot.TokenInfo.SoPinFinalTry.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "SO PIN locked", _selectedSlot.TokenInfo.SoPinLocked.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "SO PIN to be changed", _selectedSlot.TokenInfo.SoPinToBeChanged.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Max session count", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.MaxSessionCount, true) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Session count", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.SessionCount, false) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Max RW session count", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.MaxRwSessionCount, true) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "RW session count", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.RwSessionCount, false) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Max PIN length", _selectedSlot.TokenInfo.MaxPinLen.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Min PIN length", _selectedSlot.TokenInfo.MinPinLen.ToString() }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Total public memory", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.TotalPublicMemory, false) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Free public memory", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.FreePublicMemory, false) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Total private memory", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.TotalPrivateMemory, false) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Free private memory", CheckSpecialTokenInfoValues(_selectedSlot.TokenInfo.FreePrivateMemory, false) }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Hardware version", _selectedSlot.TokenInfo.HardwareVersion }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "Firmware version", _selectedSlot.TokenInfo.FirmwareVersion }));
                data.Add(new KeyValuePair<object, string[]>(_selectedSlot.TokenInfo, new string[] { "UTC time", _selectedSlot.TokenInfo.UtcTime }));

                WinFormsUtils.AppendToListView(ListViewBasicInfo, "Token info", data);
            }

            ListViewBasicInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewBasicInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewBasicInfo.EndUpdate();
        }

        private void SetComboBoxBasicInfoItems()
        {
            ComboBoxBasicInfo.Items.Clear();
            ComboBoxBasicInfo.Items.Add(new Operation(OperationType.BuildUri, "Build PKCS#11 URI..."));
            ComboBoxBasicInfo.SelectedIndex = 0;
        }

        private void ButtonBasicInfo_Click(object sender, EventArgs e)
        {
            Operation selectedOperation = ComboBoxBasicInfo.SelectedItem as Operation;
            switch (selectedOperation.Type)
            {
                case OperationType.BuildUri:
                    BuildPkcs11Uri();
                    break;

                default:
                    WinFormsUtils.ShowError(this, "Selected operation is not implemented");
                    break;
            }
        }

        #endregion

        #region TabPageMechanisms

        private void ReloadTabPageMechanisms()
        {
            bool controlsEnabled = (!((_selectedSlot == null) || (_selectedSlot.Mechanisms == null) || (_selectedSlot.MechanismsException != null)));
            TabPageMechanisms.Enabled = controlsEnabled;
            ListViewMechanisms.HeaderStyle = (controlsEnabled) ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            ReloadListViewMechanisms();
        }

        private void ReloadListViewMechanisms()
        {
            ListViewMechanisms.BeginUpdate();

            ListViewMechanisms.Columns.Clear();
            ListViewMechanisms.Items.Clear();
            ListViewMechanisms.Groups.Clear();

            ListViewMechanisms.AddColumn("Mechanism", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewMechanisms.AddColumn("Min key size", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Max key size", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Flags", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Performed in HW", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Encryption", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Decryption", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Digesting", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Signing", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Signing with recovery", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Verification", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Verification with recovery", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Key generation", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Key pair generation", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Key wrapping", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Key unwrapping", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Key derivation", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("Has extensions", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("EC over Fp", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("EC over F2m", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("EC with ecParameters", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("EC with namedCurve", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("EC point uncompressed", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);
            ListViewMechanisms.AddColumn("EC point compressed", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Center);

            List<KeyValuePair<object, string[]>> data = new List<KeyValuePair<object, string[]>>();

            if ((_selectedSlot != null) && (_selectedSlot.Mechanisms != null))
            {
                foreach (Pkcs11MechanismInfo mechanism in _selectedSlot.Mechanisms)
                {
                    data.Add(new KeyValuePair<object, string[]>(mechanism, new string[] {
                        mechanism.Mechanism.ToString(),
                        mechanism.MinKeySize.ToString(),
                        mechanism.MaxKeySize.ToString(),
                        mechanism.Flags.ToString(),
                        mechanism.Hw.ToString(),
                        mechanism.Encrypt.ToString(),
                        mechanism.Decrypt.ToString(),
                        mechanism.Digest.ToString(),
                        mechanism.Sign.ToString(),
                        mechanism.SignRecover.ToString(),
                        mechanism.Verify.ToString(),
                        mechanism.VerifyRecover.ToString(),
                        mechanism.Generate.ToString(),
                        mechanism.GenerateKeyPair.ToString(),
                        mechanism.Wrap.ToString(),
                        mechanism.Unwrap.ToString(),
                        mechanism.Derive.ToString(),
                        mechanism.Extension.ToString(),
                        mechanism.EcFp.ToString(),
                        mechanism.EcF2m.ToString(),
                        mechanism.EcEcParameters.ToString(),
                        mechanism.EcNamedCurve.ToString(),
                        mechanism.EcUncompress.ToString(),
                        mechanism.EcCompress.ToString()
                    }));
                }

                WinFormsUtils.AppendToListView(ListViewMechanisms, null, data);
            }

            ListViewMechanisms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewMechanisms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewMechanisms.EndUpdate();
        }

        private void SetComboBoxMechanismsItems()
        {
            ComboBoxMechanisms.Items.Clear();
            ComboBoxMechanisms.Items.Add(new Operation(OperationType.Export, "Export mechanisms to CSV file..."));
            ComboBoxMechanisms.SelectedIndex = 0;
        }

        private void ButtonMechanisms_Click(object sender, EventArgs e)
        {
            Operation selectedOperation = ComboBoxMechanisms.SelectedItem as Operation;
            switch (selectedOperation.Type)
            {
                case OperationType.Export:
                    string csvFileName = Path.GetFileNameWithoutExtension(_selectedLibrary.Info.LibraryPath) + "_mechanisms.csv";
                    ExportListView(ListViewMechanisms, csvFileName);
                    break;

                default:
                    WinFormsUtils.ShowError(this, "Selected operation is not implemented");
                    break;
            }
        }

        #endregion

        #region TabPageHwFeatures

        private void ReloadTabPageHwFeatures()
        {
            bool controlsEnabled = (!((_selectedSlot == null) || (_selectedSlot.HwFeatures == null) || (_selectedSlot.HwFeaturesException != null)));
            TabPageHwFeatures.Enabled = controlsEnabled;
            ListViewHwFeatures.HeaderStyle = (controlsEnabled) ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            ReloadListViewHwFeatures();
        }

        private void ReloadListViewHwFeatures()
        {
            ListViewHwFeatures.BeginUpdate();

            ListViewHwFeatures.Columns.Clear();
            ListViewHwFeatures.Items.Clear();
            ListViewHwFeatures.Groups.Clear();

            ListViewHwFeatures.AddColumn("HW feature type", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewHwFeatures.AddColumn("Storage size", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Left);

            List<KeyValuePair<object, string[]>> data = new List<KeyValuePair<object, string[]>>();

            if ((_selectedSlot != null) && (_selectedSlot.HwFeatures != null))
            {
                foreach (Pkcs11HwFeatureInfo hwFeature in _selectedSlot.HwFeatures)
                {
                    data.Add(new KeyValuePair<object, string[]>(hwFeature, new string[] {
                        StringUtils.GetAttributeEnumValue((ulong)CKA.CKA_HW_FEATURE_TYPE, hwFeature.CkaHwFeatureType, true),
                        StorageSizeToString(hwFeature.StorageSize)
                    }));
                }

                WinFormsUtils.AppendToListView(ListViewHwFeatures, null, data);
            }

            ListViewHwFeatures.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewHwFeatures.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewHwFeatures.EndUpdate();
        }

        private void SetComboBoxHwFeaturesItems()
        {
            ComboBoxHwFeatures.Items.Clear();
            ComboBoxHwFeatures.Items.Add(new Operation(OperationType.Edit, "Edit attributes of selected hardware feature..."));
            ComboBoxHwFeatures.SelectedIndex = 0;
        }

        private async void ButtonHwFeatures_Click(object sender, EventArgs e)
        {
            bool formReloadNeeded = false;

            Operation selectedOperation = ComboBoxHwFeatures.SelectedItem as Operation;
            switch (selectedOperation.Type)
            {
                case OperationType.Edit:
                    formReloadNeeded = EditPkcs11ObjectAttributes(ListViewHwFeatures);
                    break;

                default:
                    WinFormsUtils.ShowError(this, "Selected operation is not implemented");
                    break;
            }

            if (formReloadNeeded)
                await ReloadFormAfter(_selectedSlot.Reload);
        }

        #endregion

        #region TabPageDataObjects

        private void ReloadTabPageDataObjects()
        {
            bool controlsEnabled = (!((_selectedSlot == null) || (_selectedSlot.DataObjects == null) || (_selectedSlot.DataObjectsException != null)));
            TabPageDataObjects.Enabled = controlsEnabled;
            ListViewDataObjects.HeaderStyle = (controlsEnabled) ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            ReloadListViewDataObjects();
        }

        private void ReloadListViewDataObjects()
        {
            ListViewDataObjects.BeginUpdate();

            ListViewDataObjects.Columns.Clear();
            ListViewDataObjects.Items.Clear();
            ListViewDataObjects.Groups.Clear();

            ListViewDataObjects.AddColumn("Label", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewDataObjects.AddColumn("Application", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewDataObjects.AddColumn("Private", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Left);
            ListViewDataObjects.AddColumn("Storage size", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Left);

            List<KeyValuePair<object, string[]>> data = new List<KeyValuePair<object, string[]>>();

            if ((_selectedSlot != null) && (_selectedSlot.DataObjects != null))
            {
                foreach (Pkcs11DataObjectInfo dataObject in _selectedSlot.DataObjects)
                {
                    data.Add(new KeyValuePair<object, string[]>(dataObject, new string[] {
                        dataObject.CkaLabel,
                        dataObject.CkaApplication,
                        dataObject.CkaPrivate.ToString(),
                        StorageSizeToString(dataObject.StorageSize)
                    }));
                }

                WinFormsUtils.AppendToListView(ListViewDataObjects, null, data);
            }

            ListViewDataObjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewDataObjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewDataObjects.EndUpdate();
        }

        private void SetComboBoxDataObjectsItems()
        {
            ComboBoxDataObjects.Items.Clear();
            ComboBoxDataObjects.Items.Add(new Operation(OperationType.Create, "Create new data object..."));
            ComboBoxDataObjects.Items.Add(new Operation(OperationType.Edit, "Edit attributes of selected data object..."));
            ComboBoxDataObjects.Items.Add(new Operation(OperationType.Delete, "Delete selected data objects..."));
            ComboBoxDataObjects.Items.Add(new Operation(OperationType.Import, "Import file as a new data object..."));
            ComboBoxDataObjects.Items.Add(new Operation(OperationType.Export, "Export selected data object to the file..."));
            ComboBoxDataObjects.Items.Add(new Operation(OperationType.BuildUri, "Build PKCS#11 URI for selected data object..."));
            ComboBoxDataObjects.SelectedIndex = 0;
        }

        private async void ButtonDataObjects_Click(object sender, EventArgs e)
        {
            bool formReloadNeeded = false;

            Operation selectedOperation = ComboBoxDataObjects.SelectedItem as Operation;
            switch (selectedOperation.Type)
            {
                case OperationType.Create:
                    formReloadNeeded = CreatePkcs11Object();
                    break;

                case OperationType.Edit:
                    formReloadNeeded = EditPkcs11ObjectAttributes(ListViewDataObjects);
                    break;

                case OperationType.Delete:
                    formReloadNeeded = DeletePkcs11Object(ListViewDataObjects);
                    break;

                case OperationType.Import:
                    formReloadNeeded = ImportDataObject();
                    break;

                case OperationType.Export:
                    ExportDataObject();
                    break;

                case OperationType.BuildUri:
                    BuildPkcs11Uri(ListViewDataObjects);
                    break;

                default:
                    WinFormsUtils.ShowError(this, "Selected operation is not implemented");
                    break;
            }

            if (formReloadNeeded)
                await ReloadFormAfter(_selectedSlot.Reload);
        }

        #endregion

        #region TabPageCertificates;

        private void ReloadTabPageCertificates()
        {
            bool controlsEnabled = (!((_selectedSlot == null) || (_selectedSlot.Certificates == null) || (_selectedSlot.CertificatesException != null)));
            TabPageCertificates.Enabled = controlsEnabled;
            ListViewCertificates.HeaderStyle = (controlsEnabled) ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            ReloadListViewCertificates();
        }

        private void ReloadListViewCertificates()
        {
            ListViewCertificates.BeginUpdate();

            ListViewCertificates.Columns.Clear();
            ListViewCertificates.Items.Clear();
            ListViewCertificates.Groups.Clear();

            ListViewCertificates.AddColumn("Label", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewCertificates.AddColumn("ID", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewCertificates.AddColumn("Certificate type", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewCertificates.AddColumn("Private", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Left);
            ListViewCertificates.AddColumn("Storage size", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Left);

            List<KeyValuePair<object, string[]>> data = new List<KeyValuePair<object, string[]>>();

            if ((_selectedSlot != null) && (_selectedSlot.Certificates != null))
            {
                foreach (Pkcs11CertificateInfo certificate in _selectedSlot.Certificates)
                {
                    data.Add(new KeyValuePair<object, string[]>(certificate, new string[] {
                        certificate.CkaLabel,
                        StringUtils.BytesToHexString(certificate.CkaId),
                        StringUtils.GetAttributeEnumValue((ulong)CKA.CKA_CERTIFICATE_TYPE, certificate.CkaCertificateType, true),
                        certificate.CkaPrivate.ToString(),
                        StorageSizeToString(certificate.StorageSize)
                    }));
                }

                WinFormsUtils.AppendToListView(ListViewCertificates, null, data);
            }

            ListViewCertificates.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewCertificates.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewCertificates.EndUpdate();
        }

        private void SetComboBoxCertificatesItems()
        {
            ComboBoxCertificates.Items.Clear();
            ComboBoxCertificates.Items.Add(new Operation(OperationType.Edit, "Edit attributes of selected certificate..."));
            ComboBoxCertificates.Items.Add(new Operation(OperationType.Delete, "Delete selected certificates..."));
            ComboBoxCertificates.Items.Add(new Operation(OperationType.Import, "NOT IMPLEMENTED - Import certificate from file..."));
            ComboBoxCertificates.Items.Add(new Operation(OperationType.Export, "NOT IMPLEMENTED - Export selected certificate to the file..."));
            ComboBoxCertificates.Items.Add(new Operation(OperationType.BuildUri, "Build PKCS#11 URI for selected certificate..."));
            ComboBoxCertificates.Items.Add(new Operation(OperationType.Details, (Platform.IsWindows) ? "Show certificate details..." : "NOT IMPLEMENTED - Show certificate details..."));
            ComboBoxCertificates.SelectedIndex = 0;
        }

        private async void ButtonCertificates_Click(object sender, EventArgs e)
        {
            bool formReloadNeeded = false;

            Operation selectedOperation = ComboBoxCertificates.SelectedItem as Operation;
            switch (selectedOperation.Type)
            {
                case OperationType.Edit:
                    formReloadNeeded = EditPkcs11ObjectAttributes(ListViewCertificates);
                    break;

                case OperationType.Delete:
                    formReloadNeeded = DeletePkcs11Object(ListViewCertificates);
                    break;

                case OperationType.Import: // TODO
                case OperationType.Export: // TODO
                    WinFormsUtils.ShowInfo(this, "Selected operation has not been implemented yet");
                    break;

                case OperationType.BuildUri:
                    BuildPkcs11Uri(ListViewCertificates);
                    break;

                case OperationType.Details:
                    ShowCertificateDetails();
                    break;

                default:
                    WinFormsUtils.ShowError(this, "Selected operation is not implemented");
                    break;
            }

            if (formReloadNeeded)
                await ReloadFormAfter(_selectedSlot.Reload);
        }

        #endregion

        #region TabPageKeys

        private void ReloadTabPageKeys()
        {
            bool controlsEnabled = (!((_selectedSlot == null) || (_selectedSlot.Keys == null) || (_selectedSlot.KeysException != null)));
            TabPageKeys.Enabled = controlsEnabled;
            ListViewKeys.HeaderStyle = (controlsEnabled) ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            ReloadListViewKeys();
        }

        private void ReloadListViewKeys()
        {
            ListViewKeys.BeginUpdate();

            ListViewKeys.Columns.Clear();
            ListViewKeys.Items.Clear();
            ListViewKeys.Groups.Clear();

            ListViewKeys.AddColumn("Label", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewKeys.AddColumn("ID", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewKeys.AddColumn("Key type", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewKeys.AddColumn("Key type", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewKeys.AddColumn("Private", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Left);
            ListViewKeys.AddColumn("Storage size", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Left);

            List<KeyValuePair<object, string[]>> data = new List<KeyValuePair<object, string[]>>();

            if ((_selectedSlot != null) && (_selectedSlot.Keys != null))
            {
                foreach (Pkcs11KeyInfo key in _selectedSlot.Keys)
                {
                    data.Add(new KeyValuePair<object, string[]>(key, new string[] {
                        key.CkaLabel,
                        StringUtils.BytesToHexString(key.CkaId),
                        StringUtils.GetAttributeEnumValue((ulong)CKA.CKA_CLASS, key.CkaClass, true),
                        StringUtils.GetAttributeEnumValue((ulong)CKA.CKA_KEY_TYPE, key.CkaKeyType, true),
                        key.CkaPrivate.ToString(),
                        StorageSizeToString(key.StorageSize)
                    }));
                }

                WinFormsUtils.AppendToListView(ListViewKeys, null, data);
            }

            ListViewKeys.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewKeys.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewKeys.EndUpdate();
        }

        private void SetComboBoxKeysItems()
        {
            ComboBoxKeys.Items.Clear();
            ComboBoxKeys.Items.Add(new Operation(OperationType.Generate, "NOT IMPLEMENTED - Generate new key or keypair..."));
            ComboBoxKeys.Items.Add(new Operation(OperationType.Edit, "Edit attributes of selected key..."));
            ComboBoxKeys.Items.Add(new Operation(OperationType.Delete, "Delete selected keys..."));
            ComboBoxKeys.Items.Add(new Operation(OperationType.Import, "NOT IMPLEMENTED - Import key from file..."));
            ComboBoxKeys.Items.Add(new Operation(OperationType.Export, "NOT IMPLEMENTED - Export selected key to the file..."));
            ComboBoxKeys.Items.Add(new Operation(OperationType.GenerateCSR, "NOT IMPLEMENTED - Generate certificate signing request for selected key..."));
            ComboBoxKeys.Items.Add(new Operation(OperationType.GenerateCertificate, "NOT IMPLEMENTED - Generate self-signed certificate for selected key..."));
            ComboBoxKeys.Items.Add(new Operation(OperationType.BuildUri, "Build PKCS#11 URI for selected key..."));
            ComboBoxKeys.SelectedIndex = 0;
        }

        private async void ButtonKeys_Click(object sender, EventArgs e)
        {
            bool formReloadNeeded = false;

            Operation selectedOperation = ComboBoxKeys.SelectedItem as Operation;
            switch (selectedOperation.Type)
            {
                case OperationType.Generate: // TODO
                case OperationType.Import: // TODO
                case OperationType.Export: // TODO
                case OperationType.GenerateCSR: // TODO
                case OperationType.GenerateCertificate: // TODO
                    WinFormsUtils.ShowInfo(this, "Selected operation has not been implemented yet");
                    break;

                case OperationType.Edit:
                    formReloadNeeded = EditPkcs11ObjectAttributes(ListViewKeys);
                    break;

                case OperationType.Delete:
                    formReloadNeeded = DeletePkcs11Object(ListViewKeys);
                    break;

                case OperationType.BuildUri:
                    BuildPkcs11Uri(ListViewKeys);
                    break;

                default:
                    WinFormsUtils.ShowError(this, "Selected operation is not implemented");
                    break;
            }

            if (formReloadNeeded)
                await ReloadFormAfter(_selectedSlot.Reload);
        }

        #endregion

        #region TabPageDomainParams

        private void ReloadTabPageDomainParams()
        {
            bool controlsEnabled = (!((_selectedSlot == null) || (_selectedSlot.DomainParams == null) || (_selectedSlot.DomainParamsException != null)));
            TabPageDomainParams.Enabled = controlsEnabled;
            ListViewDomainParams.HeaderStyle = (controlsEnabled) ? ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            ReloadListViewDomainParams();
        }

        private void ReloadListViewDomainParams()
        {
            ListViewDomainParams.BeginUpdate();

            ListViewDomainParams.Columns.Clear();
            ListViewDomainParams.Items.Clear();
            ListViewDomainParams.Groups.Clear();

            ListViewDomainParams.AddColumn("Label", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewDomainParams.AddColumn("Key type", EnhancedListView.ColumnType.String, HorizontalAlignment.Left);
            ListViewDomainParams.AddColumn("Private", EnhancedListView.ColumnType.Bool, HorizontalAlignment.Left);
            ListViewDomainParams.AddColumn("Storage size", EnhancedListView.ColumnType.ULong, HorizontalAlignment.Left);

            List<KeyValuePair<object, string[]>> data = new List<KeyValuePair<object, string[]>>();

            if ((_selectedSlot != null) && (_selectedSlot.DomainParams != null))
            {
                foreach (Pkcs11DomainParamsInfo domainParams in _selectedSlot.DomainParams)
                {
                    data.Add(new KeyValuePair<object, string[]>(domainParams, new string[] {
                        domainParams.CkaLabel,
                        StringUtils.GetAttributeEnumValue((ulong)CKA.CKA_KEY_TYPE, domainParams.CkaKeyType, true),
                        domainParams.CkaPrivate.ToString(),
                        StorageSizeToString(domainParams.StorageSize)
                    }));
                }

                WinFormsUtils.AppendToListView(ListViewDomainParams, null, data);
            }

            ListViewDomainParams.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewDomainParams.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewDomainParams.EndUpdate();
        }

        private void SetComboBoxDomainParamsItems()
        {
            ComboBoxDomainParams.Items.Clear();
            ComboBoxDomainParams.Items.Add(new Operation(OperationType.Edit, "Edit attributes of selected domain parameters..."));
            ComboBoxDomainParams.Items.Add(new Operation(OperationType.Delete, "Delete selected domain parameters..."));
            ComboBoxDomainParams.SelectedIndex = 0;
        }

        private async void ButtonDomainParams_Click(object sender, EventArgs e)
        {
            bool formReloadNeeded = false;

            Operation selectedOperation = ComboBoxDomainParams.SelectedItem as Operation;
            switch (selectedOperation.Type)
            {
                case OperationType.Edit:
                    formReloadNeeded = EditPkcs11ObjectAttributes(ListViewDomainParams);
                    break;

                case OperationType.Delete:
                    formReloadNeeded = DeletePkcs11Object(ListViewDomainParams);
                    break;

                default:
                    WinFormsUtils.ShowError(this, "Selected operation is not implemented");
                    break;
            }

            if (formReloadNeeded)
                await ReloadFormAfter(_selectedSlot.Reload);
        }

        #endregion

        #endregion

        #region MainFormStatusStrip

        private void ReloadMainFormStatusStripLabel()
        {
            if ((_selectedLibrary == null) && (_selectedSlot == null))
            {
                ShowInfoInStatusStrip(string.Empty);
                return;
            }

            if ((_selectedLibrary != null) && (_selectedLibrary.Slots.Count == 0))
            {
                ShowErrorInStatusStrip("No slots/readers found");
                return;
            }

            if (MainFormTabControl.SelectedTab == TabPageBasicInfo)
            {
                if (_selectedSlot.SlotInfoException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.SlotInfoException);
                else if (_selectedSlot.TokenInfoException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.TokenInfoException);
                else if (_selectedSlot.SessionInfoException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.SessionInfoException);
                else
                    ShowInfoInStatusStrip(string.Empty);
            }
            else if (MainFormTabControl.SelectedTab == TabPageMechanisms)
            {
                if (_selectedSlot.MechanismsException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.MechanismsException);
                else
                    ShowObjectCountInStatusStrip(ListViewMechanisms.Items.Count);
            }
            else if (MainFormTabControl.SelectedTab == TabPageHwFeatures)
            {
                if (_selectedSlot.HwFeaturesException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.HwFeaturesException);
                else
                    ShowObjectCountInStatusStrip(ListViewHwFeatures.Items.Count);
            }
            else if (MainFormTabControl.SelectedTab == TabPageDataObjects)
            {
                if (_selectedSlot.DataObjectsException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.DataObjectsException);
                else
                    ShowObjectCountInStatusStrip(ListViewDataObjects.Items.Count);
            }
            else if (MainFormTabControl.SelectedTab == TabPageCertificates)
            {
                if (_selectedSlot.CertificatesException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.CertificatesException);
                else
                    ShowObjectCountInStatusStrip(ListViewCertificates.Items.Count);
            }
            else if (MainFormTabControl.SelectedTab == TabPageKeys)
            {
                if (_selectedSlot.KeysException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.KeysException);
                else
                    ShowObjectCountInStatusStrip(ListViewKeys.Items.Count);
            }
            else if (MainFormTabControl.SelectedTab == TabPageDomainParams)
            {
                if (_selectedSlot.DomainParamsException != null)
                    ShowExceptionInStatusStrip(_selectedSlot.DomainParamsException);
                else
                    ShowObjectCountInStatusStrip(ListViewDomainParams.Items.Count);
            }
            else
            {
                ShowInfoInStatusStrip(string.Empty);
            }
        }

        private void ShowInfoInStatusStrip(string message)
        {
            MainFormStatusStripLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            MainFormStatusStripLabel.Text = message;
        }

        private void ShowErrorInStatusStrip(string message)
        {
            MainFormStatusStripLabel.ForeColor = System.Drawing.Color.Red;
            MainFormStatusStripLabel.Text = message;
        }

        private void ShowExceptionInStatusStrip(Exception exception)
        {
            if (exception is TokenNotPresentException)
                ShowErrorInStatusStrip(exception.Message);
            else
                ShowErrorInStatusStrip(string.Format("Error occurred: {0}", exception.Message));
        }

        private void ShowObjectCountInStatusStrip(int count)
        {
            ShowInfoInStatusStrip(string.Format("Found {0} object(s)", count));
        }

        #endregion

        #region Other methods

        private void ReloadForm()
        {
            ReloadMenuItemApplication();
            ReloadMenuItemSlot();
            ReloadMenuItemToken();

            ReloadTabPageBasicInfo();
            ReloadTabPageMechanisms();
            ReloadTabPageHwFeatures();
            ReloadTabPageDataObjects();
            ReloadTabPageCertificates();
            ReloadTabPageKeys();
            ReloadTabPageDomainParams();

            ReloadMainFormStatusStripLabel();
        }

        private async Task ReloadFormAfter(Action action)
        {
            try
            {
                await WaitDialog.Execute(this, null, action, ReloadForm);
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        private void ShowLibraryDialog()
        {
            using (LibraryDialog libraryDialog = new LibraryDialog())
                if (libraryDialog.ShowDialog(this) == DialogResult.OK)
                    SetupLoadedLibrary();
        }

        private void SetupLoadedLibrary()
        {
            _selectedLibrary = Pkcs11Admin.Instance.Library;
            InitializeMenuItemSlot(_selectedLibrary.Slots);
        }

        private bool EditPkcs11ObjectAttributes(ListView listView)
        {
            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(listView);
            if (selectedItem == null)
                return false;

            using (EditObjectDialog editObjectDialog = new EditObjectDialog(_selectedSlot, (Pkcs11ObjectInfo)selectedItem.Tag))
            {
                editObjectDialog.ShowDialog();
                return editObjectDialog.AttributeModified;
            }
        }

        private bool DeletePkcs11Object(ListView listView)
        {
            List<ListViewItem> selectedItems = WinFormsUtils.GetSelectedItems(listView);
            if (selectedItems == null)
                return false;

            if (DialogResult.No == WinFormsUtils.AskQuestion(this, string.Format("Are you sure you want to delete {0} object(s)", selectedItems.Count)))
                return false;

            foreach (ListViewItem selectedItem in selectedItems)
                _selectedSlot.DeleteObject((Pkcs11ObjectInfo)selectedItem.Tag);

            return true;
        }

        private bool CreatePkcs11Object()
        {
            // TODO - Customize for each object type
            List<Tuple<ObjectAttribute, ClassAttribute>> objectAttributes = StringUtils.GetDefaultAttributes(Pkcs11Admin.Instance.Config.DataObjectAttributes, null);

            using (CreateObjectDialog createObjectDialog = new CreateObjectDialog(_selectedSlot, objectAttributes))
                return (createObjectDialog.ShowDialog() == DialogResult.OK);
        }

        private bool CreatePkcs11Object(List<Tuple<ObjectAttribute, ClassAttribute>> objectAttributes)
        {
            using (CreateObjectDialog createObjectDialog = new CreateObjectDialog(_selectedSlot, objectAttributes))
                return (createObjectDialog.ShowDialog() == DialogResult.OK);
        }

        private void BuildPkcs11Uri()
        {
            using (UriDialog uriDialog = new UriDialog(_selectedLibrary, _selectedSlot, null))
                uriDialog.ShowDialog();
        }

        private void BuildPkcs11Uri(ListView listView)
        {
            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(listView);
            if (selectedItem == null)
                return;

            using (UriDialog uriDialog = new UriDialog(_selectedLibrary, _selectedSlot, (Pkcs11ObjectInfo)selectedItem.Tag))
                uriDialog.ShowDialog();
        }

        private void ShowCertificateDetails()
        {
            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(ListViewCertificates);
            if (selectedItem == null)
                return;

            byte[] certData = ((Pkcs11CertificateInfo)selectedItem.Tag).CkaValue;
            using (CertificateDialog certificateDialog = new CertificateDialog(certData))
                certificateDialog.ShowDialog(this);
        }

        private void ExportListView(EnhancedListView listView, string fileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = fileName;

                saveFileDialog.Filter = "All files (*.*)|*.*|Text CSV (*.csv)|*.csv";
                saveFileDialog.FilterIndex = 2;

                saveFileDialog.AddExtension = true;
                saveFileDialog.CreatePrompt = false;
                saveFileDialog.OverwritePrompt = true;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    listView.ExportToCsvFile(saveFileDialog.FileName);
            }
        }

        private bool ImportDataObject()
        {
            // Let user select a file
            string filePath = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    filePath = openFileDialog.FileName;
            }

            if (string.IsNullOrEmpty(filePath))
                return false;

            // Read file content
            string fileName = Path.GetFileName(filePath);
            byte[] fileContent = File.ReadAllBytes(filePath);

            // Construct new object attributes
            List<Tuple<ObjectAttribute, ClassAttribute>> objectAttributes = _selectedSlot.ImportDataObject(fileName, fileContent);

            // Let user modify object attributes before the object is created
            return CreatePkcs11Object(objectAttributes);
        }

        private void ExportDataObject()
        {
            try
            {
                ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(ListViewDataObjects);
                if (selectedItem == null)
                    return;

                string fileName = null;
                byte[] fileContent = null;
                _selectedSlot.ExportDataObject((Pkcs11DataObjectInfo)selectedItem.Tag, out fileName, out fileContent);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = fileName;

                    saveFileDialog.Filter = "All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;

                    saveFileDialog.CreatePrompt = false;
                    saveFileDialog.OverwritePrompt = true;

                    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, fileContent);
                        WinFormsUtils.ShowInfo(this, "Data object successfully exported");
                    }
                }
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        #endregion

        #region Utils

        private string CheckSpecialTokenInfoValues(ulong ul, bool checkInfinite)
        {
            if (CK.IsCkInformationUnavailable(ul))
                return "information unavailable";

            if (checkInfinite && (ul == CK.CK_EFFECTIVELY_INFINITE))
                return "unlimited";

            return ul.ToString();
        }

        private string StorageSizeToString(ulong? storageSize)
        {
            return (storageSize == null) ? "-" : storageSize.ToString();
        }

        #endregion
    }
}

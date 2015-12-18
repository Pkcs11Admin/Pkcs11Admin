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

namespace Net.Pkcs11Admin.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainFormStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuItemApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLoadLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpenLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemApplicationSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemReloadLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRefreshSlot = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemApplicationSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCheckUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItemSlot = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemToken = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUserLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemProtectedUserLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSoLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemProtectedSoLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChangePin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUserChange = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemProtectedUserChange = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSoChange = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemProtectedSoChange = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTokenSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemInitToken = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTokenInit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemProtectedTokenInit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemInitPin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUserInit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemProtectedUserInit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectNewData = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectNewKey = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectNewCsr = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectNewCert = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectViewData = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectViewCert = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectImportData = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectImportCert = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectImportKey = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectExportData = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectExportCert = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemObjectExportKey = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCsvExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCsvExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCsvExportSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPkcs11Uri = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPkcs11UriEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPkcs11UriWithObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPkcs11UriWithoutObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormPanel = new System.Windows.Forms.Panel();
            this.MainFormTabControl = new System.Windows.Forms.TabControl();
            this.TabPageBasicInfo = new System.Windows.Forms.TabPage();
            this.ListViewBasicInfo = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.LabelBasicInfo = new System.Windows.Forms.Label();
            this.TabPageMechanisms = new System.Windows.Forms.TabPage();
            this.ListViewMechanisms = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.LabelMechanisms = new System.Windows.Forms.Label();
            this.TabPageHwFeatures = new System.Windows.Forms.TabPage();
            this.ListViewHwFeatures = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.LabelHwFeatures = new System.Windows.Forms.Label();
            this.TabPageDataObjects = new System.Windows.Forms.TabPage();
            this.ListViewDataObjects = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.LabelDataObjects = new System.Windows.Forms.Label();
            this.TabPageCertificates = new System.Windows.Forms.TabPage();
            this.ListViewCertificates = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.LabelCertificates = new System.Windows.Forms.Label();
            this.TabPageKeys = new System.Windows.Forms.TabPage();
            this.ListViewKeys = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.LabelKeys = new System.Windows.Forms.Label();
            this.TabPageDomainParams = new System.Windows.Forms.TabPage();
            this.ListViewDomainParams = new Net.Pkcs11Admin.WinForms.Controls.EnhancedListView();
            this.LabelDomainParams = new System.Windows.Forms.Label();
            this.MainFormStatusStrip.SuspendLayout();
            this.MainFormMenuStrip.SuspendLayout();
            this.MainFormPanel.SuspendLayout();
            this.MainFormTabControl.SuspendLayout();
            this.TabPageBasicInfo.SuspendLayout();
            this.TabPageMechanisms.SuspendLayout();
            this.TabPageHwFeatures.SuspendLayout();
            this.TabPageDataObjects.SuspendLayout();
            this.TabPageCertificates.SuspendLayout();
            this.TabPageKeys.SuspendLayout();
            this.TabPageDomainParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormStatusStrip
            // 
            this.MainFormStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainFormStatusStripLabel});
            this.MainFormStatusStrip.Location = new System.Drawing.Point(0, 439);
            this.MainFormStatusStrip.Name = "MainFormStatusStrip";
            this.MainFormStatusStrip.Size = new System.Drawing.Size(784, 22);
            this.MainFormStatusStrip.SizingGrip = false;
            this.MainFormStatusStrip.TabIndex = 3;
            // 
            // MainFormStatusStripLabel
            // 
            this.MainFormStatusStripLabel.Name = "MainFormStatusStripLabel";
            this.MainFormStatusStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MenuItemApplication
            // 
            this.MenuItemApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLoadLibrary,
            this.MenuItemOpenLogFile,
            this.MenuItemApplicationSeparator1,
            this.MenuItemReloadLibrary,
            this.MenuItemRefreshSlot,
            this.MenuItemApplicationSeparator2,
            this.MenuItemExit});
            this.MenuItemApplication.Name = "MenuItemApplication";
            this.MenuItemApplication.Size = new System.Drawing.Size(80, 20);
            this.MenuItemApplication.Text = "Application";
            // 
            // MenuItemLoadLibrary
            // 
            this.MenuItemLoadLibrary.Name = "MenuItemLoadLibrary";
            this.MenuItemLoadLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemLoadLibrary.Size = new System.Drawing.Size(242, 22);
            this.MenuItemLoadLibrary.Text = "Load PKCS#11 library...";
            this.MenuItemLoadLibrary.Click += new System.EventHandler(this.MenuItemLoadLibrary_Click);
            // 
            // MenuItemOpenLogFile
            // 
            this.MenuItemOpenLogFile.Name = "MenuItemOpenLogFile";
            this.MenuItemOpenLogFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.MenuItemOpenLogFile.Size = new System.Drawing.Size(242, 22);
            this.MenuItemOpenLogFile.Text = "Open log file...";
            this.MenuItemOpenLogFile.Click += new System.EventHandler(this.MenuItemOpenLogFile_Click);
            // 
            // MenuItemApplicationSeparator1
            // 
            this.MenuItemApplicationSeparator1.Name = "MenuItemApplicationSeparator1";
            this.MenuItemApplicationSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // MenuItemReloadLibrary
            // 
            this.MenuItemReloadLibrary.Name = "MenuItemReloadLibrary";
            this.MenuItemReloadLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.MenuItemReloadLibrary.Size = new System.Drawing.Size(242, 22);
            this.MenuItemReloadLibrary.Text = "Reload PKCS#11 library";
            this.MenuItemReloadLibrary.Click += new System.EventHandler(this.MenuItemReloadLibrary_Click);
            // 
            // MenuItemRefreshSlot
            // 
            this.MenuItemRefreshSlot.Name = "MenuItemRefreshSlot";
            this.MenuItemRefreshSlot.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MenuItemRefreshSlot.Size = new System.Drawing.Size(242, 22);
            this.MenuItemRefreshSlot.Text = "Refresh selected slot";
            this.MenuItemRefreshSlot.Click += new System.EventHandler(this.MenuItemRefreshSlot_Click);
            // 
            // MenuItemApplicationSeparator2
            // 
            this.MenuItemApplicationSeparator2.Name = "MenuItemApplicationSeparator2";
            this.MenuItemApplicationSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.MenuItemExit.Size = new System.Drawing.Size(242, 22);
            this.MenuItemExit.Text = "Exit";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCheckUpdates,
            this.MenuItemAbout});
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuItemHelp.Text = "Help";
            // 
            // MenuItemCheckUpdates
            // 
            this.MenuItemCheckUpdates.Name = "MenuItemCheckUpdates";
            this.MenuItemCheckUpdates.Size = new System.Drawing.Size(170, 22);
            this.MenuItemCheckUpdates.Text = "Check for updates";
            this.MenuItemCheckUpdates.Click += new System.EventHandler(this.MenuItemCheckUpdates_Click);
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.Size = new System.Drawing.Size(170, 22);
            this.MenuItemAbout.Text = "About...";
            this.MenuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemApplication,
            this.MenuItemSlot,
            this.MenuItemToken,
            this.MenuItemObject,
            this.MenuItemTools,
            this.MenuItemHelp});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MainFormMenuStrip.TabIndex = 2;
            // 
            // MenuItemSlot
            // 
            this.MenuItemSlot.Name = "MenuItemSlot";
            this.MenuItemSlot.Size = new System.Drawing.Size(39, 20);
            this.MenuItemSlot.Text = "Slot";
            // 
            // MenuItemToken
            // 
            this.MenuItemToken.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLogin,
            this.MenuItemLogout,
            this.MenuItemChangePin,
            this.MenuItemTokenSeparator1,
            this.MenuItemInitToken,
            this.MenuItemInitPin});
            this.MenuItemToken.Name = "MenuItemToken";
            this.MenuItemToken.Size = new System.Drawing.Size(52, 20);
            this.MenuItemToken.Text = "Token";
            // 
            // MenuItemLogin
            // 
            this.MenuItemLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUserLogin,
            this.MenuItemProtectedUserLogin,
            this.MenuItemSoLogin,
            this.MenuItemProtectedSoLogin});
            this.MenuItemLogin.Name = "MenuItemLogin";
            this.MenuItemLogin.Size = new System.Drawing.Size(187, 22);
            this.MenuItemLogin.Text = "Login";
            // 
            // MenuItemUserLogin
            // 
            this.MenuItemUserLogin.Name = "MenuItemUserLogin";
            this.MenuItemUserLogin.Size = new System.Drawing.Size(189, 22);
            this.MenuItemUserLogin.Text = "User login...";
            this.MenuItemUserLogin.Click += new System.EventHandler(this.MenuItemUserLogin_Click);
            // 
            // MenuItemProtectedUserLogin
            // 
            this.MenuItemProtectedUserLogin.Name = "MenuItemProtectedUserLogin";
            this.MenuItemProtectedUserLogin.Size = new System.Drawing.Size(189, 22);
            this.MenuItemProtectedUserLogin.Text = "Protected user login...";
            this.MenuItemProtectedUserLogin.Click += new System.EventHandler(this.MenuItemProtectedUserLogin_Click);
            // 
            // MenuItemSoLogin
            // 
            this.MenuItemSoLogin.Name = "MenuItemSoLogin";
            this.MenuItemSoLogin.Size = new System.Drawing.Size(189, 22);
            this.MenuItemSoLogin.Text = "SO login...";
            this.MenuItemSoLogin.Click += new System.EventHandler(this.MenuItemSoLogin_Click);
            // 
            // MenuItemProtectedSoLogin
            // 
            this.MenuItemProtectedSoLogin.Name = "MenuItemProtectedSoLogin";
            this.MenuItemProtectedSoLogin.Size = new System.Drawing.Size(189, 22);
            this.MenuItemProtectedSoLogin.Text = "Protected SO login...";
            this.MenuItemProtectedSoLogin.Click += new System.EventHandler(this.MenuItemProtectedSoLogin_Click);
            // 
            // MenuItemLogout
            // 
            this.MenuItemLogout.Name = "MenuItemLogout";
            this.MenuItemLogout.Size = new System.Drawing.Size(187, 22);
            this.MenuItemLogout.Text = "Logout";
            this.MenuItemLogout.Click += new System.EventHandler(this.MenuItemLogout_Click);
            // 
            // MenuItemChangePin
            // 
            this.MenuItemChangePin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUserChange,
            this.MenuItemProtectedUserChange,
            this.MenuItemSoChange,
            this.MenuItemProtectedSoChange});
            this.MenuItemChangePin.Name = "MenuItemChangePin";
            this.MenuItemChangePin.Size = new System.Drawing.Size(187, 22);
            this.MenuItemChangePin.Text = "Change PIN";
            // 
            // MenuItemUserChange
            // 
            this.MenuItemUserChange.Name = "MenuItemUserChange";
            this.MenuItemUserChange.Size = new System.Drawing.Size(223, 22);
            this.MenuItemUserChange.Text = "User PIN change...";
            this.MenuItemUserChange.Click += new System.EventHandler(this.MenuItemUserChange_Click);
            // 
            // MenuItemProtectedUserChange
            // 
            this.MenuItemProtectedUserChange.Name = "MenuItemProtectedUserChange";
            this.MenuItemProtectedUserChange.Size = new System.Drawing.Size(223, 22);
            this.MenuItemProtectedUserChange.Text = "Protected user PIN change...";
            this.MenuItemProtectedUserChange.Click += new System.EventHandler(this.MenuItemProtectedUserChange_Click);
            // 
            // MenuItemSoChange
            // 
            this.MenuItemSoChange.Name = "MenuItemSoChange";
            this.MenuItemSoChange.Size = new System.Drawing.Size(223, 22);
            this.MenuItemSoChange.Text = "SO PIN change...";
            this.MenuItemSoChange.Click += new System.EventHandler(this.MenuItemSoChange_Click);
            // 
            // MenuItemProtectedSoChange
            // 
            this.MenuItemProtectedSoChange.Name = "MenuItemProtectedSoChange";
            this.MenuItemProtectedSoChange.Size = new System.Drawing.Size(223, 22);
            this.MenuItemProtectedSoChange.Text = "Protected SO PIN change...";
            this.MenuItemProtectedSoChange.Click += new System.EventHandler(this.MenuItemProtectedSoChange_Click);
            // 
            // MenuItemTokenSeparator1
            // 
            this.MenuItemTokenSeparator1.Name = "MenuItemTokenSeparator1";
            this.MenuItemTokenSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // MenuItemInitToken
            // 
            this.MenuItemInitToken.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTokenInit,
            this.MenuItemProtectedTokenInit});
            this.MenuItemInitToken.Name = "MenuItemInitToken";
            this.MenuItemInitToken.Size = new System.Drawing.Size(187, 22);
            this.MenuItemInitToken.Text = "Initialize token";
            // 
            // MenuItemTokenInit
            // 
            this.MenuItemTokenInit.Name = "MenuItemTokenInit";
            this.MenuItemTokenInit.Size = new System.Drawing.Size(234, 22);
            this.MenuItemTokenInit.Text = "Token initialization...";
            this.MenuItemTokenInit.Click += new System.EventHandler(this.MenuItemTokenInit_Click);
            // 
            // MenuItemProtectedTokenInit
            // 
            this.MenuItemProtectedTokenInit.Name = "MenuItemProtectedTokenInit";
            this.MenuItemProtectedTokenInit.Size = new System.Drawing.Size(234, 22);
            this.MenuItemProtectedTokenInit.Text = "Protected token initialization...";
            this.MenuItemProtectedTokenInit.Click += new System.EventHandler(this.MenuItemProtectedTokenInit_Click);
            // 
            // MenuItemInitPin
            // 
            this.MenuItemInitPin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUserInit,
            this.MenuItemProtectedUserInit});
            this.MenuItemInitPin.Name = "MenuItemInitPin";
            this.MenuItemInitPin.Size = new System.Drawing.Size(187, 22);
            this.MenuItemInitPin.Text = "Initialize/unblock PIN";
            // 
            // MenuItemUserInit
            // 
            this.MenuItemUserInit.Name = "MenuItemUserInit";
            this.MenuItemUserInit.Size = new System.Drawing.Size(245, 22);
            this.MenuItemUserInit.Text = "User PIN initialization...";
            this.MenuItemUserInit.Click += new System.EventHandler(this.MenuItemUserInit_Click);
            // 
            // MenuItemProtectedUserInit
            // 
            this.MenuItemProtectedUserInit.Name = "MenuItemProtectedUserInit";
            this.MenuItemProtectedUserInit.Size = new System.Drawing.Size(245, 22);
            this.MenuItemProtectedUserInit.Text = "Protected user PIN initialization..";
            this.MenuItemProtectedUserInit.Click += new System.EventHandler(this.MenuItemProtectedUserInit_Click);
            // 
            // MenuItemObject
            // 
            this.MenuItemObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemObjectNew,
            this.MenuItemObjectEdit,
            this.MenuItemObjectDelete,
            this.MenuItemObjectView,
            this.MenuItemObjectImport,
            this.MenuItemObjectExport});
            this.MenuItemObject.Name = "MenuItemObject";
            this.MenuItemObject.Size = new System.Drawing.Size(54, 20);
            this.MenuItemObject.Text = "Object";
            // 
            // MenuItemObjectNew
            // 
            this.MenuItemObjectNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemObjectNewData,
            this.MenuItemObjectNewKey,
            this.MenuItemObjectNewCsr,
            this.MenuItemObjectNewCert});
            this.MenuItemObjectNew.Name = "MenuItemObjectNew";
            this.MenuItemObjectNew.Size = new System.Drawing.Size(110, 22);
            this.MenuItemObjectNew.Text = "New";
            // 
            // MenuItemObjectNewData
            // 
            this.MenuItemObjectNewData.Name = "MenuItemObjectNewData";
            this.MenuItemObjectNewData.Size = new System.Drawing.Size(221, 22);
            this.MenuItemObjectNewData.Text = "Data object...";
            this.MenuItemObjectNewData.Click += new System.EventHandler(this.MenuItemObjectNewData_Click);
            // 
            // MenuItemObjectNewKey
            // 
            this.MenuItemObjectNewKey.Name = "MenuItemObjectNewKey";
            this.MenuItemObjectNewKey.Size = new System.Drawing.Size(221, 22);
            this.MenuItemObjectNewKey.Text = "Key...";
            this.MenuItemObjectNewKey.Click += new System.EventHandler(this.MenuItemObjectNewKey_Click);
            // 
            // MenuItemObjectNewCsr
            // 
            this.MenuItemObjectNewCsr.Name = "MenuItemObjectNewCsr";
            this.MenuItemObjectNewCsr.Size = new System.Drawing.Size(221, 22);
            this.MenuItemObjectNewCsr.Text = "Certificate signing request...";
            this.MenuItemObjectNewCsr.Click += new System.EventHandler(this.MenuItemObjectNewCsr_Click);
            // 
            // MenuItemObjectNewCert
            // 
            this.MenuItemObjectNewCert.Name = "MenuItemObjectNewCert";
            this.MenuItemObjectNewCert.Size = new System.Drawing.Size(221, 22);
            this.MenuItemObjectNewCert.Text = "Self-signed certificate...";
            this.MenuItemObjectNewCert.Click += new System.EventHandler(this.MenuItemObjectNewCert_Click);
            // 
            // MenuItemObjectEdit
            // 
            this.MenuItemObjectEdit.Name = "MenuItemObjectEdit";
            this.MenuItemObjectEdit.Size = new System.Drawing.Size(110, 22);
            this.MenuItemObjectEdit.Text = "Edit...";
            this.MenuItemObjectEdit.Click += new System.EventHandler(this.MenuItemObjectEdit_Click);
            // 
            // MenuItemObjectDelete
            // 
            this.MenuItemObjectDelete.Name = "MenuItemObjectDelete";
            this.MenuItemObjectDelete.Size = new System.Drawing.Size(110, 22);
            this.MenuItemObjectDelete.Text = "Delete";
            this.MenuItemObjectDelete.Click += new System.EventHandler(this.MenuItemObjectDelete_Click);
            // 
            // MenuItemObjectView
            // 
            this.MenuItemObjectView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemObjectViewData,
            this.MenuItemObjectViewCert});
            this.MenuItemObjectView.Name = "MenuItemObjectView";
            this.MenuItemObjectView.Size = new System.Drawing.Size(110, 22);
            this.MenuItemObjectView.Text = "View";
            // 
            // MenuItemObjectViewData
            // 
            this.MenuItemObjectViewData.Name = "MenuItemObjectViewData";
            this.MenuItemObjectViewData.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectViewData.Text = "Data object...";
            this.MenuItemObjectViewData.Click += new System.EventHandler(this.MenuItemObjectViewData_Click);
            // 
            // MenuItemObjectViewCert
            // 
            this.MenuItemObjectViewCert.Name = "MenuItemObjectViewCert";
            this.MenuItemObjectViewCert.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectViewCert.Text = "Certificate...";
            this.MenuItemObjectViewCert.Click += new System.EventHandler(this.MenuItemObjectViewCert_Click);
            // 
            // MenuItemObjectImport
            // 
            this.MenuItemObjectImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemObjectImportData,
            this.MenuItemObjectImportCert,
            this.MenuItemObjectImportKey});
            this.MenuItemObjectImport.Name = "MenuItemObjectImport";
            this.MenuItemObjectImport.Size = new System.Drawing.Size(110, 22);
            this.MenuItemObjectImport.Text = "Import";
            // 
            // MenuItemObjectImportData
            // 
            this.MenuItemObjectImportData.Name = "MenuItemObjectImportData";
            this.MenuItemObjectImportData.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectImportData.Text = "Data object...";
            this.MenuItemObjectImportData.Click += new System.EventHandler(this.MenuItemObjectImportData_Click);
            // 
            // MenuItemObjectImportCert
            // 
            this.MenuItemObjectImportCert.Name = "MenuItemObjectImportCert";
            this.MenuItemObjectImportCert.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectImportCert.Text = "Certificate...";
            this.MenuItemObjectImportCert.Click += new System.EventHandler(this.MenuItemObjectImportCert_Click);
            // 
            // MenuItemObjectImportKey
            // 
            this.MenuItemObjectImportKey.Name = "MenuItemObjectImportKey";
            this.MenuItemObjectImportKey.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectImportKey.Text = "Key...";
            this.MenuItemObjectImportKey.Click += new System.EventHandler(this.MenuItemObjectImportKey_Click);
            // 
            // MenuItemObjectExport
            // 
            this.MenuItemObjectExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemObjectExportData,
            this.MenuItemObjectExportCert,
            this.MenuItemObjectExportKey});
            this.MenuItemObjectExport.Name = "MenuItemObjectExport";
            this.MenuItemObjectExport.Size = new System.Drawing.Size(110, 22);
            this.MenuItemObjectExport.Text = "Export";
            // 
            // MenuItemObjectExportData
            // 
            this.MenuItemObjectExportData.Name = "MenuItemObjectExportData";
            this.MenuItemObjectExportData.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectExportData.Text = "Data object...";
            this.MenuItemObjectExportData.Click += new System.EventHandler(this.MenuItemObjectExportData_Click);
            // 
            // MenuItemObjectExportCert
            // 
            this.MenuItemObjectExportCert.Name = "MenuItemObjectExportCert";
            this.MenuItemObjectExportCert.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectExportCert.Text = "Certificate...";
            this.MenuItemObjectExportCert.Click += new System.EventHandler(this.MenuItemObjectExportCert_Click);
            // 
            // MenuItemObjectExportKey
            // 
            this.MenuItemObjectExportKey.Name = "MenuItemObjectExportKey";
            this.MenuItemObjectExportKey.Size = new System.Drawing.Size(143, 22);
            this.MenuItemObjectExportKey.Text = "Key...";
            this.MenuItemObjectExportKey.Click += new System.EventHandler(this.MenuItemObjectExportKey_Click);
            // 
            // MenuItemTools
            // 
            this.MenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCsvExport,
            this.MenuItemPkcs11Uri});
            this.MenuItemTools.Name = "MenuItemTools";
            this.MenuItemTools.Size = new System.Drawing.Size(48, 20);
            this.MenuItemTools.Text = "Tools";
            // 
            // MenuItemCsvExport
            // 
            this.MenuItemCsvExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCsvExportAll,
            this.MenuItemCsvExportSelected});
            this.MenuItemCsvExport.Name = "MenuItemCsvExport";
            this.MenuItemCsvExport.Size = new System.Drawing.Size(172, 22);
            this.MenuItemCsvExport.Text = "Export to CSV";
            // 
            // MenuItemCsvExportAll
            // 
            this.MenuItemCsvExportAll.Name = "MenuItemCsvExportAll";
            this.MenuItemCsvExportAll.Size = new System.Drawing.Size(159, 22);
            this.MenuItemCsvExportAll.Text = "All items...";
            this.MenuItemCsvExportAll.Click += new System.EventHandler(this.MenuItemCsvExportAll_Click);
            // 
            // MenuItemCsvExportSelected
            // 
            this.MenuItemCsvExportSelected.Name = "MenuItemCsvExportSelected";
            this.MenuItemCsvExportSelected.Size = new System.Drawing.Size(159, 22);
            this.MenuItemCsvExportSelected.Text = "Selected items...";
            this.MenuItemCsvExportSelected.Click += new System.EventHandler(this.MenuItemCsvExportSelected_Click);
            // 
            // MenuItemPkcs11Uri
            // 
            this.MenuItemPkcs11Uri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemPkcs11UriEmpty,
            this.MenuItemPkcs11UriWithObject,
            this.MenuItemPkcs11UriWithoutObject});
            this.MenuItemPkcs11Uri.Name = "MenuItemPkcs11Uri";
            this.MenuItemPkcs11Uri.Size = new System.Drawing.Size(172, 22);
            this.MenuItemPkcs11Uri.Text = "Build PKCS#11 URI";
            // 
            // MenuItemPkcs11UriEmpty
            // 
            this.MenuItemPkcs11UriEmpty.Name = "MenuItemPkcs11UriEmpty";
            this.MenuItemPkcs11UriEmpty.Size = new System.Drawing.Size(208, 22);
            this.MenuItemPkcs11UriEmpty.Text = "Empty...";
            this.MenuItemPkcs11UriEmpty.Click += new System.EventHandler(this.MenuItemPkcs11UriEmpty_Click);
            // 
            // MenuItemPkcs11UriWithObject
            // 
            this.MenuItemPkcs11UriWithObject.Name = "MenuItemPkcs11UriWithObject";
            this.MenuItemPkcs11UriWithObject.Size = new System.Drawing.Size(208, 22);
            this.MenuItemPkcs11UriWithObject.Text = "With selected object...";
            this.MenuItemPkcs11UriWithObject.Click += new System.EventHandler(this.MenuItemPkcs11UriWithObject_Click);
            // 
            // MenuItemPkcs11UriWithoutObject
            // 
            this.MenuItemPkcs11UriWithoutObject.Name = "MenuItemPkcs11UriWithoutObject";
            this.MenuItemPkcs11UriWithoutObject.Size = new System.Drawing.Size(208, 22);
            this.MenuItemPkcs11UriWithoutObject.Text = "Without selected object...";
            this.MenuItemPkcs11UriWithoutObject.Click += new System.EventHandler(this.MenuItemPkcs11UriWithoutObject_Click);
            // 
            // MainFormPanel
            // 
            this.MainFormPanel.Controls.Add(this.MainFormTabControl);
            this.MainFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormPanel.Location = new System.Drawing.Point(0, 24);
            this.MainFormPanel.Name = "MainFormPanel";
            this.MainFormPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainFormPanel.Size = new System.Drawing.Size(784, 415);
            this.MainFormPanel.TabIndex = 2;
            // 
            // MainFormTabControl
            // 
            this.MainFormTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainFormTabControl.Controls.Add(this.TabPageBasicInfo);
            this.MainFormTabControl.Controls.Add(this.TabPageMechanisms);
            this.MainFormTabControl.Controls.Add(this.TabPageHwFeatures);
            this.MainFormTabControl.Controls.Add(this.TabPageDataObjects);
            this.MainFormTabControl.Controls.Add(this.TabPageCertificates);
            this.MainFormTabControl.Controls.Add(this.TabPageKeys);
            this.MainFormTabControl.Controls.Add(this.TabPageDomainParams);
            this.MainFormTabControl.Location = new System.Drawing.Point(12, 13);
            this.MainFormTabControl.Name = "MainFormTabControl";
            this.MainFormTabControl.SelectedIndex = 0;
            this.MainFormTabControl.Size = new System.Drawing.Size(758, 389);
            this.MainFormTabControl.TabIndex = 1;
            this.MainFormTabControl.SelectedIndexChanged += new System.EventHandler(this.MainFormTabControl_SelectedIndexChanged);
            // 
            // TabPageBasicInfo
            // 
            this.TabPageBasicInfo.Controls.Add(this.ListViewBasicInfo);
            this.TabPageBasicInfo.Controls.Add(this.LabelBasicInfo);
            this.TabPageBasicInfo.Location = new System.Drawing.Point(4, 22);
            this.TabPageBasicInfo.Name = "TabPageBasicInfo";
            this.TabPageBasicInfo.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageBasicInfo.Size = new System.Drawing.Size(750, 363);
            this.TabPageBasicInfo.TabIndex = 7;
            this.TabPageBasicInfo.Text = "Basic info";
            this.TabPageBasicInfo.UseVisualStyleBackColor = true;
            // 
            // ListViewBasicInfo
            // 
            this.ListViewBasicInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewBasicInfo.FullRowSelect = true;
            this.ListViewBasicInfo.HideSelection = false;
            this.ListViewBasicInfo.Location = new System.Drawing.Point(13, 26);
            this.ListViewBasicInfo.Name = "ListViewBasicInfo";
            this.ListViewBasicInfo.Size = new System.Drawing.Size(724, 324);
            this.ListViewBasicInfo.Sortable = true;
            this.ListViewBasicInfo.TabIndex = 1;
            this.ListViewBasicInfo.UseCompatibleStateImageBehavior = false;
            this.ListViewBasicInfo.View = System.Windows.Forms.View.Details;
            // 
            // LabelBasicInfo
            // 
            this.LabelBasicInfo.AutoSize = true;
            this.LabelBasicInfo.Location = new System.Drawing.Point(10, 10);
            this.LabelBasicInfo.Name = "LabelBasicInfo";
            this.LabelBasicInfo.Size = new System.Drawing.Size(273, 13);
            this.LabelBasicInfo.TabIndex = 0;
            this.LabelBasicInfo.Text = "Basic information about PKCS#11 library, slot and token:";
            // 
            // TabPageMechanisms
            // 
            this.TabPageMechanisms.Controls.Add(this.ListViewMechanisms);
            this.TabPageMechanisms.Controls.Add(this.LabelMechanisms);
            this.TabPageMechanisms.Location = new System.Drawing.Point(4, 22);
            this.TabPageMechanisms.Name = "TabPageMechanisms";
            this.TabPageMechanisms.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageMechanisms.Size = new System.Drawing.Size(750, 363);
            this.TabPageMechanisms.TabIndex = 0;
            this.TabPageMechanisms.Text = "Mechanisms";
            this.TabPageMechanisms.UseVisualStyleBackColor = true;
            // 
            // ListViewMechanisms
            // 
            this.ListViewMechanisms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewMechanisms.FullRowSelect = true;
            this.ListViewMechanisms.HideSelection = false;
            this.ListViewMechanisms.Location = new System.Drawing.Point(13, 26);
            this.ListViewMechanisms.Name = "ListViewMechanisms";
            this.ListViewMechanisms.Size = new System.Drawing.Size(724, 324);
            this.ListViewMechanisms.Sortable = true;
            this.ListViewMechanisms.TabIndex = 0;
            this.ListViewMechanisms.UseCompatibleStateImageBehavior = false;
            this.ListViewMechanisms.View = System.Windows.Forms.View.Details;
            // 
            // LabelMechanisms
            // 
            this.LabelMechanisms.AutoSize = true;
            this.LabelMechanisms.Location = new System.Drawing.Point(10, 10);
            this.LabelMechanisms.Name = "LabelMechanisms";
            this.LabelMechanisms.Size = new System.Drawing.Size(281, 13);
            this.LabelMechanisms.TabIndex = 1;
            this.LabelMechanisms.Text = "These mechanisms are supported by the PKCS#11 library:";
            // 
            // TabPageHwFeatures
            // 
            this.TabPageHwFeatures.Controls.Add(this.ListViewHwFeatures);
            this.TabPageHwFeatures.Controls.Add(this.LabelHwFeatures);
            this.TabPageHwFeatures.Location = new System.Drawing.Point(4, 22);
            this.TabPageHwFeatures.Name = "TabPageHwFeatures";
            this.TabPageHwFeatures.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageHwFeatures.Size = new System.Drawing.Size(750, 363);
            this.TabPageHwFeatures.TabIndex = 1;
            this.TabPageHwFeatures.Text = "HW features";
            this.TabPageHwFeatures.UseVisualStyleBackColor = true;
            // 
            // ListViewHwFeatures
            // 
            this.ListViewHwFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewHwFeatures.FullRowSelect = true;
            this.ListViewHwFeatures.HideSelection = false;
            this.ListViewHwFeatures.Location = new System.Drawing.Point(13, 26);
            this.ListViewHwFeatures.Name = "ListViewHwFeatures";
            this.ListViewHwFeatures.Size = new System.Drawing.Size(724, 324);
            this.ListViewHwFeatures.Sortable = true;
            this.ListViewHwFeatures.TabIndex = 1;
            this.ListViewHwFeatures.UseCompatibleStateImageBehavior = false;
            this.ListViewHwFeatures.View = System.Windows.Forms.View.Details;
            // 
            // LabelHwFeatures
            // 
            this.LabelHwFeatures.AutoSize = true;
            this.LabelHwFeatures.Location = new System.Drawing.Point(10, 10);
            this.LabelHwFeatures.Name = "LabelHwFeatures";
            this.LabelHwFeatures.Size = new System.Drawing.Size(216, 13);
            this.LabelHwFeatures.TabIndex = 0;
            this.LabelHwFeatures.Text = "These hardware feature objects were found:";
            // 
            // TabPageDataObjects
            // 
            this.TabPageDataObjects.Controls.Add(this.ListViewDataObjects);
            this.TabPageDataObjects.Controls.Add(this.LabelDataObjects);
            this.TabPageDataObjects.Location = new System.Drawing.Point(4, 22);
            this.TabPageDataObjects.Name = "TabPageDataObjects";
            this.TabPageDataObjects.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageDataObjects.Size = new System.Drawing.Size(750, 363);
            this.TabPageDataObjects.TabIndex = 2;
            this.TabPageDataObjects.Text = "Data objects";
            this.TabPageDataObjects.UseVisualStyleBackColor = true;
            // 
            // ListViewDataObjects
            // 
            this.ListViewDataObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewDataObjects.FullRowSelect = true;
            this.ListViewDataObjects.HideSelection = false;
            this.ListViewDataObjects.Location = new System.Drawing.Point(13, 26);
            this.ListViewDataObjects.Name = "ListViewDataObjects";
            this.ListViewDataObjects.Size = new System.Drawing.Size(724, 324);
            this.ListViewDataObjects.Sortable = true;
            this.ListViewDataObjects.TabIndex = 1;
            this.ListViewDataObjects.UseCompatibleStateImageBehavior = false;
            this.ListViewDataObjects.View = System.Windows.Forms.View.Details;
            // 
            // LabelDataObjects
            // 
            this.LabelDataObjects.AutoSize = true;
            this.LabelDataObjects.Location = new System.Drawing.Point(10, 10);
            this.LabelDataObjects.Name = "LabelDataObjects";
            this.LabelDataObjects.Size = new System.Drawing.Size(157, 13);
            this.LabelDataObjects.TabIndex = 0;
            this.LabelDataObjects.Text = "These data objects were found:";
            // 
            // TabPageCertificates
            // 
            this.TabPageCertificates.Controls.Add(this.ListViewCertificates);
            this.TabPageCertificates.Controls.Add(this.LabelCertificates);
            this.TabPageCertificates.Location = new System.Drawing.Point(4, 22);
            this.TabPageCertificates.Name = "TabPageCertificates";
            this.TabPageCertificates.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageCertificates.Size = new System.Drawing.Size(750, 363);
            this.TabPageCertificates.TabIndex = 5;
            this.TabPageCertificates.Text = "Certificates";
            this.TabPageCertificates.UseVisualStyleBackColor = true;
            // 
            // ListViewCertificates
            // 
            this.ListViewCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewCertificates.FullRowSelect = true;
            this.ListViewCertificates.HideSelection = false;
            this.ListViewCertificates.Location = new System.Drawing.Point(13, 26);
            this.ListViewCertificates.Name = "ListViewCertificates";
            this.ListViewCertificates.Size = new System.Drawing.Size(724, 324);
            this.ListViewCertificates.Sortable = true;
            this.ListViewCertificates.TabIndex = 1;
            this.ListViewCertificates.UseCompatibleStateImageBehavior = false;
            this.ListViewCertificates.View = System.Windows.Forms.View.Details;
            // 
            // LabelCertificates
            // 
            this.LabelCertificates.AutoSize = true;
            this.LabelCertificates.Location = new System.Drawing.Point(10, 10);
            this.LabelCertificates.Name = "LabelCertificates";
            this.LabelCertificates.Size = new System.Drawing.Size(182, 13);
            this.LabelCertificates.TabIndex = 0;
            this.LabelCertificates.Text = "These certificate objects were found:";
            // 
            // TabPageKeys
            // 
            this.TabPageKeys.Controls.Add(this.ListViewKeys);
            this.TabPageKeys.Controls.Add(this.LabelKeys);
            this.TabPageKeys.Location = new System.Drawing.Point(4, 22);
            this.TabPageKeys.Name = "TabPageKeys";
            this.TabPageKeys.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageKeys.Size = new System.Drawing.Size(750, 363);
            this.TabPageKeys.TabIndex = 3;
            this.TabPageKeys.Text = "Keys";
            this.TabPageKeys.UseVisualStyleBackColor = true;
            // 
            // ListViewKeys
            // 
            this.ListViewKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewKeys.FullRowSelect = true;
            this.ListViewKeys.HideSelection = false;
            this.ListViewKeys.Location = new System.Drawing.Point(13, 26);
            this.ListViewKeys.Name = "ListViewKeys";
            this.ListViewKeys.Size = new System.Drawing.Size(724, 324);
            this.ListViewKeys.Sortable = true;
            this.ListViewKeys.TabIndex = 1;
            this.ListViewKeys.UseCompatibleStateImageBehavior = false;
            this.ListViewKeys.View = System.Windows.Forms.View.Details;
            // 
            // LabelKeys
            // 
            this.LabelKeys.AutoSize = true;
            this.LabelKeys.Location = new System.Drawing.Point(10, 10);
            this.LabelKeys.Name = "LabelKeys";
            this.LabelKeys.Size = new System.Drawing.Size(153, 13);
            this.LabelKeys.TabIndex = 0;
            this.LabelKeys.Text = "These key objects were found:";
            // 
            // TabPageDomainParams
            // 
            this.TabPageDomainParams.Controls.Add(this.ListViewDomainParams);
            this.TabPageDomainParams.Controls.Add(this.LabelDomainParams);
            this.TabPageDomainParams.Location = new System.Drawing.Point(4, 22);
            this.TabPageDomainParams.Name = "TabPageDomainParams";
            this.TabPageDomainParams.Padding = new System.Windows.Forms.Padding(10);
            this.TabPageDomainParams.Size = new System.Drawing.Size(750, 363);
            this.TabPageDomainParams.TabIndex = 8;
            this.TabPageDomainParams.Text = "Domain params";
            this.TabPageDomainParams.UseVisualStyleBackColor = true;
            // 
            // ListViewDomainParams
            // 
            this.ListViewDomainParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewDomainParams.HideSelection = false;
            this.ListViewDomainParams.Location = new System.Drawing.Point(13, 26);
            this.ListViewDomainParams.Name = "ListViewDomainParams";
            this.ListViewDomainParams.Size = new System.Drawing.Size(724, 324);
            this.ListViewDomainParams.Sortable = true;
            this.ListViewDomainParams.TabIndex = 1;
            this.ListViewDomainParams.UseCompatibleStateImageBehavior = false;
            this.ListViewDomainParams.View = System.Windows.Forms.View.Details;
            // 
            // LabelDomainParams
            // 
            this.LabelDomainParams.AutoSize = true;
            this.LabelDomainParams.Location = new System.Drawing.Point(10, 10);
            this.LabelDomainParams.Name = "LabelDomainParams";
            this.LabelDomainParams.Size = new System.Drawing.Size(225, 13);
            this.LabelDomainParams.TabIndex = 0;
            this.LabelDomainParams.Text = "These domain parameters objects were found:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.MainFormPanel);
            this.Controls.Add(this.MainFormStatusStrip);
            this.Controls.Add(this.MainFormMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MainFormStatusStrip.ResumeLayout(false);
            this.MainFormStatusStrip.PerformLayout();
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.MainFormPanel.ResumeLayout(false);
            this.MainFormTabControl.ResumeLayout(false);
            this.TabPageBasicInfo.ResumeLayout(false);
            this.TabPageBasicInfo.PerformLayout();
            this.TabPageMechanisms.ResumeLayout(false);
            this.TabPageMechanisms.PerformLayout();
            this.TabPageHwFeatures.ResumeLayout(false);
            this.TabPageHwFeatures.PerformLayout();
            this.TabPageDataObjects.ResumeLayout(false);
            this.TabPageDataObjects.PerformLayout();
            this.TabPageCertificates.ResumeLayout(false);
            this.TabPageCertificates.PerformLayout();
            this.TabPageKeys.ResumeLayout(false);
            this.TabPageKeys.PerformLayout();
            this.TabPageDomainParams.ResumeLayout(false);
            this.TabPageDomainParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MainFormStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItemApplication;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.MenuStrip MainFormMenuStrip;
        private System.Windows.Forms.Panel MainFormPanel;
        private System.Windows.Forms.TabControl MainFormTabControl;
        private System.Windows.Forms.TabPage TabPageBasicInfo;
        private System.Windows.Forms.TabPage TabPageMechanisms;
        private System.Windows.Forms.TabPage TabPageHwFeatures;
        private System.Windows.Forms.TabPage TabPageDataObjects;
        private System.Windows.Forms.TabPage TabPageKeys;
        private System.Windows.Forms.TabPage TabPageCertificates;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLoadLibrary;
        private System.Windows.Forms.ToolStripSeparator MenuItemApplicationSeparator2;
        private Net.Pkcs11Admin.WinForms.Controls.EnhancedListView ListViewBasicInfo;
        private System.Windows.Forms.Label LabelBasicInfo;
        private System.Windows.Forms.Label LabelMechanisms;
        private Controls.EnhancedListView ListViewMechanisms;
        private System.Windows.Forms.Label LabelHwFeatures;
        private System.Windows.Forms.Label LabelDataObjects;
        private System.Windows.Forms.Label LabelKeys;
        private System.Windows.Forms.Label LabelCertificates;
        private Net.Pkcs11Admin.WinForms.Controls.EnhancedListView ListViewHwFeatures;
        private Net.Pkcs11Admin.WinForms.Controls.EnhancedListView ListViewDataObjects;
        private Net.Pkcs11Admin.WinForms.Controls.EnhancedListView ListViewKeys;
        private Net.Pkcs11Admin.WinForms.Controls.EnhancedListView ListViewCertificates;
        private System.Windows.Forms.ToolStripMenuItem MenuItemToken;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLogin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLogout;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChangePin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInitPin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUserLogin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProtectedUserLogin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSoLogin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProtectedSoLogin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUserChange;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProtectedUserChange;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSoChange;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProtectedSoChange;
        private System.Windows.Forms.ToolStripSeparator MenuItemTokenSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInitToken;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTokenInit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProtectedTokenInit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUserInit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProtectedUserInit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefreshSlot;
        private System.Windows.Forms.TabPage TabPageDomainParams;
        private Net.Pkcs11Admin.WinForms.Controls.EnhancedListView ListViewDomainParams;
        private System.Windows.Forms.Label LabelDomainParams;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpenLogFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSlot;
        private System.Windows.Forms.ToolStripStatusLabel MainFormStatusStripLabel;
        private System.Windows.Forms.ToolStripSeparator MenuItemApplicationSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReloadLibrary;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCheckUpdates;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObject;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTools;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPkcs11Uri;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCsvExport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCsvExportSelected;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCsvExportAll;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectNew;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectNewData;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectNewKey;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectDelete;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectImport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectImportData;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectImportCert;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectImportKey;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectExport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectExportData;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectExportCert;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectExportKey;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectNewCsr;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectNewCert;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectView;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectViewData;
        private System.Windows.Forms.ToolStripMenuItem MenuItemObjectViewCert;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPkcs11UriEmpty;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPkcs11UriWithObject;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPkcs11UriWithoutObject;
    }
}
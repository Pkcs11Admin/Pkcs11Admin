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
            this.MainFormStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainFormStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuItemApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLoadLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpenLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemApplicationSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MainFormPanel = new System.Windows.Forms.Panel();
            this.MainFormTabControl = new System.Windows.Forms.TabControl();
            this.TabPageBasicInfo = new System.Windows.Forms.TabPage();
            this.ListViewBasicInfo = new System.Windows.Forms.ListView();
            this.LabelBasicInfo = new System.Windows.Forms.Label();
            this.TabPageMechanisms = new System.Windows.Forms.TabPage();
            this.ButtonMechanisms = new System.Windows.Forms.Button();
            this.ComboBoxMechanisms = new System.Windows.Forms.ComboBox();
            this.ListViewMechanisms = new System.Windows.Forms.ListView();
            this.LabelMechanisms = new System.Windows.Forms.Label();
            this.TabPageHwFeatures = new System.Windows.Forms.TabPage();
            this.ButtonHwFeatures = new System.Windows.Forms.Button();
            this.ComboBoxHwFeatures = new System.Windows.Forms.ComboBox();
            this.ListViewHwFeatures = new System.Windows.Forms.ListView();
            this.LabelHwFeatures = new System.Windows.Forms.Label();
            this.TabPageDataObjects = new System.Windows.Forms.TabPage();
            this.ButtonDataObjects = new System.Windows.Forms.Button();
            this.ComboBoxDataObjects = new System.Windows.Forms.ComboBox();
            this.ListViewDataObjects = new System.Windows.Forms.ListView();
            this.LabelDataObjects = new System.Windows.Forms.Label();
            this.TabPageCertificates = new System.Windows.Forms.TabPage();
            this.ButtonCertificates = new System.Windows.Forms.Button();
            this.ComboBoxCertificates = new System.Windows.Forms.ComboBox();
            this.ListViewCertificates = new System.Windows.Forms.ListView();
            this.LabelCertificates = new System.Windows.Forms.Label();
            this.TabPageKeys = new System.Windows.Forms.TabPage();
            this.ButtonKeys = new System.Windows.Forms.Button();
            this.ComboBoxKeys = new System.Windows.Forms.ComboBox();
            this.ListViewKeys = new System.Windows.Forms.ListView();
            this.LabelKeys = new System.Windows.Forms.Label();
            this.TabPageDomainParams = new System.Windows.Forms.TabPage();
            this.ComboBoxDomainParams = new System.Windows.Forms.ComboBox();
            this.ButtonDomainParams = new System.Windows.Forms.Button();
            this.ListViewDomainParams = new System.Windows.Forms.ListView();
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
            this.MenuItemRefresh,
            this.MenuItemApplicationSeparator1,
            this.MenuItemExit});
            this.MenuItemApplication.Name = "MenuItemApplication";
            this.MenuItemApplication.Size = new System.Drawing.Size(80, 20);
            this.MenuItemApplication.Text = "Application";
            // 
            // MenuItemLoadLibrary
            // 
            this.MenuItemLoadLibrary.Name = "MenuItemLoadLibrary";
            this.MenuItemLoadLibrary.Size = new System.Drawing.Size(195, 22);
            this.MenuItemLoadLibrary.Text = "Load PKCS#11 library...";
            this.MenuItemLoadLibrary.Click += new System.EventHandler(this.MenuItemLoadLibrary_Click);
            // 
            // MenuItemOpenLogFile
            // 
            this.MenuItemOpenLogFile.Name = "MenuItemOpenLogFile";
            this.MenuItemOpenLogFile.Size = new System.Drawing.Size(195, 22);
            this.MenuItemOpenLogFile.Text = "Open log file...";
            this.MenuItemOpenLogFile.Click += new System.EventHandler(this.MenuItemOpenLogFile_Click);
            // 
            // MenuItemRefresh
            // 
            this.MenuItemRefresh.Name = "MenuItemRefresh";
            this.MenuItemRefresh.Size = new System.Drawing.Size(195, 22);
            this.MenuItemRefresh.Text = "Refresh";
            this.MenuItemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // MenuItemApplicationSeparator1
            // 
            this.MenuItemApplicationSeparator1.Name = "MenuItemApplicationSeparator1";
            this.MenuItemApplicationSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(195, 22);
            this.MenuItemExit.Text = "Exit";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAbout});
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuItemHelp.Text = "Help";
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.MenuItemAbout.Text = "About";
            this.MenuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemApplication,
            this.MenuItemSlot,
            this.MenuItemToken,
            this.MenuItemHelp});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MainFormMenuStrip.TabIndex = 2;
            // 
            // MenuItemSlot
            // 
            this.MenuItemSlot.Name = "MenuItemSlot";
            this.MenuItemSlot.Size = new System.Drawing.Size(80, 20);
            this.MenuItemSlot.Text = "Slot/Reader";
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
            this.MenuItemToken.Size = new System.Drawing.Size(82, 20);
            this.MenuItemToken.Text = "Token/Card";
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
            this.ListViewBasicInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewBasicInfo.HideSelection = false;
            this.ListViewBasicInfo.Location = new System.Drawing.Point(13, 26);
            this.ListViewBasicInfo.MultiSelect = false;
            this.ListViewBasicInfo.Name = "ListViewBasicInfo";
            this.ListViewBasicInfo.Size = new System.Drawing.Size(724, 295);
            this.ListViewBasicInfo.TabIndex = 1;
            this.ListViewBasicInfo.UseCompatibleStateImageBehavior = false;
            this.ListViewBasicInfo.View = System.Windows.Forms.View.Details;
            // 
            // LabelBasicInfo
            // 
            this.LabelBasicInfo.AutoSize = true;
            this.LabelBasicInfo.Location = new System.Drawing.Point(10, 10);
            this.LabelBasicInfo.Name = "LabelBasicInfo";
            this.LabelBasicInfo.Size = new System.Drawing.Size(334, 13);
            this.LabelBasicInfo.TabIndex = 0;
            this.LabelBasicInfo.Text = "Basic information about PKCS#11 library, slot/reader and token/card:";
            // 
            // TabPageMechanisms
            // 
            this.TabPageMechanisms.Controls.Add(this.ButtonMechanisms);
            this.TabPageMechanisms.Controls.Add(this.ComboBoxMechanisms);
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
            // ButtonMechanisms
            // 
            this.ButtonMechanisms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMechanisms.Location = new System.Drawing.Point(662, 327);
            this.ButtonMechanisms.Name = "ButtonMechanisms";
            this.ButtonMechanisms.Size = new System.Drawing.Size(75, 23);
            this.ButtonMechanisms.TabIndex = 3;
            this.ButtonMechanisms.Text = "Start";
            this.ButtonMechanisms.UseVisualStyleBackColor = true;
            this.ButtonMechanisms.Click += new System.EventHandler(this.ButtonMechanisms_Click);
            // 
            // ComboBoxMechanisms
            // 
            this.ComboBoxMechanisms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxMechanisms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMechanisms.FormattingEnabled = true;
            this.ComboBoxMechanisms.Location = new System.Drawing.Point(13, 328);
            this.ComboBoxMechanisms.Name = "ComboBoxMechanisms";
            this.ComboBoxMechanisms.Size = new System.Drawing.Size(643, 21);
            this.ComboBoxMechanisms.TabIndex = 2;
            // 
            // ListViewMechanisms
            // 
            this.ListViewMechanisms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewMechanisms.FullRowSelect = true;
            this.ListViewMechanisms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewMechanisms.HideSelection = false;
            this.ListViewMechanisms.Location = new System.Drawing.Point(13, 26);
            this.ListViewMechanisms.Name = "ListViewMechanisms";
            this.ListViewMechanisms.Size = new System.Drawing.Size(724, 295);
            this.ListViewMechanisms.TabIndex = 0;
            this.ListViewMechanisms.UseCompatibleStateImageBehavior = false;
            this.ListViewMechanisms.View = System.Windows.Forms.View.Details;
            // 
            // LabelMechanisms
            // 
            this.LabelMechanisms.AutoSize = true;
            this.LabelMechanisms.Location = new System.Drawing.Point(10, 10);
            this.LabelMechanisms.Name = "LabelMechanisms";
            this.LabelMechanisms.Size = new System.Drawing.Size(333, 13);
            this.LabelMechanisms.TabIndex = 1;
            this.LabelMechanisms.Text = "These mechanisms/algorithms are supported by the PKCS#11 library:";
            // 
            // TabPageHwFeatures
            // 
            this.TabPageHwFeatures.Controls.Add(this.ButtonHwFeatures);
            this.TabPageHwFeatures.Controls.Add(this.ComboBoxHwFeatures);
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
            // ButtonHwFeatures
            // 
            this.ButtonHwFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonHwFeatures.Location = new System.Drawing.Point(662, 327);
            this.ButtonHwFeatures.Name = "ButtonHwFeatures";
            this.ButtonHwFeatures.Size = new System.Drawing.Size(75, 23);
            this.ButtonHwFeatures.TabIndex = 3;
            this.ButtonHwFeatures.Text = "Start";
            this.ButtonHwFeatures.UseVisualStyleBackColor = true;
            this.ButtonHwFeatures.Click += new System.EventHandler(this.ButtonHwFeatures_Click);
            // 
            // ComboBoxHwFeatures
            // 
            this.ComboBoxHwFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxHwFeatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHwFeatures.FormattingEnabled = true;
            this.ComboBoxHwFeatures.Location = new System.Drawing.Point(13, 328);
            this.ComboBoxHwFeatures.Name = "ComboBoxHwFeatures";
            this.ComboBoxHwFeatures.Size = new System.Drawing.Size(643, 21);
            this.ComboBoxHwFeatures.TabIndex = 2;
            // 
            // ListViewHwFeatures
            // 
            this.ListViewHwFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewHwFeatures.FullRowSelect = true;
            this.ListViewHwFeatures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewHwFeatures.HideSelection = false;
            this.ListViewHwFeatures.Location = new System.Drawing.Point(13, 26);
            this.ListViewHwFeatures.Name = "ListViewHwFeatures";
            this.ListViewHwFeatures.Size = new System.Drawing.Size(724, 295);
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
            this.TabPageDataObjects.Controls.Add(this.ButtonDataObjects);
            this.TabPageDataObjects.Controls.Add(this.ComboBoxDataObjects);
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
            // ButtonDataObjects
            // 
            this.ButtonDataObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDataObjects.Location = new System.Drawing.Point(662, 327);
            this.ButtonDataObjects.Name = "ButtonDataObjects";
            this.ButtonDataObjects.Size = new System.Drawing.Size(75, 23);
            this.ButtonDataObjects.TabIndex = 3;
            this.ButtonDataObjects.Text = "Start";
            this.ButtonDataObjects.UseVisualStyleBackColor = true;
            this.ButtonDataObjects.Click += new System.EventHandler(this.ButtonDataObjects_Click);
            // 
            // ComboBoxDataObjects
            // 
            this.ComboBoxDataObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxDataObjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDataObjects.FormattingEnabled = true;
            this.ComboBoxDataObjects.Location = new System.Drawing.Point(13, 328);
            this.ComboBoxDataObjects.Name = "ComboBoxDataObjects";
            this.ComboBoxDataObjects.Size = new System.Drawing.Size(643, 21);
            this.ComboBoxDataObjects.TabIndex = 2;
            // 
            // ListViewDataObjects
            // 
            this.ListViewDataObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewDataObjects.FullRowSelect = true;
            this.ListViewDataObjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewDataObjects.HideSelection = false;
            this.ListViewDataObjects.Location = new System.Drawing.Point(13, 26);
            this.ListViewDataObjects.Name = "ListViewDataObjects";
            this.ListViewDataObjects.Size = new System.Drawing.Size(724, 295);
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
            this.TabPageCertificates.Controls.Add(this.ButtonCertificates);
            this.TabPageCertificates.Controls.Add(this.ComboBoxCertificates);
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
            // ButtonCertificates
            // 
            this.ButtonCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCertificates.Location = new System.Drawing.Point(662, 327);
            this.ButtonCertificates.Name = "ButtonCertificates";
            this.ButtonCertificates.Size = new System.Drawing.Size(75, 23);
            this.ButtonCertificates.TabIndex = 3;
            this.ButtonCertificates.Text = "Start";
            this.ButtonCertificates.UseVisualStyleBackColor = true;
            this.ButtonCertificates.Click += new System.EventHandler(this.ButtonCertificates_Click);
            // 
            // ComboBoxCertificates
            // 
            this.ComboBoxCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxCertificates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCertificates.FormattingEnabled = true;
            this.ComboBoxCertificates.Location = new System.Drawing.Point(13, 328);
            this.ComboBoxCertificates.Name = "ComboBoxCertificates";
            this.ComboBoxCertificates.Size = new System.Drawing.Size(643, 21);
            this.ComboBoxCertificates.TabIndex = 2;
            // 
            // ListViewCertificates
            // 
            this.ListViewCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewCertificates.FullRowSelect = true;
            this.ListViewCertificates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewCertificates.HideSelection = false;
            this.ListViewCertificates.Location = new System.Drawing.Point(13, 26);
            this.ListViewCertificates.Name = "ListViewCertificates";
            this.ListViewCertificates.Size = new System.Drawing.Size(724, 295);
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
            this.TabPageKeys.Controls.Add(this.ButtonKeys);
            this.TabPageKeys.Controls.Add(this.ComboBoxKeys);
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
            // ButtonKeys
            // 
            this.ButtonKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonKeys.Location = new System.Drawing.Point(662, 327);
            this.ButtonKeys.Name = "ButtonKeys";
            this.ButtonKeys.Size = new System.Drawing.Size(75, 23);
            this.ButtonKeys.TabIndex = 3;
            this.ButtonKeys.Text = "Start";
            this.ButtonKeys.UseVisualStyleBackColor = true;
            this.ButtonKeys.Click += new System.EventHandler(this.ButtonKeys_Click);
            // 
            // ComboBoxKeys
            // 
            this.ComboBoxKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxKeys.FormattingEnabled = true;
            this.ComboBoxKeys.Location = new System.Drawing.Point(13, 328);
            this.ComboBoxKeys.Name = "ComboBoxKeys";
            this.ComboBoxKeys.Size = new System.Drawing.Size(643, 21);
            this.ComboBoxKeys.TabIndex = 2;
            // 
            // ListViewKeys
            // 
            this.ListViewKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewKeys.FullRowSelect = true;
            this.ListViewKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewKeys.HideSelection = false;
            this.ListViewKeys.Location = new System.Drawing.Point(13, 26);
            this.ListViewKeys.Name = "ListViewKeys";
            this.ListViewKeys.Size = new System.Drawing.Size(724, 295);
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
            this.TabPageDomainParams.Controls.Add(this.ComboBoxDomainParams);
            this.TabPageDomainParams.Controls.Add(this.ButtonDomainParams);
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
            // ComboBoxDomainParams
            // 
            this.ComboBoxDomainParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxDomainParams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDomainParams.FormattingEnabled = true;
            this.ComboBoxDomainParams.Location = new System.Drawing.Point(13, 328);
            this.ComboBoxDomainParams.Name = "ComboBoxDomainParams";
            this.ComboBoxDomainParams.Size = new System.Drawing.Size(643, 21);
            this.ComboBoxDomainParams.TabIndex = 3;
            // 
            // ButtonDomainParams
            // 
            this.ButtonDomainParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDomainParams.Location = new System.Drawing.Point(662, 327);
            this.ButtonDomainParams.Name = "ButtonDomainParams";
            this.ButtonDomainParams.Size = new System.Drawing.Size(75, 23);
            this.ButtonDomainParams.TabIndex = 2;
            this.ButtonDomainParams.Text = "Start";
            this.ButtonDomainParams.UseVisualStyleBackColor = true;
            this.ButtonDomainParams.Click += new System.EventHandler(this.ButtonDomainParams_Click);
            // 
            // ListViewDomainParams
            // 
            this.ListViewDomainParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewDomainParams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewDomainParams.HideSelection = false;
            this.ListViewDomainParams.Location = new System.Drawing.Point(13, 26);
            this.ListViewDomainParams.Name = "ListViewDomainParams";
            this.ListViewDomainParams.Size = new System.Drawing.Size(724, 295);
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
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.ToolStripSeparator MenuItemApplicationSeparator1;
        private System.Windows.Forms.ListView ListViewBasicInfo;
        private System.Windows.Forms.Label LabelBasicInfo;
        private System.Windows.Forms.Label LabelMechanisms;
        private System.Windows.Forms.ListView ListViewMechanisms;
        private System.Windows.Forms.Label LabelHwFeatures;
        private System.Windows.Forms.Label LabelDataObjects;
        private System.Windows.Forms.Label LabelKeys;
        private System.Windows.Forms.Label LabelCertificates;
        private System.Windows.Forms.ListView ListViewHwFeatures;
        private System.Windows.Forms.ListView ListViewDataObjects;
        private System.Windows.Forms.ListView ListViewKeys;
        private System.Windows.Forms.ListView ListViewCertificates;
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
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.TabPage TabPageDomainParams;
        private System.Windows.Forms.ListView ListViewDomainParams;
        private System.Windows.Forms.Label LabelDomainParams;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpenLogFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSlot;
        private System.Windows.Forms.ToolStripStatusLabel MainFormStatusStripLabel;
        private System.Windows.Forms.Button ButtonDataObjects;
        private System.Windows.Forms.ComboBox ComboBoxDataObjects;
        private System.Windows.Forms.Button ButtonMechanisms;
        private System.Windows.Forms.ComboBox ComboBoxMechanisms;
        private System.Windows.Forms.Button ButtonHwFeatures;
        private System.Windows.Forms.ComboBox ComboBoxHwFeatures;
        private System.Windows.Forms.Button ButtonCertificates;
        private System.Windows.Forms.ComboBox ComboBoxCertificates;
        private System.Windows.Forms.Button ButtonKeys;
        private System.Windows.Forms.ComboBox ComboBoxKeys;
        private System.Windows.Forms.ComboBox ComboBoxDomainParams;
        private System.Windows.Forms.Button ButtonDomainParams;

    }
}
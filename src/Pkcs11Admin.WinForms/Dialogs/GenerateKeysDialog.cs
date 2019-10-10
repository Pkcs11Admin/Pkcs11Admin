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

using Net.Pkcs11Admin.Configuration;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class GenerateKeysDialog : Form
    {
        private Pkcs11Slot _pkcs11Slot = null;

        public GenerateKeysDialog(Pkcs11Slot pkcs11Slot)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            if (pkcs11Slot == null)
                throw new ArgumentNullException("pkcs11Slot");

            _pkcs11Slot = pkcs11Slot;

            List<CKK> asymKeyTypes = pkcs11Slot.GetGeneratableAsymmetricKeyTypes();
            foreach (CKK asymKeyType in asymKeyTypes)
                ComboBoxKeyType.Items.Add(new ComboBoxKeyTypeItem(asymKeyType, ComboBoxKeyTypeItem.Kinds.Asymmetric));

            List<CKK> symKeyTypes = pkcs11Slot.GetGeneratableSymmetricKeyTypes();
            foreach (CKK symKeyType in symKeyTypes)
                ComboBoxKeyType.Items.Add(new ComboBoxKeyTypeItem(symKeyType, ComboBoxKeyTypeItem.Kinds.Symmetric));
        }

        private void GenerateKeysDialog_Shown(object sender, EventArgs e)
        {
            if (ComboBoxKeyType.Items.Count <= 0)
            {
                WinFormsUtils.ShowError(this, "PKCS#11 library does not support generation of the known key types");
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                ComboBoxKeyType.SelectedIndex = 0;
            }
        }

        private ComboBoxKeyTypeItem GetSelectedComboBoxItem()
        {
            return ComboBoxKeyType.SelectedItem as ComboBoxKeyTypeItem;
        }

        private void ComboBoxKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxKeyTypeItem selectedKeyTypeItem = GetSelectedComboBoxItem();

            switch (selectedKeyTypeItem.Kind)
            {
                case ComboBoxKeyTypeItem.Kinds.Asymmetric:
                    ListViewPrivateKeyAttributes.Enabled = true;
                    ListViewPublicKeyAttributes.Enabled = true;
                    ListViewSecretKeyAttributes.Enabled = false;
                    break;
                case ComboBoxKeyTypeItem.Kinds.Symmetric:
                    ListViewPrivateKeyAttributes.Enabled = false;
                    ListViewPublicKeyAttributes.Enabled = false;
                    ListViewSecretKeyAttributes.Enabled = true;
                    break;
                default:
                    ListViewPrivateKeyAttributes.Enabled = false;
                    ListViewPublicKeyAttributes.Enabled = false;
                    ListViewSecretKeyAttributes.Enabled = false;
                    break;
            }

            if (!ListViewPrivateKeyAttributes.Enabled)
            {
                ListViewPrivateKeyAttributes.BeginUpdate();
                ListViewPrivateKeyAttributes.HeaderStyle = ColumnHeaderStyle.None;
                ListViewPrivateKeyAttributes.Items.Clear();
                ListViewPrivateKeyAttributes.EndUpdate();
            }
            else
            {
                ListViewPrivateKeyAttributes.BeginUpdate();
                ListViewPrivateKeyAttributes.HeaderStyle = ColumnHeaderStyle.Clickable;
                ListViewPrivateKeyAttributes.Items.Clear();
                List<Tuple<IObjectAttribute, ClassAttribute>> objectAttributes = StringUtils.GetGenerateDefaultAttributes(Pkcs11Admin.Instance.Config.PrivateKeyAttributes, (ulong)selectedKeyTypeItem.KeyType);
                PutAttributesIntoListView(ListViewPrivateKeyAttributes, objectAttributes);
                ListViewPrivateKeyAttributes.EndUpdate();

                GenerateKeysTabControl.SelectedTab = TabPagePrivateKey;
            }

            if (!ListViewPublicKeyAttributes.Enabled)
            {
                ListViewPublicKeyAttributes.BeginUpdate();
                ListViewPublicKeyAttributes.HeaderStyle = ColumnHeaderStyle.None;
                ListViewPublicKeyAttributes.Items.Clear();
                ListViewPublicKeyAttributes.EndUpdate();
            }
            else
            {
                ListViewPublicKeyAttributes.BeginUpdate();
                ListViewPublicKeyAttributes.HeaderStyle = ColumnHeaderStyle.Clickable;
                ListViewPublicKeyAttributes.Items.Clear();
                List<Tuple<IObjectAttribute, ClassAttribute>> objectAttributes = StringUtils.GetGenerateDefaultAttributes(Pkcs11Admin.Instance.Config.PublicKeyAttributes, (ulong)selectedKeyTypeItem.KeyType);
                PutAttributesIntoListView(ListViewPublicKeyAttributes, objectAttributes);
                ListViewPublicKeyAttributes.EndUpdate();
            }

            if (!ListViewSecretKeyAttributes.Enabled)
            {
                ListViewSecretKeyAttributes.BeginUpdate();
                ListViewSecretKeyAttributes.HeaderStyle = ColumnHeaderStyle.None;
                ListViewSecretKeyAttributes.Items.Clear();
                ListViewSecretKeyAttributes.EndUpdate();
            }
            else
            {
                ListViewSecretKeyAttributes.BeginUpdate();
                ListViewSecretKeyAttributes.HeaderStyle = ColumnHeaderStyle.Clickable;
                ListViewSecretKeyAttributes.Items.Clear();
                List<Tuple<IObjectAttribute, ClassAttribute>> objectAttributes = StringUtils.GetGenerateDefaultAttributes(Pkcs11Admin.Instance.Config.SecretKeyAttributes, (ulong)selectedKeyTypeItem.KeyType);
                PutAttributesIntoListView(ListViewSecretKeyAttributes, objectAttributes);
                ListViewSecretKeyAttributes.EndUpdate();

                GenerateKeysTabControl.SelectedTab = TabPageSecretKey;
            }

            ReloadListViews();
        }

        private void PutAttributesIntoListView(ListView listView, List<Tuple<IObjectAttribute, ClassAttribute>> objectAttributes)
        {
            // Add items to ListView and set the tags
            foreach (Tuple<IObjectAttribute, ClassAttribute> objectAttribute in objectAttributes)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = objectAttribute.Item1;
                listViewItem.Checked = objectAttribute.Item2.GenerateSetByDefault;
                listView.Items.Add(listViewItem);
            }
        }

        private void ReloadListViews()
        {
            ListView[] listViews = new ListView[] { ListViewPrivateKeyAttributes, ListViewPublicKeyAttributes, ListViewSecretKeyAttributes };
            foreach (ListView listView in listViews)
                ReloadListView(listView);
        }

        private void ReloadListView(ListView listView)
        {
            foreach (ListViewItem listViewItem in listView.Items)
            {
                // Clear currently viewed values
                listViewItem.Text = null;
                listViewItem.SubItems.Clear();

                // Parse tag
                IObjectAttribute objectAttribute = (IObjectAttribute)listViewItem.Tag;

                // Determine viewable values
                string attributeName = null;
                string attributeValue = null;
                StringUtils.GetAttributeNameAndValue(objectAttribute, out attributeName, out attributeValue);

                // Set new values
                listViewItem.Text = attributeName;
                listViewItem.SubItems.Add(attributeValue);
            }
        }

        private ListView GetActiveListView()
        {
            ListView listView = null;

            if (GenerateKeysTabControl.SelectedTab == TabPagePrivateKey)
                listView = ListViewPrivateKeyAttributes;
            else if (GenerateKeysTabControl.SelectedTab == TabPagePublicKey)
                listView = ListViewPublicKeyAttributes;
            else if (GenerateKeysTabControl.SelectedTab == TabPageSecretKey)
                listView = ListViewSecretKeyAttributes;

            return listView;
        }

        private void EditAttributeValue()
        {
            ListView activeListView = GetActiveListView();

            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(activeListView);
            if (selectedItem == null)
                return;

            IObjectAttribute objectAttribute = (IObjectAttribute)selectedItem.Tag;

            string attributeName = selectedItem.Text;
            byte[] attributeValue = objectAttribute.GetValueAsByteArray() ?? new byte[0];

            using (HexEditor hexEditor = new HexEditor(attributeName, attributeValue))
            {
                if (hexEditor.ShowDialog() == DialogResult.OK)
                {
                    IObjectAttribute updatedObjectAttribute = Pkcs11Admin.Instance.Factories.ObjectAttributeFactory.Create(objectAttribute.Type, hexEditor.Bytes);
                    selectedItem.Tag = updatedObjectAttribute;
                    ReloadListView(activeListView);
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            EditAttributeValue();
        }

        private void ViewAsn1AttributeValue()
        {
            ListView activeListView = GetActiveListView();

            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(activeListView);
            if (selectedItem == null)
                return;

            IObjectAttribute objectAttribute = (IObjectAttribute)selectedItem.Tag;

            string attributeName = selectedItem.Text;
            byte[] attributeValue = (objectAttribute.CannotBeRead) ? new byte[0] : objectAttribute.GetValueAsByteArray();

            using (Asn1Viewer asn1Viewer = new Asn1Viewer(attributeName, attributeValue))
                asn1Viewer.ShowDialog();
        }

        private void ButtonAsn1_Click(object sender, EventArgs e)
        {
            ViewAsn1AttributeValue();
        }

        private List<IObjectAttribute> GetObjectAttributesFromListView(ListView listView)
        {
            List<IObjectAttribute> objectAttributes = new List<IObjectAttribute>();

            foreach (ListViewItem listViewItem in listView.CheckedItems)
                objectAttributes.Add((IObjectAttribute)listViewItem.Tag);

            return objectAttributes;
        }

        private async void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBoxKeyTypeItem selectedKeyTypeItem = GetSelectedComboBoxItem();

                if (selectedKeyTypeItem.Kind == ComboBoxKeyTypeItem.Kinds.Asymmetric)
                {
                    List<IObjectAttribute> privateKeyObjectAttributes = GetObjectAttributesFromListView(ListViewPrivateKeyAttributes);
                    List<IObjectAttribute> publicKeyObjectAttributes = GetObjectAttributesFromListView(ListViewPublicKeyAttributes);

                    await WaitDialog.Execute(
                        this,
                        () => _pkcs11Slot.GenerateAsymmetricKeyPair(selectedKeyTypeItem.KeyType, privateKeyObjectAttributes, publicKeyObjectAttributes)
                    );
                }
                else
                {
                    List<IObjectAttribute> secretKeyObjectAttributes = GetObjectAttributesFromListView(ListViewSecretKeyAttributes);

                    await WaitDialog.Execute(
                        this,
                        () => _pkcs11Slot.GenerateSymmetricKey(selectedKeyTypeItem.KeyType, secretKeyObjectAttributes)
                    );
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        private class ComboBoxKeyTypeItem
        {
            public enum Kinds
            {
                Asymmetric,
                Symmetric
            }

            public CKK KeyType
            {
                get;
                private set;
            }

            public Kinds Kind
            {
                get;
                private set;
            }

            public ComboBoxKeyTypeItem(CKK keyType, Kinds kind)
            {
                this.KeyType = keyType;
                this.Kind = kind;
            }

            public override string ToString()
            {
                return this.KeyType.ToString();
            }
        }
    }
}

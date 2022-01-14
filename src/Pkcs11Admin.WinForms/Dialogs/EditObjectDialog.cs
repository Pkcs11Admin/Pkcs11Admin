/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2022 Jaroslav Imrich <jimrich@jimrich.sk>
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
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class EditObjectDialog : Form
    {
        private Pkcs11Slot _pkcs11Slot = null;

        private Pkcs11ObjectInfo _pkcs11ObjectInfo = null;

        public bool AttributeModified
        {
            get;
            private set;
        }

        public EditObjectDialog(Pkcs11Slot pkcs11Slot, Pkcs11ObjectInfo pkcs11ObjectInfo)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            if (pkcs11Slot == null)
                throw new ArgumentNullException("pkcs11Slot");

            if (pkcs11ObjectInfo == null)
                throw new ArgumentNullException("pkcs11Objectinfo");

            _pkcs11Slot = pkcs11Slot;
            _pkcs11ObjectInfo = pkcs11ObjectInfo;
            AttributeModified = false;

            // Add items to ListView and set the tags
            foreach (IObjectAttribute objectAttribute in _pkcs11ObjectInfo.ObjectAttributes)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = objectAttribute;
                ListViewAttributes.Items.Add(listViewItem);
            }

            ReloadListView();
        }

        private void ReloadListView()
        {
            foreach (ListViewItem listViewItem in ListViewAttributes.Items)
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

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            EditAttributeValue();
        }

        private void EditAttributeValue()
        {
            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(ListViewAttributes);
            if (selectedItem == null)
                return;

            IObjectAttribute objectAttribute = (IObjectAttribute)selectedItem.Tag;

            string attributeName = selectedItem.Text;
            byte[] attributeValue = (objectAttribute.CannotBeRead) ? new byte[0] : objectAttribute.GetValueAsByteArray();

            using (HexEditor hexEditor = new HexEditor(attributeName, attributeValue))
            {
                if (hexEditor.ShowDialog() == DialogResult.OK)
                {
                    AttributeModified = true;
                    IObjectAttribute updatedObjectAttribute = Pkcs11Admin.Instance.Factories.ObjectAttributeFactory.Create(objectAttribute.Type, hexEditor.Bytes);
                    _pkcs11Slot.SaveObjectAttributes(_pkcs11ObjectInfo, new List<IObjectAttribute>() { updatedObjectAttribute });
                    selectedItem.Tag = updatedObjectAttribute;
                    ReloadListView();
                }
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            List<ulong> attributes = new List<ulong>();

            for (int i = 0; i < ListViewAttributes.Items.Count; i++)
            {
                IObjectAttribute objectAttribute = (IObjectAttribute)ListViewAttributes.Items[i].Tag;
                attributes.Add(objectAttribute.Type);
            }

            List<IObjectAttribute> objectAttributes = _pkcs11Slot.LoadObjectAttributes(_pkcs11ObjectInfo, attributes);

            for (int i = 0; i < ListViewAttributes.Items.Count; i++)
            {
                ListViewAttributes.Items[i].Tag = objectAttributes[i];
            }

            ReloadListView();
        }

        private void ButtonAsn1_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(ListViewAttributes);
            if (selectedItem == null)
                return;

            IObjectAttribute objectAttribute = (IObjectAttribute)selectedItem.Tag;

            string attributeName = selectedItem.Text;
            byte[] attributeValue = (objectAttribute.CannotBeRead) ? new byte[0] : objectAttribute.GetValueAsByteArray();

            using (Asn1Viewer asn1Viewer = new Asn1Viewer(attributeName, attributeValue))
                asn1Viewer.ShowDialog();
        }
    }
}

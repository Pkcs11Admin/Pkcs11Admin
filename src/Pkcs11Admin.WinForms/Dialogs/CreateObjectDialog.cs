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
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class CreateObjectDialog : Form
    {
        private Pkcs11Slot _pkcs11Slot = null;

        public CreateObjectDialog(Pkcs11Slot pkcs11Slot, List<Tuple<IObjectAttribute, ClassAttribute>> objectAttributes)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            if (pkcs11Slot == null)
                throw new ArgumentNullException("pkcs11Slot");

            if (objectAttributes == null)
                throw new ArgumentNullException("objectAttributes");

            _pkcs11Slot = pkcs11Slot;

            // Add items to ListView and set the tags
            foreach (Tuple<IObjectAttribute, ClassAttribute> objectAttribute in objectAttributes)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = objectAttribute.Item1;
                listViewItem.Checked = objectAttribute.Item2.CreateSetByDefault;
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

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                List<IObjectAttribute> objectAttributes = new List<IObjectAttribute>();
                foreach (ListViewItem listViewItem in ListViewAttributes.CheckedItems)
                    objectAttributes.Add((IObjectAttribute)listViewItem.Tag);

                _pkcs11Slot.CreateObject(objectAttributes);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        private void EditAttributeValue()
        {
            ListViewItem selectedItem = WinFormsUtils.GetSingleSelectedItem(ListViewAttributes);
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
                    ReloadListView();
                }
            }
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

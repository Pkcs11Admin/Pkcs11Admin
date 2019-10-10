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
using System;
using System.IO;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Dialogs
{
    public partial class CsrDialog : Form
    {
        private Pkcs11Slot _pkcs11Slot = null;

        private Pkcs11KeyInfo _privKeyInfo = null;

        private Pkcs11KeyInfo _pubKeyInfo = null;

        public CsrDialog(Pkcs11Slot pkcs11Slot, Pkcs11KeyInfo privKeyInfo, Pkcs11KeyInfo pubKeyInfo)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Pkcs11Admin;

            if (pkcs11Slot == null)
                throw new ArgumentNullException(nameof(pkcs11Slot));

            if (privKeyInfo == null)
                throw new ArgumentNullException(nameof(privKeyInfo));

            _pkcs11Slot = pkcs11Slot;
            _privKeyInfo = privKeyInfo;
            _pubKeyInfo = pubKeyInfo;

            SetupComboBoxType();
        }

        private void SetupComboBoxType()
        {
            foreach (DnEntryDefinition dnEntryDefinition in Pkcs11Admin.Instance.Config.DnEntryDefinitions.Values)
                ComboBoxType.Items.Add(new ComboBoxDnEntryTypeItem(dnEntryDefinition));

            ComboBoxType.SelectedIndex = 0;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxValue.Text))
            {
                TextBoxValue.Focus();
                return;
            }

            DnEntryDefinition dnEntryDefinition = ((ComboBoxDnEntryTypeItem)ComboBoxType.SelectedItem).DnEntryDefinition;
            DnEntry dnEntry = new DnEntry(dnEntryDefinition, TextBoxValue.Text);

            ListViewSubject.Items.Add(new ListViewItem() { Tag = dnEntry });

            TextBoxValue.Text = null;

            ReloadListView();
        }

        private void ReloadListView()
        {
            foreach (ListViewItem listViewItem in ListViewSubject.Items)
            {
                // Clear currently viewed values
                listViewItem.Text = null;
                listViewItem.SubItems.Clear();

                // Parse tag
                DnEntry dnEntry = (DnEntry)listViewItem.Tag;

                // Set new values
                listViewItem.Text = string.Format("{0} ({1})", dnEntry.Definition.Name, dnEntry.Definition.Oid);
                listViewItem.SubItems.Add(dnEntry.Value);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            int? index = GetSingleSelectedItemIndex(ListViewSubject);
            if (index != null)
            {
                ListViewSubject.Items.RemoveAt(index.Value);
                ReloadListView();
            }
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            int? index = GetSingleSelectedItemIndex(ListViewSubject);
            if (index != null && ListViewSubject.MoveItemUp(index.Value))
                ReloadListView();
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            int? index = GetSingleSelectedItemIndex(ListViewSubject);
            if (index != null && ListViewSubject.MoveItemDown(index.Value))
                ReloadListView();
        }

        private int? GetSingleSelectedItemIndex(ListView listView)
        {
            if (listView == null)
                throw new ArgumentNullException("listBox");

            if (listView.SelectedItems.Count < 1)
            {
                WinFormsUtils.ShowInfo(null, "Please select item first");
                return null;
            }

            if (listView.SelectedItems.Count > 1)
            {
                WinFormsUtils.ShowInfo(null, "Please select only one item");
                return null;
            }

            return listView.SelectedItems[0].Index;
        }

        private async void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListViewSubject.Items.Count < 1)
                {
                    WinFormsUtils.ShowInfo(null, "Please specify subject first");
                    return;
                }

                DnEntry[] dnEntries = new DnEntry[ListViewSubject.Items.Count];
                for (int i = 0; i < ListViewSubject.Items.Count; i++)
                    dnEntries[i] = (DnEntry)ListViewSubject.Items[i].Tag;

                string fileName = null;
                byte[] fileContent = null;

                // TODO - Parametrize HashAlgorithm
                // TODO - Specify SAN

                await WaitDialog.Execute(
                    this,
                    () => _pkcs11Slot.GenerateCsr(_privKeyInfo, _pubKeyInfo, dnEntries, HashAlgorithm.SHA256, out fileName, out fileContent)
                );

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = fileName;

                    saveFileDialog.Filter = "All files (*.*)|*.*|DER encoded certificate signing request (*.csr)|*.csr";
                    saveFileDialog.FilterIndex = 2;

                    saveFileDialog.AddExtension = true;
                    saveFileDialog.CreatePrompt = false;
                    saveFileDialog.OverwritePrompt = true;

                    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, fileContent);
                        WinFormsUtils.ShowInfo(this, "CSR successfully saved");
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                WinFormsUtils.ShowError(this, ex);
            }
        }

        private class ComboBoxDnEntryTypeItem
        {
            public DnEntryDefinition DnEntryDefinition
            {
                get;
                private set;
            }

            public ComboBoxDnEntryTypeItem(DnEntryDefinition dnEntryDefinition)
            {
                this.DnEntryDefinition = dnEntryDefinition;
            }

            public override string ToString()
            {
                return string.Format("{0} ({1})", this.DnEntryDefinition.Name, this.DnEntryDefinition.Oid);
            }
        }
    }
}

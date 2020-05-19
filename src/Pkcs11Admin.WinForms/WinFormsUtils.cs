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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms
{
    public static class WinFormsUtils
    {
        public static void ShowInfo(IWin32Window owner, string message)
        {
            MessageBox.Show(owner, message, Pkcs11AdminInfo.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(IWin32Window owner, Exception exception)
        {
            // TODO - Log exception
            ShowError(owner, exception.Message); // TODO - Handle specific exceptions
        }

        public static void ShowError(IWin32Window owner, string message)
        {
            MessageBox.Show(owner, message, Pkcs11AdminInfo.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult AskQuestion(IWin32Window owner, string question)
        {
            return MessageBox.Show(owner, question, Pkcs11AdminInfo.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <param name="data">
        /// A collection of rows.
        /// Each row has a key, and cells.
        /// Each cell is a pair of the original cell value as an object, and a string representation that can be displayed.</param>
        public static void AppendToListView(
            ListView listView,
            string listViewGroupName,
            IEnumerable<KeyValuePair<object, IEnumerable<KeyValuePair<object, string>>>> data,
            Action<KeyValuePair<object, string>, ListViewItem.ListViewSubItem> postProcessSubItem)
        {
            if (listView == null)
                throw new ArgumentNullException("listView");

            ListViewGroup listViewGroup = null;
            if (!string.IsNullOrEmpty(listViewGroupName))
                listViewGroup = new ListViewGroup(listViewGroupName);

            if (data == null)
                throw new ArgumentNullException("data");

            foreach (var record in data)
            {
                ListViewItem listViewItem = new ListViewItem(record.Value.First().Value);
                listViewItem.Tag = record.Key;
                listViewItem.UseItemStyleForSubItems = false; // Essential to allow sub-processing to set a style for each cell.

                foreach (var subRecord in record.Value.Skip(1))
                {
                    var subItem = listViewItem.SubItems.Add(subRecord.Value);
                    postProcessSubItem?.Invoke(subRecord, subItem);
                }

                if (listViewGroup != null)
                    listViewGroup.Items.Add(listViewItem);

                listView.Items.Add(listViewItem);
            }

            if (listViewGroup != null)
                listView.Groups.Add(listViewGroup);
        }

        public static void AppendToListView(ListView listView, string listViewGroupName, List<KeyValuePair<object, string[]>> data)
        {
            var adaptedData = from record in data
                              let subRecords = from subRecord in record.Value
                                               select new KeyValuePair<object, string>(subRecord, subRecord)
                              select new KeyValuePair<object, IEnumerable<KeyValuePair<object, string>>>(record.Key, subRecords);
            AppendToListView(listView, listViewGroupName, adaptedData, null);
        }

        public static ListViewItem GetSingleSelectedItem(ListView listView)
        {
            if (listView == null)
                throw new ArgumentNullException("listView");

            if (listView.SelectedItems.Count < 1)
            {
                ShowInfo(null, "Please select object first");
                return null;
            }

            if (listView.SelectedItems.Count > 1)
            {
                ShowInfo(null, "Please select only one object");
                return null;
            }

            return listView.SelectedItems[0];
        }

        public static List<ListViewItem> GetSelectedItems(ListView listView)
        {
            if (listView == null)
                throw new ArgumentNullException("listView");

            if (listView.SelectedItems.Count < 1)
            {
                ShowInfo(null, "Please select object first");
                return null;
            }

            List<ListViewItem> selectedItems = new List<ListViewItem>();
            foreach (ListViewItem selectedItem in listView.SelectedItems)
                selectedItems.Add(selectedItem);

            return selectedItems;
        }
    }
}

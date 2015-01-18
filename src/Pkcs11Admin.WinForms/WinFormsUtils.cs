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
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            Pkcs11Admin.Instance.Log(exception.ToString());
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

        public static void DumpListViewToCsvFile(ListView listView, string filePath)
        {
            if (listView == null)
                throw new ArgumentNullException("listView");

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            int rows = listView.Items.Count + 1;
            int cols = listView.Columns.Count;

            string value = null;
            char[] eol = new char[] { (char)0x0d, (char)0x0a };

            // Generate RFC4180 compliant CSV file
            using (StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        value = (i == 0) ? listView.Columns[j].Text : listView.Items[i - 1].SubItems[j].Text;
                        value = value.Replace("\"", "\"\"");
                        value = "\"" + value + "\"";
                        value = (j == (cols - 1)) ? value : value + ", ";
                        streamWriter.Write(value);
                    }

                    streamWriter.Write(eol);
                }
            }
        }
    }
}

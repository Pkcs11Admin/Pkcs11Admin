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
using System.Windows.Forms;

namespace Net.Pkcs11Admin.WinForms.Controls
{
    public class EnhancedListView : ListView
    {
        private int _lastSortedColumn = -1;

        private SortOrder _sorting = SortOrder.Ascending;

        private bool _sortable = false;

        public bool Sortable
        {
            get
            {
                return _sortable;
            }
            set
            {
                _sortable = value;

                if (_sortable)
                    ColumnClick += new ColumnClickEventHandler(ColumnClickHandler);
                else
                    ColumnClick -= new ColumnClickEventHandler(ColumnClickHandler);
            }
        }

        public EnhancedListView()
            : base()
        {
            
        }

        public ColumnHeader AddColumn(string text, ColumnType type, HorizontalAlignment align)
        {
            ColumnHeader columnHeader = Columns.Add(text, -2, align);
            columnHeader.Tag = type;
            return columnHeader;
        }

        private void ColumnClickHandler(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _lastSortedColumn)
                _sorting = (_sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            else
                _sorting = SortOrder.Ascending;

            ColumnType type = (ColumnType)Columns[e.Column].Tag;

            switch (type)
            {
                case ColumnType.String:
                    ListViewItemSorter = new StringItemComparer(e.Column, _sorting);
                    break;

                case ColumnType.ULong:
                    ListViewItemSorter = new ULongItemComparer(e.Column, _sorting);
                    break;

                case ColumnType.Bool:
                    ListViewItemSorter = new BoolItemComparer(e.Column, _sorting);
                    break;

                default:
                    ListViewItemSorter = new StringItemComparer(e.Column, _sorting);
                    break;
            }

            Sort();

            _lastSortedColumn = e.Column;
        }

        #region Enums

        public enum ColumnType
        {
            String,
            ULong,
            Bool
        };

        #endregion

        #region Comparers

        private class StringItemComparer : System.Collections.IComparer
        {
            private int _column = 0;

            private SortOrder _order = SortOrder.None;

            public StringItemComparer(int column, SortOrder order)
            {
                _column = column;
                _order = order;
            }

            public int Compare(object x, object y)
            {
                string xText = ((ListViewItem)x).SubItems[_column].Text;
                string yText = ((ListViewItem)y).SubItems[_column].Text;
                int rv = string.Compare(xText, yText, StringComparison.Ordinal);
                return (_order == SortOrder.Descending) ? rv * -1 : rv;
            }
        }

        private class ULongItemComparer : System.Collections.IComparer
        {
            private int _column = 0;

            private SortOrder _order = SortOrder.None;

            public ULongItemComparer(int column, SortOrder order)
            {
                _column = column;
                _order = order;
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns>Less than zero when x is less than y. Zero when x equals y. Greater than zero when x is greater than y.</returns>
            public int Compare(object x, object y)
            {
                string xText = ((ListViewItem)x).SubItems[_column].Text;
                string yText = ((ListViewItem)y).SubItems[_column].Text;

                ulong xULong = (xText == "-") ? 0 : Convert.ToUInt64(xText);
                ulong yULong = (yText == "-") ? 0 : Convert.ToUInt64(yText);

                int rv = 0;

                if (xULong < yULong)
                    rv = -1;
                else if (xULong > yULong)
                    rv = 1;
                else
                    rv = 0;

                return (_order == SortOrder.Descending) ? rv * -1 : rv;
            }
        }

        private class BoolItemComparer : System.Collections.IComparer
        {
            private int _column = 0;

            private SortOrder _order = SortOrder.None;

            public BoolItemComparer(int column, SortOrder order)
            {
                _column = column;
                _order = order;
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns>Less than zero when x is less than y. Zero when x equals y. Greater than zero when x is greater than y.</returns>
            public int Compare(object x, object y)
            {
                string xText = ((ListViewItem)x).SubItems[_column].Text;
                string yText = ((ListViewItem)y).SubItems[_column].Text;

                bool xBool = Convert.ToBoolean(xText);
                bool yBool = Convert.ToBoolean(yText);

                int rv = 0;

                if (!xBool && yBool)
                    rv = -1;
                else if (xBool && !yBool)
                    rv = 1;
                else
                    rv = 0;

                return (_order == SortOrder.Descending) ? rv * -1 : rv;
            }
        }

        #endregion
    }
}

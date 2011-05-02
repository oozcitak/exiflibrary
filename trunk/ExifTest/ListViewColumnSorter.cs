using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace ExifLibrary
{
    /// <summary>
    /// Sorts the columns of a listview.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        private IComparer mComparer;

        public int SortColumn { get; set; }
        public SortOrder SortOrder { get; set; }
        public IComparer Comparer { get { return mComparer; } }

        public ListViewColumnSorter()
        {
            SortColumn = 0;
            SortOrder = SortOrder.Ascending;

            mComparer = new CaseInsensitiveComparer();
        }

        public ListViewColumnSorter(IComparer comparer)
        {
            SortColumn = 0;
            SortOrder = SortOrder.Ascending;

            mComparer = comparer;
        }

        public int Compare(object x, object y)
        {
            if (SortOrder == SortOrder.None) return 0;

            string xs = ((ListViewItem)x).SubItems[SortColumn].Text;
            string ys = ((ListViewItem)y).SubItems[SortColumn].Text;

            int c = mComparer.Compare(xs, ys);
            if (SortOrder == SortOrder.Descending)
                c *= -1;
            return c;
        }

        public void ReverseSortOrder()
        {
            if (SortOrder == SortOrder.Ascending)
                SortOrder = SortOrder.Descending;
            else
                SortOrder = SortOrder.Ascending;
        }
    }
}

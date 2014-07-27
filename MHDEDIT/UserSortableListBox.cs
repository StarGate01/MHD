using System;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace System.Windows.Forms
{

    public class UserSortableListBox : ListBox
    {

        public class ReorderEventArgs : EventArgs
        {
            public int index1, index2;
        }
        public delegate void ReorderHandler(object sender, ReorderEventArgs e);
        public event ReorderHandler Reorder;

        [Browsable(false)]
        new public bool AllowDrop
        {
            get { return true; }
            set { }
        }
        public UserSortableListBox()
        {
            base.AllowDrop = true;
            base.SelectionMode = SelectionMode.One;
        }

        [Browsable(false)]
        new public SelectionMode SelectionMode
        {
            get { return SelectionMode.One; }
            set { }
        }
        private int sourceIndex = 0;
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);
            System.Drawing.Point point = PointToClient(new System.Drawing.Point(e.X, e.Y));
            int index = IndexFromPoint(point);
            IList items = DataSource != null ? DataSource as IList : Items;
            if (index < 0) index = items.Count - 1;
            if (index != sourceIndex)
            {
                if (index > sourceIndex)
                {
                    items.Insert(index + 1, items[sourceIndex]);
                    items.RemoveAt(sourceIndex);
                }
                else
                {
                    items.Insert(index, items[sourceIndex]);
                    items.RemoveAt(sourceIndex + 1);
                }
                if (null != Reorder) Reorder(this, new ReorderEventArgs() { index1 = sourceIndex, index2 = index });
            }
            SelectedIndex = index;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effect = DragDropEffects.Move | DragDropEffects.Scroll;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == Forms.MouseButtons.Right) return;
            if (e.Clicks == 2) return;
            if (SelectedItem == null) return;
            sourceIndex = SelectedIndex;
            OnSelectedIndexChanged(e);
            DoDragDrop(SelectedItem, DragDropEffects.Move);
        }

    }

}
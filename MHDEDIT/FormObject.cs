#region Using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace MHDEDIT
{

    public partial class FormObject : Form
    {

        #region Initialisation

        public MHD.Content.Level.Data.Object obj = new MHD.Content.Level.Data.Object();

        public FormObject(MHD.Content.Level.Data.Object o)
        {
            if (o != null) obj = o;
            InitializeComponent();
            comboBoxGenerate.Text = comboBoxGenerate.Items[0].ToString();
        }

        #endregion

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            obj = null;
            DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            switch (comboBoxGenerate.Text)
            {
                case "Regular polygon":
                    FormDefineRegularShape shapeGenerator = new FormDefineRegularShape();
                    if (shapeGenerator.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (PointF point in shapeGenerator.Result) listBoxPoints.Items.Add(point);
                        panelRender.Invalidate();
                    }
                    break;
                case "Rectangle":
                    FormDefineRectangle rectangleGenerator = new FormDefineRectangle();
                    if (rectangleGenerator.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (PointF point in rectangleGenerator.Result) listBoxPoints.Items.Add(point);
                        panelRender.Invalidate();
                    }
                    break;
            }
        }

        #region Listbox events

        void listBoxPoints_Reorder(object sender, UserSortableListBox.ReorderEventArgs e)
        {
            panelRender.Invalidate();
        }

        void listBoxPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            editToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = (listBoxPoints.SelectedIndex != -1);
        }

        private void listBoxPoints_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(null, null);
        }

        #endregion

        #region Listbox context menu

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefinePoint definePoint = new FormDefinePoint(new PointF(0, 0));
            if (definePoint.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                listBoxPoints.Items.Add(definePoint.Result);
                panelRender.Invalidate();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefinePoint definePoint = new FormDefinePoint((PointF)listBoxPoints.SelectedItem);
            if (definePoint.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                listBoxPoints.SelectedItem = definePoint.Result;
                panelRender.Invalidate();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxPoints.Items.Remove(listBoxPoints.SelectedItem);
            panelRender.Invalidate();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxPoints.Items.Clear();
            panelRender.Invalidate();
        }

        #endregion

        #region Render

        private void panelRender_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                PointF[] points = listBoxPoints.Items.Cast<PointF>().ToArray();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Matrix transformMatrix = new Matrix();
                transformMatrix.Translate(panelRender.Width / 2, panelRender.Height / 2);
                transformMatrix.Rotate(Convert.ToSingle(textBoxStartRotation.Text));
                e.Graphics.Transform = transformMatrix;
                e.Graphics.FillPolygon(new SolidBrush(buttonFillColor.BackColor), points);
                e.Graphics.DrawPolygon(new Pen(buttonStrokeColor.BackColor, Convert.ToSingle(textBoxStrokeWidth.Text)), points);
            }
            catch { }
        }

        private void textBoxStartRotation_TextChanged(object sender, EventArgs e)
        {
            panelRender.Invalidate();
        }

        private void textBoxStrokeWidth_TextChanged(object sender, EventArgs e)
        {
            panelRender.Invalidate();
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                buttonFillColor.BackColor = colorDialog1.Color;
                panelRender.Invalidate();
            }
        }

        private void buttonStrokeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                buttonStrokeColor.BackColor = colorDialog1.Color;
                panelRender.Invalidate();
            }
        }

        #endregion

    }

}

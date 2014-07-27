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

        public MHD.Content.Level.Data.Object Result = new MHD.Content.Level.Data.Object();

        public FormObject(MHD.Content.Level.Data.Object obj)
        {
            if (obj != null) Result = obj;
            InitializeComponent();
            comboBoxGenerate.Text = comboBoxGenerate.Items[0].ToString();
            SetValues(Result);
        }

        #endregion

        #region Data gui converter

        private void SetValues(MHD.Content.Level.Data.Object objnew)
        {
            textBoxStartPositionX.Text = objnew.StartPosition.X.ToString();
            textBoxStartPositionY.Text = objnew.StartPosition.Y.ToString();
            textBoxStartRotation.Text = Math.Round(objnew.StartRotation / Math.PI * 180, 2).ToString();
            textBoxFillColorAlpha.Text = objnew.Geometry.FillColor.A.ToString();
            buttonFillColor.BackColor = Color.FromArgb(objnew.Geometry.FillColor.R, objnew.Geometry.FillColor.G, objnew.Geometry.FillColor.B);
            textBoxStrokeColorAlpha.Text = Result.Geometry.StrokeColor.A.ToString();
            buttonStrokeColor.BackColor = Color.FromArgb(objnew.Geometry.StrokeColor.R, objnew.Geometry.StrokeColor.G, objnew.Geometry.StrokeColor.B);
            textBoxStrokeWidth.Text = objnew.Geometry.StrokeWidth.ToString();
            foreach (MHD.Content.Level.Data.Point point in objnew.Geometry.Points) listBoxPoints.Items.Add(new PointF(point.X, point.Y));
        }

        private void GetValues()
        {
            Result.StartPosition.X = Convert.ToSingle(textBoxStartPositionX.Text);
            Result.StartPosition.Y = Convert.ToSingle(textBoxStartPositionY.Text);
            Result.StartRotation = Convert.ToSingle(textBoxStartRotation.Text) / 180 * (float)Math.PI;
            Result.Geometry.FillColor = new MHD.Content.Level.Data.Color()
            {
                A = Convert.ToByte(textBoxFillColorAlpha.Text),
                R = buttonFillColor.BackColor.R,
                G = buttonFillColor.BackColor.G,
                B = buttonFillColor.BackColor.B
            };
            Result.Geometry.StrokeColor = new MHD.Content.Level.Data.Color()
            {
                A = Convert.ToByte(textBoxStrokeColorAlpha.Text),
                R = buttonStrokeColor.BackColor.R,
                G = buttonStrokeColor.BackColor.G,
                B = buttonStrokeColor.BackColor.B
            };
            Result.Geometry.StrokeWidth = Convert.ToSingle(textBoxStrokeWidth.Text);
            Result.Geometry.Points.Clear();
            foreach (object item in listBoxPoints.Items) Result.Geometry.Points.Add(new MHD.Content.Level.Data.Point() { X = ((PointF)item).X, Y = ((PointF)item).Y });
        }

        #endregion

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            Result = null;
            DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetValues();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("MHDEDIT - Error", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
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
                transformMatrix.Rotate(Convert.ToSingle(textBoxStartRotation.Text), MatrixOrder.Append); 
                transformMatrix.Translate(panelRender.Width / 2, panelRender.Height / 2, MatrixOrder.Append);
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

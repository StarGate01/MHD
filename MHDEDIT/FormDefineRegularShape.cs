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
    public partial class FormDefineRegularShape : Form
    {

        public PointF[] Result;

        public FormDefineRegularShape()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Result = GetPoints(Convert.ToSingle(textBoxRadius.Text));
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("MHDEDIT - Error", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void numericUpDownCorners_ValueChanged(object sender, EventArgs e)
        {
            panelRender.Invalidate();
        }

        private void panelRender_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPolygon(Brushes.DimGray, GetPoints(50).Select(el => new PointF(el.X + (panelRender.Width / 2), el.Y + (panelRender.Height / 2))).ToArray());
                e.Graphics.DrawPolygon(Pens.Black, GetPoints(50).Select(el => new PointF(el.X + (panelRender.Width / 2), el.Y + (panelRender.Height / 2))).ToArray());
            }
            catch { }
        }

        private PointF[] GetPoints(float radius)
        {
            int cornerCount = Convert.ToInt32(numericUpDownCorners.Value);
            float angle = (float)(Math.PI * 2) / cornerCount;
            PointF[] points = new PointF[cornerCount];
            for (int i = 0; i < cornerCount; i++)
            {
                points[i] = new PointF((float)Math.Cos(angle * i) * radius, (float)Math.Sin(angle * i) * radius);
            }
            return points;
        }

    }
}

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
    public partial class FormDefineRectangle : Form
    {

        public PointF[] Result = new PointF[4];

        public FormDefineRectangle()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                float left = Convert.ToSingle(textBoxX.Text);
                float top = Convert.ToSingle(textBoxY.Text);
                float width = Convert.ToSingle(textBoxWidth.Text);
                float height = Convert.ToSingle(textBoxHeight.Text);
                Result[0] = new PointF(left, top);
                Result[1] = new PointF(left + width, top);
                Result[2] = new PointF(left + width, top + height);
                Result[3] = new PointF(left, top + height);
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

    }
}

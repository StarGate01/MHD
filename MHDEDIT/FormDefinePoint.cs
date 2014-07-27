#region Using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace MHDEDIT
{
    public partial class FormDefinePoint : Form
    {

        public PointF Result;

        public FormDefinePoint(PointF p)
        {
            InitializeComponent();
            textBoxX.Text = p.X.ToString();
            textBoxY.Text = p.Y.ToString();
        }

        private void FormDefinePoint_Load(object sender, EventArgs e)
        {
            textBoxX.Focus();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Result = new PointF(Convert.ToSingle(textBoxX.Text), Convert.ToSingle(textBoxY.Text));
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

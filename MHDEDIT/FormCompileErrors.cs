using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace MHDEDIT
{
    public partial class FormCompileErrors : Form
    {

        private List<string> errors;

        public FormCompileErrors(List<string> err)
        {
            errors = err;
            InitializeComponent();
        }

        private void FormCompileErrors_Load(object sender, EventArgs e)
        {
            foreach (string actError in errors) listBox1.Items.Add(actError);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

    }
}

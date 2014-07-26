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

        private CompilerErrorCollection errors;

        public FormCompileErrors(CompilerErrorCollection err)
        {
            errors = err;
            InitializeComponent();
        }

        private void FormCompileErrors_Load(object sender, EventArgs e)
        {
            foreach (CompilerError actError in errors) {
                //string displayError = actError.FileName + " (" + actError.Line.ToString() + "," + actError.Column.ToString() + ")" + actError.ErrorText + Environment.NewLine;
                //listViewErrors.Items.Add(actError.FileName).SubItems.AddRange(new string[] { actError.Line.ToString(), actError.Column.ToString(), actError.ErrorText } , Color.Black, (actError.IsWarning)? Color.Yellow:Color.Red, buttonOK.Font);
                listBox1.Items.Add(actError.FileName.Substring(actError.FileName.LastIndexOf("\\") + 1) + " (" + actError.Line.ToString() + "," + actError.Column.ToString() + ") " + actError.ErrorText);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

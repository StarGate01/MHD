using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHDEDIT
{
    public partial class FormObject : Form
    {

        private MHD.Content.Level.Object obj = new MHD.Content.Level.Object();

        public FormObject(MHD.Content.Level.Object o = null)
        {
            if (o != null) obj = o;
            InitializeComponent();
        }
    }
}

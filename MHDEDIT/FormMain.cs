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
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Reflection;

#endregion

namespace MHDEDIT
{

    public partial class FormMain : Form
    {

        private string lastSavePath = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SaveLoad.Load(ref treeViewOverview, "EmptyLevel.xml");
            treeViewOverview.Nodes.Find("placeholder", true).ToList().ForEach(f => f.Remove());
            treeViewOverview.Nodes[0].Nodes[0].Collapse();
            treeViewOverview.Nodes[0].Nodes[1].Collapse();
            treeViewOverview.Nodes[0].EnsureVisible();
        }

        #region Main menu

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastSavePath != null)
            {
                try
                {
                    SaveLoad.Save(treeViewOverview, lastSavePath);
                }
                catch (Exception ex)
                {
                    lastSavePath = null;
                    MessageBox.Show(ex.Message, "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to override the current level?", "MHDEDIT - Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes) openFileDialog1.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = Application.ExecutablePath;
            p.Start();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            lastSavePath = saveFileDialog1.FileName;
            saveToolStripMenuItem_Click(null, null);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                SaveLoad.Load(ref treeViewOverview, openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                lastSavePath = null;
                MessageBox.Show(ex.Message, "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Overview Menu

        private void unfoldAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewOverview.ExpandAll();
        }

        private void contractViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewOverview.CollapseAll();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewOverview.SelectedNode != null)
            {
                TreeNode tNode = new TreeNode("Object", 3, 3);
                tNode.Nodes.Add(new TreeNode("UID", 3, 3, new TreeNode[] { new TreeNode(Guid.NewGuid().ToString(), 7, 7) }));
                treeViewOverview.SelectedNode.Nodes.Add(tNode);
                tNode.ExpandAll();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewOverview.SelectedNode != null)
            {
                DialogResult res = MessageBox.Show("Do you want to remove this object?", "MHDEDIT - Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes) treeViewOverview.SelectedNode.Remove();
            }
        }

        #endregion

        private void treeViewOverview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewOverview.SelectedNode != null)
            {
                addToolStripMenuItem.Enabled = (treeViewOverview.SelectedNode.Text == "Objects");
                if (treeViewOverview.SelectedNode.Parent != null) editToolStripMenuItem.Enabled = removeToolStripMenuItem.Enabled = (treeViewOverview.SelectedNode.Parent.Text == "Objects");
                if (treeViewOverview.SelectedNode.GetNodeCount(true) == 0 && !addToolStripMenuItem.Enabled)
                {
                    treeViewOverview.LabelEdit = true;
                    treeViewOverview.SelectedNode.BeginEdit();
                }
            }
        }

        private void treeViewOverview_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            treeViewOverview.LabelEdit = false;
        }


    }

}

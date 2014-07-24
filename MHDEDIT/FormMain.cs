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

        #region private Attributes

        private string lastSavePath = null;
        private MHD.Content.Level.Manager dataManager;

        #endregion

        #region Initialisation

        public FormMain()
        {
            InitializeComponent();
            dataManager = new MHD.Content.Level.Manager(ref treeViewOverview);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dataManager.data = MHD.Content.Level.Converter.XMLToData("EmptyLevel.xml");
            dataManager.Refresh();
            treeViewOverview.ExpandAll();
            treeViewOverview.Nodes[0].Nodes[0].Collapse();
            treeViewOverview.Nodes[0].Nodes[1].Collapse();
            treeViewOverview.Nodes[0].Nodes[2].Collapse();
            treeViewOverview.Nodes[0].EnsureVisible();
            treeViewOverview.SelectedNode = treeViewOverview.Nodes[0];
            treeViewOverview.Focus();
        }

        #endregion

        #region Main menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = Application.ExecutablePath;
            p.Start();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Unsaved changes will be lost.", "MHDEDIT - Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK) openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lastSavePath = openFileDialog1.FileName;
                MHD.Content.Level.Root data = MHD.Content.Level.Converter.XMLToData(lastSavePath);
                dataManager.Refresh();
                treeViewOverview.ExpandAll();
                treeViewOverview.Nodes[0].EnsureVisible();
                treeViewOverview.SelectedNode = treeViewOverview.Nodes[0];
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                lastSavePath = null;
                MessageBox.Show(ex.Message, "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastSavePath != null)
            {
                try
                {
                    MHD.Content.Level.Root data = (MHD.Content.Level.Root)MHD.Content.Level.Converter.NodeToData(treeViewOverview.Nodes[0].Nodes);
                    MHD.Content.Level.Converter.DataToXML(data, lastSavePath);
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

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            lastSavePath = saveFileDialog1.FileName;
            saveToolStripMenuItem_Click(null, null);
        }

        #endregion


        #region Overview

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
            dataManager.data.Objects.Add(new MHD.Content.Level.Object());
            dataManager.Refresh();
            TreeNode tNode = treeViewOverview.Nodes[0].Nodes[2].Nodes[dataManager.data.Objects.Count - 1];
            tNode.EnsureVisible();
            treeViewOverview.SelectedNode = tNode;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewOverview.SelectedNode != null)
            {
                DialogResult res = MessageBox.Show("Do you want to remove this object?", "MHDEDIT - Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    treeViewOverview.SelectedNode.Remove();
                    dataManager.data = (MHD.Content.Level.Root)MHD.Content.Level.Converter.NodeToData(treeViewOverview.Nodes[0].Nodes);
                }
            }
        }

        #endregion

        #region Treeview events

        private void treeViewOverview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewOverview.SelectedNode != null && treeViewOverview.SelectedNode.Parent != null)
            {
                editToolStripMenuItem.Enabled = removeToolStripMenuItem.Enabled = (treeViewOverview.SelectedNode.Parent.Text == "Objects");
                if (treeViewOverview.SelectedNode.GetNodeCount(true) == 0 &&
                    treeViewOverview.SelectedNode.Parent.Text != "UID" &&
                    treeViewOverview.SelectedNode.Text != "Objects")
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

        #endregion

        #endregion

    }

}

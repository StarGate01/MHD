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
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Interactivity;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.SharpDevelop.Dom;

#endregion

namespace MHDEDIT
{

    public partial class FormMain : Form
    {

        #region private Attributes

        private string lastSavePath = null;
        private MHD.Content.Level.Manager dataManager;
        private Lazy<Compile.CSharpScriptCompiler> m_scriptCompiler;
        private Compile.ScriptFile m_currentFile;
        private ICSharpCode.AvalonEdit.TextEditor avalonEditor;
        private CodeCompletionBeahvior avalonCodeCompletionBehaviour;

        #endregion

        #region Initialisation

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dataManager = new MHD.Content.Level.Manager(ref treeViewOverview);
            m_scriptCompiler = new Lazy<Compile.CSharpScriptCompiler>();
            LoadAvalon();
        }

        #endregion


        #region Main menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dataManager.data = new MHD.Content.Level.Data.Root();
            dataManager.LevelScript = Static.StaticStrings.EmptyLevelScriptCode;
            dataManager.ObjectScripts = new Dictionary<string, string>();
            this.Cursor = Cursors.Default;
            if (!SaveAs())
            {
                dataManager.data = null;
                dataManager.LevelScript = "";
            }
            else
            {
                dataManager.Refresh();
                dataManager.SetInit();
                InitTabPages();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    lastSavePath = folderBrowserDialog1.SelectedPath;
                    dataManager.data = MHD.Content.Level.Converter.XMLToData(Path.Combine(lastSavePath, "level.xml"));
                    dataManager.LevelScript = System.IO.File.ReadAllText(Path.Combine(lastSavePath, "level.cs"));
                    dataManager.ObjectScripts = new Dictionary<string, string>();
                    foreach (string file in System.IO.Directory.GetFiles(Path.Combine(lastSavePath, "objectscripts")))
                    {
                        dataManager.ObjectScripts.Add(file.Substring(file.LastIndexOf("\\") + 1), System.IO.File.ReadAllText(file));
                    }
                    dataManager.Refresh();
                    dataManager.SetInit();
                    tabControl1.SelectedTab = TabPageStructure;
                    InitTabPages();
                }
                catch (Exception ex)
                {
                    lastSavePath = null;
                    MessageBox.Show(ex.Message, "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private bool Save()
        {
            if (lastSavePath != null)
            {
                try
                {
                    MHD.Content.Level.Data.Root data = dataManager.data;
                    if (treeViewOverview.Nodes.Count > 0) data = (MHD.Content.Level.Data.Root)MHD.Content.Level.Converter.NodeToData(treeViewOverview.Nodes[0].Nodes);
                    MHD.Content.Level.Converter.DataToXML(data, Path.Combine(lastSavePath, "level.xml"));
                    System.IO.File.WriteAllText(Path.Combine(lastSavePath, "level.cs"), dataManager.LevelScript);
                    System.IO.Directory.CreateDirectory(Path.Combine(lastSavePath, "objectscripts"));
                    foreach (KeyValuePair<string, string> pair in dataManager.ObjectScripts)
                    {
                        System.IO.File.WriteAllText(Path.Combine(lastSavePath, "objectscripts", pair.Key), pair.Value);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    lastSavePath = null;
                    MessageBox.Show(ex.Message, "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return SaveAs();
            }
            return false;
        }

        private bool SaveAs()
        {
            if (dataManager.data != null)
            {
                if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    lastSavePath = folderBrowserDialog1.SelectedPath;
                    return Save();
                }
            }
            else
            {
                MessageBox.Show("No existing level to save", "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabPageStructure)
            {
                if (dataManager.data != null)
                {
                    dataManager.Refresh();
                    dataManager.SetInit();
                }
                else
                {
                    treeViewOverview.Nodes.Clear();
                }
            }
            if (tabControl1.SelectedTab == TabPageCode && dataManager.data != null)
            {
                dataManager.Update();
                tabControlEditor.TabPages[0].Tag = MHD.Content.Level.Converter.DataToXML(dataManager.data);
                if (tabControlEditor.SelectedIndex == 0) tabControlEditor_SelectedIndexChanged(null, null);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"MHDEDIT: MHD Editor
By Christoph Honal

Used components:
 - SharpDX
 - AvalonEdit
 - SharpDevelopCodeCompletion
 - VS 2013 Image Library
", "MHDEDIT - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataManager.data != null)
            {
                saveFileDialog1.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No existing level to save", "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "MHDEDIT - Compile error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Overview

        #region Menu

        private void unfoldAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewOverview.ExpandAll();
        }

        private void contractViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataManager.SetInit();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MHD.Content.Level.Data.Object obj = new MHD.Content.Level.Data.Object();
            obj.Script = obj.UID + ".cs";
            dataManager.data.Objects.Add(obj);
            dataManager.Refresh();
            TreeNode tNode = treeViewOverview.Nodes[0].Nodes[2].Nodes[dataManager.data.Objects.Count - 1];
            tNode.EnsureVisible();
            treeViewOverview.SelectedNode = tNode;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataManager.Update();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewOverview.SelectedNode != null)
            {
                DialogResult res = MessageBox.Show("Do you want to remove this object?", "MHDEDIT - Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    treeViewOverview.SelectedNode.Remove();
                    dataManager.Update();
                }
            }
        }

        private void errorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = TabPageCode;
            tabControlEditor.SelectedIndex = 0;
        }

        #endregion

        #region Treeview

        private void treeViewOverview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            addToolStripMenuItem.Enabled = (treeViewOverview.SelectedNode != null);
            if (treeViewOverview.SelectedNode != null && treeViewOverview.SelectedNode.Parent != null)
            {
                editToolStripMenuItem.Enabled = removeToolStripMenuItem.Enabled = (treeViewOverview.SelectedNode.Parent.Text == "Objects");
                if (treeViewOverview.SelectedNode.Tag != null)
                {
                    treeViewOverview.LabelEdit = true;
                    treeViewOverview.SelectedNode.BeginEdit();
                }
            }
        }

        private void treeViewOverview_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            treeViewOverview.LabelEdit = false;
            dataManager.Update();
        }

        #endregion

        #endregion

        #region Code

        private void LoadAvalon()
        {
            avalonEditor = new ICSharpCode.AvalonEdit.TextEditor();
            avalonEditor.Name = "TextEditor";
            avalonEditor.ShowLineNumbers = true;
            avalonEditor.FontFamily = new System.Windows.Media.FontFamily("Courier New");
            avalonEditor.FontSize = 14;
            avalonEditor.Options.ConvertTabsToSpaces = true;
            avalonEditor.Options.EnableTextDragDrop = true;
            avalonEditor.TextArea.SelectionCornerRadius = 0;
            avalonEditor.IsEnabled = false;
            elementHostEditor.Child = avalonEditor;
            avalonEditor.TextChanged += avalonEditor_TextChanged;
            m_currentFile = new Compile.ScriptFile("");
            avalonEditor.Text = m_currentFile.ScriptContent;
            BehaviorCollection avalonBehahiors = Interaction.GetBehaviors(avalonEditor);
            avalonCodeCompletionBehaviour = new ICSharpCode.AvalonEdit.CodeCompletion.CodeCompletionBeahvior();
            avalonCodeCompletionBehaviour.FilterStrategy = m_currentFile.FilterStrategy;
            avalonCodeCompletionBehaviour.ProjectContent = m_currentFile.ProjectContent;
            avalonBehahiors.Add(avalonCodeCompletionBehaviour);
            SetAvalonMode(false);
        }

        private void SetAvalonMode(Boolean isXML)
        {
            if (!isXML)
            {
                avalonEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C#");
                avalonEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy();
                avalonCodeCompletionBehaviour.ProjectContent = m_currentFile.ProjectContent;
                avalonCodeCompletionBehaviour.FilterStrategy = m_currentFile.FilterStrategy;
            }
            else
            {
                avalonEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("XML");
                avalonEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                avalonCodeCompletionBehaviour.ProjectContent = new DefaultProjectContent();
                avalonCodeCompletionBehaviour.FilterStrategy = new Util.AllFilterStrategy();
            }
        }

        void avalonEditor_TextChanged(object sender, EventArgs e)
        {
            if (tabControlEditor.SelectedTab != null)
            {
                tabControlEditor.SelectedTab.Tag = avalonEditor.Text;
                if (tabControlEditor.SelectedTab.Text == "level.xml")
                {
                    try
                    {
                        tabControlEditor.SelectedTab.Tag = avalonEditor.Text;
                        dataManager.data = MHD.Content.Level.Converter.XMLToData(avalonEditor.Text, false);
                        errorToolStripMenuItem.Visible = false;
                        errorToolStripMenuItem2.Visible = false;
                    }
                    catch
                    {
                        dataManager.data = null;
                        errorToolStripMenuItem.Visible = true;
                        errorToolStripMenuItem2.Visible = true;
                    }
                }
                else if (tabControlEditor.SelectedTab.Text == "level.cs")
                {
                    dataManager.LevelScript = avalonEditor.Text;
                }
                else
                {
                    dataManager.ObjectScripts[tabControlEditor.SelectedTab.Text] = avalonEditor.Text;
                }
            }

        }

        #region TabControl

        private TabPage AddTabPage(string title, string content, string key = null)
        {
            TabPage page = new TabPage(title);
            page.Tag = content;
            page.Name = key;
            tabControlEditor.TabPages.Add(page);
            return page;
        }

        private void InitTabPages()
        {
            tabControlEditor.TabPages.Clear();
            AddTabPage("level.xml", MHD.Content.Level.Converter.DataToXML(dataManager.data));
            AddTabPage("level.cs", dataManager.LevelScript);
            tabControlEditor.SelectedIndex = 1;
        }

        private void tabControlEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlEditor.SelectedTab != null)
            {
                avalonEditor.IsEnabled = true;
                try
                {
                    m_currentFile.ScriptContent = (string)tabControlEditor.SelectedTab.Tag;
                    avalonEditor.Text = m_currentFile.ScriptContent;
                }
                catch { }
                SetAvalonMode(!tabControlEditor.SelectedTab.Text.EndsWith(".cs"));
            }
            else
            {
                avalonEditor.IsEnabled = false;
            }
        }

        private void treeViewOverview_DoubleClick(object sender, EventArgs e)
        {
            if (treeViewOverview.SelectedNode != null && treeViewOverview.SelectedNode.Text.EndsWith(".cs"))
            {
                if (treeViewOverview.SelectedNode.Text == "level.cs")
                {
                    tabControl1.SelectedTab = TabPageCode;
                    tabControlEditor.SelectedIndex = 1;
                }
                else
                {
                    string key = treeViewOverview.SelectedNode.Text;
                    string uid = key.Replace(".cs", "");
                    if (!dataManager.ObjectScripts.ContainsKey(key))
                    {
                        dataManager.ObjectScripts[key] = Static.StaticStrings.EmptyObjectScriptCode.Replace("{%UID%}", uid.Replace("-", "_"));
                    }
                    if (tabControlEditor.TabPages.ContainsKey(uid))
                    {
                        tabControlEditor.SelectedIndex = tabControlEditor.TabPages.IndexOfKey(uid);
                    }
                    else
                    {
                        tabControl1.SelectedTab = TabPageCode;
                        tabControlEditor.SelectedTab = AddTabPage(key, dataManager.ObjectScripts[key], uid);
                    }
                }
            }
        }

        #endregion

        #region Menu

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avalonEditor.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avalonEditor.Undo();
        }

        #endregion


        #endregion

    }

}

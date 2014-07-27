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
using System.CodeDom.Compiler;

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
        private bool addPDBfile = false;

        #endregion

        #region Form

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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing &&
                MessageBox.Show("Do you want to exit MHDEDIT?" + Environment.NewLine + "Unsaved changes will be lost!", "MHDEDIT - Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
        }

        #endregion


        #region Main menu

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == TabPageStructure)
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
            if (tabControlMain.SelectedTab == TabPageCode && dataManager.data != null)
            {
                dataManager.Update();
                tabControlEditor.TabPages[0].Tag = MHD.Content.Level.Converter.DataToXML(dataManager.data);
                if (tabControlEditor.SelectedIndex == 0) tabControlEditor_SelectedIndexChanged(null, null);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataManager.data != null && MessageBox.Show("Do you want to load a new level?" + Environment.NewLine + "Unsaved changes on the current one will be lost!", "MHDEDIT - Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel) return;
            this.Cursor = Cursors.WaitCursor;
            dataManager.data = new MHD.Content.Level.Data.Root();
            dataManager.LevelScript = Static.StaticStrings.EmptyLevelScriptCode;
            dataManager.ObjectScripts = new Dictionary<string, string>();
            dataManager.data.Meta.References.AddRange(new List<string>() {
                "mscorlib.dll", 
                "Microsoft.CSharp.dll", 
                "System.dll", 
                "System.Core.dll", 
                "System.Data.dll", 
                "System.Linq.dll", 
                "System.Reflection.dll", 
                "System.IO.dll", 
                "SharpDX.dll", 
                "SharpDX.Direct3D11.dll", 
                "SharpDX.Direct2D1.dll", 
                "SharpDX.DirectInput.dll",  
                "MHD.exe"
            });
            foreach (string reference in dataManager.data.Meta.References) m_currentFile.ReferencedAssemblies.Add(reference);
            if (!SaveAs())
            {
                dataManager.data = null;
                dataManager.LevelScript = "";
            }
            else
            {
                dataManager.Refresh();
                dataManager.SetInit();
                tabControlMain.SelectedTab = TabPageStructure;
                InitEditorTabPages();
                referenceToolStripMenuItem.Enabled = true;
            }
            this.Cursor = Cursors.Default;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataManager.data != null && MessageBox.Show("Do you want to load a level?" + Environment.NewLine + "Unsaved changes on the current one will be lost!", "MHDEDIT - Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel) return;
            if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    lastSavePath = folderBrowserDialog1.SelectedPath;
                    dataManager.data = MHD.Content.Level.Converter.XMLToData(Path.Combine(lastSavePath, "level.xml"));
                    dataManager.LevelScript = System.IO.File.ReadAllText(Path.Combine(lastSavePath, "level.cs"));
                    dataManager.ObjectScripts = new Dictionary<string, string>();
                    foreach (string reference in dataManager.data.Meta.References) m_currentFile.ReferencedAssemblies.Add(reference);
                    foreach (string file in System.IO.Directory.GetFiles(Path.Combine(lastSavePath, "objectscripts")))
                    {
                        dataManager.ObjectScripts.Add(file.Substring(file.LastIndexOf("\\") + 1), System.IO.File.ReadAllText(file));
                    }
                    dataManager.Refresh();
                    dataManager.SetInit();
                    tabControlMain.SelectedTab = TabPageStructure;
                    InitEditorTabPages();
                    referenceToolStripMenuItem.Enabled = true;
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
                    List<string> codePages = System.IO.Directory.GetFiles(Path.Combine(lastSavePath, "objectscripts"), "*.cs").ToList();
                    List<string> codePagesNames = codePages.Select(el => el.Substring(el.LastIndexOf("\\") + 1)).ToList();
                    foreach (MHD.Content.Level.Data.Object obj in dataManager.data.Objects)
                    {
                        string scriptName = obj.UID + ".cs"; ;
                        if (!codePagesNames.Contains(scriptName))
                        {
                            string scriptPath = Path.Combine(lastSavePath, "objectscripts", scriptName);
                            File.WriteAllText(scriptPath, Static.StaticStrings.EmptyObjectScriptCode.Replace("{%UID%}", obj.UID.Replace("-", "_")));
                        }
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"MHDEDIT: MHD Editor
By Christoph Honal

Used components:
 - SharpDX
 - AvalonEdit by SharpDeleop
 - SharpDevelopCodeCompletion
 - Visual Studio 2013 Image Library
 - UserSortableListBox by synek317@codeproject.org
", "MHDEDIT - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataManager.data != null)
            {
                addPDBfile = false;
                levelToolStripMenuItem.HideDropDown();
                saveFileDialogCompile.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No existing level to compile", "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void compileWithDebugFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataManager.data != null)
            {
                addPDBfile = true;
                levelToolStripMenuItem.HideDropDown();
                saveFileDialogCompile.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existing level to compile", "MHDEDIT - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveFileDialogCompile_FileOk(object sender, CancelEventArgs e)
        {
            Save();
            List<string> codePages = System.IO.Directory.GetFiles(Path.Combine(lastSavePath, "objectscripts"), "*.cs").ToList();
            codePages.Add(Path.Combine(lastSavePath, "level.cs"));
            CompilerErrorCollection errors = m_scriptCompiler.Value.CompileAndSave(m_currentFile, codePages.ToArray(), Path.Combine(lastSavePath, "level.xml"), addPDBfile, saveFileDialogCompile.FileName);
            if(errors.Count > 0)
            {
                FormCompileErrors errorForm = new FormCompileErrors(errors);
                errorForm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Compiling completed", "MHDEDIT - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Overview

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

        private void treeViewOverview_DoubleClick(object sender, EventArgs e)
        {
            if (treeViewOverview.SelectedNode != null && treeViewOverview.SelectedNode.Text.EndsWith(".cs"))
            {
                if (treeViewOverview.SelectedNode.Text == "level.cs")
                {
                    tabControlMain.SelectedTab = TabPageCode;
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
                    int isFileOpen = -1;
                    foreach(TabPage page in  tabControlEditor.TabPages)
                    {
                        if (page.Text == key) { isFileOpen = tabControlEditor.TabPages.IndexOf(page); break; }
                    }
                    if (isFileOpen != -1)
                    {
                        tabControlEditor.SelectedIndex = isFileOpen;
                        tabControlMain.SelectedTab = TabPageCode;
                    }
                    else
                    {
                        tabControlMain.SelectedTab = TabPageCode;
                        tabControlEditor.SelectedTab = AddEditorTabPage(key, dataManager.ObjectScripts[key], uid);
                    }
                }
            }
        }

        #endregion

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
            FormObject objectEditor = new FormObject(obj);
            if(objectEditor.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                dataManager.data.Objects.Add(objectEditor.Result);
                dataManager.Refresh();
                TreeNode tNode = treeViewOverview.Nodes[0].Nodes[2].Nodes[dataManager.data.Objects.Count - 1];
                tNode.EnsureVisible();
                treeViewOverview.SelectedNode = tNode;
            }
        }

        private void addEmptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MHD.Content.Level.Data.Object obj = new MHD.Content.Level.Data.Object();
            obj.Script = obj.UID + ".cs";
            dataManager.data.Objects.Add(obj);
            dataManager.Refresh();
            dataManager.SetInit();
            TreeNode tNode = treeViewOverview.Nodes[0].Nodes[2].Nodes[dataManager.data.Objects.Count - 1];
            tNode.EnsureVisible();
            treeViewOverview.SelectedNode = tNode;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uid = "";
            foreach(TreeNode node in treeViewOverview.SelectedNode.Nodes) if(node.Text == "UID") uid = node.Nodes[0].Text;
            MHD.Content.Level.Data.Object obj = dataManager.data.Objects.FirstOrDefault(el => el.UID == uid);
            if(obj != null)
            {
                FormObject objectEditor = new FormObject(obj);
                obj = objectEditor.Result;
                if (objectEditor.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    dataManager.Refresh();
                    dataManager.SetInit();
                }
            }
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
            tabControlMain.SelectedTab = TabPageCode;
            tabControlEditor.SelectedIndex = 0;
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
                        errorToolStripMenuItem.Visible = errorToolStripMenuItem2.Visible = false;
                    }
                    catch
                    {
                        dataManager.data = null;
                        errorToolStripMenuItem.Visible = errorToolStripMenuItem2.Visible = true;
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

        private TabPage AddEditorTabPage(string title, string content, string key = null)
        {
            TabPage page = new TabPage(title);
            page.Tag = content;
            page.Name = key;
            tabControlEditor.TabPages.Add(page);
            return page;
        }

        private void InitEditorTabPages()
        {
            tabControlEditor.TabPages.Clear();
            AddEditorTabPage("level.xml", MHD.Content.Level.Converter.DataToXML(dataManager.data));
            AddEditorTabPage("level.cs", dataManager.LevelScript);
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

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search(toolStripTextBoxSearch.Text, avalonEditor.SelectionStart + avalonEditor.SelectionLength);
        }

        private void Search(string query, int start, bool cancel = false)
        {
            int index = avalonEditor.Text.IndexOf(query, start);
            if (index == -1 && !cancel) Search(query, 0, true);
            if (index != -1)
            {
                avalonEditor.Select(index, query.Length);
                avalonEditor.ScrollToLine(avalonEditor.TextArea.Document.GetLineByOffset(index).LineNumber);
            }
        }

        #endregion

        #endregion

    }

}

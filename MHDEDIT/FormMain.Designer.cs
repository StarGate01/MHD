namespace MHDEDIT
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileWithDebugFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.TabPageStructure = new System.Windows.Forms.TabPage();
            this.treeViewOverview = new System.Windows.Forms.TreeView();
            this.imageListOverview = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfoldAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageCode = new System.Windows.Forms.TabPage();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.elementHostEditor = new System.Windows.Forms.Integration.ElementHost();
            this.tabControlEditor = new System.Windows.Forms.TabControl();
            this.menuStripCode = new System.Windows.Forms.MenuStrip();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageRender = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialogCompile = new System.Windows.Forms.SaveFileDialog();
            this.menuStripMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.TabPageStructure.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.TabPageCode.SuspendLayout();
            this.panelEditor.SuspendLayout();
            this.menuStripCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStripMain.Size = new System.Drawing.Size(995, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.compileToolStripMenuItem,
            this.testToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "&Level";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.application_16xLG;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Folder_6221;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.save_16xLG;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.save_16xLG;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeyDisplayString = "Strg+Shift+S";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileWithDebugFileToolStripMenuItem});
            this.compileToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.BuildSolution_104;
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.compileToolStripMenuItem.Text = "&Compile";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // compileWithDebugFileToolStripMenuItem
            // 
            this.compileWithDebugFileToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.BuildSolution_104;
            this.compileWithDebugFileToolStripMenuItem.Name = "compileWithDebugFileToolStripMenuItem";
            this.compileWithDebugFileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.compileWithDebugFileToolStripMenuItem.Text = "Compile with debug file";
            this.compileWithDebugFileToolStripMenuItem.Click += new System.EventHandler(this.compileWithDebugFileToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.arrow_run_16xLG;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.testToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.testToolStripMenuItem.Text = "&Test";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referenceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // referenceToolStripMenuItem
            // 
            this.referenceToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Symbols_Help_and_inclusive_16xLG;
            this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
            this.referenceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.referenceToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.referenceToolStripMenuItem.Text = "&Reference";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Symbols_Information_16xLG;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.TabPageStructure);
            this.tabControlMain.Controls.Add(this.TabPageCode);
            this.tabControlMain.Controls.Add(this.TabPageRender);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(995, 652);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // TabPageStructure
            // 
            this.TabPageStructure.Controls.Add(this.treeViewOverview);
            this.TabPageStructure.Controls.Add(this.menuStrip1);
            this.TabPageStructure.Location = new System.Drawing.Point(4, 22);
            this.TabPageStructure.Name = "TabPageStructure";
            this.TabPageStructure.Size = new System.Drawing.Size(987, 626);
            this.TabPageStructure.TabIndex = 2;
            this.TabPageStructure.Text = "Structure";
            this.TabPageStructure.UseVisualStyleBackColor = true;
            // 
            // treeViewOverview
            // 
            this.treeViewOverview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewOverview.ImageIndex = 7;
            this.treeViewOverview.ImageList = this.imageListOverview;
            this.treeViewOverview.Location = new System.Drawing.Point(0, 24);
            this.treeViewOverview.Name = "treeViewOverview";
            this.treeViewOverview.SelectedImageIndex = 7;
            this.treeViewOverview.Size = new System.Drawing.Size(987, 602);
            this.treeViewOverview.TabIndex = 0;
            this.treeViewOverview.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewOverview_AfterLabelEdit);
            this.treeViewOverview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewOverview_AfterSelect);
            this.treeViewOverview.DoubleClick += new System.EventHandler(this.treeViewOverview_DoubleClick);
            // 
            // imageListOverview
            // 
            this.imageListOverview.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListOverview.ImageStream")));
            this.imageListOverview.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListOverview.Images.SetKeyName(0, "Folder_6222.png");
            this.imageListOverview.Images.SetKeyName(1, "Folder_6221.png");
            this.imageListOverview.Images.SetKeyName(2, "application_16xLG.png");
            this.imageListOverview.Images.SetKeyName(3, "ASCube_16xLG.png");
            this.imageListOverview.Images.SetKeyName(4, "Actor_16xLG.png");
            this.imageListOverview.Images.SetKeyName(5, "Animation_10763_12x.png");
            this.imageListOverview.Images.SetKeyName(6, "class_16xLG.png");
            this.imageListOverview.Images.SetKeyName(7, "FieldIcon.png");
            this.imageListOverview.Images.SetKeyName(8, "XMLFile_828_32x.png");
            this.imageListOverview.Images.SetKeyName(9, "CSharpFile_SolutionExplorerNode.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectToolStripMenuItem,
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.contractViewToolStripMenuItem,
            this.unfoldAllToolStripMenuItem,
            this.errorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.Enabled = false;
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.objectToolStripMenuItem.Text = "Object: ";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.AddMark_10580;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.addToolStripMenuItem.Text = "&Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Hammer_Builder_16xLG;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.action_Cancel_16xLG;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.removeToolStripMenuItem.Text = "&Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // contractViewToolStripMenuItem
            // 
            this.contractViewToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.contractViewToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.arrow_Down_16xLG;
            this.contractViewToolStripMenuItem.Name = "contractViewToolStripMenuItem";
            this.contractViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.contractViewToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.contractViewToolStripMenuItem.Text = "Collapse view";
            this.contractViewToolStripMenuItem.Click += new System.EventHandler(this.contractViewToolStripMenuItem_Click);
            // 
            // unfoldAllToolStripMenuItem
            // 
            this.unfoldAllToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.unfoldAllToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.arrow_Up_16xLG;
            this.unfoldAllToolStripMenuItem.Name = "unfoldAllToolStripMenuItem";
            this.unfoldAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.unfoldAllToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.unfoldAllToolStripMenuItem.Text = "Expand view";
            this.unfoldAllToolStripMenuItem.Click += new System.EventHandler(this.unfoldAllToolStripMenuItem_Click);
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.errorToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.errorToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.StatusAnnotations_Warning_32xLG_color;
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.errorToolStripMenuItem.Text = "Error: Invalid markup";
            this.errorToolStripMenuItem.Visible = false;
            this.errorToolStripMenuItem.Click += new System.EventHandler(this.errorToolStripMenuItem_Click);
            // 
            // TabPageCode
            // 
            this.TabPageCode.Controls.Add(this.panelEditor);
            this.TabPageCode.Controls.Add(this.tabControlEditor);
            this.TabPageCode.Controls.Add(this.menuStripCode);
            this.TabPageCode.Location = new System.Drawing.Point(4, 22);
            this.TabPageCode.Name = "TabPageCode";
            this.TabPageCode.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCode.Size = new System.Drawing.Size(723, 335);
            this.TabPageCode.TabIndex = 1;
            this.TabPageCode.Text = "Code";
            this.TabPageCode.UseVisualStyleBackColor = true;
            // 
            // panelEditor
            // 
            this.panelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditor.Controls.Add(this.elementHostEditor);
            this.panelEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditor.Location = new System.Drawing.Point(3, 48);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(717, 284);
            this.panelEditor.TabIndex = 2;
            // 
            // elementHostEditor
            // 
            this.elementHostEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostEditor.Location = new System.Drawing.Point(0, 0);
            this.elementHostEditor.Name = "elementHostEditor";
            this.elementHostEditor.Size = new System.Drawing.Size(715, 282);
            this.elementHostEditor.TabIndex = 0;
            this.elementHostEditor.Text = "elementHost1";
            this.elementHostEditor.Child = null;
            // 
            // tabControlEditor
            // 
            this.tabControlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlEditor.ImageList = this.imageListOverview;
            this.tabControlEditor.Location = new System.Drawing.Point(3, 27);
            this.tabControlEditor.Name = "tabControlEditor";
            this.tabControlEditor.SelectedIndex = 0;
            this.tabControlEditor.Size = new System.Drawing.Size(717, 21);
            this.tabControlEditor.TabIndex = 1;
            this.tabControlEditor.SelectedIndexChanged += new System.EventHandler(this.tabControlEditor_SelectedIndexChanged);
            // 
            // menuStripCode
            // 
            this.menuStripCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.errorToolStripMenuItem2});
            this.menuStripCode.Location = new System.Drawing.Point(3, 3);
            this.menuStripCode.Name = "menuStripCode";
            this.menuStripCode.Size = new System.Drawing.Size(717, 24);
            this.menuStripCode.TabIndex = 1;
            this.menuStripCode.Text = "menuStrip2";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Undo_16x;
            this.undoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.undoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Redo_16x;
            this.redoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // errorToolStripMenuItem2
            // 
            this.errorToolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.errorToolStripMenuItem2.ForeColor = System.Drawing.Color.Red;
            this.errorToolStripMenuItem2.Image = global::MHDEDIT.Properties.Resources.StatusAnnotations_Warning_32xLG_color;
            this.errorToolStripMenuItem2.Name = "errorToolStripMenuItem2";
            this.errorToolStripMenuItem2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.errorToolStripMenuItem2.Size = new System.Drawing.Size(145, 20);
            this.errorToolStripMenuItem2.Text = "Error: Invalid markup";
            this.errorToolStripMenuItem2.Visible = false;
            // 
            // TabPageRender
            // 
            this.TabPageRender.Location = new System.Drawing.Point(4, 22);
            this.TabPageRender.Name = "TabPageRender";
            this.TabPageRender.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRender.Size = new System.Drawing.Size(723, 335);
            this.TabPageRender.TabIndex = 0;
            this.TabPageRender.Text = "Render";
            this.TabPageRender.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Please select a project folder";
            // 
            // saveFileDialogCompile
            // 
            this.saveFileDialogCompile.DefaultExt = "dll";
            this.saveFileDialogCompile.FileName = "level.dll";
            this.saveFileDialogCompile.Filter = "Dynamic link library|*.dll";
            this.saveFileDialogCompile.Title = "Save compiled level";
            this.saveFileDialogCompile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogCompile_FileOk);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 676);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MHDEDIT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.TabPageStructure.ResumeLayout(false);
            this.TabPageStructure.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabPageCode.ResumeLayout(false);
            this.TabPageCode.PerformLayout();
            this.panelEditor.ResumeLayout(false);
            this.menuStripCode.ResumeLayout(false);
            this.menuStripCode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage TabPageStructure;
        private System.Windows.Forms.TabPage TabPageRender;
        private System.Windows.Forms.TabPage TabPageCode;
        private System.Windows.Forms.TreeView treeViewOverview;
        private System.Windows.Forms.ImageList imageListOverview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unfoldAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
        private System.Windows.Forms.Integration.ElementHost elementHostEditor;
        private System.Windows.Forms.TabControl tabControlEditor;
        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.MenuStrip menuStripCode;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCompile;
        private System.Windows.Forms.ToolStripMenuItem compileWithDebugFileToolStripMenuItem;
    }
}


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
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageStructure = new System.Windows.Forms.TabPage();
            this.treeViewOverview = new System.Windows.Forms.TreeView();
            this.imageListOverview = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfoldAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageCode = new System.Windows.Forms.TabPage();
            this.TabPageRender = new System.Windows.Forms.TabPage();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPageStructure.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.menuStripMain.Size = new System.Drawing.Size(831, 24);
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
            this.testToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "&Level";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.application_16xLG;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Folder_6221;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.save_16xLG;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.save_16xLG;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.arrow_run_16xLG;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
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
            this.referenceToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.referenceToolStripMenuItem.Text = "&Reference";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Symbols_Information_16xLG;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageStructure);
            this.tabControl1.Controls.Add(this.TabPageCode);
            this.tabControl1.Controls.Add(this.TabPageRender);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 570);
            this.tabControl1.TabIndex = 1;
            // 
            // TabPageStructure
            // 
            this.TabPageStructure.Controls.Add(this.treeViewOverview);
            this.TabPageStructure.Controls.Add(this.menuStrip1);
            this.TabPageStructure.Location = new System.Drawing.Point(4, 22);
            this.TabPageStructure.Name = "TabPageStructure";
            this.TabPageStructure.Size = new System.Drawing.Size(823, 544);
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
            this.treeViewOverview.Size = new System.Drawing.Size(823, 520);
            this.treeViewOverview.TabIndex = 0;
            this.treeViewOverview.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewOverview_AfterLabelEdit);
            this.treeViewOverview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewOverview_AfterSelect);
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
            this.unfoldAllToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.AddMark_10580;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.addToolStripMenuItem.Text = "&Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Hammer_Builder_16xLG;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.action_Cancel_16xLG;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.removeToolStripMenuItem.Text = "&Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // contractViewToolStripMenuItem
            // 
            this.contractViewToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.contractViewToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.arrow_Down_16xLG;
            this.contractViewToolStripMenuItem.Name = "contractViewToolStripMenuItem";
            this.contractViewToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.contractViewToolStripMenuItem.Text = "Collapse view";
            this.contractViewToolStripMenuItem.Click += new System.EventHandler(this.contractViewToolStripMenuItem_Click);
            // 
            // unfoldAllToolStripMenuItem
            // 
            this.unfoldAllToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.unfoldAllToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.arrow_Up_16xLG;
            this.unfoldAllToolStripMenuItem.Name = "unfoldAllToolStripMenuItem";
            this.unfoldAllToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.unfoldAllToolStripMenuItem.Text = "Expand view";
            this.unfoldAllToolStripMenuItem.Click += new System.EventHandler(this.unfoldAllToolStripMenuItem_Click);
            // 
            // TabPageCode
            // 
            this.TabPageCode.Location = new System.Drawing.Point(4, 22);
            this.TabPageCode.Name = "TabPageCode";
            this.TabPageCode.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCode.Size = new System.Drawing.Size(823, 522);
            this.TabPageCode.TabIndex = 1;
            this.TabPageCode.Text = "Code";
            this.TabPageCode.UseVisualStyleBackColor = true;
            // 
            // TabPageRender
            // 
            this.TabPageRender.Location = new System.Drawing.Point(4, 22);
            this.TabPageRender.Name = "TabPageRender";
            this.TabPageRender.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRender.Size = new System.Drawing.Size(823, 522);
            this.TabPageRender.TabIndex = 0;
            this.TabPageRender.Text = "Render";
            this.TabPageRender.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.FileName = "level.xml";
            this.saveFileDialog1.Filter = "XML|*xml";
            this.saveFileDialog1.Title = "Save level";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "level.xml";
            this.openFileDialog1.Filter = "XML|*xml";
            this.openFileDialog1.Title = "Open level";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.Enabled = false;
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.objectToolStripMenuItem.Text = "Object: ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 594);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MHDEDIT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPageStructure.ResumeLayout(false);
            this.TabPageStructure.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
    }
}


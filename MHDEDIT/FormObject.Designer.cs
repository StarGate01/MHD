namespace MHDEDIT
{
    partial class FormObject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxStrokeWidth = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonStrokeColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonFillColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxStartRotation = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStartPositionY = new System.Windows.Forms.TextBox();
            this.textBoxStartPositionX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxGenerate = new System.Windows.Forms.ComboBox();
            this.panelRender = new System.Windows.Forms.Panel();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.groupBoxPoints = new System.Windows.Forms.GroupBox();
            this.contextMenuStripPoints = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxPoints = new System.Windows.Forms.UserSortableListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.contextMenuStripPoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(432, 487);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonAbort
            // 
            this.buttonAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAbort.Location = new System.Drawing.Point(513, 487);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(75, 23);
            this.buttonAbort.TabIndex = 1;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 104);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxStrokeWidth);
            this.groupBox6.Location = new System.Drawing.Point(457, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(113, 78);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "StrokeWidth";
            // 
            // textBoxStrokeWidth
            // 
            this.textBoxStrokeWidth.Location = new System.Drawing.Point(6, 16);
            this.textBoxStrokeWidth.Name = "textBoxStrokeWidth";
            this.textBoxStrokeWidth.Size = new System.Drawing.Size(101, 20);
            this.textBoxStrokeWidth.TabIndex = 6;
            this.textBoxStrokeWidth.Text = "1";
            this.textBoxStrokeWidth.TextChanged += new System.EventHandler(this.textBoxStrokeWidth_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.buttonStrokeColor);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.buttonFillColor);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(240, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(211, 78);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Colors";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(154, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(32, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "255";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(154, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(32, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "255";
            // 
            // buttonStrokeColor
            // 
            this.buttonStrokeColor.BackColor = System.Drawing.Color.Black;
            this.buttonStrokeColor.Location = new System.Drawing.Point(77, 48);
            this.buttonStrokeColor.Name = "buttonStrokeColor";
            this.buttonStrokeColor.Size = new System.Drawing.Size(71, 23);
            this.buttonStrokeColor.TabIndex = 3;
            this.buttonStrokeColor.UseVisualStyleBackColor = false;
            this.buttonStrokeColor.Click += new System.EventHandler(this.buttonStrokeColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "StrokeColor:";
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.BackColor = System.Drawing.Color.DimGray;
            this.buttonFillColor.Location = new System.Drawing.Point(77, 19);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(71, 23);
            this.buttonFillColor.TabIndex = 1;
            this.buttonFillColor.UseVisualStyleBackColor = false;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FillColor: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxStartRotation);
            this.groupBox3.Location = new System.Drawing.Point(123, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 78);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "StartRotation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "(Degrees)";
            // 
            // textBoxStartRotation
            // 
            this.textBoxStartRotation.Location = new System.Drawing.Point(6, 19);
            this.textBoxStartRotation.Name = "textBoxStartRotation";
            this.textBoxStartRotation.Size = new System.Drawing.Size(99, 20);
            this.textBoxStartRotation.TabIndex = 5;
            this.textBoxStartRotation.Text = "0";
            this.textBoxStartRotation.TextChanged += new System.EventHandler(this.textBoxStartRotation_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxStartPositionY);
            this.groupBox2.Controls.Add(this.textBoxStartPositionX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 79);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "StartPosition";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X:";
            // 
            // textBoxStartPositionY
            // 
            this.textBoxStartPositionY.Location = new System.Drawing.Point(29, 45);
            this.textBoxStartPositionY.Name = "textBoxStartPositionY";
            this.textBoxStartPositionY.Size = new System.Drawing.Size(76, 20);
            this.textBoxStartPositionY.TabIndex = 7;
            this.textBoxStartPositionY.Text = "0";
            // 
            // textBoxStartPositionX
            // 
            this.textBoxStartPositionX.Location = new System.Drawing.Point(29, 19);
            this.textBoxStartPositionX.Name = "textBoxStartPositionX";
            this.textBoxStartPositionX.Size = new System.Drawing.Size(76, 20);
            this.textBoxStartPositionX.TabIndex = 5;
            this.textBoxStartPositionX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxGenerate);
            this.groupBox5.Controls.Add(this.panelRender);
            this.groupBox5.Controls.Add(this.buttonGenerate);
            this.groupBox5.Controls.Add(this.groupBoxPoints);
            this.groupBox5.Location = new System.Drawing.Point(12, 122);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(576, 359);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Geometry";
            // 
            // comboBoxGenerate
            // 
            this.comboBoxGenerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenerate.FormattingEnabled = true;
            this.comboBoxGenerate.Items.AddRange(new object[] {
            "Rectangle",
            "Regular polygon"});
            this.comboBoxGenerate.Location = new System.Drawing.Point(6, 332);
            this.comboBoxGenerate.Name = "comboBoxGenerate";
            this.comboBoxGenerate.Size = new System.Drawing.Size(128, 21);
            this.comboBoxGenerate.TabIndex = 18;
            // 
            // panelRender
            // 
            this.panelRender.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelRender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRender.Location = new System.Drawing.Point(237, 19);
            this.panelRender.Name = "panelRender";
            this.panelRender.Size = new System.Drawing.Size(333, 333);
            this.panelRender.TabIndex = 17;
            this.panelRender.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRender_Paint);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(140, 330);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(88, 24);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // groupBoxPoints
            // 
            this.groupBoxPoints.Location = new System.Drawing.Point(6, 19);
            this.groupBoxPoints.Name = "groupBoxPoints";
            this.groupBoxPoints.Size = new System.Drawing.Size(222, 304);
            this.groupBoxPoints.TabIndex = 1;
            this.groupBoxPoints.TabStop = false;
            this.groupBoxPoints.Text = "Points";
            // 
            // contextMenuStripPoints
            // 
            this.contextMenuStripPoints.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearToolStripMenuItem});
            this.contextMenuStripPoints.Name = "contextMenuStripPoints";
            this.contextMenuStripPoints.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripPoints.Size = new System.Drawing.Size(108, 98);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.AddMark_10580;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.Hammer_Builder_16xLG;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.action_Cancel_16xLG;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::MHDEDIT.Properties.Resources.action_Cancel_16xLG;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "α";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "α";
            // 
            // listBoxPoints
            // 
            this.listBoxPoints.AllowDrop = true;
            this.listBoxPoints.ContextMenuStrip = this.contextMenuStripPoints;
            this.listBoxPoints.FormattingEnabled = true;
            this.listBoxPoints.Location = new System.Drawing.Point(24, 160);
            this.listBoxPoints.Name = "listBoxPoints";
            this.listBoxPoints.Size = new System.Drawing.Size(210, 277);
            this.listBoxPoints.TabIndex = 0;
            this.listBoxPoints.Reorder += new System.Windows.Forms.UserSortableListBox.ReorderHandler(this.listBoxPoints_Reorder);
            this.listBoxPoints.SelectedIndexChanged += new System.EventHandler(this.listBoxPoints_SelectedIndexChanged);
            this.listBoxPoints.DoubleClick += new System.EventHandler(this.listBoxPoints_DoubleClick);
            // 
            // FormObject
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonAbort;
            this.ClientSize = new System.Drawing.Size(600, 522);
            this.ControlBox = false;
            this.Controls.Add(this.listBoxPoints);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormObject";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add or edit object";
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.contextMenuStripPoints.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxStartRotation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStartPositionY;
        private System.Windows.Forms.TextBox textBoxStartPositionX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonStrokeColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBoxPoints;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPoints;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Panel panelRender;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxStrokeWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxGenerate;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.UserSortableListBox listBoxPoints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;

    }
}
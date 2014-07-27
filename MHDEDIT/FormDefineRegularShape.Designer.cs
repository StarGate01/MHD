namespace MHDEDIT
{
    partial class FormDefineRegularShape
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
            this.buttonAbort = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelRender = new System.Windows.Forms.Panel();
            this.numericUpDownCorners = new System.Windows.Forms.NumericUpDown();
            this.textBoxRadius = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorners)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAbort
            // 
            this.buttonAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAbort.Location = new System.Drawing.Point(255, 116);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(75, 23);
            this.buttonAbort.TabIndex = 3;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(174, 116);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Radius:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Corners:";
            // 
            // panelRender
            // 
            this.panelRender.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelRender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRender.Location = new System.Drawing.Point(11, 12);
            this.panelRender.Name = "panelRender";
            this.panelRender.Size = new System.Drawing.Size(127, 127);
            this.panelRender.TabIndex = 16;
            this.panelRender.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRender_Paint);
            // 
            // numericUpDownCorners
            // 
            this.numericUpDownCorners.Location = new System.Drawing.Point(196, 39);
            this.numericUpDownCorners.Name = "numericUpDownCorners";
            this.numericUpDownCorners.Size = new System.Drawing.Size(134, 20);
            this.numericUpDownCorners.TabIndex = 1;
            this.numericUpDownCorners.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownCorners.ValueChanged += new System.EventHandler(this.numericUpDownCorners_ValueChanged);
            this.numericUpDownCorners.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownCorners_KeyDown);
            // 
            // textBoxRadius
            // 
            this.textBoxRadius.Location = new System.Drawing.Point(196, 12);
            this.textBoxRadius.Name = "textBoxRadius";
            this.textBoxRadius.Size = new System.Drawing.Size(134, 20);
            this.textBoxRadius.TabIndex = 0;
            this.textBoxRadius.Text = "20";
            // 
            // FormDefineRegularShape
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonAbort;
            this.ClientSize = new System.Drawing.Size(342, 151);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDownCorners);
            this.Controls.Add(this.panelRender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxRadius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDefineRegularShape";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MHDEDIT - Define regular shape";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelRender;
        private System.Windows.Forms.NumericUpDown numericUpDownCorners;
        private System.Windows.Forms.TextBox textBoxRadius;
    }
}
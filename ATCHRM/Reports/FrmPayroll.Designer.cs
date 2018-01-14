namespace ATCHRM.Reports
{
    partial class FrmPayroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayroll));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.LblstrDt = new System.Windows.Forms.Label();
            this.LblEdt = new System.Windows.Forms.Label();
            this.LblLoc = new System.Windows.Forms.Label();
            this.LblDept = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(974, 579);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 554);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(974, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton1.Text = "Close";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton2.Text = "Preview";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // LblstrDt
            // 
            this.LblstrDt.AutoSize = true;
            this.LblstrDt.Location = new System.Drawing.Point(530, 92);
            this.LblstrDt.Name = "LblstrDt";
            this.LblstrDt.Size = new System.Drawing.Size(41, 13);
            this.LblstrDt.TabIndex = 2;
            this.LblstrDt.Text = "lblStrDt";
            this.LblstrDt.Visible = false;
            // 
            // LblEdt
            // 
            this.LblEdt.AutoSize = true;
            this.LblEdt.Location = new System.Drawing.Point(530, 39);
            this.LblEdt.Name = "LblEdt";
            this.LblEdt.Size = new System.Drawing.Size(39, 13);
            this.LblEdt.TabIndex = 3;
            this.LblEdt.Text = "LblEDt";
            this.LblEdt.Visible = false;
            // 
            // LblLoc
            // 
            this.LblLoc.AutoSize = true;
            this.LblLoc.Location = new System.Drawing.Point(661, 109);
            this.LblLoc.Name = "LblLoc";
            this.LblLoc.Size = new System.Drawing.Size(35, 13);
            this.LblLoc.TabIndex = 4;
            this.LblLoc.Text = "label1";
            this.LblLoc.Visible = false;
            // 
            // LblDept
            // 
            this.LblDept.AutoSize = true;
            this.LblDept.Location = new System.Drawing.Point(661, 62);
            this.LblDept.Name = "LblDept";
            this.LblDept.Size = new System.Drawing.Size(35, 13);
            this.LblDept.TabIndex = 5;
            this.LblDept.Text = "label2";
            this.LblDept.Visible = false;
            // 
            // FrmPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(974, 579);
            this.Controls.Add(this.LblDept);
            this.Controls.Add(this.LblLoc);
            this.Controls.Add(this.LblEdt);
            this.Controls.Add(this.LblstrDt);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FrmPayroll";
            this.Text = "FrmPayroll";
            this.Load += new System.EventHandler(this.FrmPayroll_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.Label LblstrDt;
        public System.Windows.Forms.Label LblEdt;
        public System.Windows.Forms.Label LblLoc;
        public System.Windows.Forms.Label LblDept;
    }
}
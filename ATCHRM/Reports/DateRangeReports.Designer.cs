namespace ATCHRM.Reports
{
    partial class DateRangeReports
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Crvt_ApplicationReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.synchronizeabscnet = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceAfterConfirmOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractEndingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.pendingExceptionBeforeAdjusterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingExceptionAfterAdjusterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Crvt_ApplicationReport);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 628);
            this.panel1.TabIndex = 0;
            // 
            // Crvt_ApplicationReport
            // 
            this.Crvt_ApplicationReport.ActiveViewIndex = -1;
            this.Crvt_ApplicationReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Crvt_ApplicationReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.Crvt_ApplicationReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Crvt_ApplicationReport.Location = new System.Drawing.Point(0, 110);
            this.Crvt_ApplicationReport.Name = "Crvt_ApplicationReport";
            this.Crvt_ApplicationReport.Size = new System.Drawing.Size(1204, 518);
            this.Crvt_ApplicationReport.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1204, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // menuStrip7
            // 
            this.menuStrip7.AllowMerge = false;
            this.menuStrip7.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip7.DataBindings.Add(new System.Windows.Forms.Binding("DefaultDropDownDirection", global::ATCHRM.Properties.Settings.Default, "foractionnew", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.menuStrip7.DefaultDropDownDirection = global::ATCHRM.Properties.Settings.Default.foractionnew;
            this.menuStrip7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.synchronizeabscnet,
            this.attendanceAfterConfirmOTToolStripMenuItem,
            this.contractEndingReportToolStripMenuItem,
            this.pendingExceptionBeforeAdjusterToolStripMenuItem,
            this.pendingExceptionAfterAdjusterToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(3, 83);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(1198, 24);
            this.menuStrip7.TabIndex = 32;
            this.menuStrip7.Text = "menuStrip7";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Image = global::ATCHRM.Properties.Resources.cancel;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem2.Text = "Cancel";
            // 
            // synchronizeabscnet
            // 
            this.synchronizeabscnet.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.synchronizeabscnet.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.synchronizeabscnet.Image = global::ATCHRM.Properties.Resources.arrow_rotate_anticlockwise;
            this.synchronizeabscnet.Name = "synchronizeabscnet";
            this.synchronizeabscnet.Size = new System.Drawing.Size(203, 20);
            this.synchronizeabscnet.Text = "Attendance Before Confirm OT";
            this.synchronizeabscnet.Click += new System.EventHandler(this.synchronizeabscnet_Click);
            // 
            // attendanceAfterConfirmOTToolStripMenuItem
            // 
            this.attendanceAfterConfirmOTToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.attendanceAfterConfirmOTToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.attendanceAfterConfirmOTToolStripMenuItem.Name = "attendanceAfterConfirmOTToolStripMenuItem";
            this.attendanceAfterConfirmOTToolStripMenuItem.Size = new System.Drawing.Size(178, 20);
            this.attendanceAfterConfirmOTToolStripMenuItem.Text = "Attendance After Confirm OT";
            this.attendanceAfterConfirmOTToolStripMenuItem.Click += new System.EventHandler(this.attendanceAfterConfirmOTToolStripMenuItem_Click);
            // 
            // contractEndingReportToolStripMenuItem
            // 
            this.contractEndingReportToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.contractEndingReportToolStripMenuItem.Name = "contractEndingReportToolStripMenuItem";
            this.contractEndingReportToolStripMenuItem.Size = new System.Drawing.Size(181, 20);
            this.contractEndingReportToolStripMenuItem.Text = "Contract EndingWithin Period";
            this.contractEndingReportToolStripMenuItem.Click += new System.EventHandler(this.contractEndingReportToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To  : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From : ";
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(400, 31);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(200, 20);
            this.dtp_to.TabIndex = 1;
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(131, 30);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(200, 20);
            this.dtp_from.TabIndex = 0;
            // 
            // pendingExceptionBeforeAdjusterToolStripMenuItem
            // 
            this.pendingExceptionBeforeAdjusterToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.pendingExceptionBeforeAdjusterToolStripMenuItem.Name = "pendingExceptionBeforeAdjusterToolStripMenuItem";
            this.pendingExceptionBeforeAdjusterToolStripMenuItem.Size = new System.Drawing.Size(209, 20);
            this.pendingExceptionBeforeAdjusterToolStripMenuItem.Text = "Pending Exception Before Adjuster";
            this.pendingExceptionBeforeAdjusterToolStripMenuItem.Click += new System.EventHandler(this.pendingExceptionBeforeAdjusterToolStripMenuItem_Click);
            // 
            // pendingExceptionAfterAdjusterToolStripMenuItem
            // 
            this.pendingExceptionAfterAdjusterToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.pendingExceptionAfterAdjusterToolStripMenuItem.Name = "pendingExceptionAfterAdjusterToolStripMenuItem";
            this.pendingExceptionAfterAdjusterToolStripMenuItem.Size = new System.Drawing.Size(215, 20);
            this.pendingExceptionAfterAdjusterToolStripMenuItem.Text = "Pending Exception After Confirm OT";
            this.pendingExceptionAfterAdjusterToolStripMenuItem.Click += new System.EventHandler(this.pendingExceptionAfterAdjusterToolStripMenuItem_Click);
            // 
            // DateRangeReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 628);
            this.Controls.Add(this.panel1);
            this.Name = "DateRangeReports";
            this.Text = "DateRangeReports";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Crvt_ApplicationReport;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem synchronizeabscnet;
        private System.Windows.Forms.ToolStripMenuItem attendanceAfterConfirmOTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractEndingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingExceptionBeforeAdjusterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingExceptionAfterAdjusterToolStripMenuItem;
    }
}
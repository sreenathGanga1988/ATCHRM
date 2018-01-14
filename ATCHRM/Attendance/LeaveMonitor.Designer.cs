namespace ATCHRM.Attendance
{
    partial class LeaveMonitor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbl_empleavetaken = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbl_adjstrdetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbl_swipedatabank = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbl_swipedaily = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbl_adjstrconsol = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tbl_actionlog = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox1.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_empleavetaken)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_adjstrdetail)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_swipedatabank)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_swipedaily)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_adjstrconsol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_actionlog)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.menuStrip7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(923, 116);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Empid :";
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
            this.showLogToolStripMenuItem,
            this.showAllLeaveToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(3, 86);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(917, 27);
            this.menuStrip7.TabIndex = 32;
            this.menuStrip7.Text = "menuStrip7";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Image = global::ATCHRM.Properties.Resources.cancel;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(70, 23);
            this.toolStripMenuItem2.Text = "Cancel";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(173, 23);
            this.showLogToolStripMenuItem.Text = "Show Details of one Emp";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // showAllLeaveToolStripMenuItem
            // 
            this.showAllLeaveToolStripMenuItem.Name = "showAllLeaveToolStripMenuItem";
            this.showAllLeaveToolStripMenuItem.Size = new System.Drawing.Size(181, 23);
            this.showAllLeaveToolStripMenuItem.Text = "Show All Employee Details";
            this.showAllLeaveToolStripMenuItem.Click += new System.EventHandler(this.showAllLeaveToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To  : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From : ";
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(357, 58);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(200, 20);
            this.dtp_to.TabIndex = 1;
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(99, 58);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(200, 20);
            this.dtp_from.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 116);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 454);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbl_empleavetaken);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(915, 428);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee leave Taken";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbl_empleavetaken
            // 
            this.tbl_empleavetaken.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.tbl_empleavetaken.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.tbl_empleavetaken.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_empleavetaken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_empleavetaken.Location = new System.Drawing.Point(3, 3);
            this.tbl_empleavetaken.Name = "tbl_empleavetaken";
            this.tbl_empleavetaken.Size = new System.Drawing.Size(909, 422);
            this.tbl_empleavetaken.TabIndex = 14;
            this.tbl_empleavetaken.Text = "ultraGrid1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbl_adjstrdetail);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adjuster Detail";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbl_adjstrdetail
            // 
            this.tbl_adjstrdetail.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.tbl_adjstrdetail.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType;
            this.tbl_adjstrdetail.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_adjstrdetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_adjstrdetail.Location = new System.Drawing.Point(3, 3);
            this.tbl_adjstrdetail.Name = "tbl_adjstrdetail";
            this.tbl_adjstrdetail.Size = new System.Drawing.Size(909, 422);
            this.tbl_adjstrdetail.TabIndex = 14;
            this.tbl_adjstrdetail.Text = "ultraGrid1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbl_swipedatabank);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(915, 428);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Employee Swipe DataBank";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbl_swipedatabank
            // 
            this.tbl_swipedatabank.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.tbl_swipedatabank.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.tbl_swipedatabank.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_swipedatabank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_swipedatabank.Location = new System.Drawing.Point(3, 3);
            this.tbl_swipedatabank.Name = "tbl_swipedatabank";
            this.tbl_swipedatabank.Size = new System.Drawing.Size(909, 422);
            this.tbl_swipedatabank.TabIndex = 14;
            this.tbl_swipedatabank.Text = "ultraGrid1";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbl_swipedaily);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(915, 428);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Employee SwipeDaily";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbl_swipedaily
            // 
            this.tbl_swipedaily.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.tbl_swipedaily.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_swipedaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_swipedaily.Location = new System.Drawing.Point(0, 0);
            this.tbl_swipedaily.Name = "tbl_swipedaily";
            this.tbl_swipedaily.Size = new System.Drawing.Size(915, 428);
            this.tbl_swipedaily.TabIndex = 15;
            this.tbl_swipedaily.Text = "ultraGrid1";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tbl_adjstrconsol);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(915, 428);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Adjuster Consol";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tbl_actionlog);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(915, 428);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Action Log";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tbl_adjstrconsol
            // 
            this.tbl_adjstrconsol.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.tbl_adjstrconsol.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_adjstrconsol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_adjstrconsol.Location = new System.Drawing.Point(3, 3);
            this.tbl_adjstrconsol.Name = "tbl_adjstrconsol";
            this.tbl_adjstrconsol.Size = new System.Drawing.Size(909, 422);
            this.tbl_adjstrconsol.TabIndex = 16;
            this.tbl_adjstrconsol.Text = "ultraGrid1";
            // 
            // tbl_actionlog
            // 
            this.tbl_actionlog.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.tbl_actionlog.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_actionlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_actionlog.Location = new System.Drawing.Point(0, 0);
            this.tbl_actionlog.Name = "tbl_actionlog";
            this.tbl_actionlog.Size = new System.Drawing.Size(915, 428);
            this.tbl_actionlog.TabIndex = 16;
            this.tbl_actionlog.Text = "ultraGrid1";
            // 
            // LeaveMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 570);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "LeaveMonitor";
            this.Text = "LeaveMonitor";
            this.Load += new System.EventHandler(this.LeaveMonitor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_empleavetaken)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_adjstrdetail)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_swipedatabank)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_swipedaily)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_adjstrconsol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_actionlog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllLeaveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_empleavetaken;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_adjstrdetail;
        private System.Windows.Forms.TabPage tabPage3;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_swipedatabank;
        private System.Windows.Forms.TabPage tabPage4;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_swipedaily;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_adjstrconsol;
        private System.Windows.Forms.TabPage tabPage6;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_actionlog;
    }
}
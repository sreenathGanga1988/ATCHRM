namespace ATCHRM.Administrator
{
    partial class AttendanceDescrepancyReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.croppedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeleaveTakenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_frm = new System.Windows.Forms.DateTimePicker();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_frm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1075, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date range";
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
            this.finalAttendanceToolStripMenuItem,
            this.toolStripMenuItem1,
            this.croppedDataToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.employeeleaveTakenToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(3, 92);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(1069, 27);
            this.menuStrip7.TabIndex = 33;
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
            this.showLogToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(176, 23);
            this.showLogToolStripMenuItem.Text = "Show Leave and Applications";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // finalAttendanceToolStripMenuItem
            // 
            this.finalAttendanceToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.finalAttendanceToolStripMenuItem.Name = "finalAttendanceToolStripMenuItem";
            this.finalAttendanceToolStripMenuItem.Size = new System.Drawing.Size(132, 23);
            this.finalAttendanceToolStripMenuItem.Text = " Show Applied Leave";
            this.finalAttendanceToolStripMenuItem.Click += new System.EventHandler(this.finalAttendanceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 23);
            this.toolStripMenuItem1.Text = "Not in Swipe Data Bank";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // croppedDataToolStripMenuItem
            // 
            this.croppedDataToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.croppedDataToolStripMenuItem.Name = "croppedDataToolStripMenuItem";
            this.croppedDataToolStripMenuItem.Size = new System.Drawing.Size(198, 23);
            this.croppedDataToolStripMenuItem.Text = "Mark Applied leave on Absenties";
            this.croppedDataToolStripMenuItem.Click += new System.EventHandler(this.croppedDataToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Checked = true;
            this.exportToExcelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportToExcelToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.ToolTipText = "Export to Excel";
            // 
            // employeeleaveTakenToolStripMenuItem
            // 
            this.employeeleaveTakenToolStripMenuItem.Name = "employeeleaveTakenToolStripMenuItem";
            this.employeeleaveTakenToolStripMenuItem.Size = new System.Drawing.Size(149, 23);
            this.employeeleaveTakenToolStripMenuItem.Text = "Employeeleave Taken";
            this.employeeleaveTakenToolStripMenuItem.Click += new System.EventHandler(this.employeeleaveTakenToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date :";
            // 
            // dtp_frm
            // 
            this.dtp_frm.Location = new System.Drawing.Point(65, 20);
            this.dtp_frm.Name = "dtp_frm";
            this.dtp_frm.Size = new System.Drawing.Size(200, 20);
            this.dtp_frm.TabIndex = 0;
            this.toolTip1.SetToolTip(this.dtp_frm, "Select Date");
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.ContextMenuStrip = this.contextMenuStrip1;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 122);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1075, 459);
            this.ultraGrid1.TabIndex = 3;
            this.ultraGrid1.Text = "ultraGrid1";
            this.ultraGrid1.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ultraGrid1_CellChange);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(327, 26);
            // 
            // updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem
            // 
            this.updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem.Name = "updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem";
            this.updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem.Size = new System.Drawing.Size(326, 22);
            this.updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem.Text = "Update on SwipeDatabank And  Adjuster Details";
            this.updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem.Click += new System.EventHandler(this.updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem_Click);
            // 
            // TryGoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 581);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TryGoodForm";
            this.Text = "Attendance Administrative form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_frm;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem croppedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem employeeleaveTakenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem;
    }
}
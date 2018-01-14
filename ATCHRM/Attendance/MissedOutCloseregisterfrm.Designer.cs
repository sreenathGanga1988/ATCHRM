namespace ATCHRM.Attendance
{
    partial class MissedOutCloseregisterfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissedOutCloseregisterfrm));
            this.RBT_INOUT = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_oldempid = new System.Windows.Forms.TextBox();
            this.lbl_day = new System.Windows.Forms.Label();
            this.lbl_daystatus = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_approval = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_exportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_go = new System.Windows.Forms.Button();
            this.Cmb_location = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mrk_present = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.markSwipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grp_Dtatypesin = new System.Windows.Forms.GroupBox();
            this.tbl_DailyTime = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_datetoday = new System.Windows.Forms.DateTimePicker();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.mrk_present.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grp_Dtatypesin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RBT_INOUT
            // 
            this.RBT_INOUT.AutoSize = true;
            this.RBT_INOUT.Checked = true;
            this.RBT_INOUT.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBT_INOUT.Location = new System.Drawing.Point(44, 18);
            this.RBT_INOUT.Name = "RBT_INOUT";
            this.RBT_INOUT.Size = new System.Drawing.Size(51, 19);
            this.RBT_INOUT.TabIndex = 8;
            this.RBT_INOUT.TabStop = true;
            this.RBT_INOUT.Text = "Both";
            this.RBT_INOUT.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txt_oldempid);
            this.groupBox4.Controls.Add(this.lbl_day);
            this.groupBox4.Controls.Add(this.lbl_daystatus);
            this.groupBox4.Location = new System.Drawing.Point(419, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(914, 47);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "|\"?.";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(326, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 23);
            this.button3.TabIndex = 31;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Old Empid  : ";
            // 
            // txt_oldempid
            // 
            this.txt_oldempid.Location = new System.Drawing.Point(113, 17);
            this.txt_oldempid.Name = "txt_oldempid";
            this.txt_oldempid.Size = new System.Drawing.Size(207, 20);
            this.txt_oldempid.TabIndex = 29;
            // 
            // lbl_day
            // 
            this.lbl_day.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_day.AutoSize = true;
            this.lbl_day.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_day.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_day.Location = new System.Drawing.Point(744, 10);
            this.lbl_day.Name = "lbl_day";
            this.lbl_day.Size = new System.Drawing.Size(98, 15);
            this.lbl_day.TabIndex = 28;
            this.lbl_day.Text = "xxxxxxxxxxxxx";
            // 
            // lbl_daystatus
            // 
            this.lbl_daystatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_daystatus.AutoSize = true;
            this.lbl_daystatus.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_daystatus.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daystatus.Location = new System.Drawing.Point(743, 25);
            this.lbl_daystatus.Name = "lbl_daystatus";
            this.lbl_daystatus.Size = new System.Drawing.Size(153, 22);
            this.lbl_daystatus.TabIndex = 25;
            this.lbl_daystatus.Text = "xxxxxxxxxxxxx";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripButton1.Text = "Cancel";
            // 
            // btn_approval
            // 
            this.btn_approval.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_approval.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_approval.Image = ((System.Drawing.Image)(resources.GetObject("btn_approval.Image")));
            this.btn_approval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_approval.Name = "btn_approval";
            this.btn_approval.Size = new System.Drawing.Size(104, 22);
            this.btn_approval.Text = "Close Register";
            this.btn_approval.Click += new System.EventHandler(this.btn_approval_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_exportExcel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_exportExcel.Image")));
            this.btn_exportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(108, 22);
            this.btn_exportExcel.Text = "Export To Excel";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btn_approval,
            this.toolStripSeparator2,
            this.btn_exportExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 518);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1345, 25);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(1119, 1);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(32, 24);
            this.btn_go.TabIndex = 33;
            this.btn_go.Text = "GO";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // Cmb_location
            // 
            this.Cmb_location.FormattingEnabled = true;
            this.Cmb_location.Location = new System.Drawing.Point(83, 15);
            this.Cmb_location.Name = "Cmb_location";
            this.Cmb_location.Size = new System.Drawing.Size(402, 21);
            this.Cmb_location.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location :";
            // 
            // mrk_present
            // 
            this.mrk_present.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.markSwipeToolStripMenuItem});
            this.mrk_present.Name = "contextMenuStrip1";
            this.mrk_present.Size = new System.Drawing.Size(136, 70);
            this.mrk_present.Text = "Mark Present";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem1.Text = "Mark P";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem2.Text = "Mark LH";
            // 
            // markSwipeToolStripMenuItem
            // 
            this.markSwipeToolStripMenuItem.Name = "markSwipeToolStripMenuItem";
            this.markSwipeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.markSwipeToolStripMenuItem.Text = "Mark Swipe";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 543);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1345, 75);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(387, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // grp_Dtatypesin
            // 
            this.grp_Dtatypesin.Controls.Add(this.RBT_INOUT);
            this.grp_Dtatypesin.Location = new System.Drawing.Point(12, 83);
            this.grp_Dtatypesin.Name = "grp_Dtatypesin";
            this.grp_Dtatypesin.Size = new System.Drawing.Size(401, 47);
            this.grp_Dtatypesin.TabIndex = 30;
            this.grp_Dtatypesin.TabStop = false;
            this.grp_Dtatypesin.Text = "Details";
            // 
            // tbl_DailyTime
            // 
            this.tbl_DailyTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_DailyTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_DailyTime.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tbl_DailyTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_DailyTime.ContextMenuStrip = this.mrk_present;
            this.tbl_DailyTime.Location = new System.Drawing.Point(9, 140);
            this.tbl_DailyTime.Name = "tbl_DailyTime";
            this.tbl_DailyTime.RowHeadersVisible = false;
            this.tbl_DailyTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_DailyTime.Size = new System.Drawing.Size(1326, 363);
            this.tbl_DailyTime.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.Cmb_location);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1315, 58);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By ";
            // 
            // dtp_datetoday
            // 
            this.dtp_datetoday.CustomFormat = "MM-dd-yyyy";
            this.dtp_datetoday.Location = new System.Drawing.Point(923, 3);
            this.dtp_datetoday.Name = "dtp_datetoday";
            this.dtp_datetoday.Size = new System.Drawing.Size(190, 20);
            this.dtp_datetoday.TabIndex = 24;
            // 
            // MissedOutCloseregisterfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 618);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp_Dtatypesin);
            this.Controls.Add(this.tbl_DailyTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtp_datetoday);
            this.Name = "MissedOutCloseregisterfrm";
            this.Text = "MissedOutCloseregisterfrm";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.mrk_present.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_Dtatypesin.ResumeLayout(false);
            this.grp_Dtatypesin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RBT_INOUT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_oldempid;
        private System.Windows.Forms.Label lbl_day;
        private System.Windows.Forms.Label lbl_daystatus;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btn_approval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_exportExcel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.ComboBox Cmb_location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip mrk_present;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem markSwipeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grp_Dtatypesin;
        private System.Windows.Forms.DataGridView tbl_DailyTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_datetoday;
    }
}
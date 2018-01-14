namespace ATCHRM.HR.NewFolder1
{
    partial class EmployeeMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMasterForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_empname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Nid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holdPayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unHoldPayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackListEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPersonalDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbt_department = new System.Windows.Forms.RadioButton();
            this.rbt_Status = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.rbt_empdetail = new System.Windows.Forms.RadioButton();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grp_dept = new System.Windows.Forms.GroupBox();
            this.cmb_designation = new System.Windows.Forms.ComboBox();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Search = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_employeeregistration = new System.Windows.Forms.ToolStripButton();
            this.btn_exportExcel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grp_dept.SuspendLayout();
            this.Search.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_empname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Nid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(553, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee ";
            // 
            // txt_empname
            // 
            this.txt_empname.Location = new System.Drawing.Point(269, 21);
            this.txt_empname.Name = "txt_empname";
            this.txt_empname.Size = new System.Drawing.Size(128, 20);
            this.txt_empname.TabIndex = 8;
            this.txt_empname.TextChanged += new System.EventHandler(this.txt_empname_TextChanged);
            this.txt_empname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_empname_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "EmpName:";
            // 
            // txt_Nid
            // 
            this.txt_Nid.Location = new System.Drawing.Point(55, 21);
            this.txt_Nid.Name = "txt_Nid";
            this.txt_Nid.Size = new System.Drawing.Size(128, 20);
            this.txt_Nid.TabIndex = 7;
            this.txt_Nid.TextChanged += new System.EventHandler(this.txt_Nid_TextChanged);
            this.txt_Nid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Nid_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "N I D:";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 578);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(972, 71);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(969, 396);
            this.dataGridView1.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteEmployeeToolStripMenuItem,
            this.holdPayrollToolStripMenuItem,
            this.unHoldPayrollToolStripMenuItem,
            this.blackListEmployeeToolStripMenuItem,
            this.editPersonalDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 136);
            // 
            // deleteEmployeeToolStripMenuItem
            // 
            this.deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
            this.deleteEmployeeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteEmployeeToolStripMenuItem.Text = "Delete Employee";
            this.deleteEmployeeToolStripMenuItem.Click += new System.EventHandler(this.deleteEmployeeToolStripMenuItem_Click);
            // 
            // holdPayrollToolStripMenuItem
            // 
            this.holdPayrollToolStripMenuItem.Name = "holdPayrollToolStripMenuItem";
            this.holdPayrollToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.holdPayrollToolStripMenuItem.Text = "Hold Payroll";
            this.holdPayrollToolStripMenuItem.Click += new System.EventHandler(this.holdPayrollToolStripMenuItem_Click);
            // 
            // unHoldPayrollToolStripMenuItem
            // 
            this.unHoldPayrollToolStripMenuItem.Name = "unHoldPayrollToolStripMenuItem";
            this.unHoldPayrollToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unHoldPayrollToolStripMenuItem.Text = "UnHold Payroll";
            this.unHoldPayrollToolStripMenuItem.Click += new System.EventHandler(this.unHoldPayrollToolStripMenuItem_Click);
            // 
            // blackListEmployeeToolStripMenuItem
            // 
            this.blackListEmployeeToolStripMenuItem.Name = "blackListEmployeeToolStripMenuItem";
            this.blackListEmployeeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blackListEmployeeToolStripMenuItem.Text = "Black List Employee";
            this.blackListEmployeeToolStripMenuItem.Click += new System.EventHandler(this.blackListEmployeeToolStripMenuItem_Click);
            // 
            // editPersonalDetailsToolStripMenuItem
            // 
            this.editPersonalDetailsToolStripMenuItem.Name = "editPersonalDetailsToolStripMenuItem";
            this.editPersonalDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editPersonalDetailsToolStripMenuItem.Text = "Edit Personal Details";
            this.editPersonalDetailsToolStripMenuItem.Click += new System.EventHandler(this.editPersonalDetailsToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(252, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Designation  :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbt_department);
            this.groupBox4.Controls.Add(this.rbt_Status);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.rbt_empdetail);
            this.groupBox4.Controls.Add(this.cmb_location);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(972, 55);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Criteria";
            // 
            // rbt_department
            // 
            this.rbt_department.AutoSize = true;
            this.rbt_department.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_department.Location = new System.Drawing.Point(546, 25);
            this.rbt_department.Name = "rbt_department";
            this.rbt_department.Size = new System.Drawing.Size(109, 19);
            this.rbt_department.TabIndex = 4;
            this.rbt_department.TabStop = true;
            this.rbt_department.Text = "By Department";
            this.rbt_department.UseVisualStyleBackColor = true;
            this.rbt_department.CheckedChanged += new System.EventHandler(this.rbt_department_CheckedChanged);
            // 
            // rbt_Status
            // 
            this.rbt_Status.AutoSize = true;
            this.rbt_Status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_Status.Location = new System.Drawing.Point(460, 25);
            this.rbt_Status.Name = "rbt_Status";
            this.rbt_Status.Size = new System.Drawing.Size(75, 19);
            this.rbt_Status.TabIndex = 3;
            this.rbt_Status.TabStop = true;
            this.rbt_Status.Text = "By Status";
            this.rbt_Status.UseVisualStyleBackColor = true;
            this.rbt_Status.CheckedChanged += new System.EventHandler(this.rbt_Status_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.Location = new System.Drawing.Point(824, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 37);
            this.button3.TabIndex = 10;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rbt_empdetail
            // 
            this.rbt_empdetail.AutoSize = true;
            this.rbt_empdetail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_empdetail.Location = new System.Drawing.Point(320, 25);
            this.rbt_empdetail.Name = "rbt_empdetail";
            this.rbt_empdetail.Size = new System.Drawing.Size(130, 19);
            this.rbt_empdetail.TabIndex = 2;
            this.rbt_empdetail.TabStop = true;
            this.rbt_empdetail.Text = "By Employee Detail";
            this.rbt_empdetail.UseVisualStyleBackColor = true;
            this.rbt_empdetail.CheckedChanged += new System.EventHandler(this.rbt_empdetail_CheckedChanged);
            // 
            // cmb_location
            // 
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Location = new System.Drawing.Point(91, 20);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(213, 22);
            this.cmb_location.TabIndex = 1;
            this.cmb_location.SelectedIndexChanged += new System.EventHandler(this.cmb_location_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Location :";
            // 
            // grp_dept
            // 
            this.grp_dept.Controls.Add(this.cmb_designation);
            this.grp_dept.Controls.Add(this.cmb_dept);
            this.grp_dept.Controls.Add(this.label5);
            this.grp_dept.Controls.Add(this.label6);
            this.grp_dept.Enabled = false;
            this.grp_dept.Location = new System.Drawing.Point(6, 16);
            this.grp_dept.Name = "grp_dept";
            this.grp_dept.Size = new System.Drawing.Size(541, 55);
            this.grp_dept.TabIndex = 9;
            this.grp_dept.TabStop = false;
            this.grp_dept.Text = "Dept";
            // 
            // cmb_designation
            // 
            this.cmb_designation.FormattingEnabled = true;
            this.cmb_designation.Items.AddRange(new object[] {
            "Active",
            "In Active"});
            this.cmb_designation.Location = new System.Drawing.Point(338, 21);
            this.cmb_designation.Name = "cmb_designation";
            this.cmb_designation.Size = new System.Drawing.Size(184, 22);
            this.cmb_designation.TabIndex = 6;
            this.cmb_designation.SelectedIndexChanged += new System.EventHandler(this.cmb_designation_SelectedIndexChanged);
            this.cmb_designation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_designation_MouseClick);
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(51, 20);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(195, 22);
            this.cmb_dept.TabIndex = 5;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            this.cmb_dept.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_dept_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Dept  :";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Search
            // 
            this.Search.Controls.Add(this.grp_dept);
            this.Search.Controls.Add(this.groupBox1);
            this.Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.Search.Location = new System.Drawing.Point(0, 55);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(972, 77);
            this.Search.TabIndex = 19;
            this.Search.TabStop = false;
            this.Search.Text = "Search";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 553);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(972, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(62, 22);
            this.toolStripButton2.Text = "Cancel";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(108, 22);
            this.toolStripButton3.Text = "Export To Excel";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 25);
            this.toolStripButton1.Text = "Cancel";
            // 
            // btn_employeeregistration
            // 
            this.btn_employeeregistration.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_employeeregistration.Image = ((System.Drawing.Image)(resources.GetObject("btn_employeeregistration.Image")));
            this.btn_employeeregistration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_employeeregistration.Name = "btn_employeeregistration";
            this.btn_employeeregistration.Size = new System.Drawing.Size(186, 25);
            this.btn_employeeregistration.Text = "Employee Registration";
            this.btn_employeeregistration.Click += new System.EventHandler(this.btn_employeeregistration_Click);
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_exportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_exportExcel.Image")));
            this.btn_exportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(133, 25);
            this.btn_exportExcel.Text = "Export To Excel";
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // EmployeeMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(972, 649);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmployeeMasterForm";
            this.Text = "Employee Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grp_dept.ResumeLayout(false);
            this.grp_dept.PerformLayout();
            this.Search.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_Nid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbt_department;
        private System.Windows.Forms.RadioButton rbt_Status;
        private System.Windows.Forms.RadioButton rbt_empdetail;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grp_dept;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmb_designation;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_employeeregistration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_exportExcel;
        private System.Windows.Forms.TextBox txt_empname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Search;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holdPayrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unHoldPayrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackListEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPersonalDetailsToolStripMenuItem;
    }
}
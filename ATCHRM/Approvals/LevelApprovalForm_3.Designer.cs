namespace ATCHRM.Approvals
{
    partial class LevelApprovalForm_3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelApprovalForm_3));
            this.rbt_Recruitment = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.rbt_leave = new System.Windows.Forms.RadioButton();
            this.rbt_Desgnation = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_Selection = new System.Windows.Forms.CheckBox();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt_OtAplication = new System.Windows.Forms.RadioButton();
            this.rbt_leaveencashment = new System.Windows.Forms.RadioButton();
            this.rbt_contract = new System.Windows.Forms.RadioButton();
            this.rbt_lhr = new System.Windows.Forms.RadioButton();
            this.rbt_shift = new System.Windows.Forms.RadioButton();
            this.rbt_Advance = new System.Windows.Forms.RadioButton();
            this.tbl_ApprovalData = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makeAbsentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_designation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_EmpCode = new System.Windows.Forms.ComboBox();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ApprovalData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbt_Recruitment
            // 
            this.rbt_Recruitment.AutoSize = true;
            this.rbt_Recruitment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_Recruitment.Location = new System.Drawing.Point(7, 14);
            this.rbt_Recruitment.Name = "rbt_Recruitment";
            this.rbt_Recruitment.Size = new System.Drawing.Size(158, 19);
            this.rbt_Recruitment.TabIndex = 6;
            this.rbt_Recruitment.TabStop = true;
            this.rbt_Recruitment.Text = "Recruitment Application";
            this.rbt_Recruitment.UseVisualStyleBackColor = true;
            this.rbt_Recruitment.CheckedChanged += new System.EventHandler(this.rbt_Recruitment_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(531, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // rbt_leave
            // 
            this.rbt_leave.AutoSize = true;
            this.rbt_leave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_leave.Location = new System.Drawing.Point(167, 14);
            this.rbt_leave.Name = "rbt_leave";
            this.rbt_leave.Size = new System.Drawing.Size(121, 19);
            this.rbt_leave.TabIndex = 7;
            this.rbt_leave.TabStop = true;
            this.rbt_leave.Text = "Leave Application";
            this.rbt_leave.UseVisualStyleBackColor = true;
            this.rbt_leave.CheckedChanged += new System.EventHandler(this.rbt_leave_CheckedChanged);
            // 
            // rbt_Desgnation
            // 
            this.rbt_Desgnation.AutoSize = true;
            this.rbt_Desgnation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_Desgnation.Location = new System.Drawing.Point(400, 14);
            this.rbt_Desgnation.Name = "rbt_Desgnation";
            this.rbt_Desgnation.Size = new System.Drawing.Size(132, 19);
            this.rbt_Desgnation.TabIndex = 9;
            this.rbt_Desgnation.TabStop = true;
            this.rbt_Desgnation.Text = "Designation Change";
            this.rbt_Desgnation.UseVisualStyleBackColor = true;
            this.rbt_Desgnation.CheckedChanged += new System.EventHandler(this.rbt_Desgnation_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 497);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1150, 44);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // chk_Selection
            // 
            this.chk_Selection.AutoSize = true;
            this.chk_Selection.Location = new System.Drawing.Point(4, 90);
            this.chk_Selection.Name = "chk_Selection";
            this.chk_Selection.Size = new System.Drawing.Size(70, 17);
            this.chk_Selection.TabIndex = 16;
            this.chk_Selection.Text = "Select All";
            this.chk_Selection.UseVisualStyleBackColor = true;
            this.chk_Selection.CheckedChanged += new System.EventHandler(this.chk_Selection_CheckedChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SELECT";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt_OtAplication);
            this.groupBox2.Controls.Add(this.rbt_leaveencashment);
            this.groupBox2.Controls.Add(this.rbt_contract);
            this.groupBox2.Controls.Add(this.rbt_lhr);
            this.groupBox2.Controls.Add(this.rbt_shift);
            this.groupBox2.Controls.Add(this.rbt_Recruitment);
            this.groupBox2.Controls.Add(this.rbt_leave);
            this.groupBox2.Controls.Add(this.rbt_Desgnation);
            this.groupBox2.Controls.Add(this.rbt_Advance);
            this.groupBox2.Location = new System.Drawing.Point(0, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1143, 40);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action Type";
            // 
            // rbt_OtAplication
            // 
            this.rbt_OtAplication.AutoSize = true;
            this.rbt_OtAplication.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_OtAplication.Location = new System.Drawing.Point(1032, 13);
            this.rbt_OtAplication.Name = "rbt_OtAplication";
            this.rbt_OtAplication.Size = new System.Drawing.Size(68, 19);
            this.rbt_OtAplication.TabIndex = 15;
            this.rbt_OtAplication.TabStop = true;
            this.rbt_OtAplication.Text = "O T App";
            this.rbt_OtAplication.UseVisualStyleBackColor = true;
            this.rbt_OtAplication.CheckedChanged += new System.EventHandler(this.rbt_OtAplication_CheckedChanged);
            // 
            // rbt_leaveencashment
            // 
            this.rbt_leaveencashment.AutoSize = true;
            this.rbt_leaveencashment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_leaveencashment.Location = new System.Drawing.Point(890, 13);
            this.rbt_leaveencashment.Name = "rbt_leaveencashment";
            this.rbt_leaveencashment.Size = new System.Drawing.Size(126, 19);
            this.rbt_leaveencashment.TabIndex = 13;
            this.rbt_leaveencashment.TabStop = true;
            this.rbt_leaveencashment.Text = "Leave Encashment";
            this.rbt_leaveencashment.UseVisualStyleBackColor = true;
            this.rbt_leaveencashment.CheckedChanged += new System.EventHandler(this.rbt_leaveencashment_CheckedChanged);
            // 
            // rbt_contract
            // 
            this.rbt_contract.AutoSize = true;
            this.rbt_contract.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_contract.Location = new System.Drawing.Point(760, 14);
            this.rbt_contract.Name = "rbt_contract";
            this.rbt_contract.Size = new System.Drawing.Size(122, 19);
            this.rbt_contract.TabIndex = 12;
            this.rbt_contract.TabStop = true;
            this.rbt_contract.Text = "Contract Renewal";
            this.rbt_contract.UseVisualStyleBackColor = true;
            this.rbt_contract.CheckedChanged += new System.EventHandler(this.rbt_contract_CheckedChanged);
            // 
            // rbt_lhr
            // 
            this.rbt_lhr.AutoSize = true;
            this.rbt_lhr.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_lhr.Location = new System.Drawing.Point(637, 14);
            this.rbt_lhr.Name = "rbt_lhr";
            this.rbt_lhr.Size = new System.Drawing.Size(116, 19);
            this.rbt_lhr.TabIndex = 11;
            this.rbt_lhr.TabStop = true;
            this.rbt_lhr.Text = "L H R Application";
            this.rbt_lhr.UseVisualStyleBackColor = true;
            this.rbt_lhr.CheckedChanged += new System.EventHandler(this.rbt_lhr_CheckedChanged);
            // 
            // rbt_shift
            // 
            this.rbt_shift.AutoSize = true;
            this.rbt_shift.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_shift.Location = new System.Drawing.Point(539, 15);
            this.rbt_shift.Name = "rbt_shift";
            this.rbt_shift.Size = new System.Drawing.Size(95, 19);
            this.rbt_shift.TabIndex = 10;
            this.rbt_shift.TabStop = true;
            this.rbt_shift.Text = "Shift Change ";
            this.rbt_shift.UseVisualStyleBackColor = true;
            this.rbt_shift.CheckedChanged += new System.EventHandler(this.rbt_shift_CheckedChanged_1);
            // 
            // rbt_Advance
            // 
            this.rbt_Advance.AutoSize = true;
            this.rbt_Advance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_Advance.Location = new System.Drawing.Point(293, 15);
            this.rbt_Advance.Name = "rbt_Advance";
            this.rbt_Advance.Size = new System.Drawing.Size(106, 19);
            this.rbt_Advance.TabIndex = 8;
            this.rbt_Advance.TabStop = true;
            this.rbt_Advance.Text = "Advance Salary";
            this.rbt_Advance.UseVisualStyleBackColor = true;
            this.rbt_Advance.CheckedChanged += new System.EventHandler(this.rbt_Advance_CheckedChanged);
            // 
            // tbl_ApprovalData
            // 
            this.tbl_ApprovalData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_ApprovalData.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_ApprovalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_ApprovalData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.tbl_ApprovalData.ContextMenuStrip = this.contextMenuStrip1;
            this.tbl_ApprovalData.Location = new System.Drawing.Point(0, 111);
            this.tbl_ApprovalData.Name = "tbl_ApprovalData";
            this.tbl_ApprovalData.RowHeadersVisible = false;
            this.tbl_ApprovalData.RowHeadersWidth = 16;
            this.tbl_ApprovalData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_ApprovalData.Size = new System.Drawing.Size(1143, 359);
            this.tbl_ApprovalData.TabIndex = 25;
            this.tbl_ApprovalData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_ApprovalData_CellContentClick);
            this.tbl_ApprovalData.CurrentCellDirtyStateChanged += new System.EventHandler(this.tbl_ApprovalData_CurrentCellDirtyStateChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeAbsentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 26);
            // 
            // makeAbsentToolStripMenuItem
            // 
            this.makeAbsentToolStripMenuItem.Name = "makeAbsentToolStripMenuItem";
            this.makeAbsentToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.makeAbsentToolStripMenuItem.Text = "View Details";
            this.makeAbsentToolStripMenuItem.Click += new System.EventHandler(this.makeAbsentToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btn_add,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 472);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1150, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
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
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_add
            // 
            this.btn_add.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_add.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(74, 22);
            this.btn_add.Text = "Approve";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton3.Text = "Reject";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_designation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_EmpCode);
            this.groupBox1.Controls.Add(this.cmb_dept);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_location);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1150, 40);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criteria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(585, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Desg : ";
            this.label4.Visible = false;
            // 
            // cmb_designation
            // 
            this.cmb_designation.FormattingEnabled = true;
            this.cmb_designation.Location = new System.Drawing.Point(638, 12);
            this.cmb_designation.Name = "cmb_designation";
            this.cmb_designation.Size = new System.Drawing.Size(140, 21);
            this.cmb_designation.TabIndex = 3;
            this.cmb_designation.Visible = false;
            this.cmb_designation.SelectedIndexChanged += new System.EventHandler(this.cmb_designation_SelectedIndexChanged);
            this.cmb_designation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_designation_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(781, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Emp Code : ";
            this.label3.Visible = false;
            // 
            // cmb_EmpCode
            // 
            this.cmb_EmpCode.FormattingEnabled = true;
            this.cmb_EmpCode.Location = new System.Drawing.Point(858, 13);
            this.cmb_EmpCode.Name = "cmb_EmpCode";
            this.cmb_EmpCode.Size = new System.Drawing.Size(140, 21);
            this.cmb_EmpCode.TabIndex = 4;
            this.cmb_EmpCode.Visible = false;
            this.cmb_EmpCode.SelectedIndexChanged += new System.EventHandler(this.cmb_EmpCode_SelectedIndexChanged);
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(438, 13);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(140, 21);
            this.cmb_dept.TabIndex = 2;
            this.cmb_dept.Visible = false;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            this.cmb_dept.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_dept_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(349, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Department :";
            this.label2.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1015, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(112, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location :";
            // 
            // cmb_location
            // 
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Location = new System.Drawing.Point(74, 13);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(268, 21);
            this.cmb_location.TabIndex = 1;
            this.cmb_location.SelectedIndexChanged += new System.EventHandler(this.cmb_location_SelectedIndexChanged);
            this.cmb_location.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_location_MouseClick);
            // 
            // LevelApprovalForm_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1150, 541);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbl_ApprovalData);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chk_Selection);
            this.Name = "LevelApprovalForm_3";
            this.Text = "LevelApprovalForm_3";
            this.Load += new System.EventHandler(this.LevelApprovalForm_3_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ApprovalData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbt_Recruitment;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RadioButton rbt_leave;
        private System.Windows.Forms.RadioButton rbt_Desgnation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_Selection;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbt_Advance;
        private System.Windows.Forms.DataGridView tbl_ApprovalData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_designation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.RadioButton rbt_shift;
        private System.Windows.Forms.RadioButton rbt_lhr;
        private System.Windows.Forms.RadioButton rbt_contract;
        private System.Windows.Forms.RadioButton rbt_leaveencashment;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ComboBox cmb_EmpCode;
        private System.Windows.Forms.RadioButton rbt_OtAplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem makeAbsentToolStripMenuItem;
    }
}
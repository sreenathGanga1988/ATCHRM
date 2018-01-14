namespace ATCHRM.Applications
{
    partial class LostHourRecoveryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LostHourRecoveryForm));
            this.pnl_byLocation = new System.Windows.Forms.Panel();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_EmployeeCode = new System.Windows.Forms.Panel();
            this.cmb_EmpCode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_byDept = new System.Windows.Forms.Panel();
            this.cmb_designation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_submitt = new System.Windows.Forms.ToolStripButton();
            this.tbl_Aplication = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_day = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_Adress1 = new System.Windows.Forms.Label();
            this.lbl_CompanyCode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_Otdate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtduration = new System.Windows.Forms.TextBox();
            this.rht1_reason = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chk_Selection = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.Btn_cropLH = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnl_byLocation.SuspendLayout();
            this.pnl_EmployeeCode.SuspendLayout();
            this.pnl_byDept.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Aplication)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_byLocation
            // 
            this.pnl_byLocation.BackColor = System.Drawing.Color.LightBlue;
            this.pnl_byLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_byLocation.Controls.Add(this.cmb_location);
            this.pnl_byLocation.Controls.Add(this.label7);
            this.pnl_byLocation.Location = new System.Drawing.Point(12, 12);
            this.pnl_byLocation.Name = "pnl_byLocation";
            this.pnl_byLocation.Size = new System.Drawing.Size(283, 52);
            this.pnl_byLocation.TabIndex = 7;
            // 
            // cmb_location
            // 
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Location = new System.Drawing.Point(70, 10);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(199, 21);
            this.cmb_location.TabIndex = 1;
            this.cmb_location.SelectedIndexChanged += new System.EventHandler(this.cmb_location_SelectedIndexChanged);
            this.cmb_location.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_location_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Location : ";
            // 
            // pnl_EmployeeCode
            // 
            this.pnl_EmployeeCode.BackColor = System.Drawing.Color.LightBlue;
            this.pnl_EmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_EmployeeCode.Controls.Add(this.cmb_EmpCode);
            this.pnl_EmployeeCode.Controls.Add(this.label6);
            this.pnl_EmployeeCode.Location = new System.Drawing.Point(695, 12);
            this.pnl_EmployeeCode.Name = "pnl_EmployeeCode";
            this.pnl_EmployeeCode.Size = new System.Drawing.Size(209, 52);
            this.pnl_EmployeeCode.TabIndex = 6;
            // 
            // cmb_EmpCode
            // 
            this.cmb_EmpCode.FormattingEnabled = true;
            this.cmb_EmpCode.Location = new System.Drawing.Point(75, 15);
            this.cmb_EmpCode.Name = "cmb_EmpCode";
            this.cmb_EmpCode.Size = new System.Drawing.Size(121, 21);
            this.cmb_EmpCode.TabIndex = 4;
            this.cmb_EmpCode.SelectedIndexChanged += new System.EventHandler(this.cmb_EmpCode_SelectedIndexChanged);
            this.cmb_EmpCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_EmpCode_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Emp Code  : ";
            // 
            // pnl_byDept
            // 
            this.pnl_byDept.BackColor = System.Drawing.Color.LightBlue;
            this.pnl_byDept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_byDept.Controls.Add(this.cmb_designation);
            this.pnl_byDept.Controls.Add(this.label2);
            this.pnl_byDept.Controls.Add(this.cmb_dept);
            this.pnl_byDept.Controls.Add(this.label1);
            this.pnl_byDept.Location = new System.Drawing.Point(316, 12);
            this.pnl_byDept.Name = "pnl_byDept";
            this.pnl_byDept.Size = new System.Drawing.Size(359, 52);
            this.pnl_byDept.TabIndex = 5;
            // 
            // cmb_designation
            // 
            this.cmb_designation.FormattingEnabled = true;
            this.cmb_designation.Location = new System.Drawing.Point(235, 15);
            this.cmb_designation.Name = "cmb_designation";
            this.cmb_designation.Size = new System.Drawing.Size(111, 21);
            this.cmb_designation.TabIndex = 3;
            this.cmb_designation.SelectedIndexChanged += new System.EventHandler(this.cmb_designation_SelectedIndexChanged);
            this.cmb_designation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_designation_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Designation : ";
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(45, 15);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(102, 21);
            this.cmb_dept.TabIndex = 2;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            this.cmb_dept.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_dept_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dept : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(-316, -316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 52);
            this.panel1.TabIndex = 24;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(56, 10);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(207, 21);
            this.comboBox3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.comboBox6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(694, -318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 52);
            this.panel2.TabIndex = 23;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(67, 15);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 21);
            this.comboBox6.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Emp Code  : ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.comboBox7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.comboBox8);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(-35, -318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 52);
            this.panel3.TabIndex = 22;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(225, 15);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 21);
            this.comboBox7.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Desgn: ";
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(48, 15);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(121, 21);
            this.comboBox8.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Dept : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 581);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(911, 66);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(351, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btn_submitt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 556);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(911, 25);
            this.toolStrip1.TabIndex = 14;
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
            // btn_submitt
            // 
            this.btn_submitt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_submitt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submitt.Image = ((System.Drawing.Image)(resources.GetObject("btn_submitt.Image")));
            this.btn_submitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_submitt.Name = "btn_submitt";
            this.btn_submitt.Size = new System.Drawing.Size(66, 22);
            this.btn_submitt.Text = "Submit";
            this.btn_submitt.Click += new System.EventHandler(this.btn_submitt_Click);
            // 
            // tbl_Aplication
            // 
            this.tbl_Aplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_Aplication.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_Aplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Aplication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.tbl_Aplication.Location = new System.Drawing.Point(9, 221);
            this.tbl_Aplication.Name = "tbl_Aplication";
            this.tbl_Aplication.RowHeadersVisible = false;
            this.tbl_Aplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_Aplication.Size = new System.Drawing.Size(892, 326);
            this.tbl_Aplication.TabIndex = 13;
            this.tbl_Aplication.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_Aplication_CellContentClick);
            this.tbl_Aplication.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_Aplication_CellValueChanged);
            this.tbl_Aplication.CurrentCellDirtyStateChanged += new System.EventHandler(this.tbl_Aplication_CurrentCellDirtyStateChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Select";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_day);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lbl_Adress1);
            this.groupBox2.Controls.Add(this.lbl_CompanyCode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtp_Otdate);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtduration);
            this.groupBox2.Controls.Add(this.rht1_reason);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 102);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LHR  Details";
            // 
            // lbl_day
            // 
            this.lbl_day.AutoSize = true;
            this.lbl_day.BackColor = System.Drawing.Color.Red;
            this.lbl_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_day.Location = new System.Drawing.Point(339, 56);
            this.lbl_day.Name = "lbl_day";
            this.lbl_day.Size = new System.Drawing.Size(26, 17);
            this.lbl_day.TabIndex = 43;
            this.lbl_day.Text = "na";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(243, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 42;
            this.label13.Text = "Day of Week:";
            // 
            // lbl_Adress1
            // 
            this.lbl_Adress1.AutoSize = true;
            this.lbl_Adress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Adress1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Adress1.Location = new System.Drawing.Point(210, 52);
            this.lbl_Adress1.Name = "lbl_Adress1";
            this.lbl_Adress1.Size = new System.Drawing.Size(13, 17);
            this.lbl_Adress1.TabIndex = 36;
            this.lbl_Adress1.Text = "*";
            this.lbl_Adress1.Visible = false;
            // 
            // lbl_CompanyCode
            // 
            this.lbl_CompanyCode.AutoSize = true;
            this.lbl_CompanyCode.ForeColor = System.Drawing.Color.Red;
            this.lbl_CompanyCode.Location = new System.Drawing.Point(178, 12);
            this.lbl_CompanyCode.Name = "lbl_CompanyCode";
            this.lbl_CompanyCode.Size = new System.Drawing.Size(11, 13);
            this.lbl_CompanyCode.TabIndex = 35;
            this.lbl_CompanyCode.Text = "*";
            this.lbl_CompanyCode.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(257, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "LHR  Date :";
            // 
            // dtp_Otdate
            // 
            this.dtp_Otdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Otdate.Location = new System.Drawing.Point(354, 17);
            this.dtp_Otdate.Name = "dtp_Otdate";
            this.dtp_Otdate.Size = new System.Drawing.Size(148, 20);
            this.dtp_Otdate.TabIndex = 6;
            this.dtp_Otdate.ValueChanged += new System.EventHandler(this.dtp_Otdate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Minutes";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(404, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Duration :";
            // 
            // txtduration
            // 
            this.txtduration.Location = new System.Drawing.Point(75, 20);
            this.txtduration.Name = "txtduration";
            this.txtduration.Size = new System.Drawing.Size(97, 20);
            this.txtduration.TabIndex = 5;
            this.txtduration.Text = "0";
            // 
            // rht1_reason
            // 
            this.rht1_reason.Location = new System.Drawing.Point(75, 51);
            this.rht1_reason.Name = "rht1_reason";
            this.rht1_reason.Size = new System.Drawing.Size(129, 31);
            this.rht1_reason.TabIndex = 7;
            this.rht1_reason.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(2, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Description :";
            // 
            // chk_Selection
            // 
            this.chk_Selection.AutoSize = true;
            this.chk_Selection.Location = new System.Drawing.Point(23, 188);
            this.chk_Selection.Name = "chk_Selection";
            this.chk_Selection.Size = new System.Drawing.Size(70, 17);
            this.chk_Selection.TabIndex = 10;
            this.chk_Selection.Text = "Select All";
            this.chk_Selection.UseVisualStyleBackColor = true;
            this.chk_Selection.CheckedChanged += new System.EventHandler(this.chk_Selection_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Location = new System.Drawing.Point(553, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 102);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LHR  Details";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_cropLH,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.toolStripButton2});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(345, 83);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // Btn_cropLH
            // 
            this.Btn_cropLH.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Btn_cropLH.Image = ((System.Drawing.Image)(resources.GetObject("Btn_cropLH.Image")));
            this.Btn_cropLH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_cropLH.Name = "Btn_cropLH";
            this.Btn_cropLH.Size = new System.Drawing.Size(343, 25);
            this.Btn_cropLH.Text = "Crop to Actual LH";
            this.Btn_cropLH.Click += new System.EventHandler(this.Btn_cropLH_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(343, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(343, 6);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(343, 25);
            this.toolStripButton2.Text = "Reject LH Application";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(119, 188);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(121, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "VIew Only LH Employee";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LostHourRecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(911, 647);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chk_Selection);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbl_Aplication);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnl_byLocation);
            this.Controls.Add(this.pnl_EmployeeCode);
            this.Controls.Add(this.pnl_byDept);
            this.MaximizeBox = false;
            this.Name = "LostHourRecoveryForm";
            this.Text = "Lost Hour Recovery";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LostHourRecoveryForm_FormClosed);
            this.Load += new System.EventHandler(this.LostHourRecoveryForm_Load);
            this.pnl_byLocation.ResumeLayout(false);
            this.pnl_byLocation.PerformLayout();
            this.pnl_EmployeeCode.ResumeLayout(false);
            this.pnl_EmployeeCode.PerformLayout();
            this.pnl_byDept.ResumeLayout(false);
            this.pnl_byDept.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Aplication)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_byLocation;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnl_EmployeeCode;
        private System.Windows.Forms.ComboBox cmb_EmpCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_byDept;
        private System.Windows.Forms.ComboBox cmb_designation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_submitt;
        private System.Windows.Forms.DataGridView tbl_Aplication;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_Adress1;
        private System.Windows.Forms.Label lbl_CompanyCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_Otdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtduration;
        private System.Windows.Forms.RichTextBox rht1_reason;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chk_Selection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton Btn_cropLH;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label lbl_day;
        private System.Windows.Forms.Label label13;
    }
}
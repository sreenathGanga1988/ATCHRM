namespace ATCHRM.Applications
{
    partial class LeaveEnchasementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaveEnchasementForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.cmb_empcode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_joiningdate = new System.Windows.Forms.Label();
            this.txt_currentyear = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lbl_todate = new System.Windows.Forms.Label();
            this.lbl_FrmDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Cmb_contract = new System.Windows.Forms.ComboBox();
            this.cmb_subcontract = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_allowedday = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_leavetaken = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_Enchaseddays = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_allowedleaves = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_mode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_daysLeft = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txt_mobile = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmb_daytype = new System.Windows.Forms.ComboBox();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_leave = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_cancell = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_submitt = new System.Windows.Forms.ToolStripButton();
            this.tbl_empdata = new System.Windows.Forms.DataGridView();
            this.lbl_subcontrctenddate = new System.Windows.Forms.Label();
            this.lbl_subcontractstartdate = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_empdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_dept);
            this.groupBox1.Controls.Add(this.cmb_empcode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_location);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dept  :";
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(73, 58);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(255, 22);
            this.cmb_dept.TabIndex = 2;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            this.cmb_dept.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_dept_MouseClick);
            // 
            // cmb_empcode
            // 
            this.cmb_empcode.FormattingEnabled = true;
            this.cmb_empcode.Location = new System.Drawing.Point(445, 61);
            this.cmb_empcode.Name = "cmb_empcode";
            this.cmb_empcode.Size = new System.Drawing.Size(186, 22);
            this.cmb_empcode.TabIndex = 3;
            this.cmb_empcode.SelectedIndexChanged += new System.EventHandler(this.cmb_empcode_SelectedIndexChanged);
            this.cmb_empcode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_empcode_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location :";
            // 
            // cmb_location
            // 
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Location = new System.Drawing.Point(81, 16);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(359, 22);
            this.cmb_location.TabIndex = 1;
            this.cmb_location.SelectedIndexChanged += new System.EventHandler(this.cmb_location_SelectedIndexChanged);
            this.cmb_location.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_location_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(368, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emp Code : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 642);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 75);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(230, 32);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbl_subcontrctenddate);
            this.panel2.Controls.Add(this.lbl_subcontractstartdate);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.lbl_joiningdate);
            this.panel2.Controls.Add(this.txt_currentyear);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.lblMonth);
            this.panel2.Controls.Add(this.lbl_todate);
            this.panel2.Controls.Add(this.lbl_FrmDate);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.Cmb_contract);
            this.panel2.Controls.Add(this.cmb_subcontract);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.cmb_daytype);
            this.panel2.Controls.Add(this.txtDays);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cmb_leave);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(0, 201);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 365);
            this.panel2.TabIndex = 19;
            // 
            // lbl_joiningdate
            // 
            this.lbl_joiningdate.AutoSize = true;
            this.lbl_joiningdate.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_joiningdate.Location = new System.Drawing.Point(115, 117);
            this.lbl_joiningdate.Name = "lbl_joiningdate";
            this.lbl_joiningdate.Size = new System.Drawing.Size(85, 13);
            this.lbl_joiningdate.TabIndex = 37;
            this.lbl_joiningdate.Text = "Actual JoiningDate :";
            // 
            // txt_currentyear
            // 
            this.txt_currentyear.Enabled = false;
            this.txt_currentyear.Location = new System.Drawing.Point(115, 68);
            this.txt_currentyear.Name = "txt_currentyear";
            this.txt_currentyear.Size = new System.Drawing.Size(112, 20);
            this.txt_currentyear.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(21, 71);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 15);
            this.label21.TabIndex = 36;
            this.label21.Text = "Current Year :";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(29, 117);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(27, 13);
            this.lblMonth.TabIndex = 35;
            this.lblMonth.Text = "AJD :";
            // 
            // lbl_todate
            // 
            this.lbl_todate.AutoSize = true;
            this.lbl_todate.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_todate.Location = new System.Drawing.Point(257, 91);
            this.lbl_todate.Name = "lbl_todate";
            this.lbl_todate.Size = new System.Drawing.Size(47, 13);
            this.lbl_todate.TabIndex = 34;
            this.lbl_todate.Text = "lbl_todate";
            // 
            // lbl_FrmDate
            // 
            this.lbl_FrmDate.AutoSize = true;
            this.lbl_FrmDate.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FrmDate.Location = new System.Drawing.Point(115, 91);
            this.lbl_FrmDate.Name = "lbl_FrmDate";
            this.lbl_FrmDate.Size = new System.Drawing.Size(57, 13);
            this.lbl_FrmDate.TabIndex = 33;
            this.lbl_FrmDate.Text = "lbl_FrmDate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(204, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "CED :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(29, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "CSD :";
            // 
            // Cmb_contract
            // 
            this.Cmb_contract.FormattingEnabled = true;
            this.Cmb_contract.Location = new System.Drawing.Point(115, 38);
            this.Cmb_contract.Name = "Cmb_contract";
            this.Cmb_contract.Size = new System.Drawing.Size(211, 22);
            this.Cmb_contract.TabIndex = 5;
            this.Cmb_contract.SelectedIndexChanged += new System.EventHandler(this.Cmb_contract_SelectedIndexChanged);
            this.Cmb_contract.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cmb_contract_MouseClick);
            // 
            // cmb_subcontract
            // 
            this.cmb_subcontract.FormattingEnabled = true;
            this.cmb_subcontract.Location = new System.Drawing.Point(114, 135);
            this.cmb_subcontract.Name = "cmb_subcontract";
            this.cmb_subcontract.Size = new System.Drawing.Size(120, 22);
            this.cmb_subcontract.TabIndex = 7;
            this.cmb_subcontract.SelectedIndexChanged += new System.EventHandler(this.cmb_subcontract_SelectedIndexChanged);
            this.cmb_subcontract.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_subcontract_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Year :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Contract Tenure:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(334, 22);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer1.Panel1.Controls.Add(this.label22);
            this.splitContainer1.Panel1.Controls.Add(this.txt_allowedday);
            this.splitContainer1.Panel1.Controls.Add(this.label23);
            this.splitContainer1.Panel1.Controls.Add(this.txt_leavetaken);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Enchaseddays);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txt_allowedleaves);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer1.Panel2.Controls.Add(this.label20);
            this.splitContainer1.Panel2.Controls.Add(this.txt_mode);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.txt_daysLeft);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Size = new System.Drawing.Size(314, 306);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 25;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(38, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(98, 15);
            this.label22.TabIndex = 14;
            this.label22.Text = "Leave Of  Year  : ";
            // 
            // txt_allowedday
            // 
            this.txt_allowedday.Location = new System.Drawing.Point(151, 18);
            this.txt_allowedday.Name = "txt_allowedday";
            this.txt_allowedday.ReadOnly = true;
            this.txt_allowedday.Size = new System.Drawing.Size(43, 20);
            this.txt_allowedday.TabIndex = 16;
            this.txt_allowedday.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(202, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 15;
            this.label23.Text = "Days.";
            // 
            // txt_leavetaken
            // 
            this.txt_leavetaken.Location = new System.Drawing.Point(150, 127);
            this.txt_leavetaken.Name = "txt_leavetaken";
            this.txt_leavetaken.ReadOnly = true;
            this.txt_leavetaken.Size = new System.Drawing.Size(43, 20);
            this.txt_leavetaken.TabIndex = 12;
            this.txt_leavetaken.Text = "0";
            this.txt_leavetaken.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(201, 132);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 14);
            this.label18.TabIndex = 13;
            this.label18.Text = "Days.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(50, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 15);
            this.label17.TabIndex = 11;
            this.label17.Text = "Leave Taken     :";
            // 
            // txt_Enchaseddays
            // 
            this.txt_Enchaseddays.Location = new System.Drawing.Point(151, 90);
            this.txt_Enchaseddays.Name = "txt_Enchaseddays";
            this.txt_Enchaseddays.ReadOnly = true;
            this.txt_Enchaseddays.Size = new System.Drawing.Size(43, 20);
            this.txt_Enchaseddays.TabIndex = 11;
            this.txt_Enchaseddays.Text = "0";
            this.txt_Enchaseddays.TextChanged += new System.EventHandler(this.txt_Enchaseddays_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(201, 95);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 14);
            this.label16.TabIndex = 10;
            this.label16.Text = "Days.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(21, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = " Already Encashed    : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Leave Allowed  : ";
            // 
            // txt_allowedleaves
            // 
            this.txt_allowedleaves.Location = new System.Drawing.Point(150, 52);
            this.txt_allowedleaves.Name = "txt_allowedleaves";
            this.txt_allowedleaves.ReadOnly = true;
            this.txt_allowedleaves.Size = new System.Drawing.Size(43, 20);
            this.txt_allowedleaves.TabIndex = 10;
            this.txt_allowedleaves.Text = "0";
            this.txt_allowedleaves.TextChanged += new System.EventHandler(this.txt_enchasable_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "Days.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(126, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 15);
            this.label20.TabIndex = 14;
            this.label20.Text = "Mode :";
            // 
            // txt_mode
            // 
            this.txt_mode.Enabled = false;
            this.txt_mode.Location = new System.Drawing.Point(184, 47);
            this.txt_mode.Name = "txt_mode";
            this.txt_mode.Size = new System.Drawing.Size(123, 20);
            this.txt_mode.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Leaves Left for Encashement : ";
            // 
            // txt_daysLeft
            // 
            this.txt_daysLeft.Location = new System.Drawing.Point(180, 16);
            this.txt_daysLeft.Name = "txt_daysLeft";
            this.txt_daysLeft.Size = new System.Drawing.Size(42, 20);
            this.txt_daysLeft.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(232, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 7;
            this.label12.Text = "Days.";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Controls.Add(this.txt_mobile);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(13, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 99);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Leave Encaement Application Details";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(106, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(186, 27);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // txt_mobile
            // 
            this.txt_mobile.Location = new System.Drawing.Point(106, 28);
            this.txt_mobile.Name = "txt_mobile";
            this.txt_mobile.Size = new System.Drawing.Size(186, 20);
            this.txt_mobile.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Remark  : ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Priority :";
            // 
            // cmb_daytype
            // 
            this.cmb_daytype.FormattingEnabled = true;
            this.cmb_daytype.Items.AddRange(new object[] {
            "Days of year",
            "Half Day"});
            this.cmb_daytype.Location = new System.Drawing.Point(190, 191);
            this.cmb_daytype.Name = "cmb_daytype";
            this.cmb_daytype.Size = new System.Drawing.Size(102, 22);
            this.cmb_daytype.TabIndex = 9;
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDays.Location = new System.Drawing.Point(116, 193);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(64, 20);
            this.txtDays.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = "Encash Days :";
            // 
            // cmb_leave
            // 
            this.cmb_leave.FormattingEnabled = true;
            this.cmb_leave.Location = new System.Drawing.Point(116, 8);
            this.cmb_leave.Name = "cmb_leave";
            this.cmb_leave.Size = new System.Drawing.Size(121, 22);
            this.cmb_leave.TabIndex = 4;
            this.cmb_leave.SelectedIndexChanged += new System.EventHandler(this.cmb_leave_SelectedIndexChanged);
            this.cmb_leave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_leave_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Leave Type :";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_cancell,
            this.toolStripSeparator1,
            this.btn_submitt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 617);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(673, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_cancell
            // 
            this.btn_cancell.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_cancell.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancell.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancell.Image")));
            this.btn_cancell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancell.Name = "btn_cancell";
            this.btn_cancell.Size = new System.Drawing.Size(62, 22);
            this.btn_cancell.Text = "Cancel";
            this.btn_cancell.Click += new System.EventHandler(this.btn_cancell_Click);
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
            // tbl_empdata
            // 
            this.tbl_empdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_empdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_empdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_empdata.Enabled = false;
            this.tbl_empdata.Location = new System.Drawing.Point(0, 106);
            this.tbl_empdata.Name = "tbl_empdata";
            this.tbl_empdata.RowHeadersVisible = false;
            this.tbl_empdata.Size = new System.Drawing.Size(661, 89);
            this.tbl_empdata.TabIndex = 20;
            // 
            // lbl_subcontrctenddate
            // 
            this.lbl_subcontrctenddate.AutoSize = true;
            this.lbl_subcontrctenddate.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subcontrctenddate.ForeColor = System.Drawing.Color.Red;
            this.lbl_subcontrctenddate.Location = new System.Drawing.Point(262, 168);
            this.lbl_subcontrctenddate.Name = "lbl_subcontrctenddate";
            this.lbl_subcontrctenddate.Size = new System.Drawing.Size(36, 13);
            this.lbl_subcontrctenddate.TabIndex = 41;
            this.lbl_subcontrctenddate.Text = "label24";
            // 
            // lbl_subcontractstartdate
            // 
            this.lbl_subcontractstartdate.AutoSize = true;
            this.lbl_subcontractstartdate.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subcontractstartdate.ForeColor = System.Drawing.Color.Red;
            this.lbl_subcontractstartdate.Location = new System.Drawing.Point(120, 168);
            this.lbl_subcontractstartdate.Name = "lbl_subcontractstartdate";
            this.lbl_subcontractstartdate.Size = new System.Drawing.Size(36, 13);
            this.lbl_subcontractstartdate.TabIndex = 40;
            this.lbl_subcontractstartdate.Text = "label25";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(209, 168);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 13);
            this.label26.TabIndex = 39;
            this.label26.Text = "To:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(34, 168);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(34, 13);
            this.label27.TabIndex = 38;
            this.label27.Text = "From :";
            // 
            // LeaveEnchasementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(673, 717);
            this.Controls.Add(this.tbl_empdata);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LeaveEnchasementForm";
            this.Text = "Leave Encashement";
            this.Load += new System.EventHandler(this.LeaveEnchasementForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_empdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_empcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_daysLeft;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_allowedleaves;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_mobile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_cancell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_submitt;
        private System.Windows.Forms.ComboBox cmb_daytype;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_leave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_leavetaken;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_Enchaseddays;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmb_subcontract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cmb_contract;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lbl_todate;
        private System.Windows.Forms.Label lbl_FrmDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_currentyear;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_mode;
        private System.Windows.Forms.DataGridView tbl_empdata;
        private System.Windows.Forms.Label lbl_joiningdate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_allowedday;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbl_subcontrctenddate;
        private System.Windows.Forms.Label lbl_subcontractstartdate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
    }
}
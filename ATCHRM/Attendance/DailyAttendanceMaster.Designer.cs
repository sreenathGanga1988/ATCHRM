namespace ATCHRM.Attendance
{
    partial class DailyCloseregister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyCloseregister));
            this.dtp_datetoday = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_EmpCode = new System.Windows.Forms.ComboBox();
            this.Cmb_Department = new System.Windows.Forms.ComboBox();
            this.Cmb_location = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_EmployeeSearch = new System.Windows.Forms.CheckBox();
            this.tbl_DailyTime = new System.Windows.Forms.DataGridView();
            this.mrk_present = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.markSwipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grp_Dtatypesin = new System.Windows.Forms.GroupBox();
            this.RBT_INOUT = new System.Windows.Forms.RadioButton();
            this.rbt_swipeOut = new System.Windows.Forms.RadioButton();
            this.rbt_swipe = new System.Windows.Forms.RadioButton();
            this.grp_all = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_oldempid = new System.Windows.Forms.TextBox();
            this.lbl_day = new System.Windows.Forms.Label();
            this.lbl_daystatus = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Lh_panel = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_LH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_go = new System.Windows.Forms.Button();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_approval = new System.Windows.Forms.ToolStripButton();
            this.btn_exportExcel = new System.Windows.Forms.ToolStripButton();
            this.btn_all = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyTime)).BeginInit();
            this.mrk_present.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grp_Dtatypesin.SuspendLayout();
            this.grp_all.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.Lh_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_datetoday
            // 
            this.dtp_datetoday.CustomFormat = "MM-dd-yyyy";
            this.dtp_datetoday.Location = new System.Drawing.Point(923, 4);
            this.dtp_datetoday.Name = "dtp_datetoday";
            this.dtp_datetoday.Size = new System.Drawing.Size(190, 20);
            this.dtp_datetoday.TabIndex = 1;
            this.dtp_datetoday.ValueChanged += new System.EventHandler(this.dtp_datetoday_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.cmb_EmpCode);
            this.groupBox1.Controls.Add(this.Cmb_Department);
            this.groupBox1.Controls.Add(this.Cmb_location);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By ";
            // 
            // cmb_EmpCode
            // 
            this.cmb_EmpCode.FormattingEnabled = true;
            this.cmb_EmpCode.Location = new System.Drawing.Point(614, 16);
            this.cmb_EmpCode.Name = "cmb_EmpCode";
            this.cmb_EmpCode.Size = new System.Drawing.Size(121, 22);
            this.cmb_EmpCode.TabIndex = 4;
            this.cmb_EmpCode.SelectedIndexChanged += new System.EventHandler(this.cmb_EmpCode_SelectedIndexChanged);
            this.cmb_EmpCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_EmpCode_MouseClick);
            // 
            // Cmb_Department
            // 
            this.Cmb_Department.FormattingEnabled = true;
            this.Cmb_Department.Location = new System.Drawing.Point(377, 16);
            this.Cmb_Department.Name = "Cmb_Department";
            this.Cmb_Department.Size = new System.Drawing.Size(150, 22);
            this.Cmb_Department.TabIndex = 3;
            this.Cmb_Department.SelectedIndexChanged += new System.EventHandler(this.Cmb_Department_SelectedIndexChanged);
            this.Cmb_Department.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cmb_Department_MouseClick);
            // 
            // Cmb_location
            // 
            this.Cmb_location.FormattingEnabled = true;
            this.Cmb_location.Location = new System.Drawing.Point(83, 15);
            this.Cmb_location.Name = "Cmb_location";
            this.Cmb_location.Size = new System.Drawing.Size(190, 22);
            this.Cmb_location.TabIndex = 2;
            this.Cmb_location.SelectedIndexChanged += new System.EventHandler(this.Cmb_location_SelectedIndexChanged);
            this.Cmb_location.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cmb_location_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(293, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(539, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Empcode :";
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
            // chk_EmployeeSearch
            // 
            this.chk_EmployeeSearch.AutoSize = true;
            this.chk_EmployeeSearch.Location = new System.Drawing.Point(805, 26);
            this.chk_EmployeeSearch.Name = "chk_EmployeeSearch";
            this.chk_EmployeeSearch.Size = new System.Drawing.Size(15, 14);
            this.chk_EmployeeSearch.TabIndex = 5;
            this.chk_EmployeeSearch.UseVisualStyleBackColor = true;
            this.chk_EmployeeSearch.CheckedChanged += new System.EventHandler(this.chk_EmployeeSearch_CheckedChanged);
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
            this.tbl_DailyTime.Location = new System.Drawing.Point(9, 141);
            this.tbl_DailyTime.Name = "tbl_DailyTime";
            this.tbl_DailyTime.RowHeadersVisible = false;
            this.tbl_DailyTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_DailyTime.Size = new System.Drawing.Size(1176, 363);
            this.tbl_DailyTime.TabIndex = 9;
            this.tbl_DailyTime.CurrentCellDirtyStateChanged += new System.EventHandler(this.tbl_DailyTime_CurrentCellDirtyStateChanged);
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
            this.mrk_present.Opening += new System.ComponentModel.CancelEventHandler(this.mrk_present_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem1.Text = "Mark P";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem2.Text = "Mark LH";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(0, 532);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1197, 75);
            this.groupBox2.TabIndex = 12;
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
            this.grp_Dtatypesin.Controls.Add(this.rbt_swipeOut);
            this.grp_Dtatypesin.Controls.Add(this.rbt_swipe);
            this.grp_Dtatypesin.Location = new System.Drawing.Point(12, 84);
            this.grp_Dtatypesin.Name = "grp_Dtatypesin";
            this.grp_Dtatypesin.Size = new System.Drawing.Size(401, 47);
            this.grp_Dtatypesin.TabIndex = 17;
            this.grp_Dtatypesin.TabStop = false;
            this.grp_Dtatypesin.Text = "Details";
            // 
            // RBT_INOUT
            // 
            this.RBT_INOUT.AutoSize = true;
            this.RBT_INOUT.Checked = true;
            this.RBT_INOUT.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBT_INOUT.Location = new System.Drawing.Point(292, 17);
            this.RBT_INOUT.Name = "RBT_INOUT";
            this.RBT_INOUT.Size = new System.Drawing.Size(51, 19);
            this.RBT_INOUT.TabIndex = 8;
            this.RBT_INOUT.TabStop = true;
            this.RBT_INOUT.Text = "Both";
            this.RBT_INOUT.UseVisualStyleBackColor = true;
            this.RBT_INOUT.CheckedChanged += new System.EventHandler(this.RBT_INOUT_CheckedChanged);
            // 
            // rbt_swipeOut
            // 
            this.rbt_swipeOut.AutoSize = true;
            this.rbt_swipeOut.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_swipeOut.Location = new System.Drawing.Point(168, 17);
            this.rbt_swipeOut.Name = "rbt_swipeOut";
            this.rbt_swipeOut.Size = new System.Drawing.Size(82, 19);
            this.rbt_swipeOut.TabIndex = 7;
            this.rbt_swipeOut.Text = "Swipe Out";
            this.rbt_swipeOut.UseVisualStyleBackColor = true;
            this.rbt_swipeOut.CheckedChanged += new System.EventHandler(this.rbt_swipeOut_CheckedChanged);
            // 
            // rbt_swipe
            // 
            this.rbt_swipe.AutoSize = true;
            this.rbt_swipe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_swipe.Location = new System.Drawing.Point(63, 16);
            this.rbt_swipe.Name = "rbt_swipe";
            this.rbt_swipe.Size = new System.Drawing.Size(71, 19);
            this.rbt_swipe.TabIndex = 7;
            this.rbt_swipe.Text = "Swipe In";
            this.rbt_swipe.UseVisualStyleBackColor = true;
            this.rbt_swipe.CheckedChanged += new System.EventHandler(this.rbt_swipe_CheckedChanged);
            // 
            // grp_all
            // 
            this.grp_all.Controls.Add(this.btn_all);
            this.grp_all.Location = new System.Drawing.Point(826, 26);
            this.grp_all.Name = "grp_all";
            this.grp_all.Size = new System.Drawing.Size(359, 58);
            this.grp_all.TabIndex = 21;
            this.grp_all.TabStop = false;
            this.grp_all.Text = "Show All Employee Data";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txt_oldempid);
            this.groupBox4.Controls.Add(this.lbl_day);
            this.groupBox4.Controls.Add(this.lbl_daystatus);
            this.groupBox4.Location = new System.Drawing.Point(419, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(766, 47);
            this.groupBox4.TabIndex = 18;
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
            this.lbl_day.Location = new System.Drawing.Point(596, 10);
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
            this.lbl_daystatus.Location = new System.Drawing.Point(595, 25);
            this.lbl_daystatus.Name = "lbl_daystatus";
            this.lbl_daystatus.Size = new System.Drawing.Size(153, 22);
            this.lbl_daystatus.TabIndex = 25;
            this.lbl_daystatus.Text = "xxxxxxxxxxxxx";
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 507);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1197, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Lh_panel
            // 
            this.Lh_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.Lh_panel.Controls.Add(this.button2);
            this.Lh_panel.Controls.Add(this.button1);
            this.Lh_panel.Controls.Add(this.txt_LH);
            this.Lh_panel.Controls.Add(this.label4);
            this.Lh_panel.Location = new System.Drawing.Point(791, 182);
            this.Lh_panel.Name = "Lh_panel";
            this.Lh_panel.Size = new System.Drawing.Size(96, 59);
            this.Lh_panel.TabIndex = 10;
            this.Lh_panel.TabStop = false;
            this.Lh_panel.Text = "LH";
            this.Lh_panel.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txt_LH
            // 
            this.txt_LH.Location = new System.Drawing.Point(62, 10);
            this.txt_LH.Name = "txt_LH";
            this.txt_LH.Size = new System.Drawing.Size(28, 20);
            this.txt_LH.TabIndex = 1;
            this.txt_LH.Text = "0";
            this.txt_LH.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txt_LH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.txt_LH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "LH Value";
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(1119, 2);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(32, 24);
            this.btn_go.TabIndex = 22;
            this.btn_go.Text = "GO";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
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
            // btn_exportExcel
            // 
            this.btn_exportExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_exportExcel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_exportExcel.Image")));
            this.btn_exportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(108, 22);
            this.btn_exportExcel.Text = "Export To Excel";
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // btn_all
            // 
            this.btn_all.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all.Image = global::ATCHRM.Properties.Resources.user_go;
            this.btn_all.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_all.Location = new System.Drawing.Point(28, 15);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(210, 37);
            this.btn_all.TabIndex = 6;
            this.btn_all.Text = "Show All";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // DailyCloseregister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1197, 607);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grp_all);
            this.Controls.Add(this.Lh_panel);
            this.Controls.Add(this.chk_EmployeeSearch);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grp_Dtatypesin);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbl_DailyTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtp_datetoday);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "DailyCloseregister";
            this.Text = "Close Register";
            this.Load += new System.EventHandler(this.DailyAttendanceMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyTime)).EndInit();
            this.mrk_present.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_Dtatypesin.ResumeLayout(false);
            this.grp_Dtatypesin.PerformLayout();
            this.grp_all.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Lh_panel.ResumeLayout(false);
            this.Lh_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_datetoday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_EmployeeSearch;
        private System.Windows.Forms.ComboBox cmb_EmpCode;
        private System.Windows.Forms.ComboBox Cmb_Department;
        private System.Windows.Forms.ComboBox Cmb_location;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tbl_DailyTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grp_Dtatypesin;
        private System.Windows.Forms.RadioButton RBT_INOUT;
        private System.Windows.Forms.RadioButton rbt_swipeOut;
        private System.Windows.Forms.RadioButton rbt_swipe;
        private System.Windows.Forms.GroupBox grp_all;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_daystatus;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_approval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_exportExcel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Label lbl_day;
        private System.Windows.Forms.ContextMenuStrip mrk_present;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.GroupBox Lh_panel;
        private System.Windows.Forms.TextBox txt_LH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_oldempid;
        private System.Windows.Forms.ToolStripMenuItem markSwipeToolStripMenuItem;
    }
}
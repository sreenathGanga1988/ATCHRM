namespace ATCHRM.Applications
{
    partial class OVertimeApplicationMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OVertimeApplicationMaster));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_apply = new System.Windows.Forms.ToolStripButton();
            this.tbl_Abscent = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chk_Selection = new System.Windows.Forms.CheckBox();
            this.roundedGroupBox2 = new RoundedGroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_oldid = new System.Windows.Forms.TextBox();
            this.lbl_otType = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_Adress1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rht1_reason = new System.Windows.Forms.RichTextBox();
            this.txtduration = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Companyname = new System.Windows.Forms.Label();
            this.cmb_empcode = new System.Windows.Forms.ComboBox();
            this.cmb_designation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_CompanyCode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.roundedGroupBox1 = new RoundedGroupBox();
            this.lbl_daystatus = new System.Windows.Forms.Label();
            this.lbl_day = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_Otdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.RejectOT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteAPP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbl_otdetails = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_applicationumber = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Abscent)).BeginInit();
            this.roundedGroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.roundedGroupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_otdetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(946, 561);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.tbl_Abscent);
            this.tabPage1.Controls.Add(this.chk_Selection);
            this.tabPage1.Controls.Add(this.roundedGroupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(938, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Application";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btn_apply});
            this.toolStrip1.Location = new System.Drawing.Point(3, 507);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(932, 25);
            this.toolStrip1.TabIndex = 9;
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
            // btn_apply
            // 
            this.btn_apply.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_apply.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_apply.Image = ((System.Drawing.Image)(resources.GetObject("btn_apply.Image")));
            this.btn_apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(66, 22);
            this.btn_apply.Text = "Submit";
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // tbl_Abscent
            // 
            this.tbl_Abscent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_Abscent.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_Abscent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Abscent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.tbl_Abscent.Location = new System.Drawing.Point(1, 198);
            this.tbl_Abscent.Name = "tbl_Abscent";
            this.tbl_Abscent.RowHeadersVisible = false;
            this.tbl_Abscent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_Abscent.Size = new System.Drawing.Size(937, 306);
            this.tbl_Abscent.TabIndex = 8;
            this.tbl_Abscent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_Aplication_CellContentClick);
            this.tbl_Abscent.CurrentCellDirtyStateChanged += new System.EventHandler(this.tbl_Aplication_CurrentCellDirtyStateChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Select";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chk_Selection
            // 
            this.chk_Selection.AutoSize = true;
            this.chk_Selection.Location = new System.Drawing.Point(6, 174);
            this.chk_Selection.Name = "chk_Selection";
            this.chk_Selection.Size = new System.Drawing.Size(70, 17);
            this.chk_Selection.TabIndex = 7;
            this.chk_Selection.Text = "Select All";
            this.chk_Selection.UseVisualStyleBackColor = true;
            this.chk_Selection.CheckedChanged += new System.EventHandler(this.chk_Selection_CheckedChanged);
            // 
            // roundedGroupBox2
            // 
            this.roundedGroupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.roundedGroupBox2.BackgroundColor = System.Drawing.Color.Transparent;
            this.roundedGroupBox2.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.roundedGroupBox2.BackgroundGradientMode = RoundedGroupBox.GroupBoxGradientMode.Vertical;
            this.roundedGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.roundedGroupBox2.BorderWidth = 1F;
            this.roundedGroupBox2.Caption = "";
            this.roundedGroupBox2.CaptionAlignment = RoundedGroupBox.CaptionAlignmentEnum.Center;
            this.roundedGroupBox2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.roundedGroupBox2.CaptionHeight = 25;
            this.roundedGroupBox2.CaptionVisible = true;
            this.roundedGroupBox2.Controls.Add(this.label10);
            this.roundedGroupBox2.Controls.Add(this.btn_search);
            this.roundedGroupBox2.Controls.Add(this.txt_oldid);
            this.roundedGroupBox2.Controls.Add(this.lbl_otType);
            this.roundedGroupBox2.Controls.Add(this.button1);
            this.roundedGroupBox2.Controls.Add(this.lbl_Adress1);
            this.roundedGroupBox2.Controls.Add(this.label8);
            this.roundedGroupBox2.Controls.Add(this.rht1_reason);
            this.roundedGroupBox2.Controls.Add(this.txtduration);
            this.roundedGroupBox2.Controls.Add(this.groupBox1);
            this.roundedGroupBox2.Controls.Add(this.label3);
            this.roundedGroupBox2.Controls.Add(this.lbl_CompanyCode);
            this.roundedGroupBox2.Controls.Add(this.label9);
            this.roundedGroupBox2.Controls.Add(this.roundedGroupBox1);
            this.roundedGroupBox2.Controls.Add(this.dtp_Otdate);
            this.roundedGroupBox2.Controls.Add(this.label4);
            this.roundedGroupBox2.CornerRadius = 5;
            this.roundedGroupBox2.Corners = ((RoundedGroupBox.GroupBoxCorners)((((RoundedGroupBox.GroupBoxCorners.NorthWest | RoundedGroupBox.GroupBoxCorners.NorthEast) 
            | RoundedGroupBox.GroupBoxCorners.SouthEast) 
            | RoundedGroupBox.GroupBoxCorners.SouthWest)));
            this.roundedGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.roundedGroupBox2.DropShadowThickness = 3;
            this.roundedGroupBox2.DropShadowVisible = true;
            this.roundedGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.roundedGroupBox2.Name = "roundedGroupBox2";
            this.roundedGroupBox2.Size = new System.Drawing.Size(932, 165);
            this.roundedGroupBox2.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 49;
            this.label10.Text = "Old ID :";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(185, 135);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(26, 20);
            this.btn_search.TabIndex = 48;
            this.btn_search.Text = "S";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_oldid
            // 
            this.txt_oldid.Location = new System.Drawing.Point(82, 135);
            this.txt_oldid.Name = "txt_oldid";
            this.txt_oldid.Size = new System.Drawing.Size(97, 20);
            this.txt_oldid.TabIndex = 47;
            this.txt_oldid.Text = "0";
            this.txt_oldid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_oldid_KeyDown);
            // 
            // lbl_otType
            // 
            this.lbl_otType.AutoSize = true;
            this.lbl_otType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_otType.Location = new System.Drawing.Point(852, 36);
            this.lbl_otType.Name = "lbl_otType";
            this.lbl_otType.Size = new System.Drawing.Size(40, 15);
            this.lbl_otType.TabIndex = 46;
            this.lbl_otType.Text = "label6";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(514, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Adress1
            // 
            this.lbl_Adress1.AutoSize = true;
            this.lbl_Adress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Adress1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Adress1.Location = new System.Drawing.Point(551, 72);
            this.lbl_Adress1.Name = "lbl_Adress1";
            this.lbl_Adress1.Size = new System.Drawing.Size(13, 17);
            this.lbl_Adress1.TabIndex = 44;
            this.lbl_Adress1.Text = "*";
            this.lbl_Adress1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(348, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 41;
            this.label8.Text = "Duration :";
            // 
            // rht1_reason
            // 
            this.rht1_reason.Location = new System.Drawing.Point(414, 68);
            this.rht1_reason.Name = "rht1_reason";
            this.rht1_reason.Size = new System.Drawing.Size(129, 44);
            this.rht1_reason.TabIndex = 4;
            this.rht1_reason.Text = "";
            // 
            // txtduration
            // 
            this.txtduration.Location = new System.Drawing.Point(416, 36);
            this.txtduration.Name = "txtduration";
            this.txtduration.Size = new System.Drawing.Size(97, 20);
            this.txtduration.TabIndex = 3;
            this.txtduration.Text = "0";
            this.txtduration.TextChanged += new System.EventHandler(this.txtduration_TextChanged);
            this.txtduration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtduration_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Companyname);
            this.groupBox1.Controls.Add(this.cmb_empcode);
            this.groupBox1.Controls.Add(this.cmb_designation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_dept);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 101);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // lbl_Companyname
            // 
            this.lbl_Companyname.AutoSize = true;
            this.lbl_Companyname.ForeColor = System.Drawing.Color.Red;
            this.lbl_Companyname.Location = new System.Drawing.Point(299, 12);
            this.lbl_Companyname.Name = "lbl_Companyname";
            this.lbl_Companyname.Size = new System.Drawing.Size(11, 13);
            this.lbl_Companyname.TabIndex = 34;
            this.lbl_Companyname.Text = "*";
            this.lbl_Companyname.Visible = false;
            // 
            // cmb_empcode
            // 
            this.cmb_empcode.FormattingEnabled = true;
            this.cmb_empcode.Location = new System.Drawing.Point(79, 72);
            this.cmb_empcode.Name = "cmb_empcode";
            this.cmb_empcode.Size = new System.Drawing.Size(214, 21);
            this.cmb_empcode.TabIndex = 2;
            this.cmb_empcode.SelectedIndexChanged += new System.EventHandler(this.cmb_empcode_SelectedIndexChanged);
            this.cmb_empcode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_empcode_MouseClick);
            // 
            // cmb_designation
            // 
            this.cmb_designation.FormattingEnabled = true;
            this.cmb_designation.Location = new System.Drawing.Point(79, 40);
            this.cmb_designation.Name = "cmb_designation";
            this.cmb_designation.Size = new System.Drawing.Size(214, 21);
            this.cmb_designation.TabIndex = 1;
            this.cmb_designation.SelectedIndexChanged += new System.EventHandler(this.cmb_designation_SelectedIndexChanged);
            this.cmb_designation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_designation_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Desig. : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Emp Code : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dept :";
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(79, 12);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(214, 21);
            this.cmb_dept.TabIndex = 0;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            this.cmb_dept.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_dept_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(334, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "Description :";
            // 
            // lbl_CompanyCode
            // 
            this.lbl_CompanyCode.AutoSize = true;
            this.lbl_CompanyCode.ForeColor = System.Drawing.Color.Red;
            this.lbl_CompanyCode.Location = new System.Drawing.Point(574, 39);
            this.lbl_CompanyCode.Name = "lbl_CompanyCode";
            this.lbl_CompanyCode.Size = new System.Drawing.Size(11, 13);
            this.lbl_CompanyCode.TabIndex = 43;
            this.lbl_CompanyCode.Text = "*";
            this.lbl_CompanyCode.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(519, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 42;
            this.label9.Text = "Minutes";
            // 
            // roundedGroupBox1
            // 
            this.roundedGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.roundedGroupBox1.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.roundedGroupBox1.BackgroundGradientMode = RoundedGroupBox.GroupBoxGradientMode.Vertical;
            this.roundedGroupBox1.BorderColor = System.Drawing.Color.DarkGray;
            this.roundedGroupBox1.BorderWidth = 1F;
            this.roundedGroupBox1.Caption = "Day Status";
            this.roundedGroupBox1.CaptionAlignment = RoundedGroupBox.CaptionAlignmentEnum.Center;
            this.roundedGroupBox1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.roundedGroupBox1.CaptionHeight = 25;
            this.roundedGroupBox1.CaptionVisible = true;
            this.roundedGroupBox1.Controls.Add(this.lbl_daystatus);
            this.roundedGroupBox1.Controls.Add(this.lbl_day);
            this.roundedGroupBox1.Controls.Add(this.label6);
            this.roundedGroupBox1.CornerRadius = 5;
            this.roundedGroupBox1.Corners = ((RoundedGroupBox.GroupBoxCorners)((((RoundedGroupBox.GroupBoxCorners.NorthWest | RoundedGroupBox.GroupBoxCorners.NorthEast) 
            | RoundedGroupBox.GroupBoxCorners.SouthEast) 
            | RoundedGroupBox.GroupBoxCorners.SouthWest)));
            this.roundedGroupBox1.DropShadowThickness = 3;
            this.roundedGroupBox1.DropShadowVisible = true;
            this.roundedGroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedGroupBox1.Location = new System.Drawing.Point(595, 62);
            this.roundedGroupBox1.Name = "roundedGroupBox1";
            this.roundedGroupBox1.Size = new System.Drawing.Size(252, 81);
            this.roundedGroupBox1.TabIndex = 17;
            // 
            // lbl_daystatus
            // 
            this.lbl_daystatus.AutoSize = true;
            this.lbl_daystatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daystatus.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_daystatus.Location = new System.Drawing.Point(125, 61);
            this.lbl_daystatus.Name = "lbl_daystatus";
            this.lbl_daystatus.Size = new System.Drawing.Size(40, 15);
            this.lbl_daystatus.TabIndex = 37;
            this.lbl_daystatus.Text = "label5";
            // 
            // lbl_day
            // 
            this.lbl_day.AutoSize = true;
            this.lbl_day.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_day.Location = new System.Drawing.Point(125, 31);
            this.lbl_day.Name = "lbl_day";
            this.lbl_day.Size = new System.Drawing.Size(20, 15);
            this.lbl_day.TabIndex = 41;
            this.lbl_day.Text = "na";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "Day of Week:";
            // 
            // dtp_Otdate
            // 
            this.dtp_Otdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Otdate.Location = new System.Drawing.Point(689, 36);
            this.dtp_Otdate.Name = "dtp_Otdate";
            this.dtp_Otdate.Size = new System.Drawing.Size(148, 20);
            this.dtp_Otdate.TabIndex = 5;
            this.dtp_Otdate.ValueChanged += new System.EventHandler(this.dtp_Otdate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(616, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "OT  Date :";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Controls.Add(this.tbl_otdetails);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cmb_applicationumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(938, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Status";
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripSeparator5,
            this.RejectOT,
            this.toolStripSeparator6});
            this.toolStrip3.Location = new System.Drawing.Point(3, 507);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(932, 25);
            this.toolStrip3.TabIndex = 28;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(62, 22);
            this.toolStripButton3.Text = "Cancel";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // RejectOT
            // 
            this.RejectOT.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RejectOT.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RejectOT.Image = ((System.Drawing.Image)(resources.GetObject("RejectOT.Image")));
            this.RejectOT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RejectOT.Name = "RejectOT";
            this.RejectOT.Size = new System.Drawing.Size(128, 22);
            this.RejectOT.Text = "Delete Application";
            this.RejectOT.Click += new System.EventHandler(this.RejectOT_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.deleteAPP,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(3, 511);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(932, 28);
            this.toolStrip2.TabIndex = 27;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 25);
            this.toolStripButton2.Text = "Cancel";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // deleteAPP
            // 
            this.deleteAPP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deleteAPP.Image = ((System.Drawing.Image)(resources.GetObject("deleteAPP.Image")));
            this.deleteAPP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteAPP.Name = "deleteAPP";
            this.deleteAPP.Size = new System.Drawing.Size(156, 25);
            this.deleteAPP.Text = "Delete Application";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // tbl_otdetails
            // 
            this.tbl_otdetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_otdetails.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_otdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_otdetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column2,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26});
            this.tbl_otdetails.Location = new System.Drawing.Point(6, 33);
            this.tbl_otdetails.Name = "tbl_otdetails";
            this.tbl_otdetails.RowHeadersVisible = false;
            this.tbl_otdetails.Size = new System.Drawing.Size(926, 462);
            this.tbl_otdetails.TabIndex = 5;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Empid";
            this.Column15.Name = "Column15";
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "OT APPPK";
            this.Column16.Name = "Column16";
            this.Column16.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "OT APP #";
            this.Column2.Name = "Column2";
            // 
            // Column17
            // 
            this.Column17.HeaderText = "OT Date";
            this.Column17.Name = "Column17";
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Emp no";
            this.Column18.Name = "Column18";
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Emp Name";
            this.Column19.Name = "Column19";
            // 
            // Column20
            // 
            this.Column20.HeaderText = "Designation";
            this.Column20.Name = "Column20";
            // 
            // Column21
            // 
            this.Column21.HeaderText = "Duration";
            this.Column21.Name = "Column21";
            // 
            // Column22
            // 
            this.Column22.HeaderText = "Duration Type";
            this.Column22.Name = "Column22";
            // 
            // Column23
            // 
            this.Column23.HeaderText = "OT Type";
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.HeaderText = "Level 1";
            this.Column24.Name = "Column24";
            // 
            // Column25
            // 
            this.Column25.HeaderText = "Level 2";
            this.Column25.Name = "Column25";
            // 
            // Column26
            // 
            this.Column26.HeaderText = "Level 3";
            this.Column26.Name = "Column26";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(355, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sumbit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "OT Application # : ";
            // 
            // cmb_applicationumber
            // 
            this.cmb_applicationumber.FormattingEnabled = true;
            this.cmb_applicationumber.Location = new System.Drawing.Point(126, 10);
            this.cmb_applicationumber.Name = "cmb_applicationumber";
            this.cmb_applicationumber.Size = new System.Drawing.Size(180, 21);
            this.cmb_applicationumber.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 568);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 67);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(336, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // OVertimeApplicationMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(970, 635);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Name = "OVertimeApplicationMaster";
            this.Text = "Overtime Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OVertimeApplicationMaster_FormClosing);
            this.Load += new System.EventHandler(this.OVertimeApplicationMaster_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Abscent)).EndInit();
            this.roundedGroupBox2.ResumeLayout(false);
            this.roundedGroupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.roundedGroupBox1.ResumeLayout(false);
            this.roundedGroupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_otdetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private RoundedGroupBox roundedGroupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Adress1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rht1_reason;
        private System.Windows.Forms.TextBox txtduration;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Companyname;
        private System.Windows.Forms.ComboBox cmb_empcode;
        private System.Windows.Forms.ComboBox cmb_designation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_CompanyCode;
        private System.Windows.Forms.Label label9;
        private RoundedGroupBox roundedGroupBox1;
        private System.Windows.Forms.Label lbl_daystatus;
        private System.Windows.Forms.Label lbl_day;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_Otdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_Selection;
        private System.Windows.Forms.DataGridView tbl_Abscent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_apply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_applicationumber;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView tbl_otdetails;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton deleteAPP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton RejectOT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.Label lbl_otType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_oldid;
    }
}
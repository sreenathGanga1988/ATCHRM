namespace ATCHRM.Applications
{
    partial class OvertimeMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OvertimeMasterForm));
            this.tbl_Aplication = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chk_Selection = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_approval = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_apply = new System.Windows.Forms.ToolStripButton();
            this.roundedGroupBox2 = new RoundedGroupBox();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_otType = new System.Windows.Forms.Label();
            this.dtp_Otdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Aplication)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.roundedGroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.roundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_Aplication
            // 
            this.tbl_Aplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_Aplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Aplication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.tbl_Aplication.Location = new System.Drawing.Point(0, 190);
            this.tbl_Aplication.Name = "tbl_Aplication";
            this.tbl_Aplication.RowHeadersVisible = false;
            this.tbl_Aplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_Aplication.Size = new System.Drawing.Size(935, 391);
            this.tbl_Aplication.TabIndex = 9;
            this.tbl_Aplication.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
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
            this.chk_Selection.Location = new System.Drawing.Point(13, 170);
            this.chk_Selection.Name = "chk_Selection";
            this.chk_Selection.Size = new System.Drawing.Size(70, 18);
            this.chk_Selection.TabIndex = 8;
            this.chk_Selection.Text = "Select All";
            this.chk_Selection.UseVisualStyleBackColor = true;
            this.chk_Selection.CheckedChanged += new System.EventHandler(this.chk_Selection_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 614);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(935, 70);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(363, 30);
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
            this.btn_approval,
            this.toolStripSeparator2,
            this.btn_apply});
            this.toolStrip1.Location = new System.Drawing.Point(0, 589);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(935, 25);
            this.toolStrip1.TabIndex = 10;
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
            // btn_approval
            // 
            this.btn_approval.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_approval.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_approval.Image = ((System.Drawing.Image)(resources.GetObject("btn_approval.Image")));
            this.btn_approval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_approval.Name = "btn_approval";
            this.btn_approval.Size = new System.Drawing.Size(82, 22);
            this.btn_approval.Text = "Segregate";
            this.btn_approval.Click += new System.EventHandler(this.btn_approval_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click_1);
            // 
            // roundedGroupBox2
            // 
            this.roundedGroupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.roundedGroupBox2.BackgroundColor = System.Drawing.Color.White;
            this.roundedGroupBox2.BackgroundColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.roundedGroupBox2.BackgroundGradientMode = RoundedGroupBox.GroupBoxGradientMode.Vertical;
            this.roundedGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(178)))), ((int)(((byte)(227)))));
            this.roundedGroupBox2.BorderWidth = 1F;
            this.roundedGroupBox2.Caption = "";
            this.roundedGroupBox2.CaptionAlignment = RoundedGroupBox.CaptionAlignmentEnum.Center;
            this.roundedGroupBox2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.roundedGroupBox2.CaptionHeight = 25;
            this.roundedGroupBox2.CaptionVisible = true;
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
            this.roundedGroupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.roundedGroupBox2.Name = "roundedGroupBox2";
            this.roundedGroupBox2.Size = new System.Drawing.Size(935, 165);
            this.roundedGroupBox2.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(533, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbl_Adress1
            // 
            this.lbl_Adress1.AutoSize = true;
            this.lbl_Adress1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Adress1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Adress1.Location = new System.Drawing.Point(624, 73);
            this.lbl_Adress1.Name = "lbl_Adress1";
            this.lbl_Adress1.Size = new System.Drawing.Size(13, 15);
            this.lbl_Adress1.TabIndex = 44;
            this.lbl_Adress1.Text = "*";
            this.lbl_Adress1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(412, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 41;
            this.label8.Text = "Duration :";
            // 
            // rht1_reason
            // 
            this.rht1_reason.Location = new System.Drawing.Point(489, 72);
            this.rht1_reason.Name = "rht1_reason";
            this.rht1_reason.Size = new System.Drawing.Size(125, 44);
            this.rht1_reason.TabIndex = 4;
            this.rht1_reason.Text = "";
            // 
            // txtduration
            // 
            this.txtduration.Location = new System.Drawing.Point(488, 33);
            this.txtduration.Name = "txtduration";
            this.txtduration.Size = new System.Drawing.Size(84, 23);
            this.txtduration.TabIndex = 39;
            this.txtduration.Text = "3";
            this.txtduration.TextChanged += new System.EventHandler(this.txtduration_TextChanged_1);
            this.txtduration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtduration_KeyPress_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.lbl_Companyname);
            this.groupBox1.Controls.Add(this.cmb_empcode);
            this.groupBox1.Controls.Add(this.cmb_designation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_dept);
            this.groupBox1.Location = new System.Drawing.Point(8, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 110);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // lbl_Companyname
            // 
            this.lbl_Companyname.AutoSize = true;
            this.lbl_Companyname.ForeColor = System.Drawing.Color.Red;
            this.lbl_Companyname.Location = new System.Drawing.Point(358, 15);
            this.lbl_Companyname.Name = "lbl_Companyname";
            this.lbl_Companyname.Size = new System.Drawing.Size(13, 15);
            this.lbl_Companyname.TabIndex = 34;
            this.lbl_Companyname.Text = "*";
            this.lbl_Companyname.Visible = false;
            // 
            // cmb_empcode
            // 
            this.cmb_empcode.FormattingEnabled = true;
            this.cmb_empcode.Location = new System.Drawing.Point(84, 77);
            this.cmb_empcode.Name = "cmb_empcode";
            this.cmb_empcode.Size = new System.Drawing.Size(262, 23);
            this.cmb_empcode.TabIndex = 2;
            this.cmb_empcode.SelectedIndexChanged += new System.EventHandler(this.cmb_empcode_SelectedIndexChanged);
            // 
            // cmb_designation
            // 
            this.cmb_designation.FormattingEnabled = true;
            this.cmb_designation.Location = new System.Drawing.Point(86, 44);
            this.cmb_designation.Name = "cmb_designation";
            this.cmb_designation.Size = new System.Drawing.Size(262, 23);
            this.cmb_designation.TabIndex = 1;
            this.cmb_designation.SelectedIndexChanged += new System.EventHandler(this.cmb_designation_SelectedIndexChanged);
            this.cmb_designation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_designation_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Designation :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Emp Code :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dept :";
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(86, 12);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(262, 23);
            this.cmb_dept.TabIndex = 0;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            this.cmb_dept.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_dept_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(401, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "Description :";
            // 
            // lbl_CompanyCode
            // 
            this.lbl_CompanyCode.AutoSize = true;
            this.lbl_CompanyCode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompanyCode.ForeColor = System.Drawing.Color.Red;
            this.lbl_CompanyCode.Location = new System.Drawing.Point(633, 33);
            this.lbl_CompanyCode.Name = "lbl_CompanyCode";
            this.lbl_CompanyCode.Size = new System.Drawing.Size(13, 15);
            this.lbl_CompanyCode.TabIndex = 43;
            this.lbl_CompanyCode.Text = "*";
            this.lbl_CompanyCode.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(583, 36);
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
            this.roundedGroupBox1.Controls.Add(this.label5);
            this.roundedGroupBox1.Controls.Add(this.label6);
            this.roundedGroupBox1.Controls.Add(this.lbl_otType);
            this.roundedGroupBox1.CornerRadius = 5;
            this.roundedGroupBox1.Corners = ((RoundedGroupBox.GroupBoxCorners)((((RoundedGroupBox.GroupBoxCorners.NorthWest | RoundedGroupBox.GroupBoxCorners.NorthEast) 
            | RoundedGroupBox.GroupBoxCorners.SouthEast) 
            | RoundedGroupBox.GroupBoxCorners.SouthWest)));
            this.roundedGroupBox1.DropShadowThickness = 3;
            this.roundedGroupBox1.DropShadowVisible = true;
            this.roundedGroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedGroupBox1.Location = new System.Drawing.Point(659, 67);
            this.roundedGroupBox1.Name = "roundedGroupBox1";
            this.roundedGroupBox1.Size = new System.Drawing.Size(250, 91);
            this.roundedGroupBox1.TabIndex = 6;
            // 
            // lbl_daystatus
            // 
            this.lbl_daystatus.AutoSize = true;
            this.lbl_daystatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daystatus.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_daystatus.Location = new System.Drawing.Point(188, 65);
            this.lbl_daystatus.Name = "lbl_daystatus";
            this.lbl_daystatus.Size = new System.Drawing.Size(40, 15);
            this.lbl_daystatus.TabIndex = 37;
            this.lbl_daystatus.Text = "label5";
            // 
            // lbl_day
            // 
            this.lbl_day.AutoSize = true;
            this.lbl_day.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_day.Location = new System.Drawing.Point(119, 64);
            this.lbl_day.Name = "lbl_day";
            this.lbl_day.Size = new System.Drawing.Size(20, 15);
            this.lbl_day.TabIndex = 41;
            this.lbl_day.Text = "na";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "OT  Type :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "Day of Week:";
            // 
            // lbl_otType
            // 
            this.lbl_otType.AutoSize = true;
            this.lbl_otType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_otType.Location = new System.Drawing.Point(118, 36);
            this.lbl_otType.Name = "lbl_otType";
            this.lbl_otType.Size = new System.Drawing.Size(40, 15);
            this.lbl_otType.TabIndex = 38;
            this.lbl_otType.Text = "label6";
            // 
            // dtp_Otdate
            // 
            this.dtp_Otdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Otdate.Location = new System.Drawing.Point(753, 33);
            this.dtp_Otdate.Name = "dtp_Otdate";
            this.dtp_Otdate.Size = new System.Drawing.Size(148, 23);
            this.dtp_Otdate.TabIndex = 5;
            this.dtp_Otdate.ValueChanged += new System.EventHandler(this.dtp_Otdate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(656, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "OT  Date";
            // 
            // OvertimeMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(935, 684);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.roundedGroupBox2);
            this.Controls.Add(this.tbl_Aplication);
            this.Controls.Add(this.chk_Selection);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "OvertimeMasterForm";
            this.Text = "Overtime ";
            this.Load += new System.EventHandler(this.OvertimeMasterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Aplication)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.roundedGroupBox2.ResumeLayout(false);
            this.roundedGroupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.roundedGroupBox1.ResumeLayout(false);
            this.roundedGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tbl_Aplication;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.CheckBox chk_Selection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_designation;
        private System.Windows.Forms.ComboBox cmb_empcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_Otdate;
        private System.Windows.Forms.Label lbl_Companyname;
        private System.Windows.Forms.Label lbl_otType;
        private System.Windows.Forms.Label lbl_daystatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_day;
        private System.Windows.Forms.Label label6;
        private RoundedGroupBox roundedGroupBox1;
        private RoundedGroupBox roundedGroupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Adress1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rht1_reason;
        private System.Windows.Forms.TextBox txtduration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_CompanyCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_approval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_apply;

    }
}
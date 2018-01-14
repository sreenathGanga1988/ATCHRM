namespace ATCHRM
{
    partial class ShiftForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_shift = new System.Windows.Forms.Panel();
            this.lpk4 = new System.Windows.Forms.Label();
            this.lpk3 = new System.Windows.Forms.Label();
            this.lpk2 = new System.Windows.Forms.Label();
            this.lpk1 = new System.Windows.Forms.Label();
            this.lblShiftPk = new System.Windows.Forms.Label();
            this.dtp_toTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_FromTime = new System.Windows.Forms.DateTimePicker();
            this.cmb_NoofBreak = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txt_duration4 = new System.Windows.Forms.TextBox();
            this.txt_duration3 = new System.Windows.Forms.TextBox();
            this.txt_duration2 = new System.Windows.Forms.TextBox();
            this.txt_duration1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_BreakName4 = new System.Windows.Forms.TextBox();
            this.txt_breakName3 = new System.Windows.Forms.TextBox();
            this.txt_Breakname2 = new System.Windows.Forms.TextBox();
            this.txt_BreakName1 = new System.Windows.Forms.TextBox();
            this.txt_ShiftName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbltstatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbl_leave = new System.Windows.Forms.DataGridView();
            this.pnl_shift.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leave)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(210, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Duration : ";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Break Name : ";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Name : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(91, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "From :";
            // 
            // pnl_shift
            // 
            this.pnl_shift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_shift.BackColor = System.Drawing.Color.LightBlue;
            this.pnl_shift.Controls.Add(this.lpk4);
            this.pnl_shift.Controls.Add(this.lpk3);
            this.pnl_shift.Controls.Add(this.lpk2);
            this.pnl_shift.Controls.Add(this.lpk1);
            this.pnl_shift.Controls.Add(this.lblShiftPk);
            this.pnl_shift.Controls.Add(this.dtp_toTime);
            this.pnl_shift.Controls.Add(this.dtp_FromTime);
            this.pnl_shift.Controls.Add(this.cmb_NoofBreak);
            this.pnl_shift.Controls.Add(this.label1);
            this.pnl_shift.Controls.Add(this.linkLabel1);
            this.pnl_shift.Controls.Add(this.txt_duration4);
            this.pnl_shift.Controls.Add(this.txt_duration3);
            this.pnl_shift.Controls.Add(this.txt_duration2);
            this.pnl_shift.Controls.Add(this.txt_duration1);
            this.pnl_shift.Controls.Add(this.label20);
            this.pnl_shift.Controls.Add(this.label19);
            this.pnl_shift.Controls.Add(this.label18);
            this.pnl_shift.Controls.Add(this.label15);
            this.pnl_shift.Controls.Add(this.txt_BreakName4);
            this.pnl_shift.Controls.Add(this.txt_breakName3);
            this.pnl_shift.Controls.Add(this.txt_Breakname2);
            this.pnl_shift.Controls.Add(this.txt_BreakName1);
            this.pnl_shift.Controls.Add(this.txt_ShiftName);
            this.pnl_shift.Controls.Add(this.label11);
            this.pnl_shift.Controls.Add(this.label10);
            this.pnl_shift.Controls.Add(this.label9);
            this.pnl_shift.Controls.Add(this.label7);
            this.pnl_shift.Controls.Add(this.label5);
            this.pnl_shift.Controls.Add(this.label6);
            this.pnl_shift.Controls.Add(this.label8);
            this.pnl_shift.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_shift.Location = new System.Drawing.Point(12, 10);
            this.pnl_shift.Name = "pnl_shift";
            this.pnl_shift.Size = new System.Drawing.Size(416, 283);
            this.pnl_shift.TabIndex = 8;
            // 
            // lpk4
            // 
            this.lpk4.AutoSize = true;
            this.lpk4.Location = new System.Drawing.Point(383, 255);
            this.lpk4.Name = "lpk4";
            this.lpk4.Size = new System.Drawing.Size(25, 14);
            this.lpk4.TabIndex = 42;
            this.lpk4.Text = "xxx";
            // 
            // lpk3
            // 
            this.lpk3.AutoSize = true;
            this.lpk3.Location = new System.Drawing.Point(383, 220);
            this.lpk3.Name = "lpk3";
            this.lpk3.Size = new System.Drawing.Size(25, 14);
            this.lpk3.TabIndex = 41;
            this.lpk3.Text = "xxx";
            // 
            // lpk2
            // 
            this.lpk2.AutoSize = true;
            this.lpk2.Location = new System.Drawing.Point(384, 183);
            this.lpk2.Name = "lpk2";
            this.lpk2.Size = new System.Drawing.Size(25, 14);
            this.lpk2.TabIndex = 40;
            this.lpk2.Text = "xxx";
            // 
            // lpk1
            // 
            this.lpk1.AutoSize = true;
            this.lpk1.Location = new System.Drawing.Point(384, 150);
            this.lpk1.Name = "lpk1";
            this.lpk1.Size = new System.Drawing.Size(25, 14);
            this.lpk1.TabIndex = 39;
            this.lpk1.Text = "xxx";
            // 
            // lblShiftPk
            // 
            this.lblShiftPk.AutoSize = true;
            this.lblShiftPk.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftPk.Location = new System.Drawing.Point(349, 32);
            this.lblShiftPk.Name = "lblShiftPk";
            this.lblShiftPk.Size = new System.Drawing.Size(40, 15);
            this.lblShiftPk.TabIndex = 38;
            this.lblShiftPk.Text = "label2";
            // 
            // dtp_toTime
            // 
            this.dtp_toTime.CustomFormat = "";
            this.dtp_toTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_toTime.Location = new System.Drawing.Point(154, 77);
            this.dtp_toTime.Name = "dtp_toTime";
            this.dtp_toTime.ShowUpDown = true;
            this.dtp_toTime.Size = new System.Drawing.Size(122, 20);
            this.dtp_toTime.TabIndex = 3;
            this.dtp_toTime.ValueChanged += new System.EventHandler(this.dtp_toTime_ValueChanged);
            // 
            // dtp_FromTime
            // 
            this.dtp_FromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_FromTime.Location = new System.Drawing.Point(154, 50);
            this.dtp_FromTime.Name = "dtp_FromTime";
            this.dtp_FromTime.ShowUpDown = true;
            this.dtp_FromTime.Size = new System.Drawing.Size(122, 20);
            this.dtp_FromTime.TabIndex = 2;
            // 
            // cmb_NoofBreak
            // 
            this.cmb_NoofBreak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NoofBreak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_NoofBreak.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_NoofBreak.FormattingEnabled = true;
            this.cmb_NoofBreak.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmb_NoofBreak.Location = new System.Drawing.Point(154, 111);
            this.cmb_NoofBreak.Name = "cmb_NoofBreak";
            this.cmb_NoofBreak.Size = new System.Drawing.Size(122, 22);
            this.cmb_NoofBreak.TabIndex = 4;
            this.cmb_NoofBreak.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "No of Breaks Allowed :";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 14);
            this.linkLabel1.TabIndex = 32;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "New Shift";
            // 
            // txt_duration4
            // 
            this.txt_duration4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_duration4.Location = new System.Drawing.Point(275, 251);
            this.txt_duration4.Name = "txt_duration4";
            this.txt_duration4.Size = new System.Drawing.Size(100, 20);
            this.txt_duration4.TabIndex = 12;
            this.txt_duration4.Visible = false;
            this.txt_duration4.TextChanged += new System.EventHandler(this.txt_duration4_TextChanged);
            // 
            // txt_duration3
            // 
            this.txt_duration3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_duration3.Location = new System.Drawing.Point(274, 216);
            this.txt_duration3.Name = "txt_duration3";
            this.txt_duration3.Size = new System.Drawing.Size(100, 20);
            this.txt_duration3.TabIndex = 10;
            this.txt_duration3.Visible = false;
            this.txt_duration3.TextChanged += new System.EventHandler(this.txt_duration3_TextChanged);
            // 
            // txt_duration2
            // 
            this.txt_duration2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_duration2.Location = new System.Drawing.Point(274, 182);
            this.txt_duration2.Name = "txt_duration2";
            this.txt_duration2.Size = new System.Drawing.Size(100, 20);
            this.txt_duration2.TabIndex = 8;
            this.txt_duration2.Visible = false;
            this.txt_duration2.TextChanged += new System.EventHandler(this.txt_duration2_TextChanged);
            // 
            // txt_duration1
            // 
            this.txt_duration1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_duration1.Location = new System.Drawing.Point(274, 151);
            this.txt_duration1.Name = "txt_duration1";
            this.txt_duration1.Size = new System.Drawing.Size(100, 20);
            this.txt_duration1.TabIndex = 6;
            this.txt_duration1.Visible = false;
            this.txt_duration1.TextChanged += new System.EventHandler(this.txt_duration1_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(211, 250);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 15);
            this.label20.TabIndex = 24;
            this.label20.Text = "Duration : ";
            this.label20.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(210, 218);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 15);
            this.label19.TabIndex = 23;
            this.label19.Text = "Duration : ";
            this.label19.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(211, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 15);
            this.label18.TabIndex = 22;
            this.label18.Text = "Duration : ";
            this.label18.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(106, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 15);
            this.label15.TabIndex = 19;
            this.label15.Text = "To : ";
            // 
            // txt_BreakName4
            // 
            this.txt_BreakName4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BreakName4.Location = new System.Drawing.Point(98, 251);
            this.txt_BreakName4.Name = "txt_BreakName4";
            this.txt_BreakName4.Size = new System.Drawing.Size(100, 20);
            this.txt_BreakName4.TabIndex = 11;
            this.txt_BreakName4.Visible = false;
            // 
            // txt_breakName3
            // 
            this.txt_breakName3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_breakName3.Location = new System.Drawing.Point(97, 217);
            this.txt_breakName3.Name = "txt_breakName3";
            this.txt_breakName3.Size = new System.Drawing.Size(100, 20);
            this.txt_breakName3.TabIndex = 9;
            this.txt_breakName3.Visible = false;
            // 
            // txt_Breakname2
            // 
            this.txt_Breakname2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Breakname2.Location = new System.Drawing.Point(98, 183);
            this.txt_Breakname2.Name = "txt_Breakname2";
            this.txt_Breakname2.Size = new System.Drawing.Size(100, 20);
            this.txt_Breakname2.TabIndex = 7;
            this.txt_Breakname2.Visible = false;
            // 
            // txt_BreakName1
            // 
            this.txt_BreakName1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BreakName1.Location = new System.Drawing.Point(98, 151);
            this.txt_BreakName1.Name = "txt_BreakName1";
            this.txt_BreakName1.Size = new System.Drawing.Size(100, 20);
            this.txt_BreakName1.TabIndex = 5;
            this.txt_BreakName1.Visible = false;
            // 
            // txt_ShiftName
            // 
            this.txt_ShiftName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ShiftName.Location = new System.Drawing.Point(154, 18);
            this.txt_ShiftName.Name = "txt_ShiftName";
            this.txt_ShiftName.Size = new System.Drawing.Size(122, 20);
            this.txt_ShiftName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Break Name : ";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Break Name : ";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Break Name : ";
            this.label9.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(349, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(268, 306);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbltstatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 465);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(923, 57);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lbltstatus
            // 
            this.lbltstatus.AutoSize = true;
            this.lbltstatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltstatus.Location = new System.Drawing.Point(346, 30);
            this.lbltstatus.Name = "lbltstatus";
            this.lbltstatus.Size = new System.Drawing.Size(137, 13);
            this.lbltstatus.TabIndex = 2;
            this.lbltstatus.Text = "Message will be Shown here";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbl_leave);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(440, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(479, 289);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Shifts";
            // 
            // tbl_leave
            // 
            this.tbl_leave.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_leave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_leave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_leave.Location = new System.Drawing.Point(3, 16);
            this.tbl_leave.Name = "tbl_leave";
            this.tbl_leave.ReadOnly = true;
            this.tbl_leave.RowHeadersVisible = false;
            this.tbl_leave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_leave.Size = new System.Drawing.Size(473, 270);
            this.tbl_leave.TabIndex = 15;
            this.tbl_leave.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_leave_CellDoubleClick);
            // 
            // ShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(923, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnl_shift);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ShiftForm";
            this.Text = "Shift";
            this.pnl_shift.ResumeLayout(false);
            this.pnl_shift.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnl_shift;
        private System.Windows.Forms.TextBox txt_duration4;
        private System.Windows.Forms.TextBox txt_duration3;
        private System.Windows.Forms.TextBox txt_duration2;
        private System.Windows.Forms.TextBox txt_duration1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_BreakName4;
        private System.Windows.Forms.TextBox txt_breakName3;
        private System.Windows.Forms.TextBox txt_Breakname2;
        private System.Windows.Forms.TextBox txt_BreakName1;
        private System.Windows.Forms.TextBox txt_ShiftName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cmb_NoofBreak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_FromTime;
        private System.Windows.Forms.DateTimePicker dtp_toTime;
        private System.Windows.Forms.Label lbltstatus;
        private System.Windows.Forms.DataGridView tbl_leave;
        private System.Windows.Forms.Label lpk4;
        private System.Windows.Forms.Label lpk3;
        private System.Windows.Forms.Label lpk2;
        private System.Windows.Forms.Label lpk1;
        private System.Windows.Forms.Label lblShiftPk;
    }
}
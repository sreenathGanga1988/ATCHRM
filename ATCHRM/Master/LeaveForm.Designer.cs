namespace ATCHRM.Master
{
    partial class LeaveForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grp_leave = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbt_notcarryforwardable = new System.Windows.Forms.RadioButton();
            this.rbt_iscarryforwardable = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmb_consider = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_calculateUpto = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_leaveCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_allowedLeave = new System.Windows.Forms.TextBox();
            this.lbl_leavepk = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbt_notforwomen = new System.Windows.Forms.RadioButton();
            this.rbt_isforwomen = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbt_notformale = new System.Windows.Forms.RadioButton();
            this.rbt_isformale = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbt_notEnhasable = new System.Windows.Forms.RadioButton();
            this.rbt_isenchasable = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_Enhasement = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_enhasableDays = new System.Windows.Forms.TextBox();
            this.cmb_calculationtype = new System.Windows.Forms.ComboBox();
            this.rht_description = new System.Windows.Forms.RichTextBox();
            this.txt_leavename = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbl_leavedata = new System.Windows.Forms.DataGridView();
            this.grp_leave.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Enhasement.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leavedata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leave Name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Leave Calculation :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Description : ";
            // 
            // grp_leave
            // 
            this.grp_leave.Controls.Add(this.panel5);
            this.grp_leave.Controls.Add(this.panel4);
            this.grp_leave.Controls.Add(this.txt_leaveCode);
            this.grp_leave.Controls.Add(this.label9);
            this.grp_leave.Controls.Add(this.label5);
            this.grp_leave.Controls.Add(this.txt_allowedLeave);
            this.grp_leave.Controls.Add(this.lbl_leavepk);
            this.grp_leave.Controls.Add(this.panel3);
            this.grp_leave.Controls.Add(this.panel2);
            this.grp_leave.Controls.Add(this.panel1);
            this.grp_leave.Controls.Add(this.pnl_Enhasement);
            this.grp_leave.Controls.Add(this.cmb_calculationtype);
            this.grp_leave.Controls.Add(this.rht_description);
            this.grp_leave.Controls.Add(this.txt_leavename);
            this.grp_leave.Controls.Add(this.label1);
            this.grp_leave.Controls.Add(this.label6);
            this.grp_leave.Controls.Add(this.label2);
            this.grp_leave.Location = new System.Drawing.Point(12, 3);
            this.grp_leave.Name = "grp_leave";
            this.grp_leave.Size = new System.Drawing.Size(276, 515);
            this.grp_leave.TabIndex = 6;
            this.grp_leave.TabStop = false;
            this.grp_leave.Text = "New Leave";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbt_notcarryforwardable);
            this.panel5.Controls.Add(this.rbt_iscarryforwardable);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Location = new System.Drawing.Point(18, 404);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 37);
            this.panel5.TabIndex = 21;
            // 
            // rbt_notcarryforwardable
            // 
            this.rbt_notcarryforwardable.AutoSize = true;
            this.rbt_notcarryforwardable.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_notcarryforwardable.Location = new System.Drawing.Point(185, 8);
            this.rbt_notcarryforwardable.Name = "rbt_notcarryforwardable";
            this.rbt_notcarryforwardable.Size = new System.Drawing.Size(41, 19);
            this.rbt_notcarryforwardable.TabIndex = 15;
            this.rbt_notcarryforwardable.TabStop = true;
            this.rbt_notcarryforwardable.Text = "No";
            this.rbt_notcarryforwardable.UseVisualStyleBackColor = true;
            // 
            // rbt_iscarryforwardable
            // 
            this.rbt_iscarryforwardable.AutoSize = true;
            this.rbt_iscarryforwardable.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_iscarryforwardable.Location = new System.Drawing.Point(138, 8);
            this.rbt_iscarryforwardable.Name = "rbt_iscarryforwardable";
            this.rbt_iscarryforwardable.Size = new System.Drawing.Size(43, 19);
            this.rbt_iscarryforwardable.TabIndex = 14;
            this.rbt_iscarryforwardable.TabStop = true;
            this.rbt_iscarryforwardable.Text = "yes";
            this.rbt_iscarryforwardable.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Will Carry Forward";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cmb_consider);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.cmb_calculateUpto);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(6, 185);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 76);
            this.panel4.TabIndex = 20;
            // 
            // cmb_consider
            // 
            this.cmb_consider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_consider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_consider.FormattingEnabled = true;
            this.cmb_consider.Items.AddRange(new object[] {
            "Holiday And Offday",
            "Holidays",
            "Off Days",
            "NA"});
            this.cmb_consider.Location = new System.Drawing.Point(114, 40);
            this.cmb_consider.Name = "cmb_consider";
            this.cmb_consider.Size = new System.Drawing.Size(126, 22);
            this.cmb_consider.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Consider Also :";
            // 
            // cmb_calculateUpto
            // 
            this.cmb_calculateUpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_calculateUpto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_calculateUpto.FormattingEnabled = true;
            this.cmb_calculateUpto.Items.AddRange(new object[] {
            "Last  Month",
            "End of Contract",
            "Upto Date"});
            this.cmb_calculateUpto.Location = new System.Drawing.Point(115, 10);
            this.cmb_calculateUpto.Name = "cmb_calculateUpto";
            this.cmb_calculateUpto.Size = new System.Drawing.Size(126, 22);
            this.cmb_calculateUpto.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Calculation Upto :";
            // 
            // txt_leaveCode
            // 
            this.txt_leaveCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_leaveCode.Location = new System.Drawing.Point(125, 46);
            this.txt_leaveCode.MaxLength = 3;
            this.txt_leaveCode.Name = "txt_leaveCode";
            this.txt_leaveCode.Size = new System.Drawing.Size(129, 20);
            this.txt_leaveCode.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Leave Code  : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Leave Allowed :";
            // 
            // txt_allowedLeave
            // 
            this.txt_allowedLeave.Location = new System.Drawing.Point(121, 159);
            this.txt_allowedLeave.Name = "txt_allowedLeave";
            this.txt_allowedLeave.Size = new System.Drawing.Size(129, 20);
            this.txt_allowedLeave.TabIndex = 5;
            this.txt_allowedLeave.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txt_allowedLeave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_allowedLeave_KeyPress);
            // 
            // lbl_leavepk
            // 
            this.lbl_leavepk.AutoSize = true;
            this.lbl_leavepk.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_leavepk.Location = new System.Drawing.Point(50, 139);
            this.lbl_leavepk.Name = "lbl_leavepk";
            this.lbl_leavepk.Size = new System.Drawing.Size(68, 15);
            this.lbl_leavepk.TabIndex = 16;
            this.lbl_leavepk.Text = "lbl_leavepk";
            this.lbl_leavepk.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbt_notforwomen);
            this.panel3.Controls.Add(this.rbt_isforwomen);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(18, 358);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 37);
            this.panel3.TabIndex = 11;
            // 
            // rbt_notforwomen
            // 
            this.rbt_notforwomen.AutoSize = true;
            this.rbt_notforwomen.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_notforwomen.Location = new System.Drawing.Point(185, 8);
            this.rbt_notforwomen.Name = "rbt_notforwomen";
            this.rbt_notforwomen.Size = new System.Drawing.Size(41, 19);
            this.rbt_notforwomen.TabIndex = 13;
            this.rbt_notforwomen.TabStop = true;
            this.rbt_notforwomen.Text = "No";
            this.rbt_notforwomen.UseVisualStyleBackColor = true;
            // 
            // rbt_isforwomen
            // 
            this.rbt_isforwomen.AutoSize = true;
            this.rbt_isforwomen.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_isforwomen.Location = new System.Drawing.Point(138, 8);
            this.rbt_isforwomen.Name = "rbt_isforwomen";
            this.rbt_isforwomen.Size = new System.Drawing.Size(43, 19);
            this.rbt_isforwomen.TabIndex = 12;
            this.rbt_isforwomen.TabStop = true;
            this.rbt_isforwomen.Text = "yes";
            this.rbt_isforwomen.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Eligible For Females";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbt_notformale);
            this.panel2.Controls.Add(this.rbt_isformale);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(19, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 37);
            this.panel2.TabIndex = 10;
            // 
            // rbt_notformale
            // 
            this.rbt_notformale.AutoSize = true;
            this.rbt_notformale.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_notformale.Location = new System.Drawing.Point(185, 10);
            this.rbt_notformale.Name = "rbt_notformale";
            this.rbt_notformale.Size = new System.Drawing.Size(41, 19);
            this.rbt_notformale.TabIndex = 11;
            this.rbt_notformale.TabStop = true;
            this.rbt_notformale.Text = "No";
            this.rbt_notformale.UseVisualStyleBackColor = true;
            // 
            // rbt_isformale
            // 
            this.rbt_isformale.AutoSize = true;
            this.rbt_isformale.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_isformale.Location = new System.Drawing.Point(138, 8);
            this.rbt_isformale.Name = "rbt_isformale";
            this.rbt_isformale.Size = new System.Drawing.Size(43, 19);
            this.rbt_isformale.TabIndex = 10;
            this.rbt_isformale.TabStop = true;
            this.rbt_isformale.Text = "yes";
            this.rbt_isformale.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Eligible For Males";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbt_notEnhasable);
            this.panel1.Controls.Add(this.rbt_isenchasable);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(21, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 37);
            this.panel1.TabIndex = 4;
            // 
            // rbt_notEnhasable
            // 
            this.rbt_notEnhasable.AutoSize = true;
            this.rbt_notEnhasable.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_notEnhasable.Location = new System.Drawing.Point(185, 12);
            this.rbt_notEnhasable.Name = "rbt_notEnhasable";
            this.rbt_notEnhasable.Size = new System.Drawing.Size(41, 19);
            this.rbt_notEnhasable.TabIndex = 9;
            this.rbt_notEnhasable.TabStop = true;
            this.rbt_notEnhasable.Text = "No";
            this.rbt_notEnhasable.UseVisualStyleBackColor = true;
            // 
            // rbt_isenchasable
            // 
            this.rbt_isenchasable.AutoSize = true;
            this.rbt_isenchasable.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_isenchasable.Location = new System.Drawing.Point(138, 12);
            this.rbt_isenchasable.Name = "rbt_isenchasable";
            this.rbt_isenchasable.Size = new System.Drawing.Size(43, 19);
            this.rbt_isenchasable.TabIndex = 8;
            this.rbt_isenchasable.TabStop = true;
            this.rbt_isenchasable.Text = "yes";
            this.rbt_isenchasable.UseVisualStyleBackColor = true;
            this.rbt_isenchasable.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Is The Leave Encashable";
            // 
            // pnl_Enhasement
            // 
            this.pnl_Enhasement.BackColor = System.Drawing.Color.LightBlue;
            this.pnl_Enhasement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Enhasement.Controls.Add(this.label4);
            this.pnl_Enhasement.Controls.Add(this.txt_enhasableDays);
            this.pnl_Enhasement.Location = new System.Drawing.Point(18, 453);
            this.pnl_Enhasement.Name = "pnl_Enhasement";
            this.pnl_Enhasement.Size = new System.Drawing.Size(240, 49);
            this.pnl_Enhasement.TabIndex = 15;
            this.pnl_Enhasement.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "No of Enchasable Days :";
            // 
            // txt_enhasableDays
            // 
            this.txt_enhasableDays.Location = new System.Drawing.Point(137, 8);
            this.txt_enhasableDays.Name = "txt_enhasableDays";
            this.txt_enhasableDays.Size = new System.Drawing.Size(98, 20);
            this.txt_enhasableDays.TabIndex = 16;
            this.txt_enhasableDays.TextChanged += new System.EventHandler(this.txt_enhasableDays_TextChanged);
            this.txt_enhasableDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_enhasableDays_KeyPress);
            // 
            // cmb_calculationtype
            // 
            this.cmb_calculationtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_calculationtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_calculationtype.FormattingEnabled = true;
            this.cmb_calculationtype.Items.AddRange(new object[] {
            "Days Per Month",
            "Days Per Year",
            "Months Per year",
            "1/2 Days Per Year",
            "Not Applicable",
            "1/2 Days Per Month"});
            this.cmb_calculationtype.Location = new System.Drawing.Point(123, 124);
            this.cmb_calculationtype.Name = "cmb_calculationtype";
            this.cmb_calculationtype.Size = new System.Drawing.Size(129, 22);
            this.cmb_calculationtype.TabIndex = 4;
            // 
            // rht_description
            // 
            this.rht_description.Location = new System.Drawing.Point(125, 78);
            this.rht_description.Name = "rht_description";
            this.rht_description.Size = new System.Drawing.Size(129, 32);
            this.rht_description.TabIndex = 3;
            this.rht_description.Text = "";
            // 
            // txt_leavename
            // 
            this.txt_leavename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_leavename.Location = new System.Drawing.Point(125, 16);
            this.txt_leavename.Name = "txt_leavename";
            this.txt_leavename.Size = new System.Drawing.Size(129, 20);
            this.txt_leavename.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 547);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(841, 53);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(241, 28);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(136, 523);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(214, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbl_leavedata);
            this.groupBox3.Location = new System.Drawing.Point(294, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(545, 546);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Leaves";
            // 
            // tbl_leavedata
            // 
            this.tbl_leavedata.AllowUserToAddRows = false;
            this.tbl_leavedata.AllowUserToDeleteRows = false;
            this.tbl_leavedata.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tbl_leavedata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_leavedata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_leavedata.Location = new System.Drawing.Point(3, 16);
            this.tbl_leavedata.Name = "tbl_leavedata";
            this.tbl_leavedata.ReadOnly = true;
            this.tbl_leavedata.RowHeadersVisible = false;
            this.tbl_leavedata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_leavedata.Size = new System.Drawing.Size(539, 527);
            this.tbl_leavedata.TabIndex = 0;
            this.tbl_leavedata.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_leavedata_CellDoubleClick);
            // 
            // LeaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(841, 600);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp_leave);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "LeaveForm";
            this.Text = "Leave";
            this.grp_leave.ResumeLayout(false);
            this.grp_leave.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Enhasement.ResumeLayout(false);
            this.pnl_Enhasement.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leavedata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grp_leave;
        private System.Windows.Forms.ComboBox cmb_calculationtype;
        private System.Windows.Forms.RichTextBox rht_description;
        private System.Windows.Forms.TextBox txt_leavename;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_Enhasement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_enhasableDays;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbt_notforwomen;
        private System.Windows.Forms.RadioButton rbt_isforwomen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbt_notformale;
        private System.Windows.Forms.RadioButton rbt_isformale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbt_notEnhasable;
        private System.Windows.Forms.RadioButton rbt_isenchasable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView tbl_leavedata;
        private System.Windows.Forms.Label lbl_leavepk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_allowedLeave;
        private System.Windows.Forms.TextBox txt_leaveCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cmb_calculateUpto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbt_notcarryforwardable;
        private System.Windows.Forms.RadioButton rbt_iscarryforwardable;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_consider;
        private System.Windows.Forms.Label label12;
    }
}
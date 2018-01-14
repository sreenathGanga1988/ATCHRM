namespace ATCHRM.Reports
{
    partial class LeaveMasterOfEmployee
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
            this.Grp_searchCriteria = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_empcode = new System.Windows.Forms.Label();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.cmb_designation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_EmpCode = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbl_Employeedata = new ATCHRM.MergeDatagridview();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_leave = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.lbl_joiningdate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_noofdays = new System.Windows.Forms.TextBox();
            this.Grp_searchCriteria.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Employeedata)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grp_searchCriteria
            // 
            this.Grp_searchCriteria.Controls.Add(this.groupBox1);
            this.Grp_searchCriteria.Controls.Add(this.button1);
            this.Grp_searchCriteria.Controls.Add(this.lbl_empcode);
            this.Grp_searchCriteria.Controls.Add(this.cmb_location);
            this.Grp_searchCriteria.Controls.Add(this.cmb_dept);
            this.Grp_searchCriteria.Controls.Add(this.cmb_designation);
            this.Grp_searchCriteria.Controls.Add(this.label5);
            this.Grp_searchCriteria.Controls.Add(this.label4);
            this.Grp_searchCriteria.Controls.Add(this.label6);
            this.Grp_searchCriteria.Controls.Add(this.label1);
            this.Grp_searchCriteria.Controls.Add(this.cmb_EmpCode);
            this.Grp_searchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grp_searchCriteria.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_searchCriteria.Location = new System.Drawing.Point(0, 0);
            this.Grp_searchCriteria.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grp_searchCriteria.Name = "Grp_searchCriteria";
            this.Grp_searchCriteria.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grp_searchCriteria.Size = new System.Drawing.Size(1126, 116);
            this.Grp_searchCriteria.TabIndex = 3;
            this.Grp_searchCriteria.TabStop = false;
            this.Grp_searchCriteria.Text = "Employee Details :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 37);
            this.button1.TabIndex = 45;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_empcode
            // 
            this.lbl_empcode.AutoSize = true;
            this.lbl_empcode.ForeColor = System.Drawing.Color.Red;
            this.lbl_empcode.Location = new System.Drawing.Point(576, 73);
            this.lbl_empcode.Name = "lbl_empcode";
            this.lbl_empcode.Size = new System.Drawing.Size(13, 15);
            this.lbl_empcode.TabIndex = 36;
            this.lbl_empcode.Text = "*";
            this.lbl_empcode.Visible = false;
            // 
            // cmb_location
            // 
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Location = new System.Drawing.Point(67, 24);
            this.cmb_location.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(239, 23);
            this.cmb_location.TabIndex = 1;
            this.cmb_location.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_location_MouseClick);
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(372, 24);
            this.cmb_dept.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(204, 23);
            this.cmb_dept.TabIndex = 2;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            this.cmb_dept.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_dept_MouseClick);
            // 
            // cmb_designation
            // 
            this.cmb_designation.FormattingEnabled = true;
            this.cmb_designation.Location = new System.Drawing.Point(97, 70);
            this.cmb_designation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_designation.Name = "cmb_designation";
            this.cmb_designation.Size = new System.Drawing.Size(209, 23);
            this.cmb_designation.TabIndex = 3;
            this.cmb_designation.SelectedIndexChanged += new System.EventHandler(this.cmb_designation_SelectedIndexChanged);
            this.cmb_designation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_designation_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Designation  : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dept  : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Location : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(314, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Emp Code :";
            // 
            // cmb_EmpCode
            // 
            this.cmb_EmpCode.FormattingEnabled = true;
            this.cmb_EmpCode.Items.AddRange(new object[] {
            "All"});
            this.cmb_EmpCode.Location = new System.Drawing.Point(386, 68);
            this.cmb_EmpCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_EmpCode.Name = "cmb_EmpCode";
            this.cmb_EmpCode.Size = new System.Drawing.Size(183, 23);
            this.cmb_EmpCode.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 376);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(1126, 65);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(175, 25);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // tbl_Employeedata
            // 
            this.tbl_Employeedata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_Employeedata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Employeedata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_Employeedata.Location = new System.Drawing.Point(0, 116);
            this.tbl_Employeedata.Name = "tbl_Employeedata";
            this.tbl_Employeedata.Size = new System.Drawing.Size(1126, 260);
            this.tbl_Employeedata.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_noofdays);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbl_joiningdate);
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_leave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(710, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 88);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Leave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Leave : ";
            // 
            // cmb_leave
            // 
            this.cmb_leave.FormattingEnabled = true;
            this.cmb_leave.Location = new System.Drawing.Point(58, 16);
            this.cmb_leave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_leave.Name = "cmb_leave";
            this.cmb_leave.Size = new System.Drawing.Size(133, 23);
            this.cmb_leave.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "From : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "To : ";
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(58, 45);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(142, 23);
            this.dtp_from.TabIndex = 16;
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(256, 45);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(118, 23);
            this.dtp_to.TabIndex = 17;
            // 
            // lbl_joiningdate
            // 
            this.lbl_joiningdate.AutoSize = true;
            this.lbl_joiningdate.Location = new System.Drawing.Point(93, 71);
            this.lbl_joiningdate.Name = "lbl_joiningdate";
            this.lbl_joiningdate.Size = new System.Drawing.Size(14, 15);
            this.lbl_joiningdate.TabIndex = 18;
            this.lbl_joiningdate.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Joining : ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_noofdays
            // 
            this.txt_noofdays.Location = new System.Drawing.Point(220, 17);
            this.txt_noofdays.Name = "txt_noofdays";
            this.txt_noofdays.Size = new System.Drawing.Size(42, 23);
            this.txt_noofdays.TabIndex = 21;
            // 
            // LeaveMasterOfEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 441);
            this.Controls.Add(this.tbl_Employeedata);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Grp_searchCriteria);
            this.Name = "LeaveMasterOfEmployee";
            this.Text = "LeaveMasterOfEmployee";
            this.Load += new System.EventHandler(this.LeaveMasterOfEmployee_Load);
            this.Grp_searchCriteria.ResumeLayout(false);
            this.Grp_searchCriteria.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Employeedata)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grp_searchCriteria;
        private System.Windows.Forms.Label lbl_empcode;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.ComboBox cmb_designation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_EmpCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button1;
        private MergeDatagridview tbl_Employeedata;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_leave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_joiningdate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_noofdays;
    }
}
namespace ATCHRM.Applications
{
    partial class RecruitmentApplicationForm
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
            if (disposing && (this.components != null))
            {
               this. components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecruitmentApplicationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmp_dept = new System.Windows.Forms.ComboBox();
            this.cmb_designation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Company = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Location = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rht_descriptiom = new System.Windows.Forms.RichTextBox();
            this.dtp_joiningDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_interviewedPerson = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbt_isinterviewed = new System.Windows.Forms.RadioButton();
            this.rbt_notinterviewed = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_Contract = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_vaccancyNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_cancell = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_submitt = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmp_dept);
            this.groupBox1.Controls.Add(this.cmb_designation);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_Company);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_Location);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(817, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "For";
            // 
            // cmp_dept
            // 
            this.cmp_dept.FormattingEnabled = true;
            this.cmp_dept.Location = new System.Drawing.Point(646, 17);
            this.cmp_dept.Name = "cmp_dept";
            this.cmp_dept.Size = new System.Drawing.Size(156, 22);
            this.cmp_dept.TabIndex = 3;
            this.cmp_dept.SelectedIndexChanged += new System.EventHandler(this.cmp_dept_SelectedIndexChanged);
            // 
            // cmb_designation
            // 
            this.cmb_designation.FormattingEnabled = true;
            this.cmb_designation.Location = new System.Drawing.Point(100, 52);
            this.cmb_designation.Name = "cmb_designation";
            this.cmb_designation.Size = new System.Drawing.Size(280, 22);
            this.cmb_designation.TabIndex = 4;
            this.cmb_designation.SelectedIndexChanged += new System.EventHandler(this.cmb_designation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Designation  : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(589, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dept  : ";
            // 
            // cmb_Company
            // 
            this.cmb_Company.FormattingEnabled = true;
            this.cmb_Company.Location = new System.Drawing.Point(79, 17);
            this.cmb_Company.Name = "cmb_Company";
            this.cmb_Company.Size = new System.Drawing.Size(145, 22);
            this.cmb_Company.TabIndex = 1;
            this.cmb_Company.SelectedIndexChanged += new System.EventHandler(this.cmb_Company_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Company :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Location : ";
            // 
            // cmb_Location
            // 
            this.cmb_Location.FormattingEnabled = true;
            this.cmb_Location.Location = new System.Drawing.Point(295, 17);
            this.cmb_Location.Name = "cmb_Location";
            this.cmb_Location.Size = new System.Drawing.Size(288, 22);
            this.cmb_Location.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rht_descriptiom);
            this.panel1.Controls.Add(this.dtp_joiningDate);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txt_interviewedPerson);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.rbt_isinterviewed);
            this.panel1.Controls.Add(this.rbt_notinterviewed);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmb_Contract);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_vaccancyNum);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(3, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 58);
            this.panel1.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(372, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Expected Date Of Joining :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "NA";
            this.label2.Visible = false;
            // 
            // rht_descriptiom
            // 
            this.rht_descriptiom.Location = new System.Drawing.Point(47, 121);
            this.rht_descriptiom.Name = "rht_descriptiom";
            this.rht_descriptiom.Size = new System.Drawing.Size(184, 26);
            this.rht_descriptiom.TabIndex = 11;
            this.rht_descriptiom.Text = "NA";
            this.rht_descriptiom.Visible = false;
            // 
            // dtp_joiningDate
            // 
            this.dtp_joiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_joiningDate.Location = new System.Drawing.Point(528, 17);
            this.dtp_joiningDate.Name = "dtp_joiningDate";
            this.dtp_joiningDate.Size = new System.Drawing.Size(95, 20);
            this.dtp_joiningDate.TabIndex = 7;
            this.dtp_joiningDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(83, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 14);
            this.label10.TabIndex = 9;
            this.label10.Text = "NA";
            this.label10.Visible = false;
            // 
            // txt_interviewedPerson
            // 
            this.txt_interviewedPerson.Location = new System.Drawing.Point(47, 90);
            this.txt_interviewedPerson.Name = "txt_interviewedPerson";
            this.txt_interviewedPerson.Size = new System.Drawing.Size(223, 20);
            this.txt_interviewedPerson.TabIndex = 8;
            this.txt_interviewedPerson.Text = "NA";
            this.txt_interviewedPerson.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "NA";
            this.label9.Visible = false;
            // 
            // rbt_isinterviewed
            // 
            this.rbt_isinterviewed.AutoSize = true;
            this.rbt_isinterviewed.Location = new System.Drawing.Point(119, 96);
            this.rbt_isinterviewed.Name = "rbt_isinterviewed";
            this.rbt_isinterviewed.Size = new System.Drawing.Size(43, 18);
            this.rbt_isinterviewed.TabIndex = 6;
            this.rbt_isinterviewed.Text = "yes";
            this.rbt_isinterviewed.UseVisualStyleBackColor = true;
            this.rbt_isinterviewed.Visible = false;
            // 
            // rbt_notinterviewed
            // 
            this.rbt_notinterviewed.AutoSize = true;
            this.rbt_notinterviewed.Checked = true;
            this.rbt_notinterviewed.Location = new System.Drawing.Point(168, 96);
            this.rbt_notinterviewed.Name = "rbt_notinterviewed";
            this.rbt_notinterviewed.Size = new System.Drawing.Size(38, 18);
            this.rbt_notinterviewed.TabIndex = 5;
            this.rbt_notinterviewed.TabStop = true;
            this.rbt_notinterviewed.Text = "No";
            this.rbt_notinterviewed.UseVisualStyleBackColor = true;
            this.rbt_notinterviewed.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(227, 14);
            this.label8.TabIndex = 4;
            this.label8.Text = "Has the Candidate been tested/interviewed  : ";
            this.label8.Visible = false;
            // 
            // cmb_Contract
            // 
            this.cmb_Contract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Contract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Contract.FormattingEnabled = true;
            this.cmb_Contract.Items.AddRange(new object[] {
            "Permanent",
            "Contractual",
            "Casual",
            "Temporary"});
            this.cmb_Contract.Location = new System.Drawing.Point(273, 18);
            this.cmb_Contract.Name = "cmb_Contract";
            this.cmb_Contract.Size = new System.Drawing.Size(90, 22);
            this.cmb_Contract.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(166, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Type of Contract : ";
            // 
            // txt_vaccancyNum
            // 
            this.txt_vaccancyNum.Location = new System.Drawing.Point(92, 18);
            this.txt_vaccancyNum.Name = "txt_vaccancyNum";
            this.txt_vaccancyNum.Size = new System.Drawing.Size(76, 20);
            this.txt_vaccancyNum.TabIndex = 5;
            this.txt_vaccancyNum.TextChanged += new System.EventHandler(this.txt_vaccancyNum_TextChanged);
            this.txt_vaccancyNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_vaccancyNum_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "No of Vacancy :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(821, 34);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(251, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 1;
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 163);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 8;
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
            // RecruitmentApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(821, 222);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "RecruitmentApplicationForm";
            this.Text = "Recruitment Request";
            this.Load += new System.EventHandler(this.RecruitmentApplicationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Company;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Location;
        private System.Windows.Forms.ComboBox cmp_dept;
        private System.Windows.Forms.ComboBox cmb_designation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp_joiningDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_interviewedPerson;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbt_isinterviewed;
        private System.Windows.Forms.RadioButton rbt_notinterviewed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_Contract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_vaccancyNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rht_descriptiom;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_cancell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_submitt;
        private System.Windows.Forms.Label label11;
    }
}
namespace ATCHRM.HR.NewFolder1
{
    partial class EmployeeDeactivationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_blacklist = new System.Windows.Forms.CheckBox();
            this.dtp_fromdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.rht_remark = new System.Windows.Forms.RichTextBox();
            this.lbkl = new System.Windows.Forms.Label();
            this.txt_desg = new System.Windows.Forms.TextBox();
            this.rbt_employable = new System.Windows.Forms.RadioButton();
            this.rbtunemployable = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnid = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.cmb_employecode = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkbx_Reasons = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk_blacklist);
            this.groupBox1.Controls.Add(this.dtp_fromdate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rht_remark);
            this.groupBox1.Controls.Add(this.lbkl);
            this.groupBox1.Controls.Add(this.txt_desg);
            this.groupBox1.Controls.Add(this.rbt_employable);
            this.groupBox1.Controls.Add(this.rbtunemployable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtnid);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.cmb_employecode);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 477);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deactivate";
            // 
            // chk_blacklist
            // 
            this.chk_blacklist.AutoSize = true;
            this.chk_blacklist.Location = new System.Drawing.Point(26, 136);
            this.chk_blacklist.Name = "chk_blacklist";
            this.chk_blacklist.Size = new System.Drawing.Size(121, 18);
            this.chk_blacklist.TabIndex = 16;
            this.chk_blacklist.Text = "Black List Employee";
            this.chk_blacklist.UseVisualStyleBackColor = true;
            // 
            // dtp_fromdate
            // 
            this.dtp_fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fromdate.Location = new System.Drawing.Point(108, 98);
            this.dtp_fromdate.Name = "dtp_fromdate";
            this.dtp_fromdate.Size = new System.Drawing.Size(200, 20);
            this.dtp_fromdate.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "From Date  : ";
            // 
            // rht_remark
            // 
            this.rht_remark.Location = new System.Drawing.Point(85, 400);
            this.rht_remark.Name = "rht_remark";
            this.rht_remark.Size = new System.Drawing.Size(383, 63);
            this.rht_remark.TabIndex = 8;
            this.rht_remark.Text = "";
            // 
            // lbkl
            // 
            this.lbkl.AutoSize = true;
            this.lbkl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbkl.Location = new System.Drawing.Point(23, 400);
            this.lbkl.Name = "lbkl";
            this.lbkl.Size = new System.Drawing.Size(61, 15);
            this.lbkl.TabIndex = 13;
            this.lbkl.Text = "Remarks :";
            // 
            // txt_desg
            // 
            this.txt_desg.Location = new System.Drawing.Point(389, 66);
            this.txt_desg.Name = "txt_desg";
            this.txt_desg.Size = new System.Drawing.Size(141, 20);
            this.txt_desg.TabIndex = 4;
            // 
            // rbt_employable
            // 
            this.rbt_employable.AutoSize = true;
            this.rbt_employable.Checked = true;
            this.rbt_employable.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_employable.Location = new System.Drawing.Point(158, 367);
            this.rbt_employable.Name = "rbt_employable";
            this.rbt_employable.Size = new System.Drawing.Size(43, 19);
            this.rbt_employable.TabIndex = 6;
            this.rbt_employable.TabStop = true;
            this.rbt_employable.Text = "Yes";
            this.rbt_employable.UseVisualStyleBackColor = true;
            // 
            // rbtunemployable
            // 
            this.rbtunemployable.AutoSize = true;
            this.rbtunemployable.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtunemployable.Location = new System.Drawing.Point(208, 367);
            this.rbtunemployable.Name = "rbtunemployable";
            this.rbtunemployable.Size = new System.Drawing.Size(41, 19);
            this.rbtunemployable.TabIndex = 7;
            this.rbtunemployable.Text = "No";
            this.rbtunemployable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Can be Remployed :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(307, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Designation :";
            // 
            // txtnid
            // 
            this.txtnid.Location = new System.Drawing.Point(85, 65);
            this.txtnid.Name = "txtnid";
            this.txtnid.Size = new System.Drawing.Size(164, 20);
            this.txtnid.TabIndex = 3;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(392, 25);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(138, 20);
            this.txt_name.TabIndex = 2;
            // 
            // cmb_employecode
            // 
            this.cmb_employecode.FormattingEnabled = true;
            this.cmb_employecode.Location = new System.Drawing.Point(94, 25);
            this.cmb_employecode.Name = "cmb_employecode";
            this.cmb_employecode.Size = new System.Drawing.Size(155, 22);
            this.cmb_employecode.TabIndex = 1;
            this.cmb_employecode.SelectedIndexChanged += new System.EventHandler(this.cmb_employecode_SelectedIndexChanged);
            this.cmb_employecode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_employecode_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkbx_Reasons);
            this.groupBox2.Location = new System.Drawing.Point(19, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 175);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reason For Deactivation";
            // 
            // chkbx_Reasons
            // 
            this.chkbx_Reasons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkbx_Reasons.FormattingEnabled = true;
            this.chkbx_Reasons.Items.AddRange(new object[] {
            "Absconding",
            "Resignation",
            "Redundancy",
            "Low Efficiency",
            "Disciplinary Action ",
            "Financial Discrepsancy",
            "Terminate",
            "Dismissal",
            "Death"});
            this.chkbx_Reasons.Location = new System.Drawing.Point(3, 18);
            this.chkbx_Reasons.Name = "chkbx_Reasons";
            this.chkbx_Reasons.Size = new System.Drawing.Size(442, 154);
            this.chkbx_Reasons.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "NID/PP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emp Code :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 65);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(115, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(324, 487);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 25);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Submit";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(408, 487);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EmployeeDeactivationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(552, 604);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmployeeDeactivationForm";
            this.Text = "Employee Deactivation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnid;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.ComboBox cmb_employecode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chkbx_Reasons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbt_employable;
        private System.Windows.Forms.RadioButton rbtunemployable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_desg;
        private System.Windows.Forms.RichTextBox rht_remark;
        private System.Windows.Forms.Label lbkl;
        private System.Windows.Forms.DateTimePicker dtp_fromdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_blacklist;
    }
}
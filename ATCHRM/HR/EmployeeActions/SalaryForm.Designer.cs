namespace ATCHRM.Master.NewFolder1
{
    partial class SalaryForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmb_currency = new System.Windows.Forms.ComboBox();
            this.lbl_currency = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbl_SalComponentmain = new System.Windows.Forms.DataGridView();
            this.lbl_empid = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbl_disbursement = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbl_deduction = new System.Windows.Forms.DataGridView();
            this.cmb_EmpCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_bank = new System.Windows.Forms.ComboBox();
            this.txtaccountnum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cocmb_paymentmde = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_appsal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_basicsal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_SalComponentmain)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_disbursement)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_deduction)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1091, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage2.Controls.Add(this.cmb_currency);
            this.tabPage2.Controls.Add(this.lbl_currency);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.lbl_empid);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.cmb_EmpCode);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.cocmb_paymentmde);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txt_appsal);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txt_basicsal);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1083, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Salary";
            // 
            // cmb_currency
            // 
            this.cmb_currency.FormattingEnabled = true;
            this.cmb_currency.Location = new System.Drawing.Point(813, 15);
            this.cmb_currency.Name = "cmb_currency";
            this.cmb_currency.Size = new System.Drawing.Size(86, 22);
            this.cmb_currency.TabIndex = 4;
            this.cmb_currency.SelectedIndexChanged += new System.EventHandler(this.cmb_currency_SelectedIndexChanged);
            // 
            // lbl_currency
            // 
            this.lbl_currency.AutoSize = true;
            this.lbl_currency.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currency.Location = new System.Drawing.Point(484, 17);
            this.lbl_currency.Name = "lbl_currency";
            this.lbl_currency.Size = new System.Drawing.Size(40, 15);
            this.lbl_currency.TabIndex = 13;
            this.lbl_currency.Text = "Dollor";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbl_SalComponentmain);
            this.groupBox6.Location = new System.Drawing.Point(8, 69);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(466, 249);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Salary Component : ";
            // 
            // tbl_SalComponentmain
            // 
            this.tbl_SalComponentmain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_SalComponentmain.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_SalComponentmain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_SalComponentmain.Location = new System.Drawing.Point(13, 20);
            this.tbl_SalComponentmain.MultiSelect = false;
            this.tbl_SalComponentmain.Name = "tbl_SalComponentmain";
            this.tbl_SalComponentmain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_SalComponentmain.Size = new System.Drawing.Size(442, 212);
            this.tbl_SalComponentmain.TabIndex = 5;
            // 
            // lbl_empid
            // 
            this.lbl_empid.AutoSize = true;
            this.lbl_empid.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_empid.Location = new System.Drawing.Point(201, 17);
            this.lbl_empid.Name = "lbl_empid";
            this.lbl_empid.Size = new System.Drawing.Size(61, 15);
            this.lbl_empid.TabIndex = 12;
            this.lbl_empid.Text = "lbl_empid";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Location = new System.Drawing.Point(9, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 280);
            this.panel1.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(471, 140);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(471, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Location = new System.Drawing.Point(517, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(548, 249);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Applicable";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbl_disbursement);
            this.groupBox1.Location = new System.Drawing.Point(18, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 93);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disbursement ";
            // 
            // tbl_disbursement
            // 
            this.tbl_disbursement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_disbursement.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_disbursement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_disbursement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_disbursement.Location = new System.Drawing.Point(3, 16);
            this.tbl_disbursement.MultiSelect = false;
            this.tbl_disbursement.Name = "tbl_disbursement";
            this.tbl_disbursement.RowHeadersVisible = false;
            this.tbl_disbursement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_disbursement.Size = new System.Drawing.Size(513, 74);
            this.tbl_disbursement.TabIndex = 8;
            this.tbl_disbursement.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tbl_disbursement_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbl_deduction);
            this.groupBox2.Location = new System.Drawing.Point(21, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 106);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deduction";
            // 
            // tbl_deduction
            // 
            this.tbl_deduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_deduction.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_deduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_deduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_deduction.Location = new System.Drawing.Point(3, 16);
            this.tbl_deduction.MultiSelect = false;
            this.tbl_deduction.Name = "tbl_deduction";
            this.tbl_deduction.RowHeadersVisible = false;
            this.tbl_deduction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_deduction.Size = new System.Drawing.Size(507, 87);
            this.tbl_deduction.TabIndex = 9;
            this.tbl_deduction.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_deduction_CellClick);
            // 
            // cmb_EmpCode
            // 
            this.cmb_EmpCode.FormattingEnabled = true;
            this.cmb_EmpCode.Location = new System.Drawing.Point(71, 14);
            this.cmb_EmpCode.Name = "cmb_EmpCode";
            this.cmb_EmpCode.Size = new System.Drawing.Size(121, 22);
            this.cmb_EmpCode.TabIndex = 1;
            this.cmb_EmpCode.SelectedIndexChanged += new System.EventHandler(this.cmb_EmpCode_SelectedIndexChanged);
            this.cmb_EmpCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_EmpCode_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "EmpCode :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Controls.Add(this.cmb_bank);
            this.groupBox3.Controls.Add(this.txtaccountnum);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(9, 377);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 108);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment Mode ";
            // 
            // cmb_bank
            // 
            this.cmb_bank.FormattingEnabled = true;
            this.cmb_bank.Location = new System.Drawing.Point(114, 23);
            this.cmb_bank.Name = "cmb_bank";
            this.cmb_bank.Size = new System.Drawing.Size(351, 22);
            this.cmb_bank.TabIndex = 11;
            this.cmb_bank.SelectedIndexChanged += new System.EventHandler(this.cmb_bank_SelectedIndexChanged);
            // 
            // txtaccountnum
            // 
            this.txtaccountnum.Location = new System.Drawing.Point(114, 60);
            this.txtaccountnum.Name = "txtaccountnum";
            this.txtaccountnum.Size = new System.Drawing.Size(113, 20);
            this.txtaccountnum.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Account# :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bank Name : ";
            // 
            // cocmb_paymentmde
            // 
            this.cocmb_paymentmde.FormattingEnabled = true;
            this.cocmb_paymentmde.Items.AddRange(new object[] {
            "Bank Transfer",
            "Check Payment",
            "Cash "});
            this.cocmb_paymentmde.Location = new System.Drawing.Point(131, 349);
            this.cocmb_paymentmde.Name = "cocmb_paymentmde";
            this.cocmb_paymentmde.Size = new System.Drawing.Size(121, 22);
            this.cocmb_paymentmde.TabIndex = 10;
            this.cocmb_paymentmde.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Salary To Be Paid By  :";
            // 
            // txt_appsal
            // 
            this.txt_appsal.Location = new System.Drawing.Point(697, 15);
            this.txt_appsal.Name = "txt_appsal";
            this.txt_appsal.Size = new System.Drawing.Size(100, 20);
            this.txt_appsal.TabIndex = 3;
            this.txt_appsal.TextChanged += new System.EventHandler(this.txt_appsal_TextChanged);
            this.txt_appsal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_appsal_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(572, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Approved Sal  :";
            // 
            // txt_basicsal
            // 
            this.txt_basicsal.Location = new System.Drawing.Point(363, 14);
            this.txt_basicsal.Name = "txt_basicsal";
            this.txt_basicsal.Size = new System.Drawing.Size(100, 20);
            this.txt_basicsal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Basic Salary : ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 564);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1115, 65);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(96, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(415, 538);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 25);
            this.btn_submit.TabIndex = 13;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(503, 538);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1115, 629);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SalaryForm";
            this.Text = "SalaryForm";
            this.Load += new System.EventHandler(this.SalaryForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_SalComponentmain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_disbursement)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_deduction)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView tbl_SalComponentmain;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tbl_disbursement;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tbl_deduction;
        private System.Windows.Forms.ComboBox cmb_EmpCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmb_bank;
        private System.Windows.Forms.TextBox txtaccountnum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cocmb_paymentmde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_appsal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_basicsal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_empid;
        private System.Windows.Forms.Label lbl_currency;
        private System.Windows.Forms.ComboBox cmb_currency;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}
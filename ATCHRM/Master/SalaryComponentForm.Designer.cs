namespace ATCHRM.Master
{
    partial class SalaryComponentForm
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
            this.pnl_calculationtype = new System.Windows.Forms.Panel();
            this.grpformul = new System.Windows.Forms.GroupBox();
            this.cmb_Formula = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblformulatype = new System.Windows.Forms.Label();
            this.cmb_calculatiotypeselected = new System.Windows.Forms.ComboBox();
            this.pnl_iffixed = new System.Windows.Forms.Panel();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_calculationtype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_componenttypechange = new System.Windows.Forms.Panel();
            this.cmb_typeselected = new System.Windows.Forms.ComboBox();
            this.lbltype = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_componenttype = new System.Windows.Forms.ComboBox();
            this.txt_componentname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnl_calculationtype.SuspendLayout();
            this.grpformul.SuspendLayout();
            this.pnl_iffixed.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_componenttypechange.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pnl_calculationtype);
            this.groupBox1.Controls.Add(this.pnl_iffixed);
            this.groupBox1.Controls.Add(this.cmb_calculationtype);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txt_componentname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-1, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Component ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnl_calculationtype
            // 
            this.pnl_calculationtype.Controls.Add(this.grpformul);
            this.pnl_calculationtype.Controls.Add(this.lblformulatype);
            this.pnl_calculationtype.Controls.Add(this.cmb_calculatiotypeselected);
            this.pnl_calculationtype.Location = new System.Drawing.Point(287, 84);
            this.pnl_calculationtype.Name = "pnl_calculationtype";
            this.pnl_calculationtype.Size = new System.Drawing.Size(309, 100);
            this.pnl_calculationtype.TabIndex = 14;
            this.pnl_calculationtype.Visible = false;
            // 
            // grpformul
            // 
            this.grpformul.Controls.Add(this.cmb_Formula);
            this.grpformul.Controls.Add(this.label2);
            this.grpformul.Location = new System.Drawing.Point(6, 44);
            this.grpformul.Name = "grpformul";
            this.grpformul.Size = new System.Drawing.Size(299, 48);
            this.grpformul.TabIndex = 9;
            this.grpformul.TabStop = false;
            // 
            // cmb_Formula
            // 
            this.cmb_Formula.FormattingEnabled = true;
            this.cmb_Formula.Location = new System.Drawing.Point(82, 19);
            this.cmb_Formula.Name = "cmb_Formula";
            this.cmb_Formula.Size = new System.Drawing.Size(214, 21);
            this.cmb_Formula.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Formula :";
            // 
            // lblformulatype
            // 
            this.lblformulatype.AutoSize = true;
            this.lblformulatype.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblformulatype.Location = new System.Drawing.Point(26, 16);
            this.lblformulatype.Name = "lblformulatype";
            this.lblformulatype.Size = new System.Drawing.Size(47, 15);
            this.lblformulatype.TabIndex = 8;
            this.lblformulatype.Text = "label5 :";
            // 
            // cmb_calculatiotypeselected
            // 
            this.cmb_calculatiotypeselected.FormattingEnabled = true;
            this.cmb_calculatiotypeselected.Location = new System.Drawing.Point(89, 14);
            this.cmb_calculatiotypeselected.Name = "cmb_calculatiotypeselected";
            this.cmb_calculatiotypeselected.Size = new System.Drawing.Size(213, 21);
            this.cmb_calculatiotypeselected.TabIndex = 4;
            this.cmb_calculatiotypeselected.SelectedIndexChanged += new System.EventHandler(this.cmb_calculatiotypeselected_SelectedIndexChanged);
            // 
            // pnl_iffixed
            // 
            this.pnl_iffixed.BackColor = System.Drawing.Color.LightBlue;
            this.pnl_iffixed.Controls.Add(this.txt_amount);
            this.pnl_iffixed.Controls.Add(this.label6);
            this.pnl_iffixed.Location = new System.Drawing.Point(602, 139);
            this.pnl_iffixed.Name = "pnl_iffixed";
            this.pnl_iffixed.Size = new System.Drawing.Size(206, 45);
            this.pnl_iffixed.TabIndex = 10;
            this.pnl_iffixed.Visible = false;
            this.pnl_iffixed.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_iffixed_Paint);
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(69, 11);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(122, 21);
            this.txt_amount.TabIndex = 7;
            this.txt_amount.TextChanged += new System.EventHandler(this.txt_amount_TextChanged);
            this.txt_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_amount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Amount :";
            // 
            // cmb_calculationtype
            // 
            this.cmb_calculationtype.FormattingEnabled = true;
            this.cmb_calculationtype.Items.AddRange(new object[] {
            "Manually",
            "Formula"});
            this.cmb_calculationtype.Location = new System.Drawing.Point(145, 146);
            this.cmb_calculationtype.Name = "cmb_calculationtype";
            this.cmb_calculationtype.Size = new System.Drawing.Size(136, 21);
            this.cmb_calculationtype.TabIndex = 5;
            this.cmb_calculationtype.SelectedIndexChanged += new System.EventHandler(this.cmb_calculationtype_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Calculation Type : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.pnl_componenttypechange);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_componenttype);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 60);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnl_componenttypechange
            // 
            this.pnl_componenttypechange.Controls.Add(this.cmb_typeselected);
            this.pnl_componenttypechange.Controls.Add(this.lbltype);
            this.pnl_componenttypechange.Location = new System.Drawing.Point(281, 0);
            this.pnl_componenttypechange.Name = "pnl_componenttypechange";
            this.pnl_componenttypechange.Size = new System.Drawing.Size(472, 47);
            this.pnl_componenttypechange.TabIndex = 4;
            this.pnl_componenttypechange.Visible = false;
            // 
            // cmb_typeselected
            // 
            this.cmb_typeselected.FormattingEnabled = true;
            this.cmb_typeselected.Location = new System.Drawing.Point(100, 15);
            this.cmb_typeselected.Name = "cmb_typeselected";
            this.cmb_typeselected.Size = new System.Drawing.Size(216, 21);
            this.cmb_typeselected.TabIndex = 2;
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.Location = new System.Drawing.Point(27, 20);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(47, 15);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "label2 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type of Component : ";
            // 
            // cmb_componenttype
            // 
            this.cmb_componenttype.FormattingEnabled = true;
            this.cmb_componenttype.Items.AddRange(new object[] {
            "Disbursement",
            "Deduction"});
            this.cmb_componenttype.Location = new System.Drawing.Point(139, 17);
            this.cmb_componenttype.Name = "cmb_componenttype";
            this.cmb_componenttype.Size = new System.Drawing.Size(136, 21);
            this.cmb_componenttype.TabIndex = 1;
            this.cmb_componenttype.SelectedIndexChanged += new System.EventHandler(this.cmb_componenttype_SelectedIndexChanged);
            // 
            // txt_componentname
            // 
            this.txt_componentname.Location = new System.Drawing.Point(145, 97);
            this.txt_componentname.Name = "txt_componentname";
            this.txt_componentname.Size = new System.Drawing.Size(136, 21);
            this.txt_componentname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name of Component :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(820, 65);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(291, 28);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(660, 197);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(741, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SalaryComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(820, 287);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SalaryComponentForm";
            this.Text = "Salary Component";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnl_calculationtype.ResumeLayout(false);
            this.pnl_calculationtype.PerformLayout();
            this.grpformul.ResumeLayout(false);
            this.grpformul.PerformLayout();
            this.pnl_iffixed.ResumeLayout(false);
            this.pnl_iffixed.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_componenttypechange.ResumeLayout(false);
            this.pnl_componenttypechange.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_typeselected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_componenttype;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.TextBox txt_componentname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_calculatiotypeselected;
        private System.Windows.Forms.Label lblformulatype;
        private System.Windows.Forms.ComboBox cmb_calculationtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnl_iffixed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_componenttypechange;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_calculationtype;
        private System.Windows.Forms.ComboBox cmb_Formula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpformul;
    }
}
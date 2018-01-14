namespace ATCHRM.Master
{
    partial class FormulaEditorForm
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
            this.txt_formulaName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Formulatype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_formulaSubmit = new System.Windows.Forms.Button();
            this.txt_formulaTest = new System.Windows.Forms.TextBox();
            this.lbl_addOperator = new System.Windows.Forms.Label();
            this.lbl_addoperend = new System.Windows.Forms.Label();
            this.cmb_Operator = new System.Windows.Forms.ComboBox();
            this.cmb_feildName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.rht_mainFormula = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_numdecimal = new System.Windows.Forms.Button();
            this.btn_num0 = new System.Windows.Forms.Button();
            this.btn_num9 = new System.Windows.Forms.Button();
            this.btn_num2 = new System.Windows.Forms.Button();
            this.btn_num4 = new System.Windows.Forms.Button();
            this.btn_num5 = new System.Windows.Forms.Button();
            this.btn_num7 = new System.Windows.Forms.Button();
            this.btn_num8 = new System.Windows.Forms.Button();
            this.btn_num3 = new System.Windows.Forms.Button();
            this.btn_num6 = new System.Windows.Forms.Button();
            this.btn_numADD = new System.Windows.Forms.Button();
            this.btn_numClear = new System.Windows.Forms.Button();
            this.txt_CalNum = new System.Windows.Forms.TextBox();
            this.btn_num1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tb_lFormula = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lFormula)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.txt_formulaName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_Formulatype);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1058, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // txt_formulaName
            // 
            this.txt_formulaName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_formulaName.Location = new System.Drawing.Point(336, 25);
            this.txt_formulaName.Name = "txt_formulaName";
            this.txt_formulaName.Size = new System.Drawing.Size(127, 20);
            this.txt_formulaName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(249, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Formula Name :";
            // 
            // cmb_Formulatype
            // 
            this.cmb_Formulatype.FormattingEnabled = true;
            this.cmb_Formulatype.Items.AddRange(new object[] {
            "Salary",
            "Overtime",
            "Provident Fund",
            "Others"});
            this.cmb_Formulatype.Location = new System.Drawing.Point(108, 24);
            this.cmb_Formulatype.Name = "cmb_Formulatype";
            this.cmb_Formulatype.Size = new System.Drawing.Size(121, 22);
            this.cmb_Formulatype.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Formula For:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Controls.Add(this.btn_formulaSubmit);
            this.groupBox2.Controls.Add(this.txt_formulaTest);
            this.groupBox2.Controls.Add(this.lbl_addOperator);
            this.groupBox2.Controls.Add(this.lbl_addoperend);
            this.groupBox2.Controls.Add(this.cmb_Operator);
            this.groupBox2.Controls.Add(this.cmb_feildName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(2, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 229);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Formula Editor";
            // 
            // btn_formulaSubmit
            // 
            this.btn_formulaSubmit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_formulaSubmit.Location = new System.Drawing.Point(163, 193);
            this.btn_formulaSubmit.Name = "btn_formulaSubmit";
            this.btn_formulaSubmit.Size = new System.Drawing.Size(60, 25);
            this.btn_formulaSubmit.TabIndex = 8;
            this.btn_formulaSubmit.Text = "Submit";
            this.btn_formulaSubmit.UseVisualStyleBackColor = true;
            this.btn_formulaSubmit.Click += new System.EventHandler(this.btn_formulaSubmit_Click);
            // 
            // txt_formulaTest
            // 
            this.txt_formulaTest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_formulaTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_formulaTest.Location = new System.Drawing.Point(28, 145);
            this.txt_formulaTest.Name = "txt_formulaTest";
            this.txt_formulaTest.Size = new System.Drawing.Size(320, 21);
            this.txt_formulaTest.TabIndex = 7;
            // 
            // lbl_addOperator
            // 
            this.lbl_addOperator.AutoSize = true;
            this.lbl_addOperator.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_addOperator.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_addOperator.Location = new System.Drawing.Point(318, 98);
            this.lbl_addOperator.Name = "lbl_addOperator";
            this.lbl_addOperator.Size = new System.Drawing.Size(30, 14);
            this.lbl_addOperator.TabIndex = 6;
            this.lbl_addOperator.Text = "ADD";
            this.lbl_addOperator.Click += new System.EventHandler(this.lbl_addOperator_Click);
            // 
            // lbl_addoperend
            // 
            this.lbl_addoperend.AutoSize = true;
            this.lbl_addoperend.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_addoperend.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_addoperend.Location = new System.Drawing.Point(318, 48);
            this.lbl_addoperend.Name = "lbl_addoperend";
            this.lbl_addoperend.Size = new System.Drawing.Size(30, 14);
            this.lbl_addoperend.TabIndex = 4;
            this.lbl_addoperend.Text = "ADD";
            this.lbl_addoperend.Click += new System.EventHandler(this.lbl_addoperend_Click);
            // 
            // cmb_Operator
            // 
            this.cmb_Operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Operator.FormattingEnabled = true;
            this.cmb_Operator.Items.AddRange(new object[] {
            "(",
            ")",
            "*",
            "/",
            "+",
            "-",
            "%"});
            this.cmb_Operator.Location = new System.Drawing.Point(163, 93);
            this.cmb_Operator.Name = "cmb_Operator";
            this.cmb_Operator.Size = new System.Drawing.Size(137, 22);
            this.cmb_Operator.TabIndex = 5;
            // 
            // cmb_feildName
            // 
            this.cmb_feildName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_feildName.FormattingEnabled = true;
            this.cmb_feildName.Items.AddRange(new object[] {
            "BASIC",
            "HA",
            "TA",
            "DA",
            "OT",
            "LH",
            "BONUS"});
            this.cmb_feildName.Location = new System.Drawing.Point(163, 45);
            this.cmb_feildName.Name = "cmb_feildName";
            this.cmb_feildName.Size = new System.Drawing.Size(137, 22);
            this.cmb_feildName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Action (Operator) : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Feild Name (Operend) : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 493);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1061, 73);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(189, 28);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // rht_mainFormula
            // 
            this.rht_mainFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rht_mainFormula.Location = new System.Drawing.Point(2, 308);
            this.rht_mainFormula.Name = "rht_mainFormula";
            this.rht_mainFormula.Size = new System.Drawing.Size(666, 153);
            this.rht_mainFormula.TabIndex = 4;
            this.rht_mainFormula.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Azure;
            this.groupBox4.Controls.Add(this.btn_numdecimal);
            this.groupBox4.Controls.Add(this.btn_num0);
            this.groupBox4.Controls.Add(this.btn_num9);
            this.groupBox4.Controls.Add(this.btn_num2);
            this.groupBox4.Controls.Add(this.btn_num4);
            this.groupBox4.Controls.Add(this.btn_num5);
            this.groupBox4.Controls.Add(this.btn_num7);
            this.groupBox4.Controls.Add(this.btn_num8);
            this.groupBox4.Controls.Add(this.btn_num3);
            this.groupBox4.Controls.Add(this.btn_num6);
            this.groupBox4.Controls.Add(this.btn_numADD);
            this.groupBox4.Controls.Add(this.btn_numClear);
            this.groupBox4.Controls.Add(this.txt_CalNum);
            this.groupBox4.Controls.Add(this.btn_num1);
            this.groupBox4.Location = new System.Drawing.Point(390, 74);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 229);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Feilds";
            // 
            // btn_numdecimal
            // 
            this.btn_numdecimal.BackColor = System.Drawing.Color.LightBlue;
            this.btn_numdecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_numdecimal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_numdecimal.Location = new System.Drawing.Point(130, 193);
            this.btn_numdecimal.Name = "btn_numdecimal";
            this.btn_numdecimal.Size = new System.Drawing.Size(60, 28);
            this.btn_numdecimal.TabIndex = 21;
            this.btn_numdecimal.Text = ".";
            this.btn_numdecimal.UseVisualStyleBackColor = false;
            this.btn_numdecimal.Click += new System.EventHandler(this.btn_numdecimal_Click);
            // 
            // btn_num0
            // 
            this.btn_num0.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num0.Location = new System.Drawing.Point(49, 193);
            this.btn_num0.Name = "btn_num0";
            this.btn_num0.Size = new System.Drawing.Size(75, 28);
            this.btn_num0.TabIndex = 20;
            this.btn_num0.Text = "0";
            this.btn_num0.UseVisualStyleBackColor = false;
            this.btn_num0.Click += new System.EventHandler(this.btn_num0_Click);
            // 
            // btn_num9
            // 
            this.btn_num9.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num9.Location = new System.Drawing.Point(147, 145);
            this.btn_num9.Name = "btn_num9";
            this.btn_num9.Size = new System.Drawing.Size(43, 41);
            this.btn_num9.TabIndex = 19;
            this.btn_num9.Text = "9";
            this.btn_num9.UseVisualStyleBackColor = false;
            this.btn_num9.Click += new System.EventHandler(this.btn_num9_Click);
            // 
            // btn_num2
            // 
            this.btn_num2.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num2.Location = new System.Drawing.Point(98, 51);
            this.btn_num2.Name = "btn_num2";
            this.btn_num2.Size = new System.Drawing.Size(43, 41);
            this.btn_num2.TabIndex = 18;
            this.btn_num2.Text = "2";
            this.btn_num2.UseVisualStyleBackColor = false;
            this.btn_num2.Click += new System.EventHandler(this.btn_num2_Click);
            // 
            // btn_num4
            // 
            this.btn_num4.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num4.Location = new System.Drawing.Point(49, 98);
            this.btn_num4.Name = "btn_num4";
            this.btn_num4.Size = new System.Drawing.Size(43, 41);
            this.btn_num4.TabIndex = 17;
            this.btn_num4.Text = "4";
            this.btn_num4.UseVisualStyleBackColor = false;
            this.btn_num4.Click += new System.EventHandler(this.btn_num4_Click);
            // 
            // btn_num5
            // 
            this.btn_num5.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num5.Location = new System.Drawing.Point(98, 98);
            this.btn_num5.Name = "btn_num5";
            this.btn_num5.Size = new System.Drawing.Size(43, 41);
            this.btn_num5.TabIndex = 16;
            this.btn_num5.Text = "5";
            this.btn_num5.UseVisualStyleBackColor = false;
            this.btn_num5.Click += new System.EventHandler(this.btn_num5_Click);
            // 
            // btn_num7
            // 
            this.btn_num7.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num7.Location = new System.Drawing.Point(49, 145);
            this.btn_num7.Name = "btn_num7";
            this.btn_num7.Size = new System.Drawing.Size(43, 41);
            this.btn_num7.TabIndex = 15;
            this.btn_num7.Text = "7";
            this.btn_num7.UseVisualStyleBackColor = false;
            this.btn_num7.Click += new System.EventHandler(this.btn_num7_Click);
            // 
            // btn_num8
            // 
            this.btn_num8.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num8.Location = new System.Drawing.Point(98, 145);
            this.btn_num8.Name = "btn_num8";
            this.btn_num8.Size = new System.Drawing.Size(43, 41);
            this.btn_num8.TabIndex = 14;
            this.btn_num8.Text = "8";
            this.btn_num8.UseVisualStyleBackColor = false;
            this.btn_num8.Click += new System.EventHandler(this.btn_num8_Click);
            // 
            // btn_num3
            // 
            this.btn_num3.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num3.Location = new System.Drawing.Point(147, 51);
            this.btn_num3.Name = "btn_num3";
            this.btn_num3.Size = new System.Drawing.Size(43, 41);
            this.btn_num3.TabIndex = 13;
            this.btn_num3.Text = "3";
            this.btn_num3.UseVisualStyleBackColor = false;
            this.btn_num3.Click += new System.EventHandler(this.btn_num3_Click);
            // 
            // btn_num6
            // 
            this.btn_num6.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num6.Location = new System.Drawing.Point(147, 98);
            this.btn_num6.Name = "btn_num6";
            this.btn_num6.Size = new System.Drawing.Size(43, 41);
            this.btn_num6.TabIndex = 12;
            this.btn_num6.Text = "6";
            this.btn_num6.UseVisualStyleBackColor = false;
            this.btn_num6.Click += new System.EventHandler(this.btn_num6_Click);
            // 
            // btn_numADD
            // 
            this.btn_numADD.BackColor = System.Drawing.Color.LightBlue;
            this.btn_numADD.Location = new System.Drawing.Point(196, 113);
            this.btn_numADD.Name = "btn_numADD";
            this.btn_numADD.Size = new System.Drawing.Size(64, 108);
            this.btn_numADD.TabIndex = 11;
            this.btn_numADD.Text = "Add";
            this.btn_numADD.UseVisualStyleBackColor = false;
            this.btn_numADD.Click += new System.EventHandler(this.btn_numADD_Click);
            // 
            // btn_numClear
            // 
            this.btn_numClear.BackColor = System.Drawing.Color.LightBlue;
            this.btn_numClear.Location = new System.Drawing.Point(196, 20);
            this.btn_numClear.Name = "btn_numClear";
            this.btn_numClear.Size = new System.Drawing.Size(64, 86);
            this.btn_numClear.TabIndex = 10;
            this.btn_numClear.Text = "CLR";
            this.btn_numClear.UseVisualStyleBackColor = false;
            this.btn_numClear.Click += new System.EventHandler(this.btn_numClear_Click);
            // 
            // txt_CalNum
            // 
            this.txt_CalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CalNum.Location = new System.Drawing.Point(49, 19);
            this.txt_CalNum.Name = "txt_CalNum";
            this.txt_CalNum.Size = new System.Drawing.Size(141, 21);
            this.txt_CalNum.TabIndex = 2;
            // 
            // btn_num1
            // 
            this.btn_num1.BackColor = System.Drawing.Color.LightBlue;
            this.btn_num1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_num1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_num1.Location = new System.Drawing.Point(49, 51);
            this.btn_num1.Name = "btn_num1";
            this.btn_num1.Size = new System.Drawing.Size(43, 41);
            this.btn_num1.TabIndex = 0;
            this.btn_num1.Text = "1";
            this.btn_num1.UseVisualStyleBackColor = false;
            this.btn_num1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(670, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 21;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(572, 470);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 20;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // tb_lFormula
            // 
            this.tb_lFormula.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tb_lFormula.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.tb_lFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_lFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_lFormula.Location = new System.Drawing.Point(3, 16);
            this.tb_lFormula.Name = "tb_lFormula";
            this.tb_lFormula.ReadOnly = true;
            this.tb_lFormula.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tb_lFormula.RowHeadersVisible = false;
            this.tb_lFormula.Size = new System.Drawing.Size(373, 370);
            this.tb_lFormula.TabIndex = 8;
            this.tb_lFormula.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_lFormula_CellDoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tb_lFormula);
            this.groupBox5.Location = new System.Drawing.Point(681, 74);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(379, 389);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Formulas";
            // 
            // FormulaEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1061, 566);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.rht_mainFormula);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormulaEditorForm";
            this.Text = "Formula Editor";
            this.Load += new System.EventHandler(this.FormulaEditorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lFormula)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_formulaName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Formulatype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rht_mainFormula;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_num9;
        private System.Windows.Forms.Button btn_num2;
        private System.Windows.Forms.Button btn_num4;
        private System.Windows.Forms.Button btn_num5;
        private System.Windows.Forms.Button btn_num7;
        private System.Windows.Forms.Button btn_num8;
        private System.Windows.Forms.Button btn_num3;
        private System.Windows.Forms.Button btn_num6;
        private System.Windows.Forms.Button btn_numADD;
        private System.Windows.Forms.Button btn_numClear;
        private System.Windows.Forms.TextBox txt_CalNum;
        private System.Windows.Forms.Button btn_num1;
        private System.Windows.Forms.Label lbl_addoperend;
        private System.Windows.Forms.ComboBox cmb_Operator;
        private System.Windows.Forms.ComboBox cmb_feildName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_formulaSubmit;
        private System.Windows.Forms.TextBox txt_formulaTest;
        private System.Windows.Forms.Label lbl_addOperator;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btn_numdecimal;
        private System.Windows.Forms.Button btn_num0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridView tb_lFormula;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}
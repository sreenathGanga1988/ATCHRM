namespace ATCHRM.Master.NewFolder1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaveForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbl_Leavedata = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_emppk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_empCode = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbl_leaveForward = new System.Windows.Forms.DataGridView();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbrecureleave = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowedNumberdays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Skip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_submmit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Leavedata)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leaveForward)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbl_Leavedata);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 181);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eligible For : ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tbl_Leavedata
            // 
            this.tbl_Leavedata.AllowUserToAddRows = false;
            this.tbl_Leavedata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_Leavedata.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_Leavedata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Leavedata.Location = new System.Drawing.Point(6, 20);
            this.tbl_Leavedata.Name = "tbl_Leavedata";
            this.tbl_Leavedata.ReadOnly = true;
            this.tbl_Leavedata.RowHeadersVisible = false;
            this.tbl_Leavedata.Size = new System.Drawing.Size(450, 146);
            this.tbl_Leavedata.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(401, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Finish";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(320, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 492);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(106, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_emppk);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmb_empCode);
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 45);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Employee : ";
            // 
            // lbl_emppk
            // 
            this.lbl_emppk.AutoSize = true;
            this.lbl_emppk.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_emppk.Location = new System.Drawing.Point(245, 18);
            this.lbl_emppk.Name = "lbl_emppk";
            this.lbl_emppk.Size = new System.Drawing.Size(64, 15);
            this.lbl_emppk.TabIndex = 22;
            this.lbl_emppk.Text = "lbl_emppk";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Emp Code : ";
            // 
            // cmb_empCode
            // 
            this.cmb_empCode.FormattingEnabled = true;
            this.cmb_empCode.Location = new System.Drawing.Point(97, 15);
            this.cmb_empCode.Name = "cmb_empCode";
            this.cmb_empCode.Size = new System.Drawing.Size(121, 22);
            this.cmb_empCode.TabIndex = 1;
            this.cmb_empCode.SelectedIndexChanged += new System.EventHandler(this.cmb_empCode_SelectedIndexChanged);
            this.cmb_empCode.Click += new System.EventHandler(this.cmb_empCode_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.tbl_leaveForward);
            this.groupBox4.Location = new System.Drawing.Point(12, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(471, 192);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Leave Carry Forward : ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 18);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Leave Forward";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tbl_leaveForward
            // 
            this.tbl_leaveForward.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_leaveForward.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_leaveForward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_leaveForward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SL,
            this.cmbrecureleave,
            this.Days,
            this.CalculationType,
            this.AllowedNumberdays,
            this.Column1});
            this.tbl_leaveForward.Location = new System.Drawing.Point(6, 44);
            this.tbl_leaveForward.Name = "tbl_leaveForward";
            this.tbl_leaveForward.RowHeadersVisible = false;
            this.tbl_leaveForward.Size = new System.Drawing.Size(450, 132);
            this.tbl_leaveForward.TabIndex = 4;
            this.tbl_leaveForward.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_leaveForward_CellEndEdit);
            this.tbl_leaveForward.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_leaveForward_CellValueChanged);
            // 
            // SL
            // 
            this.SL.HeaderText = "Column1";
            this.SL.Name = "SL";
            // 
            // cmbrecureleave
            // 
            this.cmbrecureleave.HeaderText = "Leave";
            this.cmbrecureleave.Name = "cmbrecureleave";
            this.cmbrecureleave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbrecureleave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Days
            // 
            this.Days.HeaderText = "Days";
            this.Days.Name = "Days";
            // 
            // CalculationType
            // 
            this.CalculationType.HeaderText = "CalculationType";
            this.CalculationType.Name = "CalculationType";
            // 
            // AllowedNumberdays
            // 
            this.AllowedNumberdays.HeaderText = "AllowedNumber";
            this.AllowedNumberdays.Name = "AllowedNumberdays";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Remark";
            this.Column1.Name = "Column1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Skip,
            this.toolStripButton1,
            this.btn_submmit,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 467);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(485, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Skip
            // 
            this.btn_Skip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Skip.Enabled = false;
            this.btn_Skip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Skip.Image = ((System.Drawing.Image)(resources.GetObject("btn_Skip.Image")));
            this.btn_Skip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Skip.Name = "btn_Skip";
            this.btn_Skip.Size = new System.Drawing.Size(49, 22);
            this.btn_Skip.Text = "Skip";
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
            // 
            // btn_submmit
            // 
            this.btn_submmit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_submmit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submmit.Image = ((System.Drawing.Image)(resources.GetObject("btn_submmit.Image")));
            this.btn_submmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_submmit.Name = "btn_submmit";
            this.btn_submmit.Size = new System.Drawing.Size(66, 22);
            this.btn_submmit.Text = "Submit";
            this.btn_submmit.Click += new System.EventHandler(this.btn_submmit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // LeaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(485, 562);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LeaveForm";
            this.Text = "LeaveForm";
            this.Load += new System.EventHandler(this.LeaveForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Leavedata)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leaveForward)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tbl_Leavedata;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_empCode;
        private System.Windows.Forms.Label lbl_emppk;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView tbl_leaveForward;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbrecureleave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalculationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowedNumberdays;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Skip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btn_submmit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
namespace ATCHRM.Action
{
    partial class tryform
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
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_empcode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_leave = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbl_contract = new System.Windows.Forms.DataGridView();
            this.tbl_leavedata = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_display = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_contract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leavedata)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Leave Type :";
            // 
            // cmb_empcode
            // 
            this.cmb_empcode.FormattingEnabled = true;
            this.cmb_empcode.Location = new System.Drawing.Point(104, 17);
            this.cmb_empcode.Name = "cmb_empcode";
            this.cmb_empcode.Size = new System.Drawing.Size(121, 21);
            this.cmb_empcode.TabIndex = 1;
            this.cmb_empcode.SelectedIndexChanged += new System.EventHandler(this.cmb_empcode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Emp Code : ";
            // 
            // cmb_leave
            // 
            this.cmb_leave.FormattingEnabled = true;
            this.cmb_leave.Location = new System.Drawing.Point(104, 62);
            this.cmb_leave.Name = "cmb_leave";
            this.cmb_leave.Size = new System.Drawing.Size(121, 21);
            this.cmb_leave.TabIndex = 2;
            this.cmb_leave.SelectedIndexChanged += new System.EventHandler(this.cmb_leave_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(286, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Proceed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbl_contract
            // 
            this.tbl_contract.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_contract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_contract.Location = new System.Drawing.Point(12, 120);
            this.tbl_contract.Name = "tbl_contract";
            this.tbl_contract.Size = new System.Drawing.Size(706, 83);
            this.tbl_contract.TabIndex = 5;
            // 
            // tbl_leavedata
            // 
            this.tbl_leavedata.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_leavedata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_leavedata.Location = new System.Drawing.Point(12, 232);
            this.tbl_leavedata.Name = "tbl_leavedata";
            this.tbl_leavedata.Size = new System.Drawing.Size(706, 83);
            this.tbl_leavedata.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(494, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(413, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Date & Time :";
            // 
            // btn_display
            // 
            this.btn_display.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_display.Location = new System.Drawing.Point(240, 369);
            this.btn_display.Name = "btn_display";
            this.btn_display.Size = new System.Drawing.Size(75, 36);
            this.btn_display.TabIndex = 7;
            this.btn_display.Text = "Value";
            this.btn_display.UseVisualStyleBackColor = true;
            // 
            // tryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(730, 413);
            this.Controls.Add(this.btn_display);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tbl_leavedata);
            this.Controls.Add(this.tbl_contract);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_empcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_leave);
            this.MaximizeBox = false;
            this.Name = "tryform";
            this.Text = "Employee Shift";
            this.Load += new System.EventHandler(this.tryform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_contract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_leavedata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_empcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_leave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tbl_contract;
        private System.Windows.Forms.DataGridView tbl_leavedata;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_display;




    }
}
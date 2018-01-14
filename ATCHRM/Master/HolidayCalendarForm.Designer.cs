namespace ATCHRM.Master
{
    partial class HolidayCalendarForm
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
            this.pnl_otherholiday = new System.Windows.Forms.GroupBox();
            this.lblholidaypk = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rht_description = new System.Windows.Forms.RichTextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.cmb_HolidayType = new System.Windows.Forms.ComboBox();
            this.dtp_Timepicker = new System.Windows.Forms.DateTimePicker();
            this.txt_holiday = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbl_holidaytable = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_weeklyofdays = new System.Windows.Forms.ComboBox();
            this.chk_Otherholidays = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_Year = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_otherholiday.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_holidaytable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_otherholiday
            // 
            this.pnl_otherholiday.Controls.Add(this.lblholidaypk);
            this.pnl_otherholiday.Controls.Add(this.btn_Cancel);
            this.pnl_otherholiday.Controls.Add(this.rht_description);
            this.pnl_otherholiday.Controls.Add(this.btn_submit);
            this.pnl_otherholiday.Controls.Add(this.cmb_HolidayType);
            this.pnl_otherholiday.Controls.Add(this.dtp_Timepicker);
            this.pnl_otherholiday.Controls.Add(this.txt_holiday);
            this.pnl_otherholiday.Controls.Add(this.label4);
            this.pnl_otherholiday.Controls.Add(this.label2);
            this.pnl_otherholiday.Controls.Add(this.label1);
            this.pnl_otherholiday.Controls.Add(this.label3);
            this.pnl_otherholiday.Enabled = false;
            this.pnl_otherholiday.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_otherholiday.Location = new System.Drawing.Point(12, 201);
            this.pnl_otherholiday.Name = "pnl_otherholiday";
            this.pnl_otherholiday.Size = new System.Drawing.Size(306, 275);
            this.pnl_otherholiday.TabIndex = 0;
            this.pnl_otherholiday.TabStop = false;
            this.pnl_otherholiday.Text = "Holiday Calendar";
            // 
            // lblholidaypk
            // 
            this.lblholidaypk.AutoSize = true;
            this.lblholidaypk.Location = new System.Drawing.Point(267, 33);
            this.lblholidaypk.Name = "lblholidaypk";
            this.lblholidaypk.Size = new System.Drawing.Size(37, 13);
            this.lblholidaypk.TabIndex = 6;
            this.lblholidaypk.Text = "label6";
            this.lblholidaypk.Visible = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(218, 240);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rht_description
            // 
            this.rht_description.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rht_description.Location = new System.Drawing.Point(115, 163);
            this.rht_description.Name = "rht_description";
            this.rht_description.Size = new System.Drawing.Size(171, 57);
            this.rht_description.TabIndex = 9;
            this.rht_description.Text = "";
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(137, 240);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 25);
            this.btn_submit.TabIndex = 10;
            this.btn_submit.Text = "Save";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // cmb_HolidayType
            // 
            this.cmb_HolidayType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_HolidayType.FormattingEnabled = true;
            this.cmb_HolidayType.Items.AddRange(new object[] {
            "Public Holiday",
            "Others"});
            this.cmb_HolidayType.Location = new System.Drawing.Point(116, 117);
            this.cmb_HolidayType.Name = "cmb_HolidayType";
            this.cmb_HolidayType.Size = new System.Drawing.Size(139, 22);
            this.cmb_HolidayType.TabIndex = 8;
            // 
            // dtp_Timepicker
            // 
            this.dtp_Timepicker.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Timepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Timepicker.Location = new System.Drawing.Point(116, 74);
            this.dtp_Timepicker.Name = "dtp_Timepicker";
            this.dtp_Timepicker.Size = new System.Drawing.Size(139, 20);
            this.dtp_Timepicker.TabIndex = 7;
            // 
            // txt_holiday
            // 
            this.txt_holiday.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_holiday.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_holiday.Location = new System.Drawing.Point(115, 30);
            this.txt_holiday.Name = "txt_holiday";
            this.txt_holiday.Size = new System.Drawing.Size(139, 20);
            this.txt_holiday.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Holiday Type : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Holiday Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(851, 64);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(165, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(191, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Message will be Shown here";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbl_holidaytable);
            this.groupBox3.Location = new System.Drawing.Point(324, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 464);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Holidays";
            // 
            // tbl_holidaytable
            // 
            this.tbl_holidaytable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_holidaytable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_holidaytable.Location = new System.Drawing.Point(6, 13);
            this.tbl_holidaytable.Name = "tbl_holidaytable";
            this.tbl_holidaytable.ReadOnly = true;
            this.tbl_holidaytable.RowHeadersVisible = false;
            this.tbl_holidaytable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_holidaytable.Size = new System.Drawing.Size(510, 441);
            this.tbl_holidaytable.TabIndex = 0;
            this.tbl_holidaytable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_holidaytable_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "Weekly Off Day :";
            // 
            // cmb_weeklyofdays
            // 
            this.cmb_weeklyofdays.FormattingEnabled = true;
            this.cmb_weeklyofdays.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmb_weeklyofdays.Location = new System.Drawing.Point(115, 63);
            this.cmb_weeklyofdays.Name = "cmb_weeklyofdays";
            this.cmb_weeklyofdays.Size = new System.Drawing.Size(140, 22);
            this.cmb_weeklyofdays.TabIndex = 2;
            // 
            // chk_Otherholidays
            // 
            this.chk_Otherholidays.AutoSize = true;
            this.chk_Otherholidays.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Otherholidays.Location = new System.Drawing.Point(19, 178);
            this.chk_Otherholidays.Name = "chk_Otherholidays";
            this.chk_Otherholidays.Size = new System.Drawing.Size(131, 18);
            this.chk_Otherholidays.TabIndex = 5;
            this.chk_Otherholidays.Text = "Add Other Holidays";
            this.chk_Otherholidays.UseVisualStyleBackColor = true;
            this.chk_Otherholidays.CheckedChanged += new System.EventHandler(this.chk_Otherholidays_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_Year);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_weeklyofdays);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 149);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common Off Day";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(218, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(137, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_Year
            // 
            this.cmb_Year.FormattingEnabled = true;
            this.cmb_Year.Items.AddRange(new object[] {
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028"});
            this.cmb_Year.Location = new System.Drawing.Point(115, 32);
            this.cmb_Year.Name = "cmb_Year";
            this.cmb_Year.Size = new System.Drawing.Size(139, 22);
            this.cmb_Year.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(67, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Year :";
            // 
            // HolidayCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(851, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chk_Otherholidays);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnl_otherholiday);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "HolidayCalendarForm";
            this.Text = "Off Day  Calendar";
            this.pnl_otherholiday.ResumeLayout(false);
            this.pnl_otherholiday.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_holidaytable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox pnl_otherholiday;
        private System.Windows.Forms.RichTextBox rht_description;
        private System.Windows.Forms.ComboBox cmb_HolidayType;
        private System.Windows.Forms.DateTimePicker dtp_Timepicker;
        private System.Windows.Forms.TextBox txt_holiday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_weeklyofdays;
        private System.Windows.Forms.CheckBox chk_Otherholidays;
        private System.Windows.Forms.DataGridView tbl_holidaytable;
        private System.Windows.Forms.Label lblholidaypk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Year;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
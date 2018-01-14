namespace ATCHRM.Administrator
{
    partial class NotificationForm
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
            this.lbl_birthday = new System.Windows.Forms.LinkLabel();
            this.lnk_Contract = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_closeregistr = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_birthday
            // 
            this.lbl_birthday.AutoSize = true;
            this.lbl_birthday.Font = new System.Drawing.Font("Calibri", 14F);
            this.lbl_birthday.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_birthday.LinkColor = System.Drawing.Color.Red;
            this.lbl_birthday.Location = new System.Drawing.Point(42, 83);
            this.lbl_birthday.Name = "lbl_birthday";
            this.lbl_birthday.Size = new System.Drawing.Size(15, 23);
            this.lbl_birthday.TabIndex = 0;
            this.lbl_birthday.TabStop = true;
            this.lbl_birthday.Text = ".";
            this.lbl_birthday.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_birthday_LinkClicked);
            // 
            // lnk_Contract
            // 
            this.lnk_Contract.AutoSize = true;
            this.lnk_Contract.Font = new System.Drawing.Font("Calibri", 14F);
            this.lnk_Contract.ForeColor = System.Drawing.Color.Maroon;
            this.lnk_Contract.LinkColor = System.Drawing.Color.Red;
            this.lnk_Contract.Location = new System.Drawing.Point(42, 123);
            this.lnk_Contract.Name = "lnk_Contract";
            this.lnk_Contract.Size = new System.Drawing.Size(15, 23);
            this.lnk_Contract.TabIndex = 1;
            this.lnk_Contract.TabStop = true;
            this.lnk_Contract.Text = ".";
            this.lnk_Contract.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Contract_LinkClicked);
            this.lnk_Contract.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnk_Contract_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Day at a glance";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(658, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Skip>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_closeregistr
            // 
            this.lbl_closeregistr.AutoSize = true;
            this.lbl_closeregistr.Font = new System.Drawing.Font("Calibri", 14F);
            this.lbl_closeregistr.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_closeregistr.LinkColor = System.Drawing.Color.Red;
            this.lbl_closeregistr.Location = new System.Drawing.Point(42, 164);
            this.lbl_closeregistr.Name = "lbl_closeregistr";
            this.lbl_closeregistr.Size = new System.Drawing.Size(15, 23);
            this.lbl_closeregistr.TabIndex = 3;
            this.lbl_closeregistr.TabStop = true;
            this.lbl_closeregistr.Text = ".";
            this.lbl_closeregistr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_closeregistr_LinkClicked);
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(739, 440);
            this.Controls.Add(this.lbl_closeregistr);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lnk_Contract);
            this.Controls.Add(this.lbl_birthday);
            this.Name = "NotificationForm";
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbl_birthday;
        private System.Windows.Forms.LinkLabel lnk_Contract;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel lbl_closeregistr;
    }
}
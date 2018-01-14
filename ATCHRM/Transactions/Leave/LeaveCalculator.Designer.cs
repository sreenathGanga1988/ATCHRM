namespace ATCHRM.Transactions.Leave
{
    partial class LeaveCalculator
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
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Leave Type :";
            // 
            // cmb_empcode
            // 
            this.cmb_empcode.FormattingEnabled = true;
            this.cmb_empcode.Location = new System.Drawing.Point(122, 15);
            this.cmb_empcode.Name = "cmb_empcode";
            this.cmb_empcode.Size = new System.Drawing.Size(121, 21);
            this.cmb_empcode.TabIndex = 10;
            this.cmb_empcode.SelectedIndexChanged += new System.EventHandler(this.cmb_empcode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Emp Code : ";
            // 
            // cmb_leave
            // 
            this.cmb_leave.FormattingEnabled = true;
            this.cmb_leave.Location = new System.Drawing.Point(122, 60);
            this.cmb_leave.Name = "cmb_leave";
            this.cmb_leave.Size = new System.Drawing.Size(121, 21);
            this.cmb_leave.TabIndex = 12;
            this.cmb_leave.SelectedIndexChanged += new System.EventHandler(this.cmb_leave_SelectedIndexChanged);
            // 
            // LeaveCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 394);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_empcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_leave);
            this.Name = "LeaveCalculator";
            this.Text = "LeaveCalculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_empcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_leave;
    }
}
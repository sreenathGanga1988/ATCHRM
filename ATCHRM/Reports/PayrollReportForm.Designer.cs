namespace ATCHRM.Reports
{
    partial class PayrollReportForm
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
            this.Grp_searchCriteria = new System.Windows.Forms.GroupBox();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_payroll = new System.Windows.Forms.ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.Grp_searchCriteria.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grp_searchCriteria
            // 
            this.Grp_searchCriteria.Controls.Add(this.button1);
            this.Grp_searchCriteria.Controls.Add(this.cmb_payroll);
            this.Grp_searchCriteria.Controls.Add(this.cmb_dept);
            this.Grp_searchCriteria.Controls.Add(this.label4);
            this.Grp_searchCriteria.Controls.Add(this.label6);
            this.Grp_searchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grp_searchCriteria.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_searchCriteria.Location = new System.Drawing.Point(0, 0);
            this.Grp_searchCriteria.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grp_searchCriteria.Name = "Grp_searchCriteria";
            this.Grp_searchCriteria.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grp_searchCriteria.Size = new System.Drawing.Size(1049, 72);
            this.Grp_searchCriteria.TabIndex = 4;
            this.Grp_searchCriteria.TabStop = false;
            this.Grp_searchCriteria.Text = "Employee Details :";
            // 
            // cmb_dept
            // 
            this.cmb_dept.FormattingEnabled = true;
            this.cmb_dept.Location = new System.Drawing.Point(372, 24);
            this.cmb_dept.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(204, 23);
            this.cmb_dept.TabIndex = 2;
            this.cmb_dept.SelectedIndexChanged += new System.EventHandler(this.cmb_dept_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dept  : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Payroll No";
            // 
            // cmb_payroll
            // 
            this.cmb_payroll.FormattingEnabled = true;
            this.cmb_payroll.Location = new System.Drawing.Point(102, 24);
            this.cmb_payroll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_payroll.Name = "cmb_payroll";
            this.cmb_payroll.Size = new System.Drawing.Size(204, 23);
            this.cmb_payroll.TabIndex = 16;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 72);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1049, 525);
            this.crystalReportViewer1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PayrollReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 597);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.Grp_searchCriteria);
            this.Name = "PayrollReportForm";
            this.Text = "PayrollReportForm";
            this.Load += new System.EventHandler(this.PayrollReportForm_Load);
            this.Grp_searchCriteria.ResumeLayout(false);
            this.Grp_searchCriteria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grp_searchCriteria;
        private System.Windows.Forms.ComboBox cmb_payroll;
        private System.Windows.Forms.ComboBox cmb_dept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button1;
    }
}
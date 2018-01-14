namespace ATCHRM.Payroll
{
    partial class PayrollReportcs
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_payroll = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Grp_searchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // Grp_searchCriteria
            // 
            this.Grp_searchCriteria.Controls.Add(this.button1);
            this.Grp_searchCriteria.Controls.Add(this.cmb_payroll);
            this.Grp_searchCriteria.Controls.Add(this.label6);
            this.Grp_searchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grp_searchCriteria.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_searchCriteria.Location = new System.Drawing.Point(0, 0);
            this.Grp_searchCriteria.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grp_searchCriteria.Name = "Grp_searchCriteria";
            this.Grp_searchCriteria.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grp_searchCriteria.Size = new System.Drawing.Size(919, 72);
            this.Grp_searchCriteria.TabIndex = 5;
            this.Grp_searchCriteria.TabStop = false;
            this.Grp_searchCriteria.Text = "Employee Details :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // ultraGrid1
            // 
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 72);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(919, 395);
            this.ultraGrid1.TabIndex = 6;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // PayrollReportcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 467);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.Grp_searchCriteria);
            this.Name = "PayrollReportcs";
            this.Text = "PayrollReportcs";
            this.Grp_searchCriteria.ResumeLayout(false);
            this.Grp_searchCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grp_searchCriteria;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_payroll;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
    }
}
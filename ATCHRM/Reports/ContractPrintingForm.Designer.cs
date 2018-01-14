namespace ATCHRM.Reports
{
    partial class ContractPrintingForm
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
            this.button4 = new System.Windows.Forms.Button();
            this.cmb_empcode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Crvt_ApplicationReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.cmb_empcode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1021, 63);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applications Summary";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(390, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 33;
            this.button4.Text = "Show";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmb_empcode
            // 
            this.cmb_empcode.FormattingEnabled = true;
            this.cmb_empcode.Location = new System.Drawing.Point(90, 26);
            this.cmb_empcode.Name = "cmb_empcode";
            this.cmb_empcode.Size = new System.Drawing.Size(294, 21);
            this.cmb_empcode.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Emp Code : ";
            // 
            // Crvt_ApplicationReport
            // 
            this.Crvt_ApplicationReport.ActiveViewIndex = -1;
            this.Crvt_ApplicationReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Crvt_ApplicationReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.Crvt_ApplicationReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Crvt_ApplicationReport.Location = new System.Drawing.Point(0, 63);
            this.Crvt_ApplicationReport.Name = "Crvt_ApplicationReport";
            this.Crvt_ApplicationReport.Size = new System.Drawing.Size(1021, 199);
            this.Crvt_ApplicationReport.TabIndex = 4;
            // 
            // ContractPrintingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 262);
            this.Controls.Add(this.Crvt_ApplicationReport);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContractPrintingForm";
            this.Text = "ContractPrintingForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cmb_empcode;
        private System.Windows.Forms.Label label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Crvt_ApplicationReport;
    }
}
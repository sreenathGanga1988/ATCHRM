namespace ATCHRM.Approvals
{
    partial class PayrollConfirmation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollConfirmation));
            this.tbl_payroll = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PayrollID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.totalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incentivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDetailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Btn_cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_printPreview = new System.Windows.Forms.ToolStripButton();
            this.payslipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_payroll)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_payroll
            // 
            this.tbl_payroll.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_payroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_payroll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.PayrollID,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.tbl_payroll.ContextMenuStrip = this.contextMenuStrip1;
            this.tbl_payroll.Location = new System.Drawing.Point(6, 5);
            this.tbl_payroll.Name = "tbl_payroll";
            this.tbl_payroll.Size = new System.Drawing.Size(796, 433);
            this.tbl_payroll.TabIndex = 0;
            this.tbl_payroll.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_payroll_CellDoubleClick);
            this.tbl_payroll.CurrentCellDirtyStateChanged += new System.EventHandler(this.tbl_payroll_CurrentCellDirtyStateChanged);
            this.tbl_payroll.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tbl_payroll_DataError);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Approve";
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // PayrollID
            // 
            this.PayrollID.HeaderText = "Payroll ID";
            this.PayrollID.Name = "PayrollID";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Location";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Department";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fromdate";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "To Date";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "No of People";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Total Amount";
            this.Column6.Name = "Column6";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalToolStripMenuItem,
            this.partimeToolStripMenuItem,
            this.incentivesToolStripMenuItem,
            this.completeNewToolStripMenuItem,
            this.allDetailReportToolStripMenuItem,
            this.bankDetailsToolStripMenuItem,
            this.cashDetailsToolStripMenuItem,
            this.payslipToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 202);
            // 
            // totalToolStripMenuItem
            // 
            this.totalToolStripMenuItem.Name = "totalToolStripMenuItem";
            this.totalToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.totalToolStripMenuItem.Text = "Total";
            this.totalToolStripMenuItem.Click += new System.EventHandler(this.totalToolStripMenuItem_Click);
            // 
            // partimeToolStripMenuItem
            // 
            this.partimeToolStripMenuItem.Name = "partimeToolStripMenuItem";
            this.partimeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.partimeToolStripMenuItem.Text = "Payroll";
            this.partimeToolStripMenuItem.Click += new System.EventHandler(this.partimeToolStripMenuItem_Click);
            // 
            // incentivesToolStripMenuItem
            // 
            this.incentivesToolStripMenuItem.Name = "incentivesToolStripMenuItem";
            this.incentivesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.incentivesToolStripMenuItem.Text = "Incentives";
            this.incentivesToolStripMenuItem.Click += new System.EventHandler(this.incentivesToolStripMenuItem_Click);
            // 
            // completeNewToolStripMenuItem
            // 
            this.completeNewToolStripMenuItem.Name = "completeNewToolStripMenuItem";
            this.completeNewToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.completeNewToolStripMenuItem.Text = "Complete new";
            this.completeNewToolStripMenuItem.Visible = false;
            this.completeNewToolStripMenuItem.Click += new System.EventHandler(this.completeNewToolStripMenuItem_Click);
            // 
            // allDetailReportToolStripMenuItem
            // 
            this.allDetailReportToolStripMenuItem.Name = "allDetailReportToolStripMenuItem";
            this.allDetailReportToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.allDetailReportToolStripMenuItem.Text = "All Detail Report";
            this.allDetailReportToolStripMenuItem.Click += new System.EventHandler(this.allDetailReportToolStripMenuItem_Click);
            // 
            // bankDetailsToolStripMenuItem
            // 
            this.bankDetailsToolStripMenuItem.Name = "bankDetailsToolStripMenuItem";
            this.bankDetailsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bankDetailsToolStripMenuItem.Text = "Bank Details";
            this.bankDetailsToolStripMenuItem.Click += new System.EventHandler(this.bankDetailsToolStripMenuItem_Click);
            // 
            // cashDetailsToolStripMenuItem
            // 
            this.cashDetailsToolStripMenuItem.Name = "cashDetailsToolStripMenuItem";
            this.cashDetailsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.cashDetailsToolStripMenuItem.Text = "Cash Details";
            this.cashDetailsToolStripMenuItem.Click += new System.EventHandler(this.cashDetailsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_cancel,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.btn_printPreview});
            this.toolStrip1.Location = new System.Drawing.Point(0, 443);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Btn_cancel
            // 
            this.Btn_cancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Btn_cancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("Btn_cancel.Image")));
            this.Btn_cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_cancel.Name = "Btn_cancel";
            this.Btn_cancel.Size = new System.Drawing.Size(62, 22);
            this.Btn_cancel.Text = "Cancel";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton1.Text = "Reject";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btn_printPreview
            // 
            this.btn_printPreview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_printPreview.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printPreview.Image = ((System.Drawing.Image)(resources.GetObject("btn_printPreview.Image")));
            this.btn_printPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_printPreview.Name = "btn_printPreview";
            this.btn_printPreview.Size = new System.Drawing.Size(74, 22);
            this.btn_printPreview.Text = "Approve";
            this.btn_printPreview.Click += new System.EventHandler(this.btn_printPreview_Click);
            // 
            // payslipToolStripMenuItem
            // 
            this.payslipToolStripMenuItem.Name = "payslipToolStripMenuItem";
            this.payslipToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.payslipToolStripMenuItem.Text = "Payslip";
            this.payslipToolStripMenuItem.Click += new System.EventHandler(this.payslipToolStripMenuItem_Click);
            // 
            // PayrollConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(802, 468);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbl_payroll);
            this.Name = "PayrollConfirmation";
            this.Text = "Payroll Confirmation";
            ((System.ComponentModel.ISupportInitialize)(this.tbl_payroll)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tbl_payroll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayrollID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Btn_cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btn_printPreview;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem totalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incentivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allDetailReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payslipToolStripMenuItem;
    }
}
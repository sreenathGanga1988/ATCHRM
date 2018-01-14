namespace ATCHRM.HR.NewFolder1
{
    partial class AddEmpEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmpEditForm));
            this.tbl_dgv = new System.Windows.Forms.DataGridView();
            this.Empid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passportnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NHIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MartialStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephonenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_dgv
            // 
            this.tbl_dgv.AllowUserToAddRows = false;
            this.tbl_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empid,
            this.Passportnum,
            this.NID,
            this.NHIF,
            this.NSSF,
            this.FirstName,
            this.LastName,
            this.MartialStatus,
            this.Telephonenum,
            this.Column1,
            this.Column2,
            this.Column3});
            this.tbl_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_dgv.Location = new System.Drawing.Point(0, 0);
            this.tbl_dgv.Name = "tbl_dgv";
            this.tbl_dgv.RowHeadersVisible = false;
            this.tbl_dgv.Size = new System.Drawing.Size(1030, 152);
            this.tbl_dgv.TabIndex = 2;
            // 
            // Empid
            // 
            this.Empid.HeaderText = "Empid";
            this.Empid.Name = "Empid";
            // 
            // Passportnum
            // 
            this.Passportnum.HeaderText = "Passport#";
            this.Passportnum.Name = "Passportnum";
            // 
            // NID
            // 
            this.NID.HeaderText = "NID";
            this.NID.Name = "NID";
            // 
            // NHIF
            // 
            this.NHIF.HeaderText = "NHIF";
            this.NHIF.Name = "NHIF";
            // 
            // NSSF
            // 
            this.NSSF.HeaderText = "NSSF";
            this.NSSF.Name = "NSSF";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // MartialStatus
            // 
            this.MartialStatus.HeaderText = "Martial Status";
            this.MartialStatus.Name = "MartialStatus";
            // 
            // Telephonenum
            // 
            this.Telephonenum.HeaderText = "Telephone#";
            this.Telephonenum.Name = "Telephonenum";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Address1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Address2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mobilenum";
            this.Column3.Name = "Column3";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 127);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1030, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(62, 22);
            this.toolStripButton2.Text = "Cancel";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton3.Text = "Update";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // AddEmpEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 152);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbl_dgv);
            this.Name = "AddEmpEditForm";
            this.Text = "AddEmpEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tbl_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passportnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn NID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NHIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MartialStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephonenum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;

    }
}
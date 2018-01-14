namespace ATCHRM.Master
{
    partial class PerkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerkForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbl_perk = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Adress1 = new System.Windows.Forms.Label();
            this.lbl_BranchName = new System.Windows.Forms.Label();
            this.lbl_Bankname = new System.Windows.Forms.Label();
            this.lbl_pk = new System.Windows.Forms.Label();
            this.txt_taxable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_cancell = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_submitt = new System.Windows.Forms.ToolStripButton();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_perk)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 434);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.tbl_perk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 291);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 44);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Error:";
            // 
            // tbl_perk
            // 
            this.tbl_perk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_perk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_perk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_perk.Location = new System.Drawing.Point(0, 0);
            this.tbl_perk.Name = "tbl_perk";
            this.tbl_perk.RowHeadersVisible = false;
            this.tbl_perk.Size = new System.Drawing.Size(333, 291);
            this.tbl_perk.TabIndex = 0;
            this.tbl_perk.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_perk_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Adress1);
            this.groupBox1.Controls.Add(this.lbl_BranchName);
            this.groupBox1.Controls.Add(this.lbl_Bankname);
            this.groupBox1.Controls.Add(this.lbl_pk);
            this.groupBox1.Controls.Add(this.txt_taxable);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.txt_code);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perk";
            // 
            // lbl_Adress1
            // 
            this.lbl_Adress1.AutoSize = true;
            this.lbl_Adress1.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_Adress1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Adress1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Adress1.Location = new System.Drawing.Point(200, 89);
            this.lbl_Adress1.Name = "lbl_Adress1";
            this.lbl_Adress1.Size = new System.Drawing.Size(13, 15);
            this.lbl_Adress1.TabIndex = 61;
            this.lbl_Adress1.Text = "*";
            this.lbl_Adress1.Visible = false;
            // 
            // lbl_BranchName
            // 
            this.lbl_BranchName.AutoSize = true;
            this.lbl_BranchName.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_BranchName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BranchName.ForeColor = System.Drawing.Color.Red;
            this.lbl_BranchName.Location = new System.Drawing.Point(317, 56);
            this.lbl_BranchName.Name = "lbl_BranchName";
            this.lbl_BranchName.Size = new System.Drawing.Size(13, 15);
            this.lbl_BranchName.TabIndex = 60;
            this.lbl_BranchName.Text = "*";
            this.lbl_BranchName.Visible = false;
            // 
            // lbl_Bankname
            // 
            this.lbl_Bankname.AutoSize = true;
            this.lbl_Bankname.BackColor = System.Drawing.Color.LightBlue;
            this.lbl_Bankname.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bankname.ForeColor = System.Drawing.Color.Red;
            this.lbl_Bankname.Location = new System.Drawing.Point(206, 24);
            this.lbl_Bankname.Name = "lbl_Bankname";
            this.lbl_Bankname.Size = new System.Drawing.Size(13, 15);
            this.lbl_Bankname.TabIndex = 59;
            this.lbl_Bankname.Text = "*";
            this.lbl_Bankname.Visible = false;
            // 
            // lbl_pk
            // 
            this.lbl_pk.AutoSize = true;
            this.lbl_pk.Location = new System.Drawing.Point(200, 22);
            this.lbl_pk.Name = "lbl_pk";
            this.lbl_pk.Size = new System.Drawing.Size(0, 13);
            this.lbl_pk.TabIndex = 32;
            // 
            // txt_taxable
            // 
            this.txt_taxable.Location = new System.Drawing.Point(94, 87);
            this.txt_taxable.Name = "txt_taxable";
            this.txt_taxable.Size = new System.Drawing.Size(100, 20);
            this.txt_taxable.TabIndex = 31;
            this.txt_taxable.Text = "0";
            this.txt_taxable.TextChanged += new System.EventHandler(this.txt_taxable_TextChanged);
            this.txt_taxable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_taxable_KeyPress);
            this.txt_taxable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_taxable_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Taxable % : ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SeaShell;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_cancell,
            this.toolStripSeparator1,
            this.btn_submitt});
            this.toolStrip1.Location = new System.Drawing.Point(3, 115);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(327, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_cancell
            // 
            this.btn_cancell.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_cancell.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancell.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancell.Image")));
            this.btn_cancell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancell.Name = "btn_cancell";
            this.btn_cancell.Size = new System.Drawing.Size(62, 22);
            this.btn_cancell.Text = "Cancel";
            this.btn_cancell.Click += new System.EventHandler(this.btn_cancell_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_submitt
            // 
            this.btn_submitt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_submitt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submitt.Image = ((System.Drawing.Image)(resources.GetObject("btn_submitt.Image")));
            this.btn_submitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_submitt.Name = "btn_submitt";
            this.btn_submitt.Size = new System.Drawing.Size(52, 22);
            this.btn_submitt.Text = "Add ";
            this.btn_submitt.Click += new System.EventHandler(this.btn_submitt_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(94, 55);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(221, 20);
            this.txt_name.TabIndex = 3;
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(94, 22);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(100, 20);
            this.txt_code.TabIndex = 2;
            this.txt_code.TextChanged += new System.EventHandler(this.txt_code_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code : ";
            // 
            // PerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 434);
            this.Controls.Add(this.panel1);
            this.Name = "PerkForm";
            this.Text = "PerkForm";
            this.Load += new System.EventHandler(this.PerkForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_perk)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_cancell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_submitt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tbl_perk;
        private System.Windows.Forms.TextBox txt_taxable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_pk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lbl_Bankname;
        private System.Windows.Forms.Label lbl_Adress1;
        private System.Windows.Forms.Label lbl_BranchName;
    }
}
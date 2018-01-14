namespace ATCHRM.Applications
{
    partial class NonApprovedRecruitmentApllicationForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbl_recruitmentdata = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_recruitmentdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbl_recruitmentdata);
            this.groupBox2.Location = new System.Drawing.Point(1, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 359);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "  Recruitment Applications";
            // 
            // tbl_recruitmentdata
            // 
            this.tbl_recruitmentdata.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_recruitmentdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_recruitmentdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_recruitmentdata.Location = new System.Drawing.Point(3, 16);
            this.tbl_recruitmentdata.Name = "tbl_recruitmentdata";
            this.tbl_recruitmentdata.RowHeadersVisible = false;
            this.tbl_recruitmentdata.Size = new System.Drawing.Size(982, 340);
            this.tbl_recruitmentdata.TabIndex = 0;
            // 
            // NonApprovedRecruitmentApllicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(991, 376);
            this.Controls.Add(this.groupBox2);
            this.Name = "NonApprovedRecruitmentApllicationForm";
            this.Text = " Approved Recruitment Apllication";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_recruitmentdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tbl_recruitmentdata;
    }
}
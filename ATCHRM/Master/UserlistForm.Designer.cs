namespace ATCHRM.Master
{
    partial class UserlistForm
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
            this.tbl_userlist = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_userlist)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_userlist
            // 
            this.tbl_userlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_userlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_userlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_userlist.Location = new System.Drawing.Point(0, 0);
            this.tbl_userlist.Name = "tbl_userlist";
            this.tbl_userlist.Size = new System.Drawing.Size(833, 322);
            this.tbl_userlist.TabIndex = 0;
            // 
            // UserlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 322);
            this.Controls.Add(this.tbl_userlist);
            this.Name = "UserlistForm";
            this.Text = "User List ";
            this.Load += new System.EventHandler(this.UserlistForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_userlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tbl_userlist;
    }
}
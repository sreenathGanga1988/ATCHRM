namespace ATCHRM.Master
{
    partial class ShiftDetailsMasterForm
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
            this.tbl_shiftdata = new ATCHRM.MergeDatagridview();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_shiftdata)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_shiftdata
            // 
            this.tbl_shiftdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_shiftdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_shiftdata.Location = new System.Drawing.Point(5, 12);
            this.tbl_shiftdata.Name = "tbl_shiftdata";
            this.tbl_shiftdata.Size = new System.Drawing.Size(836, 481);
            this.tbl_shiftdata.TabIndex = 0;
            // 
            // ShiftDetailsMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 497);
            this.Controls.Add(this.tbl_shiftdata);
            this.Name = "ShiftDetailsMasterForm";
            this.Text = "Shift Details";
            ((System.ComponentModel.ISupportInitialize)(this.tbl_shiftdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MergeDatagridview tbl_shiftdata;
    }
}
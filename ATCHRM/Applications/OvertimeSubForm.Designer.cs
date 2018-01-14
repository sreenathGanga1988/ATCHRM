namespace ATCHRM.Applications
{
    partial class OvertimeSubForm
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
            this.tbl_LH = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.tbl_Abscent = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_lh = new System.Windows.Forms.Label();
            this.lbl_leave = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_LH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Abscent)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_LH
            // 
            this.tbl_LH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_LH.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_LH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_LH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.tbl_LH.Location = new System.Drawing.Point(196, 58);
            this.tbl_LH.Name = "tbl_LH";
            this.tbl_LH.RowHeadersVisible = false;
            this.tbl_LH.Size = new System.Drawing.Size(142, 212);
            this.tbl_LH.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "EmpCode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(42, 276);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(243, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "Continue";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tbl_Abscent
            // 
            this.tbl_Abscent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_Abscent.BackgroundColor = System.Drawing.Color.LightBlue;
            this.tbl_Abscent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Abscent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3});
            this.tbl_Abscent.Location = new System.Drawing.Point(15, 58);
            this.tbl_Abscent.Name = "tbl_Abscent";
            this.tbl_Abscent.RowHeadersVisible = false;
            this.tbl_Abscent.Size = new System.Drawing.Size(144, 212);
            this.tbl_Abscent.TabIndex = 1;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "EmpCode";
            this.Column3.Name = "Column3";
            // 
            // lbl_lh
            // 
            this.lbl_lh.AutoSize = true;
            this.lbl_lh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lh.Location = new System.Drawing.Point(319, 32);
            this.lbl_lh.Name = "lbl_lh";
            this.lbl_lh.Size = new System.Drawing.Size(14, 15);
            this.lbl_lh.TabIndex = 24;
            this.lbl_lh.Text = "0";
            // 
            // lbl_leave
            // 
            this.lbl_leave.AutoSize = true;
            this.lbl_leave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_leave.Location = new System.Drawing.Point(99, 32);
            this.lbl_leave.Name = "lbl_leave";
            this.lbl_leave.Size = new System.Drawing.Size(14, 15);
            this.lbl_leave.TabIndex = 23;
            this.lbl_leave.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(197, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 15);
            this.label15.TabIndex = 22;
            this.label15.Text = "Lost Hour Holders  :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 15);
            this.label16.TabIndex = 21;
            this.label16.Text = "Abscenties :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(267, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "Your Application Consist Of Below Descripancies";
            // 
            // OvertimeSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(342, 311);
            this.Controls.Add(this.tbl_LH);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.tbl_Abscent);
            this.Controls.Add(this.lbl_lh);
            this.Controls.Add(this.lbl_leave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OvertimeSubForm";
            this.Text = "Overtime Details";
            ((System.ComponentModel.ISupportInitialize)(this.tbl_LH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Abscent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tbl_LH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView tbl_Abscent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label lbl_lh;
        private System.Windows.Forms.Label lbl_leave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}
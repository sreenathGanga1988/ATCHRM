using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class AdvanceMasterForm : Form
    {
        Transactions.Approvalview.AdvanceApplication cntrctapprview = null;
        public AdvanceMasterForm()
        {
            InitializeComponent();
            cntrctapprview = new Transactions.Approvalview.AdvanceApplication();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Applications.AdvanceApplicationForm advnce = null;
         //   advnce = new AdvanceApplicationForm();
            advnce = new Applications.AdvanceApplicationForm();
            advnce.MdiParent = this.MdiParent;
            advnce.StartPosition = FormStartPosition.CenterScreen;
            advnce.Show();
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void Grid_View()
        {
            DataTable dt = new DataTable();
            dataGridView2.RowCount = 0;
            dataGridView1.RowCount = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                dt = cntrctapprview.GetAllAdvance (0);

               


                if(dt!=null)
                {


                    if (dt.Rows.Count != 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                            dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();

                            dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                            dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                            dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                            dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                            dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][7].ToString();
                            dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][8].ToString();
                        }

                    }

                }

            }
            else if (tabControl1.SelectedIndex == 1)
            {

                dt = cntrctapprview.GetAllAdvance(1);

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView2.Rows.Add();
                            dataGridView2.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                            dataGridView2.Rows[i].Cells[2].Value = dt.Rows[i][1].ToString();

                            dataGridView2.Rows[i].Cells[3].Value = dt.Rows[i][2].ToString();
                            dataGridView2.Rows[i].Cells[4].Value = dt.Rows[i][3].ToString();
                            dataGridView2.Rows[i].Cells[5].Value = dt.Rows[i][4].ToString();
                            dataGridView2.Rows[i].Cells[6].Value = dt.Rows[i][5].ToString();
                            dataGridView2.Rows[i].Cells[7].Value = dt.Rows[i][6].ToString();
                            dataGridView2.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                        }

                    }

                }




            }










        }

        private void AdvanceMasterForm_Load(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid_View();
        }
        int chos = 0;
      
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[0].Value) == "")
                    {
                        chos = 1;
                        dataGridView2.Rows[e.RowIndex].Cells[0].Value = "✓";
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else if (Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[0].Value) == "✓")
                    {
                        chos = 0;
                        dataGridView2.Rows[e.RowIndex].Cells[0].Value = "";
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

                    }

                }
            }
        
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (chos == 0)
            {
                MessageBox.Show("Nothing Selected", "ATCHRM MASTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Are You Sure To Remove From List", "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (Convert.ToString(dataGridView2.Rows[i].Cells[0].Value) == "✓")
                    {
                        cntrctapprview.removefromlist(int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString()));
                    }
                }

                Grid_View();
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {

        }











    }
}

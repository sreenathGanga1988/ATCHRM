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
    public partial class LeaveEncashmentMaster : Form
    {
        Transactions.Approvalview.leaveencashview cntrctapprview = null;
        public LeaveEncashmentMaster()
        {
            InitializeComponent();
            cntrctapprview = new Transactions.Approvalview.leaveencashview();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Applications.LeaveEnchasementForm lvenfrm = null;
           
                lvenfrm = new Applications.LeaveEnchasementForm();
                lvenfrm.MdiParent = this.MdiParent ;
                lvenfrm.StartPosition = FormStartPosition.CenterScreen;
                lvenfrm.Show();
            }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void Grid_View()
        {
            DataTable dt = new DataTable();
            dataGridView1.RowCount = 0;
            dataGridView2.RowCount = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                dt = cntrctapprview.getAllEncashData (0);





                if(dt!=null)
                {

                    if (dt.Rows.Count != 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0];
                            dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1];
                            dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2];
                            dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3];
                            dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4];
                            dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5];
                            dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6];
                            dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7];
                            //dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][8];
                            //dataGridView1.Rows[i].Cells[10].Value = dt.Rows[i][9];
                            //dataGridView1.Rows[i].Cells[11].Value = dt.Rows[i][10];

                        }

                    }

                }

            }
            else if (tabControl1.SelectedIndex == 1)
            {

                dt = cntrctapprview.getAllEncashData(1);
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView2.Rows.Add();
                            dataGridView2.Rows.Add();
                            dataGridView2.Rows[i].Cells[1].Value = dt.Rows[i][0];
                            dataGridView2.Rows[i].Cells[2].Value = dt.Rows[i][1];
                            dataGridView2.Rows[i].Cells[3].Value = dt.Rows[i][2];
                            dataGridView2.Rows[i].Cells[4].Value = dt.Rows[i][3];
                            dataGridView2.Rows[i].Cells[5].Value = dt.Rows[i][4];
                            dataGridView2.Rows[i].Cells[6].Value = dt.Rows[i][5];
                            dataGridView2.Rows[i].Cells[7].Value = dt.Rows[i][6];
                            dataGridView2.Rows[i].Cells[8].Value = dt.Rows[i][7];
                            //dataGridView2.Rows[i].Cells[9].Value = dt.Rows[i][8];
                            //dataGridView2.Rows[i].Cells[10].Value = dt.Rows[i][9];
                            //dataGridView2.Rows[i].Cells[11].Value = dt.Rows[i][10];
                        }

                    }

                }




            }










        }
        int chos = 0;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void LeaveEncashmentMaster_Load(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }
    
    }
    
}

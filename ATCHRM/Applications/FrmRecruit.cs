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
    public partial class FrmRecruit : Form
    {
        Transactions.RecruitApplicationTransaction rcrtapptrans = new Transactions.RecruitApplicationTransaction();
        public FrmRecruit()
        {
            InitializeComponent();
            rcrtapptrans = new Transactions.RecruitApplicationTransaction();
        }

        private void FrmRecruit_Load(object sender, EventArgs e)
        {
            Grid_View();
        }



        private void Grid_View()
        {
            DataTable dt = new DataTable();
            dataGridView2.RowCount = 0;
            dataGridView1.RowCount = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                dt = rcrtapptrans.GetAllApllicationStatus ();







                if (dt != null)
                {
                    dataGridView1 .Rows.Clear();
                    dataGridView1.DataSource = null;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0];//sl
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1];//aapnum
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2];//desg
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3];//dept
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4];//branch
                        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5];//vaccancy
                        dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6];  //
                        dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7];//
                        dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][8];//
                     //   dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][9];
                      //  dataGridView1.Rows[i].Cells[10].Value = dt.Rows[i][12];



                    }
                    filterdata();
                }

            }
            else if (tabControl1.SelectedIndex == 1)
            {
                dt = rcrtapptrans.getallApprovedRecruitmentAppData();
                if (dt != null)
                {
                    dataGridView2 .Rows.Clear();
                    dataGridView2.DataSource = null;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[1].Value = dt.Rows[i][0];
                        dataGridView2.Rows[i].Cells[2].Value = dt.Rows[i][1];
                        dataGridView2.Rows[i].Cells[3].Value = dt.Rows[i][2];
                        dataGridView2.Rows[i].Cells[4].Value = dt.Rows[i][3];
                        dataGridView2.Rows[i].Cells[5].Value = dt.Rows[i][4];
                        dataGridView2.Rows[i].Cells[6].Value = dt.Rows[i][5];
                        dataGridView2.Rows[i].Cells[7].Value = dt.Rows[i][6];
                        dataGridView2.Rows[i].Cells[8].Value = dt.Rows[i][7];
                        dataGridView2.Rows[i].Cells[9].Value = dt.Rows[i][8];


                    }
                }






            }










        }


        public void filterdata()
        {
            for (int i = 0; i < dataGridView1 .Rows.Count - 2; i++)
            {

                //if (dataGridView1.Rows[i].Cells[5].Value.ToString() != dataGridView1.Rows[i].Cells[10].Value.ToString())
                //{
                //    dataGridView1.Rows.RemoveAt(i);
                //}
            }
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
                        rcrtapptrans.removefromlist(int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString()));
                    }
                }

                Grid_View();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).newrecruitment();
        }





    }
}

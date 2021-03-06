﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class FrmDeactivation : Form
    {
        Transactions.Approvalview.Deactvationview  cntrctapprview = null;
        public FrmDeactivation()
        {
            InitializeComponent();
            cntrctapprview = new Transactions.Approvalview.Deactvationview();
        }




        private void Grid_View()
        {
            DataTable dt = new DataTable();
            dataGridView1.RowCount = 0;
            dataGridView2.RowCount = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                dt = cntrctapprview.getAllDeactivationData (0);







                if (dt.Rows.Count != 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][0];
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][1];
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][2];
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][3];
                        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][4];
                        dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][5];
                        dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][6];
                        dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][7];
                        dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][8];
                        dataGridView1.Rows[i].Cells[10].Value = dt.Rows[i][9];
                        dataGridView1.Rows[i].Cells[11].Value = dt.Rows[i][10];
                        
                    }



                }

            }
            else if (tabControl1.SelectedIndex == 1)
            {

                dt = cntrctapprview.getAllDeactivationData(1);
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
                            dataGridView2.Rows[i].Cells[9].Value = dt.Rows[i][8];
                            dataGridView2.Rows[i].Cells[10].Value = dt.Rows[i][9];
                            dataGridView2.Rows[i].Cells[11].Value = dt.Rows[i][10];
                        }

                    }

                }




            }










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

        private void FrmDeactivation_Load(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).employeedeactivate();
           
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












    }
}

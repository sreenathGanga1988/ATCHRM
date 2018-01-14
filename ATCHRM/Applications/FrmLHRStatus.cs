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
    public partial class FrmLHRStatus : Form
    {
        public FrmLHRStatus()
        {
            InitializeComponent();
        }

        private void Grid_View()
        {

            string qry = "";
            if (tabControl1.SelectedIndex == 0)
            {
                qry = "SELECT     COUNT(LHRApplicationMaster_tbl.Appnum) AS Expr1, LHRApplicationMaster_tbl.DateOfLHR,"
                +" LHRApplicationMaster_tbl.IsLevel1, LHRApplicationMaster_tbl.Reason, "
                      + " LHRApplicationMaster_tbl.Islevel2, LHRApplicationMaster_tbl.Appnum, LHRApplicationMaster_tbl.LHRApPK, "
                      +" LHRApplicationMaster_tbl.DateAdded,LHRDetails_tbl.LHRAppK AS Expr2, LHRApplicationMaster_tbl.Islevel3 "
+" FROM         LHRApplicationMaster_tbl INNER JOIN "
                      + " LHRDetails_tbl ON LHRApplicationMaster_tbl.LHRApPK = LHRDetails_tbl.LHRAppK WHERE     (LHRApplicationMaster_tbl.Islevel3 = 'N') "
+" GROUP BY LHRApplicationMaster_tbl.DateOfLHR, LHRApplicationMaster_tbl.IsLevel1, LHRApplicationMaster_tbl.Reason, LHRApplicationMaster_tbl.Islevel2, "
                      + " LHRApplicationMaster_tbl.Appnum, LHRApplicationMaster_tbl.LHRApPK, LHRApplicationMaster_tbl.DateAdded, "
                      + " LHRDetails_tbl.LHRAppK, LHRApplicationMaster_tbl.Islevel3";

                DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                dataGridView1.RowCount = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][5];//APPln no
                        dataGridView1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][0];//App Count
                        dataGridView1.Rows[i].Cells[2].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][7]).ToString("dd/MMM/yyyy");//date added
                        dataGridView1.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][1]).ToString("dd/MMM/yyyy");//date of lhr
                        dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][3];//Reason
                        dataGridView1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][2];//level1
                        dataGridView1.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][4];//level 2
                        dataGridView1.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][6];//Apppk
                        dataGridView1.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][8];//Det Pk
                    }

                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                qry = "SELECT     COUNT(LHRApplicationMaster_tbl.Appnum) AS Expr1, LHRApplicationMaster_tbl.DateOfLHR,"
                + " LHRApplicationMaster_tbl.IsLevel1, LHRApplicationMaster_tbl.Reason, "
                      + " LHRApplicationMaster_tbl.Islevel2, LHRApplicationMaster_tbl.Appnum, LHRApplicationMaster_tbl.LHRApPK, "
                      + " LHRApplicationMaster_tbl.DateAdded,LHRDetails_tbl.LHRAppK AS Expr2, LHRApplicationMaster_tbl.Islevel3 "
+ " FROM         LHRApplicationMaster_tbl INNER JOIN "
                      + " LHRDetails_tbl ON LHRApplicationMaster_tbl.LHRApPK = LHRDetails_tbl.LHRAppK WHERE (LHRApplicationMaster_tbl.Islevel3 = 'A') and Display_Hide='Y'"
+ " GROUP BY LHRApplicationMaster_tbl.DateOfLHR, LHRApplicationMaster_tbl.IsLevel1, LHRApplicationMaster_tbl.Reason, LHRApplicationMaster_tbl.Islevel2, "
                      + " LHRApplicationMaster_tbl.Appnum, LHRApplicationMaster_tbl.LHRApPK, LHRApplicationMaster_tbl.DateAdded, "
                      +" LHRDetails_tbl.LHRAppK, LHRApplicationMaster_tbl.Islevel3";

                DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                dataGridView2.RowCount = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                   
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][5];//APPln no
                        dataGridView2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][0];//App Count
                        dataGridView2.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][7]).ToString("dd/MMM/yyyy");//date added
                        dataGridView2.Rows[i].Cells[4].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][1]).ToString("dd/MMM/yyyy");//date of lhr
                        dataGridView2.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][3];//Reason
                        dataGridView2.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][2];//level1
                        dataGridView2.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][4];//level 2
                        dataGridView2.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][9];//level 3
                        dataGridView2.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i][6];//Apppk
                    }

                }
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void FrmLHRStatus_Load(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid_View();
        }

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

        int chos = 0;
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
                        GridViewmModels.ClsDatabase.Set_Data("update LHRApplicationMaster_tbl set Display_Hide='N' where "
                            + " LHRApPK=" + dataGridView2.Rows[i].Cells[9].Value + "");
                    }
                }

                Grid_View();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (chos == 0)
            {
                MessageBox.Show("Nothing Selected", "ATCHRM MASTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("Are You Sure To Cancel", "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Grid_View();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Applications.LostHourRecoveryForm Lhrform = null;
            //bool isFormOpen = IsAlreadyOpen(typeof(Applications.LostHourRecoveryForm));
             
                Lhrform = new Applications.LostHourRecoveryForm();
                Lhrform.MdiParent = this.MdiParent;
                Lhrform.StartPosition = FormStartPosition.CenterScreen;
                Lhrform.Show();
                this.Close();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

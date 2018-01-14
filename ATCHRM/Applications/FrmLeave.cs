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
    public partial class FrmLeave : Form
    {
        public FrmLeave()
        {
            InitializeComponent();
        }

      

        private void FrmLeave_Load(object sender, EventArgs e)
        {
            Grid_View();
        }

        public void Grid_View()
        {

            string qry = "";
            if (tabControl1.SelectedIndex == 0)
            {
                qry = "SELECT     LeaveApplicationMaster.LeaveAppPk, LeaveApprovalMaster_tbl.Islevel1, LeaveApprovalMaster_tbl.Islevel2,"
                + "LeaveApprovalMaster_tbl.Islevel3,LeaveApplicationMaster.Fromdate, LeaveApplicationMaster.LvAppnum,"
                + " LeaveApplicationMaster.Empid, EmployeePersonalMaster_tbl.First_name, "
                + "      EmployeePersonalMaster_tbl.Last_Name, LeaveApplicationMaster.LeavePK, LeaveMaster_tbl.LeaveName, LeaveApplicationMaster.Duration "
+ " FROM         LeaveApplicationMaster INNER JOIN "
                     + " LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk INNER JOIN "
                  + "    EmployeePersonalMaster_tbl ON LeaveApplicationMaster.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN "
                    + "  LeaveMaster_tbl ON LeaveApplicationMaster.LeavePK = LeaveMaster_tbl.LeavePk "
+ " WHERE     (LeaveApprovalMaster_tbl.Islevel3 = 'N')";

                DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                dataGridView1.RowCount = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][5];//APPln no
                        dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(ds.Tables[0].Rows[i][7]) + " " + Convert.ToString(ds.Tables[0].Rows[i][8]);//Emp Name
                        dataGridView1.Rows[i].Cells[2].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][4]).ToString("dd/MMM/yyyy");//date added
                        dataGridView1.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][10]; //date of lhr
                        dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][11];//Reason
                        dataGridView1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][1];//level1
                        dataGridView1.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][2];//level 2
                        dataGridView1.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][6];//Emp Id
                        dataGridView1.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][0];//Det Pk
                    }

                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                qry = "SELECT     LeaveApplicationMaster.LeaveAppPk, LeaveApprovalMaster_tbl.Islevel1, LeaveApprovalMaster_tbl.Islevel2,"
                + "LeaveApprovalMaster_tbl.Islevel3,LeaveApplicationMaster.Fromdate, LeaveApplicationMaster.LvAppnum,"
                + " LeaveApplicationMaster.Empid, EmployeePersonalMaster_tbl.First_name, "
                + "      EmployeePersonalMaster_tbl.Last_Name, LeaveApplicationMaster.LeavePK, LeaveMaster_tbl.LeaveName, LeaveApplicationMaster.Duration "
+ " FROM         LeaveApplicationMaster INNER JOIN "
                     + " LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk INNER JOIN "
                  + "    EmployeePersonalMaster_tbl ON LeaveApplicationMaster.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN "
                    + "  LeaveMaster_tbl ON LeaveApplicationMaster.LeavePK = LeaveMaster_tbl.LeavePk "
+ " WHERE     (LeaveApprovalMaster_tbl.Islevel3 = 'A' and Display_Hide='Y')";

                DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                dataGridView2.RowCount = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][5];//APPln no
                        dataGridView2.Rows[i].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[i][7]) + " " + Convert.ToString(ds.Tables[0].Rows[i][8]);//App Count
                        dataGridView2.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][4]).ToString("dd/MMM/yyyy");//date added
                        dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][10];//date of lhr
                        dataGridView2.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][11];//Reason
                        dataGridView2.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][1];//level1
                        dataGridView2.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][2];//level 2
                        dataGridView2.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][3];//level 3
                        dataGridView2.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i][0];//Apppk
                        dataGridView2.Rows[i].Cells[10].Value = ds.Tables[0].Rows[i][6];
                    }

                }
            }


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Applications.LeaveApplicationForm lvappfrm = null;
             
                lvappfrm = new Applications.LeaveApplicationForm();
                lvappfrm.StartPosition = FormStartPosition.CenterScreen;
                lvappfrm.MdiParent = this.MdiParent;
                lvappfrm.Show();
                this.Close();
             
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        GridViewmModels.ClsDatabase.Set_Data("update LeaveApplicationMaster set Display_Hide='N' where "
                            + " LeaveAppPk=" + dataGridView2.Rows[i].Cells[9].Value + "");
                    }
                }
                chos = 0;
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
            chos = 0;
        }
    }
}

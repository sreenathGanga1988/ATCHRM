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
    public partial class FrmOtShow : Form
    {
        public FrmOtShow()
        {
            InitializeComponent();
        }

        private void FrmOtShow_Load(object sender, EventArgs e)
        {
            Grid_View();
        }

        private string[] Emp_Count(int otapppk )
        {
            string[] count=new string[3];
            DataSet ds=GridViewmModels.ClsDatabase.Get_Data("select count(OTAppPK), ottype from OtApplicationDetails_tbl "
                + " where OTAppPK=" + otapppk + " group by OTAppPK,ottype");
            if (ds.Tables[0].Rows.Count > 0)
            {
                count[0] = Convert.ToString(ds.Tables[0].Rows[0][0]);
                count[1] = Convert.ToString(ds.Tables[0].Rows[0][1]);
            }
            return count;
        }

        private void Grid_View()
        {
           
            string qry ="";
                if(tabControl1.SelectedIndex==0)
                {
//                    qry = "SELECT     OTApproval_tbl.ApprovalPk, OTApproval_tbl.OTAppPK, OTApproval_tbl.IsLevel1,"
//            +" OTApproval_tbl.Islevel2, OTApproval_tbl.Islevel3, "
//                      +" EmployeePersonalMaster_tbl.First_name, EmployeePersonalMaster_tbl.Last_Name,"
//            +" EmployeePersonalMaster_tbl.empno, OtApplicationMaster_tbl.OTDate,OtApplicationDetails_tbl.OtType "
//+" FROM OTApproval_tbl INNER JOIN OtApplicationMaster_tbl ON OTApproval_tbl.OTAppPK = OtApplicationMaster_tbl.OTAppPK INNER JOIN "
//                      +" OtApplicationDetails_tbl ON OtApplicationMaster_tbl.OTAppPK = OtApplicationDetails_tbl.OtAppPK INNER JOIN "
//                      + " EmployeePersonalMaster_tbl ON OtApplicationDetails_tbl.empid = EmployeePersonalMaster_tbl.empid where OTApproval_tbl.Islevel2 = 'N'  "
//                    + " and OtApplicationMaster_tbl.BranchLocationPk=" + Program.LOCTNPK + " and hide_display='R' ";

                    qry = "SELECT     OTApproval_tbl.ApprovalPk, OTApproval_tbl.OTAppPK, OTApproval_tbl.IsLevel1,"
                    +" OTApproval_tbl.Islevel2, OTApproval_tbl.Islevel3, OtApplicationMaster_tbl.OTDate, "
                      +" OtApplicationMaster_tbl.Otreason, OtApplicationMaster_tbl.OtAppnum FROM OTApproval_tbl INNER JOIN "
                      +" OtApplicationMaster_tbl ON OTApproval_tbl.OTAppPK = OtApplicationMaster_tbl.OTAppPK "
+ " WHERE  (OTApproval_tbl.Iscompleted='N') AND  (OTApproval_tbl.Islevel2 = 'N') AND (OtApplicationMaster_tbl.BranchLocationPk = " + Program.LOCTNPK + ") AND (OTApproval_tbl.Hide_Display = 'R')";


                    DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataGridView1.RowCount = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][7];//emp no
                            //dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(ds.Tables[0].Rows[i][5]) + Convert.ToString(ds.Tables[0].Rows[i][6]);//emp name
                            string[] valg = Emp_Count(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
                            dataGridView1.Rows[i].Cells[1].Value = valg[0];
                            //dataGridView1.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][9];//ot type
                            dataGridView1.Rows[i].Cells[2].Value = valg[1];
                            dataGridView1.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][5]).ToString("dd/MMM/yyyy");//ot date
                            dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][2];//level 1
                            dataGridView1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][3];//level 2
                            dataGridView1.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][4];//level 3
                            dataGridView1.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][1];//ot pk
                            dataGridView1.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][0];//appr pk
                        }

                    }
                }
                else if (tabControl1.SelectedIndex == 1)
                {
//                    qry = "SELECT     OTApproval_tbl.ApprovalPk, OTApproval_tbl.OTAppPK, OTApproval_tbl.IsLevel1,"
//            + " OTApproval_tbl.Islevel2, OTApproval_tbl.Islevel3, "
//                      + " EmployeePersonalMaster_tbl.First_name, EmployeePersonalMaster_tbl.Last_Name,"
//            + " EmployeePersonalMaster_tbl.empno, OtApplicationMaster_tbl.OTDate,OtApplicationDetails_tbl.OtType "
//+ " FROM OTApproval_tbl INNER JOIN OtApplicationMaster_tbl ON OTApproval_tbl.OTAppPK = OtApplicationMaster_tbl.OTAppPK INNER JOIN "
//                      + " OtApplicationDetails_tbl ON OtApplicationMaster_tbl.OTAppPK = OtApplicationDetails_tbl.OtAppPK INNER JOIN "
//                      + " EmployeePersonalMaster_tbl ON OtApplicationDetails_tbl.empid = EmployeePersonalMaster_tbl.empid WHERE (OTApproval_tbl.Islevel2 = 'A')"
//                      + "and OtApplicationMaster_tbl.BranchLocationPk=" + Program.LOCTNPK + " and hide_display='R' ";
 
                    qry = "SELECT     OTApproval_tbl.ApprovalPk, OTApproval_tbl.OTAppPK, OTApproval_tbl.IsLevel1,"
                   + " OTApproval_tbl.Islevel2, OTApproval_tbl.Islevel3, OtApplicationMaster_tbl.OTDate, "
                     + " OtApplicationMaster_tbl.Otreason, OtApplicationMaster_tbl.OtAppnum FROM OTApproval_tbl INNER JOIN "
                     + " OtApplicationMaster_tbl ON OTApproval_tbl.OTAppPK = OtApplicationMaster_tbl.OTAppPK "
+ " WHERE   (OTApproval_tbl.Iscompleted<> N'N')  AND (OtApplicationMaster_tbl.BranchLocationPk = " + Program.LOCTNPK + ") AND (OTApproval_tbl.Hide_Display = 'R')";

                    DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataGridView2.RowCount = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dataGridView2.Rows.Add();
                            dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][7];//emp no
                            //dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(ds.Tables[0].Rows[i][5]) + Convert.ToString(ds.Tables[0].Rows[i][6]);//emp name
                            string[] valg = Emp_Count(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
                            dataGridView2.Rows[i].Cells[2].Value = valg[0];
                            //dataGridView1.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][9];//ot type
                            dataGridView2.Rows[i].Cells[3].Value = valg[1];
                            dataGridView2.Rows[i].Cells[4].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][5]).ToString("dd/MMM/yyyy"); ;//ot date
                            dataGridView2.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][2];//level 1
                            dataGridView2.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][3];//level 2
                            dataGridView2.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][4];//level 3
                            dataGridView2.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][1];//ot pk
                            dataGridView2.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i][0];//appr pk
                        }

                    }
                }

          
        }

       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid_View();
        }

        

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    if (e.ColumnIndex == 9)
            //    {
            //        button1.Top = dataGridView2.DisplayRectangle.Top;
            //        button1.Width = dataGridView2.DisplayRectangle.Width;
 
            //    }
            //}
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
                        GridViewmModels.ClsDatabase.Set_Data("update OTApproval_tbl set hide_display='Y' where "
                            + " otapppk="+ dataGridView2.Rows[i].Cells[8].Value +" and "
                        + " ApprovalPk= " + dataGridView2.Rows[i].Cells[9].Value + "");
                    }
                }

                Grid_View();
            }
           
        }

        int chos = 0;

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (chos == 0)
            {
                MessageBox.Show("Nothing Selected", "ATCHRM MASTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("Are You Sure To Cancel", "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    Grid_View();
                    //if (Convert.ToString(dataGridView2.Rows[i].Cells[0].Value) == "✓")
                    //{
                    //    dataGridView2.Rows[i].Cells[0].Value = "";
                    //    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Applications.OVertimeApplicationMaster ovtmstrfrm = new Applications.OVertimeApplicationMaster();
            ovtmstrfrm.MdiParent = this.MdiParent; 
            ovtmstrfrm.Show();
            this.Close();
          
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox2.Visible = true;
            if (tabControl1.SelectedIndex == 1)
            {
              string  qry = "SELECT     OTApproval_tbl.ApprovalPk, OTApproval_tbl.OTAppPK, OTApproval_tbl.IsLevel1,"
        + " OTApproval_tbl.Islevel2, OTApproval_tbl.Islevel3, "
                  + " EmployeePersonalMaster_tbl.First_name, EmployeePersonalMaster_tbl.Last_Name,"
        + " EmployeePersonalMaster_tbl.empno, OtApplicationMaster_tbl.OTDate,OtApplicationDetails_tbl.OtType "
+ " FROM OTApproval_tbl INNER JOIN OtApplicationMaster_tbl ON OTApproval_tbl.OTAppPK = OtApplicationMaster_tbl.OTAppPK INNER JOIN "
                  + " OtApplicationDetails_tbl ON OtApplicationMaster_tbl.OTAppPK = OtApplicationDetails_tbl.OtAppPK INNER JOIN "
                  + " EmployeePersonalMaster_tbl ON OtApplicationDetails_tbl.empid = EmployeePersonalMaster_tbl.empid WHERE (OTApproval_tbl.Islevel2 = 'A')"
                  + "and OtApplicationMaster_tbl.BranchLocationPk=" + Program.LOCTNPK + " and hide_display='R' and "
                + " OTApproval_tbl.OTAppPK="+ dataGridView2.Rows[e.RowIndex].Cells[8].Value +" ";

                DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView3.RowCount = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView3.Rows.Add();
                        dataGridView3.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][7];//emp no
                        dataGridView3.Rows[i].Cells[1].Value = Convert.ToString(ds.Tables[0].Rows[i][5]) + Convert.ToString(ds.Tables[0].Rows[i][6]);//emp name
                        dataGridView3.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][9];//ot type
                        dataGridView3.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][8];//ot date
                        dataGridView3.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][2];//level 1
                        dataGridView3.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][3];//level 2
                        dataGridView3.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][4];//level 3
                        dataGridView3.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][1];//ot pk
                        dataGridView3.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][0];//appr pk
                    }

                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

       

        
    }
}

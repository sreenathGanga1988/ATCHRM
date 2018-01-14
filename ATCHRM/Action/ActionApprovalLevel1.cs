using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
namespace ATCHRM.Action
{
    public partial class ActionApprovalLevel1 : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.ActionTransactions actntransaction = null;
     //   Transactions.ActionTransactions actntrans = null;
        Transactions.RejectActionTransaction rjctactiontrans = null;

        int actionlevel = 0;
        int lctnflg = 0;
        public ActionApprovalLevel1()
        {
            InitializeComponent();
            actntransaction = new Transactions.ActionTransactions();
            cmptransaction = new Transactions.CompanyBranchTransactions();
        }


        public ActionApprovalLevel1(int levelnum)
        {
           
            InitializeComponent();
            actntransaction = new Transactions.ActionTransactions();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            rjctactiontrans = new Transactions.RejectActionTransaction();

            if (levelnum==1)
            {
                actionlevel = 1;
                this.Text = "Attendance Action Approval Level 1"; 
            }
            else if (levelnum == 2)
            {
                actionlevel =2;
                this.Text = "Attendance Action Approval Level 2"; 
            }
            else if (levelnum == 3)
            {
                actionlevel = 3;
                this.Text = "Attendance Action Approval Level 3"; 
            }
        }



        /// <summary>
        /// loads the location 
        /// </summary>
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";

            cmb_location.SelectedValue = Program.LOCTNPK;
        }





        public void datagridviewsetup( )
        {
           
            tbl_ApprovalData.Rows.Clear();
            tbl_ApprovalData.ColumnCount = 1;
            tbl_ApprovalData.DataSource = null;

            tbl_ApprovalData.Columns.Add("1", "SL");
            //Hide Column After all
          //  tbl_ApprovalData.Columns[1].Visible = false; 
            tbl_ApprovalData.Columns.Add("2", "Swipe Id #");
            tbl_ApprovalData.Columns.Add("3", "Empid ");
            tbl_ApprovalData.Columns.Add("4", "Emp Code");
            tbl_ApprovalData.Columns.Add("5", "Name");
            tbl_ApprovalData.Columns.Add("6", "Dept");
            tbl_ApprovalData.Columns.Add("7", "ActionForDate");
            tbl_ApprovalData.Columns.Add("8", "Action Type");
            tbl_ApprovalData.Columns.Add("9", "From Component");
            tbl_ApprovalData.Columns.Add("10", "To Component");
            tbl_ApprovalData.Columns.Add("11", "In or Out");

        }


        public void leavedatafill(int Selectedoption)
        {

            
            DataTable dt = actntransaction.GetAllActionForApproval (int.Parse(cmb_location.SelectedValue.ToString()), dtp_Nowdate.Value.Date, actionlevel);
            datagridviewsetup();
            fillDataGrid(dt);
        }



        public void fillDataGrid(DataTable actiondata)
        {
            if (actiondata!=null)
            {
       
                
                if(actiondata.Rows.Count!=0)
          {


            for (int i = 0; i < actiondata.Rows.Count; i++)
            {
               

                tbl_ApprovalData.Rows.Add();
                tbl_ApprovalData.Rows[i].Cells[1].Value = actiondata.Rows[i][0].ToString();
                tbl_ApprovalData.Rows[i].Cells[2].Value = actiondata.Rows[i][1].ToString();
                tbl_ApprovalData.Rows[i].Cells[3].Value = actiondata.Rows[i][2].ToString();
                tbl_ApprovalData.Rows[i].Cells[4].Value = actiondata.Rows[i][3].ToString();
                tbl_ApprovalData.Rows[i].Cells[5].Value = actiondata.Rows[i][4].ToString();
                tbl_ApprovalData.Rows[i].Cells[6].Value = actiondata.Rows[i][5].ToString();
                tbl_ApprovalData.Rows[i].Cells[7].Value = actiondata.Rows[i][6].ToString();
                
                tbl_ApprovalData.Rows[i].Cells[8].Value = actiondata.Rows[i][7].ToString();
                tbl_ApprovalData.Rows[i].Cells[9].Value = actiondata.Rows[i][8].ToString();
                tbl_ApprovalData.Rows[i].Cells[10].Value = actiondata.Rows[i][9].ToString();
                tbl_ApprovalData.Rows[i].Cells[11].Value = actiondata.Rows[i][10].ToString();
              


              
            }
}

          }
        }

        private void ActionApprovalLevel1_Load(object sender, EventArgs e)
        {
            locationListLoad();
            datagridviewsetup();
        }

        private void dtp_Nowdate_ValueChanged(object sender, EventArgs e)
        {
           leavedatafill(actionlevel );
        }

        private void rbt_Recruitment_CheckedChanged(object sender, EventArgs e)
        {
           // datagridviewsetup(ActionApprovalLevel1);
           // leavedatafill("Leave Type");
        }

        private void tbl_ApprovalData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_ApprovalData.IsCurrentCellDirty)
            {
                tbl_ApprovalData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }




       

        private void tbl_ApprovalData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cmb_checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cmb_checkAll.Checked == true)
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = true;

                }
            }
            else
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                }
            }

        }

    


        public void approveAction()
        {
            for (int i = 0; i < tbl_ApprovalData.Rows.Count-1; i++)
            {
                if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                {

                    ArrayList emplst = new ArrayList();
                    emplst.Add(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()));
                    emplst.Add(int.Parse(tbl_ApprovalData.Rows[i].Cells[2].Value.ToString()));
                    emplst.Add(int.Parse(tbl_ApprovalData.Rows[i].Cells[3].Value.ToString()));
                    actntransaction.UpdateAttndAppovalAction(emplst, actionlevel);
                }
            }

             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            leavedatafill(actionlevel);
        }



        //CHANGED BY SREENATH ON 11-07-2015
       // private string inouttime(int empid, DateTime dt, string stat)
       // {


       //     string dttime = "", qry = "";
       //     if (stat.Trim() == "IN")
       //     {
       //         qry = "SELECT sdt.FromTime  "
       //+ " AS Expr1 FROM EmployeShift_tbl est,ShiftDayDetails_tbl sdt where est.Shiftpk = sdt.ShiftPK and est.Empid =" + empid + ""
       // + " AND (sdt.DayOFWeekname = '" + dt.DayOfWeek.ToString() + "')";
       //     }
       //     else if (stat.Trim() == "OUT")
       //     {
       //         qry = "SELECT sdt.toTime  "
       //+ " AS Expr1 FROM EmployeShift_tbl est,ShiftDayDetails_tbl sdt where est.Shiftpk = sdt.ShiftPK and est.Empid =" + empid + ""
       // + " AND (sdt.DayOFWeekname = '" + dt.DayOfWeek.ToString() + "')";
       //     }

       //     DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
       //     if (ds.Tables[0].Rows.Count > 0)
       //     {
       //         dttime = dt.ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("HH:mm:ss tt");
       //     }
       //     return dttime;
       // }

        private string inouttime(int empid,DateTime dt,string stat)
        {
            string dttime = "", qry = "";
            try
            {
                DataTable employeeshiftdetail = actntransaction.getShiftInandOutTimeOfADayofEmployee(empid, dt);
                if (employeeshiftdetail != null)
                {
                    if (employeeshiftdetail.Rows.Count > 0)
                    {

                        if (employeeshiftdetail.Rows[0]["FromTime"].ToString().Trim() != "")
                        {
                            if (stat.Trim() == "IN")
                            {
                                dttime = dt.ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(employeeshiftdetail.Rows[0]["FromTime"]).ToString("HH:mm:ss tt");
                            }
                            else if (stat.Trim() == "OUT")
                            {
                                dttime = dt.ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(employeeshiftdetail.Rows[0]["ToTime"]).ToString("HH:mm:ss tt");
                            }



                        }

                    }
                }
            }
            catch (Exception)
            {

                dttime = "";
            }

            //if shiftpk is not on employeeSwipeDataBank
            if (dttime.Trim() == "")
            {

                if (stat.Trim() == "IN")
                {
                    qry = "SELECT sdt.FromTime  "
           + " AS Expr1 FROM EmployeShift_tbl est,ShiftDayDetails_tbl sdt where est.Shiftpk = sdt.ShiftPK and est.Empid =" + empid + ""
            + " AND (sdt.DayOFWeekname = '" + dt.DayOfWeek.ToString() + "')";
                }
                else if (stat.Trim() == "OUT")
                {
                    qry = "SELECT sdt.toTime  "
           + " AS Expr1 FROM EmployeShift_tbl est,ShiftDayDetails_tbl sdt where est.Shiftpk = sdt.ShiftPK and est.Empid =" + empid + ""
            + " AND (sdt.DayOFWeekname = '" + dt.DayOfWeek.ToString() + "')";
                }

                DataSet ds = GridViewmModels.ClsDatabase.Get_Data(qry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dttime = dt.ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("HH:mm:ss tt");
                }
            }
            return dttime;
        }
  
        private void btn_approval_Click(object sender, EventArgs e)
        {
            try
            {
                actionapproval();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

               
            }

           
        }


        public void actionapproval()
        {
            if (actionlevel == 3)
            {

                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                    {
                        DateTime dt = Convert.ToDateTime(dtp_Nowdate.Text);
                        int empid = Convert.ToInt32(tbl_ApprovalData.Rows[i].Cells[3].Value);
                        int swipedatid=Convert.ToInt32(tbl_ApprovalData.Rows[i].Cells[2].Value);
                        DateTime actiondate = Convert.ToDateTime(dtp_Nowdate.Text);
                        String fromComponent = Convert.ToString(tbl_ApprovalData.Rows[i].Cells[9].Value).Trim();
                        String toComponent = Convert.ToString(tbl_ApprovalData.Rows[i].Cells[10].Value).Trim();
                        String WhetherInOrOut = Convert.ToString(tbl_ApprovalData.Rows[i].Cells[11].Value).Trim();
                        using (SqlConnection con = new SqlConnection(Program.ConnStr))
                        {
                            con.Open();
                            SqlCommand com = new SqlCommand("Action_Approve", con);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@empid", empid);
                            com.Parameters.AddWithValue("@swipedatid", swipedatid);
                            com.Parameters.AddWithValue("@inoutstat", toComponent);
                            com.Parameters.AddWithValue("@inout", WhetherInOrOut);
                            com.Parameters.AddWithValue("@dayofweek", Convert.ToString(dtp_Nowdate.Value.DayOfWeek.ToString()));
                            com.Parameters.AddWithValue("@closedt", dt.ToString("dd/MMM/yyyy"));




                            if (toComponent == "P" && WhetherInOrOut == "IN")
                            {
                               
                                dt = Convert.ToDateTime(inouttime(empid, actiondate, "IN"));
                            }


                            else if (toComponent == "P" && WhetherInOrOut == "OUT")
                            {

                              
                                dt = Convert.ToDateTime(inouttime(empid, actiondate, "OUT"));

                            }

                            else if (toComponent == "OT1.5" && WhetherInOrOut == "OUT" && fromComponent == "A")
                            {
                                dt = Convert.ToDateTime(inouttime(empid, actiondate, "OUT"));
                            }

                            else if (toComponent == "OT1.5" && WhetherInOrOut == "OUT" && fromComponent == "UOT")
                            {


                                DateTime swipeoutt = actntransaction.choosedateforSwipe(swipedatid, empid);
                                dt = Convert.ToDateTime(inouttime(empid, swipeoutt, "OUT"));
                            }
                            else
                            {
                                dt = Convert.ToDateTime(dtp_Nowdate.Text);
                            }
                            com.Parameters.AddWithValue("@inoutime", dt);



                            com.ExecuteNonQuery();
                        }

                    }
                }

            }
            approveAction();
            leavedatafill(actionlevel);
        }




        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
        }

        /// <summary>
        ///restrict the acess to other loacation
        /// </summary>

        public void resrictacess()
        {
            try
            {
                if (lctnflg != 0)
                {
                    if (Program.UserType == "A" || Program.UserType == "M")
                    {

                    }
                    else
                    {

                        if (int.Parse(cmb_location.SelectedValue.ToString()) != Program.LOCTNPK)
                        {
                             ATCHRM.Controls.ATCHRMMessagebox.Show("You Are Not Allowed to Acess This Location Data");
                            cmb_location.SelectedValue = Program.LOCTNPK;
                        }



                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void tbl_ApprovalData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void tbl_ApprovalData_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {


                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {


                        tbl_ApprovalData.Rows[e.RowIndex].Selected = true;


                    }
                    else
                    {

                    }

                }
            }
            catch (Exception)
            {


            }
        }

        private void tbl_ApprovalData_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (tbl_ApprovalData.IsCurrentCellDirty)
            {
                tbl_ApprovalData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbl_ApprovalData_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {


                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {


                        tbl_ApprovalData.Rows[e.RowIndex].Selected = true;


                    }
                    else
                    {

                    }

                }
            }
            catch (Exception)
            {


            }
        }

        private void tbl_ApprovalData_CurrentCellDirtyStateChanged_2(object sender, EventArgs e)
        {
            if (tbl_ApprovalData.IsCurrentCellDirty)
            {
                tbl_ApprovalData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_ApprovalData .Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                {
                 rjctactiontrans. rejectApprovalAction("Action", int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString ()), actionlevel);
                }
            }
            leavedatafill(actionlevel );
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            getmissingdata();
        }



        public void getmissingdata()
        {
            DataTable dt = actntransaction.GetAllMissingDataForApproval(dtp_Nowdate.Value.Date);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0][0].ToString().Trim() != "")
                    {
                        if (MessageBox.Show("Are You Sure You want getback  " + dt.Rows.Count + "  to an employee Action", "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int k = 0;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                actntransaction.insertActionDetail(int.Parse(dt.Rows[i][0].ToString()));
                                   k=i;
                            }
                            MessageBox.Show (k.ToString ()+" Records Added" );
                        }
                    }
                }

            }
        }



    }
}

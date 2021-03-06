﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;
using System.Diagnostics;
namespace ATCHRM.Attendance
{

    public partial class DailyCloseregister : Form
    {
        int ewmpflag = 0;
        Transactions.AttendanceManagementTransaction atndncemngmnt = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DataExporter DTPEXPTR = null;
        Transactions.HolidayTransaction hldytransaction = null;
        int locationflag = 0;
        int currentrowindex = 0;
        int deptflag = 0;
        DataTable allemployedata = null;
        public DailyCloseregister()
        {
            InitializeComponent();

            hldytransaction = new Transactions.HolidayTransaction();
            atndncemngmnt = new Transactions.AttendanceManagementTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            depttrans = new Transactions.DepartmentTransaction();
            empreg = new Transactions.EmployeeRegTransaction();
            locationListLoad();
            DeptcomboLoad();
            // employecodeload(0, 0, 0);

        }

        private void chk_EmployeeSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_EmployeeSearch.Checked == true)
            {
                cmb_EmpCode.Enabled = false;
                Cmb_Department.Enabled = false;
                Cmb_location.Enabled = false;
                grp_all.Enabled = true;
                btn_all.Enabled = true;
            }
            else
            {

                cmb_EmpCode.Enabled = true;
                Cmb_Department.Enabled = true;
                Cmb_location.Enabled = true;
                grp_all.Enabled = false;
                btn_all.Enabled = false;
            }
        }

        /// <summary>
        /// loads the location
        /// </summary>
        public void locationListLoad()
        {
            Cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            Cmb_location.DataSource = dt;
            Cmb_location.DisplayMember = "LOCATION";
            Cmb_location.ValueMember = "SL";
            Cmb_location.SelectedValue = Program.LOCTNPK;
        }




        /// <summary>
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            Cmb_Department.DataSource = dt;
            Cmb_Department.DisplayMember = "DepartmentName";
            Cmb_Department.ValueMember = "DepartmentPK";
        }









        private void btn_employeeNameSearch_Click(object sender, EventArgs e)
        {
            HR.NewFolder1.EmployeeMasterForm empmasterfrm = new HR.NewFolder1.EmployeeMasterForm();
            empmasterfrm.MdiParent = this.MdiParent;
            empmasterfrm.Show();
        }


        /// <summary>
        /// loads the employee
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.ValueMember = "empid";
            cmb_EmpCode.DisplayMember = "empno";


        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            ewmpflag++;

        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ewmpflag > 0)
            {
                if (deptflag != 0)
                {

                    if (Cmb_Department.SelectedValue != null)
                    {
                        if (Cmb_location.SelectedValue != null)
                        {
                            DataTable dt = allemployedata.Clone();


                            if (allemployedata == null || allemployedata.Rows.Count == 0)
                            {
                                allemployedata = atndncemngmnt.getallswipe(Program.LOCTNPK, dtp_datetoday.Value.Date,"Show");
                            }

                            DataRow[] result = allemployedata.Select("empno='" + cmb_EmpCode.Text.Trim() + "' ");



                            foreach (DataRow row in result)
                            {
                               
                                dt.Rows.Add(row.ItemArray);
                            }

                            filldatagridview(dt);                           


                        }
                    }
                }
            }
        }




        /// <summary>
        /// setup the gridview
        /// </summary>
        public void gridviewsetup()
        {

            tbl_DailyTime.DataSource = null;
            tbl_DailyTime.ColumnCount = 0;
            tbl_DailyTime.RowTemplate.Height = 18;

            if (rbt_swipe.Checked == true)
            {


                tbl_DailyTime.Columns.Add("2", "Empid ");
                tbl_DailyTime.Columns.Add("3", "EmpCode ");
                tbl_DailyTime.Columns.Add("4", "Empname");
                tbl_DailyTime.Columns.Add("5", "Designation");
                tbl_DailyTime.Columns.Add("6", "Department");
                tbl_DailyTime.Columns.Add("7", "Date");

                tbl_DailyTime.Columns.Add("8", "Shift In ");
                tbl_DailyTime.Columns.Add("9", "Swipe In");
                tbl_DailyTime.Columns.Add("10", "Status");
                tbl_DailyTime.Columns.Add("11", "Closed");
                tbl_DailyTime.Columns.Add("12", "SwipePk");
                tbl_DailyTime.Columns.Add("13", "Old Empid");
                tbl_DailyTime.Columns[10].Visible = false;
            }
            else if (rbt_swipeOut.Checked == true)
            {

                tbl_DailyTime.Columns.Add("2", "Empid ");
                tbl_DailyTime.Columns.Add("3", "EmpCode ");
                tbl_DailyTime.Columns.Add("4", "Empname");
                tbl_DailyTime.Columns.Add("5", "Designation");
                tbl_DailyTime.Columns.Add("6", "Department");
                tbl_DailyTime.Columns.Add("7", "Date");

                tbl_DailyTime.Columns.Add("8", " Shift Out");
                tbl_DailyTime.Columns.Add("9", "Swipe Out");
                tbl_DailyTime.Columns.Add("10", "Status");
                tbl_DailyTime.Columns.Add("11", "Closed");
                tbl_DailyTime.Columns.Add("12", "SwipePk");
                tbl_DailyTime.Columns.Add("13", "Old Empid");
                tbl_DailyTime.Columns[10].Visible = false;
            }
            else if (RBT_INOUT.Checked == true)
            {

                tbl_DailyTime.Columns.Add("2", "Empid ");
                tbl_DailyTime.Columns.Add("3", "EmpCode ");
                tbl_DailyTime.Columns.Add("4", "Empname");
                tbl_DailyTime.Columns.Add("5", "Designation");
                tbl_DailyTime.Columns.Add("6", "Department");
                tbl_DailyTime.Columns.Add("7", "Date");

                tbl_DailyTime.Columns.Add("8", "Shift In ");
                tbl_DailyTime.Columns.Add("9", " Shift OuT");
                tbl_DailyTime.Columns.Add("10", "Swipe In");
                tbl_DailyTime.Columns.Add("11", "Swipe Out");
                tbl_DailyTime.Columns.Add("12", "IN Status");
                tbl_DailyTime.Columns.Add("13", "OUT Status");
                tbl_DailyTime.Columns.Add("14", "Duration");
                tbl_DailyTime.Columns.Add("15", "Closed");
                tbl_DailyTime.Columns.Add("16", "SwipePk");
                tbl_DailyTime.Columns.Add("15", "InValue");
                tbl_DailyTime.Columns.Add("16", "OutValue");
                tbl_DailyTime.Columns.Add("17", "Approved OT");
                tbl_DailyTime.Columns.Add("18", "Approved LHR");
                tbl_DailyTime.Columns.Add("19", "Approved Leave");
                tbl_DailyTime.Columns.Add("20", "Extra Value");
                tbl_DailyTime.Columns.Add("21", "Extra Status");
                tbl_DailyTime.Columns.Add("22", "Day Status");
                tbl_DailyTime.Columns.Add("23", "Shift PK");
                tbl_DailyTime.Columns.Add("24", "Old Empid");
                tbl_DailyTime.Columns.Add("25", "Status");
                tbl_DailyTime.Columns.Add("26", "Sub Dept");

                //tbl_DailyTime.Columns[14].Visible = false;
                //tbl_DailyTime.Columns[15].Visible = false;
                //tbl_DailyTime.Columns[16].Visible = false;
                //tbl_DailyTime.Columns[17].Visible = false;
                //tbl_DailyTime.Columns[18].Visible = false;
                //tbl_DailyTime.Columns[19].Visible = false;
                //tbl_DailyTime.Columns[20].Visible = false;
                //tbl_DailyTime.Columns[21].Visible = false;
                //tbl_DailyTime.Columns[23].Visible = false;
                //tbl_DailyTime.Columns[0].Visible = true;
               // tbl_DailyTime.Columns[1].Width = -1;
            }
            else
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show("Enter the Type of Data Required");
                grp_Dtatypesin.BackColor = Color.Chartreuse;

            }
        }




        public void closeRegisterActionMain(DataTable EmployeeSwipedata)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);

      
            for (int i = 0; i < EmployeeSwipedata.Rows.Count; i++)
            {

                SqlCommand cmd = new SqlCommand("AttendanceClosingDaily", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", int.Parse(EmployeeSwipedata.Rows[i][0].ToString()));
                cmd.Parameters.AddWithValue("@datetoday", DateTime.Parse(EmployeeSwipedata.Rows[i][1].ToString()));
                int k = int.Parse(EmployeeSwipedata.Rows[i][2].ToString());


                cmd.Parameters.AddWithValue("@swipepk", int.Parse(EmployeeSwipedata.Rows[i][2].ToString()));
                cmd.Parameters.AddWithValue("@actualdate", DateTime.Parse(EmployeeSwipedata.Rows[i][3].ToString()));
                cmd.Parameters.AddWithValue("@completedDate", Program.Datetoday);
                cmd.Parameters.AddWithValue("@instatus", EmployeeSwipedata.Rows[i][4].ToString());
                cmd.Parameters.AddWithValue("@outstatus", EmployeeSwipedata.Rows[i][5].ToString());
                cmd.ExecuteNonQuery();
            }




        }



        /// <summary>
        /// get all the swipe on that date
        /// </summary>
        public void getshiftdataofadateadata(int i)
        {


            try
            {

                if (i == 1)
                {
                    if (int.Parse(Cmb_location.SelectedValue.ToString()) == Program.LOCTNPK)
                    {
                        allemployedata = atndncemngmnt.getallswipe(Program.LOCTNPK, dtp_datetoday.Value.Date, "Show");



                    }

                    else
                    {
                        allemployedata = atndncemngmnt.getallswipe(int.Parse(Cmb_location.SelectedValue.ToString()), dtp_datetoday.Value.Date,"Show");


                    }
                }
                else 
                {
                      if (int.Parse(Cmb_location.SelectedValue.ToString()) == Program.LOCTNPK)
                    {
                        allemployedata = atndncemngmnt.getallswipe(Program.LOCTNPK, dtp_datetoday.Value.Date, "Retriewe");



                    }

                    else
                    {
                        allemployedata = atndncemngmnt.getallswipe(int.Parse(Cmb_location.SelectedValue.ToString()), dtp_datetoday.Value.Date,"Retriewe");


                    }

                }


                filldatagridview(allemployedata);
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }
        }




        /// <summary>
        /// fill the datagridview
        /// </summary>
        /// <param name="dt"></param>
        public void filldatagridview(DataTable dt)
        {
            //one if is condition added for updating In absent and out absent

            gridviewsetup();
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    if (rbt_swipe.Checked == true)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            tbl_DailyTime.Rows.Add();
                            tbl_DailyTime.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                            tbl_DailyTime.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                            tbl_DailyTime.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString() + "  " + dt.Rows[i][3].ToString();
                            tbl_DailyTime.Rows[i].Cells[3].Value = dt.Rows[i][4].ToString();
                            tbl_DailyTime.Rows[i].Cells[4].Value = dt.Rows[i][5].ToString();
                            string sg=Convert.ToDateTime(dt.Rows[i][6]).ToString("dd-MMM-yyyy");
                            if ( sg== "01-Jan-1900")
                            {
                                tbl_DailyTime.Rows[i].Cells[6].Value = "00:00:00";
                                tbl_DailyTime.Rows[i].Cells[7].Value = "00:00:00";
                                tbl_DailyTime.Rows[i].Cells[5].Value = sg;
                            }
                            else
                            {
                                tbl_DailyTime.Rows[i].Cells[5].Value = DateTime.Parse(dt.Rows[i][6].ToString()).ToString("dd/MM/yyyy");
                                tbl_DailyTime.Rows[i].Cells[6].Value = DateTime.Parse(dt.Rows[i][7].ToString()).ToString("HH:mm:ss");
                                tbl_DailyTime.Rows[i].Cells[7].Value = DateTime.Parse(dt.Rows[i][9].ToString()).ToString("HH:mm:ss");
                            }
                            tbl_DailyTime.Rows[i].Cells[8].Value = dt.Rows[i][12].ToString();
                            tbl_DailyTime.Rows[i].Cells[9].Value = dt.Rows[i][17].ToString();
                            tbl_DailyTime.Rows[i].Cells[10].Value = dt.Rows[i][18].ToString();
                            tbl_DailyTime.Rows[i].Cells[11].Value = dt.Rows[i][21].ToString();

                        }
                        highlighter();
                    }
                    else if (rbt_swipeOut.Checked == true)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            tbl_DailyTime.Rows.Add();
                            tbl_DailyTime.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                            tbl_DailyTime.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();

                            tbl_DailyTime.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString() + "  " + dt.Rows[i][3].ToString();
                            tbl_DailyTime.Rows[i].Cells[3].Value = dt.Rows[i][4].ToString();
                            tbl_DailyTime.Rows[i].Cells[4].Value = dt.Rows[i][5].ToString();
                            string sg = Convert.ToDateTime(dt.Rows[i][6]).ToString("dd-MMM-yyyy");
                            if (sg == "01-Jan-1900")
                            {
                                tbl_DailyTime.Rows[i].Cells[5].Value = sg;
                                tbl_DailyTime.Rows[i].Cells[6].Value = "00:00:00";
                                tbl_DailyTime.Rows[i].Cells[7].Value = "00:00:00";
                            }
                            else
                            {
                                tbl_DailyTime.Rows[i].Cells[5].Value = DateTime.Parse(dt.Rows[i][6].ToString()).ToString("dd/MM/yyyy");
                                tbl_DailyTime.Rows[i].Cells[6].Value = DateTime.Parse(dt.Rows[i][8].ToString()).ToString("HH:mm:ss");
                                tbl_DailyTime.Rows[i].Cells[7].Value = DateTime.Parse(dt.Rows[i][10].ToString()).ToString("HH:mm:ss");
                            }
                            tbl_DailyTime.Rows[i].Cells[8].Value = dt.Rows[i][13].ToString();
                            tbl_DailyTime.Rows[i].Cells[9].Value = dt.Rows[i][17].ToString();
                            tbl_DailyTime.Rows[i].Cells[10].Value = dt.Rows[i][18].ToString();
                            tbl_DailyTime.Rows[i].Cells[11].Value = dt.Rows[i][21].ToString();

                        }
                        highlighter();
                    }


                    else if (RBT_INOUT.Checked == true)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            tbl_DailyTime.Rows.Add();
                            tbl_DailyTime.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                            tbl_DailyTime.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                            tbl_DailyTime.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString() + "  " + dt.Rows[i][3].ToString();
                            tbl_DailyTime.Rows[i].Cells[3].Value = dt.Rows[i][4].ToString();
                            tbl_DailyTime.Rows[i].Cells[4].Value = dt.Rows[i][5].ToString();
                            string sg = Convert.ToDateTime(dt.Rows[i][6]).ToString("dd-MMM-yyyy");
                            if (sg == "01-Jan-1900")
                            {
                                tbl_DailyTime.Rows[i].Cells[5].Value = sg;
                                tbl_DailyTime.Rows[i].Cells[8].Value = "00:00:00";
                                tbl_DailyTime.Rows[i].Cells[9].Value = "00:00:00";
                                tbl_DailyTime.Rows[i].Cells[6].Value = "00:00:00";
                                tbl_DailyTime.Rows[i].Cells[7].Value = "00:00:00";
                            }
                            else
                            {
                                tbl_DailyTime.Rows[i].Cells[5].Value = DateTime.Parse(dt.Rows[i][6].ToString()).ToString("dd/MM/yyyy");
                                tbl_DailyTime.Rows[i].Cells[6].Value = DateTime.Parse(dt.Rows[i][7].ToString()).ToString("HH:mm:ss");
                                tbl_DailyTime.Rows[i].Cells[7].Value = DateTime.Parse(dt.Rows[i][8].ToString()).ToString("HH:mm:ss");
                                tbl_DailyTime.Rows[i].Cells[8].Value = DateTime.Parse(dt.Rows[i][9].ToString());
                                tbl_DailyTime.Rows[i].Cells[9].Value = DateTime.Parse(dt.Rows[i][10].ToString());
                            }
                            tbl_DailyTime.Rows[i].Cells[10].Value = dt.Rows[i][12].ToString();
                            tbl_DailyTime.Rows[i].Cells[11].Value = dt.Rows[i][13].ToString();
                            tbl_DailyTime.Rows[i].Cells[12].Value = dt.Rows[i][16].ToString();
                            tbl_DailyTime.Rows[i].Cells[13].Value = dt.Rows[i][17].ToString();
                            tbl_DailyTime.Rows[i].Cells[14].Value = dt.Rows[i][18].ToString();
                            tbl_DailyTime.Rows[i].Cells[15].Value = dt.Rows[i][14].ToString();
                            //       tbl_DailyTime.Rows[i].Cells[15].Value = (int.Parse(tbl_DailyTime.Rows[i].Cells[8].Value.ToString()) - int.Parse(tbl_DailyTime.Rows[i].Cells[6].Value.ToString());
                            tbl_DailyTime.Rows[i].Cells[16].Value = dt.Rows[i][15].ToString();

                            tbl_DailyTime.Rows[i].Cells[20].Value = 0;
                            tbl_DailyTime.Rows[i].Cells[21].Value = "NA";
                            tbl_DailyTime.Rows[i].Cells[22].Value = dt.Rows[i][19].ToString();
                            tbl_DailyTime.Rows[i].Cells[23].Value = dt.Rows[i][20].ToString();
                            tbl_DailyTime.Rows[i].Cells[24].Value = dt.Rows[i][21].ToString();
                            tbl_DailyTime.Rows[i].Cells[25].Value = dt.Rows[i][22].ToString();
                            tbl_DailyTime.Rows[i].Cells[26].Value = dt.Rows[i][23].ToString();

                            DataTable dt1 = atndncemngmnt.getAllOTApllicationOfaDateandEmployee(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));
                            DataTable dt2 = atndncemngmnt.getAlLlhrOfaDateandEmployee(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));
                            DataTable dt3 = atndncemngmnt.getLeaveOfaDateandEmployee(DateTime.Parse(dtp_datetoday.Value.Date.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));
                            if (dt1.Rows.Count != 0)
                            {
                                tbl_DailyTime.Rows[i].Cells[17].Value = dt1.Rows[0][2].ToString();
                            }
                            else
                            {
                                tbl_DailyTime.Rows[i].Cells[17].Value = 0;
                            }
                            if (dt2.Rows.Count != 0)
                            {
                                tbl_DailyTime.Rows[i].Cells[18].Value = dt2.Rows[0][0].ToString();
                            }
                            else
                            {
                                tbl_DailyTime.Rows[i].Cells[18].Value = 0;
                            }
                            if (dt3.Rows.Count != 0)
                            {
                                tbl_DailyTime.Rows[i].Cells[19].Value = dt3.Rows[0][0].ToString();
                            }
                            else
                            {
                                tbl_DailyTime.Rows[i].Cells[19].Value = "N";
                            }
                           

                        }
                        AdjustTerminology();
                        adjustEarlySwipe();
                       OTapplyaction();
                    LHRapplyaction();


                        highlighter();
                        LeaveAction();
                        offDayCalculator();
                    }
                }
            }




        }










        private void button2_Click(object sender, EventArgs e)
        {

            btn_all.Enabled = false;
            filldatagridview(allemployedata);


        }

       

        private void rbt_swipe_CheckedChanged(object sender, EventArgs e)
        {
            filldatagridview(allemployedata);
        }

        private void rbt_swipeOut_CheckedChanged(object sender, EventArgs e)
        {
            filldatagridview(allemployedata);
        }

        private void RBT_INOUT_CheckedChanged(object sender, EventArgs e)
        {
            filldatagridview(allemployedata);
        }




        private void Cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            locationflag++;
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            btn_all.Enabled = false;
            allemployedata = atndncemngmnt.getallswipe(Program.LOCTNPK, dtp_datetoday.Value.Date,"Show" );


            filldatagridview(allemployedata);
        }

        private void Cmb_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (deptflag != 0)
                {

                    if (Cmb_Department.SelectedValue != null)
                    {
                        if (Cmb_location.SelectedValue != null)
                        {
                            DataTable dt = allemployedata.Clone();

                            employecodeload(int.Parse(Cmb_location.SelectedValue.ToString()), int.Parse(Cmb_Department.SelectedValue.ToString()), 0);



                            if (allemployedata == null || allemployedata.Rows.Count == 0)
                            {
                                allemployedata = atndncemngmnt.getallswipe(Program.LOCTNPK, dtp_datetoday.Value.Date,"Show");
                            }

                            DataRow[] result = allemployedata.Select("DepartmentName='" + Cmb_Department.Text.Trim() + "' ");



                            foreach (DataRow row in result)
                            {

                                dt.Rows.Add(row.ItemArray);
                            }

                            filldatagridview(dt);

                        }
                    }

                }

            }
            catch (Exception)
            {


            }
        }

        private void Cmb_Department_MouseClick(object sender, MouseEventArgs e)
        {
            deptflag++;
        }



        /// <summary>
        /// this function will collect the possible 
        /// cases of other terminologies from database and will convert them to our terminologies like UOt,OT,LH etc
        /// not this is applicable only during the IN OUT is selected
        /// </summary>
        public void AdjustTerminology()
        {
            try
            {
                // IN STATUS
                for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                {
                    if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Consider it LH")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "LH";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Adjust Swipe")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "Early";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Consider it UOT")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "UOT";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Consider It as LH")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "LH";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Consider it as LH")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "LH";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Consider It As UOT")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "UOT";
                    }

                    else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Out UOT")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "UOT";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "")
                    {
                        tbl_DailyTime.Rows[i].Cells[10].Value = "A";
                    }

                    //out status
                    if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "Consider it LH")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "LH";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "Adjust Swipe")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "Early";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "Consider it UOT")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "UOT";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "Consider It as LH")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "LH";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "Consider It As UOT")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "UOT";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "Out UOT")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "UOT";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "Consider it as LH")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "LH";
                    }
                    else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "")
                    {
                        tbl_DailyTime.Rows[i].Cells[11].Value = "A";
                    }



                    if (tbl_DailyTime.Rows[i].Cells[12].Value.ToString().Trim() == "")
                    {
                        tbl_DailyTime.Rows[i].Cells[12].Value = "00:00:00";
                    }
                    if (tbl_DailyTime.Rows[i].Cells[15].Value.ToString().Trim() == "")
                    {
                        tbl_DailyTime.Rows[i].Cells[15].Value = "0";
                    } if (tbl_DailyTime.Rows[i].Cells[16].Value.ToString().Trim() == "")
                    {
                        tbl_DailyTime.Rows[i].Cells[16].Value = "0";
                    }



                    if (tbl_DailyTime.Rows[i].Cells[23].Value.ToString().Trim() == "0")
                    {
                        tbl_DailyTime.Rows[i].Cells[23].Value = atndncemngmnt.getemployeeshift (int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString())).ToString ();
                    }



                }

            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }

        }

        /// <summary>
        /// if it is an early swipe
        /// Mark the Term In instatus from Early to P 
        /// and
        /// In value=0
        /// swipe time is made a time betwwen the allowed time
        /// 
        /// </summary>

        public void adjustEarlySwipe()
        {
            for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
            {
                if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "Early" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "EARLY")
                {
                    DateTime allowedduration = (DateTime.Parse(tbl_DailyTime.Rows[i].Cells[6].Value.ToString()));
                    //      DateTime allowedduration = Shifttime.AddMinutes(-30);

                    DateTime Shifttime = allowedduration.AddMinutes(-30);
                    TimeSpan timeSpan = allowedduration - Shifttime;
                    var randomTest = new Random();
                    TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                    DateTime newadjstedtime = allowedduration - newSpan;



                    tbl_DailyTime.Rows[i].Cells[10].Value = "P";

                    tbl_DailyTime.Rows[i].Cells[8].Value = newadjstedtime.ToString("hh:mm");

                    tbl_DailyTime.Rows[i].Cells[15].Value = 0;


                }

            }


        }




        /// <summary>
        /// highlights the discrepancies in the Attendance
        /// </summary>
        public void highlighter()
        {
            try
            {
                for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < tbl_DailyTime.Columns.Count - 1; j++)
                    {
                        tbl_DailyTime.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                if (rbt_swipe.Checked == true)
                {
                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {
                        if (tbl_DailyTime.Rows[i].Cells[8].Value.ToString().Trim() == "LH")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
                        }
                        else if (tbl_DailyTime.Rows[i].Cells[8].Value.ToString().Trim() == "A")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[8].Style.BackColor = Color.Red;
                        }
                        else if (tbl_DailyTime.Rows[i].Cells[8].Value.ToString().Trim() == "UOT")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[8].Style.BackColor = Color.BurlyWood;
                        }
                        else if (tbl_DailyTime.Rows[i].Cells[8].Value.ToString().Trim() == "")
                        {
                            tbl_DailyTime.Rows[i].Cells[8].Value = "A";
                        }
                    }


                }
                else if (rbt_swipeOut.Checked == true)
                {
                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {
                        if (tbl_DailyTime.Rows[i].Cells[8].Value.ToString().Trim() == "LH")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
                        }
                        else if (tbl_DailyTime.Rows[i].Cells[8].Value.ToString().Trim() == "A")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[8].Style.BackColor = Color.Red;
                        }
                        else if (tbl_DailyTime.Rows[i].Cells[8].Value.ToString().Trim() == "UOT")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[8].Style.BackColor = Color.BurlyWood;
                        }

                    }

                }

                else if (RBT_INOUT.Checked == true)
                {
                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {
                        if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "LH")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[10].Style.BackColor = Color.Yellow;
                        }
                        else if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "A")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[10].Style.BackColor = Color.Red;
                        }
                        if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "LH")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                        }
                        else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[11].Style.BackColor = Color.Red;
                        }

                        else if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[11].Style.BackColor = Color.BurlyWood;
                        }

                        if (tbl_DailyTime.Rows[i].Cells[19].Value.ToString().Trim() != "N")
                        {
                            this.tbl_DailyTime.Rows[i].Cells[19].Style.BackColor = Color.GreenYellow;
                        }



                    }

                }
                else
                {


                }
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tbl_DailyTime);
        }

        private void dtp_datetoday_ValueChanged(object sender, EventArgs e)
        {
          

        }

        private void btn_approval_Click(object sender, EventArgs e)
        {
            if (isdateaccesible(Program.Datetoday, dtp_datetoday.Value.Date))
            {
                try
                {
                    if (dtp_datetoday.Value.Date != Program.Datetoday.Date)
                    {

                        if (tbl_DailyTime.Rows[0].Cells[13].Value.ToString().Trim() == "N")
                        {


                            if (dtp_datetoday.Value.Date == Program.Datetoday.Date)
                            {
                                 ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Close the Register For the Same Day");
                            }
                            else if (dtp_datetoday.Value.Date > Program.Datetoday.Date)
                            {
                                 ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Close the Register for Future Day");
                            }

                            else
                            {



                                RBT_INOUT.Checked = true;
                                getshiftdataofadateadata(1);

                                DialogResult dialogResult = MessageBox.Show("Are you Sure to Close Attendance Register of  " + tbl_DailyTime.Rows.Count + "  Employees  For the Date " + dtp_datetoday.Value.Date.ToString("dd/MM/yyy") + " ", "Attention ", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    // getdataforClosing();
                                    try
                                    {
                                        if (lbl_daystatus.Text != "Working Day")
                                        {
                                            atndncemngmnt.closeDataRegister(getdataforClosing());
                                            getshiftdataofadateadata(2);
                                            atndncemngmnt.EmployeeSwipeBankEnter(getdataforInserting());
                                            atndncemngmnt.EmployyeLeaveTakenUpdate(dtp_datetoday.Value.Date, getdataforClosing());
                                            atndncemngmnt.insertCloseregisterexception(CloseregisterExceptionFetch());
                                            offdayDataentry();
                                             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                                        }
                                        else
                                        {
                                            DataTable swipedata = getdataforClosing();

                                            atndncemngmnt.closeDataRegister(swipedata);


                                            atndncemngmnt.insertConsolidatedData(swipedata);
                                            atndncemngmnt.EmployyeLeaveTakenUpdate(dtp_datetoday.Value.Date, swipedata);
                                            getshiftdataofadateadata(2);
                                            //  ConsolidateStatusData();
                                            atndncemngmnt.EmployeeSwipeBankEnter(getdataforInserting());
                                            offdayDataentry();
                                             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

                                        }


                                    }
                                    catch (Exception exp)
                                    {

                                        if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                                        {
                                             ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
                                        }

                                        ErrorLogger er = new ErrorLogger();
                                        er.createErrorLog(exp);

                                    }



                                }
                                else
                                {

                                    this.Close();
                                }
                            }
                        }
                        else
                        {

                             ATCHRM.Controls.ATCHRMMessagebox.Show("Already Close Register Done For This  Date");

                        }
                    }
                    else
                    {

                         ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Close the Register For the Same Day");
                    }
                }
                catch (Exception exp)
                {
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);

                    this.Dispose();
                }
            }
            
            else
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show("You are not allowed to Close register Days older than 3 Days");
            }
        }


        public void ConsolidateStatusData()
        {
            try
            {
               



                for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                {
                    int EMPID = int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString());
                    int SWIPEPK = int.Parse(tbl_DailyTime.Rows[i].Cells[14].Value.ToString());
                    DateTime swipedate = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString());
                    if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "A")
                    {

                        String Statusinout1 = tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim();
                        int INVALUE1 = int.Parse(tbl_DailyTime.Rows[i].Cells[15].Value.ToString());
                

                    }
                    if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                    {
                        String Statusinout2 = tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim();
                        int INVALUE2 = int.Parse(tbl_DailyTime.Rows[i].Cells[16].Value.ToString());
                                       }


                }

               
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
        }


        /// <summary>
        /// collect all the swipe datas to get it to database and mark it approved
        /// </summary>
        /// <returns></returns>
        public DataTable getdataforClosing()
        {
            DataTable dTable = new DataTable();
            DataColumn auto = new DataColumn("empid", typeof(System.Int32));
            dTable.Columns.Add(auto);

            DataColumn salcompK = new DataColumn("Datetoday", typeof(DateTime));
            dTable.Columns.Add(salcompK);


            DataColumn swipepk = new DataColumn("SwipePk", typeof(System.Int32));
            dTable.Columns.Add(swipepk);
            DataColumn dateactl = new DataColumn("ActualDate", typeof(DateTime));
            dTable.Columns.Add(dateactl);
            
            DataColumn intatus = new DataColumn("InStatus", typeof(String));
            dTable.Columns.Add(intatus);
            DataColumn outstatus = new DataColumn("Outstatus", typeof(String));
            dTable.Columns.Add(outstatus);



            DataColumn invalue = new DataColumn("InValue", typeof(System.Int32));
            dTable.Columns.Add(invalue);
            DataColumn outvalue = new DataColumn("OutValue", typeof(System.Int32));
            dTable.Columns.Add(outvalue);

            DataColumn swipein = new DataColumn("SwipeIn", typeof(DateTime));
            dTable.Columns.Add(swipein);
            DataColumn swipeout = new DataColumn("SwipeOut", typeof(DateTime));
            dTable.Columns.Add(swipeout);

            DataColumn ShiftPk = new DataColumn("ShiftPk", typeof(System.Int32));
            dTable.Columns.Add(ShiftPk);
            DataColumn extratime = new DataColumn("extratime", typeof(System.Int32));
            dTable.Columns.Add(extratime);
            DataColumn extrastatus = new DataColumn("extrastatus", typeof(System.String));
            dTable.Columns.Add(extrastatus);





            DataRow row = null;

            for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
            {
                if (tbl_DailyTime.Rows[i].Cells[13].Value.ToString().Trim() == "N")
                {

               
                    row = dTable.NewRow();
                    row["empid"] = int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString());
                    row["Datetoday"] = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString());
                    row["SwipePk"] = int.Parse(tbl_DailyTime.Rows[i].Cells[14].Value.ToString());
                    row["ActualDate"] = DateTime.Parse(dtp_datetoday.Value.Date.ToString());
                    row["InStatus"] = tbl_DailyTime.Rows[i].Cells[10].Value.ToString();
                    row["Outstatus"] = tbl_DailyTime.Rows[i].Cells[11].Value.ToString();


                    row["InValue"] = int.Parse(tbl_DailyTime.Rows[i].Cells[15].Value.ToString());
                    row["OutValue"] = int.Parse(tbl_DailyTime.Rows[i].Cells[16].Value.ToString());
                    row["SwipeIn"] = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[8].Value.ToString());
                    row["SwipeOut"] = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[9].Value.ToString());
                    row["ShiftPk"] = tbl_DailyTime.Rows[i].Cells[23].Value.ToString().Trim();
                    row["extratime"] = int.Parse(tbl_DailyTime.Rows[i].Cells[20].Value.ToString());
                    row["extrastatus"] = tbl_DailyTime.Rows[i].Cells[21].Value.ToString().Trim();
                    dTable.Rows.Add(row);
                }
            }
            return dTable;
        }

         public DataTable getdataforInserting()
        {
            DataTable dTable = new DataTable();
            DataColumn auto = new DataColumn("empid", typeof(System.Int32));
            dTable.Columns.Add(auto);

            DataColumn salcompK = new DataColumn("Datetoday", typeof(DateTime));
            dTable.Columns.Add(salcompK);


            DataColumn swipepk = new DataColumn("SwipePk", typeof(System.Int32));
            dTable.Columns.Add(swipepk);
            DataColumn dateactl = new DataColumn("ActualDate", typeof(DateTime));
            dTable.Columns.Add(dateactl);

            DataColumn intatus = new DataColumn("InStatus", typeof(String));
            dTable.Columns.Add(intatus);
            DataColumn outstatus = new DataColumn("Outstatus", typeof(String));
            dTable.Columns.Add(outstatus);



            DataColumn invalue = new DataColumn("InValue", typeof(System.Int32));
            dTable.Columns.Add(invalue);
            DataColumn outvalue = new DataColumn("OutValue", typeof(System.Int32));
            dTable.Columns.Add(outvalue);

            DataColumn swipein = new DataColumn("SwipeIn", typeof(DateTime));
            dTable.Columns.Add(swipein);
            DataColumn swipeout = new DataColumn("SwipeOut", typeof(DateTime));
            dTable.Columns.Add(swipeout);

            DataColumn Actualin = new DataColumn("Actualin", typeof(DateTime));
            dTable.Columns.Add(Actualin);
            DataColumn Actualout = new DataColumn("Actualout", typeof(DateTime));
            dTable.Columns.Add(Actualout);
            DataColumn ShiftPk = new DataColumn("ShiftPk", typeof(System.Int32));
            dTable.Columns.Add(ShiftPk);

            DataColumn extratime = new DataColumn("extratime", typeof(System.Int32));
            dTable.Columns.Add(extratime);
            DataColumn extrastatus = new DataColumn("extrastatus", typeof(System.String));
            dTable.Columns.Add(extrastatus);




            DataRow row = null;

            for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
            {
                if (tbl_DailyTime.Rows[i].Cells[13].Value.ToString().Trim() == "Y")
                {


                    row = dTable.NewRow();
                    row["empid"] = int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString());
                    row["Datetoday"] = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString());
                    row["SwipePk"] = int.Parse(tbl_DailyTime.Rows[i].Cells[14].Value.ToString());
                    row["ActualDate"] = DateTime.Parse(dtp_datetoday.Value.Date.ToString());
                    row["InStatus"] = tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim();
                    row["Outstatus"] = tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim();


                    row["InValue"] = int.Parse(tbl_DailyTime.Rows[i].Cells[15].Value.ToString());
                    row["OutValue"] = int.Parse(tbl_DailyTime.Rows[i].Cells[16].Value.ToString());
                    row["SwipeIn"] = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[8].Value.ToString());
                    row["SwipeOut"] = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[9].Value.ToString());
                    row["Actualin"] = tbl_DailyTime.Rows[i].Cells[6].Value.ToString().Trim();
                    row["Actualout"] = tbl_DailyTime.Rows[i].Cells[7].Value.ToString().Trim();
                    row["ShiftPk"] = tbl_DailyTime.Rows[i].Cells[23].Value.ToString().Trim();
                    row["extratime"] = int.Parse(tbl_DailyTime.Rows[i].Cells[20].Value.ToString());
                    row["extrastatus"] = tbl_DailyTime.Rows[i].Cells[21].Value.ToString().Trim();
                    dTable.Rows.Add(row);
                }
            }
            return dTable;
        }


        /// <summary>
        /// if any exception or extra value is found then the 
        /// datatble is made and that extra value for the 
        /// swipe data is made 
        /// </summary>
        /// <returns></returns>
        public DataTable CloseregisterExceptionFetch()
        {
            DataTable dt = new DataTable();


            DataColumn empid = new DataColumn("Empid", typeof(System.Int32));
            dt.Columns.Add(empid);
            DataColumn swipepk = new DataColumn("SwipePk", typeof(System.Int32));
            dt.Columns.Add(swipepk);
            DataColumn dateactl = new DataColumn("ActualDate", typeof(DateTime));
            dt.Columns.Add(dateactl);

            DataColumn invalue = new DataColumn("ExtraValue", typeof(System.Int32));
            dt.Columns.Add(invalue);
            DataColumn outstatus = new DataColumn("ExtraStatus", typeof(String));
            dt.Columns.Add(outstatus);

            DataRow row = null;
            for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
            {
                if (tbl_DailyTime.Rows[i].Cells[21].Value.ToString().Trim() != "N" && int.Parse(tbl_DailyTime.Rows[i].Cells[20].Value.ToString())!=0)
                {


                    row = dt.NewRow();
                    row["empid"] = int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString());
                    row["ActualDate"] = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString());
                    row["SwipePk"] = int.Parse(tbl_DailyTime.Rows[i].Cells[14].Value.ToString());
                    row["ExtraValue"] = int.Parse(tbl_DailyTime.Rows[i].Cells[20].Value.ToString());
                    row["ExtraStatus"] = tbl_DailyTime.Rows[i].Cells[21].Value.ToString().Trim();



                    dt.Rows.Add(row);





                }

            }



            return dt;

        }




        /// <summary>
        /// change all the off day Present to ot1.5
        /// </summary>
        public void offDayCalculator()
        {
          //  Boolean offday=false ;
            try
            {

                if (lbl_daystatus.Text != "Working Day")
                {

                    if (lbl_daystatus.Text == "WEEKLY OFF")
                    {

                        for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                        {


                            if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT1.5")
                            {
                                if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString().Trim())))
                                {
                                    //    offday=true;
                                    tbl_DailyTime.Rows[i].Cells[10].Value = "OT2.0";
                                    //  ATCHRM.Controls.ATCHRMMessagebox.Show(offday.ToString ());
                                }



                            }
                            if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT1.5")
                            {
                                if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString().Trim())))
                                {

                                    tbl_DailyTime.Rows[i].Cells[11].Value = "OT2.0";
                                }

                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {


                        if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT1.5")
                        {
                            if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString().Trim())))
                            {
                                //    offday=true;
                                tbl_DailyTime.Rows[i].Cells[10].Value = "OT2.0";
                                //  ATCHRM.Controls.ATCHRMMessagebox.Show(offday.ToString ());
                            }



                        }
                        if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT1.5")
                        {
                            if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString().Trim())))
                            {

                                tbl_DailyTime.Rows[i].Cells[11].Value = "OT2.0";
                            }

                        }
                    }
                }
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
        }

        /// <summary>
        /// CHECK IF THE EMPLOYEE HAS A APPROVED OT ON THAT DAY AND DOES THE ACTION
        /// </summary>
        public void OTapplyaction()
        {


            try
            {
                for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                {


                    if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
                    {
                        if (int.Parse(tbl_DailyTime.Rows[i].Cells[17].Value.ToString().Trim()) != 0)
                        {
                            int otdone = int.Parse(tbl_DailyTime.Rows[i].Cells[16].Value.ToString().Trim());
                            int approvedot = int.Parse(tbl_DailyTime.Rows[i].Cells[17].Value.ToString().Trim());

                            // IF THE EMPLOYEE DOES WORK LESSER THAN THE APPROVED OT 
                            //THEN HIS WORK LH REMAINING TIME IS MARKED AS UUOT

                            if (approvedot >= otdone)
                            {

                                int balance = approvedot - otdone;
                              
                                if (balance != 0)
                                {
                                    tbl_DailyTime.Rows[i].Cells[20].Value = balance;
                                    tbl_DailyTime.Rows[i].Cells[21].Value = "UUOT";
                                }
                            }
                            //IF THE EMPLOYEE WORKED MORE THAN THE APPROVED OT
                            ///THEN HIS EXTRA TIME WILL GO FOR THE  UOT
                            else
                            {
                                int extra = otdone - approvedot;
                              //  otdone = approvedot;
                                tbl_DailyTime.Rows[i].Cells[16].Value = approvedot;
                                if (extra != 0)
                                {
                                    tbl_DailyTime.Rows[i].Cells[20].Value = extra;
                                    tbl_DailyTime.Rows[i].Cells[21].Value = "UOT";
                                }
                            }
                            tbl_DailyTime.Rows[i].Cells[11].Value = "OT1.5";
                        }


                    }









                }


            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }








        }


/// <summary>
/// IF THE EMPLOYEE HAVE AN APPROVED LHR
/// AND IF HE HAD DONE SOME UOT
/// THEN THE ACTION TAKE PLACE
/// </summary>
        public void LHRapplyaction()
        {
            try
            {
                for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                {

                    if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
                    {
                        if (int.Parse(tbl_DailyTime.Rows[i].Cells[18].Value.ToString().Trim()) != 0)
                        {

                            int uotdone = int.Parse(tbl_DailyTime.Rows[i].Cells[16].Value.ToString().Trim());
                            int approvedlhr = int.Parse(tbl_DailyTime.Rows[i].Cells[18].Value.ToString().Trim());

                            if (uotdone > approvedlhr)
                            {

                                int extra = uotdone - approvedlhr;

                                if (extra != 0)
                                {
                                    tbl_DailyTime.Rows[i].Cells[16].Value = approvedlhr;
                                    tbl_DailyTime.Rows[i].Cells[20].Value = extra;
                                    tbl_DailyTime.Rows[i].Cells[21].Value = "UOT";
                                }
                            }
                            else
                            {
                                int balance = approvedlhr - uotdone;
                                if (balance != 0)
                                {
                                    tbl_DailyTime.Rows[i].Cells[20].Value = balance;
                                    tbl_DailyTime.Rows[i].Cells[21].Value = "ULHR";

                                }
                            }
                            tbl_DailyTime.Rows[i].Cells[11].Value = "LHR";
                        }
                    }



                }
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }


        }







/// <summary>
///  IF THE EMPLOYEE HAD A LEAVE APPROVED ON THAT DAY
/// </summary>

        public void LeaveAction()
        {
            for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
            {
                if (tbl_DailyTime.Rows[i].Cells[19].Value.ToString().Trim() != "N")
                {

                    if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "A")
                    {

                        tbl_DailyTime.Rows[i].Cells[10].Value = tbl_DailyTime.Rows[i].Cells[19].Value; 

                    }
                    if (tbl_DailyTime.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                    {

                        tbl_DailyTime.Rows[i].Cells[11].Value = tbl_DailyTime.Rows[i].Cells[19].Value; 

                    }

                }

            }
        }

        /// <summary>
        /// get any off days or leave of that days
        /// </summary>

        public void checkWhetheroffday()
        {
            try
            {

                lbl_day.Text = dtp_datetoday.Value.Date.DayOfWeek.ToString(); ;


                DataTable dt = hldytransaction.getAnyHolidayofaDate(dtp_datetoday.Value.Date, int.Parse(Cmb_location.SelectedValue.ToString()));

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        lbl_daystatus.Text = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        lbl_daystatus.Text = "Working Day";
                    }
                }


            }
            catch (Exception exp)
            {


                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);

            }
        }

     

        private void Cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
        }
        /// <summary>
        /// restrict the acess to the other factories
        /// </summary>
        public void resrictacess()
        {
            try
            {
                if (locationflag != 0)
                {
                    if (Program.UserType == "A" || Program.UserType == "M")
                    {

                    }
                    else
                    {

                        if (int.Parse(Cmb_location.SelectedValue.ToString()) != Program.LOCTNPK)
                        {
                             ATCHRM.Controls.ATCHRMMessagebox.Show("You Are Not Allowed to Acess This Location Data");
                            Cmb_location.SelectedValue = Program.LOCTNPK;
                        }



                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void DailyAttendanceMaster_Load(object sender, EventArgs e)
        {
            checkWhetheroffday();
        }










        /// <summary>
        /// calculate the Off day
        /// 
        /// </summary>
        public void offdayDataentry()
        {
            try
            {
                if (lbl_daystatus.Text == "WEEKLY OFF")
                {


                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {
                        if (tbl_DailyTime.Rows[i].Cells[22].Value.ToString().Trim() == "Off Day")
                        {
                            if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT2.0" && tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT2.0")
                            {


                                ArrayList emparrylst = new ArrayList();
                                emparrylst.Add(int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));

                                emparrylst.Add(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()));

                                //     emparrylst.Add(  DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString ());

                                double duration = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes;
                                int myduration = int.Parse(Math.Truncate(duration).ToString());

                                emparrylst.Add(myduration);

                                // ATCHRM.Controls.ATCHRMMessagebox.Show(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString());
                                atndncemngmnt.insertEmployeeOffOvertime(emparrylst);
                            }
                        }
                    }
                }
                else if (lbl_daystatus.Text == "Working Day")
                {
                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {

                        // IF IT IS WEEKLY OF FOR COMPANY AND OFF DAY FOR THE EMPLOYEE HE WILL GET A OT2.0
                        if (tbl_DailyTime.Rows[i].Cells[22].Value.ToString().Trim() == "Off Day")
                        {
                            ArrayList emparrylst = new ArrayList();
                            emparrylst.Add(int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));

                            emparrylst.Add(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()));

                            //     emparrylst.Add(  DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString ());

                            double duration = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes;
                            int myduration = int.Parse(Math.Truncate(duration).ToString());

                            emparrylst.Add(myduration);

                            // ATCHRM.Controls.ATCHRMMessagebox.Show(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString());
                            atndncemngmnt.insertEmployeeOffOvertime(emparrylst);

                        }

                    }

                }
                else
                {

                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {
                        if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT2.0" && tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT2.0")
                        {


                            ArrayList emparrylst = new ArrayList();
                            emparrylst.Add(int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));

                            emparrylst.Add(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()));

                            //     emparrylst.Add(  DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString ());

                            double duration = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes;
                            int myduration = int.Parse(Math.Truncate(duration).ToString());

                            emparrylst.Add(myduration);

                            // ATCHRM.Controls.ATCHRMMessagebox.Show(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString());
                            atndncemngmnt.insertEmployeeOffOvertime(emparrylst);
                        }
                    }

                }
            }
            catch (Exception exp )
            {
                   ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
               
            }


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public void AdjustmissingValue(int rowindex , String Status, int invalue)
        {
            if (Status == "P")
            {
                atndncemngmnt.inserCorretiondata(int.Parse(tbl_DailyTime.Rows[rowindex].Cells[0].Value.ToString()), 0, dtp_datetoday.Value.Date, "A", 0);
            }
            else
            {
                atndncemngmnt.inserCorretiondata(int.Parse(tbl_DailyTime.Rows[rowindex].Cells[0].Value.ToString()), 0, dtp_datetoday.Value.Date, "LH", invalue);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (rbt_swipe.Checked == true)
            {
                if (tbl_DailyTime.Rows[tbl_DailyTime.CurrentCell  .RowIndex ].Cells[9].Value.ToString().Trim() == "N")
                {

                    if (tbl_DailyTime.Rows[tbl_DailyTime.CurrentCell.RowIndex].Cells[8].Value.ToString().Trim() == "A")
                    {

                        AdjustmissingValue(tbl_DailyTime.CurrentCell.RowIndex, "P",0);
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    }
                    //if (tbl_DailyTime.Rows[tbl_DailyTime.CurrentCell.RowIndex].Cells[8].Value.ToString().Trim() == "A")
                    //{

                    //    AdjustmissingValue(tbl_DailyTim.RowIndex, "P");
                    //     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    //}


                    else
                    {
                        lblStatus.Text = "Correction Can Occur Only to Abscenties";
                    }
                }
                else
                {
                    lblStatus.Text = "Cannot Apply Attendance  Correction for Closed Days ";
                }
            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Attendance Correction Can be Done Only from the Swipe In Screen");
            }
        }

        private void mrk_present_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tbl_DailyTime_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_DailyTime.IsCurrentCellDirty)
            {
                tbl_DailyTime.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {


               currentrowindex = tbl_DailyTime.CurrentCell.RowIndex;
            if (rbt_swipe.Checked == true)
            {
                if (tbl_DailyTime.Rows[currentrowindex].Cells[9].Value.ToString().Trim() == "N")
                {

                    if (tbl_DailyTime.Rows[currentrowindex].Cells[8].Value.ToString().Trim() == "A")
                    {



                        Lh_panel.Visible = true;
                        
                  //     AdjustmissingValue(tbl_DailyTime.CurrentCell.RowIndex, "P",int.Parse (txt_LH.Text));
                      
                    }
                    //if (tbl_DailyTime.Rows[tbl_DailyTime.CurrentCell.RowIndex].Cells[8].Value.ToString().Trim() == "A")
                    //{

                    //    AdjustmissingValue(tbl_DailyTim.RowIndex, "P");
                    //     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    //}


                    else
                    {
                        lblStatus.Text = "Correction Can Occur Only to Abscenties";
                    }
                }
                else
                {
                    lblStatus.Text = "Cannot Apply Attendance  Correction for Closed Days ";
                }
            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Attendance Correction Can be Done Only from the Swipe In Screen");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_LH.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
                //}

            }
        }

        public Boolean NumberValidation(object sender, KeyPressEventArgs e)
        {
            Boolean VALID = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46)
            {
                VALID = false;
            }
            else
            {
                VALID = true;
            }
            return VALID;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_LH.Text);
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Over  Time";
                txt_LH.Text = "0";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txt_LH.Text != null || txt_LH.Text != "")
            {
                AdjustmissingValue(currentrowindex , "LH",int.Parse ( txt_LH.Text) );
                Lh_panel.Visible = false;
                txt_LH.Text = "0";
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Lh_panel.Visible = false;
            txt_LH.Text = "0";
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
         
            // the code that you want to measure comes here
            if(isdateaccesible(Program.Datetoday ,dtp_datetoday.Value.Date )){

            checkWhetheroffday();
            getshiftdataofadateadata(1);
            btn_all.Enabled = false;
            }
            else
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show("You are not allowed to Close register Days older than 3 Days");
            }
            
        }



        /// <summary>
        /// check whether the date is Acessible
        /// </summary>
        /// <param name="actualdate"></param>
        /// <param name="selecteddate"></param>
        /// <returns></returns>
        public Boolean isdateaccesible(DateTime actualdate, DateTime selecteddate)
        {
            Boolean issuccess = true;

            DateTime backlimit = actualdate.AddDays(-3);

            DateTime uplimit = actualdate;



           

            return issuccess;
        }
  










        private void button3_Click(object sender, EventArgs e)
        {
            String searchValue = txt_oldempid.Text;
            int rowIndex = -1;
            int oldidcolumnno = 0;

            if (rbt_swipe.Checked == true)
            {
                oldidcolumnno = 11;
            }
            else if (rbt_swipeOut.Checked == true)
            {
                oldidcolumnno = 11;
            }


            else if (RBT_INOUT.Checked == true)
            {
                oldidcolumnno = 24;
            }
            

            foreach (DataGridViewRow row in tbl_DailyTime .Rows)
            {
                if (row.Index != tbl_DailyTime.RowCount - 1)
                {
                    if (row.Cells[oldidcolumnno].Value.ToString().Equals(searchValue))
                    {

                        rowIndex = row.Index;
                        tbl_DailyTime.FirstDisplayedScrollingRowIndex = rowIndex;
                        tbl_DailyTime.Rows[rowIndex].Selected = true;
                    }
                }
            }
        }





    }
}

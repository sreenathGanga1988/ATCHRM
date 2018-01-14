using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;
namespace ATCHRM.Payroll
{
    public partial class IndividualPayrollForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.PayrollTransaction.SalaryCalculatuionTransaction salpaytrans = null;
        Transactions.PayrollTransaction.MainPayrollTransaction paytrrans = null;
        Datalayer.PayrollEmployeeDetailsDataBean payrollEmpDetailDataBean = null;
        Transactions.ActionTransactions actntran = null;
        int diffDays = 0;
        Datalayer.PayrollDatabean payrolldatabean = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        int payrollid = 0;
        int empflag = 0;
        DataTable payrollcalender = null;
        public IndividualPayrollForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            salpaytrans = new Transactions.PayrollTransaction.SalaryCalculatuionTransaction();
            paytrrans = new Transactions.PayrollTransaction.MainPayrollTransaction();
            payrollEmpDetailDataBean = new Datalayer.PayrollEmployeeDetailsDataBean();
            actntran = new Transactions.ActionTransactions();
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



        /// <summary>
        /// loads the payroll months and year
        /// </summary>
        public void Payrolcalendrerload()
        {
            cmb_payrollmonth .DataSource = null;
            payrollcalender = paytrrans.getPayrollCalender();
            cmb_payrollmonth.DataSource = payrollcalender;
            cmb_payrollmonth.DisplayMember = "payrollmonth";
            cmb_payrollmonth.ValueMember = "Payrolldateid";

            
        }


















        /// <summary>
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        /// <summary>
        /// get all the designation
        /// against a given dept
        /// </summary>
        public void getallDesignation()
        {

            if (deptchangeflag != 0)
            {


                if (cmb_dept.SelectedValue != null)
                {


                    cmb_designation.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_dept.SelectedValue.ToString()));

                    cmb_designation.DisplayMember = "DESGN";
                    cmb_designation.ValueMember = "SL";
                    cmb_designation.DataSource = dt;
                }

            }
        }

        /// <summary>
        /// get the employee code of the persons
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
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

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Branch location";

            }
            else if (cmb_dept.Text == "" || cmb_dept.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), 0, 0);
            }
            else if (cmb_designation.Text == "" || cmb_designation.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
            }
            else
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
            }
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

       

        /// <summary>
        /// get how much ot lh off ot etc done by the employee
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public DataTable  getemployeedetails(int employeeid)
        {
            DataTable leavedata = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT     UOT, LH, OT, OffOT, LHR FROM         FinalEmployeeDuty_tbl WHERE     (empid = @Param1)", con))
                {

                    cmd.Parameters.AddWithValue("@Param1", employeeid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    leavedata.Load(reader);


                }
            }

            return leavedata;


        }

        private void IndividualPayrollForm_Load(object sender, EventArgs e)
        {
          salcomp =GridViewmModels.ClsDatabase.Get_Data("select salcomppk,componentname from SalComponentMaster_tbl");
            locationListLoad();
            Payrolcalendrerload();
            DeptcomboLoad();
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptchangeflag != 0)
            {
                if (Process_payroll() == true)
                {
                    MessageBox.Show("Salary Processed For this Period", "ATC HRM");
                    return;
                }
                getallDesignation();
            }
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

       

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            empflag++;
        }

        /// <summary>
        /// fill the employee duty table and leave table
        /// </summary>
        /// <param name="empid"></param>

        public void fillaction(int empid)
        {
            try
            {
             
                
                
                int k = 0;
               DateTime fromdate = dtp_Fromdate.Value.Date;
               DateTime enddate = dtp_todate.Value.Date;

               try
               {
                   ArrayList arrylst = paytrrans.getStartandEndDateofpayroll(empid, dtp_Fromdate.Value.Date, dtp_todate.Value.Date);

                   fromdate = DateTime.Parse(arrylst[0].ToString()).Date ;
                   enddate = DateTime.Parse(arrylst[1].ToString()).Date ;
               }
               catch (Exception exp)
               {

                   ErrorLogger er = new ErrorLogger();
                   er.createErrorLog(exp);
               }

                //changed by sreenath on 26-05-2014
           //  DataTable leavtable = salpaytrans.getAllLeakeTaken(empid, dtp_Fromdate.Value.Date, dtp_todate.Value.Date);

                DataTable leavtable = salpaytrans.getAllLeakeTaken(empid, fromdate, enddate);
                
                DataTable attnddata = salpaytrans.GetEmployeeduties(empid);

                //changed by sreenath on 26-05-2014 
         //      diffDays = int.Parse ( (dtp_todate.Value.Date - dtp_Fromdate.Value.Date).TotalDays.ToString ())+1;
       //         k = salpaytrans.getClosedRegisterDays(empid, dtp_Fromdate.Value.Date, dtp_todate.Value.Date);

                diffDays = int.Parse((enddate - fromdate).TotalDays.ToString()) + 1;
                k = salpaytrans.getClosedRegisterDays(empid, enddate, fromdate);

                tbl_Empduty.Rows.Clear();
                tbl_EmpLeave.Rows.Clear();
                if (attnddata.Rows.Count != 0)
                {
                    tbl_Empduty.Rows.Add();
                    tbl_Empduty.Rows[0].Cells[0].Value = attnddata.Rows[0][0];
                    tbl_Empduty.Rows[0].Cells[1].Value = attnddata.Rows[0][1];
                    tbl_Empduty.Rows[0].Cells[2].Value = attnddata.Rows[0][2];
                    tbl_Empduty.Rows[0].Cells[3].Value = attnddata.Rows[0][3];
                    tbl_Empduty.Rows[0].Cells[4].Value = attnddata.Rows[0][4];
                    tbl_Empduty.Rows[0].Cells[5].Value = attnddata.Rows[0][5];

                }
                if (leavtable.Rows.Count != 0)
                {
                    for (int i = 0; i < leavtable.Rows.Count; i++)
                    {
                        tbl_EmpLeave.Rows.Add();
                        tbl_EmpLeave.Rows[i].Cells[0].Value = leavtable.Rows[i][0];
                        tbl_EmpLeave.Rows[i].Cells[1].Value = leavtable.Rows[i][1];
                        tbl_EmpLeave.Rows[i].Cells[2].Value = leavtable.Rows[i][2];
                        tbl_EmpLeave.Rows[i].Cells[3].Value = leavtable.Rows[i][3];
                        tbl_EmpLeave.Rows[i].Cells[4].Value = leavtable.Rows[i][5];


                        if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == null || tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            if (tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim() == null || tbl_EmpLeave.Rows[i].Cells[4].Value.ToString() == "")
                            {
                                tbl_EmpLeave.Rows[i].Cells[2].Value = tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim();
                            }
                            else
                            {
                                tbl_EmpLeave.Rows[i].Cells[2].Value = "A";
                            }

                            
                            
                        }
                        if (tbl_EmpLeave.Rows[i].Cells[3].Value.ToString() == null || tbl_EmpLeave.Rows[i].Cells[3].Value.ToString() == "")
                        {
                            tbl_EmpLeave.Rows[i].Cells[3].Value = "NA";                           
                        }
                    }

                }


               leaveAndAbscentCalculator(empid ,fromdate ,enddate );
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
        }

        /// <summary>
        /// Created by sreenath for testing
        /// </summary>
        /// <param name="payrollEmpDetailDatabean"></param>
        public void fillaction(Datalayer.PayrollEmployeeDetailsDataBean  payrollEmpDetailDatabean)
        {

            int empid = payrollEmpDetailDatabean.empid;
            try
            {



                int k = 0;
                payrollEmpDetailDatabean.PayrollFromDate  = dtp_Fromdate.Value.Date;
                payrollEmpDetailDatabean.payrollToDate  = dtp_todate.Value.Date;

                try
                {
                    ArrayList arrylst = paytrrans.getStartandEndDateofpayroll(empid, dtp_Fromdate.Value.Date, dtp_todate.Value.Date);

                    payrollEmpDetailDatabean.PayrollFromDate = DateTime.Parse(arrylst[0].ToString()).Date;
                    payrollEmpDetailDatabean.payrollToDate = DateTime.Parse(arrylst[1].ToString()).Date;
                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }

                DateTime fromdate = payrollEmpDetailDatabean.PayrollFromDate.Date;
                DateTime todate = payrollEmpDetailDatabean.payrollToDate.Date;


                //changed by sreenath on 26-05-2014
                //  DataTable leavtable = salpaytrans.getAllLeakeTaken(empid, dtp_Fromdate.Value.Date, dtp_todate.Value.Date);

                DataTable leavtable = salpaytrans.getAllLeakeTaken(empid, fromdate, todate);

                DataTable attnddata = salpaytrans.GetEmployeeduties(empid);

                //changed by sreenath on 26-05-2014 
                //      diffDays = int.Parse ( (dtp_todate.Value.Date - dtp_Fromdate.Value.Date).TotalDays.ToString ())+1;
                //         k = salpaytrans.getClosedRegisterDays(empid, dtp_Fromdate.Value.Date, dtp_todate.Value.Date);

                diffDays = int.Parse((payrollEmpDetailDatabean.payrollToDate - payrollEmpDetailDatabean.PayrollFromDate).TotalDays.ToString()) + 1;
               // k = salpaytrans.getClosedRegisterDays(empid, fromdate , todate);

                payrollEmpDetailDatabean.Payrolldays = diffDays;
            //    lbl_closednum.Text = k.ToString() + "  Records Out of    " + diffDays + "   Records Present";
                tbl_Empduty.Rows.Clear();
                tbl_EmpLeave.Rows.Clear();
                if (attnddata.Rows.Count != 0)
                {
                    tbl_Empduty.Rows.Add();
                    tbl_Empduty.Rows[0].Cells[0].Value = attnddata.Rows[0][0];
                    tbl_Empduty.Rows[0].Cells[1].Value = attnddata.Rows[0][1];
                    tbl_Empduty.Rows[0].Cells[2].Value = attnddata.Rows[0][2];
                    tbl_Empduty.Rows[0].Cells[3].Value = attnddata.Rows[0][3];
                    tbl_Empduty.Rows[0].Cells[4].Value = attnddata.Rows[0][4];
                    tbl_Empduty.Rows[0].Cells[5].Value = attnddata.Rows[0][5];

                }
                if (leavtable.Rows.Count != 0)
                {
                    for (int i = 0; i < leavtable.Rows.Count; i++)
                    {
                        tbl_EmpLeave.Rows.Add();
                        tbl_EmpLeave.Rows[i].Cells[0].Value = leavtable.Rows[i][0];
                        tbl_EmpLeave.Rows[i].Cells[1].Value = leavtable.Rows[i][1];
                        tbl_EmpLeave.Rows[i].Cells[2].Value = leavtable.Rows[i][2];
                        tbl_EmpLeave.Rows[i].Cells[3].Value = leavtable.Rows[i][3];
                        tbl_EmpLeave.Rows[i].Cells[4].Value = leavtable.Rows[i][5];


                        if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == null || tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            //{
                            //if (tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim() == null || tbl_EmpLeave.Rows[i].Cells[4].Value.ToString() == "")
                            //{
                            //    tbl_EmpLeave.Rows[i].Cells[2].Value = tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim();
                            //}
                            if (tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim() == null || tbl_EmpLeave.Rows[i].Cells[4].Value.ToString() == "")
                            {
                                tbl_EmpLeave.Rows[i].Cells[2].Value = tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim();
                            }

                            else
                            {
                                if (tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim() == "SHD" || tbl_EmpLeave.Rows[i].Cells[4].Value.ToString() == "HD" || tbl_EmpLeave.Rows[i].Cells[4].Value.ToString() == "HPL")
                                {
                                    tbl_EmpLeave.Rows[i].Cells[2].Value = tbl_EmpLeave.Rows[i].Cells[4].Value.ToString().Trim();
                                }
                                else
                                {

                                    tbl_EmpLeave.Rows[i].Cells[2].Value = "A";
                                }
                            }





                        }
                        if (tbl_EmpLeave.Rows[i].Cells[3].Value.ToString() == null || tbl_EmpLeave.Rows[i].Cells[3].Value.ToString() == "")
                        {
                            tbl_EmpLeave.Rows[i].Cells[3].Value = "NA";
                        }
                    }

                }


                leaveAndAbscentCalculator(payrollEmpDetailDatabean);
            }
            catch (Exception exp)
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
        }

        /// <summary>
        /// created by sreenath for testing
        /// </summary>
        /// <param name="payrollEmpDetailDatabean"></param>
        public void leaveAndAbscentCalculator(Datalayer.PayrollEmployeeDetailsDataBean payrollEmpDetailDatabean)
        {
            int empid = payrollEmpDetailDatabean.empid;
            DateTime fromdate = payrollEmpDetailDatabean.PayrollFromDate.Date  ;
            DateTime todate = payrollEmpDetailDatabean.payrollToDate .Date ;
            int rownumber = tbl_EmpLeave.Rows.Count;
            float leaveflag = 0;
            float abscentflag = 0;
            float halfdayabsdcent = 0;
            int halfdayleaveflag = 0;
            lbl_total.Text = rownumber.ToString();
            int offdays = 0;
            int holidaynum = 0;
            int leaveonoffday=0;
            int leaveonholiday=0;
            int paidleave = 0;
            string[] Leave = { "SL", "ML", "OSD", "FL", "PL", "AL"};

            String[] PaidLeavelist = { "SL", "ML", "FL" ,"PL","AL"};
            try
                
            {
              // fromdate= new DateTime (fromdate.)
             //   fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 00, 00, 00);
             //   todate = new DateTime(todate.Year, todate.Month, todate.Day, 0, 0, 0);


              
                offdays = salpaytrans.GetoffdayOfEmployeeeInPeriod(empid, fromdate.Date, todate.Date);
                holidaynum = salpaytrans.getemployeeHolidayinPeriod(empid, fromdate, todate);
                leaveonoffday = salpaytrans.getLeaveOnOffDays (empid, fromdate, todate);
                leaveonholiday = salpaytrans.getLeaveOnHoliDays(empid, fromdate, todate);



                
            }

                  

               
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
            }

            for (int i = 0; i < rownumber; i++)
            {

                if (PaidLeavelist.Contains(tbl_EmpLeave.Rows[i].Cells[2].Value.ToString()))
                {
                    paidleave++;

                }

                if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "A")
                {
                    abscentflag++;

                }
                else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "UPL")
                {
                    abscentflag++;

                }
                //else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() != "A" && tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() != "UPL")
                //{
                //    leaveflag++;
                //}

                else  if (Leave.Contains(tbl_EmpLeave.Rows[i].Cells[2].Value.ToString()))
                {
                    leaveflag++;
                }

                else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "HD")
                {
                    halfdayabsdcent++;
                }
                else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "SHD" || tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "HPL")
                {
                    halfdayleaveflag++;
                }
            }


            payrollEmpDetailDataBean.Abscent_no = abscentflag;
            payrollEmpDetailDataBean.Holidayno = holidaynum;
            payrollEmpDetailDataBean.Leave_Days1 = leaveflag;
            payrollEmpDetailDataBean.Halfdayabscent = halfdayabsdcent;
            payrollEmpDetailDataBean.Halfdayleave = halfdayleaveflag;
            payrollEmpDetailDatabean.LeaveonOffday1 = leaveonoffday;
            payrollEmpDetailDatabean.Offdays = offdays;
            payrollEmpDetailDatabean.Paidleaves = paidleave;
            payrollEmpDetailDataBean.Leaveonholiday = leaveonholiday;
          
            
            
            
            if (abscentflag >= 0)
            {
                //abscentflag = abscentflag - (holidaynum);
////// changed on 27-03-2016
                //abscentflag = abscentflag - (holidaynum) + leaveonoffday + leaveonholiday;

                //offabscentflag = 3;
                //offleave=1

                //    holidaynum=1
                // changed on 30-03-2016
                abscentflag = abscentflag;
               
            }

            if (halfdayabsdcent > 0)
            {
                halfdayabsdcent = halfdayabsdcent / 2;
                abscentflag = abscentflag + halfdayabsdcent;
            }
            if (halfdayleaveflag > 0)
            {
                halfdayleaveflag = halfdayleaveflag / 2;
                leaveflag = leaveflag + halfdayabsdcent;
            }


            lbl_leavestaken.Text = leaveflag.ToString();
            lbl_abscentdays.Text = abscentflag.ToString();

        }



        /// <summary>
        /// check how many days are Abscent
        /// or leave taken
        /// </summary>

        public void leaveAndAbscentCalculator(int empid , DateTime fromdate , DateTime todate)
        {
            int rownumber =tbl_EmpLeave.Rows.Count;
            float leaveflag = 0;
            float abscentflag = 0;
            float halfdayabsdcent = 0;
            int halfdayleaveflag = 0;
            lbl_total.Text  = rownumber.ToString ();
            int offdays =0;
            int holidaynum = 0;
            try
            {
                offdays = salpaytrans.GetoffdayOfEmployeeeInPeriod(empid, fromdate, todate);
                holidaynum = salpaytrans.getemployeeHolidayinPeriod(empid, fromdate, todate);
            }
            catch (Exception exp)
            {
                
                ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                    ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
            }

            for (int i = 0; i < rownumber;i++ )
            {
                if ( tbl_EmpLeave.Rows[i].Cells[2].Value.ToString () == "A")
                {
                    abscentflag++;

                }
                else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "UPL")
                {
                    abscentflag++;

                }
                else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() != "A" && tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() != "UPL")
                {


                    leaveflag++;


                }
                else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "HD")
                {
                    halfdayabsdcent++;
                }
                else if (tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "SHD" || tbl_EmpLeave.Rows[i].Cells[2].Value.ToString() == "HPL")
                {
                    halfdayleaveflag++;
                }
            }

            if (abscentflag > 0)
            {
                abscentflag = abscentflag - (offdays+holidaynum);
            }

            if (halfdayabsdcent > 0)
            {
                halfdayabsdcent = halfdayabsdcent / 2;
                abscentflag = abscentflag + halfdayabsdcent;
            }
            if (halfdayleaveflag > 0)
            {
                halfdayleaveflag = halfdayleaveflag / 2;
                leaveflag = leaveflag + halfdayabsdcent;
            }


            lbl_leavestaken.Text = leaveflag.ToString ();
            lbl_abscentdays.Text = abscentflag.ToString();

        }

        private Boolean Process_payroll()
        {
            Boolean flg = false;

                  

            
            return flg;
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            #region Clearedregion
            tbl_deduction.RowCount = 0;
            tbl_disbursement.RowCount = 0;
            tbl_Empduty.RowCount = 0;
            tbl_EmpLeave.RowCount = 0;
            if (empflag > 0)
            {
                try
                {

                    fillaction(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                    getsalcomponents(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                }
                catch (Exception)
                {


                }
            } 
            #endregion
        }



        public void getsalcomponents(int empidno)
        {

        // DataTable dt = salpaytrans.getEmployeeSalComponents(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
            DataTable dt = salpaytrans.getEmployeeSalComponents(empidno);

            if (dt.Rows.Count != 0)
            {
               
                int j = 0;
                int k = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == "Deduction")
                    {
                        tbl_deduction.Rows.Add();
                        tbl_deduction.Rows[j].Cells[0].Value = dt.Rows[i][0];
                        tbl_deduction.Rows[j].Cells[1].Value = dt.Rows[i][1];
                        tbl_deduction.Rows[j].Cells[2].Value = dt.Rows[i][2];
                        tbl_deduction.Rows[j].Cells[3].Value = dt.Rows[i][3];
                        tbl_deduction.Rows[j].Cells[4].Value = dt.Rows[i][4];

                        j++;

                    }
                    else if (dt.Rows[i][2].ToString() == "Disbursement")
                    {

                        tbl_disbursement.Rows.Add();
                        tbl_disbursement.Rows[k].Cells[0].Value = dt.Rows[i][0];
                        tbl_disbursement.Rows[k].Cells[1].Value = dt.Rows[i][1];
                        tbl_disbursement.Rows[k].Cells[2].Value = dt.Rows[i][2];
                        tbl_disbursement.Rows[k].Cells[3].Value = dt.Rows[i][3];
                        tbl_disbursement.Rows[k].Cells[4].Value = dt.Rows[i][4];

                        k++;
                    }
                }
            }



        }

        private double Disburse(int empn)
        {
            double dis = 0.0;
            try
            {
                if (tbl_disbursement.Rows.Count > 0)
                {
                    for (int i = 0; i < tbl_disbursement.Rows.Count; i++)
                    {
                        if (Convert.ToString(tbl_disbursement.Rows[i].Cells[4].Value) != "Formula")
                        {
                            if (tbl_disbursement.Rows[i].Cells[3].Value.ToString() == "" || tbl_disbursement.Rows[i].Cells[3].Value.ToString() == null)
                            {
                                tbl_disbursement.Rows[i].Cells[3].Value = 0;
                            }
                                dis = dis + Convert.ToDouble(tbl_disbursement.Rows[i].Cells[3].Value);
                            
                        }
                        else if (Convert.ToString(tbl_disbursement.Rows[i].Cells[4].Value) == "Formula")
                        {
                            DataSet dsf = GridViewmModels.ClsDatabase.Get_Data("select form_data from formula_details_tbl where form_name='" + tbl_disbursement.Rows[i].Cells[1].Value + "'");
                            if (dsf.Tables[0].Rows.Count > 0)
                            {
                                dis = dis + Evaluate(Formula_Value(Convert.ToString(dsf.Tables[0].Rows[0][0]), empn));
                            }

                        }

                    }
                }

            }
            catch (Exception)
            {
                
                throw;
            }
            return dis;
        }
        private double Deduct(int empn)
        {
            double dis = 0.0;
            if (tbl_deduction.Rows.Count > 0)
            {
                for (int i = 0; i < tbl_deduction.Rows.Count ; i++)
                {
                    if (Convert.ToString(tbl_deduction.Rows[i].Cells[4].Value) != "Formula")
                    {
                        dis = dis + Convert.ToDouble(tbl_deduction.Rows[i].Cells[3].Value);
                    }
                    else if (Convert.ToString(tbl_deduction.Rows[i].Cells[4].Value) == "Formula")
                    {
                        DataSet dsf = GridViewmModels.ClsDatabase.Get_Data("select form_data from formula_details_tbl where form_name='" + tbl_deduction.Rows[i].Cells[1].Value + "'");
                        if (dsf.Tables[0].Rows.Count > 0)
                        {
                            dis =dis+ Evaluate(Formula_Value(Convert.ToString(dsf.Tables[0].Rows[0][0]),empn));
                        }
                    }

                }
            }
            return dis;
        }
        static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
        DataSet salcomp;
        private string Formula_Value(string expression,int empidn)
        {
            string valu = "";
            try
            {
               
                char[] symb = { '+', '-', '*', '/', '%', '(', ')' };
                string[] var = expression.Split(symb);
                for (int i = 0; i < var.Length; i++)
                {
                    if (salcomp.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < salcomp.Tables[0].Rows.Count; j++)
                        {
                            if (var[i] == Convert.ToString(salcomp.Tables[0].Rows[j][1]))
                            {
                                DataSet comp = GridViewmModels.ClsDatabase.Get_Data("select amount from EmployeesalCompApplicable_tbl where salcomppk="
                                    + "" + salcomp.Tables[0].Rows[j][0] + " and empid=" + empidn + "");
                                if (comp.Tables[0].Rows.Count > 0)
                                {
                                    expression = expression.Replace(var[i], Convert.ToString(comp.Tables[0].Rows[0][0]));
                                }
                                else
                                {
                                    expression = expression.Replace(var[i], "0");
                                }
                            }
                        }
                    }
                }
                valu = expression;
                
            }
            catch (Exception )
            {
            }
            return valu;
        }
        private double ot_val(int otempid)
        {
            double ot1 = 0.0,ot2=0.0,totot=0.0;
            for (int i = 0; i < tbl_Empduty.Rows.Count; i++)
            {
                ot1 = ot1 + Evaluate(Formula_Value("BASIC/11700", otempid)) * Convert.ToDouble(tbl_Empduty.Rows[i].Cells[3].Value)*1.5;
                ot2 = ot2 + Evaluate(Formula_Value("BASIC/11700", otempid))*Convert.ToDouble(tbl_Empduty.Rows[i].Cells[4].Value)*2;
            }
            totot = ot1 + ot2;
            return totot;
        }
        int empidno = 0;











        public void doapayrollaction()
        {          
            if (Process_payroll() == true)
            {
                MessageBox.Show("Salary Processed For this Period", "ATC HRM");
                return;
            }
            else
            {
               
              
                DataTable dt = empregtrans.getEmpcodeforPayroll  (Convert.ToInt32(cmb_location.SelectedValue), 0, 0,"Normal");
               dt = dt.Select("empid=5").CopyToDataTable();
                if (dt.Rows.Count > 0)
                {

                    payrolldatabean = new Datalayer.PayrollDatabean();



                    payrolldatabean.BranchlocationPK1 = int.Parse(cmb_location.SelectedValue.ToString());

                    payrolldatabean.Deptid = int.Parse(cmb_dept.SelectedValue.ToString());

                    payrolldatabean.Empcount = dt.Rows.Count;
                    payrolldatabean.Payrollfromdate = DateTime.Parse(dtp_Fromdate.Value.ToString("dd/MMM/yyyy"));
                    payrolldatabean.PayrollEndDate = DateTime.Parse(dtp_todate.Value.ToString("dd/MMM/yyyy"));
                    payrolldatabean.Payrollmonth = cmb_payrollmonth.Text.Trim();

                    int payrollofmonthdays = int.Parse((payrolldatabean.PayrollEndDate - payrolldatabean.Payrollfromdate).TotalDays.ToString()) + 1;
                   
             payrolldatabean.Payroolid = paytrrans.InsertPayroll(payrolldatabean);

        //          payrolldatabean.Payroolid =0;
                    payrollid = payrolldatabean.Payroolid;                 

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tbl_deduction.RowCount = 0;
                        tbl_disbursement.RowCount = 0;
                        tbl_Empduty.RowCount = 0;
                        tbl_EmpLeave.RowCount = 0;
                        payrollEmpDetailDataBean = new Datalayer.PayrollEmployeeDetailsDataBean();
                        try
                        {

                           // empidno = Convert.ToInt32(dt.Rows[i][0]);
                           // fillaction(empidno);
                           // getsalcomponents(empidno);

                           payrollEmpDetailDataBean.empid = Convert.ToInt32(dt.Rows[i][0]);
                          
                          // payrollEmpDetailDataBean.empid =8448;
                           empidno = payrollEmpDetailDataBean.empid;
                          //  empidno = 7565;
                            payrollEmpDetailDataBean.Pay_Id1 = payrollid;
                            fillaction(payrollEmpDetailDataBean);
                            getsalcomponents(empidno);
                           
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                      
                        double disb = 0.0;
                        double ded = 0.0;
                        double otval = 0.0;
                        double totl = (disb - ded) + otval;
                        Boolean isotApplicable = false;
                        try
                        {
                            try
                            {
                                disb = Disburse(empidno);
                            }
                            catch (Exception)
                            {
                                
                                
                            }
                            try
                            {
                                ded = Deduct(empidno);
                            }
                            catch (Exception)
                            {
                                
                               
                            }
                            //check if the Ot is applicable for employee
                             if (actntran.isOTApplicableForEmployee(empidno))
                             {

                                 isotApplicable = true;
                                 otval = ot_val(empidno);
                             }
                             else
                             {
                                 isotApplicable = false;
                                 otval = 0;
                             }
                            totl = (disb - ded) + otval;
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }



                        ArrayList empdataarry = new ArrayList();

                        empdataarry.Add(payrolldatabean.Payroolid);
                        empdataarry.Add(empidno);
                        empdataarry.Add(totl);
                        empdataarry.Add(disb);
                        empdataarry.Add(ded);
                        empdataarry.Add(lbl_leavestaken.Text);
                        empdataarry.Add(lbl_abscentdays.Text);
                        empdataarry.Add(otval);
                        empdataarry.Add(payrolldatabean.Payrollmonth);
                        empdataarry.Add(payrolldatabean.Payrollfromdate);
                        empdataarry.Add(payrolldatabean.PayrollEndDate);

                       
                        payrollEmpDetailDataBean.Empdataarray = empdataarry;
                        payrollEmpDetailDataBean.IsOtapplicable = isotApplicable;
                        payrollEmpDetailDataBean.Payrollofthemonth = payrollofmonthdays;
                        paytrrans.insertemployeePayrollDetails(payrollEmpDetailDataBean);
                       // paytrrans.insertemployeePayrollDetails(empdataarry,diffDays );

                    }


                    DisplayPayroll();

                    Reports.FrmPayroll frl = new Reports.FrmPayroll(payrollid);
                    frl.Show();
                
                
                
                }

            }
        }


    

      

        /// <summary>
        /// when payroll button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                doapayrollaction();
                ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }

            
 
    }
     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_payrollmonth.Text != "")
                {
                   getstartandenddate(payrollcalender, int.Parse(cmb_payrollmonth.SelectedValue.ToString()));
                }
            }
            catch (Exception )
            {
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (Process_payroll() == false)
                {
                  //  fillaction(empidno);



                    dtp_Fromdate.Enabled = false;
                    dtp_todate.Enabled = false;
                    btn_payrollaction.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Salary Processed For this Period", "ATC HRM");
                    return;
                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }
        
        /// <summary>
        /// select the end date and start date for the payroll and then 
        /// set it to the datetimepickers
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="payrolldatid"></param>
        public void getstartandenddate(DataTable dt, int payrolldatid)
        {

            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DataRow[] result = dt.Select("Payrolldateid =" + payrolldatid + "");
                    foreach (DataRow row in result)
                    {
                        // Console.WriteLine("{0}, {1}", row[0], row[1]);
                        int numberofdays = int.Parse(row[2].ToString());
                        DateTime startdate = DateTime.Parse(row[3].ToString());
                        DateTime endate = DateTime.Parse(row[4].ToString());

                        dtp_Fromdate.Value = startdate;
                        dtp_todate.Value = endate;

                        btn_dateconfirm.Text = "Confirm " + numberofdays.ToString() + "   Days  ";
                        btn_dateconfirm.Visible = true;
                    }

                }
            }
           
        }


        /// <summary>
        /// display the data in grid
        /// </summary>
        public void DisplayPayroll()
        {
            DataSet ds = paytrrans.selectalldatafordisplay();
            if (ds.Tables[0].Rows.Count > 0)
            {
                mergeDatagridview1.RowCount = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    mergeDatagridview1.Rows.Add();
                    mergeDatagridview1.Rows[i].Cells[0].Value = 0;//location
                    mergeDatagridview1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][17];//department
                    mergeDatagridview1.Rows[i].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[i][2]) + "" + Convert.ToString(ds.Tables[0].Rows[i][3]);//emp name
                    mergeDatagridview1.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][22];//absent
                    mergeDatagridview1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][18];//LH
                    mergeDatagridview1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][14];//ot
                    mergeDatagridview1.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i][15];//off ot
                    mergeDatagridview1.Rows[i].Cells[7].Value = ds.Tables[0].Rows[i][19];//uot
                    mergeDatagridview1.Rows[i].Cells[8].Value = ds.Tables[0].Rows[i][20];//lhr
                    mergeDatagridview1.Rows[i].Cells[9].Value = 0;
                    double nhhif = 0;
                    double nssf = 0;
                    if (Convert.ToString(ds.Tables[0].Rows[i][8]) != "")
                    {
                        nhhif = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i][8]), 0);
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[i][7]) != "")
                    {
                        nssf = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i][7]), 0);
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[i][5]) != "")
                    {
                        mergeDatagridview1.Rows[i].Cells[10].Value = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i][5]), 0);
                    }
                    else
                    {
                        mergeDatagridview1.Rows[i].Cells[10].Value = "0";
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[i][9]) != "")
                    {
                        mergeDatagridview1.Rows[i].Cells[11].Value = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i][9]), 0) + nssf + nhhif;
                    }
                    else
                    {
                        mergeDatagridview1.Rows[i].Cells[10].Value = "0";
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[i][11]) != "")
                    {
                        mergeDatagridview1.Rows[i].Cells[12].Value = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i][1]), 0) - (nssf + nhhif);
                    }
                    else
                    {
                        mergeDatagridview1.Rows[i].Cells[12].Value = "0";
                    }
                }

            }
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }


}



    }

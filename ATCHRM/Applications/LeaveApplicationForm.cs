using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class LeaveApplicationForm : Form
    {
        Transactions.AnualContractrenewal annul = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.LeaveTransaction lvtransaction = null;
        Transactions.DepartmentTransaction depttrans = null;
        Datalayer.LeaveAppDatabean lvappdatabean = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.LeaveandAdvanceAppTransaction lveandadvancetrans = null;
        Transactions.LeaveTrabnsactionCalculator LVTRANSCAL = null;
        Transactions.leaveEnchasementTransaction lvencashmenttrans = null;
        DataTable employelvedetl = null;
        DataTable leaveencashed = null;
        int contractid = 0;
        String subcontractfromdate = null;
        String subcontracttodate = null;
        String currentyear = "";
        int encashedleave = 0;
        int pendingleave = 0;
        int flag = 0;
        int leaveflag = 0;
        /// <summary>
        /// constructor
        /// </summary>
        public LeaveApplicationForm()
        {
            InitializeComponent();
            lvtransaction = new Transactions.LeaveTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            lveandadvancetrans = new Transactions.LeaveandAdvanceAppTransaction();
            annul = new Transactions.AnualContractrenewal();
            empreg = new Transactions.EmployeeRegTransaction();
            LVTRANSCAL = new Transactions.LeaveTrabnsactionCalculator();
            lvencashmenttrans = new Transactions.leaveEnchasementTransaction();
            DeptcomboLoad();
            locationListLoad();
        }

        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";
            cmb_location.SelectedValue = Program.LOCTNPK;
        }
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmb_empcode.DataSource = dt;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
        }

        public void leavecomboLoad(int empid)
        {
            DataTable dt = lvtransaction.LeaveApplicabletoEmployee(empid);


            dt = dt.Select("SL <> 36 AND  SL <> 34 ").CopyToDataTable();
           cmb_leave.DataSource = dt;
            cmb_leave.DisplayMember = "LEAVE";
            cmb_leave.ValueMember = "SL";

            //cmb_leave.Items.Remove("HALF SICK LEAVE");
            //cmb_leave.Items.Remove("HALF PAID LEAVE");
        }
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag != 0)
            {
                if (Program.UserType == "U")
                {
                    if (int.Parse(cmb_location.SelectedValue.ToString()) != Program.LOCTNPK)
                    {
                         ATCHRM.Controls.ATCHRMMessagebox.Show("You are not allowed to Acess This Location");
                    }
                    else
                    {
                        if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
                        {
                            lblStatus.Text = "Enter the Branch location";

                        }
                        else
                        {
                            employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                        }
                    }
                }
            }
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            flag++;
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Branch location";

            }
            else
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
            }
        }

        private void dtpfrom_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_leave.Text.Trim() == "MATERNITY LEAVE"||cmb_leave.Text.Trim() == "PATERNITY LEAVE")
        {
                if (dtpfrom.Value.Date > dtrp_to.Value.Date)
                {
                    dtrp_to.Value = dtpfrom.Value.Date.AddDays(1);
                }
        }
                

            if (dtpfrom.Value.Date > dtrp_to.Value.Date)
            {
                lblStatus.Text = "Enter An Valid from date ";
                txtDays.Text = "0";

            }
            else if (!annul.ifdatevalidContractdate(int.Parse(cmb_empcode.SelectedValue.ToString()), dtpfrom.Value.Date))
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Date Out Of Contract period");

            }
            else
            {
                if (cmb_leave.Text.Trim() == "MATERNITY LEAVE")
                {
                    DateTime selelctedfromdate = dtpfrom.Value.Date;

                    DateTime todateforpaternity= selelctedfromdate.AddMonths (3);
                   
                        TimeSpan dt1 = todateforpaternity - selelctedfromdate;
                        txt_allowedday.Text = dt1.Days.ToString();
                        txt_mode.Text = "Days Per year";
                        lbl_monthordays.Text = "Days";

                    
                  //  dtrp_to.Value = todateforpaternity;
                    //added asper hiren
                    dtrp_to.Value = todateforpaternity.AddDays (-1);
                }

                else if(cmb_leave.Text.Trim() == "PATERNITY LEAVE")
                {
                    DateTime selelctedfromdate = dtpfrom.Value.Date;

                    DateTime todateforpaternity = selelctedfromdate.AddDays (14);

                    TimeSpan dt1 = todateforpaternity - selelctedfromdate;
                    txt_allowedday.Text = dt1.Days.ToString();
                    txt_mode.Text = "Days Per year";
                    lbl_monthordays.Text = "Days";


                    //  dtrp_to.Value = todateforpaternity;
                    //added asper hiren
                    dtrp_to.Value = todateforpaternity.AddDays(-1);
                }


                TimeSpan dt = dtrp_to.Value.Date - dtpfrom.Value.Date;
                int totday = int.Parse(dt.Days.ToString()) + 1;

                txtDays.Text = totday.ToString();

                lblStatus.Text = " ";
                cmb_daytype.Text = "Day";
            }
        }

        private void dtrp_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtpfrom.Value.Date > dtrp_to.Value.Date)
            {
                lblStatus.Text = "Enter An Valid from date ";
                txtDays.Text = "0";
                cmb_daytype.Text = "Day";
            }
            else if (!annul.ifdatevalidContractdate(int.Parse(cmb_empcode.SelectedValue.ToString()), dtrp_to.Value.Date))
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Date Out Of Contract period .Renew the Contract");

            }
            else
            {
               
                TimeSpan dt = dtrp_to.Value.Date - dtpfrom.Value.Date;
                int totday = int.Parse(dt.Days.ToString())+1;

                txtDays.Text = totday.ToString ();
                lblStatus.Text = " ";
            }
        }


        /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (cmb_empcode.Text == null || cmb_empcode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid EmployeCode";
                cmb_empcode.Focus();
                cmb_empcode.Visible = true;
            }
            else if (cmb_leave.Text == null || cmb_leave.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Leave Type";
                cmb_leave.Focus();
                cmb_leave.Visible = true;
            }
            //else if (cmb_leave.Text == null || cmb_leave.Text.Trim() == "")
            //{
            //    lblStatus.Text = "Enter Leave Type";
            //    cmb_leave.Focus();
            //    cmb_leave.Visible = true;
            //}
            else if (txtDays.Text == null || txtDays.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  CalculationMode ";
                txtDays.Focus();
                txtDays.Visible = true;
            }

            else if (int.Parse(txtDays.Text) > int.Parse(txt_daysleft.Text))
            {
                lblStatus.Text = "You are not Allowed to Exeed the Allowed Number of Days ";
                txtDays.Focus();
                txtDays.Visible = true;
            }

            //else if(DateTime.Parse (lbl_FrmDate.Text )>){
            //}
            else
            {
                sucess = true;
            }

            return sucess;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationControl())
                {
                    if (!lveandadvancetrans.IsLeaveApplicationpending(int.Parse(cmb_empcode.SelectedValue.ToString())))
                    {
                        if (!lveandadvancetrans.isLeaveApplicationAlreadyPresent(int.Parse(cmb_empcode.SelectedValue.ToString()), dtpfrom.Value.Date, dtrp_to.Value.Date))
                        {


                            lvappdatabean = new Datalayer.LeaveAppDatabean();
                            lvappdatabean.Empid = int.Parse(cmb_empcode.SelectedValue.ToString());
                            lvappdatabean.Leavepk1 = int.Parse(cmb_leave.SelectedValue.ToString());
                            lvappdatabean.Fromdate = dtpfrom.Value.Date;
                            lvappdatabean.Todate = dtrp_to.Value.Date;
                            lvappdatabean.Duration = int.Parse(txtDays.Text);
                            lvappdatabean.Mobilenum = txt_mobile.Text;
                            lvappdatabean.Durationtype1 = cmb_daytype.Text;
                            lvappdatabean.Telephonenum1 = txt_Telephone.Text;
                            lvappdatabean.Balance = 0;


                            String LeaveApplicationcode = lveandadvancetrans.insertLeaveApplication(lvappdatabean);
                            ATCHRM.Controls.ATCHRMMessagebox.Show("Apllication  " + LeaveApplicationcode + "Done");
                            this.Close();
                        }
                        else
                        {
                            ATCHRM.Controls.ATCHRMMessagebox.Show("Leave ApplicationAlready Exist for the  selected dayDay");
                        }
                    }
                    else
                    {
                        ATCHRM.Controls.ATCHRMMessagebox.Show("Leave Application Already Pending Approval");
                    }
                }
            }
            catch (Exception exp)
            {              

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            //     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }




        public void getcurrentcontractleave(int empid)
        {

            DataTable contractdata = annul.getCurrentSubContract(empid);
            if (contractdata.Rows.Count != 0)
            {
                contractid = int.Parse(contractdata.Rows[0][0].ToString());
                currentyear = contractdata.Rows[0][1].ToString();
                subcontractfromdate = DateTime.Parse(contractdata.Rows[0][2].ToString()).ToString("dd-MM-yyyy");
                subcontracttodate = DateTime.Parse(contractdata.Rows[0][3].ToString()).ToString("dd-MM-yyyy");
                lbl_joiningdate.Text =  DateTime.Parse(contractdata.Rows[0][4].ToString()).ToString("dd-MM-yyyy");
                txt_currentyear.Text = currentyear;
                lbl_FrmDate.Text = subcontractfromdate.ToString();
                lbl_todate.Text = subcontracttodate.ToString();
            }
        }

        private void cmb_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_empcode.Text.Trim() != null && cmb_empcode.Text.Trim() != "")
                {
                    try
                    {
                        tbl_empdata.DataSource = empreg.getEmployeOldIDandContract(int.Parse(cmb_empcode.SelectedValue.ToString()));
                        getcurrentcontractleave(int.Parse(cmb_empcode.SelectedValue.ToString()));
                    }
                    catch (Exception)
                    {
                        lblStatus.Text = "Select A Employee ID ";

                    }


                    try
                    {
                        leavecomboLoad(int.Parse(cmb_empcode.SelectedValue.ToString()));
                    }
                    catch (Exception)
                    {
                        lblStatus.Text = "Select A Leave ";

                    }

                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }
        }



        private void cmb_leave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (leaveflag != 0)
            {
                double availableleave = 0;



                DataTable dt = new DataTable();



                try
                {
                    int leavepk = int.Parse(cmb_leave.SelectedValue.ToString());
                    int empid = int.Parse(cmb_empcode.SelectedValue.ToString());



                    availableleave = LVTRANSCAL.employeeleavecalculatorstarter(empid, leavepk);

                    txt_allowedday.Text = availableleave.ToString();
                    employelvedetl = LVTRANSCAL.getallleavetakenbetweenperiod(empid, leavepk, Program.Datetoday);

                    try
                    {
                        //encashedleave = lvencashmenttrans.getAllPreviousEnchasementofYear(empid, leavepk, contractid, currentyear);
                        encashedleave = LVTRANSCAL.getallLeaveEncashed(empid, leavepk);
                        txT_ENCASHED.Text = encashedleave.ToString();
                    }
                    catch (Exception)
                    {
                        txT_ENCASHED.Text = "0";

                    }


                    try
                    {
                        //encashedleave = lvencashmenttrans.getAllPreviousEnchasementofYear(empid, leavepk, contractid, currentyear);
                        pendingleave = LVTRANSCAL.getallleavePending(empid, leavepk);
                        txt_Pending.Text = pendingleave.ToString();
                    }
                    catch (Exception)
                    {
                        txt_Pending.Text = "0";

                    }


                    if (employelvedetl.Rows.Count == 0)
                    {
                        lblStatus.Text = "No Leave of this Type Taken";
                        txt_leavetaken.Text = "0";

                    }
                    else
                    {

                        txt_leavetaken.Text = employelvedetl.Rows.Count.ToString();


                    }

                    checkingleavemode(leavepk, empid);

                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }

            }

        }

        private void txt_leavetaken_TextChanged(object sender, EventArgs e)
        {


            int daysleft = int.Parse(txt_allowedday.Text) - int.Parse(txt_leavetaken.Text) - int.Parse(txT_ENCASHED.Text) - int.Parse(txt_Pending.Text); 
            txt_daysleft.Text = daysleft.ToString();
        }

        private void txt_allowedday_TextChanged(object sender, EventArgs e)
        {
            int daysleft = int.Parse(txt_allowedday.Text) - int.Parse(txt_leavetaken.Text) - int.Parse(txT_ENCASHED.Text) - int.Parse(txt_Pending.Text);
            txt_daysleft.Text = daysleft.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (employelvedetl != null)
            {
                if (employelvedetl.Rows.Count != 0)
                {
                    Attendance.EmployeeLeaveAndOFf emplvfrm = new Attendance.EmployeeLeaveAndOFf(employelvedetl);
                    emplvfrm.MdiParent = this.MdiParent;
                    emplvfrm.Show();


                }
                else
                {
                    lblStatus.Text = "No Leave Data Found";
                }
            }
        }

       

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }









        public void checkingleavemode(int leavepk,int empid)
        {


            if (leavepk == 31)//Maternity leave
            {
                txt_mode.Text  = "Months Per year";
                lbl_monthordays.Text = "Month";

            }
            else if (leavepk == 34) //half sick days
            {
                txt_mode.Text = "Half Days Per year";
                lbl_monthordays.Text = "Half Days";
            }

            else// normal days
            {
                txt_mode.Text = "Days Per year";
                lbl_monthordays.Text = "Days";
            }


        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void cmb_leave_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (cmb_leave.SelectedValue != null || int.Parse(cmb_leave.SelectedValue.ToString()) != 0)
                {
                    leaveflag = 1;
                }
            }
            catch (Exception)
            {
                leaveflag = 0;
               
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Pending_TextChanged(object sender, EventArgs e)
        {
            int daysleft = int.Parse(txt_allowedday.Text) - int.Parse(txt_leavetaken.Text) - int.Parse(txT_ENCASHED.Text) - int.Parse(txt_Pending.Text);
            txt_daysleft.Text = daysleft.ToString();
        }





      

     



    }
}

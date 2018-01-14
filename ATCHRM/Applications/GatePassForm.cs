using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace ATCHRM.Applications
{
    public partial class GatePassForm : Form
    {
        Transactions.HolidayTransaction hldytransaction = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        public GatePassForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            hldytransaction = new Transactions.HolidayTransaction();

            employecodeload(Program.LOCTNPK, 0, 0);

        }







        //////////////////////////////////////////////////////////////////////////////////


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






       





     
       

        private void cmb_designation_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void cmb_designation_MouseClick_1(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
        }

        private void cmb_dept_MouseClick_1(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void GatePassForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }


        /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;

          if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid EmployeCode";
                cmb_EmpCode.Focus();
                cmb_EmpCode.Visible = true;
            }
          
            
            else if (rht_descriptiom.Text == null || rht_descriptiom.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  Description ";
                rht_descriptiom.Focus();
                rht_descriptiom.Visible = true;
            }

            else
            {
                sucess = true;
            }

            return sucess;

        }







        /// <summary>
        /// clculates the shift duration
        /// </summary>
        /// <returns></returns>
        public TimeSpan calculateduration()
        {
            TimeSpan swipein = dtp_GatepassDate .Value.TimeOfDay;
            TimeSpan swipeout = dtp_toTime.Value.TimeOfDay;
            TimeSpan duration;
            if (swipeout >= swipein)
            {
                duration = swipeout - swipein;
            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("From time cannot be greater than  the To time ");
                duration = swipeout + new TimeSpan(1, 0, 0, 0) - swipein;
            }

         //    ATCHRM.Controls.ATCHRMMessagebox.Show("Gatepass Duration = " + duration.ToString());

            return duration;
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_EmpCode.Text != "")
                {

                    ArrayList gatpaslst = new ArrayList();
                    //gatpaslst.Add(int.Parse(cmb_location.SelectedValue.ToString()));

                    //gatpaslst.Add(int.Parse(cmb_designation.SelectedValue.ToString()));
                    gatpaslst.Add(int.Parse(cmb_EmpCode.SelectedValue.ToString()));

                    gatpaslst.Add(DateTime.Parse(dtp_GatepassDate.Value.Date.ToString()));
                    gatpaslst.Add(DateTime.Parse(dtp_fromTime.Value.Date.ToString()));
                    gatpaslst.Add(DateTime.Parse(dtp_toTime.Value.Date.ToString()));
                    gatpaslst.Add(rht_descriptiom.Text);

                    hldytransaction.insertGatepass(gatpaslst);
                     ATCHRM.Controls.ATCHRMMessagebox.Show("GatePass Application Forwarded");

                }
                else
                {
                    lblStatus.Text = "No Empcode Selected";
                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                //         ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }
    
        private void dtp_fromTime_ValueChanged(object sender, EventArgs e)
        {
            calculateduration();
        }

        private void dtp_toTime_ValueChanged(object sender, EventArgs e)
        {
            calculateduration();
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }













    }
}

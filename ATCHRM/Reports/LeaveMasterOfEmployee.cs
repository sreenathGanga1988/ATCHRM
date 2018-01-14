using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Reports
{
    public partial class LeaveMasterOfEmployee : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.LeaveTransaction lvtransaction = null;
        Transactions.PayrollTransaction.SalaryCalculatuionTransaction salcaltransaction = null;
        Transactions.AnualContractrenewal annul = null;
        Transactions.DataExporter DTPEXPTR = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        public LeaveMasterOfEmployee()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lvtransaction = new Transactions.LeaveTransaction();
            salcaltransaction = new Transactions.PayrollTransaction.SalaryCalculatuionTransaction();
            annul = new Transactions.AnualContractrenewal();
        }


        public void leavecomboLoad(int empid)
        {
            DataTable dt = lvtransaction.LeaveApplicabletoEmployee(empid);
            cmb_leave.DataSource = dt;
            cmb_leave.DisplayMember = "LEAVE";
            cmb_leave.ValueMember = "SL";
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

        private void LeaveMasterOfEmployee_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();

        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
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

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt= lvtransaction.getLeaveApplicableandLeavetaken (int.Parse (cmb_EmpCode.SelectedValue.ToString ()));

            tbl_Employeedata.DataSource = dt;

            if(cmb_EmpCode .Text .Trim ()!="")
            {
                leavecomboLoad(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                getcurrentcontractleave(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
            }
               

        }


        public void getcurrentcontractleave(int empid)
        {

            DataTable contractdata = annul.getCurrentSubContract(empid);
            if (contractdata.Rows.Count != 0)
            {
                //contractid = int.Parse(contractdata.Rows[0][0].ToString());
                //currentyear = contractdata.Rows[0][1].ToString();
                dtp_from.Value  = DateTime.Parse(contractdata.Rows[0][2].ToString());
                dtp_to .Value = DateTime.Parse(contractdata.Rows[0][3].ToString());
                lbl_joiningdate.Text = DateTime.Parse(contractdata.Rows[0][4].ToString()).ToString("dd-MM-yyyy");
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = lvtransaction.getAllEmployeeLeavetaken(int.Parse(cmb_EmpCode.SelectedValue.ToString()));


        }

        public void leavetakenbyEmployee(DataTable leavedata, int leavepk,int empid)
        {
            int number = int.Parse(txt_noofdays.Text);
            DateTime startdate = DateTime.Parse(dtp_from.Value.ToString());
            DateTime todate = DateTime.Parse(dtp_to.Value.Date.ToString());


            if (number > 0)
            {
                for(int i=0;i<leavedata.Rows.Count;i++)
                {
                    int leavePk = int.Parse(leavedata.Rows[i][1].ToString());
                    DateTime leavedate = DateTime .Parse(leavedata.Rows[i][2].ToString());



                }

            }
            else
            {
                lblStatus.Text = "Enter Number";
            }

        }


        public void getdate(int numberofdays ,DateTime fromDateTime ,DateTime todate)
        {


        }












    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Attendance
{ 
    public partial class EmployeeLeaveAndOFf : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.LeaveTransaction lvtransaction = null;
        Transactions.PayrollTransaction.SalaryCalculatuionTransaction salcaltransaction = null;
        Transactions.DataExporter DTPEXPTR = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        public EmployeeLeaveAndOFf()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lvtransaction = new Transactions.LeaveTransaction();
            salcaltransaction = new Transactions.PayrollTransaction.SalaryCalculatuionTransaction();
        }


        public EmployeeLeaveAndOFf(DataTable dt)
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lvtransaction = new Transactions.LeaveTransaction();
            salcaltransaction = new Transactions.PayrollTransaction.SalaryCalculatuionTransaction();
            showemployeedata(dt);
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

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
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

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
           
        }

        private void EmployeeLeaveAndOFf_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }



        public void showemployeedata(DataTable dt) 
        {
            Grp_searchCriteria.Enabled = false;
            tbl_Employeedata.DataSource = dt;


        }

        private void Grp_searchCriteria_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tbl_Employeedata);
        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all.Checked == true)
            {
                cmb_dept.Enabled = false;
                cmb_EmpCode.Enabled = false;
                cmb_designation.Enabled = false;           

            }
            else
            {
                cmb_dept.Enabled = true;
                cmb_EmpCode.Enabled = true;
                cmb_designation.Enabled = true;
                cmb_location.Enabled = true;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (chk_all.Checked == true)
                {
                    if (cmb_Type.Text == "Leave And OFF")
                    {
                        DataTable dt = lvtransaction.getAbscentandLeaveofaLocation(int.Parse(cmb_location.SelectedValue.ToString()), "Y", dtp_from.Value.Date, dtp_to.Value.Date);
                        showemployeedata(dt);
                    }
                }
                else
                {
                    if (cmb_Type.Text == "Leave And OFF")
                    {
                        DataTable dt = lvtransaction.getAllEmployeeLeavetaken(int.Parse(cmb_EmpCode.SelectedValue.ToString()), "Y", dtp_from.Value.Date, dtp_to.Value.Date);
                        showemployeedata(dt);
                    }
                    else if (cmb_Type.Text == "Off Day OTs")
                    {

                        DataTable dt = salcaltransaction.getallemployeeOffOt(Program.LOCTNPK, dtp_from.Value.Date, dtp_to.Value.Date);
                        showemployeedata(dt);

                    }
                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
           

        }

       

      }
}

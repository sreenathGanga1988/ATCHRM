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
    public partial class DesignationChangeApplication : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;

        Transactions.DepartmentTransaction depttrans = null;
      //  Transactions.currencytransaction crncytrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.EmployeeRegTransaction empreg = null;

        Datalayer.EmployeeDesignationDataBean empdesgdatabean = null;
        public int deptchangeflag = 0;
        public int empchangeflag = 0;
        public int depttochangeflag = 0;
        public int lctnflg = 0;
        public DesignationChangeApplication()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            locationListLoad();
            DeptcomboLoad();
            DeptTOcomboLoad();
            locationToListLoad();
        }





        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
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
            cmb_EmpCode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }
        public void locationToListLoad()
        {
            cmb_tolocation .DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_tolocation.DataSource = dt;
            cmb_tolocation.DisplayMember = "LOCATION";
            cmb_tolocation.ValueMember = "SL";
        }

        public void DeptTOcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_todept.DataSource = dt;
            cmb_todept.DisplayMember = "DepartmentName";
            cmb_todept.ValueMember = "DepartmentPK";
        }


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

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptchangeflag==1)
            {
            getallDesignation();
        }
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag = 1;
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

        private void cmb_todept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (depttochangeflag == 1)
            {
                getalltoDesignation();
            }

        }

        private void cmb_todept_MouseClick(object sender, MouseEventArgs e)
        {
            depttochangeflag = 1;
        }




        public void getalltoDesignation()
        {

            if (depttochangeflag != 0)
            {


                if (cmb_todept.SelectedValue != null)
                {


                    cmb_todesgn.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_todept.SelectedValue.ToString()));

                    cmb_todesgn.DisplayMember = "DESGN";
                    cmb_todesgn.ValueMember = "SL";
                    cmb_todesgn.DataSource = dt;
                }

            }
        }



           /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;

            if (cmb_location.Text == null || cmb_location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Current Location";
                cmb_location.Focus();
                cmb_location.Visible = true;
            }
            else if (cmb_dept.Text == null || cmb_dept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter  Current Department";
                cmb_dept.Focus();
                cmb_dept.Visible = true;
            }

            else if (cmb_designation.Text == null || cmb_designation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Current Designation";
                cmb_designation.Focus();
                cmb_designation.Visible = true;
            }

            else if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid EmployeCode";
                cmb_EmpCode.Focus();
                cmb_EmpCode.Visible = true;
            }
            else if (cmb_tolocation.Text == null || cmb_tolocation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the New Location";
                cmb_tolocation.Focus();
                cmb_tolocation.Visible = true;
            }
            else if (cmb_todept.Text == null || cmb_todept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter New Department";
                cmb_todept.Focus();
                cmb_todept.Visible = true;
            }
            else if (cmb_todesgn.Text == null || cmb_todesgn.Text.Trim() == "")
            {
                lblStatus.Text = "Enter New Designation  ";
                cmb_todesgn.Focus();
                cmb_todesgn.Visible = true;
            }

            else
            {
                sucess = true;
            }

            return sucess;

        }




        public void applyaction()
        {

            if(ValidationControl ())
            {

                empdesgdatabean = new Datalayer.EmployeeDesignationDataBean();
                empdesgdatabean.Empid =int.Parse( cmb_EmpCode.SelectedValue.ToString());
                empdesgdatabean.Lctnid = int.Parse(cmb_tolocation .SelectedValue.ToString());
                empdesgdatabean.Deptid = int.Parse(cmb_todept.SelectedValue.ToString());
                empdesgdatabean.Desgid = int.Parse(cmb_todesgn.SelectedValue.ToString());
                empdesgdatabean.Reason = rht_reason.Text;

                String Applicationnum = dsgtrans.designationchangeApplication(empdesgdatabean);


                 ATCHRM.Controls.ATCHRMMessagebox.Show("Apllication  " + Applicationnum + "Done");
                this.Close();
            }

        }

      

        private void btn_submitt_Click(object sender, EventArgs e)
        {

            try
            {
                applyaction();
            }
            catch (Exception exp)
            {

                 ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
             //    ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
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

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}

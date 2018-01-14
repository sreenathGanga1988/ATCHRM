using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR
{
    public partial class AppreciationSubForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.Helper hlpr = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        public AppreciationSubForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            hlpr = new Transactions.Helper();


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








        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
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

        private void AppreciationSubForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
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

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
        }


        public Boolean ValidationbControl()
        {

            Boolean sucess = false;



            if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid EmployeCode";
                cmb_EmpCode.Focus();
                cmb_EmpCode.Visible = true;
            }
            else if (cmb_reason.Text == null || cmb_reason.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid EmployeCode";
                cmb_reason.Focus();
                cmb_reason.Visible = true;
            }
            else
            {
                sucess = true;
            }

            return sucess;
        }
        public void Addaction()
        {
            if (ValidationbControl())
            {

                ArrayList warningdata = new ArrayList();
                warningdata.Add(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                warningdata.Add(cmb_reason .Text);
                warningdata.Add(txt_recommended.Text);
                warningdata.Add(rht_reason .Text );
                warningdata.Add(Program.EmpName);

                empregtrans.insertAprreciation(warningdata);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done ");
                hlpr.ClearFormControls(this);
            }




        }



        private void btn_submitt_Click(object sender, EventArgs e)
        {
            if (ValidationbControl())
            {
                Addaction();
            }

        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

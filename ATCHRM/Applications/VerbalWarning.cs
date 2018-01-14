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
    public partial class VerbalWarning : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.AnualContractrenewal annul = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.Helper  hlpr = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DesignationTransaction dsgtrans = null;
      //  Transactions.ApprovalTransaction  wa
        public int deptchangeflag = 0;
        public int empchangeflag = 0;
        int lctnflg = 0;
        String WarningType = "";
        public VerbalWarning()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empreg = new Transactions.EmployeeRegTransaction();
            hlpr = new Transactions.Helper();
        }
        public VerbalWarning(String warningtype)
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empreg = new Transactions.EmployeeRegTransaction();
            hlpr = new Transactions.Helper();
            WarningType = warningtype;

            if (warningtype == "Writing")
            {
                rht_message.Visible  = true;
                lbl_message.Visible = true;
            }
            else
            {
                rht_message.Visible = false;
                lbl_message.Visible = false;
            }
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
        /// <summary>
        /// loads employe code
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
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

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
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
            
        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            empchangeflag++;
        }

        private void VerbalWarning_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empchangeflag != 0)
            {
                if (cmb_EmpCode.Text != null || cmb_EmpCode.Text != "")
                {
                    if (cmb_EmpCode.SelectedValue != null)
                    {
                        DataTable dt = empreg.getemployeegenderandName(int.Parse(cmb_EmpCode.SelectedValue.ToString()));

                        cmb_empname.Text = dt.Rows[0][0].ToString();

                       
                    }
                }
                else
                {
                    cmb_empname.Text = "";
                }
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

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {
                Addaction();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
             
                this.Dispose();
            }
            

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_reason.Text == "Others")
            {
                txt_reason.Visible = true;
            }
            else
            {
                txt_reason.Visible = false;
            }

        }

        private void txt_reason_TextChanged(object sender, EventArgs e)
        {
            if (txt_reason.Text.Trim() != "")
            {
                cmb_reason.Text = txt_reason.Text;
            }
        }




        public void Addaction()
        {
            if (ValidationbControl())
            {

                ArrayList warningdata = new ArrayList();
                warningdata.Add(int.Parse (cmb_EmpCode.SelectedValue.ToString ()));
                warningdata.Add(cmb_reason.Text);
                warningdata.Add(rht_message.Text);
                warningdata.Add(WarningType);
                warningdata.Add(Program.EmpName);

                empreg.insertEmployeeWarning(warningdata);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done ");
                hlpr.ClearFormControls(this);
            }




        }

    }
}

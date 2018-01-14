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
    public partial class ContractRenewalForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;

        Transactions.DepartmentTransaction depttrans = null;
       // Transactions.currencytransaction crncytrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.ApprovalTransaction aaprvltransaction = null;
        public int deptchangeflag = 0;
        public int empchangeflag = 0;
        public int depttochangeflag = 0;
        public int lctnflg = 0;
        public int desigchangeflag = 0;
        public ContractRenewalForm()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            aaprvltransaction = new Transactions.ApprovalTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            locationListLoad();
            DeptcomboLoad();
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

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptchangeflag == 1)
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
            if (desigchangeflag != 0)
            {

                if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter the Branch location";

                }
                else if (cmb_dept.Text == "" || cmb_dept.Text.Trim() == "")
                {
                    employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), 0, 0);
                }
                else
                {
                    employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
                }
            }
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
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }



        /// <summary>
        /// validates the controls
        /// </summary>
        /// <returns></returns>
        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Leave Name ";
                cmb_EmpCode.Focus();


            }
            else if (cmb_contracttype.Text == null || cmb_contracttype.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Leave Calculation Type ";
                cmb_contracttype.Focus();
            }
            else if (dtp_fromdate.Value.Date == dtp_todate.Value.Date)
            {
                lblStatus.Text = "End Date and Start Date  are Same";

            }
            else
            {
                sucess = true;
            }
            return sucess;
        }
      







        private void btn_submitt_Click(object sender, EventArgs e)
        {


            try
            {
                if (validationcontrol())
                {

                    if (cmb_EmpCode.Text.Trim() != null || cmb_EmpCode.Text.Trim() != "")
                    {

                        if (rht_remark.Text != "")
                        {
                            try
                            {
                                String Applicationcode = aaprvltransaction.insertCntractrenewalApplication(int.Parse(cmb_EmpCode.SelectedValue.ToString()), rht_remark.Text.Trim(), dtp_fromdate.Value.Date, dtp_todate.Value.Date, cmb_contracttype.Text);
                                 ATCHRM.Controls.ATCHRMMessagebox.Show(Applicationcode + "Done");
                                this.Close();
                            }
                            catch (Exception exp)
                            {
                                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                                {
                                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
                                }


                                ErrorLogger er = new ErrorLogger();
                                er.createErrorLog(exp);
                                //     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                                this.Dispose();

                            }

                        }
                        else
                        {
                            lblStatus.Text = "Enter the Remark";
                        }
                    }
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

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmb_EmpCode.Text != "")
            {

                empchangeflag++;
            }
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {  if (cmb_EmpCode.Text.Trim ()!= null ||cmb_EmpCode.Text.Trim ()!= "" )
            {
            if (empchangeflag != 0)
            {
                 DataTable dt1 = new DataTable();
                 if (cmb_EmpCode.SelectedValue!=null )
                 {
                    dt1 = empreg.getCurrentContractDetails(int.Parse (cmb_EmpCode.SelectedValue.ToString ()));
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count != 0)
                        {

                            cmb_contracttype.Text = dt1.Rows[0][2].ToString();
                            dtp_fromdate.Value = DateTime.Parse(dt1.Rows[0][3].ToString());
                            dtp_todate.Value = DateTime.Parse(dt1.Rows[0][4].ToString());
                            dtp_extendabledate.Value = DateTime.Parse(dt1.Rows[0][5].ToString());
                            cmb_empname.Text = dt1.Rows[0][6].ToString();
                        }
                    }
            }
                }
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

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desigchangeflag++;
        }
    
    
    
    
    
    }
}

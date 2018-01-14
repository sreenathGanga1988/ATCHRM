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
    public partial class ShiftChangeApplication : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;

        Transactions.DepartmentTransaction depttrans = null;
      // Transactions.currencytransaction crncytrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.ApprovalTransaction aaprvltransaction = null;
        Transactions.ShiftTransactionNewform  shftransaction = null;
        public int deptchangeflag = 0;
        public int empchangeflag = 0;
        public int depttochangeflag = 0;
          
 public int lctnflg = 0;
        public ShiftChangeApplication()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            aaprvltransaction = new Transactions.ApprovalTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            shftransaction = new Transactions.ShiftTransactionNewform();
            locationListLoad();
            DeptcomboLoad();
            shiftcomboload();
        }

        /// <summary>
        /// load department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }
/// <summary>
/// load all location
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

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_EmpCode.Text.Trim() != null || cmb_EmpCode.Text.Trim() != "")
            {
                if (empchangeflag != 0)
                {
                    if (cmb_EmpCode.SelectedValue != null)
                    {
                        DataTable dt = shftransaction.getemployeeshiftdata(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                        if (dt != null)
                        {
                            if (dt.Rows.Count != 0)
                            {
                                Cmb_shift.Text = dt.Rows[0][1].ToString();
                                lbl_shiftPK.Text = dt.Rows[0][0].ToString();
                               
                                dtp_fromdate.Value = DateTime.Parse(dt.Rows[0][2].ToString());
                             //   dtp_fromTime.Value = DateTime.Parse(dt.Rows[0][4].ToString());
                           //     dtp_toTime.Value = DateTime.Parse(dt.Rows[0][5].ToString());
                                // cmb_weeklyofdays.Text = dt.Rows[0][2].ToString();

                            }
                        }
                    }
                }
            }
        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmb_EmpCode.Text != "")
            {

                empchangeflag++;
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
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation .SelectedValue.ToString()));
            }
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

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationControl())
                {
                    int empid = 0;
                    int fromshiftpk = 0;
                    int toshiftpk = 0;
                    String remark = "";

                    empid = int.Parse(cmb_EmpCode.SelectedValue.ToString());
                    fromshiftpk = int.Parse(lbl_shiftPK.Text.ToString());
                    toshiftpk = int.Parse(cmb_toshift.SelectedValue.ToString());
                    remark = rht_remark.Text;




                    String applicationnum = aaprvltransaction.insertShiftTransferAppliucation(empid, fromshiftpk, toshiftpk, remark);
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Application " + applicationnum + "   Submitted ");
                    this.Close();
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
        /// LOAD ALL THE SHIFT DATA
        /// </summary>
        public void shiftcomboload()
        {
            DataTable dt = shftransaction.getAllShiftName ();

            cmb_toshift .DataSource = dt;
            cmb_toshift.DisplayMember = "ShiftName";
            cmb_toshift.ValueMember = "ShiftPk";
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
            else if (lbl_shiftPK.Text == null || lbl_shiftPK.Text.Trim() == "")
            {
                lblStatus.Text = "Click on the EmployeCode3 to view Current Shift Details ";
                cmb_EmpCode.Focus();
                cmb_EmpCode.Visible = true;
            }
            else if (cmb_toshift.Text == null || cmb_toshift.Text.Trim() == "")
            {
                lblStatus.Text = "Enter New Shift ";
                cmb_toshift.Focus();
                cmb_toshift.Visible = true;
            }
            else if (Cmb_shift.Text == null || Cmb_shift.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  EmployeeCode...Previous Shiftdata Not Found ";
                Cmb_shift.Focus();
                Cmb_shift.Visible = true;
            }
            else if (rht_remark.Text == null || rht_remark.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Remark ";
                rht_remark.Focus();
                rht_remark.Visible = true;
            }

            else
            {
                sucess = true;
            }

            return sucess;

        

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

        private void cmb_empname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cmb_shift_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_shiftPK_TextChanged(object sender, EventArgs e)
        {
            if (lbl_shiftPK.Text != null)
            {
                if (lbl_shiftPK.Text != "")
                {

                    try
                    {
                        int k = int.Parse(lbl_shiftPK.Text);

                        if (k > 0)
                        {
                            DataTable dt = shftransaction.getsShiftByPK(k);
                            fillothercontrols(dt,"Current");
                        }
                    }
                    catch(Exception )
                    {
                    }

                }
            }
        }





        public void fillothercontrols(DataTable dt ,String typeshft)
        {

           
                if (dt.Rows.Count != 0)
                {
                    if (typeshft == "Current")
                    {

                    for (int i = 0; i < 7; i++)
                    {

                        if (dt.Rows[i][1].ToString() == "Monday")
                        {
                            dtpIn_Monday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                            dtp_Monday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                            cmbDayType_Monday.Text = dt.Rows[i][2].ToString();

                        }
                        else if (dt.Rows[i][1].ToString().Trim() == "Tuesday")
                        {
                            dtpIn_Tuesday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                            dtpOut_Tuesday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                            cmbDayType_Tuesday.Text = dt.Rows[i][2].ToString();

                        }
                        else if (dt.Rows[i][1].ToString() == "Wednesday")
                        {
                            dtpIn_Wednesday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                            dtpOut_Wednesday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                            cmbDayType_Wednesday.Text = dt.Rows[i][2].ToString();

                        }
                        else if (dt.Rows[i][1].ToString() == "Thursday")
                        {
                            dtpIn_Thursday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                            dtpOut_Thursday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                            cmbDayType_Thursday.Text = dt.Rows[i][2].ToString();

                        }
                        else if (dt.Rows[i][1].ToString() == "Friday")
                        {
                            dtpIn_Friday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                            dtpOut_Friday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                            cmbDayType_Friday.Text = dt.Rows[i][2].ToString();

                        }
                        else if (dt.Rows[i][1].ToString() == "Saturday")
                        {
                            dtpIn_Saturday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                            dtpOut_Saturday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                            cmbDayType_Saturday.Text = dt.Rows[i][2].ToString();

                        }
                        else if (dt.Rows[i][1].ToString() == "Sunday")
                        {
                            dtpIn_Sunday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                            dtpOut_Sunday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                            cmbDayType_Sunday.Text = dt.Rows[i][2].ToString();


                        }

                    }

                    }
                    else if (typeshft == "To")
                    {

                        for (int i = 0; i < 7; i++)
                        {

                            if (dt.Rows[i][1].ToString() == "Monday")
                            {
                                dtpIn_Monday2.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                                dtpOut_Monday2 .Value = DateTime.Parse(dt.Rows[i][4].ToString());
                                cmbDayType_Mond2 .Text = dt.Rows[i][2].ToString();

                            }
                            else if (dt.Rows[i][1].ToString().Trim() == "Tuesday")
                            {
                                dtpIn_Tuesday2.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                                dtpOut_Tuesday2.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                                cmbDayType_Tues2.Text = dt.Rows[i][2].ToString();

                            }
                            else if (dt.Rows[i][1].ToString() == "Wednesday")
                            {
                                dtpIn_Wednesday2.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                                dtpOut_Wednesday2 .Value = DateTime.Parse(dt.Rows[i][4].ToString());
                                cmbDayType_Wednes2 .Text = dt.Rows[i][2].ToString();

                            }
                            else if (dt.Rows[i][1].ToString() == "Thursday")
                            {
                                dtpIn_Thursday2.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                                dtpOut_Thrsday2 .Value = DateTime.Parse(dt.Rows[i][4].ToString());
                                cmbDayType_Thurs2 .Text = dt.Rows[i][2].ToString();

                            }
                            else if (dt.Rows[i][1].ToString() == "Friday")
                            {
                                dtpIn_Friday2.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                                dtpOut_Friday2 .Value   = DateTime.Parse(dt.Rows[i][4].ToString());
                                cmbDayType_Friday2.Text = dt.Rows[i][2].ToString();

                            }
                            else if (dt.Rows[i][1].ToString() == "Saturday")
                            {
                                dtpIn_Saturday2.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                                dtpOut_Saturday2.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                                cmbDayType_satur2 .  Text = dt.Rows[i][2].ToString();

                            }
                            else if (dt.Rows[i][1].ToString() == "Sunday")
                            {
                                dtpIn_Sunday2.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                                dtpOut_Sunday2.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                                cmbDayType_Sunday2.Text = dt.Rows[i][2].ToString();


                            }

                        }


                    }
            }
        }

        private void cmb_toshift_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cmb_toshift.SelectedValue!=null ){
                if (cmb_toshift.Text != "")
                {

                    try
                    {
                        int k = int.Parse(cmb_toshift.SelectedValue.ToString());

                        if (k > 0)
                        {
                            DataTable dt = shftransaction.getsShiftByPK(k);
                            fillothercontrols(dt, "To");
                        }
                    }
                    catch (Exception )
                    {
                    }

                }
                else
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Please enter the To Shift");
                }
            }
        }

        private void lbl_shiftPK_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShiftChangeApplication_Load(object sender, EventArgs e)
        {

        }














    }
}

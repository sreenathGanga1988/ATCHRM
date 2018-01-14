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
    public partial class GroupshiftchangeForm : Form
    {
        public int deptchangeflag = 0;
        public int empchangeflag = 0; 
        public int lctnflg = 0;
        public int depttochangeflag = 0; 
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        // Transactions.currencytransaction crncytrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.ApprovalTransaction aaprvltransaction = null;
        Transactions.ShiftTransactionNewform shftransaction = null;
        public GroupshiftchangeForm()
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
        /// LOAD ALL THE SHIFT DATA
        /// </summary>
        public void shiftcomboload()
        {
            DataTable dt = shftransaction.getAllShiftName();

            cmb_toshift.DataSource = dt;
            cmb_toshift.DisplayMember = "ShiftName";
            cmb_toshift.ValueMember = "ShiftPk";
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

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptchangeflag == 1)
            {
                getallDesignation();
            }
        }


        public void showdata()
        {
            DataTable dt = empreg.getemployyeIDShiftName(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
            tbl_employeedata.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag = 1;
        }

        private void tbl_employeedata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_employeedata .IsCurrentCellDirty)
            {
                tbl_employeedata.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

   

        /// <summary>
        /// get the employee code of the persons
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>



                 /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (cmb_toshift.Text == null || cmb_toshift.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Shift";
                cmb_toshift.Focus();
                cmb_toshift.Visible = true;
            }
            else
            {
                sucess = true;
            }

    return sucess;
}

        private void btn_submitt_Click_1(object sender, EventArgs e)
        {
            String ApplicationNum = "";
            for (int i = 0; i < tbl_employeedata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_employeedata.Rows[i].Cells[0].Value) == true)
                {

                    try
                    {
                        if (ValidationControl())
                        {
                            int empid = 0;
                            int fromshiftpk = 0;
                            int toshiftpk = 0;
                            String remark = "";

                            empid = int.Parse(tbl_employeedata.Rows[i].Cells[1].Value.ToString());
                            fromshiftpk = int.Parse(tbl_employeedata.Rows[i].Cells[6].Value.ToString());
                            toshiftpk = int.Parse(cmb_toshift.SelectedValue.ToString());
                            remark = rht_remark.Text;




                            String applicationnum = aaprvltransaction.insertShiftTransferAppliucation(empid, fromshiftpk, toshiftpk, remark);
                          //   ATCHRM.Controls.ATCHRMMessagebox.Show("Application " + applicationnum + "   Submitted  for "  +tbl_employeedata.Rows[i].Cells[2].Value.ToString()  );
                            ApplicationNum = ApplicationNum+ "Application " + applicationnum + "   Submitted  for " + tbl_employeedata.Rows[i].Cells[2].Value.ToString() + System.Environment.NewLine;
                           
                        }
                    }
                    catch (Exception exp)
                    {
                        ErrorLogger er = new ErrorLogger();
                        er.createErrorLog(exp);

                        this.Dispose();
                    }
                }
            }
           
            if (ApplicationNum != "")
            {
                MessageBox .Show(ApplicationNum);
                showdata();
            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected");
            }
        }

    }
}

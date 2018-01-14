using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master.NewFolder1
{
    /// <summary>
    /// position of employee
    /// </summary>
    public partial class PositionForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
     //   Datalayer.DesignationDatabean dsgnationdatbean = null;
        Datalayer.EmployeeDesignationDataBean empdsgbean = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        int branchflag = 0;
        int deptflag = 0;
        int desgflag = 0;
        String applicationType = null;
        int locationflag = 0;
        int changedesgappid = 0;
        public PositionForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
        }
        public PositionForm(int empid )
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            fillcontrol(empid, "ADD");
        }
        public PositionForm(int empid, string editstring ,int applicationid)
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            depttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            branchlistload();
            applicationType = editstring;
            locationListLoad();
            getallDeparment();
            grp_details.Enabled = false;
          fillcontrol(empid,"EDIT");
            btn_submmit.Text = "Edit";
            changedesgappid = applicationid;
            if (editstring != "Designation Change")
            {
                btn_Skip.Enabled = true;

            }


        }
        public void fillcontrol(int empid ,String action)
        {
            DataTable dt = empregtrans.getEmployeDesignationandLocation(empid, action);
            if (dt != null)
            {

                cmb_Empcode.Text = dt.Rows[0][0].ToString ();
                lbl_emppk.Text = dt.Rows[0][1].ToString ();
                cmb_designation.Text = dt.Rows[0][2].ToString();
                lbl_desingnsation.Text= dt.Rows[0][3].ToString();
                cmb_dept.Text = dt.Rows[0][4].ToString();
                lbl_dept.Text = dt.Rows[0][5].ToString();
                cmb_Location.Text = dt.Rows[0][6].ToString();
                lbl_LocationPk .Text = dt.Rows[0][7].ToString();
                cmb_Branch.Text = dt.Rows[0][8].ToString();
                lbl_branchPk.Text = dt.Rows[0][9].ToString();

            }
        }

        

        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (cmb_Empcode.Text == null || cmb_Empcode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the  EmpCode ";
                cmb_Empcode.Focus();


            }
            else if (cmb_Branch.Text == null || cmb_Branch.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Branch ";
                cmb_Branch.Focus();
            }
            else if (cmb_Location.Text == null || cmb_Location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Location  ";
                cmb_Location.Focus();
            }
            else if (cmb_dept.Text == null || cmb_dept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Deignation  ";
                cmb_dept.Focus();
            }
            else if (cmb_designation.Text == null || cmb_designation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Deignation  ";
                cmb_designation.Focus();
            }

            else
            {
                sucess = true;
            }
            return sucess;
        }

        private void btn_submmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_submmit.Text == "Submit")
                {

                    empdsgbean = new Datalayer.EmployeeDesignationDataBean();
                    if (validationcontrol())
                    {

                        empdsgbean.Empid = int.Parse(lbl_emppk.Text);
                        empdsgbean.Deptid = int.Parse(lbl_dept.Text);
                        empdsgbean.Lctnid = int.Parse(lbl_LocationPk.Text);
                        empdsgbean.Desgid = int.Parse(lbl_desingnsation.Text);

                        empregtrans.insertEmployeeDesignation(empdsgbean, "ADD");

                    }
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    HR.NewFolder1.EmployeeShiftFormcs shftform = new HR.NewFolder1.EmployeeShiftFormcs(cmb_Empcode.Text, int.Parse(lbl_emppk.Text));
                    shftform.MdiParent = this.MdiParent;
                    shftform.Show();
                    this.Close();
                }


                else if (btn_submmit.Text == "Edit")
                {

                    btn_submmit.Text = "Update";

                    grp_details.Enabled = true;



                }
                else if (btn_submmit.Text == "Update")
                {
                    empdsgbean = new Datalayer.EmployeeDesignationDataBean();

                    if (validationcontrol())
                    {

                        empdsgbean.Empid = int.Parse(lbl_emppk.Text);
                        empdsgbean.Deptid = int.Parse(lbl_dept.Text);
                        empdsgbean.Lctnid = int.Parse(lbl_LocationPk.Text);
                        empdsgbean.Desgid = int.Parse(lbl_desingnsation.Text);
                        empdsgbean.DesgchangeAppid = changedesgappid;
                        empregtrans.insertEmployeeDesignation(empdsgbean, "EDIT");

                    }
                     ATCHRM.Controls.ATCHRMMessagebox.Show(" Updated");
                    ShiftForm shftform = new ShiftForm(cmb_Empcode.Text, int.Parse(lbl_emppk.Text), applicationType, changedesgappid);
                    shftform.MdiParent = this.MdiParent;
                    shftform.Show();
                    this.Close();

                }
            }
            catch (Exception exp)
            {
                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }





        /// <summary>
        ///will get all thew department from the database and will 
        ///display it in combobox
        /// </summary>
        public void getallDeparment()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

       

        /// <summary>
        /// get all designation against dept
        /// </summary>
        public void getallDesignation()
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



        /// <summary>
        /// get all location branch
        /// </summary>
        public void locationListLoad()
        {
            cmb_Location .DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_Location.DataSource = dt;
            cmb_Location.DisplayMember = "LOCATION";
            cmb_Location.ValueMember = "SL";
           // cmb_Location.SelectedValue = Program.LOCTNPK;

        }


        public void branchlistload()
        {
            DataTable dt = cmptransaction.selectallbranch();

            cmb_Branch .DisplayMember = "BRANCH";
            cmb_Branch.ValueMember = "SL";
            cmb_Branch.DataSource = dt;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_dept.Text = cmb_dept.SelectedValue.ToString();
            if (deptflag != 0)
            {
                getallDesignation();
            }
        }

        private void cmb_Branch_MouseClick(object sender, MouseEventArgs e)
        {
            branchflag++;

        }

        private void cmb_Location_MouseClick(object sender, MouseEventArgs e)
        {
            locationflag++;
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void cmb_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_branchPk.Text = cmb_Branch.SelectedValue.ToString();
        }

        private void cmb_Location_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_LocationPk.Text = cmb_Location.SelectedValue.ToString();
        }

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_desingnsation.Text = cmb_designation.SelectedValue.ToString();
        }

        private void btn_Skip_Click(object sender, EventArgs e)
        {
      
            ShiftForm shftform = new ShiftForm(cmb_Empcode.Text, int.Parse(lbl_emppk.Text), applicationType, changedesgappid);
            shftform.MdiParent = this.MdiParent;
            shftform.Show();
            this.Close();
        }
    
    }
}

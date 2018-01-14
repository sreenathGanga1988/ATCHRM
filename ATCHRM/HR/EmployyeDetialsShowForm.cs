using ATCHRM.Action;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR
{
    public partial class EmployyeDetialsShowForm : Form
    {
        Transactions.ShiftTransactionNewform shfttransaction = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Datalayer.EmployeeContractDatabean empcontrctdatbean = null;
        Transactions.AnualContractrenewal annulcntrct = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.SubDepartmentTransaction subdepttrans = null;
        Transactions.ShiftTransactionNewform shftransaction = null;
        int deptchangeflag = 0;
        int newdeptfalg = 0;
        public EmployyeDetialsShowForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            annulcntrct = new Transactions.AnualContractrenewal();
            // employecodeload(Program.LOCTNPK, 0, 0);
            subdepttrans = new Transactions.SubDepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            shftransaction = new Transactions.ShiftTransactionNewform();
        }


        /// <summary>
        /// loads the employee detail of a location
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            //DataTable  dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            //  cmb_empcode.DataSource = dt;
            //  cmb_empcode.DisplayMember = "empno";
            //  cmb_empcode.ValueMember = "empid";


            //    cmb_empcode.Text = cmb_empcode.SelectedValue.ToString();
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
        /// loads the department
        /// </summary>
        public void newDeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_newDept.DataSource = dt;
            cmb_newDept.DisplayMember = "DepartmentName";
            cmb_newDept.ValueMember = "DepartmentPK";
        }
        public void loadsubdept(int deptid)
        {
            DataTable dt = subdepttrans.getSubdepartment(deptid);
            cmb_subdept.DataSource = dt;
            cmb_subdept.DisplayMember = "SubDeptName";
            cmb_subdept.ValueMember = "SubDeptPK";
        }

        /// <summary>
        /// get all designation under a department
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
        /// get the New Designation
        /// </summary>
        public void getallNewDesignation()
        {

            if (deptchangeflag != 0)
            {


                if (cmb_dept.SelectedValue != null)
                {


                    cmb_newdesignation.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_dept.SelectedValue.ToString()));

                    cmb_newdesignation.DisplayMember = "DESGN";
                    cmb_newdesignation.ValueMember = "SL";
                    cmb_newdesignation.DataSource = dt;
                }

            }
        }

        /// <summary>
        /// get all the destination available for the new department selected by the user
        /// </summary>
        public void getallNewDesignationfornewDept()
        {

            if (newdeptfalg != 0)
            {


                if (cmb_dept.SelectedValue != null)
                {


                    cmb_newdesignationofdept.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_newDept.SelectedValue.ToString()));

                    cmb_newdesignationofdept.DisplayMember = "DESGN";
                    cmb_newdesignationofdept.ValueMember = "SL";
                    cmb_newdesignationofdept.DataSource = dt;
                }

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void cmb_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EmployyeDetialsShowForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }










        /// <summary>
        /// LOAD ALL THE SHIFT DATA
        /// </summary>
        public void newShiftcomboload()
        {
            DataTable dt = shftransaction.getAllShiftName();

            cmb_toshift.DataSource = dt;
            cmb_toshift.DisplayMember = "ShiftName";
            cmb_toshift.ValueMember = "ShiftPk";
        }






        public void Loadnewlocationcombo()
        {
            cmb_newlctn.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();

            cmb_newlctn.DataSource = dt;
            cmb_newlctn.DisplayMember = "LOCATION";
            cmb_newlctn.ValueMember = "SL";
        }

        public void loaddata()
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    DataTable dt = empregtrans.getcontractofallemployeeofadeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                    tbL_contract.DataSource = dt;
                }
                else if (tabControl1.SelectedTab == ShiftAssigner)
                {
                    DataTable dt = empregtrans.getemployeedetailswithShift(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                    tbl_shift.DataSource = dt;
                    newShiftcomboload();
                }
                else if (tabControl1.SelectedTab == OvertimeAsigner)
                {
                    DataTable dt = empregtrans.geTmployeeofadeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                    tblOtview.DataSource = dt;

                }
                else if (tabControl1.SelectedTab == Locationchanger)
                {
                    DataTable dt = empregtrans.getemployeedetailsforChangingLocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                    tbl_location.DataSource = dt;
                    Loadnewlocationcombo();
                }

                else if (tabControl1.SelectedTab == tb_changedesignation)
                {
                    DataTable dt = empregtrans.geTmployeeofadeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                    tbl_changeDesignation.DataSource = dt;
                    getallNewDesignation();

                }
                else if (tabControl1.SelectedTab == tb_changedepartment)
                {
                    DataTable dt = empregtrans.geTmployeeofadeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                    tbl_changedepartment.DataSource = dt;
                    newDeptcomboLoad();
                }
                else if (tabControl1.SelectedTab == tb_subdeptpk)
                {
                    DataTable dt = empregtrans.geTmployeeofaSubdeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                    tbl_subdept.DataSource = dt;
                    loadsubdept(int.Parse(cmb_dept.SelectedValue.ToString()));

                }
                if (tabControl1.SelectedTab == tb_contractExtend)
                {
                    DataTable dt = empregtrans.getcontractofallemployeeofadeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
                   
                    tbl_extendContract.DataSource = dt;
                }
            }
            catch (Exception)
            {


            }
        }






        public Boolean ifauthunicated()
        {
            Boolean authenicated = false;

            Action.UserAuthenication frm = new UserAuthenication();
            frm.ShowDialog();
            authenicated = frm.Isauthenicated;

            return authenicated;
        }







        private void button1_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ifauthunicated())
            {
                for (int i = 0; i < tbL_contract.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbL_contract.Rows[i].Cells[0].Value) == true)
                    {

                        empcontrctdatbean = new Datalayer.EmployeeContractDatabean();
                        empcontrctdatbean.Empid = int.Parse(tbL_contract.Rows[i].Cells[1].Value.ToString());
                        empcontrctdatbean.Actualjoinigdate = DateTime.Parse(tbL_contract.Rows[i].Cells[4].Value.ToString());
                        empcontrctdatbean.Contractype = tbL_contract.Rows[i].Cells[5].Value.ToString();
                        empcontrctdatbean.Startime = dtp_fromdate.Value.Date;
                        empcontrctdatbean.Endtime = dtp_todate.Value.Date;
                        empcontrctdatbean.Extendeddate = dtp_todate.Value.Date;
                        empcontrctdatbean.ContractchangeAppid1 = 0;

                        empregtrans.insertEmployeeContractdetails(empcontrctdatbean, "Contract Change");

                        annulcntrct.insertAnnualContractforexistingEmployee(empcontrctdatbean.Empid);
                    }

                }




                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");


            }


        }

        private void tbL_contract_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbL_contract.IsCurrentCellDirty)
            {
                tbL_contract.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }



        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbL_contract.Rows.Count - 1; i++)
                {
                    tbL_contract.Rows[i].Cells[0].Value = true;
                    tbL_contract.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbL_contract.Rows.Count - 1; i++)
                {
                    tbL_contract.Rows[i].Cells[0].Value = false;
                    tbL_contract.Rows[i].Selected = false;

                }
            }
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getallDesignation();
                loadsubdept(int.Parse(cmb_dept.SelectedValue.ToString()));
            }
            catch (Exception)
            {


            }
        }

        private void cmb_dept_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cmb_designation.Text == null || cmb_designation.Text == "")
            {
                ((DataTable)tblOtview.DataSource).DefaultView.RowFilter = " DepartmentName like '%" + cmb_dept.Text.Trim() + "%' ";

            }
            else if (cmb_dept.Text != null || cmb_dept.Text != "")
            {
                ((DataTable)tblOtview.DataSource).DefaultView.RowFilter = " DesignationName like '%" + cmb_designation.Text.Trim() + "%' ";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < tblOtview.Rows.Count - 1; i++)
                {
                    tblOtview.Rows[i].Cells[0].Value = true;
                    tblOtview.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tblOtview.Rows.Count - 1; i++)
                {
                    tblOtview.Rows[i].Cells[0].Value = false;
                    tblOtview.Rows[i].Selected = false;

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int actiondonerows = 0;
            for (int i = 0; i < tblOtview.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tblOtview.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empregtrans.markOTApplicableforEmployee(int.Parse(tblOtview.Rows[i].Cells[1].Value.ToString()), true);
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                loaddata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int actiondonerows = 0;
            for (int i = 0; i < tblOtview.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tblOtview.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empregtrans.markOTApplicableforEmployee(int.Parse(tblOtview.Rows[i].Cells[1].Value.ToString()), false);
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                loaddata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < tbl_location.Rows.Count - 1; i++)
                {
                    tbl_location.Rows[i].Cells[0].Value = true;
                    tbl_location.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_location.Rows.Count - 1; i++)
                {
                    tbl_location.Rows[i].Cells[0].Value = false;
                    tbl_location.Rows[i].Selected = false;

                }
            }
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(cmb_location.SelectedValue.ToString()) != 0)
            {
                changelocationofEmployee();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Change the Location of Ashton Employees");
            }
        }

        /// <summary>
        /// change the location of selectedemployee
        /// </summary>

        public void changelocationofEmployee()
        {
            int actiondonerows = 0;
            for (int i = 0; i < tbl_location.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_location.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empregtrans.changeEmployeeLocation(int.Parse(tbl_location.Rows[i].Cells[1].Value.ToString()), int.Parse(cmb_newlctn.SelectedValue.ToString()));
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                loaddata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
            }
        }

        private void tblOtview_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tblOtview.IsCurrentCellDirty)
            {
                tblOtview.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbl_location_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_location.IsCurrentCellDirty)
            {
                tbl_location.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            int actiondonerows = 0;
            for (int i = 0; i < tbl_shift.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_shift.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empregtrans.ChangeEmployeeShift(int.Parse(tbl_shift.Rows[i].Cells[1].Value.ToString()), int.Parse(cmb_toshift.SelectedValue.ToString()), dtp_effectivetime.Value);
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                loaddata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
            }


        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ATCHRM.Controls.ATCHRMMessagebox.Show("Code not  Done ");
        }

        private void btn_changeDesignation_Click(object sender, EventArgs e)
        {
            if (Actionconfirmation("Designation Change"))
            {
                int actiondonerows = 0;
                for (int i = 0; i < tbl_changeDesignation.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_changeDesignation.Rows[i].Cells[0].Value) == true)
                    {
                        actiondonerows++;
                        empregtrans.ChangeemployeeDesignation(int.Parse(tbl_changeDesignation.Rows[i].Cells[1].Value.ToString()), int.Parse(cmb_newdesignation.SelectedValue.ToString()));
                    }

                }
                if (actiondonerows > 0)
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                    loaddata();
                }
                else
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
                };
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            addsubdept();
        }






        public void addsubdept()
        {
            int actiondonerows = 0;
            for (int i = 0; i < tbl_subdept.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_subdept.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empregtrans.changeEmployeeSubdept(int.Parse(tbl_subdept.Rows[i].Cells[1].Value.ToString()), int.Parse(cmb_subdept.SelectedValue.ToString()));
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                loaddata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
            }
        }










        private void cmb_subdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {


            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                for (int i = 0; i < tbl_subdept.Rows.Count - 1; i++)
                {
                    tbl_subdept.Rows[i].Cells[0].Value = true;
                    tbl_subdept.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_subdept.Rows.Count - 1; i++)
                {
                    tbl_subdept.Rows[i].Cells[0].Value = false;
                    tbl_subdept.Rows[i].Selected = false;

                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                for (int i = 0; i < tbl_changedepartment.Rows.Count - 1; i++)
                {
                    tbl_changedepartment.Rows[i].Cells[0].Value = true;
                    tbl_changedepartment.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_changedepartment.Rows.Count - 1; i++)
                {
                    tbl_changedepartment.Rows[i].Cells[0].Value = false;
                    tbl_changedepartment.Rows[i].Selected = false;

                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                for (int i = 0; i < tbl_changeDesignation.Rows.Count - 1; i++)
                {
                    tbl_changeDesignation.Rows[i].Cells[0].Value = true;
                    tbl_changeDesignation.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_changeDesignation.Rows.Count - 1; i++)
                {
                    tbl_changeDesignation.Rows[i].Cells[0].Value = false;
                    tbl_changeDesignation.Rows[i].Selected = false;

                }
            }
        }

        private void tbl_subdept_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_subdept.IsCurrentCellDirty)
            {
                tbl_subdept.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                for (int i = 0; i < tbl_shift.Rows.Count - 1; i++)
                {
                    tbl_shift.Rows[i].Cells[0].Value = true;
                    tbl_shift.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_shift.Rows.Count - 1; i++)
                {
                    tbl_shift.Rows[i].Cells[0].Value = false;
                    tbl_shift.Rows[i].Selected = false;

                }
            }
        }

        private void tbl_shift_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_shift.IsCurrentCellDirty)
            {
                tbl_shift.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cmb_newDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallNewDesignationfornewDept();
        }

        private void cmb_newDept_MouseClick(object sender, MouseEventArgs e)
        {
            newdeptfalg++;
        }

        private void tbl_changeDesignation_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_changeDesignation.IsCurrentCellDirty)
            {
                tbl_changeDesignation.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbl_changedepartment_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_changedepartment.IsCurrentCellDirty)
            {
                tbl_changedepartment.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btn_changedept_Click(object sender, EventArgs e)
        {
            if (Actionconfirmation("Department Change"))
            {

                int actiondonerows = 0;
                for (int i = 0; i < tbl_changedepartment.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_changedepartment.Rows[i].Cells[0].Value) == true)
                    {
                        actiondonerows++;
                        empregtrans.ChangeemployeeDepartmentanddesignation(int.Parse(tbl_changedepartment.Rows[i].Cells[1].Value.ToString()), int.Parse(cmb_newdesignationofdept.SelectedValue.ToString()), int.Parse(cmb_newDept.SelectedValue.ToString()));
                    }

                }
                if (actiondonerows > 0)
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Updated \n Please Change the Sub Dept Details  ");
                    loaddata();
                }
                else
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
                };
            }
        }




        public Boolean Actionconfirmation(string actiontype)
        {
            Boolean iscontinue = false;
            DialogResult rslt = MessageBox.Show("Confirm Action :-" + actiontype + "", "The Action you are  going to perform may require change in Salary details of Empoloyee Do you Whish to Continue", MessageBoxButtons.YesNo);
            if (rslt == DialogResult.Yes)
            {
                iscontinue = true;
            }

            return iscontinue;
        }

        private void cmb_newlctn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                for (int i = 0; i < tbl_extendContract.Rows.Count - 1; i++)
                {
                    tbl_extendContract.Rows[i].Cells[0].Value = true;
                    tbl_extendContract.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_extendContract.Rows.Count - 1; i++)
                {
                    tbl_extendContract.Rows[i].Cells[0].Value = false;
                    tbl_extendContract.Rows[i].Selected = false;

                }
            }
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            int k = 0;

            for (int i = 0; i < tbl_extendContract.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_extendContract.Rows[i].Cells[0].Value) == true)
                {
                    int Empid = int.Parse(tbl_extendContract.Rows[i].Cells[1].Value.ToString());
                
                    DateTime  Endtime = dtp_newdate .Value.Date;

                    SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);

                    var q = from asd in cntxt.EmpContract_tbls
                            where asd.EmpId == Empid
                            select asd;
                  
                  


                    foreach (var contractmaster in q)
                    {
                        int year = DateTime.Parse(contractmaster.Endtime.ToString()).Year;
                        int newyear = Endtime.Year;
                        if (year == newyear)
                        {
                            var q1 = from asd1 in cntxt.EmpContractDetail_tbls
                                     where asd1.empid == int.Parse (contractmaster.EmpId.ToString ())  && asd1.ToDate  == DateTime .Parse ( contractmaster.Endtime.ToString ())  && asd1.Contractid == int.Parse (contractmaster.Contractid .ToString ())
                                     select asd1;
                            foreach (var contractdetail in q1)
                            {
                                if((year==DateTime.Parse(contractdetail.ToDate .ToString()).Year) && (newyear==DateTime.Parse(contractdetail.ToDate.ToString()).Year ))
                                {
                                    contractmaster.Endtime = Endtime;
                                    contractdetail.ToDate  = Endtime;
                                    //cntxt.EmpContractDetail_tbls.InsertOnSubmit(contractdetail);
                                   // cntxt.EmpContract_tbls.InsertOnSubmit(contractmaster);
                                   k++;
                                }
                                 else
                        {
                            MessageBox.Show("Renew The Contract  of " + Empid + "");
                        }

                            }

                            cntxt.SubmitChanges();
                        }
                        else
                        {
                            MessageBox.Show("Renew The Contract  of " + Empid + "");
                        }

                    }

                    cntxt.SubmitChanges();
                    if(k>0)
                    {
                        MessageBox.Show(k + "Employeees Contract Extended");
                    }
                    else
                    {
                        MessageBox.Show("No Employeees Contract Extended");
                    }
                }
            }





        }

        private void button7_Click(object sender, EventArgs e)
        {
            MultiContractChangeApplication();
        }



        public void MultiContractChangeApplication()
        {
            for (int i = 0; i < tbL_contract.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbL_contract.Rows[i].Cells[0].Value) == true)
                {

                    empcontrctdatbean = new Datalayer.EmployeeContractDatabean();
                    empcontrctdatbean.Empid = int.Parse(tbL_contract.Rows[i].Cells[1].Value.ToString());
                    empcontrctdatbean.Actualjoinigdate = DateTime.Parse(tbL_contract.Rows[i].Cells[4].Value.ToString());
                    empcontrctdatbean.Contractype = tbL_contract.Rows[i].Cells[5].Value.ToString();
                    empcontrctdatbean.Startime = dtp_fromdate.Value.Date;
                    empcontrctdatbean.Endtime = dtp_todate.Value.Date;
                    empcontrctdatbean.Extendeddate = dtp_todate.Value.Date;
                    empcontrctdatbean.ContractchangeAppid1 = 0;

                    empregtrans.insertEmployeeContractdetApplication(empcontrctdatbean, "Contract Change");

                   
                }

            }




            ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = empregtrans.getcontractofallemployeeofadeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()),"Permanent");
            tbL_contract.DataSource = dt;
        }
    }
}
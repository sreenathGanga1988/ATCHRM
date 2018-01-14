using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Approvals
{
    public partial class LevelApprovalForm_2 : Form
    {
        Transactions.RecruitApplicationTransaction rcrtapp = null;
        Transactions.ApprovalTransaction apprvlTransaction = null;
        Datalayer.RecruitmentApprovalDataBean rcrtapprvaldatabean = null;
        Datalayer.AdvanceApprovalDatabean advncapprdatabean = null;

           DataTable masterdesigntable=null;
       // Transactions.ApprovalTransaction leaveapptransaction = null;
           Transactions.CompanyBranchTransactions cmptransaction = null;
           Transactions.DesignationTransaction dsgtrans = null;
           Transactions.DepartmentTransaction depttrans = null;
           Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.RejectActionTransaction rjctactiontrans = null;

           int deptchangeflag = 0;
           int desgflag = 0;
           int lctnflg = 0;
           DataTable mstrOTApplication = null;
           DataTable mstrLHRTable = null;
        DataTable masterAdvancetable = null;
        DataTable mstrShftchangedata = null;
        DataTable mstrContractdata = null;

        DataTable mstrlvncashdata = null;
        Datalayer.LeaveApprovalDatabean lvapprvldatabean = null;
       
        DataTable masterleavedata = null;
        DataTable masterrecruitdata = null;
        public LevelApprovalForm_2()
        {
            InitializeComponent();
            rcrtapp = new Transactions.RecruitApplicationTransaction();
            apprvlTransaction = new Transactions.ApprovalTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();

            rjctactiontrans = new Transactions.RejectActionTransaction();
        }

        private void LevelApprovalForm_2_Load(object sender, EventArgs e)
        {
            DeptcomboLoad();
            locationListLoad();
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







        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {

            if (rbt_Recruitment.Checked == true)
            {
                selectallforrecruit();
            }
            else if (rbt_leave.Checked == true)
            {
            selectallforLeave();
            }
            else if (rbt_contract.Checked == true)
            {
                selectContractdata();
            }
            else if (rbt_Advance.Checked == true)
            {
                selectAdvancedata();
            }
            else if (rbt_desgn.Checked==true)
            {
                selectdesgdata();
            }
            else if (rbt_OtAplication.Checked == true)
            {
                selectOTdata();
            }
            else if (rbt_lhr.Checked == true)
            {
                selectLHRdata();
            }
            else if (rbt_shift.Checked == true)
            {
                selectShiftdata();
            }
            else if(rbt_leaveencashment .Checked==true){
                selectLeaveencashdata();
            }

        }

////////////////////////////////*********Recruitment***********///////////////////////////////////////////////////////

/// <summary>
/// recruitment clicked
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void rbt_Recruitment_CheckedChanged(object sender, EventArgs e)
        {
            fillrecruitmentdata();
        }




        public void fillrecruitmentdata()
        {

            tbl_ApprovalData.Rows.Clear();
            tbl_ApprovalData.DataSource = null;



            if (rbt_Recruitment.Checked == true)
            {
                GRIDVIEWSETUP();

              
                    masterrecruitdata = rcrtapp.getalldataforApprovallevel2();
                

                for (int i = 0; i < masterrecruitdata.Rows.Count; i++)
                {
                    tbl_ApprovalData.Rows.Add();
                    tbl_ApprovalData.Rows[i].Cells[1].Value = masterrecruitdata.Rows[i][0];
                    tbl_ApprovalData.Rows[i].Cells[2].Value = masterrecruitdata.Rows[i][1];
                    tbl_ApprovalData.Rows[i].Cells[3].Value = masterrecruitdata.Rows[i][2];
                    tbl_ApprovalData.Rows[i].Cells[4].Value = masterrecruitdata.Rows[i][3];
                    tbl_ApprovalData.Rows[i].Cells[5].Value = masterrecruitdata.Rows[i][4];
                    tbl_ApprovalData.Rows[i].Cells[6].Value = masterrecruitdata.Rows[i][5];
                    tbl_ApprovalData.Rows[i].Cells[7].Value = masterrecruitdata.Rows[i][6];
                    tbl_ApprovalData.Rows[i].Cells[8].Value = masterrecruitdata.Rows[i][7];
                    tbl_ApprovalData.Rows[i].Cells[9].Value = masterrecruitdata.Rows[i][8];
                    tbl_ApprovalData.Rows[i].Cells[10].Value = masterrecruitdata.Rows[i][9];
                    tbl_ApprovalData.Rows[i].Cells[11].Value = masterrecruitdata.Rows[i][10];
                    tbl_ApprovalData.Rows[i].Cells[12].Value = masterrecruitdata.Rows[i][11];
                    tbl_ApprovalData.Rows[i].Cells[13].Value = int.Parse(masterrecruitdata.Rows[i][9].ToString()) - int.Parse(masterrecruitdata.Rows[i][11].ToString());
                }

            }

            else
            {

                tbl_ApprovalData.ColumnCount = 1;
            }
            viewOnlybalanceforrecruit();
        }
        public void GRIDVIEWSETUP()
        {
            tbl_ApprovalData.ColumnCount = 1;
            if (rbt_Recruitment.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "S.L");
                tbl_ApprovalData.Columns.Add("2", "Application Code");
                tbl_ApprovalData.Columns.Add("3", "Recruitment Location ");
                tbl_ApprovalData.Columns.Add("4", "Designation");
                tbl_ApprovalData.Columns.Add("5", "Department");

                tbl_ApprovalData.Columns.Add("6", "Contract Type");
                tbl_ApprovalData.Columns.Add("7", "Job Description");
                tbl_ApprovalData.Columns.Add("8", "Applied Number");
                tbl_ApprovalData.Columns.Add("9", " L1 Approval");

                tbl_ApprovalData.Columns.Add("10", "l1 Number");
                tbl_ApprovalData.Columns.Add("11", "L1 Aprroved By");

                tbl_ApprovalData.Columns.Add("12", " L2 Approved ");
                tbl_ApprovalData.Columns.Add("13", " Approve ");
                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;
                tbl_ApprovalData.Columns[9].ReadOnly = true;
                tbl_ApprovalData.Columns[10].ReadOnly = true;
                tbl_ApprovalData.Columns[11].ReadOnly = true;
                tbl_ApprovalData.Columns[12].ReadOnly = true;
                tbl_ApprovalData.Columns[13].ReadOnly = true;
                tbl_ApprovalData.RowTemplate.Height = 18;

            }
            else if (rbt_leave.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "App Id");
                tbl_ApprovalData.Columns.Add("2", "Approv Id");
                tbl_ApprovalData.Columns.Add("3", "Application #");
                tbl_ApprovalData.Columns.Add("4", "Emp Name ");
                tbl_ApprovalData.Columns.Add("5", "Designation");
                tbl_ApprovalData.Columns.Add("6", "Department");
                tbl_ApprovalData.Columns.Add("7", "Branch");
                tbl_ApprovalData.Columns.Add("8", "LeaveName");
                tbl_ApprovalData.Columns.Add("9", "Leavetype");
                tbl_ApprovalData.Columns.Add("10", "Allowed Leave");
                tbl_ApprovalData.Columns.Add("11", "From");
                tbl_ApprovalData.Columns.Add("12", "To");
                tbl_ApprovalData.Columns.Add("13", " Duration ");
                tbl_ApprovalData.Columns.Add("14", "DurationType ");
                tbl_ApprovalData.Columns.Add("15", " L1 Approved ");
                tbl_ApprovalData.Columns.Add("16", "L1 by ");
                tbl_ApprovalData.Columns.Add("17", "L2  Approved ");
                tbl_ApprovalData.Columns.Add("18", "L2  Approve ");
                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;
                tbl_ApprovalData.Columns[9].ReadOnly = true;
                tbl_ApprovalData.Columns[10].ReadOnly = true;
                tbl_ApprovalData.Columns[11].ReadOnly = true;
                tbl_ApprovalData.Columns[12].ReadOnly = true;
                tbl_ApprovalData.Columns[13].ReadOnly = true;
                tbl_ApprovalData.Columns[14].ReadOnly = true;
                tbl_ApprovalData.Columns[15].ReadOnly = true;
                tbl_ApprovalData.Columns[16].ReadOnly = true;
                tbl_ApprovalData.Columns[17].ReadOnly = true;
                tbl_ApprovalData.Columns[18].ReadOnly = true;
                tbl_ApprovalData.RowTemplate.Height = 18;


            }
            else if (rbt_Advance.Checked == true)
            {


                tbl_ApprovalData.Columns.Add("1", "App Id");
                tbl_ApprovalData.Columns.Add("2", "Approv Id");
                tbl_ApprovalData.Columns.Add("3", "APPLICATION #");
                tbl_ApprovalData.Columns.Add("4", "Emp Name ");
                tbl_ApprovalData.Columns.Add("5", "Designation");
                tbl_ApprovalData.Columns.Add("6", "Department");
                tbl_ApprovalData.Columns.Add("7", "Branch");

                tbl_ApprovalData.Columns.Add("8", "Emp Nation");
                tbl_ApprovalData.Columns.Add("9", "Amount");
                tbl_ApprovalData.Columns.Add("10", "Currency");
                tbl_ApprovalData.Columns.Add("11", "Duration");

                tbl_ApprovalData.Columns.Add("12", "Duration Type ");
                tbl_ApprovalData.Columns.Add("13", " Instalments of  ");
                tbl_ApprovalData.Columns.Add("14", "Reason");
                tbl_ApprovalData.Columns.Add("15", "L1 Approved");
                tbl_ApprovalData.Columns.Add("16", "L1 by ");
                tbl_ApprovalData.Columns.Add("17", "L2  Approved ");
                tbl_ApprovalData.Columns.Add("18", "L2  Approve ");
                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;
                tbl_ApprovalData.Columns[9].ReadOnly = true;
                tbl_ApprovalData.Columns[10].ReadOnly = true;
                tbl_ApprovalData.Columns[11].ReadOnly = true;
                tbl_ApprovalData.Columns[12].ReadOnly = true;
                tbl_ApprovalData.Columns[13].ReadOnly = true;
                tbl_ApprovalData.Columns[14].ReadOnly = true;
                tbl_ApprovalData.Columns[15].ReadOnly = true;
                tbl_ApprovalData.Columns[16].ReadOnly = true;
                 tbl_ApprovalData.Columns[17].ReadOnly = true;
                 tbl_ApprovalData.Columns[18].ReadOnly = true;
                tbl_ApprovalData.RowTemplate.Height = 18;






            }
            else if (rbt_lhr.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "App Id");

                tbl_ApprovalData.Columns.Add("2", "APPLICATION #");
                tbl_ApprovalData.Columns.Add("3", "Date  ");
                tbl_ApprovalData.Columns.Add("4", "Location");

                tbl_ApprovalData.Columns.Add("5", "Reason");
                tbl_ApprovalData.Columns.Add("6", "Total LHR");
                tbl_ApprovalData.Columns.Add("7", "NO of Employees");
                tbl_ApprovalData.Columns.Add("8", "Applied BY");


                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;

            }

            else  if (rbt_desgn.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "App Id");
                tbl_ApprovalData.Columns.Add("2", "Approv Id");
                tbl_ApprovalData.Columns.Add("3", "APPLICATION #");
                tbl_ApprovalData.Columns.Add("4", "Emp ID");
                tbl_ApprovalData.Columns.Add("5", "Emp Name ");
                tbl_ApprovalData.Columns.Add("6", " Current Designation");
                tbl_ApprovalData.Columns.Add("7", "Current  Department");
                tbl_ApprovalData.Columns.Add("8", "Current Location");
                tbl_ApprovalData.Columns.Add("9", "TO Designation");
                tbl_ApprovalData.Columns.Add("10", "To  Department");
                tbl_ApprovalData.Columns.Add("11", "To Location");
                tbl_ApprovalData.Columns.Add("12", "L1 Approved By");
                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;
                tbl_ApprovalData.Columns[9].ReadOnly = true;
                tbl_ApprovalData.Columns[10].ReadOnly = true;
                tbl_ApprovalData.Columns[11].ReadOnly = true;
                tbl_ApprovalData.Columns[12].ReadOnly = true;
            }
            else if (rbt_OtAplication.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "App Id");
                tbl_ApprovalData.Columns.Add("2", "Approv Id");
                tbl_ApprovalData.Columns.Add("3", "APPLICATION #");
                tbl_ApprovalData.Columns.Add("4", "Date  ");
                tbl_ApprovalData.Columns.Add("5", "Department");

                tbl_ApprovalData.Columns.Add("7", "P/H DURATION ");
                tbl_ApprovalData.Columns.Add("6", "OT  Reason");
                tbl_ApprovalData.Columns.Add("8", "OT HEADS");
                tbl_ApprovalData.Columns.Add("9", "Total OT Duration");
                tbl_ApprovalData.Columns.Add("10", "L1 Approved");
                tbl_ApprovalData.Columns.Add("11", "level1 Approved By");
                tbl_ApprovalData.Columns.Add("12", "l2 Approved ");
                tbl_ApprovalData.Columns.Add("13", " Approve");
                tbl_ApprovalData.Columns.Add("13", "  OT Amount");
                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;
                tbl_ApprovalData.Columns[9].ReadOnly = true;
                tbl_ApprovalData.Columns[10].ReadOnly = true;
                tbl_ApprovalData.Columns[11].ReadOnly = true;
                tbl_ApprovalData.Columns[12].ReadOnly = true;
                tbl_ApprovalData.Columns[13].ReadOnly = true;
                tbl_ApprovalData.Columns[1].Visible = false;
                tbl_ApprovalData.Columns[2].Visible = false;
            }

            else if (rbt_shift.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "App Id");

                tbl_ApprovalData.Columns.Add("2", "APPLICATION #");
                tbl_ApprovalData.Columns.Add("3", "Emp No  ");
                tbl_ApprovalData.Columns.Add("4", "EmpName");


                tbl_ApprovalData.Columns.Add("6", "Designation Name");
                tbl_ApprovalData.Columns.Add("7", "Department Name");
                tbl_ApprovalData.Columns.Add("8", "From Shift");
                tbl_ApprovalData.Columns.Add("9", "To shift Shift");


                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;


            }

            else if (rbt_contract.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "App Id");

                tbl_ApprovalData.Columns.Add("2", "APPLICATION #");
                tbl_ApprovalData.Columns.Add("3", "Emp No  ");
                tbl_ApprovalData.Columns.Add("4", "EmpName");


                tbl_ApprovalData.Columns.Add("6", "Designation Name");
                tbl_ApprovalData.Columns.Add("7", "Department Name");
                tbl_ApprovalData.Columns.Add("8", " Current Contract");
                tbl_ApprovalData.Columns.Add("9", "Actual Joining Date");


                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;


            }
            else if (rbt_leaveencashment.Checked == true)
            {
                tbl_ApprovalData.Columns.Add("1", "LvnEncshPK");

                tbl_ApprovalData.Columns.Add("2", "empid");
                tbl_ApprovalData.Columns.Add("3", "Contract id  ");
                tbl_ApprovalData.Columns.Add("4", "Appnum");
                tbl_ApprovalData.Columns.Add("5", "Empno");
                tbl_ApprovalData.Columns.Add("6", "Emp Name");
                tbl_ApprovalData.Columns.Add("7", "Designation Name");
                tbl_ApprovalData.Columns.Add("8", "Department Name");
                tbl_ApprovalData.Columns.Add("9", " Current Year");
                tbl_ApprovalData.Columns.Add("10", "Encash Duration");
                tbl_ApprovalData.Columns.Add("11", "Duration Type");
                tbl_ApprovalData.Columns.Add("12", "Added Date");
                tbl_ApprovalData.Columns.Add("13", " Amount");
                tbl_ApprovalData.Columns.Add("14", "Approve");
                tbl_ApprovalData.Columns[0].ReadOnly = false;
                tbl_ApprovalData.Columns[1].ReadOnly = true;
                tbl_ApprovalData.Columns[2].ReadOnly = true;
                tbl_ApprovalData.Columns[3].ReadOnly = true;
                tbl_ApprovalData.Columns[4].ReadOnly = true;
                tbl_ApprovalData.Columns[5].ReadOnly = true;
                tbl_ApprovalData.Columns[6].ReadOnly = true;
                tbl_ApprovalData.Columns[7].ReadOnly = true;
                tbl_ApprovalData.Columns[8].ReadOnly = true;
                tbl_ApprovalData.Columns[9].ReadOnly = true;
                tbl_ApprovalData.Columns[10].ReadOnly = true;
                tbl_ApprovalData.Columns[11].ReadOnly = true;
                tbl_ApprovalData.Columns[12].ReadOnly = true;
                tbl_ApprovalData.Columns[13].ReadOnly = true;
                tbl_ApprovalData.Columns[14].ReadOnly = true;


            }
            tbl_ApprovalData.RowTemplate.Height = 18;

        }

        public void viewOnlybalanceforrecruit()
        {
          

            int row = tbl_ApprovalData.Rows.Count - 1;
            for (int i = row - 1; i >= 0; i--)
            {

                if (int.Parse(tbl_ApprovalData.Rows[i].Cells[13].Value.ToString()) == 0)
                {
                    tbl_ApprovalData.Rows.RemoveAt(i);

                }
            }



        }


        private void tbl_ApprovalData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (rbt_Recruitment.Checked == true)
                {
                    if (tbl_ApprovalData.Rows[e.RowIndex].Cells.Count == 14)
                    {




                        if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                        {
                            tbl_ApprovalData.Rows[e.RowIndex].Cells[13].ReadOnly = false;

                        }
                        else
                        {
                            tbl_ApprovalData.Rows[e.RowIndex].Cells[13].ReadOnly = true;
                        }
                    }


                }

                else if (rbt_contract.Checked == true)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = true;
                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = false;
                    }

                }
                else if (rbt_leave.Checked == true)
                {





                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Cells[18].ReadOnly = false;

                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Cells[18].ReadOnly = true;
                    }



                }

                else if (rbt_Advance.Checked == true)
                {

                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Cells[18].ReadOnly = false;

                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Cells[18].ReadOnly = true;
                    }
                }

                else if (rbt_desgn.Checked == true)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = true;
                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = false;
                    }


                }
                else if (rbt_shift.Checked == true)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = true;
                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = false;
                    }

                }

                else if (rbt_OtAplication.Checked == true)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Cells[13].ReadOnly = false;
                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Cells[13].ReadOnly = true;
                    }
                }
                else if (rbt_lhr.Checked == true)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = true;
                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = false;
                    }

                }
                else if (rbt_leaveencashment .Checked == true)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = true;
                    }
                    else
                    {
                        tbl_ApprovalData.Rows[e.RowIndex].Selected = false;
                    }

                }

            }
        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
           
        }


        /// <summary>
        /// select the rows in the table if rcrtment is selected
        /// </summary>
        public void selectallforrecruit()
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                    tbl_ApprovalData.Rows[i].Selected = true;
                    tbl_ApprovalData.Columns[13].ReadOnly = false;
                }

            }
            else
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                    tbl_ApprovalData.Rows[i].Selected = false;
                    tbl_ApprovalData.Columns[13].ReadOnly = true; ;
                }
            }
        }

        /// <summary>
        /// actions recuired to do recruitmentprocess
        /// </summary>
        public void recruitmentApprovalaction()
        {
            for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                {
                    if (validationcontrolforrecruit(i))
                    {
                        rcrtapprvaldatabean = new Datalayer.RecruitmentApprovalDataBean();

                        rcrtapprvaldatabean.RecruitmentAppPk1 = int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString());
                        rcrtapprvaldatabean.Islevel2 = "A";
                        rcrtapprvaldatabean.Level2num = int.Parse(tbl_ApprovalData.Rows[i].Cells[13].Value.ToString()) + int.Parse(tbl_ApprovalData.Rows[i].Cells[12].Value.ToString());
                        rcrtapprvaldatabean.Level2date2 = DateTime.Now.Date;
                        int approvednow = int.Parse(tbl_ApprovalData.Rows[i].Cells[13].Value.ToString());
                        DataTable dt = apprvlTransaction.getexistingApproval(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()));
                        if (dt.Rows.Count != 0)
                        {
                            int pk = int.Parse(dt.Rows[0][0].ToString());

                            // rcrtapptransaction.updatedata(rcrtapprvaldatabean, balance for approval , recruitmentApprovalpk ,numbeapprovednow );
                            apprvlTransaction.ApproveRecruitLevel2(rcrtapprvaldatabean, pk, approvednow);

                          
                        }

                    }
                }
            }
             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            fillrecruitmentdata();
        }


        public Boolean validationcontrolforrecruit(int i)
        {
            Boolean sucess = false;

            if (tbl_ApprovalData.Rows[i].Cells[13].Value.ToString() == "0")
            {
                lblStatus.Text = "Approved Vaccancy  Cannot Be Zero for" + tbl_ApprovalData.Rows[i].Cells[2].Value.ToString();
                tbl_ApprovalData.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
            }

            else if (int.Parse(tbl_ApprovalData.Rows[i].Cells[13].Value.ToString()) > int.Parse(tbl_ApprovalData.Rows[i].Cells[10].Value.ToString()))
            {
                lblStatus.Text = "Approved Vaccancy  Cannot Be  More Than Applied Number" + tbl_ApprovalData.Rows[i].Cells[2].Value.ToString();
                tbl_ApprovalData.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
            }


            else if (int.Parse(tbl_ApprovalData.Rows[i].Cells[13].Value.ToString()) + int.Parse(tbl_ApprovalData.Rows[i].Cells[12].Value.ToString()) > int.Parse(tbl_ApprovalData.Rows[i].Cells[10].Value.ToString()))
            {
                lblStatus.Text = "Approved Vaccancy  Cannot Be  More Than Applied Number" + tbl_ApprovalData.Rows[i].Cells[2].Value.ToString();
                tbl_ApprovalData.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
            }

            else
            {
                sucess = true;
                tbl_ApprovalData.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            return sucess;
        }





////////////////////****************Leave Application**********//////////////////////////////////////////////////////////////////////





/// <summary>
/// leave clicked
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>


        private void rbt_leave_CheckedChanged(object sender, EventArgs e)
        {
            showleaveappdata();

        }

        public void showleaveappdata()
        {



            if (rbt_leave.Checked == true)
            {
                // masterleavedata = apprvlTransaction.getallLeavedataforApproval2();
                masterleavedata = apprvlTransaction.getallLeaveForApproval(2, int.Parse(cmb_location.SelectedValue.ToString()));
                GRIDVIEWSETUP();
                for (int i = 0; i < masterleavedata.Rows.Count; i++)
                {

                    tbl_ApprovalData.Rows.Add();
                    tbl_ApprovalData.Rows[i].Cells[1].Value = masterleavedata.Rows[i][0];

                    tbl_ApprovalData.Rows[i].Cells[2].Value = masterleavedata.Rows[i][1];
                    tbl_ApprovalData.Rows[i].Cells[3].Value = masterleavedata.Rows[i][2];
                    tbl_ApprovalData.Rows[i].Cells[4].Value = masterleavedata.Rows[i][3];
                    tbl_ApprovalData.Rows[i].Cells[5].Value = masterleavedata.Rows[i][4];
                    tbl_ApprovalData.Rows[i].Cells[6].Value = masterleavedata.Rows[i][5];
                    tbl_ApprovalData.Rows[i].Cells[7].Value = masterleavedata.Rows[i][6];   //BALACE 
                    tbl_ApprovalData.Rows[i].Cells[8].Value = masterleavedata.Rows[i][7];
                    tbl_ApprovalData.Rows[i].Cells[9].Value = masterleavedata.Rows[i][8];
                    tbl_ApprovalData.Rows[i].Cells[10].Value = masterleavedata.Rows[i][9];
                    tbl_ApprovalData.Rows[i].Cells[11].Value = masterleavedata.Rows[i][10];
                    string basicsal = masterleavedata.Rows[i][10].ToString() + "  " + masterleavedata.Rows[i][11].ToString();
                    tbl_ApprovalData.Rows[i].Cells[12].Value = masterleavedata.Rows[i][11];
                    tbl_ApprovalData.Rows[i].Cells[13].Value = masterleavedata.Rows[i][12];
                    tbl_ApprovalData.Rows[i].Cells[14].Value = masterleavedata.Rows[i][13];
                    tbl_ApprovalData.Rows[i].Cells[15].Value = masterleavedata.Rows[i][14];
                    tbl_ApprovalData.Rows[i].Cells[16].Value = masterleavedata.Rows[i][15];
                    tbl_ApprovalData.Rows[i].Cells[17].Value = masterleavedata.Rows[i][16];
                    if (masterleavedata.Rows[i][16] == null || masterleavedata.Rows[i][16].ToString() == "")
                    {
                        tbl_ApprovalData.Rows[i].Cells[17].Value = "0";
                    }

                    tbl_ApprovalData.Rows[i].Cells[18].Value = int.Parse(tbl_ApprovalData.Rows[i].Cells[15].Value.ToString()) - int.Parse(tbl_ApprovalData.Rows[i].Cells[17].Value.ToString());

                }

            }
            else
            {
                tbl_ApprovalData.ColumnCount = 1;
            }


        }
        /// <summary>
        /// select the rows in the table if rLeave is selected
        /// </summary>
        public void selectallforLeave()
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                    tbl_ApprovalData.Rows[i].Selected = true;
                    tbl_ApprovalData.Columns[18].ReadOnly = false;
                }

            }
            else
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                    tbl_ApprovalData.Rows[i].Selected = false;
                    tbl_ApprovalData.Columns[18].ReadOnly = true; ;
                }
            }
        }

        /// <summary>
        /// apply to processes to leave approval
        /// </summary>
        public void leaveapprovalAction()
        {
            try
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                    {
                        if (validationcontrolforLeave(i))
                        {


                            lvapprvldatabean = new Datalayer.LeaveApprovalDatabean();
                            lvapprvldatabean.Islevel2 = "A";
                            lvapprvldatabean.Level2num  = int.Parse(tbl_ApprovalData.Rows[i].Cells[17].Value.ToString()) + int.Parse(tbl_ApprovalData.Rows[i].Cells[18].Value.ToString());
                            lvapprvldatabean.Level2date2   = DateTime.Now.Date;
                            lvapprvldatabean.LeaveAppPk = int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString());
                            lvapprvldatabean.LeaveapprovalPK = int.Parse(tbl_ApprovalData.Rows[i].Cells[2].Value.ToString());
                            lvapprvldatabean.Approvdnow = int.Parse(tbl_ApprovalData.Rows[i].Cells[18].Value.ToString());

                            apprvlTransaction.LeaveApprovalLevel2(lvapprvldatabean);

                            DataTable dt = apprvlTransaction.GetTheLeaveApprovedDays(lvapprvldatabean.LeaveAppPk);
                            Administrator.Ultrafridform  frm = new Administrator.Ultrafridform(dt);
                            frm.Text = "Approved Leave Dates";
                            frm.ShowDialog();
                       //     this.Close();


                        }
                    }
                }
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                masterleavedata  = null;
                showleaveappdata ();
            }
            catch (Exception exp)
            {


                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }









        }


        /// <summary>
        /// validationcontrol wheen Leave is selkected
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Boolean validationcontrolforLeave(int i)
        {
            Boolean sucess = false;

            if (tbl_ApprovalData.Rows[i].Cells[16].Value.ToString() == "0")
            {
                lblStatus.Text = "Approved Value Cannot Be Zero for" + tbl_ApprovalData.Rows[i].Cells[3].Value.ToString();

            }

            else if (int.Parse(tbl_ApprovalData.Rows[i].Cells[18].Value.ToString()) + int.Parse(tbl_ApprovalData.Rows[i].Cells[17].Value.ToString()) > int.Parse(tbl_ApprovalData.Rows[i].Cells[15].Value.ToString()))
            {
                lblStatus.Text = "Approved Leave  Cannot Be  More Than Level One Approved Number" + tbl_ApprovalData.Rows[i].Cells[2].Value.ToString();

            }

            else
            {
                sucess = true;
            }

            return sucess;
        }

 //////////////////////////////////////////////////////******Advance********//////////////////////////////////////////

        /// <summary>
        /// select the rows in the table if Advance is selected
        /// </summary>
        public void selectAdvancedata()
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                    tbl_ApprovalData.Rows[i].Selected = true;
                    tbl_ApprovalData.Columns[18].ReadOnly = false;
                }

            }
            else
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                    tbl_ApprovalData.Rows[i].Selected = false;
                    tbl_ApprovalData.Columns[18].ReadOnly = true; ;
                }
            }
        }

        private void rbt_Advance_CheckedChanged(object sender, EventArgs e)
        {
            showadvancedata();
        }

        public void showadvancedata()
        {

            tbl_ApprovalData.Rows.Clear();
            //  tbl_ApprovalData.Columns.Clear();
            tbl_ApprovalData.DataSource = null;
            if (rbt_Advance.Checked == true)
            {

                //  masterAdvancetable = apprvlTransaction.getallAdvancedataforApproval2 ();
                masterAdvancetable = apprvlTransaction.getallAdvancedataforAlLevelsOfApproval(2, int.Parse(cmb_location.SelectedValue.ToString()));
                GRIDVIEWSETUP();

                for (int i = 0; i < masterAdvancetable.Rows.Count; i++)
                {

                    tbl_ApprovalData.Rows.Add();
                    tbl_ApprovalData.Rows[i].Cells[1].Value = masterAdvancetable.Rows[i][0];

                    tbl_ApprovalData.Rows[i].Cells[2].Value = masterAdvancetable.Rows[i][1];
                    tbl_ApprovalData.Rows[i].Cells[3].Value = masterAdvancetable.Rows[i][2];
                    tbl_ApprovalData.Rows[i].Cells[4].Value = masterAdvancetable.Rows[i][3];
                    tbl_ApprovalData.Rows[i].Cells[5].Value = masterAdvancetable.Rows[i][4];
                    tbl_ApprovalData.Rows[i].Cells[6].Value = masterAdvancetable.Rows[i][5];
                    tbl_ApprovalData.Rows[i].Cells[7].Value = masterAdvancetable.Rows[i][6];
                    tbl_ApprovalData.Rows[i].Cells[8].Value = masterAdvancetable.Rows[i][7];
                    tbl_ApprovalData.Rows[i].Cells[9].Value = masterAdvancetable.Rows[i][8];
                    tbl_ApprovalData.Rows[i].Cells[10].Value = masterAdvancetable.Rows[i][9];
                    tbl_ApprovalData.Rows[i].Cells[11].Value = masterAdvancetable.Rows[i][10];

                    tbl_ApprovalData.Rows[i].Cells[12].Value = masterAdvancetable.Rows[i][11];
                    tbl_ApprovalData.Rows[i].Cells[13].Value = masterAdvancetable.Rows[i][12];
                    tbl_ApprovalData.Rows[i].Cells[14].Value = masterAdvancetable.Rows[i][13];
                    tbl_ApprovalData.Rows[i].Cells[15].Value = masterAdvancetable.Rows[i][14];
                    tbl_ApprovalData.Rows[i].Cells[16].Value = masterAdvancetable.Rows[i][15];
                    if (masterAdvancetable.Rows[i][16] == null || masterAdvancetable.Rows[i][16].ToString() == "" || masterAdvancetable.Rows[i][16].ToString() == "0")
                    {
                        tbl_ApprovalData.Rows[i].Cells[17].Value = "0";
                    }
                    else
                    {
                        tbl_ApprovalData.Rows[i].Cells[17].Value = masterAdvancetable.Rows[i][16];
                    }
                    tbl_ApprovalData.Rows[i].Cells[18].Value = int.Parse(tbl_ApprovalData.Rows[i].Cells[15].Value.ToString()) - int.Parse(tbl_ApprovalData.Rows[i].Cells[17].Value.ToString());

                }




            }
            else
            {
                tbl_ApprovalData.ColumnCount = 1;
            }


        }


        /// <summary>
        /// validates the datagridview
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Boolean validationcontrolforAdvance(int i)
        {
            Boolean sucess = false;

            if (tbl_ApprovalData.Rows[i].Cells[18].Value.ToString() == "0")
            {
                lblStatus.Text = "Approved Amount Cannot Be Zero for" + tbl_ApprovalData.Rows[i].Cells[3].Value.ToString();

            }

            else if (int.Parse(tbl_ApprovalData.Rows[i].Cells[18].Value.ToString()) + int.Parse(tbl_ApprovalData.Rows[i].Cells[17].Value.ToString()) > int.Parse(tbl_ApprovalData.Rows[i].Cells[15].Value.ToString()))
            {
                lblStatus.Text = "Approved Amount   Cannot Be  More Than Applied Number" + tbl_ApprovalData.Rows[i].Cells[3].Value.ToString();

            }

            else
            {
                sucess = true;
            }

            return sucess;
        }

        public void AdvanceappAction()
        {


            try
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                    {
                        if (validationcontrolforAdvance(i))
                        {


                            advncapprdatabean = new Datalayer.AdvanceApprovalDatabean();
                            advncapprdatabean.Islevel2 = "A";
                            advncapprdatabean.Level2num = int.Parse(tbl_ApprovalData.Rows[i].Cells[17].Value.ToString()) + int.Parse(tbl_ApprovalData.Rows[i].Cells[18].Value.ToString());
                            advncapprdatabean.Level2date2 = DateTime.Now.Date;
                            advncapprdatabean.AdvanceAppPK1 = int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString());
                            advncapprdatabean.ApprovalPk1 = int.Parse(tbl_ApprovalData.Rows[i].Cells[2].Value.ToString());
                            advncapprdatabean.Approvdnow = int.Parse(tbl_ApprovalData.Rows[i].Cells[18].Value.ToString());

                            apprvlTransaction.AdvanceApprovalLevel2(advncapprdatabean);
                           
                        //    this.Close();


                        }
                    }
                }
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                masterAdvancetable = null;
                showadvancedata();
            } catch (Exception exp)
            {


                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              //  this.Dispose();
            }

          


        }




 ////////////////////////////////////////////////////////////////Designation Change\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




/// <summary>
///
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void rbt_desgn_CheckedChanged(object sender, EventArgs e)
        {

            filldesignationData();

        }




        /// <summary>
        /// select the rows in the table if Designation is selected
        /// </summary>
        public void selectdesgdata()
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                    tbl_ApprovalData.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
                {
                    tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                    tbl_ApprovalData.Rows[i].Selected = false;

                }
            }
        }




        public Boolean validationcontrolforDesignatione(int i)
        {
            Boolean sucess = false;

            if (tbl_ApprovalData.Rows[i].Cells[1].Value.ToString() == "")
            {
                lblStatus.Text = "Approved Amount Cannot Be Zero for" + tbl_ApprovalData.Rows[i].Cells[3].Value.ToString();

            }



            else
            {
                sucess = true;
            }

            return sucess;
        }
    
    
    /// <summary>
    /// fill the grid with application approved in level 2 for desgnation change
    /// </summary>
      public void filldesignationData()
        {
            
            tbl_ApprovalData.Rows.Clear();
            //  tbl_ApprovalData.Columns.Clear();
            tbl_ApprovalData.DataSource = null;

            if (rbt_desgn.Checked == true)
            {



              //  masterdesigntable = apprvlTransaction.getallDesignationdataforApproval2  ();
                masterdesigntable = apprvlTransaction.getAllDesignationChangeApplication(int.Parse(cmb_location.SelectedValue.ToString()), 2);
                GRIDVIEWSETUP();

                for (int i = 0; i < masterdesigntable.Rows.Count; i++)
                {

                    tbl_ApprovalData.Rows.Add();
                    tbl_ApprovalData.Rows[i].Cells[1].Value = masterdesigntable.Rows[i][0];

                    tbl_ApprovalData.Rows[i].Cells[2].Value = masterdesigntable.Rows[i][1];
                    tbl_ApprovalData.Rows[i].Cells[3].Value = masterdesigntable.Rows[i][2]; 
                    tbl_ApprovalData.Rows[i].Cells[4].Value = masterdesigntable.Rows[i][3]; 
                    tbl_ApprovalData.Rows[i].Cells[5].Value = masterdesigntable.Rows[i][4];
                    tbl_ApprovalData.Rows[i].Cells[6].Value = masterdesigntable.Rows[i][5]; 
                    tbl_ApprovalData.Rows[i].Cells[7].Value = masterdesigntable.Rows[i][6];   
                    tbl_ApprovalData.Rows[i].Cells[8].Value = masterdesigntable.Rows[i][7];
                    tbl_ApprovalData.Rows[i].Cells[9].Value = masterdesigntable.Rows[i][8]; 
                    tbl_ApprovalData.Rows[i].Cells[10].Value = masterdesigntable.Rows[i][9]; 
                    tbl_ApprovalData.Rows[i].Cells[11].Value = masterdesigntable.Rows[i][10];         
                     tbl_ApprovalData.Rows[i].Cells[12].Value = masterdesigntable.Rows[i][11];   
                  

                    

                }

            }
            else
            {
                tbl_ApprovalData.ColumnCount = 1;
            }

        }

        
      /// <summary>
      /// Approve changes the designation
      /// </summary>
      public void approvedesignationchangeaction()
      {
          try
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
              {
                  if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                  {

                      if (validationcontrolforDesignatione(i))
                      {
                          apprvlTransaction.UpdateDesignationChangeApprovalLevel2(int.Parse(tbl_ApprovalData.Rows[i].Cells[2].Value.ToString()));
                          
                        //  this.Close();
                      }
                  }
              }
               ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
              masterdesigntable = null;
              filldesignationData();
          }
          catch (Exception exp)
          {


              if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
              {
                   ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
              }


              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);
               ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              this.Dispose();
          }





      }

      private void btn_add_Click(object sender, EventArgs e)
      {
          try
          {
              if (rbt_Recruitment.Checked == true)
              {
                  recruitmentApprovalaction();
              }
              else if (rbt_leave.Checked == true)
              {

                  leaveapprovalAction();

              }
              else if (rbt_Advance.Checked == true)
              {
                  AdvanceappAction();
              }
              else if (rbt_desgn.Checked == true)
              {
                  approvedesignationchangeaction();
              }
              else if (rbt_OtAplication.Checked == true)
              {
                  otApproveAction();
              }
              else if (rbt_shift.Checked == true)
              {
                  ShiftApprovalAction();
              }
              else if (rbt_lhr.Checked == true)
              {
                  LHRApprovalAction();
              }
              else if (rbt_contract.Checked == true)
              {
                  ContractRenewalApplication();
              }
              else if (rbt_leaveencashment.Checked == true)
              {
                  LeaveEncshmentApproveaction();
              }
          }
          catch (Exception exp)
          {
              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);

              this.Dispose();
          }
        //  this.Close();
      }

      private void tbl_ApprovalData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
      {
          if (tbl_ApprovalData.IsCurrentCellDirty)
          {
              tbl_ApprovalData.CommitEdit(DataGridViewDataErrorContexts.Commit);
          }
      }

      private void cmb_location_MouseClick(object sender, MouseEventArgs e)
      {
          lctnflg++;
      }

      private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
      {
          resrictacess();
      }

      private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
      {
          if (deptchangeflag !=0)
          {
              getallDesignation();
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

      private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
      {
          deptchangeflag++;
      }

      private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
      {
          desgflag++;
      }





//////////////////////////////////////////// OT APPLICATION DATA ////////////////////////////////////////


/// <summary>
/// /
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>

      private void rbt_OtAplication_CheckedChanged(object sender, EventArgs e)
      {
          showotappdaat();
      }


      public void showotappdaat()
      {


          tbl_ApprovalData.Rows.Clear();
          //  tbl_ApprovalData.Columns.Clear();
          tbl_ApprovalData.DataSource = null;
          if (rbt_OtAplication.Checked == true)
          {

              mstrOTApplication = apprvlTransaction.getallOTApplicationforApprovals(2, int.Parse(cmb_location.SelectedValue.ToString()));

              GRIDVIEWSETUP();

              for (int i = 0; i < mstrOTApplication.Rows.Count; i++)
              {

                  tbl_ApprovalData.Rows.Add();
                  tbl_ApprovalData.Rows[i].Cells[1].Value = mstrOTApplication.Rows[i][0];

                  tbl_ApprovalData.Rows[i].Cells[2].Value = mstrOTApplication.Rows[i][1];
                  tbl_ApprovalData.Rows[i].Cells[3].Value = mstrOTApplication.Rows[i][2]; 
                  tbl_ApprovalData.Rows[i].Cells[4].Value = mstrOTApplication.Rows[i][3]; 
                  tbl_ApprovalData.Rows[i].Cells[5].Value = mstrOTApplication.Rows[i][4];
                  tbl_ApprovalData.Rows[i].Cells[6].Value = mstrOTApplication.Rows[i][5]; 
                  tbl_ApprovalData.Rows[i].Cells[7].Value = mstrOTApplication.Rows[i][6];   
                  tbl_ApprovalData.Rows[i].Cells[8].Value = mstrOTApplication.Rows[i][7];
                  tbl_ApprovalData.Rows[i].Cells[9].Value = mstrOTApplication.Rows[i][8]; 
                  tbl_ApprovalData.Rows[i].Cells[10].Value = mstrOTApplication.Rows[i][9]; 
                  tbl_ApprovalData.Rows[i].Cells[11].Value = mstrOTApplication.Rows[i][10]; 
                  tbl_ApprovalData.Rows[i].Cells[12].Value = mstrOTApplication.Rows[i][11];
                  if (mstrOTApplication.Rows[i][11] == null || mstrOTApplication.Rows[i][11].ToString() == "")
                  {
                      tbl_ApprovalData.Rows[i].Cells[12].Value = "0";
                  }
                  tbl_ApprovalData.Rows[i].Cells[13].Value = int.Parse(tbl_ApprovalData.Rows[i].Cells[10].Value.ToString()) - int.Parse(tbl_ApprovalData.Rows[i].Cells[12].Value.ToString());

                  tbl_ApprovalData.Rows[i].Cells[14].Value = mstrOTApplication.Rows[i][14];
              }




          }
          else
          {
              tbl_ApprovalData.ColumnCount = 1;
          }
      }

      /// <summary>
      /// select the rows in the table if Advance is selected
      /// </summary>
      public void selectOTdata()
      {
          if (chk_Selection.Checked == true)
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                  tbl_ApprovalData.Rows[i].Selected = true;
                  tbl_ApprovalData.Columns[13].ReadOnly = false;
              }

          }
          else
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                  tbl_ApprovalData.Rows[i].Selected = false;
                  tbl_ApprovalData.Columns[13].ReadOnly = true; ;
              }
          }
      }





      public void otApproveAction()
      {
          try
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
              {
                  if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                  {
                      if (validationcontrolforOT(i))
                      {


                          apprvlTransaction.ApproveOTApllications(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_ApprovalData.Rows[i].Cells[2].Value.ToString()), 2, int.Parse(tbl_ApprovalData.Rows[i].Cells[13].Value.ToString()));

                         
                       //   this.Close();
                      }
                  }
              }
               ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
              mstrOTApplication = null;
              showotappdaat();
          }
          catch (Exception exp)
          {


              if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
              {
                   ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
              }


              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);
               ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              this.Dispose();
          }






      }



      /// <summary>
      /// validates the datagridview
      /// </summary>
      /// <param name="i"></param>
      /// <returns></returns>
      public Boolean validationcontrolforOT(int i)
      {
          Boolean sucess = false;

          if (tbl_ApprovalData.Rows[i].Cells[11].Value.ToString() == "0")
          {
              lblStatus.Text = "Approved Duration Cannot Be Zero for" + tbl_ApprovalData.Rows[i].Cells[3].Value.ToString();

          }

          else if (int.Parse(tbl_ApprovalData.Rows[i].Cells[12].Value.ToString()) + int.Parse(tbl_ApprovalData.Rows[i].Cells[13].Value.ToString()) > int.Parse(tbl_ApprovalData.Rows[i].Cells[10].Value.ToString()))
          {
              lblStatus.Text = "Approved Duration    Cannot Be  More Than Applied Duration " + tbl_ApprovalData.Rows[i].Cells[3].Value.ToString();

          }

          else
          {
              sucess = true;
          }

          return sucess;
      }
////////////////////////////////***********LHR****************/////////////////////////////////////////////



      private void rbt_lhr_CheckedChanged(object sender, EventArgs e)
      {
          fillLHRApplication();
      }


      /// <summary>
      /// fill lhr application
      /// </summary>
      public void fillLHRApplication()
      {

          tbl_ApprovalData.Rows.Clear();
          //  tbl_ApprovalData.Columns.Clear();
          tbl_ApprovalData.DataSource = null;

          if (rbt_lhr.Checked == true)
          {





              mstrLHRTable = apprvlTransaction.getallLHRForApproval(int.Parse(cmb_location.SelectedValue.ToString()), 2);

              GRIDVIEWSETUP();

              for (int i = 0; i < mstrLHRTable.Rows.Count; i++)
              {

                  tbl_ApprovalData.Rows.Add();
                  tbl_ApprovalData.Rows[i].Cells[1].Value = mstrLHRTable.Rows[i][0];

                  tbl_ApprovalData.Rows[i].Cells[2].Value = mstrLHRTable.Rows[i][1];
                  tbl_ApprovalData.Rows[i].Cells[3].Value = mstrLHRTable.Rows[i][2];
                  tbl_ApprovalData.Rows[i].Cells[4].Value = mstrLHRTable.Rows[i][3];
                  tbl_ApprovalData.Rows[i].Cells[5].Value = mstrLHRTable.Rows[i][4];
                  tbl_ApprovalData.Rows[i].Cells[6].Value = mstrLHRTable.Rows[i][5];
                  tbl_ApprovalData.Rows[i].Cells[7].Value = mstrLHRTable.Rows[i][6];
                  tbl_ApprovalData.Rows[i].Cells[8].Value = mstrLHRTable.Rows[i][7];






              }

          }
          else
          {
              tbl_ApprovalData.ColumnCount = 1;
          }

      }


      /// <summary>
      /// APPROVAL OF ot aPLLICATIONS
      /// </summary>
      public void LHRApprovalAction()
      {
          try
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
              {
                  if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                  {



                      apprvlTransaction.approveLHRApplications(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()),2, int.Parse(tbl_ApprovalData.Rows[i].Cells[6].Value.ToString()));

                     
                    //  this.Close();

                  }
              }
               ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
              mstrLHRTable = null;
              fillLHRApplication();
          }
          catch (Exception exp)
          {


              if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
              {
                   ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
              }


              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);
               ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              this.Dispose();
          }






      }





      /// <summary>
      /// select the rows in the table if lhr is selected
      /// </summary>
      public void selectLHRdata()
      {
          if (chk_Selection.Checked == true)
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                  tbl_ApprovalData.Rows[i].Selected = true;

              }

          }
          else
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                  tbl_ApprovalData.Rows[i].Selected = false;

              }
          }
      }



      ///////////////////////////////////////////////////////////Shift Change///////////////////////////////////////////////






      /// <summary>
      /// select the rows in the table if lhr is selected
      /// </summary>
      public void selectShiftdata()
      {
          if (chk_Selection.Checked == true)
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                  tbl_ApprovalData.Rows[i].Selected = true;

              }

          }
          else
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                  tbl_ApprovalData.Rows[i].Selected = false;

              }
          }
      }

    



      /// <summary>
      /// APPROVAL OF ot aPLLICATIONS
      /// </summary>
      public void ShiftApprovalAction()
      {
          try
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
              {
                  if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                  {



                      apprvlTransaction.UpdatesShiftChangeApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 2, "A");

                     
                      // this.Close();

                  }
              }

               ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
              showshiftAppdata();
          }
          catch (Exception exp)
          {


              if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
              {
                   ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
              }


              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);
               ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              this.Dispose();
          }






      }







      public void showshiftAppdata()
      {

          tbl_ApprovalData.Rows.Clear();
          //  tbl_ApprovalData.Columns.Clear();
          tbl_ApprovalData.DataSource = null;
          if (rbt_shift.Checked == true)
          {

              mstrShftchangedata = apprvlTransaction.getShiftChangeForApproval(2, int.Parse(cmb_location.SelectedValue.ToString()));

              GRIDVIEWSETUP();

              for (int i = 0; i < mstrShftchangedata.Rows.Count; i++)
              {

                  tbl_ApprovalData.Rows.Add();
                  tbl_ApprovalData.Rows[i].Cells[1].Value = mstrShftchangedata.Rows[i][0];

                  tbl_ApprovalData.Rows[i].Cells[2].Value = mstrShftchangedata.Rows[i][1];
                  tbl_ApprovalData.Rows[i].Cells[3].Value = mstrShftchangedata.Rows[i][2];
                  tbl_ApprovalData.Rows[i].Cells[4].Value = mstrShftchangedata.Rows[i][3];
                  tbl_ApprovalData.Rows[i].Cells[5].Value = mstrShftchangedata.Rows[i][4];
                  tbl_ApprovalData.Rows[i].Cells[6].Value = mstrShftchangedata.Rows[i][5];
                  tbl_ApprovalData.Rows[i].Cells[7].Value = mstrShftchangedata.Rows[i][6];
                  tbl_ApprovalData.Rows[i].Cells[8].Value = mstrShftchangedata.Rows[i][7];
                  //    tbl_ApprovalData.Rows[i].Cells[9].Value = mstrShftchangedata.Rows[i][8]; 




              }




          }
          else
          {
              tbl_ApprovalData.ColumnCount = 1;
          }


      }

      private void rbt_shift_CheckedChanged_1(object sender, EventArgs e)
      {

          showshiftAppdata();
      }


//////////////////////////////////////Contract Data//////////////////////////////////////////////////////////////////





/// <summary>
/// selecting all rows of a contract
/// </summary>


      public void selectContractdata()
      {
          if (chk_Selection.Checked == true)
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                  tbl_ApprovalData.Rows[i].Selected = true;

              }

          }
          else
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                  tbl_ApprovalData.Rows[i].Selected = false;

              }
          }
      }


      public void showContractAppdata()
      {

          tbl_ApprovalData.Rows.Clear();
          //  tbl_ApprovalData.Columns.Clear();
          tbl_ApprovalData.DataSource = null;
          if (rbt_contract.Checked == true)
          {

              mstrContractdata = apprvlTransaction.getallContractRenewalApplicationforApprovals(2, int.Parse(cmb_location.SelectedValue.ToString()));

              GRIDVIEWSETUP();

              for (int i = 0; i < mstrContractdata.Rows.Count; i++)
              {

                  tbl_ApprovalData.Rows.Add();
                  tbl_ApprovalData.Rows[i].Cells[1].Value = mstrContractdata.Rows[i][0];

                  tbl_ApprovalData.Rows[i].Cells[2].Value = mstrContractdata.Rows[i][1];
                  tbl_ApprovalData.Rows[i].Cells[3].Value = mstrContractdata.Rows[i][2];
                  tbl_ApprovalData.Rows[i].Cells[4].Value = mstrContractdata.Rows[i][3];
                  tbl_ApprovalData.Rows[i].Cells[5].Value = mstrContractdata.Rows[i][4];
                  tbl_ApprovalData.Rows[i].Cells[6].Value = mstrContractdata.Rows[i][5];
                  tbl_ApprovalData.Rows[i].Cells[7].Value = mstrContractdata.Rows[i][6];
                  tbl_ApprovalData.Rows[i].Cells[8].Value = mstrContractdata.Rows[i][7];
                  //    tbl_ApprovalData.Rows[i].Cells[9].Value = mstrShftchangedata.Rows[i][8]; 




              }




          }
          else
          {
              tbl_ApprovalData.ColumnCount = 1;
          }


      }

      /// <summary>
      /// APPROVAL OF Contract Renewal aPLLICATIONS
      /// </summary>
      public void ContractRenewalApplication()
      {
          try
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
              {
                  if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                  {



                      apprvlTransaction.ApproveContractRenewalApllications(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 2, 0);

                     
                      // this.Close();

                  }
              }

               ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
              showshiftAppdata();
          }
          catch (Exception exp)
          {


              if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
              {
                   ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
              }


              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);
               ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              this.Dispose();
          }






      }

      private void rbt_contract_CheckedChanged(object sender, EventArgs e)
      {
          showContractAppdata();
      }



/////////////////////////////////////Leave Encashment//////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      private void rbt_leaveencashment_CheckedChanged(object sender, EventArgs e)
      {
          showLeaveEncashmentData();
      }




        /// <summary>
        /// select all the leave encash data
        /// </summary>
      public void selectLeaveencashdata()
      {
          if (chk_Selection.Checked == true)
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = true;
                  tbl_ApprovalData.Rows[i].Selected = true;

              }

          }
          else
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count - 1; i++)
              {
                  tbl_ApprovalData.Rows[i].Cells[0].Value = false;
                  tbl_ApprovalData.Rows[i].Selected = false;

              }
          }
      }


/// <summary>
/// SHOW ALL THE LEAVE ENCHASHMENT APP
/// </summary>
      public void showLeaveEncashmentData()
      {

          tbl_ApprovalData.Rows.Clear();
          //  tbl_ApprovalData.Columns.Clear();
          tbl_ApprovalData.DataSource = null;
          if (rbt_leaveencashment .Checked == true)
          {

              mstrlvncashdata = apprvlTransaction.getLeaveEnchasementApplicationforApproval(2, int.Parse(cmb_location.SelectedValue.ToString()));

              GRIDVIEWSETUP();

              for (int i = 0; i < mstrlvncashdata.Rows.Count; i++)
              {

                  tbl_ApprovalData.Rows.Add();
                  tbl_ApprovalData.Rows[i].Cells[1].Value = mstrlvncashdata.Rows[i][0];

                  tbl_ApprovalData.Rows[i].Cells[2].Value = mstrlvncashdata.Rows[i][1];
                  tbl_ApprovalData.Rows[i].Cells[3].Value = mstrlvncashdata.Rows[i][2];
                  tbl_ApprovalData.Rows[i].Cells[4].Value = mstrlvncashdata.Rows[i][3];
                  tbl_ApprovalData.Rows[i].Cells[5].Value = mstrlvncashdata.Rows[i][4];
                  tbl_ApprovalData.Rows[i].Cells[6].Value = mstrlvncashdata.Rows[i][5];
                  tbl_ApprovalData.Rows[i].Cells[7].Value = mstrlvncashdata.Rows[i][6];
                  tbl_ApprovalData.Rows[i].Cells[8].Value = mstrlvncashdata.Rows[i][7];
                  tbl_ApprovalData.Rows[i].Cells[9].Value = mstrlvncashdata.Rows[i][8];
                  tbl_ApprovalData.Rows[i].Cells[10].Value = mstrlvncashdata.Rows[i][9];
                  tbl_ApprovalData.Rows[i].Cells[11].Value = mstrlvncashdata.Rows[i][10];
                  tbl_ApprovalData.Rows[i].Cells[12].Value = mstrlvncashdata.Rows[i][11];
                  tbl_ApprovalData.Rows[i].Cells[13].Value = 0;

                  tbl_ApprovalData.Rows[i].Cells[14].Value =0;



              }




          }
          else
          {
              tbl_ApprovalData.ColumnCount = 1;
          }


      }

/// <summary>
/// approves a leaveencashment application of one row
/// </summary>
      public void LeaveEncshmentApproveaction()
      {
          try
          {
              for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
              {
                  if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
                  {



                      apprvlTransaction.UpdateLeaveEncashmentApp(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 2, "A");

                   
                      // this.Close();

                  }
              }

               ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
              showshiftAppdata();
          }
          catch (Exception exp)
          {


              if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
              {
                   ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
              }


              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);
               ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              this.Dispose();
          }






      }

      private void toolStripButton3_Click(object sender, EventArgs e)
      {
          try
          {
              rejectaction();
          }
          catch (Exception exp)
          {
              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);

              this.Dispose();
          }
      }

      public void rejectaction()
      {

          for (int i = 0; i < tbl_ApprovalData.Rows.Count; i++)
          {
              if (Convert.ToBoolean(tbl_ApprovalData.Rows[i].Cells[0].Value) == true)
              {
                  if (rbt_Recruitment.Checked == true)
                  {
                      rjctactiontrans.rejectApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 0, "Recruitment Rejection", 2);
                      masterrecruitdata = null;
                      fillrecruitmentdata ();
                  }
                  else if (rbt_leave.Checked == true)
                  {
                      rjctactiontrans.rejectApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 0, "Leave Rejection", 2);

                      showleaveappdata();
                  }
                  else if (rbt_Advance.Checked == true)
                  {
                      rjctactiontrans.rejectApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 0, "Advance Rejection", 2);
                      showadvancedata ();
                  }
                  else if (rbt_desgn .Checked == true)
                  {
                      rjctactiontrans.rejectApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 0, "Designation Change Rejection", 2);
                      filldesignationData();
                  }
                  else if (rbt_OtAplication.Checked == true)
                  { 
                    rjctactiontrans.rejectApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[2].Value.ToString()), 0, "OT Rejection", 2);
                    showotappdaat();

               
                  }
                  else if (rbt_lhr.Checked == true)
                  {

                  }
                  else if (rbt_shift.Checked == true)
                  {
                      rjctactiontrans.rejectApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 0, "Shift Change Rejection", 2);

                      showshiftAppdata();

                  }
                  else if (rbt_contract.Checked == true)
                  {
                      rjctactiontrans.rejectApplication(int.Parse(tbl_ApprovalData.Rows[i].Cells[1].Value.ToString()), 0, "Contract Renewal Rejection", 2);
                      showContractAppdata();
                  }
                  else if (rbt_leaveencashment.Checked == true)
                  {

                  }
              }
          }

      }

      private void viewitems_Click(object sender, EventArgs e)
      {
          if (rbt_OtAplication.Checked == true)
          {
              if (tbl_ApprovalData.Rows.Count != 0)
              {
                  int rowindexer = tbl_ApprovalData.CurrentRow.Index;
                  int appid = int.Parse(tbl_ApprovalData.Rows[rowindexer].Cells[2].Value.ToString());



                  Approvals.OTApprovalSubForm otprvlsub = new Approvals.OTApprovalSubForm(this ,appid, 2);
                  otprvlsub.MdiParent = this.MdiParent;
                  otprvlsub.Show();

              }
          }
          else if (rbt_leave.Checked == true)
          {
              int rowindexer = tbl_ApprovalData.CurrentRow.Index;
              int appid = int.Parse(tbl_ApprovalData.Rows[rowindexer].Cells[1].Value.ToString());

              Applications.LeaveConfirmForm lvcnfrm = new Applications.LeaveConfirmForm(appid);
              lvcnfrm.MdiParent = this.MdiParent;
              lvcnfrm.Show();

          }
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
          this.Close();
      }

     

     
    
    }
}

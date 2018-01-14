using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace ATCHRM.Action
{
    public partial class ActionMasterForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.HolidayTransaction hldytransaction = null;
        Transactions.OvertimeandShiftTransaction ovrshfttrans = null;
        Transactions.Adjuster.AdjusterTranscation ajstrtrans = null;
        Transactions.ShiftTransactionNewform shftransaction = null;
        Transactions.LeaveTransaction lvtrans = null;
        Transactions.ActionTransactions actntrans = null;
        Transactions.LeaveandAdvanceAppTransaction lvapadvncetrans = null;
        Transactions.Helper hlpr = null;
        int deptchangeflag = 0;
        //   int desgflag = 0;
        int lctnflg = 0;

        DataTable employeeswipetable = null;
        Transactions.AttendanceManagementTransaction attndmngmnttrans = null;
        public ActionMasterForm()
        {
            InitializeComponent();
            //System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            //dateInfo.ShortDatePattern = "dd/MM/yyyy"; 
            hldytransaction = new Transactions.HolidayTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            attndmngmnttrans = new Transactions.AttendanceManagementTransaction();
            actntrans = new Transactions.ActionTransactions();
            lvtrans = new Transactions.LeaveTransaction();
            shftransaction = new Transactions.ShiftTransactionNewform();
            lvapadvncetrans = new Transactions.LeaveandAdvanceAppTransaction();
            ovrshfttrans = new Transactions.OvertimeandShiftTransaction();
            hlpr = new Transactions.Helper();
            datgridviewsetup();

            ajstrtrans = new Transactions.Adjuster.AdjusterTranscation();
        }

        private void makeAbsentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tbl_attendancedata.SelectedRows[0].Cells[11].Value = "PL";
            tbl_attendancedata.SelectedRows[0].Cells[12].Value = "PL";



            //  ActionReasonForm actnreason = new ActionReasonForm(1);
            //actnreason.ShowDialog();
        }

        private void makePresentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbl_attendancedata.SelectedRows[0].Cells[11].Value = "SL";
            tbl_attendancedata.SelectedRows[0].Cells[12].Value = "SL";
            //ActionReasonForm actnreason = new ActionReasonForm(2);
            //actnreason.ShowDialog();
        }

        private void putLeavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbl_attendancedata.SelectedRows[0].Cells[11].Value = "ML";
            tbl_attendancedata.SelectedRows[0].Cells[12].Value = "ML";
            //ActionReasonForm actnreason = new ActionReasonForm(3);
            //actnreason.ShowDialog();
        }

        private void markAOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbl_attendancedata.SelectedRows[0].Cells[11].Value = "UPL";
            tbl_attendancedata.SelectedRows[0].Cells[12].Value = "UPL";
            //ActionReasonForm actnreason = new ActionReasonForm(4);
            //actnreason.ShowDialog();
        }


        public void shiftcomboload()
        {
            DataTable dt = shftransaction.getAllShiftName();

            cmb_toshift.DataSource = dt;
            cmb_toshift.DisplayMember = "ShiftName";
            cmb_toshift.ValueMember = "ShiftPk";
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

        private void ActionMasterForm_Load(object sender, EventArgs e)
        {
            DeptcomboLoad();
            locationListLoad();
            shiftcomboload();
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptchangeflag != 0)
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




















        /// <summary>
        /// 
        /// </summary>
        public void datgridviewsetup()
        {
            tbl_attendancedata.ColumnCount = 1;

            tbl_attendancedata.Columns.Add("1", "Swipedataid");
            tbl_attendancedata.Columns.Add("2", "SwipePK");
            tbl_attendancedata.Columns.Add("3", "Empid ");
            tbl_attendancedata.Columns.Add("4", "EmpNo#");
            tbl_attendancedata.Columns.Add("5", "EmpName");
            tbl_attendancedata.Columns.Add("6", "Designation");
            tbl_attendancedata.Columns.Add("7", "Department");
            tbl_attendancedata.Columns.Add("8", "Date");
            tbl_attendancedata.Columns.Add("9", "In Time");
            tbl_attendancedata.Columns.Add("10", "Out Time");
            tbl_attendancedata.Columns.Add("11", "Instatus");
            tbl_attendancedata.Columns.Add("12", "Out Stastus");
            tbl_attendancedata.Columns.Add("13", "In value");
            tbl_attendancedata.Columns.Add("14", "Out Value");
            tbl_attendancedata.Columns.Add("15", "Action required");
            tbl_attendancedata.Columns.Add("16", "Approved In Status");
            tbl_attendancedata.Columns.Add("17", "Approved Out Status");
            tbl_attendancedata.Columns.Add("18", "Old Empid");
            tbl_attendancedata.Columns.Add("19", "Applied InStatus");
            tbl_attendancedata.Columns.Add("20", "Applied OutStatus");
            tbl_attendancedata.Columns.Add("21", "Duration");
            tbl_attendancedata.Columns.Add("22", "ShiftPk");

            tbl_attendancedata.RowTemplate.Height = 18;
            //    tbl_attendancedata.Columns[1].Visible = false;
            //   tbl_attendancedata.Columns[2].Visible = false;
            //   tbl_attendancedata.Columns[13].Visible = false;

        }


        public void filldatagridview(DataTable employeeswipetable)
        {


            tbl_attendancedata.RowCount = 1;

            for (int i = 0; i < employeeswipetable.Rows.Count; i++)
            {


                tbl_attendancedata.Rows.Add();
                tbl_attendancedata.Rows[i].Cells[1].Value = employeeswipetable.Rows[i][0].ToString();
                tbl_attendancedata.Rows[i].Cells[2].Value = employeeswipetable.Rows[i][1].ToString();
                tbl_attendancedata.Rows[i].Cells[3].Value = employeeswipetable.Rows[i][2].ToString();
                tbl_attendancedata.Rows[i].Cells[4].Value = employeeswipetable.Rows[i][3].ToString();
                tbl_attendancedata.Rows[i].Cells[5].Value = employeeswipetable.Rows[i][4].ToString();
                tbl_attendancedata.Rows[i].Cells[6].Value = employeeswipetable.Rows[i][5].ToString();
                tbl_attendancedata.Rows[i].Cells[7].Value = employeeswipetable.Rows[i][6].ToString();
                tbl_attendancedata.Rows[i].Cells[8].Value = DateTime.Parse(employeeswipetable.Rows[i][7].ToString()).ToString("dd/MM/yyyy");
                tbl_attendancedata.Rows[i].Cells[9].Value = DateTime.Parse(employeeswipetable.Rows[i][8].ToString()).ToString("HH:mm:ss");
                tbl_attendancedata.Rows[i].Cells[10].Value = DateTime.Parse(employeeswipetable.Rows[i][9].ToString()).ToString("HH:mm:ss");
                tbl_attendancedata.Rows[i].Cells[11].Value = employeeswipetable.Rows[i][10].ToString();
                tbl_attendancedata.Rows[i].Cells[12].Value = employeeswipetable.Rows[i][11].ToString();
                tbl_attendancedata.Rows[i].Cells[13].Value = employeeswipetable.Rows[i][12].ToString();
                tbl_attendancedata.Rows[i].Cells[14].Value = employeeswipetable.Rows[i][13].ToString();
                tbl_attendancedata.Rows[i].Cells[15].Value = employeeswipetable.Rows[i][14].ToString();
                tbl_attendancedata.Rows[i].Cells[16].Value = employeeswipetable.Rows[i][15].ToString();
                tbl_attendancedata.Rows[i].Cells[17].Value = employeeswipetable.Rows[i][16].ToString();
                tbl_attendancedata.Rows[i].Cells[18].Value = employeeswipetable.Rows[i][17].ToString();
                tbl_attendancedata.Rows[i].Cells[19].Value = employeeswipetable.Rows[i][18].ToString();
                tbl_attendancedata.Rows[i].Cells[20].Value = employeeswipetable.Rows[i][19].ToString();
                tbl_attendancedata.Rows[i].Cells[21].Value = employeeswipetable.Rows[i][20].ToString();
                tbl_attendancedata.Rows[i].Cells[22].Value = employeeswipetable.Rows[i][21].ToString();

                highlighter(i);
            }

            AvoidLeaveEmployees();
        }
        /// <summary>
        /// this action occurs wher undo action button is 
        /// pressed
        /// </summary>
        public void undoAction()
        {
            RejectGridsetupsetup();
            DataTable dt = actntrans.GetAllActionDone(int.Parse(cmb_location.SelectedValue.ToString()), dtp_datevalue.Value.Date, "");
            fillDataGridforUndo(dt);

        }
        /// <summary>
        /// this will redraw the datagridview for the undo action
        /// </summary>
        public void RejectGridsetupsetup()
        {

            tbl_attendancedata.Rows.Clear();
            tbl_attendancedata.ColumnCount = 1;
            tbl_attendancedata.DataSource = null;


            tbl_attendancedata.Columns.Add("1", "Acton Id");
            tbl_attendancedata.Columns.Add("2", "Swipe Id #");
            tbl_attendancedata.Columns.Add("3", "Empid ");
            tbl_attendancedata.Columns.Add("4", "Emp Code");
            tbl_attendancedata.Columns.Add("5", "Name");
            tbl_attendancedata.Columns.Add("6", "Dept");
            tbl_attendancedata.Columns.Add("7", "ActionForDate");
            tbl_attendancedata.Columns.Add("8", "Action Type");
            tbl_attendancedata.Columns.Add("9", "From Component");
            tbl_attendancedata.Columns.Add("10", "To Component");
            tbl_attendancedata.Columns.Add("11", "In or Out");
            tbl_attendancedata.Columns.Add("12", "Status");

            menuStrip1.Enabled = false;
            menuStrip1.ContextMenuStrip = cmnstrp_undoaction;
            this.BackColor = Color.DarkKhaki;

        }

        /// <summary>
        /// fill the datagridview with all the Actions done but not 
        /// done by the Level 1 
        /// </summary>
        /// <param name="actiondata"></param>
        public void fillDataGridforUndo(DataTable actiondata)
        {




            for (int i = 0; i < actiondata.Rows.Count; i++)
            {


                tbl_attendancedata.Rows.Add();
                tbl_attendancedata.Rows[i].Cells[1].Value = actiondata.Rows[i][0].ToString();
                tbl_attendancedata.Rows[i].Cells[2].Value = actiondata.Rows[i][1].ToString();
                tbl_attendancedata.Rows[i].Cells[3].Value = actiondata.Rows[i][2].ToString();
                tbl_attendancedata.Rows[i].Cells[4].Value = actiondata.Rows[i][3].ToString();
                tbl_attendancedata.Rows[i].Cells[5].Value = actiondata.Rows[i][4].ToString();
                tbl_attendancedata.Rows[i].Cells[6].Value = actiondata.Rows[i][5].ToString();
                tbl_attendancedata.Rows[i].Cells[7].Value = actiondata.Rows[i][6].ToString();

                tbl_attendancedata.Rows[i].Cells[8].Value = actiondata.Rows[i][7].ToString();
                tbl_attendancedata.Rows[i].Cells[9].Value = actiondata.Rows[i][8].ToString();
                tbl_attendancedata.Rows[i].Cells[10].Value = actiondata.Rows[i][9].ToString();
                tbl_attendancedata.Rows[i].Cells[11].Value = actiondata.Rows[i][10].ToString();
                tbl_attendancedata.Rows[i].Cells[12].Value = actiondata.Rows[i][11].ToString();



            }
        }

        /// <summary>
        /// get any off days or leave of that days
        /// </summary>

        public void getdatFromDatabase()
        {
            try
            {
                tabControl1.SelectedTab = tabPage1;

                employeeswipetable = actntrans.GetSwipeemplyeesdetailforAction(int.Parse(cmb_location.SelectedValue.ToString()), dtp_datevalue.Value.Date);

                DataTable dt = hldytransaction.getAnyHolidayofaDate(dtp_datevalue.Value.Date, int.Parse(cmb_location.SelectedValue.ToString()));
                filldatagridview(employeeswipetable);
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        lbl_daystatus.Text = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        lbl_daystatus.Text = "Working Day";
                    }
                }


            }
            catch (Exception)
            {


            }
        }

        private void dtp_datevalue_ValueChanged(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// when select all done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_checkAll_CheckedChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                selectallonbuttonOnmain();
            }

            else if (tabControl1.SelectedTab == tabPage2)
            {
                selectAllclicked(tbl_Gatepassdaata);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                selectAllclicked(tbl_leavedata);
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                selectAllclicked(tbl_swipeonleave);

            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                selectAllclicked(tbl_wrongswipedata);
            }
            else if (tabControl1.SelectedTab == tabPage7)
            {
                selectAllclicked(tbl_offOt);
            }
            else if (tabControl1.SelectedTab == tabPage8)
            {
                selectAllclicked(tbl_otdata);
            }
            else if (tabControl1.SelectedTab == tabPage9)
            {
                selectAllclicked(tbl_UOTData);
            }
            else if (tabControl1.SelectedTab == tabPage10)
            {
                selectAllclicked(tbl_abscent);
            }
            else if (tabControl1.SelectedTab == tabPage11)
            {
                selectAllclicked(tbl_presenties);
            }
            else if (tabControl1.SelectedTab == tabPage12)
            {
                selectAllclicked(tbl_abscentononeside);
            }
            else if (tabControl1.SelectedTab == tabPage14)
            {
                selectAllclicked(tbl_extrastatus);
            }
        }














        public void selectAllclicked(DataGridView tbl_grid)
        {
            if (cmb_checkAll.Checked == true)
            {
                for (int i = 0; i < tbl_grid.Rows.Count; i++)
                {
                    tbl_grid.Rows[i].Cells[0].Value = true;
                }

            }
            else
            {
                for (int i = 0; i < tbl_grid.Rows.Count; i++)
                {
                    tbl_grid.Rows[i].Cells[0].Value = false;
                }
            }
        }






        public void selectallonbuttonOnmain()
        {
            if (cmb_checkAll.Checked == true)
            {
                for (int i = 0; i < tbl_attendancedata.Rows.Count; i++)
                {
                    if ((Convert.ToString(tbl_attendancedata.Rows[i].Cells[11].Value).Trim() == "P") && (Convert.ToString(tbl_attendancedata.Rows[i].Cells[12].Value).Trim() == "A") || (Convert.ToString(tbl_attendancedata.Rows[i].Cells[11].Value).Trim() == "A") && (Convert.ToString(tbl_attendancedata.Rows[i].Cells[12].Value).Trim() == "P"))
                    {
                        if ((Convert.ToString(tbl_attendancedata.Rows[i].Cells[11].Value).Trim()) != (Convert.ToString(tbl_attendancedata.Rows[i].Cells[16].Value).Trim()) || (Convert.ToString(tbl_attendancedata.Rows[i].Cells[12].Value).Trim()) != (Convert.ToString(tbl_attendancedata.Rows[i].Cells[17].Value).Trim()))
                        {
                            tbl_attendancedata.Rows[i].Cells[0].Value = false;
                        }
                        else
                        {
                            tbl_attendancedata.Rows[i].Cells[0].Value = true;
                        }
                    }
                    else
                    {
                        tbl_attendancedata.Rows[i].Cells[0].Value = false;
                    }

                }
            }
            else
            {
                for (int i = 0; i < tbl_attendancedata.Rows.Count; i++)
                {
                    tbl_attendancedata.Rows[i].Cells[0].Value = false;
                }
            }

            lblStatus.Text = tbl_attendancedata.SelectedRows.Count.ToString(); ;


        }


        public int selectedrownumber()
        {
            int selectedflag = 0;
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    selectedflag++;
                }
            }

            return selectedflag;
        }





        /// <summary>
        /// send the marked leave action for approvals
        /// </summary>
        public Boolean applyLeaveAction(int rownum, String Inout, int colnmunum)
        {
            Boolean sucesss = true;
            ArrayList arrylst = new ArrayList();
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[1].Value.ToString()));//Swipedataid
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[3].Value.ToString()));//@empid
            arrylst.Add(DateTime.Parse(tbl_attendancedata.Rows[rownum].Cells[8].Value.ToString()));//@Actionfordate
            arrylst.Add("Mark Leave Type");//@ActionType
            arrylst.Add(Inout);//@Inorout
            arrylst.Add(Program.USERPK);
            arrylst.Add("A");//@fromComponent
            arrylst.Add(tbl_attendancedata.Rows[rownum].Cells[colnmunum].Value.ToString());//@tocomponent

            sucesss = actntrans.MarkLeaveAction(arrylst);
            return sucesss;
        }

        /// <summary>
        /// Reject action
        /// </summary>
        /// <param name="inout"></param>
        /// <param name="rownum"></param>
        /// <param name="columnnum"></param>
        public Boolean applyRejectaction(String inout, int rownum, int columnnum)
        {
            Boolean sucesss = true;
            ArrayList arrylst = new ArrayList();
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[1].Value.ToString()));
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[3].Value.ToString()));
            arrylst.Add(DateTime.Parse(tbl_attendancedata.Rows[rownum].Cells[8].Value.ToString()));
            arrylst.Add("Rejection Type");
            arrylst.Add(inout);
            arrylst.Add(Program.USERPK);

            arrylst.Add(tbl_attendancedata.Rows[rownum].Cells[columnnum].Value.ToString());
            arrylst.Add("P");
            sucesss = actntrans.MarkLeaveAction(arrylst);
            return sucesss;
        }


        /// <summary>
        /// mark present
        /// </summary>
        /// <param name="inout"></param>
        /// <param name="rownum"></param>
        /// <param name="columnnum"></param>
        public Boolean markPresentaction(String inout, int rownum, int columnnum)
        {
            Boolean sucesss = true;
            ArrayList arrylst = new ArrayList();
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[1].Value.ToString()));
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[3].Value.ToString()));
            arrylst.Add(DateTime.Parse(tbl_attendancedata.Rows[rownum].Cells[8].Value.ToString()));
            arrylst.Add("Mark Present Type");
            arrylst.Add(inout);
            arrylst.Add(Program.USERPK);

            arrylst.Add(tbl_attendancedata.Rows[rownum].Cells[columnnum].Value.ToString());
            arrylst.Add("P");
            sucesss = actntrans.MarkLeaveAction(arrylst);
            return sucesss;
        }
        /// <summary>
        /// marking OT
        /// </summary>
        /// <param name="inout"></param>
        /// <param name="rownum"></param>
        /// <param name="columnnum"></param>
        /// <param name="ottype"></param>
        public Boolean MarkOTaction(String inout, int rownum, int columnnum, String ottype)
        {
            Action.OtValueApproval dataform = new Action.OtValueApproval();
            dataform.ShowDialog();
            int actionvalue = 0;


            try
            {
                actionvalue = int.Parse(dataform.Amount);
            }
            catch (Exception)
            {

                actionvalue = 0;
            }

            Boolean sucesss = true;
            ArrayList arrylst = new ArrayList();
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[1].Value.ToString()));
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[3].Value.ToString()));
            arrylst.Add(DateTime.Parse(tbl_attendancedata.Rows[rownum].Cells[8].Value.ToString()));
            arrylst.Add("Mark OT Type");
            arrylst.Add(inout);
            arrylst.Add(Program.USERPK);

            arrylst.Add(tbl_attendancedata.Rows[rownum].Cells[columnnum].Value.ToString());
            arrylst.Add(ottype);
            arrylst.Add(actionvalue);
            sucesss = actntrans.MarkLeaveAction(arrylst);
            return sucesss;
        }

        /// <summary>
        /// marking leave
        /// </summary>
        /// <param name="inout"></param>
        /// <param name="rownum"></param>
        /// <param name="columnnum"></param>
        public Boolean MarkAbscentAction(String inout, int rownum, int columnnum)
        {
            Boolean sucesss = true;
            ArrayList arrylst = new ArrayList();
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[1].Value.ToString()));
            arrylst.Add(int.Parse(tbl_attendancedata.Rows[rownum].Cells[3].Value.ToString()));
            arrylst.Add(DateTime.Parse(tbl_attendancedata.Rows[rownum].Cells[8].Value.ToString()));
            arrylst.Add("Mark Abscent Type");
            arrylst.Add(inout);
            arrylst.Add(Program.USERPK);

            arrylst.Add(tbl_attendancedata.Rows[rownum].Cells[columnnum].Value.ToString());
            arrylst.Add("A");
            sucesss = actntrans.MarkLeaveAction(arrylst);
            return sucesss;
        }


        public void MarkleaveAction(String leavetype)
        {
            int countnum = 0;
            if (tbl_attendancedata.SelectedRows.Count > 1)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("You Have to Select Each Employee Seperatly And Assign Leave ");
            }

            else if (selectedrownumber() > 1)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("You Have to Select Each Employee Seperatly And Assign Leave ");
            }
            else
            {


                for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
                {

                    if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                    {
                        string aPPLIEDoUTSTATUS = tbl_attendancedata.Rows[i].Cells["20"].Value.ToString().Trim();
                        string OUTSTATUS = tbl_attendancedata.Rows[i].Cells["12"].Value.ToString().Trim();
                        string aPPROUTSTATUS = tbl_attendancedata.Rows[i].Cells["17"].Value.ToString().Trim();
                        string aPPLIEDINSTATUS = tbl_attendancedata.Rows[i].Cells["19"].Value.ToString().Trim();
                        string INSTATUS = tbl_attendancedata.Rows[i].Cells["11"].Value.ToString().Trim();
                        string APPRINSTATUS = tbl_attendancedata.Rows[i].Cells["16"].Value.ToString().Trim();

                        string[] Leavesarray = { "SHD", "SHP", "HSL", "HPL" };

                        if (ifleaveavailable(int.Parse(tbl_attendancedata.Rows[i].Cells[3].Value.ToString()), leavetype))
                        {


                            if (leavetype == "SHP" || leavetype == "SHD")
                            {
                                if (Leavesarray.Contains(aPPLIEDoUTSTATUS) || Leavesarray.Contains(OUTSTATUS) || Leavesarray.Contains(aPPROUTSTATUS) || Leavesarray.Contains(aPPLIEDINSTATUS) || Leavesarray.Contains(INSTATUS) || Leavesarray.Contains(APPRINSTATUS))
                                {
                                    MessageBox.Show("Already one HalfDay Applied");
                                }
                                else
                                {
                                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A" && tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                                    {
                                        if (MessageBox.Show("Are You Sure You want to Assing  " + leavetype + "  to an employee Abscent on full Day", "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                        {

                                            tbl_attendancedata.Rows[i].Cells[11].Value = leavetype;
                                            applyLeaveAction(i, "IN", 11);

                                        }
                                    }
                                    else
                                    {
                                        if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                                        {
                                            tbl_attendancedata.Rows[i].Cells[11].Value = leavetype;
                                            applyLeaveAction(i, "IN", 11);
                                        }
                                        else if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "A")
                                        {
                                            tbl_attendancedata.Rows[i].Cells[12].Value = leavetype;
                                            applyLeaveAction(i, "OUT", 12);
                                        }

                                    }
                                }
                            }
                            else if (leavetype == "HPL")
                            {
                                if (Leavesarray.Contains(aPPLIEDoUTSTATUS) || Leavesarray.Contains(OUTSTATUS) || Leavesarray.Contains(aPPROUTSTATUS) || Leavesarray.Contains(aPPLIEDINSTATUS) || Leavesarray.Contains(INSTATUS) || Leavesarray.Contains(APPRINSTATUS))
                                {
                                    MessageBox.Show("Already one HalfDay Applied");
                                }
                                else
                                {
                                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A" && tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                                    {
                                        if (MessageBox.Show("Are You Sure You want to Assing  " + leavetype + "  to an employee Abscent on full Day", "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                        {
                                            tbl_attendancedata.Rows[i].Cells[11].Value = leavetype;
                                            applyLeaveAction(i, "IN", 11);

                                        }

                                    }
                                    else
                                    {
                                        if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                                        {
                                            tbl_attendancedata.Rows[i].Cells[11].Value = leavetype;
                                            applyLeaveAction(i, "IN", 11);
                                        }
                                        else if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "A")
                                        {
                                            tbl_attendancedata.Rows[i].Cells[12].Value = leavetype;
                                            applyLeaveAction(i, "OUT", 12);
                                        }
                                        else if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "P" && tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "LH")
                                        {
                                            tbl_attendancedata.Rows[i].Cells[12].Value = leavetype;
                                            applyLeaveAction(i, "OUT", 12);
                                        }
                                        else if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "LH" && tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "P")
                                        {
                                            tbl_attendancedata.Rows[i].Cells[11].Value = leavetype;
                                            applyLeaveAction(i, "IN", 11);
                                        }

                                    }
                                }

                            }
                            else
                            {
                                if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A" && tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                                {
                                    tbl_attendancedata.Rows[i].Cells[12].Value = leavetype;

                                    tbl_attendancedata.Rows[i].Cells[11].Value = leavetype;

                                    applyLeaveAction(i, "IN", 11);
                                    applyLeaveAction(i, "OUT", 12);
                                    countnum++;


                                }
                                else
                                {

                                    ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Mark Leave to Employee ID : " + tbl_attendancedata.Rows[i].Cells[4].Value.ToString());
                                }

                            }

                        }
                    }



                    highlighter(i);

                }


            }


        }


        /// <summary>
        /// highlights the discrepancies in the Attendance
        /// </summary>

        public void highlighter(int i)
        {

            //for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            //    {
            if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "LH")
            {
                this.tbl_attendancedata.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
            }
            else if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
            {
                this.tbl_attendancedata.Rows[i].Cells[11].Style.BackColor = Color.Red;
            }
            else if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
            {
                this.tbl_attendancedata.Rows[i].Cells[11].Style.BackColor = Color.BurlyWood;
            }
            else
            {
                this.tbl_attendancedata.Rows[i].Cells[11].Style.BackColor = Color.White;
            }

            if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "LH")
            {
                this.tbl_attendancedata.Rows[i].Cells[12].Style.BackColor = Color.Yellow;
            }
            else if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "A")
            {
                this.tbl_attendancedata.Rows[i].Cells[12].Style.BackColor = Color.Red;
            }
            else if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
            {
                this.tbl_attendancedata.Rows[i].Cells[12].Style.BackColor = Color.BurlyWood;
            }

            else
            {
                this.tbl_attendancedata.Rows[i].Cells[12].Style.BackColor = Color.White;
            }


            //}

            //    {
            if (tbl_attendancedata.Rows[i].Cells[16].Value.ToString().Trim() == "LH")
            {
                this.tbl_attendancedata.Rows[i].Cells[16].Style.BackColor = Color.Yellow;
            }
            else if (tbl_attendancedata.Rows[i].Cells[16].Value.ToString().Trim() == "A")
            {
                this.tbl_attendancedata.Rows[i].Cells[16].Style.BackColor = Color.Red;
            }
            else if (tbl_attendancedata.Rows[i].Cells[16].Value.ToString().Trim() == "UOT")
            {
                this.tbl_attendancedata.Rows[i].Cells[16].Style.BackColor = Color.BurlyWood;
            }
            else
            {
                this.tbl_attendancedata.Rows[i].Cells[16].Style.BackColor = Color.White;
            }

            if (tbl_attendancedata.Rows[i].Cells[17].Value.ToString().Trim() == "LH")
            {
                this.tbl_attendancedata.Rows[i].Cells[17].Style.BackColor = Color.Yellow;
            }
            else if (tbl_attendancedata.Rows[i].Cells[17].Value.ToString().Trim() == "A")
            {
                this.tbl_attendancedata.Rows[i].Cells[17].Style.BackColor = Color.Red;
            }
            else if (tbl_attendancedata.Rows[i].Cells[17].Value.ToString().Trim() == "UOT")
            {
                this.tbl_attendancedata.Rows[i].Cells[17].Style.BackColor = Color.BurlyWood;
            }

            else
            {
                this.tbl_attendancedata.Rows[i].Cells[12].Style.BackColor = Color.White;
            }

            if (tbl_attendancedata.Rows[i].Cells[19].Value.ToString().Trim() != "NA" || tbl_attendancedata.Rows[i].Cells[20].Value.ToString().Trim() != "NA")
            {
                tbl_attendancedata.Rows[i].DefaultCellStyle.BackColor = Color.Thistle;
            }


        }








        public void AvoidLeaveEmployees()
        {
            DataTable leavedata = lvtrans.GetAllLeaveCodeandName();
            //        for (int i = 0; i < tbl_attendancedata.Rows.Count - 1;i++ )
            for (int i = tbl_attendancedata.Rows.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < leavedata.Rows.Count; j++)
                {
                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == leavedata.Rows[j][0].ToString().Trim() && tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == leavedata.Rows[j][0].ToString().Trim())
                    {

                        tbl_attendancedata.Rows.RemoveAt(i);
                    }
                }

            }




        }










        /// <summary>
        /// convert all absent LH and Leave to present 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_present_Click(object sender, EventArgs e)
        {
            if (tbl_attendancedata.Rows.Count != 0)
            {
                for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                    {

                        if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                        {

                            tbl_attendancedata.Rows[i].Cells[11].Value = "P";


                        }

                        else if (tbl_attendancedata.Rows[i].Cells[10].Value.ToString().Trim() == "LH")
                        {
                            tbl_attendancedata.Rows[i].Cells[10].Value = "P";
                        }






                        if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "A")
                        {
                            tbl_attendancedata.Rows[i].Cells[12].Value = "P";
                        }



                    }
                    highlighter(i);
                }
            }

        }



        private void tbl_attendancedata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_attendancedata.IsCurrentCellDirty)
            {
                tbl_attendancedata.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbl_attendancedata_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == 0)
                {


                    if (Convert.ToBoolean(tbl_attendancedata.Rows[e.RowIndex].Cells[0].Value) == true)
                    {


                        tbl_attendancedata.Rows[e.RowIndex].Selected = true;


                    }
                    else
                    {

                    }

                }
            }
            catch (Exception)
            {


            }
        }



        private void btn_Abscent_Click(object sender, EventArgs e)
        {
            if (tbl_attendancedata.Rows.Count != 0)
            {
                for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
                {

                    if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                    {
                        tbl_attendancedata.Rows[i].Cells[11].Value = "A";
                        tbl_attendancedata.Rows[i].Cells[12].Value = "A";
                    }
                    highlighter(i);
                }



            }
        }
















        private void oT15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {

                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
                    {

                        tbl_attendancedata.Rows[i].Cells[11].Value = "OT1.5";


                    }

                    else if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                    {
                        tbl_attendancedata.Rows[i].Cells[12].Value = "OT1.5";
                    }
                }
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {

                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
                    {

                        tbl_attendancedata.Rows[i].Cells[11].Value = "OT 1.5";


                    }

                    else if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                    {
                        tbl_attendancedata.Rows[i].Cells[12].Value = "OT 1.5";
                    }
                }
            }
        }

        private void oT20ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {

                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
                    {

                        tbl_attendancedata.Rows[i].Cells[11].Value = "OT 2.0";


                    }

                    else if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                    {
                        tbl_attendancedata.Rows[i].Cells[12].Value = "OT 2.0";
                    }
                }
            }
        }

        private void pLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MarkleaveAction("PL");
        }

        private void sLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("SL");
        }

        private void mLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("ML");
        }

        private void uPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("UPL");
        }

        private void oSDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MarkleaveAction("OSD");
        }

        private void rToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MarkleaveAction("R");
        }

        private void sHPToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //  MarkleaveAction("SHP");
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "UOT")
                    {
                        applyRejectaction("IN", i, 11);
                        tbl_attendancedata.Rows[i].Cells[11].Value = "P";
                        tbl_attendancedata.Rows[i].DefaultCellStyle.BackColor = Color.Honeydew;

                    }

                }
            }


        }

        private void outStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                    {
                        applyRejectaction("OUT", i, 12);
                        tbl_attendancedata.Rows[i].Cells[12].Value = "P";
                        tbl_attendancedata.Rows[i].DefaultCellStyle.BackColor = Color.Honeydew;


                    }

                }
            }



        }

        private void foreNoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                    {
                        markPresentaction("IN", i, 11);
                        tbl_attendancedata.Rows[i].Cells[11].Value = "P";


                    }


                }
            }

        }

        private void afterNoonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "A")
                    {
                        markPresentaction("OUT", i, 12);
                        tbl_attendancedata.Rows[i].Cells[12].Value = "P";


                    }

                }
            }
        }

        private void bothToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "A" && tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() == "A")
                    {
                        applyRejectaction("IN", i, 11);
                        applyRejectaction("OUT", i, 12);
                        tbl_attendancedata.Rows[i].Cells[12].Value = "P";
                        tbl_attendancedata.Rows[i].Cells[11].Value = "P";

                    }

                }
            }
        }

        private void oT15ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                    {

                        MarkOTaction("OUT", i, 12, "OT1.5");
                        tbl_attendancedata.Rows[i].Cells[12].Value = "OT1.5";


                    }

                }
            }
        }

        private void oT20ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                    {

                        MarkOTaction("OUT", i, 12, "OT2.0");
                        tbl_attendancedata.Rows[i].Cells[12].Value = "OT2.0";


                    }

                }
            }
        }

        private void forNoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() != "A")
                    {
                        MarkAbscentAction("IN", i, 11);
                        tbl_attendancedata.Rows[i].Cells[11].Value = "A";



                    }
                    else
                    {
                        string aPPLIEDoUTSTATUS = tbl_attendancedata.Rows[i].Cells["20"].Value.ToString().Trim();
                        string OUTSTATUS = tbl_attendancedata.Rows[i].Cells["12"].Value.ToString().Trim();
                        string aPPROUTSTATUS = tbl_attendancedata.Rows[i].Cells["17"].Value.ToString().Trim();
                        if (aPPLIEDoUTSTATUS == "SHD" || OUTSTATUS == "SHD" || OUTSTATUS == "SHD")
                        {
                            MarkAbscentAction("IN", i, 11);
                            tbl_attendancedata.Rows[i].Cells[11].Value = "A";

                        }


                    }

                }
            }
            MessageBox.Show("Attendance Action Applied");
        }

        private void afterNoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() != "A")
                    {
                        MarkAbscentAction("OUT", i, 12);
                        tbl_attendancedata.Rows[i].Cells[12].Value = "A";



                    }
                    else
                    {
                        string aPPLIEDINSTATUS = tbl_attendancedata.Rows[i].Cells["19"].Value.ToString().Trim();
                        string INSTATUS = tbl_attendancedata.Rows[i].Cells["11"].Value.ToString().Trim();
                        string APPRINSTATUS = tbl_attendancedata.Rows[i].Cells["16"].Value.ToString().Trim();
                        if (aPPLIEDINSTATUS == "SHD" || INSTATUS == "SHD" || APPRINSTATUS == "SHD")
                        {
                            MarkAbscentAction("OUT", i, 12);
                            tbl_attendancedata.Rows[i].Cells[12].Value = "A";

                        }


                    }

                }
            }
            MessageBox.Show("Attendance Action Applied");
        }

        private void bothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() != "A" && tbl_attendancedata.Rows[i].Cells[11].Value.ToString().Trim() != "A")
                    {
                        MarkAbscentAction("IN", i, 11);
                        MarkAbscentAction("OUT", i, 12);
                        tbl_attendancedata.Rows[i].Cells[12].Value = "A";
                        tbl_attendancedata.Rows[i].Cells[11].Value = "A";

                    }

                }
            }
        }



        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoAction();
        }

        private void tbl_attendancedata_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (tbl_attendancedata.ColumnCount == 13)
                {
                    Point pt = tbl_attendancedata.PointToScreen(e.Location);
                    cmnstrp_undoaction.Show(pt);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datgridviewsetup();
            getdatFromDatabase();
            menuStrip1.Enabled = true;
            this.BackColor = SystemColors.Control;

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {

                    ArrayList actndata = new ArrayList();
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[1].Value.ToString()));
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[2].Value.ToString()));
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[3].Value.ToString()));
                    actndata.Add(tbl_attendancedata.Rows[i].Cells[11].Value.ToString());
                    actndata.Add(tbl_attendancedata.Rows[i].Cells[8].Value.ToString());
                    actntrans.Deleteactions(actndata);


                }
            }

            undoAction();
        }

        private void holdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {

                    ArrayList actndata = new ArrayList();
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[1].Value.ToString()));
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[2].Value.ToString()));
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[3].Value.ToString()));
                    actndata.Add(tbl_attendancedata.Rows[i].Cells[11].Value.ToString());
                    actndata.Add(tbl_attendancedata.Rows[i].Cells[8].Value.ToString());
                    actntrans.UpdateAttndHoldAction(actndata, "Hold");


                }
            }

            undoAction();
        }

        private void unHoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {

                    ArrayList actndata = new ArrayList();
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[1].Value.ToString()));
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[2].Value.ToString()));
                    actndata.Add(int.Parse(tbl_attendancedata.Rows[i].Cells[3].Value.ToString()));
                    actndata.Add(tbl_attendancedata.Rows[i].Cells[11].Value.ToString());
                    actndata.Add(tbl_attendancedata.Rows[i].Cells[8].Value.ToString());
                    actntrans.UpdateAttndHoldAction(actndata, "Active");


                }
            }

            undoAction();
        }




        private void markOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dayw = "";
            //DataSet ds = GridViewmModels.ClsDatabase.Get_Data("select daystatus from ShiftDayDetails_tbl where "
            //+" DayOFWeekname='" + dtp_datevalue.Value.DayOfWeek + "'");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    dayw =Convert.ToString(ds.Tables[0].Rows[0][0]);
            //}

            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (Convert.ToString(tbl_attendancedata.Rows[i].Cells[12].Value).Trim() == "UOT")
                    {
                        DataSet ds = GridViewmModels.ClsDatabase.Get_Data("SELECT     ShiftDayDetails_tbl.DayStatus" +
                            " FROM         EmpSwipedataBank_tbl INNER JOIN " +
                            "   ShiftDayDetails_tbl ON EmpSwipedataBank_tbl.ShiftPk = ShiftDayDetails_tbl.ShiftPK " +
                            " WHERE     (EmpSwipedataBank_tbl.Swipedataid = '" + int.Parse(Convert.ToString(tbl_attendancedata.Rows[i].Cells[1].Value)) + "') and (DayOFWeekname='" + dtp_datevalue.Value.DayOfWeek + "')");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dayw = Convert.ToString(ds.Tables[0].Rows[0][0]);
                        }




                        if (dayw != "Working Day")
                        {
                            if (MarkOTaction("OUT", i, 12, "OT2.0"))
                            {
                                tbl_attendancedata.Rows[i].Cells[12].Value = "OT2.0";
                            }

                        }
                        else
                        {
                            if (MarkOTaction("OUT", i, 12, "OT1.5"))
                            {
                                tbl_attendancedata.Rows[i].Cells[12].Value = "OT1.5";

                            }

                        }
                    }
                }

            }
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rejectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void markLHRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (Convert.ToString(tbl_attendancedata.Rows[i].Cells[12].Value).Trim() == "UOT")
                    {

                        if (MarkOTaction("OUT", i, 12, "LHR"))
                        {
                            tbl_attendancedata.Rows[i].Cells[12].Value = "LHR";
                        }
                    }
                }
            }
        }














        public Boolean ifleaveavailable(int empid, String Code)
        {

            Boolean isavailable = false;



            int Leaveavailable = lvapadvncetrans.leaveleftofatype(empid, getleavePk(empid, Code));

            if (Leaveavailable > 0)
            {
                isavailable = true;
                ATCHRM.Controls.ATCHRMMessagebox.Show(Code + " Left  is  " + Leaveavailable);
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Leaves Left ");
            }

            return isavailable;
        }


        public int getleavePk(int empid, String Code)
        {
            int leavepk = 0;
            DataTable dt = lvapadvncetrans.getleavePkfromcode(Code, empid);
            if (dt.Rows.Count != 0)
            {
                leavepk = int.Parse(dt.Rows[0][0].ToString());
            }


            return leavepk;

        }


        //////////////////////////////////////////////////////////////////////////////////////Gate Passs /////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tbl_Gatepassdaata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        public void gatepassdatgridviewsetup()
        {
            tbl_Gatepassdaata.ColumnCount = 1;

            tbl_Gatepassdaata.Columns.Add("1", "Swipedataid");
            tbl_Gatepassdaata.Columns.Add("2", "SwipePK");
            tbl_Gatepassdaata.Columns.Add("3", "Empid ");
            tbl_Gatepassdaata.Columns.Add("4", "EmpNo#");
            tbl_Gatepassdaata.Columns.Add("5", "EmpName");
            tbl_Gatepassdaata.Columns.Add("6", "Designation");
            tbl_Gatepassdaata.Columns.Add("7", "Department");
            tbl_Gatepassdaata.Columns.Add("8", "Date");
            tbl_Gatepassdaata.Columns.Add("9", "In Time");
            tbl_Gatepassdaata.Columns.Add("10", "Out Time");
            tbl_Gatepassdaata.Columns.Add("11", "Instatus");
            tbl_Gatepassdaata.Columns.Add("12", "Out Stastus");
            tbl_Gatepassdaata.Columns.Add("13", "In value");
            tbl_Gatepassdaata.Columns.Add("14", "Out Value");
            tbl_Gatepassdaata.Columns.Add("15", "Action required");
            tbl_Gatepassdaata.Columns.Add("16", "Approved In Status");
            tbl_Gatepassdaata.Columns.Add("17", "Approved Out Status");
            tbl_Gatepassdaata.Columns.Add("18", "GatepassNum");
            tbl_Gatepassdaata.Columns.Add("19", "From Time");
            tbl_Gatepassdaata.Columns.Add("20", "TO Time");
            tbl_Gatepassdaata.RowTemplate.Height = 18;
            //    tbl_attendancedata.Columns[1].Visible = false;
            //   tbl_attendancedata.Columns[2].Visible = false;
            //   tbl_attendancedata.Columns[13].Visible = false;

        }



        public void gatepassactions()
        {

            DataTable dt = attndmngmnttrans.Getgatepassdata(dtp_datevalue.Value.Date, Program.LOCTNPK);

            gatepassfilldatagrid(dt);

        }

        public void gatepassfilldatagrid(DataTable actiondata)
        {
            gatepassdatgridviewsetup();


            tbl_Gatepassdaata.RowCount = 1;

            for (int i = 0; i < actiondata.Rows.Count; i++)
            {


                tbl_Gatepassdaata.Rows.Add();
                tbl_Gatepassdaata.Rows[i].Cells[1].Value = actiondata.Rows[i][0].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[2].Value = actiondata.Rows[i][1].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[3].Value = actiondata.Rows[i][2].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[4].Value = actiondata.Rows[i][3].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[5].Value = actiondata.Rows[i][4].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[6].Value = actiondata.Rows[i][5].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[7].Value = actiondata.Rows[i][6].ToString();

                tbl_Gatepassdaata.Rows[i].Cells[8].Value = actiondata.Rows[i][7].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[9].Value = actiondata.Rows[i][8].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[10].Value = actiondata.Rows[i][9].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[11].Value = actiondata.Rows[i][10].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[12].Value = actiondata.Rows[i][11].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[13].Value = actiondata.Rows[i][12].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[14].Value = actiondata.Rows[i][13].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[15].Value = actiondata.Rows[i][14].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[16].Value = actiondata.Rows[i][15].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[17].Value = actiondata.Rows[i][16].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[18].Value = actiondata.Rows[i][17].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[19].Value = actiondata.Rows[i][18].ToString();
                tbl_Gatepassdaata.Rows[i].Cells[20].Value = actiondata.Rows[i][19].ToString();


            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                menuStrip1.Enabled = true;
                getdatFromDatabase();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                gatepassactions();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                Leavedataaction();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                getSwipesOnLeave();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                getwrongswipes();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage6)
            {
                Getemployyepresentonleave();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage7)
            {
                getOffOTofaDay();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage8)
            {
                getOtData();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage9)
            {
                getUOTData();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage10)
            {
                GetAbscentiesData();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage11)
            {
                gettpresentemployeedata();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage12)
            {
                getAbscentonOnesidedata();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage13)
            {
                getLHData();
                menuStrip1.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage14)
            {
                getExtrastatusData();
                menuStrip1.Enabled = false;
            }
        }





        #region leave Data
        /////////////////////////////////////////////////Leave //////////////////////////////////////////////////////////////////////////



        public void LeavedetailsGridviewsetup()
        {
            tbl_leavedata.ColumnCount = 1;

            tbl_leavedata.Columns.Add("1", "Swipedataid");
            tbl_leavedata.Columns.Add("2", "SwipePK");
            tbl_leavedata.Columns.Add("3", "Empid ");
            tbl_leavedata.Columns.Add("4", "EmpNo#");
            tbl_leavedata.Columns.Add("5", "EmpName");
            tbl_leavedata.Columns.Add("6", "Designation");
            tbl_leavedata.Columns.Add("7", "Department");
            tbl_leavedata.Columns.Add("8", "Date");
            tbl_leavedata.Columns.Add("9", "In Time");
            tbl_leavedata.Columns.Add("10", "Out Time");
            tbl_leavedata.Columns.Add("11", "Instatus");
            tbl_leavedata.Columns.Add("12", "Out Stastus");
            tbl_leavedata.Columns.Add("13", "In value");
            tbl_leavedata.Columns.Add("14", "Out Value");
            tbl_leavedata.Columns.Add("15", "Action required");
            tbl_leavedata.Columns.Add("16", "Approved In Status");
            tbl_leavedata.Columns.Add("17", "Approved Out Status");
            //  tbl_leavedata.Columns.Add("18", "GatepassNum");
            // tbl_leavedata.Columns.Add("19", "From Time");
            //  tbl_leavedata.Columns.Add("20", "TO Time");
            //tbl_leavedata.RowTemplate.Height = 18;
            //    tbl_attendancedata.Columns[1].Visible = false;
            //   tbl_attendancedata.Columns[2].Visible = false;
            //   tbl_attendancedata.Columns[13].Visible = false;
            tbl_leavedata.RowTemplate.Height = 18;
        }

        public void Leavedatafilldatagrid(DataTable actiondata)
        {
            LeavedetailsGridviewsetup();



            tbl_leavedata.RowCount = 1;

            for (int i = 0; i < actiondata.Rows.Count; i++)
            {


                tbl_leavedata.Rows.Add();
                tbl_leavedata.Rows[i].Cells[1].Value = actiondata.Rows[i][0].ToString();
                tbl_leavedata.Rows[i].Cells[2].Value = actiondata.Rows[i][1].ToString();
                tbl_leavedata.Rows[i].Cells[3].Value = actiondata.Rows[i][2].ToString();
                tbl_leavedata.Rows[i].Cells[4].Value = actiondata.Rows[i][3].ToString();
                tbl_leavedata.Rows[i].Cells[5].Value = actiondata.Rows[i][4].ToString();
                tbl_leavedata.Rows[i].Cells[6].Value = actiondata.Rows[i][5].ToString();
                tbl_leavedata.Rows[i].Cells[7].Value = actiondata.Rows[i][6].ToString();

                tbl_leavedata.Rows[i].Cells[8].Value = actiondata.Rows[i][7].ToString();
                tbl_leavedata.Rows[i].Cells[9].Value = actiondata.Rows[i][8].ToString();
                tbl_leavedata.Rows[i].Cells[10].Value = actiondata.Rows[i][9].ToString();
                tbl_leavedata.Rows[i].Cells[11].Value = actiondata.Rows[i][10].ToString();
                tbl_leavedata.Rows[i].Cells[12].Value = actiondata.Rows[i][11].ToString();
                tbl_leavedata.Rows[i].Cells[13].Value = actiondata.Rows[i][12].ToString();
                tbl_leavedata.Rows[i].Cells[14].Value = actiondata.Rows[i][13].ToString();
                tbl_leavedata.Rows[i].Cells[15].Value = actiondata.Rows[i][14].ToString();
                tbl_leavedata.Rows[i].Cells[16].Value = actiondata.Rows[i][15].ToString();
                //       tbl_leavedata.Rows[i].Cells[17].Value = actiondata.Rows[i][16].ToString();
                //  tbl_leavedata.Rows[i].Cells[18].Value = actiondata.Rows[i][17].ToString();
                // tbl_leavedata.Rows[i].Cells[19].Value = actiondata.Rows[i][18].ToString();
                //  tbl_leavedata.Rows[i].Cells[20].Value = actiondata.Rows[i][19].ToString();


            }
        }



        public void Leavedataaction()
        {
            DataTable dt = attndmngmnttrans.GetALLLeaveData(dtp_datevalue.Value.Date, Program.LOCTNPK);

            Leavedatafilldatagrid(dt);

        }


        # endregion



        private void btn_go_Click(object sender, EventArgs e)
        {
            if (hlpr.isdateaccesible(Program.Datetoday, dtp_datevalue.Value.Date))
            {
                tabControl1.SelectedTab = tabPage1;
                menuStrip1.Enabled = true;
                getdatFromDatabase();
            }
            else
            {
                //   ATCHRM.Controls.ATCHRMMessagebox.Show("You Cannot Select This Date");
                //     dtp_datevalue.Value = Program.Datetoday;


                //    menuStrip1.Enabled = false;
                tabControl1.SelectedTab = tabPage1;
                getdatFromDatabase();
            }
        }

        private void hSLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("HSL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchOldid();
        }



        # region Search Functions

        public void searchOldid()
        {
            String searchValue = txt_oldempid.Text;
            int rowIndex = -1;
            foreach (DataGridViewRow row in tbl_attendancedata.Rows)
            {
                if (row.Index != tbl_attendancedata.RowCount - 1)
                {
                    if (row.Cells[18].Value.ToString().Equals(searchValue))
                    {

                        rowIndex = row.Index;
                        tbl_attendancedata.FirstDisplayedScrollingRowIndex = rowIndex;
                        tbl_attendancedata.Rows[rowIndex].Selected = true;
                    }
                }
            }

        }

        public void SearchNewEmployeeID()
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                searchGridview(tbl_attendancedata, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                searchGridview(tbl_Gatepassdaata, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                searchGridview(tbl_leavedata, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                searchGridview(tbl_swipeonleave, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                searchGridview(tbl_wrongswipedata, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage7)
            {
                searchGridview(tbl_offOt, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage8)
            {
                searchGridview(tbl_otdata, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage9)
            {
                searchGridview(tbl_UOTData, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage10)
            {
                searchGridview(tbl_abscent, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage11)
            {
                searchGridview(tbl_presenties, 3, txt_empid.Text.Trim());
            }

            else if (tabControl1.SelectedTab == tabPage12)
            {
                searchGridview(tbl_abscentononeside, 3, txt_empid.Text.Trim());
            }
            else if (tabControl1.SelectedTab == tabPage14)
            {
                searchGridview(tbl_extrastatus, 3, txt_empid.Text.Trim());
            }



            searchGridview(tbl_UOTData, 3, txt_empid.Text.Trim());
        }

        public void searchGridview(DataGridView datagrid, int searchrowindex, String searchvalue)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in datagrid.Rows)
            {
                if (row.Index != datagrid.RowCount - 1)
                {
                    if (row.Cells[searchrowindex].Value.ToString().Equals(searchvalue))
                    {

                        rowIndex = row.Index;
                        datagrid.FirstDisplayedScrollingRowIndex = rowIndex;
                        datagrid.Rows[rowIndex].Selected = true;
                    }
                }
            }
        }


        # endregion



        private void foreNoonSHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("SHD");
        }

        private void afterNoonSHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("SHD");
        }

        private void fNHPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("HPL");

        }

        private void aFTERNOONHPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkleaveAction("HPL");
        }


        /// <summary>
        /// remove UOT of Non OT Employee and adjust the Swipe OutTime Also
        /// </summary>

        public void cropUOT()
        {
            int actiondoneresult = 0;


            if (!ajstrtrans.isActionForTheDateDone(dtp_datevalue.Value.Date, int.Parse(cmb_location.SelectedValue.ToString())))
            {
                DataTable nonotemployeedata = actntrans.GetNonOTEmployees(Program.LOCTNPK);

                if (nonotemployeedata != null)
                {
                    if (nonotemployeedata.Rows.Count != 0)
                    {
                        for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
                        {
                            if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                            {

                                DataRow[] result = nonotemployeedata.Select("empid=" + tbl_attendancedata.Rows[i].Cells[3].Value.ToString());

                                foreach (DataRow row in result)
                                {
                                    DateTime actiondate = DateTime.Parse(tbl_attendancedata.Rows[i].Cells[8].Value.ToString());
                                    String Dayofweek = actiondate.DayOfWeek.ToString();
                                    int empid = int.Parse(tbl_attendancedata.Rows[i].Cells[3].Value.ToString());
                                    int swipepk = int.Parse(tbl_attendancedata.Rows[i].Cells[1].Value.ToString());
                                    DataTable empshiftdata = ovrshfttrans.getShiftInOutTimeOfEmployee(empid, Dayofweek);

                                    if (empshiftdata != null)
                                    {

                                        if (empshiftdata.Rows.Count > 0)
                                        {
                                            actiondoneresult++;
                                            String timestr = empshiftdata.Rows[0][0].ToString();
                                            DateTime shifttime = actiondate.Add(TimeSpan.Parse(timestr));


                                            DateTime totime = shifttime.AddMinutes(20);



                                            DateTime swipeouttime = randomtimecreator(shifttime, totime);



                                            actntrans.MarkEmployeePresentInAfterNoon(empid, swipepk, actiondate, swipeouttime);
                                            //   TimeSpan  shiftoutime = new TimeSpan (empshiftdata.Rows[i][0].ToString());
                                            //    MarkEmployeePresentInAfterNoon

                                        }
                                    }


                                }



                            }
                        }
                    }


                }
                if (actiondoneresult == 0)
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("NO UnAuthorised UOT");

                }
                else
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Data Updated for  " + actiondoneresult + " Employees ");
                    getdatFromDatabase();
                }

            }


        }


        /// <summary>
        /// crop the UOT of Non Swiped Employee Without Changing outtime
        /// </summary>
        public void cropUOTWithoutTimeChange()
        {

            int actiondoneresult = 0;


            if (!ajstrtrans.isActionForTheDateDone(dtp_datevalue.Value.Date, int.Parse(cmb_location.SelectedValue.ToString())))
            {
                DataTable nonotemployeedata = actntrans.GetNonOTEmployees(Program.LOCTNPK);

                if (nonotemployeedata != null)
                {
                    if (nonotemployeedata.Rows.Count != 0)
                    {
                        for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
                        {
                            if (tbl_attendancedata.Rows[i].Cells[12].Value.ToString().Trim() == "UOT")
                            {

                                DataRow[] result = nonotemployeedata.Select("empid=" + tbl_attendancedata.Rows[i].Cells[3].Value.ToString());

                                foreach (DataRow row in result)
                                {
                                    DateTime actiondate = DateTime.Parse(tbl_attendancedata.Rows[i].Cells[8].Value.ToString());
                                    String Dayofweek = actiondate.DayOfWeek.ToString();
                                    int empid = int.Parse(tbl_attendancedata.Rows[i].Cells[3].Value.ToString());
                                    int swipepk = int.Parse(tbl_attendancedata.Rows[i].Cells[1].Value.ToString());
                                    DataTable empshiftdata = ovrshfttrans.getShiftInOutTimeOfEmployee(empid, Dayofweek);

                                    if (empshiftdata != null)
                                    {

                                        if (empshiftdata.Rows.Count > 0)
                                        {
                                            actiondoneresult++;




                                            actntrans.MarkEUOTEmployeePresentinAfternoon(empid, swipepk, actiondate);
                                            //   TimeSpan  shiftoutime = new TimeSpan (empshiftdata.Rows[i][0].ToString());
                                            //    MarkEmployeePresentInAfterNoon
                                            Actionlog.actiondone("Crop UOT Withouttime change", "of employeeID " + empid + " ondate " + actiondate + "", empid);

                                        }
                                    }


                                }



                            }
                        }
                    }


                }
                if (actiondoneresult == 0)
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("NO UnAuthorised UOT");

                }
                else
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Data Updated for  " + actiondoneresult + " Employees ");
                    getdatFromDatabase();
                }

            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cropUOT();
        }





        static readonly Random rnd = new Random();

        public DateTime randomtimecreator(DateTime fromtime, DateTime totime)
        {
            DateTime newswipeouttime = fromtime;

            var range = totime - fromtime;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            newswipeouttime = fromtime + randTimeSpan;

            return newswipeouttime;
        }


        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {

            int p = int.Parse(markOtherHalfLeave().ToString());
            if (p == 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("NO Data Corrected");
            }
            else
            {
                String done = p + "   Rows Updated";
                MessageBoxDemo.frmShowMessage.Show(done, "Action Completed", MessageBoxDemo.enumMessageIcon.Done, MessageBoxDemo.enumMessageButton.OKCancel);
                getdatFromDatabase();
            }

        }



        public void sendDataForUpdation(int i)
        {

            DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString());
            DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString());
            attndmngmnttrans.ResestSwipeData(int.Parse(tbl_wrongswipedata.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_wrongswipedata.Rows[i].Cells[3].Value.ToString()),
                intime, outime, tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString(), tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString());


        }



        public void sendDataForUpdationwithvalue(int i)
        {
            DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString());
            DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString());
            int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[13].Value.ToString());
            int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[14].Value.ToString());

            attndmngmnttrans.ResetSwipedataAndValue(int.Parse(tbl_wrongswipedata.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_wrongswipedata.Rows[i].Cells[3].Value.ToString()),
              intime, outime, tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString(), tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString(), invalue, outvalue);


        }





        public void synchroniseInandOuttime(int i)
        {
            if (DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString()) >= DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString()))
            {
                tbl_wrongswipedata.Rows[i].Cells[10].Value = tbl_wrongswipedata.Rows[i].Cells[9].Value;
                sendDataForUpdation(i);
            }
            else
            {
                tbl_wrongswipedata.Rows[i].Cells[9].Value = tbl_wrongswipedata.Rows[i].Cells[10].Value;
                sendDataForUpdation(i);
            }
        }


        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {


            correctingOTEntries();
            makedurationOK();
            getdatFromDatabase();
        }










        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            clearLHissues();

            getdatFromDatabase();






        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            CleraPresentSipes();
            getdatFromDatabase();
        }

        private void tbl_wrongswipedata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_wrongswipedata.IsCurrentCellDirty)
            {
                tbl_wrongswipedata.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            String[] halfday = { "HPL", "HSL", "SHD", "SHP" };
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells[0].Value) == true)
                {
                    DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString());
                    int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[13].Value.ToString());
                    int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[14].Value.ToString());
                    String instatus = tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString().Trim();
                    String outstatus = tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString().Trim();
                    double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells[25].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[23].Value.ToString());
                    DateTime shiftoutime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[24].Value.ToString());

                    if (instatus == "P" && outstatus == "LH")
                    {

                    }
                    else if (instatus == "LH" && outstatus == "A")
                    {
                        if (tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString().Trim() == "01/01/2000" || tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString().Trim() == "01/01/2000 00:00:00")
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            double fullday = Math.Truncate(halfdaytime - invalue);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;
                        }
                        else
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            double fullday = Math.Truncate(halfdaytime - invalue);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;
                        }
                    }
                    else if (instatus == "P" && outstatus == "A")
                    {
                        if (tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString().Trim() == "01/01/2000" || tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString().Trim() == "01/01/2000 00:00:00")
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;
                        }
                        else
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;
                        }

                    }
                    else if (instatus == "LH" && outstatus == "P")
                    {
                        // ASSUMING MAXIMUM LH IS 370
                        if (invalue < 270)
                        {
                            double fullday = Math.Truncate(sahiftduration - invalue);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;
                        }

                    }
                    else if (halfday.Contains(instatus) && outstatus == "A")
                    {
                        tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime;


                        sendDataForUpdation(i);
                        tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;

                    }
                    else if (instatus == "A" && halfday.Contains(outstatus))
                    {
                        tbl_wrongswipedata.Rows[i].Cells["Intime"].Value = outime;
                        sendDataForUpdation(i);
                        tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;

                    }

                }

            }

        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            AddSwipeForOFFOT();
        }

        private void tbl_otdata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_otdata.IsCurrentCellDirty)
            {
                tbl_otdata.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void ExtendOT_Click(object sender, EventArgs e)
        {
            AddTimetoOT();

        }

        private void reduceOt_Click(object sender, EventArgs e)
        {
            ReduceOT();

        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            // this is useed to  adjust the Outime asper the Outvalu

            matchEmployeeSwipeWithOutValue();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            markZeroValuedOTtoP();

        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            MarkOTtoUOT();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            SynchroniseInstatusandApprovedInstatus();
        }

        private void tbl_UOTData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_UOTData.IsCurrentCellDirty)
            {
                tbl_UOTData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        public void nonSwipedOT()
        {
            string dayw = "";
            //DataSet ds = GridViewmModels.ClsDatabase.Get_Data("select daystatus from ShiftDayDetails_tbl where "
            //+" DayOFWeekname='" + dtp_datevalue.Value.DayOfWeek + "'");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    dayw =Convert.ToString(ds.Tables[0].Rows[0][0]);
            //}

            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells[0].Value) == true)
                {
                    if (Convert.ToString(tbl_attendancedata.Rows[i].Cells[12].Value).Trim() == "A" && (Convert.ToString(tbl_attendancedata.Rows[i].Cells[11].Value).Trim() == "P" || Convert.ToString(tbl_attendancedata.Rows[i].Cells[11].Value).Trim() == "LH"))
                    {
                        DataSet ds = GridViewmModels.ClsDatabase.Get_Data("SELECT     ShiftDayDetails_tbl.DayStatus" +
                            " FROM         EmpSwipedataBank_tbl INNER JOIN " +
                            "   ShiftDayDetails_tbl ON EmpSwipedataBank_tbl.ShiftPk = ShiftDayDetails_tbl.ShiftPK " +
                            " WHERE     (EmpSwipedataBank_tbl.Swipedataid = '" + int.Parse(Convert.ToString(tbl_attendancedata.Rows[i].Cells[1].Value)) + "') and (DayOFWeekname='" + dtp_datevalue.Value.DayOfWeek + "')");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dayw = Convert.ToString(ds.Tables[0].Rows[0][0]);
                        }




                        if (dayw != "Working Day")
                        {
                            ATCHRM.Controls.ATCHRMMessagebox.Show("Not Working Day for this Employee");

                        }
                        else
                        {
                            if (MarkOTaction("OUT", i, 12, "OT1.5"))
                            {
                                tbl_attendancedata.Rows[i].Cells[12].Value = "OT1.5";

                            }

                        }
                    }
                }

            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            nonSwipedOT();
        }

        private void cropUOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cropUOT();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchNewEmployeeID();

        }



        private void removeOffOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkOFFOTtoAbscent();
        }



        #region OTactions


        /// <summary>
        /// get All the OT Entries Of a day
        /// </summary>

        public void getOtData()
        {
            DataTable otdatatable = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    otdatatable = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {
                        String outstatus = dr.ItemArray[16].ToString().Trim();


                        if (outstatus == "OT1.5" || outstatus == "OT")
                        {

                            otdatatable.Rows.Add(dr.ItemArray);

                        }



                    }


                }
            }
            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Shiftintime", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            otdatatable.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("Shiftoutime", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            otdatatable.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("Shiftduration", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            otdatatable.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Shiftname", typeof(System.String));
            Shiftname.DefaultValue = "0";
            otdatatable.Columns.Add(Shiftname);


            tbl_otdata.DataSource = otdatatable;

            fillShiftdataforOT();

            if (tbl_otdata.Rows.Count > 1)
            {
                tbl_otdata.Columns[1].Visible = false;
                tbl_otdata.Columns[2].Visible = false;
                tbl_otdata.Columns[22].Visible = false;
                tbl_otdata.Columns[18].Visible = false;
                tbl_otdata.Columns[15].Visible = false;
                tbl_otdata.Columns[11].Visible = false;
                tbl_otdata.Columns[12].Visible = false;
            }
        }


        /// <summary>
        /// get the actual shift in and outtime of all employee who had OT
        /// </summary>
        public void fillShiftdataforOT()
        {
            for (int i = 0; i < tbl_otdata.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_otdata.Rows[i].Cells[22].Value.ToString()), DateTime.Parse(tbl_otdata.Rows[i].Cells[8].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_otdata.Rows[i].Cells[23].Value = shiftdata.Rows[0][0].ToString();
                        tbl_otdata.Rows[i].Cells[24].Value = shiftdata.Rows[0][1].ToString();
                        tbl_otdata.Rows[i].Cells[25].Value = shiftdata.Rows[0][2].ToString();
                        tbl_otdata.Rows[i].Cells[26].Value = shiftdata.Rows[0][3].ToString();


                    }
                }





            }
        }


        /// <summary>
        /// add the Outime and Outvalue if the Outstatus is ot
        /// </summary>
        public void AddTimetoOT()
        {
            Action.OtValueApproval dataform = new Action.OtValueApproval("OT");
            dataform.ShowDialog();
            int OtValue = 0;
            try
            {
                OtValue = int.Parse(dataform.Amount);
            }
            catch (Exception)
            {
                OtValue = 0;
            }
            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {


                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString());


                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());

                    outvalue = outvalue + OtValue;
                    //added the entered number to the existing oT value in putvalue
                    tbl_otdata.Rows[i].Cells[14].Value = outvalue;


                    // added the ot minutes to the intime 
                    outime = outime.AddMinutes(OtValue);

                    tbl_otdata.Rows[i].Cells[10].Value = outime;



                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, instatus, Outstatus, invalue, outvalue);

                    tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;
                }
            }
        }

        /// <summary>
        /// this function help in reducing the OT
        /// we have to enter the Quantty to be reduced
        /// </summary>
        public void ReduceOT()
        {
            Action.OtValueApproval dataform = new Action.OtValueApproval("OT");
            dataform.ShowDialog();
            int OtValue = 0;
            try
            {
                OtValue = int.Parse(dataform.Amount);
            }
            catch (Exception)
            {
                OtValue = 0;
            }
            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {


                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {
                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString());


                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());

                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());

                    outvalue = outvalue - OtValue;
                    //subtract the entered number to the existing oT value in putvalue
                    tbl_otdata.Rows[i].Cells[14].Value = outvalue;


                    // added the ot minutes to the intime 
                    outime = outime.AddMinutes(-OtValue);

                    tbl_otdata.Rows[i].Cells[10].Value = outime;



                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, instatus, Outstatus, invalue, outvalue);

                    //   tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;
                }
            }
        }

        /// <summary>
        /// Check if the outvalue of the selected Employee is Zero and if he have OT as outsatatus then mark it P
        /// </summary>
        public void markZeroValuedOTtoP()
        {
            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {
                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());

                    if (outvalue == 0 && Outstatus.Trim() == "OT1.5")
                    {

                        tbl_otdata.Rows[i].Cells[17].Value = "P";
                        attndmngmnttrans.ResetSwipedataAndValue(int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString()),
                    intime, outime, tbl_otdata.Rows[i].Cells[16].Value.ToString(), tbl_otdata.Rows[i].Cells[17].Value.ToString(), invalue, outvalue);
                        tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    }

                }
            }
        }

        /// <summary>
        /// somethimes the outvalue of OT may be different from the actual outvalue according to swipe out
        /// this function will help in sysnchronizing Outvale
        /// </summary>
        public void matchEmployeeSwipeWithOutValue()
        {
            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {
                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());
                    if (instatus == "P")
                    {

                        //if p just add the shift  duration to the intime 
                        // and we will get the actual shiftoutime out time
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);
                        double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells[25].Value.ToString());
                        TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);
                        outime = actualintime.Add(t1);
                        outime = outime.AddMinutes(outvalue);
                        outime = randomtimecreator(outime, outime.AddMinutes(10));

                    }
                    else
                    {
                        // if instatus is not  P create the actual shift outtime and then 
                        DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                        outime = actualoutime.AddMinutes(outvalue);
                        outime = randomtimecreator(outime, outime.AddMinutes(10));
                    }




                    tbl_otdata.Rows[i].Cells[10].Value = outime;




                    attndmngmnttrans.ResetSwipedataAndValue(int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString()),
                      intime, outime, tbl_otdata.Rows[i].Cells[16].Value.ToString(), tbl_otdata.Rows[i].Cells[17].Value.ToString(), invalue, outvalue);

                    tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Firebrick;
                }
            }
        }



        /// <summary>
        ///mark the ot person to UOT
        ///no approval required
        /// </summary>
        public void MarkOTtoUOT()
        {
            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {
                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());
                    if (outvalue != 0 && Outstatus.Trim() == "OT1.5")
                    {
                        tbl_otdata.Rows[i].Cells[17].Value = "UOT";
                        attndmngmnttrans.ResetSwipedataAndValue(int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString()),
                    intime, outime, tbl_otdata.Rows[i].Cells[16].Value.ToString(), tbl_otdata.Rows[i].Cells[17].Value.ToString(), invalue, outvalue);
                        tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Green;

                    }


                }
            }

        }

        /// <summary>
        /// remove the OT of a Employee if he is not authorised to DO OT
        /// </summary>
        public void removeOTofNonOTEmployee()
        {
            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString());
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells[23].Value.ToString());

                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());

                    if (actntrans.isOTApplicableForEmployee(empid) == false)
                    {
                        if (outvalue != 0 && Outstatus.Trim() == "OT1.5")
                        {
                            Outstatus = "P";

                            DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                            outime = randomtimecreator(actualoutime, actualoutime.AddMinutes(10));
                            outvalue = 0;
                            attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, instatus, Outstatus, invalue, outvalue);
                            tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Green;

                        }
                    }
                }
            }
        }

        /// <summary>
        /// HighLight All the Wrong OT ie the OT assigned to the Persons who are not authorised to Do OT
        /// </summary>
        public void HighlightOTofNonOTEmployee()
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[tbl_otdata.DataSource];

            currencyManager1.SuspendBinding();
            ArrayList rownum = new ArrayList();

            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {


                int empid = int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString());
                if (!actntrans.isOTApplicableForEmployee(empid))
                {
                    tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    tbl_otdata.Rows[i].Visible = true;
                }
                else
                {

                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells[23].Value.ToString());

                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());



                    DateTime expectedouttime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                    expectedouttime = expectedouttime.AddMinutes(outvalue);
                    TimeSpan durat = outime - expectedouttime;
                    double totalMinutes = durat.TotalMinutes;
                    if (Math.Abs(totalMinutes) > 45)
                    {
                        tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        tbl_otdata.Rows[i].Visible = true;
                    }else
                    {
                        tbl_otdata.Rows[i].Visible = false;
                    }
                }


            }

        }



        #endregion



        # region UOTActions






        /// <summary>
        /// get the actual shift in and outtime of all employee who had UOT
        /// </summary>
        public void fillShiftdataforUOT()
        {
            for (int i = 0; i < tbl_UOTData.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_UOTData.Rows[i].Cells[22].Value.ToString()), DateTime.Parse(tbl_UOTData.Rows[i].Cells[8].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_UOTData.Rows[i].Cells[23].Value = shiftdata.Rows[0][0].ToString();
                        tbl_UOTData.Rows[i].Cells[24].Value = shiftdata.Rows[0][1].ToString();
                        tbl_UOTData.Rows[i].Cells[25].Value = shiftdata.Rows[0][2].ToString();
                        tbl_UOTData.Rows[i].Cells[26].Value = shiftdata.Rows[0][3].ToString();


                    }
                }





            }
        }

        /// <summary>
        /// rejects the UOt of a person without action
        /// </summary>
        public void rejectUOTwithoutAction()
        {
            for (int i = 0; i < tbl_UOTData.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_UOTData.Rows[i].Cells[0].Value) == true)
                {
                    String Apprinstatus = tbl_UOTData.Rows[i].Cells[16].Value.ToString().Trim();
                    String ApprOutstatus = tbl_UOTData.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_UOTData.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_UOTData.Rows[i].Cells[13].Value.ToString());

                    outime = outime.AddMinutes(-outvalue);

                    ApprOutstatus = "P";
                    tbl_UOTData.Rows[i].Cells[10].Value = outime;
                    tbl_UOTData.Rows[i].Cells[17].Value = ApprOutstatus;
                    outvalue = 0;



                    attndmngmnttrans.ResetStatuses(int.Parse(tbl_UOTData.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_UOTData.Rows[i].Cells[3].Value.ToString()),
                 intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);
                    tbl_UOTData.Rows[i].DefaultCellStyle.BackColor = Color.LemonChiffon;

                }
            }
        }




        public void ReduceLHfromUOT()
        {
            for (int i = 0; i < tbl_UOTData.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_UOTData.Rows[i].Cells[0].Value) == true)
                {
                    String Apprinstatus = tbl_UOTData.Rows[i].Cells[16].Value.ToString().Trim();
                    String ApprOutstatus = tbl_UOTData.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_UOTData.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_UOTData.Rows[i].Cells[13].Value.ToString());
                    int swipedatid = int.Parse(tbl_UOTData.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_UOTData.Rows[i].Cells[3].Value.ToString());

                    if (Apprinstatus == "LH" && ApprOutstatus.Trim() == "UOT")
                    {   //if uot value greater than  LH value
                        if (outvalue >= invalue)
                        {
                            outvalue = outvalue - invalue;
                            if (outvalue == 0)
                            {
                                ApprOutstatus = "P";
                            }

                            DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                            outime = actualoutime.AddMinutes(outvalue);
                            invalue = 0;
                            Apprinstatus = "P";
                            DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);

                            attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                         intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);


                        }
                        //if LH value is greater than UOT
                        else
                        {
                            invalue = invalue - outvalue;

                            outvalue = 0;
                            if (outvalue == 0)
                            {
                                ApprOutstatus = "P";
                                DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                                outvalue = 0;
                                DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);
                                intime = actualintime.AddMinutes(invalue);

                                attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                        intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);


                            }

                        }
                    }

                }
            }
        }

        /// <summary>
        /// get All the UOT Entries Of a day
        /// </summary>
        public void getUOTData()
        {
            DataTable UOTData = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    UOTData = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {
                        String outstatus = dr.ItemArray[16].ToString().Trim();


                        if (outstatus == "UOT")
                        {

                            UOTData.Rows.Add(dr.ItemArray);

                        }



                    }


                }
            }
            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Shiftintime", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            UOTData.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("Shiftoutime", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            UOTData.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("Shiftduration", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            UOTData.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Shiftname", typeof(System.String));
            Shiftname.DefaultValue = "0";
            UOTData.Columns.Add(Shiftname);


            tbl_UOTData.DataSource = UOTData;

            fillShiftdataforUOT();

            if (tbl_UOTData.Rows.Count > 1)
            {
                tbl_UOTData.Columns[1].Visible = false;
                tbl_UOTData.Columns[2].Visible = false;
                tbl_UOTData.Columns[22].Visible = false;
                tbl_UOTData.Columns[18].Visible = false;
                tbl_UOTData.Columns[15].Visible = false;
                tbl_UOTData.Columns[11].Visible = false;
                tbl_UOTData.Columns[12].Visible = false;
            }
        }

        // <summary>
        // Make the instaus Equal to the Approved Instatus and Outstatus equal to the approved Outstatus
        /// </summary>
        public void SynchroniseInstatusandApprovedInstatus()
        {
            for (int i = 0; i < tbl_UOTData.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_UOTData.Rows[i].Cells[0].Value) == true)
                {
                    String Apprinstatus = tbl_UOTData.Rows[i].Cells[16].Value.ToString().Trim();
                    String ApprOutstatus = tbl_UOTData.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_UOTData.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_UOTData.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_UOTData.Rows[i].Cells[13].Value.ToString());
                    if (outvalue != 0 && ApprOutstatus.Trim() == "UOT")
                    {
                        tbl_UOTData.Rows[i].Cells[11].Value = Apprinstatus;
                        tbl_UOTData.Rows[i].Cells[12].Value = ApprOutstatus;

                        attndmngmnttrans.ResetStatuses(int.Parse(tbl_UOTData.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_UOTData.Rows[i].Cells[3].Value.ToString()),
                    intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);
                        tbl_UOTData.Rows[i].DefaultCellStyle.BackColor = Color.LemonChiffon;

                    }


                }
            }

        }







        # endregion

        # region offOT



        /// <summary>
        /// get the off OT of a Day 
        /// </summary>
        public void getOffOTofaDay()
        {
            DataTable offotdata = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    offotdata = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {

                        String outstatus = dr.ItemArray[16].ToString().Trim();

                        if (outstatus == "OT2.0")
                        {
                            offotdata.Rows.Add(dr.ItemArray);
                        }
                    }

                    tbl_offOt.DataSource = offotdata;
                }
            }


        }













        /// <summary>
        /// Add  swipe record for OF OT
        /// user will enter the Swipe in time and OTMinutesa
        /// </summary>
        public void AddSwipeForOFFOT()
        {
            Action.OFFOtvalueApproval otform = new Action.OFFOtvalueApproval(dtp_datevalue.Value);

            otform.ShowDialog();
            int offotvalue = 0;
            DateTime intime = DateTime.MinValue;


            try
            {
                offotvalue = int.Parse(otform.OutTime);
                intime = DateTime.Parse(otform.Intime.ToString());
            }
            catch (Exception)
            {

                offotvalue = 0;
            }


            for (int i = 0; i < tbl_offOt.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_offOt.Rows[i].Cells[0].Value) == true)
                {


                    DateTime outime = intime.AddMinutes(offotvalue);
                    DateTime correctedintime = randomtimecreator(intime, intime.AddMinutes(-20));
                    DateTime correctedoutime = randomtimecreator(outime, outime.AddMinutes(10));

                    tbl_offOt.Rows[i].Cells[9].Value = correctedintime;
                    tbl_offOt.Rows[i].Cells[10].Value = correctedoutime;
                    tbl_offOt.Rows[i].Cells[16].Value = "OT2.0";




                    intime = DateTime.Parse(tbl_offOt.Rows[i].Cells[9].Value.ToString());
                    outime = DateTime.Parse(tbl_offOt.Rows[i].Cells[10].Value.ToString());
                    int invalue = int.Parse(tbl_offOt.Rows[i].Cells[13].Value.ToString());
                    int outvalue = offotvalue;

                    attndmngmnttrans.ResetSwipedataAndValue(int.Parse(tbl_offOt.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_offOt.Rows[i].Cells[3].Value.ToString()),
                      intime, outime, tbl_offOt.Rows[i].Cells[16].Value.ToString(), tbl_offOt.Rows[i].Cells[17].Value.ToString(), invalue, outvalue);

                    tbl_offOt.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;

                }
            }
            getdatFromDatabase();
        }


        public void MarkOFFOTtoAbscent()
        {
            for (int i = 0; i < tbl_offOt.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_offOt.Rows[i].Cells[0].Value) == true)
                {
                    tbl_offOt.Rows[i].Cells[10].Value = tbl_offOt.Rows[i].Cells[9].Value = DateTime.Parse("2000-01-01 00:00:00.000");
                    int invalue = 0;
                    int outvalue = 0;
                    tbl_offOt.Rows[i].Cells[16].Value = "A";
                    tbl_offOt.Rows[i].Cells[17].Value = "A";
                    DateTime intime = DateTime.Parse(tbl_offOt.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_offOt.Rows[i].Cells[10].Value.ToString());

                    attndmngmnttrans.ResetSwipedataAndValue(int.Parse(tbl_offOt.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_offOt.Rows[i].Cells[3].Value.ToString()),
                                        intime, outime, tbl_offOt.Rows[i].Cells[16].Value.ToString(), tbl_offOt.Rows[i].Cells[17].Value.ToString(), invalue, outvalue);

                    tbl_offOt.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                }
            }


        }

        private void tbl_offOt_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_offOt.IsCurrentCellDirty)
            {
                tbl_offOt.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        #endregion




        #region Abscenties
        /// <summary>
        /// get the actual shift in and outtime of all employee who had UOT
        /// </summary>
        public void fillShiftdataforAbscenties()
        {
            for (int i = 0; i < tbl_abscent.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_abscent.Rows[i].Cells[22].Value.ToString()), DateTime.Parse(tbl_abscent.Rows[i].Cells[8].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_abscent.Rows[i].Cells[23].Value = shiftdata.Rows[0][0].ToString();
                        tbl_abscent.Rows[i].Cells[24].Value = shiftdata.Rows[0][1].ToString();
                        tbl_abscent.Rows[i].Cells[25].Value = shiftdata.Rows[0][2].ToString();
                        tbl_abscent.Rows[i].Cells[26].Value = shiftdata.Rows[0][3].ToString();


                    }
                }





            }
        }



        /// <summary>
        /// get All the UOT Entries Of a day
        /// </summary>
        public void GetAbscentiesData()
        {
            DataTable abscentidata = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    abscentidata = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {
                        String outstatus = dr.ItemArray[16].ToString().Trim();
                        String instatus = dr.ItemArray[15].ToString().Trim();

                        if (outstatus == "A" && instatus == "A")
                        {

                            abscentidata.Rows.Add(dr.ItemArray);

                        }



                    }


                }
            }
            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Shiftintime", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            abscentidata.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("Shiftoutime", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            abscentidata.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("Shiftduration", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            abscentidata.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Shiftname", typeof(System.String));
            Shiftname.DefaultValue = "0";
            abscentidata.Columns.Add(Shiftname);


            tbl_abscent.DataSource = abscentidata;

            fillShiftdataforAbscenties();

            if (tbl_abscent.Rows.Count > 1)
            {
                tbl_abscent.Columns[1].Visible = false;
                tbl_abscent.Columns[2].Visible = false;
                tbl_abscent.Columns[22].Visible = false;
                tbl_abscent.Columns[18].Visible = false;
                tbl_abscent.Columns[15].Visible = false;
                tbl_abscent.Columns[11].Visible = false;
                tbl_abscent.Columns[12].Visible = false;
            }
        }




        public void GetAbscentsynchrozized()
        {
            for (int i = 0; i < tbl_abscent.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_abscent.Rows[i].Cells[0].Value) == true)
                {
                    String instatus = tbl_abscent.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_abscent.Rows[i].Cells[17].Value.ToString().Trim();
                    if (instatus == "A" && Outstatus == "A")
                    {

                        if (DateTime.Parse(tbl_abscent.Rows[i].Cells[9].Value.ToString()) >= DateTime.Parse(tbl_abscent.Rows[i].Cells[10].Value.ToString()))
                        {
                            tbl_abscent.Rows[i].Cells[10].Value = tbl_abscent.Rows[i].Cells[9].Value;

                        }
                        else
                        {
                            tbl_abscent.Rows[i].Cells[9].Value = tbl_abscent.Rows[i].Cells[10].Value;

                        }



                        DateTime intime = DateTime.Parse(tbl_abscent.Rows[i].Cells[9].Value.ToString());
                        DateTime outime = DateTime.Parse(tbl_abscent.Rows[i].Cells[10].Value.ToString());
                        attndmngmnttrans.ResestSwipeData(int.Parse(tbl_abscent.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_abscent.Rows[i].Cells[3].Value.ToString()),
                            intime, outime, tbl_abscent.Rows[i].Cells[16].Value.ToString(), tbl_abscent.Rows[i].Cells[17].Value.ToString());


                    }
                }
            }
        }
        #endregion




        # region PresentMarkedRegion




        private void tbl_presenties_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_presenties.IsCurrentCellDirty)
            {
                tbl_presenties.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {

            SynchronisePresnetEmployeedata();


        }


        public void gettpresentemployeedata()
        {
            DataTable presentemployee = actntrans.GetAllpresentEmployee(int.Parse(cmb_location.SelectedValue.ToString()), dtp_datevalue.Value.Date);


            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Shiftintime", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            presentemployee.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("Shiftoutime", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            presentemployee.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("Shiftduration", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            presentemployee.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Shiftname", typeof(System.String));
            Shiftname.DefaultValue = "0";
            presentemployee.Columns.Add(Shiftname);


            tbl_presenties.DataSource = presentemployee;

            fillShiftdataforPresenties();

            if (tbl_presenties.Rows.Count > 1)
            {
                tbl_presenties.Columns[1].Visible = false;
                tbl_presenties.Columns[2].Visible = false;
                tbl_presenties.Columns[22].Visible = false;
                tbl_presenties.Columns[18].Visible = false;
                tbl_presenties.Columns[15].Visible = false;
                tbl_presenties.Columns[11].Visible = false;
                tbl_presenties.Columns[12].Visible = false;
            }
        }











        /// <summary>
        /// synchronise the presentdata
        /// </summary>
        public void SynchronisePresnetEmployeedata()
        {
            for (int i = 0; i < tbl_presenties.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_presenties.Rows[i].Cells[0].Value) == true)
                {
                    if (int.Parse(tbl_presenties.Rows[i].Cells[21].Value.ToString()) < 0)
                    {
                        String instatus = tbl_presenties.Rows[i].Cells[16].Value.ToString().Trim();
                        String Outstatus = tbl_presenties.Rows[i].Cells[17].Value.ToString().Trim();


                        if (instatus == "P" && Outstatus == "P")
                        {
                            DateTime intime = DateTime.Parse(tbl_presenties.Rows[i].Cells[9].Value.ToString());
                            double sahiftduration = double.Parse(tbl_presenties.Rows[i].Cells[25].Value.ToString());
                            TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);
                            tbl_presenties.Rows[i].Cells[10].Value = intime.Add(t1);


                            intime = DateTime.Parse(tbl_presenties.Rows[i].Cells[9].Value.ToString());
                            DateTime outime = DateTime.Parse(tbl_presenties.Rows[i].Cells[10].Value.ToString());
                            attndmngmnttrans.ResestSwipeData(int.Parse(tbl_presenties.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_presenties.Rows[i].Cells[3].Value.ToString()),
                                intime, outime, tbl_presenties.Rows[i].Cells[16].Value.ToString(), tbl_presenties.Rows[i].Cells[17].Value.ToString());
                        }


                    }

                }
            }
        }






        /// <summary>
        /// get the actual shift in and outtime of all employee who had UOT
        /// </summary>
        public void fillShiftdataforPresenties()
        {
            for (int i = 0; i < tbl_presenties.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_presenties.Rows[i].Cells[22].Value.ToString()), DateTime.Parse(tbl_presenties.Rows[i].Cells[8].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_presenties.Rows[i].Cells[23].Value = shiftdata.Rows[0][0].ToString();
                        tbl_presenties.Rows[i].Cells[24].Value = shiftdata.Rows[0][1].ToString();
                        tbl_presenties.Rows[i].Cells[25].Value = shiftdata.Rows[0][2].ToString();
                        tbl_presenties.Rows[i].Cells[26].Value = shiftdata.Rows[0][3].ToString();


                    }
                }





            }
        }














        #endregion






        # region Swipe On Leave

        /// <summary>
        /// mark the other half also as leave
        /// </summary>
        public int markOtherHalfLeave()
        {
            int correctedflag = 0;
            string[] Leavesarray = { "PL", "UPL", "SL", "ML", "FL" };
            for (int i = 0; i < tbl_swipeonleave.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_swipeonleave.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_swipeonleave.Rows[i].Cells[16].Value.ToString().Trim();
                    String outstatus = tbl_swipeonleave.Rows[i].Cells[17].Value.ToString().Trim();


                    if (outstatus == "PL" || outstatus == "UPL" || outstatus == "SL" || outstatus == "ML" || outstatus == "FL")
                    {

                        tbl_swipeonleave.Rows[i].Cells[9].Value = tbl_swipeonleave.Rows[i].Cells[10].Value;
                        tbl_swipeonleave.Rows[i].Cells[16].Value = outstatus;

                        DateTime intime = DateTime.Parse(tbl_swipeonleave.Rows[i].Cells[9].Value.ToString());
                        DateTime outime = DateTime.Parse(tbl_swipeonleave.Rows[i].Cells[10].Value.ToString());
                        attndmngmnttrans.ResestSwipeData(int.Parse(tbl_swipeonleave.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_swipeonleave.Rows[i].Cells[3].Value.ToString()),
                            intime, outime, tbl_swipeonleave.Rows[i].Cells[16].Value.ToString(), tbl_swipeonleave.Rows[i].Cells[17].Value.ToString());

                        correctedflag++;
                    }
                    else if (instatus == "PL" || instatus == "UPL" || instatus == "SL" || instatus == "ML" || instatus == "FL")
                    {
                        tbl_swipeonleave.Rows[i].Cells[10].Value = tbl_swipeonleave.Rows[i].Cells[9].Value;
                        tbl_swipeonleave.Rows[i].Cells[17].Value = instatus;
                        DateTime intime = DateTime.Parse(tbl_swipeonleave.Rows[i].Cells[9].Value.ToString());
                        DateTime outime = DateTime.Parse(tbl_swipeonleave.Rows[i].Cells[10].Value.ToString());
                        attndmngmnttrans.ResestSwipeData(int.Parse(tbl_swipeonleave.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_swipeonleave.Rows[i].Cells[3].Value.ToString()),
                            intime, outime, tbl_swipeonleave.Rows[i].Cells[16].Value.ToString(), tbl_swipeonleave.Rows[i].Cells[17].Value.ToString());
                        correctedflag++;
                    }
                }




            }

            return correctedflag;
        }

        private void tbl_swipeonleave_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_swipeonleave.IsCurrentCellDirty)
            {
                tbl_swipeonleave.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }





        /// <summary>
        /// getall Swipe of employee on a day where one part is Leave
        /// </summary>
        public void getSwipesOnLeave()
        {

            string[] Leavesarray = { "PL", "UPL", "SL", "ML", "PL" };

            DataTable swipeonleavetable = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    swipeonleavetable = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {

                        if (Leavesarray.Contains(dr.ItemArray[15].ToString().Trim()) || Leavesarray.Contains(dr.ItemArray[16].ToString().Trim()))
                        {


                            if (dr.ItemArray[15].ToString().Trim() != dr.ItemArray[16].ToString().Trim())
                            {
                                swipeonleavetable.Rows.Add(dr.ItemArray);

                            }

                        }


                    }


                    tbl_swipeonleave.DataSource = swipeonleavetable;
                }


            }


        }




        public void Getemployyepresentonleave()
        {
            DataTable dt = actntrans.Getswipeofemployeespresentonappliedleave(int.Parse(cmb_location.SelectedValue.ToString()), dtp_datevalue.Value.Date);
            tbl_swipeonleavedata.DataSource = dt;
        }



        # endregion





        # region WrongSwipeData


        /// <summary>
        /// correct the mistake entries with  OT
        /// </summary>
        public void correctingOTEntries()
        {
            int flag = 0;
            for (int i = 0; i < tbl_wrongswipedata.RowCount - 1; i++)
            {

                String instatus = tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString().Trim();
                String outstatus = tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString().Trim();

                DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString());
                DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString());
                if (outstatus == "OT" || outstatus == "OT1.5")
                {
                    int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[14].Value.ToString());
                    int shiftduration = int.Parse(tbl_wrongswipedata.Rows[i].Cells[25].Value.ToString());


                    if (instatus == "LH")
                    {
                        int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[13].Value.ToString());
                        TimeSpan t1 = new TimeSpan(0, int.Parse(invalue.ToString()), 0);

                        intime = intime.Subtract(t1);
                        int totaldone = outvalue + shiftduration;



                        TimeSpan t12 = new TimeSpan(0, int.Parse(totaldone.ToString()), 0);

                        tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t12);


                        sendDataForUpdation(i);
                        tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                        //   calculateduration(i);

                    }
                    else if (instatus == "A")
                    {

                    }
                    else if (instatus == "P" && (outstatus == "OT1.5" || outstatus == "OT"))
                    {
                        if (intime > outime)
                        {


                            int totaldone = outvalue + shiftduration;



                            TimeSpan t1 = new TimeSpan(0, int.Parse(totaldone.ToString()), 0);

                            tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);

                            sendDataForUpdation(i);
                            //  calculateduration(i);
                            tbl_wrongswipedata.Rows[i].DefaultCellStyle.BackColor = Color.Beige;

                            flag++;
                        }
                    }

                }


                //   correctNegativeenteries(i);
            }
            //  MessageBox.Show(flag.ToString());
        }

        /// <summary>
        /// make the duration Ok for the wrong swipes
        /// </summary>

        public void makedurationOK()
        {
            string[] halfdayleaves = { "SHD", "HPL" };
            String[] otandpresent = { "P", "OT", "OT1.5", "UOT" };

            for (int i = 0; i < tbl_wrongswipedata.RowCount - 1; i++)
            {



                String instatus = tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString().Trim();
                String Outstatus = tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString().Trim();
                if (instatus == "A" && Outstatus == "A")
                {
                    synchroniseInandOuttime(i);
                }

                if (instatus == "P" && Outstatus == "LH")
                {

                }









                if (tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString().Trim() == "01/01/2000" || tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString().Trim() == "01/01/2000 00:00:00")
                {
                    if (halfdayleaves.Contains(Outstatus))
                    {
                        tbl_wrongswipedata.Rows[i].Cells[9].Value = tbl_wrongswipedata.Rows[i].Cells[10].Value;

                        synchroniseInandOuttime(i);

                    }

                    else if (Outstatus == "LH")
                    {
                        double outvalue = double.Parse(tbl_wrongswipedata.Rows[i].Cells[14].Value.ToString());
                        DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString());

                        TimeSpan losttime = new TimeSpan(0, int.Parse(outvalue.ToString()), 0);
                        DateTime swipeout = outime.Add(losttime);
                        double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells[25].Value.ToString());
                        if (sahiftduration > 0)
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells[9].Value = outime.Subtract(t1);
                            sendDataForUpdation(i);
                        }

                    }
                    else if (Outstatus == "P")
                    {


                        double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells[25].Value.ToString());

                        if (sahiftduration > 0)
                        {
                            double outvalue = double.Parse(tbl_wrongswipedata.Rows[i].Cells[14].Value.ToString());
                            DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString());
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells[9].Value = outime.Subtract(t1);

                            sendDataForUpdation(i);


                        }




                    }

                }
            }
        }

        /// <summary>
        /// fil shiftdata of employee
        /// </summary>
        public void fillshiftdata()
        {
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_wrongswipedata.Rows[i].Cells[22].Value.ToString()), DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[8].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_wrongswipedata.Rows[i].Cells[23].Value = shiftdata.Rows[0][0].ToString();
                        tbl_wrongswipedata.Rows[i].Cells[24].Value = shiftdata.Rows[0][1].ToString();
                        tbl_wrongswipedata.Rows[i].Cells[25].Value = shiftdata.Rows[0][2].ToString();
                        tbl_wrongswipedata.Rows[i].Cells[26].Value = shiftdata.Rows[0][3].ToString();


                    }
                }





            }

        }




        /// <summary>
        /// clear issue where in value is P and Out is LH
        /// </summary>
        public void clearLHissues()
        {
            Action.OtValueApproval dataform = new Action.OtValueApproval("LH");
            dataform.ShowDialog();
            int lhvalue = 0;
            try
            {
                lhvalue = int.Parse(dataform.Amount);
            }
            catch (Exception)
            {
                lhvalue = 0;
            }
            for (int i = 0; i < tbl_wrongswipedata.RowCount - 1; i++)
            {
                String instatus = tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString().Trim();
                String Outstatus = tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString().Trim();

                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells[0].Value) == true)
                {
                    if (Outstatus == "LH")
                    {
                        if (instatus == "P")
                        {
                            double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells[25].Value.ToString());

                            if (sahiftduration > 0)
                            {
                                tbl_wrongswipedata.Rows[i].Cells[14].Value = lhvalue;
                                DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString());
                                double fullday = Math.Truncate(sahiftduration - lhvalue);
                                TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                                tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);
                                sendDataForUpdationwithvalue(i);

                            }

                        }
                    }
                }
            }


        }




        /// <summary>
        /// clear the duration and swipe records if both are P
        /// </summary>
        public void CleraPresentSipes()
        {
            for (int i = 0; i < tbl_wrongswipedata.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString().Trim();


                    if (instatus == "P" && Outstatus == "P")
                    {
                        DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString());
                        double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells[25].Value.ToString());
                        TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);
                        tbl_wrongswipedata.Rows[i].Cells[10].Value = intime.Add(t1);
                        sendDataForUpdation(i);
                    }


                }
            }
        }






        /// <summary>
        /// get all the negative entries
        /// </summary>
        public void getwrongswipes()
        {

            DataTable wrongswipedatatable = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    wrongswipedatatable = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {
                        DateTime intime = DateTime.Parse(dr.ItemArray[8].ToString());
                        DateTime outime = DateTime.Parse(dr.ItemArray[9].ToString());

                        if (intime > outime)
                        {

                            wrongswipedatatable.Rows.Add(dr.ItemArray);

                        }



                    }

                }
            }

            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Shiftintime", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            wrongswipedatatable.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("Shiftoutime", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            wrongswipedatatable.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("Shiftduration", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            wrongswipedatatable.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Shiftname", typeof(System.String));
            Shiftname.DefaultValue = "0";
            wrongswipedatatable.Columns.Add(Shiftname);


            tbl_wrongswipedata.DataSource = wrongswipedatatable;

            fillshiftdata();



            if (tbl_wrongswipedata.Rows.Count > 1)
            {
                tbl_wrongswipedata.Columns[1].Visible = false;
                tbl_wrongswipedata.Columns[2].Visible = false;
                tbl_wrongswipedata.Columns[22].Visible = false;
                tbl_wrongswipedata.Columns[18].Visible = false;
                tbl_wrongswipedata.Columns[15].Visible = false;
                tbl_wrongswipedata.Columns[11].Visible = false;
                tbl_wrongswipedata.Columns[12].Visible = false;
            }

        }






        # endregion






        # region AbscentonOneside

        /// <summary>
        /// get All the UOT Entries Of a day
        /// </summary>
        public void getAbscentonOnesidedata()
        {
            DataTable onesideabscentdata = new DataTable();
            String[] otandpresent = { "P", "OT", "OT1.5", "UOT" };
            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    onesideabscentdata = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {
                        String outstatus = dr.ItemArray[16].ToString().Trim();
                        String instatus = dr.ItemArray[15].ToString().Trim();

                        if ((instatus == "A" && otandpresent.Contains(outstatus)) || (outstatus == "A" && otandpresent.Contains(instatus)))
                        {

                            onesideabscentdata.Rows.Add(dr.ItemArray);

                        }



                    }


                }
            }
            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Shiftintime", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            onesideabscentdata.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("Shiftoutime", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            onesideabscentdata.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("Shiftduration", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            onesideabscentdata.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Shiftname", typeof(System.String));
            Shiftname.DefaultValue = "0";
            onesideabscentdata.Columns.Add(Shiftname);


            tbl_abscentononeside.DataSource = onesideabscentdata;

            fillshiftdataforonesideAbscenties();

            if (tbl_abscentononeside.Rows.Count > 1)
            {
                tbl_abscentononeside.Columns[1].Visible = false;
                tbl_abscentononeside.Columns[2].Visible = false;
                tbl_abscentononeside.Columns[22].Visible = false;
                tbl_abscentononeside.Columns[18].Visible = false;
                tbl_abscentononeside.Columns[15].Visible = false;
                tbl_abscentononeside.Columns[11].Visible = false;
                tbl_abscentononeside.Columns[12].Visible = false;
            }
        }

        public void fillshiftdataforonesideAbscenties()
        {
            for (int i = 0; i < tbl_abscentononeside.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_abscentononeside.Rows[i].Cells[22].Value.ToString()), DateTime.Parse(tbl_abscentononeside.Rows[i].Cells[8].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_abscentononeside.Rows[i].Cells[23].Value = shiftdata.Rows[0][0].ToString();
                        tbl_abscentononeside.Rows[i].Cells[24].Value = shiftdata.Rows[0][1].ToString();
                        tbl_abscentononeside.Rows[i].Cells[25].Value = shiftdata.Rows[0][2].ToString();
                        tbl_abscentononeside.Rows[i].Cells[26].Value = shiftdata.Rows[0][3].ToString();


                    }
                }





            }
        }

        /// <summary>
        /// mark the swipe of the  half day abscent
        /// </summary>
        public void cleartheSwipetimeHalftimeAbscent()
        {
            for (int i = 0; i < tbl_abscentononeside.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_abscentononeside.Rows[i].Cells[0].Value) == true)
                {
                    String Apprinstatus = tbl_abscentononeside.Rows[i].Cells[16].Value.ToString().Trim();
                    String ApprOutstatus = tbl_abscentononeside.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_abscentononeside.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_abscentononeside.Rows[i].Cells[13].Value.ToString());
                    double sahiftduration = double.Parse(tbl_abscentononeside.Rows[i].Cells[25].Value.ToString());
                    String[] otandpresent = { "P", "OT", "OT1.5", "UOT" };

                    if (Apprinstatus != ApprOutstatus)
                    {

                        if (Apprinstatus == "A")
                        {
                            if (otandpresent.Contains(ApprOutstatus))
                            {
                                //if outstatus is P and instatus is A
                                if (ApprOutstatus == "P")
                                {




                                    if (sahiftduration > 0)
                                    {


                                        double halfdaytime = Math.Truncate(sahiftduration / 2);
                                        TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                        intime = outime.Subtract(t1);

                                        attndmngmnttrans.ResetStatuses(int.Parse(tbl_abscentononeside.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_abscentononeside.Rows[i].Cells[3].Value.ToString()),
              intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);


                                    }
                                }
                                //if its OT
                                else
                                {


                                    if (sahiftduration > 0)
                                    {
                                        TimeSpan t2 = new TimeSpan(0, int.Parse(outvalue.ToString()), 0);
                                        DateTime swipeout = outime.Subtract(t2);
                                        double halfdaytime = Math.Truncate(sahiftduration / 2);
                                        TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                        intime = swipeout.Subtract(t1);

                                        attndmngmnttrans.ResetStatuses(int.Parse(tbl_abscentononeside.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_abscentononeside.Rows[i].Cells[3].Value.ToString()),
              intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);

                                    }
                                }
                            }
                        }
                        else if (ApprOutstatus == "A")

                            if (Apprinstatus == "P")
                            {

                                if (sahiftduration > 0)
                                {

                                    double halfdaytime = Math.Truncate(sahiftduration / 2);
                                    TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                    outime = intime.Add(t1);
                                    attndmngmnttrans.ResetStatuses(int.Parse(tbl_abscentononeside.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_abscentononeside.Rows[i].Cells[3].Value.ToString()),
              intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);
                                }

                            }
                        if (Apprinstatus == "LH")
                        {

                            if (sahiftduration > 0)
                            {
                                double halfdaytime = Math.Truncate(sahiftduration / 2);
                                TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                outime = intime.Add(t1);
                                attndmngmnttrans.ResetStatuses(int.Parse(tbl_abscentononeside.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_abscentononeside.Rows[i].Cells[3].Value.ToString()),
          intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);

                            }

                        }











                    }















                }






            }
        }


        #endregion








        # region LH Action

        private void tbl_lhdata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_lhdata.IsCurrentCellDirty)
            {
                tbl_lhdata.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        public void getLHData()
        {
            DataTable LHdatatable = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    LHdatatable = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {
                        String outstatus = dr.ItemArray[16].ToString().Trim();
                        String instatus = dr.ItemArray[15].ToString().Trim();


                        if (outstatus == "LH" || instatus == "LH")
                        {

                            LHdatatable.Rows.Add(dr.ItemArray);

                        }



                    }


                }
            }
            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Shiftintime", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            LHdatatable.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("Shiftoutime", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            LHdatatable.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("Shiftduration", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            LHdatatable.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Shiftname", typeof(System.String));
            Shiftname.DefaultValue = "0";
            LHdatatable.Columns.Add(Shiftname);


            tbl_lhdata.DataSource = LHdatatable;

            fillShiftdataforLH();

            if (tbl_otdata.Rows.Count > 1)
            {
                tbl_lhdata.Columns[1].Visible = false;
                tbl_lhdata.Columns[2].Visible = false;
                tbl_lhdata.Columns[22].Visible = false;
                tbl_lhdata.Columns[18].Visible = false;
                tbl_lhdata.Columns[15].Visible = false;
                tbl_lhdata.Columns[11].Visible = false;
                tbl_lhdata.Columns[12].Visible = false;
            }
        }


        /// <summary>
        /// get the actual shift in and outtime of all employee who had OT
        /// </summary>
        public void fillShiftdataforLH()
        {
            for (int i = 0; i < tbl_lhdata.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_lhdata.Rows[i].Cells[22].Value.ToString()), DateTime.Parse(tbl_lhdata.Rows[i].Cells[8].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_lhdata.Rows[i].Cells[23].Value = shiftdata.Rows[0][0].ToString();
                        tbl_lhdata.Rows[i].Cells[24].Value = shiftdata.Rows[0][1].ToString();
                        tbl_lhdata.Rows[i].Cells[25].Value = shiftdata.Rows[0][2].ToString();
                        tbl_lhdata.Rows[i].Cells[26].Value = shiftdata.Rows[0][3].ToString();


                    }
                }
            }
        }





        public void LHofEmployeeClear()
        {
            Action.OtValueApproval dataform = new Action.OtValueApproval("LH");
            dataform.ShowDialog();
            int lhvalue = 0;
            try
            {
                lhvalue = int.Parse(dataform.Amount);
            }
            catch (Exception)
            {
                lhvalue = 0;
            }
            for (int i = 0; i < tbl_lhdata.RowCount - 1; i++)
            {
                String instatus = tbl_lhdata.Rows[i].Cells[16].Value.ToString().Trim();
                String Outstatus = tbl_lhdata.Rows[i].Cells[17].Value.ToString().Trim();

                if (Convert.ToBoolean(tbl_lhdata.Rows[i].Cells[0].Value) == true)
                {
                    if (Outstatus == "LH")
                    {
                        if (instatus == "P")
                        {
                            double sahiftduration = double.Parse(tbl_lhdata.Rows[i].Cells[25].Value.ToString());

                            if (sahiftduration > 0)
                            {
                                tbl_lhdata.Rows[i].Cells[14].Value = lhvalue;
                                DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[9].Value.ToString());
                                double fullday = Math.Truncate(sahiftduration - lhvalue);
                                TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                                tbl_lhdata.Rows[i].Cells[10].Value = intime.Add(t1);
                                sendDataForUpdationwithvalue(i);

                            }

                        }
                    }
                }
            }


        }









        #endregion





        # region Extrastatus

        public void getExtrastatusData()
        {
            DataTable extrastatusdata = new DataTable();


            extrastatusdata = actntrans.GetSwipeemplyeesdetailforActionWithExtrastatus(int.Parse(cmb_location.SelectedValue.ToString()), dtp_datevalue.Value.Date);


            tbl_extrastatus.DataSource = extrastatusdata;



            if (tbl_extrastatus.Rows.Count > 1)
            {
                tbl_extrastatus.Columns[1].Visible = false;
                tbl_extrastatus.Columns[2].Visible = false;

            }
        }

        private void tbl_extrastatus_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_extrastatus.IsCurrentCellDirty)
            {
                tbl_extrastatus.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            addtoOt();
            MessageBox.Show("Done");
        }

        public void addtoOt()
        {
            for (int i = 0; i < tbl_extrastatus.RowCount - 1; i++)
            {


                if (Convert.ToBoolean(tbl_extrastatus.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_extrastatus.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_extrastatus.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_extrastatus.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_extrastatus.Rows[i].Cells[3].Value.ToString());
                    float OtValue = float.Parse(tbl_extrastatus.Rows[i].Cells["ExtraValue"].Value.ToString());


                    int extravalues = Convert.ToInt32(Math.Ceiling(OtValue));


                    DateTime intime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_extrastatus.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_extrastatus.Rows[i].Cells[13].Value.ToString());
                    int extravalue = 0;
                    String extrastatus = "NA";
                    outvalue = outvalue + extravalues;
                    //added the entered number to the existing oT value in outvalue
                    tbl_extrastatus.Rows[i].Cells[14].Value = outvalue;


                    // added the ot minutes to the intime 
                    //    outime = outime.AddMinutes(OtValue);

                    tbl_extrastatus.Rows[i].Cells[10].Value = outime;

                    //make the extravalue to zero
                    tbl_extrastatus.Rows[i].Cells["ExtraValue"].Value = 0;

                    attndmngmnttrans.ResetSwipedataAndValueAndExtrastatus(swipedatid, empid,
                      intime, outime, instatus, Outstatus, invalue, outvalue, extravalue, extrastatus);
                    Actionlog.actiondone("Added Excess UOT Without time", "of employeeID " + empid + " for swipedatid " + swipedatid + "", empid);
                    tbl_extrastatus.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;
                }
            }
        }


        public void RemoveExcessUOT()
        {
            for (int i = 0; i < tbl_extrastatus.RowCount - 1; i++)
            {


                if (Convert.ToBoolean(tbl_extrastatus.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_extrastatus.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_extrastatus.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_extrastatus.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_extrastatus.Rows[i].Cells[3].Value.ToString());


                    DateTime intime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_extrastatus.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_extrastatus.Rows[i].Cells[13].Value.ToString());
                    int extravalue = 0;
                    String extrastatus = "NA";

                    attndmngmnttrans.ResetSwipedataAndValueAndExtrastatus(swipedatid, empid,
                     intime, outime, instatus, Outstatus, invalue, outvalue, extravalue, extrastatus);
                    Actionlog.actiondone("Remove Excess UOT Without timeChange", "of employeeID " + empid + " for swipedatid " + swipedatid + "", empid);
                    tbl_extrastatus.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;
                }
            }
        }
        public void RemoveExcessUOTTime()
        {
            for (int i = 0; i < tbl_extrastatus.RowCount - 1; i++)
            {


                if (Convert.ToBoolean(tbl_extrastatus.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_extrastatus.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_extrastatus.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_extrastatus.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_extrastatus.Rows[i].Cells[3].Value.ToString());
                    float OtValue = float.Parse(tbl_extrastatus.Rows[i].Cells["ExtraValue"].Value.ToString());
                    int extravalues = Convert.ToInt32(Math.Ceiling(OtValue));
                    DateTime intime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells[10].Value.ToString());
                    outime = outime.AddMinutes(-extravalues);
                    int outvalue = int.Parse(tbl_extrastatus.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_extrastatus.Rows[i].Cells[13].Value.ToString());
                    int extravalue = 0;
                    String extrastatus = "NA";

                    attndmngmnttrans.ResetSwipedataAndValueAndExtrastatus(swipedatid, empid,
                     intime, outime, instatus, Outstatus, invalue, outvalue, extravalue, extrastatus);
                    Actionlog.actiondone("Remove Excess UOT With time", "of employeeID " + empid + " for swipedatid " + swipedatid + "", empid);
                    tbl_extrastatus.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;
                }
            }
        }

        private void removeExcessUOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveExcessUOT();
            MessageBox.Show("Done");
        }


        # endregion


        private void synchronizeabscnet_Click(object sender, EventArgs e)
        {
            GetAbscentsynchrozized();
            MessageBox.Show("Done");
        }








        private void rejectUOTWithoutActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rejectUOTwithoutAction();
        }

        private void markPresentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem23_Click_1(object sender, EventArgs e)
        {
            HighlightOTofNonOTEmployee();
        }

        private void removeOTofUnauthorisedEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeOTofNonOTEmployee();
        }

        private void txt_oldempid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                searchOldid();
            }
        }

        private void txt_empid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchNewEmployeeID();
            }
        }

        private void adjustUOTWithLHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReduceLHfromUOT();
        }

        private void tbl_abscentononeside_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_abscentononeside.IsCurrentCellDirty)
            {
                tbl_abscentononeside.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void markSwipeForOneSideAbscentiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleartheSwipetimeHalftimeAbscent();
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            cropUOTWithoutTimeChange();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            //  ATCHRM.Controls.ATCHRMMessagebox.Show("This feature is provided already in Other window");
            for (int i = 0; i < tbl_lhdata.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_lhdata.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_lhdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_lhdata.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[9].Value.ToString());
                    if (instatus == "LH" && Outstatus != "LH")
                    {
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);
                        double sahiftduration = double.Parse(tbl_lhdata.Rows[i].Cells[25].Value.ToString());
                        tbl_lhdata.Rows[i].Cells[9].Value = actualintime;
                        tbl_lhdata.Rows[i].Cells[16].Value = "P";
                        tbl_lhdata.Rows[i].Cells[13].Value = "0";
                        sendLHDataForUpdationwithvalue(i);
                    }
                    else if ((instatus != "LH" && Outstatus == "LH"))
                    {
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);
                        double sahiftduration = double.Parse(tbl_lhdata.Rows[i].Cells[25].Value.ToString());

                        TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);


                        tbl_lhdata.Rows[i].Cells[10].Value = intime.Add(t1);
                        tbl_lhdata.Rows[i].Cells[17].Value = "P";
                        tbl_lhdata.Rows[i].Cells[14].Value = "0";
                        sendLHDataForUpdationwithvalue(i);

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  ((DataTable)tbl_attendancedata.DataSource).DefaultView.RowFilter = "ShiftPK = " + int.Parse (cmb_toshift .SelectedValue.ToString ()) + " ";
        }

        private void synchroniseBothSideLHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_lhdata.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_lhdata.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_lhdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_lhdata.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[9].Value.ToString());

                    if (instatus == "LH" && Outstatus == "LH")
                    {
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);
                        double sahiftduration = double.Parse(tbl_lhdata.Rows[i].Cells[25].Value.ToString());

                        TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);

                        tbl_lhdata.Rows[i].Cells[9].Value = actualintime;
                        tbl_lhdata.Rows[i].Cells[10].Value = intime.Add(t1);
                        tbl_lhdata.Rows[i].Cells[16].Value = "P";
                        tbl_lhdata.Rows[i].Cells[17].Value = "P";
                        tbl_lhdata.Rows[i].Cells[13].Value = "0";
                        tbl_lhdata.Rows[i].Cells[14].Value = "0";
                        sendLHDataForUpdationwithvalue(i);

                    }


                }
            }
        }




        public void sendLHDataForUpdationwithvalue(int i)
        {
            DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[9].Value.ToString());
            DateTime outime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[10].Value.ToString());
            int invalue = int.Parse(tbl_lhdata.Rows[i].Cells[13].Value.ToString());
            int outvalue = int.Parse(tbl_lhdata.Rows[i].Cells[14].Value.ToString());

            attndmngmnttrans.ResetSwipedataAndValue(int.Parse(tbl_lhdata.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_lhdata.Rows[i].Cells[3].Value.ToString()),
              intime, outime, tbl_lhdata.Rows[i].Cells[16].Value.ToString(), tbl_lhdata.Rows[i].Cells[17].Value.ToString(), invalue, outvalue);


        }





        private void markAbscentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_lhdata.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(tbl_lhdata.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_lhdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_lhdata.Rows[i].Cells[17].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[23].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells[9].Value.ToString());

                    if (instatus == "LH" && Outstatus == "LH")
                    {
                        tbl_lhdata.Rows[i].Cells[9].Value = DateTime.Parse("01/01/2000 00:00:00");
                        tbl_lhdata.Rows[i].Cells[10].Value = DateTime.Parse("01/01/2000 00:00:00");
                        tbl_lhdata.Rows[i].Cells[16].Value = "P";
                        tbl_lhdata.Rows[i].Cells[17].Value = "P";
                        tbl_lhdata.Rows[i].Cells[13].Value = "0";
                        tbl_lhdata.Rows[i].Cells[14].Value = "0";
                        sendLHDataForUpdationwithvalue(i);


                    }

                }
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_empid_TextChanged(object sender, EventArgs e)
        {

        }

        private void addOneDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells[0].Value) == true)
                {
                }
            }
        }

        private void removeExcessUOTWithTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveExcessUOTTime();
        }

        private void addOneDayToOutStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells[0].Value) == true)
                {
                    DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[10].Value.ToString());
                    int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[13].Value.ToString());
                    int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells[14].Value.ToString());
                    String instatus = tbl_wrongswipedata.Rows[i].Cells[16].Value.ToString().Trim();
                    String outstatus = tbl_wrongswipedata.Rows[i].Cells[17].Value.ToString().Trim();
                    double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells[25].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[23].Value.ToString());
                    DateTime shiftoutime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells[24].Value.ToString());
                    outime = outime.AddDays(1);
                    sendDataForUpdation(i);
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void reduceOTValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReduceOT();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbl_attendancedata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            ReduceLHfromOT();
        }


        public void ReduceLHfromOT()
        {
            for (int i = 0; i < tbl_otdata.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {



                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString());
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells[23].Value.ToString());

                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());

                    if (instatus == "LH" && Outstatus.Trim() == "OT1.5")
                    {   //if uot value greater than  LH value
                        if (outvalue >= invalue)
                        {
                            outvalue = outvalue - invalue;
                            if (outvalue == 0)
                            {
                                Outstatus = "P";
                            }
                            else if (outvalue <= 45)
                            {
                                Outstatus = "P";

                            }
                            outvalue = CropTheValueasperRule(outvalue);
                            //DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                            //outime = actualoutime.AddMinutes(outvalue);
                            invalue = 0;

                            //DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);

                            attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                         intime, outime, instatus, Outstatus, invalue, outvalue);


                        }
                        //if LH value is greater than UOT
                        else
                        {
                            invalue = invalue - outvalue;

                            outvalue = 0;
                            if (outvalue == 0)
                            {
                                Outstatus = "P";

                                outvalue = 0;


                                attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                        intime, outime, instatus, Outstatus, invalue, outvalue);


                            }

                        }
                    }

                }
            }
        }

        public int CropTheValueasperRule(int outvalue)
        {
            int returnvalue = 0;
            if (outvalue < 26)
            {
                returnvalue = 0;
            }
            else if ((outvalue >= 26) && (outvalue < 56))
            {
                returnvalue = 30;
            }
            else if ((outvalue >= 56) && (outvalue < 86))
            {
                returnvalue = 60;
            }
            else if ((outvalue >= 86) && (outvalue < 116))
            {
                returnvalue = 90;
            }
            else if ((outvalue >= 116) && (outvalue < 146))
            {
                returnvalue = 120;
            }
            else if ((outvalue >= 146) && (outvalue < 176))
            {
                returnvalue = 150;
            }
            else if ((outvalue >= 176) && (outvalue < 206))
            {
                returnvalue = 180;
            }
            else if ((outvalue >= 206) && (outvalue < 236))
            {
                returnvalue = 210;
            }
            else if ((outvalue >= 236) && (outvalue < 266))
            {
                returnvalue = 240;
            }
            else if ((outvalue >= 266) && (outvalue < 296))
            {
                returnvalue = 270;
            }
            else if ((outvalue >= 296) && (outvalue < 326))
            {
                returnvalue = 300;
            }
            else if ((outvalue >= 326) && (outvalue < 356))
            {
                returnvalue = 330;
            }
            else if ((outvalue >= 356) && (outvalue < 386))
            {
                returnvalue = 360;
            }
            else if ((outvalue >= 386) && (outvalue < 416))
            {
                returnvalue = 390;
            }
            else if ((outvalue >= 416) && (outvalue < 446))
            {
                returnvalue = 420;
            }
            else if ((outvalue >= 446) && (outvalue < 476))
            {
                returnvalue = 450;
            }
            else if ((outvalue >= 476) && (outvalue < 506))
            {
                returnvalue = 480;
            }
            else if ((outvalue >= 506) && (outvalue < 536))
            {
                returnvalue = 510;
            }
            else if ((outvalue >= 536) && (outvalue < 566))
            {
                returnvalue = 540;
            }
            else if ((outvalue >= 566) && (outvalue < 596))
            {
                returnvalue = 570;
            }
            else if ((outvalue >= 596) && (outvalue < 626))
            {
                returnvalue = 600;
            }
            else if ((outvalue >= 626) && (outvalue < 656))
            {
                returnvalue = 630;
            }
            else if ((outvalue >= 656) && (outvalue < 686))
            {
                returnvalue = 660;
            }
            else if ((outvalue >= 686) && (outvalue < 716))
            {
                returnvalue = 690;
            }
            else if ((outvalue >= 716) && (outvalue < 746))
            {
                returnvalue = 720;
            }
            else if ((outvalue >= 746) && (outvalue < 776))
            {
                returnvalue = 750;
            }
            else if ((outvalue >= 776) && (outvalue < 806))
            {
                returnvalue = 780;
            }
            else if ((outvalue >= 806) && (outvalue < 836))
            {
                returnvalue = 810;
            }
            else
            {
                returnvalue = outvalue - (outvalue % 30);
            }

            return returnvalue;
        }

        private void MatchOutValuewithSwipe_Click(object sender, EventArgs e)
        {
            matchOutValueWithSwipe();
        }
        public void matchOutValueWithSwipe()
        {
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {


                    String instatus = tbl_otdata.Rows[i].Cells[16].Value.ToString().Trim();
                    String Outstatus = tbl_otdata.Rows[i].Cells[17].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells[1].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString());
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells[24].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells[23].Value.ToString());

                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells[9].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells[10].Value.ToString());
                    //int outvalue = int.Parse(tbl_otdata.Rows[i].Cells[14].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells[13].Value.ToString());






                    DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                  
                    if (Outstatus == "P")
                    {
                        TimeSpan span = new TimeSpan();
                        span = outime.Subtract(actualoutime);
                        int outvalue = (int)Math.Round(span.TotalMinutes);

                        outvalue = CropTheValueasperRule(outvalue);
                        attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                    intime, outime, instatus, Outstatus, invalue, outvalue);


                    }
                    if (Outstatus == "OT1.5")
                    {
                        TimeSpan span = new TimeSpan();
                        span = outime.Subtract(actualoutime);
                        int outvalue = (int)Math.Round(span.TotalMinutes);

                        outvalue = CropTheValueasperRule(outvalue);

                        if (outvalue < 45)
                        {
                            Outstatus = "P";
                            outvalue = 0;
                        }
                        attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                    intime, outime, instatus, Outstatus, invalue, outvalue);

                    }

                }
            }
        }

        private void hPLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reduceLHFormOTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {

        }
    }
}
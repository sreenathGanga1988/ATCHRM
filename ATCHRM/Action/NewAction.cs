using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Action
{
    public partial class NewAction : Form
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
        DataTable employeeswipetable = null;
        Transactions.AttendanceManagementTransaction attndmngmnttrans = null;
        public NewAction()
        {
            InitializeComponent();
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
            ajstrtrans = new Transactions.Adjuster.AdjusterTranscation();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (hlpr.isdateaccesible(Program.Datetoday, dtp_datevalue.Value.Date))
            {
                tabControl1.SelectedTab = tab_general;

                getdatFromDatabase();

            }
            else
            {
                //   ATCHRM.Controls.ATCHRMMessagebox.Show("You Cannot Select This Date");
                //     dtp_datevalue.Value = Program.Datetoday;


                //    menuStrip1.Enabled = false;
                tabControl1.SelectedTab = tab_general;
                getdatFromDatabase();
            }
        }


        public void getdatFromDatabase()
        {
            try
            {
                tabControl1.SelectedTab = tab_general;

                employeeswipetable = actntrans.DataForNewAction(Program.LOCTNPK, dtp_datevalue.Value.Date);

                DataTable dt = hldytransaction.getAnyHolidayofaDate(dtp_datevalue.Value.Date, Program.LOCTNPK);
                filldatagridview(employeeswipetable);

                if (employeeswipetable.Rows.Count > 0)
                {
                    tbl_attendancedata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_attendancedata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_attendancedata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_attendancedata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
                }
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

        public void filldatagridview(DataTable employeeswipetable)
        {



            tbl_attendancedata.DataSource = employeeswipetable;

            UltraGridBand band = this.tbl_attendancedata.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;


            AvoidLeaveEmployees();
        }

        /// <summary>
        /// Remove the Leavedata
        /// </summary>
        public void AvoidLeaveEmployees()
        {
            DataTable leavedata = lvtrans.GetAllLeaveCodeandName();

            for (int i = tbl_attendancedata.Rows.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < leavedata.Rows.Count; j++)
                {
                    if (tbl_attendancedata.Rows[i].Cells["Instatus"].Value.ToString().Trim() == leavedata.Rows[j][0].ToString().Trim() && tbl_attendancedata.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == leavedata.Rows[j][0].ToString().Trim())
                    {

                        // tbl_attendancedata.Rows[i].Delete ();
                    }
                }

            }




        }


        # region SETTINGSELECTBUTTON
        private void tbl_attendancedata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_attendancedata.DisplayLayout.Bands[0].ResetColumns();
            tbl_attendancedata.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            // tbl_attendancedata.DisplayLayout.Bands[0].Override.AllowUpdate = DefaultableBoolean.False;
            tbl_attendancedata.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);


            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
        }

        private void tbl_gatepassdata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_gatepassdata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;

        }

        private void tbl_extrastatus_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_extrastatus.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_extrastatus.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_extrastatus.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_lhdata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_lhdata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_lhdata.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_lhdata.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_abscentononeside_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_abscentononeside.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_abscentononeside.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_abscentononeside.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_presenties_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_presenties.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_presenties.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_presenties.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_abscent_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_abscent.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_abscent.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_abscent.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_uotdata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_uotdata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_uotdata.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_uotdata.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_otdata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_otdata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_otdata.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_otdata.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_offdata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_offdata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_offdata.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;

        }

        private void tbl_swipeonleavedata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_swipeonleavedata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_swipeonleavedata.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_swipeonleavedata.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_wrongswipedata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_wrongswipedata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_wrongswipedata.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_wrongswipedata.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_swipeonleave_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_swipeonleave.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_swipeonleave.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_swipeonleave.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;

        }

        private void tbl_leavedata_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_leavedata.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_leavedata.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_leavedata.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;


        }

        private void tbl_offday_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_offday.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            tbl_offday.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            tbl_offday.DisplayLayout.Bands[0].Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
        }

        # endregion















        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_general)
            {
                menuStrip1.Enabled = true;
                getdatFromDatabase();
            }
            else if (tabControl1.SelectedTab == tab_gatepass)
            {
                gatepassactions();

            }
            else if (tabControl1.SelectedTab == tab_Leave)
            {
                Leavedataaction();

            }
            else if (tabControl1.SelectedTab == tab_swipeonHalfday)
            {

                getSwipesOnLeave();

            }
            else if (tabControl1.SelectedTab == tab_wrongswipe)
            {
                getwrongswipes();

            }
            else if (tabControl1.SelectedTab == tab_employeepresentonleave)
            {
                Getemployyepresentonleave();

            }
            else if (tabControl1.SelectedTab == tab_OFFOt)
            {
                getOffOTofaDay();

            }
            else if (tabControl1.SelectedTab == tab_OT)
            {
                getOtData();

            }
            else if (tabControl1.SelectedTab == tab_uot)
            {
                getUOTData();

            }
            else if (tabControl1.SelectedTab == tab_abscenties)
            {
                GetAbscentiesData();

            }
            else if (tabControl1.SelectedTab == tab_presnties)
            {
                gettpresentemployeedata();

            }
            else if (tabControl1.SelectedTab == tab_AtoP)
            {
                getAbscentonOnesidedata();

            }
            else if (tabControl1.SelectedTab == tab_LH)
            {
                getLHData();

            }
            else if (tabControl1.SelectedTab == Tab_extraStatus)
            {
                getExtrastatusData();

            }
            else if (tabControl1.SelectedTab == tab_offday)
            {
                GetOffdata();

            }
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

        # region Action



        private void tbl_attendancedata_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug = sender as UltraGrid;

            ug.ActiveRow.Update();
            ug.PerformAction(UltraGridAction.ExitEditMode);
        }
        private void foreNoonSHPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void multiUPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ifauthunicated())
            {
                MarkleaveAction("UPL");
                MessageBox.Show("Sucess");
            }
        }
        private void multiPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ifauthunicated())
            {
                MarkleaveAction("PL");
                MessageBox.Show("Sucess");
            }
        }
        private void multiHPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ifauthunicated())
            {
                MarkHalfLeaveAction("HPL");
                MessageBox.Show("Sucess");
            }
        }
        private void multiPLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ifauthunicated())
            {
                MarkleaveAction("SL");
                MessageBox.Show("Sucess");
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
        public void MarkleaveAction(String leavetype)
        {




            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    String instatus = tbl_attendancedata.Rows[i].Cells["Instatus"].Value.ToString().Trim();
                    String appliedInStatus = tbl_attendancedata.Rows[i].Cells["ApplyInStatus"].Value.ToString().Trim();
                    String apprInStatus = tbl_attendancedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();

                    String outStatus = tbl_attendancedata.Rows[i].Cells["OutStatus"].Value.ToString().Trim();
                    String aplliedOutStatus = tbl_attendancedata.Rows[i].Cells["ApplyOuttStatus"].Value.ToString().Trim();
                    String apprOutstatus = tbl_attendancedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();

                    int swipedatid = int.Parse(tbl_attendancedata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_attendancedata.Rows[i].Cells["empid"].Value.ToString());

                    DateTime intime = DateTime.Parse(tbl_attendancedata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_attendancedata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_attendancedata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_attendancedata.Rows[i].Cells["Invalue"].Value.ToString());



                    if (ifleaveavailableformulti(empid, leavetype, "Multi"))
                    {



                        if (instatus == "A" && outStatus == "A")
                        {
                            tbl_attendancedata.Rows[i].Cells["OutStatus"].Value = leavetype;

                            tbl_attendancedata.Rows[i].Cells["Instatus"].Value = leavetype;

                            applyLeaveAction(i, "IN", "Instatus");
                            applyLeaveAction(i, "OUT", "OutStatus");



                        }
                        else
                        {
                            tbl_attendancedata.Rows[i].Cells["OutStatus"].Value = leavetype;

                            tbl_attendancedata.Rows[i].Cells["Instatus"].Value = leavetype;

                            applyLeaveAction(i, "IN", "Instatus");
                            applyLeaveAction(i, "OUT", "OutStatus");

                        }



                    }
                    else
                    {

                    }
                }








            }


        }


        public void MarkHalfLeaveAction(String leavetype)
        {
            string[] otherenddata = { "P",  "HSL", "HPL" };
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(tbl_attendancedata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    String instatus = tbl_attendancedata.Rows[i].Cells["Instatus"].Value.ToString().Trim();
                    String appliedInStatus = tbl_attendancedata.Rows[i].Cells["ApplyInStatus"].Value.ToString().Trim();
                    String apprInStatus = tbl_attendancedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();

                    String outStatus = tbl_attendancedata.Rows[i].Cells["OutStatus"].Value.ToString().Trim();
                    String aplliedOutStatus = tbl_attendancedata.Rows[i].Cells["ApplyOuttStatus"].Value.ToString().Trim();
                    String apprOutstatus = tbl_attendancedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();

                    int swipedatid = int.Parse(tbl_attendancedata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_attendancedata.Rows[i].Cells["empid"].Value.ToString());

                    DateTime intime = DateTime.Parse(tbl_attendancedata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_attendancedata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_attendancedata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_attendancedata.Rows[i].Cells["Invalue"].Value.ToString());



                    if (ifleaveavailableformulti(empid, leavetype, "Multi"))
                    {



                        if (instatus == "A" && otherenddata.Contains(outStatus))
                        {
                            

                            tbl_attendancedata.Rows[i].Cells["Instatus"].Value = leavetype;

                            applyLeaveAction(i, "IN", "Instatus");
                            



                        }
                        else if (otherenddata.Contains(instatus) && outStatus == "A")
                        {
                            tbl_attendancedata.Rows[i].Cells["OutStatus"].Value = leavetype;

                           

                            applyLeaveAction(i, "IN", "Instatus");
                            applyLeaveAction(i, "OUT", "OutStatus");

                        }
                        else if (instatus=="A" && outStatus == "A")
                        {
                            tbl_attendancedata.Rows[i].Cells["OutStatus"].Value = leavetype;



                          
                            applyLeaveAction(i, "OUT", "OutStatus");

                        }
                        else
                        {
                            MessageBox.Show("Out of all condition of Half day");
                        }


                    }
                    else
                    {
                        MessageBox.Show("No Leave Pending");
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
                ATCHRM.Controls.ATCHRMMessagebox.Show(Code + " Left  Is -" + Leaveavailable);
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Leaves Left ");
            }

            return isavailable;
        }
        public Boolean ifleaveavailableformulti(int empid, String Code, String multi)
        {

            Boolean isavailable = false;



            int Leaveavailable = lvapadvncetrans.leaveleftofatype(empid, getleavePk(empid, Code));

            if (Leaveavailable > 0)
            {
                isavailable = true;

            }
            else
            {
                MessageBox.Show("No Leave Available for empid " + empid.ToString());

            }

            return isavailable;
        }

        /// <summary>
        /// send the marked leave action for approvals
        /// </summary>
        public Boolean applyLeaveAction(int rownum, String Inout, String colnmunum)
        {
            Boolean sucesss = true;

            int swipedatid = int.Parse(tbl_attendancedata.Rows[rownum].Cells["Swipedataid"].Value.ToString());
            int empid = int.Parse(tbl_attendancedata.Rows[rownum].Cells["empid"].Value.ToString());
            DateTime Swipedate = DateTime.Parse(tbl_attendancedata.Rows[rownum].Cells["SwipeDate"].Value.ToString());
            String Tocomponents = tbl_attendancedata.Rows[rownum].Cells[colnmunum].Value.ToString();

            ArrayList arrylst = new ArrayList();
            arrylst.Add(swipedatid);//swipedatid
            arrylst.Add(empid); //empid
            arrylst.Add(Swipedate); //swipedate
            arrylst.Add("Mark Leave Type");//type
            arrylst.Add(Inout);//in or out
            arrylst.Add(Program.USERPK);//user
            arrylst.Add("A");//from component
            arrylst.Add(Tocomponents); //to componment

            sucesss = actntrans.MarkLeaveAction(arrylst);
            return sucesss;
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


        #endregion


        # region Gatepass Actions

        public void gatepassactions()
        {

            DataTable dt = attndmngmnttrans.Getgatepassdata(dtp_datevalue.Value.Date, Program.LOCTNPK);
            gatepassfilldatagrid(dt);
            if (dt.Rows.Count > 1)
            {


                tbl_gatepassdata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_gatepassdata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                //tbl_gatepassdata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                //tbl_gatepassdata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }


        }

        public void gatepassfilldatagrid(DataTable actiondata)
        {
            tbl_gatepassdata.DataSource = actiondata;
        }
        #endregion




        # region  LEAVE Actions


        public void Leavedataaction()
        {
            DataTable dt = attndmngmnttrans.GetALLLeaveData(dtp_datevalue.Value.Date, Program.LOCTNPK);

            Leavedatafilldatagrid(dt);
            if (dt.Rows.Count > 1)
            {
                tbl_leavedata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_leavedata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                //tbl_leavedata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                //tbl_leavedata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }


        }

        public void Leavedatafilldatagrid(DataTable actiondata)
        {

            tbl_leavedata.DataSource = actiondata;


        }

        # endregion


        # region SWIPEONlEAVE

        /// <summary>
        /// getall Swipe of employee on a day where one part is Leave
        /// </summary>
        /// 
        public void getSwipesOnLeave()
        {

            string[] Leavesarray = { "PL", "UPL", "SL", "ML", "PL", "SHD", "HD" };

            DataTable swipeonleavetable = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    swipeonleavetable = employeeswipetable.Clone();
                    foreach (DataRow dr in employeeswipetable.Rows)
                    {


                        if (Leavesarray.Contains(dr["ApprInstatus"].ToString().Trim()) || Leavesarray.Contains(dr["ApprOutstatus"].ToString().Trim()))
                        {


                            if (dr["ApprInstatus"].ToString().Trim() != dr["ApprOutstatus"].ToString().Trim())
                            {
                                swipeonleavetable.Rows.Add(dr.ItemArray);

                            }

                        }


                    }


                    tbl_swipeonleave.DataSource = swipeonleavetable;
                    if (swipeonleavetable.Rows.Count > 1)
                    {
                        tbl_swipeonleavedata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
                        tbl_swipeonleavedata.DisplayLayout.Bands[0].Columns["TotimeTime"].Format = "dd/MM/yyyy HH:mm:ss";

                    }
                }


            }


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
        /// <summary>
        /// mark leaveonother half if leave
        /// </summary>
        /// <returns></returns>
        public int markOtherHalfLeave()
        {
            int correctedflag = 0;
            string[] Leavesarray = { "PL", "UPL", "SL", "ML", "FL" };
            for (int i = 0; i < tbl_swipeonleave.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_swipeonleave.Rows[i].Cells[0].Value) == true)
                {

                    String instatus = tbl_swipeonleave.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String outstatus = tbl_swipeonleave.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime intime = DateTime.Parse(tbl_swipeonleave.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_swipeonleave.Rows[i].Cells["Outtime"].Value.ToString());

                    if (outstatus == "PL" || outstatus == "UPL" || outstatus == "SL" || outstatus == "ML" || outstatus == "FL")
                    {

                        tbl_swipeonleave.Rows[i].Cells["Intime"].Value = tbl_swipeonleave.Rows[i].Cells["Outtime"].Value;
                        tbl_swipeonleave.Rows[i].Cells["ApprInstatus"].Value = outstatus;


                        attndmngmnttrans.ResestSwipeData(int.Parse(tbl_swipeonleave.Rows[i].Cells["Swipedataid"].Value.ToString()), int.Parse(tbl_swipeonleave.Rows[i].Cells["empid"].Value.ToString()),
                            intime, outime, tbl_swipeonleave.Rows[i].Cells["ApprInstatus"].Value.ToString(), tbl_swipeonleave.Rows[i].Cells["ApprOutStatus"].Value.ToString());

                        correctedflag++;
                    }
                    else if (instatus == "PL" || instatus == "UPL" || instatus == "SL" || instatus == "ML" || instatus == "FL")
                    {
                        tbl_swipeonleave.Rows[i].Cells["Outtime"].Value = tbl_swipeonleave.Rows[i].Cells["Intime"].Value;
                        tbl_swipeonleave.Rows[i].Cells["ApprOutStatus"].Value = instatus;

                        attndmngmnttrans.ResestSwipeData(int.Parse(tbl_swipeonleave.Rows[i].Cells["Swipedataid"].Value.ToString()), int.Parse(tbl_swipeonleave.Rows[i].Cells["empid"].Value.ToString()),
                          intime, outime, tbl_swipeonleave.Rows[i].Cells["ApprInstatus"].Value.ToString(), tbl_swipeonleave.Rows[i].Cells["ApprOutStatus"].Value.ToString());
                        correctedflag++;
                    }
                }




            }

            return correctedflag;
        }

        # endregion


        # region WRONG SWIPE Actions

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


                    try
                    {
                        wrongswipedatatable = employeeswipetable.Select("Intime>Outtime").CopyToDataTable();
                    }
                    catch (Exception)
                    {


                    }



                }
            }







            if (wrongswipedatatable.Rows.Count > 0)
            {
                tbl_wrongswipedata.DataSource = wrongswipedatatable;
                tbl_wrongswipedata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_wrongswipedata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_wrongswipedata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_wrongswipedata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";

            }

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            correctingOTEntries();
            makedurationOK();
            getdatFromDatabase();
        }

        /// <summary>
        /// correct the mistake entries with  OT
        /// </summary>
        public void correctingOTEntries()
        {
            int flag = 0;
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count; i++)
            {

                int swipedatid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Swipedataid"].Value.ToString());
                int empid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["empid"].Value.ToString());
                String Apprinstatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                String ApprOutstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                DateTime shiftoutime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                DateTime shiftintime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftintime"].Value.ToString());

                double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());
                DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString());
                DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString());
                int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value.ToString());
                int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Invalue"].Value.ToString());





                if (ApprOutstatus == "OT" || ApprOutstatus == "OT1.5")
                {

                    int shiftduration = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());


                    if (Apprinstatus == "LH")
                    {

                        TimeSpan t1 = new TimeSpan(0, int.Parse(invalue.ToString()), 0);

                        intime = intime.Subtract(t1);
                        int totaldone = outvalue + shiftduration;



                        TimeSpan t12 = new TimeSpan(0, int.Parse(totaldone.ToString()), 0);

                        tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t12);


                        sendDataForUpdation(i);
                        tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Beige;
                        //   calculateduration(i);

                    }
                    else if (Apprinstatus == "A")
                    {

                    }
                    else if (Apprinstatus == "P" && (ApprOutstatus == "OT1.5" || ApprOutstatus == "OT"))
                    {
                        if (intime > outime)
                        {


                            int totaldone = outvalue + shiftduration;



                            TimeSpan t1 = new TimeSpan(0, int.Parse(totaldone.ToString()), 0);

                            tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);

                            sendDataForUpdation(i);
                            //  calculateduration(i);
                            tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Beige;

                            flag++;
                        }
                    }

                }



            }

        }

        /// <summary>
        /// make the duration Ok for the wrong swipes
        /// </summary>

        public void makedurationOK()
        {
            string[] halfdayleaves = { "SHD", "HPL" };
            String[] otandpresent = { "P", "OT", "OT1.5", "UOT" };

            for (int i = 0; i < tbl_wrongswipedata.Rows.Count; i++)
            {



                String instatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                String Outstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                if (instatus == "A" && Outstatus == "A")
                {
                    synchroniseInandOuttime(i);
                }

                if (instatus == "P" && Outstatus == "LH")
                {

                }









                if (tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/2000" || tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/2000 00:00:00")
                {
                    if (halfdayleaves.Contains(Outstatus))
                    {
                        tbl_wrongswipedata.Rows[i].Cells["Intime"].Value = tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value;

                        synchroniseInandOuttime(i);

                    }

                    else if (Outstatus == "LH")
                    {
                        double outvalue = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value.ToString());
                        DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString());

                        TimeSpan losttime = new TimeSpan(0, int.Parse(outvalue.ToString()), 0);
                        DateTime swipeout = outime.Add(losttime);
                        double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());
                        if (sahiftduration > 0)
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells["Intime"].Value = outime.Subtract(t1);
                            sendDataForUpdation(i);
                        }

                    }
                    else if (Outstatus == "P")
                    {


                        double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());

                        if (sahiftduration > 0)
                        {
                            double outvalue = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value.ToString());
                            DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString());

                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells["Intime"].Value = outime.Subtract(t1);

                            sendDataForUpdation(i);


                        }




                    }

                }
            }
        }
        public void synchroniseInandOuttime(int i)
        {
            if (DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString()) >= DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString()))
            {
                tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = tbl_wrongswipedata.Rows[i].Cells["Intime"].Value;
                sendDataForUpdation(i);
            }
            else
            {
                tbl_wrongswipedata.Rows[i].Cells["Intime"].Value = tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value;
                sendDataForUpdation(i);
            }
        }

        public void sendDataForUpdation(int i)
        {

            int swipedatid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Swipedataid"].Value.ToString());
            int empid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["empid"].Value.ToString());
            String Apprinstatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
            String ApprOutstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
            DateTime shiftoutime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftoutime"].Value.ToString());
            DateTime shiftintime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftintime"].Value.ToString());

            double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());
            DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString());
            DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString());
            int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value.ToString());
            int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Invalue"].Value.ToString());

            attndmngmnttrans.ResestSwipeData(swipedatid, empid,
                intime, outime, Apprinstatus, ApprOutstatus);


        }
        public void sendDataForUpdationwithvalue(int i)
        {
            int swipedatid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Swipedataid"].Value.ToString());
            int empid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["empid"].Value.ToString());
            String Apprinstatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
            String ApprOutstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
            DateTime shiftoutime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftoutime"].Value.ToString());
            DateTime shiftintime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftintime"].Value.ToString());

            double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());
            DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString());
            DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString());
            int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value.ToString());
            int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Invalue"].Value.ToString());

            attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
              intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);


        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            clearLHissues();

            getdatFromDatabase();
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
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count; i++)
            {
                String instatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                String Outstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    if (Outstatus == "LH")
                    {
                        if (instatus == "P")
                        {
                            double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());

                            if (sahiftduration > 0)
                            {
                                tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value = lhvalue;
                                DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString());
                                double fullday = Math.Truncate(sahiftduration - lhvalue);
                                TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                                tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
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
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String instatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();


                    if (instatus == "P" && Outstatus == "P")
                    {
                        DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString());
                        double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());
                        TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);
                        tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                        sendDataForUpdation(i);
                    }


                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            CleraPresentSipes();
            getdatFromDatabase();
        }

        //clear the Abscent that may occur in one place
        public void synchroniseAbscent()
        {
             String[] halfday = { "HPL", "HSL", "SHD", "SHP" };

            for (int i = 0; i < tbl_wrongswipedata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["empid"].Value.ToString());
                    String instatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String outstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Invalue"].Value.ToString());






                    if (instatus == "P" && outstatus == "LH")
                    {

                    }
                    else if (instatus == "LH" && outstatus == "A")
                    {
                        if (tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000" || tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000 00:00:00")
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            double fullday = Math.Truncate(halfdaytime - invalue);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Tomato;
                        }
                        else
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            double fullday = Math.Truncate(halfdaytime - invalue);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Tomato;
                        }
                    }
                    else if (instatus == "P" && outstatus == "A")
                    {
                        if (tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000" || tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000 00:00:00")
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Tomato;
                        }
                        else
                        {
                            double halfdaytime = Math.Truncate(sahiftduration / 2);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Tomato;
                        }

                    }
                    else if (instatus == "LH" && outstatus == "P")
                    {
                        // ASSUMING MAXIMUM LH IS 370
                        if (invalue < 270)
                        {
                            double fullday = Math.Truncate(sahiftduration - invalue);
                            TimeSpan t1 = new TimeSpan(0, int.Parse(fullday.ToString()), 0);
                            tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                            sendDataForUpdation(i);
                            tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Turquoise;
                        }

                    }
                    else if(halfday.Contains(instatus)&& outstatus == "A")
                    {
                        tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = intime;

                        
                        sendDataForUpdation(i);
                        tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Turquoise;

                    }
                    else if (instatus == "A" && halfday.Contains(outstatus))
                    {
                        tbl_wrongswipedata.Rows[i].Cells["Intime"].Value = outime;                                              
                        sendDataForUpdation(i);
                        tbl_wrongswipedata.Rows[i].Appearance.BackColor = Color.Turquoise;

                    }
                }

            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            synchroniseAbscent();
        }
        /// <summary>
        /// add one day to outstatus
        /// </summary>
        public void addoneday()
        {
            for (int i = 0; i < tbl_wrongswipedata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_wrongswipedata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_wrongswipedata.Rows[i].Cells["empid"].Value.ToString());
                    String instatus = tbl_wrongswipedata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String outstatus = tbl_wrongswipedata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_wrongswipedata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_wrongswipedata.Rows[i].Cells["Invalue"].Value.ToString());

                    outime = outime.AddDays(1);
                    tbl_wrongswipedata.Rows[i].Cells["Outtime"].Value = outime;
                    sendDataForUpdation(i);
                }
            }
        }

        private void addOneDayToOutStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addoneday();
        }



        # endregion


        # region EMPLOYEEPRESENTONLEAVE Actions
        public void Getemployyepresentonleave()
        {
            DataTable dt = actntrans.Getswipeofemployeespresentonappliedleave(Program.LOCTNPK, dtp_datevalue.Value.Date);
            tbl_swipeonleavedata.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                //          tbl_swipeonleave.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                //     tbl_swipeonleave.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";

            }
        }
        # endregion


        # region OFFOT Actions
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
                    try
                    {
                        DataTable results = employeeswipetable.Select("ApprOutstatus ='OT2.0'").CopyToDataTable();
                    }
                    catch (Exception)
                    {


                    }
                }

                tbl_offdata.DataSource = offotdata;
                if (offotdata.Rows.Count > 0)
                {
                    tbl_offdata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_offdata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_offdata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_offdata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
                }
            }
        }


        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            AddSwipeForOFFOT();
        }

        private void removeOffOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkOFFOTtoAbscent();
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


            for (int i = 0; i < tbl_offdata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_offdata.Rows[i].Cells[0].Value) == true)
                {


                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells["Shiftduration"].Value.ToString());




                    DateTime outime = intime.AddMinutes(offotvalue);
                    DateTime correctedintime = randomtimecreator(intime, intime.AddMinutes(-20));
                    DateTime correctedoutime = randomtimecreator(outime, outime.AddMinutes(10));

                    tbl_offdata.Rows[i].Cells["Intime"].Value = correctedintime;
                    tbl_offdata.Rows[i].Cells["Outtime"].Value = correctedoutime;
                    tbl_offdata.Rows[i].Cells["ApprOutStatus"].Value = "OT2.0";

                    ApprOutstatus = "OT2.0";



                    int invalue = int.Parse(tbl_offdata.Rows[i].Cells["Invalue"].Value.ToString());
                    int outvalue = offotvalue;

                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);

                    tbl_offdata.Rows[i].Appearance.BackColor = Color.CornflowerBlue;

                }
            }

        }

        //Remove Swipw of the day and mark it to A
        public void MarkOFFOTtoAbscent()
        {
            for (int i = 0; i < tbl_offdata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_offdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_offdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_offdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_offdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_offdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_offdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_offdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_offdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_offdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_offdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_offdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_offdata.Rows[i].Cells["Invalue"].Value.ToString());

                    tbl_offdata.Rows[i].Cells[10].Value = tbl_offdata.Rows[i].Cells[9].Value = DateTime.Parse("2000-01-01 00:00:00.000");
                    outime = DateTime.Parse("2000-01-01 00:00:00.000");
                    outime = DateTime.Parse("2000-01-01 00:00:00.000");
                    invalue = 0;
                    outvalue = 0;
                    tbl_offdata.Rows[i].Cells[16].Value = Apprinstatus = "A";
                    tbl_offdata.Rows[i].Cells[17].Value = ApprOutstatus = "A";


                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                                        intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);

                    tbl_offdata.Rows[i].Appearance.BackColor = Color.CornflowerBlue;
                }
            }


        }





        #endregion



        #region OT Actions


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
                    try
                    {
                        otdatatable = employeeswipetable.Select("ApprOutstatus ='OT1.5' or ApprOutstatus ='OT'").CopyToDataTable();
                    }
                    catch (Exception)
                    {


                    }

                }
            }



            tbl_otdata.DataSource = otdatatable;
            if (otdatatable.Rows.Count > 0)
            {
                tbl_otdata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_otdata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_otdata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_otdata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }



        }


        private void ExtendOT_Click(object sender, EventArgs e)
        {
            AddTimetoOT();
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
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {


                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells["Selecter"].Value) == true)
                {





                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Totimetime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells["fromtime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells["Invalue"].Value.ToString());


                    outvalue = outvalue + OtValue;
                    //added the entered number to the existing oT value in putvalue
                    tbl_otdata.Rows[i].Cells["Outvalue"].Value = outvalue;


                    // added the ot minutes to the intime 
                    outime = outime.AddMinutes(OtValue);

                    tbl_otdata.Rows[i].Cells["Outtime"].Value = outime;



                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);

                    tbl_otdata.Rows[i].Appearance.BackColor = Color.Turquoise;
                }
            }
        }



        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            // this is useed to  adjust the Outime asper the Outvalu

            matchEmployeeSwipeWithOutValue();
        }





        public void matchOutValueWithSwipe()
        {
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Outtime"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Intime"].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells["Invalue"].Value.ToString());
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Totimetime"].Value.ToString());
                    DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                    TimeSpan span = new TimeSpan();
                    if (Apprinstatus == "P")
                    {
                        span = outime.Subtract(actualoutime);
                        int outvalue = (int)Math.Round(span.TotalMinutes);

                      outvalue=  CropTheValueasperRule(outvalue);
                         attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                     intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);

                         tbl_otdata.Rows[i].Appearance.BackColor = Color.Firebrick;
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
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells["Invalue"].Value.ToString());
                    if (Apprinstatus == "P")
                    {

                        //if p just add the shift  duration to the intime 
                        // and we will get the actual shiftoutime out time
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);

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




                    tbl_otdata.Rows[i].Cells["Outtime"].Value = outime;




                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);

                    tbl_otdata.Rows[i].Appearance.BackColor = Color.Firebrick;
                }
            }
        }
        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            markZeroValuedOTtoP();
        }




        /// <summary>
        /// Check if the outvalue of the selected Employee is Zero and if he have OT as outsatatus then mark it P
        /// </summary>
        public void markZeroValuedOTtoP()
        {
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells["Invalue"].Value.ToString());

                    if (outvalue == 0 && ApprOutstatus.Trim() == "OT1.5")
                    {

                        tbl_otdata.Rows[i].Cells["ApprOutstatus"].Value = "P";
                        ApprOutstatus = "P";
                        attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                    intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);
                        tbl_otdata.Rows[i].Appearance.BackColor = Color.Gray;
                    }

                }
            }
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            MarkOTtoUOT();
        }

        /// <summary>
        /// Mark Selected OT As UOT
        /// </summary>
        public void MarkOTtoUOT()
        {
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells["Invalue"].Value.ToString());
                    if (outvalue != 0 && ApprOutstatus.Trim() == "OT1.5")
                    {
                        tbl_otdata.Rows[i].Cells[17].Value = "UOT";
                        ApprOutstatus = "UOT";
                        attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                    intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);


                        tbl_otdata.Rows[i].Appearance.BackColor = Color.Green;

                    }


                }
            }

        }


        private void reduceOTValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReduceOT();
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
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells["Invalue"].Value.ToString());

                    outvalue = outvalue - OtValue;
                    //subtract the entered number to the existing oT value in putvalue
                    tbl_otdata.Rows[i].Cells["Outvalue"].Value = outvalue;


                    // added the ot minutes to the intime 
                    outime = outime.AddMinutes(-OtValue);

                    tbl_otdata.Rows[i].Cells["Outtime"].Value = outime;



                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);

                    //   tbl_otdata.Rows[i].DefaultCellStyle.BackColor = Color.Turquoise;
                }
            }
        }


        private void removeOTofUnauthorisedEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeOTofNonOTEmployee();
        }


        /// <summary>
        /// remove the OT of a Employee if he is not authorised to DO OT
        /// </summary>
        public void removeOTofNonOTEmployee()
        {
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_otdata.Rows[i].Cells[0].Value) == true)
                {


                    int swipedatid = int.Parse(tbl_otdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_otdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_otdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_otdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_otdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_otdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_otdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_otdata.Rows[i].Cells["Invalue"].Value.ToString());


                    if (actntrans.isOTApplicableForEmployee(empid) == false)
                    {
                        if (outvalue != 0 && ApprOutstatus.Trim() == "OT1.5")
                        {
                            ApprOutstatus = "P";

                            DateTime actualoutime = new DateTime(outime.Year, outime.Month, outime.Day, shiftoutime.Hour, shiftoutime.Minute, shiftoutime.Second);
                            outime = randomtimecreator(actualoutime, actualoutime.AddMinutes(10));
                            outvalue = 0;
                            attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);
                            tbl_otdata.Rows[i].Appearance.BackColor = Color.Green;

                        }
                    }
                }
            }
        }


        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            HighlightOTofNonOTEmployee();
        }

        /// <summary>
        /// HighLight All the Wrong OT ie the OT assigned to the Persons who are not authorised to Do OT
        /// </summary>
        public void HighlightOTofNonOTEmployee()
        {
            for (int i = 0; i < tbl_otdata.Rows.Count; i++)
            {


                int empid = int.Parse(tbl_otdata.Rows[i].Cells[3].Value.ToString());
                if (!actntrans.isOTApplicableForEmployee(empid))
                {
                    tbl_otdata.Rows[i].Appearance.BackColor = Color.Red;
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
                        tbl_otdata.Rows[i].Appearance.BackColor = Color.Blue;
                    }
                }

            }

        }





        # endregion


        # region UOT Action

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

                    try
                    {
                        UOTData = employeeswipetable.Select("ApprOutstatus ='UOT'").CopyToDataTable();
                    }
                    catch (Exception)
                    {


                    }


                }
            }




            tbl_uotdata.DataSource = UOTData;

            if (UOTData.Rows.Count > 1)
            {
                tbl_uotdata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_uotdata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_uotdata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_uotdata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }


        }
        private void StatusSnynchroniser_Click(object sender, EventArgs e)
        {
            SynchroniseInstatusandApprovedInstatus();
        }

        public void SynchroniseInstatusandApprovedInstatus()
        {
            for (int i = 0; i < tbl_uotdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_uotdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                   


                }
            }

        }

        private void adjustUOTWithLHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReduceLHfromUOT();
        }
        public void ReduceLHfromUOT()
        {
            for (int i = 0; i < tbl_uotdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_uotdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_uotdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_uotdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_uotdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_uotdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_uotdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_uotdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_uotdata.Rows[i].Cells["Invalue"].Value.ToString());

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

        private void rejectUOTWithoutActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rejectUOTwithoutAction();
        }


        /// <summary>
        /// rejects the UOt of a person without action
        /// </summary>
        public void rejectUOTwithoutAction()
        {
            for (int i = 0; i < tbl_uotdata.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_uotdata.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int swipedatid = int.Parse(tbl_uotdata.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_uotdata.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_uotdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_uotdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_uotdata.Rows[i].Cells["Shiftduration"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_uotdata.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_uotdata.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_uotdata.Rows[i].Cells["Invalue"].Value.ToString());

                    outime = outime.AddMinutes(-outvalue);

                    ApprOutstatus = "P";
                    tbl_uotdata.Rows[i].Cells["Outtime"].Value = outime;
                    tbl_uotdata.Rows[i].Cells["ApprOutStatus"].Value = ApprOutstatus;
                    outvalue = 0;



                    attndmngmnttrans.ResetStatuses(swipedatid, empid,
                 intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);
                    tbl_uotdata.Rows[i].Appearance.BackColor = Color.LemonChiffon;

                }
            }
        }




        # endregion


        # region Abscenties Action
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
                    abscentidata = employeeswipetable.Select("ApprOutstatus ='A' and ApprInstatus ='A'").CopyToDataTable();


                }
            }



            tbl_abscent.DataSource = abscentidata;

            if (abscentidata.Rows.Count > 1)
            {
                tbl_abscent.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_abscent.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_abscent.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_abscent.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }


        }

        private void synchronizeabscnet_Click(object sender, EventArgs e)
        {
            GetAbscentsynchrozized();
        }
        public void GetAbscentsynchrozized()
        {
            for (int i = 0; i < tbl_abscent.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_abscent.Rows[i].Cells[0].Value) == true)
                {
                    String instatus = tbl_abscent.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_abscent.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_abscent.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_abscent.Rows[i].Cells["empid"].Value.ToString());
                    if (instatus == "A" && Outstatus == "A")
                    {

                        if (DateTime.Parse(tbl_abscent.Rows[i].Cells["Intime"].Value.ToString()) >= DateTime.Parse(tbl_abscent.Rows[i].Cells["Outime"].Value.ToString()))
                        {
                            tbl_abscent.Rows[i].Cells["Outime"].Value = tbl_abscent.Rows[i].Cells["Intime"].Value;

                        }
                        else
                        {
                            tbl_abscent.Rows[i].Cells["Intime"].Value = tbl_abscent.Rows[i].Cells["Outtime"].Value;

                        }



                        DateTime intime = DateTime.Parse(tbl_abscent.Rows[i].Cells[9].Value.ToString());
                        DateTime outime = DateTime.Parse(tbl_abscent.Rows[i].Cells[10].Value.ToString());
                        attndmngmnttrans.ResestSwipeData(swipedatid, empid,
                            intime, outime, instatus, Outstatus);


                    }
                }
            }
        }





        # endregion




        # region Presenties Action

        public void gettpresentemployeedata()
        {
            DataTable presentemployee = actntrans.GetAllpresentEmployee(Program.LOCTNPK, dtp_datevalue.Value.Date);


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
                //tbl_presenties.Columns[1].Visible = false;
                //tbl_presenties.Columns[2].Visible = false;
                //tbl_presenties.Columns[22].Visible = false;
                //tbl_presenties.Columns[18].Visible = false;
                //tbl_presenties.Columns[15].Visible = false;
                //tbl_presenties.Columns[11].Visible = false;
                //tbl_presenties.Columns[12].Visible = false;
            }
        }

        /// <summary>
        /// get the actual shift in and outtime of all employee who had UOT
        /// </summary>
        public void fillShiftdataforPresenties()
        {
            for (int i = 0; i < tbl_presenties.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_presenties.Rows[i].Cells["Shiftpk"].Value.ToString()), DateTime.Parse(tbl_presenties.Rows[i].Cells["SwipeDate"].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_presenties.Rows[i].Cells["Shiftintime"].Value = shiftdata.Rows[0]["fromtime"].ToString();
                        tbl_presenties.Rows[i].Cells["Shiftoutime"].Value = shiftdata.Rows[0]["Totimetime"].ToString();
                        tbl_presenties.Rows[i].Cells["Shiftduration"].Value = shiftdata.Rows[0]["Duration"].ToString();
                        tbl_presenties.Rows[i].Cells["Shiftname"].Value = shiftdata.Rows[0]["Shiftname"].ToString();


                    }
                }





            }
        }



        /// <summary>
        /// synchronise the presentdata
        /// </summary>
        public void SynchronisePresnetEmployeedata()
        {

            for (int i = 0; i < tbl_presenties.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_presenties.Rows[i].Cells["Selecter"].Value) == true)
                {
                    if (int.Parse(tbl_presenties.Rows[i].Cells[21].Value.ToString()) < 0)
                    {
                        String instatus = tbl_presenties.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                        String Outstatus = tbl_presenties.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                        int swipedatid = int.Parse(tbl_presenties.Rows[i].Cells["Swipedataid"].Value.ToString());
                        int empid = int.Parse(tbl_presenties.Rows[i].Cells["empid"].Value.ToString());
                        if (instatus == "P" && Outstatus == "P")
                        {
                            DateTime intime = DateTime.Parse(tbl_presenties.Rows[i].Cells["Intime"].Value.ToString());
                            double sahiftduration = double.Parse(tbl_presenties.Rows[i].Cells["Shiftduration"].Value.ToString());
                            TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);
                            tbl_presenties.Rows[i].Cells["outime"].Value = intime.Add(t1);


                            intime = DateTime.Parse(tbl_presenties.Rows[i].Cells["Intime"].Value.ToString());
                            DateTime outime = DateTime.Parse(tbl_presenties.Rows[i].Cells["outime"].Value.ToString());
                            attndmngmnttrans.ResestSwipeData(swipedatid, empid,
                                intime, outime, instatus, Outstatus);
                        }


                    }

                }
            }
        }



        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            SynchronisePresnetEmployeedata();
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
                        String outstatus = dr["ApprOutstatus"].ToString().Trim();
                        String instatus = dr["ApprInstatus"].ToString().Trim();

                        if ((instatus == "A" && otandpresent.Contains(outstatus)) || (outstatus == "A" && otandpresent.Contains(instatus)))
                        {

                            onesideabscentdata.Rows.Add(dr.ItemArray);

                        }



                    }


                }
            }


            tbl_abscentononeside.DataSource = onesideabscentdata;

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
                tbl_abscentononeside.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_abscentononeside.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_abscentononeside.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_abscentononeside.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }
        }

        public void fillshiftdataforonesideAbscenties()
        {
            for (int i = 0; i < tbl_abscentononeside.Rows.Count - 1; i++)
            {
                DataTable shiftdata = ovrshfttrans.getShiftInandOutTimeOfADay(int.Parse(tbl_abscentononeside.Rows[i].Cells["ShiftPk"].Value.ToString()), DateTime.Parse(tbl_abscentononeside.Rows[i].Cells["SwipeDate"].Value.ToString()));

                if (shiftdata != null)
                {
                    if (shiftdata.Rows.Count != 0)
                    {

                        tbl_abscentononeside.Rows[i].Cells["Shiftintime"].Value = shiftdata.Rows[0]["fromtime"].ToString();
                        tbl_abscentononeside.Rows[i].Cells["Shiftoutime"].Value = shiftdata.Rows[0]["Totimetime"].ToString();
                        tbl_abscentononeside.Rows[i].Cells["Shiftduration"].Value = shiftdata.Rows[0]["Duration"].ToString();
                        tbl_abscentononeside.Rows[i].Cells["Shiftname"].Value = shiftdata.Rows[0]["ShiftName"].ToString();


                    }
                }





            }
        }


        private void markSwipeForOneSideAbscentiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleartheSwipetimeHalftimeAbscent();
        }
        /// <summary>
        /// mark the swipe of the  half day abscent
        /// </summary>
        public void cleartheSwipetimeHalftimeAbscent()
        {
            for (int i = 0; i < tbl_abscentononeside.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_abscentononeside.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String Apprinstatus = tbl_abscentononeside.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_abscentononeside.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_abscentononeside.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_abscentononeside.Rows[i].Cells["empid"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_abscentononeside.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_abscentononeside.Rows[i].Cells["Invalue"].Value.ToString());





                    DateTime shiftoutime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells["Shiftoutime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_abscentononeside.Rows[i].Cells["Shiftintime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_abscentononeside.Rows[i].Cells["Shiftduration"].Value.ToString());
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

                                        attndmngmnttrans.ResetStatuses(swipedatid, empid,
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

                                        attndmngmnttrans.ResetStatuses(swipedatid, empid,
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
                                    attndmngmnttrans.ResetStatuses(swipedatid, empid,
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
                                attndmngmnttrans.ResetStatuses(swipedatid, empid,
          intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue, Apprinstatus, ApprOutstatus);

                            }

                        }











                    }















                }






            }
        }

        # endregion



        # region LHData

        public void getLHData()
        {
            DataTable LHdatatable = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    try
                    {
                        LHdatatable = employeeswipetable.Select("ApprOutstatus ='LH' or ApprInstatus ='LH' ").CopyToDataTable();
                    }
                    catch (Exception)
                    {


                    }


                }
            }



            tbl_lhdata.DataSource = LHdatatable;

            if (LHdatatable.Rows.Count > 1)
            {
                tbl_lhdata.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_lhdata.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_lhdata.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_lhdata.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }


        }


        private void markAbscentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markAbscentonBothSideLH();
        }

        public void markAbscentonBothSideLH()
        {
            for (int i = 0; i < tbl_lhdata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_lhdata.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String instatus = tbl_lhdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_lhdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();


                    DateTime shiftoutime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Totimetime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Fromtime"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Intime"].Value.ToString());

                    if (instatus == "LH" && Outstatus == "LH")
                    {
                        tbl_lhdata.Rows[i].Cells["Intime"].Value = DateTime.Parse("01/01/2000 00:00:00");
                        tbl_lhdata.Rows[i].Cells["Outtime"].Value = DateTime.Parse("01/01/2000 00:00:00");
                        tbl_lhdata.Rows[i].Cells["ApprInstatus"].Value = "A";
                        tbl_lhdata.Rows[i].Cells["ApprOutstatus"].Value = "A";
                        tbl_lhdata.Rows[i].Cells["Invalue"].Value = "0";
                        tbl_lhdata.Rows[i].Cells["Outvalue"].Value = "0";
                        sendLHDataForUpdationwithvalue(i);


                    }

                }
            }

        }
        public void markPresentonBothSideLH()
        {
            for (int i = 0; i < tbl_lhdata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_lhdata.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String instatus = tbl_lhdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_lhdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();

                    DateTime shiftoutime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Totimetime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Fromtime"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Intime"].Value.ToString());

                    if (instatus == "LH" && Outstatus == "LH")
                    {
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);
                        double sahiftduration = double.Parse(tbl_lhdata.Rows[i].Cells["ShiftDuration"].Value.ToString());

                        TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);


                        tbl_lhdata.Rows[i].Cells["Intime"].Value = actualintime;
                        tbl_lhdata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                        tbl_lhdata.Rows[i].Cells["ApprInstatus"].Value = "P";
                        tbl_lhdata.Rows[i].Cells["ApprOutstatus"].Value = "P";
                        tbl_lhdata.Rows[i].Cells["Invalue"].Value = "0";
                        tbl_lhdata.Rows[i].Cells["Outvalue"].Value = "0";
                        sendLHDataForUpdationwithvalue(i);

                    }


                }
            }

        }

        public void markLHtoP()
        {
            for (int i = 0; i < tbl_lhdata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_lhdata.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String instatus = tbl_lhdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_lhdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();

                    DateTime shiftoutime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Totimetime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Fromtime"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Intime"].Value.ToString());
                    double sahiftduration = double.Parse(tbl_lhdata.Rows[i].Cells["ShiftDuration"].Value.ToString());
                    if (instatus == "LH" && Outstatus != "LH")
                    {
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);

                        tbl_lhdata.Rows[i].Cells["Intime"].Value = actualintime;
                        tbl_lhdata.Rows[i].Cells["ApprInstatus"].Value = "P";
                        tbl_lhdata.Rows[i].Cells["Invalue"].Value = "0";
                        sendLHDataForUpdationwithvalue(i);
                    }
                    else if ((instatus != "LH" && Outstatus == "LH"))
                    {
                        DateTime actualintime = new DateTime(intime.Year, intime.Month, intime.Day, shiftintime.Hour, shiftintime.Minute, shiftintime.Second);


                        TimeSpan t1 = new TimeSpan(0, int.Parse(sahiftduration.ToString()), 0);


                        tbl_lhdata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                        tbl_lhdata.Rows[i].Cells["ApprOutstatus"].Value = "P";
                        tbl_lhdata.Rows[i].Cells["Outvalue"].Value = "0";
                        sendLHDataForUpdationwithvalue(i);

                    }
                }
            }
        }

        public void sendLHDataForUpdationwithvalue(int i)
        {
            DateTime intime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Intime"].Value.ToString());
            DateTime outime = DateTime.Parse(tbl_lhdata.Rows[i].Cells["Outtime"].Value.ToString());
            int invalue = int.Parse(tbl_lhdata.Rows[i].Cells["Invalue"].Value.ToString());
            int outvalue = int.Parse(tbl_lhdata.Rows[i].Cells["Outvalue"].Value.ToString());
            int swipedatid = int.Parse(tbl_lhdata.Rows[i].Cells["Swipedataid"].Value.ToString());
            int empid = int.Parse(tbl_lhdata.Rows[i].Cells["empid"].Value.ToString());
            String instatus = tbl_lhdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
            String Outstatus = tbl_lhdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();


            attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
              intime, outime, instatus, Outstatus, invalue, outvalue);
            tbl_extrastatus.Rows[i].Appearance.BackColor = Color.RosyBrown;

        }

        private void synchroniseBothSideLHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markPresentonBothSideLH();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            markLHtoP();
        }

        private void tbl_lhdata_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug = sender as UltraGrid;

            ug.ActiveRow.Update();
            ug.PerformAction(UltraGridAction.ExitEditMode);
        }


        #endregion



        # region Extrastatus Action

        public void getExtrastatusData()
        {
            DataTable extrastatusdata = new DataTable();


            extrastatusdata = actntrans.GetSwipeemplyeesdetailforActionWithExtrastatus(Program.LOCTNPK, dtp_datevalue.Value.Date);


            tbl_extrastatus.DataSource = extrastatusdata;

            if (extrastatusdata.Rows.Count > 1)
            {
                tbl_extrastatus.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                tbl_extrastatus.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                // tbl_extrastatus.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                // tbl_extrastatus.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
            }


        }
        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            addtoOt();
        }
        private void removeExcessUOTWithTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveExcessUOTTime();
        }
        /// <summary>
        /// remove EXCESS UOt with change in outtime
        /// </summary>
        public void RemoveExcessUOTTime()
        {
            for (int i = 0; i < tbl_extrastatus.Rows.Count; i++)
            {


                if (Convert.ToBoolean(tbl_extrastatus.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String instatus = tbl_extrastatus.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_extrastatus.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_extrastatus.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_extrastatus.Rows[i].Cells["empid"].Value.ToString());
                    float OtValue = float.Parse(tbl_extrastatus.Rows[i].Cells["ExtraValue"].Value.ToString());
                    int extravalues = Convert.ToInt32(Math.Ceiling(OtValue));
                    DateTime intime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells["Outtime"].Value.ToString());
                    outime = outime.AddMinutes(-extravalues);
                    int outvalue = int.Parse(tbl_extrastatus.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_extrastatus.Rows[i].Cells["Invalue"].Value.ToString());
                    int extravalue = 0;
                    String extrastatus = "NA";

                    attndmngmnttrans.ResetSwipedataAndValueAndExtrastatus(swipedatid, empid,
                     intime, outime, instatus, Outstatus, invalue, outvalue, extravalue, extrastatus);

                    Actionlog.actiondone("Remove Excess UOT With time", "of employeeID " + empid + " for swipedatid " + swipedatid + "", empid);
                    tbl_extrastatus.Rows[i].Appearance.BackColor = Color.LightSalmon;
                }
            }
        }
        /// <summary>
        /// remove EXCESS UOt without change in outtime
        /// </summary>
        public void RemoveExcessUOT()
        {
            for (int i = 0; i < tbl_extrastatus.Rows.Count; i++)
            {


                if (Convert.ToBoolean(tbl_extrastatus.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String instatus = tbl_extrastatus.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_extrastatus.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_extrastatus.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_extrastatus.Rows[i].Cells["empid"].Value.ToString());

                    DateTime intime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_extrastatus.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_extrastatus.Rows[i].Cells["Invalue"].Value.ToString());
                    int extravalue = 0;
                    String extrastatus = "NA";

                    attndmngmnttrans.ResetSwipedataAndValueAndExtrastatus(swipedatid, empid,
                     intime, outime, instatus, Outstatus, invalue, outvalue, extravalue, extrastatus);
                    Actionlog.actiondone("Remove Excess UOT Without timeChange", "of employeeID " + empid + " for swipedatid " + swipedatid + "", empid);
                    tbl_extrastatus.Rows[i].Appearance.BackColor = Color.LightSalmon;
                }
            }
        }
        //Add Excess UOT as OT
        public void addtoOt()
        {
            for (int i = 0; i < tbl_extrastatus.Rows.Count; i++)
            {


                if (Convert.ToBoolean(tbl_extrastatus.Rows[i].Cells["Selecter"].Value) == true)
                {

                    String instatus = tbl_extrastatus.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_extrastatus.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_extrastatus.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_extrastatus.Rows[i].Cells["empid"].Value.ToString());

                    float OtValue = float.Parse(tbl_extrastatus.Rows[i].Cells["ExtraValue"].Value.ToString());


                    int extravalues = Convert.ToInt32(Math.Ceiling(OtValue));


                    DateTime intime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_extrastatus.Rows[i].Cells["Outtime"].Value.ToString());
                    int outvalue = int.Parse(tbl_extrastatus.Rows[i].Cells["Outvalue"].Value.ToString());
                    int invalue = int.Parse(tbl_extrastatus.Rows[i].Cells["Invalue"].Value.ToString());
                    int extravalue = 0;
                    String extrastatus = "NA";
                    outvalue = outvalue + extravalues;
                    //added the entered number to the existing oT value in 0utvalue
                    tbl_extrastatus.Rows[i].Cells["Outvalue"].Value = outvalue;


                    // added the ot minutes to the intime 
                    //    outime = outime.AddMinutes(OtValue);

                    tbl_extrastatus.Rows[i].Cells["Outtime"].Value = outime;



                    attndmngmnttrans.ResetSwipedataAndValueAndExtrastatus(swipedatid, empid,
                      intime, outime, instatus, Outstatus, invalue, outvalue, extravalue, extrastatus);
                    Actionlog.actiondone("Added Excess UOT Without time", "of employeeID " + empid + " for swipedatid " + swipedatid + "", empid);
                    tbl_extrastatus.Rows[i].Appearance.BackColor = Color.Turquoise;
                }
            }
        }

        private void tbl_extrastatus_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug = sender as UltraGrid;

            ug.ActiveRow.Update();
            ug.PerformAction(UltraGridAction.ExitEditMode);

        }

        private void removeExcessUOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveExcessUOT();
        }


        # endregion









        # region OffDay Action

        public void GetOffdata()
        {
            DataTable results = new DataTable();

            if (employeeswipetable != null)
            {
                if (employeeswipetable.Rows.Count != 0)
                {
                    try
                    {
                        if (lbl_daystatus.Text != "Working Day")
                        {
                            results = employeeswipetable.Select().CopyToDataTable();
                        }
                        else
                        {
                            results = employeeswipetable.Select("Daystatus ='Off Day'").CopyToDataTable();
                        }
                    }
                    catch (Exception)
                    {


                    }
                }

                tbl_offday.DataSource = results;
                if (tbl_offday.Rows.Count > 0)
                {
                    tbl_offday.DisplayLayout.Bands[0].Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_offday.DisplayLayout.Bands[0].Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_offday.DisplayLayout.Bands[0].Columns["Totimetime"].Format = "dd/MM/yyyy HH:mm:ss";
                    tbl_offday.DisplayLayout.Bands[0].Columns["fromtime"].Format = "dd/MM/yyyy HH:mm:ss";
                }
            }


        }
        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            RemoveUPLandPL();
        }
        public void RemoveUPLandPL()
        {
            for (int i = 0; i < tbl_offday.Rows.Count; i++)
            {


                if (Convert.ToBoolean(tbl_offday.Rows[i].Cells["Selecter"].Value) == true)
                {
                    String instatus = tbl_offday.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String Outstatus = tbl_offday.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    int swipedatid = int.Parse(tbl_offday.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_offday.Rows[i].Cells["empid"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_offday.Rows[i].Cells["Intime"].Value.ToString());
                    DateTime outime = DateTime.Parse(tbl_offday.Rows[i].Cells["Outtime"].Value.ToString());
                    DateTime Swipedate = DateTime.Parse(tbl_offday.Rows[i].Cells["SwipeDate"].Value.ToString());
                    if ((instatus == "UPL" && Outstatus == "UPL") || (instatus == "PL" && Outstatus == "PL"))
                    {
                        attndmngmnttrans.ResestSwipeData(swipedatid, empid,
                                intime, outime, "A", "A");
                        attndmngmnttrans.setLeavetoAbscent(empid, Swipedate, instatus);
                    }


                    Actionlog.actiondone("Removed UPL/PL from off days", "of employeeID " + empid + " for swipedatid " + swipedatid + "", empid);


                }
            }
        }





        /// <summary>
        /// Add  swipe record for OF OT
        /// user will enter the Swipe in time and OTMinutesa
        /// </summary>
        public void AddSwipeForOFFOTofHoliday()
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


            for (int i = 0; i < tbl_offday.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_offday.Rows[i].Cells[0].Value) == true)
                {


                    int swipedatid = int.Parse(tbl_offday.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_offday.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_offday.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_offday.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime shiftoutime = DateTime.Parse(tbl_offday.Rows[i].Cells["Totimetime"].Value.ToString());
                    DateTime shiftintime = DateTime.Parse(tbl_offday.Rows[i].Cells["fromtime"].Value.ToString());

                    double sahiftduration = double.Parse(tbl_offday.Rows[i].Cells["Shiftduration"].Value.ToString());




                    DateTime outime = intime.AddMinutes(offotvalue);
                    DateTime correctedintime = randomtimecreator(intime, intime.AddMinutes(-20));
                    DateTime correctedoutime = randomtimecreator(outime, outime.AddMinutes(10));

                    tbl_offday.Rows[i].Cells["Intime"].Value = correctedintime;
                    tbl_offday.Rows[i].Cells["Outtime"].Value = correctedoutime;
                    tbl_offday.Rows[i].Cells["ApprOutStatus"].Value = "OT2.0";

                    ApprOutstatus = "OT2.0";



                    int invalue = int.Parse(tbl_offday.Rows[i].Cells["Invalue"].Value.ToString());
                    int outvalue = offotvalue;

                    attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                      intime, outime, Apprinstatus, ApprOutstatus, invalue, outvalue);

                    tbl_offday.Rows[i].Appearance.BackColor = Color.CornflowerBlue;

                }
            }

        }

        private void markOT20WithoutChangingSwipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkOt2withExistingDuration();
        }
        /// <summary>
        /// mark ot2.0 without changing the swipe
        /// use duration as outvalue
        /// </summary>
        public void MarkOt2withExistingDuration()
        {
            String[] Allowedlabels = { "P", "LH", "OT2.0", "OT1.5", "UOT" };
            

            for (int i = 0; i < tbl_offday.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_offday.Rows[i].Cells[0].Value) == true)
                {


                    int swipedatid = int.Parse(tbl_offday.Rows[i].Cells["Swipedataid"].Value.ToString());
                    int empid = int.Parse(tbl_offday.Rows[i].Cells["empid"].Value.ToString());
                    String Apprinstatus = tbl_offday.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                    String ApprOutstatus = tbl_offday.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                    DateTime outtime = DateTime.Parse(tbl_offday.Rows[i].Cells["Outtime"].Value.ToString());
                    DateTime intime = DateTime.Parse(tbl_offday.Rows[i].Cells["Intime"].Value.ToString());

                    int  duration = int.Parse(tbl_offday.Rows[i].Cells["duration"].Value.ToString());



                    if (Allowedlabels.Contains(Apprinstatus) && Allowedlabels.Contains(Apprinstatus))
                    {

                        tbl_offday.Rows[i].Cells["ApprOutStatus"].Value = "OT2.0";

                        ApprOutstatus = "OT2.0";



                        int invalue = int.Parse(tbl_offday.Rows[i].Cells["Invalue"].Value.ToString());

                        duration = CropTheValueasperRule(duration);
                        attndmngmnttrans.ResetSwipedataAndValue(swipedatid, empid,
                          intime, outtime, Apprinstatus, ApprOutstatus, invalue, duration);

                        tbl_offday.Rows[i].Appearance.BackColor = Color.CornflowerBlue;
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




        private void markOT20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSwipeForOFFOTofHoliday();
        }

        #endregion

        private void oT20ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_OT)
            {
                selectAllclicked(tbl_otdata);
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            matchOutValueWithSwipe();
        }

        private void tbl_otdata_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug = sender as UltraGrid;

            ug.ActiveRow.Update();
            ug.PerformAction(UltraGridAction.ExitEditMode);
        }






        public void selectAllclicked(UltraGrid  tbl_grid)
        {
            if (cmb_checkAll.Checked == true)
            {
                for (int i = 0; i < tbl_grid.Rows.Count; i++)
                {
                    tbl_grid.Rows[i].Cells["Selecter"].Value = true;
                }

            }
            else
            {
                for (int i = 0; i < tbl_grid.Rows.Count; i++)
                {
                    tbl_grid.Rows[i].Cells["Selecter"].Value = false;
                }
            }
        }





    }
}

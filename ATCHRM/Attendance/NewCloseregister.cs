using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Attendance
{
    public partial class NewCloseregister : Form
    {
        Datalayer.AdjusterDatabean adjstbean = null;
        Transactions.Adjuster.AdjusterTranscation adjstrtrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.Adjuster.OtRulerTransaction ottrans = null;
        Transactions.AttendanceManagementTransaction atndncemngmnt = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DataExporter DTPEXPTR = null;
        Transactions.HolidayTransaction hldytransaction = null;
        int lctnflag = 0;

        public NewCloseregister()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            cmptransaction = new Transactions.CompanyBranchTransactions();
            ottrans = new Transactions.Adjuster.OtRulerTransaction();
            atndncemngmnt = new Transactions.AttendanceManagementTransaction();
            hldytransaction = new Transactions.HolidayTransaction();
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

            //   cmb_location.SelectedValue = Program.LOCTNPK;
        }
      

      
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (cmb_location.Text.Trim() != "")
            {
                checkWhetheroffday();
                adddata();
                btn_approval.Enabled = true;
            }
        }
    


     

        # region display
        private void adddata()
        {
          

            DataTable dt = ottrans.Getdataforcloseregister(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date);
        // dt = dt.Select("empid=7123").CopyToDataTable();

            foreach (DataColumn clm in dt.Columns)
            {
                clm.ReadOnly = false;
            }
            tbl_DailyTime.DataSource = dt;
         
            int totalentry = dt.Rows.Count;
            int numberofclosed = dt.Select("IsCompleted = 'Y'").Length;
            int numberofopen = dt.Select("IsCompleted = 'N'").Length;
            lbl_total.Text = totalentry.ToString();
            lbl_closed.Text = numberofclosed.ToString();
            lbl_pending.Text = numberofopen.ToString();
            
           
            iterator();
           
        }
        public void checkWhetheroffday()
        {
            try
            {

                lbl_day.Text = dtp_from.Value.Date.DayOfWeek.ToString(); ;


                DataTable dt = hldytransaction.getAnyHolidayofaDate(dtp_from.Value.Date, int.Parse(cmb_location.SelectedValue.ToString()));

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
            catch (Exception exp)
            {


                ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);

            }
        }
        public void iterator()
        {

            for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
            {
                //DataTable dt1 = atndncemngmnt.getAllOTApllicationOfaDateandEmployee(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));
                //DataTable dt2 = atndncemngmnt.getAlLlhrOfaDateandEmployee(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));
                //DataTable dt3 = atndncemngmnt.getLeaveOfaDateandEmployee(DateTime.Parse(dtp_from.Value.Date.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));

                //if (dt1.Rows.Count != 0)
                //{
                //    tbl_DailyTime.Rows[i].Cells["ApprovedOT"].Value = dt1.Rows[0][2].ToString();
                //}
                //else
                //{
                //    tbl_DailyTime.Rows[i].Cells["ApprovedOT"].Value = 0;
                //}
                //if (dt2.Rows.Count != 0)
                //{
                //    tbl_DailyTime.Rows[i].Cells["ApprovedLHR"].Value = dt2.Rows[0][0].ToString();
                //}
                //else
                //{
                //    tbl_DailyTime.Rows[i].Cells["ApprovedLHR"].Value = 0;
                //}
                //if (dt3.Rows.Count != 0)
                //{
                //    tbl_DailyTime.Rows[i].Cells["ApprovedLeave"].Value = dt3.Rows[0][0].ToString();
                //}
                //else
                //{
                //    tbl_DailyTime.Rows[i].Cells["ApprovedLeave"].Value = "N";
                //}

                try
                {

                 //  dateadjuster(i);
                    AdjustTerminology(i);
                    adjustEarlySwipe(i);
                    OTapplyaction(i);
                    LHRapplyaction(i);
                    LeaveAction(i);
                    checkotrule(i);
                    CropExtravalueagain(i);
                }
                catch (Exception exp)
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                    ErrorLogger er = new ErrorLogger();

                    er.createErrorLog(exp);
                }


            }

            // the code that you want to measure comes here
            offDayCalculator();


        }



      

        public void AdjustTerminology(int i)
        {

            // IN STATUS

            if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Consider it LH")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "LH";
            }
            else if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Adjust Swipe")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "Early";
            }
            else if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Consider it UOT")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "UOT";
            }
            else if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Consider It as LH")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "LH";
            }
            else if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Consider it as LH")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "LH";
            }
            else if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Consider It As UOT")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "UOT";
            }

            else if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Out UOT")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "UOT";
            }
            else if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "")
            {
                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "A";
            }

            //out status
            if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "Consider it LH")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "LH";
            }
            else if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "Adjust Swipe")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "Early";
            }
            else if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "Consider it UOT")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "UOT";
            }
            else if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "Consider It as LH")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "LH";
            }
            else if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "Consider It As UOT")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "UOT";
            }
            else if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "Out UOT")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "UOT";
            }
            else if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "Consider it as LH")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "LH";
            }
            else if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "")
            {
                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "A";
            }



            if (tbl_DailyTime.Rows[i].Cells["Duration"].Value.ToString().Trim() == "")
            {
                tbl_DailyTime.Rows[i].Cells["Duration"].Value = "00:00:00";
            }
            if (tbl_DailyTime.Rows[i].Cells["Invalue"].Value.ToString().Trim() == "")
            {
                tbl_DailyTime.Rows[i].Cells["Invalue"].Value = "0";
            } if (tbl_DailyTime.Rows[i].Cells["OutValue"].Value.ToString().Trim() == "")
            {
                tbl_DailyTime.Rows[i].Cells["OutValue"].Value = "0";
            }



            if (tbl_DailyTime.Rows[i].Cells["ShiftPK"].Value.ToString().Trim() == "0")
            {
                tbl_DailyTime.Rows[i].Cells["ShiftPK"].Value = atndncemngmnt.getemployeeshift(int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString())).ToString();
            }







        }
        public void adjustEarlySwipe(int i)
        {

            if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "Early" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "EARLY")
            {
                DateTime allowedduration = (DateTime.Parse(tbl_DailyTime.Rows[i].Cells["FromTime"].Value.ToString()));
                //      DateTime allowedduration = Shifttime.AddMinutes(-30);

                DateTime Shifttime = allowedduration.AddMinutes(-30);
                TimeSpan timeSpan = allowedduration - Shifttime;
                var randomTest = new Random();
                TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                DateTime newadjstedtime = allowedduration - newSpan;



                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "P";

                tbl_DailyTime.Rows[i].Cells["Swipin"].Value = newadjstedtime.ToString("hh:mm");

                tbl_DailyTime.Rows[i].Cells["Invalue"].Value = 0;




            }


        }

        public void OTapplyaction(int i)
        {


            if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "UOT")
            {
                if (int.Parse(tbl_DailyTime.Rows[i].Cells["ApprovedOT"].Value.ToString().Trim()) != 0)
                {
                    int otdone = int.Parse(tbl_DailyTime.Rows[i].Cells["OutValue"].Value.ToString().Trim());
                    int approvedot = int.Parse(tbl_DailyTime.Rows[i].Cells["ApprovedOT"].Value.ToString().Trim());

                    // IF THE EMPLOYEE DOES WORK LESSER THAN THE APPROVED OT 
                    //THEN HIS WORK LH REMAINING TIME IS MARKED AS UUOT

                    if (approvedot >= otdone)
                    {

                        int balance = approvedot - otdone;

                        if (balance != 0)
                        {
                            tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value = balance;
                            tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value = "UUOT";
                        }
                    }
                    //IF THE EMPLOYEE WORKED MORE THAN THE APPROVED OT
                    ///THEN HIS EXTRA TIME WILL GO FOR THE  UOT
                    else
                    {
                        int extra = otdone - approvedot;
                        //  otdone = approvedot;
                        tbl_DailyTime.Rows[i].Cells["OutValue"].Value = approvedot;
                        if (extra != 0)
                        {
                            tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value = extra;
                            tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value = "UOT";
                        }
                    }
                    tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "OT1.5";
                }


            }












        }

        public void LHRapplyaction(int i)
        {



            if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "UOT")
            {
                if (int.Parse(tbl_DailyTime.Rows[i].Cells["ApprovedLHR"].Value.ToString().Trim()) != 0)
                {

                    int uotdone = int.Parse(tbl_DailyTime.Rows[i].Cells["OutValue"].Value.ToString().Trim());
                    int approvedlhr = int.Parse(tbl_DailyTime.Rows[i].Cells["ApprovedLHR"].Value.ToString().Trim());

                    if (uotdone > approvedlhr)
                    {

                        int extra = uotdone - approvedlhr;

                        if (extra != 0)
                        {
                            tbl_DailyTime.Rows[i].Cells["OutValue"].Value = approvedlhr;
                            tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value = extra;
                            tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value = "UOT";
                        }
                    }
                    else
                    {
                        int balance = approvedlhr - uotdone;
                        if (balance != 0)
                        {
                            tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value = balance;
                            tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value = "ULHR";

                        }
                    }
                    tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "LHR";
                }
            }







        }

        /// <summary>
        /// adjust the datetime feilds
        /// </summary>
        /// <param name="i"></param>
        public void dateadjuster(int i)
        {
            string sg = Convert.ToDateTime(tbl_DailyTime.Rows[i].Cells["Date"].Value).ToString("dd-MMM-yyyy");
            if (sg == "01-Jan-1900")
            {
                tbl_DailyTime.Rows[i].Cells["Date"].Value = sg;
                tbl_DailyTime.Rows[i].Cells["Swipin"].Value = "00:00:00";
                tbl_DailyTime.Rows[i].Cells["SwipeOut"].Value = "00:00:00";
                tbl_DailyTime.Rows[i].Cells["FromTime"].Value = "00:00:00";
                tbl_DailyTime.Rows[i].Cells["ToTime"].Value = "00:00:00";
            }
            else
            {
                tbl_DailyTime.Rows[i].Cells["Date"].Value = DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()).ToString("dd/MM/yyyy");
                tbl_DailyTime.Rows[i].Cells["FromTime"].Value = DateTime.Parse(tbl_DailyTime.Rows[i].Cells["FromTime"].Value.ToString()).ToString("HH:mm:ss");
                tbl_DailyTime.Rows[i].Cells["ToTime"].Value = DateTime.Parse(tbl_DailyTime.Rows[i].Cells["ToTime"].Value.ToString()).ToString("HH:mm:ss");

            }

        }
        /// <summary>
        ///  IF THE EMPLOYEE HAD A LEAVE APPROVED ON THAT DAY
        /// </summary>
        public void LeaveAction(int i)
        {

            if (tbl_DailyTime.Rows[i].Cells["ApprovedLeave"].Value.ToString().Trim() != "N")
            {

                if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "A")
                {

                    tbl_DailyTime.Rows[i].Cells["InStatus"].Value = tbl_DailyTime.Rows[i].Cells["ApprovedLeave"].Value;

                }
                if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "A")
                {

                    tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = tbl_DailyTime.Rows[i].Cells["ApprovedLeave"].Value;

                }
               tbl_DailyTime.Rows[i]. DefaultCellStyle.BackColor = Color.Red;
            }


        }

        /// <summary>
        /// change all the off day Present to ot1.5
        /// </summary>
        public void offDayCalculator()
        {
            //  Boolean offday=false ;
            try
            {
                //if not normal working day for the factory
                if (lbl_daystatus.Text != "Working Day")
                {
                    //if weekly off day
                    if (lbl_daystatus.Text == "WEEKLY OFF")
                    {

                        for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                        {


                            if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT1.5")
                            {
                                if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString().Trim())))
                                {
                                    //    offday=true;
                                    tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "OT2.0";
                                    tbl_DailyTime.Rows[i].Cells["DayStatus"].Value = "Off Day";
                                    //  ATCHRM.Controls.ATCHRMMessagebox.Show(offday.ToString ());
                                }



                            }
                            if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT1.5")
                            {
                                if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString().Trim())))
                                {

                                    tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "OT2.0";
                                    tbl_DailyTime.Rows[i].Cells["DayStatus"].Value = "Off Day";
                                }

                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {


                        if (tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT1.5")
                        {
                            if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString().Trim())))
                            {
                                //    offday=true;
                                tbl_DailyTime.Rows[i].Cells["InStatus"].Value = "OT2.0";
                                //  ATCHRM.Controls.ATCHRMMessagebox.Show(offday.ToString ());
                            }



                        }
                        if (tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "LH" || tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "UOT" || tbl_DailyTime.Rows[i].Cells["Outstatus"].Value.ToString().Trim() == "P" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT" || tbl_DailyTime.Rows[i].Cells["InStatus"].Value.ToString().Trim() == "OT1.5")
                        {
                            if (atndncemngmnt.CheckWhetherEmployeeOFFday(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString().Trim())))
                            {

                                tbl_DailyTime.Rows[i].Cells["Outstatus"].Value = "OT2.0";
                            }

                        }
                    }
                }
            }
            catch (Exception exp)
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
        }




# endregion


        # region close register


        private void closeregister()
        {
            if (isdateaccesible(Program.Datetoday, dtp_from.Value.Date))
            {
                if (dtp_from .Value.Date != Program.Datetoday.Date)
                {
                    
                    if (dtp_from.Value.Date == Program.Datetoday.Date)
                    {
                        ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Close the Register For the Same Day");
                    }
                    else if (dtp_from.Value.Date > Program.Datetoday.Date)
                    {
                        ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Close the Register for Future Day");
                    }
                    else
                    {
                        DataTable dt=getdataforclosing();

                        ottrans.closeDataRegister(dt ,dtp_from.Value.Date);
                        ottrans.EmployeeSwipeBankEnter(dt);
                        ottrans.EmployyeLeaveTakenUpdate (dtp_from.Value.Date,dt);
                        offdayDataentry();
                        markDateclosed();
                        MessageBox.Show("Done");
                    }


                   

                }
                else
                {

                    ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Close the Register For the Same Day");
                }

            }
            else
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show("You chose not to Closeregister");
            }


        }


        public void markDateclosed()
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
            CloseRegisterRecord_tbl clstbl = new CloseRegisterRecord_tbl();
            clstbl.BranchlctnPK = int.Parse(cmb_location.SelectedValue.ToString());
            clstbl.CloseRegisterDate = dtp_from.Value.Date;
            clstbl.DoneBy = Program.USERPK;
            clstbl.AddedDate = DateTime.Now;
            clstbl.NoofEmployee = int.Parse(lbl_pending.Text);
            cntxt.CloseRegisterRecord_tbls.InsertOnSubmit(clstbl);
            cntxt.SubmitChanges(); 

        }
        /// <summary>
        /// check whether the date is Acessible
        /// </summary>
        /// <param name="actualdate"></param>
        /// <param name="selecteddate"></param>
        /// <returns></returns>
        public Boolean isdateaccesible(DateTime actualdate, DateTime selecteddate)
        {
            Boolean issuccess = true;

            try
            {
                DateTime backlimit = actualdate.AddDays(-3);

                DateTime uplimit = actualdate;

                SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);

                var asd = (from closeddata in cntxt.CloseRegisterRecord_tbls
                           where closeddata.BranchlctnPK == int.Parse(cmb_location.SelectedValue.ToString())
                           orderby closeddata.CloseRegisterDate descending
                           select closeddata).FirstOrDefault();

                DateTime Lstdateclosed = DateTime.Parse(asd.CloseRegisterDate.ToString());
                if (selecteddate < Lstdateclosed)
                {
                    DialogResult result = MessageBox.Show("Do you want to Close Register A Date Previous to last close Register Date?", "Last Close Registered Date is '" + Lstdateclosed.ToString("dd/MM/yyyy") + "'",
            MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        issuccess = true;
                    }
                    else
                    {
                        issuccess = false;
                    }
                }
                else if (Lstdateclosed < selecteddate)
                {
                    double daydifference = ((selecteddate - Lstdateclosed).TotalDays);

                    if (daydifference > 1)
                    {
                        DialogResult result = MessageBox.Show("Do you want to Skip " + daydifference.ToString() + "  Days And Close Register " + selecteddate.ToString("dd/MM/yyyy") + " ?", "Last Close Registered Date is '" + Lstdateclosed.ToString("dd/MM/yyyy") + "'",
            MessageBoxButtons.OKCancel);

                        if (result == DialogResult.OK)
                        {
                            issuccess = true;
                        }
                        else
                        {
                            issuccess = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                
               
            }
            return issuccess;
        }

        private void btn_approval_Click(object sender, EventArgs e)
        {
            closeregister();
        }
        public void offdayDataentry()
        {
            try
            {

                # region commented by sreenath on 20052015
                //                if (lbl_daystatus.Text == "WEEKLY OFF")
//                {

//                    # region OFFDAYFORCOMPANY
//                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
//                    {
//                        if (tbl_DailyTime.Rows[i].Cells[22].Value.ToString().Trim() == "Off Day")
//                        {
//                            if (tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT2.0" && tbl_DailyTime.Rows[i].Cells[10].Value.ToString().Trim() == "OT2.0")
//                            {


//                                ArrayList emparrylst = new ArrayList();
//                                emparrylst.Add(int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));
//                                emparrylst.Add(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()));                             

//                                double duration = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes;
//                                int myduration = int.Parse(Math.Truncate(duration).ToString());

//                                emparrylst.Add(myduration);                             
//                                atndncemngmnt.insertEmployeeOffOvertime(emparrylst);
//                            }
//                        }
//                    }

//#endregion
//                }
//                else if (lbl_daystatus.Text == "Working Day")
//                {
//                    # region working day for company
//                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
//                    {

//                        // IF IT IS WEEKLY OF FOR COMPANY AND OFF DAY FOR THE EMPLOYEE HE WILL GET A OT2.0
//                        if (tbl_DailyTime.Rows[i].Cells[22].Value.ToString().Trim() == "Off Day")
//                        {
//                            ArrayList emparrylst = new ArrayList();
//                            emparrylst.Add(int.Parse(tbl_DailyTime.Rows[i].Cells[0].Value.ToString()));

//                            emparrylst.Add(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[5].Value.ToString()));

//                            //     emparrylst.Add(  DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString ());

//                            double duration = DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes;
//                            int myduration = int.Parse(Math.Truncate(duration).ToString());

//                            emparrylst.Add(myduration);

//                            // ATCHRM.Controls.ATCHRMMessagebox.Show(DateTime.Parse(tbl_DailyTime.Rows[i].Cells[12].Value.ToString()).TimeOfDay.TotalMinutes.ToString());
//                            atndncemngmnt.insertEmployeeOffOvertime(emparrylst);

//                        }

//                    }
//                    # endregion
//                }
# endregion
                if (lbl_daystatus.Text == "WEEKLY OFF" || lbl_daystatus.Text == "Working Day")
                {
                     for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                     {
                         //if weekday for employee
                         if (tbl_DailyTime.Rows[i].Cells["DayStatus"].Value.ToString().Trim() == "Off Day")
                         {
                             if (tbl_DailyTime.Rows[i].Cells["Instatus"].Value.ToString().Trim() == "OT2.0" || tbl_DailyTime.Rows[i].Cells["OutStatus"].Value.ToString().Trim() == "OT2.0")
                           {
                             ArrayList emparrylst = new ArrayList();
                             emparrylst.Add(int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));
                             emparrylst.Add(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()));

                             double duration = DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Duration"].Value.ToString()).TimeOfDay.TotalMinutes;
                             int myduration = int.Parse(Math.Truncate(duration).ToString());

                             emparrylst.Add(myduration);

                             
                             atndncemngmnt.insertEmployeeOffOvertime(emparrylst);
                      }
                         }

                     }

                }
                else
                {
                    # region Holidayforoffice

                    for (int i = 0; i < tbl_DailyTime.Rows.Count - 1; i++)
                    {
                        if (tbl_DailyTime.Rows[i].Cells["Instatus"].Value.ToString().Trim() == "OT2.0" || tbl_DailyTime.Rows[i].Cells["OutStatus"].Value.ToString().Trim() == "OT2.0")
                        {
                            ArrayList emparrylst = new ArrayList();
                            emparrylst.Add(int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));

                            emparrylst.Add(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Date"].Value.ToString()));

                            double duration = DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Duration"].Value.ToString()).TimeOfDay.TotalMinutes;
                            int myduration = int.Parse(Math.Truncate(duration).ToString());
                            emparrylst.Add(myduration);                            
                            atndncemngmnt.insertEmployeeOffOvertime(emparrylst);
                        }



                    }
                    # endregion
                }
            }
            catch (Exception exp)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);

            }


        }


        public DataTable  getdataforclosing()
        {

            DataTable dummyswipeTable = (DataTable)(tbl_DailyTime.DataSource);
            dummyswipeTable.Columns.Remove("First_Name");
            dummyswipeTable.Columns.Remove("Last_Name");
            dummyswipeTable.Columns.Remove("DesignationName");
            dummyswipeTable.Columns.Remove("DepartmentName");
            dummyswipeTable.Columns.Remove("deviceid");
            dummyswipeTable.Columns.Remove("Status");
            dummyswipeTable.Columns.Remove("oldempid");
            dummyswipeTable.Columns.Remove("SubDeptName");
            DataTable swipedata = dummyswipeTable.Select("IsCompleted='N'").CopyToDataTable();

            return swipedata;
        }



#endregion


        # region OTrule


        public void checkotrule(int i)
        {
            OTRuleAction(i);
            UOTRuleAction(i);
        }
        public void CropExtravalueagain(int i)
        {
            if (tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value.ToString().Trim() == "UOT")
            {

                int outextravalue = int.Parse(tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value.ToString());
                if (outextravalue > 0)
                {
                    outextravalue = CropTheValueasperRule(outextravalue);
                    if (outextravalue <= 0)
                    {
                        tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value = "NA";
                    }
                    tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value = outextravalue;
                }
            }

        }

        public void OTRuleAction(int i)
        {
            if (tbl_DailyTime.Rows[i].Cells["outstatus"].Value.ToString().Trim() == "OT1.5")
            {
                int newoutvalue=0;
                int outvalue = int.Parse(tbl_DailyTime.Rows[i].Cells["Outvalue"].Value.ToString());
                if (tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value.ToString().Trim() == "UOT")
                {
                   
                    int outextravalue = int.Parse(tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value.ToString());
                    
                    if (tbl_DailyTime.Rows[i].Cells["instatus"].Value.ToString().Trim() == "LH")
                    {
                        int lhinvalue = int.Parse(tbl_DailyTime.Rows[i].Cells["Invalue"].Value.ToString());
                       
                        if((outvalue+outextravalue)>lhinvalue )
                        {
                            if(outextravalue>=lhinvalue )
                            {
                                //if extrastatus is greater than LH value reduce it from the extra value and update and if extra value now is zero mark extra status as NA
                                outextravalue = outextravalue - lhinvalue;
                                tbl_DailyTime.Rows[i].Cells["Invalue"].Value = 0;

                                outextravalue = CropTheValueasperRule(outextravalue);
                                if (outextravalue <= 0)
                                {
                                    tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value = "NA";
                                }
                                tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value = outextravalue;
                                tbl_DailyTime.Rows[i].Cells["outstatus"].Style.BackColor = System.Drawing.Color.Red ;
                            }
                            else if (lhinvalue > outextravalue)
                            {
                            //    if lh value is greater than the extavalue  then subtract extravalue first  with lh value and the remaining of LH value should be subtracted from Outvalue

                                int tempextra = outextravalue;
                                outextravalue = 0;
                                lhinvalue = lhinvalue - tempextra;
                                outvalue = outvalue - lhinvalue;
                                lhinvalue = lhinvalue - lhinvalue;
                                tbl_DailyTime.Rows[i].Cells["Invalue"].Value = 0;
                                tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value = 0;
                                tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value = "NA";
                                newoutvalue = CropTheValueasperRule(outvalue);
                                if (newoutvalue <= 0)
                                {
                                    tbl_DailyTime.Rows[i].Cells["outstatus"].Value = "P";
                                    tbl_DailyTime.Rows[i].Cells["outstatus"].Style.BackColor = System.Drawing.Color.Green;
                                }
                            }

                        }


                       
                    }

                }
                    // if no extraUot
                else
                {
                    //if no excess value is there and if lh value less than the ot value reduce the OT
                    if (tbl_DailyTime.Rows[i].Cells["instatus"].Value.ToString().Trim() == "LH")
                    {
                         int lhinvalue = int.Parse(tbl_DailyTime.Rows[i].Cells["Invalue"].Value.ToString());
                    if(outvalue>lhinvalue)
                    {
                        outvalue = outvalue - lhinvalue;
                        tbl_DailyTime.Rows[i].Cells["Invalue"].Value = 0;
                    }
                    
                    }
                    newoutvalue = CropTheValueasperRule(outvalue);
                  

                    tbl_DailyTime.Rows[i].Cells["Outvalue"].Value = newoutvalue;
                    //if the new cropped value is equal to 0 
                    if (newoutvalue <= 0)
                    {
                        tbl_DailyTime.Rows[i].Cells["outstatus"].Value = "P";
                        tbl_DailyTime.Rows[i].Cells["outstatus"].Style.BackColor = System.Drawing.Color.Green ;
                    }
                }

            }
        }

        public void UOTRuleAction(int i)
        {
            if (tbl_DailyTime.Rows[i].Cells["outstatus"].Value.ToString().Trim() == "UOT")
            {
                int outvalue = int.Parse(tbl_DailyTime.Rows[i].Cells["Outvalue"].Value.ToString());
                int newoutvalue = 0;

                if (tbl_DailyTime.Rows[i].Cells["instatus"].Value.ToString().Trim() == "LH")
                {
                    int lhinvalue = int.Parse(tbl_DailyTime.Rows[i].Cells["Invalue"].Value.ToString());
                    //if lh value is less than the outvalue reduce it for Outvalue and make lh value zero
                    if (lhinvalue < outvalue)
                    {
                        outvalue = outvalue - lhinvalue;
                        tbl_DailyTime.Rows[i].Cells["Invalue"].Value = 0;
                    }
                }


                newoutvalue = CropTheValueasperRule(outvalue);

                tbl_DailyTime.Rows[i].Cells["Outvalue"].Value = newoutvalue;
                //if the new cropped value is equal to 0 
                if (newoutvalue <= 0)
                {
                    tbl_DailyTime.Rows[i].Cells["outstatus"].Value = "P";
                    tbl_DailyTime.Rows[i].Cells["outstatus"].Style.BackColor = System.Drawing.Color.Green ;
                }

            }

        }

        public void ExtrastatusRuleAction(int i)
        {
            if (tbl_DailyTime.Rows[i].Cells["outstatus"].Value.ToString().Trim() == "OT1.5")
            {
                if (tbl_DailyTime.Rows[i].Cells["Extrastatus"].Value.ToString().Trim() == "UOT")
                {
                    int outextravalue = int.Parse(tbl_DailyTime.Rows[i].Cells["ExtraValue"].Value.ToString());
                }
            }

        }
        
        # endregion


        public int CropTheValueasperRule(int outvalue)
        {
            int returnvalue = 0;
            if (outvalue < 26)
            {
                returnvalue = 0;
            }
            else if((outvalue >=26)  && (outvalue < 56) )
            {
                returnvalue =30;
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
            else
            {
                returnvalue = outvalue - (outvalue % 30);
            }

            return returnvalue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn_approval.Enabled = false;
            DataTable dt = ottrans.ShowCloseRegisteredData(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date);
            tbl_DailyTime.DataSource = dt;
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tbl_DailyTime);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = getdataforclosing();

            ottrans.closeDataRegister(dt, dtp_from.Value.Date);
            ottrans.EmployeeSwipeBankEnter(dt);
            ottrans.EmployyeLeaveTakenUpdate(dtp_from.Value.Date, dt);
            offdayDataentry();
            markDateclosed();
            MessageBox.Show("Done");
        }






    }
}

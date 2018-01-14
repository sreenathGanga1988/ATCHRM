using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Attendance
{
    public partial class MasterOTRuler : Form
    {
        Datalayer.AdjusterDatabean adjstbean = null;
        Transactions.Adjuster.AdjusterTranscation adjstrtrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.Adjuster.OtRulerTransaction ottrans = null;
        DataTable holidaydatatable = new DataTable();
        int lctnflag = 0;
        Boolean DataReadyflag = true;
        Transactions.DataExporter DTPEXPTR = null;
        DataTable Employeedistinctvalues = null;
             int adjstid =0;
        public MasterOTRuler()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            cmptransaction = new Transactions.CompanyBranchTransactions();
            ottrans = new Transactions.Adjuster.OtRulerTransaction();
            adjstrtrans = new Transactions.Adjuster.AdjusterTranscation();
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

        private void MasterOTRuler_Load(object sender, EventArgs e)
        {
            locationListLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = ottrans.Getdataforaction(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);
         //dt = dt.Select("EMPID=736 ").CopyToDataTable();
            label3.Text = "Records Found :" + dt.Rows.Count.ToString();
            foreach (DataColumn  clmn in dt.Columns  )
            {
                clmn.ReadOnly = false;
            }
            tblNonAdjusterdata.DataSource = dt;
            tblNonAdjusterdata.Columns[0].Visible = false;
            tblNonAdjusterdata.Columns[1].Visible = false;
            tblNonAdjusterdata.Columns[2].Visible = false;
          //  Leaveadderer();
            getdurationdone();

        }




      






        public void Leaveadderer()
        {

            
            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {
                String outstatus = tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells["empid"].Value.ToString());
                DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()).Date;

                string[] Leave = { "A", "HPL", "PL", "SL", "ML", "UPL", "SHD", "HD", "OSD", "FL" };

                if (Leave.Contains(instatus) && Leave.Contains(outstatus))
                {
                    adjstrtrans.insertPendingLeavesofEmployees(empid, dateofleave, instatus, outstatus);
                 
                    
                }
                else if ((instatus == "P" && Leave.Contains(outstatus)) || (Leave.Contains(instatus) && outstatus == "P"))
                {
                    adjstrtrans.insertPendingLeavesofEmployees(empid, dateofleave, instatus, outstatus);
                }
                else if ((instatus == "LH" && Leave.Contains(outstatus)) || (Leave.Contains(instatus) && outstatus == "LH"))
                {
                    if (instatus == "LH")
                    {
                        //consider lh as p to mark half day leave
                        instatus = "P";
                    }
                    else
                    {//consider lh as p to mark half day leave
                        outstatus = "P";
                    }
                    adjstrtrans.insertPendingLeavesofEmployees(empid, dateofleave, instatus, outstatus);
                }


            }
                    


        }


        /// <summary>
        /// if data not correct ie half day leave or leave duration greater than zero
        /// </summary>
        /// <returns></returns>
        public Boolean IsdataCorrect()
        {
            Boolean correct = false;

            ErrorLogger lg = new ErrorLogger();
            string[] halfdayleaves = { "SHD", "HPL" };
            string[] leaves = { "PL", "SL", "UPL", "UPL", "ML" };
            String[] otandpresent = { "P", "OT", "OT1.5", "UOT", "LH" };


           
            int errorflag = 0;



            for (int i = 0; i < tblNonAdjusterdata.Rows.Count - 1; i++)
            {


                String outstatus = tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();



                #region LeaveonOnside

                if (otandpresent.Contains(instatus) && leaves.Contains(outstatus))
                {
                    errorflag++;

                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells["Empid"].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()), "Half Day TYpe Leave on OUT Section");
                  
                }
                else if (otandpresent.Contains(outstatus) && leaves.Contains(instatus))
                {
                    errorflag++;
                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells["Empid"].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()), "Half Day TYpe Leave on IN Section");

                    
                }


                #endregion

                # region datemistake()
                if ((tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/2000 00:00:00") || (tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000 00:00:00"))
                {
                    if (!(tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString().Trim()))
                    {
                         errorflag++;
                        tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells["Empid"].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()), "One Unhandled Leave or Abscent Data");
                    }
                  
                }
                else if (DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString()) > DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString()))
                {
                     errorflag++;
                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells["Empid"].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()), "SwipeIn Time Greater Than Swipe Out time ");
                 
                
                }
                #endregion



# region UOTPRESENT
                if (outstatus=="UOT")
                {
                    errorflag++;

                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells["Empid"].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()), "UOT Data");

                }
#endregion





            }




            if (errorflag == 0)
            {
                correct = true;


            }
            else
            {
                correct = false;
                String msg = errorflag.ToString() + "    Unhandled Exceptions Found in Given  Data ";

                MessageBoxDemo.frmShowMessage.Show(msg, "Adjuster Error ", MessageBoxDemo.enumMessageIcon.Error, MessageBoxDemo.enumMessageButton.OK);
            }


          

            return correct;

        }






        public Boolean  isdurationwrong()
        {
            Boolean iswrongentrypresent = false ;
            DataTable filteredData = new DataTable();
            try
            {
                filteredData = ((DataTable)(tblNonAdjusterdata.DataSource)).Select("[Actual Duration]<0 or [Actual Duration]>1080").CopyToDataTable();
            }
            catch (Exception)
            {
                
             
            }

            if (filteredData.Rows.Count > 0)
            {

             
                iswrongentrypresent = true;
                Attendance.Displayform frm = new Displayform(filteredData );
                frm.Text = "Critical -Wrong Entries";
                frm.ShowDialog();
              //  DataReadyflag = false;
                
            }
            return iswrongentrypresent;
        }




        //public DataTable  OtRuleAction()
        //{
        //    DataTable dt = (DataTable)tblNonAdjusterdata.DataSource;
        //    for (int i = 0; i < Employeedistinctvalues.Rows.Count; i++)
        //    {
        //        int otvalue = 0, lhvalue = 0, offotvalue = 0, normaloffot = 0, holidayofot = 0;

        //        try
        //        {
                    
        //            object sumOTvalue = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT1.5'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");
        //            Employeedistinctvalues.Rows[i]["OT"] = int.Parse(sumOTvalue.ToString());
        //            otvalue = int.Parse(sumOTvalue.ToString());
        //        }
        //        catch (Exception)
        //        {
                    
                   
        //        }

        //        try
        //        {
        //            object sumLHOUTvalue = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='LH'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");
        //            object sumLHINvalue = dt.Compute("Sum(invalue)", "ApprInstatus ='LH'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");

        //            Employeedistinctvalues.Rows[i]["LH"] = int.Parse(sumLHOUTvalue.ToString()) + int.Parse(sumLHINvalue.ToString());
        //             lhvalue=int.Parse (Employeedistinctvalues.Rows[i]["empid"].ToString ());
        //        }
        //        catch (Exception)
        //        {
                    
                   
        //        }

        //        try
        //        {
        //            object sumoofoffot = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT2.0'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");
        //              Employeedistinctvalues.Rows[i]["OffOT"] = int.Parse(sumoofoffot.ToString());

        //              offotvalue = int.Parse(sumoofoffot.ToString());
        //        }
        //        catch (Exception)
        //        {


        //        }


        //        try
        //        {
        //            object sumofNormalOffOT = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT2.0'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + " and DayStatus='Off Day'");
        //            Employeedistinctvalues.Rows[i]["NormalOffOT"] = int.Parse(sumofNormalOffOT.ToString());

        //            normaloffot = int.Parse(sumofNormalOffOT.ToString());
        //        }
        //        catch (Exception)
        //        {


        //        }
        //        try
        //        {
        //            object sumofholidayOffOT = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT2.0'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + " and DayStatus !='Off Day'");
        //            Employeedistinctvalues.Rows[i]["HolidayOffOT"] = int.Parse(sumofholidayOffOT.ToString());

        //            normaloffot = int.Parse(holidayofot.ToString());
        //        }
        //        catch (Exception)
        //        {


        //        }




        //        int empid=int.Parse (Employeedistinctvalues.Rows[i]["empid"].ToString ());
        //        int extravalue = int.Parse(Employeedistinctvalues.Rows[i]["ExtraMinutes"].ToString());
        //        ottrans.Final_databank(empid, otvalue, extravalue, offotvalue, lhvalue, 0, adjstid, normaloffot, holidayofot);
        //    }
        //    return Employeedistinctvalues;
        //}

            //new  otrukler asper Hiren discussed on 21/7/2015 holiday ot will be offot and off ot will be holiday ot
        public DataTable OtRuleAction()
        {
            DataTable dt = (DataTable)tblNonAdjusterdata.DataSource;
            for (int i = 0; i < Employeedistinctvalues.Rows.Count; i++)
            {
                int otvalue = 0, lhvalue = 0, offotvalue = 0, normaloffot = 0, holidayofot = 0;

                try
                {

                    object sumOTvalue = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT1.5'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");
                    Employeedistinctvalues.Rows[i]["OT"] = int.Parse(sumOTvalue.ToString());
                    otvalue = int.Parse(sumOTvalue.ToString());
                }
                catch (Exception)
                {


                }

                try
                {
                    object sumLHOUTvalue = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='LH'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");
                    object sumLHINvalue = dt.Compute("Sum(invalue)", "ApprInstatus ='LH'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");

                    Employeedistinctvalues.Rows[i]["LH"] = int.Parse(sumLHOUTvalue.ToString()) + int.Parse(sumLHINvalue.ToString());
                    lhvalue = int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString());
                }
                catch (Exception)
                {


                }

                try
                {
                    object sumoofoffot = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT2.0'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + "");
                    Employeedistinctvalues.Rows[i]["OffOT"] = int.Parse(sumoofoffot.ToString());

                    offotvalue = int.Parse(sumoofoffot.ToString());
                }
                catch (Exception)
                {


                }


                try
                {
                    object sumofNormalOffOT = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT2.0'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + " and DayStatus='Off Day'");
                    Employeedistinctvalues.Rows[i]["NormalOffOT"] = int.Parse(sumofNormalOffOT.ToString());

                    normaloffot = int.Parse(sumofNormalOffOT.ToString());
                }
                catch (Exception)
                {


                }
                try
                {
                    object sumofholidayOffOT = dt.Compute("Sum(Outvalue)", "ApprOutStatus ='OT2.0'  and  empid=" + int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString()) + " and DayStatus !='Off Day'");
                    Employeedistinctvalues.Rows[i]["HolidayOffOT"] = int.Parse(sumofholidayOffOT.ToString());

                    holidayofot = int.Parse(holidayofot.ToString());
                }
                catch (Exception)
                {


                }




                int empid = int.Parse(Employeedistinctvalues.Rows[i]["empid"].ToString());
                int extravalue = int.Parse(Employeedistinctvalues.Rows[i]["ExtraMinutes"].ToString());
                ottrans.Final_databank(empid, otvalue, extravalue, holidayofot, lhvalue, 0, adjstid, normaloffot, normaloffot);
            }
            return Employeedistinctvalues;
        }





        private void button3_Click(object sender, EventArgs e)
        {
            if (IsdataCorrect())
            {
               
                Leaveadderer();
                getdurationdone();

                if(isdurationwrong())
                {

                    DataReadyflag = false;

                }else
                {
                    DataReadyflag = true;
                }
            }
            else
            {
                try
                {
                    String apppath = Program.OurLogSource + "Adjstrlog.txt";
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(@"c:\Windows\System32\notepad.exe", apppath);
                    Process.Start(processStartInfo);
                   // Process.Start(apppath);
                }
                catch (Exception)
                {
                    
                   
                }
            }

        }




        public void synchroniseInandOuttime(int i)
        {
            if (DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString()) >= DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString()))
            {
                tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = tblNonAdjusterdata.Rows[i].Cells["Intime"].Value;
                tblNonAdjusterdata.Rows[i].Cells["Actual Duration"].Value = 0;
            }
            else
            {
                tblNonAdjusterdata.Rows[i].Cells["Intime"].Value = tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value;
                tblNonAdjusterdata.Rows[i].Cells["Actual Duration"].Value = 0;
            }
        }

        public void calculateduration(int i)
        {
            DateTime a = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString());

            DateTime b = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString());

            tblNonAdjusterdata.Rows[i].Cells["Actual Duration"].Value = Math.Truncate(b.Subtract(a).TotalMinutes);
       //     double difference = Math.Truncate(float.Parse(tblNonAdjusterdata.Rows[i].Cells["Actual Duration"].Value.ToString()) - float.Parse(tblNonAdjusterdata.Rows[i].Cells[14].Value.ToString()));


           // tblNonAdjusterdata.Rows[i].Cells[15].Value = Math.Truncate(float.Parse(tblNonAdjusterdata.Rows[i].Cells[12].Value.ToString()) - float.Parse(tblNonAdjusterdata.Rows[i].Cells[14].Value.ToString()));

        }

        public void getdurationdone()
        {
            string[] halfdayleaves = { "SHD", "HPL" };
            string[] leaves = { "PL", "SL", "UPL", "UPL", "ML" };
            String[] otandpresent = { "P", "OT", "OT1.5", "UOT" };
            for (int i = 0; i < tblNonAdjusterdata.RowCount; i++)
            {
                String outstatus = tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells["empid"].Value.ToString());
                DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()).Date;
                int duration=int.Parse(tblNonAdjusterdata.Rows[i].Cells["Actual Duration"].Value.ToString());

                //if A on both sides make both punches same and mark duration zero
                if (instatus == "A" && outstatus == "A" && duration != 0)
                {
                    synchroniseInandOuttime(i);
                }

                else if (instatus != outstatus)
                {
                    // IF Instatus is A and outstatus not
                    # region A on Instatus only
                    if (instatus == "A")
                    {
                        if (instatus == "A" && leaves.Contains(outstatus))
                        {
                            synchroniseInandOuttime(i);

                        }

                        if (tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/2000 00:00:00" || tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/1900"|| DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString()).ToString("dd/mm/yyyy") == "01/01/1900"  || tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/1900 00:00:00" || tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString().Trim() == "01/01/1900 12:00:00 AM")
                        {
                            //// if the outstatus is any halfdays set the intime also to the same or if outstatus is a leave set the intime also the same
                            #region If halfday or leave on OUTstatus
                            if (halfdayleaves.Contains(outstatus) ||leaves.Contains(outstatus) )
                            {
                                tblNonAdjusterdata.Rows[i].Cells["Intime"].Value = tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value;

                                 calculateduration(i);

                            }


                            # endregion
                            //if outstatus=LH
                            # region if LH on OUtstatus

                          
                            else if (outstatus == "LH")
                            {
                                double outvalue = double.Parse(tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value.ToString());
                                DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString());

                                TimeSpan losttime = new TimeSpan(0, int.Parse(outvalue.ToString()), 0);
                                DateTime swipeout = outime.Add(losttime);
                                double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells["shiftDuaration"].Value.ToString());
                                if (sahiftduration > 0)
                                {
                                    double halfdaytime = Math.Truncate(sahiftduration / 2);
                                    TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                    tblNonAdjusterdata.Rows[i].Cells["Intime"].Value = outime.Subtract(t1);
                                    calculateduration(i);
                                }

                            }
                            # endregion
                            //if ouutstatus is P or OT
                            # region OT or P on OUTSTATUS
                          
                            else if (otandpresent.Contains(outstatus))
                            {
                               
                                //if outstatus is P and instatus is A
                                if (outstatus == "P" && instatus == "A")
                                {


                                    double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());

                                    if (sahiftduration > 0)
                                    {
                                        double outvalue = double.Parse(tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value.ToString());
                                        DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString());
                                        double halfdaytime = Math.Truncate(sahiftduration / 2);
                                        TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                        tblNonAdjusterdata.Rows[i].Cells["Intime"].Value = outime.Subtract(t1);
                                        calculateduration(i);



                                    }
                                }
                                    //if its OT
                                else
                                {
                                    double outvalue = double.Parse(tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value.ToString());
                                    DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString());
                                    double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells["shiftDuaration"].Value.ToString());
                                    if (sahiftduration > 0)
                                    {
                                        TimeSpan t2 = new TimeSpan(0, int.Parse(outvalue.ToString()), 0);
                                        DateTime swipeout = outime.Subtract(t2);
                                        double halfdaytime = Math.Truncate(sahiftduration / 2);
                                        TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                        tblNonAdjusterdata.Rows[i].Cells["Intime"].Value = swipeout.Subtract(t1);


                                        calculateduration(i);
                                    }
                                }

                            }
                                # endregion

                        }

                    }

# endregion


                        //if outstatus is A and instatus is not
                   

                    else if (outstatus == "A")
                    {

                        if (tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/2000 00:00:00" || DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString()).ToString("dd/mm/yyyy") == "01/01/1900" || tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/1900 00:00:00" || tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString().Trim() == "01/01/1900 12:00:00 AM")
                        {
                            //// if the INSTATUS is any halfdays set the intime also to the same
                            if (halfdayleaves.Contains(instatus ))
                            {
                                tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = tblNonAdjusterdata.Rows[i].Cells["Intime"].Value;

                            }
                            //if instatus is P
                            if (instatus  == "P")
                            {
                                double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells["shiftDuaration"].Value.ToString());
                                if (sahiftduration > 0)
                                {
                                    DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString());
                                    double halfdaytime = Math.Truncate(sahiftduration / 2);
                                    TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                    tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                                    calculateduration(i);
                                }
                                
                            }
                            if (instatus  == "LH")
                            {
                                double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells["shiftDuaration"].Value.ToString());

                                if (sahiftduration > 0)
                                {
                                    DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Intime"].Value.ToString());
                                    double halfdaytime = Math.Truncate(sahiftduration / 2);
                                    TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                    tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = intime.Add(t1);
                                    calculateduration(i);
                                }

                            }
                        }


                    }
                }




               



            }
        }















        private void button2_Click(object sender, EventArgs e)
        {
            
            DataView view = new DataView((DataTable)(tblNonAdjusterdata.DataSource));


            Employeedistinctvalues = view.ToTable(true, "empid");
            //distinctValues.Columns.Add("ExtraMinutes", typeof(int));
            DataColumn col = new DataColumn();
            col.ColumnName = "ExtraMinutes";
            col.AllowDBNull = false;
            col.DataType = System.Type.GetType("System.Int32");
            col.DefaultValue = 0;
            Employeedistinctvalues.Columns.Add(col);
            DataColumn col2 = new DataColumn();
            col2.ColumnName = "OT";
            col2.AllowDBNull = false;
            col2.DataType = System.Type.GetType("System.Int32");
            col2.DefaultValue = 0;
            Employeedistinctvalues.Columns.Add(col2);
            DataColumn col3 = new DataColumn();
            col3.ColumnName = "LH";
            col3.AllowDBNull = false;
            col3.DataType = System.Type.GetType("System.Int32");
            col3.DefaultValue = 0;
            Employeedistinctvalues.Columns.Add(col3);
            DataColumn col4 = new DataColumn();
            col4.ColumnName = "OffOT";
            col4.AllowDBNull = false;
            col4.DataType = System.Type.GetType("System.Int32");
            col4.DefaultValue = 0;
            Employeedistinctvalues.Columns.Add(col4);

            DataColumn col5 = new DataColumn();
            col5.ColumnName = "NormalOffOT";
            col5.AllowDBNull = false;
            col5.DataType = System.Type.GetType("System.Int32");
            col5.DefaultValue = 0;
            Employeedistinctvalues.Columns.Add(col5);

            DataColumn col6 = new DataColumn();
            col6.ColumnName = "HolidayOffOT";
            col6.AllowDBNull = false;
            col6.DataType = System.Type.GetType("System.Int32");
            col6.DefaultValue = 0;
            Employeedistinctvalues.Columns.Add(col6);
            label4.Text = "Emp Found :" + Employeedistinctvalues.Rows.Count.ToString();
          
            
            holidaydatatable = adjstrtrans.GetAllHolidayodLocation(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);
           
            
            if (DataReadyflag == true)
            {
                showholidayongrid();

                cropvalue();
                cropvalue();

               AddAfdjustermaster();
                OtRuleAction();
               loadholidays();
               CheckWhetherPresentiesLeaveisMarked();
                clearoffdayrecordsnotinemployeeleavetaken();
               ClearAbscentiesnotINEmpLeaveTaken();
                MessageBox.Show("Done");
            }else
            {
                MessageBox.Show("There are Exceptions that are needed to be cleared before proceeding with Confirm OT");
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
            else
            {
                returnvalue = outvalue - (outvalue % 30);
            }

            return returnvalue;
        }


        public void AddAfdjustermaster()
        {
           
            adjstbean = new Datalayer.AdjusterDatabean();

            adjstbean.BranchlctnPk = int.Parse(cmb_location.SelectedValue.ToString());
            adjstbean.Fromdate = dtp_from.Value.Date;
            adjstbean.Todate = dtp_to.Value.Date;
            adjstbean.Aid = 0;
            if (!adjstrtrans.checkifactiondone(dtp_from.Value.Date, dtp_to.Value.Date))
            {
                DataTable dt = (DataTable)(tblNonAdjusterdata.DataSource);
                 adjstid = adjstrtrans.insertAdjusterdata(adjstbean);
               
                foreach (DataRow row in dt.Rows)
                    row["adjustid"] = adjstid.ToString();

               ottrans. insertdata(dt);
          //     MessageBox.Show("Done");

            }
            else
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show("Adjuster for these date already Done");
                return;
            }
        }

        public void loadholidays()
        {
          
            int holicount = holidaydatatable.Rows.Count;


            for (int i = 0; i < tblNonAdjusterdata.RowCount ; i++)
            {
              
                String outstatus = tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells["empid"].Value.ToString());
               
                if (outstatus == "A" && instatus == "A")
                {
                    DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()).Date;


                    for (int k = 0; k < holicount; k++)
                    {
                        DateTime holidaydate = DateTime.Parse(holidaydatatable.Rows[k][0].ToString());
                        String Holidayname = holidaydatatable.Rows[k][1].ToString();
                        if (holidaydate == dateofleave)
                        {
                            tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            tblNonAdjusterdata.Rows[i].Cells["DayStatus"].Value = Holidayname;

                            adjstrtrans.updateadjusterforHolidays(empid,
                                int.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedataid"].Value.ToString()), dateofleave, Holidayname);
                        }
                    }

                }


            }

        }









        public void showholidayongrid()
        {
            int holicount = holidaydatatable.Rows.Count;
            for (int k = 0; k < holicount; k++)
            {
                DateTime holidaydate = DateTime.Parse(holidaydatatable.Rows[k][0].ToString());
                String Holidayname = holidaydatatable.Rows[k][1].ToString();
                for (int i = 0; i < tblNonAdjusterdata.RowCount ; i++)
                {
                    DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()).Date;
                      if (holidaydate == dateofleave)
                        {
                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    tblNonAdjusterdata.Rows[i].Cells["DayStatus"].Value = Holidayname;
                        }
                }
            }
        }







        /// <summary>
        /// check if there is a leave marked in the Employee leaveTaken of an employee
        /// eventhough he is Present on both Sides
        /// </summary>
        public void CheckWhetherPresentiesLeaveisMarked()
        {

            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {
                String outstatus = tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells["ApprInstatus"].Value.ToString().Trim();
                int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells["empid"].Value.ToString());
                string[] Leave = { "A", "HPL", "PL", "SL", "ML", "UPL", "SHD", "HD", "OSD", "FL" };

                if (!Leave.Contains(instatus) && !Leave.Contains(outstatus))
                {

                    DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Swipedate"].Value.ToString()).Date;
                    adjstrtrans.RemoveAbscentdataofEmployees(empid, dateofleave, instatus, outstatus);


                }

            }


        }



        public void clearoffdayrecordsnotinemployeeleavetaken()
        {
            DataTable dt = ottrans.GetAddjustedOFFDaysnotRegister();
            int totalrowcount = dt.Rows.Count;
           
           
            
            for (int i = 0; i < totalrowcount; i++)
            {
                String Outstatus = dt.Rows[i]["Out_Status"].ToString();
            String Instatus = dt.Rows[i]["In_Status"].ToString().Trim();
            int empid = int.Parse(dt.Rows[i]["empid"].ToString());
            DateTime Swipedate= DateTime.Parse(dt.Rows[i]["Swipe_Date"].ToString());
                if (Outstatus.Trim() == "A" && Instatus.Trim() == "A")
                {
                    using (SqlConnection con = new SqlConnection(Program.ConnStr))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeLeaveTaken_tbl " +
             "     (Istaken, empid, dateofleave, LeavePk, Reason, Userpk, Dateadded, AddedVia) " +
 " VALUES     (N'Y',@EMPID,@DATELEAVE, 0, 'A',@USERPK,@DATEADDED,'AdjstrCorrection')", con))
                        {

                            cmd.Parameters.AddWithValue("@EMPID", empid);
                            cmd.Parameters.AddWithValue("@DATELEAVE",Swipedate);
                            cmd.Parameters.AddWithValue("@USERPK", Program.USERPK);
                            cmd.Parameters.AddWithValue("@DATEADDED", Program.Datetoday);
                            cmd.ExecuteNonQuery();

                        }
                    }

                }

            }
        }

        public void ClearAbscentiesnotINEmpLeaveTaken()
        {
            DataTable dt = ottrans.GetAddjustedAbscentiesnotRegister();
               int totalrowcount = dt.Rows.Count;
           
           
            
            for (int i = 0; i < totalrowcount; i++)
            {
                String Outstatus = dt.Rows[i]["Out_Status"].ToString();
            String Instatus = dt.Rows[i]["In_Status"].ToString().Trim();
            int empid = int.Parse(dt.Rows[i]["empid"].ToString());
            DateTime Swipedate= DateTime.Parse(dt.Rows[i]["Swipe_Date"].ToString());

                 if (Outstatus.Trim() == "A" && Instatus.Trim() == "A")
                { DataTable newdata = checkifEmployeeleavetakenAvailable(Swipedate, empid);
                    if (newdata != null)
                    {
                        if (newdata.Rows.Count > 0)
                        {
                            if (newdata.Rows[0]["Reason"].ToString().Trim() == "A")
                            {
                                int leavid = int.Parse(newdata.Rows[0]["Leaveid"].ToString());

                                SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
                                var q = from frm in cntxt.EmployeeLeaveTaken_tbls
                                        where frm.Leaveid == leavid
                                        select frm;


                                foreach (var element in q)
                                {
                                    element.Istaken = "Y";
                                    cntxt.SubmitChanges();
                                }


                            }
                            else
                            {
                                MessageBox.Show("Multiple leave Found for   empid" + empid  + " in" +Swipedate );
                            }

                        }
                        else
                        {
                            using (SqlConnection con = new SqlConnection(Program.ConnStr))
                            {
                                con.Open();
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeLeaveTaken_tbl " +
                     "     (Istaken, empid, dateofleave, LeavePk, Reason, Userpk, Dateadded, AddedVia) " +
         " VALUES     (N'Y',@EMPID,@DATELEAVE, 0, 'A',@USERPK,@DATEADDED,'AdjstrCorrection')", con))
                                {

                                    cmd.Parameters.AddWithValue("@EMPID", empid );
                                    cmd.Parameters.AddWithValue("@DATELEAVE", Swipedate );
                                    cmd.Parameters.AddWithValue("@USERPK", Program.USERPK);
                                    cmd.Parameters.AddWithValue("@DATEADDED", Program.Datetoday);
                                    cmd.ExecuteNonQuery();

                                }
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Data");
                    }
            

                 }
            }
        }


        public DataTable checkifEmployeeleavetakenAvailable(DateTime leavedate, int empid)
        {
            Boolean present = false;

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT   * FROM  EmployeeLeaveTaken_tbl WHERE        empid = @empid AND dateofleave=@datetime", con);

                command.Parameters.AddWithValue("@empid", empid);
                command.Parameters.AddWithValue("@datetime", leavedate);

                SqlDataReader reader = command.ExecuteReader();


                dt.Load(reader);
                con.Close();

                return dt;
            }



        }





        public DataTable cropvalue()
        {

            int totalrowcount = tblNonAdjusterdata.RowCount;
            for (int i = 0; i < totalrowcount - 1; i++)
            {
                # region Ot region
                if (tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim() == "OT1.5")
                {
                    //if(ot and extravalue >26) add extraoutvalue to the extraminutes of distinctemployeetable
                    //and reduce the extraminutes from outtime
                    if (int.Parse(tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value.ToString()) > 26)
                    {



                        int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells["empid"].Value.ToString());

                        DataRow[] HRow = Employeedistinctvalues.Select("empid=" + empid + "");
                        //add extravalue to emp otbank
                        HRow[0]["ExtraMinutes"] = int.Parse(tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value.ToString()) + int.Parse(HRow[0]["ExtraMinutes"].ToString());

                        DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString());
                        int outvalue = int.Parse(tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value.ToString());
                        int extraminute = int.Parse(tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value.ToString());
                        //and reduce the extraminutes from outtime
                        tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = outime.AddMinutes(-extraminute);
                        //and reduce the extraminutes from outvalue
                        tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value = outvalue - extraminute;
                        tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].ReadOnly = false;
                        //make extravalue zero
                        tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value = 0;
                        tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        calculateduration(i);
                    }
                        // if extraminutes is less than -26 ie if there is emplty slot for adding ot
                    else if (int.Parse(tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value.ToString())< -26)
                    {
                        int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells["empid"].Value.ToString());

                        DataRow[] HRow = Employeedistinctvalues.Select("empid=" + empid + "");
                        //if the emp have extravalue in his otbank
                        if( int.Parse(HRow[0]["ExtraMinutes"].ToString())>0)
                        {
                            DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString());
                            int outvalue = int.Parse(tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value.ToString());
                            //absolute of extra out is room available
                            int extraslotavailable= Math.Abs (int.Parse(tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value.ToString()));

                            //if slot available is less than extraminutes in otbank
                            if(extraslotavailable< int.Parse(HRow[0]["ExtraMinutes"].ToString()))
                            {
                                // extra ot left to allocate= extraotavailablee -slot available
                            HRow[0]["ExtraMinutes"] =  int.Parse(HRow[0]["ExtraMinutes"].ToString())- Math.Abs (extraslotavailable);
                                //add the extra available slot to outime 
                            tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = outime.AddMinutes(extraslotavailable);
                                //add the extra slot available to out value
                            tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value = outvalue + extraslotavailable;
                                //since slot available is used mark it zero
                            tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value=0;
                            tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Green ;
                            calculateduration(i);
                            }
                        }
                    }
                }
# endregion
                    //if status=p
                else if (tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value.ToString().Trim() == "P")
                {


                    //if slot available isless than 26 means slot availble is more than 26
                    if (int.Parse(tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value.ToString())< -26)
                    {
                        int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells["empid"].Value.ToString());
                        //get employee ot bank
                        DataRow[] HRow = Employeedistinctvalues.Select("empid=" + empid + "");
                        //if ot bank has extra ot
                        if( int.Parse(HRow[0]["ExtraMinutes"].ToString())>0)
                        {
                            DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value.ToString());
                            int outvalue = int.Parse(tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value.ToString());
                            //get slot available
                            int extraslotavailable= Math.Abs (int.Parse(tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value.ToString()));

                            //if  slot availble>0
                            if (extraslotavailable > 0)
                            {
                                //if slot availble is less than ectra ot of otbank
                                if (extraslotavailable < int.Parse(HRow[0]["ExtraMinutes"].ToString()))
                                {
                                    //reduce extraot of otbank with slot availble
                                    HRow[0]["ExtraMinutes"] = int.Parse(HRow[0]["ExtraMinutes"].ToString()) - Math.Abs(extraslotavailable);
                                    //convert outvalue to nearest 30 asperrule and add the slot availble
                                    tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value = CropTheValueasperRule(outvalue) + extraslotavailable;
                                    tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value = 0;
                                    tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = outime.AddMinutes(extraslotavailable);
                                    tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value = "OT1.5";
                                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                                    calculateduration(i);
                                }
                                else
                                {
                                    //if slot available is more than otslot required
                                    tblNonAdjusterdata.Rows[i].Cells["Outvalue"].Value = CropTheValueasperRule(outvalue) + int.Parse(HRow[0]["ExtraMinutes"].ToString());
                                //changed by sreenath on29092015
                                    // tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value = extraslotavailable - int.Parse(HRow[0]["ExtraMinutes"].ToString());
                                    tblNonAdjusterdata.Rows[i].Cells["exrtaOutValue"].Value = 0-(extraslotavailable - int.Parse(HRow[0]["ExtraMinutes"].ToString()));
                                    tblNonAdjusterdata.Rows[i].Cells["Outtime"].Value = outime.AddMinutes(int.Parse(HRow[0]["ExtraMinutes"].ToString()));
                                    tblNonAdjusterdata.Rows[i].Cells["ApprOutStatus"].Value = "OT1.5";
                                    HRow[0]["ExtraMinutes"] = 0;
                                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                                    calculateduration(i);
                                }
                            }
                        }
                    }

                }

            }
            return Employeedistinctvalues;
        }







  
        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tblNonAdjusterdata);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadholidays();
        }


    }
}

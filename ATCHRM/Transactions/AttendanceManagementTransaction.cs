using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
namespace ATCHRM.Transactions
{
    class AttendanceManagementTransaction
    {




        ///// <summary>
        /// get the employe code and empid
        /// </summary>
        /// <returns></returns>
        public DataTable GetSwipeemplyeesdetailforAction(int BranchlctnPK, DateTime nowdate)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("  SELECT     EmployeSwipeDaily_tbl.swipePK, EmployeSwipeDaily_tbl.empid, EmployeePersonalMaster_tbl.empno, " +
                     " EmployeePersonalMaster_tbl.First_name + '' + EmployeePersonalMaster_tbl.Last_Name AS name, DesignationMaster_tbl.DesignationName, " +
                   "   DepartmentMaster_tbl.DepartmentName, EmployeSwipeDaily_tbl.Date, EmployeSwipeDaily_tbl.Duration, EmployeSwipeDaily_tbl.Invalue, " +
                  "    EmployeSwipeDaily_tbl.InStatus, EmployeSwipeDaily_tbl.OutValue, EmployeSwipeDaily_tbl.Outstatus, EmployeSwipeDaily_tbl.IsCompleted " +
 " FROM         DepartmentMaster_tbl INNER JOIN " +
                   "   DesignationMaster_tbl ON DepartmentMaster_tbl.DepartmentPK = DesignationMaster_tbl.DepartmentPK INNER JOIN " +
                  "    EmployeSwipeDaily_tbl INNER JOIN " +
               "       EmployeeDesignation_tbl ON EmployeSwipeDaily_tbl.empid = EmployeeDesignation_tbl.empid ON  " +
                "      DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN  " +
              "        EmployeePersonalMaster_tbl ON EmployeSwipeDaily_tbl.empid = EmployeePersonalMaster_tbl.empid " +
" WHERE     (EmployeSwipeDaily_tbl.IsCompleted = N'Y') AND (EmployeSwipeDaily_tbl.Date = @date) AND (EmployeeDesignation_tbl.BranchLocationPK =@BranchlctnPK) ", con);



                cmd.Parameters.AddWithValue("@date", nowdate);
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }



















        /// <summary>
        /// get swipedetails of all employyes
        /// </summary>
        /// <returns></returns>
        public DataTable getallswipe(int BranchPk, DateTime nowdate, String retrievetypr)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                //changed on 14th April2013
                //  SqlCommand cmd = new SqlCommand("GetEmployeSwipedata_sp", con);
                SqlCommand cmd = new SqlCommand("DataforCloseRegister_SP", con);



                cmd.Parameters.AddWithValue("@BranchLocationPk", BranchPk);
                cmd.Parameters.AddWithValue("@datetoday", nowdate.ToString("MM-dd-yyyy"));
                //cmd.Parameters AddWithValue("@dayoffweek",nowdate.DayOfWeek.ToString ());


                cmd.Parameters.AddWithValue("@Calltype", retrievetypr);

                cmd.Parameters.AddWithValue("@dayoffweek", nowdate.DayOfWeek.ToString());

                // cmd.Parameters.AddWithValue("@Calltype", "Show");

                //    cmd.Parameters.AddWithValue("@Calltype", "Show");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;





        }







        /// <summary>
        /// insert the correction Applications
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="Swipepk"></param>
        /// <param name="mydate"></param>
        /// <param name="previoussatus"></param>
        /// <param name="invalue"></param>
        public void inserCorretiondata(int empid, int Swipepk, DateTime mydate, String previoussatus, int invalue)
        {
            DataTable dt = new DataTable();
            String Dayoftheweek = mydate.DayOfWeek.ToString(); ;
            string mynowdate = mydate.ToString("dd/MMM/yyyy");
            if (!isCorectionAppliocationPresernt(empid, mydate))
            {
                if (previoussatus == "A")
                {
                    using (SqlConnection con = new SqlConnection(Program.ConnStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("SELECT     ShiftDayDetails_tbl.FromTime, ShiftDayDetails_tbl.ShiftPK " +
    " FROM         ShiftDayDetails_tbl INNER JOIN " +
                   "       EmployeShift_tbl ON ShiftDayDetails_tbl.ShiftPK = EmployeShift_tbl.Shiftpk " +
    " WHERE     (ShiftDayDetails_tbl.DayOFWeekname = @datetoday) AND (EmployeShift_tbl.Empid = @empid)", con);



                        cmd.Parameters.AddWithValue("@datetoday", Dayoftheweek);
                        cmd.Parameters.AddWithValue("@empid", empid);
                        SqlDataReader reader = cmd.ExecuteReader();

                        dt.Load(reader);
                        if (dt != null)
                        {
                            if (dt.Rows.Count != 0)
                            {


                                String sg1 = DateTime.Parse(dt.Rows[0][0].ToString()).ToString("dd/MMM/yyyy HH:mm:ss tt");
                                sg1 = sg1.Replace("01/Jan/1900", mynowdate);

                                DateTime Shifttime1 = DateTime.Parse(sg1);

                                int shiftPk = int.Parse(dt.Rows[0][1].ToString());
                                SqlCommand cmd1 = new SqlCommand("INSERT INTO CorrectionDaily_tbl " +
                        "  (empid, ShiftPK, InStatus, PreviousInStatus, InValue, DateForSwipe, UserPK , ShiftTime) " +
    " VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8 )", con);

                                cmd1.Parameters.AddWithValue("@Param1", empid);
                                cmd1.Parameters.AddWithValue("@Param2", shiftPk);
                                cmd1.Parameters.AddWithValue("@Param3", "P");
                                cmd1.Parameters.AddWithValue("@Param4", "A");
                                cmd1.Parameters.AddWithValue("@Param5", 0);

                                cmd1.Parameters.AddWithValue("@Param6", mydate);
                                cmd1.Parameters.AddWithValue("@Param7", Program.USERPK);
                                cmd1.Parameters.AddWithValue("@Param8", Shifttime1);

                                cmd1.ExecuteNonQuery();

                            }
                        }
                        con.Close();
                    }
                }
                else  //// if its a  Mark LH type
                {
                    using (SqlConnection con = new SqlConnection(Program.ConnStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("SELECT     EmployeSwipeDaily_tbl.swipePK, EmployeSwipeDaily_tbl.Shift_Pk, ShiftDayDetails_tbl.FromTime, ShiftDayDetails_tbl.DayOFWeekname , EmployeSwipeDaily_tbl.Outstatus " +
" FROM         EmployeSwipeDaily_tbl INNER JOIN " +
               "       ShiftDayDetails_tbl ON EmployeSwipeDaily_tbl.Shift_Pk = ShiftDayDetails_tbl.ShiftPK" +
                     "   WHERE     (EmployeSwipeDaily_tbl.empid = @empid) AND (EmployeSwipeDaily_tbl.Date = @datetoday) AND (ShiftDayDetails_tbl.DayOFWeekname = @dayoffweek)", con);

                        cmd.Parameters.AddWithValue("@datetoday", mydate.ToString("MM-dd-yyyy"));
                        cmd.Parameters.AddWithValue("@empid", empid);
                        cmd.Parameters.AddWithValue("@dayoffweek", Dayoftheweek);
                        cmd.CommandTimeout = 0;
                        SqlDataReader reader = cmd.ExecuteReader();

                        dt.Load(reader);
                        if (dt != null)
                        {
                            if (dt.Rows.Count != 0)
                            {
                                // if the empoloyee have a  outstatus

                                int swipepk = int.Parse(dt.Rows[0][0].ToString());
                                int shiftpk = int.Parse(dt.Rows[0][1].ToString());
                                String sg1 = DateTime.Parse(dt.Rows[0][2].ToString()).ToString("dd/MMM/yyyy HH:mm:ss tt");
                                sg1 = sg1.Replace("01/Jan/1900", mynowdate);

                                DateTime Shifttime1 = DateTime.Parse(sg1).AddMinutes(invalue); ;

                                String outstatus = dt.Rows[0][4].ToString();


                                SqlCommand cmd1 = new SqlCommand("INSERT INTO CorrectionDaily_tbl " +
                    "  (empid, ShiftPK, InStatus, PreviousInStatus, InValue, DateForSwipe, UserPK , ShiftTime,SwipePk,Outstatus) " +
" VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8 ,@Param9,@Param10 )", con);

                                cmd1.Parameters.AddWithValue("@Param1", empid);
                                cmd1.Parameters.AddWithValue("@Param2", shiftpk);
                                cmd1.Parameters.AddWithValue("@Param3", "LH");
                                cmd1.Parameters.AddWithValue("@Param4", "A");
                                cmd1.Parameters.AddWithValue("@Param5", invalue);

                                cmd1.Parameters.AddWithValue("@Param6", mydate);
                                cmd1.Parameters.AddWithValue("@Param7", Program.USERPK);
                                cmd1.Parameters.AddWithValue("@Param8", Shifttime1);
                                cmd1.Parameters.AddWithValue("@Param9", swipepk);
                                cmd1.Parameters.AddWithValue("@Param10", outstatus);
                                cmd1.ExecuteNonQuery();





                            }
                            else
                            {

                                ///if he doesnot have an outstatus

                                DataTable dt2 = new DataTable();
                                SqlCommand cmd23 = new SqlCommand("SELECT     ShiftDayDetails_tbl.FromTime, ShiftDayDetails_tbl.ShiftPK " +
 " FROM         ShiftDayDetails_tbl INNER JOIN " +
                "       EmployeShift_tbl ON ShiftDayDetails_tbl.ShiftPK = EmployeShift_tbl.Shiftpk " +
 " WHERE     (ShiftDayDetails_tbl.DayOFWeekname = @datetoday) AND (EmployeShift_tbl.Empid = @empid)", con);



                                cmd23.Parameters.AddWithValue("@datetoday", Dayoftheweek);
                                cmd23.Parameters.AddWithValue("@empid", empid);
                                SqlDataReader reader1 = cmd23.ExecuteReader();



                                dt2.Load(reader1);
                                if (dt2 != null)
                                {
                                    if (dt2.Rows.Count != 0)
                                    {


                                        String sg1 = DateTime.Parse(dt2.Rows[0][0].ToString()).ToString("dd/MMM/yyyy HH:mm:ss tt");
                                        sg1 = sg1.Replace("01/Jan/1900", mynowdate);

                                        DateTime Shifttime1 = DateTime.Parse(sg1);

                                        int shiftPk = int.Parse(dt2.Rows[0][1].ToString());

                                        DateTime Shifttime12 = DateTime.Parse(sg1).AddMinutes(invalue); ;

                                        SqlCommand cmd1 = new SqlCommand("INSERT INTO CorrectionDaily_tbl " +
                 "  (empid, ShiftPK, InStatus, PreviousInStatus, InValue, DateForSwipe, UserPK , ShiftTime,SwipePk,Outstatus) " +
" VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8 ,@Param9,@Param10 )", con);

                                        cmd1.Parameters.AddWithValue("@Param1", empid);
                                        cmd1.Parameters.AddWithValue("@Param2", shiftPk);
                                        cmd1.Parameters.AddWithValue("@Param3", "LH");
                                        cmd1.Parameters.AddWithValue("@Param4", "A");
                                        cmd1.Parameters.AddWithValue("@Param5", invalue);

                                        cmd1.Parameters.AddWithValue("@Param6", mydate);
                                        cmd1.Parameters.AddWithValue("@Param7", Program.USERPK);
                                        cmd1.Parameters.AddWithValue("@Param8", Shifttime12);
                                        cmd1.Parameters.AddWithValue("@Param9", 0);
                                        cmd1.Parameters.AddWithValue("@Param10", 'N');
                                        cmd1.ExecuteNonQuery();




                                    }
                                }



                            }

                        }
                    }


                }

            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Correction for this Swipedata has been Already Applied");
            }
        }




        public Boolean isCorectionAppliocationPresernt(int empid, DateTime mydate)
        {
            DataTable dt = new DataTable();
            Boolean ispresent = false;


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT     CorrectionPk  FROM         CorrectionDaily_tbl WHERE     (empid = @Param1) AND (DateForSwipe = @Param2)", con))
                {
                    cmd.Parameters.AddWithValue("@Param1", empid);
                    cmd.Parameters.AddWithValue("@Param2", mydate);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    if (dt.Rows.Count != 0)
                    {
                        ispresent = true;
                    }
                }
            }
            return ispresent;
        }









        /// <summary>
        /// closes the attendance of a day on next day
        /// </summary>
        /// <param name="dt"></param>
        public void closeDataRegister(DataTable dt)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {
                con.Open();
                for (int i = 0; i < dt.Rows.Count; i++)
                {





                    SqlCommand cmd = new SqlCommand("AttendanceClosingDaily", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[i][0].ToString()));
                    cmd.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[i][1].ToString()));
                    int k = int.Parse(dt.Rows[i][2].ToString());


                    cmd.Parameters.AddWithValue("@swipepk", int.Parse(dt.Rows[i][2].ToString()));
                    cmd.Parameters.AddWithValue("@actualdate", DateTime.Parse(dt.Rows[i][3].ToString()));
                    cmd.Parameters.AddWithValue("@completedDate", Program.Datetoday);
                    cmd.Parameters.AddWithValue("@instatus", dt.Rows[i][4].ToString());
                    cmd.Parameters.AddWithValue("@outstatus", dt.Rows[i][5].ToString());
                    cmd.Parameters.AddWithValue("@shiftPk", dt.Rows[i][10].ToString());

                    cmd.ExecuteNonQuery();




                }
                con.Close();
                //    insertConsolidatedData(dt);
                //    EmployyeLeaveTakenUpdate(dt);
            }
            catch (Exception exp)
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }









        }

        /// <summary>
        /// GET ALL THE aPPROVED ot THE eMPLOYEE HAVE FOR THAT DAY
        /// </summary>
        /// <param name="nowdate"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getAllOTApllicationOfaDateandEmployee(DateTime nowdate, int empid)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(" SELECT     OtApplicationDetails_tbl.empid, OtApplicationDetails_tbl.OTDate, SUM(OtApplicationDetails_tbl.Duration) AS OTDuration, OTApproval_tbl.Islevel2, " +
 "  OtApplicationDetails_tbl.OtAppPK " +
" FROM         OTApproval_tbl INNER JOIN " +
                    "  OtApplicationDetails_tbl ON OTApproval_tbl.OTAppPK = OtApplicationDetails_tbl.OtAppPK " +
 " GROUP BY OtApplicationDetails_tbl.Isdone, OTApproval_tbl.Islevel2, OtApplicationDetails_tbl.empid, OtApplicationDetails_tbl.OtAppPK, OtApplicationDetails_tbl.OTDate " +
" HAVING      (OTApproval_tbl.Islevel2 = N'A') AND (OtApplicationDetails_tbl.empid = @empid) AND (OtApplicationDetails_tbl.OTDate = @datetoday) AND " +
                 "     (OtApplicationDetails_tbl.Isdone = N'N') ", con);



                cmd.Parameters.AddWithValue("@datetoday", nowdate);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }

        /// <summary>
        /// get all the empoloyee LHR Approved
        /// Avilable for that day
        /// </summary>
        /// <param name="nowdate"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getAlLlhrOfaDateandEmployee(DateTime nowdate, int empid)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(" SELECT     LHRDetails_tbl.LhrValue, LHRApplicationMaster_tbl.Islevel2 " +
            " FROM         LHRApplicationMaster_tbl INNER JOIN " +
   "  LHRDetails_tbl ON LHRApplicationMaster_tbl.LHRApPK = LHRDetails_tbl.LHRAppK " +
 " WHERE     (LHRDetails_tbl.empid = @empid) AND (LHRApplicationMaster_tbl.DateOfLHR = @datetoday) AND (LHRApplicationMaster_tbl.Islevel2 = N'A') AND " +
                     " (LHRDetails_tbl.IscCompleted = N'N') ", con);



                cmd.Parameters.AddWithValue("@datetoday", nowdate);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }

        /// <summary>
        /// get all thye Approved leave fo a day
        /// </summary>
        /// <param name="nowdate"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getLeaveOfaDateandEmployee(DateTime nowdate, int empid)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     LeaveMaster_tbl.LeaveCode, LeaveMaster_tbl.LeaveName " +
" FROM     EmployeeLeaveTaken_tbl INNER JOIN " +
                    "  LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk " +
"WHERE     (EmployeeLeaveTaken_tbl.dateofleave = @datetoday) AND (EmployeeLeaveTaken_tbl.empid = @empid) ", con);

                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@datetoday", nowdate);
                cmd.Parameters.AddWithValue("@empid", empid);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }


        /// <summary>
        /// 
        /// check whether the given day is enrolled as an offday for that employee
        /// if yes give back true
        /// else 
        /// false
        /// 
        /// </summary>
        /// <param name="todaydate"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public Boolean CheckWhetherEmployeeOFFday(DateTime todaydate, int empid)
        {
            Boolean offday = false;

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT     ShiftDayDetails_tbl.DayOFWeekname " +
" FROM         EmployeShift_tbl INNER JOIN " +
                    "  ShiftDayDetails_tbl ON EmployeShift_tbl.Shiftpk = ShiftDayDetails_tbl.ShiftPK " +
"WHERE     (EmployeShift_tbl.Empid = @empid) AND (ShiftDayDetails_tbl.DayStatus = N'Off Day')", con))
                {
                    cmd.Parameters.AddWithValue("@empid", empid);
                    SqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        if (rdr != null)
                        {
                            if (rdr[0].ToString() == todaydate.DayOfWeek.ToString())
                            {
                                offday = true;
                            }

                        }

                        else
                        {
                            offday = false;
                        }
                    }
                }



                con.Close();
            }




            return offday;


        }

        /// <summary>
        /// insert data to the inout exception_tbl and Emp duty table
        /// only the  swipe discrepancies are sent like that
        /// </summary>
        public void insertConsolidatedData(DataTable dt)
        {
            SqlTransaction sqltrnsctn;

            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {



                sqlConnection1.Open();
                sqltrnsctn = sqlConnection1.BeginTransaction();
                try
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        if (dt.Rows[i][4].ToString().Trim() != "P")
                        {



                            SqlCommand command = new SqlCommand("INSERT INTO INOUTException_tbl(empid, Swipepk, Satus, InorOut, Value, IsUsed,SwipeDate) VALUES  (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", sqlConnection1);
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", int.Parse(dt.Rows[i][0].ToString()));
                            command.Parameters.AddWithValue("@Param2", int.Parse(dt.Rows[i][2].ToString()));
                            command.Parameters.AddWithValue("@Param3", dt.Rows[i][4].ToString().Trim());
                            command.Parameters.AddWithValue("@Param4", "IN");
                            command.Parameters.AddWithValue("@Param5", int.Parse(dt.Rows[i][6].ToString()));
                            command.Parameters.AddWithValue("@Param6", "N");
                            command.Parameters.AddWithValue("@Param7", DateTime.Parse(dt.Rows[i][1].ToString()));
                            command.ExecuteNonQuery();




                            SqlCommand cmd = new SqlCommand("UpdatedDailyComponents_Sp", sqlConnection1);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = sqltrnsctn;

                            cmd.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[i][0].ToString()));
                            cmd.Parameters.AddWithValue("@AttendanceType", dt.Rows[i][4].ToString().Trim());
                            cmd.Parameters.AddWithValue("@attendancevalue", int.Parse(dt.Rows[i][6].ToString()));
                            cmd.ExecuteNonQuery();



                        }

                        if (dt.Rows[i][5].ToString().Trim() != "P")
                        {


                            SqlCommand command = new SqlCommand("INSERT INTO INOUTException_tbl(empid, Swipepk, Satus, InorOut, Value, IsUsed,SwipeDate) VALUES  (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", sqlConnection1);
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", int.Parse(dt.Rows[i][0].ToString()));
                            command.Parameters.AddWithValue("@Param2", int.Parse(dt.Rows[i][2].ToString()));
                            command.Parameters.AddWithValue("@Param3", dt.Rows[i][5].ToString().Trim());
                            command.Parameters.AddWithValue("@Param4", "OUT");
                            command.Parameters.AddWithValue("@Param5", int.Parse(dt.Rows[i][7].ToString()));
                            command.Parameters.AddWithValue("@Param6", "N");
                            command.Parameters.AddWithValue("@Param7", DateTime.Parse(dt.Rows[i][1].ToString()));
                            command.ExecuteNonQuery();




                            SqlCommand cmd = new SqlCommand("UpdatedDailyComponents_Sp", sqlConnection1);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = sqltrnsctn;

                            cmd.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[i][0].ToString()));
                            cmd.Parameters.AddWithValue("@AttendanceType", dt.Rows[i][5].ToString().Trim());
                            cmd.Parameters.AddWithValue("@attendancevalue", int.Parse(dt.Rows[i][7].ToString()));
                            cmd.ExecuteNonQuery();


                        }





                    }
                }
                catch (Exception exp)
                {

                    ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                    ErrorLogger er = new ErrorLogger();

                    er.createErrorLog(exp);
                }
                finally
                {

                }
                sqltrnsctn.Commit();
                sqlConnection1.Close();
            }



        }




        /// <summary>
        /// update the leave taken by employee
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public void EmployyeLeaveTakenUpdate(DateTime swipedata, DataTable dt)
        {
            try
            {
                DataTable leavedata = new DataTable();

                SqlConnection con = new SqlConnection(Program.ConnStr);
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT     LeaveCode, LeavePk FROM         LeaveMaster_tbl", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    leavedata.Load(reader);


                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    //EDITED BY SREENATH IN 26-02-2013 ADDED OT2.0 ALSO
                    if ((dt.Rows[i][5].ToString().Trim() == "A" && dt.Rows[i][4].ToString().Trim() == "A") || (dt.Rows[i][5].ToString().Trim() == "OT2.0" && dt.Rows[i][4].ToString().Trim() == "OT2.0"))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeLeaveTaken_tbl " +
             "     (Istaken, empid, dateofleave, LeavePk, Reason, Userpk, Dateadded, AddedVia) " +
" VALUES     (N'Y',@EMPID,@DATELEAVE, 0, 'A',@USERPK,@DATEADDED,'CloseRegister')", con))
                        {

                            cmd.Parameters.AddWithValue("@EMPID", int.Parse(dt.Rows[i][0].ToString()));
                            cmd.Parameters.AddWithValue("@DATELEAVE", swipedata);
                            cmd.Parameters.AddWithValue("@USERPK", Program.USERPK);
                            cmd.Parameters.AddWithValue("@DATEADDED", Program.Datetoday);
                            cmd.ExecuteNonQuery();

                        }
                    }


                    else
                    {

                        for (int j = 0; j < leavedata.Rows.Count; j++)
                        {
                            if (dt.Rows[i][5].ToString().Trim() == leavedata.Rows[j][0].ToString().Trim() && dt.Rows[i][4].ToString().Trim() == leavedata.Rows[j][0].ToString().Trim())
                            {
                                using (SqlCommand cmd = new SqlCommand("UPDATE    EmployeeLeaveTaken_tbl   SET Istaken = N'Y' WHERE     (empid = @Param2) AND (dateofleave = @Param3)", con))
                                {

                                    cmd.Parameters.AddWithValue("@Param2", int.Parse(dt.Rows[i][0].ToString()));
                                    cmd.Parameters.AddWithValue("@Param3", swipedata);
                                    cmd.ExecuteNonQuery();

                                }



                            }

                        }


                    }


                }
                con.Close();
            }
            catch (Exception exp)
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
        }

        /// <summary>
        /// enter the Employee Data To the Employee Swipe Bank
        /// </summary>
        /// <param name="dt"></param>
        public void EmployeeSwipeBankEnter(DataTable dt)
        {
            SqlTransaction sqltrnsctn;
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {



                    sqlConnection1.Open();
                    sqltrnsctn = sqlConnection1.BeginTransaction();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        using (SqlCommand command1 = new SqlCommand("INSERT INTO EmpSwipedataBank_tbl (empid, SwipeDate, SwipePK, Instatus, OutStatus, Invalue, Outvalue, Intime, Outtime,ApprInstatus ,ApprOutStatus,ShiftPk,ExtraValue,ExtraStatus) " +
        "VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14)", sqlConnection1))
                        {
                            command1.Transaction = sqltrnsctn;
                            command1.Parameters.AddWithValue("@Param1", int.Parse(dt.Rows[i][0].ToString()));
                            command1.Parameters.AddWithValue("@Param2", DateTime.Parse(dt.Rows[i][1].ToString()));
                            command1.Parameters.AddWithValue("@Param3", int.Parse(dt.Rows[i][2].ToString()));
                            command1.Parameters.AddWithValue("@Param4", dt.Rows[i][4].ToString().Trim());
                            command1.Parameters.AddWithValue("@Param5", dt.Rows[i][5].ToString().Trim());
                            if (Convert.ToString(dt.Rows[i]["InStatus"]).Trim() == "P")
                            {
                                //commented by sreenath on 19052015 to get the orginal punch of the employee if P
                                //string sg = Convert.ToString(Convert.ToDateTime(dt.Rows[i][1]).ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(dt.Rows[i]["Actualin"]).ToString("HH:mm:ss tt"));
                                //command1.Parameters.AddWithValue("@Param8", DateTime.Parse(Convert.ToDateTime(dt.Rows[i][1]).ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(dt.Rows[i]["Actualin"]).ToString("HH:mm:ss tt")));
                                //command1.Parameters.AddWithValue("@Param6", 0);

                                command1.Parameters.AddWithValue("@Param8", DateTime.Parse(dt.Rows[i][8].ToString()));
                                command1.Parameters.AddWithValue("@Param6", int.Parse(dt.Rows[i][6].ToString()));
                            }
                            else
                            {
                                command1.Parameters.AddWithValue("@Param8", DateTime.Parse(dt.Rows[i][8].ToString()));
                                command1.Parameters.AddWithValue("@Param6", int.Parse(dt.Rows[i][6].ToString()));
                            }
                            if (Convert.ToString(dt.Rows[i]["Outstatus"]).Trim() == "P")
                            {  //commented by sreenath on 19052015 to get the orginal punch of the employee if P
                                //string sg = Convert.ToString(Convert.ToDateTime(dt.Rows[i][1]).ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(dt.Rows[i]["Actualout"]).ToString("HH:mm:ss tt"));
                                //command1.Parameters.AddWithValue("@Param9", DateTime.Parse(Convert.ToDateTime(dt.Rows[i][1]).ToString("dd/MMM/yyyy") + " " + Convert.ToDateTime(dt.Rows[i]["Actualout"]).ToString("HH:mm:ss tt")));
                                //command1.Parameters.AddWithValue("@Param7", 0);
                                command1.Parameters.AddWithValue("@Param9", DateTime.Parse(dt.Rows[i][9].ToString()));
                                command1.Parameters.AddWithValue("@Param7", int.Parse(dt.Rows[i][7].ToString()));
                            }
                            else
                            {
                                command1.Parameters.AddWithValue("@Param9", DateTime.Parse(dt.Rows[i][9].ToString()));
                                command1.Parameters.AddWithValue("@Param7", int.Parse(dt.Rows[i][7].ToString()));
                            }
                            //   command1.Parameters.AddWithValue("@Param6", int.Parse(dt.Rows[i][6].ToString()));
                            //     command1.Parameters.AddWithValue("@Param7", int.Parse(dt.Rows[i][7].ToString()));
                            //command1.Parameters.AddWithValue("@Param8", DateTime.Parse(dt.Rows[i][8].ToString()));
                            // command1.Parameters.AddWithValue("@Param9", DateTime.Parse(dt.Rows[i][9].ToString()));
                            command1.Parameters.AddWithValue("@Param10", dt.Rows[i][4].ToString());
                            command1.Parameters.AddWithValue("@Param11", dt.Rows[i][5].ToString());
                            command1.Parameters.AddWithValue("@Param12", dt.Rows[i][12].ToString());
                            command1.Parameters.AddWithValue("@Param13", dt.Rows[i][13].ToString());
                            command1.Parameters.AddWithValue("@Param14", dt.Rows[i][14].ToString());
                            command1.ExecuteNonQuery();
                        }
                    }


                    sqltrnsctn.Commit();
                    sqlConnection1.Close();




                }
            }
            catch (Exception exp)
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show(MethodBase.GetCurrentMethod().ToString());
                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }

        }

        /// <summary>
        /// INSERT THE OFF DAY AOT DONE BY THE EMPLOYEE
        /// </summary>
        /// <param name="emparray"></param>
        public void insertEmployeeOffOvertime(ArrayList emparray)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeOffDayOt_tbl(empid, Date, Duration) VALUES (@Param1,@Param2,@Param3)", con))
                {
                    cmd.Parameters.AddWithValue("@Param1", emparray[0]);
                    cmd.Parameters.AddWithValue("@Param2", emparray[1]);
                    cmd.Parameters.AddWithValue("@Param3", emparray[2]);
                    cmd.ExecuteNonQuery();

                }

                SqlCommand cmd1 = new SqlCommand("UpdatedDailyComponents_Sp", con);
                cmd1.CommandType = CommandType.StoredProcedure;


                cmd1.Parameters.AddWithValue("@empid", emparray[0]);
                cmd1.Parameters.AddWithValue("@AttendanceType", "OT2.0");
                cmd1.Parameters.AddWithValue("@attendancevalue", emparray[2]);
                cmd1.ExecuteNonQuery();


                con.Close();
            }
        }

        public int getemployeeshift(int empid)
        {
            int shiftpk = 0;

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT     Shiftpk FROM         EmployeShift_tbl WHERE     (Empid = @Param1)", con))
                {
                    cmd.Parameters.AddWithValue("@Param1", empid);
                    SqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        if (rdr != null)
                        {
                            if (rdr[0].ToString() != null || rdr[0].ToString() != "")
                            {
                                shiftpk = int.Parse(rdr[0].ToString());
                            }

                        }


                    }



                }



                con.Close();
            }




            return shiftpk;


        }



        /// <summary>
        /// get the attendance of an employee 
        /// between two given dates
        /// only the closed dates data will be comming 
        /// </summary>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <param name="empid"></param>
        /// <returns></returns>

        public DataTable GetClosedAttendancebetweendate(DateTime fromdate, DateTime todate)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     EmpSwipedataBank_tbl.Swipedataid, EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmpSwipedataBank_tbl.SwipeDate, " +
                     " CONVERT(VARCHAR(8),EmpSwipedataBank_tbl.Intime,108) AS InTime, CONVERT(VARCHAR(8),EmpSwipedataBank_tbl.Outtime,108) AS OutTime, EmpSwipedataBank_tbl.Instatus, EmpSwipedataBank_tbl.OutStatus, EmpSwipedataBank_tbl.Invalue, " +
                    "  EmpSwipedataBank_tbl.Outvalue, EmpSwipedataBank_tbl.ApprInstatus, EmpSwipedataBank_tbl.ApprOutStatus, EmpSwipedataBank_tbl.IsWaved , DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) AS Duration " +
"  FROM         EmployeePersonalMaster_tbl INNER JOIN " +
                     " EmpSwipedataBank_tbl ON EmployeePersonalMaster_tbl.empid = EmpSwipedataBank_tbl.empid " +
" WHERE    (EmpSwipedataBank_tbl.SwipeDate BETWEEN @fromdate AND @todate) ", con);


                cmd.Parameters.AddWithValue("@fromdate", fromdate);
                cmd.Parameters.AddWithValue("@todate", todate);
                cmd.CommandTimeout = 0;
                //    cmd.Parameters.AddWithValue("@empid", empid);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }




        public void insertCloseregisterexception(DataTable dt)
        {


            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {


                SqlTransaction sqltrnsctn;
                sqlConnection1.Open();
                sqltrnsctn = sqlConnection1.BeginTransaction();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    using (SqlCommand command1 = new SqlCommand("INSERT INTO CloseRegException_tbl(SwipePk, empid, ExpStatus, ExpValue, SwipeDate, ACtionStatus) " +
"VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        command1.Transaction = sqltrnsctn;
                        command1.Parameters.AddWithValue("@Param1", int.Parse(dt.Rows[i][2].ToString()));
                        command1.Parameters.AddWithValue("@Param2", int.Parse(dt.Rows[i][0].ToString()));
                        command1.Parameters.AddWithValue("@Param3", dt.Rows[i][4].ToString());
                        command1.Parameters.AddWithValue("@Param4", int.Parse(dt.Rows[i][3].ToString()));
                        command1.Parameters.AddWithValue("@Param5", DateTime.Parse(dt.Rows[i][0].ToString()));
                        command1.Parameters.AddWithValue("@Param6", "N");
                        command1.ExecuteNonQuery();

                    }
                }
            }

        }


        /// <summary>
        /// get all the swipe data of the employees having th gatepass details
        /// </summary>
        /// <param name="daydate"></param>
        /// <param name="branchPK"></param>
        /// <returns></returns>
        public DataTable Getgatepassdata(DateTime daydate, int branchPK)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, " +
                    "  EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS employeeename, DesignationMaster_tbl.DesignationName, " +
                  " DepartmentMaster_tbl.DepartmentName, EmpSwipedataBank_tbl.SwipeDate, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, " +
                    "   EmpSwipedataBank_tbl.Instatus, EmpSwipedataBank_tbl.OutStatus, EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, " +

         "       EmpSwipedataBank_tbl.Actionrequired, EmpSwipedataBank_tbl.ApprInstatus, EmpSwipedataBank_tbl.ApprOutStatus, GatePassMaster_tbl.GatePassnum, " +
                    "  GatePassMaster_tbl.fromtime, GatePassMaster_tbl.totime " +
" FROM         EmpSwipedataBank_tbl INNER JOIN " +
                   "   EmployeePersonalMaster_tbl ON EmpSwipedataBank_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                 "     EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
               "       DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN " +
                   "   DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN " +
                 "     GatePassMaster_tbl ON EmployeePersonalMaster_tbl.empid = GatePassMaster_tbl.empid AND " +
                   "   EmpSwipedataBank_tbl.SwipeDate = GatePassMaster_tbl.GatepassDate" +
" WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmpSwipedataBank_tbl.SwipeDate = @Param2) ", con);


                cmd.Parameters.AddWithValue("@Param2", daydate);
                cmd.Parameters.AddWithValue("@Param1", branchPK);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }

        /// <summary>
        /// Whether the Instatus is A or P
        /// </summary>
        /// <param name="daydate"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public String checkwhetherAnEmployyeisPresent(DateTime daydate, int empid)
        {
            DataTable dt = new DataTable();
            String instatus = "A";
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     InStatus FROM         EmployeSwipeDaily_tbl WHERE     (Date = @Param1) AND (empid = @Param2) ", con);


                cmd.Parameters.AddWithValue("@Param1", daydate);
                cmd.Parameters.AddWithValue("@Param2", empid);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }

            if (dt.Rows.Count != 0)
            {
                instatus = dt.Rows[0][0].ToString();
            }


            return instatus;
        }






        public DataTable GetALLLeaveData(DateTime daydate, int branchPK)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("LeaveEmployeesOfDate_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@datetoday", daydate);
                    cmd.Parameters.AddWithValue("@BranchlctnPK", branchPK);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
            return dt;
        }

        /// <summary>
        /// Resetthe SwipeIN, SwipeOut,Approvedout,ApprovedInstatus
        /// </summary>
        /// <param name="swipedatid"></param>
        /// <param name="empid"></param>
        /// <param name="intime"></param>
        /// <param name="outtime"></param>
        /// <param name="instatus"></param>
        /// <param name="Outstatus"></param>
        public void ResestSwipeData(int swipedatid, int empid, DateTime intime, DateTime outtime, String instatus, String Outstatus)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand("UPDATE       EmpSwipedataBank_tbl " +
"SET                Intime = @Param3, Outtime = @Param4, ApprInstatus = @Param5, ApprOutStatus = @Param6" +
" WHERE        (empid = @Param1) AND (Swipedataid = @Param2)", con);

                    command.Parameters.AddWithValue("@Param1", empid);
                    command.Parameters.AddWithValue("@Param2", swipedatid);
                    command.Parameters.AddWithValue("@Param3", intime);
                    command.Parameters.AddWithValue("@Param4", outtime);
                    command.Parameters.AddWithValue("@Param5", instatus);
                    command.Parameters.AddWithValue("@Param6", Outstatus);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }


        }





        public void ResetSwipedataAndValue(int swipedatid, int empid, DateTime intime, DateTime outtime, String instatus, String Outstatus, int invalue, int outvalue)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand("UPDATE       EmpSwipedataBank_tbl " +
"SET                Intime = @Param3, Outtime = @Param4, ApprInstatus = @Param5, ApprOutStatus = @Param6 , Invalue = @Param7, Outvalue = @Param8" +
" WHERE        (empid = @Param1) AND (Swipedataid = @Param2)", con);

                    command.Parameters.AddWithValue("@Param1", empid);
                    command.Parameters.AddWithValue("@Param2", swipedatid);
                    command.Parameters.AddWithValue("@Param3", intime);
                    command.Parameters.AddWithValue("@Param4", outtime);
                    command.Parameters.AddWithValue("@Param5", instatus);
                    command.Parameters.AddWithValue("@Param6", Outstatus);
                    command.Parameters.AddWithValue("@Param7", invalue);
                    command.Parameters.AddWithValue("@Param8", outvalue);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }

        }

        public void ResetStatuses(int swipedatid, int empid, DateTime intime, DateTime outtime, String Apprinstatus, String ApprOutstatus, int invalue, int outvalue, String instatus, String Outstatus)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand("UPDATE       EmpSwipedataBank_tbl " +
"SET                Intime = @Param3, Outtime = @Param4, ApprInstatus = @Param5, ApprOutStatus = @Param6 , Invalue = @Param7, Outvalue = @Param8 ,Instatus = @Param9, OutStatus = @Param10" +
" WHERE        (empid = @Param1) AND (Swipedataid = @Param2)", con);


                    command.Parameters.AddWithValue("@Param1", empid);
                    command.Parameters.AddWithValue("@Param2", swipedatid);
                    command.Parameters.AddWithValue("@Param3", intime);
                    command.Parameters.AddWithValue("@Param4", outtime);
                    command.Parameters.AddWithValue("@Param5", Apprinstatus);
                    command.Parameters.AddWithValue("@Param6", ApprOutstatus);
                    command.Parameters.AddWithValue("@Param7", invalue);
                    command.Parameters.AddWithValue("@Param8", outvalue);
                    command.Parameters.AddWithValue("@Param9", instatus);
                    command.Parameters.AddWithValue("@Param10", Outstatus);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }

        }


        public void ResetSwipedataAndValueAndExtrastatus(int swipedatid, int empid, DateTime intime, DateTime outtime, String instatus, String Outstatus, int invalue, int outvalue,int extravalue,String Extrastatus)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand("UPDATE       EmpSwipedataBank_tbl " +
"SET                Intime = @Param3, Outtime = @Param4, ApprInstatus = @Param5, ApprOutStatus = @Param6 , Invalue = @Param7, Outvalue = @Param8 ,ExtraValue=@Param9,ExtraStatus=@Param10" +
" WHERE        (empid = @Param1) AND (Swipedataid = @Param2)", con);

                    command.Parameters.AddWithValue("@Param1", empid);
                    command.Parameters.AddWithValue("@Param2", swipedatid);
                    command.Parameters.AddWithValue("@Param3", intime);
                    command.Parameters.AddWithValue("@Param4", outtime);
                    command.Parameters.AddWithValue("@Param5", instatus);
                    command.Parameters.AddWithValue("@Param6", Outstatus);
                    command.Parameters.AddWithValue("@Param7", invalue);
                    command.Parameters.AddWithValue("@Param8", outvalue);
                    command.Parameters.AddWithValue("@Param9", extravalue);
                    command.Parameters.AddWithValue("@Param10", Extrastatus);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }

        }



        /// <summary>
        /// get raw swipes between dates
        /// 
        /// </summary>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <param name="branchlctnpk"></param>
        /// <returns></returns>

        public DataTable GetRawSwipeRecordBetweenDates(DateTime fromdate, DateTime todate, int branchlctnpk)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT        EmployeSwipeDaily_tbl.empid AS Empid, DepartmentMaster_tbl.DepartmentName AS Department, EmployeSwipeDaily_tbl.Date AS [Swipe Date], 
                         EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS Name, EmployeSwipeDaily_tbl.Swipin AS [In Time], 
                         EmployeSwipeDaily_tbl.SwipeOut AS [Out Time], EmployeSwipeDaily_tbl.InStatus AS [In Status], EmployeSwipeDaily_tbl.Outstatus AS [Out Status], 
                         ISNULL(EmployeSwipeDaily_tbl.Invalue, 0) AS [In value], ISNULL(EmployeSwipeDaily_tbl.OutValue, 0) AS [Out Value], ISNULL(OtApplicationDetails_tbl.Duration, 0) 
                         AS [Approved OT], OtApplicationDetails_tbl.durationtype AS [Duration Type], ShiftMasterNew_tbl.ShiftName AS [Shift Name]
FROM            EmployeSwipeDaily_tbl AS EmployeSwipeDaily_tbl INNER JOIN
                         EmployeePersonalMaster_tbl AS EmployeePersonalMaster_tbl ON EmployeSwipeDaily_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         ShiftMasterNew_tbl ON EmployeSwipeDaily_tbl.Shift_Pk = ShiftMasterNew_tbl.ShiftPK INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK LEFT OUTER JOIN
                         OtApplicationDetails_tbl ON EmployeSwipeDaily_tbl.Date = OtApplicationDetails_tbl.OTDate AND 
                         EmployeSwipeDaily_tbl.empid = OtApplicationDetails_tbl.empid
WHERE        (EmployeSwipeDaily_tbl.Date BETWEEN @param2 AND @param3) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1)", con);


                    cmd.Parameters.AddWithValue("@param2", fromdate.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@param3", todate.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@Param1", branchlctnpk);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
            return dt;
        }



        public DataTable GetLeaveDataBetweenDates(DateTime fromdate, DateTime todate, int branchlctnpk)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT        EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                         EmpSwipedataBank_tbl.SwipeDate, ShiftDayDetails_tbl.DayOFWeekname, ShiftDayDetails_tbl.DayStatus, EmpSwipedataBank_tbl.ApprInstatus, 
                         EmpSwipedataBank_tbl.ApprOutStatus, EmpSwipedataBank_tbl.ShiftPk, ShiftMasterNew_tbl.ShiftName, EmployeeLeaveTaken_tbl.Reason, 
                         LeaveApplicationMaster.LvAppnum, EmployeeLeaveTaken_tbl.Istaken, EmployeeLeaveTaken_tbl.AddedVia
FROM            EmpSwipedataBank_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmpSwipedataBank_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         ShiftMasterNew_tbl ON EmpSwipedataBank_tbl.ShiftPk = ShiftMasterNew_tbl.ShiftPK INNER JOIN
                         ShiftDayDetails_tbl ON ShiftMasterNew_tbl.ShiftPK = ShiftDayDetails_tbl.ShiftPK AND ShiftDayDetails_tbl.DayOFWeekname = DATENAME(dw, 
                         EmpSwipedataBank_tbl.SwipeDate) INNER JOIN
                         WorkLimitMaster_tbl ON ShiftMasterNew_tbl.ShiftPK = WorkLimitMaster_tbl.ShiftPk INNER JOIN
                         WorkLimitDetails_tbl ON WorkLimitMaster_tbl.WorkLimitPK = WorkLimitDetails_tbl.WorkLimitID AND 
                         ShiftDayDetails_tbl.DayOFWeekname = WorkLimitDetails_tbl.WeekDayName INNER JOIN
                         EmployeeLeaveTaken_tbl ON EmpSwipedataBank_tbl.SwipeDate = EmployeeLeaveTaken_tbl.dateofleave AND 
                         EmpSwipedataBank_tbl.empid = EmployeeLeaveTaken_tbl.empid LEFT OUTER JOIN
                         LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param3) AND (EmpSwipedataBank_tbl.SwipeDate BETWEEN @param1 AND @param2)
ORDER BY EmpSwipedataBank_tbl.empid, EmpSwipedataBank_tbl.SwipeDate", con);


                    cmd.Parameters.AddWithValue("@param1", fromdate.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@param2", todate.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@Param3", branchlctnpk);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
            return dt;
        }




        public DataTable GetActionDoneBetweendates(DateTime fromdate, DateTime todate, int branchlctnpk)
        {
            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT        AttendanceActionMaster_tbl.ActionId, AttendanceActionMaster_tbl.Swipedataid, AttendanceActionMaster_tbl.Empid, AttendanceActionMaster_tbl.ActionforDate, 
                         AttendanceActionMaster_tbl.ActionType, AttendanceActionMaster_tbl.FromComponent, AttendanceActionMaster_tbl.ToComponent, 
                         AttendanceActionMaster_tbl.InorOut, AttendanceActionMaster_tbl.ActionDate, AttendanceActionMaster_tbl.UserPK, AttendanceActionMaster_tbl.Isapproved, 
                         AttendanceActionMaster_tbl.ActStatus, AttendanceActionMaster_tbl.ActionValue, AttendanceActionDetails_tbl.IsLevel1, AttendanceActionDetails_tbl.IsLevel2, 
                         AttendanceActionDetails_tbl.Islevel3, AttendanceActionDetails_tbl.Level1user, AttendanceActionDetails_tbl.Level2user, AttendanceActionDetails_tbl.Level3user, 
                         AttendanceActionDetails_tbl.Iscompleted
FROM            AttendanceActionMaster_tbl INNER JOIN
                         AttendanceActionDetails_tbl ON AttendanceActionMaster_tbl.ActionId = AttendanceActionDetails_tbl.ActionId INNER JOIN
                         EmployeeDesignation_tbl ON AttendanceActionMaster_tbl.Empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param3) and (AttendanceActionMaster_tbl.ActionforDate BETWEEN @param1 AND @param2)", con);


                    cmd.Parameters.AddWithValue("@param1", fromdate.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@param2", todate.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@Param3", branchlctnpk);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();

                er.createErrorLog(exp);
            }
            return dt;
        }


        
        public void setLeavetoAbscent(int empid ,DateTime dateofleave,String Status )
        {


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"UPDATE       EmployeeLeaveTaken_tbl
SET                LeavePk = 0, Reason = 'A'
WHERE        (empid = @empid) AND (dateofleave = @dateofleave) AND (Reason = @reason)", con))
                {

                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@dateofleave", dateofleave);
                    cmd.Parameters.AddWithValue("@reason", Status);
                    
                    cmd.ExecuteNonQuery();

                }
            }
        }


    }
}

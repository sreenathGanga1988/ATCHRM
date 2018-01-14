using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ATCHRM.Transactions.Adjuster
{
    class AdjusterTranscation
    {
        AnycodeAutoGenerator anycodegenarator = null;

        /// <summary>
        /// get all data for the adjuster
        /// this is changed by sreenath on 20-02-2014
        /// </summary>
        /// <param name="branchPK"></param>
        /// <param name="fromtime"></param>
        /// <param name="totime"></param>
        /// <returns></returns>
        public DataTable GetNonAdjustedData(int branchPK ,DateTime fromtime , DateTime totime)
        {
            DataTable dt = new DataTable();
            using(SqlConnection con= new SqlConnection (Program.ConnStr ))
            {
                con.Open();



                // this is changed by sreenath on 20-02-2014
//                SqlCommand cmd = new SqlCommand("  SELECT  EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.empid, EmpSwipedataBank_tbl.SwipeDate, ShiftDayDetails_tbl.DayOFWeekname, " +
//                   "   ShiftDayDetails_tbl.DayStatus, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, EmpSwipedataBank_tbl.ApprInstatus, " +
//                    "  EmpSwipedataBank_tbl.ApprOutStatus, EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, EmpSwipedataBank_tbl.IsAdjusted, " +
//                  "    ShiftDayDetails_tbl.TotalDuration + ShiftDayDetails_tbl.BreakDuration AS TotalShifttime, WorkLimitDetails_tbl.MaxWorkLimit " +
//"FROM         EmpSwipedataBank_tbl INNER JOIN " +
//          "            EmployeShift_tbl ON EmpSwipedataBank_tbl.empid = EmployeShift_tbl.Empid INNER JOIN " +
//                   "   ShiftDayDetails_tbl ON EmployeShift_tbl.Shiftpk = ShiftDayDetails_tbl.ShiftPK AND (select datename(dw,EmpSwipedataBank_tbl.SwipeDate ) )= ShiftDayDetails_tbl.DayOFWeekname INNER JOIN " +
//                    "  WorkLimitMaster_tbl ON ShiftDayDetails_tbl.ShiftPK = WorkLimitMaster_tbl.ShiftPk INNER JOIN " +
//                     " WorkLimitDetails_tbl ON WorkLimitMaster_tbl.WorkLimitPK = WorkLimitDetails_tbl.WorkLimitID AND " +
//                    "  ShiftDayDetails_tbl.DayOFWeekname = WorkLimitDetails_tbl.WeekDayName  INNER JOIN " +
//                  "    EmployeeDesignation_tbl ON EmpSwipedataBank_tbl.empid = EmployeeDesignation_tbl.empid " +
//                   " WHERE     (EmpSwipedataBank_tbl.SwipeDate BETWEEN @Param1 AND @Param2) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param3)  "+
//                  " ORDER BY Swipedataid", con);
                      


               SqlCommand cmd = new SqlCommand("  SELECT        EmpSwipedataBank_tbl.Swipedataid AS [swipe id], EmpSwipedataBank_tbl.empid AS [Emp Id], EmpSwipedataBank_tbl.SwipeDate AS [Swipe Date], "+ 
                     "    ShiftDayDetails_tbl.DayOFWeekname AS [Day of Week], ShiftDayDetails_tbl.DayStatus AS [Day Status], EmpSwipedataBank_tbl.Intime AS [Swipe In],  "+
                  "       EmpSwipedataBank_tbl.Outtime AS [Swipe Out], EmpSwipedataBank_tbl.ApprInstatus AS InStatus, EmpSwipedataBank_tbl.ApprOutStatus AS [Out Status],  "+
                     "    EmpSwipedataBank_tbl.Invalue AS [In Value], EmpSwipedataBank_tbl.Outvalue AS [Out Value], EmpSwipedataBank_tbl.IsAdjusted AS [Is Adjusted],  "+
                    "     DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) AS Duration,  "+
                   "      ShiftDayDetails_tbl.TotalDuration + ShiftDayDetails_tbl.BreakDuration AS [Total Shift Time], WorkLimitDetails_tbl.MaxWorkLimit AS [MAX WORK LIMIT], "+
             "            DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) - WorkLimitDetails_tbl.MaxWorkLimit AS Difference1 "+
"FROM            EmpSwipedataBank_tbl INNER JOIN "+
      "                   EmployeShift_tbl ON EmpSwipedataBank_tbl.empid = EmployeShift_tbl.Empid INNER JOIN "+
              "           ShiftDayDetails_tbl ON EmployeShift_tbl.Shiftpk = ShiftDayDetails_tbl.ShiftPK AND "+
        "                     (SELECT        DATENAME(dw, EmpSwipedataBank_tbl.SwipeDate) AS Expr1) = ShiftDayDetails_tbl.DayOFWeekname INNER JOIN "+
                "         WorkLimitMaster_tbl ON ShiftDayDetails_tbl.ShiftPK = WorkLimitMaster_tbl.ShiftPk INNER JOIN "+
                   "      WorkLimitDetails_tbl ON WorkLimitMaster_tbl.WorkLimitPK = WorkLimitDetails_tbl.WorkLimitID AND  "+
                    "     ShiftDayDetails_tbl.DayOFWeekname = WorkLimitDetails_tbl.WeekDayName INNER JOIN "+
                    "     EmployeeDesignation_tbl ON EmpSwipedataBank_tbl.empid = EmployeeDesignation_tbl.empid "+
" WHERE        (EmpSwipedataBank_tbl.SwipeDate BETWEEN @Param1 AND @Param2) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param3) " +
" ORDER BY [swipe id]", con);


                   cmd.Parameters.AddWithValue("@Param1", fromtime);
                   cmd.Parameters.AddWithValue("@Param2", totime);
                   cmd.Parameters.AddWithValue("@Param3", branchPK);
                   cmd.CommandTimeout = 0;
                   SqlDataReader reader = cmd.ExecuteReader();
                   

                   dt.Load(reader);
                con.Close();
            }
            return dt;
        }



        public int  insertAdjusterdata(Datalayer .AdjusterDatabean adjstrdatabean)
        {
            anycodegenarator = new AnycodeAutoGenerator();


            using (SqlConnection connection = new SqlConnection(Program .ConnStr))
            {
                connection.Open();

               
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("ADjustrTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
              

                try
                {



                    SqlCommand cmd = new SqlCommand("INSERT INTO AdjusterMaster_tbl "+
                     " (FromDate, Todate, UserPK, BranchLctnPk, DoneOn,ad_id) "+
"VALUES     (@Param1,@Param2,@Param3,@Param4,getdate(),@Param5) ;SELECT @@IDENTITY", connection);
                    cmd.Parameters.AddWithValue("@Param1",adjstrdatabean.Fromdate );
                    cmd.Parameters.AddWithValue("@Param2",adjstrdatabean.Todate );
                    cmd.Parameters.AddWithValue("@Param3",adjstrdatabean.Userpk );
                    cmd.Parameters.AddWithValue("@Param4",adjstrdatabean.BranchlctnPk );
                    cmd.Parameters.AddWithValue("@Param5", adjstrdatabean.Aid);
                 //   cmd.Parameters.AddWithValue("@Param5","getdate()");
                    cmd.Transaction = transaction;
                    adjstrdatabean.Adjusterid = int.Parse(cmd.ExecuteScalar().ToString());


                    adjstrdatabean.Adjustercode = anycodegenarator.GETAdjusterCode(adjstrdatabean.Adjusterid);


                    SqlCommand cmd1 = new SqlCommand("UPDATE    AdjusterMaster_tbl SET  AdjusterCode =@param1 WHERE     (AdjusterID = @param2)", connection);
                    cmd1.Parameters.AddWithValue("@Param1", adjstrdatabean.Adjustercode);
                    cmd1.Parameters.AddWithValue("@Param2", adjstrdatabean.Adjusterid );
                    cmd1.Transaction = transaction;

                    cmd1.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Error occured in entering the data");
                }
                catch (Exception ex)
                {
                    ErrorLogger er = new ErrorLogger();

                    er.createErrorLog(ex);

                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                      

                        er.createErrorLog(ex2);
                    }
                }


                return adjstrdatabean.Adjusterid;
            
            }


           



        }


        /// <summary>
        /// check whether adjuster is done for any date withinthe daterange provided
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public Boolean checkifactiondone(DateTime dt1, DateTime dt2)
        {
            Boolean present = false;

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand  command= new SqlCommand ("SELECT   top 1  AdjusterID, AdjusterCode, FromDate, Todate, IsDeleted, BranchLctnPk "+
"FROM         AdjusterMaster_tbl "+
"WHERE     (IsDeleted = N'N') AND (BranchLctnPk = @Param1)",con);

                command.Parameters.AddWithValue("@Param1", Program.LOCTNPK);


                SqlDataReader reader = command.ExecuteReader();


                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count != 0)
                {

                    if (dt1 <= DateTime.Parse(dt.Rows[0][2].ToString()) || dt2<= DateTime.Parse(dt.Rows[0][3].ToString()))
                    {
                        present = true;

                    }
                }



            }


            return present;
        }


        public DataTable GetNonAdjustedDataforemployee(int branchPK, DateTime fromtime, DateTime totime, int empid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();



//                SqlCommand cmd = new SqlCommand("SELECT     EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.empid, EmpSwipedataBank_tbl.SwipeDate, ShiftDayDetails_tbl.DayOFWeekname, ShiftDayDetails_tbl.DayStatus, EmpSwipedataBank_tbl.Intime, " +
//  "                    EmpSwipedataBank_tbl.Outtime, EmpSwipedataBank_tbl.ApprInstatus, EmpSwipedataBank_tbl.ApprOutStatus, EmpSwipedataBank_tbl.Invalue, " +
// "                     EmpSwipedataBank_tbl.Outvalue, EmpSwipedataBank_tbl.IsAdjusted  , ShiftDayDetails_tbl.TotalDuration + ShiftDayDetails_tbl.BreakDuration AS duration , WorkLimitDetails_tbl.MaxWorkLimit " +
//"FROM         EmpSwipedataBank_tbl INNER JOIN " +
//                    "  EmployeeDesignation_tbl ON EmpSwipedataBank_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
//                    "  EmployeShift_tbl ON EmpSwipedataBank_tbl.empid = EmployeShift_tbl.Empid INNER JOIN " +
//                    "  ShiftDayDetails_tbl ON EmployeShift_tbl.Shiftpk = ShiftDayDetails_tbl.ShiftPK AND (select datename(dw,EmpSwipedataBank_tbl.SwipeDate ) )= ShiftDayDetails_tbl.DayOFWeekname " +
//                    " INNER JOIN WorkLimitDetails_tbl ON ShiftDayDetails_tbl.DayOFWeekname = WorkLimitDetails_tbl.WeekDayName  " +
//  " WHERE     (EmpSwipedataBank_tbl.SwipeDate BETWEEN @Param1 AND @Param2) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param3) AND (EmployeeDesignation_tbl.empid = @Param4)", con);




                SqlCommand cmd = new SqlCommand("  SELECT  EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.empid, EmpSwipedataBank_tbl.SwipeDate, ShiftDayDetails_tbl.DayOFWeekname, " +
                   "   ShiftDayDetails_tbl.DayStatus, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, EmpSwipedataBank_tbl.ApprInstatus, "+
                    "  EmpSwipedataBank_tbl.ApprOutStatus, EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, EmpSwipedataBank_tbl.IsAdjusted, "+
                  "    ShiftDayDetails_tbl.TotalDuration + ShiftDayDetails_tbl.BreakDuration AS TotalShifttime, WorkLimitDetails_tbl.MaxWorkLimit "+
"FROM         EmpSwipedataBank_tbl INNER JOIN "+
          "            EmployeShift_tbl ON EmpSwipedataBank_tbl.empid = EmployeShift_tbl.Empid INNER JOIN "+
                   "   ShiftDayDetails_tbl ON EmployeShift_tbl.Shiftpk = ShiftDayDetails_tbl.ShiftPK AND (select datename(dw,EmpSwipedataBank_tbl.SwipeDate ) )= ShiftDayDetails_tbl.DayOFWeekname INNER JOIN "+
                    "  WorkLimitMaster_tbl ON ShiftDayDetails_tbl.ShiftPK = WorkLimitMaster_tbl.ShiftPk INNER JOIN "+
                     " WorkLimitDetails_tbl ON WorkLimitMaster_tbl.WorkLimitPK = WorkLimitDetails_tbl.WorkLimitID AND "+
                    "  ShiftDayDetails_tbl.DayOFWeekname = WorkLimitDetails_tbl.WeekDayName  INNER JOIN "+
                  "    EmployeeDesignation_tbl ON EmpSwipedataBank_tbl.empid = EmployeeDesignation_tbl.empid "+
                   " WHERE     (EmpSwipedataBank_tbl.SwipeDate BETWEEN @Param1 AND @Param2) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param3) AND (EmpSwipedataBank_tbl.empid = @Param4) ", con);
                      






                //cmd.Parameters.AddWithValue("@Param1", fromtime.ToString("dd/MM/yyyy"));
                //   cmd.Parameters.AddWithValue("@Param2",totime.ToString("dd/MM/yyyy"));


                cmd.Parameters.AddWithValue("@Param1", fromtime);
                cmd.Parameters.AddWithValue("@Param2", totime);
                cmd.Parameters.AddWithValue("@Param3", branchPK);
                cmd.Parameters.AddWithValue("@Param4", empid);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;
        }


       /// <summary>
        ///  will check whether the  date is within the date range
        /// thus we can find whether the Adjuster is done or that
       /// </summary>
       /// <param name="actiondate"></param>
       /// <param name="branchlctnpk"></param>
       /// <returns></returns>
        public Boolean  isActionForTheDateDone(DateTime actiondate ,int branchlctnpk)
        {
            Boolean sucess = false ;
            DataTable dt = new DataTable();
             using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand  command= new SqlCommand ("SELECT  AdjusterID, AdjusterCode FROM AdjusterMaster_tbl  WHERE (FromDate <= @StartDate) AND (Todate >= @StartDate) AND (BranchLctnPk = @Param1)",con);

                command.Parameters.AddWithValue("@Param1", branchlctnpk);
                command.Parameters.AddWithValue("@StartDate", actiondate);
                SqlDataReader reader = command.ExecuteReader();


                dt.Load(reader);




                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ATCHRM.Controls.ATCHRMMessagebox.Show ("Adjuster Already Done for This Date : AdjusterCode :-"+dt.Rows[0][1].ToString ());
                        sucess= true;
                    
                    }

                }

             }

             return sucess;

        }



        /// <summary>
        /// ADD THE PENDING LEAVE ENTRIES TO THE eMPLOYEE LEAVE TAKEN
        /// IF ITS MISSED
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="leavedate"></param>
        /// <param name="instatus"></param>
        /// <param name="outstatus"></param>

        public void insertPendingLeavesofEmployees(int empid , DateTime leavedate ,String instatus ,String outstatus  )
        {

            using (SqlConnection con= new SqlConnection (Program.ConnStr ))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("FinalLeaveMarker_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DateofLeave", leavedate);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@instatus", instatus);
                cmd.Parameters.AddWithValue("@outstatus", outstatus);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }


        /// <summary>
        /// if there is employeeleave taken for P entry of Employee it will be removed
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="leavedate"></param>
        /// <param name="instatus"></param>
        /// <param name="outstatus"></param>
        public void RemoveAbscentdataofEmployees(int empid, DateTime leavedate, String instatus, String outstatus)
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("FinalLeaveRemover_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DateofLeave", leavedate);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@instatus", instatus);
                cmd.Parameters.AddWithValue("@outstatus", outstatus);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }




        /// <summary>
        /// get the holidays of the period 
        /// </summary>
        /// <param name="branchPK"></param>
        /// <param name="fromtime"></param>
        /// <param name="totime"></param>
        /// <returns></returns>
        public DataTable GetAllHolidayodLocation(int branchPK, DateTime fromtime, DateTime totime)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("  SELECT        HolidayDate, Holidayname FROM            OffdayMaster_tbl "+
"WHERE        (Holidayname <> 'WEEKLY OFF') AND (LocationPK = @Param3) AND (HolidayDate BETWEEN @Param1 AND @Param2)", con);
                         


                cmd.Parameters.AddWithValue("@Param1", fromtime);
                cmd.Parameters.AddWithValue("@Param2", totime);
                cmd.Parameters.AddWithValue("@Param3", branchPK);
               
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;
        }


        /// <summary>
        /// update the daystatus of the adjuster data  with the holiday assigned for that date
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="swipeid"></param>
        /// <param name="swipedate"></param>

        public void updateadjusterforHolidays(int empid ,int swipeid,DateTime swipedate,String daystatus)
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("  UPDATE       Adjuster_Details SET                Day_Status = @daystatus "+
"WHERE        (Swipe_Id = @swipeid) AND (Emp_Id = @empid) AND (Swipe_Date = @swipedate)", con);



                cmd.Parameters.AddWithValue("@daystatus", daystatus);
                cmd.Parameters.AddWithValue("@swipeid", swipeid);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@swipedate", swipedate);
                cmd.ExecuteNonQuery();


                
                con.Close();
            }
        }





        /// <summary>
        /// get the employees who had crossed OT value of 3120 in a month
        /// </summary>
        /// <param name="Adjusterpk"></param>
        /// <returns></returns>
        public DataTable GetOverOTEmployees(int Adjusterpk)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                            



                SqlCommand cmd = new SqlCommand(@"  SELECT        Adjuster_id, Adjuster_Det_Id, Swipe_Id, Emp_Id, Swipe_Date, Week_Day, Day_Status, In_Time, Out_Time, IN_Status, Out_Status, in_Value, Out_Value, Adjust_Stat, 
                         Adjust_Dura, Shift_Dura, Allow_Dura, Value_Diff,(Shift_Dura+Out_Value) as Actual_dura,((Shift_Dura+Out_Value)-Allow_Dura) as Extratime,(Adjust_Dura-Allow_Dura )as actualextra
FROM            Adjuster_Details
WHERE        (Adjuster_id =  @Adjusterpk) AND (Emp_Id IN
                             (SELECT        Emp_Id
                               FROM            (SELECT        Emp_Id, SUM(Out_Value) AS otVALUE
                                                         FROM            Adjuster_Details
                                                         GROUP BY Emp_Id, Adjuster_id, Out_Status
                                                         HAVING         (Adjuster_id = @Adjusterpk) AND (Out_Status = 'OT1.5')) AS ss
                               WHERE        (otVALUE > 3120)))", con);



                cmd.Parameters.AddWithValue("@Adjusterpk", Adjusterpk);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;
        }
        /// <summary>
        /// updates the outtime and the outvalue of the employee in the adjusted data
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="adjustdetid"></param>
        /// <param name="swipeouttime"></param>
        /// <param name="outvalue"></param>
        /// <param name="adjustdur"></param>

        public void adjustadjusterotvalues(int empid ,int adjustdetid,DateTime swipeouttime,int outvalue,int adjustdur)
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@" UPDATE       Adjuster_Details
SET                Out_Time = @swipeouttime, Out_Value = @outvalue, Adjust_Dura = @adjustdur
WHERE        (Emp_Id = @empid) AND (Adjuster_Det_Id = @adjustdetid)", con);



                cmd.Parameters.AddWithValue("@swipeouttime", swipeouttime);
                cmd.Parameters.AddWithValue("@outvalue", outvalue);
                cmd.Parameters.AddWithValue("@adjustdur", adjustdur);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@adjustdetid", adjustdetid);
                cmd.ExecuteNonQuery();



                con.Close();
            }

        }



        public void adjustCroppedOT(int empid,int adjusterid,int branchlcnpk,int otvalue)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("ExcessovertimeAdjuster_sp ", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@emploc", branchlcnpk);
                cmd.Parameters.AddWithValue("@adjusterid", adjusterid);
                cmd.Parameters.AddWithValue("@otvalue", @otvalue);
              
                cmd.ExecuteNonQuery();



                con.Close();
            }
        }



    }
}

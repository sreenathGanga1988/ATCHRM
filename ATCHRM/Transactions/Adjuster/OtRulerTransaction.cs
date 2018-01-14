using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
namespace ATCHRM.Transactions.Adjuster
{
    class OtRulerTransaction
    {

        # region closeregister

        public DataTable Getdataforcloseregister(int branchPK, DateTime nowdate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();






                SqlCommand cmd = new SqlCommand(@" SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, EmployeePersonalMaster_tbl.Last_Name, 
                         DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, EmployeSwipeDaily_tbl.Date, ShiftDayDetails_tbl.FromTime, 
                         ShiftDayDetails_tbl.ToTime, EmployeSwipeDaily_tbl.Swipin, EmployeSwipeDaily_tbl.SwipeOut, EmployeSwipeDaily_tbl.deviceid, EmployeSwipeDaily_tbl.InStatus, 
                         EmployeSwipeDaily_tbl.Outstatus, EmployeSwipeDaily_tbl.Invalue, EmployeSwipeDaily_tbl.OutValue, EmployeSwipeDaily_tbl.Duration, 
                         EmployeSwipeDaily_tbl.IsCompleted, EmployeSwipeDaily_tbl.swipePK, ShiftDayDetails_tbl.DayStatus, ShiftDayDetails_tbl.ShiftPK, 
                         EmployeePersonalMaster_tbl.oldempid, EmployeePersonalMaster_tbl.Status, SubDepartmentMaster_tbl.SubDeptName,isnull((SELECT        SUM(OtApplicationDetails_tbl.Duration) AS Expr1
FROM            OTApproval_tbl INNER JOIN
                         OtApplicationDetails_tbl ON OTApproval_tbl.OTAppPK = OtApplicationDetails_tbl.OtAppPK
WHERE        (OTApproval_tbl.Islevel2 = N'A') AND (OtApplicationDetails_tbl.OTDate = @datetoday) AND (OtApplicationDetails_tbl.Isdone = N'N') AND 
                         (OtApplicationDetails_tbl.empid =  EmployeePersonalMaster_tbl.empid)),0000) as ApprovedOT,ISNULL( ( SELECT     SUM(LHRDetails_tbl.LhrValue) 
             FROM         LHRApplicationMaster_tbl INNER JOIN 
    LHRDetails_tbl ON LHRApplicationMaster_tbl.LHRApPK = LHRDetails_tbl.LHRAppK 
 WHERE     (LHRDetails_tbl.empid = EmployeePersonalMaster_tbl.empid) AND (LHRApplicationMaster_tbl.DateOfLHR = @datetoday) AND (LHRApplicationMaster_tbl.Islevel2 = N'A') AND 
                      (LHRDetails_tbl.IscCompleted = N'N')),0000) as ApprovedLHR,ISNULL((SELECT        TOP (1) LeaveMaster_tbl.LeaveCode
FROM            EmployeeLeaveTaken_tbl INNER JOIN
                         LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk
WHERE        (EmployeeLeaveTaken_tbl.dateofleave = @datetoday) AND (EmployeeLeaveTaken_tbl.empid = EmployeePersonalMaster_tbl.empid)),'N') as ApprovedLeave,'0000' as ExtraValue,'    ' as Extrastatus
FROM            SubDepartmentMaster_tbl INNER JOIN
                         EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK ON 
                         SubDepartmentMaster_tbl.SubDeptPK = EmployeeDesignation_tbl.SubdeptPK LEFT OUTER JOIN
                         ShiftDayDetails_tbl INNER JOIN
                         EmployeSwipeDaily_tbl ON ShiftDayDetails_tbl.ShiftPK = EmployeSwipeDaily_tbl.Shift_Pk ON 
                         EmployeePersonalMaster_tbl.empid = EmployeSwipeDaily_tbl.empid
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @BranchLocationPk) AND (EmployeSwipeDaily_tbl.Date = @datetoday) AND 
                         (EmployeePersonalMaster_tbl.Status = N'A') AND (ShiftDayDetails_tbl.DayOFWeekname = @dayoffweek)
                      
                             UNION
SELECT        EmployeePersonalMaster_tbl_1.empid, EmployeePersonalMaster_tbl_1.empno, EmployeePersonalMaster_tbl_1.First_name, 
                         EmployeePersonalMaster_tbl_1.Last_Name, DesignationMaster_tbl_1.DesignationName, DepartmentMaster_tbl_1.DepartmentName, @datetoday AS Date, 
                         '1/1/1900' AS FromTime, '1/1/1900' AS ToTime, '' AS Swipin, '' AS SwipeOut, '0' AS deviceid, 'A' AS InStatus, 'A' AS Outstatus, '0' AS Invalue, '0' AS OutValue, NULL AS Duration, 
                         'N' AS IsCompleted, '0' AS swipePK, 'NA' AS DayStatus, ISNULL((SELECT     Shiftpk FROM         EmployeShift_tbl WHERE     (Empid =   EmployeePersonalMaster_tbl_1.empid)),0) AS ShiftPK, EmployeePersonalMaster_tbl_1.oldempid, EmployeePersonalMaster_tbl_1.Status, 
                         SubDepartmentMaster_tbl.SubDeptName,'00000' as ApprovedOT, '00000' as ApprovedLHR,ISNULL((SELECT        TOP (1) LeaveMaster_tbl.LeaveCode
FROM            EmployeeLeaveTaken_tbl INNER JOIN
                         LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk
WHERE        (EmployeeLeaveTaken_tbl.dateofleave = @datetoday) AND (EmployeeLeaveTaken_tbl.empid = EmployeePersonalMaster_tbl_1.empid)),'N') as ApprovedLeave, '0000' as ExtraValue,'    ' as Extrastatus
FROM            EmployeePersonalMaster_tbl AS EmployeePersonalMaster_tbl_1 INNER JOIN
                         EmployeeDesignation_tbl AS EmployeeDesignation_tbl_1 ON EmployeePersonalMaster_tbl_1.empid = EmployeeDesignation_tbl_1.empid INNER JOIN
                         EmployeShift_tbl AS EmployeShift_tbl_1 ON EmployeePersonalMaster_tbl_1.empid = EmployeShift_tbl_1.Empid INNER JOIN
                         DesignationMaster_tbl AS DesignationMaster_tbl_1 ON EmployeeDesignation_tbl_1.DesignationPk = DesignationMaster_tbl_1.DesgnationPK INNER JOIN
                         DepartmentMaster_tbl AS DepartmentMaster_tbl_1 ON EmployeeDesignation_tbl_1.DepartmeentPk = DepartmentMaster_tbl_1.DepartmentPK INNER JOIN
                         SubDepartmentMaster_tbl ON EmployeeDesignation_tbl_1.SubdeptPK = SubDepartmentMaster_tbl.SubDeptPK
WHERE        (EmployeePersonalMaster_tbl_1.empid NOT IN
                             (SELECT        empid
                               FROM            EmployeSwipeDaily_tbl AS EmployeSwipeDaily_tbl_1
                               WHERE        (Date = @datetoday))) AND (EmployeeDesignation_tbl_1.BranchLocationPK = @BranchLocationPk)
	", con);








                cmd.Parameters.AddWithValue("@BranchLocationPk", branchPK);
                cmd.Parameters.AddWithValue("@datetoday", nowdate.ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@dayoffweek", nowdate.DayOfWeek.ToString());
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;
        }

        public DataTable ShowCloseRegisteredData(int branchPK, DateTime nowdate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();






                SqlCommand cmd = new SqlCommand(@" SELECT        EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                         EmpSwipedataBank_tbl.SwipeDate, ShiftDayDetails_tbl.DayOFWeekname, ShiftDayDetails_tbl.DayStatus, EmpSwipedataBank_tbl.ApprInstatus, 
                         EmpSwipedataBank_tbl.ApprOutStatus, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, EmpSwipedataBank_tbl.Invalue, 
                         EmpSwipedataBank_tbl.Outvalue, DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) AS [Actual Duration], 
                         EmpSwipedataBank_tbl.ShiftPk, ShiftMasterNew_tbl.ShiftName, ShiftDayDetails_tbl.FromTime AS ShiftIntime, ShiftDayDetails_tbl.ToTime AS ShiftOuttime, 
                         ShiftDayDetails_tbl.TotalDuration + ShiftDayDetails_tbl.BreakDuration AS shiftDuaration, WorkLimitDetails_tbl.MaxWorkLimit AS AllowedDuration, 
                         EmpSwipedataBank_tbl.ExtraStatus, EmpSwipedataBank_tbl.ExtraValue
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
                         ShiftDayDetails_tbl.DayOFWeekname = WorkLimitDetails_tbl.WeekDayName
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @BranchLocationPk) AND (EmpSwipedataBank_tbl.SwipeDate = @datetoday) 
ORDER BY EmpSwipedataBank_tbl.empid, EmpSwipedataBank_tbl.SwipeDate
	", con);








                cmd.Parameters.AddWithValue("@BranchLocationPk", branchPK);
                cmd.Parameters.AddWithValue("@datetoday", nowdate.ToString("MM-dd-yyyy"));

                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;
        }

        public void closeDataRegister(DataTable dt, DateTime actualdate)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {
                con.Open();
                for (int i = 0; i < dt.Rows.Count; i++)
                {





                    SqlCommand cmd = new SqlCommand("AttendanceClosingDaily", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[i]["empid"].ToString()));
                    cmd.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[i]["Date"].ToString()));
                    cmd.Parameters.AddWithValue("@swipepk", int.Parse(dt.Rows[i]["swipepk"].ToString()));
                    cmd.Parameters.AddWithValue("@actualdate", actualdate);
                    cmd.Parameters.AddWithValue("@completedDate", Program.Datetoday);
                    cmd.Parameters.AddWithValue("@instatus", dt.Rows[i]["Instatus"].ToString());
                    cmd.Parameters.AddWithValue("@outstatus", dt.Rows[i]["Outstatus"].ToString());
                    cmd.Parameters.AddWithValue("@shiftPk", dt.Rows[i]["Shiftpk"].ToString());

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
                            command1.Parameters.AddWithValue("@Param1", int.Parse(dt.Rows[i]["empid"].ToString()));
                            command1.Parameters.AddWithValue("@Param2", DateTime.Parse(dt.Rows[i]["Date"].ToString()));
                            command1.Parameters.AddWithValue("@Param3", int.Parse(dt.Rows[i]["swipePK"].ToString()));
                            command1.Parameters.AddWithValue("@Param4", dt.Rows[i]["InStatus"].ToString().Trim());
                            command1.Parameters.AddWithValue("@Param5", dt.Rows[i]["Outstatus"].ToString().Trim());
                            if (Convert.ToString(dt.Rows[i]["InStatus"]).Trim() == "P")
                            {


                                command1.Parameters.AddWithValue("@Param8", DateTime.Parse(dt.Rows[i]["Swipin"].ToString()));
                                command1.Parameters.AddWithValue("@Param6", int.Parse(dt.Rows[i]["Invalue"].ToString()));
                            }
                            else
                            {
                                command1.Parameters.AddWithValue("@Param8", DateTime.Parse(dt.Rows[i]["Swipin"].ToString()));
                                command1.Parameters.AddWithValue("@Param6", int.Parse(dt.Rows[i]["Invalue"].ToString()));
                            }
                            if (Convert.ToString(dt.Rows[i]["Outstatus"]).Trim() == "P")
                            {
                                command1.Parameters.AddWithValue("@Param9", DateTime.Parse(dt.Rows[i]["SwipeOut"].ToString()));
                                command1.Parameters.AddWithValue("@Param7", int.Parse(dt.Rows[i]["OutValue"].ToString()));
                            }
                            else
                            {
                                command1.Parameters.AddWithValue("@Param9", DateTime.Parse(dt.Rows[i]["SwipeOut"].ToString()));
                                command1.Parameters.AddWithValue("@Param7", int.Parse(dt.Rows[i]["OutValue"].ToString()));
                            }
                            ;
                            command1.Parameters.AddWithValue("@Param10", dt.Rows[i]["InStatus"].ToString());
                            command1.Parameters.AddWithValue("@Param11", dt.Rows[i]["Outstatus"].ToString());
                            command1.Parameters.AddWithValue("@Param12", dt.Rows[i]["ShiftPK"].ToString());
                            command1.Parameters.AddWithValue("@Param13", dt.Rows[i]["ExtraValue"].ToString());
                            command1.Parameters.AddWithValue("@Param14", dt.Rows[i]["ExtraStatus"].ToString());
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

        public void EmployyeLeaveTakenUpdate(DateTime swipedate, DataTable dt)
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
                    if ((dt.Rows[i]["Outstatus"].ToString().Trim() == "A" && dt.Rows[i]["InStatus"].ToString().Trim() == "A") || (dt.Rows[i]["Outstatus"].ToString().Trim() == "OT2.0" && dt.Rows[i]["InStatus"].ToString().Trim() == "OT2.0"))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeLeaveTaken_tbl " +
             "     (Istaken, empid, dateofleave, LeavePk, Reason, Userpk, Dateadded, AddedVia,IsRegisterClosed) " +
" VALUES     (N'Y',@EMPID,@DATELEAVE, 0, 'A',@USERPK,@DATEADDED,'CloseRegister',N'Y')", con))
                        {

                            cmd.Parameters.AddWithValue("@EMPID", int.Parse(dt.Rows[i]["empid"].ToString()));
                            cmd.Parameters.AddWithValue("@DATELEAVE", swipedate);
                            cmd.Parameters.AddWithValue("@USERPK", Program.USERPK);
                            cmd.Parameters.AddWithValue("@DATEADDED", Program.Datetoday);
                            cmd.ExecuteNonQuery();

                        }
                    }


                    else
                    {

                        for (int j = 0; j < leavedata.Rows.Count; j++)
                        {
                            if (dt.Rows[i]["Outstatus"].ToString().Trim() == leavedata.Rows[j][0].ToString().Trim() && dt.Rows[i]["InStatus"].ToString().Trim() == leavedata.Rows[j][0].ToString().Trim())
                            {
                                using (SqlCommand cmd = new SqlCommand("UPDATE    EmployeeLeaveTaken_tbl   SET Istaken = N'Y' ,IsRegisterClosed = N'Y' WHERE     (empid = @Param2) AND (dateofleave = @Param3)", con))
                                {

                                    cmd.Parameters.AddWithValue("@Param2", int.Parse(dt.Rows[i]["empid"].ToString()));
                                    cmd.Parameters.AddWithValue("@Param3", swipedate);
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


        # endregion

        public void insertdata(DataTable dt)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    using (SqlCommand command1 = new SqlCommand(@"INSERT INTO Adjuster_Details
                         (Adjuster_id, Swipe_Id, Emp_Id, Swipe_Date, Week_Day, Day_Status, In_Time, Out_Time, IN_Status, Out_Status, in_Value, Out_Value, Adjust_Stat, Adjust_Dura, 
                         Shift_Dura, Allow_Dura, Value_Diff,DayOftheWeek,ShiftPK)
VALUES        (@adjstid,@swipedatid,@empid,@swipedate,@weekday,@daystatus,@intime,@outime,@Apprinstatus,@approutstatus,@invalue,@outvalue,@status,@adjstdur,@shiftdur,@allowedur,@valuiediff,@DayOftheWeek,@shiftpk)", sqlConnection1))
                    {

                        command1.Parameters.AddWithValue("@adjstid", int.Parse(dt.Rows[i]["Adjustid"].ToString()));
                        command1.Parameters.AddWithValue("@swipedatid", int.Parse(dt.Rows[i]["Swipedataid"].ToString()));
                        command1.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[i]["empid"].ToString()));
                        command1.Parameters.AddWithValue("@swipedate", DateTime.Parse(dt.Rows[i]["SwipeDate"].ToString()));
                        command1.Parameters.AddWithValue("@weekday", dt.Rows[i]["DayOFWeekname"].ToString());
                        command1.Parameters.AddWithValue("@daystatus", dt.Rows[i]["DayStatus"].ToString());
                        command1.Parameters.AddWithValue("@intime", DateTime.Parse(dt.Rows[i]["Intime"].ToString()));
                        command1.Parameters.AddWithValue("@outime", DateTime.Parse(dt.Rows[i]["Outtime"].ToString()));
                        command1.Parameters.AddWithValue("@Apprinstatus", dt.Rows[i]["ApprInstatus"].ToString().Trim ());
                        command1.Parameters.AddWithValue("@approutstatus", dt.Rows[i]["ApprOutStatus"].ToString().Trim ());
                        command1.Parameters.AddWithValue("@invalue", int.Parse(dt.Rows[i]["Invalue"].ToString()));
                        command1.Parameters.AddWithValue("@outvalue", int.Parse(dt.Rows[i]["Outvalue"].ToString()));
                        command1.Parameters.AddWithValue("@status", dt.Rows[i]["Ajststatus"].ToString());
                        command1.Parameters.AddWithValue("@adjstdur", int.Parse(dt.Rows[i]["Actual Duration"].ToString()));
                        command1.Parameters.AddWithValue("@shiftdur", int.Parse(dt.Rows[i]["shiftDuaration"].ToString()));
                        command1.Parameters.AddWithValue("@allowedur", int.Parse(dt.Rows[i]["AllowedDuration"].ToString()));
                        command1.Parameters.AddWithValue("@valuiediff", int.Parse(dt.Rows[i]["exrtaOutValue"].ToString()));
                        command1.Parameters.AddWithValue("@DayOftheWeek", dt.Rows[i]["DayOFWeekname"].ToString());
                        command1.Parameters.AddWithValue("@shiftpk", int.Parse(dt.Rows[i]["ShiftPk"].ToString()));
                        command1.ExecuteNonQuery();
                    }
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                MessageBox.Show(dt.Rows.Count + "Rows Entered in " + elapsedMs + "Milliseconds");
            }

        }
        public DataTable Getdataforaction(int branchPK, DateTime fromtime, DateTime totime)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                        EmpSwipedataBank_tbl.SwipeDate, 
                         ShiftDayDetails_tbl.DayOFWeekname, ShiftDayDetails_tbl.DayStatus, EmpSwipedataBank_tbl.ApprInstatus, EmpSwipedataBank_tbl.ApprOutStatus, 
                         EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, EmpSwipedataBank_tbl.Invalue,( case  when EmpSwipedataBank_tbl.ApprOutStatus ='P' then 0 else EmpSwipedataBank_tbl.Outvalue end) as Outvalue, DATEDIFF(MINUTE, 
                         EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) AS [Actual Duration], (WorkLimitDetails_tbl.MaxWorkLimit-ShiftDayDetails_tbl.TotalDuration) as AllowedOvertime , EmpSwipedataBank_tbl.ShiftPk, ShiftMasterNew_tbl.ShiftName, 
                         ShiftDayDetails_tbl.FromTime AS ShiftIntime, ShiftDayDetails_tbl.ToTime AS ShiftOuttime, (ShiftDayDetails_tbl.TotalDuration +
                         ShiftDayDetails_tbl.BreakDuration) as shiftDuaration, WorkLimitDetails_tbl.MaxWorkLimit AS AllowedDuration,EmpSwipedataBank_tbl.ExtraStatus , EmpSwipedataBank_tbl.ExtraValue ,(( DATEDIFF(MINUTE, 
                         EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime))-(WorkLimitDetails_tbl.MaxWorkLimit+30) )as RuleDifferenceValue,( EmpSwipedataBank_tbl.Outvalue-(WorkLimitDetails_tbl.MaxWorkLimit-ShiftDayDetails_tbl.TotalDuration) ) as exrtaOutValue,'000' as adjustid ,'N' as Ajststatus
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
                         ShiftDayDetails_tbl.DayOFWeekname = WorkLimitDetails_tbl.WeekDayName
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param3) AND (EmpSwipedataBank_tbl.SwipeDate BETWEEN @param1 AND @param2)  ORDER BY EmpSwipedataBank_tbl.empid, EmpSwipedataBank_tbl.SwipeDate", con);

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



        public void Final_databank(int empid, int otdur, int Extravalue, int ofotdur, int lh, int lhr, int adjid,int normaloffdayot,int holidayOT)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("FinalEmpDetailGeneration_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@Otvalue", otdur);
                cmd.Parameters.AddWithValue("@Extraminutes", Extravalue);
                cmd.Parameters.AddWithValue("@UOT", 0);
                cmd.Parameters.AddWithValue("@lh", lh);
                cmd.Parameters.AddWithValue("@ofot", ofotdur);
                cmd.Parameters.AddWithValue("@adjustid", adjid);
                cmd.Parameters.AddWithValue("@normaofot", normaloffdayot);
                cmd.Parameters.AddWithValue("@holidayofOT", holidayOT);
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();



                con.Close();
            }



        }

        public DataTable getadjustedDetailsConsol(int adjstid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.oldempid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, 
                         EmployeePersonalMaster_tbl.Last_Name, EmployeePersonalMaster_tbl.EmpNation, EmployeePersonalMaster_tbl.NationalId, 
                         EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.Incometaxnum, EmployeePersonalMaster_tbl.NSSFnum, 
                         EmployeePersonalMaster_tbl.NHIFnum, DepartmentMaster_tbl.DepartmentName, DesignationMaster_tbl.DesignationName, AdjusterConsil_tbl.Extravalue, 
                         AdjusterConsil_tbl.Otvalue, AdjusterConsil_tbl.LhValue
FROM            EmployeeDesignation_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmployeeDesignation_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         AdjusterConsil_tbl ON EmployeePersonalMaster_tbl.empid = AdjusterConsil_tbl.Empid
WHERE        (AdjusterConsil_tbl.AdjusterID = @Param1)", con);

                cmd.Parameters.AddWithValue("@Param1", adjstid);


                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;



        }

        public DataTable getadjusteddata(int adjstid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        Adjuster_Details.Adjuster_Det_Id, EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.oldempid, EmployeePersonalMaster_tbl.empno, 
                         EmployeePersonalMaster_tbl.First_name, EmployeePersonalMaster_tbl.Last_Name, EmployeePersonalMaster_tbl.EmpNation, 
                         EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.Incometaxnum, 
                         EmployeePersonalMaster_tbl.NSSFnum, EmployeePersonalMaster_tbl.NHIFnum, DepartmentMaster_tbl.DepartmentName, DesignationMaster_tbl.DesignationName,
                          Adjuster_Details.Swipe_Date, Adjuster_Details.Week_Day, Adjuster_Details.Day_Status, ShiftMasterNew_tbl.ShiftName, Adjuster_Details.In_Time, 
                         Adjuster_Details.Out_Time, Adjuster_Details.IN_Status, Adjuster_Details.Out_Status, Adjuster_Details.in_Value, Adjuster_Details.Out_Value, 
                         Adjuster_Details.Adjust_Dura, Adjuster_Details.Shift_Dura, Adjuster_Details.Allow_Dura, Adjuster_Details.Adjuster_id
FROM            EmployeeDesignation_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmployeeDesignation_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         Adjuster_Details ON EmployeePersonalMaster_tbl.empid = Adjuster_Details.Emp_Id INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         ShiftMasterNew_tbl ON Adjuster_Details.ShiftPK = ShiftMasterNew_tbl.ShiftPK
WHERE        (Adjuster_Details.Adjuster_id = @Param1) ", con);

                cmd.Parameters.AddWithValue("@Param1", adjstid);
                

                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;



        }


        public DataTable getadjustedCroppedData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.oldempid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, 
                         EmployeePersonalMaster_tbl.Last_Name, EmployeePersonalMaster_tbl.EmpNation, EmployeePersonalMaster_tbl.NationalId, 
                         EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.Incometaxnum, EmployeePersonalMaster_tbl.NSSFnum, 
                         EmployeePersonalMaster_tbl.NHIFnum, DepartmentMaster_tbl.DepartmentName, DesignationMaster_tbl.DesignationName, Adjuster_Cropped.OffOT_Dur, 
                         Adjuster_Cropped.Ot_Dura, Adjuster_Cropped.Avail_Bal
FROM            EmployeeDesignation_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmployeeDesignation_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         Adjuster_Cropped ON EmployeePersonalMaster_tbl.empid = Adjuster_Cropped.Emp_Id
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ", con);

                cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK );


                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;



        }


        /// <summary>
        /// give the list of Employess who have off day but is not present in the 
        /// employee leavetaken
        /// </summary>
        /// <returns></returns>
        public DataTable GetAddjustedOFFDaysnotRegister()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        Adjuster_Details.Adjuster_Det_Id, EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.oldempid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, 
                         EmployeePersonalMaster_tbl.Last_Name, EmployeePersonalMaster_tbl.EmpNation, EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, 
                         EmployeePersonalMaster_tbl.Incometaxnum, EmployeePersonalMaster_tbl.NSSFnum, EmployeePersonalMaster_tbl.NHIFnum, DepartmentMaster_tbl.DepartmentName, DesignationMaster_tbl.DesignationName, 
                         Adjuster_Details.Swipe_Date, Adjuster_Details.Week_Day, Adjuster_Details.Day_Status, ShiftMasterNew_tbl.ShiftName, Adjuster_Details.In_Time, Adjuster_Details.Out_Time, Adjuster_Details.IN_Status, 
                         Adjuster_Details.Out_Status, Adjuster_Details.in_Value, Adjuster_Details.Out_Value, Adjuster_Details.Adjust_Dura, Adjuster_Details.Shift_Dura, Adjuster_Details.Allow_Dura, Adjuster_Details.Adjuster_id
FROM            EmployeeDesignation_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmployeeDesignation_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         Adjuster_Details ON EmployeePersonalMaster_tbl.empid = Adjuster_Details.Emp_Id INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         ShiftMasterNew_tbl ON Adjuster_Details.ShiftPK = ShiftMasterNew_tbl.ShiftPK
WHERE        (Adjuster_Details.Day_Status = 'Off Day') AND (Adjuster_Details.Swipe_Date NOT IN
                             (SELECT        dateofleave
                               FROM            EmployeeLeaveTaken_tbl
                               WHERE        (empid = Adjuster_Details.Emp_Id))) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ", con);

                cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK);


                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;



        }


        public DataTable GetAddjustedAbscentiesnotRegister()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        Adjuster_Details.Adjuster_Det_Id, EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.oldempid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, 
                         EmployeePersonalMaster_tbl.Last_Name, EmployeePersonalMaster_tbl.EmpNation, EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, 
                         EmployeePersonalMaster_tbl.Incometaxnum, EmployeePersonalMaster_tbl.NSSFnum, EmployeePersonalMaster_tbl.NHIFnum, DepartmentMaster_tbl.DepartmentName, DesignationMaster_tbl.DesignationName, 
                         Adjuster_Details.Swipe_Date, Adjuster_Details.Week_Day, Adjuster_Details.Day_Status, ShiftMasterNew_tbl.ShiftName, Adjuster_Details.In_Time, Adjuster_Details.Out_Time, Adjuster_Details.IN_Status, 
                         Adjuster_Details.Out_Status, Adjuster_Details.in_Value, Adjuster_Details.Out_Value, Adjuster_Details.Adjust_Dura, Adjuster_Details.Shift_Dura, Adjuster_Details.Allow_Dura, Adjuster_Details.Adjuster_id, 
                         EmployeeDesignation_tbl.BranchLocationPK
FROM            EmployeeDesignation_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmployeeDesignation_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         Adjuster_Details ON EmployeePersonalMaster_tbl.empid = Adjuster_Details.Emp_Id INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         ShiftMasterNew_tbl ON Adjuster_Details.ShiftPK = ShiftMasterNew_tbl.ShiftPK
WHERE        (Adjuster_Details.Swipe_Date NOT IN
                             (SELECT        dateofleave
                               FROM            EmployeeLeaveTaken_tbl
                               WHERE        (empid = Adjuster_Details.Emp_Id) AND (Istaken = 'Y'))) AND (Adjuster_Details.IN_Status = 'A') AND (Adjuster_Details.Out_Status = 'A') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ", con);

                cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK);


                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }
            return dt;



        }


    }
}
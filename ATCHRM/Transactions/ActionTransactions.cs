using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;
namespace ATCHRM.Transactions
{
    class ActionTransactions
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

                SqlCommand cmd = new SqlCommand("SELECT     EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, "+
                 "     EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS employeeename, " +

" DesignationMaster_tbl.DesignationName, " +
               "       DepartmentMaster_tbl.DepartmentName, EmpSwipedataBank_tbl.SwipeDate, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, " +
                  "    EmpSwipedataBank_tbl.Instatus, EmpSwipedataBank_tbl.OutStatus, EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, " +
                 "     EmpSwipedataBank_tbl.Actionrequired ,EmpSwipedataBank_tbl.ApprInstatus ,   EmpSwipedataBank_tbl.ApprOutStatus , EmployeePersonalMaster_tbl.oldempid ," +
" EmpSwipedataBank_tbl.ApplyInStatus ,EmpSwipedataBank_tbl.ApplyOuttStatus ,DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) AS Duration , EmpSwipedataBank_tbl.ShiftPk FROM         EmpSwipedataBank_tbl INNER JOIN " +
            "          EmployeePersonalMaster_tbl ON EmpSwipedataBank_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                  "    EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
                "      DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN " +
             "         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK " +
" WHERE      (EmpSwipedataBank_tbl.Instatus <> N'P' or EmpSwipedataBank_tbl.OutStatus <> N'P' ) AND  (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND " +
                   "   (EmpSwipedataBank_tbl.SwipeDate = @date)", con);

               cmd.Parameters.AddWithValue("@date", nowdate.ToString ("MM-dd-yyyy"));

               String  DT = nowdate.ToString("dd-MM-yyyy");
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }

        public DataTable GetSwipeemplyeesdetailforActionWithExtrastatus(int BranchlctnPK, DateTime nowdate)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, " +
                 "     EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS employeeename, " +

" DesignationMaster_tbl.DesignationName, " +
               "       DepartmentMaster_tbl.DepartmentName, EmpSwipedataBank_tbl.SwipeDate, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, " +
                  "    EmpSwipedataBank_tbl.Instatus, EmpSwipedataBank_tbl.OutStatus, EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, " +
                 "     EmpSwipedataBank_tbl.Actionrequired ,EmpSwipedataBank_tbl.ApprInstatus ,   EmpSwipedataBank_tbl.ApprOutStatus , EmployeePersonalMaster_tbl.oldempid ," +
" EmpSwipedataBank_tbl.ApplyInStatus ,EmpSwipedataBank_tbl.ApplyOuttStatus ,DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) AS Duration , EmpSwipedataBank_tbl.ShiftPk , EmpSwipedataBank_tbl.ExtraValue , EmpSwipedataBank_tbl.ExtraStatus FROM         EmpSwipedataBank_tbl INNER JOIN " +
            "          EmployeePersonalMaster_tbl ON EmpSwipedataBank_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                  "    EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
                "      DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN " +
             "         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK " +
" WHERE      (EmpSwipedataBank_tbl.Instatus <> N'P' or EmpSwipedataBank_tbl.OutStatus <> N'P' ) AND  (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND " +
                   "   (EmpSwipedataBank_tbl.SwipeDate = @date) and EmpSwipedataBank_tbl.ExtraStatus='UOT' ", con);

                cmd.Parameters.AddWithValue("@date", nowdate.ToString("MM-dd-yyyy"));

                String DT = nowdate.ToString("dd-MM-yyyy");
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }



        public DataTable DataForNewAction(int BranchlctnPK, DateTime nowdate)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                         EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS employeeename, DesignationMaster_tbl.DesignationName, 
                         DepartmentMaster_tbl.DepartmentName, EmpSwipedataBank_tbl.SwipeDate, ShiftDayDetails_tbl.DayStatus, ShiftMasterNew_tbl.ShiftName, 
                         EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, EmpSwipedataBank_tbl.Instatus, EmpSwipedataBank_tbl.OutStatus, 
                         EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, EmpSwipedataBank_tbl.ApprInstatus, EmpSwipedataBank_tbl.ApprOutStatus, 
                         EmployeePersonalMaster_tbl.oldempid, EmpSwipedataBank_tbl.ApplyInStatus, EmpSwipedataBank_tbl.ApplyOuttStatus, EmpSwipedataBank_tbl.ExtraValue, 
                         EmpSwipedataBank_tbl.ExtraStatus, EmpSwipedataBank_tbl.Actionrequired, DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) 
                         AS Duration, EmpSwipedataBank_tbl.ShiftPk, CAST(ShiftDayDetails_tbl.FromTime AS time) AS fromtime, CAST(ShiftDayDetails_tbl.ToTime AS time) AS Totimetime, 
                         ShiftDayDetails_tbl.TotalDuration + ShiftDayDetails_tbl.BreakDuration AS ShiftDuration
FROM            EmpSwipedataBank_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmpSwipedataBank_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         ShiftDayDetails_tbl ON EmpSwipedataBank_tbl.ShiftPk = ShiftDayDetails_tbl.ShiftPK AND ShiftDayDetails_tbl.DayOFWeekname = DATENAME(dw, 
                         EmpSwipedataBank_tbl.SwipeDate) INNER JOIN
                         ShiftMasterNew_tbl ON EmpSwipedataBank_tbl.ShiftPk = ShiftMasterNew_tbl.ShiftPK
WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND (EmpSwipedataBank_tbl.SwipeDate = @date)", con);
                //   ( (EmpSwipedataBank_tbl.Instatus <> N'P') or (EmpSwipedataBank_tbl.OutStatus <> N'P')) AND
                cmd.Parameters.AddWithValue("@date", nowdate.ToString("MM-dd-yyyy"));

                String DT = nowdate.ToString("dd-MM-yyyy");
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }


        /// <summary>
        /// get the swipe of employyes who swipe on the days they have leave Applied
        /// </summary>
        /// <param name="BranchlctnPK"></param>
        /// <param name="nowdate"></param>
        /// <returns></returns>
        public DataTable Getswipeofemployeespresentonappliedleave(int BranchlctnPK, DateTime nowdate)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                         EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS employeeename, DesignationMaster_tbl.DesignationName, 
                         DepartmentMaster_tbl.DepartmentName, EmpSwipedataBank_tbl.SwipeDate, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, 
                         EmpSwipedataBank_tbl.Instatus, EmpSwipedataBank_tbl.OutStatus, EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, 
                         EmpSwipedataBank_tbl.Actionrequired, EmpSwipedataBank_tbl.ApprInstatus, EmpSwipedataBank_tbl.ApprOutStatus, EmployeePersonalMaster_tbl.oldempid, 
                         EmpSwipedataBank_tbl.ApplyInStatus, EmpSwipedataBank_tbl.ApplyOuttStatus, DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) 
                         AS Duration, EmpSwipedataBank_tbl.ShiftPk
FROM            EmpSwipedataBank_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmpSwipedataBank_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         EmployeeLeaveTaken_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeLeaveTaken_tbl.empid AND 
                         EmpSwipedataBank_tbl.SwipeDate = EmployeeLeaveTaken_tbl.dateofleave
WHERE        (EmpSwipedataBank_tbl.Instatus <> N'P') AND (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND (EmpSwipedataBank_tbl.SwipeDate = @date) OR
                         (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND (EmpSwipedataBank_tbl.SwipeDate = @date) AND (EmpSwipedataBank_tbl.OutStatus <> N'P')
						 and  (EmployeeLeaveTaken_tbl.Istaken = N'N') AND ((EmpSwipedataBank_tbl.ApprInstatus IN ('P', 'LH')) OR
                        (EmpSwipedataBank_tbl.ApprOutStatus IN ('P', 'LH', 'OT', 'OT1.5')))", con);

                cmd.Parameters.AddWithValue("@date", nowdate.ToString("MM-dd-yyyy"));

                String DT = nowdate.ToString("dd-MM-yyyy");
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }









        /// <summary>
        /// get the list of all approved present employees of a region
        /// </summary>
        /// <param name="BranchlctnPK"></param>
        /// <param name="nowdate"></param>
        /// <returns></returns>

        public DataTable GetAllpresentEmployee(int BranchlctnPK, DateTime nowdate)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     EmpSwipedataBank_tbl.Swipedataid, EmpSwipedataBank_tbl.SwipePK, EmpSwipedataBank_tbl.empid, EmployeePersonalMaster_tbl.empno, " +
                 "     EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS employeeename, " +

" DesignationMaster_tbl.DesignationName, " +
               "       DepartmentMaster_tbl.DepartmentName, EmpSwipedataBank_tbl.SwipeDate, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime, " +
                  "    EmpSwipedataBank_tbl.Instatus, EmpSwipedataBank_tbl.OutStatus, EmpSwipedataBank_tbl.Invalue, EmpSwipedataBank_tbl.Outvalue, " +
                 "     EmpSwipedataBank_tbl.Actionrequired ,EmpSwipedataBank_tbl.ApprInstatus ,   EmpSwipedataBank_tbl.ApprOutStatus , EmployeePersonalMaster_tbl.oldempid ," +
" EmpSwipedataBank_tbl.ApplyInStatus ,EmpSwipedataBank_tbl.ApplyOuttStatus ,DATEDIFF(MINUTE, EmpSwipedataBank_tbl.Intime, EmpSwipedataBank_tbl.Outtime) AS Duration , EmpSwipedataBank_tbl.ShiftPk  FROM         EmpSwipedataBank_tbl INNER JOIN " +
            "          EmployeePersonalMaster_tbl ON EmpSwipedataBank_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                  "    EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
                "      DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN " +
             "         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK " +
" WHERE      (EmpSwipedataBank_tbl.ApprInstatus = N'P' and EmpSwipedataBank_tbl.ApprOutStatus = N'P' ) AND  (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND " +
                   "   (EmpSwipedataBank_tbl.SwipeDate = @date)", con);

                cmd.Parameters.AddWithValue("@date", nowdate.ToString("MM-dd-yyyy"));

                String DT = nowdate.ToString("dd-MM-yyyy");
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }







        /// <summary>
        /// get all the leavecode and name
        /// </summary>
        /// <returns></returns>
        public DataTable  GetAllLeaveCode()
        {
            DataTable leavedata = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT     LeaveCode, LeavePk ,LeaveName FROM         LeaveMaster_tbl", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        leavedata.Load(reader);


                    }
                }
            }
            catch (Exception exp)
            {
                
                throw;
            }

            return leavedata;
        }




        public DataTable getShiftInandOutTimeOfADayofEmployee(int empid, DateTime actionDate)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        ShiftDayDetails_tbl.DayStatus, ShiftDayDetails_tbl.DayOFWeekname, ShiftDayDetails_tbl.FromTime, ShiftDayDetails_tbl.ToTime, EmpSwipedataBank_tbl.empid, 
                         EmpSwipedataBank_tbl.SwipeDate
FROM            EmpSwipedataBank_tbl INNER JOIN
                         ShiftMasterNew_tbl ON EmpSwipedataBank_tbl.ShiftPk = ShiftMasterNew_tbl.ShiftPK INNER JOIN
                         ShiftDayDetails_tbl ON ShiftMasterNew_tbl.ShiftPK = ShiftDayDetails_tbl.ShiftPK
WHERE        (ShiftDayDetails_tbl.DayOFWeekname = @Param1) AND (EmpSwipedataBank_tbl.empid = @empid) AND (EmpSwipedataBank_tbl.SwipeDate = @dateofDay)", con);

               // cmd.Parameters.AddWithValue("@dateofDay", actionDate);

                cmd.Parameters.AddWithValue("@dateofDay", actionDate.ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@Param1", actionDate.DayOfWeek.ToString ());
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);
                return dt;

            }
            catch (Exception)
            {

                throw;


            }
            finally
            {
                con.Close();
            }
        }




        /// <summary>
        /// Will add the row to attendance actionmaster andsend it for approval
        /// </summary>
        public Boolean  MarkLeaveAction(ArrayList emparry)
        {
            Boolean actionDone = true;
            DataTable Actiondata = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {
                con.Open();



                SqlCommand cmd2 = new SqlCommand("SELECT   ActionId FROM         AttendanceActionMaster_tbl WHERE     (Swipedataid = @Swipedataid) AND (Empid = @empid) AND (ActionforDate = @Actionfordate) AND  (InorOut =@Inorout) AND (ActStatus = N'Active')", con);

                cmd2.Parameters.AddWithValue("@Swipedataid", emparry[0]);
                cmd2.Parameters.AddWithValue("@empid", emparry[1]);
                cmd2.Parameters.AddWithValue("@Actionfordate", emparry[2]);
             
                cmd2.Parameters.AddWithValue("@Inorout", emparry[4]);
                SqlDataReader reader = cmd2.ExecuteReader();

                Actiondata.Load(reader);
                if (Actiondata.Rows.Count != 0)
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("You Have already made An Action for This Entry");
                    actionDone = false;
                }
                else
                {

                    if (emparry[3].ToString().Trim() == "Mark OT Type")
                    {
                        if (isOTApplicableForEmployee(int.Parse(emparry[1].ToString())))
                        {

                            SqlCommand cmd = new SqlCommand("AttendanceActionMaster_sp", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Swipedataid", emparry[0]);
                            cmd.Parameters.AddWithValue("@empid", emparry[1]);
                            cmd.Parameters.AddWithValue("@Actionfordate", emparry[2]);
                            cmd.Parameters.AddWithValue("@ActionType", emparry[3]);
                            cmd.Parameters.AddWithValue("@Inorout", emparry[4]);
                            cmd.Parameters.AddWithValue("@userpk", emparry[5]);

                            cmd.Parameters.AddWithValue("@fromComponent", emparry[6]);
                            cmd.Parameters.AddWithValue("@tocomponent", emparry[7]);
                            cmd.Parameters.AddWithValue("@actionvalue", emparry[8]);
                            cmd.ExecuteNonQuery();
                            updateappliedstatus(emparry, "Add");
                            actionDone = true;
                        }
                        else
                        {
                            ATCHRM.Controls.ATCHRMMessagebox.Show("OT cannot be Assigned to an non OT employee ");
                        }
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("AttendanceActionMaster_sp", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Swipedataid", emparry[0]);
                        cmd.Parameters.AddWithValue("@empid", emparry[1]);
                        cmd.Parameters.AddWithValue("@Actionfordate", emparry[2]);
                        cmd.Parameters.AddWithValue("@ActionType", emparry[3]);
                        cmd.Parameters.AddWithValue("@Inorout", emparry[4]);
                        cmd.Parameters.AddWithValue("@userpk", emparry[5]);

                        cmd.Parameters.AddWithValue("@fromComponent", emparry[6]);
                        cmd.Parameters.AddWithValue("@tocomponent", emparry[7]);
                        cmd.Parameters.AddWithValue("@actionvalue", 0);
                        cmd.ExecuteNonQuery();
                        updateappliedstatus(emparry, "Add");
                        actionDone = true;
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


            return actionDone;

        }




        /// <summary>
        /// get whether ot is applicable for employee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public Boolean isOTApplicableForEmployee(int empid)
        {
            Boolean isOTapplicable = false;

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT        EmployeeDesignation_tbl.empid AS Expr1
FROM            EmployeeDesignation_tbl INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK
WHERE        (EmployeeDesignation_tbl.empid = @Param1) AND (DesignationMaster_tbl.IsOTApplicable = N'Y')", con);

                    cmd.Parameters.AddWithValue("@Param1", empid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();

                    dt.Load(reader);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            isOTapplicable = true;
                        }
                        else
                        {
                            isOTapplicable = false;
                        }

                    }

                    return isOTapplicable;
                }
                catch (Exception)
                {

                    throw;


                }
                finally
                {
                    con.Close();
                }
            }
        }





        public void insertActionDetail(int actionID)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@" INSERT INTO AttendanceActionDetails_tbl
                      (ActionId)
                    VALUES     (@actionid)", con);



                cmd.Parameters.AddWithValue("@actionid", actionID);
                cmd.ExecuteNonQuery();
                con.Close();

            }


        }


        /// <summary>
        /// updates the applied statuses 
        /// </summary>
        /// <param name="emparry"></param>
        /// <param name="approvaltype"></param>
        public void updateappliedstatus(ArrayList emparry,String approvaltype)
        {



            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                if (approvaltype == "Add")
                {

                    if (emparry[4].ToString().Trim() == "IN")
                    {

                        SqlCommand cmd = new SqlCommand("UPDATE       EmpSwipedataBank_tbl SET   ApplyInStatus = @Param2 WHERE        (Swipedataid = @Param1)", sqlConnection1);
                        cmd.Parameters.AddWithValue("@Param1", emparry[0]);
                        cmd.Parameters.AddWithValue("@Param2", emparry[7]);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE       EmpSwipedataBank_tbl SET                ApplyOuttStatus = @Param2 WHERE        (Swipedataid = @Param1)", sqlConnection1);
                        cmd.Parameters.AddWithValue("@Param1", emparry[0]);
                        cmd.Parameters.AddWithValue("@Param2", emparry[7]);
                        cmd.ExecuteNonQuery();
                    }
                 
                }
                else
                {
                    if (emparry[4].ToString().Trim() == "IN")
                    {

                        SqlCommand cmd = new SqlCommand("UPDATE       EmpSwipedataBank_tbl SET                ApplyInStatus = N'NA' WHERE        (Swipedataid = @Param1)", sqlConnection1);
                        cmd.Parameters.AddWithValue("@Param1", emparry[0]);
                        cmd.Parameters.AddWithValue("@Param2", emparry[7]);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE       EmpSwipedataBank_tbl SET                ApplyOuttStatus = N'NA' WHERE        (Swipedataid = @Param1)", sqlConnection1);
                        cmd.Parameters.AddWithValue("@Param1", emparry[0]);
                        cmd.Parameters.AddWithValue("@Param2", emparry[7]);
                        cmd.ExecuteNonQuery();
                    }
                }


                sqlConnection1.Close();
            }






           
            



        }



        ///// <summary>
        /// get the employe actionDone
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllActionDone(int BranchlctnPK, DateTime nowdate, string actionType)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     AttendanceActionMaster_tbl.ActionId, AttendanceActionMaster_tbl.Swipedataid, AttendanceActionMaster_tbl.Empid, EmployeePersonalMaster_tbl.empno, "+
                     " EmployeePersonalMaster_tbl.First_name, DepartmentMaster_tbl.DepartmentName, AttendanceActionMaster_tbl.ActionforDate, AttendanceActionMaster_tbl.ActionType, AttendanceActionMaster_tbl.FromComponent , " +
                   "    AttendanceActionMaster_tbl.ToComponent, AttendanceActionMaster_tbl.InorOut ,AttendanceActionMaster_tbl.ActStatus" +
" FROM         AttendanceActionDetails_tbl INNER JOIN "+
                  "    AttendanceActionMaster_tbl ON AttendanceActionDetails_tbl.ActionId = AttendanceActionMaster_tbl.ActionId INNER JOIN " +
                "      EmployeePersonalMaster_tbl ON AttendanceActionMaster_tbl.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                "      EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN "+
                 "     DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK  "+
" WHERE     (AttendanceActionDetails_tbl.IsLevel1 = N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK)   " +
            "          AND (AttendanceActionMaster_tbl.ActionforDate = @date)AND ((AttendanceActionMaster_tbl.ActStatus = N'Active') or(AttendanceActionMaster_tbl.ActStatus = N'Hold') )", con);



                cmd.Parameters.AddWithValue("@date", nowdate.ToString ("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.CommandTimeout = 0;
               // cmd.Parameters.AddWithValue("@actiontype", actionType);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }



        ///// <summary>
        /// get the employe actionDone
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllActionForApproval(int BranchlctnPK, DateTime nowdate, int actionlevel)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetDataForActionApproval_sp ", con);


                 cmd.CommandType = CommandType.StoredProcedure;


                 cmd.Parameters.AddWithValue("@ActionDate", nowdate.ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                cmd.Parameters.AddWithValue("@approvalevel", actionlevel);
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }



        /// <summary>
        /// get all missing Actions
        /// </summary>
        /// <param name="BranchlctnPK"></param>
        /// <param name="nowdate"></param>
        /// <param name="actionlevel"></param>
        /// <returns></returns>
        public DataTable GetAllMissingDataForApproval(DateTime nowdate)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT DISTINCT AttendanceActionMaster_tbl.ActionId
FROM            AttendanceActionMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON AttendanceActionMaster_tbl.Empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @branclctnpk) AND (AttendanceActionMaster_tbl.ActionforDate = @dateofaction) AND AttendanceActionMaster_tbl.ActionId NOT IN( 
SELECT DISTINCT AttendanceActionDetails_tbl.ActionId
FROM            AttendanceActionDetails_tbl INNER JOIN
                         AttendanceActionMaster_tbl ON AttendanceActionDetails_tbl.ActionId = AttendanceActionMaster_tbl.ActionId INNER JOIN
                         EmployeeDesignation_tbl ON AttendanceActionMaster_tbl.Empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @branclctnpk) AND (AttendanceActionMaster_tbl.ActionforDate = @dateofaction))", con);


                

              
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@branclctnpk", Program.LOCTNPK);
                cmd.Parameters.AddWithValue("@dateofaction",nowdate.ToString ("MM-dd-yyyy"));
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }





        /// <summary>
        /// get the outime of a specific swipe of an emp
        /// </summary>
        /// <param name="swipeid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DateTime  choosedateforSwipe( int swipeid ,int empid )
        {
            DataTable dt = new DataTable();
            DateTime swipeouttime = DateTime.Now;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SELECT  Outtime  FROM   EmpSwipedataBank_tbl WHERE        (Swipedataid = @swipedatid) AND (empid = @empid) ", con);
                    cmd1.Parameters.AddWithValue("@swipedatid", swipeid );
                    cmd1.Parameters.AddWithValue("@empid", empid);
                    SqlDataReader reader = cmd1.ExecuteReader();

                    dt.Load(reader);


                    if (dt != null)
                    {
                        if (dt.Rows.Count!=0)
                        {
                            swipeouttime = DateTime.Parse ( dt.Rows[0][0].ToString());
                        }
                    }
            }
            return swipeouttime;

        }




        /// <summary>
        /// mark the Employee Present in the Afternoon
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="swipepk"></param>
        /// <param name="actionfordate"></param>
        /// <param name="newswipeouttime"></param>
        public void MarkEmployeePresentInAfterNoon(int empid, int swipepk, DateTime actionfordate, DateTime newswipeouttime)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("UPDATE       EmpSwipedataBank_tbl "+
"SET                Outvalue = @outvalue, OutStatus = @outstatus, ApprOutStatus = @apprvoutstatus, Outtime = @outtime "+
 " WHERE        (Swipedataid = @swipedatid) AND (empid = @empid) AND (SwipeDate = @swipedate)", con);



                    cmd1.Parameters.AddWithValue("@outvalue", 0);
                    cmd1.Parameters.AddWithValue("@outstatus", "P");
                    cmd1.Parameters.AddWithValue("@apprvoutstatus", "P");
                    cmd1.Parameters.AddWithValue("@outtime", newswipeouttime);
                    cmd1.Parameters.AddWithValue("@swipedatid", swipepk);
                    cmd1.Parameters.AddWithValue("@empid", empid);
                    cmd1.Parameters.AddWithValue("@swipedate", actionfordate);

                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exp)
            {
                
                 ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                
            }

        }




        public void MarkEUOTEmployeePresentinAfternoon(int empid, int swipepk, DateTime actionfordate)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("UPDATE       EmpSwipedataBank_tbl " +
"SET                Outvalue = @outvalue, OutStatus = @outstatus, ApprOutStatus = @apprvoutstatus" +
 " WHERE        (Swipedataid = @swipedatid) AND (empid = @empid) AND (SwipeDate = @swipedate)", con);



                    cmd1.Parameters.AddWithValue("@outvalue", 0);
                    cmd1.Parameters.AddWithValue("@outstatus", "P");
                    cmd1.Parameters.AddWithValue("@apprvoutstatus", "P");
                    cmd1.Parameters.AddWithValue("@swipedatid", swipepk);
                    cmd1.Parameters.AddWithValue("@empid", empid);
                    cmd1.Parameters.AddWithValue("@swipedate", actionfordate);

                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }

        }





/// <summary>
/// delete the actionrequested
/// </summary>
/// <param name="actnarray"></param>
        public void Deleteactions(ArrayList actnarray)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM AttendanceActionMaster_tbl " +
" WHERE     (ActionId = @actionid) AND (Swipedataid = @swipedataid) AND (Empid = @empid) AND (InorOut = @inorout) AND (ActionType = @actionstype)", con);

                SqlCommand cmd1 = new SqlCommand("DELETE FROM AttendanceActionDetails_tbl " +
" WHERE     (ActionId = @actionid) ", con);

                cmd.Parameters.AddWithValue("@actionid", actnarray[0]);
                cmd.Parameters.AddWithValue("@swipedataid", actnarray[1]);
                cmd.Parameters.AddWithValue("@empid", actnarray[2]);
                cmd.Parameters.AddWithValue("@inorout", actnarray[3]);
                cmd.Parameters.AddWithValue("@actionstype", actnarray[4]);

                cmd1.Parameters.AddWithValue("@actionid", actnarray[0]);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
            }

        }



/// <summary>
/// mark An Action In Hold or Unhold
/// </summary>
/// <param name="actnarray"></param>
        public void UpdateAttndHoldAction(ArrayList actnarray ,String action)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE    AttendanceActionMaster_tbl SET    ActStatus = @action " +
" WHERE     (ActionId = @actionid) AND (Swipedataid = @swipedataid) AND (Empid = @empid) AND (InorOut = @inorout) AND (ActionType = @actionstype)", con);


                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@actionid", actnarray[0]);
                cmd.Parameters.AddWithValue("@swipedataid", actnarray[1]);
                cmd.Parameters.AddWithValue("@empid", actnarray[2]);
                cmd.Parameters.AddWithValue("@inorout", actnarray[3]);
                cmd.Parameters.AddWithValue("@actionstype", actnarray[4]);

                cmd.ExecuteNonQuery();

                con.Close();
            }

        }






    // <summary>
/// mark An Action In Hold or Unhold
/// </summary>
/// <param name="actnarray"></param>
        public void UpdateAttndAppovalAction(ArrayList actnarray, int actionlevel)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                if(actionlevel==1 )
                {
                    SqlCommand cmd = new SqlCommand("UPDATE    AttendanceActionDetails_tbl SET   IsLevel1 = N'A' , Level1user = @userpk WHERE   (ActionId = @actionid)", con);


                    cmd.Parameters.AddWithValue("@actionid",int.Parse ( actnarray [0].ToString ()));
                    cmd.Parameters.AddWithValue("@userpk", Program.USERPK );
                    cmd.ExecuteNonQuery();
                }
                else if (actionlevel == 2)
                {

                    SqlCommand cmd1 = new SqlCommand("UPDATE    AttendanceActionDetails_tbl SET   IsLevel2 = N'A', Level2user = @userpk WHERE   (ActionId = @actionid)", con);


                    cmd1.Parameters.AddWithValue("@actionid", int.Parse(actnarray[0].ToString()));
                    cmd1.Parameters.AddWithValue("@userpk", Program.USERPK);
                    cmd1.ExecuteNonQuery();
                }
                else if (actionlevel == 3)
                {

                    SqlCommand cmd1 = new SqlCommand("UPDATE    AttendanceActionDetails_tbl SET   Islevel3 = N'A', Level3user = @userpk WHERE   (ActionId = @actionid)", con);


                    cmd1.Parameters.AddWithValue("@actionid", int.Parse(actnarray[0].ToString()));
                    cmd1.Parameters.AddWithValue("@userpk", Program.USERPK);
                    cmd1.ExecuteNonQuery();
                }

               
                con.Close();
            }

        }

 
/// <summary>
/// get the list of all employees who are not entitled for OT
/// </summary>
/// <param name="Branchlctnpk"></param>
/// <returns></returns>
        public DataTable  GetNonOTEmployees(int Branchlctnpk)
        {


            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT        EmployeeDesignation_tbl.empid, DesignationMaster_tbl.IsOTApplicable
FROM            EmployeeDesignation_tbl INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @BranchlctnPK) AND (DesignationMaster_tbl.IsOTApplicable = N'N') ", con);




                    cmd.Parameters.AddWithValue("@BranchlctnPK", Branchlctnpk);
                    cmd.CommandTimeout = 0;
                    // cmd.Parameters.AddWithValue("@actiontype", actionType);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }


        }

  










    
    
    }







}

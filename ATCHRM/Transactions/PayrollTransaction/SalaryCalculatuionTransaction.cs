using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ATCHRM.Transactions.PayrollTransaction
{
    class SalaryCalculatuionTransaction
    {

      


        ///// <summary>
        /// get the employe component values
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployeeduties(int empid)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT   EmpDutyId, LH, UOT,  OT, OffOT, LHR  FROM FinalEmployeeDuty_tbl WHERE (empid = @empid)", con);




                    cmd.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                  


                }
            }
            return dt;


        }

        public DataTable getAllLeakeTaken(int empid , DateTime fromdate ,DateTime todate )
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
               try
                {
                   
                   con.Open();

                   SqlCommand cmd = new SqlCommand("SELECT   EmployeeLeaveTaken_tbl.Leaveid,   EmployeeLeaveTaken_tbl.dateofleave,  LeaveMaster_tbl.LeaveCode, LeaveApplicationMaster.LvAppnum, EmployeeLeaveTaken_tbl.Istaken , EmployeeLeaveTaken_tbl.Reason" +
" FROM         EmployeeLeaveTaken_tbl LEFT JOIN "+
         "             LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk LEFT JOIN " +
                 "     LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk " +
 "WHERE     (EmployeeLeaveTaken_tbl.empid = @empid) AND (EmployeeLeaveTaken_tbl.dateofleave BETWEEN @fromdate AND @todate) AND  " +
                   "   (EmployeeLeaveTaken_tbl.Istaken = N'Y')", con);




                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@fromdate", fromdate);
             //   cmd.Parameters.AddWithValue("@fromdate", fromdate.ToString("MM-dd-yyyy"));
             //   cmd.Parameters.AddWithValue("@todate", todate.ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@todate", todate);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();  }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                  


                }
            }
            return dt;


        }

            /// <summary>
        ///returns the LH left fo rthat person
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int getClosedRegisterDays(int empid, DateTime fromdate, DateTime todate)
        {

            int closeddays = 0;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT     COUNT(*) AS Expr1, SwipeDate FROM    EmpSwipedataBank_tbl " +
    " GROUP BY SwipeDate, IsWaved HAVING      (SwipeDate BETWEEN @fromdate AND @todate)AND (IsWaved = N'N')", con);
                    command.Parameters.AddWithValue("@Param1", empid);
                    command.Parameters.AddWithValue("@fromdate", fromdate.ToString("MM-dd-yyyy"));
                    command.Parameters.AddWithValue("@todate", todate.ToString("MM-dd-yyyy"));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            closeddays = int.Parse(reader[0].ToString());

                        }
                    }


                    reader.Close();
                }
                catch (Exception exp)
                {
                    
                    
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                }

            }
            return closeddays;
        }



        /// <summary>
        /// get the number of off days between two periods of a employee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        public int GetoffdayOfEmployeeeInPeriod(int empid, DateTime fromdate, DateTime todate)
        {
            int closeddays = 0;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT  count (  distinct    EmployeeLeaveTaken_tbl.dateofleave) " +
"FROM            Adjuster_Details INNER JOIN "+
      "                   EmployeeLeaveTaken_tbl ON Adjuster_Details.Swipe_Date = EmployeeLeaveTaken_tbl.dateofleave AND  "+
         "                Adjuster_Details.Emp_Id = EmployeeLeaveTaken_tbl.empid "+
"WHERE        (Adjuster_Details.Day_Status = 'Off Day') AND (Adjuster_Details.Emp_Id = @Param1) AND (EmployeeLeaveTaken_tbl.dateofleave BETWEEN @fromdate AND @todate)", con);
                    command.Parameters.AddWithValue("@Param1", empid);
                    command.Parameters.AddWithValue("@fromdate", fromdate.ToString("MM-dd-yyyy"));
                    command.Parameters.AddWithValue("@todate", todate.ToString("MM-dd-yyyy"));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            closeddays = int.Parse(reader[0].ToString());

                        }
                    }


                    reader.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                    ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                }

            }
            return closeddays;
        }



        /// <summary>
        /// get the number of holidays in a period
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>

        public int  getemployeeHolidayinPeriod(int empid, DateTime fromdate, DateTime todate)
        {
            int holidaynum = 0;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT       Count (distinct Swipe_Date) FROM            Adjuster_Details "+
"WHERE        (Day_Status <> 'Working Day') AND (Day_Status <> 'Off Day') AND (Emp_Id = @empid) and (Swipe_Date between @fromdate and @todate)", con);
                    command.Parameters.AddWithValue("@empid", empid);
                    command.Parameters.AddWithValue("@fromdate", fromdate.ToString("MM-dd-yyyy"));
                    command.Parameters.AddWithValue("@todate", todate.ToString("MM-dd-yyyy"));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            holidaynum = int.Parse(reader[0].ToString());

                        }
                    }


                    reader.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                    ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                }

            }
            return holidaynum;
        }



        public int getLeaveOnOffDays(int empid, DateTime fromdate, DateTime todate)
        {
            int LeaveonOFF = 0;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(@"SELECT        Count (distinct EmployeeLeaveTaken_tbl.dateofleave) 
FROM            EmployeeLeaveTaken_tbl INNER JOIN
                         Adjuster_Details ON EmployeeLeaveTaken_tbl.empid = Adjuster_Details.Emp_Id AND 
                         EmployeeLeaveTaken_tbl.dateofleave = Adjuster_Details.Swipe_Date INNER JOIN
                         LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk
WHERE        (Adjuster_Details.Day_Status = 'Off Day') and (EmployeeLeaveTaken_tbl.dateofleave between @fromdate and @todate) and  (EmployeeLeaveTaken_tbl.empid = @empid) ", con);
                    command.Parameters.AddWithValue("@empid", empid);
                    command.Parameters.AddWithValue("@fromdate", fromdate.ToString("MM-dd-yyyy"));
                    command.Parameters.AddWithValue("@todate", todate.ToString("MM-dd-yyyy"));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            LeaveonOFF = int.Parse(reader[0].ToString());

                        }
                    }


                    reader.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                    ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                }

            }
            return LeaveonOFF;
        }


        public int getLeaveOnHoliDays(int empid, DateTime fromdate, DateTime todate)
        {
            int LeaveonOFF = 0;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(@"SELECT        Count (distinct EmployeeLeaveTaken_tbl.dateofleave) 
FROM            EmployeeLeaveTaken_tbl INNER JOIN
                         Adjuster_Details ON EmployeeLeaveTaken_tbl.empid = Adjuster_Details.Emp_Id AND 
                         EmployeeLeaveTaken_tbl.dateofleave = Adjuster_Details.Swipe_Date INNER JOIN
                         LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk
WHERE        (Adjuster_Details.Day_Status != 'Off Day') and (Adjuster_Details.Day_Status != 'Working Day') and(EmployeeLeaveTaken_tbl.dateofleave between @fromdate and @todate) and  (EmployeeLeaveTaken_tbl.empid = @empid) ", con);
                    command.Parameters.AddWithValue("@empid", empid);
                    command.Parameters.AddWithValue("@fromdate", fromdate.ToString("MM-dd-yyyy"));
                    command.Parameters.AddWithValue("@todate", todate.ToString("MM-dd-yyyy"));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            LeaveonOFF = int.Parse(reader[0].ToString());

                        }
                    }


                    reader.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                    ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                }

            }
            return LeaveonOFF;
        }

        /// <summary>
        /// get sal Component of employee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getEmployeeSalComponents(int empid)        
        {



             DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(" SELECT      EmployeesalCompApplicable_tbl.SalcompPk, SalComponentMaster_tbl.ComponentName, ComponentType_tbl.ComponentType, EmployeesalCompApplicable_tbl.Amount, " +
                         " ComponentCalMaster_tbl.CalculationType " +
    " FROM         EmployeesalCompApplicable_tbl INNER JOIN " +
                     "     SalComponentMaster_tbl ON EmployeesalCompApplicable_tbl.SalcompPk = SalComponentMaster_tbl.SalcompPk INNER JOIN " +
                       "   ComponentType_tbl ON SalComponentMaster_tbl.Componenttypepk = ComponentType_tbl.Componenttypepk INNER JOIN " +
                       "   ComponentCalMaster_tbl ON SalComponentMaster_tbl.Caluculationpk = ComponentCalMaster_tbl.Caluculationpk WHERE     (EmployeesalCompApplicable_tbl.empid = @empid)", con);




                    cmd.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }
                catch (Exception exp)
                {
                    
                      ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                }
            }
            return dt;











        }




        public DataTable getallemployeeOffOt(int branchlocationpk, DateTime fromdate, DateTime todate)
        {


          DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("    SELECT     EmployeeOffDayOt_tbl.EmpOtId, EmployeeOffDayOt_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, " +
                       "   EmployeePersonalMaster_tbl.Last_Name, DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, EmployeeOffDayOt_tbl.Date, " +
                     "     EmployeeOffDayOt_tbl.Duration " +
    "FROM         EmployeeOffDayOt_tbl INNER JOIN " +
                    "      EmployeePersonalMaster_tbl ON EmployeeOffDayOt_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                      "    EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
                        "  DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN " +
                       "   DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK " +
    "WHERE     (EmployeeOffDayOt_tbl.Date BETWEEN @Param1 AND @Param2) AND (EmployeeDesignation_tbl.BranchLocationPK = @Branchpk) ", con);




                    cmd.Parameters.AddWithValue("@Branchpk", branchlocationpk);
                    cmd.Parameters.AddWithValue("@Param1", fromdate);
                    cmd.Parameters.AddWithValue("@Param2", todate);



                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }
                catch (Exception exp)
                {
                    
                     ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                }
            }
            return dt;



        }
    
    
    
    
    
    
    
    
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql ;
using System.Data;
using System.Collections;

namespace ATCHRM.Transactions
{
    class LeaveTransaction
    {

        /// <summary>
        /// insert new leave to Leave master
        /// </summary>
        /// <param name="leavedatabean"></param>
        public void insertLeavedata(Datalayer.LeaveDataBean  leavedatabean)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("INSERT INTO LeaveMaster_tbl(LeaveName, LeaveType, Description, Isenchasable, IsMaleapp, IsWomenapp, EnchasableDays, DateAdded, userPk ,Allowedleave,LeaveCode ,IsCarryForward ,CalculationUpto ,ConsiderAlso)" +
                " VALUES(@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10 ,@Param11,@Param12 ,@Param13,@Param14)", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", leavedatabean.Leavename);
                command.Parameters.AddWithValue("@Param2", leavedatabean.Leavecaltype);
                command.Parameters.AddWithValue("@Param3", leavedatabean.Description);
                command.Parameters.AddWithValue("@Param5", leavedatabean.Isencashable);
                command.Parameters.AddWithValue("@Param4", leavedatabean.Ismaleapp);
                command.Parameters.AddWithValue("@Param6", leavedatabean.Isfemaleapp);
                command.Parameters.AddWithValue("@Param7", leavedatabean.Enchasabledays);
                command.Parameters.AddWithValue("@Param8", DateTime.Now.Date);
                command.Parameters.AddWithValue("@Param9", Program.USERPK);
                command.Parameters.AddWithValue("@Param10", leavedatabean.Allowedleave);
                command.Parameters.AddWithValue("@Param11", leavedatabean.LeaveCode1 );
                command.Parameters.AddWithValue("@Param12", leavedatabean.IsCarryFowardable);
                command.Parameters.AddWithValue("@Param13", leavedatabean.CalculateUpto1 );
                command.Parameters.AddWithValue("@Param14", leavedatabean.ConsiderAlso1 );
                command.ExecuteNonQuery();
                sqlConnection1.Close();
            }
        }
        /// <summary>
        /// get all the leaves and their features from masters
        /// </summary>
        /// <returns></returns>
        public DataTable getAllLeaveData()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT LeavePk AS SL, LeaveName AS LEAVE, Description AS DESCRPT, LeaveType AS CALCULATED, EnchasableDays AS [ENHASABLE DAYS], IsMaleapp AS [FOR MEN], IsWomenapp AS [FOR WOMEN] , Allowedleave AS  ALLOWED , LeaveCode as LEAVECODE ,CalculationUpto as [Calculate Upto] ,  ConsiderAlso as Consider   FROM  LeaveMaster_tbl", con);

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
        /// get all the leave taken by the employee  entered against the 
        ///
        /// </summary>
        /// <returns></returns>
        public DataTable getAllEmployeeLeavetaken(int empid ,String istaken ,DateTime  fromdate,DateTime todate)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     EmployeeLeaveTaken_tbl.Leaveid, EmployeeLeaveTaken_tbl.LeavePk, EmployeeLeaveTaken_tbl.dateofleave, LeaveMaster_tbl.LeaveName,"+ 
                   "   LeaveMaster_tbl.LeaveType, LeaveApplicationMaster.LvAppnum, EmployeeLeaveTaken_tbl.Reason, EmployeeLeaveTaken_tbl.empid, "+
                     " EmployeeLeaveTaken_tbl.Istaken "+
" FROM         EmployeeLeaveTaken_tbl LEFT OUTER JOIN " +
                     " LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk LEFT OUTER JOIN "+
                     " LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk "+
"WHERE     (EmployeeLeaveTaken_tbl.empid = @empid) AND (EmployeeLeaveTaken_tbl.Istaken = @Istaken) AND (EmployeeLeaveTaken_tbl.dateofleave BETWEEN " + 
                  "    @fromdate AND @todate)", con);
                cmd.Parameters.AddWithValue("@empid",empid);
                cmd.Parameters.AddWithValue("@Istaken", istaken);
                cmd.Parameters.AddWithValue("@fromdate", fromdate);
                cmd.Parameters.AddWithValue("@todate", todate);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);
                return dt;

            }
            catch (Exception exp)
            {

                throw;


            }
            finally
            {
                con.Close();
            }
        }





        public DataTable getAllEmployeeLeavetaken(int empid)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     EmployeeLeaveTaken_tbl.Leaveid, EmployeeLeaveTaken_tbl.LeavePk, EmployeeLeaveTaken_tbl.dateofleave, LeaveMaster_tbl.LeaveName," +
                   "   LeaveMaster_tbl.LeaveType, LeaveApplicationMaster.LvAppnum, EmployeeLeaveTaken_tbl.Reason, EmployeeLeaveTaken_tbl.empid, " +
                     " EmployeeLeaveTaken_tbl.Istaken " +
" FROM         EmployeeLeaveTaken_tbl LEFT OUTER JOIN " +
                     " LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk LEFT OUTER JOIN " +
                     " LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk " +
"WHERE     (EmployeeLeaveTaken_tbl.empid = @empid) AND (EmployeeLeaveTaken_tbl.Istaken = 'Y') ", con);
                cmd.Parameters.AddWithValue("@empid", empid);
                
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);
                return dt;

            }
            catch (Exception exp)
            {

                throw;


            }
            finally
            {
                con.Close();
            }
        }







        public DataTable getAbscentandLeaveofaLocation(int branchlocationpk, String istaken, DateTime fromdate, DateTime todate)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     EmployeeLeaveTaken_tbl.Leaveid,   EmployeeLeaveTaken_tbl.dateofleave AS Date, DepartmentMaster_tbl.DepartmentName, DesignationMaster_tbl.DesignationName, " +
                "         EmployeePersonalMaster_tbl.empno AS [Emp  Num], EmployeePersonalMaster_tbl.First_name + '' + EmployeePersonalMaster_tbl.Last_Name AS Name,  "+
                 "        ISNULL(LeaveMaster_tbl.LeaveName, 'A') AS [Leave Name], ISNULL(LeaveMaster_tbl.LeaveType, 'NA') AS [Leave Type],  "+
                 "        ISNULL(LeaveApplicationMaster.LvAppnum, 'NA') AS [Leave App], EmployeeLeaveTaken_tbl.Reason, EmployeeLeaveTaken_tbl.Istaken AS [Is taken] "+
"FROM            LeaveMaster_tbl RIGHT OUTER JOIN "+
                "         DepartmentMaster_tbl INNER JOIN "+
                "         EmployeeLeaveTaken_tbl INNER JOIN "+
                     "    EmployeeDesignation_tbl ON EmployeeLeaveTaken_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN "+
                  "       EmployeePersonalMaster_tbl ON EmployeeLeaveTaken_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
                  "       DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK ON  "+
                  "       DepartmentMaster_tbl.DepartmentPK = EmployeeDesignation_tbl.DepartmeentPk LEFT OUTER JOIN "+
                 "        LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk ON  "+
                "         LeaveMaster_tbl.LeavePk = EmployeeLeaveTaken_tbl.LeavePk "+
 "WHERE        (EmployeeLeaveTaken_tbl.Istaken = @Istaken) AND (EmployeeLeaveTaken_tbl.dateofleave BETWEEN "+
                     "    @fromdate AND @todate) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1)", con);
                cmd.Parameters.AddWithValue("@Param1", branchlocationpk);
                cmd.Parameters.AddWithValue("@Istaken", istaken);
                cmd.Parameters.AddWithValue("@fromdate", fromdate);
                cmd.Parameters.AddWithValue("@todate", todate);
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
         /// get the leaves not applicable for that designation
         /// </summary>
         /// <returns></returns>
        public DataTable GetAllNonApplicableLeavenamesOnly(int desgpk)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     LeavePk, LeaveName FROM LeaveMaster_tbl where LeavePk not in (select LeavePk  from DesignationLeave_tbl where DesgnationPK= @param1)", con);
                cmd.Parameters.AddWithValue("param1",desgpk);
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
        /// get the leaves not applicable for that designation
        /// </summary>
        /// <returns></returns>

        public DataTable getapplicableleavesname(int desgpk)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     DesignationLeave_tbl.LeavePk, LeaveMaster_tbl.LeaveName FROM     DesignationLeave_tbl INNER JOIN LeaveMaster_tbl ON DesignationLeave_tbl.LeavePk = LeaveMaster_tbl.LeavePk WHERE     (DesignationLeave_tbl.DesgnationPK = @param1)", con);
                cmd.Parameters.AddWithValue("param1", desgpk);
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
        /// get all the leavecode and name
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllLeaveCodeandName()
        {
            DataTable leavedata = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT     LeaveCode, LeavePk ,LeaveName FROM         LeaveMaster_tbl", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    leavedata.Load(reader);


                }
            }

            return leavedata;
        }







        /// <summary>
        /// gets the enchasable days against each leave
        /// </summary>
        /// <param name="leavepk"></param>
        /// <returns></returns>
        public DataTable getAllLeaveEnchasableData( int leavepk)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     EnchasableDays , LeaveType FROM  LeaveMaster_tbl WHERE (LeavePk = @Param1)", con);


                cmd.Parameters.AddWithValue("@Param1", leavepk);
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
        
        
        
        public void updateLeaveData(Datalayer.LeaveDataBean leavedatabean)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                
                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("UPDATE LeaveMaster_tbl SET LeaveName = @Param1, LeaveType = @Param2, Description = @Param3, Isenchasable = @Param4, IsMaleapp = @Param5, IsWomenapp = @Param6, EnchasableDays = @Param7, DateAdded = @Param8, userPk = @Param9 ,Allowedleave =@Param11 WHERE (LeavePk = @Param10)", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", leavedatabean.Leavename);
                command.Parameters.AddWithValue("@Param2", leavedatabean.Leavecaltype);
                command.Parameters.AddWithValue("@Param3", leavedatabean.Description);
                command.Parameters.AddWithValue("@Param5", leavedatabean.Isencashable);
                command.Parameters.AddWithValue("@Param4", leavedatabean.Ismaleapp);
                command.Parameters.AddWithValue("@Param6", leavedatabean.Isfemaleapp);
                command.Parameters.AddWithValue("@Param7", leavedatabean.Enchasabledays);
                command.Parameters.AddWithValue("@Param8", DateTime.Now.Date);
                command.Parameters.AddWithValue("@Param9", Program.USERPK);
                command.Parameters.AddWithValue("@Param10", leavedatabean.Leavepk);
                command.Parameters.AddWithValue("@Param11", leavedatabean.Allowedleave);
                command.ExecuteNonQuery();
                sqlConnection1.Close(); 
            }

        }

        /// <summary>
        /// get the leaves taken as Applied leave by an employee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="leavepk"></param>
        /// <returns></returns>
        public DataTable getallleavetaken(int empid, int leavepk)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     sum(LeaveApprovalMaster_tbl.Level3num ) FROM LeaveApprovalMaster_tbl CROSS JOIN   LeaveApplicationMaster WHERE  (LeaveApplicationMaster.Empid = @Param1) AND (LeaveApplicationMaster.LeavePK = @Param2) ", con);
                cmd.Parameters.AddWithValue("@Param1", empid);
                cmd.Parameters.AddWithValue("@Param2", leavepk);
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
        /// get the name and Pk of the leaves that are applicable for the
        /// specific employees
        /// </summary>
        /// <returns></returns>
        public DataTable getenchashableApplicableleave( int empid)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     LeaveMaster_tbl.LeavePk, LeaveMaster_tbl.LeaveName FROM EmployeeApplicableLeave_tbl INNER JOIN  LeaveMaster_tbl ON EmployeeApplicableLeave_tbl.LeavePk = LeaveMaster_tbl.LeavePk "+
                    " WHERE     (EmployeeApplicableLeave_tbl.empid = @Param1) AND (LeaveMaster_tbl.Isenchasable = 1)", con);
                cmd.Parameters.AddWithValue("@Param1", empid);
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
        /// get all the leave which a employee is entitiled
        /// </summary>
        /// <param name="emploeid"></param>
        /// <returns></returns>
        public DataTable LeaveApplicabletoEmployee(int emploeid)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     LeaveMaster_tbl.LeavePk AS  SL, LeaveMaster_tbl.LeaveName AS LEAVE " +
"FROM         LeaveMaster_tbl INNER JOIN " +
                     " EmployeeApplicableLeave_tbl ON LeaveMaster_tbl.LeavePk = EmployeeApplicableLeave_tbl.LeavePk " +
"WHERE     (EmployeeApplicableLeave_tbl.empid = @EMPID)", con);

                cmd.Parameters.AddWithValue("@EMPID", emploeid);
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
     /// give the details of a type of leave to the employee
     /// </summary>
     /// <returns></returns>
        public DataTable getemployeeApplicableleavedata(int empid , int Leavepk)
        {
            DataTable Leavedata = new DataTable ();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     EmployeeApplicableLeave_tbl.LeavePk, EmployeeApplicableLeave_tbl.empid, EmployeeApplicableLeave_tbl.Allowedleave, "+
             "         EmployeeApplicableLeave_tbl.EnchasableDays, LeaveMaster_tbl.LeaveCode, LeaveMaster_tbl.LeaveType, LeaveMaster_tbl.IsCarryForward, "+
                  "    LeaveMaster_tbl.CalculationUpto, LeaveMaster_tbl.ConsiderAlso "+
"FROM         EmployeeApplicableLeave_tbl INNER JOIN "+
           "           LeaveMaster_tbl ON EmployeeApplicableLeave_tbl.LeavePk = LeaveMaster_tbl.LeavePk "+
"WHERE     (EmployeeApplicableLeave_tbl.LeavePk = @leavepk) AND (EmployeeApplicableLeave_tbl.empid = @empid)", con);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@leavepk", Leavepk);

                SqlDataReader reader = cmd.ExecuteReader();

                Leavedata.Load(reader);


                reader.Close();
                con.Close();
            }

           







            return Leavedata;
        }

        /// <summary>
        /// get the details of the given leaves of employee 
        /// during a given time
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="leavepk"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <returns></returns>

        public DataTable  getAllSpecificLeavetakenByEmployee(int empid, int leavepk , DateTime Fromdate ,DateTime Todate)
        {
            DataTable leavetaken = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     EmployeeLeaveTaken_tbl.Leaveid as [Leave id], EmployeeLeaveTaken_tbl.dateofleave as [Leave Date], LeaveMaster_tbl.LeaveName as [Leave Name ], LeaveMaster_tbl.LeaveType as [Leave Type], "+
                      "LeaveApplicationMaster.LvAppnum as [Leave App#], EmployeeLeaveTaken_tbl.Reason as [Description], EmployeeLeaveTaken_tbl.Istaken  as [Is Taken ]" +
"FROM         EmployeeLeaveTaken_tbl INNER JOIN "+
                    "  LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk LEFT JOIN "+
                     " LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk AND "+ 
                      " EmployeeLeaveTaken_tbl.empid = LeaveApplicationMaster.Empid "+
"WHERE     (EmployeeLeaveTaken_tbl.Istaken <> N'N') AND (EmployeeLeaveTaken_tbl.LeavePk = @leavepk) AND (EmployeeLeaveTaken_tbl.empid = @empid) AND "+
                      "(EmployeeLeaveTaken_tbl.dateofleave BETWEEN @fromdate AND @todate) ", con);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@leavepk", leavepk);
                cmd.Parameters.AddWithValue("@fromdate", Fromdate);
                cmd.Parameters.AddWithValue("@todate", Todate);
                SqlDataReader reader = cmd.ExecuteReader();

                leavetaken.Load(reader);


                reader.Close();
                con.Close();
            }
            return leavetaken ;
        }







        /// <summary>
        /// Get the leaves Applied By the employee but not close registered
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="leavepk"></param>
        /// <returns></returns>


        public DataTable getAllSpecificLeaveAppliedByEmployeeBUTnotCloseregister(int empid, int leavepk)
        {
            DataTable leavetaken = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        Leaveid, empid, dateofleave, LeavePk, LeaveAppPk, Reason, Userpk, Dateadded, Istaken, AddedVia, IsRegisterClosed
FROM            EmployeeLeaveTaken_tbl
WHERE        (empid = @empid) AND (Istaken = N'N') AND (IsRegisterClosed = N'N') AND (LeavePk = @leavepk) ", con);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@leavepk", leavepk);
              
                SqlDataReader reader = cmd.ExecuteReader();

                leavetaken.Load(reader);


                reader.Close();
                con.Close();
            }
            return leavetaken;
        }







        /// <summary>
        /// get All the Applicabkle leave and the leavetaken
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>

        public DataTable getLeaveApplicableandLeavetaken(int empid)
        {


            DataTable Leavedata = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeeApplicableLeave_tbl.LeavePk, LeaveMaster_tbl.LeaveCode, EmployeeApplicableLeave_tbl.Isenchasable, EmployeeApplicableLeave_tbl.EnchasableDays, 
                         EmployeeApplicableLeave_tbl.Allowedleave, LeaveMaster_tbl.LeaveType, LeaveMaster_tbl.CalculationUpto, LeaveMaster_tbl.LeaveName, 
                         COUNT(EmployeeLeaveTaken_tbl.Leaveid) AS [Total Leave Taken]
FROM            EmployeeApplicableLeave_tbl INNER JOIN
                         LeaveMaster_tbl ON EmployeeApplicableLeave_tbl.LeavePk = LeaveMaster_tbl.LeavePk LEFT OUTER JOIN
                         EmployeeLeaveTaken_tbl ON EmployeeApplicableLeave_tbl.empid = EmployeeLeaveTaken_tbl.empid AND 
                         EmployeeApplicableLeave_tbl.LeavePk = EmployeeLeaveTaken_tbl.LeavePk
GROUP BY EmployeeApplicableLeave_tbl.LeavePk, LeaveMaster_tbl.LeaveCode, EmployeeApplicableLeave_tbl.Isenchasable, EmployeeApplicableLeave_tbl.EnchasableDays, 
                         EmployeeApplicableLeave_tbl.Allowedleave, LeaveMaster_tbl.LeaveName, EmployeeApplicableLeave_tbl.empid, LeaveMaster_tbl.CalculationUpto, 
                         LeaveMaster_tbl.LeaveType
HAVING        (EmployeeApplicableLeave_tbl.empid = @empid)", con);
                cmd.Parameters.AddWithValue("@empid", empid);

                //cmd.Parameters.AddWithValue("@fromdate", Fromdate);
                //cmd.Parameters.AddWithValue("@todate", Todate);
                SqlDataReader reader = cmd.ExecuteReader();

                Leavedata.Load(reader);


                reader.Close();
                con.Close();
            }
            return Leavedata;


        }






        /// <summary>
      ///  get the details of the given leaves of employee 
        /// during a given time by giving leavecode
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="lEAVECODE"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <returns></returns>
        public DataTable getAllSpecificLeavetakenByEmployeeBYLEAVECODE(int empid, string lEAVECODE, DateTime Fromdate, DateTime Todate)
        {
            DataTable leavetaken = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     EmployeeLeaveTaken_tbl.Leaveid as [Leave id], EmployeeLeaveTaken_tbl.dateofleave as [Leave Date], LeaveMaster_tbl.LeaveName as [Leave Name ], LeaveMaster_tbl.LeaveType as [Leave Type], " +
                      "LeaveApplicationMaster.LvAppnum as [Leave App#], EmployeeLeaveTaken_tbl.Reason as [Description], EmployeeLeaveTaken_tbl.Istaken  as [Is Taken ]" +
"FROM         EmployeeLeaveTaken_tbl INNER JOIN " +
                    "  LeaveMaster_tbl ON EmployeeLeaveTaken_tbl.LeavePk = LeaveMaster_tbl.LeavePk INNER JOIN " +
                     " LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk AND " +
                      " EmployeeLeaveTaken_tbl.empid = LeaveApplicationMaster.Empid " +
"WHERE     (EmployeeLeaveTaken_tbl.Istaken <> N'N') AND (LeaveMaster_tbl.LeaveCode = @leavepk) AND (EmployeeLeaveTaken_tbl.empid = @empid) AND " +
                      "(EmployeeLeaveTaken_tbl.dateofleave BETWEEN @fromdate AND @todate) ", con);
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@leavepk", lEAVECODE);
                cmd.Parameters.AddWithValue("@fromdate", Fromdate);
                cmd.Parameters.AddWithValue("@todate", Todate);
                SqlDataReader reader = cmd.ExecuteReader();

                leavetaken.Load(reader);


                reader.Close();
                con.Close();
            }
            return leavetaken;
        }
    















    }



    class HolidayTransaction
    {
          AnycodeAutoGenerator anycodegenarator = null;
        /// <summary>
        /// insert holidays to holiday master
        /// </summary>
        /// <param name="holydaydatabean"></param>
        public void insertHoliday(Datalayer.HolidayDayDataBean holydaydatabean)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("INSERT INTO OffdayMaster_tbl (Holidayname, Holidaytype, HolidayDate, Descriptiom, DateAdded, Userpk,LocationPK) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", holydaydatabean.Holidayname );
                command.Parameters.AddWithValue("@Param2", holydaydatabean.Holidaytype );
                command.Parameters.AddWithValue("@Param3", holydaydatabean.Holidaydate );
                command.Parameters.AddWithValue("@Param4", holydaydatabean.Holidaydescrption);

                command.Parameters.AddWithValue("@Param5", DateTime.Now.Date);
                command.Parameters.AddWithValue("@Param6", Program.USERPK);
                command.Parameters.AddWithValue("@Param7", Program.LOCTNPK);
                command.ExecuteNonQuery();
                sqlConnection1.Close();
            }
        }
        /// <summary>
        /// shows all the holidays of the location
        /// </summary>
        /// <returns></returns>
        public DataTable getallholidaydetails()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  Hilydayid, Holidayname, Holidaytype, HolidayDate, Descriptiom FROM OffdayMaster_tbl where LocationPK=@param1", con);
                cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK);
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
        /// get all the Holiday of a location against an date
        /// </summary>
        /// <param name="swipedateday"></param>
        /// <param name="BranchlctnPK"></param>
        /// <returns></returns>

        public DataTable getAnyHolidayofaDate(DateTime swipedateday ,int BranchlctnPK)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     Holidayname, Holidaytype FROM         OffdayMaster_tbl  WHERE (HolidayDate = @Param1) AND (LocationPK = @Param2)", con);
                cmd.Parameters.AddWithValue("@Param1", swipedateday);
                cmd.Parameters.AddWithValue("@Param2", BranchlctnPK);
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
        /// give all the list of dates of a particular day in a given year
        /// </summary>
        /// <param name="dateoftime"></param>
        /// <param name="daynum"></param>
        /// <returns></returns>

        public DataTable GetallDayOfYear(DateTime dateoftime ,  int daynum)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("declare @d datetime "+
" select @d = @Param2 " +
" select dateadd(dd,number,@d) from master..spt_values " +
" where type = 'p' " +
" and year(dateadd(dd,number,@d))=year(@d) " +
" and DATEPART(dw,dateadd(dd,number,@d)) = @Param1", con);

                cmd.Parameters.AddWithValue("@Param1", daynum);
                cmd.Parameters.AddWithValue("@Param2", dateoftime.ToString ("yyyy-MM-dd").ToString());

       
               
                SqlDataReader reader = cmd.ExecuteReader();
                

                dt.Load(reader);
              

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {
                con.Close();
            }
            return dt;
        }






/// <summary>
///insert all the off days
/// </summary>
/// <param name="dt"></param>
        public void insertoffdays(DataTable dt)
        {


            try
            {
                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    sqlConnection1.Open();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand command = new SqlCommand("  INSERT INTO OffdayMaster_tbl " +
                         "     (Holidayname, Holidaytype, HolidayDate, Descriptiom, DateAdded, LocationPK, Userpk) " +
        " VALUES     ('WEEKLY OFF', 'OFF',@Param1, 'OFF DAY',@Param2,@Param3,@Param4)", sqlConnection1);

                        command.Parameters.AddWithValue("@Param1", DateTime.Parse(dt.Rows[i][0].ToString()));
                        command.Parameters.AddWithValue("@Param2", Program.Datetoday);
                        command.Parameters.AddWithValue("@Param3", Program.LOCTNPK);
                        command.Parameters.AddWithValue("@Param4", Program.USERPK);


                        command.ExecuteNonQuery();

                    }
                    sqlConnection1.Close();
                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            

        }



        public void getemployeeleaveforaPeriod(int branchlctnpk)
        {


            DataTable dt = new DataTable();



        }






/// <summary>
/// insert data to gate pass
/// 
/// </summary>
/// <param name="gatepasslst"></param>
        public void insertGatepass(ArrayList gatepasslst)
        {
            anycodegenarator = new AnycodeAutoGenerator();

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {
                    int gatepassid = 0;
                    sqlConnection1.Open();

      //              SqlCommand command = new SqlCommand(" INSERT INTO GatePassMaster_tbl " +
      //          "      (BranchLctnPK, DesgnationPK, empid, GatepassDate, fromtime, totime, GatePassDescription, UserPK, DateAdded) " +
      //" VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9)  ;SELECT SCOPE_IDENTITY()", sqlConnection1);

                    SqlCommand command = new SqlCommand(@" INSERT INTO GatePassMaster_tbl 
                  (BranchLctnPK, DesgnationPK, empid, GatepassDate, fromtime, totime, GatePassDescription, UserPK, DateAdded) 
       VALUES     ( (SELECT BranchLocationPK  FROM EmployeeDesignation_tbl WHERE EmployeeDesignation_tbl.empid=@empid ),
           (SELECT DesignationPk  FROM EmployeeDesignation_tbl WHERE EmployeeDesignation_tbl.empid=@empid ),@empid,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9) 
                    ;SELECT SCOPE_IDENTITY()", sqlConnection1);
                  //  command.Parameters.AddWithValue("@Param1", gatepasslst[0]);
                 //   command.Parameters.AddWithValue("@Param2", gatepasslst[1]);
                    command.Parameters.AddWithValue("@empid", gatepasslst[0]);
                    command.Parameters.AddWithValue("@Param4", gatepasslst[1]);
                    command.Parameters.AddWithValue("@Param5", gatepasslst[2]);
                    command.Parameters.AddWithValue("@Param6", gatepasslst[3]);
                    command.Parameters.AddWithValue("@Param7", gatepasslst[4]);
                    command.Parameters.AddWithValue("@Param8", Program.USERPK);
                    command.Parameters.AddWithValue("@Param9", Program.Datetoday);


                    gatepassid = int.Parse(command.ExecuteScalar().ToString());
                    String Gatepasscode = anycodegenarator.GatepassCodeGenerator(gatepassid);






                    using (SqlCommand command1 = new SqlCommand("   UPDATE    GatePassMaster_tbl SET   GatePassnum = @Param1 WHERE  (GatePassId = @Param2) ", sqlConnection1))
                    {

                        command1.Parameters.AddWithValue("@Param1", Gatepasscode);
                        command1.Parameters.AddWithValue("@Param2", gatepassid);

                        command1.ExecuteNonQuery();

                    }






                    sqlConnection1.Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }












      











    }




  
  
    
 



}

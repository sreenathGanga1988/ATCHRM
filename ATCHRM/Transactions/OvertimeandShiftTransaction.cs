using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace ATCHRM.Transactions
{
    class OvertimeandShiftTransaction
    {

        AnycodeAutoGenerator anycodegenarator = null;

        /// <summary>
        /// insert a new Leave Application
        /// </summary>
        /// <param name="leavappdatabean"></param>
        /// <returns></returns>
        public String insertOTApplication(Datalayer.OvertimeApplicationDatabean  otappdatabean )
        {
            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int OTAppid;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO OtApplicationMaster_tbl (OTDate, Otreason, Deptpk, OTDuration, DateAdded, Userpk ,BranchLocationPk) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)  ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", otappdatabean.Otdate1 );
                        command.Parameters.AddWithValue("@Param2", otappdatabean.Reason );
                        command.Parameters.AddWithValue("@Param3", otappdatabean.Deptpk);
                        command.Parameters.AddWithValue("@Param4", otappdatabean.Duration1 );
                        command.Parameters.AddWithValue("@Param5", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param6",Program.USERPK);
                        command.Parameters.AddWithValue("@Param7", Program.LOCTNPK );
                        OTAppid = int.Parse(command.ExecuteScalar().ToString());

                    }




                    sqlConnection1.Close();
                    String OTapplicationcode = anycodegenarator.OTApplicationcodegenerator(OTAppid);
                    String updatedappnum = UpdateandApproveOTApplication(OTapplicationcode, OTAppid, otappdatabean.Empadded );
                    return updatedappnum;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }


        /// <summary>
        /// Overtime  app num to leave
        /// </summary>
        /// <param name="Leaveapplicationcode"></param>
        /// <param name="leaveapplicationpk"></param>
        /// <returns></returns>

        public String UpdateandApproveOTApplication(String OTapplicationcode, int OTAppid ,DataTable  empdata)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection2 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection2.Open();
                sqltrnsctn = sqlConnection2.BeginTransaction();


                try
                {                    
                    using (SqlCommand command1 = new SqlCommand("UPDATE    OtApplicationMaster_tbl SET OtAppnum = @param1 WHERE (OTAppPK = @Param2)", sqlConnection2))
                    {
                        command1.Transaction = sqltrnsctn;
                        command1.Parameters.AddWithValue("@Param1", OTapplicationcode);
                        command1.Parameters.AddWithValue("@Param2", OTAppid);

                        command1.ExecuteNonQuery();
                    }
                    
                    using (SqlCommand command2 = new SqlCommand("INSERT INTO OTApproval_tbl (OTAppPK) VALUES  (@Param1)", sqlConnection2))
                    {
                        command2.Transaction = sqltrnsctn;
                        command2.Parameters.AddWithValue("@Param1", OTAppid);


                        command2.ExecuteNonQuery();
                    }


                    for (int i = 0; i < empdata.Rows.Count; i++)
                    {


                        using (SqlCommand command1 = new SqlCommand("INSERT INTO OtApplicationDetails_tbl  (empid, Duration, newswipepout, OtAppPK, OTDate, durationtype,OtType,OtAmount) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6 ,@Param7,@Param8)", sqlConnection2))
                    {

                        command1.Transaction = sqltrnsctn;

                     

                            command1.Parameters.AddWithValue("@Param1", empdata.Rows[i][0]);
                            command1.Parameters.AddWithValue("@Param2", empdata.Rows[i][1]);
                            command1.Parameters.AddWithValue("@Param3",DateTime.Parse(empdata.Rows[i][2].ToString()));
                            command1.Parameters.AddWithValue("@Param4", OTAppid);
                            command1.Parameters.AddWithValue("@Param5", DateTime.Parse(empdata.Rows[i][3].ToString()));
                            command1.Parameters.AddWithValue("@Param6",  "Minute");
                            command1.Parameters.AddWithValue("@Param7", empdata.Rows[i][4]);
                            command1.Parameters.AddWithValue("@Param8", empdata.Rows[i][5]);
                            command1.ExecuteNonQuery();
                           

                        }
                       
                    }





                    sqltrnsctn.Commit();


                    return OTapplicationcode;
                }
                catch (SqlException sqlError)
                {
                    sqltrnsctn.Rollback();

                    throw sqlError;
                }
                finally
                {
                    sqlConnection2.Close();

                }


            }
        }

/// <summary>
/// get the detailed list of employee applied for the ot
/// used for viewing the status
/// </summary>
/// <param name="OTAPPpk"></param>
/// <returns></returns>
        public DataTable getOTdetails(int OTAPPpk)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     OtApplicationDetails_tbl.empid, OtApplicationDetails_tbl.OtAppPK, OtApplicationMaster_tbl.OtAppnum, OtApplicationDetails_tbl.OTDate,  "+
                  "    EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS name, "+
                 "     DesignationMaster_tbl.DesignationName, OtApplicationDetails_tbl.Duration, OtApplicationDetails_tbl.durationtype, OtApplicationDetails_tbl.OtType, "+
                  "    OtApplicationDetails_tbl.IsLevel1, OtApplicationDetails_tbl.Islevel2, OtApplicationDetails_tbl.Islevel3 " +
"FROM         OtApplicationDetails_tbl INNER JOIN "+
 "                     EmployeePersonalMaster_tbl ON OtApplicationDetails_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
  "                    EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN "+
   "                   DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN "+
    "                  OtApplicationMaster_tbl ON OtApplicationDetails_tbl.OtAppPK = OtApplicationMaster_tbl.OTAppPK INNER JOIN "+
     "                 OTApproval_tbl ON OtApplicationMaster_tbl.OTAppPK = OTApproval_tbl.OTAppPK "+
"WHERE     (OtApplicationDetails_tbl.OtAppPK = @Param1)", con);

                cmd.Parameters.AddWithValue("@Param1", OTAPPpk);
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
/// get alll the ot applications
/// to fill in combobox
/// </summary>
/// <returns></returns>
        public DataTable getallOTApplication()
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     OtAppnum, OTAppPK FROM         OtApplicationMaster_tbl WHERE     (BranchLocationPk = @Param1)", con);

             cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK );
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
        /// get the in and out time of an employee asper the latest shift assigned to them
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="DayOfWeek"></param>
        /// <returns></returns>

        public DataTable getShiftInOutTimeOfEmployee(int empid ,String DayOfWeek)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT   cast(ShiftDayDetails_tbl.ToTime as time) [time]     , ShiftDayDetails_tbl.DayOFWeekname FROM            EmployeShift_tbl INNER JOIN " +
" ShiftDayDetails_tbl ON EmployeShift_tbl.Shiftpk = ShiftDayDetails_tbl.ShiftPK WHERE        (ShiftDayDetails_tbl.DayOFWeekname = @Param1)  AND (EmployeShift_tbl.Empid = @Param2)", con);

                cmd.Parameters.AddWithValue("@Param1", DayOfWeek);
                cmd.Parameters.AddWithValue("@Param2", empid);
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
        /// get the intime and out time of a shift of a day
        /// </summary>
        /// <param name="Shiftpk"></param>
        /// <param name="Date"></param>
        /// <returns></returns>

        public DataTable getShiftInandOutTimeOfADay(int shiftpk, DateTime actionDate)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT        CAST(ShiftDayDetails_tbl.FromTime  AS time) AS fromtime, CAST(ShiftDayDetails_tbl.ToTime AS time) AS Totimetime ,(ShiftDayDetails_tbl.TotalDuration +ShiftDayDetails_tbl.BreakDuration ) as Duration,  " +
                    "     ShiftMasterNew_tbl.ShiftName  FROM            ShiftDayDetails_tbl INNER JOIN "+
                  "       ShiftMasterNew_tbl ON ShiftDayDetails_tbl.ShiftPK = ShiftMasterNew_tbl.ShiftPK "+
" WHERE        (ShiftDayDetails_tbl.DayOFWeekname = (Select datename(dw,@dateofDay)) )AND (ShiftDayDetails_tbl.ShiftPK = @shiftpk) ", con);

                cmd.Parameters.AddWithValue("@dateofDay", actionDate);
                cmd.Parameters.AddWithValue("@shiftpk", shiftpk);
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








        /// <summary>
        /// get the ot rate of the employee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public float getOTrateofanemployee( int  empid)        
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     EmployeesalCompApplicable_tbl.Amount "+
"FROM         SalComponentMaster_tbl INNER JOIN "+
                "      EmployeesalCompApplicable_tbl ON SalComponentMaster_tbl.SalcompPk = EmployeesalCompApplicable_tbl.SalcompPk "+
" WHERE     (SalComponentMaster_tbl.ComponentName = 'BASIC') AND (EmployeesalCompApplicable_tbl.empid = @Param1)", con);

                cmd.Parameters.AddWithValue("@Param1", empid);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                int basicsalary = 0;
                float rate=0;
                dt.Load(reader);
                if (dt.Rows.Count != 0)
                {
                    try
                    {
                        basicsalary = int.Parse(dt.Rows[0][0].ToString());
                    }
                    catch (Exception)
                    {
                        
                        
                    }
                    if (basicsalary > 0)
                    {

                        rate = basicsalary / 195;
                    }

                }

                return rate;
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
        /// delet an ot applicvation if it not approved by  any levels
        /// </summary>
        /// <param name="otapppk"></param>
        public void OtDletetion(int otapppk)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {
                    using (SqlCommand command1 = new SqlCommand(" DELETE FROM OtApplicationMaster_tbl WHERE     (OTAppPK = @Param1)", sqlConnection1))
                    {
                        command1.Transaction = sqltrnsctn;
                        command1.Parameters.AddWithValue("@Param1", otapppk);


                        command1.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(" DELETE FROM OtApplicationDetails_tbl WHERE     (OtAppPK = @Param1) ", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", otapppk);
                     


                        command.ExecuteNonQuery();
                    }
                   


                    sqltrnsctn.Commit();



                }
                catch (Exception exp)
                {

                    sqltrnsctn.Rollback();

                    throw exp;
                }

                sqlConnection1.Close();
            }

        }

        #region LHRAction



        /// <summary>
        /// insert the LHR Application
        /// 
        /// </summary>
        /// <param name="lhrapplist"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public String insertLHRApplication(ArrayList lhrapplist  , DataTable dt)
        {
            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int LHRAPPid;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO LHRApplicationMaster_tbl (BranchLctnPK, DateOfLHR, Reason ,UserPK) VALUES  (@Param1,@Param2,@Param3,@Param4 )  ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", lhrapplist[0]);
                        command.Parameters.AddWithValue("@Param2", DateTime .Parse ( lhrapplist[1].ToString()));
                        command.Parameters.AddWithValue("@Param3", lhrapplist[2].ToString ());
                      
                        command.Parameters.AddWithValue("@Param4", Program.USERPK);
                      
                        LHRAPPid = int.Parse(command.ExecuteScalar().ToString());

                    }




                    sqlConnection1.Close();
                    String LHRapplicationcode = anycodegenarator.LHRApplicationCodeGenerator(LHRAPPid);
                    sqlConnection1.Open();

                    using (SqlCommand command12 = new SqlCommand("UPDATE    LHRApplicationMaster_tbl SET   Appnum = @Param1 WHERE     (LHRApPK = @Param2) ", sqlConnection1))
                    {

                        command12.Parameters.AddWithValue("@Param1", LHRapplicationcode);
                        command12.Parameters.AddWithValue("@Param2", LHRAPPid);
                        command12.ExecuteNonQuery(); 

                     

                    }





                    for (int i = 0; i < dt.Rows.Count;i++ )
                    {
                        using (SqlCommand command1 = new SqlCommand("INSERT INTO LHRDetails_tbl (LHRAppK ,empid, LhrValue, DatetofLHR) VALUES (@Param4 ,@Param1,@Param2,@Param3) ", sqlConnection1))
                        {

                            command1.Parameters.AddWithValue("@Param1",int.Parse (dt.Rows[i][0].ToString ()));
                            command1.Parameters.AddWithValue("@Param2", int.Parse(dt.Rows[i][1].ToString()));
                            command1.Parameters.AddWithValue("@Param3", DateTime.Parse(dt.Rows[i][2].ToString()));
                            command1.Parameters.AddWithValue("@Param4", int.Parse(LHRAPPid.ToString()));
                            command1.ExecuteNonQuery(); 

                          

                        }


                    }


                    sqlConnection1.Close();


                    return LHRapplicationcode;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }

        



        public void rejectLHRapplication(int empid, int LhrValue)
        {
            int LHRAPPid;
            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                  
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO DeleteEmployeeLhr_tbl (empid, Lhvalue ,UserpK)VALUES     (@Param1,@Param2,@Param3)  ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);
                        command.Parameters.AddWithValue("@Param2", LhrValue);

                        command.Parameters.AddWithValue("@Param3", Program.USERPK);

                        LHRAPPid = int.Parse(command.ExecuteScalar().ToString());


                    }



                    String LHRapplicationcode = anycodegenarator.RejectLHApplication(LHRAPPid);


                    using (SqlCommand command1 = new SqlCommand(" UPDATE    DeleteEmployeeLhr_tbl SET  Appnum = @Param1 WHERE     (LhrRejId = @Param2) ", sqlConnection1))
                    {

                        command1.Parameters.AddWithValue("@Param1", LHRapplicationcode);
                        command1.Parameters.AddWithValue("@Param2", LHRAPPid);

                        command1.ExecuteNonQuery();




                    }





                    sqlConnection1.Close();

                }
              


               

            }
            catch (Exception )
            {
                throw;
            }


        }



        #endregion


    }
}

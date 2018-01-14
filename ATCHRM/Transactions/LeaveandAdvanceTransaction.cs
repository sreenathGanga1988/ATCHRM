using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ATCHRM.Transactions
{
    class LeaveandAdvanceAppTransaction
    {
        Transactions.LeaveTransaction lvtransaction = null;
        AnycodeAutoGenerator anycodegenarator = null;
        Transactions.LeaveTrabnsactionCalculator LVTRANSCAL = null;
        Transactions.AnualContractrenewal annul = null;

        public Boolean isLeaveApplicationAlreadyPresent(int empid,DateTime fromdate,DateTime todate)
        {
            Boolean  ispresent = false;


            DataTable dt= getallleaveappinsideaperiod(empid,fromdate,todate );
            if(dt!=null)
            {
                if(dt.Rows.Count!=0)
                {
                    if(dt.Rows[0][0].ToString ().Trim ()!="")
                    {
                        ispresent=true;
                    }
                }
            }


            return ispresent;

        }



          public Boolean IsLeaveApplicationpending(int empid)
        {    Boolean ispendingApplication= false;
              using(SqlServerLinqDataContext cntxt=new SqlServerLinqDataContext (Program.ConnStr))
              {

                  var q = from leavapp in cntxt.LeaveApplicationMasters
                          join leavappdet in cntxt.LeaveApprovalMaster_tbls
                          on leavapp.LeaveAppPk equals leavappdet.LeaveAppPk
                          where leavapp.Empid == empid
                          select new { leavappdet.LeaveAppPk, leavappdet.Islevel1, leavappdet.Islevel2, leavappdet.Islevel3,leavappdet.IsCompleted };

                         foreach(var element in q)
                         {
                          
                             if(element.IsCompleted.Trim ()!="R" && element.IsCompleted.Trim ()!="Y")
                             {
                                 ispendingApplication = true;
                             }
                         }
              }

              return ispendingApplication;
        }


        public DataTable getAllLeaveTakenDetails( DateTime todate)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
//                SqlCommand cmd = new SqlCommand(@" SELECT        EmployeeLeaveTaken_tbl.*,(SELECT        TOP (1) LeaveApplicationMaster.LvAppnum
//FROM            LeaveApplicationMaster INNER JOIN
//                         LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk INNER JOIN
//                         LeaveMaster_tbl ON LeaveApplicationMaster.LeavePK = LeaveMaster_tbl.LeavePk
//WHERE        (LeaveApplicationMaster.Todate >= @date) AND (LeaveApplicationMaster.Fromdate <= @date) AND (LeaveApplicationMaster.Empid = EmployeeLeaveTaken_tbl.Empid) AND 
//                         (LeaveApprovalMaster_tbl.Islevel3 = N'A' )) as Appnum
//FROM            EmployeeLeaveTaken_tbl where dateofleave =@date", con);


                SqlCommand cmd = new SqlCommand(@" SELECT   EmployeeLeaveTaken_tbl.*  ,(SELECT        TOP (1) LeaveApplicationMaster.LvAppnum
FROM            LeaveApplicationMaster INNER JOIN
                         LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk INNER JOIN
                         LeaveMaster_tbl ON LeaveApplicationMaster.LeavePK = LeaveMaster_tbl.LeavePk
WHERE        (LeaveApplicationMaster.Todate >= @date) AND (LeaveApplicationMaster.Fromdate <= @date) AND (LeaveApplicationMaster.Empid = EmployeeLeaveTaken_tbl.Empid) AND 
                         (LeaveApprovalMaster_tbl.Islevel3 = N'A' )) as Appnum  
FROM            EmployeeLeaveTaken_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeeLeaveTaken_tbl.empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeeLeaveTaken_tbl.dateofleave = @date) AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1)", con);


                cmd.Parameters.AddWithValue("@date", todate);
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
        /// get all leaveApplication of a location
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllLeaveApplication()
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@" SELECT     LeaveApplicationMaster.LvAppnum,   LeaveApplicationMaster.Empid, LeaveMaster_tbl.LeaveName, LeaveMaster_tbl.LeaveType, LeaveMaster_tbl.LeaveCode, LeaveApplicationMaster.Fromdate, 
                         LeaveApplicationMaster.Todate, LeaveApplicationMaster.Duration, LeaveApplicationMaster.Durationtype, LeaveApplicationMaster.Telephonenum, 
                         LeaveApplicationMaster.Mobilenum, LeaveApprovalMaster_tbl.Islevel1, LeaveApprovalMaster_tbl.Islevel2, LeaveApprovalMaster_tbl.Islevel3, 
                         LeaveApprovalMaster_tbl.Level1num, LeaveApprovalMaster_tbl.Level2num, LeaveApprovalMaster_tbl.Level3num, LeaveApprovalMaster_tbl.Level1ApprovalDate, 
                         LeaveApprovalMaster_tbl.Level2ApprovalDate, LeaveApprovalMaster_tbl.Level3ApprovalDate
FROM            LeaveApplicationMaster INNER JOIN
                         LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk INNER JOIN
                         LeaveMaster_tbl ON LeaveApplicationMaster.LeavePK = LeaveMaster_tbl.LeavePk INNER JOIN
                         EmployeeDesignation_tbl ON LeaveApplicationMaster.Empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param1)", con);


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



            public DataTable GetAllEmployeesnotinSwipedataBank(DateTime datetoday)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeSwipeDaily_tbl.swipePK, EmployeSwipeDaily_tbl.empid, EmployeSwipeDaily_tbl.Swipin, EmployeSwipeDaily_tbl.SwipeOut, EmployeSwipeDaily_tbl.Date, 
                         EmployeSwipeDaily_tbl.Duration, EmployeSwipeDaily_tbl.InStatus, EmployeSwipeDaily_tbl.Outstatus, EmployeSwipeDaily_tbl.Invalue, 
                         EmployeSwipeDaily_tbl.OutValue, EmployeSwipeDaily_tbl.IsCompleted
FROM            EmployeSwipeDaily_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeSwipeDaily_tbl.empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeSwipeDaily_tbl.IsCompleted = 'A') AND (EmployeSwipeDaily_tbl.Date = @datetoday) AND (EmployeeDesignation_tbl.BranchLocationPK = @branchlctnpk) 
                         AND (EmployeSwipeDaily_tbl.empid NOT IN
                             (SELECT        EmpSwipedataBank_tbl.empid
                               FROM            EmpSwipedataBank_tbl INNER JOIN
                                                         EmployeeDesignation_tbl ON EmpSwipedataBank_tbl.empid = EmployeeDesignation_tbl.empid
                               WHERE        (EmpSwipedataBank_tbl.SwipeDate = @datetoday) AND (EmployeeDesignation_tbl.BranchLocationPK = @branchlctnpk)))
", con);


                cmd.Parameters.AddWithValue("@branchlctnpk", Program.LOCTNPK);
                cmd.Parameters.AddWithValue("@datetoday", datetoday.ToString("MM-dd-yyyy"));
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

        public DataTable getallleaveappinsideaperiod(int empid, DateTime fromdate, DateTime todate)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"  SELECT        LeaveApplicationMaster.LeaveAppPk, LeaveApprovalMaster_tbl.Islevel1, LeaveApprovalMaster_tbl.Islevel2, LeaveApprovalMaster_tbl.Islevel3
FROM            LeaveApplicationMaster INNER JOIN
                         LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk
WHERE        ((@newtodate BETWEEN LeaveApplicationMaster.Fromdate AND LeaveApplicationMaster.Todate)  OR
                         (@newfromdate BETWEEN LeaveApplicationMaster.Fromdate AND LeaveApplicationMaster.Todate) ) AND (LeaveApplicationMaster.Empid = @Param1);
", con);

                cmd.Parameters.AddWithValue("@Param1", empid);
                cmd.Parameters.AddWithValue("@newfromdate", fromdate);
                cmd.Parameters.AddWithValue("@newtodate", todate);
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
        /// insert a new Leave Application
        /// </summary>
        /// <param name="leavappdatabean"></param>
        /// <returns></returns>
        public String insertLeaveApplication(Datalayer.LeaveAppDatabean leavappdatabean)
        {
            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int leavAppid;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO LeaveApplicationMaster (Empid, LeavePK, Fromdate, Todate, Duration, Durationtype, Telephonenum, Mobilenum, Balance, Userpk, DateAdded)  " +
 "  VALUES  (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,getdate())  ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", leavappdatabean.Empid);
                        command.Parameters.AddWithValue("@Param2", leavappdatabean.Leavepk1);
                        command.Parameters.AddWithValue("@Param3", leavappdatabean.Fromdate);
                        command.Parameters.AddWithValue("@Param4", leavappdatabean.Todate);
                        command.Parameters.AddWithValue("@Param5", leavappdatabean.Duration);
                        command.Parameters.AddWithValue("@Param6", leavappdatabean.Durationtype1);
                        command.Parameters.AddWithValue("@Param7", leavappdatabean.Telephonenum1);
                        command.Parameters.AddWithValue("@Param8", leavappdatabean.Mobilenum);
                        command.Parameters.AddWithValue("@Param9", leavappdatabean.Balance);
                        command.Parameters.AddWithValue("@Param10", Program.USERPK);
                     //   command.Parameters.AddWithValue("@Param11", DateTime.Now.Date);




                        leavAppid = int.Parse(command.ExecuteScalar().ToString());

                    }

                    sqlConnection1.Close();
                    String leaveapplicationcode = anycodegenarator.LeaveApplicationcodegeneLAtor(leavAppid);
                    String updatedappnum = UpdateandApproveLeaveApplication(leaveapplicationcode, leavAppid);
                    return updatedappnum;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }

        /// <summary>
        /// updateleave app num to leave
        /// </summary>
        /// <param name="Leaveapplicationcode"></param>
        /// <param name="leaveapplicationpk"></param>
        /// <returns></returns>

        public String UpdateandApproveLeaveApplication(String Leaveapplicationcode, int leaveapplicationpk)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection2 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection2.Open();
                sqltrnsctn = sqlConnection2.BeginTransaction();


                try
                {


                    using (SqlCommand command1 = new SqlCommand("UPDATE    LeaveApplicationMaster SET LvAppnum = @Param1 WHERE  (LeaveAppPk = @Param2)", sqlConnection2))
                    {
                        command1.Transaction = sqltrnsctn;
                        command1.Parameters.AddWithValue("@Param1", Leaveapplicationcode);
                        command1.Parameters.AddWithValue("@Param2", leaveapplicationpk);

                        command1.ExecuteNonQuery();
                    }





                    using (SqlCommand command2 = new SqlCommand("INSERT INTO LeaveApprovalMaster_tbl (LeaveAppPk) VALUES (@Param1) ", sqlConnection2))
                    {
                        command2.Transaction = sqltrnsctn;
                        command2.Parameters.AddWithValue("@Param1", leaveapplicationpk);


                        command2.ExecuteNonQuery();
                    }








                    sqltrnsctn.Commit();


                    return Leaveapplicationcode;
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
        /// this will get all the Leave application
        /// number aagainst each employee who are not enchased and is already approved in level three
        /// </summary>
        /// <param name="empid"></param>
        public DataTable getLeaveAppnumFOrEnchasing(int empid)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  LeaveApplicationMaster.LvAppnum, LeaveApplicationMaster.LeaveAppPk FROM  LeaveApplicationMaster INNER JOIN  LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk WHERE  (LeaveApprovalMaster_tbl.Islevel3 = N'A') AND (LeaveApplicationMaster.Empid = @Param1) AND (LeaveApplicationMaster.Isencashed IS NULL) ", con);

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



        public String insertAdvanceApplication(Datalayer.AdvanceAppDatabean ladvanceappdatabean)
        {
            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int advanceappid;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO AdvanceApplicationMaster_tbl (empid, Amount, CurrencyPK, duration, durationType, instalmentof, Reason, DateAdded, UserPk, Iscompleted,ToBePayedBy) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9, N'N',@Param10)  ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", ladvanceappdatabean.Empid);
                        command.Parameters.AddWithValue("@Param2", ladvanceappdatabean.Amount1);
                        command.Parameters.AddWithValue("@Param3", ladvanceappdatabean.Currencypk);
                        command.Parameters.AddWithValue("@Param4", ladvanceappdatabean.Duration);
                        command.Parameters.AddWithValue("@Param5", ladvanceappdatabean.Durationtype);
                        command.Parameters.AddWithValue("@Param6", ladvanceappdatabean.Instalmentof1);
                        command.Parameters.AddWithValue("@Param7", ladvanceappdatabean.Reason);
                        command.Parameters.AddWithValue("@Param8", ladvanceappdatabean.Dateadded);

                        command.Parameters.AddWithValue("@Param9", Program.USERPK);

                        command.Parameters.AddWithValue("@Param10", ladvanceappdatabean.Tobepayedby1 );



                        advanceappid = int.Parse(command.ExecuteScalar().ToString());

                    }


                    if (ladvanceappdatabean.Paybackdate.Rows.Count > 0)
                    {
                        for(int i=0;i<ladvanceappdatabean.Paybackdate.Rows.Count;i++)
                        {

                            using (SqlCommand command = new SqlCommand("INSERT INTO AdvancePayBackDetail_tbl (empid, Amount, DateofPay, Ispayed ,AdvanceAppPk) " +
" VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5) ", sqlConnection1))
                        {

                            command.Parameters.AddWithValue("@Param1", ladvanceappdatabean.Paybackdate.Rows[i][0]);
                            command.Parameters.AddWithValue("@Param2", ladvanceappdatabean.Paybackdate.Rows[i][1]);
                            command.Parameters.AddWithValue("@Param3", ladvanceappdatabean.Paybackdate.Rows[i][2]);
                            command.Parameters.AddWithValue("@Param4", "N");
                            command.Parameters.AddWithValue("@Param5", advanceappid);
                            command.ExecuteNonQuery();
                        }

                    }
                    }








                    sqlConnection1.Close();






                    String advanceapplicationcode = anycodegenarator.AdvanceApplicationcodegeneLAtor(advanceappid);
                    String updatedappnum = UpdateandApproveAdvanceApplication(advanceapplicationcode, advanceappid);


                    return updatedappnum;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }


        /// <summary>
        /// Approval for Advance  Application
        /// </summary>
        /// <param name="advanceapplicationcode"></param>
        /// <param name="advanceapppk"></param>
        /// <returns></returns>

        public String UpdateandApproveAdvanceApplication(String advanceapplicationcode, int advanceapppk)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection2 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection2.Open();
                sqltrnsctn = sqlConnection2.BeginTransaction();


                try
                {


                    using (SqlCommand command1 = new SqlCommand(" UPDATE    AdvanceApplicationMaster_tbl SET   AddvanceAppnum = @Param2 WHERE     (AdvanceAppPk = @Param1) ", sqlConnection2))
                    {
                        command1.Transaction = sqltrnsctn;
                        command1.Parameters.AddWithValue("@Param1", advanceapppk);
                        command1.Parameters.AddWithValue("@Param2", advanceapplicationcode);

                        command1.ExecuteNonQuery();
                    }





                    using (SqlCommand command2 = new SqlCommand(" INSERT INTO AdvanceApprovalMaster_tbl (AdvanceAppPk, Iscompleted) VALUES     (@Param1, N'N')", sqlConnection2))
                    {
                        command2.Transaction = sqltrnsctn;
                        command2.Parameters.AddWithValue("@Param1", advanceapppk);


                        command2.ExecuteNonQuery();
                    }








                    sqltrnsctn.Commit();


                    return advanceapplicationcode;
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


        public DataTable getprevoiueAdvanceDetails(int empid)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     AdvanceApplicationMaster_tbl.AddvanceAppnum AS Appnum, " +
                     " AdvanceApplicationMaster_tbl.DateAdded AS AppliedDate, AdvanceApplicationMaster_tbl.Amount AS AppliedAmount, CurrencyMaster_tbl.Name AS CurrencyName," +
                     " AdvanceApplicationMaster_tbl.Reason AS AppliedReason, AdvanceApprovalMaster_tbl.Level3Amount AS ApprovedAmount, " +
                     " AdvanceApprovalMaster_tbl.Level3ApprovalDate AS ApprovedDate, AdvanceApplicationMaster_tbl.Iscompleted " +
                    " FROM   AdvanceApplicationMaster_tbl INNER JOIN AdvanceApprovalMaster_tbl ON AdvanceApplicationMaster_tbl.AdvanceAppPk = AdvanceApprovalMaster_tbl.AdvanceAppPk INNER JOIN " +
                  "  CurrencyMaster_tbl ON AdvanceApplicationMaster_tbl.CurrencyPK = CurrencyMaster_tbl.Currency_Pk " +
                  " WHERE  (AdvanceApplicationMaster_tbl.empid = @Param1)   ", con);

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


        //give the number of leave left for that type
        //to  that employee

        public int  leaveleftofatype(int empid, int leavepk)
        {
            LVTRANSCAL = new LeaveTrabnsactionCalculator();
            lvtransaction = new LeaveTransaction();
            annul = new Transactions.AnualContractrenewal();
            DataTable dt = new DataTable();
            DataTable employelvedetl = new DataTable();
            DataTable halfdayleave = new DataTable();
            DataTable fulldayofhalfleave = new DataTable();
            String fromdate = "";
            String Todate = "";
            String alloweddays = "0";
            String Leavetaken = "0";
            int daysleft = 0;
            String leavecodenow = "";
            int halfdays = 0;
            double availableleave = 0;
            double fullday = 0;
            DataTable contractdata = annul.getCurrentSubContract(empid);
            if (contractdata.Rows.Count != 0)
            {
                String Currentyear = contractdata.Rows[0][1].ToString();

                fromdate = DateTime.Parse(contractdata.Rows[0][2].ToString()).ToString("dd-MM-yyyy");
                Todate = DateTime.Parse(contractdata.Rows[0][3].ToString()).ToString("dd-MM-yyyy");

                dt = lvtransaction.getemployeeApplicableleavedata(empid, leavepk);
                employelvedetl = lvtransaction.getAllSpecificLeavetakenByEmployee(empid, leavepk, DateTime.Parse(fromdate), DateTime.Parse(Todate));
                availableleave = LVTRANSCAL.employeeleavecalculatorstarter(empid, leavepk);
               
                if (dt.Rows.Count != 0)
                {
                    alloweddays = dt.Rows[0][2].ToString();
                     if( Convert.ToInt32(availableleave) >int.Parse (alloweddays))
                     {
                         alloweddays = availableleave.ToString ();
                     }
                    leavecodenow = dt.Rows[0][4].ToString().Trim ();

                }


                if (employelvedetl.Rows.Count != 0)
                {
                    Leavetaken = employelvedetl.Rows.Count.ToString();
                }

                if (leavecodenow == "SL")
                {
                    //lvtransaction.getAllSpecificLeavetakenByEmployeeBYLEAVECODE(empid, "SHD", DateTime.Parse(fromdate), DateTime.Parse(Todate));
                }
                else if (leavecodenow == "PL")
                {
                halfdayleave=lvtransaction.getAllSpecificLeavetakenByEmployeeBYLEAVECODE(empid,"HPL", DateTime.Parse(fromdate), DateTime.Parse(Todate));
                halfdays = halfdayleave.Rows.Count;
                halfdays = halfdays / 2;
                }
                else if (leavecodenow == "HPL")
                {
                    //if half PL reduce the paid leave full
                    fulldayofhalfleave = lvtransaction.getAllSpecificLeavetakenByEmployeeBYLEAVECODE(empid, "PL", DateTime.Parse(fromdate), DateTime.Parse(Todate));
                    halfdays = (halfdayleave.Rows.Count)*2;
                   
                }


                daysleft = int.Parse(alloweddays) - int.Parse(Leavetaken) - halfdays;
            }


            return daysleft;
        }

        /// <summary>
        /// get LeaveApplication  details based on Leavecode and Empid
        /// </summary>
        /// <param name="code"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable  getleavePkfromcode(String code , int empid)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     LeaveMaster_tbl.LeavePk, LeaveMaster_tbl.LeaveName, LeaveMaster_tbl.LeaveCode, EmployeeApplicableLeave_tbl.empid "+
" FROM         LeaveMaster_tbl INNER JOIN "+
 "      EmployeeApplicableLeave_tbl ON LeaveMaster_tbl.LeavePk = EmployeeApplicableLeave_tbl.LeavePk "+
"WHERE     (LeaveMaster_tbl.LeaveCode = @Param1) AND (EmployeeApplicableLeave_tbl.empid = @Param2)", con);
                cmd.Parameters.AddWithValue("@Param1", code);
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

        public DataTable getleaveDetailsOfAplication(String LeaveAppnum, int empid)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        LeaveApplicationMaster.LeaveAppPk, LeaveMaster_tbl.LeavePk, LeaveMaster_tbl.LeaveCode
FROM            LeaveApplicationMaster INNER JOIN
                         LeaveMaster_tbl ON LeaveApplicationMaster.LeavePK = LeaveMaster_tbl.LeavePk
WHERE        (LeaveApplicationMaster.LvAppnum = @Param1) AND (LeaveApplicationMaster.Empid = @Param2)", con);
                cmd.Parameters.AddWithValue("@Param1", LeaveAppnum);
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





    }




    class leaveEnchasementTransaction
    {
        AnycodeAutoGenerator anycodegenarator = null;

        /// <summary>
        ///returns the LH left fo rthat person
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int getAllPreviousEnchasementofYear(int empid, int leavePK, int Contractid, String currentyear)
        {

            int lhleft = 0;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT     SUM(EncashDuration) AS Expr1 " +
" FROM         LeaveEnchasementMaster_tbl" +
" WHERE     (ContractId = @Param1) AND (CurentYear = @Param2) AND (LeavePk = @Param3) AND (empid = @Param4)", con);
                command.Parameters.AddWithValue("@Param1", Contractid);
                command.Parameters.AddWithValue("@Param2", currentyear);
                command.Parameters.AddWithValue("@Param3", leavePK);
                command.Parameters.AddWithValue("@Param4", empid);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        try
                        {
                            lhleft = int.Parse(reader[0].ToString());
                        }
                        catch (Exception)
                        {
                            lhleft = 0;



                        }

                    }
                }


                reader.Close();

            }

            return lhleft;

        }




        public String Insertleaveenchasementapplication(Datalayer.LeaveEnchasementAppDatabean lvdatabean)
        {
            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO LeaveEnchasementMaster_tbl" +
                "      (empid, LeavePk, ContractId, CurentYear, EncashDuration, DurationType, AddedDate) " +
"VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,getdate())  ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", lvdatabean.Empid);
                        command.Parameters.AddWithValue("@Param2", lvdatabean.Leavepk);
                        command.Parameters.AddWithValue("@Param3", lvdatabean.Contractid);
                        command.Parameters.AddWithValue("@Param4", lvdatabean.Currentyear);
                        command.Parameters.AddWithValue("@Param5", lvdatabean.Enchaseduration);
                        command.Parameters.AddWithValue("@Param6", lvdatabean.Durationtype);

                        lvdatabean.Levenchasid = int.Parse(command.ExecuteScalar().ToString());

                    }






                    lvdatabean.Appnum1 = anycodegenarator.LeaveencashApplicationCode(lvdatabean.Levenchasid);

                    using (SqlCommand command = new SqlCommand(" UPDATE    LeaveEnchasementMaster_tbl SET Appnum = @Param1 WHERE     (LeaveEncashPk = @Param2)", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", lvdatabean.Appnum1);
                        command.Parameters.AddWithValue("@Param2", lvdatabean.Levenchasid);
                        command.ExecuteNonQuery();

                    }

                    sqlConnection1.Close();
                    return lvdatabean.Appnum1;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }


        public int getAllPreviousEnchasementofEmployee(int empid, int leavePK, DateTime fromdate, DateTime todate)
        {

            int lhleft = 0;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT     SUM(EncashDuration) AS Expr1 " +
" FROM         LeaveEnchasementMaster_tbl" +
" WHERE     (LeaveEnchasementMaster_tbl.AddedDate BETWEEN @fromdate AND @todate) AND (LeavePk = @Param3) AND (empid = @Param4)", con);
                command.Parameters.AddWithValue("@fromdate", fromdate);
                command.Parameters.AddWithValue("@todate", todate);
                command.Parameters.AddWithValue("@Param3", leavePK);
                command.Parameters.AddWithValue("@Param4", empid);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        try
                        {
                            lhleft = int.Parse(reader[0].ToString());
                        }
                        catch (Exception)
                        {
                            lhleft = 0;



                        }

                    }
                }


                reader.Close();

            }

            return lhleft;

        }



    }
}

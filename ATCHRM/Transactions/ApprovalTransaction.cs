using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace ATCHRM.Transactions
{
    class ApprovalTransaction
    {
        Transactions.AnycodeAutoGenerator anycodegenarator = null;









        #region Recruitment Approvals



        /// <summary>
        /// if Level One had not done any Approval against some recruitmentpk  
        /// this will wrk 
        /// </summary>
        /// <param name="approveddatabean"></param>
        /// <param name="vaccancynum"></param>
        public void insertApprovalData(Datalayer.RecruitmentApprovalDataBean approveddatabean ,int vaccancynum)
        {
            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {

                    using (SqlCommand command = new SqlCommand("INSERT INTO RecruitmentApprovalMaster_tbl (RecruitmentPK, Level1number, Islevel1, Level1Approvedate, Userpk1) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", approveddatabean.RecruitmentAppPk1);
                        command.Parameters.AddWithValue("@Param2", approveddatabean.Level1num);
                        command.Parameters.AddWithValue("@Param3", approveddatabean.Islevel1);


                        command.Parameters.AddWithValue("@Param4", approveddatabean.Level1date);
                        command.Parameters.AddWithValue("@Param5", Program.USERPK);

                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command1 = new SqlCommand("UPDATE RecruitmentApplicationMaster_tbl SET balncenum = @Param1 ,iscompleted = 'H'WHERE (RecruitmentAppPk = @Param2)", sqlConnection1))
                    {
                        command1.Transaction = sqltrnsctn;
                        int p = vaccancynum - int.Parse(approveddatabean.Level1num.ToString());
                        command1.Parameters.AddWithValue("@Param2", approveddatabean.RecruitmentAppPk1);
                        command1.Parameters.AddWithValue("@Param1", p);

                      


                        command1.ExecuteNonQuery();
                    }


                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (RecruitmentPK, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;
                        int p = vaccancynum - int.Parse(approveddatabean.Level1num.ToString());
                        command2.Parameters.AddWithValue("@Param1", approveddatabean.RecruitmentAppPk1);
                        command2.Parameters.AddWithValue("@Param2", "L1");
                        command2.Parameters.AddWithValue("@Param3", approveddatabean.Level1date);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", approveddatabean.Level1num);
                        command2.Parameters.AddWithValue("@Param6", "Recruit");


                        command2.ExecuteNonQuery();
                    }




                    sqltrnsctn.Commit();
               
                
                
                }
                catch (Exception exp )
                {

                    sqltrnsctn.Rollback();

                    throw exp;
                }




             



                sqlConnection1.Close();
            }

        }


        /// <summary>
        /// to check whether the Recruitapplication has been previously approved
        /// </summary>
        /// <param name="recapppk"></param>
        /// <returns></returns>
        public DataTable getexistingApproval(int recapppk)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     ApprovalPK FROM   RecruitmentApprovalMaster_tbl WHERE  (RecruitmentPK = @Param1)", con);
                cmd.Parameters.AddWithValue("@Param1", recapppk);
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
     /// 
     /// </summary>
     /// <param name="approveddatabean"></param>
     /// <param name="balanceforapproval"></param>
     /// <param name="recruitmentApprovalpk"></param>
     /// <param name="numberapprovednow"></param>
 //  rcrtapptransaction.updatedata(rcrtapprvaldatabean, balanceforapproval , recruitmentApprovalpk ,numberapprovednow );

        public void updatedata(Datalayer.RecruitmentApprovalDataBean approveddatabean, int balanceforapproval ,int recruitmentApprovalpk ,int numberapprovednow)
        {


            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {

                    using (SqlCommand command = new SqlCommand("UPDATE    RecruitmentApprovalMaster_tbl SET Islevel1 = @Param1, Level1Approvedate = @Param2, Level1number = @Param3, Userpk1 = @Param4 WHERE (ApprovalPK = @Param5)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", approveddatabean.Islevel1);
                        command.Parameters.AddWithValue("@Param2", approveddatabean.Level1date);
                        command.Parameters.AddWithValue("@Param3", approveddatabean.Level1num);


                        command.Parameters.AddWithValue("@Param4",  Program.USERPK);
                        command.Parameters.AddWithValue("@Param5", recruitmentApprovalpk);

                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command1 = new SqlCommand("UPDATE RecruitmentApplicationMaster_tbl SET balncenum = @Param1 WHERE (RecruitmentAppPk = @Param2)", sqlConnection1))
                    {
                        command1.Transaction = sqltrnsctn;
                        int newbalanceinappliction = balanceforapproval - numberapprovednow;
                        command1.Parameters.AddWithValue("@Param2", approveddatabean.RecruitmentAppPk1);
                        command1.Parameters.AddWithValue("@Param1", newbalanceinappliction);




                        command1.ExecuteNonQuery();
                    }


                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (RecruitmentPK, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;
                      
                        command2.Parameters.AddWithValue("@Param1", approveddatabean.RecruitmentAppPk1);
                        command2.Parameters.AddWithValue("@Param2", "L1");
                        command2.Parameters.AddWithValue("@Param3", approveddatabean.Level1date);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", numberapprovednow);
                        command2.Parameters.AddWithValue("@Param6", "Recruit");


                        command2.ExecuteNonQuery();
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


        /// <summary>
        /// Approval of recruitment at level2
        /// </summary>
        /// <param name="approveddatabean"></param>
        /// <param name="recruitmentApprovalpk"></param>
        /// <param name="numberapprovednow"></param>
        public void ApproveRecruitLevel2(Datalayer.RecruitmentApprovalDataBean approveddatabean,  int recruitmentApprovalpk, int numberapprovednow)
        {
              SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand("UPDATE    RecruitmentApprovalMaster_tbl SET   Islevel2 = @Param1, Level2number = @Param2, Level2ApproveDate = @Param3, Userpk2 = @Param4 WHERE  (ApprovalPK = @Param5)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", approveddatabean.Islevel2);
                        command.Parameters.AddWithValue("@Param2", approveddatabean.Level2num );
                        command.Parameters.AddWithValue("@Param3", approveddatabean.Level2date2);

                        command.Parameters.AddWithValue("@Param4",  Program.USERPK);
                        command.Parameters.AddWithValue("@Param5", recruitmentApprovalpk);

                        command.ExecuteNonQuery();
                    }


                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (RecruitmentPK, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;
                    
                        command2.Parameters.AddWithValue("@Param1", approveddatabean.RecruitmentAppPk1);
                        command2.Parameters.AddWithValue("@Param2", "L2");
                        command2.Parameters.AddWithValue("@Param3", approveddatabean.Level2date2);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", numberapprovednow);
                        command2.Parameters.AddWithValue("@Param6", "Recruit");


                        command2.ExecuteNonQuery();
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

        /// <summary>
        /// approval at level 3
        /// </summary>
        /// <param name="approveddatabean"></param>
        /// <param name="recruitmentApprovalpk"></param>
        /// <param name="numberapprovednow"></param>
        public void ApprovalRecruitLevel3(Datalayer.RecruitmentApprovalDataBean approveddatabean, int recruitmentApprovalpk, int numberapprovednow)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand(" UPDATE    RecruitmentApprovalMaster_tbl SET   Islevel3 = @Param1, Level3ApproveDate = @Param2, Level3number = @Param3, Userpk3 = @Param4  WHERE (ApprovalPK = @Param5)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", approveddatabean.Islevel3); 
                        command.Parameters.AddWithValue("@Param2", approveddatabean.Level3date);
                        command.Parameters.AddWithValue("@Param3", approveddatabean.Level3num);
                        

                        command.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command.Parameters.AddWithValue("@Param5", recruitmentApprovalpk);

                        command.ExecuteNonQuery();
                    }


                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (RecruitmentPK, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;

                        command2.Parameters.AddWithValue("@Param1", approveddatabean.RecruitmentAppPk1);
                        command2.Parameters.AddWithValue("@Param2", "L3");
                        command2.Parameters.AddWithValue("@Param3", approveddatabean.Level3date);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", numberapprovednow);
                        command2.Parameters.AddWithValue("@Param6", "Recruit");


                        command2.ExecuteNonQuery();
                    }


                    using (SqlCommand command1 = new SqlCommand("UPDATE RecruitmentApplicationMaster_tbl SET iscompleted = 'C' WHERE (RecruitmentAppPk = @Param2)", sqlConnection1))
                    {
                        command1.Transaction = sqltrnsctn;
                       
                        command1.Parameters.AddWithValue("@Param2", approveddatabean.RecruitmentAppPk1);
                       




                        command1.ExecuteNonQuery();
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

        /// <summary>
        /// Get the Contract of the RecruitmentApplication
        /// </summary>
        /// <param name="recapppk"></param>
        /// <returns></returns>
          public String getcontracttypeofRecruitmentApplication(int recapppk)
        {

            String Contractype = "Permanent";
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     Contracttype FROM   RecruitmentApplicationMaster_tbl WHERE  (RecruitmentAppPk = @Param1)", con);
                cmd.Parameters.AddWithValue("@Param1", recapppk);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
             
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        Contractype = dt.Rows[0][0].ToString();
                    }
                }

                return Contractype;

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
        /// insert Employeerecruitingcode
        /// </summary>
        /// <param name="dsgdatabean"></param>
        public ArrayList CreateRecruitmentCode(int recruitmentappPK, int approvalpk, String location, int approvedvaccancy)
        {

            String contracttype = getcontracttypeofRecruitmentApplication(recruitmentappPK);
            ArrayList arrylst = new ArrayList();
            try
            {

                for (int i = 0; i < approvedvaccancy;i++ )
                {

                    int id;

                    using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                    {


                        sqlConnection1.Open();


                        using (SqlCommand command = new SqlCommand(" INSERT INTO RecruitmentCodeMaster_tbl (ApprovalPK, RecruitmentPK, EmpInternalCode, Status) VALUES(@Param1,@Param2,@Param3,@Param4);SELECT SCOPE_IDENTITY()", sqlConnection1))
                        {

                            command.Parameters.AddWithValue("@Param1", approvalpk);
                            command.Parameters.AddWithValue("@Param2", recruitmentappPK);
                            command.Parameters.AddWithValue("@Param3", "XXXXXX");
                            command.Parameters.AddWithValue("@Param4", "W");
                            id = int.Parse(command.ExecuteScalar().ToString());

                        }

                        sqlConnection1.Close();



                    }

                    using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                    {
                      
                        
                        sqlConnection1.Open();
                        anycodegenarator = new AnycodeAutoGenerator();
                        String Empcodenum = "";

                        if (contracttype == "Temporary")
                        {
                            Empcodenum = anycodegenarator.RecruitmentCodeGenerator(location, id,contracttype );
                        }
                        else
                        {
                           Empcodenum = anycodegenarator.RecruitmentCodeGenerator(location, id, contracttype);

                        }
                      

                        using (SqlCommand command1 = new SqlCommand("UPDATE    RecruitmentCodeMaster_tbl SET   EmpInternalCode = @Param1 WHERE  (RecruitmentCodePK = @Param2) ", sqlConnection1))
                        {

                            command1.Parameters.AddWithValue("@Param1", Empcodenum);
                            command1.Parameters.AddWithValue("@Param2", id);

                            command1.ExecuteNonQuery();
                            arrylst.Add(Empcodenum);
                        }

                        sqlConnection1.Close();



                    }


                }
                 

            }
      
            catch (Exception exp)
            {

                throw exp;
            }
            return arrylst;
        }

        # endregion

        //////////////////////////////////////////////*********Leave Application *************************////////////////////////////////////////////////////////////
        # region Leave Approval
        ///////////////////////////////////////////////////////////****************Leave Approvals*******************///////////////////////////////////////////////////////


        ///// <summary>
        ///// get all the Leaveapplication for level 1 Approval
        ///// </summary>
        ///// <returns></returns>
        //public DataTable getallLeavedataforApproval1()
        //{
        //    DataTable dt = new DataTable(); ;
        //    using (SqlConnection con = new SqlConnection(Program.ConnStr))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand("LeaveApprovalLevel1 ", con);


        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        dt.Load(reader);
        //        con.Close();
        //    }
        //    return dt;
        //}


        ///// <summary>
        ///// get all the Leaveapplication for level 2 Approval
        ///// </summary>
        ///// <returns></returns>
        //public DataTable getallLeavedataforApproval3()
        //{
        //    DataTable dt = new DataTable(); ;
        //    using (SqlConnection con = new SqlConnection(Program.ConnStr))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand("LeaveApprovalLevel3 ", con);


        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        dt.Load(reader);
        //        con.Close();
        //    }
        //    return dt;
        //}
        ///// <summary>
        ///// get all the Leaveapplication for level 2 Approval
        ///// </summary>
        ///// <returns></returns>
        //public DataTable getallLeavedataforApproval2()
        //{
        //    DataTable dt = new DataTable(); ;
        //    using (SqlConnection con = new SqlConnection(Program.ConnStr))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand("LeaveApprovalLevel2 ", con);


        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        dt.Load(reader);
        //        con.Close();
        //    }
        //    return dt;
        //}

    
        
        /// <summary>
        ///Leave approval at level 1
        /// </summary>
        /// <param name="lvappdatabean"></param>
        public void LeaveApprovalLevel1(Datalayer.LeaveApprovalDatabean  lvappdatabean)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand("UPDATE    LeaveApprovalMaster_tbl SET   Islevel1 = @Param2, Level1num = @Param3, Level1ApprovalDate = @Param4, Userpk1 = @Param5 WHERE     (ApprovalPk = @Param1)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", lvappdatabean.LeaveapprovalPK );
                        command.Parameters.AddWithValue("@Param2", lvappdatabean.Islevel1);
                        command.Parameters.AddWithValue("@Param3", lvappdatabean.Level1num  );

                        command.Parameters.AddWithValue("@Param5", Program.USERPK);
                        command.Parameters.AddWithValue("@Param4", lvappdatabean.Level1date );

                        command.ExecuteNonQuery();
                    }


                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (LeaveAppPk, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;

                        command2.Parameters.AddWithValue("@Param1", lvappdatabean.LeaveAppPk);
                        command2.Parameters.AddWithValue("@Param2", "L1");
                        command2.Parameters.AddWithValue("@Param3", lvappdatabean.Level1date);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", lvappdatabean.Approvdnow);
                        command2.Parameters.AddWithValue("@Param6", "Leave");


                        command2.ExecuteNonQuery();
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

       

        /// <summary>
        /// Leave approval at level 2
        /// </summary>
        /// <param name="lvappdatabean"></param>
        public void LeaveApprovalLevel2(Datalayer.LeaveApprovalDatabean lvappdatabean)
        {
            Boolean sucessflag = false;
            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE    LeaveApprovalMaster_tbl SET   Islevel2 = @Param1, Level2num = @Param2, Level2ApprovalDate = @Param3, Userpk2 = @Param4 WHERE (ApprovalPk = @Param5)", sqlConnection1))
                    {
                        try
                        {
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", lvappdatabean.Islevel2);
                            command.Parameters.AddWithValue("@Param2", lvappdatabean.Level2num);
                            command.Parameters.AddWithValue("@Param3", lvappdatabean.Level2date2);

                            command.Parameters.AddWithValue("@Param4", Program.USERPK);
                            command.Parameters.AddWithValue("@Param5", lvappdatabean.LeaveapprovalPK);

                            command.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            
                              sucessflag = false;
                        }
                    }
                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (LeaveAppPk, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        try
                        {
                            command2.Transaction = sqltrnsctn;

                            command2.Parameters.AddWithValue("@Param1", lvappdatabean.LeaveAppPk);
                            command2.Parameters.AddWithValue("@Param2", "L2");
                            command2.Parameters.AddWithValue("@Param3", lvappdatabean.Level2date2);
                            command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                            command2.Parameters.AddWithValue("@Param5", lvappdatabean.Approvdnow);
                            command2.Parameters.AddWithValue("@Param6", "Leave");
                            command2.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            
                            sucessflag = false;
                        }
                    }
                    
                    sqltrnsctn.Commit();
                    sucessflag = true;
                    lvappdatabean.Level3num = lvappdatabean.Level2num;
                    lvappdatabean.Islevel3 = lvappdatabean.Islevel2;
                    lvappdatabean.Level3date = lvappdatabean.Level2date2;                                 
                  

                }
                catch (Exception exp)
                {

                    sqltrnsctn.Rollback();
                    sucessflag = false;
                    throw exp;
                }

                sqlConnection1.Close();
            }

            if (sucessflag == true)
            {
                LeaveApprovalLevel3(lvappdatabean);
            }

        }


        #region newtry

        
          

#endregion


        /// <summary>
        /// Leave approval at level 3
        /// </summary>
        /// <param name="lvappdatabean"></param>
        public void LeaveApprovalLevel3(Datalayer.LeaveApprovalDatabean lvappdatabean)
        {
            Boolean sucessflag3 = false;
            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE    LeaveApprovalMaster_tbl SET  Islevel3 = @Param1, Level3num = @Param2, Level3ApprovalDate = @Param3, Userpk3 = @Param4 WHERE (ApprovalPk = @Param6) ", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", lvappdatabean.Islevel3);
                        command.Parameters.AddWithValue("@Param2", lvappdatabean.Level3num );
                        command.Parameters.AddWithValue("@Param3", lvappdatabean.Level3date );
                        command.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command.Parameters.AddWithValue("@Param6", lvappdatabean.LeaveapprovalPK);
                        command.ExecuteNonQuery();
                    }                    
                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (LeaveAppPk, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;
                        command2.Parameters.AddWithValue("@Param1", lvappdatabean.LeaveAppPk);
                        command2.Parameters.AddWithValue("@Param2", "L3");
                        command2.Parameters.AddWithValue("@Param3", lvappdatabean.Level3date);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", lvappdatabean.Approvdnow);
                        command2.Parameters.AddWithValue("@Param6", "Leave");
                        command2.ExecuteNonQuery();
                    }
                         
                    sqltrnsctn.Commit();
                    sucessflag3 = true; ;
                   

                }
                catch (Exception exp)
                {

                    sqltrnsctn.Rollback();

                    throw exp;
                }

                sqlConnection1.Close();
            }
            if (sucessflag3 == true)
            {
                confirmleavedates(lvappdatabean.LeaveAppPk);
            }

        }





/// <summary>
/// get all the leave approval data
/// </summary>
/// <param name="levelnum"></param>
/// <param name="Branchlctnpk"></param>
/// <returns></returns>
        public DataTable getallLeaveForApproval(int levelnum ,int Branchlctnpk)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetLeaveApplicationDataForApproval_SP ", con);

                cmd.Parameters.AddWithValue("@levelnum", levelnum);
                cmd.Parameters.AddWithValue("@BranchlctnPK", Branchlctnpk);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }



        /// <summary>
        /// mark entries on the employee leave taken against an application
        /// </summary>
        public void confirmleavedates(int leaveappid)
        {
            DataTable dt = getLeaveexistingApproval(leaveappid);

            if (dt.Rows .Count >0)
            {
                SqlConnection con = new SqlConnection(Program.ConnStr);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertEmployeeLeaves_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fromdate", DateTime.Parse(dt.Rows[0][4].ToString()));
                    cmd.Parameters.AddWithValue("@todate", DateTime.Parse(dt.Rows[0][5].ToString()));
                    cmd.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[0][2].ToString()));
                    cmd.Parameters.AddWithValue("@leaveapp", int.Parse(dt.Rows[0][0].ToString()));
                    cmd.Parameters.AddWithValue("@leavePK", int.Parse(dt.Rows[0][3].ToString()));
                    cmd.Parameters.AddWithValue("@leaveAprvlPK", int.Parse(dt.Rows[0][1].ToString()));

                    cmd.ExecuteNonQuery();

                    DateTime fromtime= DateTime.Parse(dt.Rows[0][4].ToString());
                    DateTime leavedate= DateTime.Parse(dt.Rows[0][4].ToString());
                    DateTime totime=DateTime.Parse(dt.Rows[0][5].ToString());
                    int empid=int.Parse(dt.Rows[0][2].ToString());
                    int leaveapppk=int.Parse(dt.Rows[0][0].ToString());
                    int leavepk= int.Parse(dt.Rows[0][3].ToString());
                    int leaveappprvlk=int.Parse(dt.Rows[0][1].ToString());

                    string Leavecode = "";
                    String[] leavestype= new String[] {"A","UPL","SL","PL","FL"};
                    using (SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr))
                    {
                        try
                        {
                            var prefix = cntxt.LeaveMaster_tbls.Where(u => u.LeavePk == leavepk).Select(u => u.LeaveCode).FirstOrDefault();
                            Leavecode = prefix.ToString().Trim();

                        }
                        catch (Exception)
                        {

                            Leavecode = "";
                        }
                    }

                   
                        using (SqlServerLinqDataContext  cntxt= new SqlServerLinqDataContext (Program.ConnStr ))
                        {
                                                     
                            

                            var q = from swpdata in cntxt.EmpSwipedataBank_tbls
                                    where swpdata.empid == empid && (swpdata.SwipeDate >= fromtime.Date && swpdata.SwipeDate <= totime)
                                    select swpdata;

                                   foreach (var element in q)
                                   {
                                       if(leavestype.Contains (element.ApprInstatus.Trim ())&& leavestype.Contains (element.ApprOutStatus.Trim ()))
                                       {
                                           if (Leavecode!="")
                                           {

                                           element.ApprInstatus = Leavecode;
                                           element.ApprOutStatus = Leavecode;

                                           Actionlog.actiondone("ApprInstatus and Outstatus changed", "of employeeID " + empid + " fordate " + element.SwipeDate + "", empid);

                                           }
                                       }
                                   }

                                   cntxt.SubmitChanges();

                        }


                     


                 
                }
                catch (Exception exp)
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Error at Confirm Days");
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }
                finally
                {
                    con.Close();

                }


            }




        }




        /// GetAll Approvaldata
        /// </summary>
        /// <param name="recapppk"></param>
        /// <returns></returns>
        public DataTable getLeaveexistingApproval(int appPK)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     LeaveApplicationMaster.LeaveAppPk, LeaveApprovalMaster_tbl.ApprovalPk, LeaveApplicationMaster.Empid, LeaveApplicationMaster.LeavePK,  " +
           "           LeaveApplicationMaster.Fromdate, LeaveApplicationMaster.Todate, LeaveApprovalMaster_tbl.IsCompleted ,DATEDIFF ( DAY ,  LeaveApplicationMaster.Fromdate,LeaveApplicationMaster.Todate  ) as day" +
 " FROM         LeaveApplicationMaster INNER JOIN " +
       "               LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk " +
 " WHERE     (LeaveApplicationMaster.LeaveAppPk = @Param1) AND (LeaveApprovalMaster_tbl.IsCompleted = N'N')", con);
                cmd.Parameters.AddWithValue("@Param1", appPK);
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


        public DataTable GetTheLeaveApprovedDays(int appPK)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        LeaveApplicationMaster.Empid, LeaveApplicationMaster.LvAppnum, EmployeeLeaveTaken_tbl.Reason, EmployeeLeaveTaken_tbl.dateofleave, 
                         EmployeeLeaveTaken_tbl.AddedVia
FROM            EmployeeLeaveTaken_tbl INNER JOIN
                         LeaveApplicationMaster ON EmployeeLeaveTaken_tbl.LeaveAppPk = LeaveApplicationMaster.LeaveAppPk
WHERE        (LeaveApplicationMaster.LeaveAppPk = @Param1)", con);
                cmd.Parameters.AddWithValue("@Param1", appPK);
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


                
# endregion
        ////////////////////////////////////////////////////*********AdvanceApplication Transaction***************////////////////////////////////////////////////////////


        # region Advance Approval


        public DataTable getallAdvancedataforAlLevelsOfApproval(int levelnum ,int BranchlctnPK)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetAdvanceDataForApproval_sp ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@levelnum", levelnum);
                cmd.Parameters.AddWithValue("@BranchlctnPK", BranchlctnPK);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }





           /// <summary>
        ///Advance approval at level 1
        /// </summary>
        /// <param name="advappdatabean"></param>
        public void AdvanceApprovalLevel1(Datalayer.AdvanceApprovalDatabean  advappdatabean)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand(" UPDATE    AdvanceApprovalMaster_tbl SET    IsLevel1 = @Param1, Level1Amount = @Param2, Level1ApprovalDate = @Param3, Userpk1 = @Param4 WHERE     (AdvanceApprovalPK = @Param5)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", advappdatabean.Islevel1);
                        command.Parameters.AddWithValue("@Param2", advappdatabean.Level1num);
                        command.Parameters.AddWithValue("@Param3", advappdatabean.Level1date);

                        command.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command.Parameters.AddWithValue("@Param5", advappdatabean.ApprovalPk1 );

                        command.ExecuteNonQuery();
                    }


                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (AdvanceAppPk, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6) ", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;

                        command2.Parameters.AddWithValue("@Param1", advappdatabean.AdvanceAppPK1);
                        command2.Parameters.AddWithValue("@Param2", "L1");
                        command2.Parameters.AddWithValue("@Param3", advappdatabean.Level1date);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", advappdatabean.Approvdnow);
                        command2.Parameters.AddWithValue("@Param6", "Advance");


                        command2.ExecuteNonQuery();
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

    



        /// <summary>
        /// Advance approval at level 2
        /// </summary>
        /// <param name="lvappdatabean"></param>
        public void AdvanceApprovalLevel2(Datalayer.AdvanceApprovalDatabean  advnapprvdatabean)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApprovalMaster_tbl SET   Islevel2 = @Param2, Level2Amount = @Param3, Level2ApprovalDate = @Param4, Userpk2 = @Param5 WHERE  (AdvanceApprovalPK = @Param1)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", advnapprvdatabean.ApprovalPk1 );
                        command.Parameters.AddWithValue("@Param2", advnapprvdatabean.Islevel2 );
                        command.Parameters.AddWithValue("@Param3", advnapprvdatabean.Level2num);

                        command.Parameters.AddWithValue("@Param4", advnapprvdatabean.Level2date2);
                        command.Parameters.AddWithValue("@Param5", Program.USERPK );

                        command.ExecuteNonQuery();
                    }


                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (AdvanceAppPk, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)  ", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;

                        command2.Parameters.AddWithValue("@Param1", advnapprvdatabean.AdvanceAppPK1);
                        command2.Parameters.AddWithValue("@Param2", "L2");
                        command2.Parameters.AddWithValue("@Param3", advnapprvdatabean.Level2date2);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", advnapprvdatabean.Approvdnow);
                        command2.Parameters.AddWithValue("@Param6", "Advance");



                        command2.ExecuteNonQuery();
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



    


        /// <summary>
        /// Advance  approval at level 3
        /// </summary>
        /// <param name="lvappdatabean"></param>
        public void AdvanceApprovalLevel3(Datalayer.AdvanceApprovalDatabean  advappdatabean)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApprovalMaster_tbl SET Iscompleted = N'Y', Islevel3 = @Param1, Level3Amount = @Param2, Level3ApprovalDate = @Param3, Userpk3 = @Param4 WHERE  (AdvanceApprovalPK = @Param5) ", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", advappdatabean.Islevel3);
                        command.Parameters.AddWithValue("@Param2", advappdatabean.Level3num);
                        command.Parameters.AddWithValue("@Param3", advappdatabean.Level3date);

                        command.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command.Parameters.AddWithValue("@Param5", advappdatabean.ApprovalPk1 );

                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command3 = new SqlCommand("UPDATE    AdvanceApplicationMaster_tbl SET              Iscompleted = N'Y' WHERE     (AdvanceAppPk = @Param1) ", sqlConnection1))
                    {
                        command3.Transaction = sqltrnsctn;
                        command3.Parameters.AddWithValue("@Param1", advappdatabean.AdvanceAppPK1);
                        command3.ExecuteNonQuery();
                    }

                    using (SqlCommand command2 = new SqlCommand("INSERT INTO ApprovalTrack_Temp_tbl (AdvanceAppPk, ApprovalLevel, ApprovalDate, UserPk, ApprovedValue, ApprovalType) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)  ", sqlConnection1))
                    {
                        command2.Transaction = sqltrnsctn;

                        command2.Parameters.AddWithValue("@Param1", advappdatabean.AdvanceAppPK1);
                        command2.Parameters.AddWithValue("@Param2", "L3");
                        command2.Parameters.AddWithValue("@Param3", advappdatabean.Level3date);
                        command2.Parameters.AddWithValue("@Param4", Program.USERPK);
                        command2.Parameters.AddWithValue("@Param5", advappdatabean.Approvdnow);
                        command2.Parameters.AddWithValue("@Param6", "Advance");


                        command2.ExecuteNonQuery();
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


      

        # endregion 
        ////////////////////////////////////////////////////////////////Designation Change\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////

        # region Designation Change


        /// <summary>
        ///get all data for the approval forms
        /// </summary>
        /// <param name="branchlctnPK"></param>
        /// <param name="levelnum"></param>
        /// <returns></returns>
        public DataTable getAllDesignationChangeApplication(int branchlctnPK ,int levelnum)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetDesignationChangeDataForApproval_sp ", con);

                cmd.Parameters.AddWithValue("@BranchlctnPK", branchlctnPK);
                cmd.Parameters.AddWithValue("@Levelnum", levelnum);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }











        /// <summary>
        ///Designation Change approval at level 1
        /// </summary>
        /// <param name="advappdatabean"></param>
        public void UpdateDesignationChangeApprovalLevel2(int dsgapprovalPk)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand("UPDATE    DesignationApprovalMaster_tbl SET   Islevel2 = @Param1, Level2ApprovalDate = getdate(), Userpk2 = @Param3 WHERE     (DsgApprovalPK = @Param4)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1","A");
                     //   command.Parameters.AddWithValue("@Param2", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param3",Program.USERPK);

                        command.Parameters.AddWithValue("@Param4", dsgapprovalPk);
                      
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





        /// <summary>
        ///Designation Change approval at level 1
        /// </summary>
        /// <param name="advappdatabean"></param>
        public void UpdateDesignationChangeApprovalLevel1(int dsgapprovalPk)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand("UPDATE    DesignationApprovalMaster_tbl SET   IsLevel1 = @Param1, Level1ApprovalDate = getdate(), Userpk1 = @Param3 WHERE     (DsgApprovalPK = @Param4)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", "A");
                    //    command.Parameters.AddWithValue("@Param2", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param3", Program.USERPK);

                        command.Parameters.AddWithValue("@Param4", dsgapprovalPk);

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




        /// <summary>
        ///Designation Change approval at level 3
        /// </summary>
        /// <param name="advappdatabean"></param>
        public void UpdateDesignationChangeApprovalLevel3(int dsgapprovalPk)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {


                    using (SqlCommand command = new SqlCommand("UPDATE    DesignationApprovalMaster_tbl SET   Islevel3 = @Param1, Level3ApprovalDate = getdate(), Userpk3 = @Param3 ,IsCompleted= N'Y'WHERE     (DsgApprovalPK = @Param4)", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", "A");
                     //   command.Parameters.AddWithValue("@Param2", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param3", Program.USERPK);

                        command.Parameters.AddWithValue("@Param4", dsgapprovalPk);

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
# endregion

        /////////////////////////////////////////////////////////////////////Contract Renewal/////////////////////////////////////////////////////////////////////////////
        # region Contract Renewal


        /// <summary>
/// INSERTCONTRACT DETAILS
/// </summary>
/// <param name="empid"></param>
/// <param name="Remark"></param>
/// <returns></returns>
        public String insertCntractrenewalApplication(int empid ,String Remark,DateTime fromdate ,DateTime todate ,String Contracttype)
        {

            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int contractrenewalid;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO ContractRenewalApplication_tbl (Empid, Remark, AppliedUserPk, Fromdate, Todate, ContractType) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6);SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);
                        command.Parameters.AddWithValue("@Param2", Remark);
                        command.Parameters.AddWithValue("@Param3", Program.USERPK );
                         command.Parameters.AddWithValue("@Param4", fromdate);
                        command.Parameters.AddWithValue("@Param5", todate);
                        command.Parameters.AddWithValue("@Param6", Contracttype);
                        contractrenewalid = int.Parse(command.ExecuteScalar().ToString());

                    }

                   
                    String contractrenewalcode = anycodegenarator.ContractRenewalCodeGenerator(contractrenewalid);




                    using (SqlCommand command1 = new SqlCommand("UPDATE ContractRenewalApplication_tbl SET    ContractAppnum =@param2 WHERE (ContractAppPk = @Param1) ", sqlConnection1))
                    {

                        command1.Parameters.AddWithValue("@Param1", contractrenewalid);
                        command1.Parameters.AddWithValue("@param2", contractrenewalcode);

                        command1.ExecuteNonQuery();

                    }

                    sqlConnection1.Close();







                    return contractrenewalcode;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }

        }

        
/// <summary>
/// get all the contract renewal Application
/// </summary>
/// <param name="levelnum"></param>
/// <param name="branchlctnpk"></param>
/// <returns></returns>
      public DataTable getallContractRenewalApplicationforApprovals(int levelnum ,int branchlctnpk)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GertAllContractRenewalAPP_sp ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchLocation", branchlctnpk);
                cmd.Parameters.AddWithValue("@ActionLevel", levelnum);
               
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }


      /// <summary>
      ///OT aPPROVAL aT ALL LEVELS
      /// </summary>
      /// <param name="advappdatabean"></param>
      public void ApproveContractRenewalApllications(int approvalPK, int applicationPk, int levelnum, int approvedduration)
      {


          using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
          {

              sqlConnection1.Open();
              SqlCommand cmd = new SqlCommand("InsertApprivlDataForContract_sp", sqlConnection1);


              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@ApprovalPK", approvalPK);
              cmd.Parameters.AddWithValue("@ApplicationPK", applicationPk);
              cmd.Parameters.AddWithValue("@ApprovedValue", approvedduration);

              cmd.Parameters.AddWithValue("@levelnum", levelnum);


              cmd.Parameters.AddWithValue("@ApprovedDate", DateTime.Now.Date);
              cmd.Parameters.AddWithValue("@UserpK", Program.USERPK);
              cmd.ExecuteNonQuery();
              sqlConnection1.Close();
          }

      }


# endregion
      ////////////////////////////////////////////////////////////////////// ShiftTransfer ////////////////////////////////////////////////////////////////////////////////////

      # region Shift Change
      /// <summary>
        /// insert the shifttransfer table and the updatedes theapplication number
        /// 
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>

        public string insertShiftTransferAppliucation(int empid, int frmShiftPK ,  int toshiftPk , String Remark)
        {
            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int shifttransferid;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO ShiftChangeApplication_tbl (Empid, CurrentShiftPK, ToShiftPk, UserApplied) VALUES  (@Param1,@Param2,@Param3,@Param4);SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);
                        command.Parameters.AddWithValue("@Param2", frmShiftPK);
                        command.Parameters.AddWithValue("@Param3", toshiftPk);
                   
                        command.Parameters.AddWithValue("@Param4", Program.USERPK);

                        shifttransferid = int.Parse(command.ExecuteScalar().ToString());

                    }

                    sqlConnection1.Close();
                    String shiftchangeCode = anycodegenarator.ShiftTransferApplicationCodeGenerator(shifttransferid);


                    sqlConnection1.Open();


                    using (SqlCommand command1 = new SqlCommand("UPDATE    ShiftChangeApplication_tbl SET  Appnum = @Param1 WHERE  (ShftAppPK = @Param2) ", sqlConnection1))
                    {

                        command1.Parameters.AddWithValue("@Param1", shiftchangeCode);
                        command1.Parameters.AddWithValue("@Param2", shifttransferid );

                        command1.ExecuteNonQuery();

                    }

                    sqlConnection1.Close();







                    return shiftchangeCode;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }




        /// <summary>
        /// get all the leave approval data
        /// </summary>
        /// <param name="levelnum"></param>
        /// <param name="Branchlctnpk"></param>
        /// <returns></returns>
        public DataTable getShiftChangeForApproval(int levelnum, int Branchlctnpk)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetShiftChangeApplicationForApproval_sp", con);

                cmd.Parameters.AddWithValue("@levelnum", levelnum);
                cmd.Parameters.AddWithValue("@BranchLctnPK", Branchlctnpk);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }
   


      # endregion

        ////////////////////////////////////////////////////////////////////// OT APPROVAL ////////////////////////////////////////////////////////////////////////////////////

        # region Ot Application



        /// <summary>
        /// get all ot application for Approval
        /// </summary>
        /// <returns></returns>
        public DataTable getallOTApplicationforApprovals(int levelnum ,int branchlctnpk)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("OTApprovalLevels12and3_sp ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchlctnPK", branchlctnpk);
                cmd.Parameters.AddWithValue("@levelnum", levelnum);
               
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }

/// <summary>
/// deletes an employee from ot list
/// </summary>
/// <param name="empid"></param>
/// <param name="appid"></param>
/// <param name="levelnum"></param>
        public void deleteOtEmployee(int empid, int appid, int levelnum)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("DeletingEmployeeFromOT_sp", sqlConnection1);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@actionLevel", levelnum);
                cmd.Parameters.AddWithValue("@otapppk", appid);
                
               
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            }


        }



        /// <summary>
        ///OT aPPROVAL aT ALL LEVELS
        /// </summary>
        /// <param name="advappdatabean"></param>
        public void ApproveOTApllications(int approvalPK ,int applicationPk ,int levelnum , int approvedduration)
        {

       
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("InsertOTApprovalData_sp", sqlConnection1);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApprovalPK", approvalPK);
                cmd.Parameters.AddWithValue("@ApplicationPK", applicationPk);
                cmd.Parameters.AddWithValue("@ApprovedValue", approvedduration);
               
                cmd.Parameters.AddWithValue("@levelnum", levelnum);


                cmd.Parameters.AddWithValue("@ApprovedDate",DateTime.Now.Date );
                cmd.Parameters.AddWithValue("@UserpK", Program.USERPK );
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            }

        }


        # endregion
        ///////////////////////////////////////////////////////////////////////////////////******LHR Application***///////////////////////////////////////////////////////
        # region LHR Approvals

        /// <summary>
        /// get all the leave approval data
        /// </summary>
        /// <param name="levelnum"></param>
        /// <param name="Branchlctnpk"></param>
        /// <returns></returns>
        public DataTable getallLHRForApproval( int Branchlctnpk ,int levelnum)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetLHRApplicationForApproval_Sp ", con);

                cmd.Parameters.AddWithValue("@levelnum", levelnum);
                cmd.Parameters.AddWithValue("@BranchlctnPK", Branchlctnpk);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }



  

        /// <summary>
        ///LHR aPPROVAL aT ALL LEVELS
        /// </summary>
        /// <param name="advappdatabean"></param>
        public void approveLHRApplications(int applicationPk, int levelnum, int approvedduration)
        {


            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("ApproveLHRApplications_Sp", sqlConnection1);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicationPK", applicationPk);
               
                cmd.Parameters.AddWithValue("@ApprovedValue", approvedduration);

                cmd.Parameters.AddWithValue("@levelnum", levelnum);


                cmd.Parameters.AddWithValue("@ApprovedDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@UserpK", Program.USERPK);
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            }

        }

        # endregion

        ////////////////////////////////////////Shift Renewal ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region shiftTransfer

        /// <summary>
        ///Designation Change approval at level 1
        /// </summary>
        /// <param name="advappdatabean"></param>
        public void UpdatesShiftChangeApplication(int shftchangeapp , int levelnum,String Action)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {
                    if (levelnum==1)
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE   ShiftChangeApplication_tbl SET Islevel1 = @Param1, UserpK1 = @Param3, Level1date = @Param2 WHERE     (ShftAppPK = @Param4)", sqlConnection1))
                        {
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", Action);
                            command.Parameters.AddWithValue("@Param2", DateTime.Now.Date);
                            command.Parameters.AddWithValue("@Param3", Program.USERPK);

                            command.Parameters.AddWithValue("@Param4", shftchangeapp);

                            command.ExecuteNonQuery();
                        }
                    }
                    else if (levelnum == 2)
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE   ShiftChangeApplication_tbl SET Islevel2 = @Param1, UserpK2 = @Param3, Level2date = @Param2 WHERE     (ShftAppPK = @Param4)", sqlConnection1))
                        {
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", Action);
                            command.Parameters.AddWithValue("@Param2", DateTime.Now.Date);
                            command.Parameters.AddWithValue("@Param3", Program.USERPK);

                            command.Parameters.AddWithValue("@Param4", shftchangeapp);

                            command.ExecuteNonQuery();
                        }

                    }
                    else if (levelnum == 3)
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE   ShiftChangeApplication_tbl SET Islevel3 = @Param1, UserpK3 = @Param3, Level3date = @Param2      WHERE     (ShftAppPK = @Param4)", sqlConnection1))
                        {
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", Action);
                            command.Parameters.AddWithValue("@Param2", DateTime.Now.Date);
                            command.Parameters.AddWithValue("@Param3", Program.USERPK);

                            command.Parameters.AddWithValue("@Param4", shftchangeapp);

                            command.ExecuteNonQuery();
                        }

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

        #endregion
////////////////////////////////////////////////LHR  Approvals /////////////////////////////////////////////////////////////////////////////////////////////////////
        #region LHR rejectApplication


        /// <summary>
        /// get all the leave approval data
        /// </summary>
        /// <param name="levelnum"></param>
        /// <param name="Branchlctnpk"></param>
        /// <returns></returns>
        public DataTable getallLHRReject(int Branchlctnpk, int levelnum)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("LHRAprrovalData_sp ", con);

                cmd.Parameters.AddWithValue("@ActionLevel", levelnum);
                cmd.Parameters.AddWithValue("@BranchlctnPK", Branchlctnpk);
                cmd.Parameters.AddWithValue("@LHRAction", "Reject");
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }









        #endregion

        ///////////////////////////////////////////// Leave Encashment Application /////////////////////////////////////////////////////////////////////////////////

        # region Leave Encashmaent
        public DataTable getLeaveEnchasementApplicationforApproval(int levelnum, int Branchlctnpk)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetLeaveEncashmentApproval_sp", con);

                cmd.Parameters.AddWithValue("@ActionLevel", levelnum);
                cmd.Parameters.AddWithValue("@BranchlctnPK", Branchlctnpk);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }


       public void UpdateLeaveEncashmentApp(int LvnEncashApp , int levelnum,String Action)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {
                    if (levelnum==1)
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE    LeaveEnchasementMaster_tbl "+
" SET              Islevel1 = @Param1, IsLevel1Date = getdate(), LevelUserPK1 = @Param3"+
" WHERE     (LeaveEncashPk = @Param7)", sqlConnection1))
                        {
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1","A");
                           
                            command.Parameters.AddWithValue("@Param3", Program.USERPK);

                            command.Parameters.AddWithValue("@Param7", LvnEncashApp);

                            command.ExecuteNonQuery();
                        }
                    }
                    else if (levelnum == 2)
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE    LeaveEnchasementMaster_tbl " +
" SET              Islevel2 = @Param1, IsLevel2Date = getdate(), LevelUserPK2 = @Param3" +
" WHERE     (LeaveEncashPk = @Param7)", sqlConnection1))
                        {
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", "A");

                            command.Parameters.AddWithValue("@Param3", Program.USERPK);

                            command.Parameters.AddWithValue("@Param7", LvnEncashApp);

                            command.ExecuteNonQuery();
                        }

                    }
                    else if (levelnum == 3)
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE    LeaveEnchasementMaster_tbl " +
" SET              Islevel3 = @Param1, IsLevel3Date = getdate(), LevelUserPK3 = @Param3 , IsCompleted = N'Y'" +
" WHERE     (LeaveEncashPk = @Param7)", sqlConnection1))
                        {
                            command.Transaction = sqltrnsctn;
                            command.Parameters.AddWithValue("@Param1", "A");

                            command.Parameters.AddWithValue("@Param3", Program.USERPK);

                            command.Parameters.AddWithValue("@Param7", LvnEncashApp);

                            command.ExecuteNonQuery();
                        }

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

        # endregion
       ////////////////////////////////////////////////////////////////////Attendance Approval////////////////////////////////////////////////////////////////////////

       # region Attendance Correction


       /// <summary>
       /// get all Approvals  for correction
       /// </summary>
       /// <returns></returns>
       public DataTable getallcorrectiondata(int BranchPk, DateTime nowdate)
       {


           DataTable dt = new DataTable();

           using (SqlConnection con = new SqlConnection(Program.ConnStr))
           {
               con.Open();

               //changed on 14th April2013
               //  SqlCommand cmd = new SqlCommand("GetEmployeSwipedata_sp", con);
               SqlCommand cmd = new SqlCommand("SELECT  CorrectionDaily_tbl.CorrectionPk,   EmployeePersonalMaster_tbl.empid AS Empid, EmployeePersonalMaster_tbl.empno AS Empnum, EmployeePersonalMaster_tbl.First_name AS Name,  " +
                   "   DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, CorrectionDaily_tbl.PreviousInStatus AS [Previous Status], "+
                  "    CorrectionDaily_tbl.InStatus AS [To Status], CorrectionDaily_tbl.DateForSwipe AS Date, CorrectionDaily_tbl.InValue AS [In Value]  "+
" FROM         CorrectionDaily_tbl INNER JOIN  "+
                     " EmployeePersonalMaster_tbl ON CorrectionDaily_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN  "+
                     " EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN  "+
                     " DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN  "+
                     " DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK  "+
" WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @BranchLocationPk)AND (CorrectionDaily_tbl.IsApproved = N'N')AND (CorrectionDaily_tbl.DateForSwipe = @datetoday)", con);



               cmd.Parameters.AddWithValue("@BranchLocationPk", BranchPk);
               cmd.Parameters.AddWithValue("@datetoday", nowdate.ToString("MM-dd-yyyy"));
               //cmd.Parameters AddWithValue("@dayoffweek",nowdate.DayOfWeek.ToString ());


               //cmd.Parameters.AddWithValue("@Calltype", retrievetypr);

               //cmd.Parameters.AddWithValue("@dayoffweek", nowdate.DayOfWeek.ToString());
               //    cmd.Parameters.AddWithValue("@Calltype", "Show");
               //cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader reader = cmd.ExecuteReader();

               dt.Load(reader);
               con.Close();
           }
           return dt;





       }



        /// <summary>
        /// reject an application for correctiom
        /// </summary>
        /// <param name="correctionId"></param>

       public void rejectCorrectionApplication(int correctionId)
       {


           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();

               SqlCommand cmd = new SqlCommand("UPDATE    CorrectionDaily_tbl SET  IsApproved = N'R' WHERE     (CorrectionPk = @Param1)", sqlConnection1);

               cmd.Parameters.AddWithValue("@Param1", correctionId);
               cmd.ExecuteNonQuery();

               sqlConnection1.Close();
           }
       }

        /// <summary>
        /// approve a attendance correction
        /// </summary>
        /// <param name="correctionId"></param>
       public void approveCorrectiondata(int correctionId)
       {
           DataTable dt = new DataTable();
          
           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();
              



                   SqlCommand cmd = new SqlCommand("SELECT     empid, ShiftPK, DateForSwipe, InStatus, InValue ,ShiftTime , SwipePk, Outstatus " +
" FROM         CorrectionDaily_tbl  "+
" WHERE     (CorrectionPk = @Param1)", sqlConnection1);
                
                   cmd.Parameters.AddWithValue("@Param1", correctionId);

                   SqlDataReader reader = cmd.ExecuteReader();

                   dt.Load(reader);

                   if (dt.Rows.Count != 0)
                   {




                      
                       if (dt.Rows[0][3].ToString().Trim() == "A" || dt.Rows[0][3].ToString().Trim() == "P")
                       {

                           #region if mark Abscent
                           SqlTransaction sqltrnsctn;
                           sqltrnsctn = sqlConnection1.BeginTransaction();
              
               try
               {
                   
                           SqlCommand cmd1 = new SqlCommand("AttendanceCorrectionDaily_sp ", sqlConnection1);



                           cmd1.Transaction = sqltrnsctn;
                           cmd1.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[0][0].ToString()));
                           cmd1.Parameters.AddWithValue("@ShiftPk", int.Parse(dt.Rows[0][1].ToString()));
                           cmd1.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[0][2].ToString()));
                           cmd1.Parameters.AddWithValue("@instatus", "P");
                           cmd1.Parameters.AddWithValue("@Invalue", 0);
                           cmd1.Parameters.AddWithValue("@SwipeinTime", DateTime.Parse(dt.Rows[0][5].ToString()));
                           cmd1.Parameters.AddWithValue("@ApplicationType", "A");
                           cmd1.Parameters.AddWithValue("@Outstatus", "N");
                           cmd1.Parameters.AddWithValue("@swipePK", 0);


                           cmd1.CommandType = CommandType.StoredProcedure;

                           cmd1.ExecuteNonQuery();



                           sqltrnsctn.Commit();
               }
               catch (Exception exp)
               {

                   sqltrnsctn.Rollback();

                   throw exp;
               }

# endregion
                           
                       }
                       else if (dt.Rows[0][3].ToString().Trim () == "LH")
                       {
# region waste region       
                             int   empid = 0;
	 int swipePK = 0;
	String Outstatus="";
	 int Invalue=0;
	  int ShiftPk=0;
	String instatus="";
	DateTime  datetoday ;
	DateTime SwipeinTime ;
	String ApplicationType ;

                              empid=int.Parse(dt.Rows[0][0].ToString());

                         ShiftPk =int.Parse(dt.Rows[0][1].ToString());
                           datetoday=DateTime.Parse(dt.Rows[0][2].ToString());
                        instatus="LH";
                           SwipeinTime=DateTime.Parse(dt.Rows[0][5].ToString());
                           ApplicationType="LH";
                           Invalue=0;
                         
                           swipePK= int.Parse(dt.Rows[0][6].ToString());


                           //cmd1.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[0][0].ToString()));
                           //cmd1.Parameters.AddWithValue("@ShiftPk", int.Parse(dt.Rows[0][1].ToString()));
                           //cmd1.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[0][2].ToString()));
                           //cmd1.Parameters.AddWithValue("@instatus", "LH");
                           //cmd1.Parameters.AddWithValue("@Invalue", 0);
                           //cmd1.Parameters.AddWithValue("@SwipeinTime", DateTime.Parse(dt.Rows[0][5].ToString()));
                           //cmd1.Parameters.AddWithValue("@ApplicationType", "LH");
                           //cmd1.Parameters.AddWithValue("@Outstatus", dt.Rows[0][7].ToString());
                           //cmd1.Parameters.AddWithValue("@swipePK", int.Parse(dt.Rows[0][6].ToString()));
# endregion
                               Outstatus=dt.Rows[0][7].ToString();

                           if (Outstatus == "LH")
                           {

                               using (SqlCommand cmd2 = new SqlCommand(" UPDATE    EmployeSwipeDaily_tbl " +
" SET            InStatus = @instatus, Invalue = @Invalue, Shift_Pk = @ShiftPk, Outstatus = NULL, OutValue = 0, SwipeOut = NULL,Swipin =@SwipeinTime " +
" WHERE     (swipePK = @swipePK) AND (empid = @empid) AND (Date = @datetoday)", sqlConnection1))
                               {
                                   cmd2.Parameters.AddWithValue("@swipePK", int.Parse(dt.Rows[0][6].ToString()));
                                   cmd2.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[0][0].ToString()));
                                   cmd2.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[0][2].ToString()));
                                   cmd2.Parameters.AddWithValue("@instatus", "LH");
                                   cmd2.Parameters.AddWithValue("@Invalue", 0);
                                   cmd2.Parameters.AddWithValue("@SwipeinTime", DateTime.Parse(dt.Rows[0][5].ToString()));
                                   cmd2.Parameters.AddWithValue("@ShiftPk", int.Parse(dt.Rows[0][1].ToString()));
                                   cmd2.ExecuteNonQuery();
                               }

                           }
                           else
                           {

                               DataTable dt1=new DataTable ();
                               using (SqlCommand cmd2 = new SqlCommand(" SELECT     swipePK FROM         EmployeSwipeDaily_tbl  WHERE     (Date = @datetoday)", sqlConnection1))
                               {

                                   cmd2.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[0][2].ToString()));

                                   cmd2.ExecuteNonQuery();


                                   SqlDataReader rdr = cmd2.ExecuteReader();

                                   dt1.Load(rdr);                                
                                   
                                  }
                               
                               //if had a row present in attendance register
                               if (dt1.Rows.Count == 0)
                               {
                                   //if not present
                                   #region ifnotpresent
                                   using (SqlCommand cmd2 = new SqlCommand(" INSERT INTO  EmployeSwipeDaily_tbl "+
                 "      (empid, Swipin, Date, InStatus, Invalue, Shift_Pk) "+
					"	VALUES     (@empid,@SwipeinTime,@datetoday,@instatus,@Invalue,@ShiftPk)", sqlConnection1)) 
                                   {

                                       cmd2.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[0][0].ToString()));
                                       cmd2.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[0][2].ToString()));
                                       cmd2.Parameters.AddWithValue("@instatus", "LH");
                                       cmd2.Parameters.AddWithValue("@Invalue", 0);
                                       cmd2.Parameters.AddWithValue("@SwipeinTime", DateTime.Parse(dt.Rows[0][5].ToString()));
                                       cmd2.Parameters.AddWithValue("@ShiftPk", int.Parse(dt.Rows[0][1].ToString()));

                                       cmd2.ExecuteNonQuery();


                                   }
                                   # endregion

                               }
                                   
                               else
                               {
                                   #region if present update

                                   //    if present update

                                   using (SqlCommand cmd2 = new SqlCommand(" UPDATE    EmployeSwipeDaily_tbl "+
               "    SET              Swipin = @SwipeinTime, InStatus = @instatus, Invalue = @Invalue "+
            "       WHERE     (Date = @datetoday) AND (empid = @empid)", sqlConnection1))
                                   {

                                       cmd2.Parameters.AddWithValue("@empid", int.Parse(dt.Rows[0][0].ToString()));
                                       cmd2.Parameters.AddWithValue("@datetoday", DateTime.Parse(dt.Rows[0][2].ToString()));
                                       cmd2.Parameters.AddWithValue("@instatus", "LH");
                                       cmd2.Parameters.AddWithValue("@Invalue", 0);
                                       cmd2.Parameters.AddWithValue("@SwipeinTime", DateTime.Parse(dt.Rows[0][5].ToString()));
                                       

                                       cmd2.ExecuteNonQuery();


                                   }

                               }

                                   #endregion


                           }


















                       }

                      



                       SqlCommand cmd3= new SqlCommand("UPDATE    CorrectionDaily_tbl SET  IsApproved = N'A' WHERE     (CorrectionPk = @Param1)", sqlConnection1);
                      // cmd2.Transaction = sqltrnsctn;
                       cmd3.Parameters.AddWithValue("@Param1", correctionId);


                       cmd3.ExecuteNonQuery();











                   }
               
               
               
               
               
               

               sqlConnection1.Close();

           }

       }













# endregion
       ////////////////////////////////////////////////////////////////////Gate Pass////////////////////////////////////////////////////////////////////////////////

       # region Gatepass
       /// <summary>
        /// get all the gatepasses Applied
        /// </summary>
        /// <param name="Branchlctnpk"></param>
        /// <param name="levelnum"></param>
        /// <returns></returns>
       public DataTable getAllGatepassApplication(int Branchlctnpk, int levelnum)
       {
           DataTable dt = new DataTable(); ;
           using (SqlConnection con = new SqlConnection(Program.ConnStr))
           {
               con.Open();

               SqlCommand cmd = new SqlCommand("GetgatepassforApproval_SP ", con);

               cmd.Parameters.AddWithValue("@levelnum", levelnum);
               cmd.Parameters.AddWithValue("@BranchlctnPK", Branchlctnpk);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader reader = cmd.ExecuteReader();

               dt.Load(reader);
               con.Close();
           }
           return dt;
       }





/// <summary>
/// REJECT THE GATEPASS aPPLICATION
/// </summary>
/// <param name="GATEPASSID"></param>
/// <param name="actionlevel"></param>
       public void rejectGatepass(int GATEPASSID , int actionlevel)
       {


          
           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();
               if (actionlevel == 1)
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    GatePassMaster_tbl SET      IsCompleted= N'R'  ,        IsLevel1 = N'R' WHERE     (GatePassId = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }
               else
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    GatePassMaster_tbl SET      IsCompleted= N'R'   ,       IsLevel1 = N'R' WHERE     (GatePassId = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }
              

               sqlConnection1.Close();
           }
       }



/// <summary>
/// approves the gatepass application
/// 
/// </summary>
/// <param name="GATEPASSID"></param>
/// <param name="actionlevel"></param>
       public void approvetheGatepassapplication(int GATEPASSID, int actionlevel)
       {



           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();
               if (actionlevel == 1)
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    GatePassMaster_tbl SET              IsLevel1 = N'A' WHERE     (GatePassId = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }
               else
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    GatePassMaster_tbl SET    IsCompleted= N'Y'   ,      IsLevel2 = N'A' WHERE     (GatePassId = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }


               sqlConnection1.Close();
           }
       }


# endregion

        /////////////////////////////////////////////////////////////////Deactivation //////////////////////////////////////////////////////////////////////////////////////////



        # region Employee Deactivation 


       public DataTable getDeactivationdataforApproval(int BranclctnPk, int actionlevel)
       {

      
       
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
              
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                if (actionlevel == 1)
                {
                    cmd.CommandText = "SELECT     EmployeDeactivationMaster_tbl.DeactivationPK, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, "+
    "                  EmployeDeactivationMaster_tbl.Dateadded, DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, EmpContract_tbl.ActualJoiningDate, " +
    "                   EmployeDeactivationMaster_tbl.Remark, EmployeDeactivationMaster_tbl.IsLevel1, EmployeDeactivationMaster_tbl.Islevel2,  " +
  "                    EmployeDeactivationMaster_tbl.Islevel3 ,EmployeDeactivationMaster_tbl.IsBlackListed" +
" FROM         DesignationMaster_tbl INNER JOIN "+
                    " EmployeDeactivationMaster_tbl INNER JOIN "+
                "      EmployeePersonalMaster_tbl ON EmployeDeactivationMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
               "       EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON "+
              "        DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN "+
             "         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN "+
            "          EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId "+
" WHERE     (EmployeDeactivationMaster_tbl.IsCompleted = N'N') AND (EmployeDeactivationMaster_tbl.HideDisplay = N'N') AND (EmployeDeactivationMaster_tbl.IsLevel1 = N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1)";
                }
                else if (actionlevel == 2)
                {
                    cmd.CommandText = "SELECT     EmployeDeactivationMaster_tbl.DeactivationPK, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, "+
              "        EmployeDeactivationMaster_tbl.Dateadded, DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, EmpContract_tbl.ActualJoiningDate, "+
               "       EmployeDeactivationMaster_tbl.Remark, EmployeDeactivationMaster_tbl.IsLevel1, EmployeDeactivationMaster_tbl.Islevel2, "+
                "      EmployeDeactivationMaster_tbl.Islevel3 , EmployeDeactivationMaster_tbl.IsBlackListed " +
" FROM         DesignationMaster_tbl INNER JOIN "+
  "                    EmployeDeactivationMaster_tbl INNER JOIN "+
   "                   EmployeePersonalMaster_tbl ON EmployeDeactivationMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
    "                  EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON "+
     "                 DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN "+
      "                DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN "+
       "               EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId "+
" WHERE     (EmployeDeactivationMaster_tbl.IsCompleted = N'N') AND (EmployeDeactivationMaster_tbl.HideDisplay = N'N') AND (EmployeDeactivationMaster_tbl.IsLevel1 = N'A') "+
              "        AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeDeactivationMaster_tbl.Islevel2 = N'N')";
                }
                else if (actionlevel == 3)
                {
                    cmd.CommandText = "SELECT     EmployeDeactivationMaster_tbl.DeactivationPK, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, "+
                  "    EmployeDeactivationMaster_tbl.Dateadded, DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, EmpContract_tbl.ActualJoiningDate, "+
                   "   EmployeDeactivationMaster_tbl.Remark, EmployeDeactivationMaster_tbl.IsLevel1, EmployeDeactivationMaster_tbl.Islevel2, "+
                    "  EmployeDeactivationMaster_tbl.Islevel3 ,EmployeDeactivationMaster_tbl.IsBlackListed " +
 " FROM         DesignationMaster_tbl INNER JOIN "+
 "                     EmployeDeactivationMaster_tbl INNER JOIN "+
"                      EmployeePersonalMaster_tbl ON EmployeDeactivationMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
   "                   EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON "+
    "                  DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN " +
     "                 DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN " +
      "                EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId "+
" WHERE     (EmployeDeactivationMaster_tbl.IsCompleted = N'N') AND (EmployeDeactivationMaster_tbl.HideDisplay = N'N') AND (EmployeDeactivationMaster_tbl.IsLevel1 = N'A') "+
         "             AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeDeactivationMaster_tbl.Islevel2 = N'A') AND "+
             "         (EmployeDeactivationMaster_tbl.Islevel3 = N'N')";
                }
                cmd.Parameters.AddWithValue("Param1", BranclctnPk);
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
       ///Designation Change approval at level 1
       /// </summary>
       /// <param name="advappdatabean"></param>
       public void DeactApproveAction(int DeactivationApp, int levelnum, String Action)
       {

           SqlTransaction sqltrnsctn;
           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();

               sqltrnsctn = sqlConnection1.BeginTransaction();

               try
               {
                   if (levelnum == 1)
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE  EmployeDeactivationMaster_tbl SET  IsLevel1 = @Param2, Level1userpk = @Param3, Level1Date =  getdate() WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;
                           command.Parameters.AddWithValue("@Param2", Action);
                           command.Parameters.AddWithValue("@Param3", Program.USERPK);

                           command.Parameters.AddWithValue("@Param1", DeactivationApp);
                           command.ExecuteNonQuery();
                       }
                   }
                   else if (levelnum == 2)
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE    EmployeDeactivationMaster_tbl SET  IsLevel2 = @Param2, Level2userpk = @Param3, Level2Date = getdate() WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;
                           command.Parameters.AddWithValue("@Param2", Action);
                           command.Parameters.AddWithValue("@Param3", Program.USERPK);

                           command.Parameters.AddWithValue("@Param1", DeactivationApp);

                           command.ExecuteNonQuery();
                       }

                   }
                   else if (levelnum == 3)
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE    EmployeDeactivationMaster_tbl SET IsCompleted=N'Y',  IsLevel3 = @Param2, Level3userpk = @Param3, Level3Date = getdate()  WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;
                           command.Parameters.AddWithValue("@Param2", Action);
                           command.Parameters.AddWithValue("@Param3", Program.USERPK);
                          // command.Parameters.AddWithValue("@Param4", Program.USERPK);
                           command.Parameters.AddWithValue("@Param1", DeactivationApp);
                          

                           command.ExecuteNonQuery();
                       }



                       using (SqlCommand command1 = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl "+
" SET              Status = N'D' "+
" WHERE     (empid = (SELECT     empid FROM         EmployeDeactivationMaster_tbl WHERE     (DeactivationPK = @Param1)))", sqlConnection1))
                       {
                           command1.Transaction = sqltrnsctn;
                           command1.Parameters.AddWithValue("@Param1", DeactivationApp);


                            command1.ExecuteNonQuery();




                       }



                     



                   }

                   if (Action == "R")
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE    EmployeDeactivationMaster_tbl SET IsCompleted=N'Y'  WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;

                           command.Parameters.AddWithValue("@Param1", DeactivationApp);


                           command.ExecuteNonQuery();
                       }
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

       /// <summary>
       ///Designation Change approval at level 1
       /// </summary>
       /// <param name="advappdatabean"></param>
       public void DeactApproveandBlacklistAction(int DeactivationApp, int levelnum, String Action)
       {

           SqlTransaction sqltrnsctn;
           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();

               sqltrnsctn = sqlConnection1.BeginTransaction();

               try
               {
                   if (levelnum == 1)
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE  EmployeDeactivationMaster_tbl SET  IsLevel1 = @Param2, Level1userpk = @Param3, Level1Date =  getdate() WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;
                           command.Parameters.AddWithValue("@Param2", Action);
                           command.Parameters.AddWithValue("@Param3", Program.USERPK);

                           command.Parameters.AddWithValue("@Param1", DeactivationApp);
                           command.ExecuteNonQuery();
                       }
                   }
                   else if (levelnum == 2)
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE    EmployeDeactivationMaster_tbl SET  IsLevel2 = @Param2, Level2userpk = @Param3, Level2Date = getdate() WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;
                           command.Parameters.AddWithValue("@Param2", Action);
                           command.Parameters.AddWithValue("@Param3", Program.USERPK);

                           command.Parameters.AddWithValue("@Param1", DeactivationApp);

                           command.ExecuteNonQuery();
                       }

                   }
                   else if (levelnum == 3)
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE    EmployeDeactivationMaster_tbl SET IsCompleted=N'Y',  IsLevel3 = @Param2, Level3userpk = @Param3, Level3Date = getdate()  WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;
                           command.Parameters.AddWithValue("@Param2", Action);
                           command.Parameters.AddWithValue("@Param3", Program.USERPK);
                           // command.Parameters.AddWithValue("@Param4", Program.USERPK);
                           command.Parameters.AddWithValue("@Param1", DeactivationApp);


                           command.ExecuteNonQuery();
                       }



                       using (SqlCommand command1 = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl " +
" SET              Status = N'D' , IsBlackListed = 'Y' " +
" WHERE     (empid = (SELECT     empid FROM         EmployeDeactivationMaster_tbl WHERE     (DeactivationPK = @Param1)))", sqlConnection1))
                       {
                           command1.Transaction = sqltrnsctn;
                           command1.Parameters.AddWithValue("@Param1", DeactivationApp);


                           command1.ExecuteNonQuery();




                       }







                   }

                   if (Action == "R")
                   {
                       using (SqlCommand command = new SqlCommand("UPDATE    EmployeDeactivationMaster_tbl SET IsCompleted=N'Y'  WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                       {
                           command.Transaction = sqltrnsctn;

                           command.Parameters.AddWithValue("@Param1", DeactivationApp);


                           command.ExecuteNonQuery();
                       }
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



        #  endregion 


        ////////////////////////////////////////////////////////////////////Waring////////////////////////////////////////////////////////////////////////////////////////

        #region EmployeeWarning


       /// <summary>
       /// get all the employee appreciation and Warning
       /// </summary>
       /// <param name="Branchlctnpk"></param>
       /// <param name="levelnum"></param>
       /// <returns></returns>
       public DataTable getAllEmployeeAppreciation(int Branchlctnpk, int levelnum,String selection )
       {
           DataTable dt = new DataTable(); ;
           using (SqlConnection con = new SqlConnection(Program.ConnStr))
           {
               con.Open();
          
               SqlCommand cmd = new SqlCommand("AppreciationAndWarning_sp ", con);

               cmd.Parameters.AddWithValue("@ActionNum", levelnum);
               cmd.Parameters.AddWithValue("@BranchLocationPK", Branchlctnpk);
               cmd.Parameters.AddWithValue("@SelectionType", selection);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader reader = cmd.ExecuteReader();

               dt.Load(reader);
               con.Close();
           }
           return dt;
       }

















       /// <summary>
       /// approves the warning application
       /// 
       /// </summary>
       /// <param name="GATEPASSID"></param>
       /// <param name="actionlevel"></param>
       public void updateandApproveWarning(int warningpk, int actionlevel)
       {



           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();
               if (actionlevel == 1)
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    WarningEmployee_tbl SET              IsLevel1 = N'A' , Level1Date = GETDATE() WHERE     (WarningPK = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", warningpk);
                   cmd.ExecuteNonQuery();
               }
               else
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    WarningEmployee_tbl SET              IsLevel2 = N'A' , Level2Date = GETDATE() WHERE     (WarningPK = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", warningpk);
                   cmd.ExecuteNonQuery();
               }


               sqlConnection1.Close();
           }
       }


       /// <summary>
       /// approves the warning application
       /// 
       /// </summary>
       /// <param name="GATEPASSID"></param>
       /// <param name="actionlevel"></param>
       public void updateAppreciation(int warningpk, int actionlevel)
       {



           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();
               if (actionlevel == 1)
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    AppreciationMaster_tbl SET              Islevel1 = N'A', Islevel1Date = GETDATE() WHERE     (ApprecationId = @Param2)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", warningpk);
                   cmd.ExecuteNonQuery();
               }
               else
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    AppreciationMaster_tbl SET              Islevel2 = N'A', Islevel2Date = GETDATE() WHERE     (ApprecationId = @Param2)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", warningpk);
                   cmd.ExecuteNonQuery();
               }


               sqlConnection1.Close();
           }
       }



       /// <summary>
       /// REJECT THE GATEPASS aPPLICATION
       /// </summary>
       /// <param name="GATEPASSID"></param>
       /// <param name="actionlevel"></param>
       public void rejectWarning(int GATEPASSID, int actionlevel)
       {



           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();
               if (actionlevel == 1)
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    WarningEmployee_tbl SET    IsLevel1 = N'R' WHERE     (WarningPK = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }
               else
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    WarningEmployee_tbl SET     IsLevel1 = N'R' WHERE     (WarningPK = @Param1)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }


               sqlConnection1.Close();
           }
       }
       /// <summary>
       /// REJECT THE GATEPASS aPPLICATION
       /// </summary>
       /// <param name="GATEPASSID"></param>
       /// <param name="actionlevel"></param>
       public void rejectAppraisal(int GATEPASSID, int actionlevel)
       {



           using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
           {

               sqlConnection1.Open();
               if (actionlevel == 1)
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    AppreciationMaster_tbl SET              Islevel1 = N'R', Islevel1Date = GETDATE() WHERE     (ApprecationId = @Param2)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }
               else
               {
                   SqlCommand cmd = new SqlCommand("UPDATE    AppreciationMaster_tbl SET              Islevel1 = N'R', Islevel1Date = GETDATE() WHERE     (ApprecationId = @Param2)", sqlConnection1);
                   cmd.Parameters.AddWithValue("@Param1", GATEPASSID);
                   cmd.ExecuteNonQuery();
               }


               sqlConnection1.Close();
           }
       }

        # endregion


        #region MultiEmployeeRenewalApproval

       /// <summary>
       /// get all the employee appreciation and Warning
       /// </summary>
       /// <param name="Branchlctnpk"></param>
       /// <param name="levelnum"></param>
       /// <returns></returns>
       public DataTable getAllEmployeeRenewalApplications(int Branchlctnpk, int levelnum)
       {
           DataTable dt = new DataTable(); ;
           using (SqlConnection con = new SqlConnection(Program.ConnStr))
           {
               con.Open();

               SqlCommand cmd = new SqlCommand("GetContractrenewaldata_sp ", con);

               cmd.Parameters.AddWithValue("@approvalevel", levelnum);
               cmd.Parameters.AddWithValue("@bracnlctnpk", Branchlctnpk);
              
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader reader = cmd.ExecuteReader();

               dt.Load(reader);
               con.Close();
           }
           return dt;
       }

        #endregion

    }



}

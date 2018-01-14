using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace ATCHRM.Transactions
{
  public   class RejectActionTransaction
    {



      public void rejectApplication(int appid, int approvalid, String ApprovalType, int approvallevel)
      {

          if (ApprovalType == "Recruitment Rejection")
          {
              # region recruitment

              if (approvallevel == 1)
              {

                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE  RecruitmentApplicationMaster_tbl SET   iscompleted = 'R' WHERE     (RecruitmentAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }
              else if (approvallevel == 2)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE  RecruitmentApplicationMaster_tbl SET   iscompleted = 'R' WHERE     (RecruitmentAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }
                      using (SqlCommand command = new SqlCommand("UPDATE    RecruitmentApprovalMaster_tbl SET              Islevel2 = N'R' WHERE     (RecruitmentPK = @Param2)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param2", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }

              else if (approvallevel == 3)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE  RecruitmentApplicationMaster_tbl SET   iscompleted = 'R' WHERE     (RecruitmentAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }
                      using (SqlCommand command = new SqlCommand("UPDATE    RecruitmentApprovalMaster_tbl SET              Islevel3 = N'R' WHERE     (RecruitmentPK = @Param2)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param2", appid);


                          command.ExecuteNonQuery();

                      }
                      sqlConnection1.Close();

                  }
              }
# endregion
          }
          else if (ApprovalType == "Leave Rejection")
          {

              #region LeaveRejection
              if (approvallevel == 1)
              {

                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    LeaveApprovalMaster_tbl SET              Islevel1 = N'R' , IsCompleted =  N'R' WHERE     (LeaveAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }
              else if (approvallevel == 2)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    LeaveApprovalMaster_tbl SET              Islevel2 = N'R'   and  IsCompleted = N'R'  WHERE     (LeaveAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }

              else if (approvallevel == 3)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    LeaveApprovalMaster_tbl SET              Islevel3 = N'R' and IsCompleted = N'R'  WHERE     (LeaveAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                  }

              }
              # endregion
          }
          else if (ApprovalType == "Advance Rejection")
          {
              # region Advance rejection



              if (approvallevel == 1)
              {

                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApprovalMaster_tbl SET              IsLevel1 = N'R' WHERE     (AdvanceAppPk = @Param2)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param2", appid);


                          command.ExecuteNonQuery();

                      }


                      using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApplicationMaster_tbl SET   Iscompleted = N'R' WHERE     (AdvanceAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }







                      sqlConnection1.Close();
                  }
              }
              else if (approvallevel == 2)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApprovalMaster_tbl SET              IsLevel2 = N'R' WHERE     (AdvanceAppPk = @Param2)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param2", appid);


                          command.ExecuteNonQuery();

                      }
                      using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApplicationMaster_tbl SET   Iscompleted = N'R' WHERE     (AdvanceAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }

              else if (approvallevel == 3)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApprovalMaster_tbl SET              IsLevel3 = N'R' WHERE     (AdvanceAppPk = @Param2)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param2", appid);


                          command.ExecuteNonQuery();

                      }
                      using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApplicationMaster_tbl SET   Iscompleted = N'R' WHERE     (AdvanceAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }
                      sqlConnection1.Close();

                  }
              }

              # endregion
          }
          else if (ApprovalType == "Designation Change Rejection")
          {
              #region Designationchange

              if (approvallevel == 1)
              {

                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    DesignationApprovalMaster_tbl SET              Iscompleted = N'R', IsLevel1 = N'R' WHERE     (DsgAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }
              else if (approvallevel == 2)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    DesignationApprovalMaster_tbl SET              Iscompleted = N'R', IsLevel2 = N'R' WHERE     (DsgAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }

              else if (approvallevel == 3)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    DesignationApprovalMaster_tbl SET              Iscompleted = N'R', IsLevel3 = N'R' WHERE     (DsgAppPk = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                  }

              }


              # endregion 

              
          }

          else if (ApprovalType == "OT Rejection")
          {
              #region Overtime Rejection

              if (approvallevel == 1)
              {

                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    OTApproval_tbl SET              IsLevel1 = N'R', Iscompleted = 'R' WHERE     (OTAppPK = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }
              else if (approvallevel == 2)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    OTApproval_tbl SET              IsLevel2 = N'R', Iscompleted = 'R' WHERE     (OTAppPK = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }

              else if (approvallevel == 3)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    ShiftChangeApplication_tbl SET  Islevel3 = N'R', Iscompleted = N'R' WHERE     (ShftAppPK = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                  }

              }


              # endregion


          }
        
          else if (ApprovalType == "Shift Change Rejection")
          {
              #region ShiftChange Rejection

              if (approvallevel == 1)
              {

                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    ShiftChangeApplication_tbl SET  Islevel1 = N'R', Iscompleted = N'R' WHERE     (ShftAppPK = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }
              else if (approvallevel == 2)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    ShiftChangeApplication_tbl SET  Islevel2 = N'R', Iscompleted = N'R' WHERE     (ShftAppPK = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }

              else if (approvallevel == 3)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    ShiftChangeApplication_tbl SET  Islevel3 = N'R', Iscompleted = N'R' WHERE     (ShftAppPK = @Param1)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param1", appid);


                          command.ExecuteNonQuery();

                      }

                  }

              }


              # endregion


          }

          else if (ApprovalType == "Contract Renewal Rejection")
          {
              #region Contract Renewal  Rejection

              if (approvallevel == 1)
              {

                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    ContractRenewalApplication_tbl SET  Islevel1 = N'R', Iscompleted = N'R' WHERE     (ContractAppPk = @Param3)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param3", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }
              else if (approvallevel == 2)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    ContractRenewalApplication_tbl SET  Islevel2 = N'R', Iscompleted = N'R' WHERE     (ContractAppPk = @Param3)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param3", appid);


                          command.ExecuteNonQuery();

                      }

                      sqlConnection1.Close();
                  }
              }

              else if (approvallevel == 3)
              {
                  using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                  {
                      sqlConnection1.Open();
                      using (SqlCommand command = new SqlCommand("UPDATE    ContractRenewalApplication_tbl SET  Islevel3 = N'R', Iscompleted = N'R' WHERE     (ContractAppPk = @Param3)", sqlConnection1))
                      {

                          command.Parameters.AddWithValue("@Param3", appid);


                          command.ExecuteNonQuery();

                      }

                  }

              }


              # endregion


          }

          else if (ApprovalType == "Leave Encashment")
          {
              # region Leave Encashment



              SqlTransaction sqltrnsctn;
              using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
              {

                  sqlConnection1.Open();

                  sqltrnsctn = sqlConnection1.BeginTransaction();

                  try
                  {
                      if (approvallevel == 1)
                      {
                          using (SqlCommand command = new SqlCommand("UPDATE    LeaveEnchasementMaster_tbl " +
  " SET              Islevel1 = @Param1, IsLevel1Date = getdate(), LevelUserPK1 = @Param3" +
  " WHERE     (LeaveEncashPk = @Param7)", sqlConnection1))
                          {
                              command.Transaction = sqltrnsctn;
                              command.Parameters.AddWithValue("@Param1", "R");

                              command.Parameters.AddWithValue("@Param3", Program.USERPK);

                              command.Parameters.AddWithValue("@Param7", appid);

                              command.ExecuteNonQuery();
                          }
                      }
                      else if (approvallevel == 2)
                      {
                          using (SqlCommand command = new SqlCommand("UPDATE    LeaveEnchasementMaster_tbl " +
  " SET              Islevel2 = @Param1, IsLevel2Date = getdate(), LevelUserPK2 = @Param3" +
  " WHERE     (LeaveEncashPk = @Param7)", sqlConnection1))
                          {
                              command.Transaction = sqltrnsctn;
                              command.Parameters.AddWithValue("@Param1", "R");

                              command.Parameters.AddWithValue("@Param3", Program.USERPK);

                              command.Parameters.AddWithValue("@Param7", appid);

                              command.ExecuteNonQuery();
                          }

                      }
                      else if (approvallevel == 3)
                      {
                          using (SqlCommand command = new SqlCommand("UPDATE    LeaveEnchasementMaster_tbl " +
  " SET              Islevel3 = @Param1, IsLevel3Date = getdate(), LevelUserPK3 = @Param3 , IsCompleted = N'R'" +
  " WHERE     (LeaveEncashPk = @Param7)", sqlConnection1))
                          {
                              command.Transaction = sqltrnsctn;
                              command.Parameters.AddWithValue("@Param1", "R");

                              command.Parameters.AddWithValue("@Param3", Program.USERPK);

                              command.Parameters.AddWithValue("@Param7", appid);

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





              # endregion

          }
      
      }




      public void rejectApprovalAction(String ApprovalType, int idvalue, int levelnumber)
      {
          if (ApprovalType == "Action")
          {
              using (SqlConnection con = new SqlConnection(Program.ConnStr))
              {
                  con.Open();
                  String Query = "";






                  if (levelnumber == 1)
                  {


                      Query = "UPDATE    AttendanceActionDetails_tbl " +
  " SET              IsLevel1 = N'R'" +
  "  WHERE     (ActionId = @Param1)";

                  }
                  else if (levelnumber == 2)
                  {
                      Query = "UPDATE    AttendanceActionDetails_tbl " +
  " SET              IsLevel2 = N'R'" +
  "  WHERE     (ActionId = @Param1)";

                  }
                  else if (levelnumber == 3)
                  {
                      Query = "UPDATE    AttendanceActionDetails_tbl " +
  " SET              IsLevel3 = N'R'" +
  "  WHERE     (ActionId = @Param1)";
                  }


                  SqlCommand cmd1 = new SqlCommand("UPDATE    AttendanceActionMaster_tbl SET              ActStatus = N'Rejected' " +
  " WHERE     (ActionId = @Param1) ", con);

                  SqlCommand cmd = new SqlCommand(Query, con);
                  cmd.Parameters.AddWithValue("@Param1", idvalue);
                  cmd1.Parameters.AddWithValue("@Param1", idvalue);

                  cmd.ExecuteNonQuery();
                  cmd1.ExecuteNonQuery();
              }


          }


      }

















    }
}

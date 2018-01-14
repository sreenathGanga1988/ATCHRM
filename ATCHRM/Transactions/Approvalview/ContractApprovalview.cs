using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace ATCHRM.Transactions.Approvalview
{
    class ContractApprovalview
    {

        public DataTable getallappplication(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
                    cmd.CommandText= "SELECT     ContractRenewalApplication_tbl.ContractAppnum, ContractRenewalApplication_tbl.ContractAppPk, ContractRenewalApplication_tbl.AppliedDate, "+
                  "    EmployeePersonalMaster_tbl.empno, ContractRenewalApplication_tbl.Fromdate, ContractRenewalApplication_tbl.Todate, ContractRenewalApplication_tbl.Islevel1, "+
                  "    ContractRenewalApplication_tbl.Islevel2, ContractRenewalApplication_tbl.ContractType "+
" FROM         ContractRenewalApplication_tbl INNER JOIN "+
                "    EmployeePersonalMaster_tbl ON ContractRenewalApplication_tbl.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
           "           EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid "+
" WHERE     (ContractRenewalApplication_tbl.Iscompleted = N'N') AND (ContractRenewalApplication_tbl.Islevel3 <> N'A') AND  " +
              "        (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ";
                }
                else
                {
                    cmd.CommandText = "SELECT     ContractRenewalApplication_tbl.ContractAppnum, ContractRenewalApplication_tbl.ContractAppPk, ContractRenewalApplication_tbl.AppliedDate, " +
                     "  EmployeePersonalMaster_tbl.empno, ContractRenewalApplication_tbl.Fromdate, ContractRenewalApplication_tbl.Todate, ContractRenewalApplication_tbl.Islevel1, " +
                    " ContractRenewalApplication_tbl.Islevel2, ContractRenewalApplication_tbl.ContractType, ContractRenewalApplication_tbl.Islevel3 " +
" FROM         ContractRenewalApplication_tbl INNER JOIN " +
 "                    EmployeePersonalMaster_tbl ON ContractRenewalApplication_tbl.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
  "                   EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
" WHERE     (ContractRenewalApplication_tbl.Iscompleted = N'Y') AND  " +
 "                    (EmployeeDesignation_tbl.BranchLocationPK = @Param1)AND (ContractRenewalApplication_tbl.hide_display <> N'Y')";
                }


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
        /// remove fromlist
        /// </summary>
        /// <param name="appid"></param>
        public void removefromlist(int appid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("UPDATE    ContractRenewalApplication_tbl SET              hide_display = N'Y' WHERE     (ContractAppPk = @Param1)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", appid);


                    command.ExecuteNonQuery();

                }

                sqlConnection1.Close();
            }

        }





        }




    class PayrollApproval
    {

        /// <summary>
        /// get all the payroll for approval
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
           public DataTable getallPayrollforApproval(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
//                    cmd.CommandText= "SELECT     Payroll_PayMaster.Pay_Id, BranchLocartionMaster_tbl.BranchlLocationPk, BranchLocartionMaster_tbl.BranchLocationName, DepartmentMaster_tbl.DepartmentName,"+
//                    "   Payroll_PayMaster.Pay_Start_Date, Payroll_PayMaster.Pay_End_Date, COUNT(Payroll_PayDetails.Emp_Id) AS Expr1, Payroll_PayDetails.Total_Salary, "+
//                   "   Payroll_PayMaster.IsCompleted "+
//" FROM         Payroll_PayMaster INNER JOIN "+
//           "           Payroll_PayDetails ON Payroll_PayMaster.Pay_Id = Payroll_PayDetails.Pay_Id INNER JOIN "+
//                 "     BranchLocartionMaster_tbl ON Payroll_PayMaster.Pay_Loc = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN "+
//              "        DepartmentMaster_tbl ON Payroll_PayMaster.Department_id = DepartmentMaster_tbl.DepartmentPK "+
//" GROUP BY Payroll_PayMaster.Pay_Id, BranchLocartionMaster_tbl.BranchlLocationPk, BranchLocartionMaster_tbl.BranchLocationName, "+
//               "       DepartmentMaster_tbl.DepartmentName, Payroll_PayMaster.Pay_Start_Date, Payroll_PayMaster.Pay_End_Date, Payroll_PayDetails.Total_Salary, "+
//                  "    Payroll_PayMaster.IsCompleted "+
//" HAVING       (Payroll_PayMaster.IsCompleted = N'N')";





                    cmd.CommandText = "SELECT     Payroll_PayMaster.Pay_Id, BranchLocartionMaster_tbl.BranchlLocationPk, BranchLocartionMaster_tbl.BranchLocationName,DepartmentMaster_tbl.DepartmentName,  " +
         "            Payroll_PayMaster.Pay_Start_Date, Payroll_PayMaster.Pay_End_Date, Payroll_PayMaster.Emp_Count, Payroll_PayMaster.IsCompleted, " +
          "          DepartmentMaster_tbl.DepartmentPK " +
"FROM         Payroll_PayMaster INNER JOIN " +
"                     DepartmentMaster_tbl ON Payroll_PayMaster.Department_id = DepartmentMaster_tbl.DepartmentPK INNER JOIN " +
"                    BranchLocartionMaster_tbl ON Payroll_PayMaster.Pay_Loc = BranchLocartionMaster_tbl.BranchlLocationPk " +
" WHERE     (Payroll_PayMaster.IsCompleted = N'N')";










                }
                else
                {
                
                }


             //   cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK);
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
           /// revert a payroll
           /// </summary>
           /// <param name="payid"></param>
           public void revertpayroll(int payid)
           {
               using (SqlConnection con = new SqlConnection(Program.ConnStr))
               {
                   con.Open();
                   SqlCommand cmd = new SqlCommand("RevertPayroll_sp", con);
                   cmd.Parameters.AddWithValue("@payid", payid);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.ExecuteNonQuery();
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
               }

           }






    }



    class GatePassApprovalView
    {


        public DataTable GetAllGatepass(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
                    cmd.CommandText = "SELECT     GatePassMaster_tbl.GatePassId, GatePassMaster_tbl.GatePassnum, GatePassMaster_tbl.GatepassDate, EmployeePersonalMaster_tbl.empno, "+
                    "  GatePassMaster_tbl.fromtime, GatePassMaster_tbl.totime, "+
         "                 (SELECT     DATEDIFF(minute, GatePassMaster_tbl.fromtime, GatePassMaster_tbl.totime) AS Expr1) AS myMinutes, GatePassMaster_tbl.IsLevel1 "+
" FROM         GatePassMaster_tbl INNER JOIN "+
         "             EmployeePersonalMaster_tbl ON GatePassMaster_tbl.empid = EmployeePersonalMaster_tbl.empid "+
"WHERE   (GatePassMaster_tbl.IsLevel1 = N'N')and (GatePassMaster_tbl.IsCompleted = N'N') AND (GatePassMaster_tbl.IsLevel2 = N'N') AND (GatePassMaster_tbl.BranchLctnPK = @Param1) ";
                }
                else
                {
                     
                    cmd.CommandText = "SELECT     GatePassMaster_tbl.GatePassId, GatePassMaster_tbl.GatePassnum, GatePassMaster_tbl.GatepassDate, EmployeePersonalMaster_tbl.empno, "+
                "      GatePassMaster_tbl.fromtime, GatePassMaster_tbl.totime,"+
                 "         (SELECT     DATEDIFF(minute, GatePassMaster_tbl.fromtime, GatePassMaster_tbl.totime) AS Expr1) AS myMinutes, GatePassMaster_tbl.IsLevel1 ,GatePassMaster_tbl.IsLevel2, " +
                   "   GatePassMaster_tbl.BranchLctnPK, GatePassMaster_tbl.hide_display "+
" FROM         GatePassMaster_tbl INNER JOIN "+
     "                 EmployeePersonalMaster_tbl ON GatePassMaster_tbl.empid = EmployeePersonalMaster_tbl.empid "+
" WHERE      (GatePassMaster_tbl.BranchLctnPK = @Param1) AND(GatePassMaster_tbl.IsCompleted <> N'N')AND (GatePassMaster_tbl.hide_display = N'N')";
            
                }


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
        /// remove fromlist
        /// </summary>
        /// <param name="appid"></param>
        public void removefromlist(int appid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("UPDATE    GatePassMaster_tbl  SET   hide_display = N'Y'WHERE GatePassId = @Param1", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", appid);


                    command.ExecuteNonQuery();

                }

                sqlConnection1.Close();
            }

        }


    }


    class DesignChangeView
    {
        public DataTable getAllDesgChangeApp(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 1)
                {
                    cmd.CommandText = "SELECT     DesignationChangeApplication_tbl.DesgAppPk, DesignationChangeApplication_tbl.Appnum, DesignationChangeApplication_tbl.DateAdded, "+
                  "    EmployeePersonalMaster_tbl.empno, DesignationMaster_tbl.DesignationName, DesignationMaster_tbl_1.DesignationName AS Expr1, "+
                   "   DesignationApprovalMaster_tbl.IsLevel1, DesignationApprovalMaster_tbl.Islevel2, DesignationApprovalMaster_tbl.Iscompleted,  "+
             "        DesignationApprovalMaster_tbl.Islevel3, DesignationChangeApplication_tbl.Hide_Display " +
" FROM         DesignationChangeApplication_tbl INNER JOIN " +
           "           DesignationApprovalMaster_tbl ON DesignationChangeApplication_tbl.DesgAppPk = DesignationApprovalMaster_tbl.DsgAppPk INNER JOIN "+
            "          EmployeePersonalMaster_tbl ON DesignationChangeApplication_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
             "         EmployeeDesignation_tbl ON DesignationChangeApplication_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN "+
              "        DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN "+
               "       DesignationMaster_tbl AS DesignationMaster_tbl_1 ON DesignationChangeApplication_tbl.DesgnPK = DesignationMaster_tbl_1.DesgnationPK "+
" WHERE     (DesignationApprovalMaster_tbl.Iscompleted <> N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1)  "+
                    "   AND (DesignationChangeApplication_tbl.Hide_Display = N'N') ";
                }
                else
                {

                    cmd.CommandText = "SELECT     DesignationChangeApplication_tbl.DesgAppPk, DesignationChangeApplication_tbl.Appnum, DesignationChangeApplication_tbl.DateAdded, "+
                   "   EmployeePersonalMaster_tbl.empno, DesignationMaster_tbl.DesignationName, DesignationMaster_tbl_1.DesignationName AS Expr1, "+
                 "     DesignationApprovalMaster_tbl.IsLevel1, DesignationApprovalMaster_tbl.Islevel2, DesignationApprovalMaster_tbl.Iscompleted, "+
                "      DesignationApprovalMaster_tbl.Islevel3 "+
" FROM         DesignationChangeApplication_tbl INNER JOIN "+
                "      DesignationApprovalMaster_tbl ON DesignationChangeApplication_tbl.DesgAppPk = DesignationApprovalMaster_tbl.DsgAppPk INNER JOIN "+
                 "     EmployeePersonalMaster_tbl ON DesignationChangeApplication_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
                 "     EmployeeDesignation_tbl ON DesignationChangeApplication_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN "+
                 "     DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN "+
                "      DesignationMaster_tbl AS DesignationMaster_tbl_1 ON DesignationChangeApplication_tbl.DesgnPK = DesignationMaster_tbl_1.DesgnationPK "+
" WHERE     (DesignationApprovalMaster_tbl.Iscompleted = N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ";

                }


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
        /// remove fromlist
        /// </summary>
        /// <param name="appid"></param>
        public void removefromlist(int appid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("UPDATE    DesignationChangeApplication_tbl SET              Hide_Display = N'Y' WHERE     (DesgAppPk = @Param1)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", appid);


                    command.ExecuteNonQuery();

                }

                sqlConnection1.Close();
            }

        }


    }


    class AdvanceApplication
    {




        public DataTable GetAllAdvance(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
                    cmd.CommandText = " SELECT     AdvanceApplicationMaster_tbl.AdvanceAppPk, AdvanceApplicationMaster_tbl.AddvanceAppnum, EmployeePersonalMaster_tbl.empno, "+
   "                   AdvanceApplicationMaster_tbl.DateAdded, AdvanceApplicationMaster_tbl.Amount, AdvanceApplicationMaster_tbl.Reason, AdvanceApplicationMaster_tbl.Iscompleted,  "+
  "                    AdvanceApprovalMaster_tbl.IsLevel1, AdvanceApprovalMaster_tbl.Islevel2, AdvanceApprovalMaster_tbl.Islevel3 "+
" FROM         AdvanceApplicationMaster_tbl INNER JOIN "+
    "                  EmployeePersonalMaster_tbl ON AdvanceApplicationMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
   "                   EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid LEFT OUTER JOIN "+
  "                    AdvanceApprovalMaster_tbl ON AdvanceApplicationMaster_tbl.AdvanceAppPk = AdvanceApprovalMaster_tbl.AdvanceAppPk "+
" WHERE     (AdvanceApplicationMaster_tbl.Iscompleted = N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1)";
                }
                else
                {
                     
                    cmd.CommandText = " SELECT     AdvanceApplicationMaster_tbl.AdvanceAppPk, AdvanceApplicationMaster_tbl.AddvanceAppnum, EmployeePersonalMaster_tbl.empno, "+
                "      AdvanceApplicationMaster_tbl.DateAdded, AdvanceApprovalMaster_tbl.Level3Amount, AdvanceApplicationMaster_tbl.Reason, AdvanceApprovalMaster_tbl.IsLevel1, "+
                  "    AdvanceApprovalMaster_tbl.Islevel2, AdvanceApprovalMaster_tbl.Islevel3, AdvanceApprovalMaster_tbl.Hide_Display "+
" FROM         AdvanceApplicationMaster_tbl INNER JOIN "+
                "      EmployeePersonalMaster_tbl ON AdvanceApplicationMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
                   "   AdvanceApprovalMaster_tbl ON AdvanceApplicationMaster_tbl.AdvanceAppPk = AdvanceApprovalMaster_tbl.AdvanceAppPk INNER JOIN "+
                   "   EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid "+
" WHERE     (AdvanceApplicationMaster_tbl.Iscompleted <> N'N') AND (AdvanceApprovalMaster_tbl.Hide_Display = N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1)";

                }


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
        /// remove fromlist
        /// </summary>
        /// <param name="appid"></param>
        public void removefromlist(int appid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("UPDATE    AdvanceApprovalMaster_tbl SET              Hide_Display = N'Y' WHERE     (AdvanceAppPk = @Param1)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", appid);


                    command.ExecuteNonQuery();

                }

                sqlConnection1.Close();
            }

        }











    }

    class shiftchangeview
    {
        public DataTable getallShiftchange(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
                    cmd.CommandText = "SELECT     ShiftChangeApplication_tbl.ShftAppPK, ShiftChangeApplication_tbl.Appnum, ShiftChangeApplication_tbl.AppliedDate, EmployeePersonalMaster_tbl.empno, "+ 
                   "   DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, ShiftMasterNew_tbl.ShiftName, ShiftMasterNew_tbl_1.ShiftName AS Expr1,  "+
                    "  ShiftChangeApplication_tbl.Islevel1, ShiftChangeApplication_tbl.Islevel2, ShiftChangeApplication_tbl.Islevel3, ShiftChangeApplication_tbl.Iscompleted, "+
                    "  EmployeeDesignation_tbl.BranchLocationPK "+
" FROM         DesignationMaster_tbl INNER JOIN "+
  "                    ShiftChangeApplication_tbl INNER JOIN "+
   "                   EmployeePersonalMaster_tbl ON ShiftChangeApplication_tbl.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
    "                  EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON  "+
     "                 DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN "+
      "                DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN "+
       "               ShiftMasterNew_tbl ON ShiftChangeApplication_tbl.CurrentShiftPK = ShiftMasterNew_tbl.ShiftPK INNER JOIN "+
        "              ShiftMasterNew_tbl AS ShiftMasterNew_tbl_1 ON ShiftChangeApplication_tbl.ToShiftPk = ShiftMasterNew_tbl_1.ShiftPK "+
" WHERE     (ShiftChangeApplication_tbl.Iscompleted = N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ";

                }
                else
                {

                    cmd.CommandText = "SELECT     ShiftChangeApplication_tbl.ShftAppPK, ShiftChangeApplication_tbl.Appnum, ShiftChangeApplication_tbl.AppliedDate, EmployeePersonalMaster_tbl.empno, "+
            "          DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, ShiftMasterNew_tbl.ShiftName, ShiftMasterNew_tbl_1.ShiftName AS Expr1, "+
             "         ShiftChangeApplication_tbl.Islevel1, ShiftChangeApplication_tbl.Islevel2, ShiftChangeApplication_tbl.Islevel3, ShiftChangeApplication_tbl.Iscompleted, "+
              "        EmployeeDesignation_tbl.BranchLocationPK, ShiftChangeApplication_tbl.Hide_Display "+
" FROM         DesignationMaster_tbl INNER JOIN "+
  "                    ShiftChangeApplication_tbl INNER JOIN "+
   "                   EmployeePersonalMaster_tbl ON ShiftChangeApplication_tbl.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
    "                  EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON  "+
     "                 DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN "+
     "                 DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN "+
      "                ShiftMasterNew_tbl ON ShiftChangeApplication_tbl.CurrentShiftPK = ShiftMasterNew_tbl.ShiftPK INNER JOIN "+
       "               ShiftMasterNew_tbl AS ShiftMasterNew_tbl_1 ON ShiftChangeApplication_tbl.ToShiftPk = ShiftMasterNew_tbl_1.ShiftPK "+
 " WHERE     (ShiftChangeApplication_tbl.Iscompleted <> N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (ShiftChangeApplication_tbl.Hide_Display = N'N') ";

                }


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
        /// remove fromlist
        /// </summary>
        /// <param name="appid"></param>
        public void removefromlist(int appid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("UPDATE    ShiftChangeApplication_tbl SET              Hide_Display = N'Y' WHERE     (ShftAppPK = @Param1)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", appid);


                    command.ExecuteNonQuery();

                }

                sqlConnection1.Close();
            }

        }
        /// <summary>
        /// et the datatable of all the approved application
        /// </summary>
        /// <returns></returns>
        public DataTable getallshiftchangeapplicationapproved()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr);
            try
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("SELECT        ShiftChangeApplication_tbl.ShftAppPK AS APPPK, ShiftChangeApplication_tbl.Appnum AS APPNUM, ShiftChangeApplication_tbl.Empid AS EMPID, " +
                     "    EmployeePersonalMaster_tbl.empno AS EMPNO, EmployeePersonalMaster_tbl.oldempid AS [OLD ID], " +
                     "    EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS NAME, ShiftMasterNew_tbl_1.ShiftName AS [CURRENT SHIFT], " +
                  "       ShiftMasterNew_tbl.ShiftName AS [TO SHIFT]  ,ShiftChangeApplication_tbl.ToShiftPk" +
" FROM            ShiftChangeApplication_tbl INNER JOIN " +
           "              EmployeePersonalMaster_tbl ON ShiftChangeApplication_tbl.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                     "    ShiftMasterNew_tbl AS ShiftMasterNew_tbl_1 ON ShiftChangeApplication_tbl.CurrentShiftPK = ShiftMasterNew_tbl_1.ShiftPK INNER JOIN " +
                     "    ShiftMasterNew_tbl ON ShiftChangeApplication_tbl.ToShiftPk = ShiftMasterNew_tbl.ShiftPK INNER JOIN " +
                      "   EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
" WHERE        (ShiftChangeApplication_tbl.Islevel3 = N'A') AND (ShiftChangeApplication_tbl.Iscompleted = N'N') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ORDER BY ShftAppPK desc", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", Program.LOCTNPK);
                SqlDataReader reader = command.ExecuteReader();


                dt.Load(reader);

                return dt;

            }
            finally
            {
                sqlConnection1.Close();
            }

        }



    }



    class Deactvationview
    {




        public DataTable getAllDeactivationData(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
                    cmd.CommandText = "SELECT     EmployeDeactivationMaster_tbl.DeactivationPK, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, "+
    "                  EmployeDeactivationMaster_tbl.Dateadded, DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, EmpContract_tbl.ActualJoiningDate, "+
   "                   EmployeDeactivationMaster_tbl.Remark, EmployeDeactivationMaster_tbl.IsLevel1, EmployeDeactivationMaster_tbl.Islevel2, "+
  "                    EmployeDeactivationMaster_tbl.Islevel3 "+
" FROM         DesignationMaster_tbl INNER JOIN "+
                    "  EmployeDeactivationMaster_tbl INNER JOIN "+
                    "  EmployeePersonalMaster_tbl ON EmployeDeactivationMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN  "+
                    "  EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON "+
                    "  DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN "+
                    "  DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN "+
                    "  EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId "+
"WHERE     (EmployeDeactivationMaster_tbl.IsCompleted = N'N') AND (EmployeDeactivationMaster_tbl.HideDisplay = N'N') AND "+
                   "   (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ";
                }
                else
                {

                    cmd.CommandText = "SELECT     EmployeDeactivationMaster_tbl.DeactivationPK, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.First_name, "+
                   "   EmployeDeactivationMaster_tbl.Dateadded, DesignationMaster_tbl.DesignationName, DepartmentMaster_tbl.DepartmentName, EmpContract_tbl.ActualJoiningDate, "+
                     " EmployeDeactivationMaster_tbl.Remark, EmployeDeactivationMaster_tbl.IsLevel1, EmployeDeactivationMaster_tbl.Islevel2, "+
                     " EmployeDeactivationMaster_tbl.Islevel3 "+
" FROM         DesignationMaster_tbl INNER JOIN "+
                    "                    EmployeDeactivationMaster_tbl INNER JOIN "+
   "                   EmployeePersonalMaster_tbl ON EmployeDeactivationMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
    "                  EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON "+
     "                 DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN "+
      "                DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN "+
       "               EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId "+
"WHERE     (EmployeDeactivationMaster_tbl.IsCompleted  <> N'N') AND (EmployeDeactivationMaster_tbl.HideDisplay = N'N') AND " +
                 "     (EmployeeDesignation_tbl.BranchLocationPK = @Param1)";

                }


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
        /// remove fromlist
        /// </summary>
        /// <param name="appid"></param>
        public void removefromlist(int appid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("UPDATE    EmployeDeactivationMaster_tbl SET              HideDisplay = N'Y' WHERE     (DeactivationPK = @Param1)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", appid);


                    command.ExecuteNonQuery();

                }

                sqlConnection1.Close();
            }

        }




    






    }


    class leaveencashview
    {
        public DataTable getAllEncashData(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
                    cmd.CommandText = "SELECT     LeaveEnchasementMaster_tbl.LeaveEncashPk, LeaveEnchasementMaster_tbl.Appnum, EmployeePersonalMaster_tbl.empno, "+
                  "    LeaveEnchasementMaster_tbl.AddedDate, LeaveEnchasementMaster_tbl.EncashDuration, LeaveEnchasementMaster_tbl.DurationType, "+
                "      LeaveEnchasementMaster_tbl.Islevel1, LeaveEnchasementMaster_tbl.IsLevel2, LeaveEnchasementMaster_tbl.IsLevel3, LeaveEnchasementMaster_tbl.IsCompleted, "+
            "          LeaveEnchasementMaster_tbl.Hide_Display "+
" FROM         LeaveEnchasementMaster_tbl INNER JOIN "+
  "                    LeaveMaster_tbl ON LeaveEnchasementMaster_tbl.LeavePk = LeaveMaster_tbl.LeavePk INNER JOIN "+
   "                   EmployeePersonalMaster_tbl ON LeaveEnchasementMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
    "                  EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid "+
" WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (LeaveEnchasementMaster_tbl.IsCompleted = N'N') AND "+
  "                    (LeaveEnchasementMaster_tbl.Hide_Display = N'N') ";
                }
                else
                {

                    cmd.CommandText = " SELECT     LeaveEnchasementMaster_tbl.LeaveEncashPk, LeaveEnchasementMaster_tbl.Appnum, EmployeePersonalMaster_tbl.empno, "+
            "          LeaveEnchasementMaster_tbl.AddedDate, LeaveEnchasementMaster_tbl.EncashDuration, LeaveEnchasementMaster_tbl.DurationType, "+
             "         LeaveEnchasementMaster_tbl.Islevel1, LeaveEnchasementMaster_tbl.IsLevel2, LeaveEnchasementMaster_tbl.IsLevel3, LeaveEnchasementMaster_tbl.IsCompleted, "+
              "        LeaveEnchasementMaster_tbl.Hide_Display "+
" FROM         LeaveEnchasementMaster_tbl INNER JOIN "+
  "                    LeaveMaster_tbl ON LeaveEnchasementMaster_tbl.LeavePk = LeaveMaster_tbl.LeavePk INNER JOIN "+
   "                   EmployeePersonalMaster_tbl ON LeaveEnchasementMaster_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN "+
    "                  EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid "+
" WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (LeaveEnchasementMaster_tbl.IsCompleted <> N'N') AND "+
  "                    (LeaveEnchasementMaster_tbl.Hide_Display = N'N')";

                }


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
    }


    class Adjusterview
    {

        public DataTable getAllAdjusterforApproval(int type)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (type == 0)
                {
                                       cmd.CommandText = "SELECT     AdjusterMaster_tbl.AdjusterID, AdjusterMaster_tbl.AdjusterCode, BranchLocartionMaster_tbl.BranchLocationName, AdjusterMaster_tbl.FromDate, "+
                   "   AdjusterMaster_tbl.Todate, AdjusterMaster_tbl.DoneOn "+
" FROM         AdjusterMaster_tbl INNER JOIN "+
                  "    BranchLocartionMaster_tbl ON AdjusterMaster_tbl.BranchLctnPk = BranchLocartionMaster_tbl.BranchlLocationPk";
                }
                else
                {

                }


                //   cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK);
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
        /// revert a payroll
        /// </summary>
        /// <param name="payid"></param>
        public void revertAdjuster(int payid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RevertAdjuster_sp", con);
                cmd.Parameters.AddWithValue("@Adhusterid", payid);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            }

        }

    }

}

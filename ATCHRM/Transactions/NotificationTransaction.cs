using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient ;
using System.Data ;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
namespace ATCHRM.Transactions
{
    class NotificationTransaction
    {

        public DataTable  getNotificationavailablelist()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     NotificationId, NotificationType FROM         NotificationMaster_tbl", con);

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

        public DataTable getbirthday()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@" SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.oldempid, 
                         EmployeePersonalMaster_tbl.First_name + '' + EmployeePersonalMaster_tbl.Last_Name AS Empname, EmployeePersonalMaster_tbl.EmpGender, 
                         EmployeePersonalMaster_tbl.EmpNation, EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, 
                         EmployeePersonalMaster_tbl.Matialstatus
FROM            EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @branchlctnpk) AND (EmployeePersonalMaster_tbl.Status = N'A') AND  DATEPART(d, EmployeePersonalMaster_tbl.DateofBirth ) = DATEPART(d, GETDATE())
    AND DATEPART(m,  EmployeePersonalMaster_tbl.DateofBirth) = DATEPART(m, GETDATE())", con);
                cmd.Parameters.AddWithValue("@branchlctnpk", Program.LOCTNPK);
                cmd.Parameters.AddWithValue("@birthday", DateTime.Now.Date);
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

        public DataTable GetContractEndingEmployees()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid AS Empid, EmployeePersonalMaster_tbl.First_name + '' + EmployeePersonalMaster_tbl.Last_Name AS [Emp Name], 
                         EmployeePersonalMaster_tbl.EmpGender AS Gender, EmployeePersonalMaster_tbl.EmpNation AS Nation, EmployeePersonalMaster_tbl.NationalId, 
                         EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.Matialstatus, EmployeePersonalMaster_tbl.Status, EmpContract_tbl.ContractType, 
                         EmpContract_tbl.ActualJoiningDate, EmpContract_tbl.Startdate, EmpContract_tbl.Endtime, EmployeeDesignation_tbl.BranchLocationPK
FROM            EmployeePersonalMaster_tbl INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid
WHERE        (EmployeePersonalMaster_tbl.Status = N'A') AND (EmpContract_tbl.Endtime - GETDATE() < 10) AND (EmployeeDesignation_tbl.BranchLocationPK = @branchlctnpk)", con);
                cmd.Parameters.AddWithValue("@branchlctnpk", Program.LOCTNPK);
               
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
        public DataTable getnotification()
        {
            DataTable dt = new DataTable();
            DataTable notifiation = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT     NotificationType "+
" FROM         UserNotification_tbl "+
" WHERE     (UserPk = @Param1)", con))
                {


                    cmd.Parameters.AddWithValue("@Param1", Program.USERPK);

                     SqlDataReader reader = cmd.ExecuteReader();
          dt = new DataTable();

                dt.Load(reader);


                }

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        SqlCommand cmd1 = new SqlCommand("UserNotification_sp ", con);
                        cmd1.Parameters.AddWithValue("@notificationtype", dt.Rows[i][0].ToString());
                        cmd1.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        notifiation.Load(reader);
                    }



                }

            }



            return notifiation;
        }

        public DataTable getpendingcloseregister()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT    DATEDIFF(day,    MAX(CloseRegisterDate) ,getdate()) as pendingdays,MAX(CloseRegisterDate)
FROM            CloseRegisterRecord_tbl
GROUP BY BranchlctnPK
HAVING        (BranchlctnPK = @branchlctnpk)", con);
                cmd.Parameters.AddWithValue("@branchlctnpk", Program.LOCTNPK);

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



        public DataTable Last10closeregister()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        TOP (10) CloseRegisterRecord_tbl.CloseRegisterDate, CloseRegisterRecord_tbl.NoofEmployee , CloseRegisterRecord_tbl.AddedDate, UserMaster_tbl.UserId
FROM            CloseRegisterRecord_tbl INNER JOIN
                         UserMaster_tbl ON CloseRegisterRecord_tbl.DoneBy = UserMaster_tbl.UserPK
WHERE        (CloseRegisterRecord_tbl.BranchlctnPK = @branchlctnpk)
ORDER BY CloseRegisterRecord_tbl.CloseRegisterDate DESC", con);
                cmd.Parameters.AddWithValue("@branchlctnpk", Program.LOCTNPK);

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
        public void sendmail()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("ashtonhrm@gmail.com", "hrm$2013"),
                EnableSsl = true
            };
            client.Send("ashtonhrm@gmail.com", "mayank_sharma@atraco.ae", "Welcome", "You are Added to HRM mail list");
             ATCHRM.Controls.ATCHRMMessagebox.Show("sent");
        }





        public void geteserverdate()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.ConnStr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Getdate() ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable datetable = new DataTable();

                datetable.Load(reader);
                con.Close();
                Program.Datetoday = DateTime.Parse(datetable.Rows[0][0].ToString());
            }
            catch (Exception exp)
            {

                ATCHRM.Controls.ATCHRMMessagebox.Show("Central Database Seems Down  Please Contact IT");
                try
                {
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                    ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                    Application.Exit();
                }
                catch (Exception)
                {

                    Application.Exit();
                }
            }

        }







    }



 

}

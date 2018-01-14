using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace ATCHRM.Transactions
{
    class ShiftTransaction
    {

        # region old code
        /// <summary>
        /// insert new shift entries to the ShiftMaster table
        /// </summary>
        /// <param name="shftdatabean"></param>
        public void insertShiftMasterData(Datalayer.ShiftDataBean shftdatabean)
        {
            SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr);
            sqlConnection1.Open();
            SqlCommand command = new SqlCommand("INSERT INTO ShiftMaster_tbl (ShiftName, StartTime, EndTime, Breaknum, TotalHours, DateAdded, UserPk) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", sqlConnection1);

            command.Parameters.AddWithValue("@Param1", shftdatabean.ShiftName1);
            command.Parameters.AddWithValue("@Param2", shftdatabean.Startofshift);
            command.Parameters.AddWithValue("@Param3", shftdatabean.Endofshift);
            command.Parameters.AddWithValue("@Param4", shftdatabean.NoOfBreak);
            command.Parameters.AddWithValue("@Param5", shftdatabean.ShftDuration1);
            command.Parameters.AddWithValue("@Param6", DateTime.Now.Date);
            command.Parameters.AddWithValue("@Param7", Program.USERPK);
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        /// <summary>
        /// get Shift details against each shift name
        /// </summary>
        /// <param name="countryname"></param>
        /// <returns></returns>

        public DataTable getsShiftByName(String ShiftName, TimeSpan intime, TimeSpan outtime)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  ShiftPk, ShiftName, StartTime, EndTime, Breaknum, TotalHours, UserPk FROM ShiftMaster_tbl WHERE (ShiftName = @Param1) AND (StartTime = @Param2) AND (EndTime = @Param3)", con);
                cmd.Parameters.AddWithValue("@Param1", ShiftName);
                cmd.Parameters.AddWithValue("@Param2", intime);
                cmd.Parameters.AddWithValue("@Param3", outtime);
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
        /// get Shift details against each shift name
        /// </summary>
        /// <param name="shifhtpk"> </param>
        /// <returns></returns>

        public DataTable getsShiftByPK(int shifhtpk)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  ShiftPk, ShiftName, StartTime, EndTime, Breaknum, TotalHours, UserPk FROM ShiftMaster_tbl WHERE ShiftPk= @param1 ", con);
                cmd.Parameters.AddWithValue("@Param1", shifhtpk);

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
        /// insert break against each shift
        /// </summary>
        /// <param name="shftdatabean"></param>
        public void insertShifBreak(Datalayer.ShiftBreakDataBean shftbrkdatabean)
        {
            SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr);
            try
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ShiftBreakSub_tbl(BreakName, ShiftPk, Duration, Uom) VALUES (@Param1,@Param2,@Param3,@Param4)", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", shftbrkdatabean.Breakname);
                command.Parameters.AddWithValue("@Param2", shftbrkdatabean.Shiftpk);
                command.Parameters.AddWithValue("@Param3", int.Parse(shftbrkdatabean.Duration1));
                command.Parameters.AddWithValue("@Param4", shftbrkdatabean.Uom);

                command.ExecuteNonQuery();

            }
            finally
            {
                sqlConnection1.Close();
            }
        }


        /// select all shift  data from database for displaying in datagrid
        /// </summary>
        /// <returns></returns>
        public DataTable selectallShiftdata()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     ShiftMaster_tbl.ShiftPk, ShiftMaster_tbl.ShiftName, ShiftMaster_tbl.StartTime, ShiftMaster_tbl.EndTime, ShiftMaster_tbl.Breaknum, ShiftMaster_tbl.TotalHours, "
                    + " SUM(ShiftBreakSub_tbl.Duration) AS Expr1 FROM  ShiftMaster_tbl INNER JOIN ShiftBreakSub_tbl ON ShiftMaster_tbl.ShiftPk = ShiftBreakSub_tbl.ShiftPk "
                    + " GROUP BY ShiftMaster_tbl.ShiftPk, ShiftMaster_tbl.ShiftName, ShiftMaster_tbl.EndTime, ShiftMaster_tbl.StartTime, ShiftMaster_tbl.Breaknum,ShiftMaster_tbl.TotalHours", con);
                SqlDataReader reader = cmd.ExecuteReader();


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
        /// get all the breaks against the 
        /// </summary>
        /// <param name="shiftpk"></param>
        /// <returns></returns>
        public DataTable selectallbreakofShift(int shiftpk)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT  BreakPK, BreakName, ShiftPk, Duration FROM  ShiftBreakSub_tbl WHERE (ShiftPk = @Param1)", con))
                {


                    cmd.Parameters.AddWithValue("@Param1", shiftpk);
                    SqlDataReader reader = cmd.ExecuteReader();


                    dt.Load(reader);

                    return dt;
                }

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
        /// Update Shift entries to the ShiftMaster table
        /// </summary>
        /// <param name="shftdatabean"></param>
        public void updateShiftMasterData(Datalayer.ShiftDataBean shftdatabean)
        {
            SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr);
            sqlConnection1.Open();
            SqlCommand command = new SqlCommand("UPDATE ShiftMaster_tbl SET ShiftName = @Param1, StartTime = @Param2, EndTime = @Param3, Breaknum = @Param4, TotalHours = @Param5, DateAdded = @Param6, UserPk = @Param7 WHERE (ShiftPk = @Param9)", sqlConnection1);

            command.Parameters.AddWithValue("@Param1", shftdatabean.ShiftName1);
            command.Parameters.AddWithValue("@Param2", shftdatabean.Startofshift);
            command.Parameters.AddWithValue("@Param3", shftdatabean.Endofshift);
            command.Parameters.AddWithValue("@Param4", shftdatabean.NoOfBreak);
            command.Parameters.AddWithValue("@Param5", shftdatabean.ShftDuration1);
            command.Parameters.AddWithValue("@Param6", DateTime.Now.Date);
            command.Parameters.AddWithValue("@Param7", Program.USERPK);

            command.Parameters.AddWithValue("@Param9", shftdatabean.Shiftpk);
            command.ExecuteNonQuery();
            sqlConnection1.Close();
        }


        /// <summary>
        /// Update  break against each shift
        /// </summary>
        /// <param name="shftdatabean"></param>
        public void updateShiftBreak(Datalayer.ShiftBreakDataBean shftbrkdatabean)
        {
            SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr);
            try
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("UPDATE ShiftBreakSub_tbl SET  BreakName = @Param1, ShiftPk = @Param2, Duration = @Param3, Uom = @Param4 WHERE (BreakPK = @Param5)", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", shftbrkdatabean.Breakname);
                command.Parameters.AddWithValue("@Param2", shftbrkdatabean.Shiftpk);
                command.Parameters.AddWithValue("@Param3", int.Parse(shftbrkdatabean.Duration1));
                command.Parameters.AddWithValue("@Param4", shftbrkdatabean.Uom);
                command.Parameters.AddWithValue("@Param5", shftbrkdatabean.Breakpk);
                command.ExecuteNonQuery();

            }
            finally
            {
                sqlConnection1.Close();
            }
        }



        /// <summary>
        /// GET THE EMPLOYEE SHIFTDATA
        /// DROM THE EMPOLOYEE CONTRACT TABLE
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getemployeeshiftdata(int empid)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr);
            try
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("SELECT  EmployeShift_tbl.Shiftpk, ShiftMasterNew_tbl.ShiftName FROM  EmployeShift_tbl INNER JOIN  ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK WHERE     (EmployeShift_tbl.Empid = @Param1) ", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", empid);
                SqlDataReader reader = command.ExecuteReader();


                dt.Load(reader);

                return dt;

            }
            finally
            {
                sqlConnection1.Close();
            }

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
         public void insertShiftTransferApplication()
       {



       }



         public DataTable gettALLShiftDetails()
         {

             SqlConnection con = new SqlConnection(Program.ConnStr);
             try
             {

                 con.Open();
                 SqlCommand cmd = new SqlCommand("SELECT     ShiftMasterNew_tbl.ShiftPK AS Sl, ShiftMasterNew_tbl.ShiftName AS [Shift Name], ShiftDayDetails_tbl.DayOFWeekname AS Day, "+
                  "     ShiftDayDetails_tbl.DayStatus AS Status, convert(varchar, ShiftDayDetails_tbl.FromTime, 8) AS [From Time],convert(varchar, ShiftDayDetails_tbl.ToTime , 8) AS [To Time],  " +
                   "   ShiftDayDetails_tbl.TotalDuration AS Duration, ShiftDayDetails_tbl.BreakDuration AS [Break Duration] "+
" FROM         ShiftMasterNew_tbl INNER JOIN "+
                    "  ShiftDayDetails_tbl ON ShiftMasterNew_tbl.ShiftPK = ShiftDayDetails_tbl.ShiftPK", con);

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

         public DataTable gettALLShiftDetailsofSpecificShift(int shiftpk)
         {

             SqlConnection con = new SqlConnection(Program.ConnStr);
             try
             {

                 con.Open();
                 SqlCommand cmd = new SqlCommand("SELECT     ShiftMasterNew_tbl.ShiftPK AS Sl, ShiftMasterNew_tbl.ShiftName AS [Shift Name], ShiftDayDetails_tbl.DayOFWeekname AS Day, " +
                  "     ShiftDayDetails_tbl.DayStatus AS Status, convert(varchar, ShiftDayDetails_tbl.FromTime, 8) AS [From Time],convert(varchar, ShiftDayDetails_tbl.ToTime , 8) AS [To Time],  " +
                   "   ShiftDayDetails_tbl.TotalDuration AS Duration, ShiftDayDetails_tbl.BreakDuration AS [Break Duration] " +
" FROM         ShiftMasterNew_tbl INNER JOIN " +
                    "  ShiftDayDetails_tbl ON ShiftMasterNew_tbl.ShiftPK = ShiftDayDetails_tbl.ShiftPK   where ShiftMasterNew_tbl.ShiftPK = @param1", con);
                 cmd.Parameters.AddWithValue("@param1", shiftpk);
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
        /// this displays the shift data in the main screen in the Shift At nsetting
        /// </summary>
        /// <returns></returns>
         public DataTable getallshiftdaataforjustdisplay()
         {

             SqlConnection con = new SqlConnection(Program.ConnStr);
             try
             {

                 con.Open();
                 SqlCommand cmd = new SqlCommand("SELECT DISTINCT  "+
                   "   ShiftMasterNew_tbl.ShiftPK AS Sl, ShiftMasterNew_tbl.ShiftName AS [Shift Name], ShiftMasterNew_tbl.Duration AS [Total Weekly Duration], "+
                  "    WorkLimitMaster_tbl.Weeeklyduration AS [Worklimit Duration],ShiftMasterNew_tbl.isActive " +
" FROM         ShiftMasterNew_tbl INNER JOIN "+
                   "   WorkLimitMaster_tbl ON ShiftMasterNew_tbl.ShiftPK = WorkLimitMaster_tbl.ShiftPk", con); 

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
         /// get all the shiftname form ShiftMasterNew_tbl
        /// </summary>
        /// <returns></returns>
         public DataTable  getAllShiftNameandPK()
         {

             SqlConnection con = new SqlConnection(Program.ConnStr);
             try
             {

                 con.Open();
                 SqlCommand cmd = new SqlCommand("SELECT     ShiftName, ShiftPK FROM ShiftMasterNew_tbl", con);
                
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

















    class WorkLimitTransaction
    {
        /// <summary>
        /// insert new shift entries to the ShiftMaster table
        /// </summary>
        /// <param name="shftdatabean"></param>
        public void insertWorkLimitrData(ArrayList arry, ArrayList dailylst, ArrayList daylst,int shiftPk)
        {
            DataTable dt = new DataTable();
            int wrklmt = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO WorkLimitMaster_tbl (Weeeklyduration, UserPk, DateAdded,ShiftPk ) VALUES (@Param1,@Param2,getdate(),@Param3) ;SELECT SCOPE_IDENTITY()", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", arry[0]);
                    command.Parameters.AddWithValue("@Param2", Program.USERPK);
                    command.Parameters.AddWithValue("@Param3", shiftPk);
                    wrklmt = int.Parse(command.ExecuteScalar().ToString());
                }


                for(int i=0;i<7;i++){
                using (SqlCommand command = new SqlCommand("INSERT INTO WorkLimitDetails_tbl (WorkLimitID, WeekDayName, MaxWorkLimit) VALUES     (@Param1,@Param2,@Param3)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", wrklmt);
                    command.Parameters.AddWithValue("@Param2", daylst[i]);
                    command.Parameters.AddWithValue("@Param3", int.Parse (dailylst[i].ToString ()));
                    command.ExecuteNonQuery();
                }

                }





                sqlConnection1.Close();
            }
        }
   
    
    }
}

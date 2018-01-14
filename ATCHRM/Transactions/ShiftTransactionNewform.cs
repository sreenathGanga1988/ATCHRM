using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ATCHRM.Transactions
{
    class ShiftTransactionNewform
    {


        /// <summary>
        /// inserts a new Shift
        /// </summary>
        /// <param name="Shiftname"></param>
        /// <param name="duration"></param>
        /// <param name="shiftdaily"></param>
        public int insertnewshift(String Shiftname, int duration, DataTable shiftdaily)
        {
            int shiftpk = 0;

            Boolean ispresent = false;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select ShiftPK from ShiftMasterNew_tbl where ShiftName=@shiftname ", con))
                {

                    cmd.Parameters.AddWithValue("@shiftname ", Shiftname);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                         ATCHRM.Controls.ATCHRMMessagebox.Show("Shift Name with the same Name Exist Try Another name");
                        ispresent = true;
                    }
                    else
                    {
                        ispresent = false;
                    }
                }
            }
            if (!ispresent)
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();
                    using (SqlCommand insrtcmd = new SqlCommand("INSERT INTO ShiftMasterNew_tbl(ShiftName, Duration) VALUES  (@Param1,@Param2) ;SELECT SCOPE_IDENTITY()", con))
                    {

                        insrtcmd.Parameters.AddWithValue("@Param1", Shiftname);
                        insrtcmd.Parameters.AddWithValue("@Param2", duration);

                        shiftpk = int.Parse(insrtcmd.ExecuteScalar().ToString());


                        if (shiftpk != 0)
                        {
                            try
                            {
                                for (int i = 0; i < 7; i++)
                                {


                                    using (SqlCommand insrtcmddetial = new SqlCommand("INSERT INTO ShiftDayDetails_tbl " +
                           "(DayOFWeekname, DayStatus, FromTime, ToTime, TotalDuration, BreakDuration, NumberOfBreak, ShiftPK) " +
        "VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8)", con))
                                    {


                                        insrtcmddetial.Parameters.AddWithValue("@Param1", shiftdaily.Rows[i][0].ToString());
                                        insrtcmddetial.Parameters.AddWithValue("@Param2", shiftdaily.Rows[i][1].ToString());
                                        insrtcmddetial.Parameters.AddWithValue("@Param3", TimeSpan.Parse(shiftdaily.Rows[i][2].ToString()));
                                        insrtcmddetial.Parameters.AddWithValue("@Param4", TimeSpan.Parse(shiftdaily.Rows[i][3].ToString()));
                                        insrtcmddetial.Parameters.AddWithValue("@Param5", int.Parse(shiftdaily.Rows[i][4].ToString()));
                                        insrtcmddetial.Parameters.AddWithValue("@Param6", int.Parse(shiftdaily.Rows[i][5].ToString()));
                                        insrtcmddetial.Parameters.AddWithValue("@Param7", int.Parse(shiftdaily.Rows[i][6].ToString()));
                                        insrtcmddetial.Parameters.AddWithValue("@Param8", shiftpk);

                                        insrtcmddetial.ExecuteNonQuery();




                                    }

                                }

                            }
                            catch (Exception)
                            {




                                using (SqlCommand deletecmnd = new SqlCommand("delete from ShiftMasterNew_tbl where  ShiftPK= @Param1", con))
                                {

                                    insrtcmd.Parameters.AddWithValue("@Param1", shiftpk);
                                    deletecmnd.ExecuteNonQuery();

                                }
                                using (SqlCommand deletecmnd1 = new SqlCommand("delete from ShiftDayDetails_tbl where  ShiftPK= @Param2", con))
                                {

                                    insrtcmd.Parameters.AddWithValue("@Param1", shiftpk);
                                    deletecmnd1.ExecuteNonQuery();
                                }
                                shiftpk = 0;
                            }
                        }









                    }
                }


            }

            return shiftpk;

        }



        /// <summary>
        /// get all the shiftname form ShiftMasterNew_tbl
        /// </summary>
        /// <returns></returns>
        public DataTable getAllShiftName()
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     ShiftName, ShiftPK FROM ShiftMasterNew_tbl where isActive !='D'", con);

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


        public DataTable getsShiftByPK(int shifhtpk)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     ShiftPK, DayOFWeekname, DayStatus, FromTime, ToTime FROM ShiftDayDetails_tbl WHERE     (ShiftPK = @Param1) ", con);
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
                SqlCommand command = new SqlCommand("SELECT  EmployeShift_tbl.Shiftpk, ShiftMasterNew_tbl.ShiftName,EffectiveFrom  FROM  EmployeShift_tbl INNER JOIN  ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK WHERE     (EmployeShift_tbl.Empid = @Param1) ", sqlConnection1);

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




       







    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;


namespace ATCHRM.SwipeAction
{
    class NightShifttransaction
    {



        public DataTable getallnightswipe(int BranchPk, DateTime frmdate,DateTime todate, int shiftpk )
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
              
             
                SqlCommand cmd = new SqlCommand("GetNightShiftPuch_SP", con);
                cmd.Parameters.AddWithValue("@branchlctnpk", BranchPk);
                cmd.Parameters.AddWithValue("@fromdate", frmdate.ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@todate", todate.ToString("MM-dd-yyyy"));
                
                cmd.Parameters.AddWithValue("@ShiftPK", shiftpk);            

             

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;





        }
    }
}

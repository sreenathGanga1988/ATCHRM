using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace ATCHRM.Transactions
{
    class ApplicationTransaction
    {

        public DataTable getallOtapplication( int BranchlctnPK ,int Deptpk, int Desgpk,String Applicationtype)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetAllApplicationNo_sp ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Branchlctnpk", BranchlctnPK);
                cmd.Parameters.AddWithValue("@Deptpk", Deptpk);
                cmd.Parameters.AddWithValue("@DesignationPK", Desgpk);

                cmd.Parameters.AddWithValue("@Applicationtype", Applicationtype);
               
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }








    }
}

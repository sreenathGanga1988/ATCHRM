using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ATCHRM.Transactions
{
    class PerkTransaction
    {


       
        /// <summary>
        /// insert perk data
        /// </summary>
        /// <param name="perkdatabean"></param>
        public void InsertPerkTransaction(Datalayer.PerkDataBean perkdatabean)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Perk_Master "+
                      "   (PerkCode, PerkName, TaxablePercentage)"+
" VALUES        (@Param1,@Param2,@Param3)", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", perkdatabean.PerkCode1 );
                command.Parameters.AddWithValue("@Param2", perkdatabean.PerkName1 );
                command.Parameters.AddWithValue("@Param3", perkdatabean.Taxablepercentage);
                              
                command.ExecuteNonQuery();
                sqlConnection1.Close();
            }
        }

        /// <summary>
        /// get all the Perk
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPerk()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PerkPK as SL, PerkCode AS CODE, PerkName PERKNAME, TaxablePercentage AS [TAXABLE%] FROM            Perk_Master ", con);
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


        public DataTable GetAllPerkandAmount()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PerkPK as SL, PerkCode AS CODE, PerkName PERKNAME, TaxablePercentage AS [TAXABLE%] , '0' as AMOUNT , '0' as [TAXABLE AMOUNT]  FROM            Perk_Master ", con);
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



        public void UpdatePerk(Datalayer.PerkDataBean perkdatabean)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                using (SqlCommand command1 = new SqlCommand("UPDATE       Perk_Master  SET  PerkCode = @Param1, PerkName = @Param2 , TaxablePercentage = @Param3 WHERE        (PerkPK = @Param4)", sqlConnection1))
                {
                    
                    command1.Parameters.AddWithValue("@Param1", perkdatabean.PerkCode1 );
                    command1.Parameters.AddWithValue("@Param2", perkdatabean.PerkName1 );
                    command1.Parameters.AddWithValue("@Param3", perkdatabean.Taxablepercentage );
                    command1.Parameters.AddWithValue("@Param4", perkdatabean.PerkPK );
                    command1.ExecuteNonQuery();
                }
            }
        }


    }
}

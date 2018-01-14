using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace ATCHRM.Transactions
{
    class SalaryCompTransaction
    {
/// <summary>
/// to get the type of calculation
/// for the sal component
/// </summary>
/// <param name="calculationtype"></param>
/// <param name="Criteria"></param>
/// <returns></returns>
        public DataTable getcalculationpk( String calculationtype ,String Criteria )
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     Caluculationpk FROM ComponentcalMaster_tbl WHERE (CalculationType = @Param1) AND (Criteria = @Param2)", con);
                cmd.Parameters.AddWithValue("@Param1",calculationtype );
                cmd.Parameters.AddWithValue("@Param2", Criteria);
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
/// get the type of component grom 
  /// ComponentType_tbl to find which type the component is
/// </summary>
/// <param name="componentname"></param>
/// <param name="componenttype"></param>
/// <returns></returns>
        public DataTable getComponentTypepk(String componentname, String componenttype)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     Componenttypepk FROM  ComponentType_tbl WHERE (ComponentName = @Param1) AND (ComponentType = @Param2)", con);
                cmd.Parameters.AddWithValue("@Param1", componentname);
                cmd.Parameters.AddWithValue("@Param2", componenttype);
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
        /// insert data to the  salcomponent master
        /// </summary>
        /// <param name="salcompdatabean"></param>

        public void insertSalComp(Datalayer.SalaryCompDataBean salcompdatabean)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();
                SqlCommand command = new SqlCommand("INSERT INTO SalComponentMaster_tbl (ComponentName, Componenttypepk, Caluculationpk, Amount, UserPk, DateAdded , Form_Det_Id)VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6 ,@Param7)", sqlConnection1);

                command.Parameters.AddWithValue("@Param1", salcompdatabean.SalcompName );
                command.Parameters.AddWithValue("@Param2", salcompdatabean.Componenttypepk);
                command.Parameters.AddWithValue("@Param3", salcompdatabean.Calculationtype);
                command.Parameters.AddWithValue("@Param4", salcompdatabean.Amount1);
                command.Parameters.AddWithValue("@Param5", Program.USERPK);
                command.Parameters.AddWithValue("@Param6", DateTime.Now.Date);
                command.Parameters.AddWithValue("@Param7", salcompdatabean.Formulapk);
                //command.Parameters.AddWithValue("@Param8", DateTime.Now.Date);
                //command.Parameters.AddWithValue("@Param9", Program.USERPK);
                command.ExecuteNonQuery();
                sqlConnection1.Close();
            }
        }

        /// <summary>
        /// get the datatable containing all the details of the
        /// sal components added
        /// </summary>
        /// <returns></returns>
        public DataTable  getAllSalCompData()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     SalComponentMaster_tbl.salcompPk AS Sl, SalComponentMaster_tbl.ComponentName AS SalComp, ComponentType_tbl.ComponentName AS Component,  "+
                          " ComponentType_tbl.ComponentType AS Type, ComponentCalMaster_tbl.CalculationType AS CalcType, ComponentCalMaster_tbl.Criteria AS Criteria,  SalComponentMaster_tbl.Amount AS Amount" +
                          " FROM SalComponentMaster_tbl INNER JOIN ComponentType_tbl ON SalComponentMaster_tbl.Componenttypepk = ComponentType_tbl.Componenttypepk INNER JOIN  ComponentCalMaster_tbl ON SalComponentMaster_tbl.Caluculationpk = ComponentCalMaster_tbl.Caluculationpk", con);
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
        /// gets all the SalComponent Name 
        /// \to be used to fill the Comboboxes
        /// </summary>
        public DataTable  getSalcomponentandPK()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT salcompPk , ComponentName  FROM SalComponentMaster_tbl ", con);
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
        /// gets all the Formula Name 
        /// \to be used to fill the Comboboxes
        /// </summary>
        public DataTable getallformula()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT Formula_details_tbl.Form_Data, Formula_details_tbl.Form_Name, Formula_details_tbl.Form_Det_Id FROM  Formula_Master_tbl INNER JOIN Formula_details_tbl ON Formula_Master_tbl.Form_id = Formula_details_tbl.Form_id", con);
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
}

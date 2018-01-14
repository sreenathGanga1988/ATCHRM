using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
namespace ATCHRM.Transactions
{
    class Locationtransaction
    {
      
        
        
        /// <summary>
        /// get all the location inserted
        /// </summary>
        /// <returns></returns>
        public DataTable getLocation()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
              
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from LocationMaster_tbl ORDER BY CountryName ASC", con);

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
      /// get all country entered in the data base
      /// </summary>
      /// <returns></returns>
        public DataTable getcountry()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Select Distinct CountryName  from LocationMaster_tbl ORDER BY CountryName ASC", con);

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
        /// get states  against each country
        /// </summary>
        /// <param name="countryname"></param>
        /// <returns></returns>

        public DataTable getstatebycountry( string countryname)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Select Distinct  StateName   from LocationMaster_tbl where CountryName ='" + countryname + "' ORDER BY StateName ASC", con);

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
        /// get city from database
        /// search and find the cities against each country and state
        /// </summary>
        /// <param name="countryname"></param>
        /// <param name="cityname"></param>
        /// <returns></returns>
        public DataTable getcitybycountry(string countryname, string cityname)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Select LocationPk , CitName   from LocationMaster_tbl where CountryName ='" + countryname + "' and  StateName  ='" + cityname + "' ORDER BY CitName ASC", con);

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
        /// Check whether a combination of country ,state
        /// and city is previously entered or present
        /// 
        /// </summary>
        /// <param name="Countryname"></param>
        /// <param name="StateName"></param>
        /// <param name="Cityname"></param>
        /// <returns>ispresent= true if present and false if not in database </returns>
        public Boolean  islocationPresent(String countryname ,String stateName ,String cityname)
        {
            Boolean ispresent = true;

            SqlConnection con = new SqlConnection(Program.ConnStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT LocationPk, StateName, CitName, CountryName FROM  LocationMaster_tbl  where(( StateName ='" + stateName + "' and CitName= '" + cityname + "') or  ( StateName ='" + cityname + "' and CitName= '" + stateName + "')) and CountryName= '" + countryname + "'", con);
           
      
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            if (dt.Rows.Count != 0)
            {
                ispresent = false;
            }
            return ispresent;
        }


        public void insertlocation(String countryname , String statename ,String cityname)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
             
                con.Open();
                
                SqlCommand cmd = new SqlCommand("INSERT INTO LocationMaster_tbl (CountryName, StateName, CitName, DateAdded)VALUES (@pCountryName,@pStateName,@pCitName,@pDateAdded)", con);

                cmd.Parameters.AddWithValue("@pCountryName", countryname);
                cmd.Parameters.AddWithValue("@pStateName", statename);
                cmd.Parameters.AddWithValue("@pCitName", cityname);
                cmd.Parameters.AddWithValue("@pDateAdded", DateTime.Now.Date);
                cmd.ExecuteNonQuery();

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                throw exp;


            }
            finally
            {
                con.Close();
            }
        }

        



    }
//**********************************************************************************************************************************************************************



    class currencytransaction
    {

        /// <summary>
        /// show all the currency entered
        /// </summary>
        /// <returns></returns>
        public DataSet showallcurrecy()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select  Name+'--'+CurrencyCode AS NameAdr,Currency_Pk as pk  from CurrencyMaster_tbl ", con);

            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            DataSet myData = new DataSet();
            myAdapter.Fill(myData, "currency");
            con.Close();
            return myData;
        }




        /// <summary>
        /// check whether a currency is already present or not
        /// </summary>
        /// <param name="Curancyname"></param>
        /// <param name="Country"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
       public Boolean  isCurrencyPresent(String Curancyname ,String Country  ,String currencyCode)
        {
            Boolean ispresent = false;

            SqlConnection con = new SqlConnection(Program.ConnStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from CurrencyMaster_tbl where  CurrencyCode = '"+ currencyCode +"'or  Name= '" + Curancyname + "' " , con);
           
      
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            if (dt.Rows.Count != 0)
            {
                ispresent = true;
            }
            con.Close();
            return ispresent;
        }


        /// <summary>
        /// get the details of currecny against currency Pk
        /// </summary>
        /// <param name="currencypk"></param>
        /// <returns></returns>
       public DataSet getcurrecydataof( int currencypk)
       {
           SqlConnection con = new SqlConnection(Program.ConnStr);

           con.Open();
           SqlCommand cmd = new SqlCommand("select  *  from CurrencyMaster_tbl  where Currency_Pk =" + currencypk + "", con);

           SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
           DataSet myData = new DataSet();
           myAdapter.Fill(myData, "currency");
           con.Close();
           return myData;
       }



       /// <summary>
       /// get all country entered in the data base
       /// </summary>
       /// <returns></returns>
       public DataTable getCurrencyName()
       {
           SqlConnection con = new SqlConnection(Program.ConnStr);
           try
           {

               con.Open();
               SqlCommand cmd = new SqlCommand("select  Name AS NameAdr,Currency_Pk as pk  from CurrencyMaster_tbl ORDER BY Name ASC ", con);

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
//**************************************************************************************************************************************************************************

    class DepartmentTransaction
    {
        /// <summary>
        /// get all DepasrtmentNameentered in the data base
        /// </summary>
        /// <returns></returns>
        public DataTable getDeptName()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
            //    SqlCommand cmd = new SqlCommand(" SELECT  DepartmentPK, DepartmentName FROM DepartmentMaster_tbl where IsActive='Y' ORDER BY DepartmentName ASC ", con);


                SqlCommand cmd = new SqlCommand(@" SELECT        DepartmentMaster_tbl.DepartmentPK, DepartmentMaster_tbl.DepartmentName, DepartmentLocation_tbl.BranchLctnPK
FROM            DepartmentMaster_tbl INNER JOIN
                         DepartmentLocation_tbl ON DepartmentMaster_tbl.DepartmentPK = DepartmentLocation_tbl.DeptPK
WHERE        (DepartmentMaster_tbl.IsActive = 'Y') AND (DepartmentLocation_tbl.BranchLctnPK = @Param1)
ORDER BY DepartmentMaster_tbl.DepartmentName ", con);
                cmd.Parameters.AddWithValue("@Param1", Program.LOCTNPK );

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
        public DataTable getAllLocDeptName()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT  DepartmentPK, DepartmentName FROM DepartmentMaster_tbl where IsActive='Y' ORDER BY DepartmentName ASC ", con);

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


 //**************************************************************************************************************************************************************************   
 
    class SubDepartmentTransaction
    {
        /// <summary>
        /// get alll the sub dept of a Department
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable getSubdepartment(int deptid)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     SubDeptName, SubDeptPK FROM         SubDepartmentMaster_tbl WHERE     (Deptid = @Param1)", con);

                cmd.Parameters.AddWithValue("@Param1", deptid);
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

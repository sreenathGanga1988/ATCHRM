using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections;
namespace ATCHRM.Transactions
{


    class CompanyBranchTransactions
    {

        /// <summary>
        /// insert new company data to database
        /// </summary>
        /// <param name="cmpdatbean"></param>
        public void insertcompanyDetails(Datalayer.CompanyDatabean cmpdatbean)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CompanyMaster_tbl (CompanyName ,CompanyCode ,CompanyLocationPK ,CompanyZipCode ,CompanyPhone,CompanyFax ,CompanyEmail,CompanyAdress1 ,CompanyAdress2,CompanyAddedDate,userpk)" +
                "values(@pcompanyName ,@pcompanyCode,@pcompanyLocationPK ,@pcompanyZipCode, @pcompanyPhone,@pcompanyFax ,@pcompanyEmail ,@pcompanyAdress1 ,@pcompanyAdress2, @pcompanyAddedDate,@puserpk )", con);

                cmd.Parameters.AddWithValue("@pcompanyName", cmpdatbean.Companyname);
                cmd.Parameters.AddWithValue("@pcompanyCode", cmpdatbean.Companycode);
                cmd.Parameters.AddWithValue("@pcompanyLocationPK", cmpdatbean.Locationpk);
                cmd.Parameters.AddWithValue("@pcompanyZipCode", cmpdatbean.Zipcode);
                cmd.Parameters.AddWithValue("@pcompanyPhone", cmpdatbean.Phoneno);

                cmd.Parameters.AddWithValue("@pcompanyFax", cmpdatbean.Faxno1);
                cmd.Parameters.AddWithValue("@pcompanyEmail", cmpdatbean.Email);
                cmd.Parameters.AddWithValue("@pcompanyAdress1", cmpdatbean.Adress11);
                cmd.Parameters.AddWithValue("@pcompanyAdress2", cmpdatbean.Adress21);
                cmd.Parameters.AddWithValue("@pcompanyAddedDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@puserpk", Program.USERPK);
                cmd.ExecuteNonQuery();
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
        /// updates the details of the specified company
        /// </summary>
        /// <param name="cmpdatbean"></param>
        public void UpdatecompanyDetails(Datalayer.CompanyDatabean cmpdatbean)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CompanyMaster_tbl SET CompanyName = @Param1, CompanyCode = @Param2, CompanyLocationPK = @Param3, CompanyZipCode = @Param4, CompanyPhone = @Param5,CompanyFax = @Param6, CompanyEmail = @Param7, CompanyAdress1 = @Param8, CompanyAdress2 = @Param9, CompanyAddedDate = @Param10, userpk = @Param11 WHERE(CompanyPk = @Param12)", con);

                cmd.Parameters.AddWithValue("@Param1", cmpdatbean.Companyname);
                cmd.Parameters.AddWithValue("@Param2", cmpdatbean.Companycode);
                cmd.Parameters.AddWithValue("@Param3", cmpdatbean.Locationpk);
                cmd.Parameters.AddWithValue("@Param4", cmpdatbean.Zipcode);
                cmd.Parameters.AddWithValue("@Param5", cmpdatbean.Phoneno);

                cmd.Parameters.AddWithValue("@Param6", cmpdatbean.Faxno1);
                cmd.Parameters.AddWithValue("@Param7", cmpdatbean.Email);
                cmd.Parameters.AddWithValue("@Param8", cmpdatbean.Adress11);
                cmd.Parameters.AddWithValue("@Param9", cmpdatbean.Adress21);
                cmd.Parameters.AddWithValue("@Param10", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param11", Program.USERPK);
                cmd.Parameters.AddWithValue("@Param12", cmpdatbean.Companypk);
                cmd.ExecuteNonQuery();
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
        /// select all company data from database for displaying in datagrid
        /// </summary>
        /// <returns></returns>
        public DataTable selectallcompanydata()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT CompanyMaster_tbl.CompanyPk AS SL, CompanyMaster_tbl.CompanyName AS NAME, CompanyMaster_tbl.CompanyCode AS CMPCODE, LocationMaster_tbl.CountryName AS COUNTRY, LocationMaster_tbl.StateName AS STATE, LocationMaster_tbl.CitName AS CITY, CompanyMaster_tbl.CompanyPhone AS PHONE, CompanyMaster_tbl.CompanyEmail AS EMAIL,CompanyMaster_tbl.CompanyFax AS FAX FROM CompanyMaster_tbl INNER JOIN LocationMaster_tbl ON CompanyMaster_tbl.CompanyLocationPK = LocationMaster_tbl.LocationPk", con);
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
        /// get the details of the specific company by giving companypk
        /// </summary>
        /// <param name="cmpnypk"></param>
        /// <returns></returns>

        public DataTable getallcompanydatabypk(int cmpnypk)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT CompanyMaster_tbl.CompanyPk , CompanyMaster_tbl.CompanyName, CompanyMaster_tbl.CompanyCode, CompanyMaster_tbl.CompanyZipCode, CompanyMaster_tbl.CompanyPhone, CompanyMaster_tbl.CompanyFax, CompanyMaster_tbl.CompanyEmail, CompanyMaster_tbl.CompanyAdress1, CompanyMaster_tbl.CompanyAdress2, LocationMaster_tbl.CountryName, LocationMaster_tbl.StateName, LocationMaster_tbl.CitName , LocationMaster_tbl.LocationPk"

+ " FROM CompanyMaster_tbl INNER JOIN LocationMaster_tbl ON CompanyMaster_tbl.CompanyLocationPK = LocationMaster_tbl.LocationPk WHERE (CompanyMaster_tbl.CompanyPk = @param1) ", con);
                cmd.Parameters.AddWithValue("@param1", cmpnypk);

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
        /// insert new location for a branch
        /// 
        /// </summary>
        /// <param name="lctndatabean"></param>

        public void insertBranchLocationDertails(Datalayer.locationBranchDatabean lctndatabean)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO BranchLocartionMaster_tbl (BranchLocationName, BranchLocationCode, BranchPk, LocationPk, BranchlLocationZip, BranchlLocationPhone, Fax, Email, Adress1, Adress2, BranchLocationAddedDate ,userpk)" +
"VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11 ,@Param12)", con);

                cmd.Parameters.AddWithValue("@Param1", lctndatabean.Branchname);
                cmd.Parameters.AddWithValue("@Param2", lctndatabean.Llocationcode);
                cmd.Parameters.AddWithValue("@Param3", lctndatabean.Branchpk);
                cmd.Parameters.AddWithValue("@Param4", lctndatabean.Lctnpk);
                cmd.Parameters.AddWithValue("@Param5", lctndatabean.Zipcode);

                cmd.Parameters.AddWithValue("@Param6", lctndatabean.Phoneno);
                cmd.Parameters.AddWithValue("@Param7", lctndatabean.Faxno);
                cmd.Parameters.AddWithValue("@Param8", lctndatabean.Email);
                cmd.Parameters.AddWithValue("@Param9", lctndatabean.Adress1);
                cmd.Parameters.AddWithValue("@Param10", lctndatabean.Adress2);
                cmd.Parameters.AddWithValue("@Param11", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param12", Program.USERPK);
                cmd.ExecuteNonQuery();
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
        /// INSERT THE NEW BRANCH DETAILS TO THE DATABASE
        /// </summary>
        /// <param name="brnchdatabean"></param>
        public void insertbranch(Datalayer.BranchDataBean brnchdatabean)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO BranchMaster_tbl(BranchName ,CompanyPk, LocationPk, BranchZipCode, BranchPhone, BranchFax, BranchEmail, BranchAdress1, BranchAdress2, BranchAddedDate, userpk) " +
                    "VALUES(@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10 ,@Param11)", con);

                cmd.Parameters.AddWithValue("@Param1", brnchdatabean.BranchName);
                cmd.Parameters.AddWithValue("@Param2", brnchdatabean.Companypk);
                cmd.Parameters.AddWithValue("@Param3", brnchdatabean.Lctnpk);
                cmd.Parameters.AddWithValue("@Param4", brnchdatabean.Zipcode);
                cmd.Parameters.AddWithValue("@Param5", brnchdatabean.Phoneno);

                cmd.Parameters.AddWithValue("@Param6", brnchdatabean.Faxno);
                cmd.Parameters.AddWithValue("@Param7", brnchdatabean.Email);
                cmd.Parameters.AddWithValue("@Param8", brnchdatabean.Adress1);
                cmd.Parameters.AddWithValue("@Param9", brnchdatabean.Adress2);
                cmd.Parameters.AddWithValue("@Param10", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param11", Program.USERPK);
                //   cmd.Parameters.AddWithValue("@Param12", Program.USERPK);
                cmd.ExecuteNonQuery();
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
        /// update details of a branch
        /// update criteria brancpk
        /// </summary>
        /// <param name="brnchdatabean"></param>
        public void updateBranch(Datalayer.BranchDataBean brnchdatabean)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE BranchMaster_tbl SET BranchName = @Param1, CompanyPk = @Param2, LocationPk = @Param3, BranchZipCode = @Param4, BranchPhone = @Param5, BranchFax = @Param6, BranchEmail = @Param7, BranchAdress1 = @Param8, BranchAdress2 = @Param9, BranchAddedDate = @Param10, userpk = @Param11 WHERE (BranchPK = @Param12)", con);

                cmd.Parameters.AddWithValue("@Param1", brnchdatabean.BranchName);
                cmd.Parameters.AddWithValue("@Param2", brnchdatabean.Companypk);
                cmd.Parameters.AddWithValue("@Param3", brnchdatabean.Lctnpk);
                cmd.Parameters.AddWithValue("@Param4", brnchdatabean.Zipcode);
                cmd.Parameters.AddWithValue("@Param5", brnchdatabean.Phoneno);

                cmd.Parameters.AddWithValue("@Param6", brnchdatabean.Faxno);
                cmd.Parameters.AddWithValue("@Param7", brnchdatabean.Email);
                cmd.Parameters.AddWithValue("@Param8", brnchdatabean.Adress1);
                cmd.Parameters.AddWithValue("@Param9", brnchdatabean.Adress2);
                cmd.Parameters.AddWithValue("@Param10", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param11", Program.USERPK);
                cmd.Parameters.AddWithValue("@Param12", brnchdatabean.Branchpk);
                cmd.ExecuteNonQuery();
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
        /// select all the branch data 
        /// </summary>
        /// <returns></returns>
        public DataTable selectallbranch()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT  BranchMaster_tbl.BranchPK AS SL, BranchMaster_tbl.BranchName AS BRANCH, CompanyMaster_tbl.CompanyName AS COMPANY, LocationMaster_tbl.CitName AS CITY, LocationMaster_tbl.StateName AS STATE, LocationMaster_tbl.CountryName AS COUNTRY, BranchMaster_tbl.BranchZipCode AS ZIPCODE, BranchMaster_tbl.BranchPhone AS PHONE, BranchMaster_tbl.BranchFax AS FAX, BranchMaster_tbl.BranchEmail AS EMAIL FROM CompanyMaster_tbl INNER JOIN  BranchMaster_tbl ON CompanyMaster_tbl.CompanyPk = BranchMaster_tbl.CompanyPk INNER JOIN  LocationMaster_tbl ON BranchMaster_tbl.LocationPk = LocationMaster_tbl.LocationPk", con);
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
        /// select all the data about a branch
        /// by pk
        /// </summary>
        /// <param name="branchpk"></param>
        /// <returns></returns>
        public DataTable getallBranchDatbyPK(int branchpk)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT CompanyMaster_tbl.CompanyName AS Cmpany, CompanyMaster_tbl.CompanyPk, BranchMaster_tbl.BranchName, BranchMaster_tbl.BranchPK, " +
                       " LocationMaster_tbl.CountryName, LocationMaster_tbl.StateName, LocationMaster_tbl.CitName, LocationMaster_tbl.LocationPk, BranchMaster_tbl.BranchZipCode, " +
                   "   BranchMaster_tbl.BranchPhone, BranchMaster_tbl.BranchFax, BranchMaster_tbl.BranchEmail FROM LocationMaster_tbl INNER JOIN BranchMaster_tbl ON LocationMaster_tbl.LocationPk = BranchMaster_tbl.LocationPk INNER JOIN  CompanyMaster_tbl ON BranchMaster_tbl.CompanyPk = CompanyMaster_tbl.CompanyPk WHERE BranchMaster_tbl.BranchPK = @param1", con);
                cmd.Parameters.AddWithValue("@param1", branchpk);

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
        /// select all branches
        /// </summary>
        /// <returns></returns>
        public DataTable selectalllocation()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();
                String Query = "SELECT  BranchLocartionMaster_tbl.BranchlLocationPk AS SL, BranchLocartionMaster_tbl.BranchLocationName AS LOCATION, " +
                      "BranchLocartionMaster_tbl.BranchLocationCode AS CODE, BranchMaster_tbl.BranchName AS BRANCH, LocationMaster_tbl.CountryName AS COUNTRY," +
                      "LocationMaster_tbl.StateName AS STATE, LocationMaster_tbl.CitName AS CITY, BranchLocartionMaster_tbl.BranchlLocationZip AS ZIPCODE," +
                      " BranchLocartionMaster_tbl.BranchlLocationPhone AS PHONE, BranchLocartionMaster_tbl.Fax AS FAX, BranchLocartionMaster_tbl.Email AS EMAIL, " +
                      "BranchLocartionMaster_tbl.Adress1 AS ADRESS1" +
                     " FROM   BranchLocartionMaster_tbl INNER JOIN BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN  LocationMaster_tbl ON BranchLocartionMaster_tbl.LocationPk = LocationMaster_tbl.LocationPk";

                SqlCommand cmd = new SqlCommand(Query, con);
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
        /// get the location of a single location
        /// </summary>
        /// <param name="locationPK"></param>
        /// <returns></returns>
        public DataTable getLocationdatabyPk(int locationPK)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT     BranchMaster_tbl.BranchName, BranchMaster_tbl.BranchPK, BranchLocartionMaster_tbl.BranchLocationName, BranchLocartionMaster_tbl.BranchlLocationPk," +
" BranchLocartionMaster_tbl.Adress1, BranchLocartionMaster_tbl.Adress2, LocationMaster_tbl.CountryName, LocationMaster_tbl.StateName, " +
"LocationMaster_tbl.CitName, LocationMaster_tbl.LocationPk, BranchLocartionMaster_tbl.BranchlLocationZip, BranchLocartionMaster_tbl.BranchlLocationPhone, BranchLocartionMaster_tbl.Fax, BranchLocartionMaster_tbl.Email " +
" FROM  BranchLocartionMaster_tbl INNER JOIN  BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN  LocationMaster_tbl ON BranchLocartionMaster_tbl.LocationPk = LocationMaster_tbl.LocationPk WHERE     (BranchLocartionMaster_tbl.BranchlLocationPk= @Param1)", con);

                cmd.Parameters.AddWithValue("@param1", locationPK);

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

        public void updateBranchLocationDertails(Datalayer.locationBranchDatabean lctndatabean)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE BranchLocartionMaster_tbl SET BranchLocationName = @Param1,  BranchPk = @Param3, LocationPk = @Param4, BranchlLocationZip = @Param5, BranchlLocationPhone = @Param6, Fax = @Param7, Email = @Param8, Adress1 = @Param9, Adress2 = @Param10, BranchLocationAddedDate = @Param11,  userpk = @Param12 WHERE  (BranchlLocationPk = @Param13)", con);

                cmd.Parameters.AddWithValue("@Param1", lctndatabean.Branchname);
                //   cmd.Parameters.AddWithValue("@Param2", lctndatabean.Llocationcode);
                cmd.Parameters.AddWithValue("@Param3", lctndatabean.Branchpk);
                cmd.Parameters.AddWithValue("@Param4", lctndatabean.Lctnpk);
                cmd.Parameters.AddWithValue("@Param5", lctndatabean.Zipcode);

                cmd.Parameters.AddWithValue("@Param6", lctndatabean.Phoneno);
                cmd.Parameters.AddWithValue("@Param7", lctndatabean.Faxno);
                cmd.Parameters.AddWithValue("@Param8", lctndatabean.Email);
                cmd.Parameters.AddWithValue("@Param9", lctndatabean.Adress1);
                cmd.Parameters.AddWithValue("@Param10", lctndatabean.Adress2);
                cmd.Parameters.AddWithValue("@Param11", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param12", Program.USERPK);
                cmd.Parameters.AddWithValue("@Param13", lctndatabean.Locationpk);
                cmd.ExecuteNonQuery();
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
/// get the Location and branch agaist each
/// company and congat them to give a single String
/// 
/// </summary>
/// <param name="cmpPK"></param>
/// <returns></returns>
        public DataTable getBranchLocationDetails(int cmpPK)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT     BranchMaster_tbl.BranchName +'--'+ BranchLocartionMaster_tbl.BranchLocationName AS LOCATION, BranchLocartionMaster_tbl.BranchlLocationPk AS SL" +
                    " FROM BranchLocartionMaster_tbl INNER JOIN  BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK WHERE (BranchMaster_tbl.CompanyPk =@param1) ", con);

                cmd.Parameters.AddWithValue("@param1", cmpPK);

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
        /// get the Location and branch
        /// and congat them to give a single String
        /// 
        /// </summary>
        /// <param name="cmpPK"></param>
        /// <returns></returns>
        /// 
        public DataTable getAllBranchLocationDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT     BranchMaster_tbl.BranchName +'--'+ BranchLocartionMaster_tbl.BranchLocationName AS LOCATION, BranchLocartionMaster_tbl.BranchlLocationPk AS SL" +
                    " FROM BranchLocartionMaster_tbl INNER JOIN  BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK  ", con);

              

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



    }


    class BankTransactions
    {

        public void insertbankData(Datalayer.BankDataBean bnkdatabean)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO BankMaster_tbl (BankName, BranchName, BranchCode, Adress1, Adress2, LocationPK, Zipcode, Phonenum, Faxnum, Email, Swiftrcode, dateadded, userPK)" +
                " VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13)", con);

                cmd.Parameters.AddWithValue("@Param1", bnkdatabean.BankName);
                cmd.Parameters.AddWithValue("@Param2", bnkdatabean.BankbranchName);
                cmd.Parameters.AddWithValue("@Param3", bnkdatabean.Branchcode);
                cmd.Parameters.AddWithValue("@Param4", bnkdatabean.Adress1);
                cmd.Parameters.AddWithValue("@Param5", bnkdatabean.Adress2);

                cmd.Parameters.AddWithValue("@Param6", bnkdatabean.Lctnpk);
                cmd.Parameters.AddWithValue("@Param7", bnkdatabean.Zipcode);
                cmd.Parameters.AddWithValue("@Param8", bnkdatabean.Phonenum);
                cmd.Parameters.AddWithValue("@Param9", bnkdatabean.Faxnum);

                cmd.Parameters.AddWithValue("@Param10", bnkdatabean.Email);
                cmd.Parameters.AddWithValue("@Param11", bnkdatabean.Swiftcode);
                cmd.Parameters.AddWithValue("@Param12", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param13", Program.USERPK);
                cmd.ExecuteNonQuery();
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

        /// select all Bank data from database for displaying in datagrid
        /// </summary>
        /// <returns></returns>
        public DataTable selectallBankdata()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT BankMaster_tbl.BankPK AS Sl , BankMaster_tbl.BankName AS [Bank Name] , BankMaster_tbl.BranchName AS Branch, BankMaster_tbl.BranchCode AS [Branch Code] , BankMaster_tbl.Swiftrcode AS [Swift Code] , " +
                    " LocationMaster_tbl.CitName AS City , LocationMaster_tbl.StateName AS State , LocationMaster_tbl.CountryName AS Country, BankMaster_tbl.Adress1 AS Address ,BankMaster_tbl.Email AS Email  , BankMaster_tbl.Phonenum AS [Phone #]  FROM BankMaster_tbl INNER JOIN LocationMaster_tbl ON BankMaster_tbl.LocationPK = LocationMaster_tbl.LocationPk", con);
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
        /// select all the data about a  bank branch
        /// by pk
        /// </summary>
        /// <param name="branchpk"></param>
        /// <returns></returns>
        public DataTable getbankdatabypk(int bnkpk)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT  BankMaster_tbl.BankPK, BankMaster_tbl.BankName, BankMaster_tbl.BranchName, BankMaster_tbl.BranchCode, BankMaster_tbl.Adress1, BankMaster_tbl.Adress2, " +
" LocationMaster_tbl.CountryName, LocationMaster_tbl.StateName, LocationMaster_tbl.CitName, BankMaster_tbl.Zipcode, BankMaster_tbl.Phonenum,  " +
" BankMaster_tbl.Faxnum, BankMaster_tbl.Email, BankMaster_tbl.Swiftrcode " +
"FROM BankMaster_tbl INNER JOIN LocationMaster_tbl ON BankMaster_tbl.LocationPK = LocationMaster_tbl.LocationPk WHERE (BankMaster_tbl.BankPK = @Param1) ", con);

                cmd.Parameters.AddWithValue("@param1", bnkpk);

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


       public void updateBranchLocationDertails(Datalayer.BankDataBean bnkdatabean)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE BankMaster_tbl SET BankName = @Param2, BranchName = @Param3, BranchCode = @Param4, Adress1 = @Param5, Adress2 = @Param6, Zipcode = @Param7, Phonenum = @Param8, " +
                    " Faxnum = @Param9, Email = @Param10, Swiftrcode = @Param11, dateadded = @Param12, userPK = @Param13 WHERE (BankPK = @Param1)", con);

                cmd.Parameters.AddWithValue("@Param1", bnkdatabean.Bankpk);
                cmd.Parameters.AddWithValue("@Param2", bnkdatabean.BankName);
                cmd.Parameters.AddWithValue("@Param3", bnkdatabean.BankbranchName);
                cmd.Parameters.AddWithValue("@Param4", bnkdatabean.Branchcode);
                cmd.Parameters.AddWithValue("@Param5", bnkdatabean.Adress1);

                cmd.Parameters.AddWithValue("@Param6", bnkdatabean.Adress2);
                cmd.Parameters.AddWithValue("@Param7", bnkdatabean.Zipcode);
                cmd.Parameters.AddWithValue("@Param8", bnkdatabean.Phonenum);
                cmd.Parameters.AddWithValue("@Param9", bnkdatabean.Faxnum);
                cmd.Parameters.AddWithValue("@Param10", bnkdatabean.Email);
                cmd.Parameters.AddWithValue("@Param11", bnkdatabean.Swiftcode);
                cmd.Parameters.AddWithValue("@Param12", DateTime.Now.Date);
                 cmd.Parameters.AddWithValue("@Param13", Program.USERPK);
             
                 cmd.ExecuteNonQuery();
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
        /// get bankcode +branchname+Bank name  and code
        /// </summary> for combobox loads
        /// <returns></returns>
       public DataTable getallbanknameandcode()
       {
           DataTable dt = new DataTable();
           SqlConnection con = new SqlConnection(Program.ConnStr);

           try
           {


               con.Open();


               SqlCommand cmd = new SqlCommand("SELECT     BankPK as pk, BranchCode+' - '+BranchName+' -'+BankName as bnkname FROM BankMaster_tbl ", con);

              

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


    }
    class DeptTransaction
    {
        public void InsertDepartment(Datalayer.DepartmentDatabean dept)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DepartmentMaster_tbl(DepartmentName)VALUES     (@Param1)", con);

                cmd.Parameters.AddWithValue("@Param1", dept.DepartmentName );
                
                cmd.ExecuteNonQuery();
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


        public DataTable getAllDept()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT     DepartmentPK AS SL, DepartmentName AS DEPT FROM  DepartmentMaster_tbl where IsActive='Y'", con);



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

        public void InsertSubDepartment(Datalayer.SubDepartmentID dept)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SubDepartmentMaster_tbl(SubDeptName, Deptid)VALUES     (@Param1,@Param2)", con);

                cmd.Parameters.AddWithValue("@Param1", dept.Subdeptname1 );
                cmd.Parameters.AddWithValue("@Param2", dept.Deptid);
                cmd.ExecuteNonQuery();
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

        public DataTable getAllSubDept()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT     SubDepartmentMaster_tbl.SubDeptPK AS SL, SubDepartmentMaster_tbl.SubDeptName AS SUB_DEPT,"+
                     " DepartmentMaster_tbl.DepartmentName AS DEPT "+
"FROM         SubDepartmentMaster_tbl INNER JOIN "+
                    "  DepartmentMaster_tbl ON SubDepartmentMaster_tbl.Deptid = DepartmentMaster_tbl.DepartmentPK ", con);



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
        /// insert a qualification
        /// </summary>
        /// <param name="QualificationName"></param>
        /// <param name="QualificationlevelPK"></param>
        public void InsertQualification(String QualificationName, int QualificationlevelPK)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Qualification_master (QualificationName, LevelPK) VALUES      (@Param1,@Param2)", con);

                cmd.Parameters.AddWithValue("@Param1", QualificationName);
                cmd.Parameters.AddWithValue("@Param2",  QualificationlevelPK);
                cmd.ExecuteNonQuery();
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
        /// Get all the Qualification LEVEL
        /// </summary>
        /// <returns></returns>
        public DataTable GetallQualificationLEVEL()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT     QualificationLevelPK AS SL, QualificationLevel AS Qual FROM  QualificationLevel_tbl ", con);



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
        /// GET ALL QUALIFICATION
        /// </summary>
        /// <returns></returns>
        public DataTable GetallQualification()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        Qualification_master.QualificationID AS SL, Qualification_master.QualificationName AS QUALIFICATION, 
                         QualificationLevel_tbl.QualificationLevel AS [QUALIFICATION LEVEL]
FROM            Qualification_master INNER JOIN
                         QualificationLevel_tbl ON Qualification_master.LevelPK = QualificationLevel_tbl.QualificationLevelPK ", con);



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



    }
}

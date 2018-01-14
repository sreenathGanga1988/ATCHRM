using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace ATCHRM.Transactions
{
  
    class DesignationTransaction
    {
        Transactions.AnycodeAutoGenerator anycodegenarator = null;
        
        /// <summary>
        /// insert designation Details
        /// </summary>
        /// <param name="dsgdatabean"></param>
        public void insertDesignastionData(Datalayer.DesignationDatabean dsgdatabean)
        {
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int id;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO DesignationMaster_tbl (DesignationName, Descripton, GradeLevel, DepartmentPK, Basicsal, CurrencyPK, userPk, DateAdded,BranchLctnPk) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9);SELECT SCOPE_IDENTITY()", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", dsgdatabean.DesignationName1);
                        command.Parameters.AddWithValue("@Param2", dsgdatabean.Description1);
                        command.Parameters.AddWithValue("@Param3", dsgdatabean.Levelno1);
                        command.Parameters.AddWithValue("@Param4", dsgdatabean.Departmentpk);
                        command.Parameters.AddWithValue("@Param5", dsgdatabean.Basicsal);
                        command.Parameters.AddWithValue("@Param6", dsgdatabean.Currencypk);
                        command.Parameters.AddWithValue("@Param7", Program.USERPK);
                        command.Parameters.AddWithValue("@Param8", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param9", dsgdatabean.Desgtype);
                        id = int.Parse(command.ExecuteScalar().ToString());

                    }

                    sqlConnection1.Close();

                    insertleaveandSalComp(id, dsgdatabean);

                }

            }
            catch (Exception exp)
            {

                throw exp;
            }

        }

        /// <summary>
        /// insert all the salary component and Leave against the Designation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dsgdatabean"></param>
        public void insertleaveandSalComp(int id, Datalayer.DesignationDatabean dsgdatabean)
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection2 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection2.Open();
                sqltrnsctn = sqlConnection2.BeginTransaction();


                try
                {

                     for (int i = 0; i < dsgdatabean.Appsal.Salcompid1.Count ; i++)
                    {
                        using (SqlCommand command1 = new SqlCommand("INSERT INTO DesgnationSalComponent_tbl (DesignationPK, salcompPk, Amount) VALUES (@Param1,@Param2,@Param3)", sqlConnection2))
                        {
                            command1.Transaction = sqltrnsctn;
                            command1.Parameters.AddWithValue("@Param1", id);
                            command1.Parameters.AddWithValue("@Param2", dsgdatabean.Appsal.Salcompid1[i]);
                            command1.Parameters.AddWithValue("@Param3", dsgdatabean.Appsal.SaCompAmount[i]);
                            command1.ExecuteNonQuery();
                        }
                    }



                     for (int i = 0; i < dsgdatabean.Appsal.Applicableleave.Count; i++)
                     {
                         using (SqlCommand command2 = new SqlCommand("INSERT INTO DesignationLeave_tbl (DesgnationPK, LeavePk)VALUES(@Param1,@Param2)", sqlConnection2))
                         {
                             command2.Transaction = sqltrnsctn;
                             command2.Parameters.AddWithValue("@Param1", id);
                             command2.Parameters.AddWithValue("@Param2", dsgdatabean.Appsal.Applicableleave[i]);

                             command2.ExecuteNonQuery();
                         }
                     }







                     sqltrnsctn.Commit();
                }  catch (SqlException sqlError)
                {
                     sqltrnsctn.Rollback();

                     throw sqlError;
                 }

                sqlConnection2.Close();

                  
                }
        }
        /// <summary>
        /// get all the designation entered against the 
        ///
        /// </summary>
        /// <returns></returns>
        public DataTable getAllDesignationData()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     DesignationMaster_tbl.DesgnationPK AS SL, DesignationMaster_tbl.DesignationName AS Designation, DesignationMaster_tbl.Descripton AS [Job Details],  "+
                    " DesignationMaster_tbl.GradeLevel, DepartmentMaster_tbl.DepartmentName AS Dept, DesignationMaster_tbl.Basicsal AS BasicSal,  CurrencyMaster_tbl.Name AS Currency , DesignationMaster_tbl.IsOtApplicable  " +
                    "FROM  DesignationMaster_tbl INNER JOIN " +
                    "  DepartmentMaster_tbl ON DesignationMaster_tbl.DepartmentPK = DepartmentMaster_tbl.DepartmentPK INNER JOIN "+
                    " CurrencyMaster_tbl ON DesignationMaster_tbl.CurrencyPK = CurrencyMaster_tbl.Currency_Pk", con);

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
        /// returns the Designations entered against each
        /// Department
        /// </summary>
        /// <param name="DeptPk"></param>
        /// <returns></returns>
        public DataTable getDesignationNameBYDept(int DeptPk)
        {
        
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                int lctn= 0;
                if (Program.LOCTNPK == 22)
                {
                    lctn = 22;
                }
                else
                {
                    lctn = 0;
                }


                using (SqlCommand command = new SqlCommand("SELECT     DesignationName AS DESGN , DesgnationPK  AS SL FROM  DesignationMaster_tbl WHERE (DepartmentPK = @Param1) AND ISACTIVE='Y' AND (BranchLctnPk = @Param2)", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@Param1",DeptPk);
                    command.Parameters.AddWithValue("@Param2", lctn);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();

                    dt.Load(reader);
                    sqlConnection1.Close();
                    return dt;
                   
                }


            }





        }



        public String designationchangeApplication(Datalayer.EmployeeDesignationDataBean empdesgdatabean)
        {


            anycodegenarator = new AnycodeAutoGenerator();
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int DsgAppid;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand(" INSERT INTO DesignationChangeApplication_tbl (empid, BranchlctnPK, DeptPk, DesgnPK, Reason, Userpk, DateAdded) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7) ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empdesgdatabean.Empid );
                        command.Parameters.AddWithValue("@Param2", empdesgdatabean.Lctnid );
                        command.Parameters.AddWithValue("@Param3", empdesgdatabean.Deptid );
                        command.Parameters.AddWithValue("@Param4", empdesgdatabean.Desgid);

                        command.Parameters.AddWithValue("@Param5", empdesgdatabean.Reason );
                        command.Parameters.AddWithValue("@Param7",DateTime.Now.Date );
                        command.Parameters.AddWithValue("@Param6", Program.USERPK);

                    DsgAppid = int.Parse(command.ExecuteScalar().ToString());

                    }




                    sqlConnection1.Close();
                    String Desgapplicationcode = anycodegenarator.DesgApplicationcodegenerator(DsgAppid);
                    String updatedappnum = UpdateandApproveDesgChange(Desgapplicationcode, DsgAppid);
                    return updatedappnum;
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }



           


        }





        public String UpdateandApproveDesgChange(String Desgapplicationcode, int DsgAppid )
        {

            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection2 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection2.Open();
                sqltrnsctn = sqlConnection2.BeginTransaction();


                try
                {


                    using (SqlCommand command1 = new SqlCommand(" UPDATE    DesignationChangeApplication_tbl SET  Appnum = @Param1 WHERE     (DesgAppPk = @Param2)", sqlConnection2))
                    {
                        command1.Transaction = sqltrnsctn;
                        command1.Parameters.AddWithValue("@Param1", Desgapplicationcode);
                        command1.Parameters.AddWithValue("@Param2", DsgAppid);

                        command1.ExecuteNonQuery();
                    }





                    using (SqlCommand command2 = new SqlCommand(" INSERT INTO DesignationApprovalMaster_tbl (DsgAppPk)VALUES (@Param5) ", sqlConnection2))
                    {
                        command2.Transaction = sqltrnsctn;
                        command2.Parameters.AddWithValue("@Param5", DsgAppid);


                        command2.ExecuteNonQuery();
                    }


                   





                    sqltrnsctn.Commit();


                    return Desgapplicationcode;
                }
                catch (SqlException sqlError)
                {
                    sqltrnsctn.Rollback();

                    throw sqlError;
                }
                finally
                {
                    sqlConnection2.Close();

                }


            }
        }



        /// <summary>
        ///getAllApproveDesignationChangeApplication of employees with employe id 
        /// </summary>
        /// <returns></returns>
        public DataTable getAllApproveDApplication(int empid , String applicationtype)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetAllApprovedApplication_sp ", con);

                cmd.Parameters.AddWithValue("@Applicationtype", applicationtype);
                cmd.Parameters.AddWithValue("@employeeid", empid);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }





        /// <summary>
        /// deletes all the existing leaves and update the existing 
        /// leaves
        /// </summary>
        /// <param name="leavpk"></param>
        /// <param name="desgpk"></param>

        public void UpdateLeaveOfDesignation(ArrayList leavpk  , int desgpk , ArrayList Desigdata)
        {
            SqlTransaction sqltrnsctn;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                sqltrnsctn = sqlConnection1.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE DesignationMaster_tbl SET DesignationName = @Param1, Descripton = @Param2, GradeLevel = @Param3, Basicsal = @Param4, CurrencyPK = @Param5, userPk = @Param6, DateAdded = @Param7  WHERE (DesgnationPK = @Param8) ", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", Desigdata[0]);
                        command.Parameters.AddWithValue("@Param2", Desigdata[1]);
                        command.Parameters.AddWithValue("@Param3", Desigdata[2]);
                        command.Parameters.AddWithValue("@Param4", Desigdata[3]);
                        command.Parameters.AddWithValue("@Param5", Desigdata[4]);
                        command.Parameters.AddWithValue("@Param6", Program.USERPK );
                        command.Parameters.AddWithValue("@Param7", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param8", desgpk);
                        command.ExecuteNonQuery();





                    }



                    using (SqlCommand command = new SqlCommand("DELETE FROM DesignationLeave_tbl WHERE  (DesgnationPK = @Param1) ", sqlConnection1))
                    {
                        command.Transaction = sqltrnsctn;
                        command.Parameters.AddWithValue("@Param1", desgpk);
                        command.ExecuteNonQuery();





                    }
                    for (int i = 0; i < leavpk.Count; i++)
                    {

                        using (SqlCommand command1 = new SqlCommand("INSERT INTO DesignationLeave_tbl (DesgnationPK, LeavePk) VALUES (@Param1,@Param2) ", sqlConnection1))
                        {
                            command1.Transaction = sqltrnsctn;
                            command1.Parameters.AddWithValue("@Param1", desgpk);

                            command1.Parameters.AddWithValue("@Param2", int.Parse(leavpk[i].ToString()));

                            command1.ExecuteNonQuery();



                        }
                    }
                    sqltrnsctn.Commit();



                }
                catch (Exception exp)
                {

                    sqltrnsctn.Rollback();

                    throw exp;
                }
                sqlConnection1.Close();
            }
         
        }




















    }
        }












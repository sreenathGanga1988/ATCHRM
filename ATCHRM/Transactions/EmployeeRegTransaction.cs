using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;
namespace ATCHRM.Transactions
{
    class EmployeeRegTransaction
    {
        /// <summary>
        /// insert employe contract data
        /// 
        /// </summary>
        /// <param name="empcontractdatabeasn"></param>
        public void insertEmployeeContractdetails(Datalayer.EmployeeContractDatabean empcontractdatabeasn, String applicatontype)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);


            con.Open();

            try
            {
                if (applicatontype == "Add")
                {




                    SqlCommand cmd = new SqlCommand(" INSERT INTO EmpContract_tbl (EmpId, ContractType, Startdate, Endtime, ExtendedTime ,UserPK, ActualJoiningDate) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", con);

                    cmd.Parameters.AddWithValue("@Param1", empcontractdatabeasn.Empid);
                    cmd.Parameters.AddWithValue("@Param2", empcontractdatabeasn.Contractype);
                    cmd.Parameters.AddWithValue("@Param4", empcontractdatabeasn.Endtime);
                    cmd.Parameters.AddWithValue("@Param5", empcontractdatabeasn.Extendeddate);
                    cmd.Parameters.AddWithValue("@Param3", empcontractdatabeasn.Startime);
                    cmd.Parameters.AddWithValue("@Param6", Program.USERPK);
                    cmd.Parameters.AddWithValue("@Param7", empcontractdatabeasn.Actualjoinigdate);
                    cmd.ExecuteNonQuery();
                }

                else if (applicatontype == "Contract Change")
                {


                    SqlCommand cmd = new SqlCommand("UpdateEmployeeContract_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empid", empcontractdatabeasn.Empid);
                    cmd.Parameters.AddWithValue("@contracttype", empcontractdatabeasn.Contractype);
                    cmd.Parameters.AddWithValue("@enddate", empcontractdatabeasn.Endtime);
                    cmd.Parameters.AddWithValue("@extendeddate", empcontractdatabeasn.Extendeddate);
                    cmd.Parameters.AddWithValue("@startdate", empcontractdatabeasn.Startime);
                    cmd.Parameters.AddWithValue("@applicationid", empcontractdatabeasn.ContractchangeAppid1);
                    cmd.Parameters.AddWithValue("@Applicationtype", applicatontype);
                    cmd.Parameters.AddWithValue("@userpk ", Program.USERPK);

                    cmd.Parameters.AddWithValue("@actualjoindate", empcontractdatabeasn.Actualjoinigdate);
                    cmd.ExecuteNonQuery();
















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



        public void insertEmployeeContractdetApplication(Datalayer.EmployeeContractDatabean empcontractdatabeasn, String applicatontype)
        {





           using( SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr))
           {

               EmpContractChangeApp_tbl empapp = new EmpContractChangeApp_tbl(); 
               empapp.EmpId=empcontractdatabeasn.Empid;
               empapp.ContractType=empcontractdatabeasn.Contractype;
               empapp.Endtime=empcontractdatabeasn.Endtime;
               empapp.ExtendedTime=empcontractdatabeasn.Extendeddate;
                empapp.Startdate=empcontractdatabeasn.Startime;
               empapp.ExtendedTime=empcontractdatabeasn.Extendeddate;
               empapp.ActualJoiningDate = empcontractdatabeasn.Actualjoinigdate;
               empapp.ApplicationType = applicatontype;
               empapp.Dateadded=DateTime.Now;
             empapp.UserPK=Program.USERPK;
             empapp.IsLevel1 = 'N';
             empapp.IsLevel2 = 'N';
               empapp.IsLevel3 = 'N';



               cntxt.EmpContractChangeApp_tbls.InsertOnSubmit (empapp);

               cntxt.SubmitChanges ();
              
                            


           }       
              
            //SqlConnection con = new SqlConnection(Program.ConnStr);


            //con.Open();

            //try
            //{
                


            //        SqlCommand cmd = new SqlCommand("UpdateEmployeeContract_sp", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@empid", empcontractdatabeasn.Empid);
            //        cmd.Parameters.AddWithValue("@contracttype", empcontractdatabeasn.Contractype);
            //        cmd.Parameters.AddWithValue("@enddate", empcontractdatabeasn.Endtime);
            //        cmd.Parameters.AddWithValue("@extendeddate", empcontractdatabeasn.Extendeddate);
            //        cmd.Parameters.AddWithValue("@startdate", empcontractdatabeasn.Startime);
            //        cmd.Parameters.AddWithValue("@applicationid", empcontractdatabeasn.ContractchangeAppid1);
            //        cmd.Parameters.AddWithValue("@Applicationtype", applicatontype);
            //        cmd.Parameters.AddWithValue("@userpk ", Program.USERPK);

            //        cmd.Parameters.AddWithValue("@actualjoindate", empcontractdatabeasn.Actualjoinigdate);
            //        cmd.ExecuteNonQuery();
               


            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    con.Close();

            //}
        }
        
        
        
        
        
        /// <summary>
        /// get all the non active employee
        /// also employees whos data is not finished
        /// </summary>
        public DataTable nonactiveemployee()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT     empid, empno FROM         EmployeePersonalMaster_tbl WHERE    (Status = N'N') ", con);

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
        /// <summary>
        /// get all the  active employee
        /// also employees whos contract is approved
        /// </summary>
        public DataTable getActiveEmployee()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT     empid, empno FROM         EmployeePersonalMaster_tbl WHERE    (Status = N'A') ", con);

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
        /// <summary>
        /// recruitmentcode and Recruitid of employye
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getRecruidmentCodeandIDofEmployee(int empid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT     EmployeePersonalMaster_tbl.Rec_Id, RecruitmentCodeMaster_tbl.EmpInternalCode " +
" FROM         EmployeePersonalMaster_tbl INNER JOIN " +
                    "  RecruitmentCodeMaster_tbl ON EmployeePersonalMaster_tbl.Rec_Id = RecruitmentCodeMaster_tbl.RecruitmentCodePK " +
"WHERE     (EmployeePersonalMaster_tbl.empid = @Param1)", con);

                    cmd.Parameters.AddWithValue("@Param1", empid);
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
        /// <summary>
        /// insert employe designation and location data
        /// 
        /// </summary>
        /// <param name="empcontractdatabeasn"></param>
        public void insertEmployeeDesignation(Datalayer.EmployeeDesignationDataBean empdsgbean, String actiontype)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                if (actiontype == "ADD")
                {
                    SqlCommand cmd = new SqlCommand(" INSERT INTO EmployeeDesignation_tbl (empid, BranchLocationPK, DesignationPk, DepartmeentPk ,Userpk,subdeptPk) VALUES (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", con);

                    cmd.Parameters.AddWithValue("@Param1", empdsgbean.Empid);
                    cmd.Parameters.AddWithValue("@Param2", empdsgbean.Lctnid);
                    cmd.Parameters.AddWithValue("@Param3", empdsgbean.Desgid);
                    cmd.Parameters.AddWithValue("@Param4", empdsgbean.Deptid);
                    cmd.Parameters.AddWithValue("@Param5", Program.USERPK);
                    cmd.Parameters.AddWithValue("@Param6", empdsgbean.SubdeptPk);
                    cmd.ExecuteNonQuery();
                }


                else if (actiontype == "EDIT")
                {
                    SqlCommand cmd = new SqlCommand("UpdateEmployeeDesignation_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empid", empdsgbean.Empid);
                    cmd.Parameters.AddWithValue("@branchlctnpk", empdsgbean.Lctnid);
                    cmd.Parameters.AddWithValue("@desginationpk", empdsgbean.Desgid);
                    cmd.Parameters.AddWithValue("@deptpk", empdsgbean.Deptid);
                    cmd.Parameters.AddWithValue("@userpk", Program.USERPK);
                    cmd.Parameters.AddWithValue("@changeappid", empdsgbean.DesgchangeAppid);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }
            finally
            {
                con.Close();

            }
        }
        /// <summary>
        /// create the employee id
        /// </summary>
        /// <returns></returns>
        public string Emp_id()
        {
            AnycodeAutoGenerator anyc = new AnycodeAutoGenerator();
            string id = "";
            SqlConnection con = new SqlConnection(Program.ConnStr);
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            com.CommandText = "select max(empid) from EmployeePersonalMaster_tbl";
            da.Fill(ds);
            if (ds.Tables[0].Rows[0][0] == DBNull.Value)
            {
                id = anyc.EmployeeInternalcodegenerator(Program.LOCATIONCODE, 1);

            }
            else
            {
                id = anyc.EmployeeInternalcodegenerator(Program.LOCATIONCODE, Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1);
            }
            return id;
        }
        /// <summary>
        ///  Assigns the recruitmentcode status to Assigned  if it is Employee is created against it
        /// </summary>
        /// <param name="recruitmentcode"></param>
        public void AssignRecruitmentcode(int recruitmentcode)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE    RecruitmentCodeMaster_tbl SET  Status = @Param2 WHERE (RecruitmentCodePK = @Param1) ", con);
                // cmd.Parameters.AddWithValue("@eid", empdatabean.Empid);
                cmd.Parameters.AddWithValue("@Param1", recruitmentcode);

                cmd.Parameters.AddWithValue("@Param2", "A");
                cmd.ExecuteNonQuery();

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }
            finally
            {
                con.Close();

            }
        }
        /// <summary>
        /// Assigns the recruitmentcode status to used if it is selected by abyuser
        /// </summary>
        /// <param name="recruitmentcode"></param>
        public void UsingRecruitmentcode(int recruitmentcode)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE    RecruitmentCodeMaster_tbl SET  Status = @Param2 WHERE (RecruitmentCodePK = @Param1) ", con);
                // cmd.Parameters.AddWithValue("@eid", empdatabean.Empid);
                cmd.Parameters.AddWithValue("@Param1", recruitmentcode);

                cmd.Parameters.AddWithValue("@Param2", "U");
                cmd.ExecuteNonQuery();

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }
            finally
            {
                con.Close();

            }
        }

        /// <summary>
        /// remove fromlist of pending
        /// </summary>
        /// <param name="appid"></param>
        public void removefromPENDINDETAILlist(int EMPID)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl SET  Showpending = N'N' WHERE     (empid = @Param1)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", EMPID);


                    command.ExecuteNonQuery();

                }

                sqlConnection1.Close();
            }

        }

        /// <summary>
        /// rELASE  the recruitmentcode status to wAITING  if it is selected by abyuser
        /// </summary>
        /// <param name="recruitmentcode"></param>
        public void releaseRecruitmentcode(int recruitmentcode)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE    RecruitmentCodeMaster_tbl SET  Status = @Param2 WHERE (RecruitmentCodePK = @Param1) ", con);
                // cmd.Parameters.AddWithValue("@eid", empdatabean.Empid);
                cmd.Parameters.AddWithValue("@Param1", recruitmentcode);

                cmd.Parameters.AddWithValue("@Param2", "W");
                cmd.ExecuteNonQuery();

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }
            finally
            {
                con.Close();

            }
        }

        /// <summary>
        /// get the contract details against  the given Employee FROM RECRUITMENT DETAILS
        /// </summary>
        public DataTable getcontrctrecruitdetails(int emppk, int recid)
        {


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                DataTable dt = new DataTable();
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT EmployeePersonalMaster_tbl.empid,EmployeePersonalMaster_tbl.empno, RecruitmentCodeMaster_tbl.RecruitmentCodePK, RecruitmentApplicationMaster_tbl.Applicationnum, RecruitmentApplicationMaster_tbl.Contracttype, EmployeePersonalMaster_tbl.Rec_Id " +
                        "  FROM  RecruitmentApplicationMaster_tbl INNER JOIN  EmployeePersonalMaster_tbl INNER JOIN RecruitmentCodeMaster_tbl ON EmployeePersonalMaster_tbl.Rec_Id = RecruitmentCodeMaster_tbl.RecruitmentCodePK ON " +
                        " RecruitmentApplicationMaster_tbl.RecruitmentAppPk = RecruitmentCodeMaster_tbl.RecruitmentPK WHERE (EmployeePersonalMaster_tbl.empid = @Param1) AND (EmployeePersonalMaster_tbl.Rec_Id = @Param2)  ", con);
                    cmd.Parameters.AddWithValue("@Param1", emppk);
                    cmd.Parameters.AddWithValue("@Param2", recid);
                    SqlDataReader reader = cmd.ExecuteReader();


                    dt.Load(reader);
                    return dt;

                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }
                finally
                {
                    con.Close();

                }

                return dt;

            }

        }

        /// <summary>
        /// get type and joining date of an recruitment id
        /// </summary>
        /// <param name="recid"></param>
        /// <returns></returns>
        public DataTable getcontracttypeofarecruitment(int recid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT     RecruitmentCodeMaster_tbl.RecruitmentCodePK,  RecruitmentApplicationMaster_tbl.Contracttype, " +
                 "     RecruitmentApplicationMaster_tbl.JoiningDate " +
"FROM         RecruitmentApplicationMaster_tbl INNER JOIN " +
                "      RecruitmentCodeMaster_tbl ON RecruitmentApplicationMaster_tbl.RecruitmentAppPk = RecruitmentCodeMaster_tbl.RecruitmentPK " +
"WHERE     (RecruitmentCodeMaster_tbl.RecruitmentCodePK = @Param1) ", con);

                    cmd.Parameters.AddWithValue("@Param1", recid);
                    SqlDataReader reader = cmd.ExecuteReader();


                    dt.Load(reader);


                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }
                finally
                {
                    con.Close();
                }
                return dt;
            }

        }

        /// <summary>
        /// get type and joining date of an recruitment id
        /// </summary>
        /// <param name="recid"></param>
        /// <returns></returns>
        public DataTable getTheApplicableleaveforrecruitment(int recid)
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT     LeaveMaster_tbl.LeavePk, LeaveMaster_tbl.LeaveName, LeaveMaster_tbl.LeaveType, LeaveMaster_tbl.Isenchasable, LeaveMaster_tbl.IsMaleapp, " +
           "           LeaveMaster_tbl.IsWomenapp, LeaveMaster_tbl.EnchasableDays, LeaveMaster_tbl.Allowedleave, RecruitmentCodeMaster_tbl.RecruitmentCodePK, " +
            "          LeaveMaster_tbl.LeaveCode, LeaveMaster_tbl.IsCarryForward, LeaveMaster_tbl.CalculationUpto, LeaveMaster_tbl.ConsiderAlso " +
" FROM         LeaveMaster_tbl INNER JOIN " +
 "                     DesignationLeave_tbl ON LeaveMaster_tbl.LeavePk = DesignationLeave_tbl.LeavePk INNER JOIN " +
  "                    RecruitmentApplicationMaster_tbl ON DesignationLeave_tbl.DesgnationPK = RecruitmentApplicationMaster_tbl.DesignationPk INNER JOIN " +
   "                   RecruitmentCodeMaster_tbl ON RecruitmentApplicationMaster_tbl.RecruitmentAppPk = RecruitmentCodeMaster_tbl.RecruitmentPK " +
" WHERE     (RecruitmentCodeMaster_tbl.RecruitmentCodePK = @Param1) ", con);

                    cmd.Parameters.AddWithValue("@Param1", recid);
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

        /// <summary>
        /// check if all the details
        /// eg contract
        /// shift and position are aaded
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>

        public Boolean IsEmployeedetailsComplete(int empid)
        {
            Boolean isCompleted = false;

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT     EmployeePersonalMaster_tbl.empid " +
"FROM         EmployeePersonalMaster_tbl INNER JOIN " +
 "                     EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
  "                    EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN " +
   "                   EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN " +
    "                  EmployeeApplicableLeave_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeApplicableLeave_tbl.empid   INNER JOIN " +
            "          EmployesalaryDetails_tbl ON EmployeePersonalMaster_tbl.empid = EmployesalaryDetails_tbl.empid WHERE     (EmployeePersonalMaster_tbl.empid = @Param1)", con);

                    cmd.Parameters.AddWithValue("@Param1", empid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();

                    dt.Load(reader);
                    if (dt.Rows.Count > 0)
                    {
                        isCompleted = true;
                    }
                    else
                    {
                        isCompleted = false;
                    }



                    return isCompleted;
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

        /// <summary>
        /// get the contract details against  the given Employee FROM employee contract details DETAILS
        /// give the existing employee details
        /// </summary>
        public DataTable getCurrentContractDetails(int emppk)
        {


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(" SELECT     EmpContract_tbl.EmpId, EmployeePersonalMaster_tbl.empno, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, EmpContract_tbl.Endtime, EmpContract_tbl.ExtendedTime, EmployeePersonalMaster_tbl.First_name+' . '+ EmployeePersonalMaster_tbl.Last_Name , ActualJoiningDate " +
                    " FROM       EmpContract_tbl INNER JOIN EmployeePersonalMaster_tbl ON EmpContract_tbl.EmpId = EmployeePersonalMaster_tbl.empid WHERE     (EmpContract_tbl.EmpId = @Param1)", con);
                    cmd.Parameters.AddWithValue("@Param1", emppk);

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

        /// <summary>
        /// change the employee contract type only
        /// 
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="contracttype"></param>
        public void changeEmployeeContractype(int empid, String contracttype)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();

                    using (SqlCommand command1 = new SqlCommand("UPDATE       EmpContract_tbl SET ContractType = @Param2 WHERE        (EmpId = @Param1)", con))
                    {
                        command1.Parameters.AddWithValue("@Param1", empid);

                        if (contracttype == "Permanent")
                        {

                            command1.Parameters.AddWithValue("@Param2", contracttype);


                        }

                        else if (contracttype == "Contractual")
                        {
                            command1.Parameters.AddWithValue("@Param2", contracttype);
                        }
                        else
                        {

                            command1.Parameters.AddWithValue("@Param2", contracttype);

                        }
                        command1.ExecuteNonQuery();




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

        }

        /// <summary>
        /// employee name empid .empno shift and name will be retriewed
        /// asper the location nand designation
        /// </summary>
        /// <param name="branchlocationPk"></param>
        /// <param name="designationPk"></param>
        /// <returns></returns>
        public DataTable getemployyeIDShiftName(int branchlocationPk, int designationPk)
        {


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(" SELECT        EmployeePersonalMaster_tbl.empid AS [EMP ID], EmployeePersonalMaster_tbl.empno AS [EMP NO], EmployeePersonalMaster_tbl.oldempid AS [OLD ID], " +
              "           EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS [EMP NAME], " +
               "          ShiftMasterNew_tbl.ShiftName AS [CURRENT SHIFT] ,EmployeShift_tbl.Shiftpk as SHIFTPK " +
"FROM            EmployeePersonalMaster_tbl INNER JOIN " +
               "          EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN " +
                   "      ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK INNER JOIN " +
                "         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
"WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeeDesignation_tbl.DesignationPk = @Param2) AND " +
                  "       (EmployeePersonalMaster_tbl.Status = N'A')", con);
                    cmd.Parameters.AddWithValue("@Param1", branchlocationPk);
                    cmd.Parameters.AddWithValue("@Param2", designationPk);

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

        /// <summary>
        /// get the contract data of employee who applied for renewal
        /// </summary>
        /// <param name="emppk"></param>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        public DataTable getApplicationContractdata(int emppk, int applicationid)
        {


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT     EmpContract_tbl.EmpId, EmployeePersonalMaster_tbl.empno, ContractRenewalApplication_tbl.ContractType, EmpContract_tbl.Startdate, ContractRenewalApplication_tbl.Todate, " +
                "      EmpContract_tbl.ExtendedTime, EmployeePersonalMaster_tbl.First_name + ' . ' + EmployeePersonalMaster_tbl.Last_Name AS Expr1, " +
                 "     EmpContract_tbl.ActualJoiningDate " +
"FROM         EmpContract_tbl INNER JOIN " +
                  "    EmployeePersonalMaster_tbl ON EmpContract_tbl.EmpId = EmployeePersonalMaster_tbl.empid INNER JOIN " +
                 "     ContractRenewalApplication_tbl ON EmployeePersonalMaster_tbl.empid = ContractRenewalApplication_tbl.Empid " +
"WHERE     (EmpContract_tbl.EmpId = @Param1) AND (ContractRenewalApplication_tbl.ContractAppPk = @Param1)", con);
                    cmd.Parameters.AddWithValue("@Param1", emppk);

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

        /// <summary>
        /// GETaLLEMPLOYEECODE FOR aPPROVAL
        /// </summary>
        /// <param name="BranchLocationPK"></param>
        /// <returns></returns>
        public DataTable GetAllEmployeeCodeForApproval(int BranchLocationPK)
        {


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    string qry = "";

                    if (BranchLocationPK == 0)
                    {
                        qry = "SELECT     empno, empid FROM         EmployeePersonalMaster_tbl WHERE     (Status = N'W') ";
                    }
                    else
                    {
                        qry = "SELECT     EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.empid FROM         EmployeePersonalMaster_tbl INNER JOIN   EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
" WHERE     (EmployeePersonalMaster_tbl.Status = N'W') AND (EmployeeDesignation_tbl.BranchLocationPK = @Param1) ";

                    }
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@Param1", BranchLocationPK);
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


        /// <summary>
        /// updates the status of employee to Approved
        /// </summary>
        /// <param name="empid"></param>
        public void MarkEmployeeActive(int empid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();

                    using (SqlCommand command1 = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl  SET              Status = N'A' WHERE     (empid = @Param1)", con))
                    {

                        command1.Parameters.AddWithValue("@Param1", empid);


                        command1.ExecuteNonQuery();

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
        }




        public void ReactivateEmployee(int empid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();

                    using (SqlCommand command1 = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl  SET              Status = N'A' WHERE     (empid = @Param1)", con))
                    {

                        command1.Parameters.AddWithValue("@Param1", empid);


                        command1.ExecuteNonQuery();

                    }
                    using (SqlCommand command2 = new SqlCommand("INSERT INTO EmployeeReactivation_tbl  (Empid, UserPK)  VALUES        (@Param1,@Param2)", con))
                    {

                        command2.Parameters.AddWithValue("@Param1", empid);

                        command2.Parameters.AddWithValue("@Param2", Program.USERPK);
                        command2.ExecuteNonQuery();

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
        }
        /// <summary>
        /// updates the status of employee to Approved
        /// </summary>
        /// <param name="empid"></param>
        public void REJECTcONTRACT(int empid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();

                    using (SqlCommand command1 = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl  SET              Status = N'R' WHERE     (empid = @Param1)", con))
                    {

                        command1.Parameters.AddWithValue("@Param1", empid);


                        command1.ExecuteNonQuery();




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
        }

        /// <summary>
        /// updates the Details of the Employee
        /// </summary>
        /// <param name="empid"></param>
        public void updatemandatory(int empid, String incometax, String NSSF, String NHIF, String Nationalid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();

                    using (SqlCommand command1 = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl SET    Incometaxnum = @Param2, NSSFnum = @Param3, NHIFnum = @Param4, NationalId = @Param5 WHERE     (empid = @Param1)", con))
                    {

                        command1.Parameters.AddWithValue("@Param2", incometax);
                        command1.Parameters.AddWithValue("@Param3", NSSF);
                        command1.Parameters.AddWithValue("@Param4", NHIF);
                        command1.Parameters.AddWithValue("@Param5", Nationalid);
                        command1.Parameters.AddWithValue("@Param1", empid);


                        command1.ExecuteNonQuery();




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
        }

        /// <summary>
        /// MARK THE DATA IS COMPLETE FOR THE EMPLOYEE AND WAIT FOR CONTRACT aPPROVAL
        /// </summary>
        /// <param name="empid"></param>
        public void MarkEmployeeDataFilled(int empid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();

                    using (SqlCommand command1 = new SqlCommand("UPDATE    EmployeePersonalMaster_tbl  SET              Status = N'W' WHERE     (empid = @Param1)", con))
                    {

                        command1.Parameters.AddWithValue("@Param1", empid);


                        command1.ExecuteNonQuery();




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
        }

        /// <summary>
        /// insert employee personal data
        /// </summary>
        /// <param name="empdatabean"></param>
        /// <returns></returns>
        public int insertEmpPersonalDetails(Datalayer.EmployeePersonaldatabean empdatabean)
        {
            int id;
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO EmployeePersonalMaster_tbl " +
" (EmpNation, NationalId, PassportNo, EmpGender, Matialstatus, First_name, Last_Name, Address_Prime, Address_Second, Contact_lctnPk, Tel_No, Mobile_No, Email, " +
 " Ref_Name, Ref_Details, Ref_Mobile, Ref_Email, Kin_Name, Kin_Relation, Kin_Email,Kin_Mobile, Rec_Id, empno ,Userpk ,DateAdded ,oldempid ,Incometaxnum,NSSFnum,NHIFnum,DateofBirth,Kins_NID,HighestQualification) " +
 " VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20,@Param21,@Param22,@Param23,@Param24,GetDate(),@Param26,@Param27,@Param28,@Param29,@Param30,@Param31,@Param32) ;SELECT SCOPE_IDENTITY() ", con);
                // cmd.Parameters.AddWithValue("@eid", empdatabean.Empid);
                cmd.Parameters.AddWithValue("@Param1", empdatabean.Nationality);
                cmd.Parameters.AddWithValue("@Param2", empdatabean.Nid);
                cmd.Parameters.AddWithValue("@Param3", empdatabean.PPnum1);
                cmd.Parameters.AddWithValue("@Param4", empdatabean.Gender);
                cmd.Parameters.AddWithValue("@Param5", empdatabean.Status);
                cmd.Parameters.AddWithValue("@Param6", empdatabean.Firstname);
                cmd.Parameters.AddWithValue("@Param7", empdatabean.Lastname);
                cmd.Parameters.AddWithValue("@Param8", empdatabean.Adress1);
                cmd.Parameters.AddWithValue("@Param9", empdatabean.Adress2);
                //   
                cmd.Parameters.AddWithValue("@Param10", empdatabean.LctnPk);
                cmd.Parameters.AddWithValue("@Param11", empdatabean.Telphone);


                cmd.Parameters.AddWithValue("@Param12", empdatabean.Mobile);
                cmd.Parameters.AddWithValue("@Param13", empdatabean.Email);
                cmd.Parameters.AddWithValue("@Param14", empdatabean.Refname);
                cmd.Parameters.AddWithValue("@Param15", empdatabean.Refdetails);
                cmd.Parameters.AddWithValue("@Param16", empdatabean.Refmobile);
                cmd.Parameters.AddWithValue("@Param17", empdatabean.Refemail);
                cmd.Parameters.AddWithValue("@Param18", empdatabean.Beneficaryname);
                cmd.Parameters.AddWithValue("@Param19", empdatabean.Benificiaryrelation);
                cmd.Parameters.AddWithValue("@Param20", empdatabean.Beneficiarymobile);
                cmd.Parameters.AddWithValue("@Param21", empdatabean.Beneficiaryemail);
                cmd.Parameters.AddWithValue("@Param22", empdatabean.RecId);
                cmd.Parameters.AddWithValue("@Param23", empdatabean.Empcode);
                cmd.Parameters.AddWithValue("@Param24", Program.USERPK);
                //   cmd.Parameters.AddWithValue("@Param25", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param26", empdatabean.Oldempid1);
                cmd.Parameters.AddWithValue("@Param27", empdatabean.INCometaxnum1);
                cmd.Parameters.AddWithValue("@Param28", empdatabean.NSSF1);
                cmd.Parameters.AddWithValue("@Param29", empdatabean.NHIF1);
                cmd.Parameters.AddWithValue("@Param30", empdatabean.Dob);
                cmd.Parameters.AddWithValue("@Param31", empdatabean.KinsNID);
                cmd.Parameters.AddWithValue("@Param32", empdatabean.Highesteducation);
                id = int.Parse(cmd.ExecuteScalar().ToString());

                return id;

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
        /// get the designation and location of employee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getEmployeDesignationandLocation(int empid, String action)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("EmployeeDesignationAndLocation_sp ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@param1", empid);
                cmd.Parameters.AddWithValue("@param2", action);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }

        /// <summary>
        /// get the designation and location of employee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getEmployeleavesApplicable(int empid)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("EmployeeLeavesApplicable_sp ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@param1", empid);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }

        /// <summary>
        /// insert employee personal data
        /// </summary>
        /// <param name="empdatabean"></param>
        /// <returns></returns>
        public void insertEmpShiftDetails(Datalayer.EmployeeShiftDatabean empshiftdata)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();



                SqlCommand cmd = new SqlCommand("INSERT INTO EmployeShift_tbl(Empid, Shiftpk, EffectiveFrom, Userpk, AddedDate)VALUES (@Param1,@Param2,@Param3,@Param4,getdate()) ", con);
                cmd.Parameters.AddWithValue("@Param1", empshiftdata.Empid);
                cmd.Parameters.AddWithValue("@Param2", empshiftdata.ShiftPk1);
                cmd.Parameters.AddWithValue("@Param3", empshiftdata.Effectivedate);
                cmd.Parameters.AddWithValue("@Param4", Program.USERPK);
                // cmd.Parameters.AddWithValue("@Param5", DateTime.Now.Date);
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
        /// updates the shift of the Employee
        /// </summary>
        /// <param name="empshiftdata"></param>
        /// <param name="applicationid"></param>
        public void updateshift(Datalayer.EmployeeShiftDatabean empshiftdata, int applicationid)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateEmployeeShift_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empid ", empshiftdata.Empid);
                    cmd.Parameters.AddWithValue("@effectivefrom", empshiftdata.Effectivedate);
                    cmd.Parameters.AddWithValue("@Applicationtype", "Shift Change");
                    cmd.Parameters.AddWithValue("@userpk", Program.USERPK);
                    cmd.Parameters.AddWithValue("@shiftPk", empshiftdata.ShiftPk1);
                    cmd.Parameters.AddWithValue("@applicationid ", applicationid);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }


        }

        /// <summary>
        /// get the employe code and empid
        /// </summary>
        /// <returns></returns>
        public DataTable getEmpcode(int branchlocation, int dept, int design)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("EmployeCodeandNameByDesignationandLocation", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchLocationPk", branchlocation);
                cmd.Parameters.AddWithValue("@DepartmentPK", dept);
                cmd.Parameters.AddWithValue("@DesignationPK", design);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }


        //get the login username and the employeecode of that employee
        public DataTable getEmpcodeandUseriid(int branchlocation)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        UserId, Empid, BranchLocationPk
FROM            UserMaster_tbl
WHERE        (BranchLocationPk = @BranchLocationPk)", con);



                cmd.Parameters.AddWithValue("@BranchLocationPk", branchlocation);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;
        }





        public DataTable getEmpcodeforPayroll(int branchlocation, int dept, int design, String HoldType)
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GEtEmployeeCodeForPayroll_sp", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchLocationPk", branchlocation);
                cmd.Parameters.AddWithValue("@DepartmentPK", dept);
                cmd.Parameters.AddWithValue("@DesignationPK", design);

                if (HoldType == "Hold")
                {
                    cmd.Parameters.AddWithValue("@payrollstatus", "Y");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@payrollstatus", "N");
                }


                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }






        /// <summary>
        /// check whether a  Nid is Present
        /// </summary>
        /// <param name="NID"></param>
        /// <returns></returns>
        public DataTable isEmployeePresent(String NID)
        {


            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     empid ,Status FROM   EmployeePersonalMaster_tbl WHERE (NationalId = @Param1) ", con);

                cmd.Parameters.AddWithValue("@Param1", NID);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();

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

        public DataTable isDuplicateNationIDAllowedfor(String NID)
        {


            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT        NationalID, IsApproved FROM NIDApproval_tbl WHERE (NationalID = @Param1) AND (IsApproved = N'Y') ", con);

                cmd.Parameters.AddWithValue("@Param1", NID);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();

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




        public DataTable isDuplicateFoundFor(String NID, String PP, String NSSF, String NHIF, String Incomtaztnumber)
        {


            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        empid, NationalId, PassportNo, NSSFnum, NHIFnum, Incometaxnum
FROM            EmployeePersonalMaster_tbl
WHERE       ( (NationalId = @nationalId) OR
                         (PassportNo = @PassportNo) OR
                         (NSSFnum = @NSSFnum) OR
                         (NHIFnum = @NHIFnum) OR
                         (Incometaxnum = @Incometaxnum)) AND Status!='D'", con);

                cmd.Parameters.AddWithValue("@nationalId", NID);
                cmd.Parameters.AddWithValue("@PassportNo", PP);
                cmd.Parameters.AddWithValue("@NSSFnum", NSSF);
                cmd.Parameters.AddWithValue("@NHIFnum", NHIF);
                cmd.Parameters.AddWithValue("@Incometaxnum", Incomtaztnumber);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();

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



        public Boolean IsBlacklisted(String NID)
        {
            Boolean isblacklisted = false;
            using (SqlServerLinqDataContext cntxt= new SqlServerLinqDataContext (Program.ConnStr))
            {
                var q = from empmst in cntxt.EmployeePersonalMaster_tbls
                        where empmst.NationalId.Trim () == NID && empmst.IsBlackListed == "Y"
                        select empmst;

                foreach( var element in q)
                {
                    isblacklisted = true;
                }

            }
            return isblacklisted;
        }





        /// <summary>
        /// get the old ID od employee and which type of contract
        /// he is now working
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getEmployeOldIDandContract(int empid)
        {


            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT        EmployeePersonalMaster_tbl.oldempid AS [Old ID], EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS [Emp Name], " +
                   "      EmpContract_tbl.ContractType AS [Contract Type], EmployeePersonalMaster_tbl.EmpGender AS Gender " +
" FROM            EmployeePersonalMaster_tbl INNER JOIN " +
           "              EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId " +
" WHERE        (EmployeePersonalMaster_tbl.empid = @Param1) ", con);

                cmd.Parameters.AddWithValue("@Param1", empid);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();

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
        /// gets the gender  of employee
        /// </summary>
        public DataTable getemployeegenderandName(int empid)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     First_name + ' ' + Last_Name AS Expr1, EmpGender FROM EmployeePersonalMaster_tbl WHERE     (empid = @Param1) ", con);

                cmd.Parameters.AddWithValue("@Param1", empid);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();

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
        /// get all the e,ploye data of a lovcation
        /// </summary>
        /// <param name="locationpk"></param>
        /// <returns></returns>
        public DataTable getAllemployeedataofLocation(int locationpk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetAllEmployeeofALocation", con);

                cmd.Parameters.AddWithValue("@branchlocationPK", locationpk);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }

            return dt;
        }






        public DataTable getallemployeedataforexport(int locationpk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                if (locationpk != 0)
                {

                    SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.oldempid,
                         EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS empname, DesignationMaster_tbl.DesignationName, 
                         DepartmentMaster_tbl.DepartmentName, BranchLocartionMaster_tbl.BranchLocationName, BranchMaster_tbl.BranchName, CompanyMaster_tbl.CompanyName, 
                         EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.EmpGender, EmployeePersonalMaster_tbl.Status, 
                         EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, ShiftMasterNew_tbl.ShiftName, 
                         EmployesalaryDetails_tbl.Paymentmode, EmployesalaryDetails_tbl.accountnum,ISNULL( BankMaster_tbl.BankName,'NA') as bankname,EmployeeDesignation_tbl.IsOtApplicable, EmployeeDesignation_tbl.isPayrollHold
FROM            DepartmentMaster_tbl INNER JOIN
                         DesignationMaster_tbl ON DepartmentMaster_tbl.DepartmentPK = DesignationMaster_tbl.DepartmentPK INNER JOIN
                         EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON 
                         DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN
                         BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN
                         CompanyMaster_tbl ON BranchMaster_tbl.CompanyPk = CompanyMaster_tbl.CompanyPk INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN
                         ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK INNER JOIN
                         EmployesalaryDetails_tbl ON EmployeePersonalMaster_tbl.empid = EmployesalaryDetails_tbl.empid LEFT OUTER JOIN
                         BankMaster_tbl ON EmployesalaryDetails_tbl.Bankpk = BankMaster_tbl.BankPK
						  WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @branchlocationPK) AND (EmployeePersonalMaster_tbl.Status = N'A')", con);

                    cmd.Parameters.AddWithValue("@branchlocationPK", locationpk);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                }
                else
                {

                    SqlCommand cmd1 = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.oldempid,
                         EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS empname, DesignationMaster_tbl.DesignationName, 
                         DepartmentMaster_tbl.DepartmentName, BranchLocartionMaster_tbl.BranchLocationName, BranchMaster_tbl.BranchName, CompanyMaster_tbl.CompanyName, 
                         EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.EmpGender, EmployeePersonalMaster_tbl.Status, 
                         EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, ShiftMasterNew_tbl.ShiftName, 
                         EmployesalaryDetails_tbl.Paymentmode, EmployesalaryDetails_tbl.accountnum,ISNULL( BankMaster_tbl.BankName,'NA') as bankname,EmployeeDesignation_tbl.IsOtApplicable, EmployeeDesignation_tbl.isPayrollHold
FROM            DepartmentMaster_tbl INNER JOIN
                         DesignationMaster_tbl ON DepartmentMaster_tbl.DepartmentPK = DesignationMaster_tbl.DepartmentPK INNER JOIN
                         EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON 
                         DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN
                         BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN
                         CompanyMaster_tbl ON BranchMaster_tbl.CompanyPk = CompanyMaster_tbl.CompanyPk INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN
                         ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK INNER JOIN
                         EmployesalaryDetails_tbl ON EmployeePersonalMaster_tbl.empid = EmployesalaryDetails_tbl.empid LEFT OUTER JOIN
                         BankMaster_tbl ON EmployesalaryDetails_tbl.Bankpk = BankMaster_tbl.BankPK
						  WHERE    (EmployeePersonalMaster_tbl.Status = N'A')", con);


                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    dt.Load(reader1);

                }

                con.Close();
            }

            return dt;
        }












        /// <summary>
        /// get the list of deactivated employees of a location
        /// </summary>
        /// <param name="locationpk"></param>
        /// <returns></returns>
        public DataTable getallDeactivatedEmployees(int locationpk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                if (locationpk != 0)
                {

                    SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.oldempid,
                         EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS empname, DesignationMaster_tbl.DesignationName, 
                         DepartmentMaster_tbl.DepartmentName, BranchLocartionMaster_tbl.BranchLocationName, BranchMaster_tbl.BranchName, CompanyMaster_tbl.CompanyName, 
                         EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.EmpGender, EmployeePersonalMaster_tbl.Status, 
                         EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, ShiftMasterNew_tbl.ShiftName, 
                         EmployesalaryDetails_tbl.Paymentmode, EmployesalaryDetails_tbl.accountnum,ISNULL( BankMaster_tbl.BankName,'NA') as bankname,EmployeeDesignation_tbl.IsOtApplicable, EmployeeDesignation_tbl.isPayrollHold
FROM            DepartmentMaster_tbl INNER JOIN
                         DesignationMaster_tbl ON DepartmentMaster_tbl.DepartmentPK = DesignationMaster_tbl.DepartmentPK INNER JOIN
                         EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON 
                         DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN
                         BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN
                         CompanyMaster_tbl ON BranchMaster_tbl.CompanyPk = CompanyMaster_tbl.CompanyPk INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN
                         ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK INNER JOIN
                         EmployesalaryDetails_tbl ON EmployeePersonalMaster_tbl.empid = EmployesalaryDetails_tbl.empid LEFT OUTER JOIN
                         BankMaster_tbl ON EmployesalaryDetails_tbl.Bankpk = BankMaster_tbl.BankPK
						  WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @branchlocationPK) AND (EmployeePersonalMaster_tbl.Status = N'D')", con);

                    cmd.Parameters.AddWithValue("@branchlocationPK", locationpk);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                }


                con.Close();
            }

            return dt;
        }


        /// <summary>
        /// get the list of reactyivated employees of a location and the date and the user who reactivatged them
        /// </summary>
        /// <param name="locationpk"></param>
        /// <returns></returns>
        public DataTable getallReactivatedEmployees(int locationpk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                if (locationpk != 0)
                {

                    SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                         EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS empname, DesignationMaster_tbl.DesignationName, 
                         DepartmentMaster_tbl.DepartmentName, BranchLocartionMaster_tbl.BranchLocationName, BranchMaster_tbl.BranchName, CompanyMaster_tbl.CompanyName, 
                         EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.EmpGender, EmployeePersonalMaster_tbl.Status, 
                         EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, ShiftMasterNew_tbl.ShiftName, 
                         EmployeeReactivation_tbl.ReactivationDate, UserMaster_tbl.UserId
FROM            DepartmentMaster_tbl INNER JOIN
                         DesignationMaster_tbl ON DepartmentMaster_tbl.DepartmentPK = DesignationMaster_tbl.DepartmentPK INNER JOIN
                         EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON 
                         DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN
                         BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN
                         CompanyMaster_tbl ON BranchMaster_tbl.CompanyPk = CompanyMaster_tbl.CompanyPk INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN
                         ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK INNER JOIN
                         EmployeeReactivation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeReactivation_tbl.Empid INNER JOIN
                         UserMaster_tbl ON EmployeeReactivation_tbl.UserPK = UserMaster_tbl.UserPK
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @branchlocationPK)", con);

                    cmd.Parameters.AddWithValue("@branchlocationPK", locationpk);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                }


                con.Close();
            }

            return dt;
        }






        /// <summary>
        /// get employee details asper different Criterias
        /// </summary>
        /// <param name="locationpk"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        public DataTable getemployeedata(int locationpk, String Action)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                String qry = "";
                if (Action == "Reject")
                {


                    qry = "GetAllRejectedContracts_SP";

                }
                else if (Action == "Pending")
                {
                    qry = "GetAllApprovalPendingContracts_sp";
                }
                else if (Action == "Deactivated")
                {

                    qry = "DeactivatedEmployee_sp";

                }
                else if (Action == "Detail Pending")
                {
                    qry = "getAlldetailPendingApplication_SP";
                }
                else if (Action == "Duplicating Entry")
                {
                    qry = "GetduplicateEmployees_SP";
                }
                else if (Action == "Submission Pending")
                {
                    qry = "GetAllNonSubmittedEmoployeeRecords_sp";
                }
                else if (Action == "Temporary Employees")
                {
                    qry = "GetAllTemperoryEmployees_sp";
                }
                else if (Action == "Hold Employees")
                {
                    qry = "GetPayrollHoldEmployeeList_sp";
                }
                else
                {
                    qry = "GetAllEmployeeofALocation";
                }




                SqlCommand cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@branchlocationPK", locationpk);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }

            return dt;
        }

        /// <summary>
        /// get the contract details against  the given Employee
        /// </summary>
        public DataTable getempDesignationAndBasic(int emppk, int recid)
        {


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(" SELECT     DesignationMaster_tbl.DesgnationPK, DesignationMaster_tbl.Basicsal, CurrencyMaster_tbl.Name FROM   EmployeeDesignation_tbl INNER JOIN  DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN " +
                       " CurrencyMaster_tbl ON DesignationMaster_tbl.CurrencyPK = CurrencyMaster_tbl.Currency_Pk WHERE (EmployeeDesignation_tbl.empid = @Param1)", con);
                    cmd.Parameters.AddWithValue("@Param1", emppk);
                    cmd.Parameters.AddWithValue("@Param2", recid);
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

        /// <summary>
        /// get all Employee detail and Shift data of particular dept and Location
        /// </summary>
        /// <param name="deptid"></param>
        public DataTable getallemployeeshiftdetails(int deptid, int branchltcnpk, String OTDay)
        {

            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetEmployeeShiftData", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentPK", deptid);
                cmd.Parameters.AddWithValue("@BranchLocationPK", branchltcnpk);
                cmd.Parameters.AddWithValue("@daynameofWeek", OTDay);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;

        }

        /// <summary>
        /// get the designation, name and location of employee
        /// </summary>EmployeeDesignationAndLocation_sp
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getEmployeDesignationNameandLocation(int empid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("getemployedesglocationandname_sp ", con);


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empid", empid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);

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
            return dt;

        }


        /// <summary>
        /// insert the deactivation data of employee
        /// it calls the bnext functiuon insertdeactivationreason()
        /// also assign D for the employe status
        /// </summary>
        /// <param name="deactivatedata"></param>
        /// <param name="reasondata"></param>

        public void deactivateemployee(ArrayList deactivatedata, ArrayList reasondata)
        {
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                    int Deactivationpk;
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO EmployeDeactivationMaster_tbl (empid, Isreemployable, Remark, Dateadded, UserpK,Effectivedate,IsBlackListed) VALUES  (@Param1,@Param2,@Param3,getdate(),@Param5,@Param6,@Param7)  ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", deactivatedata[0]);
                        command.Parameters.AddWithValue("@Param2", deactivatedata[1]);
                        command.Parameters.AddWithValue("@Param3", deactivatedata[2]);
                        //     command.Parameters.AddWithValue("@Param4", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param5", Program.USERPK);
                        command.Parameters.AddWithValue("@Param6", deactivatedata[3]);
                        command.Parameters.AddWithValue("@Param7", deactivatedata[4]);







                        Deactivationpk = int.Parse(command.ExecuteScalar().ToString());

                    }











                    sqlConnection1.Close();

                    insertdeactivationreason(Deactivationpk, reasondata);

                    Actionlog.actiondone("Employee Deactivation", "of employeeID " + deactivatedata[0] + " Updated to " + deactivatedata[1] + "", int.Parse (deactivatedata[0].ToString ()));
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }

        }




        /// <summary>
        /// mark a ot satus of designbation available or not
        /// </summary>
        /// <param name="desigid"></param>
        /// <param name="applicable"></param>

        public void MarkOTApplicableforDesignation(int desigid, Boolean applicable)
        {

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("UPDATE       DesignationMaster_tbl SET    IsOtApplicable = @Param2 WHERE        (DesgnationPK = @Param1) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", desigid);


                        if (applicable == true)
                        {
                            command.Parameters.AddWithValue("@Param2", "Y");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Param2", "N");
                        }


                        //  command.Parameters.AddWithValue("@Param5", Aprreciationdata[4]);


                        command.ExecuteNonQuery();

                        Actionlog.actiondone("OT Appicability Update", "of Designation " + desigid + " Updated to OTAvailability" + applicable.ToString() + "",0);

                    }











                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }




        /// <summary>
        /// Mark the employee applicable to OT or not
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="applicable"></param>

        public void markOTApplicableforEmployee(int empid, Boolean applicable)
        {

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("UPDATE       EmployeeDesignation_tbl SET    IsOtApplicable = @Param2 WHERE        (empid = @Param1) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);


                        if (applicable == true)
                        {
                            command.Parameters.AddWithValue("@Param2", "Y");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Param2", "N");
                        }


                        //  command.Parameters.AddWithValue("@Param5", Aprreciationdata[4]);


                        command.ExecuteNonQuery();

                        Actionlog.actiondone("OT Appicability Update", "of employeeID " + empid + " Updated to Shiftpk" + applicable.ToString() + "",empid);

                    }











                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }




        /// <summary>
        /// change employee shift
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="Shiftpk"></param>
        public void ChangeEmployeeShift(int empid, int Shiftpk, DateTime effectivedate)
        {

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    //                    using (SqlCommand command1 = new SqlCommand(@"INSERT INTO ChangeShiftTemp_tbl
                    //                         (Empid, NewShiftPK, EffectiveDate, UserPK, IsCompleted)
                    //VALUES        (@Param1,@Param2,@Param3,@Param4, N'N') ", sqlConnection1))
                    //                    {

                    //                        command1.Parameters.AddWithValue("@Param1", empid);



                    //                        command1.Parameters.AddWithValue("@Param2", Shiftpk);

                    //                        command1.Parameters.AddWithValue("@Param3", effectivedate);

                    //                        command1.Parameters.AddWithValue("@Param3", Program.USERPK );
                    //                        //  command.Parameters.AddWithValue("@Param5", Aprreciationdata[4]);


                    //                        command1.ExecuteNonQuery();


                    //                    }



                    using (SqlCommand command = new SqlCommand("UPDATE       EmployeShift_tbl  SET    Shiftpk = @Param2 WHERE        (empid = @Param1) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);



                        command.Parameters.AddWithValue("@Param2", Shiftpk);



                        //  command.Parameters.AddWithValue("@Param5", Aprreciationdata[4]);


                        command.ExecuteNonQuery();
                        Actionlog.actiondone("Shift Update Update", "of employeeID " + empid + " Updated to Shiftpk" + Shiftpk + "",empid);

                    }











                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }

        /// <summary>
        /// change the location of a employeee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="BranchLctnPk"></param>
        public void changeEmployeeLocation(int empid, int BranchLctnPk)
        {

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("UPDATE       EmployeeDesignation_tbl SET    BranchLocationPK = @Param2 WHERE        (empid = @Param1) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);



                        command.Parameters.AddWithValue("@Param2", BranchLctnPk);



                        //  command.Parameters.AddWithValue("@Param5", Aprreciationdata[4]);


                        command.ExecuteNonQuery();
                        Actionlog.actiondone("Location Update", "of employeeID " + empid + " Updated to BranchLctnPk" + BranchLctnPk + "",empid);

                    }











                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }

        /// <summary>
        /// changethe Sundept of an employee 
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="Subdeptpk"></param>

        public void changeEmployeeSubdept(int empid, int Subdeptpk)
        {

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("UPDATE       EmployeeDesignation_tbl SET    SubdeptPK = @Param2 WHERE        (empid = @Param1) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);



                        command.Parameters.AddWithValue("@Param2", Subdeptpk);



                        //  command.Parameters.AddWithValue("@Param5", Aprreciationdata[4]);


                        command.ExecuteNonQuery();
                        Actionlog.actiondone("Sub Dept Update", "of employeeID " + empid + " Updated to subdeptpk" + Subdeptpk + "",empid);

                    }











                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }


        }


        /// <summary>
        /// change the degignation of the emloyeee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="designpk"></param>

        public void ChangeemployeeDesignation(int empid, int designpk)
        {
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand(@"UPDATE EmployeeDesignation_tbl SET  DesignationPk = @Param2 WHERE  (empid = @Param1) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);



                        command.Parameters.AddWithValue("@Param2", designpk);



                        command.ExecuteNonQuery();
                        Actionlog.actiondone("Designation Update", "of employeeID " + empid + " Updated to designpk" + designpk + "",empid);
                    }



                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        /// <summary>
        /// change the department and Designation of employee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="designpk"></param>
        /// <param name="deptpk"></param>
        public void ChangeemployeeDepartmentanddesignation(int empid, int designpk, int deptpk)
        {
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand(@"UPDATE       EmployeeDesignation_tbl SET    DesignationPk = @Param2, DepartmeentPk =@Param3
WHERE        (empid = @Param1) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);



                        command.Parameters.AddWithValue("@Param2", designpk);

                        command.Parameters.AddWithValue("@Param3", deptpk);

                        command.ExecuteNonQuery();
                        Actionlog.actiondone("Department Update", "of employeeID " + empid + " Updated to designpk" + designpk + " and DeptPk=" + deptpk + "",empid);
                    }



                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }




        /// <summary>
        ///insert the reason for deactivation
        /// </summary>
        /// <param name="deactivationPK"></param>
        /// <param name="reasondata"></param>
        public void insertdeactivationreason(int deactivationPK, ArrayList reasondata)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();

                for (int i = 0; i < reasondata.Count; i++)
                {

                    SqlCommand cmd = new SqlCommand(" INSERT INTO EmployeeDeactivationDetails_tbl (DeactivationPK, Cause) VALUES (@Param1,@Param2) ", con);

                    cmd.Parameters.AddWithValue("@Param1", deactivationPK);
                    cmd.Parameters.AddWithValue("@Param2", reasondata[i]);



                    cmd.ExecuteNonQuery();

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
        /// get the datatable containing all the details of the
        /// sal components added AGAINST EACH DESIGNATION 
        /// </summary>
        /// <returns></returns>
        public DataTable getAllSalCompData(int empid)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     SalComponentMaster_tbl.SalcompPk AS SL, SalComponentMaster_tbl.ComponentName AS SALCOMP, ComponentType_tbl.ComponentName AS COMPONENT, " +
                    "  ComponentType_tbl.ComponentType AS TYPE, ComponentCalMaster_tbl.CalculationType AS CALCULATIONTYPE, ComponentCalMaster_tbl.Criteria AS CRITERIA, " +
                    "  DesgnationSalComponent_tbl.Amount AS AMOUNT " +
                    " FROM         SalComponentMaster_tbl INNER JOIN " +
                     " ComponentType_tbl ON SalComponentMaster_tbl.Componenttypepk = ComponentType_tbl.Componenttypepk INNER JOIN " +
                      " ComponentCalMaster_tbl ON SalComponentMaster_tbl.Caluculationpk = ComponentCalMaster_tbl.Caluculationpk INNER JOIN " +
                      " DesgnationSalComponent_tbl ON SalComponentMaster_tbl.SalcompPk = DesgnationSalComponent_tbl.salcompPk INNER JOIN " +
                       " EmployeeDesignation_tbl ON DesgnationSalComponent_tbl.DesignationPK = EmployeeDesignation_tbl.DesignationPk " +
                   " WHERE (EmployeeDesignation_tbl.empid = @Param2) ", con);
                cmd.Parameters.AddWithValue("@Param2", empid);
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

        public DataTable GetAssignedSalccomp(int empid)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@" SELECT        SalComponentMaster_tbl.SalcompPk AS SL, SalComponentMaster_tbl.ComponentName AS SALCOMP, ComponentType_tbl.ComponentName AS COMPONENT, 
                         ComponentType_tbl.ComponentType AS TYPE, ComponentCalMaster_tbl.CalculationType AS CALCULATIONTYPE, ComponentCalMaster_tbl.Criteria AS CRITERIA, 
                         EmployeesalCompApplicable_tbl.Amount
FROM            SalComponentMaster_tbl INNER JOIN
                         ComponentType_tbl ON SalComponentMaster_tbl.Componenttypepk = ComponentType_tbl.Componenttypepk INNER JOIN
                         ComponentCalMaster_tbl ON SalComponentMaster_tbl.Caluculationpk = ComponentCalMaster_tbl.Caluculationpk INNER JOIN
                         EmployeesalCompApplicable_tbl ON SalComponentMaster_tbl.SalcompPk = EmployeesalCompApplicable_tbl.SalcompPk
WHERE        (EmployeesalCompApplicable_tbl.empid = @empid) ", con);
                cmd.Parameters.AddWithValue("@empid", empid);
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
        /// get basic sal against the Designation
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getBasicDesgSal(int empid)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     DesignationMaster_tbl.Basicsal, DesignationMaster_tbl.CurrencyPK, CurrencyMaster_tbl.Name " +
                    " FROM         DesignationMaster_tbl INNER JOIN " +
                   "  EmployeeDesignation_tbl ON DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN " +
                   "   CurrencyMaster_tbl ON DesignationMaster_tbl.CurrencyPK = CurrencyMaster_tbl.Currency_Pk " +
                    " WHERE     (EmployeeDesignation_tbl.empid = @Param1) ", con);
                cmd.Parameters.AddWithValue("@Param1", empid);
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
        /// gets all the salary components that are not added to the designation
        /// </summary>
        /// <param name="desgpk"></param>
        /// <returns></returns>
        public DataTable getSalaryComponentNotInDesg(int empid)
        {

            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("salarycomponentnotApplicabletodesignation_sp ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }



        /// <summary>
        /// gets all the salary components thatin designation
        /// but not added to employee
        /// </summary>
        /// <param name="desgpk"></param>
        /// <returns></returns>
        public DataTable getDesgSalaryComponentNotInEmp(int empid)
        {

            DataTable dt = new DataTable(); ;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DesignationSalNotINEmpSalComp_SP ", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            }
            return dt;


        }







        /// <summary>
        /// eInserts employee salary details
        /// </summary>
        /// <param name="empsaldatabean"></param>
        public void insertemployesalarydata(Datalayer.employeesalarydatabean empsaldatabean)
        {


            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();



                SqlCommand cmd = new SqlCommand(" INSERT INTO EmployesalaryDetails_tbl (empid, Approvedsal, Currecnypk, Paymentmode, Bankpk, accountnum, Dateadded, Userpk) VALUES   (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,getdate(),@Param8) ", con);

                cmd.Parameters.AddWithValue("@Param1", empsaldatabean.Empid);
                cmd.Parameters.AddWithValue("@Param2", empsaldatabean.Approvedsal);
                cmd.Parameters.AddWithValue("@Param3", empsaldatabean.Currencypk);
                cmd.Parameters.AddWithValue("@Param4", empsaldatabean.Paymentmode);
                cmd.Parameters.AddWithValue("@Param5", empsaldatabean.Bankpk);
                cmd.Parameters.AddWithValue("@Param6", empsaldatabean.Accountnum);
                //   cmd.Parameters.AddWithValue("@Param7", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param8", Program.USERPK);

                cmd.ExecuteNonQuery();






                for (int i = 0; i < empsaldatabean.Applicablesalcomponent.Rows.Count; i++)
                {

                    SqlCommand cmd1 = new SqlCommand("INSERT INTO EmployeesalCompApplicable_tbl  (empid, SalcompPk, Amount) VALUES     (@Param1,@Param2,@Param3)  ", con);

                    cmd1.Parameters.AddWithValue("@Param1", empsaldatabean.Applicablesalcomponent.Rows[i][0]);
                    cmd1.Parameters.AddWithValue("@Param2", empsaldatabean.Applicablesalcomponent.Rows[i][1]);
                    cmd1.Parameters.AddWithValue("@Param3", empsaldatabean.Applicablesalcomponent.Rows[i][2]);



                    cmd1.ExecuteNonQuery();


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



        public void updatesalarycomponentOfEmp(DataTable Salsarydata, int empid)
        {
            Boolean isdeleted = deleteoldsalaryDetails(int.Parse(Salsarydata.Rows[0][0].ToString()));

            if (isdeleted == true)
            {
                for (int i = 0; i < Salsarydata.Rows.Count; i++)
                {



                    using (SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr))
                    {
                        try
                        {
                            EmployeesalCompApplicable_tbl emptbl = new EmployeesalCompApplicable_tbl();

                            emptbl.empid = int.Parse(Salsarydata.Rows[i][0].ToString());
                            emptbl.SalcompPk = int.Parse(Salsarydata.Rows[i][1].ToString());
                            emptbl.Amount = int.Parse(Salsarydata.Rows[i][2].ToString());
                            emptbl.AddedBy = Program.USERPK;
                            emptbl.AddedDate = DateTime.Now.Date;
                            cntxt.EmployeesalCompApplicable_tbls.InsertOnSubmit(emptbl);

                            cntxt.SubmitChanges();
                           // MessageBox.Show("Updated");
                        }
                        catch (Exception exp)
                        {

                            ATCHRM.Controls.ATCHRMMessagebox.Show("Destructive code: Trying to delete old Salarydetail of employee");
                            ErrorLogger er = new ErrorLogger();
                            er.createErrorLog(exp);


                        }
                    }






                }


            }


        }

        /// <summary>
        /// delete salarycom,ponent of an Employee
        /// </summary>
        /// <param name="empid"></param>
        public Boolean deleteoldsalaryDetails(int empid)
        {
            Boolean isdeleted = false;
            using (SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr))
            {

                var deletesaldetails =
from details in cntxt.EmployeesalCompApplicable_tbls
where details.empid == empid
select details;

                foreach (var detail in deletesaldetails)
                {
                    cntxt.EmployeesalCompApplicable_tbls.DeleteOnSubmit(detail);
                    isdeleted = true;
                }

                try
                {
                    cntxt.SubmitChanges();
                }
                catch (Exception)
                {

                    // Provide for exceptions.
                }
                return isdeleted;
            }
        }




        /// <summary>
        /// update bank account of an employee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="Accountnum"></param>
        public void updateAccountnum(int empid, String Accountnum)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE       EmployesalaryDetails_tbl  SET accountnum = @accountnum  WHERE        (empid = @empid)", con))
                {

                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@accountnum", Accountnum);

                    cmd.ExecuteNonQuery();
                    Actionlog.actiondone("Account Number changed", "of employeeID " + empid + " Updated to " + Accountnum,empid);
                }
                con.Close();
            }
        }

        /// <summary>
        /// update bankpk of an employee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="bankpk"></param>

        public void updateBankdetails(int empid, int bankpk, String Accountnum)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE       EmployesalaryDetails_tbl  SET Bankpk = @bankpk,accountnum = @accountnum WHERE        (empid = @empid)", con))
                {

                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@bankpk", bankpk);
                    cmd.Parameters.AddWithValue("@accountnum", Accountnum);
                    cmd.ExecuteNonQuery();
                    Actionlog.actiondone("Bank PK  changed", "of employeeID " + empid + " Updated to " + bankpk,empid);
                }
                con.Close();
            }
        }




        public bool IfDuplicateAccountfound(int empid, String Accountnum)
        {
            Boolean isaacountnumpresent = false;
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(@"SELECT        empid, Bankpk, accountnum
FROM            EmployesalaryDetails_tbl
WHERE        (empid <> @empid) AND (accountnum = @accountnum)", con))
                {

                    cmd.Parameters.AddWithValue("@empid", empid);

                    cmd.Parameters.AddWithValue("@accountnum", Accountnum);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        isaacountnumpresent = true;
                    }

                }
                con.Close();
            }
            return isaacountnumpresent;
        }




        /// <summary>
        /// get the to shift for an given shift appid
        /// </summary>
        /// <param name="appid"></param>
        /// <returns></returns>
        public int getanShiftChangeapplication(int appid)
        {
            int toshift = 0;


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand("  SELECT     ToShiftPk FROM         ShiftChangeApplication_tbl WHERE     (ShftAppPK = @Param1)", con);
                command.Parameters.AddWithValue("@Param1", appid);


                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        toshift = int.Parse(reader[0].ToString());

                    }
                }


                reader.Close();

            }



            return toshift;
        }


        /// <summary>
        /// insert employee warning
        /// </summary>
        /// <param name="warningdata"></param>

        public void insertEmployeeWarning(ArrayList warningdata)
        {
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand(" INSERT INTO WarningEmployee_tbl  (empid, Reason, WarningMessage, WarningType, WarnedUser) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5)", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", warningdata[0]);
                        command.Parameters.AddWithValue("@Param2", warningdata[1]);
                        command.Parameters.AddWithValue("@Param3", warningdata[2]);
                        //     command.Parameters.AddWithValue("@Param4", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param4", warningdata[3]);
                        command.Parameters.AddWithValue("@Param5", warningdata[4]);


                        command.ExecuteNonQuery();

                    }











                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                throw exp;
            }

        }

        /// <summary>
        /// get all the main contract of the employee
        /// </summary>
        /// <param name="empid"></param>
        public DataTable getcontractofemployee(int empid)
        {
            DataTable contractdata = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT     EmpId as [Emp id],Contractid as [Contract Id], ContractType as [Contract Type], Startdate as [Contract Start Date] , Endtime as [Contract End Date], ActualJoiningDate as [Joining Date] FROM         EmpContract_tbl WHERE     (EmpId = @Param1)", con))
                {
                    cmd.Parameters.AddWithValue("@Param1", empid);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    contractdata.Load(reader);


                    reader.Close();






                    con.Close();
                }

            }

            return contractdata;
        }

        /// <summary>
        /// get the contract details of the all the employees of a location and department
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="BranchlocationPK"></param>
        /// <returns></returns>
        public DataTable getcontractofallemployeeofadeptandlocation(int deptid, int BranchlocationPK)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                String Query1 = "";

                con.Open();
                if (deptid == 0)
                {
                    Query1 = "SELECT     EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], " +
                   "        EmpContract_tbl.ActualJoiningDate, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, EmpContract_tbl.Endtime " +
     " FROM         EmployeePersonalMaster_tbl INNER JOIN " +
                  "         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN " +
                    "       EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
     " WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @Param1)  AND (EmployeePersonalMaster_tbl.Status = N'A') AND  (EmpContract_tbl.ContractType = N'Contractual')";


                }
                else
                {
                    Query1 = "SELECT     EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], " +
             "        EmpContract_tbl.ActualJoiningDate, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, EmpContract_tbl.Endtime " +
" FROM         EmployeePersonalMaster_tbl INNER JOIN " +
            "         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN " +
              "       EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
" WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeeDesignation_tbl.DepartmeentPk = @Param2) AND (EmployeePersonalMaster_tbl.Status = N'A') AND  (EmpContract_tbl.ContractType = N'Contractual')";


                }

                SqlCommand cmd = new SqlCommand(Query1, con);
                cmd.Parameters.AddWithValue("@Param1", BranchlocationPK);
                if (deptid != 0)
                {
                    cmd.Parameters.AddWithValue("@Param2", deptid);
                }
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
        /// get the contract details of the all the employees of a location and department
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="BranchlocationPK"></param>
        /// <returns></returns>
        public DataTable getcontractofallemployeeofadeptandlocation(int deptid, int BranchlocationPK,String Permamenttype)
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                String Query1 = "";

                con.Open();
                if (deptid == 0)
                {
                    Query1 = "SELECT     EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], " +
                   "        EmpContract_tbl.ActualJoiningDate, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, EmpContract_tbl.Endtime " +
     " FROM         EmployeePersonalMaster_tbl INNER JOIN " +
                  "         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN " +
                    "       EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
     " WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @Param1)  AND (EmployeePersonalMaster_tbl.Status = N'A') AND  (EmpContract_tbl.ContractType = N'Permanent')";


                }
                else
                {
                    Query1 = "SELECT     EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], " +
             "        EmpContract_tbl.ActualJoiningDate, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, EmpContract_tbl.Endtime " +
" FROM         EmployeePersonalMaster_tbl INNER JOIN " +
            "         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN " +
              "       EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid " +
" WHERE     (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeeDesignation_tbl.DepartmeentPk = @Param2) AND (EmployeePersonalMaster_tbl.Status = N'A') AND  (EmpContract_tbl.ContractType = N'Permanent')";


                }

                SqlCommand cmd = new SqlCommand(Query1, con);
                cmd.Parameters.AddWithValue("@Param1", BranchlocationPK);
                if (deptid != 0)
                {
                    cmd.Parameters.AddWithValue("@Param2", deptid);
                }
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
        /// 
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="BranchlocationPK"></param>
        /// <returns></returns>
        public DataTable getemployeedetailsforChangingLocation(int deptid, int BranchlocationPK)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT        EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], EmployeePersonalMaster_tbl.First_name +''+  " +
                     "    EmployeePersonalMaster_tbl.Last_Name as Empname, EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], CONVERT(date, EmpContract_tbl.ActualJoiningDate) AS JoiningDate, " +
                    "     EmpContract_tbl.ContractType, DepartmentMaster_tbl.DepartmentName, BranchLocartionMaster_tbl.BranchLocationCode, " +
                   "      BranchLocartionMaster_tbl.BranchLocationName ,EmployeeDesignation_tbl.BranchLocationPK " +
"FROM            EmployeePersonalMaster_tbl INNER JOIN " +
                    "     EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN " +
                    "     EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN " +
                     "    DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN " +
                      "   DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN " +
                       "  BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk  " +
             "   WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeeDesignation_tbl.DepartmeentPk = @Param2)", con);
                cmd.Parameters.AddWithValue("@Param1", BranchlocationPK);
                cmd.Parameters.AddWithValue("@Param2", deptid);
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
        /// get employeedata along with Shift
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="BranchlocationPK"></param>
        /// <returns></returns>
        public DataTable getemployeedetailswithShift(int deptid, int BranchlocationPK)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], 
                         EmployeePersonalMaster_tbl.First_name + '' + EmployeePersonalMaster_tbl.Last_Name AS Empname, EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], 
                         CONVERT(date, EmpContract_tbl.ActualJoiningDate) AS JoiningDate, EmpContract_tbl.ContractType, DepartmentMaster_tbl.DepartmentName, 
                         EmployeeDesignation_tbl.BranchLocationPK, DesignationMaster_tbl.DesignationName, ShiftMasterNew_tbl.ShiftName
FROM            EmployeePersonalMaster_tbl INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN
                         ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK
WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeeDesignation_tbl.DepartmeentPk = @Param2)", con);
                cmd.Parameters.AddWithValue("@Param1", BranchlocationPK);
                cmd.Parameters.AddWithValue("@Param2", deptid);
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
        /// get the details of employee including bank and account number
        /// </summary>
        /// <param name="BranchlocationPK"></param>
        public DataTable getemployeedetailswithBankDetails(int BranchlocationPK)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                         EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS empname, DesignationMaster_tbl.DesignationName, 
                         DepartmentMaster_tbl.DepartmentName, BranchLocartionMaster_tbl.BranchLocationName, BranchMaster_tbl.BranchName, CompanyMaster_tbl.CompanyName, 
                         EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.EmpGender, EmployeePersonalMaster_tbl.Status, 
                         EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, BankMaster_tbl.BankName, 
                         EmployesalaryDetails_tbl.accountnum
FROM            DepartmentMaster_tbl INNER JOIN
                         DesignationMaster_tbl ON DepartmentMaster_tbl.DepartmentPK = DesignationMaster_tbl.DepartmentPK INNER JOIN
                         EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON 
                         DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN
                         BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN
                         CompanyMaster_tbl ON BranchMaster_tbl.CompanyPk = CompanyMaster_tbl.CompanyPk INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         EmployesalaryDetails_tbl ON EmployeePersonalMaster_tbl.empid = EmployesalaryDetails_tbl.empid LEFT OUTER JOIN
                         BankMaster_tbl ON EmployesalaryDetails_tbl.Bankpk = BankMaster_tbl.BankPK ", con);

                cmd.Parameters.AddWithValue("@branchpk", BranchlocationPK);
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {

                con.Close();
            }

            return dt;
        }


        /// <summary>
        /// get all employees details with a NID
        /// </summary>
        /// <param name="nationalID"></param>
        /// <returns></returns>
        public DataTable getnationalidePLOYEE(String nationalID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.Status, EmployeePersonalMaster_tbl.First_name, 
                         EmployeePersonalMaster_tbl.Last_Name, BranchLocartionMaster_tbl.BranchLocationName, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, 
                         EmpContract_tbl.Endtime, EmpContract_tbl.ActualJoiningDate, EmployeePersonalMaster_tbl.NationalId
FROM            EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk
WHERE        (EmployeePersonalMaster_tbl.NationalId = @Param1)
 ", con);

                cmd.Parameters.AddWithValue("@Param1", nationalID);
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {

                con.Close();
            }

            return dt;
        }










        /// <summary>
        /// get the employee details of a location and department
        /// for OT purpose
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="BranchlocationPK"></param>
        /// <returns></returns>
        public DataTable geTmployeeofadeptandlocation(int deptid, int BranchlocationPK)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT        EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], " +
                    "     EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS EmpName, DepartmentMaster_tbl.DepartmentName, " +
                  "       DesignationMaster_tbl.DesignationName, EmpContract_tbl.ContractType, EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ActualJoiningDate, " +
                   "      EmployeeDesignation_tbl.IsOtApplicable " +
" FROM            EmployeeDesignation_tbl INNER JOIN " +
                  "       EmployeePersonalMaster_tbl ON EmployeeDesignation_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN " +
              "           EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN " +
                "         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN " +
                  "       DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK " +
"WHERE        (EmployeeDesignation_tbl.BranchLocationPK = @Param1) AND (EmployeeDesignation_tbl.DepartmeentPk = @Param2) ", con);
                cmd.Parameters.AddWithValue("@Param1", BranchlocationPK);
                cmd.Parameters.AddWithValue("@Param2", deptid);
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {

                con.Close();
            }

            return dt;

        }














        /// <summary>
        /// 
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="BranchlocationPK"></param>
        /// <returns></returns>
        public DataTable geTmployeeofaSubdeptandlocation(int deptid, int BranchlocationPK)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        EmployeePersonalMaster_tbl.empid AS ID, EmployeePersonalMaster_tbl.empno AS [EMP ID], EmployeePersonalMaster_tbl.oldempid AS [OLD EMP ID], 
                         EmployeePersonalMaster_tbl.First_name + ' ' + EmployeePersonalMaster_tbl.Last_Name AS EmpName, DepartmentMaster_tbl.DepartmentName, 
                         DesignationMaster_tbl.DesignationName, EmpContract_tbl.ContractType, EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ActualJoiningDate, 
                         EmployeeDesignation_tbl.IsOtApplicable, SubDepartmentMaster_tbl_1.SubDeptName
FROM            EmployeeDesignation_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON EmployeeDesignation_tbl.empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk = DesignationMaster_tbl.DesgnationPK INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK LEFT OUTER JOIN
                         SubDepartmentMaster_tbl AS SubDepartmentMaster_tbl_1 ON EmployeeDesignation_tbl.SubdeptPK = SubDepartmentMaster_tbl_1.SubDeptPK WHERE        EmployeeDesignation_tbl.BranchLocationPK = @Param1 AND EmployeeDesignation_tbl.DepartmeentPk = @Param2", con);
                cmd.Parameters.AddWithValue("@Param1", BranchlocationPK);
                cmd.Parameters.AddWithValue("@Param2", deptid);
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {

                con.Close();
            }

            return dt;

        }








        /// <summary>
        /// INSERT THE EMPLOYEE APRECIATION
        /// </summary>
        /// <param name="warningdata"></param>
        public void insertAprreciation(ArrayList Aprreciationdata)
        {
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO AppreciationMaster_tbl  (empid, AppreciationType, Reason, RecommendedBy, EmpName)VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5) ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", Aprreciationdata[0]);
                        command.Parameters.AddWithValue("@Param2", Aprreciationdata[1]);
                        command.Parameters.AddWithValue("@Param3", Aprreciationdata[2]);
                        command.Parameters.AddWithValue("@Param4", Aprreciationdata[3]);
                        command.Parameters.AddWithValue("@Param5", Program.EmpName);
                        //  command.Parameters.AddWithValue("@Param5", Aprreciationdata[4]);


                        command.ExecuteNonQuery();

                    }











                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }

        }

        /// <summary>
        /// INSERT PHOTOGRAPH OF EMPLOYEE
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="empid"></param>
        public void insertPhotograph(String filename, int empid)
        {

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    String Query = " If Not Exists(SELECT     empid FROM         EmployeePhotograph_tbl  WHERE     (empid = @Param1)) " +
"Begin " +
"INSERT INTO EmployeePhotograph_tbl  " +
 "                     (empid, ImageFilename) " +
"VALUES     (@Param1,@Param2)  " +
"End";

                    using (SqlCommand command = new SqlCommand(Query, sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", empid);
                        command.Parameters.AddWithValue("@Param2", filename);
                        command.ExecuteNonQuery();

                    }

                    sqlConnection1.Close();


                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }

        }

        /// <summary>
        /// will return the location of the employee
        /// photographs
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public String getEmployeehotographLocation(int empid)
        {
            DataTable contractdata = new DataTable();
            String picPath = "";
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT     ImageFilename  FROM  EmployeePhotograph_tbl WHERE     (empid = @Param1)", con))
                {
                    cmd.Parameters.AddWithValue("@Param1", empid);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    contractdata.Load(reader);


                    reader.Close();


                    if (contractdata != null)
                    {
                        if (contractdata.Rows.Count != 0)
                        {
                            picPath = contractdata.Rows[0][0].ToString();
                        }

                    }
                    con.Close();
                }

            }

            return picPath;
        }

        /// <summary>
        /// get a dataset of all the employee data
        /// for edit
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable getalltheemployeedataforedit(int empid, string datatype)
        {

            DataTable dt1 = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("AllEmployeeAllData_sp", con);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@employeedatatype", datatype);

                SqlDataReader sqlReader = cmd.ExecuteReader();

                dt1.Load(sqlReader);
                con.Close();
            }
            return dt1;


        }



        /// <summary>
        /// insert the perk of an employee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="perkpk"></param>
        /// <param name="amount"></param>
        /// <param name="taxable"></param>
        public void insertperk(int empid, float perkpk, float amount, float taxable)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(" INSERT INTO EmployeePerk_Master (empid, PerkPK, Amount, TaxableAmount) VALUES        (@Param1,@Param2,@Param3,@Param4)", con))
                {

                    cmd.Parameters.AddWithValue("@Param1", empid);
                    cmd.Parameters.AddWithValue("@Param2", perkpk);
                    cmd.Parameters.AddWithValue("@Param3", amount);
                    cmd.Parameters.AddWithValue("@Param4", taxable);

                    cmd.ExecuteNonQuery();
                    Actionlog.actiondone("Insert  Employee Perk", "of employeeID " + empid + " Inserted perk PK" + perkpk + " and amount " + amount + "",empid);
                }
                con.Close();
            }
        }



        /// <summary>
        /// DONT USE IT UNLESS YOU WANT TO DELETE THE EMPLOYEE DIRECTLY FROM DB
        /// IF EMPLOYEE ID IS ZERO THE WHOLE LOCATION EMPLOYEES WILL BE DELETED
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="branchlocationpk"></param>
        public void DeleteEmployeeFromDB(int empid, int branchlocationpk)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteEmployee_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchlctnPk", branchlocationpk);
                cmd.Parameters.AddWithValue("@Empid", empid);
                cmd.ExecuteNonQuery();
                Actionlog.actiondone("Delete Employee", "of employeeID " + empid,empid);
                con.Close();
            }
        }



        /// <summary>
        /// hold an Employee Payroll
        /// </summary>
        /// <param name="empid"></param>
        public void HoldPayrollOfEmployee(int empid)
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE       EmployeeDesignation_tbl SET isPayrollHold = 'Y' WHERE (EmpId = @empid)", con))
                {

                    cmd.Parameters.AddWithValue("@empid", empid);


                    cmd.ExecuteNonQuery();
                    Actionlog.actiondone("Hold Employee", "of employeeID " + empid + " Updated to Y",empid);
                }
                con.Close();
            }


        }

        /// <summary>
        /// unhold the Employee Payroll
        /// </summary>
        /// <param name="empid"></param>
        public void unHoldPayrollOfEmployee(int empid)
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE       EmployeeDesignation_tbl SET isPayrollHold = 'N' WHERE (EmpId = @empid)", con))
                {

                    cmd.Parameters.AddWithValue("@empid", empid);


                    cmd.ExecuteNonQuery();
                    Actionlog.actiondone("Hold Employee", "of employeeID " + empid + " Updated to N",empid);
                }
                con.Close();
            }


        }

        /// <summary>
        /// select salary component for exporting
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable GetemployeeSalaryComponentforExporting(int empid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT        SalcompPk, ISNULL ( Amount,0) as amount
FROM            EmployeesalCompApplicable_tbl
WHERE        (empid = @empid)", con);

                cmd.Parameters.AddWithValue("@empid", empid);
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);
                con.Close();
            }

            return dt;
        }


        /// <summary>
        /// Puts Appliocation for reusing the employee National ID
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="noofrepeats"></param>
        /// <param name="NationalID"></param>
        public void InsertApplicationNID(int empid, int noofrepeats, String NationalID)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO NIDApproval_tbl (NationalID, IsApproved, empid, NoofOccurance) VALUES  (@NationalID, N'N',@empid,@noofoccur)", con))
                {

                    cmd.Parameters.AddWithValue("@NationalID", NationalID);
                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@noofoccur", noofrepeats);


                    cmd.ExecuteNonQuery();
                    Actionlog.actiondone("Insert  Application for reemploying ", "of employeeID " + empid + " with nationalID " + NationalID + " and noof occurance " + noofrepeats + "",empid);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationalID"></param>
        /// <returns></returns>
        public DataTable getAllPendingNationalIDApproval()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT     NIDApproval_tbl.Appid,   EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.Status, 
                         EmployeePersonalMaster_tbl.First_name, EmployeePersonalMaster_tbl.Last_Name, BranchLocartionMaster_tbl.BranchLocationName, 
                         EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, EmpContract_tbl.Endtime, EmpContract_tbl.ActualJoiningDate
FROM            EmployeePersonalMaster_tbl INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN
                         NIDApproval_tbl ON EmployeePersonalMaster_tbl.empid = NIDApproval_tbl.empid
WHERE        (NIDApproval_tbl.IsApproved = N'N')", con);


                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {

                con.Close();
            }

            return dt;
        }


        public void updateNIDStatus(int appid)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(@"UPDATE       NIDApproval_tbl
SET                IsApproved = N'Y', ApprovedBy = @Param1, Approveddate = GETDATE()
WHERE        (Appid = @appid)", con))
                {

                    cmd.Parameters.AddWithValue("@appid", appid);
                    cmd.Parameters.AddWithValue("@Param1", Program.USERPK);


                    cmd.ExecuteNonQuery();
                    Actionlog.actiondone("Insert  Application for reemploying ", "Approval for reusing nationalID under ApplicationID " + appid + " Done", appid);
                }
            }
        }



        /// <summary>
        /// get the bank details of an employee
        /// </summary>
        /// <param name="branchpk"></param>
        /// <returns></returns>

        public DataTable getAllEmployeebankDetail(int branchpk)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT View_BankDetails.* FROM  View_BankDetails WHERE   (BranchlLocationPk = @Param1)", con);

                cmd.Parameters.AddWithValue("@Param1", branchpk);
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {

                con.Close();
            }

            return dt;
        }


        /// <summary>
        /// get ALL EMPLOYEES abscent for past 10 days continously of the date given
        /// 
        /// </summary>
        /// <param name="datetoday"></param>
        public DataTable getalldesertyemployee(DateTime datetoday)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT     EmployeePersonalMaster_tbl.empid, EmployeePersonalMaster_tbl.empno, 
                      EmployeePersonalMaster_tbl.First_name + '  ' + EmployeePersonalMaster_tbl.Last_Name AS empname, DesignationMaster_tbl.DesignationName, 
                      DepartmentMaster_tbl.DepartmentName, BranchLocartionMaster_tbl.BranchLocationName, BranchMaster_tbl.BranchName, CompanyMaster_tbl.CompanyName, 
                      EmployeePersonalMaster_tbl.NationalId, EmployeePersonalMaster_tbl.PassportNo, EmployeePersonalMaster_tbl.EmpGender, EmployeePersonalMaster_tbl.Status, 
                      EmployeePersonalMaster_tbl.EmpNation, EmpContract_tbl.ContractType, EmpContract_tbl.Startdate, ShiftMasterNew_tbl.ShiftName 
FROM         DepartmentMaster_tbl INNER JOIN 
                      DesignationMaster_tbl ON DepartmentMaster_tbl.DepartmentPK = DesignationMaster_tbl.DepartmentPK INNER JOIN 
                      EmployeePersonalMaster_tbl INNER JOIN 
                      EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid ON 
                      DesignationMaster_tbl.DesgnationPK = EmployeeDesignation_tbl.DesignationPk INNER JOIN 
                      BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk INNER JOIN 
                      BranchMaster_tbl ON BranchLocartionMaster_tbl.BranchPk = BranchMaster_tbl.BranchPK INNER JOIN 
                      CompanyMaster_tbl ON BranchMaster_tbl.CompanyPk = CompanyMaster_tbl.CompanyPk INNER JOIN 
                      EmpContract_tbl ON EmployeePersonalMaster_tbl.empid = EmpContract_tbl.EmpId INNER JOIN 
                      EmployeShift_tbl ON EmployeePersonalMaster_tbl.empid = EmployeShift_tbl.Empid INNER JOIN 
                      ShiftMasterNew_tbl ON EmployeShift_tbl.Shiftpk = ShiftMasterNew_tbl.ShiftPK 
WHERE     (EmployeePersonalMaster_tbl.Status = N'A')  and EmployeePersonalMaster_tbl.empid in (Select empid from (
select empid,count(*) as Cnt from EmpSwipedataBank_tbl where SwipeDate between DATEADD(Day,-10,@date) and @date and ApprInstatus='A' and ApprOutStatus='A' group by empid )tt where cnt>=10)", con);

                cmd.Parameters.AddWithValue("@date", datetoday.ToString("MM-dd-yyyy"));
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);


            }
            finally
            {

                con.Close();
            }

            return dt;
        }




    }
}
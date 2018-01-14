using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ATCHRM.Transactions
{
    class AnualContractrenewal
    {
        Transactions.EmployeeRegTransaction empregtrans = null;
        Datalayer.contractannualrenewal cntrctanualrenewal = null;
        DataTable empcontractdata = null;
        DataTable empsubcontracttable = null;

        public AnualContractrenewal()
        {
            empregtrans = new Transactions.EmployeeRegTransaction();          
            cntrctanualrenewal = new Datalayer.contractannualrenewal();

        }

        public void insertAnnualContractforexistingEmployee(int empid)
        {

            try
            {


                empcontractdata = getContractID(empid );

                if (empcontractdata.Rows.Count != 0)
                {
                    empsubcontracttable = getallsubcontractdetails(int.Parse(empcontractdata.Rows[0][1].ToString()));

                    insertContractSubdetails(empcontractdata, empsubcontracttable);
                }
                else
                {

                     ATCHRM.Controls.ATCHRMMessagebox.Show("No Main Contract Details Found");
                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
            }


        }






        /// <summary>
        /// get the contract id of the person
        /// </summary>
        /// <param name="EMPID"></param>
        /// <returns></returns>
        public DataTable getContractID(int EMPID)
        {
            DataTable cntrcttable = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     TOP (1) EmpId,Contractid, ContractType, Startdate, Endtime, ActualJoiningDate FROM         EmpContract_tbl WHERE     (EmpId = @Param1)", con);
                cmd.Parameters.AddWithValue("@Param1", EMPID);

                SqlDataReader reader = cmd.ExecuteReader();

                cntrcttable.Load(reader);


                reader.Close();
                con.Close();
            }
            return cntrcttable;
        }



        public DataTable getallsubcontractdetails(int contractid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT     empid, Contractid, ToDate, CurrentYear, FromDate, RenewedDate FROM    EmpContractDetail_tbl WHERE     (Contractid = @Param1)", con);
                cmd.Parameters.AddWithValue("@Param1", contractid);

                SqlDataReader reader = cmd.ExecuteReader();




                dt.Load(reader);
                con.Close();

            }

            return dt;

        }


        public void insertContractSubdetails( DataTable empcontractdata, DataTable empcntrctsubdata)
        {
            DateTime maxLavel = DateTime.Now.Date;
            DateTime newfromdate=DateTime.Now.Date ;
            DateTime newtodate = DateTime.Now.Date;
            DateTime contractendtimeday = DateTime.Now.Date;
            if (empcntrctsubdata.Rows.Count != 0)
            {
                //changed by sreenath
                maxLavel = Convert.ToDateTime(empcntrctsubdata.Compute("max(ToDate)", string.Empty)); //maximum date of subcontract

                newfromdate = Convert.ToDateTime(empcontractdata.Compute("max(Startdate)", string.Empty));// Statrt date of contracttable
                newtodate = Convert.ToDateTime(empcontractdata.Compute("max(Endtime)", string.Empty));// end date of contracttable




                if (newfromdate.Year == newtodate.Year)
                {


                }




              //  maxLavel = Convert.ToDateTime(empcontractdata.Compute("max(ToDate)", string.Empty));
               if (maxLavel == newfromdate)
               {
                   cntrctanualrenewal.Fromdate1 = maxLavel;
               }
              
               else
               {
                   cntrctanualrenewal.Fromdate1 = newfromdate;
                   maxLavel = newfromdate;
               }

               
                contractendtimeday = new DateTime(maxLavel.Year, 12, 31);
            }
            else
            {
                if (empcontractdata.Rows[0][5].ToString() != null && empcontractdata.Rows[0][5].ToString() != "")
                {
                    cntrctanualrenewal.Actualjoiningdate = DateTime.Parse(empcontractdata.Rows[0][5].ToString());
                }
                else
                {
                    cntrctanualrenewal.Actualjoiningdate = DateTime.Now.Date;
                }




                cntrctanualrenewal.Fromdate1 = cntrctanualrenewal.Actualjoiningdate;

                contractendtimeday = new DateTime(maxLavel.Year, 12, 31);



            }






          
          
            if (empcontractdata != null && empcontractdata.Rows.Count != 0)
            {

                cntrctanualrenewal.Empid = int.Parse(empcontractdata.Rows[0][0].ToString());
                cntrctanualrenewal.Contractid = int.Parse(empcontractdata.Rows[0][1].ToString());



                String yearstart = cntrctanualrenewal.Fromdate1.Year.ToString();

                String endyear = contractendtimeday.Year.ToString();

             

                cntrctanualrenewal.CurrentYear1 = yearstart + "-" + endyear;

                cntrctanualrenewal.Todate1 = contractendtimeday;



            }
            if (!ifContractOver(cntrctanualrenewal, empcontractdata, empcntrctsubdata))
            {
                enterrenewal(cntrctanualrenewal);
                
            }
            else
            {
                cntrctanualrenewal.Todate1 = DateTime.Parse(empcontractdata.Rows[0][4].ToString());
                enterrenewal(cntrctanualrenewal);
              
            }


            //else
            //{

            //     ATCHRM.Controls.ATCHRMMessagebox.Show("Contract Cannot Be Renewed Please Use a Contract Renewal Application");
            //}


        }

        /// <summary>
        /// check whether the new annal contract renewal of sub details exceed the 
        /// actual contract period
        /// Also check whether there is any more record
        /// </summary>
        /// <param name="cntrctanualrenewal"></param>
        /// <param name="empcontractdata"></param>
        /// <param name="empcntrctsubdata"></param>
        /// <returns></returns>
        private Boolean ifContractOver(Datalayer.contractannualrenewal cntrctanualrenewal, DataTable empcontractdata, DataTable empcntrctsubdata)
        {
            Boolean isOver = false;


            if (empcontractdata != null)
            {

                if (cntrctanualrenewal.Todate1 > DateTime.Parse(empcontractdata.Rows[0][4].ToString()))
                {
                    isOver = true;

                }




            }


            return isOver;
        }




        private void enterrenewal(Datalayer.contractannualrenewal cntrctanualrenewal)
        {







            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                con.Open();


                try
                {
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM EmpContractDetail_tbl " +
         "WHERE        (empid = @empid) AND ((FromDate BETWEEN @operand1 AND @operand2) or (ToDate BETWEEN @operand1 AND " +
          "                    @operand2) or ( @operand1 BETWEEN FromDate AND ToDate) or  ( @operand2 BETWEEN FromDate AND ToDate) ) ", con);

                    cmd1.Parameters.AddWithValue("@empid", cntrctanualrenewal.Empid);
                    cmd1.Parameters.AddWithValue("@operand1", cntrctanualrenewal.Fromdate1);
                    cmd1.Parameters.AddWithValue("@operand2", cntrctanualrenewal.Todate1);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception exp)
                {

                     ATCHRM.Controls.ATCHRMMessagebox.Show("Destructive code: Tying to delete old contract data of employee");
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);


                }



                SqlCommand cmd = new SqlCommand("INSERT INTO EmpContractDetail_tbl " +
                    "  (empid, Contractid, CurrentYear, FromDate, ToDate, RenewedDate)" +
"VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,getdate())", con);
                cmd.Parameters.AddWithValue("@Param1", cntrctanualrenewal.Empid);
                cmd.Parameters.AddWithValue("@Param2", cntrctanualrenewal.Contractid);
                cmd.Parameters.AddWithValue("@Param3", cntrctanualrenewal.CurrentYear1);
                cmd.Parameters.AddWithValue("@Param4", cntrctanualrenewal.Fromdate1);
                cmd.Parameters.AddWithValue("@Param5", cntrctanualrenewal.Todate1);
                //   cmd.Parameters.AddWithValue("@Param6", DateTime.Now.Date);

                SqlDataReader reader = cmd.ExecuteReader();





                con.Close();
            }



        }





        public DataTable getCurrentSubContract(int empid)
        {
            DataTable dt = new DataTable();

            DataTable cntrcttable = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     EmpContract_tbl.Contractid, EmpContractDetail_tbl.CurrentYear, EmpContractDetail_tbl.FromDate, EmpContractDetail_tbl.ToDate,EmpContract_tbl.ActualJoiningDate " +
" FROM         EmpContractDetail_tbl INNER JOIN "+
    "  EmpContract_tbl ON EmpContractDetail_tbl.Contractid = EmpContract_tbl.Contractid "+
" WHERE     (EmpContractDetail_tbl.empid = @empid) AND (EmpContractDetail_tbl.FromDate <= GETDATE()) AND (EmpContractDetail_tbl.ToDate >= GETDATE())", con);
                cmd.Parameters.AddWithValue("@empid", empid);

                SqlDataReader reader = cmd.ExecuteReader();

                cntrcttable.Load(reader);


                if (cntrcttable.Rows.Count == 0)
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("No sub contract Data");
                }

                reader.Close();
                con.Close();
            }
            return cntrcttable;


            
        }





        /// <summary>
        /// get all the contract of an emoployee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable GetAllContractOfAnEmployee(int empid)
        {
            

            DataTable cntrcttable = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     Contractid, ContractType, convert (date,Startdate) as startdate ,convert (date, Endtime)  as enddate " +
"FROM         EmpContract_tbl "+
"WHERE     (EmpId = @empid) and (ContractType!='Temporary' )", con);
                cmd.Parameters.AddWithValue("@empid", empid);

                SqlDataReader reader = cmd.ExecuteReader();

                cntrcttable.Load(reader);


                reader.Close();
                con.Close();
            }

            System.Data.DataColumn newColumn = new System.Data.DataColumn("Contractperiod", typeof(System.String));
            newColumn.DefaultValue = "Not Available";
            cntrcttable.Columns.Add(newColumn);
            for (int i = 0; i < cntrcttable.Rows.Count; i++)
             {

                 string startdate = DateTime.Parse(cntrcttable.Rows[0][2].ToString()).ToString("dd-MM-yyyy"); ;
                 string enddate = DateTime.Parse(cntrcttable.Rows[0][3].ToString()).ToString("dd-MM-yyyy"); ;

                 String duration = startdate + "---" + enddate;
                 cntrcttable.Rows[i][4] = duration;

             }


            return cntrcttable;



        }

        /// <summary>
        /// get all the annula renewal against a 
        /// main contract
        /// </summary>
        /// <param name="contractid"></param>
        /// <returns></returns>
        public DataTable getallsubcontract(int contractid)
        {

            DataTable dt = new DataTable();

            DataTable cntrcttable = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     Contractid, CurrentYear, FromDate, ToDate FROM   EmpContractDetail_tbl WHERE     (Contractid = @contractid)", con);
                cmd.Parameters.AddWithValue("@contractid", contractid);

                SqlDataReader reader = cmd.ExecuteReader();

                cntrcttable.Load(reader);


                reader.Close();
                con.Close();
            }
            return cntrcttable;
        }






        public Boolean  ifdatevalidContractdate(int empid, DateTime dt)
        {
            Boolean ISOK = false;
            DataTable cntrcttable = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     TOP (1) EmpId,Contractid, ContractType, Startdate, Endtime, ActualJoiningDate FROM         EmpContract_tbl WHERE     (EmpId = @Param1)", con);
                cmd.Parameters.AddWithValue("@Param1", empid);

                SqlDataReader reader = cmd.ExecuteReader();

                cntrcttable.Load(reader);


                reader.Close();
                con.Close();



                if (cntrcttable.Rows.Count != 0)
                {



                    if ((Convert.ToDateTime(cntrcttable.Rows[0][3]) <= dt) && (Convert.ToDateTime(cntrcttable.Rows[0][4]) >= dt))
                    {
                        ISOK = true;
                    }
                    else
                    {
                        ISOK = false;
                    }

                }
                else
                {
                    ISOK = false;
                }



            }

            return ISOK;

        }











       
    }
}

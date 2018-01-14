using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;
namespace ATCHRM.Transactions.PayrollTransaction
{
    class MainPayrollTransaction
    {

        Transactions.PayrollTransaction.SalaryCalculatuionTransaction salpaytrans = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="payrolldatbean"></param>
        /// <returns></returns>
        public int InsertPayroll(Datalayer.PayrollDatabean payrolldatbean)
        {
            int Payrollid = 0;
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO Payroll_PayMaster  " +
              "        (Pay_Start_Date, Pay_Loc, Emp_Count, Pay_End_Date, Department_id,UserPK,Payroll_Month)  " +
"VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6 ,@Param7) ;SELECT SCOPE_IDENTITY()  ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", payrolldatbean.Payrollfromdate);
                        command.Parameters.AddWithValue("@Param2", payrolldatbean.BranchlocationPK1);
                        command.Parameters.AddWithValue("@Param3", payrolldatbean.Empcount);
                        command.Parameters.AddWithValue("@Param4", payrolldatbean.PayrollEndDate);
                        command.Parameters.AddWithValue("@Param5", payrolldatbean.Deptid);

                        command.Parameters.AddWithValue("@Param6", Program.USERPK);


                        command.Parameters.AddWithValue("@Param7", payrolldatbean.Payrollmonth);



                        Payrollid = int.Parse(command.ExecuteScalar().ToString());

                    }

                    sqlConnection1.Close();

                }

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
            }

            return Payrollid;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="Month"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        public void insertpayrollcalender(String year, String Month, DateTime startdate, DateTime enddate, int noofdays)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO PayrollCalenderMaster_tbl (Year, Month, StartDate, Endate,NoOfDays)  VALUES   (@Param1,@Param2,@Param3,@Param4,@Param5) ", con);


                cmd.Parameters.AddWithValue("@Param1", year);
                cmd.Parameters.AddWithValue("@Param2", Month);
                cmd.Parameters.AddWithValue("@Param3", startdate);

                cmd.Parameters.AddWithValue("@Param4", enddate);
                cmd.Parameters.AddWithValue("@Param5", noofdays);
                cmd.ExecuteNonQuery();
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

            }
        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="arry"></param>
//        /// <param name="dayadiff"></param>
//        public void insertemployeePayrollDetails(ArrayList arry, int dayadiff)
//        {
//            float  basic = 0;
//            float  hra = 0;
//            float  nssf = 0;
//            float  nhif = 0;
//            int othours = 0;
//            int offothours = 0;
//            int Payrolldetid = 0;
//            float  specialallowance = 0;
//            int holidays = 0;
            


//            basic = getbasicofemployee(arry, dayadiff);
//            specialallowance = getemployeeComponent(int.Parse(arry[1].ToString()), "SPECIAL ALLOWANCE");
//            hra = getemployeeComponent(int.Parse(arry[1].ToString()), "HRA");
//            nssf = getemployeeComponent(int.Parse(arry[1].ToString()), "NSSF");
//            nhif = getemployeeComponent(int.Parse(arry[1].ToString()), "NHIF");
//            othours = getoOTDone(int.Parse(arry[1].ToString()));
//            offothours = getOffOTDone(int.Parse(arry[1].ToString()));
//            holidays = gettheholidaysforemployeeincontract(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString()), dayadiff);
//            try
//            {

//                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
//                {


//                    sqlConnection1.Open();


//                    using (SqlCommand command = new SqlCommand("insert into Payroll_PayDetails (pay_id,emp_id,total_salary,Disburs_Amnt,Deduct_Amnt,leave_days,absent_no,ot_amnt,Special_Allow,holidayno) " +
//" values(@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10) ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
//                    {

//                        command.Parameters.AddWithValue("@Param1", arry[0].ToString());
//                        command.Parameters.AddWithValue("@Param2", arry[1].ToString());
//                        command.Parameters.AddWithValue("@Param3", arry[2].ToString());
//                        command.Parameters.AddWithValue("@Param4", arry[3].ToString());
//                        command.Parameters.AddWithValue("@Param5", arry[4].ToString());
//                        command.Parameters.AddWithValue("@Param6", arry[5].ToString());

//                        command.Parameters.AddWithValue("@Param7", arry[6].ToString());

//                        command.Parameters.AddWithValue("@Param8", arry[7].ToString());

//                        command.Parameters.AddWithValue("@Param9", specialallowance);
//                        command.Parameters.AddWithValue("@Param10", holidays);

//                        Payrolldetid = int.Parse(command.ExecuteScalar().ToString());

//                    }


//                    using (SqlCommand command = new SqlCommand("	UPDATE    Payroll_PayDetails " +
//" SET              Basic_Sal = @Param1, HRA_Allow = @Param2, NSSF = @Param3, NHIF = @Param4, Ot_Hrs = @Param5, OfOt_Hrs = @Param6 " +
//" WHERE     (Emp_Id = @empid) AND (Pay_Id = @payid) AND (Pay_Det_Id = @paydetid)", sqlConnection1))
//                    {
//                        command.Parameters.AddWithValue("@Param1", basic);
//                        command.Parameters.AddWithValue("@Param2", hra);
//                        command.Parameters.AddWithValue("@Param3", nssf);
//                        command.Parameters.AddWithValue("@Param4", nhif);
//                        command.Parameters.AddWithValue("@Param5", othours);
//                        command.Parameters.AddWithValue("@Param6", offothours);

//                        command.Parameters.AddWithValue("@empid", arry[1].ToString());

//                        command.Parameters.AddWithValue("@payid", arry[0].ToString());

//                        command.Parameters.AddWithValue("@paydetid", Payrolldetid);

//                        command.ExecuteScalar();
                        
//                    }
                                        
//                    sqlConnection1.Close();

//                }

//            }
//            catch (Exception exp)
//            {
//                ErrorLogger er = new ErrorLogger();
//                er.createErrorLog(exp);

//            }


//        }


        public String isdesertee(int empid)
        {
            String deserteestatus = "N";
            using (SqlServerLinqDataContext cntxt= new SqlServerLinqDataContext (Program.ConnStr))
            {
                var q = from empdetails in cntxt.EmployeePersonalMaster_tbls
                        where empdetails.empid == empid
                        select empdetails;

                foreach (var element in q)
                {
                    //Contacttype = (element.IsDesertee.ToString().Trim() == "") ? "N" : element.IsDesertee.ToString().Trim();
                    if(element.IsDesertee == null)
                    {
                        deserteestatus = "N";
                    }else
                    {

                        if(element.IsDesertee.ToString ().Trim () =="N")
                        {
                            deserteestatus = "N";
                        }
                        else if (element.IsDesertee.ToString().Trim() == "P")
                        {
                            deserteestatus = "P";
                        }
                        else if (element.IsDesertee.ToString().Trim() == "F")
                        {
                            deserteestatus = "F";
                        }
                       
                    }

                }

            }
            return deserteestatus;
        }


        public String GetContracttype(int empid)
        {
            String Contacttype = "N";
            using (SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr))
            {
                var q = from empdetails in cntxt.EmpContract_tbls
                        where empdetails.EmpId == empid
                        select empdetails;

                foreach (var element in q)
                {
                    //Contacttype = (element.IsDesertee.ToString().Trim() == "") ? "N" : element.IsDesertee.ToString().Trim();
                    if (element.ContractType == null)
                    {
                        Contacttype = "N";
                    }
                    else
                    {

                        Contacttype = element.ContractType.ToString();

                    }

                }

            }
            return Contacttype;
        }


        public void insertemployeePayrollDetails(Datalayer.PayrollEmployeeDetailsDataBean  payEmpDetailDataBean )
        {
            int dayadiff = payEmpDetailDataBean.Payrolldays;
            float  basic = 0;
            float  hra = 0;
            float  nssf = 0;
            float  nhif = 0;
            int othours = 0;
            int offothours = 0;
            int actualothours = 0;
            int Extraminutes = 0;
            int Payrolldetid = 0;
            float  specialallowance = 0;
            int holidays = 0;
            float  actualbasic = 0;
            float perkamount = 0;
            float perktaxable = 0;
            float advancepayback = 0;
            float employeeworkedday = dayadiff;
            int extraday = 0;
            int lessday = 0;
            ArrayList arry = payEmpDetailDataBean.Empdataarray;

            int empid=int.Parse(arry[1].ToString());
            DateTime fromdate = payEmpDetailDataBean.PayrollFromDate.Date;
            DateTime todate = payEmpDetailDataBean.payrollToDate.Date;

            if (dayadiff > 30 && payEmpDetailDataBean.Offdays < 5)
            {
             //   extraday = dayadiff - 30;
                
            }
            else if (dayadiff < 30 && payEmpDetailDataBean.Offdays > 3)
            {
             //   lessday = 30 - dayadiff;
            }
            
            try
            {
                actualbasic = getemployeeComponent(empid, "BASIC");
               
                //done by sreenath asper abhishek on 21-03-2015
                int paydaysasper26 = dayadiff + lessday - extraday;
                basic = getbasicofemployee(arry, paydaysasper26,payEmpDetailDataBean.Payrollofthemonth);
             

            }
            catch (Exception exp )
            {
                
               ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp, "Error At Calculating the Basic of EmpID: "+empid.ToString ());
            }
            float ABSCENTNUM= float.Parse (  arry[6].ToString());
            try
            {
                //   ABSCENTNUM = ABSCENTNUM ;
                //specialallowance = getemployeeComponent(empid, "SPECIAL ALLOWANCE");
                //specialallowance = (specialallowance / payEmpDetailDataBean.Payrollofthemonth) * (dayadiff - (ABSCENTNUM + extraday));
                //Above part commented by sreenath asper hiren and Abhishhek



                int paydaysasper26 = dayadiff + lessday - extraday;
                specialallowance = getSpecialAllowance(arry, paydaysasper26, payEmpDetailDataBean.Payrollofthemonth);






                
                //done by sreenath asper abhishek on 21-03-2015
              

             //   specialallowance = (specialallowance / 26) * (dayadiff - (ABSCENTNUM+extraday));

                //done by sreenath asper abhishek on 13-01-2015
              //  specialallowance=getSpecialAllowance ()

              

            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp, "Error At Calculating the Special Allowance of EmpID: " + empid.ToString());
            }
            

            hra = getemployeeComponent(empid, "HRA");
         //   hra = (hra / 26) * (dayadiff - payEmpDetailDataBean.Offdays); 
            String deserteestatus=isdesertee(empid);
            //done by SREENATH ASPER advised by Hirenji
            if (deserteestatus == "F")
            {
                hra = (hra / payEmpDetailDataBean.Payrollofthemonth) * (dayadiff - (ABSCENTNUM + extraday)); 
            }
            else if (deserteestatus == "P"|| deserteestatus == "N")
            {
                hra = (hra / payEmpDetailDataBean.Payrollofthemonth) * (dayadiff); 
            }

          //  hra = (hra / payEmpDetailDataBean.Payrollofthemonth) * (dayadiff); 
            nssf = getemployeeComponent(empid, "NSSF");
            nhif = getemployeeComponent(empid, "NHIF");
            if (payEmpDetailDataBean.IsOtapplicable == true)
            {
                actualothours = getnormalOTDone(empid);
                othours = getoOTDone(empid);
                offothours = getOffOTDone(empid);
                Extraminutes = getExtraOTDone(empid);

            }
            perkamount = getPerkAmount(empid);
            perktaxable = getPerkTaxable(empid);
          //  holidays = gettheholidaysforemployeeincontract(int.Parse(arry[1].ToString()), fromdate, todate, dayadiff);
            advancepayback = getAdvancetoPay(empid, payEmpDetailDataBean.PayrollFromDate, payEmpDetailDataBean.payrollToDate );
            holidays = gettheholidaysforemployeeincontract(int.Parse(arry[1].ToString()), fromdate, todate, dayadiff);

            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("insert into Payroll_PayDetails (pay_id,emp_id,total_salary,Disburs_Amnt,Deduct_Amnt,leave_days,absent_no,ot_amnt,Special_Allow,holidayno,offdays,Payrolldays ,ActualBasic ,PerkAmount,PerkTaxable,LeaveOnOff,PaidLeaves,halfdayleave,halfdayAbscent,LeaveOnHoliday) " +
" values(@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10 ,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20) ;SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {

                        command.Parameters.AddWithValue("@Param1", arry[0].ToString());
                        command.Parameters.AddWithValue("@Param2", arry[1].ToString());
                        command.Parameters.AddWithValue("@Param3", arry[2].ToString());
                        command.Parameters.AddWithValue("@Param4", arry[3].ToString());
                        command.Parameters.AddWithValue("@Param5", arry[4].ToString());
                        command.Parameters.AddWithValue("@Param6", arry[5].ToString());

                        command.Parameters.AddWithValue("@Param7", arry[6].ToString());

                        command.Parameters.AddWithValue("@Param8", arry[7].ToString());

                        command.Parameters.AddWithValue("@Param9", specialallowance);
                        command.Parameters.AddWithValue("@Param10", payEmpDetailDataBean.Holidayno );
                        command.Parameters.AddWithValue("@Param11", payEmpDetailDataBean.Offdays);
                        command.Parameters.AddWithValue("@Param12", dayadiff );
                        command.Parameters.AddWithValue("@Param13", actualbasic);
                        command.Parameters.AddWithValue("@Param14", perkamount);
                        command.Parameters.AddWithValue("@Param15", perktaxable);
                        command.Parameters.AddWithValue("@Param16", payEmpDetailDataBean.LeaveonOffday1 );
                        command.Parameters.AddWithValue("@Param17", payEmpDetailDataBean.Paidleaves);
                        command.Parameters.AddWithValue("@Param18", payEmpDetailDataBean.Halfdayleave );
                        command.Parameters.AddWithValue("@Param19", payEmpDetailDataBean.Halfdayabscent );
                        command.Parameters.AddWithValue("@Param20", payEmpDetailDataBean.Leaveonholiday);
                     Payrolldetid = int.Parse(command.ExecuteScalar().ToString());

                    }


                    using (SqlCommand command = new SqlCommand("	UPDATE    Payroll_PayDetails " +
" SET              Basic_Sal = @Param1, HRA_Allow = @Param2, NSSF = @Param3, NHIF = @Param4, Ot_Hrs = @Param5, OfOt_Hrs = @Param6,Normal_OTHours=@Param7,AdvanceToPay=@Param8 ,ExtraMinutes=@param9" +
" WHERE     (Emp_Id = @empid) AND (Pay_Id = @payid) AND (Pay_Det_Id = @paydetid)", sqlConnection1))
                    {
                        command.Parameters.AddWithValue("@Param1", basic);
                        command.Parameters.AddWithValue("@Param2", hra);
                        command.Parameters.AddWithValue("@Param3", nssf);
                        command.Parameters.AddWithValue("@Param4", nhif);
                        command.Parameters.AddWithValue("@Param5", othours);
                        command.Parameters.AddWithValue("@Param6", offothours);
                        command.Parameters.AddWithValue("@Param7", actualothours);
                        command.Parameters.AddWithValue("@Param8", advancepayback);
                        command.Parameters.AddWithValue("@Param9", Extraminutes);

                        command.Parameters.AddWithValue("@empid", arry[1].ToString());

                        command.Parameters.AddWithValue("@payid", arry[0].ToString());

                        command.Parameters.AddWithValue("@paydetid", Payrolldetid);

                      command.ExecuteScalar();

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


        public float  getPerkAmount(int empid)
        {
            float PerkAmount = 0;
           
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  SUM(Amount) AS Expr1 FROM EmployeePerk_Master
GROUP BY empid HAVING        (empid = @empid)", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {
                        PerkAmount = float.Parse(dt.Rows[0][0].ToString());
                       
                    }
                }


            }

            return PerkAmount;
        
        }

        public float getPerkTaxable(int empid)
        {
            
            float PerKtaxable = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT   SUM(TaxableAmount) AS Expr2 FROM EmployeePerk_Master
GROUP BY empid HAVING        (empid = @empid)", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {
                       
                        PerKtaxable = float.Parse(dt.Rows[0][0].ToString());
                    }
                }


            }

            return PerKtaxable;

        }

        public float GetHRA(ArrayList arry, int dayadiff)
        {
            float HRA = 0;
            int employeeworkdays = 0;
            int offdaysinperiod = 0;
            employeeworkdays = getthemeployeedaysaspercontract(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString()), dayadiff);
            offdaysinperiod = getEmployeeOffDaysOfAPeriod(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString())).Rows.Count;
            
            if (employeeworkdays <= dayadiff)
            {

                if (arry[8].ToString().Contains(" Januray-A"))
                {

                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * employeeworkdays;

                }
                else if (arry[8].ToString().Contains(" Januray-B"))
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * employeeworkdays;

                }
                else if (arry[8].ToString().Contains("December -A"))
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * employeeworkdays;
                }
                else if (arry[8].ToString().Contains("December -B"))
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * employeeworkdays;

                }
                else
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * employeeworkdays;
                }


            }
            else
            {
                if (arry[8].ToString().Contains(" Januray-A"))
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * dayadiff;

                }
                else if (arry[8].ToString().Contains(" Januray-B"))
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * dayadiff;

                }

                else if (arry[8].ToString().Contains("December -A"))
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * dayadiff;
                }
                else if (arry[8].ToString().Contains("December -B"))
                {
                    HRA = (getemployeeComponent(int.Parse(arry[1].ToString()), "HRA") / 26) * dayadiff;

                }
                else
                {
                    HRA = getemployeeComponent(int.Parse(arry[1].ToString()), "HRA");
                }
            }

            return HRA;












        }




















        public float getAdvancetoPay(int empid,DateTime fromdate ,DateTime todate)
        {

            float Advancepayable = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT        SUM(AdvancePayBackDetail_tbl.Amount) AS Expr1
FROM            AdvanceApplicationMaster_tbl INNER JOIN
                         AdvanceApprovalMaster_tbl ON AdvanceApplicationMaster_tbl.AdvanceAppPk = AdvanceApprovalMaster_tbl.AdvanceAppPk INNER JOIN
                         AdvancePayBackDetail_tbl ON AdvanceApplicationMaster_tbl.AdvanceAppPk = AdvancePayBackDetail_tbl.AdvanceAppPk
WHERE        (AdvancePayBackDetail_tbl.DateofPay BETWEEN @Param1 AND @Param2) AND (AdvanceApprovalMaster_tbl.Islevel3 = N'A') AND 
                         (AdvanceApplicationMaster_tbl.empid = @empid)", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);
                    command.Parameters.AddWithValue("@Param1", fromdate);
                    command.Parameters.AddWithValue("@Param2", todate);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {

                        try
                        {
                            Advancepayable = float.Parse(dt.Rows[0][0].ToString());
                        }
                        catch (Exception)
                        {

                            Advancepayable = 0;
                        }
                    }
                }


            }

            return Advancepayable;

        }



        public void updatepayrollnumber(int payid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();
                using (SqlCommand command = new SqlCommand(@"UPDATE       Payroll_PayMaster SET Emp_Count =(SELECT COUNT(Emp_Id) AS count
 FROM            Payroll_PayDetails WHERE        (Pay_Id = @payid))
WHERE        (Pay_Id = @payid)", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@payid", payid);

                    command.ExecuteNonQuery();


                    sqlConnection1.Close();
                }


            }

        }


        /// <summary>
        /// get the basic of employee
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="dayadiff"></param>
        /// <returns></returns>
        public float getbasicofemployee(ArrayList arry, int dayadiff, int payrollselecteddays)
        { 
            float  basic = 0;
            int employeeworkdays = 0;
            int offdaysinperiod=0;
            String cONTRACTTYPE = GetContracttype(int.Parse(arry[1].ToString()));
            employeeworkdays = getthemeployeedaysaspercontract(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString()), dayadiff);
            offdaysinperiod=getEmployeeOffDaysOfAPeriod(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString())).Rows.Count ;

            if (employeeworkdays <= dayadiff)
            {

                if (arry[8].ToString().Contains(" Januray-A"))
                {

                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;

                }
                else if (arry[8].ToString().Contains(" Januray-B"))
                {
                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;

                }
                else if (arry[8].ToString().Contains("December -A"))
                {
                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;
                }
                else if (arry[8].ToString().Contains("December -B"))
                {
                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;

                }
                else
                {
                    if (cONTRACTTYPE == "Contractual")
                    {
                        basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / payrollselecteddays) * employeeworkdays;

                    }
                    else{
                        basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / payrollselecteddays) * employeeworkdays;
                    }
                    
                }


            }
            else
            {
                if (arry[8].ToString().Contains(" Januray-A"))
                {
                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;

                }
                else if (arry[8].ToString().Contains(" Januray-B"))
                {
                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;

                }
                else if (arry[8].ToString().Contains("December -A"))
                {
                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;
                }
                else if (arry[8].ToString().Contains("December -B"))
                {
                    basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;

                }
                else
                {
                    basic = getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC");
                }
            }

            return basic;
        }



        public float getSpecialAllowance(ArrayList arry, int dayadiff, int payrollselecteddays)
        {
            float spal = 0;
            int employeeworkdays = 0;
            int offdaysinperiod = 0;
            String cONTRACTTYPE = GetContracttype(int.Parse(arry[1].ToString()));
            employeeworkdays = getthemeployeedaysaspercontract(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString()), dayadiff);
            offdaysinperiod = getEmployeeOffDaysOfAPeriod(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString())).Rows.Count;

            if (employeeworkdays <= dayadiff)
            {

             
                    if (cONTRACTTYPE == "Contractual")
                    {
                        spal = (getemployeeComponent(int.Parse(arry[1].ToString()), "SPECIAL ALLOWANCE") / payrollselecteddays) * employeeworkdays;

                    }
                    else
                    {
                        spal = (getemployeeComponent(int.Parse(arry[1].ToString()), "SPECIAL ALLOWANCE") / payrollselecteddays) * employeeworkdays;
                    }

                


            }
            else
            {

                spal = getemployeeComponent(int.Parse(arry[1].ToString()), "SPECIAL ALLOWANCE");
                
            }

            return spal;
        }

        //////////////////////////////////Done by Sreenath Afer Discussion with Abhishek on 18-03-2015..req from MR Pankaj ....Not sure about the accuracy of logic////////////////////////////// 


        ///// <summary>
        ///// divided the basic int number of days selected by the user and then makes the payroll
        ///// </summary>
        ///// <param name="arry"></param>
        ///// <param name="dayadiff"></param>
        ///// <param name="payrollselecteddays"></param>
        ///// <returns></returns>
        //public float getbasicofemployee(ArrayList arry, int dayadiff,int payrollselecteddays)
        //{
        //    float basic = 0;
        //    int employeeworkdays = 0;
        //    int offdaysinperiod = 0;
        //    int selectedpayrolldays=0;
        //    employeeworkdays = getthemeployeedaysaspercontract(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString()), dayadiff);
        //    offdaysinperiod = getEmployeeOffDaysOfAPeriod(int.Parse(arry[1].ToString()), DateTime.Parse(arry[9].ToString()), DateTime.Parse(arry[10].ToString())).Rows.Count;
           
        //    if (employeeworkdays <= dayadiff)
        //    {

        //        if (arry[8].ToString().Contains(" Januray-A"))
        //        {

        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / payrollselecteddays) * employeeworkdays;

        //        }
        //        else if (arry[8].ToString().Contains(" Januray-B"))
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;

        //        }
        //        else if (arry[8].ToString().Contains("December -A"))
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;
        //        }
        //        else if (arry[8].ToString().Contains("December -B"))
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;

        //        }
        //        else
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * employeeworkdays;
        //        }


        //    }
        //    else
        //    {
        //        if (arry[8].ToString().Contains(" Januray-A"))
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;

        //        }
        //        else if (arry[8].ToString().Contains(" Januray-B"))
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;

        //        }
        //        else if (arry[8].ToString().Contains("December -A"))
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;
        //        }
        //        else if (arry[8].ToString().Contains("December -B"))
        //        {
        //            basic = (getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC") / 26) * dayadiff;

        //        }
        //        else
        //        {
        //            basic = getemployeeComponent(int.Parse(arry[1].ToString()), "BASIC");
        //        }
        //    }

        //    return basic;
        //}



























        /// <summary>
        /// the days done asper the contract
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="payrollstartdate"></param>
        /// <param name="payrollenddate"></param>
        /// <param name="dayadiff"></param>
        /// <returns></returns>
        public int getthemeployeedaysaspercontract(int empid, DateTime payrollstartdate, DateTime payrollenddate, int dayadiff)
        {
            DataTable dt = new DataTable();

            DateTime actualjoiningdate;
            DateTime contractstartdatedate;
            DateTime contractenddate;
            int daysforpayroll = dayadiff;

            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT        ContractType, ActualJoiningDate, Startdate, isnull(ActualContractEndDate,Endtime) as Endtime FROM  EmpContract_tbl WHERE        (EmpId = @Param1)", con);
                    cmd.Parameters.AddWithValue("@Param1", empid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();


                    if (dt != null)
                    {
                        if (dt.Rows.Count != 0)
                        {
                            actualjoiningdate = DateTime.Parse(dt.Rows[0][1].ToString());
                            contractstartdatedate = DateTime.Parse(dt.Rows[0][2].ToString());
                            contractenddate = DateTime.Parse(dt.Rows[0][3].ToString());
                            // if employee contract start and ends  within payrollstart and end dates
                            //added by sreenath on 31-07-2014
                            //if joining date is after the  contract date
                            if (actualjoiningdate >= contractstartdatedate)
                            {
                                contractstartdatedate = actualjoiningdate;
                            }

                            // IF PAYROL PERIOD NIS BEFORE CONTRACT
                            if ((payrollstartdate < contractstartdatedate) && (payrollenddate < contractstartdatedate))
                            {
                                daysforpayroll = int.Parse((payrollenddate  - payrollstartdate ).TotalDays.ToString()) + 1;
                            }

                           else  if ((contractstartdatedate < payrollstartdate) && (contractenddate < payrollstartdate))
                            {
                                daysforpayroll = 0;
                            }
                            else
                            {
                                if (payrollstartdate < contractstartdatedate && payrollenddate > contractenddate)
                                {
                                    //daysforpayroll= period between contract start and end date (contractendate-contractstartdate)
                                    daysforpayroll = int.Parse((contractenddate.Date - contractstartdatedate.Date).TotalDays.ToString())+1;
                                }
                                else
                                {


                                    //if if contract start after the payroll date
                                    if (payrollstartdate < contractstartdatedate)
                                    {
                                        //dausforpayroll is start of contract tp payrollend (payroolenddate-contractstart)
                                        daysforpayroll = int.Parse((payrollenddate.Date - contractstartdatedate.Date).TotalDays.ToString())+1;
                                    }
                                    //if payroll ends before payrollend
                                    else if (payrollenddate > contractenddate)
                                    {
                                        //daysforpayroll is from payroll start to contract end
                                        daysforpayroll = int.Parse((contractenddate.Date - payrollstartdate.Date).TotalDays.ToString())+1;

                                    }
                                }


                            }







                        }

                    }
                }




            }


            catch (Exception exp)
            {


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());



            }


            return daysforpayroll;



        }





        /// <summary>
        /// get the correct number of the off days
        /// leaves
        /// and abcenties and holidays
        /// 
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="payrollstartdate"></param>
        /// <param name="payrollenddate"></param>
        public ArrayList  getStartandEndDateofpayroll(int empid, DateTime payrollstartdate, DateTime payrollenddate)
        {
            DataTable dt = new DataTable();
            DateTime actualjoiningdate;
            DateTime contractstartdatedate;
            DateTime contractenddate;
            ArrayList startandenddates = new ArrayList();

            DateTime actualstartdate = payrollstartdate;
            DateTime actualenddate = payrollenddate;
            salpaytrans = new SalaryCalculatuionTransaction();

            try
            {
               
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT        ContractType, ActualJoiningDate, Startdate, Endtime FROM  EmpContract_tbl WHERE        (EmpId = @Param1)", con);
                    cmd.Parameters.AddWithValue("@Param1", empid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();


                    if (dt != null)
                    {
                        if (dt.Rows.Count != 0)
                        {
                            actualjoiningdate = DateTime.Parse(dt.Rows[0][1].ToString());
                            contractstartdatedate = DateTime.Parse(dt.Rows[0][2].ToString());
                            contractenddate = DateTime.Parse(dt.Rows[0][3].ToString());

                            //added by sreenath on 31-07-2014
                            //if joining date is after the  contract date
                            if (actualjoiningdate >= contractstartdatedate)
                            {
                                contractstartdatedate = actualjoiningdate;
                            }



                                if((payrollstartdate <contractstartdatedate )&&(payrollenddate <contractstartdatedate ))
                                {
                                    actualstartdate = payrollstartdate;
                                    actualenddate = payrollenddate ;
                                }

                            // if employee contract start and ends  within payrollstart and end dates

                            else if ((contractstartdatedate < payrollstartdate) && (contractenddate < payrollstartdate))
                            {
                                 actualstartdate = DateTime.Now;
                                 actualenddate = DateTime.Now;
                            }
                            else
                            {
                                if (payrollstartdate < contractstartdatedate && payrollenddate > contractenddate)
                                {

                                    actualstartdate = contractstartdatedate;
                                    actualenddate = contractenddate;
                                    //period between contract start and end date (contractendate-contractstartdate)
                                   
                                }
                                else
                                {


                                    //if if contract start after the payroll date
                                    if (payrollstartdate < contractstartdatedate)
                                    {
                                        //period is start of contract tp payrollend (payroolenddate-contractstart)

                                        actualstartdate = contractstartdatedate;
                                        actualenddate = payrollenddate;
                                      
                                    }
                                    //if payroll ends before payrollend
                                    else if (payrollenddate > contractenddate)
                                    {
                                        //period  is from payroll start to contract end
                                        actualstartdate = payrollstartdate;
                                        actualenddate = contractenddate;
                                        
                                    }
                                }


                            }

                        }

                    }
                }
                
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
            }


            startandenddates.Add(actualstartdate);
            startandenddates.Add(actualenddate);

            return startandenddates;
           }




       /// <summary>
       /// get the holiday of the employee for the period of payroll asper his contract
       /// </summary>
       /// <param name="empid"></param>
       /// <param name="payrollstartdate"></param>
       /// <param name="payrollenddate"></param>
       /// <param name="dayadiff"></param>
       /// <returns></returns>

        public int gettheholidaysforemployeeincontract(int empid, DateTime payrollstartdate, DateTime payrollenddate, int dayadiff)
        {


            DataTable dt = new DataTable();

            DateTime actualjoiningdate;
            DateTime contractstartdatedate;
            DateTime contractenddate;
            int holidaysget = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT        ContractType, ActualJoiningDate, Startdate, Endtime FROM  EmpContract_tbl WHERE        (EmpId = @Param1)", con);
                    cmd.Parameters.AddWithValue("@Param1", empid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();


                    if (dt != null)
                    {
                        if (dt.Rows.Count != 0)
                        {
                            actualjoiningdate = DateTime.Parse(dt.Rows[0][1].ToString());
                            contractstartdatedate = DateTime.Parse(dt.Rows[0][2].ToString());
                            contractenddate = DateTime.Parse(dt.Rows[0][3].ToString());
                            //added by sreenath on 31-07-2014
                            //if joining date is after the  contract date
                            if (actualjoiningdate >= contractstartdatedate)
                            {
                                contractstartdatedate = actualjoiningdate;
                            }



                            // if employee contract start and ends  within payrollstart and end dates


                            if ((contractstartdatedate < payrollstartdate) && (contractenddate < payrollstartdate))
                            {
                                holidaysget = 0;
                            }
                            else
                            {
                                if (payrollstartdate < contractstartdatedate && payrollenddate > contractenddate)
                                {
                                    //holidaysget= period between contract start and end date (contractendate-contractstartdate)
                                    holidaysget = getholidaynumberforperiod(empid, contractstartdatedate, contractenddate);
                                }
                                else
                                {


                                    //if if contract start after the payroll date
                                    if (payrollstartdate < contractstartdatedate)
                                    {
                                        //holidaysget is start of contract tp payrollend (payroolenddate-contractstart)
                                       

                                        holidaysget = getholidaynumberforperiod(empid, contractstartdatedate, payrollenddate);
                                    }
                                    //if payroll ends before payrollend
                                    else if (payrollenddate > contractenddate)
                                    {
                                        //holidaysget  is from payroll start to contract end
                                       
                                        holidaysget = getholidaynumberforperiod(empid, payrollstartdate, contractenddate);
                                    }
                                }


                            }







                        }

                    }
                }




            }


            catch (Exception exp)
            {


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());



            }


            return holidaysget;



        }










        public DataTable GetAllPayrollNameAndID()
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT        Pay_Id, (Payroll_Month+'-'+ CAST(Pay_Id AS VARCHAR(10))) as paynumber "+
" FROM            Payroll_PayMaster ", con);

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
        /// get the puyblic holidays between a period 
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        public DataTable getpublicholidaysinperiod(int empid, DateTime fromdate, DateTime todate)
        {

            DataTable publicholidaydata = new DataTable();
            

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT        OffdayMaster_tbl.Holidayname, OffdayMaster_tbl.Holidaytype, OffdayMaster_tbl.HolidayDate " +
" FROM            OffdayMaster_tbl INNER JOIN " +
    "                     EmployeeDesignation_tbl ON OffdayMaster_tbl.LocationPK = EmployeeDesignation_tbl.BranchLocationPK " +
" WHERE        (OffdayMaster_tbl.Holidaytype = 'Public Holiday') AND (OffdayMaster_tbl.HolidayDate BETWEEN @Fromdate AND @Todate) AND  " +
               "          (EmployeeDesignation_tbl.empid = @empid)", con);

                    
                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@Fromdate", fromdate);
                    cmd.Parameters.AddWithValue("@Todate", todate);
                    SqlDataReader reader = cmd.ExecuteReader();
                    publicholidaydata.Load(reader);
                    con.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());



                }
            }
            return publicholidaydata;
        }
/// <summary>
/// get all the off day between the period
/// </summary>
/// <param name="empid"></param>
/// <param name="fromdate"></param>
/// <param name="todate"></param>
        public DataTable  getEmployeeOffDaysOfAPeriod(int empid, DateTime fromdate, DateTime todate)
        {
            DataTable offdaycalender = new DataTable();
            String offdayoffemployee = "Sunday";
            DataTable offdaystable = new DataTable();
            offdaystable.Columns.Add("HolidayDate", typeof(DateTime));
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT        ShiftDayDetails_tbl.DayOFWeekname " +
"FROM            ShiftDayDetails_tbl INNER JOIN " +
               "          EmployeShift_tbl ON ShiftDayDetails_tbl.ShiftPK = EmployeShift_tbl.Shiftpk " +
"WHERE        (ShiftDayDetails_tbl.DayStatus = N'Off Day') AND (EmployeShift_tbl.Empid = @empid)", con);
                    cmd.Parameters.AddWithValue("@empid", empid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    
                    offdaycalender.Load(reader);
                    con.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());



                }
            }


            if (offdaycalender != null)
            {
                if (offdaycalender.Rows.Count != 0)
                {
                    offdayoffemployee = offdaycalender.Rows[0][0].ToString();

                }
            }




            TimeSpan DateDiff = todate.Subtract(fromdate);
            for (int i = 0; i <= DateDiff.Days; i++)
            {
                if (fromdate.Date.AddDays(i).DayOfWeek.ToString() == offdayoffemployee)
                {
                    offdaystable.Rows.Add(fromdate.Date.AddDays(i));

                }
            }


            return offdaystable;
        }


        /// <summary>
        /// get the holiday of the employee of a period and subtract the holidays in the off days
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        public int  getholidaynumberforperiod(int empid, DateTime fromdate, DateTime todate)
        {
            int holidaydate = 0;
            try
            {
                DataTable holidaydates = getpublicholidaysinperiod(empid, fromdate, todate);
                DataTable offdays = getEmployeeOffDaysOfAPeriod(empid, fromdate, todate);
               
                for (int i = 0; i < holidaydates.Rows.Count; i++)
                {
                    DateTime holiday = DateTime.Parse(holidaydates.Rows[i][2].ToString()).Date;
                    for (int j = 0; j < offdays.Rows.Count; j++)
                    {
                        if (holiday == DateTime.Parse(offdays.Rows[j][0].ToString()).Date)
                        {
                            holidaydate++;
                        }
                    }

                }
         
            }
            catch (Exception exp)
            {


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());



            }

            return holidaydate;
        }

        public DataSet selectalldatafordisplay()
        {
            DataSet DS = new DataSet();


            string qry = "SELECT Payroll_PayDetails.Emp_Id, Payroll_PayDetails.Total_Salary, EmployeePersonalMaster_tbl.First_name,"
                   + " EmployeePersonalMaster_tbl.Last_Name, EmpContract_tbl.ActualJoiningDate, Payroll_PayDetails.Basic_Sal, "
                   + " Payroll_PayDetails.HRA_Allow, Payroll_PayDetails.NSSF, Payroll_PayDetails.NHIF, Payroll_PayDetails.Deduct_Amnt, "
                   + " DesignationMaster_tbl.DesignationName, Payroll_PayDetails.OT_Amnt, Payroll_PayDetails.Tax_Deduct, "
                   + " EmployeePersonalMaster_tbl.empno, FinalEmployeeDuty_tbl.OT, FinalEmployeeDuty_tbl.OffOT, Payroll_PayDetails.Special_Allow, "
                   + " DepartmentMaster_tbl.DepartmentName, FinalEmployeeDuty_tbl.LH, FinalEmployeeDuty_tbl.UOT,FinalEmployeeDuty_tbl.lhr, FinalEmployeeDuty_tbl.LHR,Payroll_PayDetails.Absent_No "
                   + " FROM (((((ATCHRM.dbo.Payroll_PayDetails Payroll_PayDetails "
                   + " INNER JOIN ATCHRM.dbo.EmployeePersonalMaster_tbl EmployeePersonalMaster_tbl ON "
                   + " Payroll_PayDetails.Emp_Id=EmployeePersonalMaster_tbl.empid) INNER JOIN "
                   + " ATCHRM.dbo.EmpContract_tbl EmpContract_tbl ON EmployeePersonalMaster_tbl.empid=EmpContract_tbl.EmpId) "
                   + " INNER JOIN ATCHRM.dbo.EmployeeDesignation_tbl EmployeeDesignation_tbl ON EmpContract_tbl.EmpId=EmployeeDesignation_tbl.empid) "
                   + " INNER JOIN ATCHRM.dbo.FinalEmployeeDuty_tbl FinalEmployeeDuty_tbl ON EmpContract_tbl.EmpId=FinalEmployeeDuty_tbl.empid) "
                   + " INNER JOIN ATCHRM.dbo.DesignationMaster_tbl DesignationMaster_tbl ON EmployeeDesignation_tbl.DesignationPk=DesignationMaster_tbl.DesgnationPK) "
                   + " INNER JOIN ATCHRM.dbo.DepartmentMaster_tbl DepartmentMaster_tbl ON DesignationMaster_tbl.DepartmentPK=DepartmentMaster_tbl.DepartmentPK "
    + " ORDER BY Payroll_PayDetails.Emp_Id";

            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {


                sqlConnection1.Open();


                using (SqlCommand command = new SqlCommand(qry, sqlConnection1))
                {
                    command.CommandTimeout = 0;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DS = new DataSet();
                    da.Fill(DS);
                }
            }

            return DS;


        }



        ///// <summary>
        /// get the employe component values
        /// </summary>
        /// <returns></returns>
        public DataTable getPayrollCalender()
        {


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT        Payrolldateid, Year + '-' + Month AS payrollmonth, NoOfDays, StartDate, Endate FROM  PayrollCalenderMaster_tbl WHERE  (IsCompleted = N'N')", con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);
                    con.Close();
                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());



                }
            }
            return dt;


        }


















        //get the basic salary of the employee
        public float  getemployeeComponent(int empid, String CompName)
        {
            float  basic = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();

                using (SqlCommand command = new SqlCommand("SELECT     EmployeesalCompApplicable_tbl.Amount, SalComponentMaster_tbl.ComponentName, EmployeesalCompApplicable_tbl.empid " +
" FROM         EmployeesalCompApplicable_tbl INNER JOIN " +
       "               SalComponentMaster_tbl ON EmployeesalCompApplicable_tbl.SalcompPk = SalComponentMaster_tbl.SalcompPk " +
" WHERE     (SalComponentMaster_tbl.ComponentName = @compname) AND (EmployeesalCompApplicable_tbl.empid = @empid)", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);
                    command.Parameters.AddWithValue("@compname", CompName);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {
                        basic = float.Parse(dt.Rows[0][0].ToString());

                    }
                }


            }

            return basic;
        }



        /// <summary>
        /// get cropped Ot of employee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int getoOTDone(int empid)
        {
            int otdone = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();

                using (SqlCommand command = new SqlCommand("select ot_dura from Adjuster_Cropped where emp_id=@empid", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {
                        otdone = int.Parse(dt.Rows[0][0].ToString());

                    }
                }


            }

            return otdone;
        }



        public int getExtraOTDone(int empid)
        {
            int offot = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();

                using (SqlCommand command = new SqlCommand("select  ExtraMinutes from FinalEmployeeDuty_tbl where empid=@empid", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {
                        offot = int.Parse(dt.Rows[0][0].ToString());

                    }
                }


            }

            return offot;
        }


        /// <summary>
        /// get cropped Ot of Employee
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int getOffOTDone(int empid)
        {
            int offot = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();

                using (SqlCommand command = new SqlCommand("select  OffOT from FinalEmployeeDuty_tbl where empid=@empid", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {
                        offot = int.Parse(dt.Rows[0][0].ToString());

                    }
                }


            }

            return offot;
        }
        /// <summary>
        /// get normal Ot of an enmpoloyye 
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int getnormalOTDone(int empid)
        {
            int otdone = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {
                sqlConnection1.Open();

                using (SqlCommand command = new SqlCommand("select  OT from FinalEmployeeDuty_tbl where empid=@empid", sqlConnection1))
                {
                    command.Parameters.AddWithValue("@empid", empid);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count != 0)
                    {
                        otdone = int.Parse(dt.Rows[0][0].ToString());

                    }
                }


            }

            return otdone;
        }



    }
}

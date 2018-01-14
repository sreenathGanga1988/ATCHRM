using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ATCHRM.Transactions
{
    class LeaveTrabnsactionCalculator
    {Transactions.leaveEnchasementTransaction lvencashmenttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.LeaveTransaction lvtransaction = null;
        Transactions.AnualContractrenewal annul = null;
        DataTable contractdatamain = null;
        DataTable leavedata = null;
        int empid = 0;
        int leavepk = 0;
        int employeelvenum = 0;
        DateTime actualjoinigdate;
        DateTime contractenddate;
        DateTime contractstartdate;
        DateTime applicationdate = Program.Datetoday;
        double durationdays = 0;
        double durationmonth = 0;
        int totalallowedleave = 0;
        double leavesforperiod = 0;
        String Leavetype = "";
        String calculateupto = "";
        DataTable employeetakenLeave;
        DateTime leavefromdate;
        DateTime leavetilldate;
        String Contractype = "";
        int iscarryforwadable=0;



         String currentyear="" ;
         String subcontractfromdate;
         String subcontracttodate;
              

        public DataTable  getallleavetakenbetweenperiod(int empid1, int leavepk1, DateTime datetoday)
        {
            empregtrans = new Transactions.EmployeeRegTransaction();

            annul = new AnualContractrenewal();
            lvtransaction = new Transactions.LeaveTransaction();
           
              empid = empid1;
            leavepk = leavepk1;
          //  leavecomboLoad(empid);
            getcontractstatusofemployee(empid);

            if (isacasual())
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Casual Employee Cannot have  any Leave ");
            }
            else
            {
                leavedatacalculate(empid, leavepk);
                 leavetilldate = calculatingactualleaveassigned(applicationdate);
                 leavefromdate = leavetakencalculatestartdate();
                 employeetakenLeave = lvtransaction.getAllSpecificLeavetakenByEmployee(empid, leavepk, leavefromdate, leavetilldate);
            }

            return employeetakenLeave;
        }





        
public int getallLeaveEncashed(int empid1, int leavepk1)
        {
            int leaveencashed = 0;
            lvencashmenttrans = new leaveEnchasementTransaction();
            leaveencashed = lvencashmenttrans.getAllPreviousEnchasementofEmployee(empid, leavepk, leavefromdate, leavetilldate);

            return leaveencashed;
        }







        public double  employeeleavecalculatorstarter(int empid1 , int leavepk1)
        {
            leavesforperiod = 0.0;
            empregtrans = new Transactions.EmployeeRegTransaction();
            annul = new AnualContractrenewal();

            lvtransaction = new Transactions.LeaveTransaction();
        
            empid = empid1;
            leavepk = leavepk1;
          //  leavecomboLoad(empid);
            getcontractstatusofemployee(empid);

            if (isacasual())
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Casual Employee Cannot have  any Leave ");
            }
            else
            {
                leavedatacalculate(empid, leavepk);

                leavetilldate = calculatingactualleaveassigned(applicationdate);
                leavefromdate = calculatemstartdate();



                durationcalculator(leavefromdate, leavetilldate);
                accurateleavetillgivendate();
            }

            return leavesforperiod;
        }



        public double employeeleavecalculatorstarter(int empid1, int leavepk1 ,DateTime fromdate,DateTime todate)
        {
            leavesforperiod = 0.0;
            empregtrans = new Transactions.EmployeeRegTransaction();
            annul = new AnualContractrenewal();

            lvtransaction = new Transactions.LeaveTransaction();

            empid = empid1;
            leavepk = leavepk1;
            //  leavecomboLoad(empid);
            getcontractstatusofemployee(empid);

            if (isacasual())
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Casual Employee Cannot have  any Leave ");
            }
            else
            {
                leavedatacalculate(empid, leavepk);

                leavetilldate = todate;
                leavefromdate = fromdate;



                durationcalculator(leavefromdate, leavetilldate);
                accurateleavetillgivendate();
            }

            return leavesforperiod;
        }
        public Boolean isacasual()
        {
            Boolean casual = true;
            //if (tbl_contract.Rows[0].Cells[2].Value.ToString() != "Casual")
            //{
            //    casual = false;
            //}


            if (contractdatamain.Rows[0][2].ToString().Trim() != "Casual")
            {
                casual = false;
            }

            Contractype = contractdatamain.Rows[0][2].ToString().Trim();
            return casual;
        }


        public void getcontractstatusofemployee(int empid)
        {
            DataTable contractdata = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT     TOP (1) EmpId,Contractid, ContractType, Startdate, Endtime, ActualJoiningDate FROM         EmpContract_tbl WHERE     (EmpId = @Param1)", con))
                {
                    cmd.Parameters.AddWithValue("@Param1", empid);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    contractdata.Load(reader);


                    reader.Close();

                    if (contractdata.Rows.Count != 0)
                    {

                      //  tbl_contract.DataSource = contractdata;
                        contractdatamain = contractdata;

                        actualjoinigdate = DateTime.Parse(contractdatamain.Rows[0][5].ToString());
                        contractenddate = DateTime.Parse(contractdatamain.Rows[0][4].ToString());
                        contractstartdate = DateTime.Parse(contractdatamain.Rows[0][3].ToString());
                    }




                    con.Close();
                }

            }


        }


        public void leavedatacalculate(int empid, int leavepk)
        {
            DataTable dtleavedata = lvtransaction.getemployeeApplicableleavedata(empid, leavepk);

            if (dtleavedata.Rows.Count != 0)
            {

              //  tbl_leavedata.DataSource = dtleavedata;
                leavedata = dtleavedata;
                totalallowedleave = int.Parse(leavedata.Rows[0][2].ToString());
                Leavetype = leavedata.Rows[0][5].ToString();
                iscarryforwadable = int.Parse(leavedata.Rows[0][6].ToString());
                calculateupto = leavedata.Rows[0][7].ToString();
            }
        }



        /// <summary>
        /// find out to which date the leave should be calculated
        /// </summary>
        /// <param name="todate"></param>
        /// <returns></returns>

        public DateTime calculatingactualleaveassigned(DateTime todate)
        {
            DateTime today = todate;
            DateTime month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            DateTime lastdayofpreviousmonth = month.AddDays(-1);

            if (calculateupto == "Last Month")
            {
                todate = lastdayofpreviousmonth;
            }
            else if (calculateupto == "End of Contract")
            {
                todate = contractenddate;
            }
            else if (calculateupto == "Upto Date")
            {
                todate = todate;
            }

            return todate;
        }



        public DateTime leavetakencalculatestartdate()
        {
            DateTime oneyearbac = applicationdate.AddYears(-1);
          
            if (Leavetype == "Months Per year")
            {
              //  leavefromdate = actualjoinigdate;


                if (actualjoinigdate < oneyearbac)
                {
                    leavefromdate = oneyearbac;
                }
                else
                {
                    leavefromdate = actualjoinigdate;
                }

            }
            else if (Leavetype == "Days Per Year")
            {
                if (actualjoinigdate > oneyearbac)
                {

                    if (iscarryforwadable == 1)
                    {
                        leavefromdate = oneyearbac;
                    }
                    else
                    {

                    }
                  
                }
                else
                {
                    if(actualjoinigdate>leavefromdate)
                    {


                        if (iscarryforwadable == 1)
                        {
                            leavefromdate = actualjoinigdate;
                        }
                        else
                        {

                        }




                       
                    }
                    else
                    {

                    }

                   
                }
            }
            else
            {
                if (actualjoinigdate > oneyearbac)
                {
                    leavefromdate = oneyearbac;
                }
                else
                {
                    leavefromdate = actualjoinigdate;
                }
            }
            return leavefromdate;
        }



        public DateTime calculatemstartdate()
        {

            if (iscarryforwadable == 1)
            {
                leavefromdate = actualjoinigdate;
            }
            else
            {
                getcurrentcontractleave(empid);
                leavefromdate = DateTime .Parse ( subcontractfromdate);
            }
            return leavefromdate;
        }

        public void getcurrentcontractleave(int empid)
        {

            DataTable contractdata = annul.getCurrentSubContract(empid);
            if (contractdata != null)
            {
                if (contractdata.Rows.Count != 0)
                {

                    currentyear = contractdata.Rows[0][1].ToString();
                    subcontractfromdate = DateTime.Parse(contractdata.Rows[0][2].ToString()).ToString("dd-MM-yyyy");
                    subcontracttodate = DateTime.Parse(contractdata.Rows[0][3].ToString()).ToString("dd-MM-yyyy");

                }
                else
                {
                    subcontractfromdate = actualjoinigdate.ToString();
                }
            }
            else
            {
                subcontractfromdate = actualjoinigdate.ToString();
                
            }
        }


        public void durationcalculator(DateTime starttime, DateTime endtime)
        {
            durationdays = Math.Abs((starttime - endtime).TotalDays);
            durationmonth = durationdays / 30;

        }



        public void accurateleavetillgivendate()
        {

            if (Leavetype == "Days Per Year")
            {
                double peryear = (Convert.ToDouble(totalallowedleave) / 12.0) * 12;


               
                //   leavesforperiod = (totalallowedleave / 12) *int.Parse ( durationmonth.ToString ());
                leavesforperiod = peryear ;


                //  leavesforperiod = Convert.ToDouble(totalallowedleave / 12) * durationmonth;

            }
            else if (Leavetype == "Days Per Month")
            {
                leavesforperiod = Convert.ToDouble(totalallowedleave) * durationmonth;
            }
            else if (Leavetype == "Months Per year")
            {
                leavesforperiod = totalallowedleave;
                
            }
           else if (Leavetype == "1/2 Days Per Year")
            {
                double perhalfyear = (Convert.ToDouble(totalallowedleave) / 12.0) * 12;
                 leavesforperiod = perhalfyear;
               
            }
            leavesforperiod = Math.Truncate(leavesforperiod);
            
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getallleavetaken()
        {
            employeetakenLeave = lvtransaction.getAllSpecificLeavetakenByEmployee(empid, leavepk, leavefromdate, leavetilldate);

            if (employeetakenLeave.Rows.Count == 0)
            {

                employeelvenum = 0;
            }
            else
            {

                employeelvenum = employeetakenLeave.Rows.Count;

            }

            return employeelvenum;


        }





        public int getallleavePending( int empid,int leavepk )
        {
            employeetakenLeave = lvtransaction.getAllSpecificLeaveAppliedByEmployeeBUTnotCloseregister(empid, leavepk);

            if (employeetakenLeave.Rows.Count == 0)
            {

                employeelvenum = 0;
            }
            else
            {

                employeelvenum = employeetakenLeave.Rows.Count;

            }

            return employeelvenum;


        }



                    
                    
     



    }
}

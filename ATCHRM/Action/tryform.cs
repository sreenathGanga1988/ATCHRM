using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading ;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
namespace ATCHRM.Action
{
    public partial class tryform : Form
    {
        Transactions.EmployeeRegTransaction empregtrans = null;   
        Transactions.LeaveTransaction lvtransaction = null;

        DataTable contractdatamain = null;
        DataTable leavedata = null;
        int empid = 0;
        int leavepk = 0;
        int employeelvenum = 0;
        DateTime actualjoinigdate;
        DateTime contractenddate;
        DateTime applicationdate= Program.Datetoday ;
        double durationdays = 0;
        double durationmonth = 0;
        int totalallowedleave = 0;
        double leavesforperiod = 0;
        String Leavetype = "";
        DataTable employeetakenLeave;
        DateTime leavetilldate;
        public tryform()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            employecodeload(0, 0, 0);          
          
          
            lvtransaction = new Transactions.LeaveTransaction();
        
           
            
          

        }

        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_empcode.DataSource = dt;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
        }

        public void leavecomboLoad(int empid)
        {
            DataTable dt = lvtransaction.LeaveApplicabletoEmployee(empid);
            cmb_leave.DataSource = dt;
            cmb_leave.DisplayMember = "LEAVE";
            cmb_leave.ValueMember = "SL";
        }

        private void cmb_leave_SelectedIndexChanged(object sender, EventArgs e)
        {try
            {
            leavepk = int.Parse(cmb_leave .SelectedValue.ToString());
            }
        catch (Exception)
        {


        }
        }

        private void cmb_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                leavecomboLoad(int.Parse(cmb_empcode.SelectedValue.ToString()));

                getcontractstatusofemployee(int.Parse(cmb_empcode.SelectedValue.ToString()));
                empid = int.Parse(cmb_empcode.SelectedValue.ToString());
            }
            catch (Exception)
            {


            }
        }










        public void employeeleavecalculatorstarter()
        {
            leavecomboLoad(empid);
            getcontractstatusofemployee(empid);

            if (isacasual())
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Casual Employee Cannot have  any Leave ");
            }
            else
            {
                leavedatacalculate(empid,leavepk );

               leavetilldate = calculatingactualleaveassigned(applicationdate);
                durationcalculator(actualjoinigdate, leavetilldate);
                accurateleavetillgivendate();
            }
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
            return casual;
        }


        public void getcontractstatusofemployee(int empid)
        {
            DataTable contractdata = new DataTable();

           using (SqlConnection con= new SqlConnection (Program.ConnStr ))
           {
               con.Open();
               
               using (SqlCommand cmd= new SqlCommand("SELECT     TOP (1) EmpId,Contractid, ContractType, Startdate, Endtime, ActualJoiningDate FROM         EmpContract_tbl WHERE     (EmpId = @Param1)", con))
            {
                cmd.Parameters.AddWithValue("@Param1", empid);
                   cmd.ExecuteNonQuery ();
                   SqlDataReader reader = cmd.ExecuteReader();

                   contractdata.Load(reader);


                   reader.Close();

                   if (contractdata.Rows.Count != 0)
                   {

                       tbl_contract.DataSource = contractdata;
                       contractdatamain = contractdata;

                       actualjoinigdate = DateTime.Parse(tbl_contract.Rows[0].Cells[5].Value.ToString());
                       contractenddate = DateTime.Parse(tbl_contract.Rows[0].Cells[4].Value.ToString()); 
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

                tbl_leavedata.DataSource = dtleavedata;
                leavedata = dtleavedata;
                totalallowedleave = int.Parse(leavedata.Rows[0][2].ToString());
                Leavetype = leavedata.Rows[0][5].ToString();
            }
        }
    





        private void button1_Click(object sender, EventArgs e)
        {
            
            if (isacasual())
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Casual Employee Cannot have  any Leave ");
            }
            else
            {




                 ATCHRM.Controls.ATCHRMMessagebox.Show("Check for the Calulkation type of leave and allowed leave ");
                employeeleavecalculatorstarter();

                //DataTable dtleavedata = lvtransaction.getemployeeApplicableleavedata(int.Parse(cmb_empcode.SelectedValue.ToString()), int.Parse(cmb_leave .SelectedValue.ToString()));

                //if(leavedata.Rows.Count !=0){

                //tbl_leavedata.DataSource = dtleavedata;
                //leavedata = dtleavedata;
                //totalallowedleave = int.Parse ( leavedata.Rows[0][2].ToString());
                //Leavetype = leavedata.Rows[0][6].ToString();          
                                              
           // }


            }
        }




      
    
    
  /// <summary>
  /// find out to which date the leave should be calculated
  /// </summary>
  /// <param name="todate"></param>
  /// <returns></returns>
  
   public DateTime  calculatingactualleaveassigned(DateTime todate)
   {
       DateTime today = todate;
       DateTime month = new DateTime(today.Year, today.Month, 1);
       var first = month.AddMonths(-1);
       DateTime lastdayofpreviousmonth = month.AddDays(-1);

       if (leavedata.Rows[0][7].ToString() == "Last  Month")
       {
           todate = lastdayofpreviousmonth;
       }
       else if (leavedata.Rows[0][7].ToString() == "End of Contract")
       {
           todate = contractenddate;
       }
       else if (leavedata.Rows[0][7].ToString() == "Upto Date")
       {
           todate = todate;
       }

       return todate;
   }




   public void durationcalculator(DateTime starttime, DateTime endtime)
   {
      durationdays  =  Math.Abs((starttime - endtime).TotalDays);
      durationmonth = durationdays / 30;
        
   }



   public void accurateleavetillgivendate()
   {

       if (Leavetype == "Days Per Year")
       {
           double permonth = Convert.ToDouble(totalallowedleave) / 12.0;
        //   leavesforperiod = (totalallowedleave / 12) *int.Parse ( durationmonth.ToString ());
           leavesforperiod = permonth * durationmonth;
         //  leavesforperiod = Convert.ToDouble(totalallowedleave / 12) * durationmonth;

      }
       else if (Leavetype == "Days Per Month")
       {
           leavesforperiod = Convert.ToDouble(totalallowedleave) * durationmonth;
       }
       leavesforperiod = Math.Truncate(leavesforperiod);
       btn_display.Text = leavesforperiod.ToString(); ;
   }















   private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
   {
       applicationdate = dateTimePicker1.Value.Date;
   }





   public int  getallleavetaken()
   {
       employeetakenLeave = lvtransaction.getAllSpecificLeavetakenByEmployee(empid, leavepk, actualjoinigdate, leavetilldate);

       if (employeetakenLeave.Rows.Count == 0)
       {

           employeelvenum = 0;
       }
       else
       {

           employeelvenum = employeetakenLeave.Rows.Count;

       }

    return    employeelvenum;


   }

   private void tryform_Load(object sender, EventArgs e)
   {

   }
    
    
    
    }
}

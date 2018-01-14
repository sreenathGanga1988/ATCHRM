using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class shiftmasterform : Form
    {
        Transactions.ShiftTransactionNewform shftfrm = null;
        public shiftmasterform()
        {
            InitializeComponent();
            shftfrm = new Transactions.ShiftTransactionNewform();
            chomboboxload();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void chomboboxload()
        {
            Cmb_daytypemonday.SelectedIndex = 0;
            Cmb_daytypetuesday.SelectedIndex = 0;
            Cmb_daytypewednesday.SelectedIndex = 0;
            Cmb_daytypethursday.SelectedIndex = 0;
            Cmb_daytypefriday.SelectedIndex = 0;
            Cmb_daytypesaturday.SelectedIndex = 0;
            Cmb_daytypesunday.SelectedIndex = 0;

        }

        /// <summary>
        /// calulates the display pof the duration asper the change in the value
        /// of the controls
        /// </summary>
        /// <param name="dtpin"></param>
        /// <param name="dtpOut"></param>
        /// <param name="break1"></param>
        /// <param name="break2"></param>
        /// <param name="break3"></param>
        /// <param name="break4"></param>
        /// <param name="Durationtxt"></param>
        public void durationCalculator(DateTimePicker dtpin, DateTimePicker dtpOut, TextBox break1, TextBox break2, TextBox break3, TextBox break4, TextBox Durationtxt,ComboBox outday)
        {


            try
            {
                TimeSpan swipein = dtpin.Value.TimeOfDay;
                TimeSpan swipeout = dtpOut.Value.TimeOfDay;
                TimeSpan duration;
                if (swipeout >= swipein)
                {
                    duration = swipeout - swipein;
                    outday.SelectedIndex = 0;
                }
                else
                {

                    duration = swipeout + new TimeSpan(1, 0, 0, 0) - swipein;
                    outday.SelectedIndex = 1;
                }

                int breaktime = int.Parse(break1.Text) + int.Parse(break2.Text) + int.Parse(break3.Text) + int.Parse(break4.Text);

                if (duration != null && duration.TotalMinutes > 0)
                {

                  //  int inct = int.Parse(duration.TotalMinutes.ToString());
                //    int inct = Convert.ToInt32(duration.TotalMinutes);
                    int actualduration = Convert.ToInt32(duration.TotalMinutes) - breaktime;

                    Durationtxt.Text = actualduration.ToString();


                }




                weeklyworkinghours();







            }
            catch (Exception)
            {

           
            }




        }

     
        /// <summary>
        /// send the controls for the duration calculator
        /// 
        /// </summary>
        /// <param name="dayoftheweek"></param>

        public void autoadjuster(String dayoftheweek)
        {
            switch (dayoftheweek )
            {
                case "Monday":
                    durationCalculator(dtpIn_Monday, DtpOut_Monday, txtBreak1_Monday, txtBreak2_Monday, txtBreak3_Monday, txtBreak4_Monday, txtduration_Monday,Cmb_outMonday );
                    break;
                case "Tuesday":
                    durationCalculator(dtpIn_Tuesday, DtpOut_Tuesday, txtBreak1_Tuesday, txtBreak2_Tuesday, txtBreak3_Tuesday, txtBreak4_Tuesday, txtduration_Tuesday,Cmb_outtuesday );
                    break;
                case "Wednesday":
                    durationCalculator(dtpIn_Wednesday, DtpOut_Wednesday, txtBreak1_Wednesday, txtBreak2_Wednesday, txtBreak3_Wednesday, txtBreak4_Wednesday, txtduration_Wednesday,Cmb_outWednesday );
                    break;
                case "Thursday":
                    durationCalculator(dtpIn_Thursday, DtpOut_Thursday, txtBreak1_Thursday, txtBreak2_Thursday, txtBreak3_Thursday, txtBreak4_Thursday, txtduration_Thursday,Cmb_outThursday );
                    break;
                case "Friday":
                    durationCalculator(dtpIn_Friday, DtpOut_Friday, txtBreak1_Friday, txtBreak2_Friday, txtBreak3_Friday, txtBreak4_Friday, txtduration_Friday,Cmb_outFriday );
                    break;

                case "Saturday":
                    durationCalculator(dtpIn_Saturday, DtpOut_Saturday, txtBreak1_Saturday, txtBreak2_Saturday, txtBreak3_Saturday, txtBreak4_Saturday, txtduration_Saturday,Cmb_outsaturday );
                    break;

                case "Sunday":
                    durationCalculator(dtpIn_Sunday, DtpOut_Sunday, txtBreak1_Sunday, txtBreak2_Sunday, txtBreak3_Sunday, txtBreak4_Sunday, txtduration_Sunday,Cmb_outSunday );
                    break;
                default:
                    
                    break;        

                   
            
           
           
           
           
            
        }
        }



        /// <summary>
        /// sends the controls pf the dys in which the statuus is changed to off
        /// </summary>
        /// <param name="dayoftheweek"></param>

        public void offdaysetter(String dayoftheweek)
        {
            switch (dayoftheweek)
            {
                case "Monday":
                    selectionchange(Cmb_daytypemonday,dtpIn_Monday, DtpOut_Monday, txtBreak1_Monday, txtBreak2_Monday, txtBreak3_Monday, txtBreak4_Monday, txtduration_Monday);
                    break;
                case "Tuesday":
                    selectionchange(Cmb_daytypetuesday, dtpIn_Tuesday, DtpOut_Tuesday, txtBreak1_Tuesday, txtBreak2_Tuesday, txtBreak3_Tuesday, txtBreak4_Tuesday, txtduration_Tuesday);
                    break;
                case "Wednesday":
                    selectionchange( Cmb_daytypewednesday  ,dtpIn_Wednesday, DtpOut_Wednesday, txtBreak1_Wednesday, txtBreak2_Wednesday, txtBreak3_Wednesday, txtBreak4_Wednesday, txtduration_Wednesday);
                    break;
                case "Thursday":
                    selectionchange( Cmb_daytypethursday , dtpIn_Thursday, DtpOut_Thursday, txtBreak1_Thursday, txtBreak2_Thursday, txtBreak3_Thursday, txtBreak4_Thursday, txtduration_Thursday);
                    break;
                case "Friday":
                    selectionchange( Cmb_daytypefriday ,dtpIn_Friday, DtpOut_Friday, txtBreak1_Friday, txtBreak2_Friday, txtBreak3_Friday, txtBreak4_Friday, txtduration_Friday);
                    break;

                case "Saturday":
                    selectionchange(  Cmb_daytypesaturday  ,dtpIn_Saturday, DtpOut_Saturday, txtBreak1_Saturday, txtBreak2_Saturday, txtBreak3_Saturday, txtBreak4_Saturday, txtduration_Saturday);
                    break;

                case "Sunday":
                    selectionchange( Cmb_daytypesunday   ,dtpIn_Sunday, DtpOut_Sunday, txtBreak1_Sunday, txtBreak2_Sunday, txtBreak3_Sunday, txtBreak4_Sunday, txtduration_Sunday);
                    break;
                default:

                    break;








            }
        }




/// <summary>
/// calculate the weekly working days asper the input value
/// </summary>
        public void weeklyworkinghours()
        {
            try
            {
                float totalduration = float.Parse((int.Parse(txtduration_Monday.Text) + int.Parse(txtduration_Tuesday.Text) + int.Parse(txtduration_Wednesday.Text) + int.Parse(txtduration_Thursday.Text) + int.Parse(txtduration_Friday.Text) + int.Parse(txtduration_Saturday.Text) + int.Parse(txtduration_Sunday.Text)).ToString());
                float totalweeklyduration = totalduration / 60;
                txtWeeklyDuratiuon.Text = totalweeklyduration.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
            
           
        }







        private void dtpIn_Monday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Monday");
        }

        private void dtpIn_Tuesday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Tuesday");
        }

        private void dtpIn_Wednesday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Wednesday");
        }

        private void dtpIn_Thursday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Thursday");
        }

        private void dtpIn_Friday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Friday");
        }

        private void dtpIn_Saturday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Saturday");
        }

        private void dtpIn_Sunday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Sunday");
        }

        private void DtpOut_Monday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Monday");
        }

        private void DtpOut_Tuesday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Tuesday");
        }

        private void DtpOut_Wednesday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Wednesday");
        }

        private void DtpOut_Thursday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Thursday");
        }

        private void DtpOut_Friday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Friday");
        }

        private void DtpOut_Saturday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Saturday");
        }

        private void DtpOut_Sunday_ValueChanged(object sender, EventArgs e)
        {
            autoadjuster("Sunday");
        }

        private void txtBreak1_Monday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Monday");
        }

        private void txtBreak2_Monday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Monday");
        }

        private void txtBreak3_Monday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Monday");
        }

        private void txtBreak4_Monday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Monday");
        }

        private void txtBreak1_Tuesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Tuesday");
        }

        private void txtBreak2_Tuesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Tuesday");
        }

        private void txtBreak3_Tuesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Tuesday");
        }

        private void txtBreak4_Tuesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Tuesday");
        }

        private void txtBreak1_Wednesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Wednesday");
        }

        private void txtBreak2_Wednesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Wednesday");
        }

        private void txtBreak3_Wednesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Wednesday");
        }

        private void txtBreak4_Wednesday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Wednesday");
        }

        private void txtBreak1_Thursday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Thursday");
        }

        private void txtBreak2_Thursday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Thursday");
        }

        private void txtBreak3_Thursday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Thursday");
        }

        private void txtBreak4_Thursday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Thursday");
        }

        private void txtBreak1_Friday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Friday");
        }

        private void txtBreak2_Friday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Friday");
        }

        private void txtBreak3_Friday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Friday");
        }

        private void txtBreak4_Friday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Friday");
        }

        private void txtBreak1_Saturday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Saturday");
        }

        private void txtBreak2_Saturday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Saturday");
        }

        private void txtBreak3_Saturday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Saturday");
        }

        private void txtBreak4_Saturday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Saturday");

        }

        private void txtBreak1_Sunday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Sunday");
        }

        private void txtBreak2_Sunday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Sunday");
        }

        private void txtBreak3_Sunday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Sunday");
        }

        private void txtBreak4_Sunday_TextChanged(object sender, EventArgs e)
        {
            autoadjuster("Sunday");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// does the validation for the shift form
        /// </summary>
        /// <returns></returns>
        public Boolean validationforshift()
        {

            Boolean sucess = true;

            if (txt_ShiftName.Text ==null  || txt_ShiftName.Text =="")
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Enter the ShiftName :");
                sucess = false;
            }
             if (txtWeeklyDuratiuon.Text == null || txtWeeklyDuratiuon.Text == "" || txtWeeklyDuratiuon.Text == "0")
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Are You Sure To Have A  0 hour shift ?:");
                sucess = false;
            }
             return sucess;

        }

        private void Cmb_daytypesunday_SelectedIndexChanged(object sender, EventArgs e)
        {
            offdaysetter("Sunday");

        }

         public void selectionchange(ComboBox cmb ,DateTimePicker dtpin, DateTimePicker dtpOut, TextBox break1, TextBox break2, TextBox break3, TextBox break4, TextBox Durationtxt)
         {
             if (cmb.Text == "Off Day")
             {


                 dtpin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                 dtpOut.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                 break1.Text = "0";
                 break2.Text = "0";
                 break3.Text = "0";
                 break4.Text = "0";
                 Durationtxt.Text = "0";

                 dtpin.Enabled = false;
                 dtpOut.Enabled = false;
                 break1.Enabled = false;
                 break2.Enabled = false;
                 break3.Enabled = false;
                 break4.Enabled = false;
                 Durationtxt.Enabled = false;

             }
             else
             {
                 dtpin.Enabled = true;
                 dtpOut.Enabled = true;
                 break1.Enabled = true;
                 break2.Enabled = true;
                 break3.Enabled = true;
                 break4.Enabled = true;
                 Durationtxt.Enabled = true;


             }
    }

         private void Cmb_daytypemonday_SelectedIndexChanged(object sender, EventArgs e)
         {
             offdaysetter("Monday");
         }

         private void Cmb_daytypetuesday_SelectedIndexChanged(object sender, EventArgs e)
         {
             offdaysetter("Tuesday");
         }

         private void Cmb_daytypewednesday_SelectedIndexChanged(object sender, EventArgs e)
         {
             offdaysetter("Wednesday");
         }

         private void Cmb_daytypethursday_SelectedIndexChanged(object sender, EventArgs e)
         {
             offdaysetter("Thursday");
         }

         private void Cmb_daytypefriday_SelectedIndexChanged(object sender, EventArgs e)
         {
             offdaysetter("Friday");
         }

         private void Cmb_daytypesaturday_SelectedIndexChanged(object sender, EventArgs e)
         {
             offdaysetter("Saturday");
         }

     

   
 
        /// <summary>
        /// get the data to be filled in the 
        /// Shift detils
        /// includes the shift break time
        /// 
        /// </summary>
        /// <returns></returns>
            public DataTable getdataforInserting()
        {
            DataTable dTable = new DataTable();


            DataColumn DayOfWeek = new DataColumn("DayOfWeek", typeof(String));
            dTable.Columns.Add(DayOfWeek);

            DataColumn DayStatus = new DataColumn("DayStatus", typeof(String));
            dTable.Columns.Add(DayStatus);

            DataColumn StartTime = new DataColumn("StartTime", typeof(TimeSpan));
            dTable.Columns.Add(StartTime);
            DataColumn EndTime = new DataColumn("EndTime", typeof(TimeSpan));
            dTable.Columns.Add(EndTime);
            DataColumn ShiftDuration = new DataColumn("ShiftDuration", typeof(System.Int32));
            dTable.Columns.Add(ShiftDuration);

            DataColumn BreakDuration = new DataColumn("BreakDuration", typeof(Int32));
            dTable.Columns.Add(BreakDuration);

            DataColumn BreakNumber = new DataColumn("BreakNumber", typeof(Int32));
            dTable.Columns.Add(BreakNumber);     


            DataRow row = null;

          
               

                    row = dTable.NewRow();
                    row["DayOfWeek"] = "Monday";
                    row["DayStatus"] = Cmb_daytypemonday .Text ;
                    row["StartTime"] = dtpIn_Monday.Value.TimeOfDay ;
                    row["EndTime"] = DtpOut_Monday .Value.TimeOfDay ;
                    row["ShiftDuration"] = int.Parse (txtduration_Monday .Text) ;                   
                    row["BreakDuration"] = int.Parse(txtBreak1_Monday.Text) + int.Parse(txtBreak2_Monday.Text) + int.Parse(txtBreak3_Monday.Text) + int.Parse(txtBreak4_Monday.Text);

                    row["BreakNumber"] = numberofthedays(txtBreak1_Monday, txtBreak2_Monday, txtBreak3_Monday, txtBreak4_Monday);
                dTable.Rows.Add(row);

                    row = dTable.NewRow();
                    row["DayOfWeek"] = "Tuesday";
                    row["DayStatus"] = Cmb_daytypetuesday .Text;
                    row["StartTime"] = dtpIn_Tuesday .Value.TimeOfDay;
                    row["EndTime"] = DtpOut_Tuesday  .Value.TimeOfDay;
                    row["ShiftDuration"] = int.Parse(txtduration_Tuesday.Text);
                    row["BreakDuration"] = int.Parse(txtBreak1_Tuesday.Text) + int.Parse(txtBreak2_Tuesday.Text) + int.Parse(txtBreak3_Tuesday.Text) + int.Parse(txtBreak4_Tuesday.Text);
                    row["BreakNumber"] = numberofthedays(txtBreak1_Tuesday, txtBreak2_Tuesday, txtBreak3_Tuesday, txtBreak4_Tuesday);
                dTable.Rows.Add(row);


                row = dTable.NewRow();
                row["DayOfWeek"] = "Wednesday";
                row["DayStatus"] = Cmb_daytypewednesday .Text;
                row["StartTime"] = dtpIn_Wednesday .Value.TimeOfDay;
                row["EndTime"] = DtpOut_Wednesday .Value.TimeOfDay;
                row["ShiftDuration"] = int.Parse(txtduration_Wednesday.Text);
                row["BreakDuration"] = int.Parse(txtBreak1_Wednesday.Text) + int.Parse(txtBreak2_Wednesday.Text) + int.Parse(txtBreak3_Wednesday.Text) + int.Parse(txtBreak4_Wednesday.Text);
                row["BreakNumber"] = numberofthedays(txtBreak1_Wednesday, txtBreak2_Wednesday, txtBreak3_Wednesday, txtBreak4_Wednesday);
                dTable.Rows.Add(row);



                row = dTable.NewRow();
                row["DayOfWeek"] = "Thursday";
                row["DayStatus"] = Cmb_daytypethursday .Text;
                row["StartTime"] = dtpIn_Thursday .Value.TimeOfDay;
                row["EndTime"] = DtpOut_Thursday .Value.TimeOfDay;
                row["ShiftDuration"] = int.Parse(txtduration_Thursday.Text);
                row["BreakDuration"] = int.Parse(txtBreak1_Thursday.Text) + int.Parse(txtBreak2_Thursday.Text) + int.Parse(txtBreak3_Thursday.Text) + int.Parse(txtBreak4_Thursday.Text);
                row["BreakNumber"] = numberofthedays(txtBreak1_Thursday, txtBreak2_Thursday, txtBreak3_Thursday, txtBreak4_Thursday);
                dTable.Rows.Add(row);


                row = dTable.NewRow();
                row["DayOfWeek"] = "Friday";
                row["DayStatus"] = Cmb_daytypefriday .Text;
                row["StartTime"] = dtpIn_Friday .Value.TimeOfDay;
                row["EndTime"] = DtpOut_Friday .Value.TimeOfDay;
                row["ShiftDuration"] = int.Parse(txtduration_Friday.Text);
                row["BreakDuration"] = int.Parse(txtBreak1_Friday.Text) + int.Parse(txtBreak2_Friday.Text) + int.Parse(txtBreak3_Friday.Text) + int.Parse(txtBreak4_Friday.Text);
                row["BreakNumber"] = numberofthedays(txtBreak1_Friday, txtBreak2_Friday, txtBreak3_Friday, txtBreak4_Friday);
                dTable.Rows.Add(row);

                row = dTable.NewRow();
                row["DayOfWeek"] = "Saturday";
                row["DayStatus"] = Cmb_daytypesaturday .Text;
                row["StartTime"] = dtpIn_Saturday .Value.TimeOfDay;
                row["EndTime"] = DtpOut_Saturday  .Value.TimeOfDay;
                row["ShiftDuration"] = int.Parse(txtduration_Saturday.Text);
                row["BreakDuration"] = int.Parse(txtBreak1_Saturday.Text) + int.Parse(txtBreak2_Saturday.Text) + int.Parse(txtBreak3_Saturday.Text) + int.Parse(txtBreak4_Saturday.Text);
                row["BreakNumber"] = numberofthedays(txtBreak1_Saturday, txtBreak2_Saturday, txtBreak3_Saturday, txtBreak4_Saturday);
                dTable.Rows.Add(row);

                row = dTable.NewRow();
                row["DayOfWeek"] = "Sunday";
                row["DayStatus"] = Cmb_daytypesunday .Text;
                row["StartTime"] = dtpIn_Sunday .Value.TimeOfDay;
                row["EndTime"] = DtpOut_Sunday .Value.TimeOfDay;
                row["ShiftDuration"] = int.Parse(txtduration_Sunday.Text);
                row["BreakDuration"] = int.Parse(txtBreak1_Sunday.Text) + int.Parse(txtBreak2_Sunday.Text) + int.Parse(txtBreak3_Sunday.Text) + int.Parse(txtBreak4_Sunday.Text);
                row["BreakNumber"] = numberofthedays(txtBreak1_Sunday, txtBreak2_Sunday, txtBreak3_Sunday, txtBreak4_Sunday);
                dTable.Rows.Add(row);
           
            return dTable;
        }


        /// <summary>
        /// calulate the number of breaks
        /// of a week
        /// </summary>
        /// <param name="break1"></param>
        /// <param name="break2"></param>
        /// <param name="break3"></param>
        /// <param name="break4"></param>
        /// <returns></returns>
            public int numberofthedays(TextBox break1, TextBox break2, TextBox break3, TextBox break4)
            {
                int breaknum = 0;

                if (break1.Text !="0")
                {
                    breaknum++;
                }
                if (break2.Text != "0")
                {

                    breaknum++;
                }
                if (break3.Text != "0")
                {
                    breaknum++;
                }

                if (break4.Text != "0")
                {
                    breaknum++;
                }




                return breaknum;
            }

            private void btn_Save_Click(object sender, EventArgs e)
            {
                DataTable newshfttable = null;
                if (validationforshift())
                {
                    newshfttable = getdataforInserting();

             int shiftid=       shftfrm.insertnewshift(txt_ShiftName.Text,(Int32)(float.Parse(txtWeeklyDuratiuon.Text)*60), newshfttable);
             if (shiftid > 0)
             {
                 Master.WorkLimitForm wrklmtform = new WorkLimitForm(shiftid);
                 wrklmtform.MdiParent = this.MdiParent;
                 wrklmtform.Show();

                
             }
                   

                }

            }

            private void txtBreak2_Thursday_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar)
       && !char.IsDigit(e.KeyChar)
       && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.'
                    && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }

            private void btn_approval_Click(object sender, EventArgs e)
            {
                Master.ShiftDetailsMasterForm shftdetails = new Master.ShiftDetailsMasterForm();
                shftdetails.MdiParent = this.MdiParent;
                shftdetails.Show();
            }


    }
}

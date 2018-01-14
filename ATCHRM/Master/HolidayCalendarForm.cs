using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class HolidayCalendarForm : Form
    {
        Datalayer.HolidayDayDataBean hlydaybean = null;
        Transactions.HolidayTransaction hldytransaction = null;
        Transactions.Helper hlpr = null;
        public HolidayCalendarForm()
        {
            InitializeComponent();
            hldytransaction = new Transactions.HolidayTransaction();
            gridviewsetup();
            fillGridview();
            hlpr = new Transactions.Helper();

        }

        private void chk_Otherholidays_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Otherholidays.Checked == true)
            {
                pnl_otherholiday.Enabled = true;
                cmb_weeklyofdays.Enabled = false;
            }
            else
            {
                pnl_otherholiday.Enabled = false;
                cmb_weeklyofdays.Enabled = true;
            }
        }



        public Boolean validationcontrols()
        {
            Boolean sucees = false;
            if (pnl_otherholiday.Enabled == true)
            {
                if (txt_holiday.Text == null || txt_holiday.Text == "")
                {
                    lblStatus.Text = " Enter the Name of Holiday";
                    txt_holiday.Focus();
                }

                else  if (dtp_Timepicker.Value == null)
                {
                    lblStatus.Text = " Enter the Date  of Holiday";
                    dtp_Timepicker.Focus();
                }
                else if (cmb_HolidayType.Text == null || cmb_HolidayType.Text == "")
                {
                    lblStatus.Text = " Enter the Type of Holiday";
                    cmb_HolidayType.Focus();
                }

                else
                {
                    sucees = true;
                }
            }
            else
            {
                if (cmb_Year.Text == null || cmb_Year.Text == "")
                {
                    lblStatus.Text = " Enter the Year";
                    cmb_Year.Focus();
                }
                else if (cmb_weeklyofdays.Text == null || cmb_weeklyofdays.Text == "")
                {
                    lblStatus.Text = " Enter the Date  of Holiday";
                    cmb_weeklyofdays.Focus();
                }
                else
                {
                    sucees = true;
                }
              
            }


            return sucees;
        }



        public void fetchdata()
        {
            hlydaybean = new Datalayer.HolidayDayDataBean();

            if (chk_Otherholidays.Checked == true)
            {
                if (validationcontrols())
                {
                    hlydaybean.Holidayname = txt_holiday.Text;
                    hlydaybean.Holidaytype = cmb_HolidayType.Text;
                    hlydaybean.Holidaydescrption = rht_description.Text;
                    hlydaybean.Holidaydate = dtp_Timepicker.Value.Date;

                    hldytransaction.insertHoliday(hlydaybean);
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    fillGridview();
                    clearcontrol();
                }
            }
            else
            {

                

            }

           
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(btn_submit.Text=="Save")
            {
                fetchdata();
            }
            else if (btn_submit.Text == "Edit")
            {
                chk_Otherholidays.Checked = true;
            }
            else if (btn_submit.Text == "Update")
            {
               
            }
        }


        public void gridviewsetup()
        {
            tbl_holidaytable.Columns.Add("1", "SL");
            tbl_holidaytable.Columns.Add("2", "NAME");
            tbl_holidaytable.Columns.Add("3", "TYPE");
            tbl_holidaytable.Columns.Add("4", "DATE");
            tbl_holidaytable.Columns.Add("5", "DESCRIPTION");
            tbl_holidaytable.RowTemplate.Height = 18;
            tbl_holidaytable.Rows.Add();
        }


        public void fillGridview()
        {
            tbl_holidaytable.DataSource = null;
            tbl_holidaytable.RowCount = 1;
          DataTable dt=  hldytransaction.getallholidaydetails();
            
          for (int i = 0; i < dt.Rows.Count;i++ )
          {
              tbl_holidaytable.Rows.Add();
              tbl_holidaytable.Rows[i].Cells[0].Value = dt.Rows[i][0];
              tbl_holidaytable.Rows[i].Cells[1].Value = dt.Rows[i][1];
              tbl_holidaytable.Rows[i].Cells[2].Value = dt.Rows[i][2];
              tbl_holidaytable.Rows[i].Cells[3].Value = dt.Rows[i][3];
              tbl_holidaytable.Rows[i].Cells[4].Value = dt.Rows[i][4];



          }
        }

        public void clearcontrol()
        {
            txt_holiday.Text = "";
            rht_description.Text  = "";
            cmb_HolidayType.Text = "";
            dtp_Timepicker.Value = DateTime.Now;
            pnl_otherholiday.Enabled = false;

        }

        private void tbl_holidaytable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            hlydaybean = new Datalayer.HolidayDayDataBean();
            lblholidaypk.Text = tbl_holidaytable.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_holiday.Text = tbl_holidaytable.Rows[e.RowIndex].Cells[1].Value .ToString  ();
            cmb_HolidayType.Text = tbl_holidaytable.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtp_Timepicker.Value = DateTime.Parse(tbl_holidaytable.Rows[e.RowIndex].Cells[3].Value.ToString());
            rht_description.Text = tbl_holidaytable.Rows[e.RowIndex].Cells[4].Value.ToString();
           
           
            pnl_otherholiday.Enabled = false;
            btn_submit.Text = "Edit";
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(validationcontrols ()){
            DateTime onfrom_From = new DateTime(Convert.ToInt32(cmb_Year.Text), 1, 1);
            int daynum = gettheOFFdate();
            DataTable dt = hldytransaction.GetallDayOfYear(onfrom_From, daynum);
             ATCHRM.Controls.ATCHRMMessagebox.Show( "Total Off Days is "  + dt.Rows.Count.ToString   ());
           hldytransaction. insertoffdays(dt);
            ATCHRM.Controls.ATCHRMMessagebox.Show(" Off Days Done");
           hlpr.ClearFormControls(this);
           fillGridview();
        }
        }

        /// <summary>
        /// checking the day and assigning the number 
        /// </summary>
        /// <returns></returns>
        public int gettheOFFdate()
        {  
             int daynum=1;
           String i = cmb_weeklyofdays.Text.Trim();
            switch (i)
            {
                case "Sunday":

                    daynum = 1;
                    break;
                case "Monday":

                    daynum = 2;
                    break;
                case "Tuesday":
                    daynum = 3;

                    break;
                case "Wednesday":
                    daynum = 4;

                    break;
                case "Thursday":

                    daynum = 5;
                    break;
                case "Friday":
                    daynum = 6;

                    break;
                case "Saturday":

                    daynum = 7;
                    break;
              
                default:
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Select a Vaid Date");
                    break;



            }
            return daynum;
        }


      

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class WorkLimitForm : Form
    {

        int shiftpk = 0;
        Transactions.WorkLimitTransaction wrktrnsctn = null;
        public WorkLimitForm()
        {
            InitializeComponent();
            wrktrnsctn = new Transactions.WorkLimitTransaction();
        }


        public WorkLimitForm(int shtpk)
        {
            InitializeComponent();
            wrktrnsctn = new Transactions.WorkLimitTransaction();
            shiftpk = shtpk;
        }

        
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



           
             if (txt_WeeklyTime.Text == null || txt_WeeklyTime.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Weekly Allowed Time";
                txt_WeeklyTime.Focus();
                txt_WeeklyTime.Visible = true;
            }
           
          

            else
            {
                sucess = true;
            }

            return sucess;

        }

        public Boolean NumberValidation(object sender, KeyPressEventArgs e)
        {
            Boolean VALID = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46)
            {
                VALID = false;
            }
            else
            {
                VALID = true;
            }
            return VALID;
        }

      

      

      

        private void txt_WeeklyTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_WeeklyTime.Text);
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Hours";
                txt_WeeklyTime.Text = "0";
            }
        }

        private void txt_WeeklyTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Hours";
                txt_WeeklyTime.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }

        public void addaction()
        {
            if(ValidationControl ())
        {
            ArrayList arrylst = new ArrayList();

            arrylst.Add(float.Parse(txt_WeeklyTime.Text));

            ArrayList dailyarray = new ArrayList();

            dailyarray.Add(txtminute_Monday.Text);
            dailyarray.Add(txtminute_Tuesday.Text);
            dailyarray.Add(txtminute_Wednesday .Text);
            dailyarray.Add(txtminute_Thursday .Text);
            dailyarray.Add(txtminute_Friday .Text);
            dailyarray.Add(txtminute_Saturday .Text);
            dailyarray.Add(txtminute_Sunday.Text);

            ArrayList daylist = new ArrayList();

            daylist.Add("Monday");
            daylist.Add("Tuesday");
            daylist.Add("Wednesday");
            daylist.Add("Thursday");
            daylist.Add("Friday");
            daylist.Add("Saturday");
            daylist.Add("Sunday");

                if(shiftpk !=0){

            wrktrnsctn.insertWorkLimitrData(arrylst, dailyarray, daylist, shiftpk);
             ATCHRM.Controls.ATCHRMMessagebox.Show("Work Limit Done ");
             ATCHRM.Controls.ATCHRMMessagebox.Show("New Shift Done ");
            clearcontrols();
                }
           
        }


           

        }

       

        public void clearcontrols()
        {
            txt_WeeklyTime.Text = "";
           
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            addaction();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtminute_Monday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtminute_Monday .Text);
                txtHour_Monday.Text = (f / 60).ToString();
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_WeeklyTime.Text = "0";
            }
        }

        private void txtminute_Tuesday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtminute_Tuesday.Text);
                txtHour_Tuesday.Text = (f / 60).ToString();
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_WeeklyTime.Text = "0";
            }

        }

        private void txtminute_Wednesday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtminute_Wednesday.Text);
     txtHour_Wednesday .Text = (f / 60).ToString();
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_WeeklyTime.Text = "0";
            }

        }

        private void txtminute_Thursday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtminute_Thursday.Text);
             txtHour_Thursday .Text = (f / 60).ToString();

            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_WeeklyTime.Text = "0";
            }
        }

        private void txtminute_Friday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtminute_Friday.Text);
               txtHour_Friday .Text = (f / 60).ToString();
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_WeeklyTime.Text = "0";
            }
        }

        private void txtminute_Saturday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtminute_Saturday.Text);
             txtHour_Saturday .Text = (f / 60).ToString();
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_WeeklyTime.Text = "0";
            }

        }

        private void txtminute_Sunday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtminute_Sunday.Text);
                txtHour_Sunday.Text = (f / 60).ToString();
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Minutes";
                txt_WeeklyTime.Text = "0";
            }
        }
    
    
    }
}

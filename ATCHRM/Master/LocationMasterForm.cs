using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class LocationMasterForm : Form
    {
        Transactions.Locationtransaction lctn = null;
        
        public LocationMasterForm()
        {
            InitializeComponent();
            lctn = new Transactions.Locationtransaction();
           
            
        }
        public LocationMasterForm(String details)
        {
            InitializeComponent();


            if (details == "Country")
            {
                lblStatus.Text = "Enter Country State and City";

            }

            if (details == "State")
            {
                cmb_CountryName.Enabled = false;
                lblStatus.Text = "Enter State and City";

            }

            if (details == "City")
            {
                cmb_CountryName.Enabled = false;
                txt_stateName.Enabled = false;
                lblStatus.Text = "Enter  City Name";
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {
                try
                {
                    sqlConnection1.ConnectionString = Program.ConnStr;
                    sqlConnection1.Open();
                    sqlCommand1.Parameters.AddWithValue("@pCountryName", cmb_CountryName.Text);
                    sqlCommand1.Parameters.AddWithValue("@pStateName", txt_stateName.Text);
                    sqlCommand1.Parameters.AddWithValue("@pCitName", txt_cityName.Text);
                    sqlCommand1.Parameters.AddWithValue("@pDateAdded", DateTime.Now.Date);
                    sqlCommand1.ExecuteNonQuery();
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Location Added ");
                    clearControls();
                    
                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message .ToString ());
                    this.Dispose();
                   
                }
                finally
                {
                    sqlConnection1.Close();
                    fillDataGrid();
                    
                }
            }
        }

        /// <summary>
        /// validates if any of the feilda are null
        /// </summary>
        /// <returns>sucess</returns>

        public Boolean validateControl()
        {
            Boolean sucess = false;
            if (cmb_CountryName.Text == null || cmb_CountryName.Text.Trim() == "")
            {
                lblStatus.Text = "Enter A Country Name";
                cmb_CountryName.Focus();
            }
            else if(txt_stateName.Text == null || txt_stateName.Text.Trim() == "")
            {
                lblStatus.Text = "Enter A State ";
                txt_stateName.Focus();
            }
            else if(txt_cityName.Text == null || txt_cityName.Text.Trim() == "")
            {
                lblStatus.Text = "Enter A State ";
                txt_stateName.Focus();
            }
           
            else{
                if (lctn.islocationPresent(cmb_CountryName.Text, txt_stateName.Text, txt_cityName.Text) == true)
                {

                    sucess = true;
                }
                else
                {
                    lblStatus.Text = "this Location Already Present";
                }
            }
            return sucess;
        }
        /// <summary>
        /// clear all the controls
        /// </summary>
        public void clearControls()
        {
            txt_cityName.Text = "";
            cmb_CountryName .Text = "";
            txt_stateName.Text = "";
        }

        private void LocationMasterForm_Load(object sender, EventArgs e)
        {
            fillDataGrid();  
           
        }
        /// <summary>
        /// 
        /// fill the datgrid with the last availabele location
        /// </summary>
        public void fillDataGrid()
        {
            try
            {
                lctn = new Transactions.Locationtransaction();
                DataTable dt = lctn.getLocation();
                int count = dt.Rows.Count;


                if (count != 0)
                {
                    tbl_location.DataSource = dt;

                }
                else
                {
                    lblStatus.Text = "NO Location Found";
                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }

    }
}

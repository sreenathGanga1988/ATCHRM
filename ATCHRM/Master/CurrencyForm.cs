using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class CurrencyForm : Form
    {
        Transactions.currencytransaction  crncytran = null;
        public CurrencyForm()
        {
            InitializeComponent();
            crncytran = new Transactions.currencytransaction();
            displayCurrencylist();

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.validateControl())
            {
                if (btn_Save.Text == "Save")
                {
                    addcurrency();

                }
                else
                {
                    updatecurrency();

                }
               

            }

        }

        /// <summary>
        /// clear all countrols
        /// </summary>
        public void clearControls()
        {
            txt_CurrencyCode.Text  = "";
            txt_CurrencyName.Text = "";
            cmb_CountryName.Text = "";
            txt_rate.Text = "";
            btn_Save.Text = "Save";
            lblpk.Text = "";
        }


        /// <summary>
        /// validates if any of the feilda are null
        /// </summary>
        /// <returns>sucess</returns>

        public Boolean validateControl()
        {
            Boolean sucess = false;
            if (txt_CurrencyName.Text == null || txt_CurrencyName.Text.Trim() == "")
            {
                lblStatus.Text = "Enter A CurrencyName ";
                txt_CurrencyName.Focus();
            }
            else if (cmb_CountryName.Text == null || cmb_CountryName.Text.Trim() == "")
            {
                lblStatus.Text = "Enter A Country Name";
                cmb_CountryName.Focus();
            }

            else if (txt_CurrencyCode.Text == null || txt_CurrencyCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter A CurrencyCode ";
                txt_CurrencyCode.Focus();
            }
            else if (txt_rate.Text == null || txt_rate.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Currecny Rate against ";
                txt_CurrencyCode.Focus();
            }
           
            else
            {
                sucess = true;
            }
            return sucess;
        }
        public void displayCurrencylist()
        {
            DataSet ds=  crncytran.showallcurrecy();
           
            listBox1.ValueMember = "currency.pk";
            listBox1.DisplayMember = "currency.NameAdr";
            listBox1.DataSource = ds;
        }
      
        
      public   Boolean NumberValidation(object sender, KeyPressEventArgs e)
        {
            Boolean VALID = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46)
            {
                VALID = false;
            }
            else
            {
                VALID = true;
                lblStatus.Text = "";
            }
            return VALID;
        }

        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
          if( NumberValidation(sender, e))
            {
                lblStatus.Text = "Enter Valid Number as Rate";
                txt_rate.Text = "";
          }
        }

       

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int itemno = int.Parse(listBox1.SelectedValue.ToString());
                DataSet ds = crncytran.getcurrecydataof(itemno);
                if (ds.Tables.Count > 0)
                {

                    cmb_CountryName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txt_CurrencyCode.Text = ds.Tables[0].Rows[0][2].ToString();
                    txt_CurrencyName.Text = ds.Tables[0].Rows[0][3].ToString();
                    txt_rate.Text = ds.Tables[0].Rows[0][5].ToString();
                    lblpk.Text = itemno.ToString(); ;
                    btn_Save.Text = "Update";
                }
                else
                {
                    lblStatus.Text = "Incomplete Entry";
                }
            }
            catch (Exception exp)
            {
                
               
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message .ToString ());
                    this.Dispose();
            }
        }


        /// <summary>
        /// update the existing  currency
        /// </summary>
        public void updatecurrency()
        {

           
                sqlConnection1.ConnectionString = Program.ConnStr;
                sqlConnection1.Open();
                SqlCommand updatecommand = new SqlCommand("UPDATE  CurrencyMaster_tbl SET  CurrencyCountry = @Param1, CurrencyCode = @Param2, Name = @Param3, Rate = @Param4, DateAdded = @Param5 WHERE (Currency_Pk = @Param6)", sqlConnection1);
            
                updatecommand.Parameters.AddWithValue("@Param1", cmb_CountryName.Text);
                updatecommand.Parameters.AddWithValue("@Param2", txt_CurrencyCode.Text);
                updatecommand.Parameters.AddWithValue("@Param3", txt_CurrencyName.Text);
                updatecommand.Parameters.AddWithValue("@Param5", DateTime.Now.Date);
                updatecommand.Parameters.AddWithValue("@Param4", float.Parse(txt_rate.Text.ToString()));
                updatecommand.Parameters.AddWithValue("@Param6", int.Parse(lblpk.Text.ToString()));
                updatecommand.ExecuteNonQuery();
                sqlConnection1.Close();
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Currency Updated");
                clearControls();
                displayCurrencylist();
           

        }

/// <summary>
/// add new currency if 
/// it was not previusly added
/// check whether present in the database
/// </summary>
        public void addcurrency()
        {

            if (crncytran.isCurrencyPresent(txt_CurrencyName.Text.Trim(), cmb_CountryName.Text.Trim(), txt_CurrencyCode.Text.Trim()) == true)
            {
                lblStatus.Text = "Currency Already Present ";
                clearControls();

            }


            else
            {
                try
                {
                    sqlConnection1.ConnectionString = Program.ConnStr;
                    sqlConnection1.Open();
                    sqlCommand1.Connection = sqlConnection1;
                    sqlCommand1.Parameters.AddWithValue("@pCurrencyCountry", cmb_CountryName.Text);
                    sqlCommand1.Parameters.AddWithValue("@pCurrencyCode", txt_CurrencyCode.Text);
                    sqlCommand1.Parameters.AddWithValue("@pName", txt_CurrencyName.Text);
                    sqlCommand1.Parameters.AddWithValue("@pDateAdded", DateTime.Now.Date);
                    sqlCommand1.Parameters.AddWithValue("@pRate", float.Parse(txt_rate.Text.ToString()));
                    sqlCommand1.ExecuteNonQuery();
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Currency Added");
                    clearControls();
                    displayCurrencylist();
                }
                catch (Exception exp)
                {
                    if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                    {
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
                    }
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                    this.Dispose();
                }
                finally
                {
                    sqlConnection1.Close();
                }
            }

        }

        private void txt_rate_TextChanged(object sender, EventArgs e)
        {

        }
    
    
    
    
    
    
    
    
    
    }
}

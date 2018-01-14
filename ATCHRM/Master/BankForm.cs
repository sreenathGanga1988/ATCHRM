using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class BankForm : Form
    {
        Transactions.Locationtransaction lctn = null;
        Datalayer.BankDataBean bnkdatabean= null;
        Transactions.BankTransactions bnktransaction = null;
        public BankForm()
        {
            InitializeComponent();
            lctn = new Transactions.Locationtransaction();
            bnktransaction = new Transactions.BankTransactions();
            countrylistload();
        }
        public BankForm(int bankpk)
        {
            InitializeComponent();
            lctn = new Transactions.Locationtransaction();
            bnktransaction = new Transactions.BankTransactions();

            DataTable dt = bnktransaction.getbankdatabypk(bankpk);
            filldata(dt);
        }
        private void btn_newcity_Click(object sender, EventArgs e)
        {

            try
            {
                if (btn_NewCity .Text == "Save")
                {
                    if (subvalidatelocation())
                    {
                        lctn.insertlocation(txt_newCountry.Text, txt_newState.Text, txt_Newcity.Text);
                        clearcontrols ();
                        countrylistload();
                    }


                }
                else
                {
                    txt_newCountry.Text = cmb_Country.Text;
                    txt_newState.Text = cmb_State.Text;
                    btn_NewCity.Text = "Save";
                    txt_Newcity.Visible = true;
                }
            }
            catch (Exception exp)
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.ToString());
                this.Close();
            }
            finally
            {

            }
        }

        private void btn_newState_Click(object sender, EventArgs e)
        {


            if (btn_NewState .Text == "Save")
            {


            }
            else
            {
                txt_newCountry.Text = cmb_Country.Text;
                btn_NewState.Text = "Save";
                txt_newState.Visible = true;
                btn_NewCity.Text = "Save";
                txt_Newcity.Visible = true;
                btn_NewState.Enabled = false;
            }
        }

        private void btn_addcountry_Click(object sender, EventArgs e)
        {

            if (btn_addcountry.Text == "Save")
            {


            }
            else
            {
                btn_addcountry.Text = "Save";
                txt_newCountry.Visible = true;
                btn_NewCity.Text = "Save";
                txt_Newcity.Visible = true;
                btn_NewState.Text = "Save";
                txt_newState.Visible = true;
                btn_addcountry.Enabled = false;
                btn_NewState.Enabled = false;
            }
        }



        /// <summary>
        /// vaildates the loaction controls while adding new 
        /// location
        /// </summary>
        /// <returns></returns>
        public Boolean subvalidatelocation()
        {
            Boolean sucess = false;

            if (txt_newCountry.Text == null || txt_newCountry.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  Country Name";
                txt_newCountry.Focus();

            }
            else if (txt_newState.Text == null || txt_newState.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid State  Name";
                txt_newState.Focus();

            }
            else if (txt_Newcity.Text == null || txt_Newcity.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid City ";
                txt_Newcity.Focus();

            }
            else
            {
                sucess = true;

            }

            return sucess;
        }
          /// <summary>
        /// clear all the controls of the form
        /// </summary>
        public void clearcontrols()
        {
            lblpk.Text = "0";
            txt_bankName.Text = "";
            txt_BranchName.Text = "";
            txt_BranchCode.Text = "";
            rht_adress1.Text = "";
            rht_Adress2.Text = "";
            cmb_Country.Text = "";
            cmb_State.Text = "";
            cmb_City.Text = "";
            cmb_City.Enabled = true; ;
            cmb_Country.Enabled = true; ;
            cmb_State.Enabled = true; ;
            txt_zipcode.Text = "";
            txt_phoneno.Text = "";
            txt_faxno.Text = "";
            txt_Email.Text = "";
            txt_swiftcode.Text = "";
            grpbank.Enabled = true;
            countrylistload();
        }


        /// <summary>
        /// reloads the country to comobox
        /// </summary>
        public void countrylistload()
        {
          DataTable   dt = lctn.getcountry();
            cmb_Country.DataSource = dt;
            cmb_Country.DisplayMember = "CountryName";
        } 

/// <summary>
/// validates the controls
/// </summary>
/// <returns></returns>
        public Boolean  validationcontrol()
    {
        Boolean sucess = false;

        if (txt_bankName.Text == null || txt_bankName.Text.Trim() == "")
        {
            lblStatus.Text = "Enter Valid Bank Name";
            txt_bankName.Focus();
            lbl_Bankname.Visible = true;

        }


        else if (txt_BranchName.Text == null || txt_BranchName.Text.Trim() == "")
        {
            lblStatus.Text = "Enter Valid Branch Name";
            txt_BranchName.Focus();
            lbl_BranchName.Visible = true;

        }
        else if (rht_adress1.Text == null || rht_adress1.Text.Trim() == "")
        {
            lblStatus.Text = "Enter Valid Adress";
            rht_adress1.Focus();
            lbl_Adress1.Visible = true;

        }
        else if (cmb_City.Text == null || cmb_City.Text.Trim() == "")
        {
            lblStatus.Text = "Enter City";
            cmb_City.Focus();
           

        }
        else
        {
            sucess = true;
        }


        return sucess;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.Text == "Save")
            {
                if (validationcontrol())
                {
                    bnktransaction.insertbankData(fetchdata());
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Bank Details  Added");
                    clearcontrols();
                }
            }

            else if (btn_Save.Text == "Edit")
            {
                grpbank.Enabled = true;
                btn_Save.Text ="Update";

            }
            else if (btn_Save.Text == "Update")
            {
                if (validationcontrol())
                {
                    bnktransaction.updateBranchLocationDertails(fetchdata());
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Bank Details Updated ");
                    clearcontrols();
                }

            }

        }


        public Datalayer.BankDataBean  fetchdata()
        {        bnkdatabean = new Datalayer.BankDataBean();
        if (btn_Save.Text == "Save")
        {


            bnkdatabean.BankName = txt_bankName.Text;
            bnkdatabean.BankbranchName = txt_BranchName.Text;
            string code = txt_bankName.Text.Substring(0, 2) + "-" + txt_BranchName.Text.Substring(0, 2);
            txt_BranchCode.Text = code;
            bnkdatabean.Branchcode = txt_BranchCode.Text;
            bnkdatabean.Adress1 = rht_adress1.Text;
            bnkdatabean.Adress2 = rht_Adress2.Text;
            bnkdatabean.Lctnpk = int.Parse(cmb_City.SelectedValue.ToString());
            bnkdatabean.Zipcode = txt_zipcode.Text;
            bnkdatabean.Email = txt_Email.Text;
            bnkdatabean.Phonenum = txt_phoneno.Text;
            bnkdatabean.Faxnum = txt_faxno.Text;
            bnkdatabean.Swiftcode = txt_swiftcode.Text;

        }
        else if (btn_Save.Text == "Update")
        {

            bnkdatabean.Bankpk = int.Parse(lblpk.Text); 
            bnkdatabean.BankName = txt_bankName.Text;
            bnkdatabean.BankbranchName = txt_BranchName.Text;
           
            bnkdatabean.Branchcode = txt_BranchCode.Text;
            bnkdatabean.Adress1 = rht_adress1.Text;
            bnkdatabean.Adress2 = rht_Adress2.Text;
           
            bnkdatabean.Zipcode = txt_zipcode.Text;
            bnkdatabean.Email = txt_Email.Text;
            bnkdatabean.Phonenum = txt_phoneno.Text;
            bnkdatabean.Faxnum = txt_faxno.Text;
            bnkdatabean.Swiftcode = txt_swiftcode.Text;


        }
            return bnkdatabean;

        }

        private void cmb_State_SelectedIndexChanged(object sender, EventArgs e)
        {
           DataTable dt = lctn.getcitybycountry(cmb_Country.Text, cmb_State.Text);
            cmb_City.DataSource = dt;
            cmb_City.DisplayMember = "CitName";
            cmb_City.ValueMember = "LocationPk";
        }

        private void cmb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
          DataTable    dt = lctn.getstatebycountry(cmb_Country.Text);
            cmb_State.DataSource = dt;
            cmb_State.DisplayMember = "StateName";
        }


        public void filldata(DataTable dt)
        {
            lblpk.Text = dt.Rows[0][0].ToString();
            txt_bankName.Text = dt.Rows[0][1].ToString();
            txt_BranchName.Text = dt.Rows[0][2].ToString();
            txt_BranchCode.Text = dt.Rows[0][3].ToString();
            rht_adress1.Text = dt.Rows[0][4].ToString();
            rht_Adress2.Text = dt.Rows[0][5].ToString();
            cmb_Country.Text = dt.Rows[0][6].ToString();
            cmb_State .Text = dt.Rows[0][7].ToString();
            cmb_City.Text = dt.Rows[0][8].ToString();
            cmb_City.Enabled = false;
            cmb_Country.Enabled = false;
            cmb_State.Enabled = false;
            txt_zipcode.Text = dt.Rows[0][9].ToString();
            txt_phoneno.Text = dt.Rows[0][10].ToString();
            txt_faxno.Text = dt.Rows[0][11].ToString();
            txt_Email.Text = dt.Rows[0][12].ToString();
            txt_swiftcode.Text = dt.Rows[0][13].ToString();
            grpbank.Enabled = false;
            btn_Save.Text = "Edit";

        }

       

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearcontrols ();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}

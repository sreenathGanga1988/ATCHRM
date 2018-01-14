using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using ATCHRM.Datalayer;

namespace ATCHRM.Master
{

    public partial class CompanyForm : Form
    {
        CompanyDatabean companyDatabean = null;
        Transactions.Locationtransaction lctn = null;
        Transactions.CompanyBranchTransactions cmptranctn = null;
        DataTable dt = null;
        public CompanyForm()
        {
            InitializeComponent();
            lctn = new Transactions.Locationtransaction();
            cmptranctn = new Transactions.CompanyBranchTransactions();

        }
        public CompanyForm(DataTable dt)
        {
            InitializeComponent();
            lctn = new Transactions.Locationtransaction();
            cmptranctn = new Transactions.CompanyBranchTransactions();
            filldata(dt);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_newcity_Click(object sender, EventArgs e)
        {

            try
            {
                if (btn_newcity.Text == "Save")
                {
                    if (subvalidatelocation())
                    {
                        lctn.insertlocation(txt_newCountry.Text, txt_newState.Text, txt_Newcity.Text);
                        clearallControl();
                        countrylistload();
                    }


                }
                else
                {
                    txt_newCountry.Text = cmb_Country.Text;
                    txt_newState.Text = cmb_State.Text;
                    btn_newcity.Text = "Save";
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_newState_Click(object sender, EventArgs e)
        {

            if (btn_newState.Text == "Save")
            {


            }
            else
            {
                txt_newCountry.Text = cmb_Country.Text;
                btn_newState.Text = "Save";
                txt_newState.Visible = true;
                btn_newcity.Text = "Save";
                txt_Newcity.Visible = true;
                btn_newState.Enabled = false;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addcountry_Click(object sender, EventArgs e)
        {
            if (btn_addcountry.Text == "Save")
            {


            }
            else
            {
                btn_addcountry.Text = "Save";
                txt_newCountry.Visible = true;
                btn_newcity.Text = "Save";
                txt_Newcity.Visible = true;
                btn_newState.Text = "Save";
                txt_newState.Visible = true;
                btn_addcountry.Enabled = false;
                btn_newState.Enabled = false;
            }

        }


        /// <summary>
        /// clear all the controls of the form
        /// </summary>
        public void clearallControl()
        {
            btn_newcity.Text = "Add New City";
            btn_addcountry.Text = "Add New Country";
            btn_newState.Text = "Add New State";
            txt_CompanyCode.Text = "";
            txt_newCountry.Visible = false;
            txt_newState.Visible = false;
            txt_Newcity.Visible = false;
            txt_CompanyName.Text = "";
            rht_adress1.Text = "";
            rht_Adress2.Text = "";
            txt_Email.Text = "";
            txt_faxno.Text = "";
            txt_phoneno.Text = "";
            txt_zipcode.Text = "";
            this.Text = "Company";
            //    cmb_City.SelectedIndex = 1;
            //  cmb_Country.SelectedIndex = 1;
            //    cmb_State.SelectedIndex = 1;
            lbl_Adress1.Visible = false;
            lbl_CompanyCode.Visible = false;
            lbl_Companyname.Visible = false;
            btn_addcountry.Enabled = true;
            btn_newState.Enabled = true;
            btn_newcity.Enabled = true;
            txt_Newcity.Text = "";
            txt_newCountry.Text = "";
            txt_newState.Text = "";
            txt_CompanyCode.Enabled = true;
            lblpk.Text = "";
            btn_Save.Text = "Save";
            cmb_Country.Enabled = true;
            cmb_State.Enabled = true;
            cmb_City.Enabled = true;
            grbData.Enabled = true;
            countrylistload();
        }
        /// <summary>
        /// Cancel button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearallControl();
        }
        /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (txt_CompanyName.Text == null || txt_CompanyName.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Company Name";
                txt_CompanyName.Focus();
                lbl_Companyname.Visible = true;
            }
            else if (txt_CompanyCode.Text == null || txt_CompanyCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid CompanyCode";
                txt_CompanyCode.Focus();
                lbl_CompanyCode.Visible = true;
            }
            else if (rht_adress1.Text == null || rht_adress1.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Adress ";
                rht_adress1.Focus();
                lbl_Adress1.Visible = true;
            }

            else
            {
                sucess = true;
            }

            return sucess;

        }
        /// <summary>
        /// when buttonsave cclicked
        /// will save data to database if  button text is SAve
        /// will Update if it is  UPdate
        /// will enable the group box for editting if it is Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                companyDatabean = null;
                if (btn_Save.Text == "Save")
                {

                    if (ValidationControl())
                    {

                        companyDatabean = fetchdata();
                        if (companyDatabean != null)
                        {

                            try
                            {
                                cmptranctn.insertcompanyDetails(companyDatabean);
                                 ATCHRM.Controls.ATCHRMMessagebox.Show("Company Details  Added");
                             
                                clearallControl();
                                closecontrols();
                            }
                            catch (Exception exp)
                            {

                                ErrorLogger er = new ErrorLogger();
                                er.createErrorLog(exp);
                                 ATCHRM.Controls.ATCHRMMessagebox.Show("ERROR AT ADDING NEW COMPANY " + exp.Message.ToString());
                                this.Dispose();
                            }
                        }
                    }
                }

                else if (btn_Save.Text == "Edit")
                {
                    grbData.Enabled = true;
                    btn_Save.Text = "Update";
                    txt_CompanyCode.Enabled = false;

                }
                else if (btn_Save.Text == "Update")
                {
                    if (ValidationControl())
                    {


                        fetchdata();
                        if (companyDatabean != null)
                        {
                            cmptranctn.UpdatecompanyDetails(companyDatabean);
                             ATCHRM.Controls.ATCHRMMessagebox.Show("Updates Done");
                            clearallControl();
                            closecontrols();
                        }

                    }


                }


            }

            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
                this.Close();
            }

           
            
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            if (this.Text == "New Company")
            {
                countrylistload();
            }



        }

        private void cmb_City_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = lctn.getstatebycountry(cmb_Country.Text);
            cmb_State.DataSource = dt;
            cmb_State.DisplayMember = "StateName";
        }

        private void cmb_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = lctn.getcitybycountry(cmb_Country.Text, cmb_State.Text);
            cmb_City.DataSource = dt;
            cmb_City.DisplayMember = "CitName";
            cmb_City.ValueMember = "LocationPk";
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
        /// reloads the country to comobox
        /// </summary>
        public void countrylistload()
        {
            dt = lctn.getcountry();
            cmb_Country.DataSource = dt;
            cmb_Country.DisplayMember = "CountryName";
        }
        /// <summary>
        /// fetch data from the controls
        /// and fill them in databean for transactions
        /// </summary>
        public Datalayer.CompanyDatabean fetchdata()
        {
            if (this.Text == "New Company")
            {

                companyDatabean = new CompanyDatabean();



                companyDatabean.Companyname = txt_CompanyName.Text;
                companyDatabean.Companycode = txt_CompanyCode.Text;
                companyDatabean.Adress11 = rht_adress1.Text;
                companyDatabean.Adress21 = rht_Adress2.Text;
                companyDatabean.Phoneno = txt_phoneno.Text;
                companyDatabean.Zipcode = txt_zipcode.Text;
                companyDatabean.Email = txt_Email.Text;
                companyDatabean.Faxno1 = txt_faxno.Text;
                companyDatabean.Locationpk = int.Parse(cmb_City.SelectedValue.ToString());



            }
            else
            {
                companyDatabean = new CompanyDatabean();


                companyDatabean.Companypk = int.Parse(lblpk.Text);
                companyDatabean.Companyname = txt_CompanyName.Text;
                companyDatabean.Companycode = txt_CompanyCode.Text;
                companyDatabean.Adress11 = rht_adress1.Text;
                companyDatabean.Adress21 = rht_Adress2.Text;
                companyDatabean.Phoneno = txt_phoneno.Text;
                companyDatabean.Zipcode = txt_zipcode.Text;
                companyDatabean.Email = txt_Email.Text;
                companyDatabean.Faxno1 = txt_faxno.Text;
                companyDatabean.Locationpk = int.Parse(lbl_locationpk.Text);


            }
            return companyDatabean;
        }

        /// <summary>
        /// setdata to the controlls from datatable 
        /// </summary>
        /// <param name="dt"></param>
        public void filldata(DataTable dt)
        {
            txt_CompanyName.Text = dt.Rows[0][1].ToString();
            txt_CompanyCode.Text = dt.Rows[0][2].ToString();
            txt_zipcode.Text = dt.Rows[0][3].ToString();

            txt_phoneno.Text = dt.Rows[0][4].ToString();
            txt_faxno.Text = dt.Rows[0][5].ToString();
            txt_Email.Text = dt.Rows[0][6].ToString();
            rht_adress1.Text = dt.Rows[0][7].ToString();
            rht_Adress2.Text = dt.Rows[0][8].ToString();

            cmb_Country.Text = dt.Rows[0][9].ToString();
            cmb_State.Text = dt.Rows[0][10].ToString();
            cmb_City.Text = dt.Rows[0][11].ToString();
            //    cmb_City.SelectedValue = dt.Rows[0][12].ToString();
            lblpk.Text = dt.Rows[0][0].ToString();
            grbData.Enabled = false;
            btn_Save.Text = "Edit";
            lbl_locationpk.Text = dt.Rows[0][12].ToString();
            cmb_Country.Enabled = false;
            cmb_State.Enabled = false;
            cmb_City.Enabled = false;
        }

        public void closecontrols()
        {

            this.Close();
            Master.CompanyMasterForm cmpnymasterform = new Master.CompanyMasterForm();

            cmpnymasterform.Show();
            cmpnymasterform.MdiParent = this.MdiParent;
        }


    }
}

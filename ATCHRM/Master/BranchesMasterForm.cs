using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class BranchesMasterForm : Form
    {
        Transactions.Locationtransaction lctn = null;
        Datalayer.BranchDataBean branchdatabean = null;
        Datalayer.locationBranchDatabean lctnbrdatabean = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;

        public BranchesMasterForm()
        {
            InitializeComponent();
            lctn = new Transactions.Locationtransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();

        }

        public BranchesMasterForm(int PK, String tabstring)
        {
            cmptransaction = new Transactions.CompanyBranchTransactions();
            if (tabstring == "Branches")
            {
                this.Text = "Branch Details";
                InitializeComponent();
                lctn = new Transactions.Locationtransaction();


                getbranchdataforupdate(PK);
            }
            else
            {

                InitializeComponent();
                tbc_Main.SelectedTab = LocationTab;
                this.Text = "Location Details";
                lctn = new Transactions.Locationtransaction();

                getlocationdataforupdate(PK);
            }

        }


        ///////////////////////////////////////////////////////////////////////////**************BRANCH*******************/////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  

       
        private void btn_brNewCountry_Click(object sender, EventArgs e)
        {
           
        }

       
        private void Branches_Enter(object sender, EventArgs e)
        {
            if (this.Text != "Branch Details")
            {
                basicloaditems();
            }

        }
        private void cmb_brCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = lctn.getstatebycountry(cmb_brCountry.Text);
            cmb_brState.DataSource = dt;
            cmb_brState.DisplayMember = "StateName";
        }

        public void companyListLoad()
        {
            DataTable dt = cmptransaction.selectallcompanydata();

            cmb_brheadecompany.DisplayMember = "NAME";
            cmb_brheadecompany.ValueMember = "SL";
            cmb_brheadecompany.DataSource = dt;
        }
        public void Branchtabactions()
        {


            if (this.Text.Trim () == "Branches")
            {
                if (validationcontrols())
                {
                    fetchdata();
                    if (branchdatabean != null)
                    {
                        cmptransaction.insertbranch(branchdatabean);
                         ATCHRM.Controls.ATCHRMMessagebox.Show(" Branch  Added ");
                        clearcontrols();
                       //closecontrols();
                    }

                }
            }

            else if (this.Text == "Branch Details")
            {

                if (btn_Save.Text == "Edit")
                {
                    pnl_Branch.Enabled = true;
                    btn_Save.Text = "Update";

                }

                else if (btn_Save.Text == "Update")
                {
                    fetchdataforUpdate();
                    if (branchdatabean != null)
                    {
                        cmptransaction.updateBranch(branchdatabean);
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Branch Details Updated ");
                        clearcontrols();
                        //closecontrols();
                    }

                }



            }

        }

        public void getbranchdataforupdate(int pk)
        {
            DataTable dt = cmptransaction.getallBranchDatbyPK(pk);
            cmb_brheadecompany.Text = dt.Rows[0][0].ToString();
            lbl_cmpanyPK.Text = dt.Rows[0][1].ToString();
            cmb_brheadecompany.Enabled = false;
            txt_brBranchName.Text = dt.Rows[0][2].ToString();
            lbl_branchpk.Text = dt.Rows[0][3].ToString();
            cmb_brCountry.Text = dt.Rows[0][4].ToString();
            cmb_brState.Text = dt.Rows[0][5].ToString();
            cmb_brcity.Text = dt.Rows[0][6].ToString();

            cmb_brcity.Enabled = false;
            cmb_brCountry.Enabled = false;
            cmb_brState.Enabled = false;
            txt_brZipCode.Text = dt.Rows[0][8].ToString();
            txt_brPhoneno.Text = dt.Rows[0][9].ToString();
            txt_brfaxno.Text = dt.Rows[0][10].ToString();
            txt_brEmail.Text = dt.Rows[0][11].ToString();
            lbl_locationpk.Text = dt.Rows[0][7].ToString();
            btn_Save.Text = "Edit";
            pnl_Branch.Enabled = false;
            //   ATCHRM.Controls.ATCHRMMessagebox.Show(cmb_brheadecompany.SelectedValue.ToString());
        }


        ////////////////////////////////////////////////////////////////////////***********location Tab*********///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        private void LocationTab_Enter(object sender, EventArgs e)
        {
            if (this.Text != "Location Details")
            {
                basicloaditems();
            }

        }




        public void branchListLoad()
        {
            DataTable dt = cmptransaction.selectallbranch();

            cmb_ltBranchName.DisplayMember = "BRANCH";
            cmb_ltBranchName.ValueMember = "SL";
            cmb_ltBranchName.DataSource = dt;
        }

        public void getlocationdataforupdate(int PK)
        {
            DataTable dt = cmptransaction.getLocationdatabyPk(PK);
            if (dt.Rows.Count != 0)
            {
                cmb_ltBranchName.Text = dt.Rows[0][0].ToString();
                lbl_ltbranchPk.Text = dt.Rows[0][1].ToString();
                txt_locationName.Text = dt.Rows[0][2].ToString();
                lbl_ltLocationPk.Text = dt.Rows[0][3].ToString();
                rht_ltAdress1.Text = dt.Rows[0][4].ToString();
                rht_ltAdress2.Text = dt.Rows[0][5].ToString();
                cmb_ltCountry.Text = dt.Rows[0][6].ToString();
                cmb_ltState.Text = dt.Rows[0][7].ToString();
                cmb_ltCity.Text = dt.Rows[0][8].ToString();
                lbl_ltlctnPk.Text = dt.Rows[0][9].ToString();
                cmb_ltCity.Enabled = false;
                cmb_ltCountry.Enabled = false;
                cmb_ltState.Enabled = false;
                txt_ltZipcode.Text = dt.Rows[0][10].ToString();
                txt_ltPhoneno.Text = dt.Rows[0][11].ToString();
                txt_ltfax.Text = dt.Rows[0][12].ToString();
                txt_ltEmail.Text = dt.Rows[0][13].ToString();
                btn_Save.Text = "Edit";
                pnl_location.Enabled = false;
            }


        }

        /////////////////////////////////////////////////////////////////////////////////*********COMMON Tab ***************///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// clear controls
        /// check which tAB IS SELECTED AND DELETES THE TEXT IN THAT TAB
        /// </summary>
        public void clearcontrols()
        {
            if (tbc_Main.SelectedTab == Branches)
            {
                txt_brNewCity.Text = "";
                txt_brnewcountry.Text = "";
                txt_brNewState.Text = "";
                txt_brnewcountry.Text = "";
                txt_brBranchName.Text = "";
                txt_brEmail.Text = "";
                txt_brfaxno.Text = "";
                txt_brPhoneno.Text = "";
                txt_brZipCode.Text = "";
                cmb_brheadecompany.Text = "";
                btn_brNewCity.Enabled = true;
                btn_brNewCountry.Enabled = true;
                btn_brNewState.Enabled = true;
                btn_brNewCity.Text = "Add New City";
                btn_brNewCountry.Text = "Add New Country";
                btn_brNewState.Text = "Add New State";
                cmb_brcity.Enabled = true;
                cmb_brCountry.Enabled = true;
                cmb_brState.Enabled = true;
            }
            else
            {

                txt_ltNewcity.Text = "";
                txt_ltNewcountry.Text = "";
                txt_ltNewstate.Text = "";
                txt_ltNewcountry.Text = "";
                txt_locationName.Text = "";
                txt_ltEmail.Text = "";
                txt_ltfax.Text = "";
                txt_ltPhoneno.Text = "";
                txt_ltZipcode.Text = "";
                cmb_ltBranchName.Text = "";
                rht_ltAdress1.Text = "";
                btn_ltnewcity.Text = "Add New City";
                btn_ltnewcountry.Text = "Add New Country";
                btn_ltnewstate.Text = "Add New State";
                btn_ltnewcity.Enabled = true;
                btn_brNewCountry.Enabled = true;
                btn_ltnewstate.Enabled = true;
                cmb_ltCity.Enabled = true;
                cmb_ltCountry.Enabled = true;
                cmb_ltState.Enabled = true;

            }
            pnl_location.Enabled = true;
            pnl_Branch.Enabled = true;
            countrylistload();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbc_Main.SelectedTab == Branches)
                {
                    Branchtabactions();
                    tbc_Main.SelectedTab = LocationTab ;
                }
                else
                {
                    Locationtabactions();

                }
            }
            catch (Exception exp)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Error At Adding NEW Branch or Location " + exp.Message.ToString());
                this.Dispose();
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearcontrols();
        }
        /// <summary>
        /// reloads the country to comobox
        /// </summary>
        public void countrylistload()
        {
            DataTable dt = lctn.getcountry();


            if (tbc_Main.SelectedTab == Branches)
            {
                cmb_brCountry.DataSource = dt;
                cmb_brCountry.DisplayMember = "CountryName";
            }
            else
            {
                cmb_ltCountry.DataSource = dt;
                cmb_ltCountry.DisplayMember = "CountryName";
            }

        }



        /// <summary>
        /// 
        /// validates the control
        /// </summary>
        /// <returns></returns>
        public Boolean validationcontrols()
        {
            Boolean sucess = false;
            if (tbc_Main.SelectedTab == Branches)
            {
                if (cmb_brheadecompany.Text.Trim() == null || cmb_brheadecompany.Text.Trim() == "")
                {

                    lblStatus.Text = "Select a Valid Head Company";
                    cmb_brheadecompany.Focus();
                    lbl_Companyname.Visible = true;

                }
                else if (txt_brBranchName.Text.Trim() == null || txt_brBranchName.Text.Trim() == "")
                {

                    lblStatus.Text = "Select a Valid Head Company";
                    txt_brBranchName.Focus();
                    lbl_CompanyCode.Visible = true;

                }

                else
                {
                    sucess = true;
                }

            }
            else if (tbc_Main.SelectedTab == LocationTab)
            {

                if (cmb_ltBranchName.Text.Trim() == null || cmb_ltBranchName.Text.Trim() == "")
                {

                    lblStatus.Text = "Select a Valid Branch";
                    cmb_ltBranchName.Focus();
                    lbl_Companyname.Visible = true;

                }
                else if (txt_locationName.Text.Trim() == null || txt_locationName.Text.Trim() == "")
                {

                    lblStatus.Text = "  Enter a  Valid Location";
                    txt_locationName.Focus();
                    lbl_CompanyCode.Visible = true;

                }

                else
                {
                    sucess = true;
                }

            }






            return sucess;
        }

        /// <summary>
        /// fetch dat from the controls for updation or insertion
        /// </summary>
        public void fetchdata()
        {
            if (validationcontrols())
            {
                if (tbc_Main.SelectedTab == Branches)
                {

                    branchdatabean = new Datalayer.BranchDataBean();
                    branchdatabean.Companypk = int.Parse(cmb_brheadecompany.SelectedValue.ToString());
                    branchdatabean.BranchName = txt_brBranchName.Text;
                    branchdatabean.Lctnpk = int.Parse(cmb_brcity.SelectedValue.ToString());
                    branchdatabean.Email = txt_brEmail.Text;
                    branchdatabean.Phoneno = txt_brPhoneno.Text;
                    branchdatabean.Zipcode = txt_brZipCode.Text;
                    branchdatabean.Faxno = txt_brfaxno.Text;
                    branchdatabean.Adress1 = "XXXXX";
                    branchdatabean.Adress2 = "XXXXX";
                }
                else
                {
                    lctnbrdatabean = new Datalayer.locationBranchDatabean();
                    lctnbrdatabean.Branchpk = int.Parse(cmb_ltBranchName.SelectedValue.ToString());
                    lctnbrdatabean.Branchname = txt_locationName.Text;
                    lctnbrdatabean.Phoneno = txt_ltPhoneno.Text;
                    lctnbrdatabean.Zipcode = txt_ltZipcode.Text;
                    lctnbrdatabean.Adress1 = rht_ltAdress1.Text;
                    lctnbrdatabean.Adress2 = rht_ltAdress2.Text;
                    lctnbrdatabean.Lctnpk = int.Parse(cmb_ltCity.SelectedValue.ToString());
                    lctnbrdatabean.Email = txt_ltEmail.Text;
                    lctnbrdatabean.Faxno = txt_ltfax.Text;
                    String locationcode = cmb_brheadecompany.Text.Substring(0, 3) + "-" + txt_locationName.Text.Substring(0, 3);
                    lctnbrdatabean.Llocationcode = locationcode;

                }
            }
        }
        public void fetchdataforUpdate()
        {
            if (validationcontrols())
            {
                if (tbc_Main.SelectedTab == Branches)
                {

                    branchdatabean = new Datalayer.BranchDataBean();
                    branchdatabean.Companypk = int.Parse(lbl_cmpanyPK.Text);
                    branchdatabean.Branchpk = int.Parse(lbl_branchpk.Text);
                    branchdatabean.BranchName = txt_brBranchName.Text;
                    branchdatabean.Lctnpk = int.Parse(lbl_locationpk.Text);
                    branchdatabean.Email = txt_brEmail.Text;
                    branchdatabean.Phoneno = txt_brPhoneno.Text;
                    branchdatabean.Zipcode = txt_brZipCode.Text;
                    branchdatabean.Faxno = txt_brfaxno.Text;
                    branchdatabean.Adress1 = "XXXXX";
                    branchdatabean.Adress2 = "XXXXX";
                }
                else
                {

                    lctnbrdatabean = new Datalayer.locationBranchDatabean();
                    lctnbrdatabean.Branchpk = int.Parse(lbl_ltbranchPk.Text);
                    lctnbrdatabean.Branchname = txt_locationName.Text;
                    lctnbrdatabean.Phoneno = txt_ltPhoneno.Text;
                    lctnbrdatabean.Zipcode = txt_ltZipcode.Text;
                    lctnbrdatabean.Adress1 = rht_ltAdress1.Text;
                    lctnbrdatabean.Adress2 = rht_ltAdress2.Text;
                    lctnbrdatabean.Lctnpk = int.Parse(lbl_ltlctnPk.Text);
                    lctnbrdatabean.Email = txt_ltEmail.Text;
                    lctnbrdatabean.Faxno = txt_ltfax.Text;
                    //    String locationcode = cmb_brheadecompany.Text.Substring(0, 2) + "-" + txt_locationName.Text.Substring(0, 2);
                    //    lctnbrdatabean.Llocationcode = locationcode;
                    lctnbrdatabean.Locationpk = int.Parse(lbl_ltLocationPk.Text);

                }
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

            if (tbc_Main.SelectedTab == Branches)
            {
                if (txt_brnewcountry.Text == null || txt_brnewcountry.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter Valid  Country Name";
                    txt_brnewcountry.Focus();

                }
                else if (txt_brNewState.Text == null || txt_brNewState.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter Valid State  Name";
                    txt_brNewState.Focus();

                }
                else if (txt_brNewCity.Text == null || txt_brNewCity.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter Valid City ";
                    txt_brNewCity.Focus();

                }
                else
                {
                    sucess = true;

                }

                return sucess;

            }
            else if (tbc_Main.SelectedTab == LocationTab)
            {




                if (txt_ltNewcountry.Text == null || txt_ltNewcountry.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter Valid  Country Name";
                    txt_ltNewcountry.Focus();

                }
                else if (txt_ltNewstate.Text == null || txt_ltNewstate.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter Valid State  Name";
                    txt_ltNewstate.Focus();

                }
                else if (txt_ltNewcity.Text == null || txt_ltNewcity.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter Valid City ";
                    txt_ltNewcity.Focus();

                }
                else
                {
                    sucess = true;

                }

                return sucess;




            }
            else
            {
                return sucess;
            }
        }

        public void basicloaditems()
        {

            if (tbc_Main.SelectedTab == Branches)
            {
                companyListLoad();

            }
            else
            {
                branchListLoad();

            }
            countrylistload();
        }


        public void Locationtabactions()
        {
            if (this.Text == "Location Details")
            {

                if (btn_Save.Text == "Edit")
                {
                    btn_Save.Text = "Update";
                    pnl_location.Enabled = true; ;
                }
                else if (btn_Save.Text == "Update")
                {
                    fetchdataforUpdate();
                    if (lctnbrdatabean != null)
                    {
                        cmptransaction.updateBranchLocationDertails(lctnbrdatabean);
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Branch Location  Updated ");
                        clearcontrols();
                        closecontrols();
                    }

                }


            }
            else
            {
                if (validationcontrols())
                {
                    fetchdata();
                    if (lctnbrdatabean != null)
                    {
                        cmptransaction.insertBranchLocationDertails(lctnbrdatabean);
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Branch Location  Added ");
                        clearcontrols();
                        closecontrols();
                    }
                }

            }
        }

        private void cmb_brCountry_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = lctn.getstatebycountry(cmb_brCountry.Text);
            cmb_brState.DataSource = dt;
            cmb_brState.DisplayMember = "StateName";
        }

        private void cmb_brState_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = lctn.getcitybycountry(cmb_brCountry.Text, cmb_brState.Text);
            cmb_brcity.DataSource = dt;
            cmb_brcity.DisplayMember = "CitName";
            cmb_brcity.ValueMember = "LocationPk";
        }

        private void cmb_ltCountry_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            DataTable dt = lctn.getstatebycountry(cmb_ltCountry.Text);
            cmb_ltState.DataSource = dt;
            cmb_ltState.DisplayMember = "StateName";
        }

        private void cmb_ltState_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = lctn.getcitybycountry(cmb_ltCountry.Text, cmb_ltState.Text);
            cmb_ltCity.DataSource = dt;
            cmb_ltCity.DisplayMember = "CitName";
            cmb_ltCity.ValueMember = "LocationPk";
        }


        public void closecontrols()
        {
            this.Close();
            Master.BranchMasterForm branchmasterform = new Master.BranchMasterForm();
            branchmasterform.MdiParent = this.MdiParent;
            branchmasterform.Show();
        }

        private void btn_brNewCity_Click_1(object sender, EventArgs e)
        {
            if (btn_brNewCity.Text == "Save")
            {
                if (subvalidatelocation())
                {
                    lctn.insertlocation(txt_brnewcountry.Text, txt_brNewState.Text, txt_brNewCity.Text);
                //    clearcontrols();
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Location  Added");
                    countrylistload();
                }


            }

            else
            {
                txt_brNewCity.Visible = true;
                btn_brNewCity.Text = "Save";

                txt_brNewState.Text = cmb_brState.Text;
                txt_brnewcountry.Text = cmb_brCountry.Text;
                txt_brNewState.Visible = false;
                txt_brnewcountry.Visible = false;
                btn_brNewState.Enabled = false;
                btn_brNewCountry.Enabled = false;
            }

        }

        private void btn_brNewState_Click(object sender, EventArgs e)
        {
      
            txt_brNewState.Visible = true;
            btn_brNewState.Text = "Save";
            txt_brNewCity.Visible = true;
            btn_brNewCity.Text = "Save";
            txt_brnewcountry.Text = cmb_brCountry.Text;
            btn_brNewCity.Enabled = true;
            btn_brNewCountry.Enabled = false;
            btn_brNewState.Enabled = false;
       

        }

        private void btn_brNewCountry_Click_1(object sender, EventArgs e)
        {
           


            txt_brnewcountry.Visible = true;
            btn_brNewCountry.Text = "Save";
            txt_brNewCity.Visible = true;
            btn_brNewCity.Text = "Save";
            txt_brNewState.Visible = true;
            btn_brNewState.Text = "Save";
            btn_brNewState.Enabled = false;
            btn_brNewCountry.Enabled = false;






        }

        private void btn_ltnewcountry_Click_1(object sender, EventArgs e)
        {
            txt_ltNewcity.Visible = true;
            btn_ltnewcity.Text = "Save";
            txt_ltNewcountry.Visible = true;
            btn_ltnewcountry.Text = "Save";
            txt_ltNewstate.Visible = true;
            btn_ltnewstate.Text = "Save";
            btn_ltnewcountry.Enabled = false;
            btn_ltnewstate.Enabled = false;
            btn_ltnewcity.Enabled = true;
        }

        private void btn_ltnewstate_Click_1(object sender, EventArgs e)
        {
            txt_ltNewcountry.Text = cmb_ltCountry.Text;
            txt_ltNewstate.Visible = true;
            txt_ltNewcity.Visible = true;
            btn_ltnewcity.Enabled = true;
            btn_ltnewcity.Text = "Save";
            btn_ltnewcountry.Enabled = false;
            btn_ltnewcity.Enabled = true;
        }

        private void btn_ltnewcity_Click_1(object sender, EventArgs e)
        {

            if (btn_ltnewcity.Text == "Save")
            {
                if (subvalidatelocation())
                {
                    lctn.insertlocation(txt_ltNewcountry.Text, txt_ltNewstate.Text, txt_ltNewcity.Text);
                 //   clearcontrols();
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Location  Added");
                    countrylistload();

                }


            }

            else
            {
                txt_ltNewcity.Visible = true;
                btn_ltnewcity.Text = "Save";
                txt_ltNewcountry.Text = cmb_ltCountry.Text; ;
                txt_ltNewstate.Text = cmb_ltState.Text;
                btn_ltnewcity.Text = "Save";
                btn_ltnewcountry.Enabled = false;
                btn_ltnewstate.Enabled = false;

                txt_ltNewstate.Visible = false;
                txt_ltNewcountry.Visible = false;
            }
        }

        private void cmb_ltBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BranchesMasterForm_Load(object sender, EventArgs e)
        {

        }


    }
}

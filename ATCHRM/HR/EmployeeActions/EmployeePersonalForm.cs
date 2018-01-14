using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master.NewFolder1
{
    public partial class EmployeePersonalForm : Form
    {
        Datalayer.EmployeePersonaldatabean empdb = null;
        Transactions.RecruitApplicationTransaction rcrtappltransaction = null;
        Transactions.Locationtransaction lctn = null;
        Transactions.EmployeeRegTransaction reg = null;
        DataTable dt = null;
        int clickcomboflag = 0;
        public EmployeePersonalForm()
        {

            InitializeComponent();
            rcrtappltransaction = new Transactions.RecruitApplicationTransaction();
            lctn = new Transactions.Locationtransaction();
         countrylistload();
          recruitmentCodeLoad();

            cmb_Recruitmentcode.SelectedIndex = -1;
        }


        public EmployeePersonalForm(String EditCode)
        {

            InitializeComponent();
            rcrtappltransaction = new Transactions.RecruitApplicationTransaction();
            lctn = new Transactions.Locationtransaction();
            countrylistload();
           

           
        }
     


        
        
        string emp_code = "";
        private int  Save_Data()
        {
            int emppk = 0;
            try
            {
               if(validationcontrol ()){

                reg = new Transactions.EmployeeRegTransaction();
                empdb = new Datalayer.EmployeePersonaldatabean();

               
                empdb.Nationality = comboNation.Text;
                empdb.Nid = textNid.Text;
                empdb.PPnum1 = textpp.Text;
                empdb.Gender = comboGender.Text;
                empdb.Status = combostatus.Text;
                empdb.Firstname = textfname.Text;
                empdb.Lastname = textlname.Text;
                empdb.Adress1 = richTextaddr1.Text;
                empdb.Adress2 = richTextaddr2.Text;

                empdb.LctnPk = Convert.ToInt32(cmb_City.SelectedValue);
                empdb.Telphone = textcontel.Text;
                empdb.Mobile = textconmob.Text;
                empdb.Email = textconemail.Text;
                empdb.Refname = textrefname.Text;
                empdb.Refdetails = richTextrefdetails.Text;
                empdb.Refmobile = textrefmob.Text;
                empdb.Refemail = textrefmail.Text;
                empdb.Beneficaryname = textkinnme.Text;
                empdb.Benificiaryrelation = combokinrel.Text;
                empdb.Beneficiarymobile = textkinmob.Text;
                empdb.Beneficiaryemail = textkinmail.Text;
                empdb.Oldempid1 = txt_oldid.Text;
                empdb.RecId = int.Parse(cmb_Recruitmentcode.SelectedValue.ToString());
                emp_code = reg.Emp_id();
                empdb.Empcode = reg.Emp_id();
                emppk = reg.insertEmpPersonalDetails(empdb);
                reg.AssignRecruitmentcode(int.Parse(cmb_Recruitmentcode.SelectedValue.ToString()));

               }
               
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
            return emppk;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
         int empid=   Save_Data();
         if (empid != 0)
         {
             MessageBox.Show("Employee " + emp_code + " Registered", "ATCHRM");
             NewFolder1.ContractForm cntrctfrm = new ContractForm(empid, int.Parse(cmb_Recruitmentcode.SelectedValue.ToString()));
             cntrctfrm.Show();
             this.Close();
         }
         else
         {
             MessageBox.Show("Employee Not  Registered error in system", "ATCHRM");   
         }
        }


        private void btn_AddCountry_Click(object sender, EventArgs e)
        {
            Master.LocationMasterForm lctnmasterform = new LocationMasterForm("Country");
            lctnmasterform.Show();
            countrylistload();

        }

        private void btn_AddState_Click(object sender, EventArgs e)
        {
            Master.LocationMasterForm lctnmasterform = new LocationMasterForm("State");
            lctnmasterform.Show();
            countrylistload();
        }

        private void btn_AddCity_Click(object sender, EventArgs e)
        {
            Master.LocationMasterForm lctnmasterform = new LocationMasterForm("City");
            lctnmasterform.Show();
            countrylistload();
        }

        private void EmployeePersonalForm_Load(object sender, EventArgs e)
        {
            groupIndividaul.Enabled = false;
            groupContact.Enabled = false;

        }

        /// <summary>
        /// load all the basic controls in the form 
        /// specially the comboboxes
        /// </summary>
        public void basicControlLoads()
        {


        }
        /// <summary>
        /// loads the recruit ment codes that are not used by others or that is assigned n
        /// now to somebody for editing
        /// </summary>
        public void recruitmentCodeLoad()
        {
            DataTable recruittable = new DataTable();
            recruittable = rcrtappltransaction.getAllRecruitmentCode();
            cmb_Recruitmentcode.DataSource = recruittable;

            cmb_Recruitmentcode.DisplayMember = "EmpInternalCode";
            cmb_Recruitmentcode.ValueMember = "RecruitmentCodePK";
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

        private void cmb_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = lctn.getcitybycountry(cmb_Country.Text, cmb_State.Text);
            cmb_City.DataSource = dt;
            cmb_City.DisplayMember = "CitName";
            cmb_City.ValueMember = "LocationPk";
        }

        private void cmb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = lctn.getstatebycountry(cmb_Country.Text);
            cmb_State.DataSource = dt;
            cmb_State.DisplayMember = "StateName";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Applications.RecruitmentCodeForm rctcodefrm = new Applications.RecruitmentCodeForm();
            rctcodefrm.MdiParent = this.MdiParent;
            rctcodefrm.Show();
            //NewFolder1.ContractForm cntrctfrm = new ContractForm();
            //cntrctfrm.Show();
            //this.Close();

        }

        private void cmb_Recruitmentcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Recruitmentcode.SelectedIndex != -1)
            {
                if(clickcomboflag==1){



                    DialogResult dialogResult = MessageBox.Show("Confirm  RecruitmentCode " + cmb_Recruitmentcode.Text + " Process", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        reg = new Transactions.EmployeeRegTransaction();
                        reg.UsingRecruitmentcode(int.Parse (cmb_Recruitmentcode.SelectedValue.ToString () ));


                        groupContact.Enabled = true;
                        groupIndividaul.Enabled = true;
                        //do something
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }

                }

               
            }

        }

        private void groupBox2_Leave(object sender, EventArgs e)
        {
           if (textNidConfrm.Text != textNid.Text)
            {
                groupContact.Enabled = false;
                comboGender.Enabled = false;
                textpp.Enabled = false;
                combostatus.Enabled = false;
                textfname.Enabled = false;
                textlname.Enabled = false;
                richTextaddr1.Enabled = false;
                richTextaddr2.Enabled = false;
                textNidConfrm.Focus();
                label29.Visible = true;
                // ATCHRM.Controls.ATCHRMMessagebox.Show("Pls Check The NID");
            }
            else if (textNidConfrm.Text == textNid.Text)
            {
                label29.Visible = false;
                //Here We can write the code to check weather the NID is existing or not
                groupContact.Enabled = true;
                comboGender.Enabled = true;
                textpp.Enabled = true;
                combostatus.Enabled = true;
                textfname.Enabled = true;
                textlname.Enabled = true;
                richTextaddr1.Enabled = true;
                richTextaddr2.Enabled = true;
                groupBox2.Visible = false;
                textNid.ReadOnly = true;
                prevoioustrack();
                textpp.Focus();
               
            }
        }

        private void textNid_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void textNid_Leave(object sender, EventArgs e)
        {
            if (textNid.Text == "")
            {
                lbl_Companyname.Visible = true;
                groupContact.Enabled = false;
                comboGender.Enabled = false;
                textpp.Enabled = false;
                combostatus.Enabled = false;
                textfname.Enabled = false;
                textlname.Enabled = false;
                richTextaddr1.Enabled = false;
                richTextaddr2.Enabled = false;
                textNid.Focus();
            }
            else
            {
                groupBox2.Visible = true;
                textNidConfrm.Focus();
                lbl_Companyname.Visible = false;
                groupContact.Enabled = true;
                comboGender.Enabled = true;
                textpp.Enabled = true;
                combostatus.Enabled = true;
                textfname.Enabled = true;
                textlname.Enabled = true;
                richTextaddr1.Enabled = true;
                richTextaddr2.Enabled = true;

            }
        }

        private void comboNation_Leave(object sender, EventArgs e)
        {
            if (comboNation.SelectedIndex == -1)
            {
                label27.Visible = true;
                // ATCHRM.Controls.ATCHRMMessagebox.Show("Pls Choose Nationality");
                groupContact.Enabled = false;
                comboGender.Enabled = false;
                textpp.Enabled = false;
                combostatus.Enabled = false;
                textfname.Enabled = false;
                textlname.Enabled = false;
                richTextaddr1.Enabled = false;
                richTextaddr2.Enabled = false;
                textNid.Enabled = false;
                comboNation.Focus();
            }
            else
            {
                label27.Visible = false;
                groupContact.Enabled = true;
                comboGender.Enabled = true;
                textpp.Enabled = true;
                combostatus.Enabled = true;
                textfname.Enabled = true;
                textlname.Enabled = true;
                richTextaddr1.Enabled = true;
                richTextaddr2.Enabled = true;
                groupBox2.Visible = false;
                textNid.Enabled = true;
            }
        }

        private void comboNation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboNation.SelectedIndex != -1)
            {
                label27.Visible = false;
                groupContact.Enabled = true;
                comboGender.Enabled = true;
                textpp.Enabled = true;
                combostatus.Enabled = true;
                textfname.Enabled = true;
                textlname.Enabled = true;
                richTextaddr1.Enabled = true;
                richTextaddr2.Enabled = true;
                groupBox2.Visible = false;
                textNid.Enabled = true;



                if (comboNation.Text != "Kenya")
                {
                    textNid.Text = "expat";
                    textNidConfrm.Text ="expat";
                    textpp.Focus();
                }
            }
        }

        private void comboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboGender.SelectedIndex == -1)
            {
                label28.Visible = true;
            }
            else
            {
                label28.Visible = false;
            }
        }

        private void textfname_Leave(object sender, EventArgs e)
        {
            if (textfname.Text == "")
            {
                label25.Visible = true;
                textlname.Enabled = false;
                richTextaddr1.Enabled = false;
                richTextaddr2.Enabled = false;
                groupContact.Enabled = false;
            }
            else
            {
                label25.Visible = false;
                textlname.Enabled = true;
                richTextaddr1.Enabled = true;
                richTextaddr2.Enabled = true;
                groupContact.Enabled = true;
            }
        }
        private void textlname_Leave(object sender, EventArgs e)
        {
            if (textlname.Text == "")
            {
                btn_submmit .Enabled = false;
                label30.Visible = true;
                richTextaddr1.Enabled = false;
                richTextaddr2.Enabled = false;
                groupContact.Enabled = false;
            }
            else
            {
                btn_submmit.Enabled = true;
                label30.Visible = false;
                richTextaddr1.Enabled = true;
                richTextaddr2.Enabled = true;
                groupContact.Enabled = true;
            }
        }

        private void comboGender_Leave(object sender, EventArgs e)
        {
            if (comboGender.SelectedIndex == -1)
            {
                label28.Visible = true;
                combostatus.Enabled = false;
                textfname.Enabled = false;
                textlname.Enabled = false;
                richTextaddr1.Enabled = false;
                richTextaddr2.Enabled = false;
                groupContact.Enabled = false;
            }
            else
            {
                label28.Visible = false;
                combostatus.Enabled = true;
                textfname.Enabled = true;
                textlname.Enabled = true;
                richTextaddr1.Enabled = true;
                richTextaddr2.Enabled = true;
                groupContact.Enabled = true;
            }
        }

        private void cmb_Recruitmentcode_MouseClick(object sender, MouseEventArgs e)
        {
            clickcomboflag = 1;
        }

    









        public Boolean validationcontrol()
        {

            Boolean sucess = false;

            if (comboNation.Text == null || comboNation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Country";
                comboNation.Focus();
                comboNation.Visible = true;
            }
            else if (textpp.Text == "" && textNid.Text.Trim() == "")
            {
                lblStatus.Text = "Enter  ID";
                textNid.Focus();
                textNid.Visible = true;
            }

            else if (comboGender.Text == null || comboGender.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Gender";
                comboGender.Focus();
                comboGender.Visible = true;
            }

            else if (combostatus.Text == null || combostatus.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Status";
                combostatus.Focus();
                combostatus.Visible = true;
            }
            else if (textfname.Text == null || textfname.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the First Name";
                textfname.Focus();
                textfname.Visible = true;
            }
            else if (richTextaddr1.Text == null || richTextaddr1.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Address1";
                richTextrefdetails.Focus();
                richTextrefdetails.Visible = true;
            }
            else if (txt_oldid.Text == null || txt_oldid.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Old Empid  ";
                txt_oldid.Focus();
                txt_oldid.Visible = true;
            }

            else
            {
                sucess = true;
            }

            return sucess;

        }

        public  void prevoioustrack()
        {
            DataTable  dt = new DataTable();
            dt = reg.isEmployeePresent(textNidConfrm .Text);

            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("This NID Have " + dt.Rows.Count + "   Previous Track Records Confirm Whether to Continue with Registration ", "Attention ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        reg.releaseRecruitmentcode(int.Parse(cmb_Recruitmentcode.SelectedValue.ToString()));
                        this.Close();
                    }
                }
            }
        }

        private void cmb_City_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_oldid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textlname_TextChanged(object sender, EventArgs e)
        {

        }

        private void combostatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupIndividaul_Enter(object sender, EventArgs e)
        {




































































































































































































        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_submmit_Click(object sender, EventArgs e)
        {
            int empid = Save_Data();
            if (empid != 0)
            {
                MessageBox.Show("Employee " + emp_code + " Registered", "ATCHRM");
                NewFolder1.ContractForm cntrctfrm = new ContractForm(empid, int.Parse(cmb_Recruitmentcode.SelectedValue.ToString()));
                cntrctfrm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Employee Not  Registered error in system", "ATCHRM");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void textNidConfrm_TextChanged(object sender, EventArgs e)
        {

        }

       

    }

}

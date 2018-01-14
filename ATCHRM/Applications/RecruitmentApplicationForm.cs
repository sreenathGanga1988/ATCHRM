using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class RecruitmentApplicationForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;

        Transactions.DepartmentTransaction dpttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Datalayer.RecruitAppDatabean rcrtappdatabean = null;
        Transactions.RecruitApplicationTransaction rcrtappltransaction = null;
        Transactions.Helper HLPR = null;
        public RecruitmentApplicationForm()
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dpttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            rcrtappltransaction = new Transactions.RecruitApplicationTransaction();
            HLPR = new Transactions.Helper();
        }



        public void codegenerator(){
        }

        /// <summary>
        /// get aal brach location
        /// </summary>
        public void companyListLoad()
        {
            DataTable dt = cmptransaction.selectallcompanydata();

            cmb_Company .DisplayMember = "NAME";
            cmb_Company.ValueMember = "SL";
            cmb_Company.DataSource = dt;
           
        }
        /// <summary>
        ///will get all thew department from the database and will 
        ///display it in combobox
        /// </summary>
        public void getallDeparment()
        {
            DataTable dt = dpttrans.getDeptName();
           
            cmp_dept.DisplayMember = "DepartmentName";
            cmp_dept.ValueMember = "DepartmentPK";
            cmp_dept.DataSource = dt;
        }
        public void getallDesignation()
        {
            if (cmp_dept.SelectedValue !=null)
            {


                cmb_designation.DataSource = null;
            DataTable  dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmp_dept.SelectedValue.ToString()));

            cmb_designation.DisplayMember = "DESGN";
            cmb_designation.ValueMember = "SL";
            cmb_designation.DataSource = dt;
            }
        }
        private void RecruitmentApplicationForm_Load(object sender, EventArgs e)
        {
            companyListLoad();
            getallDeparment();
        }

        private void cmb_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Location.DataSource = null;
            DataTable dt = cmptransaction.getBranchLocationDetails(int.Parse(cmb_Company.SelectedValue.ToString()));
            cmb_Location.DataSource = dt;
            cmb_Location.DisplayMember = "LOCATION";
            cmb_Location.ValueMember = "SL";
            cmb_Location.SelectedValue  = Program.LOCTNPK;
        }

        private void cmp_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
        }


        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (cmb_Company.Text == null || cmb_Company.Text == "")
            {


                lblStatus.Text = "Enter the Company Name";
                cmb_Company.Focus();

            }

            else if (cmb_Location.Text == null || cmb_Location.Text == "")
            {


                lblStatus.Text = "Enter the Location ";
                cmb_Location.Focus();
            }
            else if (cmp_dept.Text == null || cmp_dept.Text == "")
            {


                lblStatus.Text = "Enter the Department ";
                cmp_dept.Focus();
            }
            else if (cmb_designation.Text == null || cmb_designation.Text == "")
            {


                lblStatus.Text = "Enter the Designation Name";
                cmb_designation.Focus();
            }

            else if (txt_vaccancyNum.Text == null || txt_vaccancyNum.Text == "")
            {


                lblStatus.Text = "Enter the Number of Vaccancies";
                txt_vaccancyNum.Focus();
               
            }
            else if (cmb_Contract.Text == null || cmb_Contract.Text == "")
            {


                lblStatus.Text = "Enter the Amount ";
                cmb_Contract.Focus();
              
            }

          


            else
            {
                sucess = true;
            }


            return sucess;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
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

      

      

        private void txt_vaccancyNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_vaccancyNum.Text);
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Salary";
                txt_vaccancyNum.Text = "0";
            }
        }

        private void txt_vaccancyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Salary";
                txt_vaccancyNum.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }
    
    
    
    public void clearcontrols()
    {
        txt_interviewedPerson.Text = "";
        txt_vaccancyNum.Text = "0";
        rht_descriptiom.Text = "";
        cmb_Company.Text = "";
        cmb_Contract.Text = "";
        companyListLoad();
        getallDeparment();
        dtp_joiningDate.Value = DateTime.Now;
    }

    private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void btn_submitt_Click(object sender, EventArgs e)
    {
        try
        {
            if (validationcontrol())
            {
                rcrtappdatabean = new Datalayer.RecruitAppDatabean();
                rcrtappdatabean.BranchLocationpk = int.Parse(cmb_Location.SelectedValue.ToString());
                rcrtappdatabean.Designationpk = int.Parse(cmb_designation.SelectedValue.ToString());
                rcrtappdatabean.Vaccancynum = int.Parse(txt_vaccancyNum.Text);
                rcrtappdatabean.Contracttype = cmb_Contract.Text;
                if (rbt_isinterviewed.Checked == true)
                {
                    rcrtappdatabean.Isinterviewed = 1;
                }
                else if (rbt_notinterviewed.Checked == true)
                {
                    rcrtappdatabean.Isinterviewed = 0;
                }

                rcrtappdatabean.Interviewer = txt_interviewedPerson.Text;
                rcrtappdatabean.Joiningdate = dtp_joiningDate.Value;
                rcrtappdatabean.Description1 = rht_descriptiom.Text;
                rcrtappdatabean.Iscompleted = "W";
                String Aplicattionnum = rcrtappltransaction.insertRecruitApplication(rcrtappdatabean);
                //   rcrtappltransaction.insertRecruit(rcrtappdatabean);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Your Application has been Submitted " + Environment.NewLine + "Application Num :" + Aplicattionnum.ToString());
                //    ATCHRM.Controls.ATCHRMMessagebox.Show("Sucess");
                HLPR.ClearFormControls(this);
                //Applications.RecruitmentApplicationMasterForm RCRTMSTRFRM = new RecruitmentApplicationMasterForm();
                //this.Close();
                //RCRTMSTRFRM.MdiParent = this.MdiParent;
                //RCRTMSTRFRM.Show();
            }
        }
        catch (Exception exp)
        {
            ErrorLogger er = new ErrorLogger();
            er.createErrorLog(exp);
    //         ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
            this.Dispose();
        }
    }

    private void btn_cancell_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    

    
    
    }
}

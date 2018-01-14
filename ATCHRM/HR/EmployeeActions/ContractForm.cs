using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master.NewFolder1
{
    public partial class ContractForm : Form
    {
        Transactions.EmployeeRegTransaction empreg= null;
        Datalayer.EmployeeContractDatabean empcontrctdatbean = null;
        Transactions.AnualContractrenewal annulcntrct = null;
      //  int shiftflag = 0;
        int changeappid = 0;
        String Applicationtype = "Add";
        public ContractForm()
        {
            InitializeComponent();
           
            empreg= new Transactions.EmployeeRegTransaction ();
           // getemployeeDetail( empid , recid);
            employecodeload(Program.LOCTNPK , 0, 0);
            annulcntrct = new Transactions.AnualContractrenewal();

        }
       /// <summary>
       /// this construct loads during employee creation
       /// </summary>
       /// <param name="empid"></param>
       /// <param name="recid"></param>
        public ContractForm(int empid ,int recid)
        {
            InitializeComponent();
              empreg= new Transactions.EmployeeRegTransaction ();
            getemployeeDetail(empid, recid);
            annulcntrct = new Transactions.AnualContractrenewal();
        }
        /// <summary>
        /// loads with the entry is throug edit Application
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="applicationid"></param>
        /// <param name="recid"></param>
        /// <param name="Applicationtype123"></param>
        public ContractForm(int empid ,int applicationid ,int recid ,String Applicationtype123 )
        {
            
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            annulcntrct = new Transactions.AnualContractrenewal();
            Applicationtype = Applicationtype123;
            changeappid = applicationid;
            getemployeeDetail(empid, 0);
            btn_submmit.Text ="Edit";
            grp_contract.Enabled = false;

        }

/// <summary>
/// get the employee conmtracrt details
/// if its first time for an employee means if it
/// comes with a recruitment id then the details are fetched from the 
/// recruitment master 
/// else if it is from the  Application for editing the employe id then the 
/// details is fetched from the employee contract table
/// </summary>
/// <param name="empid"></param>
/// <param name="recid"></param>
        public void getemployeeDetail(int empid ,int recid)
        {
            try
            {
                if (recid == 0)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = empreg.getCurrentContractDetails(empid);
                    if (dt1 != null)
                    {
                        cmp_EmployeeCode.Text = dt1.Rows[0][1].ToString();
                        cmp_EmployeeCode.Enabled = false;
                        lbl_emppk.Text = dt1.Rows[0][0].ToString();
                        cmb_contracttype.Text = dt1.Rows[0][2].ToString();
                        dtp_fromdate.Value = DateTime.Parse(dt1.Rows[0][3].ToString());
                        dtp_todate.Value = DateTime.Parse(dt1.Rows[0][4].ToString());
                        dtp_extendabledate.Value = DateTime.Parse(dt1.Rows[0][5].ToString());
                        if (dt1.Rows[0][7] != null)
                        {
                            dtp_joiningdata.Value = DateTime.Parse(dt1.Rows[0][7].ToString());
                            dtp_joiningdata.Enabled = false;
                        }
                        else
                        {
                            dtp_joiningdata.Value = DateTime.Now.Date;

                        }
                    
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = empreg.getcontrctrecruitdetails(empid, recid);
                    if (dt != null)
                    {
                        cmp_EmployeeCode.Text = dt.Rows[0][1].ToString();
                        cmp_EmployeeCode.Enabled = false;
                        lbl_emppk.Text = dt.Rows[0][0].ToString();
                        cmb_contracttype.Text = dt.Rows[0][4].ToString();

                    }



                }

            }
            catch (Exception exp )
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

        }



        /// <summary>
        /// loads employe code
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmp_EmployeeCode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmp_EmployeeCode.DataSource = dt;
            cmp_EmployeeCode.DisplayMember = "empno";
            cmp_EmployeeCode.ValueMember = "empid";
        }




      
    /// <summary>
    /// validates the controls
    /// </summary>
    /// <returns></returns>
      public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (cmp_EmployeeCode .Text == null || cmp_EmployeeCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Leave Name ";
                cmp_EmployeeCode.Focus();


            }
            else if (cmb_contracttype.Text == null || cmb_contracttype.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Leave Calculation Type ";
                cmb_contracttype.Focus();
            }
           
            else
            {
                sucess = true;
            }
            return sucess;
        }
      

        private void btn_submmit_Click(object sender, EventArgs e)
        {


            empreg = new Transactions.EmployeeRegTransaction();


            // if it is sa add (means if it is the first time adding an contract to emnployee


            if(btn_submmit.Text.Trim()=="Submit")
            {
                empcontrctdatbean = new Datalayer.EmployeeContractDatabean();
                empcontrctdatbean.Empid = int.Parse(lbl_emppk.Text);
                empcontrctdatbean.Contractype = cmb_contracttype.Text;
                empcontrctdatbean.Startime = dtp_fromdate.Value.Date;
                empcontrctdatbean.Endtime = dtp_todate.Value.Date;
                empcontrctdatbean.Extendeddate = dtp_extendabledate.Value.Date;
                empcontrctdatbean.Actualjoinigdate = dtp_joiningdata.Value.Date;
                empreg.insertEmployeeContractdetails(empcontrctdatbean, Applicationtype);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

               annulcntrct.insertAnnualContractforexistingEmployee(empcontrctdatbean.Empid);
              //  NewFolder1.PositionForm pstnform = new PositionForm(int.Parse(lbl_emppk.Text));
              //  pstnform.Show();
              //  this.Close();
            }
            else if(btn_submmit.Text == "Edit")
            {
                btn_submmit.Text = "Update";

                grp_contract .Enabled = true;
            }
            else if (btn_submmit.Text == "Update")
            {
                empcontrctdatbean = new Datalayer.EmployeeContractDatabean();
                empcontrctdatbean.Empid = int.Parse(lbl_emppk.Text);
                empcontrctdatbean.Contractype = cmb_contracttype.Text;
                empcontrctdatbean.Startime = dtp_fromdate.Value.Date;
                empcontrctdatbean.Endtime = dtp_todate.Value.Date;
                empcontrctdatbean.Extendeddate = dtp_extendabledate.Value.Date;
                empcontrctdatbean.ContractchangeAppid1 = changeappid;
                empcontrctdatbean.Actualjoinigdate = dtp_joiningdata.Value.Date;
                empreg.insertEmployeeContractdetails(empcontrctdatbean ,Applicationtype );
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                annulcntrct.insertAnnualContractforexistingEmployee(int.Parse(lbl_emppk.Text));
                NewFolder1.PositionForm pstnform = new PositionForm(int.Parse(lbl_emppk.Text), Applicationtype, changeappid);
                pstnform.MdiParent = this.MdiParent;
                pstnform.Show();
                this.Close();
            }
           
        }

        private void grp_contract_Enter(object sender, EventArgs e)
        {

        }

        private void cmp_EmployeeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               lbl_emppk.Text = cmp_EmployeeCode  .SelectedValue.ToString();
            }
            catch (Exception)
            {
                
               
            }
        }

        private void cmb_contracttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dtp_fromdate_ValueChanged(object sender, EventArgs e)
        {
            dtp_joiningdata.Value = dtp_fromdate.Value;
        }







       
    
    
  
    }
}

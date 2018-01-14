using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR.NewFolder1
{
    public partial class ContractrenewalForm : Form
    {

        Transactions.EmployeeRegTransaction empreg = null;
        Datalayer.EmployeeContractDatabean empcontrctdatbean = null;
        Transactions.AnualContractrenewal annulcntrct = null;
        //  int shiftflag = 0;
        int changeappid = 0;
        String Applicationtype = "Add";

        public ContractrenewalForm()
        {
            InitializeComponent();
        }



         /// <summary>
        /// loads with the entry is throug edit Application
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="applicationid"></param>
        /// <param name="recid"></param>
        /// <param name="Applicationtype123"></param>
        public ContractrenewalForm(int empid, int applicationid, int recid, String Applicationtype123)
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
        public void getemployeeDetail(int empid, int recid)
        {
            try
            {
                if (Applicationtype == "Contract Change")
                {
                    DataTable dt1 = new DataTable();
                    dt1 = empreg.getApplicationContractdata(empid, changeappid);
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

        }







    }
}

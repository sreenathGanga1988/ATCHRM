using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace ATCHRM.Reports
{
    public partial class OtApplicationBriefForm : Form
    {
        Reports.Logonvalues lgvalues = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        String reporttype = "OTBrief";
        String reportname = "\\OtDepartmentalReport.rpt";
        public OtApplicationBriefForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lgvalues = new Logonvalues();
        }


        public OtApplicationBriefForm(String reporttypee)
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lgvalues = new Logonvalues();

            if(reporttypee=="OTSummary")
            {
                reportname = "\\OtSumaryReport.rpt";
                reporttype = reporttypee;
            }

        }


        /// <summary>
        /// loads the location 
        /// </summary>
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";

            cmb_location.SelectedValue = Program.LOCTNPK;
        }
        /// <summary>
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        /// <summary>
        /// get all the designation
        /// against a given dept
        /// </summary>
        public void getallDesignation()
        {

            if (deptchangeflag != 0)
            {


                if (cmb_dept.SelectedValue != null)
                {


                    cmb_designation.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_dept.SelectedValue.ToString()));

                    cmb_designation.DisplayMember = "DESGN";
                    cmb_designation.ValueMember = "SL";
                    cmb_designation.DataSource = dt;
                }

            }
        }

 

        /// <summary>
        ///restrict the acess to other loacation
        /// </summary>

        public void resrictacess()
        {
            try
            {
                if (lctnflg != 0)
                {
                    if (Program.UserType == "A" || Program.UserType == "M")
                    {

                    }
                    else
                    {

                        if (int.Parse(cmb_location.SelectedValue.ToString()) != Program.LOCTNPK)
                        {
                            ATCHRM.Controls.ATCHRMMessagebox.Show("You Are Not Allowed to Acess This Location Data");
                            cmb_location.SelectedValue = Program.LOCTNPK;
                        }



                    }
                }
            }
            catch (Exception)
            {


            }
        }





        public void loadbriefreport( int criteriaid)
        {

            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + reportname );
            
          //  cryrpt.RecordSelectionFormula = " {AdjusterMaster_tbl.AdjusterID}=" + adjsterid;

            if (criteriaid ==0)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}=CDate('" + dtp_otdate.Value.Date + "') and {OtApplicationDetails_tbl.Islevel2}='A' ";
            }

            else if (criteriaid == 1)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}=CDate('" + dtp_otdate.Value.Date + "') and {OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            else if (criteriaid == 2)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}=CDate('" + dtp_otdate.Value.Date + "') and {OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            else if (criteriaid == 3)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}=CDate('" + dtp_otdate.Value.Date + "') and {OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            if (criteriaid == 4)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();
           
        }


        public void loadsummaryreport(int criteriaid)
        {

            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + reportname);
            cryrpt.SetParameterValue("FromDate", dtp_otdate.Value.Date);
            //  cryrpt.RecordSelectionFormula = " {AdjusterMaster_tbl.AdjusterID}=" + adjsterid;

            if (criteriaid == 0)
            {
                cryrpt.RecordSelectionFormula = " {OtApplicationMaster_tbl.OTDate}={?FromDate}and{OtApplicationDetails_tbl.Islevel2}='A' and  {EmployeeDesignation_tbl.BranchLocationPK} ="+int.Parse (cmb_location.SelectedValue.ToString ())+" ";
            }

            else if (criteriaid == 1)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}=CDate('" + dtp_otdate.Value.Date + "') and {OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            else if (criteriaid == 2)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}=CDate('" + dtp_otdate.Value.Date + "') and {OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            else if (criteriaid == 3)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}=CDate('" + dtp_otdate.Value.Date + "') and {OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            if (criteriaid == 4)
            {
                cryrpt.RecordSelectionFormula = "{OtApplicationMaster_tbl.OTDate}={?FromDate}and{OtApplicationDetails_tbl.Islevel2}='A' ";
            }
            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();

        }




     



        private void OtApplicationBriefForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (reporttype == "OTSummary")
            {
                loadsummaryreport (1);
            }
            else
            {
                loadbriefreport (0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }





        public void selectioncriteriaforData(int criteriaID)
        {
            int branchlctnpk = 0;
            int deptpk = 0;
            int desigpk = 0;
            if (criteriaID == 1)
            {
                branchlctnpk = int.Parse(cmb_location.SelectedValue.ToString());
                deptpk = 0;
                desigpk = 0;
            }
            else if (criteriaID == 2)
            {
                branchlctnpk = int.Parse(cmb_location.SelectedValue.ToString());
                deptpk = int.Parse(cmb_dept.SelectedValue.ToString());
                desigpk = 0;
            }
            else if (criteriaID == 3)
            {
                branchlctnpk = int.Parse(cmb_location.SelectedValue.ToString());
                deptpk = int.Parse(cmb_dept.SelectedValue.ToString());
                desigpk = int.Parse(cmb_designation.SelectedValue.ToString());
            }



            //if (cmb_applicationType.Text == "OverTime Application")
            //{
            //    loadAppnum(branchlctnpk, deptpk, desigpk, "OverTime Application");
            //}
            //else if (cmb_applicationType.Text == "Leave Application")
            //{
            //    loadAppnum(branchlctnpk, deptpk, desigpk, "Leave Application");
            //}
            //else if (cmb_applicationType.Text == "Advance Application")
            //{
            //    loadAppnum(branchlctnpk, deptpk, desigpk, "Advance Application");
            //}
            //else if (cmb_applicationType.Text == "Gatepass Application")
            //{
            //    loadAppnum(branchlctnpk, deptpk, desigpk, "Gatepass Application");
            //}












        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadsummaryreport(4);
        }













    }
}

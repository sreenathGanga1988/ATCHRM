using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Reports
{
    public partial class ApplicationReportForm : Form
    {
        Reports.Logonvalues lgvalues = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.ApplicationTransaction apptrans = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;

        public ApplicationReportForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            apptrans = new Transactions.ApplicationTransaction();
            lgvalues = new Logonvalues();
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




        public void loadAppnum(int bvranchloctnpk, int deptpk, int Designpk, String applicationtype)
        {

            DataTable dt = apptrans.getallOtapplication(bvranchloctnpk, deptpk, Designpk, applicationtype);


            cmb_aaplicationnum.DisplayMember = "appNo";
            cmb_aaplicationnum.ValueMember = "Pk";
            cmb_aaplicationnum.DataSource = dt;
        }



        public void loadreport(String reportType, int selectionid)
        {
            if (reportType == "Leave Application")
            {
                Crvt_ApplicationReport.ReportSource = lgvalues.getpeport(Program.OurReportSource + "\\LeaveApplicationForm.rpt");



                Crvt_ApplicationReport.SelectionFormula = "{LeaveApplicationMaster.LeaveAppPk}=" + selectionid;

                Crvt_ApplicationReport.RefreshReport();
            }
            else if (reportType == "OverTime Apllication")
            {
                //Crvt_ApplicationReport.ReportSource = Program.OurReportSource +"OTApplication.rpt";
                Crvt_ApplicationReport.ReportSource = lgvalues.getpeport(Program.OurReportSource + "\\OTApplication.new.rpt");
                Crvt_ApplicationReport.SelectionFormula = "{OtApplicationMaster_tbl.OTAppPK}=" + selectionid;
                Crvt_ApplicationReport.RefreshReport();

            }
           
            else if (cmb_applicationType.Text == "Advance Application")
            {
                Crvt_ApplicationReport.ReportSource = lgvalues.getpeport(Program.OurReportSource + "\\advanceapplication.rpt");
                Crvt_ApplicationReport.SelectionFormula = "{AdvanceApplicationMaster_tbl.AdvanceAppPk} = " + selectionid;
                Crvt_ApplicationReport.RefreshReport();
            }
            else if (cmb_applicationType.Text == "Gatepass Application")
            {
                Crvt_ApplicationReport.ReportSource = lgvalues.getpeport(Program.OurReportSource + "\\gatepassnew.rpt");
                Crvt_ApplicationReport.SelectionFormula = "{GatePassMaster_tbl.GatePassId}=" + selectionid;
                Crvt_ApplicationReport.RefreshReport();
            }
        }
        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
        }



        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++; ;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;

        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
        }



        private void ApplicationReportForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }

        private void cmb_location_MouseClick_1(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }



        private void btn_printPreview_Click(object sender, EventArgs e)
        {

        }

        private void btn_printPreview_Click_1(object sender, EventArgs e)
        {
            if (cmb_aaplicationnum.Text != "")
            {
                try
                {
                    int apppk = int.Parse(cmb_aaplicationnum.SelectedValue.ToString());

                    if (cmb_applicationType.Text == "OverTime Application")
                    {
                        loadreport("OverTime Apllication", int.Parse(cmb_aaplicationnum.SelectedValue.ToString()));
                    }
                    else if (cmb_applicationType.Text == "Leave Application")
                    {
                        loadreport("Leave Application", int.Parse(cmb_aaplicationnum.SelectedValue.ToString()));
                    }
                    else if (cmb_applicationType.Text == "Advance Application")
                    {
                        loadreport("Advance Application", int.Parse(cmb_aaplicationnum.SelectedValue.ToString()));
                    }
                    else if (cmb_applicationType.Text == "Gatepass Application")
                    {
                        loadreport("Gatepass Application", int.Parse(cmb_aaplicationnum.SelectedValue.ToString()));
                    }
                }
                catch (Exception)
                {
                    MessageBoxDemo.frmShowMessage.Show("No Application Selected", "ATCHRM Error ", MessageBoxDemo.enumMessageIcon.Error, MessageBoxDemo.enumMessageButton.OK);

                }

            }
            else
            {
                MessageBoxDemo.frmShowMessage.Show("No Application Selected", "ATCHRM Error ", MessageBoxDemo.enumMessageIcon.Error, MessageBoxDemo.enumMessageButton.OK);

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectioncriteriaforData(1);
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectioncriteriaforData(2);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectioncriteriaforData(3);
           

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



            if (cmb_applicationType.Text == "OverTime Application")
            {
                loadAppnum(branchlctnpk, deptpk, desigpk, "OverTime Application");
            }
            else if (cmb_applicationType.Text == "Leave Application")
            {
                loadAppnum(branchlctnpk, deptpk, desigpk, "Leave Application");
            }
            else if (cmb_applicationType.Text == "Advance Application")
            {
                loadAppnum(branchlctnpk, deptpk, desigpk, "Advance Application");
            }
            else if (cmb_applicationType.Text == "Gatepass Application")
            {
                loadAppnum(branchlctnpk, deptpk, desigpk, "Gatepass Application");
            }












        }





    }
}

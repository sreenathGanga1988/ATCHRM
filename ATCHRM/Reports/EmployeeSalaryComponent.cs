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
    public partial class EmployeeSalaryComponent : Form
    {
        Reports.Logonvalues lgvalues = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        public EmployeeSalaryComponent()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
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





        public void loadreport()
        {

            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\EmployeeSalaryComponent.rpt");

            //  cryrpt.RecordSelectionFormula = " {AdjusterMaster_tbl.AdjusterID}=" + adjsterid;
            cryrpt.RecordSelectionFormula = "{EmployeePersonalMaster_tbl.Status}='A' and {EmployeeDesignation_tbl.BranchLocationPK}="+ int.Parse (cmb_location.SelectedValue .ToString  ());

            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadreport();
        }

        private void EmployeeSalaryComponent_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

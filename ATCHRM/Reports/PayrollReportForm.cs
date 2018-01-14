using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace ATCHRM.Reports
{
    public partial class PayrollReportForm : Form
    {
        Reports.Logonvalues lgvalues = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.PayrollTransaction.MainPayrollTransaction paytrans = null;
        public PayrollReportForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            paytrans = new Transactions.PayrollTransaction.MainPayrollTransaction();
        }
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }


        public void loadpayrollcombo()
        {
            DataTable dt = paytrans.GetAllPayrollNameAndID();
            cmb_payroll .DataSource = dt;
            cmb_payroll.DisplayMember = "paynumber";
            cmb_payroll.ValueMember = "Pay_Id";
        }

        private void PayrollReportForm_Load(object sender, EventArgs e)
        {
            DeptcomboLoad();
            loadpayrollcombo();
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int payrollid=int.Parse (cmb_payroll.SelectedValue.ToString ());
            int deptid = int.Parse(cmb_dept .SelectedValue.ToString());

            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\Total Payroll.rpt");
            cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + payrollid +"  and  {DesignationMaster_tbl.DepartmentPK}="+deptid;

            cryrpt.Refresh();
            crystalReportViewer1.ReportSource = cryrpt;

        }





    }
}

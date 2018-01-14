using CrystalDecisions.CrystalReports.Engine;
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
    public partial class ContractPrintingForm : Form
    {
        Reports.Logonvalues lgvalues = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        public ContractPrintingForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lgvalues = new Logonvalues();
            employecodeload(Program.LOCTNPK, 0, 0);
        }


        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_empcode.DataSource = dt;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadsummaryreport();
        }
        public void loadsummaryreport()
        {
           

            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource +"\\ContractReport.rpt");
           //  cryrpt.RecordSelectionFormula = " {AdjusterMaster_tbl.AdjusterID}=" + adjsterid;
            cryrpt.SetParameterValue("NEWEMPID", int.Parse(cmb_empcode.SelectedValue.ToString()));
            cryrpt.RecordSelectionFormula = "{Command.empid} ==" + int.Parse(cmb_empcode.SelectedValue.ToString()) + " ";
           
            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();

        }
    }
}

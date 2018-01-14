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
    public partial class MultiReporter : Form
    {
        Reports.Logonvalues lgvalues = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        public MultiReporter()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lgvalues = new Logonvalues();
            loadreportcombo();
        }

        public void loadreportcombo()
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
            var q = from rpt in cntxt.ReportMaster_tbls
                    select rpt;
            cmb_report.DataSource = q;
            cmb_report.DisplayMember = "ReportName";
            cmb_report.ValueMember = "ReportID";
        }

        public void loadsummaryreport()
        {

            String Location = "";
            lgvalues = new Reports.Logonvalues();


            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
            var q = from rpt in cntxt.ReportMaster_tbls
                    where rpt.ReportID== int.Parse (cmb_report.SelectedValue.ToString ())
                    select rpt;

            foreach (var order in q)
            {

                Location = order.ReportLocation .ToString().Trim ();


            }

            ReportDocument cryrpt = lgvalues.getpeport(Location );
            //  cryrpt.RecordSelectionFormula = " {AdjusterMaster_tbl.AdjusterID}=" + adjsterid;
          //  cryrpt.SetParameterValue("NEWEMPID", int.Parse(cmb_empcode.SelectedValue.ToString()));
          //  cryrpt.RecordSelectionFormula = "{Command.empid} ==" + int.Parse(cmb_empcode.SelectedValue.ToString()) + " ";

            crystalReportViewer1 .ReportSource = cryrpt;
            cryrpt.Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadsummaryreport();
        }
    }
}

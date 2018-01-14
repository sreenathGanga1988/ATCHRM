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
    public partial class DateRangeReports : Form
    {
        Reports.Logonvalues lgvalues = null;
        public DateRangeReports()
        {
            
            InitializeComponent();
            lgvalues = new Logonvalues();
        }

        private void synchronizeabscnet_Click(object sender, EventArgs e)
        {
            loadstatusbeforeAdjusterreport();
        }




        //public void loareport()
        //{
            
        //    Crvt_ApplicationReport.ReportSource = lgvalues.getpeport(Program.OurReportSource + "\\Attendance Reports\\Approved Status Before Adjuster.rpt");



        //        Crvt_ApplicationReport.SelectionFormula = "{{EmpSwipedataBank_tbl.SwipeDate}>=CDate('"+dtp_from.Value.Date +"') and {EmpSwipedataBank_tbl.SwipeDate}<=CDate('"+dtp_to .Value.Date+"') ";

        //        Crvt_ApplicationReport.RefreshReport();
           
        //}




        public void loadstatusbeforeAdjusterreport()
        {

          
            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\StatusBeforeAdjuster.rpt");
            cryrpt.RecordSelectionFormula = "{EmpSwipedataBank_tbl.SwipeDate}>=CDate('" + dtp_from.Value.Date.ToString("MM-dd-yyyy") + "') and {EmpSwipedataBank_tbl.SwipeDate}<=CDate('" + dtp_to.Value.Date.ToString("MM-dd-yyyy") + "') ";

            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();

        }

        public void loadstatusAfterAdjusterreport()
        {
            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\StatusAfterAdjuster.rpt");
            cryrpt.RecordSelectionFormula = "{Adjuster_Details.Swipe_Date}>=CDate('" + dtp_from.Value.Date.ToString("MM-dd-yyyy") + "') and {Adjuster_Details.Swipe_Date}<=CDate('" + dtp_to.Value.Date.ToString("MM-dd-yyyy") + "') ";

            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();
        }

        private void attendanceAfterConfirmOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadstatusAfterAdjusterreport();
        }

        private void contractEndingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\contract expire.rpt");
            cryrpt.RecordSelectionFormula = "{EmpContract_tbl.Endtime}>=CDate('" + dtp_from.Value.Date.ToString("MM-dd-yyyy") + "') and {EmpContract_tbl.Endtime}<=CDate('" + dtp_to.Value.Date.ToString("MM-dd-yyyy") + "') ";
            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();
        }

        private void pendingExceptionBeforeAdjusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\Status Before AdjusterOnly LH and UOT.rpt");
                cryrpt.RecordSelectionFormula = "{EmpSwipedataBank_tbl.SwipeDate}>=CDate('" + dtp_from.Value.Date.ToString("MM-dd-yyyy") + "') and {EmpSwipedataBank_tbl.SwipeDate}<=CDate('" + dtp_to.Value.Date.ToString("MM-dd-yyyy") + "') and {EmployeeDesignation_tbl.BranchLocationPK} = " +Program.LOCTNPK   + " and ({EmpSwipedataBank_tbl.ApprInstatus} = 'LH' or {EmpSwipedataBank_tbl.ApprOutStatus} = 'UOT')";
            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();
        }

        private void pendingExceptionAfterAdjusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lgvalues = new Reports.Logonvalues();
            ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\StatusBeforeAdjuster.rpt");
            cryrpt.RecordSelectionFormula = "{EmpSwipedataBank_tbl.SwipeDate}>=CDate('" + dtp_from.Value.Date.ToString("MM-dd-yyyy") + "') and {EmpSwipedataBank_tbl.SwipeDate}<=CDate('" + dtp_to.Value.Date.ToString("MM-dd-yyyy") + "') and {EmployeeDesignation_tbl.BranchLocationPK} = " + Program.LOCTNPK + " and ({EmpSwipedataBank_tbl.ApprInstatus} = 'LH' or {EmpSwipedataBank_tbl.ApprOutStatus} = 'UOT')";

            Crvt_ApplicationReport.ReportSource = cryrpt;
            cryrpt.Refresh();
        }

    }
}

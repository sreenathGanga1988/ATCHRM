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
    public partial class FrmPayroll : Form
    {
        Reports.Logonvalues lgvalues = null;
        public FrmPayroll()
        {
            InitializeComponent();
            lgvalues = new Logonvalues();
        }

          public FrmPayroll(int id)
        {
            InitializeComponent();
            lgvalues = new Logonvalues();
           //     crystalReportViewer1.ReportSource = @"I:\14042013\new\trunk\ATCHRM\ATCHRM\Reports\Payroll-try.rpt";

            crystalReportViewer1.ReportSource = lgvalues.getpeport(Program.OurReportSource +"\\Payroll-try.rpt");



                crystalReportViewer1.SelectionFormula = " {Payroll_PayMaster.Pay_Id}= "+id;
               
                crystalReportViewer1.Refresh();
        }


        private void FrmPayroll_Load(object sender, EventArgs e)
        {
            if (this.Text == "Pay Roll")
            {
                //crystalReportViewer1.ReportSource = @"I:\14042013\new\trunk\ATCHRM\ATCHRM\Reports\Payroll.rpt";
                //crystalReportViewer1.SelectionFormula = "{Payroll_PayMaster.Pay_Start_Date}>=date('"+ LblstrDt.Text +"') "
                //+ " and {Payroll_PayMaster.Pay_End_Date}<date('" + LblEdt.Text + "') and {Payroll_PayMaster.Pay_Loc} ="+ LblLoc.Text +" and "
                //+" {Payroll_PayMaster.Department_id}="+ LblDept.Text +" ";
                //crystalReportViewer1.Refresh();



              

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

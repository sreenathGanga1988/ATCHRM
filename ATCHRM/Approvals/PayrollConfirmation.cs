using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace ATCHRM.Approvals
{
    public partial class PayrollConfirmation : Form
    {
        Transactions.Approvalview.PayrollApproval PAYRLAPPRV = null;

        Reports.Logonvalues lgvalues = null;
        public PayrollConfirmation()
        {
            InitializeComponent();
            PAYRLAPPRV = new Transactions.Approvalview.PayrollApproval();
            GETAPPROVALDATA();

        }










        public void GETAPPROVALDATA()
        {
            tbl_payroll.Rows.Clear();
            //  tbl_ApprovalData.Columns.Clear();
            tbl_payroll.DataSource = null;
            DataTable DT = PAYRLAPPRV.getallPayrollforApproval(0);

            if (DT != null)
            {
                if (DT.Rows.Count != 0)
                {

                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        tbl_payroll.Rows.Add();
                        tbl_payroll.Rows[i].Cells[1].Value = DT.Rows[i][0].ToString();
                        tbl_payroll.Rows[i].Cells[2].Value = DT.Rows[i][2].ToString();

                        tbl_payroll.Rows[i].Cells[3].Value = DT.Rows[i][3].ToString();
                        tbl_payroll.Rows[i].Cells[4].Value = DT.Rows[i][4].ToString();
                        tbl_payroll.Rows[i].Cells[5].Value = DT.Rows[i][5].ToString();
                        tbl_payroll.Rows[i].Cells[6].Value = DT.Rows[i][6].ToString();
                        tbl_payroll.Rows[i].Cells[7].Value = DT.Rows[i][7].ToString();
                        // tbl_payroll.Rows[i].Cells[8].Value = DT.Rows[i][8].ToString();
                    }
                }
            }
        }

        private void tbl_payroll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_payroll.Rows[e.RowIndex].Cells[1].Value != null)
            {
                int payrollid = int.Parse(tbl_payroll.Rows[e.RowIndex].Cells[1].Value.ToString());

                Reports.FrmPayroll payroll = new Reports.FrmPayroll(payrollid);
                payroll.MdiParent = this.MdiParent;
                payroll.StartPosition = FormStartPosition.CenterScreen;
                payroll.Show();
            }
        }

        private void totalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource +"\\PayrollReports\\Total Payroll.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid;


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }

        private void partimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource +"\\PayrollReports\\Payroll.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid;


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }

        private void incentivesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource +"\\PayrollReports\\iNCENTIVE.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid;


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }

        private void btn_printPreview_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                int rowno=0;
                rowno= int.Parse (tbl_payroll.CurrentRow.Index .ToString ());
                SqlCommand cmd = new SqlCommand("Confirmpayroll_sp", con);
                cmd.Parameters.AddWithValue("@payrollid ", int.Parse(tbl_payroll.Rows[rowno].Cells[1].Value.ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                con.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tbl_payroll .Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tbl_payroll.Rows[i].Cells[0].Value) == true)
                    {
                        PAYRLAPPRV.revertpayroll(int.Parse(tbl_payroll.Rows[i].Cells[1].Value.ToString()));
                    }

                }
                GETAPPROVALDATA();
              
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }

        private void tbl_payroll_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void tbl_payroll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_payroll.IsCurrentCellDirty)
            {
                tbl_payroll.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void completeNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\Payroll-trynew.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid;


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }

        private void allDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\AllPayrollDetails.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid;


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }

        private void bankDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\PayrrolViaBank.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid + "and {EmployesalaryDetails_tbl.Paymentmode}='Bank Transfer'";


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }

        }

        private void cashDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\CashRegister.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid + "and {EmployesalaryDetails_tbl.Paymentmode}='Cash'";


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }

        private void payslipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_payroll.Rows[tbl_payroll.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\PayrollReports\\Payslip.rpt");
                cryrpt.RecordSelectionFormula = "{Payroll_PayMaster.Pay_Id}=" + adjsterid +"";


                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }





       


    }
}

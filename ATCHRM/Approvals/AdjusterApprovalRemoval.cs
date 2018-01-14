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
namespace ATCHRM.Approvals
{
    public partial class AdjusterApprovalRemoval : Form
    {
        Reports.Logonvalues lgvalues = null;
        Transactions.Approvalview.Adjusterview  adjsterview = null;
        public AdjusterApprovalRemoval()
        {
            InitializeComponent();
            adjsterview = new Transactions.Approvalview.Adjusterview();
            GETAPPROVALDATA();
        }





        public void GETAPPROVALDATA()
        {
           
            DataTable DT = adjsterview.getAllAdjusterforApproval(0);

            if (DT.Rows.Count != 0)
            {

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    tbl_adjuster.Rows.Add();
                    tbl_adjuster.Rows[i].Cells[1].Value = DT.Rows[i][0].ToString();
                    tbl_adjuster.Rows[i].Cells[2].Value = DT.Rows[i][1].ToString();

                    tbl_adjuster.Rows[i].Cells[3].Value = DT.Rows[i][2].ToString();
                    tbl_adjuster.Rows[i].Cells[4].Value = DT.Rows[i][3].ToString();
                    tbl_adjuster.Rows[i].Cells[5].Value = DT.Rows[i][4].ToString();
                    tbl_adjuster.Rows[i].Cells[6].Value = DT.Rows[i][5].ToString();
              //      tbl_payroll.Rows[i].Cells[7].Value = DT.Rows[i][7].ToString();
                    // tbl_payroll.Rows[i].Cells[8].Value = DT.Rows[i][8].ToString();
                }
            }
        }

        private void ctxt_type1_Click(object sender, EventArgs e)
        {
            if (tbl_adjuster.Rows[tbl_adjuster.CurrentCell .RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_adjuster.Rows[tbl_adjuster.CurrentCell .RowIndex].Cells[1].Value.ToString());
               
                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource +"\\AdjusterReportWithoutlines-1.rpt");
                cryrpt.RecordSelectionFormula = " {AdjusterMaster_tbl.AdjusterID}=" + adjsterid;
           

                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tbl_adjuster.Rows[tbl_adjuster.CurrentCell.RowIndex].Cells[1].Value != null)
            {
                int adjsterid = int.Parse(tbl_adjuster.Rows[tbl_adjuster.CurrentCell.RowIndex].Cells[1].Value.ToString());

                lgvalues = new Reports.Logonvalues();
                ReportDocument cryrpt = lgvalues.getpeport(Program.OurReportSource + "\\AdjustedExceptionReport-1.rpt");
                cryrpt.RecordSelectionFormula = "{Adjuster_Cropped.Adjust_Id}=" + adjsterid;

                
                cryrpt.Refresh();

                Reports.ReportForm rptfrm = new Reports.ReportForm(cryrpt);
                rptfrm.MdiParent = this.MdiParent;
                rptfrm.StartPosition = FormStartPosition.CenterScreen;
                rptfrm.Show();
            }

        }

        private void btn_printPreview_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tbl_adjuster.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tbl_adjuster.Rows[i].Cells[0].Value) == true)
                    {
                        adjsterview.revertAdjuster(int.Parse(tbl_adjuster.Rows[i].Cells[1].Value.ToString()));
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

        private void tbl_payroll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_adjuster.IsCurrentCellDirty)
            {
                tbl_adjuster.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }




      







    }
}

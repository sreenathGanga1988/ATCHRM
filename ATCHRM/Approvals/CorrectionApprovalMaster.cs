using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Approvals
{
    public partial class CorrectionApprovalMaster : Form
    {
        Transactions.ApprovalTransaction TRANS = null;
        Transactions.ApprovalTransaction apprvltrans = null;
        public CorrectionApprovalMaster()
        {
            InitializeComponent();
            TRANS = new Transactions.ApprovalTransaction();
            apprvltrans = new Transactions.ApprovalTransaction();
        }




        public void LoadDatagrid()
        {
            tbl_Approval.Rows.Clear();
            //  tbl_ApprovalData.Columns.Clear();
            tbl_Approval.DataSource = null;
            DataTable dt = new DataTable();
            dt = TRANS.getallcorrectiondata(Program.LOCTNPK, dtp_datetodat1.Value.Date);

           //tbl_Approval.DataSource = dt;




            for (int i=0 ;i <dt.Rows.Count;i++)
            {
                tbl_Approval.Rows.Add();

                tbl_Approval.Rows[i].Cells[1].Value = dt.Rows[i][0];
                tbl_Approval.Rows[i].Cells[2].Value = dt.Rows[i][1];
                tbl_Approval.Rows[i].Cells[3].Value = dt.Rows[i][2];
                tbl_Approval.Rows[i].Cells[4].Value = dt.Rows[i][3];
                tbl_Approval.Rows[i].Cells[5].Value = dt.Rows[i][4];
                tbl_Approval.Rows[i].Cells[6].Value = dt.Rows[i][5];
                tbl_Approval.Rows[i].Cells[7].Value = dt.Rows[i][6];
                tbl_Approval.Rows[i].Cells[8].Value = dt.Rows[i][7];
                tbl_Approval.Rows[i].Cells[9].Value = dt.Rows[i][8];
                tbl_Approval.Rows[i].Cells[10].Value = dt.Rows[i][9];
            }


        }

        private void dtp_datetodat1_ValueChanged(object sender, EventArgs e)
        {
            LoadDatagrid();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tbl_Approval.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_Approval.Rows[i].Cells[0].Value) == true)
                    {

                        apprvltrans.rejectCorrectionApplication(int.Parse(tbl_Approval.Rows[i].Cells[1].Value.ToString()));
                    }
                }

                LoadDatagrid();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < tbl_Approval.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_Approval.Rows[i].Cells[0].Value) == true)
                    {
                        apprvltrans.approveCorrectiondata(int.Parse(tbl_Approval.Rows[i].Cells[1].Value.ToString()));
                       
                     }

                  
                }


                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                LoadDatagrid();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
       
        
        }

        private void tbl_Approval_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void tbl_Approval_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_Approval.IsCurrentCellDirty)
            {
                tbl_Approval.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }






    }
}

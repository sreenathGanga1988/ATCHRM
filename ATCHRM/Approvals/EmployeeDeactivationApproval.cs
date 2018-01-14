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
    public partial class EmployeeDeactivationApproval : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
       
        int lctnflg = 0;
        int actionnum=0;
        Transactions.ApprovalTransaction empdectrans = null;
        public EmployeeDeactivationApproval()
        {
            InitializeComponent();
            empdectrans = new Transactions.ApprovalTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
        }
        public EmployeeDeactivationApproval(int num)
        {
            InitializeComponent();
            actionnum=num;
            empdectrans = new Transactions.ApprovalTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            filldatagridview();

        }


        public void filldatagridview()
        {
            tbl_deactivationdetails.Rows.Clear();
            //  tbl_ApprovalData.Columns.Clear();
            tbl_deactivationdetails.DataSource = null;
            DataTable dt = new DataTable();
     dt = empdectrans.getDeactivationdataforApproval(Program.LOCTNPK, actionnum);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                tbl_deactivationdetails.Rows.Add();
                tbl_deactivationdetails.Rows[i].Cells[1].Value = dt.Rows[i][0];
                tbl_deactivationdetails.Rows[i].Cells[2].Value = dt.Rows[i][1];
                tbl_deactivationdetails.Rows[i].Cells[3].Value = dt.Rows[i][2];
                tbl_deactivationdetails.Rows[i].Cells[4].Value = dt.Rows[i][3];
                tbl_deactivationdetails.Rows[i].Cells[5].Value = dt.Rows[i][4];
                tbl_deactivationdetails.Rows[i].Cells[6].Value = dt.Rows[i][5];
                tbl_deactivationdetails.Rows[i].Cells[7].Value = dt.Rows[i][6];
                tbl_deactivationdetails.Rows[i].Cells[8].Value = dt.Rows[i][7];
                tbl_deactivationdetails.Rows[i].Cells[9].Value = dt.Rows[i][8];
                tbl_deactivationdetails.Rows[i].Cells[10].Value = dt.Rows[i][9];
                tbl_deactivationdetails.Rows[i].Cells[11].Value = dt.Rows[i][10];
                tbl_deactivationdetails.Rows[i].Cells[12].Value = dt.Rows[i][11];
            }
        
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

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tbl_deactivationdetails.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_deactivationdetails.Rows[i].Cells[0].Value) == true)
                    {
                        //if black listed
                        if (tbl_deactivationdetails.Rows[i].Cells[12].Value.ToString().Trim() == "Y")
                        {
                            empdectrans.DeactApproveandBlacklistAction(int.Parse(tbl_deactivationdetails.Rows[i].Cells[1].Value.ToString()), actionnum, "A");
                            ATCHRM.Controls.ATCHRMMessagebox.Show("BlackListed");
                        }
                            //else if only decativated
                        else
                        {
                            empdectrans.DeactApproveAction(int.Parse(tbl_deactivationdetails.Rows[i].Cells[1].Value.ToString()), actionnum, "A");
                            ATCHRM.Controls.ATCHRMMessagebox.Show("Deactivated");
                        }
                    }
                }

                filldatagridview();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }

        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < tbl_deactivationdetails.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_deactivationdetails.Rows[i].Cells[0].Value) == true)
                    {
                        empdectrans.DeactApproveAction(int.Parse(tbl_deactivationdetails.Rows[i].Cells[1].Value.ToString()), actionnum, "R");
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    }
                }

                filldatagridview();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void tbl_deactivationdetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_deactivationdetails.IsCurrentCellDirty)
            {
                tbl_deactivationdetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void EmployeeDeactivationApproval_Load(object sender, EventArgs e)
        {

        }






       



















    }
}

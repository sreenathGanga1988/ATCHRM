using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class BranchMasterForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;

       
        public BranchMasterForm()
        {
            InitializeComponent();
            tbl_branch.RowTemplate.Height = 18;
            cmptransaction = new Transactions.CompanyBranchTransactions();
            cmb_action.SelectedIndex = 1;
        }



      

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void BranchMasterForm_Load(object sender, EventArgs e)
        {
            try
            {

              //  DataTable dt = cmptransaction.selectallbranch();
             //   tbl_branch.DataSource = dt;
                 DataTable dt = cmptransaction.selectalllocation ();
                    tbl_branch.DataSource = dt;
                    this.Text = "Location";
            }
            catch (Exception exp)
            {
                
                  ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_action.SelectedIndex = 1;
            
            if (cmb_action.Text == "Branches")
            {
                try
                {
                    tbl_branch.DataSource = null;
                    DataTable dt = cmptransaction.selectallbranch();
                    tbl_branch.DataSource = dt;
                    this.Text = "Branch";
                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                    this.Dispose();
                }
               
            }
            else if (cmb_action.Text == "Location")
            {
                try
                {
                    tbl_branch.DataSource = null;
                    DataTable dt = cmptransaction.selectalllocation ();
                    tbl_branch.DataSource = dt;
                    this.Text = "Location";
                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                    this.Dispose();
                }

            }
        }

        private void tbl_branch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != tbl_branch.RowCount - 1)
            {
                if (this.Text == "Branch")
                {

                    BranchesMasterForm branchesmasterform = new BranchesMasterForm(int.Parse(tbl_branch.Rows[e.RowIndex].Cells[0].Value.ToString()), "Branches");
                    this.Close();
                    branchesmasterform.Text = "Branch Details";
                    branchesmasterform.Show();
                }
                else if (this.Text == "Location")
                {
                    BranchesMasterForm branchesmasterform = new BranchesMasterForm(int.Parse(tbl_branch.Rows[e.RowIndex].Cells[0].Value.ToString()), "Location");
                    this.Close();
                    branchesmasterform.Text = "Location Details";
                    branchesmasterform.Show();
                }
                else
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Something else");
                }

            }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            Master.BranchesMasterForm branchmasterform = new Master.BranchesMasterForm();
            branchmasterform.MdiParent = this.MdiParent;
            branchmasterform.Show();
        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_action.SelectedIndex = 1;

            if (cmb_action.Text == "Branches")
            {
                try
                {
                    tbl_branch.DataSource = null;
                    DataTable dt = cmptransaction.selectallbranch();
                    tbl_branch.DataSource = dt;
                    this.Text = "Branch";
                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                    this.Dispose();
                }

            }
            else if (cmb_action.Text == "Location")
            {
                try
                {
                    tbl_branch.DataSource = null;
                    DataTable dt = cmptransaction.selectalllocation();
                    tbl_branch.DataSource = dt;
                    this.Text = "Location";
                }
                catch (Exception exp)
                {

                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                    this.Dispose();
                }

            }
        }
        
    }
}

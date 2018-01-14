using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class CompanyMasterForm : Form
    {
        Transactions.CompanyBranchTransactions cmpnytransactions = null;
        public CompanyMasterForm()
        {
            InitializeComponent();
   tbl_companyMaster.RowTemplate.Height = 18;
            cmpnytransactions = new Transactions.CompanyBranchTransactions();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

       

        private void CompanyMasterForm_Load(object sender, EventArgs e)
        {
            try
            {

                tbl_companyMaster.DataSource = cmpnytransactions.selectallcompanydata();
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.ToString ());
            }
            
        }



        private void tbl_companyMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != tbl_companyMaster.RowCount - 1)
            {
                try
                {
                    if (tbl_companyMaster.SelectedRows.Count != 0)
                    {

                        int rowno = e.RowIndex;
                        int columnno = e.ColumnIndex;

                        DataTable dt = cmpnytransactions.getallcompanydatabypk(int.Parse(tbl_companyMaster.Rows[rowno].Cells[0].Value.ToString()));

                        CompanyForm cmpform = new CompanyForm(dt);

                        cmpform.MdiParent = this.MdiParent;
                        cmpform.Text = "Company Details";
                        this.Close();
                        cmpform.Show();




                    }
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

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            CompanyForm cmpnyform = new CompanyForm();
            cmpnyform.MdiParent = this.MdiParent;
            cmpnyform.Show();

        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}

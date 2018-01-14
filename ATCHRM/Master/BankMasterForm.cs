using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class BankMasterForm : Form
    {
        Transactions.BankTransactions bnktransaction = null;
        public BankMasterForm()
        {
            InitializeComponent();
            bnktransaction = new Transactions.BankTransactions();
            tbl_BankData.RowTemplate.Height = 18;
        }
        public BankMasterForm(int bankpk)
        {
            InitializeComponent();
            bnktransaction = new Transactions.BankTransactions();
            tbl_BankData.RowTemplate.Height = 18;
        }
        private void BankMasterForm_Load(object sender, EventArgs e)
        {
            try
            {

                tbl_BankData.DataSource = bnktransaction.selectallBankdata();
                tbl_BankData.Columns[0].Visible = false;
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.ToString());
            }
        }

       

        private void tbl_BankData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != tbl_BankData.RowCount - 1)
            {
                Master.BankForm bnkform = new BankForm(int.Parse(tbl_BankData.Rows[e.RowIndex].Cells[0].Value.ToString()));
                bnkform.MdiParent = this.MdiParent;
                bnkform.Text = "Bank Details";
                this.Close();
                bnkform.Show();
            }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            
            Master.BankForm bnkfrm = new Master.BankForm();
            bnkfrm.MdiParent = this.MdiParent;
            this.Close();
            bnkfrm.Show();
        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

        

       
    }
}

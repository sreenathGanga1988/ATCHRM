using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Payroll
{
    public partial class PayrollReportcs : Form
    {
        Transactions.PayrollTransaction.MainPayrollTransaction paytrans = null;
        Transactions.ReportTransaction rpttran = new Transactions.ReportTransaction();
        public PayrollReportcs()
        {
           
            InitializeComponent();
            paytrans = new Transactions.PayrollTransaction.MainPayrollTransaction();
            rpttran = new Transactions.ReportTransaction();
           
            loadpayrollcombo();
        }
        public void loadpayrollcombo()
        {
            DataTable dt = paytrans.GetAllPayrollNameAndID();
            cmb_payroll.DataSource = dt;
            cmb_payroll.DisplayMember = "paynumber";
            cmb_payroll.ValueMember = "Pay_Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttran.GetPayrollDetailsFull(int.Parse (cmb_payroll.SelectedValue.ToString ()));
           ultraGrid1.DataSource = dt;
           Transactions.ControlSetupper.UltraGridNormalSetup(ultraGrid1);
        }
    }
}

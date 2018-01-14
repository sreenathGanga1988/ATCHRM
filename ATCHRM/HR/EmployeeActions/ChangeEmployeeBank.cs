using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR.EmployeeActions
{
    public partial class ChangeEmployeeBank : Form
    {
        Transactions.BankTransactions bnktransctn = null;
        Transactions.EmployeeRegTransaction empreg = null;
        public ChangeEmployeeBank()
        {
            InitializeComponent();
            bnktransctn = new Transactions.BankTransactions();
            empreg = new Transactions.EmployeeRegTransaction();
        }



        public ChangeEmployeeBank(int empid, String existingbankname,String accountnum)
        {
            InitializeComponent();
            bnktransctn = new Transactions.BankTransactions();
            empreg = new Transactions.EmployeeRegTransaction();
            lbl_empid.Text = empid.ToString();
            lbl_bank.Text = existingbankname;
            lbl_accountnum.Text = accountnum;
            txt_accountnum.Text = accountnum;
        }

        private void ChangeEmployeeBank_Load(object sender, EventArgs e)
        {
            fillBank();
        }
        public void fillBank()
        {

            DataTable dt = bnktransctn.getallbanknameandcode();
            cmb_bank.DataSource = dt;
            cmb_bank.DisplayMember = "bnkname";
            cmb_bank.ValueMember = "pk";

        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {

            if(cmb_bank.Text.Trim ()!=""&&txt_accountnum.Text.Trim()!="")
            {
                if (empreg.IfDuplicateAccountfound(int.Parse(lbl_empid.Text), txt_accountnum.Text.Trim()))
                {

                }
                else
                {

                    empreg.updateBankdetails(int.Parse(lbl_empid.Text), int.Parse(cmb_bank.SelectedValue.ToString()), txt_accountnum.Text.ToString());
                    Actionlog.actiondone("Employee Bank changed ", "of Empid " + lbl_empid.Text + " Done By to " + lbl_bank.Text + "", int.Parse(lbl_empid.Text));
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Administrator
{
    
    public partial class NotificationForm : Form
    {
        Transactions.NotificationTransaction trans = null;
        DataTable Birthdaydata = null;
        DataTable ContractendingData = null;
        DataTable PendingCloseregisterdata = null;
        public NotificationForm()
        {
            InitializeComponent();
            trans = new Transactions.NotificationTransaction();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            Birthdaydata = trans.getbirthday();
            ContractendingData = trans.GetContractEndingEmployees();
            PendingCloseregisterdata = trans.getpendingcloseregister();
            int birthday = 0;
            int contractDay=0;
            int pendingdays=0;
            if (Birthdaydata.Rows.Count > 0)
            {
                birthday = Birthdaydata.Rows.Count;
            }
            if (ContractendingData.Rows.Count > 0)
            {
                contractDay = ContractendingData.Rows.Count;
            }
            if (PendingCloseregisterdata.Rows.Count > 0)
            {
                pendingdays = int.Parse (PendingCloseregisterdata.Rows[0][0].ToString ());
            }

            lbl_birthday.Text = birthday .ToString () + "  Employees Have Birthday Today";
            lnk_Contract.Text = contractDay.ToString() + " Employees Contract  will Expire in 10 Days";
            lbl_closeregistr.Text = pendingdays.ToString() + " Days are not close Registered";
        }

        private void lnk_Contract_MouseClick(object sender, MouseEventArgs e)
        {
           

        }

        private void lbl_birthday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbl_birthday.Text != "")
            {
                Administrator.Ultrafridform frm = new Ultrafridform(Birthdaydata);
                frm.Text = "Todays Birthday";
                frm.ShowDialog();
            }
        }

        private void lnk_Contract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnk_Contract.Text != "")
            {
                Administrator.Ultrafridform frm = new Ultrafridform(ContractendingData);
                frm.Text = "Contract Ending Employees";
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_closeregistr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable Last10Closedata = trans.Last10closeregister();
            Administrator.Ultrafridform frm = new Ultrafridform(Last10Closedata);
            frm.Text = "Last 10 Close Register Data";
            frm.ShowDialog();

        }
    }
}

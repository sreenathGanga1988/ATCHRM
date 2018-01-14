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
    public partial class LHRApproval : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.ApprovalTransaction apprltran = null;
        int lctnflg = 0;
        int actionlevel =1;
        public LHRApproval()
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            apprltran = new Transactions.ApprovalTransaction();
        }
        public LHRApproval(int levelnum)
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            apprltran = new Transactions.ApprovalTransaction();
            actionlevel = levelnum;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LHRApproval_Load(object sender, EventArgs e)
        {
            locationListLoad();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(cmb_location.SelectedValue!=null){


                //
                //tbl_datagrid.DataSource=
               
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            DataTable dt = apprltran.getallLHRReject(int.Parse(cmb_location.SelectedValue.ToString()), actionlevel);
                tbl_datagrid.DataSource=dt;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

       
    }
}

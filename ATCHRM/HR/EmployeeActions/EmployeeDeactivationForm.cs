using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR.NewFolder1
{
    public partial class EmployeeDeactivationForm : Form
    {
        Transactions.EmployeeRegTransaction empregtrans = null;
        int empflag = 0;
        public EmployeeDeactivationForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            fillemployecode();
        }
        public EmployeeDeactivationForm(int empid)
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            fillemployecode();
            cmb_employecode.SelectedValue = empid;
            fillemployeedata();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }



        public void fillemployecode()
        {

            DataTable dt = empregtrans.getEmpcode(Program.LOCTNPK, 0, 0);

            cmb_employecode.DataSource = dt;
            cmb_employecode.DisplayMember = "empno";
            cmb_employecode.ValueMember = "empid";

        }

        private void cmb_employecode_MouseClick(object sender, MouseEventArgs e)
        {
            empflag++;
        }

        private void cmb_employecode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (empflag != 0)
            {

                fillemployeedata();
            }
        }

        public void fillemployeedata()
        {
            if (cmb_employecode.Text != "")
            {

                DataTable dt = empregtrans.getEmployeDesignationNameandLocation(int.Parse(cmb_employecode.SelectedValue.ToString()));

                if (dt.Rows.Count != 0)
                {


                    txt_name.Text = dt.Rows[0][2].ToString();
                    txt_desg.Text = dt.Rows[0][7].ToString();
                    txtnid.Text = dt.Rows[0][3].ToString();

                }

            }
        }



        public Boolean validationControl()
        {
            Boolean sucess = false;


            if (cmb_employecode.Text == null || cmb_employecode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the  EmpCode ";
                cmb_employecode.Focus();


            }
            else if ((rht_remark.Text == null || rht_remark.Text.Trim() == ""))
            {
                lblStatus.Text = "Enter the  Remark";
                rht_remark.Focus();
            }


            else if (chkbx_Reasons.SelectedItems.Count == 0)
            {
                lblStatus.Text = "Enter the  Reason";
                rht_remark.Focus();
            }
            else
            {
                sucess = true;
            }
            return sucess;

        }



        /// <summary>
        /// get the selected reasons from the checked box list
        /// </summary>
        /// <returns>rsnarrylst</returns>
        public ArrayList getreasons()
        {
            ArrayList rsnarrylst = new ArrayList();
            foreach (object itemChecked in chkbx_Reasons.CheckedItems)
            {
                String company = (String)itemChecked;
                rsnarrylst.Add(company);
            }

            return rsnarrylst;

        }

        /// <summary>
        /// get the data for deactivation
        /// </summary>
        /// <returns></returns>
        public ArrayList deactivationdata()
        {
            String employable = "Y";
            String isblacklist = "N";
            if(rbt_employable .Checked==true ){
                employable = "Y";
            }
            else if (rbtunemployable .Checked == true)
            {
                employable = "N";
            }
            if (chk_blacklist.Checked == true)
            {
                isblacklist = "Y";
            }
            else if (chk_blacklist.Checked == false)
            {
                isblacklist = "N";
            }
            ArrayList deactdata = new ArrayList();
            deactdata.Add(int.Parse(cmb_employecode.SelectedValue.ToString()));
            deactdata.Add(employable);
            deactdata.Add(rht_remark.Text );
            deactdata.Add(dtp_fromdate.Value.Date);
            deactdata.Add(isblacklist);
            return deactdata;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (validationControl())
                {

                    ArrayList deactdata = new ArrayList();
                    ArrayList rsnarrylst = new ArrayList();

                    deactdata = deactivationdata();
                    rsnarrylst = getreasons();

                    empregtrans.deactivateemployee(deactdata, rsnarrylst);
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

                    this.Close();
                }
            }
            catch (Exception exp )
            {
               if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();  
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }


    }
}


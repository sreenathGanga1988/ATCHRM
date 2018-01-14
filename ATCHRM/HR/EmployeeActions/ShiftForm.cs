using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master.NewFolder1
{
    public partial class ShiftForm : Form
    {
        Transactions.ShiftTransaction shfttransaction = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Datalayer.EmployeeShiftDatabean shftdatbean = null;
        int flag = 0;
        int changeshiftid = 0;
        String applicationType = null;
        public ShiftForm()
        {
            InitializeComponent();
            shfttransaction = new Transactions.ShiftTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
        }
        public ShiftForm(String Empnum ,int emppk)
        {
            InitializeComponent();
            shfttransaction = new Transactions.ShiftTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            cmb_empCode.Text = Empnum;
            lbl_emppk.Text = emppk.ToString ();
        }


        public ShiftForm(String Empnum, int emppk,String applicationstring ,int applicationid)
        {
            InitializeComponent();
            shfttransaction = new Transactions.ShiftTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            cmb_empCode.Text = Empnum;
            lbl_emppk.Text = emppk.ToString();
            applicationType = applicationstring;
            if (applicationstring!="Shift Change")
            {
                btn_Skip.Enabled = true;
               
            }
            getCurrentshiftdataofemployee();


        }

        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (cmb_empCode.Text == null || cmb_empCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the EmployeeCode ";
                cmb_empCode.Focus();


            }
           
            else if (Cmb_shift.Text == null || Cmb_shift.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Shift Applicable ";
                Cmb_shift.Focus();
            }
            

            else
            {
                sucess = true;
            }
            return sucess;
        }

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            shiftcomboload();
        }


        public void getCurrentshiftdataofemployee()
        {
            if (lbl_emppk.Text != null || lbl_emppk.Text=="")
            {
            DataTable dt = shfttransaction.getemployeeshiftdata(int.Parse(lbl_emppk.Text));
            if (dt.Rows.Count != 0)
            {
                Cmb_shift.Text = dt.Rows[0][1].ToString();
                lbl_shiftPK.Text = dt.Rows[0][0].ToString();
           //     cmb_weeklyofdays.Text = dt.Rows[0][2].ToString();
               // dtp_fromdate.Value = DateTime.Parse(dt.Rows[0][3].ToString());
             //   dtp_fromTime.Value = DateTime.Parse(dt.Rows[0][4].ToString());
             //   dtp_toTime.Value = DateTime.Parse(dt.Rows[0][5].ToString());
            }

            }

        }



        /// <summary>
        /// LOAD ALL THE SHIFT DATA
        /// </summary>
        public void shiftcomboload()
        {
            DataTable dt = shfttransaction.selectallShiftdata();

                Cmb_shift.DataSource=dt;
                Cmb_shift.DisplayMember = "ShiftName";
                Cmb_shift.ValueMember = "ShiftPk";
        }

        private void Cmb_shift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag != 0)
            {
                DataTable dt = shfttransaction.getsShiftByPK(int.Parse(Cmb_shift.SelectedValue.ToString()));
                dtp_fromTime.Value = DateTime.Parse(dt.Rows[0][2].ToString());
                dtp_toTime.Value = DateTime.Parse(dt.Rows[0][3].ToString());
            }

          
           
        }

        private void Cmb_shift_MouseClick(object sender, MouseEventArgs e)
        {
            flag = 1;
        }

        private void btn_Skip_Click(object sender, EventArgs e)
        {
            LeaveForm lvfrm = new LeaveForm(cmb_empCode.Text, int.Parse(lbl_emppk.Text), applicationType, changeshiftid);
            lvfrm.Show();
            this.Close();
        }

        private void btn_submmit_Click(object sender, EventArgs e)
        {
            if (validationcontrol())
            {
                shftdatbean = new Datalayer.EmployeeShiftDatabean();
                shftdatbean.Empid = int.Parse(lbl_emppk.Text);
                shftdatbean.ShiftPk1 = int.Parse(Cmb_shift.SelectedValue.ToString());
                shftdatbean.WeeklyOff1 = cmb_weeklyofdays.Text.ToString();
                shftdatbean.Startime = dtp_fromTime.Value.TimeOfDay;
                shftdatbean.Endtime = dtp_toTime.Value.TimeOfDay;
                shftdatbean.Effectivedate = dtp_fromdate.Value.Date;
                empregtrans.insertEmpShiftDetails(shftdatbean);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

                LeaveForm lvfrm = new LeaveForm(cmb_empCode.Text, int.Parse(lbl_emppk.Text));
                lvfrm.Show();
                this.Close();

                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
    
    
    }
}

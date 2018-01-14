using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class LeaveForm : Form
    {
        Datalayer.LeaveDataBean lvdatabean = null;
        Transactions.LeaveTransaction lvtransaction = null;
        public LeaveForm()
        {
            InitializeComponent();
            rbt_notEnhasable.Checked = true;
            rbt_isformale.Checked = true;
            rbt_iscarryforwardable .Checked = true;
            rbt_isforwomen.Checked = true;
            txt_enhasableDays.Text = "0";
            lvtransaction = new Transactions.LeaveTransaction();

            showAlldata();

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_isenchasable.Checked == true)
            {
                pnl_Enhasement.Visible = true;
                txt_enhasableDays.Text = txt_allowedLeave.Text ;
                }
            else
            {
                pnl_Enhasement.Visible = false;
                txt_enhasableDays.Text ="0";
}
        }




        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (txt_leavename.Text == null || txt_leavename.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Leave Name ";
                txt_leavename.Focus();


            }
            else if (txt_leaveCode.Text == null || txt_leaveCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Leave Code  ";
                txt_leaveCode.Focus();
            }


            else if (cmb_calculationtype.Text == null || cmb_calculationtype.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Leave Calculation Type ";
                cmb_calculationtype.Focus();
            }

            else if (cmb_calculateUpto.Text == null || cmb_calculateUpto.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Calculation Upto ";
                cmb_calculateUpto.Focus();
            }
            else if (cmb_consider.Text == null || cmb_consider.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Consider Also ";
                cmb_calculateUpto.Focus();
            }
            else if (txt_enhasableDays.Text == null || txt_enhasableDays.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Enchasable Days for this Leave ";
                cmb_calculationtype.Focus();
            }

            else if (checkforduplicateLeaveCode() == false)
            {

                lblStatus.Text = "LeaveCode  Already Exist ";
                txt_leavename.Focus();
                txt_leavename.Text = "";
            }

            else if (checkforduplicate() == false)
            {

                lblStatus.Text = "Leave Code Already Exist ";
                txt_leavename.Focus();
                txt_leavename.Text = "";
            }
            else
            {
                sucess = true;
            }
            return sucess;

        }


        public Datalayer.LeaveDataBean fetchdata()
        {

            if (btn_Save.Text == "Save")
            {
                lvdatabean = new Datalayer.LeaveDataBean();

                lvdatabean.Leavename = txt_leavename.Text;
                lvdatabean.Leavecaltype = cmb_calculationtype.Text;
                lvdatabean.Description = rht_description.Text;
                lvdatabean.Enchasabledays = int.Parse(txt_enhasableDays.Text);
                lvdatabean.Allowedleave = int.Parse(txt_allowedLeave.Text);
                lvdatabean.LeaveCode1 = txt_leaveCode.Text.Trim();
                lvdatabean.CalculateUpto1 = cmb_calculateUpto.Text;
                lvdatabean.ConsiderAlso1 = cmb_consider.Text;
                if (rbt_isenchasable.Checked == true)
                {
                    lvdatabean.Isencashable = 1;
                }
                else
                {
                    lvdatabean.Isencashable = 0;
                }

                if (rbt_iscarryforwardable .Checked == true)
                {
                    lvdatabean.IsCarryFowardable  = 1;
                }
                else
                {
                    lvdatabean.Isencashable = 0;
                }


                
                if (rbt_isformale.Checked == true)
                {
                    lvdatabean.Ismaleapp = 1;
                }
                else
                {
                    lvdatabean.Ismaleapp = 0;
                }

                if (rbt_isforwomen.Checked == true)
                {
                    lvdatabean.Isfemaleapp = 1;
                }
                else
                {
                    lvdatabean.Isfemaleapp = 0;
                }
               
            }


            else if (btn_Save.Text == "Update")
            {
                
                lvdatabean = new Datalayer.LeaveDataBean();

                lvdatabean .Leavepk  = int.Parse(lbl_leavepk.Text.ToString());
                lvdatabean.Leavename = txt_leavename.Text;
                lvdatabean.Leavecaltype = cmb_calculationtype.Text;
                lvdatabean.Description = rht_description.Text;
                lvdatabean.Enchasabledays = int.Parse(txt_enhasableDays.Text);
                lvdatabean.Allowedleave = int.Parse(txt_allowedLeave.Text);
                lvdatabean.ConsiderAlso1 = cmb_consider.Text;
                lvdatabean.LeaveCode1 = txt_leaveCode.Text.Trim();
                if (rbt_isenchasable.Checked == true)
                {
                    lvdatabean.Isencashable = 1;
                }
                else
                {
                    lvdatabean.Isencashable = 0;
                }
                if (rbt_iscarryforwardable.Checked == true)
                {
                    lvdatabean.IsCarryFowardable = 1;
                }
                else
                {
                    lvdatabean.Isencashable = 0;
                }

                if (rbt_isformale.Checked == true)
                {
                    lvdatabean.Ismaleapp = 1;
                }
                else
                {
                    lvdatabean.Ismaleapp = 0;
                }

                if (rbt_isforwomen.Checked == true)
                {
                    lvdatabean.Isfemaleapp = 1;
                }
                else
                {
                    lvdatabean.Isfemaleapp = 0;
                }
                       
            }
            return lvdatabean;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Save.Text == "Save")
                {
                    if (validationcontrol())
                    {
                        lvtransaction = new Transactions.LeaveTransaction();

                        lvtransaction.insertLeavedata(fetchdata());
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Leave Data  Added");
                        showAlldata();
                        clearcontrol();
                    }
                }
                else if (btn_Save.Text == "Edit")
                {
                    btn_Save.Text = "Update";
                    grp_leave.Enabled = true;

                }
                else if (btn_Save.Text == "Update")
                {
                    if (validationcontrol())
                    {
                        lvtransaction = new Transactions.LeaveTransaction();

                        lvtransaction.updateLeaveData(fetchdata());
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Leave Data  Updated");
                        showAlldata();
                        clearcontrol();
                    }

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


        public void showAlldata()
        {
            tbl_leavedata.RowCount = 0;
            tbl_leavedata.Columns.Clear();
            tbl_leavedata.Columns.Add("1", "Sl");
            tbl_leavedata.Columns.Add("1", "Leave");
            tbl_leavedata.Columns.Add("1", "Desc");
            tbl_leavedata.Columns.Add("1", "Calculation");
            tbl_leavedata.Columns.Add("1", "Encash Days");
            tbl_leavedata.Columns.Add("1", "For Males");
            tbl_leavedata.Columns.Add("1", "For Females");
            tbl_leavedata.Columns.Add("1", "Allowed");
            tbl_leavedata.Columns.Add("1", "LeaveCode");
            tbl_leavedata.Columns.Add("1", "Calculate Upto");
            tbl_leavedata.Columns.Add("1", "Consider");
            tbl_leavedata.RowTemplate.Height = 18;
            lvtransaction = new Transactions.LeaveTransaction();
            DataTable dt = lvtransaction.getAllLeaveData();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_leavedata.Rows.Add();
                tbl_leavedata.Rows[i].Cells[0].Value = dt.Rows[i][0];
                tbl_leavedata.Rows[i].Cells[1].Value = dt.Rows[i][1];
                tbl_leavedata.Rows[i].Cells[2].Value = dt.Rows[i][2];
                tbl_leavedata.Rows[i].Cells[3].Value = dt.Rows[i][3];
                tbl_leavedata.Rows[i].Cells[4].Value = dt.Rows[i][4];
                tbl_leavedata.Rows[i].Cells[5].Value = dt.Rows[i][5];
                tbl_leavedata.Rows[i].Cells[6].Value = dt.Rows[i][6];
                tbl_leavedata.Rows[i].Cells[7].Value = dt.Rows[i][7];
                tbl_leavedata.Rows[i].Cells[8].Value = dt.Rows[i][8];
                tbl_leavedata.Rows[i].Cells[9].Value = dt.Rows[i][9];
                tbl_leavedata.Rows[i].Cells[10].Value = dt.Rows[i][10];
            }
            for (int i = 0; i < tbl_leavedata.RowCount; i++)
            {
                if (int.Parse(tbl_leavedata.Rows[i].Cells[5].Value.ToString()) == 1)
                {
                    tbl_leavedata.Rows[i].Cells[5].Value = "T";
                }
                else
                {
                    tbl_leavedata.Rows[i].Cells[5].Value = "F";
                }

                if (int.Parse(tbl_leavedata.Rows[i].Cells[6].Value.ToString()) == 1)
                {
                    tbl_leavedata.Rows[i].Cells[6].Value = "T";
                }
                else
                {
                    tbl_leavedata.Rows[i].Cells[6].Value = "F";
                }
            }
        }


        public Boolean checkforduplicate()
        {
            Boolean sucess = true;
            for (int i = 0; i < tbl_leavedata.RowCount; i++)
            {
                if (tbl_leavedata.Rows[i].Cells[1].Value.ToString().Trim() == txt_leavename.Text.Trim())
                {
                    sucess = false;
                }
                else
                {
                    sucess = true;
                }

            }
            return sucess;
        }


        public Boolean checkforduplicateLeaveCode()
        {
            Boolean sucess = true;
            for (int i = 0; i < tbl_leavedata.RowCount; i++)
            {
                if (tbl_leavedata.Rows[i].Cells[8].Value.ToString().Trim() == txt_leaveCode .Text.Trim())
                {
                    sucess = false;
                }
                else
                {
                    sucess = true;
                }

            }
            return sucess;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            clearcontrol();

        }



        public Boolean NumberValidation(object sender, KeyPressEventArgs e)
        {
            Boolean VALID = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46)
            {
                VALID = false;
            }
            else
            {
                VALID = true;
            }
            return VALID;
        }

        private void txt_enhasableDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Number as Days";
                txt_enhasableDays.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }



        private void txt_enhasableDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_enhasableDays.Text);
            }
            catch (Exception )
            {

                lblStatus.Text = "Enter Valid Number as Days Again";
                txt_enhasableDays.Text = "0";
            }
        }

        private void tbl_leavedata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_leavedata.SelectedRows.Count != 0)
            {

                int rowno = e.RowIndex;
                int columnno = e.ColumnIndex;
                lbl_leavepk.Text = tbl_leavedata.Rows[rowno].Cells[0].Value.ToString();
                txt_leavename.Text = tbl_leavedata.Rows[rowno].Cells[1].Value.ToString();
                rht_description.Text = tbl_leavedata.Rows[rowno].Cells[2].Value.ToString();
                cmb_calculationtype.Text = tbl_leavedata.Rows[rowno].Cells[3].Value.ToString();
                txt_enhasableDays.Text = tbl_leavedata.Rows[rowno].Cells[4].Value.ToString();
                txt_allowedLeave.Text = tbl_leavedata.Rows[rowno].Cells[7].Value.ToString();
                txt_leaveCode.Text = tbl_leavedata.Rows[rowno].Cells[8].Value.ToString();
                cmb_consider.Text = tbl_leavedata.Rows[rowno].Cells[9].Value.ToString();
                cmb_calculateUpto .Text = tbl_leavedata.Rows[rowno].Cells[10].Value.ToString();
                if (tbl_leavedata.Rows[rowno].Cells[5].Value.ToString() == "F")
                {
                    rbt_isformale.Checked = false;
                    rbt_notformale.Checked = true;
                }
                else
                {
                    rbt_isformale.Checked = true;
                    rbt_notformale.Checked = false;
                }

                if (tbl_leavedata.Rows[rowno].Cells[5].Value.ToString() == "F")
                {
                    rbt_isforwomen.Checked = false;
                    rbt_notforwomen.Checked = true;
                }
                else
                {
                    rbt_isforwomen.Checked = true;
                    rbt_notforwomen.Checked = false;
                }

                if (tbl_leavedata.Rows[rowno].Cells[4].Value.ToString() == "0")
                {
                    rbt_notEnhasable.Checked = true;
                    rbt_isenchasable.Checked = false;
                }
                else
                {
                    rbt_notEnhasable.Checked = false;
                    rbt_isenchasable.Checked = true;
                }

                btn_Save.Text = "Edit";
                grp_leave.Enabled = false;
            }


        }
        public void clearcontrol()
        {
            txt_enhasableDays.Text = "0";
            txt_leavename.Text = "";
            rht_description.Text = "";
            lblStatus.Text = "";
            btn_Save.Text = "Save";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_allowedLeave .Text);
                
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Number as DaysAllowed Under Leave";
                txt_allowedLeave.Text = "0";
            }
        }

        private void txt_allowedLeave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Number as Days";
                txt_allowedLeave.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

     

       
    }
}

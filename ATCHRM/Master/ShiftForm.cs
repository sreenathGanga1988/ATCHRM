using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM
{
    public partial class ShiftForm : Form
    {
        Datalayer.ShiftDataBean shftdatabean = null;
        Transactions.ShiftTransaction shfttransaction = null;
        Datalayer.ShiftBreakDataBean shftbrkdatabean = null;
        public ShiftForm()
        {
            InitializeComponent();
            shfttransaction = new Transactions.ShiftTransaction();
            datagriddesign();
            filldata();
        }

        public void datagriddesign()
        {
            tbl_leave.Columns.Add("1", "SL");
            tbl_leave.Columns.Add("2", "ShiftName");
            tbl_leave.Columns.Add("3", " Swipe in ");
            tbl_leave.Columns.Add("4", "Swipe Out");
            tbl_leave.Columns.Add("5", "Shift Duration");
            tbl_leave.Columns.Add("6", "Breaks No");
            tbl_leave.Columns.Add("7", "Allowed Break");
            tbl_leave.RowTemplate.Height = 18;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = int.Parse(cmb_NoofBreak.Text.ToString());
            switch (i)
            {
                case 1:
                    txt_BreakName1.Visible = true;
                    txt_duration1.Visible = true;
                    label6.Visible = true;
                    label5.Visible = true;


                    txt_duration2.Visible = false;
                    txt_Breakname2.Visible = false;
                    txt_breakName3.Visible = false;
                    txt_duration3.Visible = false;
                    txt_BreakName4.Visible = false;
                    txt_duration4.Visible = false;

                    label10.Visible = false;
                    label19.Visible = false;
                    label9.Visible = false;
                    label20.Visible = false;
                    label11.Visible = false;
                    label18.Visible = false;

                    break;
                case 2:
                    txt_BreakName1.Visible = true;
                    txt_duration1.Visible = true;
                    txt_duration2.Visible = true;
                    txt_Breakname2.Visible = true;
                    label6.Visible = true;
                    label5.Visible = true;
                    label11.Visible = true;
                    label18.Visible = true;

                    txt_breakName3.Visible = false;
                    txt_duration3.Visible = false;
                    txt_BreakName4.Visible = false;
                    txt_duration4.Visible = false;

                    label10.Visible = false;
                    label19.Visible = false;
                    label9.Visible = false;
                    label20.Visible = false;

                    break;
                case 3:
                    txt_BreakName1.Visible = true;
                    txt_duration1.Visible = true;
                    txt_duration2.Visible = true;
                    txt_Breakname2.Visible = true;
                    txt_breakName3.Visible = true;
                    txt_duration3.Visible = true;

                    label6.Visible = true;
                    label5.Visible = true;
                    label11.Visible = true;
                    label18.Visible = true;
                    label10.Visible = true;
                    label19.Visible = true;

                    txt_BreakName4.Visible = false;
                    txt_duration4.Visible = false;

                    label9.Visible = false;
                    label20.Visible = false;

                    break;
                case 4:
                    txt_BreakName1.Visible = true;
                    txt_duration1.Visible = true;
                    txt_duration2.Visible = true;
                    txt_Breakname2.Visible = true;
                    txt_breakName3.Visible = true;
                    txt_duration3.Visible = true;
                    txt_BreakName4.Visible = true;
                    txt_duration4.Visible = true;
                    label6.Visible = true;
                    label5.Visible = true;
                    label11.Visible = true;
                    label18.Visible = true;
                    label10.Visible = true;
                    label19.Visible = true;
                    label9.Visible = true;
                    label20.Visible = true;

                    break;
                default:
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Out of range !!");
                    break;

            }
        }
        /// <summary>
        /// validates the controls
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean validationControl()
        {
            Boolean sucess = false;
            if (txt_ShiftName.Text == null || txt_ShiftName.Text.Trim() == "")
            {
                lbltstatus.Text = "Enter the Shift Name";
                txt_ShiftName.Focus();

            }

            else if (cmb_NoofBreak.Text == null || cmb_NoofBreak.Text.Trim() == "")
            {
                lbltstatus.Text = "Enter the Number of Breaks";
                cmb_NoofBreak.Focus();
            }
            else if (subValidation() == false)
            {
                sucess = false;
            }

            else
            {
                sucess = true;
            }
            return sucess;
        }

        /// <summary>
        /// validates the breaks
        /// against num of breaks
        /// </summary>
        /// <returns></returns>
        public Boolean subValidation()
        {
            Boolean sucess = true;

            if (cmb_NoofBreak.Text == "1")
            {

                if (txt_BreakName1.Text == null || txt_BreakName1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 1 ";
                    txt_BreakName1.Focus();
                    sucess = false;

                }
                else if (txt_duration1.Text == null || txt_duration1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 1  ";
                    txt_duration1.Focus();
                    sucess = false;

                }


            }

            if (cmb_NoofBreak.Text == "2")
            {

                if (txt_BreakName1.Text == null || txt_BreakName1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 1 ";
                    txt_BreakName1.Focus();
                    sucess = false;

                }
                else if (txt_duration1.Text == null || txt_duration1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 1  ";
                    txt_duration1.Focus();
                    sucess = false;

                }
                else if (txt_Breakname2.Text == null || txt_Breakname2.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 2 ";
                    txt_Breakname2.Focus();
                    sucess = false;

                }
                else if (txt_duration2.Text == null || txt_duration2.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 2 ";
                    txt_duration2.Focus();
                    sucess = false;

                }


            }

            if (cmb_NoofBreak.Text == "3")
            {
                if (txt_BreakName1.Text == null || txt_BreakName1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 1 ";
                    txt_BreakName1.Focus();
                    sucess = false;

                }
                else if (txt_duration1.Text == null || txt_duration1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 1  ";
                    txt_duration1.Focus();
                    sucess = false;

                }
                else if (txt_Breakname2.Text == null || txt_Breakname2.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 2 ";
                    txt_Breakname2.Focus();
                    sucess = false;

                }
                else if (txt_duration2.Text == null || txt_duration2.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 2 ";
                    txt_duration2.Focus();
                    sucess = false;

                }

                else if (txt_breakName3.Text == null || txt_breakName3.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 3";
                    txt_breakName3.Focus();
                    sucess = false;

                }
                else if (txt_duration3.Text == null || txt_duration3.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration  3";
                    txt_duration3.Focus();
                    sucess = false;

                }


            }
            if (cmb_NoofBreak.Text == "4")
            {

                if (txt_BreakName1.Text == null || txt_BreakName1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 1 ";
                    txt_BreakName1.Focus();
                    sucess = false;

                }
                else if (txt_duration1.Text == null || txt_duration1.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 1  ";
                    txt_duration1.Focus();
                    sucess = false;

                }
                else if (txt_Breakname2.Text == null || txt_Breakname2.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 2 ";
                    txt_Breakname2.Focus();
                    sucess = false;

                }
                else if (txt_duration2.Text == null || txt_duration2.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 2 ";
                    txt_duration2.Focus();
                    sucess = false;

                }

                else if (txt_breakName3.Text == null || txt_breakName3.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name 3";
                    txt_breakName3.Focus();
                    sucess = false;

                }
                else if (txt_duration3.Text == null || txt_duration3.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration  3";
                    txt_duration3.Focus();
                    sucess = false;

                }

                else if (txt_BreakName4.Text == null || txt_BreakName4.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Break Name4";
                    txt_BreakName4.Focus();
                    sucess = false;

                }
                else if (txt_duration4.Text == null || txt_duration4.Text.Trim() == "")
                {
                    lbltstatus.Text = "Enter Duration 4";
                    txt_duration4.Focus();
                    sucess = false;

                }


            }




            return sucess;

        }

        /// <summary>
        /// fetch data from controls for the shiftmaster
        /// </summary>
        /// <returns></returns>
        public Datalayer.ShiftDataBean fetchdata()
        {
            shftdatabean = new Datalayer.ShiftDataBean();
            shftdatabean.ShiftName1 = txt_ShiftName.Text;
            shftdatabean.Startofshift = dtp_FromTime.Value.TimeOfDay;
            shftdatabean.Endofshift = dtp_toTime.Value.TimeOfDay;
            shftdatabean.NoOfBreak = int.Parse(cmb_NoofBreak.Text);
            shftdatabean.Starttime = dtp_FromTime.Value;
            shftdatabean.EndTime = dtp_toTime.Value;
            shftdatabean.ShftDuration1 = calculateduration();

            return shftdatabean;


            //shftdatabean.Starttime = new TimeSpan (dtp_FromTime.Value.TimeOfDay) ;
            //shftdatabean.EndTime = dtp_FromTime.Value.TimeOfDay ;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.Text == "Save")
            {
                if (validationControl())
                {

                    shfttransaction = new Transactions.ShiftTransaction();
                    shfttransaction.insertShiftMasterData(fetchdata());

                    DataTable dt = shfttransaction.getsShiftByName(txt_ShiftName.Text, dtp_FromTime.Value.TimeOfDay, dtp_toTime.Value.TimeOfDay);
                    fetchbreakdata(int.Parse(dt.Rows[0][0].ToString()));
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done Details");
                    filldata();
                    clearcontrols();
                }
            }
            else if (btn_Save.Text == "Update")
            {

                updatefetchdata();
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Shift Details  Updated ");
                clearcontrols();
            }
            else if (btn_Save.Text == "Edit")
            {
                btn_Save.Text = "Update";
                pnl_shift.Enabled = true;
                btn_Save.Enabled = true;
            }
        }

       

        /// <summary>
        /// clculates the shift duration
        /// </summary>
        /// <returns></returns>
        public TimeSpan calculateduration()
        {
            TimeSpan swipein = dtp_FromTime.Value.TimeOfDay;
            TimeSpan swipeout = dtp_toTime.Value.TimeOfDay;
            TimeSpan duration;
            if (swipeout >= swipein)
            {
                duration = swipeout - swipein;
            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("As per your Current Swipe Times This is a Night Shift");
                duration = swipeout + new TimeSpan(1, 0, 0, 0) - swipein;
            }

             ATCHRM.Controls.ATCHRMMessagebox.Show("Shift Duration = " + duration.ToString());

            return duration;
        }
        /// <summary>
        /// fetch break data from the control and insert that data 
        /// </summary>
        /// <param name="shftpk"></param>
        public void fetchbreakdata(int shftpk)
        {
            try
            {
                if (cmb_NoofBreak.Text == "1")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);


                }

                else if (cmb_NoofBreak.Text == "2")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);


                }

                else if (cmb_NoofBreak.Text == "3")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_breakName3.Text;
                    shftbrkdatabean.Duration1 = txt_duration3.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);


                }

                else if (cmb_NoofBreak.Text == "4")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_breakName3.Text;
                    shftbrkdatabean.Duration1 = txt_duration3.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = shftpk;
                    shftbrkdatabean.Breakname = txt_BreakName4.Text;
                    shftbrkdatabean.Duration1 = txt_duration4.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);
                }

            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
                this.Close();
            }
            finally
            {


            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_duration1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_duration1.Text);
            }
            catch (Exception)
            {

                lbltstatus.Text = "Enter Duration in Minutes";
                txt_duration1.Text = "0";
            }
        }
        private void txt_duration2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_duration2.Text);
            }
            catch (Exception)
            {

                lbltstatus.Text = "Enter Duration in Minutes";
                txt_duration2.Text = "0";
            }
        }

        private void txt_duration3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_duration3.Text);
            }
            catch (Exception)
            {

                lbltstatus.Text = "Enter Duration in Minutes";
                txt_duration3.Text = "0";
            }
        }

        private void txt_duration4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_duration4.Text);
            }
            catch (Exception)
            {

                lbltstatus.Text = "Enter Duration in Minutes";
                txt_duration4.Text = "0";
            }
        }




        public void filldata()
        {

            tbl_leave.DataSource = null;
            using (DataTable dt = shfttransaction.selectallShiftdata())
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tbl_leave.Rows.Add();
                    tbl_leave.Rows[i].Cells[0].Value = dt.Rows[i][0];
                    tbl_leave.Rows[i].Cells[1].Value = dt.Rows[i][1];
                    tbl_leave.Rows[i].Cells[2].Value = dt.Rows[i][2];
                    tbl_leave.Rows[i].Cells[3].Value = dt.Rows[i][3];
                    tbl_leave.Rows[i].Cells[4].Value = dt.Rows[i][5];
                    tbl_leave.Rows[i].Cells[5].Value = dt.Rows[i][4];
                    tbl_leave.Rows[i].Cells[6].Value = dt.Rows[i][6];
                }
            }

        }

        private void tbl_leave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clearcontrols();
            int rowindex = e.RowIndex;
            lblShiftPk.Text = tbl_leave.Rows[rowindex].Cells[0].Value.ToString();
            txt_ShiftName.Text = tbl_leave.Rows[rowindex].Cells[1].Value.ToString();
            dtp_FromTime.Value = DateTime.Parse(tbl_leave.Rows[rowindex].Cells[2].Value.ToString());
            dtp_toTime.Value = DateTime.Parse(tbl_leave.Rows[rowindex].Cells[3].Value.ToString());
            cmb_NoofBreak.SelectedIndex = int.Parse(tbl_leave.Rows[rowindex].Cells[5].Value.ToString()) - 1;

            DataTable dt = shfttransaction.selectallbreakofShift(int.Parse(lblShiftPk.Text));
            int rowcheck = dt.Rows.Count;
            if (rowcheck > int.Parse(cmb_NoofBreak.Text))
            {
                cmb_NoofBreak.SelectedIndex = rowcheck -1;
            }
            else if (rowcheck < int.Parse(cmb_NoofBreak.Text))
            {
                cmb_NoofBreak.SelectedIndex = rowcheck - 1;
            }

            else
            {
                cmb_NoofBreak.SelectedIndex = int.Parse(tbl_leave.Rows[rowindex].Cells[5].Value.ToString()) - 1;
            }
            if (cmb_NoofBreak.Text == "1")
            {
                lpk1.Text = dt.Rows[0][0].ToString();
                txt_BreakName1.Text = dt.Rows[0][1].ToString();
                txt_duration1.Text = dt.Rows[0][3].ToString();
            }

            else if (cmb_NoofBreak.Text == "2")
            {
                lpk1.Text = dt.Rows[0][0].ToString();
                txt_BreakName1.Text = dt.Rows[0][1].ToString();
                txt_duration1.Text = dt.Rows[0][3].ToString();


                lpk2.Text = dt.Rows[1][0].ToString();
                txt_Breakname2.Text = dt.Rows[1][1].ToString();
                txt_duration2.Text = dt.Rows[1][3].ToString();


            }

            else if (cmb_NoofBreak.Text == "3")
            {
                lpk1.Text = dt.Rows[0][0].ToString();
                txt_BreakName1.Text = dt.Rows[0][1].ToString();
                txt_duration1.Text = dt.Rows[0][3].ToString();


                lpk2.Text = dt.Rows[1][0].ToString();
                txt_Breakname2.Text = dt.Rows[1][1].ToString();
                txt_duration2.Text = dt.Rows[1][3].ToString();


                lpk3.Text = dt.Rows[2][0].ToString();
                txt_breakName3.Text = dt.Rows[2][1].ToString();
                txt_duration3.Text = dt.Rows[2][3].ToString();




               
            }


            else if (cmb_NoofBreak.Text == "4")
            {
                lpk1.Text = dt.Rows[0][0].ToString();
                txt_BreakName1.Text = dt.Rows[0][1].ToString();
                txt_duration1.Text = dt.Rows[0][3].ToString();


                lpk2.Text = dt.Rows[1][0].ToString();
                txt_Breakname2.Text = dt.Rows[1][1].ToString();
                txt_duration2.Text = dt.Rows[1][3].ToString();


                lpk3.Text = dt.Rows[2][0].ToString();
                txt_breakName3.Text = dt.Rows[2][1].ToString();
                txt_duration3.Text = dt.Rows[2][3].ToString();


                lpk4.Text = dt.Rows[3][0].ToString();
                txt_BreakName4.Text = dt.Rows[3][1].ToString();
                txt_duration4.Text = dt.Rows[3][3].ToString();
            }

            btn_Save.Text = "Edit";
            pnl_shift.Enabled = false;
        
        }


        /// <summary>
        /// get tyhe break  data from controls
        /// check whether its already entered
        /// if present update it 
        /// else insert it
        ///
        /// </summary>
        public void updatefetchdata()
        {
            shftdatabean = new Datalayer.ShiftDataBean();
            shftdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
            
            shftdatabean.ShiftName1 = txt_ShiftName.Text;
            shftdatabean.Startofshift = dtp_FromTime.Value.TimeOfDay;
            shftdatabean.Endofshift = dtp_toTime.Value.TimeOfDay;
            shftdatabean.NoOfBreak = int.Parse(cmb_NoofBreak.Text);
            shftdatabean.Starttime = dtp_FromTime.Value;
            shftdatabean.EndTime = dtp_toTime.Value;
            shftdatabean.ShftDuration1 = calculateduration();
            shfttransaction.updateShiftMasterData(shftdatabean);  ////shift master updated here 


            if (cmb_NoofBreak.Text == "1")
            {

                if (lpk1.Text != "xxx")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk1.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);
                }

                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                }

            }

            else if (cmb_NoofBreak.Text == "2")
            {
                if (lpk1.Text != "xxx")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk1.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);
                }

                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                }

                if (lpk2.Text != "xxx")
                {

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk2.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);

                }
                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);
                }
            }


            else if (cmb_NoofBreak.Text == "3")
            {

                if (lpk1.Text != "xxx")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk1.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);
                }

                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                }

                if (lpk2.Text != "xxx")
                {

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk2.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);

                }
                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);
                }



                if (lpk3.Text != "xxx")
                {

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_breakName3.Text;
                    shftbrkdatabean.Duration1 = txt_duration3.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk3.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);

                }
                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_breakName3.Text;
                    shftbrkdatabean.Duration1 = txt_duration3.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);
                }
            }


            else if (cmb_NoofBreak.Text == "4")
            {
                if (lpk1.Text != "xxx")
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk1.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);
                }

                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName1.Text;
                    shftbrkdatabean.Duration1 = txt_duration1.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);

                }

                if (lpk2.Text != "xxx")
                {

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk2.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);

                }
                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_Breakname2.Text;
                    shftbrkdatabean.Duration1 = txt_duration2.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);
                }



                if (lpk3.Text != "xxx")
                {

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_breakName3.Text;
                    shftbrkdatabean.Duration1 = txt_duration3.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk3.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);

                }
                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_breakName3.Text;
                    shftbrkdatabean.Duration1 = txt_duration3.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);
                }



                if (lpk4.Text != "xxx")
                {

                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName4.Text;
                    shftbrkdatabean.Duration1 = txt_duration4.Text;
                    shftbrkdatabean.Breakpk = int.Parse(lpk4.Text);
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.updateShiftBreak(shftbrkdatabean);

                }
                else
                {
                    shftbrkdatabean = new Datalayer.ShiftBreakDataBean();
                    shftbrkdatabean.Shiftpk = int.Parse(lblShiftPk.Text);
                    shftbrkdatabean.Breakname = txt_BreakName4.Text;
                    shftbrkdatabean.Duration1 = txt_duration4.Text;
                    shftbrkdatabean.Uom = "Min";
                    shfttransaction.insertShifBreak(shftbrkdatabean);
                }

            }



        }


        public void clearcontrols()
        {
            lpk1.Text = "xxx";
            lpk2.Text = "xxx";
            lpk3.Text = "xxx";
            lpk4.Text = "xxx";
            btn_Save.Text = "Save";
            txt_BreakName1.Text = "";
            txt_Breakname2.Text = "";
            txt_breakName3.Text = "";
            txt_BreakName4.Text = "";
            txt_duration1 .Text = "0";
            txt_duration2 .Text = "0";
            txt_duration3.Text = "0";
            txt_duration4.Text = "0";
            pnl_shift.Enabled = true;
            txt_ShiftName.Text = "";
            lblShiftPk.Text = "";
            cmb_NoofBreak.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearcontrols();
        }

        private void dtp_toTime_ValueChanged(object sender, EventArgs e)
        {

        }

        



    }
}

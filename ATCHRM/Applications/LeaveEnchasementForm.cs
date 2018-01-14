using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class LeaveEnchasementForm : Form
    {
        Transactions.leaveEnchasementTransaction lvencashmenttrans = null;
        Transactions.AnualContractrenewal annul = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.LeaveTransaction lvtransaction = null;
        Transactions.LeaveandAdvanceAppTransaction lveandadvancetrans = null;
        Transactions.AnualContractrenewal annulcntrct = null;
        Transactions.leaveEnchasementTransaction lvenchsemnt = null;
        Transactions.LeaveTrabnsactionCalculator LVTRANSCAL = null;
        Datalayer.LeaveEnchasementAppDatabean lvenchasdatabean = null;
        DataTable subcontract = new DataTable();
        int flag = 0;
        int empflag = 0;
        int cntrctflag = 0;
        int leaveflag = 0;
        int empsubcntrctflag = 0;
        int emppid = 0;
        int leavepk = 0;
        DataTable employelvedetl = null;
        DataTable leaveencashed = null;
        int contractid = 0;
        String subcontractfromdate = null;
        String subcontracttodate = null;
        String currentyear = "";
        int encashedleave = 0;
      
      
        public LeaveEnchasementForm()
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            lveandadvancetrans = new Transactions.LeaveandAdvanceAppTransaction();
            lvtransaction = new Transactions.LeaveTransaction();
            annulcntrct = new Transactions.AnualContractrenewal();
            lvenchsemnt = new Transactions.leaveEnchasementTransaction();
            annul = new Transactions.AnualContractrenewal();
            LVTRANSCAL = new Transactions.LeaveTrabnsactionCalculator();
            lvencashmenttrans = new Transactions.leaveEnchasementTransaction();
          //  dataGridView1.ColumnCount =10;
         //   dataGridView1.Rows.Add();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LevncasetsubForm lvnsubfrm = new LevncasetsubForm();
            lvnsubfrm.MdiParent = this.MdiParent;
            lvnsubfrm.Show();
        }
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";
            cmb_location.SelectedValue = Program.LOCTNPK;
        }

        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }
        private void LeaveEnchasementForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }


        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmb_empcode.DataSource = dt;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag != 0)
            {
                if (Program.UserType == "U")
                {
                    if (int.Parse(cmb_location.SelectedValue.ToString()) != Program.LOCTNPK)
                    {
                         ATCHRM.Controls.ATCHRMMessagebox.Show("You are not allowed to Acess This Location");
                    }
                    else
                    {
                        if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
                        {
                            lblStatus.Text = "Enter the Branch location";

                        }
                        else
                        {
                            employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                        }
                    }
                }
            }
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            flag++;
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag != 0)
            {
                if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter the Branch location";

                }
                else
                {
                    employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                }
            }

        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            flag++;
        }

        private void cmb_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empflag != 0)
            {


                try
                {
                    if (cmb_empcode.Text.Trim() != null && cmb_empcode.Text.Trim() != "")
                    {
                        try
                        {
                            tbl_empdata.DataSource = empreg.getEmployeOldIDandContract(int.Parse(cmb_empcode.SelectedValue.ToString()));
                            getcurrentcontractleave(int.Parse(cmb_empcode.SelectedValue.ToString()));
                            contractload();
                        }
                        catch (Exception)
                        {
                            lblStatus.Text = "Select A Employee ID ";

                        }


                        try
                        {
                            leavecomboLoad();
                        }
                        catch (Exception)
                        {
                            lblStatus.Text = "Select A Leave ";

                        }

                    }
                }
                catch (Exception exp)
                {
                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }
















                //if (cmb_empcode.SelectedValue != null)
                //{
                //    if (cmb_empcode.Text != null || cmb_empcode.Text.Trim() != "")
                //    {
                //        cmb_leaveApp.DataSource = null;
                //        DataTable dt = lveandadvancetrans.getLeaveAppnumFOrEnchasing(int.Parse(cmb_empcode.SelectedValue.ToString()));
                //        cmb_leaveApp.DataSource = dt;
                //        cmb_leaveApp.DisplayMember = "LvAppnum";
                //        cmb_leaveApp.ValueMember = "LeaveAppPk";
                //        leavecomboLoad();
                //    }

                //}


                //try
                //{
                //    emppid = int.Parse(cmb_empcode.SelectedValue.ToString());
                //    leavecomboLoad();
                   contractload();
                //    getcurrentcontractleave();
                //}
                //catch (Exception)
                //{
                    
                   
                //}
            }
          
        }

        private void cmb_empcode_MouseClick(object sender, MouseEventArgs e)
        {
            empflag++;
        }

        public void leavecomboLoad()
        {
            try
            {
                DataTable dt = lvtransaction.getenchashableApplicableleave(int.Parse(cmb_empcode.SelectedValue.ToString()));
                cmb_leave.DataSource = dt;
                cmb_leave.DisplayMember = "LeaveName";
                cmb_leave.ValueMember = "LeavePk";
            }
            catch (Exception)
            {
                
                
            }
        }


        public void calculateencashabledays()
        {

            if (leaveflag != 0)
            {
                double availableleave = 0;



                DataTable dt = new DataTable();



                try
                {
                    int leavepk = int.Parse(cmb_leave.SelectedValue.ToString());
                    int empid = int.Parse(cmb_empcode.SelectedValue.ToString());
                    contractid = int.Parse(cmb_subcontract.SelectedValue.ToString());
                    currentyear = cmb_subcontract.Text.ToString().Trim();
                    DataTable subcontractdata = subcontract.Select("contractid=" + contractid + " and currentyear='" + currentyear + "' ").CopyToDataTable();
                    lbl_subcontractstartdate.Text = subcontractdata.Rows[0]["FromDate"].ToString();
                    lbl_subcontrctenddate.Text = subcontractdata.Rows[0]["ToDate"].ToString();
                    availableleave = LVTRANSCAL.employeeleavecalculatorstarter(empid, leavepk, DateTime.Parse(subcontractdata.Rows[0]["FromDate"].ToString()), DateTime.Parse(subcontractdata.Rows[0]["ToDate"].ToString()));

                    txt_allowedday.Text = availableleave.ToString();
                    employelvedetl = LVTRANSCAL.getallleavetakenbetweenperiod(empid, leavepk, Program.Datetoday);

                    try
                    {
                        encashedleave = lvencashmenttrans.getAllPreviousEnchasementofYear(empid, leavepk, contractid, currentyear);
                        txt_allowedleaves.Text = encashedleave.ToString();
                    }
                    catch (Exception)
                    {
                        txt_allowedleaves.Text = "0";

                    }


                    if (employelvedetl.Rows.Count == 0)
                    {
                        lblStatus.Text = "No Leave of this Type Taken";
                        txt_leavetaken.Text = "0";

                    }
                    else
                    {

                        txt_leavetaken.Text = employelvedetl.Rows.Count.ToString();


                    }

                 

                }
                catch (Exception exp)
                {


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }

            }

        }


        private void cmb_leave_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (leaveflag != 0)
            //    {

            //        if (cmb_leave.Text != null)
            //        {

            //            leavepk = int.Parse(cmb_leave.SelectedValue.ToString());
            //            DataTable dt = lvtransaction.getAllLeaveEnchasableData(int.Parse(cmb_leave.SelectedValue.ToString()));

            //            if (dt.Rows.Count != 0)
            //            {
            //                txt_enchasable.Text = dt.Rows[0][0].ToString();
            //                txt_mode.Text = dt.Rows[0][1].ToString();
            //            }
            //            else
            //            {
            //                txt_enchasable.Text = "0";
            //            }


            //            DataTable dt1 = lvtransaction.getAllLeaveEnchasableData(int.Parse(cmb_leave.SelectedValue.ToString()));

            //            if (dt1.Rows.Count != 0)
            //            {
            //                txt_enchasable.Text = dt1.Rows[0][0].ToString();
            //            }
            //            else
            //            {
            //                txt_enchasable.Text = "0";
            //            }

            //            dayscalculator(DateTime.Parse(lbl_FrmDate.Text), DateTime.Parse(lbl_todate.Text));


            //            calculateleaveleft();
            //        }

            //    }
            //}
            //catch (Exception)
            //{
                
                
            //}
        }

        private void cmb_leave_MouseClick(object sender, MouseEventArgs e)
        {
            leaveflag++;
        }



        public void contractload()
        {
            DataTable dt = new DataTable();
            dt= annulcntrct.GetAllContractOfAnEmployee (int.Parse (cmb_empcode.SelectedValue.ToString ()));
                    
           





            Cmb_contract .DataSource =dt;
            Cmb_contract.DisplayMember = "Contractperiod";
            Cmb_contract .ValueMember="Contractid";




        }

        private void Cmb_contract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cntrctflag  != 0)
            {
                loadSubContracts();



            }
        }

        private void Cmb_contract_MouseClick(object sender, MouseEventArgs e)
        {
            if (Cmb_contract.Text != null)
            {
                cntrctflag++;
            }
        }




        public void loadSubContracts()
        {

            subcontract = annulcntrct.getallsubcontract(int.Parse(Cmb_contract.SelectedValue.ToString()));

            cmb_subcontract.DataSource = subcontract;
            cmb_subcontract.DisplayMember = "CurrentYear";
            cmb_subcontract.ValueMember = "Contractid";
        }






        public void fillcontrols()
        {
            double availableleave = 0;
            if (leaveflag != 0)
            {
                int leavepk = int.Parse(cmb_leave.SelectedValue.ToString());
                int empid = int.Parse(cmb_empcode.SelectedValue.ToString());



                availableleave = LVTRANSCAL.employeeleavecalculatorstarter(empid, leavepk);

                txt_allowedleaves.Text = availableleave.ToString();
                employelvedetl = LVTRANSCAL.getallleavetakenbetweenperiod(empid, leavepk, Program.Datetoday);

                try
                {
                    encashedleave = lvencashmenttrans.getAllPreviousEnchasementofYear(empid, leavepk, contractid, currentyear);
                    txt_Enchaseddays.Text = encashedleave.ToString();
                }
                catch (Exception)
                {
                    txt_Enchaseddays.Text = "0";

                }


                if (employelvedetl.Rows.Count == 0)
                {
                    lblStatus.Text = "No Leave of this Type Taken";
                    txt_leavetaken.Text = "0";

                }
                else
                {

                    txt_leavetaken.Text = employelvedetl.Rows.Count.ToString();


                }


                txt_daysLeft.Text = (int.Parse(txt_allowedday.Text) - int.Parse(txt_Enchaseddays.Text)).ToString();
            }
        }

        private void cmb_subcontract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empsubcntrctflag != 0)
            {

                
                calculateencashabledays();
                fillcontrols();

            }
        }

        private void cmb_subcontract_MouseClick(object sender, MouseEventArgs e)
        {
         
            empsubcntrctflag++;
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationControl())
                {

                    lvenchasdatabean = new Datalayer.LeaveEnchasementAppDatabean();


                    lvenchasdatabean.Empid = int.Parse(cmb_empcode.SelectedValue.ToString());
                    lvenchasdatabean.Contractid = int.Parse(Cmb_contract.SelectedValue.ToString());
                    lvenchasdatabean.Leavepk = int.Parse(cmb_leave.SelectedValue.ToString());
                    lvenchasdatabean.Currentyear = cmb_subcontract.Text;
                    lvenchasdatabean.Enchaseduration = int.Parse(txtDays.Text);
                    lvenchasdatabean.Durationtype = cmb_daytype.Text;


                    if (lvenchasdatabean != null)
                    {
                         ATCHRM.Controls.ATCHRMMessagebox.Show(lvenchsemnt.Insertleaveenchasementapplication(lvenchasdatabean) + " Done ");

                    }

                }

            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                //         ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (cmb_empcode.Text == null || cmb_empcode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid EmployeCode";
                cmb_empcode.Focus();
                cmb_empcode.Visible = true;
            }
            else if (cmb_leave.Text == null || cmb_leave.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Leave Type";
                cmb_leave.Focus();
                cmb_leave.Visible = true;
            }
            else if (Cmb_contract.Text == null || Cmb_contract.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Contract Period";
                Cmb_contract.Focus();
                Cmb_contract.Visible = true;
            }
            else if (cmb_subcontract.Text == null || cmb_subcontract.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Sub Contract Period";
                cmb_subcontract.Focus();
                cmb_subcontract.Visible = true;
            }
            else if (txtDays.Text == null || txtDays.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  Duration ";
                txtDays.Focus();
                txtDays.Visible = true;
            }

                
            else if (cmb_daytype.Text == null || cmb_daytype.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  CalculationMode ";
                cmb_daytype.Focus();
                cmb_daytype.Visible = true;
            }



            else if (int.Parse(txtDays.Text) > int.Parse(txt_daysLeft.Text))
            {
                lblStatus.Text = "You are not Allowed to Exeed the Allowed Number of Days ";
                txtDays.Focus();
                txtDays.Visible = true;
            }
            else
            {
                sucess = true;
            }

            return sucess;

        }



        public void getcurrentcontractleave(int empid)
        {

            DataTable contractdata = annul.getCurrentSubContract(empid);
            if (contractdata.Rows.Count != 0)
            {
                contractid = int.Parse(contractdata.Rows[0][0].ToString());
                currentyear = contractdata.Rows[0][1].ToString();
                subcontractfromdate = DateTime.Parse(contractdata.Rows[0][2].ToString()).ToString("dd-MM-yyyy");
                subcontracttodate = DateTime.Parse(contractdata.Rows[0][3].ToString()).ToString("dd-MM-yyyy");
                lbl_joiningdate.Text = DateTime.Parse(contractdata.Rows[0][4].ToString()).ToString("dd-MM-yyyy");
                txt_currentyear.Text = currentyear;
                lbl_FrmDate.Text = subcontractfromdate.ToString();
                lbl_todate.Text = subcontracttodate.ToString();
            }
        }



        public void getcurrentcontractleave()
        {

            DataTable contractdata = annul.getallsubcontract (int.Parse (Cmb_contract.SelectedValue.ToString ()));
            if (contractdata.Rows.Count != 0)
            {
                txt_currentyear.Text = contractdata.Rows[0][1].ToString();

                lbl_FrmDate.Text = DateTime.Parse(contractdata.Rows[0][2].ToString()).ToString("dd-MM-yyyy");
                lbl_todate.Text = DateTime.Parse(contractdata.Rows[0][3].ToString()).ToString("dd-MM-yyyy");


            }
        }



        public void dayscalculator(DateTime frmdate, DateTime todate)
        {

            double dt = (todate - frmdate).TotalDays;
            DateTime thisYear = new DateTime(frmdate.Year, 1, 1);
            DateTime nextYear = new DateTime(todate.Year + 1, 1, 1);
            double totaldays = (nextYear - thisYear).Days;

            double month = dt / 30;
            lblMonth.Text = Math.Truncate(month).ToString();



            if (txt_mode.Text == "Days Per Year")
            {

                int okleeave = (int.Parse(txt_allowedleaves.Text) / 12) * int.Parse(lblMonth.Text);
                txt_allowedleaves.Text = okleeave.ToString();
            }
        }

        private void txt_enchasable_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Enchaseddays_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    


        public void calculateleaveleft()
        {
            DataTable employelvedetl = LVTRANSCAL.getallleavetakenbetweenperiod(emppid , leavepk, Program.Datetoday);
             if (employelvedetl.Rows.Count == 0)
                {
                    
                    txt_leavetaken.Text = "0";

                }
                else
                {

                    txt_leavetaken.Text = employelvedetl.Rows.Count.ToString();


                }
            int leaveleft = int.Parse(txt_allowedleaves.Text) - int.Parse(txt_Enchaseddays.Text) - int.Parse(txt_leavetaken.Text);
            txt_daysLeft.Text = leaveleft.ToString();
        }
    }
}

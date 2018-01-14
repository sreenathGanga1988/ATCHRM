using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace ATCHRM.Applications
{
    public partial class OVertimeApplicationMaster : Form
    {
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.OvertimeandShiftTransaction ovttrans = null;
        Datalayer.OvertimeApplicationDatabean ovtdatabean = null;
        Transactions.HolidayTransaction hldytransaction = null;
        Transactions.Helper hlpr = null;
        DataTable employedata = null;
        DataTable dTable = new DataTable();
        int deptflag = 0;
        int desgflag = 0;
        int empflag = 0;
        int leaveemp = 0;
        int lhemployee = 0;
        ArrayList leaveaaray = new ArrayList();
        ArrayList lhaaray = new ArrayList();
        public OVertimeApplicationMaster()
        {
            InitializeComponent();
            tbl_Abscent.RowTemplate.Height = 18;
            depttrans = new Transactions.DepartmentTransaction();
            empreg = new Transactions.EmployeeRegTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            ovttrans = new Transactions.OvertimeandShiftTransaction();
            hldytransaction = new Transactions.HolidayTransaction();
            
            hlpr = new Transactions.Helper();
            gridviewsetup();
            DeptcomboLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            applyuaction();

               
            string Showmessage = tbl_Abscent.SelectedRows.Count.ToString ();

            lblStatus.Text = Showmessage;
        }

        /// <summary>
        /// when the submit application button is clicked
        /// </summary>
        public void OnSubmitbuttonClick()
        {

            dTable = new DataTable();
            DataColumn auto = new DataColumn("EmpID", typeof(System.Int32));
            dTable.Columns.Add(auto);

            DataColumn name = new DataColumn("OT", typeof(string));
            dTable.Columns.Add(name);


            DataColumn endtime = new DataColumn("EndTime", typeof(String));
            dTable.Columns.Add(endtime);


            DataColumn otdate = new DataColumn("OTDate", typeof(String));
            dTable.Columns.Add(otdate);
            DataColumn ottype = new DataColumn("Ottype", typeof(string));
            dTable.Columns.Add(ottype);
            DataRow row = null;

            DataColumn otamount = new DataColumn("otamount", typeof(float ));
            dTable.Columns.Add(otamount);

            if (ValidationControl())
            {

                DialogResult dialogResult = MessageBox.Show("Confirm  OT Application For " + hlpr.calculateselected(tbl_Abscent).ToString() + " Employees And OT Expense " + calculatetotal() + "", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                ovtdatabean = new Datalayer.OvertimeApplicationDatabean();

                ovtdatabean.Deptpk = int.Parse(cmb_dept.SelectedValue.ToString());
                ovtdatabean.Duration1 = int.Parse(txtduration.Text);
                ovtdatabean.Reason = rht1_reason.Text;
                ovtdatabean.Otdate1 = dtp_Otdate.Value.Date;
                ovtdatabean.BranchPK1 = Program.LOCTNPK;
                for (int i = 0; i < tbl_Abscent.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_Abscent.Rows[i].Cells[0].Value) == true)
                    {

                        row = dTable.NewRow();
                 row["EmpID"] = int.Parse(tbl_Abscent.Rows[i].Cells[1].Value.ToString());
                        row["OT"] = int.Parse(tbl_Abscent.Rows[i].Cells[10].Value.ToString());
                        row["EndTime"] = TimeSpan.Parse(tbl_Abscent.Rows[i].Cells[12].Value.ToString());
                        row["OTDate"] = dtp_Otdate.Value.Date.ToString();
                        row["Ottype"] = tbl_Abscent.Rows[i].Cells[11].Value.ToString();
                        row["otamount"] = float .Parse( tbl_Abscent.Rows[i].Cells[13].Value.ToString());
                        dTable.Rows.Add(row);

                    }
                }


                ovtdatabean.Empadded = dTable;




                if (ovtdatabean != null)
                {
                    String OtAppnum = ovttrans.insertOTApplication(ovtdatabean);

                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done OT Application    " + OtAppnum);
                    DeptcomboLoad();
                }




            }


            }







        }



        public void employeelistload()
        {

            if (cmb_dept.SelectedValue != null)
            {

                if (cmb_designation.SelectedValue != null)
                {
                    employecodeload(Program.LOCTNPK, int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
                }
                else
                {
                    employecodeload(Program.LOCTNPK, int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                }




            }


        }


        public void DeptcomboLoad()
        {
            cmb_dept.DataSource = hlpr.GetComboBoxedDataTable(depttrans.getDeptName(),
     "DepartmentPK", "DepartmentName", "0", "ALL DEPT");
         //   cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }
        /// <summary>
        /// calculate the total amount for the OT application
        /// </summary>
        /// <returns></returns>
        public float  calculatetotal()
        {
            float sum = 0;
            for (int i = 0; i < tbl_Abscent.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Abscent.Rows[i].Cells[0].Value) == true)
                { 
                sum= sum + float.Parse (tbl_Abscent.Rows[i].Cells[13].Value.ToString ());
                }
            }

            return sum;
        }






        public void viewAbcentiesandLH()
        {
            for (int i = 0; i < tbl_Abscent.Rows.Count; i++)
            {
              //  ArrayList leaveaaray = new ArrayList();
              //  ArrayList lhaaray = new ArrayList();
                if (Convert.ToBoolean(tbl_Abscent.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_Abscent.Rows[i].Cells[14].Value != null)
                    {
                        if (tbl_Abscent.Rows[i].Cells[14].Value.ToString() == "A")
                        {
                            leaveemp++;
                            leaveaaray.Add(tbl_Abscent.Rows[i].Cells[2].Value.ToString());
                        }
                        else if (tbl_Abscent.Rows[i].Cells[14].Value.ToString() == "LH")
                        {
                            lhemployee++;
                            lhaaray.Add(tbl_Abscent.Rows[i].Cells[2].Value.ToString());
                        }
                    }
                }
            }

        }

        public void applyuaction()
        {
            for (int i = 0; i < tbl_Abscent.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Abscent.Rows[i].Cells[0].Value) == true)
                {

                    float f = ovttrans.getOTrateofanemployee(int.Parse(tbl_Abscent.Rows[i].Cells[1].Value.ToString()));


              //      tbl_Aplication.Rows[i].Cells[13].Value = f;

                    tbl_Abscent.Rows[i].Cells[10].Value = txtduration.Text;

                    //
                    //TimeSpan tm = new TimeSpan(tbl_Aplication.Rows[i].Cells[9].Value.ToString());

                    DateTime dt = DateTime.Parse(tbl_Abscent.Rows[i].Cells[9].Value.ToString());

                    TimeSpan endtime = dt.TimeOfDay + TimeSpan.FromMinutes(int.Parse(txtduration.Text));

              
                    tbl_Abscent.Rows[i].Cells[12].Value = endtime;

                    if (tbl_Abscent.Rows[i].Cells[7].Value.ToString() == "Off Day")
                    {
                        tbl_Abscent.Rows[i].Cells[11].Value = "OT2.0";
                        tbl_Abscent.Rows[i].Cells[13].Value = ((f/60)*2)*int.Parse (tbl_Abscent.Rows[i].Cells[10].Value.ToString ());
                    }
                    else
                    {
                        tbl_Abscent.Rows[i].Cells[11].Value = "OT1.5";
                        tbl_Abscent.Rows[i].Cells[13].Value = ((f / 60) * 1.5) * int.Parse(tbl_Abscent.Rows[i].Cells[10].Value.ToString());
                    }


                    tbl_Abscent.Rows[i].Cells[14].Value = ovttrans.checkwhetherAnEmployyeisPresent(dtp_Otdate.Value.Date,int.Parse(tbl_Abscent.Rows[i].Cells[1].Value.ToString()));
                
                
                }
          
            
            
            
            }
            if (tbl_Abscent.SelectedRows.Count != 0)
            {
                btn_apply.Enabled = true;
            }

        }


        /// <summary>
        /// get all designation against department
        /// </summary>
        public void getallDesignation()
        {
            if (cmb_dept.SelectedValue != null)
            {






                cmb_designation.DataSource = null;
               DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_dept.SelectedValue.ToString()));

               DataTable dt1 = hlpr.GetComboBoxedDataTable(dt,
     "SL", "DESGN", "0", "ALL DESG");

                cmb_designation.DisplayMember = "DESGN";
                cmb_designation.ValueMember = "SL";
             cmb_designation.DataSource = dt1;


             filldatagrid(getemployeedata());
            }
        }


        /// <summary>
        /// chek whether it is a holiday
        /// or off day and if yes make it to OT 1.5
        /// </summary>
        public void getOTTYPE()
        {
            DataTable dt = hldytransaction.getAnyHolidayofaDate(dtp_Otdate.Value.Date, Program.LOCTNPK);

            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    lbl_daystatus.Text = dt.Rows[0][0].ToString();
                    lbl_otType.Text = "OT 2";
                    lbl_daystatus.Visible = true;
                    lbl_otType.Visible = true;
                    lbl_daystatus.ForeColor = Color.BlanchedAlmond;
                    lbl_daystatus.ForeColor = Color.BurlyWood;
                }
                else
                {
                    lbl_daystatus.Text = "Working Day";
                    lbl_otType.Text = "OT 1.5";
                    lblStatus.Visible = true;
                    lbl_daystatus.Visible = true;
                    lbl_otType.Visible = true;
                    lbl_daystatus.ForeColor = Color.Firebrick;
                    lbl_daystatus.ForeColor = Color.Chartreuse;
                }
            }
            else
            {
                lbl_daystatus.Text = "Working Day";
                lbl_otType.Text = "OT 2";
            }

            lbl_day.Text = dtp_Otdate.Value.DayOfWeek.ToString();
        }


        public void gridviewsetup()
        {
            tbl_Abscent.Columns.Add("1", "Empid");
            tbl_Abscent.Columns.Add("2", "Emp no");
            tbl_Abscent.Columns.Add("3", "Emp Name");
            tbl_Abscent.Columns.Add("4", "Department ");
            tbl_Abscent.Columns.Add("5", "Designation");
            tbl_Abscent.Columns.Add("6", "Shift");
            tbl_Abscent.Columns.Add("7", "Day Status");
            tbl_Abscent.Columns.Add("8", "Start Time");

            tbl_Abscent.Columns.Add("9", "End Time");
            tbl_Abscent.Columns.Add("10", "OT");
            tbl_Abscent.Columns.Add("11", "OT Type");
            tbl_Abscent.Columns.Add("12", "Reversed Swipe Out");
            tbl_Abscent.Columns.Add("13", "Rate");
            tbl_Abscent.Columns.Add("14", "In Status");
            tbl_Abscent.Columns.Add("15", "Old Empid");
            tbl_Abscent.Columns[0].ReadOnly = false;
            tbl_Abscent.Columns[1].ReadOnly = true;
            tbl_Abscent.Columns[2].ReadOnly = true;
            tbl_Abscent.Columns[3].ReadOnly = true;
            tbl_Abscent.Columns[4].ReadOnly = true;
            tbl_Abscent.Columns[5].ReadOnly = true;
            tbl_Abscent.Columns[6].ReadOnly = true;
            tbl_Abscent.Columns[7].ReadOnly = true;
            tbl_Abscent.Columns[8].ReadOnly = true;
            tbl_Abscent.Columns[9].ReadOnly = true;
            tbl_Abscent.Columns[10].ReadOnly = true;
            tbl_Abscent.Columns[9].ReadOnly = true;
            tbl_Abscent.Columns[10].ReadOnly = true;
            //tbl_Aplication.RowTemplate.Height = 18;

            tbl_Abscent.Columns[1].Visible = false;

            tbl_Abscent.Columns[5].Visible = true;


        }



        public DataTable  getemployeedata()
        {

            if (cmb_dept.Text.Trim() == "")
            {
                employedata = empreg.getallemployeeshiftdetails(0, Program.LOCTNPK, lbl_day.Text);

            }

            else
            {
                employedata = empreg.getallemployeeshiftdetails(int.Parse(cmb_dept.SelectedValue.ToString()), Program.LOCTNPK, lbl_day.Text);
                // tbl_Aplication.DataSource = employedata.DefaultView;
            }
            return employedata;
        }

        /// <summary>
        /// fill the datagrid controls
        /// </summary>
        public void filldatagrid(DataTable employedata)
        {







            DataView dv = new DataView(employedata);
            dv.RowFilter = "IsOtApplicable='Y'"; // query example = "id = 10"


            employedata = dv.ToTable();

            tbl_Abscent.Rows.Clear();
            tbl_Abscent.DataSource = null;
            for (int i = 0; i < employedata.Rows.Count; i++)
            {

                tbl_Abscent.Rows.Add();
                tbl_Abscent.Rows[i].Cells[1].Value = employedata.Rows[i][0];

                tbl_Abscent.Rows[i].Cells[2].Value = employedata.Rows[i][1];
                tbl_Abscent.Rows[i].Cells[3].Value = employedata.Rows[i][2];
                tbl_Abscent.Rows[i].Cells[4].Value = employedata.Rows[i][3];
                tbl_Abscent.Rows[i].Cells[5].Value = employedata.Rows[i][4];
                tbl_Abscent.Rows[i].Cells[6].Value = employedata.Rows[i][5];
                tbl_Abscent.Rows[i].Cells[7].Value = employedata.Rows[i][6];
                tbl_Abscent.Rows[i].Cells[8].Value = employedata.Rows[i][7];
                tbl_Abscent.Rows[i].Cells[9].Value = employedata.Rows[i][8];
                tbl_Abscent.Rows[i].Cells[10].Value = 0;
                tbl_Abscent.Rows[i].Cells[11].Value = "NA";
                tbl_Abscent.Rows[i].Cells[12].Value = employedata.Rows[i][8];
                tbl_Abscent.Rows[i].Cells[15].Value = employedata.Rows[i][10];
            }
        }

        /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (cmb_dept.Text == null || cmb_dept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Department";
                cmb_dept.Focus();
                lbl_Companyname.Visible = true;
            }
            else if (txtduration.Text == null || txtduration.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Duration";
                txtduration.Focus();
                lbl_CompanyCode.Visible = true;
            }
            else if (rht1_reason.Text == null || rht1_reason.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Reason ";
                rht1_reason.Focus();
                lbl_Adress1.Visible = true;
            }

            else if (checkswipedate() == false)
            {
                lblStatus.Text = " Excess Overtime  Applied";
                rht1_reason.Focus();
                lbl_CompanyCode.Visible = true;

            }


            else
            {





                sucess = true;
            }

            return sucess;

        }

        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);


            DataTable dt1 = hlpr.GetComboBoxedDataTable(dt,
  "empid", "empno", "0", "ALL EMP");
            cmb_empcode.DataSource = dt1;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
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

        public Boolean checkswipedate()
        {
            Boolean sucess = false;
            int flagcount = 0;
            for (int i = 0; i < tbl_Abscent.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Abscent.Rows[i].Cells[0].Value) == true)
                {
                    try
                    {

                        TimeSpan er = TimeSpan.Parse(tbl_Abscent.Rows[i].Cells[12].Value.ToString());


                        sucess = true;
                    }
                    catch (Exception)
                    {
                        flagcount++;
                        tbl_Abscent.Rows[i].Cells[10].Style.BackColor = Color.Red;

                    }


                }
            }



            if (flagcount != 0)
            {
                sucess = false;
            }




            return sucess;

        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptflag != 0)
            {
                if (cmb_dept.SelectedValue != null)
                {
                    getallDesignation();
                    employecodeload(Program.LOCTNPK, int.Parse(cmb_dept.SelectedValue.ToString()), 0);


                    filldatagrid(getemployeedata());
                }
            }
        }

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (desgflag != 0)
            {
                if (cmb_dept.SelectedValue != null)
                {
                    if (cmb_designation.SelectedValue != null)
                    {

                       
                        employecodeload(Program.LOCTNPK, int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
                        datafilter("Designation");
                    }
                }
            }
        }

        private void txtduration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txtduration.Text);
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Over  Time";
                txtduration.Text = "0";
            }
        }

        private void txtduration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Time";
                txtduration.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }

        private void dtp_Otdate_ValueChanged(object sender, EventArgs e)
        {
            getOTTYPE();
            filldatagrid(getemployeedata());
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            try
            {
                viewAbcentiesandLH();

                if (lhemployee > 0 || leaveemp > 0)
                {
                    Applications.OvertimeSubForm sbform = new OvertimeSubForm(leaveaaray, lhaaray);

                    sbform.ShowDialog();

                    DialogResult dialogResult = MessageBox.Show("Confirm  OT Application with Abcent and LH Employees", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        OnSubmitbuttonClick();
                    }

                    //    loadlistview();
                    //   grp_Message.Show();
                }
                else
                {
                    OnSubmitbuttonClick();
                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                //         ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }

         //  
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_Abscent.Rows.Count - 1; i++)
                {
                    tbl_Abscent.Rows[i].Cells[0].Value = true;
                    tbl_Abscent.Rows[i].Selected = true;
                    tbl_Abscent.Columns[10].ReadOnly = false;
                }

            }
            else
            {
                for (int i = 0; i < tbl_Abscent.Rows.Count - 1; i++)
                {
                    tbl_Abscent.Rows[i].Cells[0].Value = false;
                    tbl_Abscent.Rows[i].Selected = false;
                    tbl_Abscent.Columns[10].ReadOnly = true; ;
                }
            }
            lblStatus.Text = hlpr.calculateselected(tbl_Abscent).ToString();
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void OVertimeApplicationMaster_Load(object sender, EventArgs e)
        {
            getOTTYPE();
        }












        public void datafilter(String fltragent)
        {
          
                DataTable dt = employedata.Clone();

               
                    if (employedata == null || employedata.Rows.Count == 0)
                    {
                        employedata = getemployeedata();
                    }

                    if (fltragent == "Designation")
                    {
                        if (desgflag != 0)
                        {
                        if (cmb_designation.Text != "ALL DESG")
                        {
                            DataRow[] result = employedata.Select("DesignationName='" + cmb_designation.Text.Trim() + "' ");



                            foreach (DataRow row in result)
                            {

                                dt.Rows.Add(row.ItemArray);
                            }

                            filldatagrid(dt);
                        }
                        else
                        {
                            filldatagrid(employedata);
                        }
                        desgflag = 0;
                    }
                    }
                    else
                    {
                        if (empflag != 0)
                        {

                            if (cmb_empcode.Text == "ALL EMP")
                            {

                                desgflag++;
                                datafilter("Designation");


                            }
                            else
                            {
                                DataRow[] result = employedata.Select("empno='" + cmb_empcode.Text.Trim() + "' ");

                                foreach (DataRow row in result)
                                {

                                    dt.Rows.Add(row.ItemArray);
                                }

                                filldatagrid(dt);
                            }
                            empflag = 0;
                        
                        }

                    }
                }
           
     

        //public void calulateOTvalue()
        //{
        //    for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
        //    {
        //        if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
        //        {            
        //            int empid= int.Parse(tbl_Aplication.Rows[i].Cells[1].Value.ToString ());



        //        }

        //    }
        //}

        ///////////////////////////////////////////////////////////////TAB 2//////////////////////////////////////////////////////////////////////////




        public void otComboLoad()
        {
            DataTable dt = ovttrans.getallOTApplication();
            cmb_applicationumber .DataSource = dt;
            cmb_applicationumber.DisplayMember = "OtAppnum";
            cmb_applicationumber.ValueMember = "OTAppPK";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                otComboLoad();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showOvertimedata();
        }

        private void RejectOT_Click(object sender, EventArgs e)
        {
            Boolean isapproved = false;
            for (int i = 0; i < tbl_otdetails.Rows.Count-1; i++)
            {
                if (tbl_otdetails.Rows[i].Cells[10].Value.ToString().Trim() == "A")
                {
                    isapproved = true;
                }
            }

            if (!isapproved)
            {

                if (cmb_applicationumber.Text.Trim() == tbl_otdetails.Rows[0].Cells[2].Value.ToString().Trim())
                {
                    ovttrans.OtDletetion(int.Parse (cmb_applicationumber.SelectedValue.ToString ()));
                }
                else
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Click the view Button and Then Press Delete Application");
                }
            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Cannot Delete An Approved Overtime ");
            }
        }

        public void showOvertimedata()
        {
            DataTable dt = new DataTable();

            tbl_otdetails.RowCount = 1;
            dt = ovttrans.getOTdetails(int.Parse(cmb_applicationumber.SelectedValue.ToString()));


            tbl_otdetails.Columns[0].Visible = false;
            tbl_otdetails.Columns[1].Visible = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_otdetails.Rows.Add();
                tbl_otdetails.Rows[i].Cells[0].Value = dt.Rows[i][0];

                tbl_otdetails.Rows[i].Cells[1].Value = dt.Rows[i][1];
                tbl_otdetails.Rows[i].Cells[2].Value = dt.Rows[i][2];
                tbl_otdetails.Rows[i].Cells[3].Value = dt.Rows[i][3];
                tbl_otdetails.Rows[i].Cells[4].Value = dt.Rows[i][4];
                tbl_otdetails.Rows[i].Cells[5].Value = dt.Rows[i][5];
                tbl_otdetails.Rows[i].Cells[6].Value = dt.Rows[i][6];   //BALACE 
                tbl_otdetails.Rows[i].Cells[7].Value = dt.Rows[i][7];
                tbl_otdetails.Rows[i].Cells[8].Value = dt.Rows[i][8];
                tbl_otdetails.Rows[i].Cells[9].Value = dt.Rows[i][9];
                tbl_otdetails.Rows[i].Cells[10].Value = dt.Rows[i][10];
                tbl_otdetails.Rows[i].Cells[11].Value = dt.Rows[i][11];
                tbl_otdetails.Rows[i].Cells[12].Value = dt.Rows[i][12];


            }
        }

        private void tbl_Aplication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToBoolean(tbl_Abscent.Rows[e.RowIndex].Cells[0].Value) == true)
                    {
                        tbl_Abscent.Rows[e.RowIndex].Selected = true;
                    }
                    else
                    {
                        tbl_Abscent.Rows[e.RowIndex].Selected = false;
                    }

                    lblStatus.Text = hlpr.calculateselected(tbl_Abscent).ToString()+ "Employees Selected  " ;

                 
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void tbl_Aplication_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_Abscent.IsCurrentCellDirty)
            {
                tbl_Abscent.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        public void calculateselected()
        {

         
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_approval_Click(object sender, EventArgs e)
        {

        }

        private void cmb_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            datafilter("EMP");
        }

        private void cmb_empcode_MouseClick(object sender, MouseEventArgs e)
        {
            empflag++;
        }

        

      

        private void button6_Click(object sender, EventArgs e)
        {
            OnSubmitbuttonClick();
        }

       

       

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OVertimeApplicationMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            Applications.FrmOtShow frmot = new FrmOtShow();
            frmot.Show();
            frmot.MdiParent = this.MdiParent;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            String searchValue = txt_oldid .Text;
            int rowIndex = -1;
            foreach (DataGridViewRow row in tbl_Abscent.Rows)
            {
                if (row.Index != tbl_Abscent.RowCount - 1)
                {
                    if (row.Cells[15].Value.ToString().Equals(searchValue))
                    {

                        rowIndex = row.Index;
                        tbl_Abscent.FirstDisplayedScrollingRowIndex = rowIndex;
                        tbl_Abscent.Rows[rowIndex].Selected = true;
                    }
                }
            }
        }








        public void SerchAction()
        {
            String searchValue = txt_oldid.Text;
            int rowIndex = -1;
            foreach (DataGridViewRow row in tbl_Abscent.Rows)
            {
                if (row.Index != tbl_Abscent.RowCount - 1)
                {
                    if (row.Cells[15].Value.ToString().Equals(searchValue))
                    {

                        rowIndex = row.Index;
                        tbl_Abscent.FirstDisplayedScrollingRowIndex = rowIndex;
                        tbl_Abscent.Rows[rowIndex].Selected = true;
                    }
                }
            }
        }

        private void txt_oldid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SerchAction();
            }   
        }


        //public void loadlistview()
        //{

        //  //   lbl_leave.Text = leaveemp.ToString();
        //     //  lbl_lh.Text = lhemployee.ToString();
        // //   loadlistview();
            
        //    int counterOfArraylist = leaveaaray .Count;

        //    for (int i = 0; i < counterOfArraylist; i++)
        //    {
        //        tbl_Abscent.Rows.Add();
        //        tbl_Abscent.Rows[i].Cells [0].Value  = leaveaaray[i].ToString();

        //    }
        

           
        //    int counteroflh = lhaaray .Count;
          
        //    for (int i = 0; i < counteroflh; i++)
        //    {
        //        tbl_LH.Rows.Add();
        //        tbl_LH .Rows[i].Cells[0].Value = lhaaray[i].ToString();

        //    }

        //    lbl_leave.Text = counterOfArraylist.ToString();
        //    lbl_lh.Text = counteroflh.ToString();
        //}

      
    
    
    
    
    
    }
}

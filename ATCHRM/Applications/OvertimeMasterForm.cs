using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{ 
   

    public partial class OvertimeMasterForm : Form
    {
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.OvertimeandShiftTransaction ovttrans = null;
        Datalayer.OvertimeApplicationDatabean ovtdatabean = null;
        Transactions.HolidayTransaction hldytransaction = null;
        Transactions.Helper HLPR = null;
        DataTable employedata = null;
        DataTable dTable = new DataTable();
        int deptflag = 0;
        int desgflag = 0;
        public OvertimeMasterForm()
        {
            InitializeComponent();
             tbl_Aplication.RowTemplate.Height  = 18;
             depttrans = new Transactions.DepartmentTransaction();
             empreg = new Transactions.EmployeeRegTransaction();
             dsgtrans = new Transactions.DesignationTransaction();
             ovttrans = new Transactions.OvertimeandShiftTransaction();
             hldytransaction = new Transactions.HolidayTransaction();
             HLPR = new Transactions.Helper();
             gridviewsetup();
              DeptcomboLoad();
        }
        public void DeptcomboLoad()
        {
      //      DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = HLPR.GetComboBoxedDataTable(depttrans.getDeptName(),
     "DepartmentPK", "DepartmentName", "0", "ALL DEPT");
           // cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptflag++;
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptflag != 0)
            {
                if (cmb_dept.SelectedValue != null)
                {
                    getallDesignation();
           employecodeload(Program.LOCTNPK , int.Parse(cmb_dept.SelectedValue.ToString()), 0);










                }
            }
        }

        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept, desg);
            cmb_empcode.DataSource = dt;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
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

                cmb_designation.DisplayMember = "DESGN";
                cmb_designation.ValueMember = "SL";
                cmb_designation.DataSource = dt;


                filldatagrid();
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

                        // tbl_Aplication.DataSource = employedata;
                        // ((DataTable)tbl_Aplication.DataSource).DefaultView.RowFilter = " designationnName like '%" + cmb_dept.Text.Trim() + "%' ";
                        employecodeload(Program.LOCTNPK, int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
                    }
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
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
                    lbl_daystatus.ForeColor = Color.BurlyWood ;
                }
                else
                {
                    lbl_daystatus.Text = "Working Day";
                    lbl_otType.Text = "OT 1.5";
                    lblStatus.Visible = true;
                    lbl_daystatus.Visible = true;
                    lbl_otType.Visible = true;
                    lbl_daystatus.ForeColor = Color.Firebrick ;
                    lbl_daystatus.ForeColor = Color.Chartreuse ;
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


            //tbl_Aplication.Columns.Add("1", "Empid");
            //tbl_Aplication.Columns.Add("2", "Emp no");
            //tbl_Aplication.Columns.Add("3", "Emp Name");
            //tbl_Aplication.Columns.Add("4", "Department ");
            //tbl_Aplication.Columns.Add("5", "Designation");
            //tbl_Aplication.Columns.Add("6", "Shift");
            //tbl_Aplication.Columns.Add("7", "Start Time");

            //tbl_Aplication.Columns.Add("8", "End Time");
            //tbl_Aplication.Columns.Add("9", "OT");

            //tbl_Aplication.Columns.Add("10", "Reversed Swipe Out");
            //tbl_Aplication.Columns[0].ReadOnly = false;
            //tbl_Aplication.Columns[1].ReadOnly = true;
            //tbl_Aplication.Columns[2].ReadOnly = true;
            //tbl_Aplication.Columns[3].ReadOnly = true;
            //tbl_Aplication.Columns[4].ReadOnly = true;
            //tbl_Aplication.Columns[5].ReadOnly = true;
            //tbl_Aplication.Columns[6].ReadOnly = true;
            //tbl_Aplication.Columns[7].ReadOnly = true;
            //tbl_Aplication.Columns[8].ReadOnly = true;
            //tbl_Aplication.Columns[9].ReadOnly = true;
            //tbl_Aplication.Columns[10].ReadOnly = true;
            ////tbl_Aplication.RowTemplate.Height = 18;




            tbl_Aplication.Columns.Add("1", "Empid");
            tbl_Aplication.Columns.Add("2", "Emp no");
            tbl_Aplication.Columns.Add("3", "Emp Name");
            tbl_Aplication.Columns.Add("4", "Department ");
            tbl_Aplication.Columns.Add("5", "Designation");
            tbl_Aplication.Columns.Add("6", "Shift");
            tbl_Aplication.Columns.Add("7", "Day Status");
            tbl_Aplication.Columns.Add("8", "Start Time");

            tbl_Aplication.Columns.Add("9", "End Time");
            tbl_Aplication.Columns.Add("10", "OT");
            tbl_Aplication.Columns.Add("11", "OT Type");
            tbl_Aplication.Columns.Add("12", "Reversed Swipe Out");
            tbl_Aplication.Columns[0].ReadOnly = false;
            tbl_Aplication.Columns[1].ReadOnly = true;
            tbl_Aplication.Columns[2].ReadOnly = true;
            tbl_Aplication.Columns[3].ReadOnly = true;
            tbl_Aplication.Columns[4].ReadOnly = true;
            tbl_Aplication.Columns[5].ReadOnly = true;
            tbl_Aplication.Columns[6].ReadOnly = true;
            tbl_Aplication.Columns[7].ReadOnly = true;
            tbl_Aplication.Columns[8].ReadOnly = true;
            tbl_Aplication.Columns[9].ReadOnly = true;
            tbl_Aplication.Columns[10].ReadOnly = true;
            tbl_Aplication.Columns[9].ReadOnly = true;
            tbl_Aplication.Columns[10].ReadOnly = true;
            //tbl_Aplication.RowTemplate.Height = 18;





            
        }

        /// <summary>
        /// fill the datagrid controls
        /// </summary>
        public void filldatagrid()
        {
            if (cmb_dept.Text.Trim() == "")
            {
                employedata = empreg.getallemployeeshiftdetails(0, Program.LOCTNPK,lbl_day .Text );

            }

            else
            {
                employedata = empreg.getallemployeeshiftdetails(int.Parse(cmb_dept.SelectedValue.ToString()), Program.LOCTNPK, lbl_day.Text);
               // tbl_Aplication.DataSource = employedata.DefaultView;
            }

            tbl_Aplication.Rows.Clear();
            tbl_Aplication.DataSource = null;
            for (int i = 0; i < employedata.Rows.Count; i++)
            {

                tbl_Aplication.Rows.Add();
                tbl_Aplication.Rows[i].Cells[1].Value = employedata.Rows[i][0];

                tbl_Aplication.Rows[i].Cells[2].Value = employedata.Rows[i][1];
                tbl_Aplication.Rows[i].Cells[3].Value = employedata.Rows[i][2];
                tbl_Aplication.Rows[i].Cells[4].Value = employedata.Rows[i][3];
                tbl_Aplication.Rows[i].Cells[5].Value = employedata.Rows[i][4];
                tbl_Aplication.Rows[i].Cells[6].Value = employedata.Rows[i][5];
                tbl_Aplication.Rows[i].Cells[7].Value = employedata.Rows[i][6];   
                tbl_Aplication.Rows[i].Cells[8].Value = employedata.Rows[i][7];
                tbl_Aplication.Rows[i].Cells[9].Value = employedata.Rows[i][8];
                 tbl_Aplication.Rows[i].Cells[10].Value = 0;
                 tbl_Aplication.Rows[i].Cells[11].Value = "NA";
                 tbl_Aplication.Rows[i].Cells[12].Value = employedata.Rows[i][8];
            }
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

       

        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_Aplication.Rows.Count - 1; i++)
                {
                    tbl_Aplication.Rows[i].Cells[0].Value = true;
                    tbl_Aplication.Rows[i].Selected = true;
                    tbl_Aplication.Columns[10].ReadOnly = false;
                }

            }
            else
            {
                for (int i = 0; i < tbl_Aplication.Rows.Count - 1; i++)
                {
                    tbl_Aplication.Rows[i].Cells[0].Value = false;
                    tbl_Aplication.Rows[i].Selected = false;
                    tbl_Aplication.Columns[10].ReadOnly = true; ;
                }
            }
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





        public void applyuaction()
        {
            for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                {

                    tbl_Aplication.Rows[i].Cells[10].Value = txtduration.Text;

                    //
                    //TimeSpan tm = new TimeSpan(tbl_Aplication.Rows[i].Cells[9].Value.ToString());

                    DateTime dt = DateTime.Parse(tbl_Aplication.Rows[i].Cells[9].Value.ToString());

                    TimeSpan endtime = dt.TimeOfDay + TimeSpan.FromMinutes(int.Parse(txtduration.Text));

                    tbl_Aplication.Rows[i].Cells[12].Value = endtime;

                    if (tbl_Aplication.Rows[i].Cells[7].Value.ToString() == "Off Day")
                    {
                        tbl_Aplication.Rows[i].Cells[11].Value = "OT2.0";
                    }

                    else if (tbl_Aplication.Rows[i].Cells[7].Value.ToString() == "Working Day")
                    {
                        tbl_Aplication.Rows[i].Cells[11].Value = "OT1.5";
                    }
                    else
                    {
                        tbl_Aplication.Rows[i].Cells[11].Value = "OT2.0";
                    }


                 
                }
            }
            if (tbl_Aplication.SelectedRows.Count != 0)
            {
                btn_apply  .Enabled = true;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {


            applyuaction();
          
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

            DataColumn otamount = new DataColumn("otamount", typeof(System.Int32));
            dTable.Columns.Add(otamount);
            DataRow row = null;



            if (ValidationControl())
            {

                ovtdatabean = new Datalayer.OvertimeApplicationDatabean();

                ovtdatabean.Deptpk = int.Parse(cmb_dept.SelectedValue.ToString());
                ovtdatabean.Duration1 = int.Parse(txtduration.Text);
                ovtdatabean.Reason = rht1_reason.Text;
                ovtdatabean.Otdate1 = dtp_Otdate.Value.Date;

                for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                    {


                        row = dTable.NewRow();
                        row["EmpID"] = int.Parse(tbl_Aplication.Rows[i].Cells[1].Value.ToString());
                        row["OT"] = int.Parse(tbl_Aplication.Rows[i].Cells[10].Value.ToString());
                        row["EndTime"] = TimeSpan .Parse(tbl_Aplication.Rows[i].Cells[12].Value.ToString());
                        row["OTDate"] = dtp_Otdate.Value.Date.ToString();
                        row["Ottype"] = tbl_Aplication.Rows[i].Cells[11].Value.ToString();
                        row["otamount"] = tbl_Aplication.Rows[i].Cells[11].Value.ToString();
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



        public void employeelistload()
        {

            if (cmb_dept.SelectedValue != null)
            {

                if (cmb_designation .SelectedValue != null)
                {
                    employecodeload(Program.LOCTNPK, int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
                }
                else
                {
                    employecodeload(Program.LOCTNPK, int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                }




            }


        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            OnSubmitbuttonClick();

           
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

          else if (checkswipedate()==false )            
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

        


        public Boolean  checkswipedate()
        {
            Boolean sucess = false;
            int flagcount=0;
            for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                {
                    try
                    {

                        TimeSpan er = TimeSpan.Parse(tbl_Aplication.Rows[i].Cells[12].Value.ToString());
                       
                        
                        sucess = true;
                    }
                    catch (Exception)
                    {
                        flagcount++;
                        tbl_Aplication.Rows[i].Cells[10].Style.BackColor = Color.Red;

                    }


                }
            }



            if(flagcount!=0){
                 sucess = false ;
            }




            return sucess;

        }

        private void OvertimeMasterForm_Load(object sender, EventArgs e)
        {
            getOTTYPE();
        }

        private void dtp_Otdate_ValueChanged(object sender, EventArgs e)
        {
            getOTTYPE();
            filldatagrid();
        }

       

      

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            applyuaction();
        }

        private void txtduration_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtduration_TextChanged_1(object sender, EventArgs e)
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

        private void btn_apply_Click_1(object sender, EventArgs e)
        {
            OnSubmitbuttonClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_approval_Click(object sender, EventArgs e)
        {

        }

    




















    }
}

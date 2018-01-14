
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient ;
using System.Collections;
namespace ATCHRM.Applications
{
    public partial class LostHourRecoveryForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.OvertimeandShiftTransaction lhrtrans = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        int empflag = 0;
        
        DataTable employedata = null;
        DataTable dTable = new DataTable();
        public LostHourRecoveryForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            lhrtrans = new Transactions.OvertimeandShiftTransaction();
            locationListLoad();
            DeptcomboLoad();

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
            //tbl_Aplication.Columns.Add("9", "LH Left ");

            //tbl_Aplication.Columns.Add("10", "Apply For");
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
            //tbl_Aplication.RowTemplate.Height = 18;


            tbl_Aplication.Columns.Add("1", "Empid");
            tbl_Aplication.Columns.Add("2", "Emp no");
            tbl_Aplication.Columns.Add("3", "Emp Name");
            tbl_Aplication.Columns.Add("4", "Department ");
            tbl_Aplication.Columns.Add("5", "Designation");
            tbl_Aplication.Columns.Add("6", "Shift");
            tbl_Aplication.Columns.Add("7", "Day Status");
            tbl_Aplication.Columns.Add("8", "Start Time");

            tbl_Aplication.Columns.Add("9", "End Time");

            tbl_Aplication.Columns.Add("10", "LH Left ");

            tbl_Aplication.Columns.Add("11", "Apply For");
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
            tbl_Aplication.Columns[11].ReadOnly = true;
            tbl_Aplication.RowTemplate.Height = 18;






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
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        /// <summary>
        /// get all the designation
        /// against a given dept
        /// </summary>
        public void getallDesignation()
        {

            if (deptchangeflag != 0)
            {


                if (cmb_dept.SelectedValue != null)
                {


                    cmb_designation.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_dept.SelectedValue.ToString()));

                    cmb_designation.DisplayMember = "DESGN";
                    cmb_designation.ValueMember = "SL";
                    cmb_designation.DataSource = dt;
                }

            }
        }

        /// <summary>
        /// get the employee code of the persons
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }


        /// <summary>
        /// getdate
        /// </summary>
        public void getshiftdata()
        {
            try
            {


                employedata = empregtrans .getallemployeeshiftdetails(int.Parse(cmb_dept.SelectedValue.ToString()),int.Parse(cmb_location.SelectedValue.ToString ()),lbl_day.Text);

                filldatagrid(employedata);
            }
            catch (Exception)
            {
                
                
            }
               
          

        }







        /// <summary>
        /// fill the datagrid controls
        /// </summary>
        public void filldatagrid(DataTable employedata)
        {

            try
            {

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
                  
                    int lhleftover = getLHhourLeft(int.Parse(tbl_Aplication.Rows[i].Cells[1].Value.ToString()));
                    tbl_Aplication.Rows[i].Cells[10].Value = lhleftover;
                }
            }
            catch (Exception exp )
            {
                
                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique  Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
        //         ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }








        private void LostHourRecoveryForm_Load(object sender, EventArgs e)
        {
            gridviewsetup();
            lbl_day.Text = dtp_Otdate.Value.DayOfWeek.ToString();
            getshiftdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Applications.LostHourRecoverSub LHRSUB = new LostHourRecoverSub();
            LHRSUB.ShowDialog();
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();

        getshiftdata();
        }

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Branch location";

            }
            else if (cmb_dept.Text == "" || cmb_dept.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), 0, 0);
            }
            else if (cmb_designation.Text == "" || cmb_designation.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
            }
            else
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
            }



            filterdata("Desg");
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void tbl_Aplication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    getshiftdata();
            resrictacess();
        }




        public void filterdata(String Typename)
        {
            if (desgflag != 0)
            {
                DataTable dt = employedata.Clone();

                if (employedata == null || employedata.Rows.Count == 0)
                {
                    employedata = empregtrans.getallemployeeshiftdetails(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()), lbl_day.Text);
                }

                if (Typename == "Desg")
                {
                    DataRow[] result = employedata.Select("DesignationName='" + cmb_designation.Text.Trim() + "' ");
                    foreach (DataRow row in result)
                    {
                        //DataRow newRow = dt.NewRow();
                        //newRow.ItemArray = row.ItemArray;
                        dt.Rows.Add(row.ItemArray);
                    }
                }
                else
                {
                    DataRow[] result = employedata.Select("empno='" + cmb_EmpCode.Text.Trim() + "' ");
                    foreach (DataRow row in result)
                    {
                        //DataRow newRow = dt.NewRow();
                        //newRow.ItemArray = row.ItemArray;
                        dt.Rows.Add(row.ItemArray);
                    }

                }


                filldatagrid(dt);
            }
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empflag != 0)
            {
                filterdata("Emp");
            }
            if (cmb_EmpCode.Text.Trim() =="")
            {
                empflag = 0;
            }
        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            empflag++;
        }


        /// <summary>
        ///returns the LH left fo rthat person
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int  getLHhourLeft(int empid)
        {     
            
            int lhleft =0;
             using (SqlConnection  con=new SqlConnection (Program.ConnStr ))
                   {
                       con.Open();
                       SqlCommand command = new SqlCommand(" SELECT     LH - LHR AS Expr1 FROM    EmpDutyMaster_tbl WHERE (empid = @Param1)", con);
        command.Parameters.AddWithValue("@Param1", empid);
      

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                lhleft = int.Parse (reader[0].ToString ());
               
            }
        }


        reader.Close();

    }
           
             return lhleft;
            
}

        private void tbl_Aplication_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                {

                    tbl_Aplication.Rows[i].Cells[11].Value = txtduration.Text;
                     if (int.Parse(tbl_Aplication.Rows[i].Cells[10].Value.ToString()) < int.Parse(tbl_Aplication.Rows[i].Cells[11].Value.ToString()))
                {
                     tbl_Aplication.Rows[i].Cells[11].Style.BackColor = Color.Red;
                     tbl_Aplication.Rows[i].Cells[0].Value = false;
                 }



                }
            }
            if (tbl_Aplication.SelectedRows.Count != 0)
            {
                btn_submitt.Enabled = true;
            }

        }

        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_Aplication.Rows.Count - 1; i++)
                {
                    tbl_Aplication.Rows[i].Cells[0].Value = true;
                    tbl_Aplication.Rows[i].Selected = true;
                    tbl_Aplication.Columns[11].ReadOnly = false;
                }

            }
            else
            {
                for (int i = 0; i < tbl_Aplication.Rows.Count - 1; i++)
                {
                    tbl_Aplication.Rows[i].Cells[0].Value = false;
                    tbl_Aplication.Rows[i].Selected = false;
                    tbl_Aplication.Columns[11].ReadOnly = true; ;
                }
            }
        }

        private void tbl_Aplication_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_Aplication.IsCurrentCellDirty)
            {
                tbl_Aplication.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btn_ViewOnlyLH_Click(object sender, EventArgs e)
        {
          
        }

        private void Btn_cropLH_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_Aplication.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                {

                    tbl_Aplication.Rows[i].Cells[11].Value = tbl_Aplication.Rows[i].Cells[10].Value;

                }

            }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidationControl())
                {
                    insertSwipeData();
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


        public void insertSwipeData()
        {
            ArrayList lhrapp = new ArrayList();

            lhrapp.Add(int.Parse(cmb_location.SelectedValue.ToString()));
            lhrapp.Add(DateTime.Parse(dtp_Otdate.Value.Date.ToString()));
            lhrapp.Add(rht1_reason.ToString());


            dTable = new DataTable();
            DataColumn auto = new DataColumn("EmpID", typeof(System.Int32));
            dTable.Columns.Add(auto);

            DataColumn name = new DataColumn("LHR", typeof(string));
            dTable.Columns.Add(name);


            DataColumn endtime = new DataColumn("LHRDate", typeof(String));
            dTable.Columns.Add(endtime);
            DataRow row = null;

          
            for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                {


                    row = dTable.NewRow();
                    row["EmpID"] = int.Parse(tbl_Aplication.Rows[i].Cells[1].Value.ToString());
                    row["LHR"] = int.Parse(tbl_Aplication.Rows[i].Cells[11].Value.ToString());
                    row["LHRDate"] = DateTime.Parse(dtp_Otdate.Value.Date.ToString()); 
                   
                    dTable.Rows.Add(row);

                }
            }



      string appnum=lhrtrans.insertLHRApplication (lhrapp, dTable);

       ATCHRM.Controls.ATCHRMMessagebox.Show("Lost Hour Recovery App num#   '" + appnum + "' is Done ");




        }

        public Boolean checkswipedate()
        {
            Boolean sucess = false;
            int flagcount = 0;
            for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                {
                    try
                    {
                  
                        int dt = int.Parse(tbl_Aplication.Rows[i].Cells[11].Value.ToString());
                        sucess = true;
                    }
                    catch (Exception)
                    {
                        flagcount++;
                        tbl_Aplication.Rows[i].Cells[10].Style.BackColor = Color.Red;

                    }


                }
            }



            if (flagcount != 0)
            {
                sucess = false;
            }




            return sucess;

        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++; ;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = tbl_Aplication.Rows.Count - 2; i >= 0; i--)
            {

                if (int.Parse(tbl_Aplication.Rows[i].Cells[10].Value.ToString().Trim()) == 0)
                {
                    tbl_Aplication.Rows.RemoveAt(i);
                }


            }

            for (int i = 0; i < tbl_Aplication.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_Aplication.Rows[i].Cells[0].Value) == true)
                {
                    lhrtrans.rejectLHRapplication(int.Parse(tbl_Aplication.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_Aplication.Rows[i].Cells[11].Value.ToString()));

                }
            }





        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = tbl_Aplication.Rows.Count - 2; i >= 0; i--)
            {

                if ((int.Parse(tbl_Aplication.Rows[i].Cells[10].Value.ToString().Trim()) == 0))
                {
                    tbl_Aplication.Rows.RemoveAt(i);
                }


            }
        }

        private void dtp_Otdate_ValueChanged(object sender, EventArgs e)
        {
            
            lbl_day.Text = dtp_Otdate.Value.DayOfWeek.ToString();
            getshiftdata();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LostHourRecoveryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Applications.FrmLHRStatus frmlh = new Applications.FrmLHRStatus();
            frmlh.Show();
            frmlh.MdiParent = this.MdiParent;
        }





    }
}

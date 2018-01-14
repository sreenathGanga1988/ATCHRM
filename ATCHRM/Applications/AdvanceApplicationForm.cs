using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class AdvanceApplicationForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.AnualContractrenewal annul = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.currencytransaction crncytrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Datalayer.AdvanceAppDatabean advncappdatbean = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.LeaveandAdvanceAppTransaction lveandadvancetrans = null;
        public int deptchangeflag = 0;
        public int empchangeflag=0;
        int lctnflg = 0;
        public AdvanceApplicationForm()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            crncytrans = new Transactions.currencytransaction();
            lveandadvancetrans = new Transactions.LeaveandAdvanceAppTransaction();
            annul = new Transactions.AnualContractrenewal();
            locationListLoad();
            DeptcomboLoad();
            fillcurrency();
            employecodeload(Program.LOCTNPK, 0, 0);
            //tbl_previousdata.ColumnCount = 8;
            //tbl_previousdata.Rows.Add();
            //tbl_previousdata.Rows.Add();
        }




        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
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
        /// <summary>
        /// loads employe code
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept ,int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept,desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }
        /// <summary>
        /// will get all thecurrency data 
        /// and will enter it to combobox
        /// 
        /// </summary>
        public void fillcurrency()
        {

            DataTable dt = crncytrans.getCurrencyName();
            cmb_currency.DataSource = dt;
            cmb_currency.DisplayMember = "NameAdr";
            cmb_currency.ValueMember = "pk";

        }

        public void getallDesignation()
        {
           
           if(deptchangeflag!=0){

            
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

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();

        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag = 1;
        }

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Branch location";

            }
            else if (cmb_dept.Text == "" || cmb_dept.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), 0,0);
            }
            else if (cmb_designation.Text == "" || cmb_designation.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
            }
            else
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
            }
        }

        private void txt_Amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_Amount.Text);
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Amount";
                txt_Amount.Text = "0";
            }
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Amount";
                txt_Amount.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
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

        private void txt_duration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_duration.Text);
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Duration";
                txt_duration.Text = "0";
            }
        }

        private void txt_duration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Duration ";
                txt_duration.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
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
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid EmpCode";
                cmb_EmpCode.Focus();
                lbl_empcode.Visible = true;
            }
            else if (cmb_empname.Text == null || cmb_empname.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Employee Name";
                cmb_empname.Focus();
               
            }
            else if (txt_Amount.Text == null || txt_Amount.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Amount ";
                txt_Amount.Focus();
                lbl_amount .Visible = true;
            }

            else if (cmb_currency.Text == null || cmb_currency.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Currency";
                cmb_currency.Focus();
                lbl_amount.Visible = true;
            }


            else if (txt_duration.Text == null || txt_duration.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Duration";
                txt_duration.Focus();
                lbl_duration.Visible = true;
            }

            else if (cmb_durationtype.Text == null || cmb_durationtype.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Payment Terms ";
                cmb_durationtype.Focus();
                lbl_duration.Visible = true;
            }

            else if (txt_instalmentype.Text == null || txt_instalmentype.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Instalment Terms ";
                txt_instalmentype.Focus();  lbl_duration.Visible = true;
                lbl_reason.Visible = true;
            }

            else if (cmb_payment.Text == null || cmb_payment.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Payment Type ";
                cmb_payment.Focus(); 
      
            }

            else if (!issumoff())
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("The Amount and the Sum of Installment Is not matching");

            }
            else if (!ispaybackdatecorrect())
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Payment Date Selected is not Correct");

            }


            else
            {
                sucess = true;
            }

            return sucess;

        }









        public Boolean ispaybackdatecorrect()
        { 
            Boolean isok= false;

           
       

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if (dataGridView1.Rows[i].Cells[2].Value == null || dataGridView1.Rows[i].Cells[2].Value.ToString().Trim () == "")
                {
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Enter Advance Pay Date");
                    lblStatus.Text="Enter Advance Pay Date";
                    break;
                }
                else if (!annul.ifdatevalidContractdate(int.Parse(cmb_EmpCode .SelectedValue.ToString()), DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())))
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Date Out Of Contract period");
                    lblStatus.Text="Date Out Of Contract period";
                    break;

                }
                //else if (DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) <Program.Datetoday )
                //{
                //     ATCHRM.Controls.ATCHRMMessagebox.Show("Advance Pay Back Date cannot be a Previous Date");
                //      lblStatus.Text="Advance Pay Back Date cannot be a Previous Date";
                //      break;
                //}
                else
                {
                    isok= true ;
                }
                
            }

            return isok;
        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (ValidationControl())
            {

                advncappdatbean = new Datalayer.AdvanceAppDatabean();


                advncappdatbean.Empid = int.Parse(cmb_EmpCode.SelectedValue .ToString ());
                advncappdatbean.Amount1 = float.Parse(txt_Amount.Text);
                advncappdatbean.Currencypk = int.Parse(cmb_currency.SelectedValue.ToString());
                advncappdatbean.Duration = int.Parse(txt_duration.Text.ToString());
                advncappdatbean.Durationtype = cmb_durationtype.Text;
                advncappdatbean.Instalmentof1 = float.Parse(txt_Amount.Text .ToString());
                advncappdatbean.Reason = rht_reason.Text;
                advncappdatbean.Dateadded = DateTime.Now.Date;
                String advanceApplicationcode = lveandadvancetrans.insertAdvanceApplication(advncappdatbean);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Apllication  " + advanceApplicationcode + "Done");
                this.Close();



            }
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empchangeflag != 0)
            {
                if (cmb_EmpCode.Text != null || cmb_EmpCode.Text != "")
                {
                    if(cmb_EmpCode.SelectedValue!=null){
                    DataTable dt = empreg.getemployeegenderandName(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                    
                    cmb_empname.Text = dt.Rows[0][0].ToString();

                    DataTable previusadvancedata = lveandadvancetrans.getprevoiueAdvanceDetails(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                    tbl_previousdata.DataSource = previusadvancedata;
                }
                }
                else
                {
                    cmb_empname.Text = "";
                }
            }
        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            empchangeflag++;
        }

        private void txt_instalmentype_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_instalmentype.Text);
                dataGridView1.RowCount = (int)Math.Round(f);
                amountsplitter();
              //  int.Parse(Math.Truncate(f)); 
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Amount";
                txt_instalmentype.Text = "0";
            }
        }

        private void txt_instalmentype_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_instalmentype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Amount";
                txt_instalmentype.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationControl())
                {

                    advncappdatbean = new Datalayer.AdvanceAppDatabean();


                    advncappdatbean.Empid = int.Parse(cmb_EmpCode.SelectedValue.ToString());
                    advncappdatbean.Amount1 = float.Parse(txt_Amount.Text);
                    advncappdatbean.Currencypk = int.Parse(cmb_currency.SelectedValue.ToString());
                    advncappdatbean.Duration = int.Parse(txt_duration.Text.ToString());
                    advncappdatbean.Durationtype = cmb_durationtype.Text;
                    advncappdatbean.Instalmentof1 = float.Parse(txt_Amount.Text.ToString());
                    advncappdatbean.Reason = rht_reason.Text;
                    advncappdatbean.Dateadded = DateTime.Now.Date;
                    advncappdatbean.Paybackdate = getpaymentdates();
                    advncappdatbean.Tobepayedby1 = cmb_payment.Text;
                    String advanceApplicationcode = lveandadvancetrans.insertAdvanceApplication(advncappdatbean);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(String.Format("Apllication  {0}Done", advanceApplicationcode));
                    this.Close();



                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
               
                this.Dispose();
            }
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            resrictacess ();
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }





        public DataTable  getpaymentdates()
        {
            DataTable dTable = new DataTable();
            DataColumn auto = new DataColumn("EmpID", typeof(System.Int32));
            dTable.Columns.Add(auto);
            DataColumn amount = new DataColumn("Amount", typeof(System.Int32));
            dTable.Columns.Add(amount);
            DataColumn Dateofpay = new DataColumn("Dateofpay", typeof(DateTime));
            dTable.Columns.Add(Dateofpay);
            DataRow row = null;
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {

                row = dTable.NewRow();
                row["EmpID"] = int.Parse(cmb_EmpCode.SelectedValue.ToString());
                row["Amount"] = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                row["Dateofpay"] = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                dTable.Rows.Add(row);
            }

            return dTable;

        }








        


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Point p = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                p.Offset(dataGridView1.Location);
                dt_drp.Location = p;
                dt_drp.Visible = true;

                try
                {
                    dt_drp.Value = Convert.ToDateTime(dataGridView1.CurrentCell.Value);
                }
                catch (Exception )
                {
                }
                dt_drp.Size = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
 
    dt_drp.Visible = true;
    dt_drp.Select();
                
            }
        }

        private void dt_drp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int year = dt_drp.Value.Date.Year ;
                int month = dt_drp.Value.Date.Month;
                DateTime startOfMonth = new DateTime(year, month, 24);
                dt_drp.Value = startOfMonth;

                dataGridView1.CurrentCell.Value = dt_drp.Value;
                dataGridView1.CurrentCell.ToolTipText = year.ToString() + "-" + startOfMonth.ToString ();
            }
            catch (Exception)
            {
                
               
            }
        }

        private void dt_drp_Leave(object sender, EventArgs e)
        {
            dt_drp.Visible = false;
        }





        public void amountsplitter()
        {
            try
            {
                float amount = float.Parse(txt_Amount.Text.ToString()) / float.Parse(txt_instalmentype.Text);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[1].Value = amount;
                    dataGridView1.Rows[i].Cells[0].Value = i;

                }
            }
            catch (Exception)
            {
                
               
            }


        }


        public Boolean  issumoff()        
        {
            Boolean ismatching = false;

            int willpaysum = 0;




            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {

                    willpaysum = willpaysum + int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
            }

            if (willpaysum == int.Parse(txt_Amount.Text))
            {
                ismatching = true;
            }

            return ismatching;
        }

        private void AdvanceApplicationForm_Load(object sender, EventArgs e)
        {
            cmb_payment.SelectedIndex = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }












    }
}

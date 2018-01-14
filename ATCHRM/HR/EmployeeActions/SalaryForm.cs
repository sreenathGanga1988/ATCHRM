using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Media;

namespace ATCHRM.Master.NewFolder1
{
    public partial class SalaryForm : Form
    {
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.SalaryCompTransaction salcomptrans = null;
          Transactions.currencytransaction crncytrans = null;
          Transactions.BankTransactions bnktransctn = null;
          Datalayer.employeesalarydatabean empsaldatabean = null;
          DataTable dTable = new DataTable();
        int employeidflag = 0;
        String selectedgrid = null;
        public SalaryForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            salcomptrans = new Transactions.SalaryCompTransaction();
            crncytrans = new Transactions.currencytransaction();
            bnktransctn = new Transactions.BankTransactions();
            
            employecodeload(Program.LOCTNPK , 0, 0);
            gridviewsetup();
            fillcurrency();
            fillBank();
        }
        public SalaryForm(int empid)
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            salcomptrans = new Transactions.SalaryCompTransaction();
            crncytrans = new Transactions.currencytransaction();
            bnktransctn = new Transactions.BankTransactions();

            employecodeload(Program.LOCTNPK, 0, 0);
            cmb_EmpCode.SelectedValue = empid;
            gridviewsetup();
           employeidflag++;
            employecodechangedevent();
           
            fillcurrency();
            fillBank();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dTable = new DataTable();
            DataColumn auto = new DataColumn("empid", typeof(System.Int32));
            dTable.Columns.Add(auto);

            DataColumn salcompK = new DataColumn("salcompK", typeof(string));
            dTable.Columns.Add(salcompK);

            DataColumn amount = new DataColumn("Amount", typeof(string));
            dTable.Columns.Add(amount);

            DataRow row = null;


            if(validationcontrol ()){

                empsaldatabean = new Datalayer.employeesalarydatabean();


                for (int i = 0; i < tbl_deduction.Rows.Count-1;i++ )
                {
                    row = dTable.NewRow();
                    row["empid"] = int.Parse(lbl_empid .Text .ToString());
                    row["salcompK"] = int.Parse(tbl_deduction .Rows[i].Cells[0].Value.ToString());
                    row["amount"] = int.Parse(tbl_deduction.Rows[i].Cells[5].Value.ToString());
                    dTable.Rows.Add(row);
                }

                for (int i = 0; i < tbl_disbursement .Rows.Count-1; i++)
                {
                    row = dTable.NewRow();
                    row["empid"] = int.Parse(lbl_empid.Text.ToString());
                    row["salcompK"] = int.Parse(tbl_disbursement.Rows[i].Cells[0].Value.ToString());
                    row["amount"] = int.Parse(tbl_disbursement.Rows[i].Cells[5].Value.ToString());
                    dTable.Rows.Add(row);
                }
                empsaldatabean.Empid = int.Parse(lbl_empid.Text.ToString());

                empsaldatabean.Approvedsal = int.Parse(txt_appsal.Text.ToString());
                empsaldatabean.Currencypk = int.Parse(cmb_currency.SelectedValue.ToString());
                empsaldatabean.Paymentmode = cocmb_paymentmde.Text;

                if (cocmb_paymentmde.Text == "Bank Transfer")
                {
                    empsaldatabean.Bankpk = int.Parse(cmb_bank.SelectedValue.ToString());
                    empsaldatabean.Accountnum = txtaccountnum.Text.ToString();
                }
                else
                {
                    empsaldatabean.Bankpk = 0;
                    empsaldatabean.Accountnum ="0";
                }

                empsaldatabean.Applicablesalcomponent = dTable;

                empregtrans.insertemployesalarydata(empsaldatabean);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
             //   this.Close();

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }




        /// <summary>
        /// validates the controls
        /// </summary>
        /// <returns></returns>
        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter EmpCode";
                cmb_EmpCode.Focus();
                cmb_EmpCode.Visible = true;

            }


            else if (txt_appsal.Text == null || txt_appsal.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Approved Salary";
                txt_appsal.Focus();
                txt_appsal.Visible = true;

            }
            else if (cmb_currency.Text == null || cmb_currency.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Currency";
                cmb_currency.Focus();
                cmb_currency.Visible = true;

            }
            else if (cocmb_paymentmde.Text == null || cocmb_paymentmde.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Payment Mode";
                cocmb_paymentmde.Focus();


            }
            else if (cocmb_paymentmde .Text== "Bank Transfer" && txtaccountnum.Text=="")
            {
                lblStatus.Text = "Enter Account Deatails";
                cocmb_paymentmde.Focus();
            }
            else
            {
                sucess = true;
            }


            return sucess;
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


        /// <summary>
        /// will get all Bank data 
        /// and will enter it to combobox
        /// 
        /// </summary>
        public void fillBank()
        {

            DataTable dt = bnktransctn.getallbanknameandcode();
           cmb_bank .DataSource = dt;
           cmb_bank.DisplayMember = "bnkname";
           cmb_bank.ValueMember = "pk";

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cocmb_paymentmde.Text == "Bank Transfer")
            {
             this.groupBox3.Visible =  true;

            }
            if (cocmb_paymentmde.Text == "Check Payment")
            {
                this.groupBox3.Visible = false;
            }
            if (cocmb_paymentmde.Text == "Cash")
            {
                this.groupBox3.Visible = false;
            }
            
        }


        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (employeidflag != 0)
            //{
            //    lbl_empid.Text = cmb_EmpCode.SelectedValue.ToString();


            //    DataTable basicsal = empregtrans.getBasicDesgSal(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
              
            //    if (basicsal.Rows.Count != 0)
            //    {
            //        txt_basicsal.Text = basicsal.Rows[0][0].ToString();
            //        lbl_currency.Text = basicsal.Rows[0][2].ToString();
            //        txt_basicsal.ReadOnly = true;
            //        txt_appsal.Text = basicsal.Rows[0][0].ToString();
            //        salcomponentdata(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
            //    }


            //}

            try
            {
                employecodechangedevent();
            }
            catch (Exception)
            {
                
                
            }
            }

        public void employecodechangedevent()
        {

            try
            {
                if (employeidflag != 0)
                {
                    lbl_empid.Text = cmb_EmpCode.SelectedValue.ToString();


                    DataTable basicsal = empregtrans.getBasicDesgSal(int.Parse(cmb_EmpCode.SelectedValue.ToString()));

                    if (basicsal.Rows.Count != 0)
                    {
                        txt_basicsal.Text = basicsal.Rows[0][0].ToString();
                        lbl_currency.Text = basicsal.Rows[0][2].ToString();
                        txt_basicsal.ReadOnly = true;
                        txt_appsal.Text = basicsal.Rows[0][0].ToString();
                        salcomponentdata(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                    }


                }
            }
            catch (Exception)
            {
                
             
            }
        }


        public void salcomponentdata(int empid )
        {
            tbl_deduction.Rows.Clear();
            tbl_deduction.DataSource = null;
            tbl_disbursement.Rows.Clear();
            tbl_disbursement.DataSource = null;


            tbl_SalComponentmain.Rows.Clear();
            tbl_SalComponentmain.DataSource = null;
            DataTable exceptioncomponent = empregtrans.getSalaryComponentNotInDesg(empid);
            DataTable dt = empregtrans.getAllSalCompData(empid);
            if (dt.Rows.Count != 0)
            {
                int j = 0;
                int k = 0;
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    if (dt.Rows[i][3].ToString ()=="Deduction" )
                    {
                        tbl_deduction.Rows.Add();
                       
                        tbl_deduction.Rows[j].Cells[0].Value = dt.Rows[i][0];
                        tbl_deduction.Rows[j].Cells[1].Value = dt.Rows[i][1];
                        tbl_deduction.Rows[j].Cells[2].Value = dt.Rows[i][2];
                        tbl_deduction.Rows[j].Cells[3].Value = dt.Rows[i][4];
                        tbl_deduction.Rows[j].Cells[4].Value = dt.Rows[i][5];
                        tbl_deduction.Rows[j].Cells[5].Value = dt.Rows[i][6];
                        tbl_deduction.Rows[j].Cells[6].Value = dt.Rows[i][3];
                        j++;

                    }
                    else if (dt.Rows[i][3].ToString() == "Disbursement")
                    {

                        tbl_disbursement.Rows.Add();
                        tbl_disbursement.Rows[k].Cells[0].Value = dt.Rows[i][0];
                        tbl_disbursement.Rows[k].Cells[1].Value = dt.Rows[i][1];
                        tbl_disbursement.Rows[k].Cells[2].Value = dt.Rows[i][2];
                        tbl_disbursement.Rows[k].Cells[3].Value = dt.Rows[i][4];
                        tbl_disbursement.Rows[k].Cells[4].Value = dt.Rows[i][5];
                        tbl_disbursement.Rows[k].Cells[5].Value = dt.Rows[i][6];
                        tbl_disbursement.Rows[k].Cells[6].Value = dt.Rows[i][3];
                        k++;
                    }
                }


                for (int p = 0; p < exceptioncomponent.Rows.Count; p++)
                {


                    tbl_SalComponentmain  .Rows.Add();

                    tbl_SalComponentmain.Rows[p].Cells[0].Value = exceptioncomponent.Rows[p][0];
                    tbl_SalComponentmain.Rows[p].Cells[1].Value = exceptioncomponent.Rows[p][1];
                    tbl_SalComponentmain.Rows[p].Cells[2].Value = exceptioncomponent.Rows[p][2];
                    tbl_SalComponentmain.Rows[p].Cells[3].Value = exceptioncomponent.Rows[p][4];
                    tbl_SalComponentmain.Rows[p].Cells[4].Value = exceptioncomponent.Rows[p][5];
                    tbl_SalComponentmain.Rows[p].Cells[5].Value = exceptioncomponent.Rows[p][6];
                    tbl_SalComponentmain.Rows[p].Cells[6].Value = exceptioncomponent.Rows[p][3];

                }





            }


        }


        public void gridviewsetup()
        {

            tbl_disbursement.Columns.Add("1", "SL");
            tbl_disbursement.Columns.Add("1", "COMPONENT");
            tbl_disbursement.Columns.Add("1", "TYPE");
            tbl_disbursement.Columns.Add("1", "CALCULATION");
            tbl_disbursement.Columns.Add("1", "CRITERIA ");
            tbl_disbursement.Columns.Add("1", "AMOUNT");
            tbl_disbursement.Columns.Add("1", "Filtertype");
            tbl_disbursement.Columns[6].Visible = false;
            tbl_disbursement.RowTemplate.Height = 18;
          

            tbl_deduction .Columns.Add("1", "SL");
            tbl_deduction.Columns.Add("1", "COMPONENT");
            tbl_deduction.Columns.Add("1", "TYPE");
            tbl_deduction.Columns.Add("1", "CALCULATION");
            tbl_deduction.Columns.Add("1", "CRITERIA ");
            tbl_deduction.Columns.Add("1", "AMOUNT");
            tbl_deduction.Columns.Add("1", "Filtertype");
            tbl_deduction.Columns[6].Visible = false;
            tbl_deduction.RowTemplate.Height = 18;

            tbl_SalComponentmain.Columns.Add("1", "SL");
            tbl_SalComponentmain.Columns.Add("1", "COMPONENT");
            tbl_SalComponentmain.Columns.Add("1", "TYPE");
            tbl_SalComponentmain.Columns.Add("1", "CALCULATION");
            tbl_SalComponentmain.Columns.Add("1", "CRITERIA ");
            tbl_SalComponentmain.Columns.Add("1", "AMOUNT");
            tbl_SalComponentmain.Columns.Add("1", "Filtertype");
            tbl_SalComponentmain.Columns[6].Visible = false;
            tbl_SalComponentmain.RowTemplate.Height = 18;
          

        }
        
        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            employeidflag++;
        }

        private void txt_appsal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_appsal.Text);
            }
            catch (Exception)
            {

                lblStatus.Text = "Enter Valid Approved Salary";
                txt_appsal.Text = "0";
            }
        }

        private void txt_appsal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Amount";
                txt_appsal.Text = "0";
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

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            lblStatus.BackColor = Color.Red;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (tbl_SalComponentmain.RowCount != 0)
            {

                int rowindex = tbl_SalComponentmain.CurrentRow.Index;
                if (rowindex != tbl_SalComponentmain.Rows.Count-1)
                {

                    if (tbl_SalComponentmain.Rows[rowindex].Cells[6].Value.ToString().Trim() == "Deduction")
                    {

                        int destinationrow = tbl_deduction.Rows.Count - 1;
                        tbl_deduction.Rows.Add();
                        tbl_deduction.Rows[destinationrow].Cells[0].Value = tbl_SalComponentmain.Rows[rowindex].Cells[0].Value;
                        tbl_deduction.Rows[destinationrow].Cells[1].Value = tbl_SalComponentmain.Rows[rowindex].Cells[1].Value;
                        tbl_deduction.Rows[destinationrow].Cells[2].Value = tbl_SalComponentmain.Rows[rowindex].Cells[2].Value;
                        tbl_deduction.Rows[destinationrow].Cells[3].Value = tbl_SalComponentmain.Rows[rowindex].Cells[3].Value;
                        tbl_deduction.Rows[destinationrow].Cells[4].Value = tbl_SalComponentmain.Rows[rowindex].Cells[4].Value;
                        tbl_deduction.Rows[destinationrow].Cells[5].Value = tbl_SalComponentmain.Rows[rowindex].Cells[5].Value;
                        tbl_deduction.Rows[destinationrow].Cells[6].Value = tbl_SalComponentmain.Rows[rowindex].Cells[6].Value;
                     


                    }


                    else if (tbl_SalComponentmain.Rows[rowindex].Cells[6].Value.ToString().Trim() == "Disbursement")
                    {

                        int destinationrow = tbl_disbursement.Rows.Count - 1;
                        tbl_disbursement.Rows.Add();
                        tbl_disbursement.Rows[destinationrow].Cells[0].Value = tbl_SalComponentmain.Rows[rowindex].Cells[0].Value;
                        tbl_disbursement.Rows[destinationrow].Cells[1].Value = tbl_SalComponentmain.Rows[rowindex].Cells[1].Value;
                        tbl_disbursement.Rows[destinationrow].Cells[2].Value = tbl_SalComponentmain.Rows[rowindex].Cells[2].Value;
                        tbl_disbursement.Rows[destinationrow].Cells[3].Value = tbl_SalComponentmain.Rows[rowindex].Cells[3].Value;
                        tbl_disbursement.Rows[destinationrow].Cells[4].Value = tbl_SalComponentmain.Rows[rowindex].Cells[4].Value;
                        tbl_disbursement.Rows[destinationrow].Cells[5].Value = tbl_SalComponentmain.Rows[rowindex].Cells[5].Value;
                        tbl_disbursement.Rows[destinationrow].Cells[6].Value = tbl_SalComponentmain.Rows[rowindex].Cells[6].Value;
                     



                    }



                    if (tbl_SalComponentmain.Rows[rowindex].Cells[0].Value  != null || tbl_SalComponentmain.Rows[rowindex].Cells[0].Value != null || tbl_SalComponentmain.Rows[rowindex].Cells[0].Value.ToString() != "")
                    {

                        tbl_SalComponentmain.Rows.Remove(tbl_SalComponentmain.Rows[rowindex]);


                    }



                }



            }
        }

        private void tbl_disbursement_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedgrid = "Disbursement";
        }

        private void tbl_deduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedgrid = "Deduction";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(selectedgrid=="Deduction")
            {
                if (tbl_deduction.Rows.Count - 1 != 0)
                {
                    if (tbl_deduction.Rows.Count != 0)
                    {
                        int rowindex = tbl_deduction.CurrentRow.Index;

                        if (rowindex != tbl_deduction.Rows.Count)
                        {


                            int destinationrow = tbl_SalComponentmain.Rows.Count - 1;

                            tbl_SalComponentmain.Rows.Add();

                            tbl_SalComponentmain.Rows[destinationrow].Cells[0].Value = tbl_deduction.Rows[rowindex].Cells[0].Value;
                            tbl_SalComponentmain.Rows[destinationrow].Cells[1].Value = tbl_deduction.Rows[rowindex].Cells[1].Value;
                            tbl_SalComponentmain.Rows[destinationrow].Cells[2].Value = tbl_deduction.Rows[rowindex].Cells[2].Value;
                            tbl_SalComponentmain.Rows[destinationrow].Cells[3].Value = tbl_deduction.Rows[rowindex].Cells[3].Value;
                            tbl_SalComponentmain.Rows[destinationrow].Cells[4].Value = tbl_deduction.Rows[rowindex].Cells[4].Value;
                            tbl_SalComponentmain.Rows[destinationrow].Cells[5].Value = tbl_deduction.Rows[rowindex].Cells[5].Value;
                            tbl_SalComponentmain.Rows[destinationrow].Cells[6].Value = tbl_deduction.Rows[rowindex].Cells[6].Value;

                            if (tbl_deduction.Rows[rowindex].Cells[0].Value != null || tbl_deduction.Rows[rowindex].Cells[0].Value != null || tbl_deduction.Rows[rowindex].Cells[0].Value.ToString() != "")
                            {

                                tbl_deduction.Rows.Remove(tbl_deduction.Rows[rowindex]);


                            }



                        }


                    }
                }
            }
            else if (selectedgrid=="Disbursement")
            {



                if (tbl_disbursement.Rows.Count - 1 != 0)
                {


                if (tbl_disbursement .Rows.Count != 0)
                {
                    int rowindex = tbl_disbursement.CurrentRow.Index;

                    if (rowindex != tbl_disbursement.Rows.Count)
                    {


                        int destinationrow = tbl_SalComponentmain.Rows.Count - 1;

                        tbl_SalComponentmain.Rows.Add();

                        tbl_SalComponentmain.Rows[destinationrow].Cells[0].Value = tbl_disbursement.Rows[rowindex].Cells[0].Value;
                        tbl_SalComponentmain.Rows[destinationrow].Cells[1].Value = tbl_disbursement.Rows[rowindex].Cells[1].Value;
                        tbl_SalComponentmain.Rows[destinationrow].Cells[2].Value = tbl_disbursement.Rows[rowindex].Cells[2].Value;
                        tbl_SalComponentmain.Rows[destinationrow].Cells[3].Value = tbl_disbursement.Rows[rowindex].Cells[3].Value;
                        tbl_SalComponentmain.Rows[destinationrow].Cells[4].Value = tbl_disbursement.Rows[rowindex].Cells[4].Value;
                        tbl_SalComponentmain.Rows[destinationrow].Cells[5].Value = tbl_disbursement.Rows[rowindex].Cells[5].Value;
                        tbl_SalComponentmain.Rows[destinationrow].Cells[6].Value = tbl_disbursement.Rows[rowindex].Cells[6].Value;

                        if (tbl_disbursement.Rows[rowindex].Cells[0].Value != null || tbl_disbursement.Rows[rowindex].Cells[0].Value != null || tbl_disbursement.Rows[rowindex].Cells[0].Value.ToString() != "")
                        {

                            tbl_disbursement.Rows.Remove(tbl_disbursement.Rows[rowindex]);


                        }


                    }
                    }


                }















            }
        }

        private void SalaryForm_Load(object sender, EventArgs e)
        {

        }

        private void cmb_bank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_currency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        
    
    
    
    
    
    }
}

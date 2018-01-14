using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR.NewFolder1
{
    public partial class EmployeeSalaryDetailsEditForm : Form
    {
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.SalaryCompTransaction salcomptrans = null;
        Transactions.currencytransaction crncytrans = null;
        Transactions.BankTransactions bnktransctn = null;
        Datalayer.employeesalarydatabean empsaldatabean = null;
        String selectedgrid = null;
        DataTable dTable = new DataTable();
        int employeidflag = 0;
        public EmployeeSalaryDetailsEditForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            salcomptrans = new Transactions.SalaryCompTransaction();
            crncytrans = new Transactions.currencytransaction();
            bnktransctn = new Transactions.BankTransactions();

            employecodeload(Program.LOCTNPK, 0, 0);
            gridviewsetup();
        }


        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
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


            tbl_deduction.Columns.Add("1", "SL");
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
                        salcomponentdata(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                    }


                }
            }
            catch (Exception)
            {


            }
        }






        public void salcomponentdata(int empid)
        {
            tbl_deduction.Rows.Clear();
            tbl_deduction.DataSource = null;
            tbl_disbursement.Rows.Clear();
            tbl_disbursement.DataSource = null;


            tbl_SalComponentmain.Rows.Clear();
            tbl_SalComponentmain.DataSource = null;
            DataTable exceptioncomponent = empregtrans.getDesgSalaryComponentNotInEmp(empid);
            DataTable dt = empregtrans.GetAssignedSalccomp(empid);
            if (dt.Rows.Count != 0)
            {
                int j = 0;
                int k = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "Deduction")
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


                    tbl_SalComponentmain.Rows.Add();

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

        public void salcomponentdatawithouytdesignation(int empid)
        {
            tbl_deduction.Rows.Clear();
            tbl_deduction.DataSource = null;
            tbl_disbursement.Rows.Clear();
            tbl_disbursement.DataSource = null;


            tbl_SalComponentmain.Rows.Clear();
            tbl_SalComponentmain.DataSource = null;
            DataTable exceptioncomponent = empregtrans.getSalaryComponentNotInDesg(empid);
            DataTable dt = empregtrans.GetAssignedSalccomp(empid);
            if (dt.Rows.Count != 0)
            {
                int j = 0;
                int k = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "Deduction")
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


                    tbl_SalComponentmain.Rows.Add();

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



        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            employeidflag++;
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            employecodechangedevent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbl_SalComponentmain.RowCount != 0)
            {

                int rowindex = tbl_SalComponentmain.CurrentRow.Index;
                if (rowindex != tbl_SalComponentmain.Rows.Count - 1)
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



                    if (tbl_SalComponentmain.Rows[rowindex].Cells[0].Value != null || tbl_SalComponentmain.Rows[rowindex].Cells[0].Value != null || tbl_SalComponentmain.Rows[rowindex].Cells[0].Value.ToString() != "")
                    {

                        tbl_SalComponentmain.Rows.Remove(tbl_SalComponentmain.Rows[rowindex]);


                    }



                }



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedgrid == "Deduction")
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
            else if (selectedgrid == "Disbursement")
            {



                if (tbl_disbursement.Rows.Count - 1 != 0)
                {


                    if (tbl_disbursement.Rows.Count != 0)
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

        private void tbl_disbursement_MouseClick(object sender, MouseEventArgs e)
        {
            selectedgrid = "Disbursement";
        }

        private void tbl_deduction_MouseClick(object sender, MouseEventArgs e)
        {
            selectedgrid = "Deduction";
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            dTable = new DataTable();
            DataColumn auto = new DataColumn("empid", typeof(System.Int32));
            dTable.Columns.Add(auto);

            DataColumn salcompK = new DataColumn("salcompK", typeof(string));
            dTable.Columns.Add(salcompK);

            DataColumn amount = new DataColumn("Amount", typeof(string));
            dTable.Columns.Add(amount);

            DataRow row = null;


           

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



                empregtrans.updatesalarycomponentOfEmp(dTable,int.Parse (cmb_EmpCode.SelectedValue.ToString ()));
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated");





        }

        private void button1_Click(object sender, EventArgs e)
        {
            salcomponentdatawithouytdesignation(int.Parse (cmb_EmpCode.SelectedValue .ToString()));
        }



    }
}

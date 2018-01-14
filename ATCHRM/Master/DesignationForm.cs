using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class DesignationForm : Form
    {
        Transactions.currencytransaction crncytrans = null;
        Transactions.SalaryCompTransaction salcomptrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.LeaveTransaction lvtrans = null;
        Datalayer.DesignationDatabean dsgnationdatbean = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Datalayer.ApplicableSalaryCompDesg aaplicsaldata = null;
        Transactions.Helper hlpr = null;
        ArrayList desgnationdata = new ArrayList();
        int desg = 0;
        public DesignationForm()
        {
            InitializeComponent();

            crncytrans = new Transactions.currencytransaction();
            salcomptrans = new Transactions.SalaryCompTransaction();
            lvtrans = new Transactions.LeaveTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            hlpr = new Transactions.Helper();

            cmb_grade.SelectedIndex = 0;

        }


        public DesignationForm(ArrayList desgdata,  int desgpk)
        {
            InitializeComponent();

            crncytrans = new Transactions.currencytransaction();
            salcomptrans = new Transactions.SalaryCompTransaction();
            lvtrans = new Transactions.LeaveTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            hlpr = new Transactions.Helper();
            //getapplicableleavesandnonapplicableleaves(desgpk);
            desgnationdata = desgdata;
            desg = desgpk;
            filldetails(desgdata);
            btn_updateLeave.Visible = true;
            btn_submitt.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Master.CurrencyForm crncy = new CurrencyForm();
            crncy.ShowDialog();
            fillcurrency();
        }

     

        private void DesignationForm_Load(object sender, EventArgs e)
        {
            fillcurrency();
          
            Datagridviewsetup();

       
      
             getsalCompdetails();
             getallDeparment();
      

       if (desg != 0 && desgnationdata.Count!=0)
       {
           getapplicableleavesandnonapplicableleaves(desg);
           filldetails(desgnationdata);
       }
       else
       {
      
           getallleave();
       }
        }




        /// <summary>
        /// get all the sal component present in database
        /// if is applicable for all designation the
        /// row will be entered inthe applicablecomponenttbl
        /// </summary>
        public void getsalCompdetails()
        {
          
            DataTable dt = salcomptrans.getAllSalCompData();
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_AllSalComp.Rows.Add();
                tbl_AllSalComp.Rows[i].Cells[0].Value = dt.Rows[i][0];
                tbl_AllSalComp.Rows[i].Cells[1].Value = dt.Rows[i][1];
                tbl_AllSalComp.Rows[i].Cells[2].Value = dt.Rows[i][2];
                tbl_AllSalComp.Rows[i].Cells[3].Value = dt.Rows[i][4];
                tbl_AllSalComp.Rows[i].Cells[4].Value = dt.Rows[i][5];
                tbl_AllSalComp.Rows[i].Cells[5].Value = dt.Rows[i][6];

            }
            int k = 0;
            for (int j = 0; j < tbl_AllSalComp.Rows.Count -1; j++)
            {
               

                if (tbl_AllSalComp.Rows[j].Cells[4].Value.ToString().Trim() == "Amount Fixed For All Employee")
                {
                    tbl_ApplicableSalComp.Rows.Add();
                    tbl_ApplicableSalComp.Rows[k].Cells[0].Value = tbl_AllSalComp.Rows[j].Cells[0].Value;
                    tbl_ApplicableSalComp.Rows[k].Cells[1].Value = tbl_AllSalComp.Rows[j].Cells[1].Value;
                    tbl_ApplicableSalComp.Rows[k].Cells[2].Value = tbl_AllSalComp.Rows[j].Cells[2].Value;
                    tbl_ApplicableSalComp.Rows[k].Cells[3].Value = tbl_AllSalComp.Rows[j].Cells[3].Value;
                    tbl_ApplicableSalComp.Rows[k].Cells[4].Value = tbl_AllSalComp.Rows[j].Cells[4].Value;
                    tbl_ApplicableSalComp.Rows[k].Cells[5].Value = tbl_AllSalComp.Rows[j].Cells[5].Value;
                    k++;
                    tbl_AllSalComp.Rows.Remove(tbl_AllSalComp.Rows[j]);
                
                }
            }

           

       //     tbl_AllSalComp.Rows.Remove(tbl_AllSalComp.Rows[3]);
           // tbl_AllSalComp.Rows.Remove(tbl_AllSalComp.Rows[2]);
           /// tbl_AllSalComp.Rows.Remove(tbl_AllSalComp.Rows[tbl_AllSalComp.Rows.Count - 1]);

        }
        /// <summary>
        ///will get all thew department from the database and will 
        ///display it in combobox
        /// </summary>
        public void getallDeparment()
        {
            DataTable dt = depttrans.getDeptName();
            CmbDept.DataSource = dt;
            CmbDept.DisplayMember = "DepartmentName";
            CmbDept.ValueMember = "DepartmentPK";
        }




        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (validationcontrol())
        //        {
        //            dsgnationdatbean = new Datalayer.DesignationDatabean();
        //            dsgnationdatbean.DesignationName1 = txt_DesignationName.Text;
        //            dsgnationdatbean.Description1 = rht_description.Text;
        //            dsgnationdatbean.Levelno1 = cmb_grade.Text;
        //            dsgnationdatbean.Currencypk = int.Parse(cmb_currency.SelectedValue.ToString());
        //            dsgnationdatbean.Basicsal = int.Parse(txt_basic.Text);
        //            dsgnationdatbean.Departmentpk = int.Parse(CmbDept.SelectedValue.ToString());
        //            dsgnationdatbean.Appsal = getapplicableSalComponent();

        //            dsgtrans.insertDesignastionData(dsgnationdatbean);
        //             ATCHRM.Controls.ATCHRMMessagebox.Show(" Designation Sucessfully Added");
        //            closewindows();

        //        }
        //    }
        //    catch (Exception exp)
        //    {
                
        //           if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
        //        {
        //             ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
        //        }


        //        ErrorLogger er = new ErrorLogger();
        //        er.createErrorLog(exp);
        //         ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
        //        this.Dispose();
        //    }
        //}



        public void clearcontrol()
        {
            txt_basic.Text = "00";
            txt_DesignationName.Text = "";
            CmbDept.SelectedIndex = 0;
            cmb_grade.SelectedIndex  = 0;

            getsalCompdetails();

            getallleave();
            
        }



        /// <summary>
        /// designs datagridview and set coloum,ns for the same
        /// </summary>
        public void Datagridviewsetup()
        {
           
           
            tbl_AllSalComp.Columns.Add("1", "Sl");
            tbl_AllSalComp.Columns.Add("1", "Component");
            tbl_AllSalComp.Columns.Add("1", "Type");
            tbl_AllSalComp.Columns.Add("1", "Calc");
            tbl_AllSalComp.Columns.Add("1", "Criteria ");
            tbl_AllSalComp.Columns.Add("1", "Amount");
            tbl_AllSalComp.RowTemplate.Height = 18;
            tbl_AllSalComp.Columns[0].Visible = false;

            tbl_ApplicableSalComp.Columns.Add("1", "Sl");
            tbl_ApplicableSalComp.Columns.Add("1", "Component");
            tbl_ApplicableSalComp.Columns.Add("1", "Type");
            tbl_ApplicableSalComp.Columns.Add("1", "Calc");
            tbl_ApplicableSalComp.Columns.Add("1", "Criteria ");
            tbl_ApplicableSalComp.Columns.Add("1", "Amount");
            tbl_ApplicableSalComp.RowTemplate.Height = 18;
            tbl_ApplicableSalComp.Columns[0].Visible = false;
            tbl_ApplicableSalComp.Columns[5].ReadOnly  = false;



            tbl_AllLeave.Columns.Add("1", "SL");
            tbl_AllLeave.Columns.Add("1", "Leave");
            tbl_AllLeave.Columns[0].Visible = false;
            tbl_AllLeave.RowTemplate.Height = 18;


            tbl_ApplicableLeave.Columns.Add("1", "SL");
            tbl_ApplicableLeave.Columns.Add("1", "Leave");
            tbl_ApplicableLeave.Columns[0].Visible = false;
            tbl_ApplicableLeave.RowTemplate.Height = 18;


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

        public void filldetails(ArrayList desgdata)
        {
            txt_DesignationName.Text = desgdata[0].ToString();
            rht_description.Text = desgdata[1].ToString();
            cmb_grade.Text = desgdata[2].ToString();
            CmbDept.Enabled = false;
           // cmb_grade.Enabled = false;
            CmbDept.Text = desgdata[3].ToString();
            txt_basic.Text = desgdata[4].ToString();
            cmb_currency.Text = desgdata[5].ToString();
        }
       

        /// <summary>
        /// will get all leave against 
        /// 
        /// </summary>
        public void getallleave()
        {
          
            DataTable dt = lvtrans.getAllLeaveData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_AllLeave.Rows.Add();
                tbl_AllLeave.Rows[i].Cells[0].Value = dt.Rows[i][0];
                tbl_AllLeave.Rows[i].Cells[1].Value = dt.Rows[i][1];
                // tbl_AllLeave.Rows[i].Cells[2].Value = dt.Rows[i][2];

            }

        }

        public void getapplicableleavesandnonapplicableleaves(int desgpk)
        {
            DataTable dt1 = lvtrans.getapplicableleavesname(desgpk);
            DataTable dt2 = lvtrans.GetAllNonApplicableLeavenamesOnly(desgpk);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                tbl_AllLeave.Rows.Add();
                tbl_AllLeave.Rows[i].Cells[0].Value = dt2.Rows[i][0];
                tbl_AllLeave.Rows[i].Cells[1].Value = dt2.Rows[i][1];
                // tbl_AllLeave.Rows[i].Cells[2].Value = dt.Rows[i][2];

            }

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                tbl_ApplicableLeave.Rows.Add();
                tbl_ApplicableLeave.Rows[i].Cells[0].Value = dt1.Rows[i][0];
                tbl_ApplicableLeave.Rows[i].Cells[1].Value = dt1.Rows[i][1];
                // tbl_AllLeave.Rows[i].Cells[2].Value = dt.Rows[i][2];

            }
        }


        private void tbl_AllSalComp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != tbl_AllSalComp.Rows.Count)
            {

                tbl_ApplicableSalComp.Rows.Add();

                int destinationrow = tbl_ApplicableSalComp.Rows.Count - 1;
                for (int i = 0; i < tbl_AllSalComp.ColumnCount; i++)
                {


                    tbl_ApplicableSalComp.Rows[destinationrow].Cells[i].Value = tbl_AllSalComp.Rows[e.RowIndex].Cells[i].Value;

                }
                if (tbl_ApplicableSalComp.Rows[destinationrow].Cells[4].Value.ToString().Trim() == "Amount Variable For Each Designation")
                {
                    Master.Salcomponentdataform dataform = new Salcomponentdataform();
                    dataform.ShowDialog();
                    String amount = dataform.Amount;
                    if (amount == null || amount == "")
                    {
                        amount = "0";

                    }
                    tbl_ApplicableSalComp.Rows[destinationrow].Cells[5].Value = amount;
                }

                if (tbl_AllSalComp.Rows[e.RowIndex].Cells[0] != null || tbl_AllSalComp.Rows[e.RowIndex].Cells[0].Value != null || tbl_AllSalComp.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
                {

                    tbl_AllSalComp.Rows.Remove(tbl_AllSalComp.Rows[e.RowIndex]);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tbl_AllSalComp.RowCount != 0)
            {
                int rowindex = tbl_AllSalComp.CurrentRow.Index;

                if (rowindex != tbl_AllSalComp.Rows.Count)
                {

                    tbl_ApplicableSalComp.Rows.Add();

                    int destinationrow = tbl_ApplicableSalComp.Rows.Count - 1;
                    for (int i = 0; i < tbl_AllSalComp.ColumnCount; i++)
                    {


                        tbl_ApplicableSalComp.Rows[destinationrow].Cells[i].Value = tbl_AllSalComp.Rows[rowindex].Cells[i].Value;

                    }
                    if (tbl_ApplicableSalComp.Rows[destinationrow].Cells[4].Value.ToString().Trim() == "Amount Variable For Each Designation")
                    {
                        Master.Salcomponentdataform dataform = new Salcomponentdataform();
                        dataform.ShowDialog();
                        String amount = dataform.Amount;
                        if (amount == null || amount == "")
                        {
                            amount = "0";

                        }
                        tbl_ApplicableSalComp.Rows[destinationrow].Cells[5].Value = amount;
                    }

                    if (tbl_AllSalComp.Rows[rowindex].Cells[0] != null || tbl_AllSalComp.Rows[rowindex].Cells[0].Value != null || tbl_AllSalComp.Rows[rowindex].Cells[0].Value.ToString() != "")
                    {

                        tbl_AllSalComp.Rows.Remove(tbl_AllSalComp.Rows[rowindex]);


                    }

                }


            }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            int rowindex = tbl_AllLeave.CurrentRow.Index;

            if (rowindex != tbl_AllLeave.Rows.Count - 1)
            {

                tbl_ApplicableLeave.Rows.Add();

                int destinationrow = tbl_ApplicableLeave.Rows.Count - 1;
                for (int i = 0; i < tbl_AllLeave.ColumnCount; i++)
                {


                    tbl_ApplicableLeave.Rows[destinationrow].Cells[i].Value = tbl_AllLeave.Rows[rowindex].Cells[i].Value;


                }

                if (tbl_AllLeave.Rows[rowindex].Cells[0] != null || tbl_AllLeave.Rows[rowindex].Cells[0].Value != null || tbl_AllLeave.Rows[rowindex].Cells[0].Value.ToString() != "")
                {

                    tbl_AllLeave.Rows.Remove(tbl_AllLeave.Rows[rowindex]);
                }
            
            
            }

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbl_ApplicableSalComp.Rows.Count!=0)
            {


                int rowindex = tbl_ApplicableSalComp.CurrentRow.Index;

                if (rowindex != tbl_ApplicableSalComp.Rows.Count)
                {

                    tbl_AllSalComp.Rows.Add();

                    int destinationrow = tbl_AllSalComp.Rows.Count - 1;
                    for (int i = 0; i < tbl_ApplicableSalComp.ColumnCount; i++)
                    {


                        tbl_AllSalComp.Rows[destinationrow].Cells[i].Value = tbl_ApplicableSalComp.Rows[rowindex].Cells[i].Value;

                    }


                    if (tbl_ApplicableSalComp.Rows[rowindex].Cells[0] != null || tbl_ApplicableSalComp.Rows[rowindex].Cells[0].Value != null || tbl_ApplicableSalComp.Rows[rowindex].Cells[0].Value.ToString() != "")
                    {

                        tbl_ApplicableSalComp.Rows.Remove(tbl_ApplicableSalComp.Rows[rowindex]);


                    }

                }




            }








        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tbl_ApplicableLeave.Rows.Count != 0)
            {
                int rowindex = tbl_ApplicableLeave.CurrentRow.Index;

                if (rowindex != tbl_ApplicableLeave.Rows.Count)
                {

                    tbl_AllLeave.Rows.Add();

                    int destinationrow = tbl_AllLeave.Rows.Count - 2;
                    for (int i = 0; i < tbl_ApplicableLeave.ColumnCount; i++)
                    {


                        tbl_AllLeave.Rows[destinationrow].Cells[i].Value = tbl_ApplicableLeave.Rows[rowindex].Cells[i].Value;


                    }

                    if (tbl_ApplicableLeave.Rows[rowindex].Cells[0] != null || tbl_ApplicableLeave.Rows[rowindex].Cells[0].Value != null || tbl_ApplicableLeave.Rows[rowindex].Cells[0].Value.ToString() != "")
                    {

                        tbl_ApplicableLeave.Rows.Remove(tbl_ApplicableLeave.Rows[rowindex]);
                    }


                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
                        tbl_AllSalComp.Rows.Remove(tbl_AllSalComp.Rows[tbl_AllSalComp .CurrentRow.Index ]);
        }



        /// <summary>
        /// validates the controls
        /// </summary>
        /// <returns></returns>
        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (txt_DesignationName.Text == null || txt_DesignationName.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Designation  Name";
                txt_DesignationName.Focus();
                txt_DesignationName.Visible = true;

            }


            else if (cmb_grade.Text == null || cmb_grade.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Grade for Designation ";
                cmb_grade.Focus();
                cmb_grade.Visible = true;

            }
            else if (cmb_type.Text == null || cmb_type.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Type of Designation ";
                cmb_type.Focus();
                cmb_type.Visible = true;

            }
            else if (rht_description.Text == null || rht_description.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Job Description";
                rht_description.Focus();
                rht_description.Visible = true;

            }
            else if (txt_basic.Text == null || txt_basic.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Basic Salary  ";
                txt_basic.Focus();
                

            }


            else if (cmb_currency.Text == null || cmb_currency.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Currency ";
                cmb_currency.Focus();


            }
            else if (CmbDept.Text == null || CmbDept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter  Department";
                CmbDept.Focus();


            }



            else
            {
                sucess = true;
            }


            return sucess;
        }

        public void closewindows()
        {
            Master.DesignationMasterForm mstrfrm = new DesignationMasterForm();
            this.Close ();
            mstrfrm.MdiParent = this.MdiParent;
            mstrfrm.Show();

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

        private void txt_basic_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_basic.Text);
            }
            catch (Exception )
            {

                lblStatus.Text = "Enter Valid Salary";
                txt_basic.Text = "0";
            }
        }

        private void txt_basic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Salary";
                txt_basic.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }


        public Datalayer.ApplicableSalaryCompDesg  getapplicableSalComponent()
        {
            aaplicsaldata = new Datalayer.ApplicableSalaryCompDesg();
            aaplicsaldata.Salcompid1= new System.Collections.ArrayList();
            aaplicsaldata.SaCompAmount = new System.Collections.ArrayList();
             aaplicsaldata.Applicableleave=new System.Collections.ArrayList();
          
            for (int i = 0; i < tbl_ApplicableSalComp.RowCount ; i++)
            {
                aaplicsaldata.Salcompid1.Add(tbl_ApplicableSalComp.Rows[i].Cells[0].Value );
                aaplicsaldata.SaCompAmount.Add(tbl_ApplicableSalComp.Rows[i].Cells[5].Value);
            }

            for (int j = 0; j < tbl_ApplicableLeave.RowCount; j++)
            {

                aaplicsaldata.Applicableleave.Add(tbl_ApplicableLeave.Rows[j].Cells[0].Value);
            }

            return aaplicsaldata;
        }

        private void tbl_AllSalComp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbl_ApplicableSalComp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {

                if (validationcontrol())
                {
                    dsgnationdatbean = new Datalayer.DesignationDatabean();
                    dsgnationdatbean.DesignationName1 = txt_DesignationName.Text;
                    dsgnationdatbean.Description1 = rht_description.Text;
                    dsgnationdatbean.Levelno1 = cmb_grade.Text;
                    dsgnationdatbean.Currencypk = int.Parse(cmb_currency.SelectedValue.ToString());
                    dsgnationdatbean.Basicsal = int.Parse(txt_basic.Text);
                    dsgnationdatbean.Departmentpk = int.Parse(CmbDept.SelectedValue.ToString());
                    dsgnationdatbean.Appsal = getapplicableSalComponent();

                    dsgtrans.insertDesignastionData(dsgnationdatbean);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(" Designation Done");
                    hlpr.ClearFormControls(this);

                }
            }
            catch (Exception exp)
            {

                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Designation Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            hlpr.ClearFormControls(this);


          
        }

        //private void btn_updateLeave_Click(object sender, EventArgs e)
        //{
        //    ArrayList leaveapplicable = new ArrayList();

        //    for (int j = 0; j < tbl_ApplicableLeave.RowCount; j++)
        //    {
        //        leaveapplicable.Add(int.Parse (tbl_ApplicableLeave.Rows[j].Cells[0].Value.ToString ()));
               
        //    }

        //    dsgtrans.UpdateLeaveOfDesignation(leaveapplicable,desg);
        //     ATCHRM.Controls.ATCHRMMessagebox.Show("Sucess");
        //}



        public void updatedesignationData()
        {
            ArrayList Desgarrylist = new ArrayList();

            Desgarrylist.Add(txt_DesignationName.Text);
            Desgarrylist.Add (rht_description.Text) ;
            Desgarrylist.Add(cmb_grade.Text);
            Desgarrylist.Add(int.Parse(txt_basic.Text));
            Desgarrylist.Add (int.Parse(cmb_currency.SelectedValue.ToString ()));

        }

        private void btn_updateLeave_Click_1(object sender, EventArgs e)
        {
            ArrayList leaveapplicable = new ArrayList();


            ArrayList Desgarrylist = new ArrayList();

            Desgarrylist.Add(txt_DesignationName.Text);
            Desgarrylist.Add(rht_description.Text);
            Desgarrylist.Add(cmb_grade.Text);
            Desgarrylist.Add(int.Parse(txt_basic.Text));
            Desgarrylist.Add(int.Parse(cmb_currency.SelectedValue.ToString()));



         

            //if (cmb_type.Text == "Ma3")
            //{
            //    dsgnationdatbean.Desgtype = 22;

            //}
            //else
            //{
            //    dsgnationdatbean.Desgtype = 0;
            //}
            for (int j = 0; j < tbl_ApplicableLeave.RowCount; j++)
            {
                leaveapplicable.Add(int.Parse(tbl_ApplicableLeave.Rows[j].Cells[0].Value.ToString()));

            }

            dsgtrans.UpdateLeaveOfDesignation(leaveapplicable, desg ,Desgarrylist );
             ATCHRM.Controls.ATCHRMMessagebox.Show("Designation Details Updated");
            hlpr.ClearFormControls(this);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            //clearcontrol();
            hlpr.ClearFormControls(this);
        }

        private void btn_submitt_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (validationcontrol())
                {
                    dsgnationdatbean = new Datalayer.DesignationDatabean();

                    if (cmb_grade.Text == "NA")
                    {
                        dsgnationdatbean.DesignationName1 = txt_DesignationName.Text;
                    }
                    else
                    {
                        dsgnationdatbean.DesignationName1 = txt_DesignationName.Text + "-"+cmb_grade.Text;
                    }
                    if (cmb_type .Text.Trim () == "MA3")
                    {
                        dsgnationdatbean.Desgtype =22;
                        dsgnationdatbean.DesignationName1 = dsgnationdatbean.DesignationName1 + "-" + "(MTP)";
                    }
                    else
                    {
                        dsgnationdatbean.Desgtype = 0;
                    }
                   
                    dsgnationdatbean.Description1 = rht_description.Text;
                    dsgnationdatbean.Levelno1 = cmb_grade.Text;
                    dsgnationdatbean.Currencypk = int.Parse(cmb_currency.SelectedValue.ToString());
                    dsgnationdatbean.Basicsal = int.Parse(txt_basic.Text);
                    dsgnationdatbean.Departmentpk = int.Parse(CmbDept.SelectedValue.ToString());
                    dsgnationdatbean.Appsal = getapplicableSalComponent();

                    dsgtrans.insertDesignastionData(dsgnationdatbean);
                     ATCHRM.Controls.ATCHRMMessagebox.Show(" Designation Created");
                    hlpr.ClearFormControls(this);

                }
            }
            catch (Exception exp)
            {

                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Designation Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
        }

        private void btn_cancell_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbl_ApplicableSalComp_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_ApplicableSalComp .IsCurrentCellDirty)
            {
                tbl_ApplicableSalComp.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbl_ApplicableLeave_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_ApplicableLeave.IsCurrentCellDirty)
            {
                tbl_ApplicableLeave.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbl_AllSalComp_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_AllSalComp.IsCurrentCellDirty)
            {
                tbl_AllSalComp.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbl_AllLeave_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_AllLeave.IsCurrentCellDirty)
            {
                tbl_AllLeave.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }


    }
}

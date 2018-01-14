using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient ;

namespace ATCHRM.HR.NewFolder1
{      
    public partial class EmployeedataEdit : Form
    {
        Datalayer.EmployeePersonaldatabean empdb = null;
        
      
        Transactions.EmployeeRegTransaction reg = null;
        Transactions.ShiftTransactionNewform shfttransaction = null;
        Datalayer.EmployeeDesignationDataBean empdsgbean = null;
        Datalayer.EmployeeContractDatabean empcontrctdatbean = null;
        Datalayer.EmployeeShiftDatabean shftdatbean = null;
        Datalayer.employeesalarydatabean empsaldatabean = null;
        Transactions.currencytransaction crncytrans = null;
        Transactions.BankTransactions bnktransctn = null;
        DataTable employyeapplicableleave = null;
        int empflag = 0;
        DataTable dTable = new DataTable();
       
        DataTable dt = null;
        int empid = 0;
        int clickcomboflag = 0;
        int shftflag = 0;
        String emp_code = "";
        Transactions.AnualContractrenewal annul = null;






        DataTable emppersonaldata= null;
        DataTable employeecontractdata = null;
        DataTable employeesalarydata = null;
        DataTable EmployeeShiftdata = null;
        DataTable employeeleavedata = null;

        public EmployeedataEdit()
        {
            InitializeComponent();
            reg = new Transactions.EmployeeRegTransaction();

        }

        public EmployeedataEdit(int empid)
        {
            InitializeComponent();
            reg = new Transactions.EmployeeRegTransaction();
        }







        /// <summary>
        /// loads the employee who are not fully active
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload1(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataTable dt = reg.getActiveEmployee();
            cmb.DataSource = dt;
            cmb.DisplayMember = "empno";
            cmb.ValueMember = "empid";


            lbl_emppk.Text = cmb_EmpCode.SelectedValue.ToString();
        }

        private void EmployeedataEdit_Load(object sender, EventArgs e)
        {
            employecodeload1(cmb_empcodemain);
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (empflag != 0)
            {
                empid = int.Parse(cmb_empcodemain.SelectedValue.ToString());

                datafilloption();
            }
        }

        private void roundButton1_MouseEnter(object sender, EventArgs e)
        {
            roundButton1.UseVisualStyleBackColor = false;
            roundButton1.BackColor = Color.DarkOliveGreen;
        }

        private void roundButton1_MouseLeave(object sender, EventArgs e)
        {
            roundButton1.UseVisualStyleBackColor = true;

        }

        private void cmb_empcodemain_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cmb_empcodemain_MouseClick(object sender, MouseEventArgs e)
        {
            empflag++;
        }

        /// <summary>
        /// fill the data according to the selected tab
        /// if the personal tab is selected that data is filled 
        /// if contract is selected that data is filled
        /// 
        /// </summary>
        public void datafilloption()
        {
            if (tabControl1.SelectedTab == tb_personal)
            {
            emppersonaldata=    reg.getalltheemployeedataforedit(empid, "Personal");
            datafilloncontroll(emppersonaldata);
            }
            else if (tabControl1.SelectedTab == tb_contract )
            {
            employeecontractdata=    reg.getalltheemployeedataforedit(int.Parse(cmb_empcodemain.SelectedValue.ToString()), "Contract");
            DatafilldesignationData(employeecontractdata);
            }
            else if (tabControl1.SelectedTab == tb_salary )
            {
             employeesalarydata=   reg.getalltheemployeedataforedit(int.Parse(cmb_empcodemain.SelectedValue.ToString()), "Salary");
            }
            else if (tabControl1.SelectedTab == tb_Shift)
            {
              EmployeeShiftdata=  reg.getalltheemployeedataforedit(int.Parse(cmb_empcodemain.SelectedValue.ToString()), "Shift");
            }
            else if (tabControl1.SelectedTab == tb_PhotoGraph)
            {
                reg.getalltheemployeedataforedit(int.Parse(cmb_empcodemain.SelectedValue.ToString()), "Photograph");
            }
        }







        public void datafilloncontroll(DataTable employeedata)
        {


            if (employeedata != null)
            {
                if (employeedata.Rows.Count != 0)
                {


                    cmb_Country.Text  = employeedata.Rows[0][1].ToString();
                    textNid.Text = employeedata.Rows[0][2].ToString();
                    textpp.Text = employeedata.Rows[0][3].ToString();
                    comboGender.Text = employeedata.Rows[0][4].ToString();
                    combostatus.Text = employeedata.Rows[0][5].ToString();


                    txt_firstname .Text = employeedata.Rows[0][6].ToString();
                    txt_lastname.Text = employeedata.Rows[0][7].ToString();
                   rht_address1  .Text = employeedata.Rows[0][8].ToString();
                   rht_address2.Text = employeedata.Rows[0][9].ToString();
                    
                 //   EmployeContactForm lctn=
                    
                    txt_tel.Text = employeedata.Rows[0][11].ToString();
                    txt_mob.Text = employeedata.Rows[0][12].ToString();
                    txt_email.Text = employeedata.Rows[0][13].ToString();
                    txt_refname.Text = employeedata.Rows[0][14].ToString();
                    rht_details .Text = employeedata.Rows[0][15].ToString();
                    txt_refmobile .Text = employeedata.Rows[0][16].ToString();
                    txt_refemail.Text = employeedata.Rows[0][17].ToString(); 

                 
                    textkinnme .Text = employeedata.Rows[0][18].ToString();
                    combokinrel .Text = employeedata.Rows[0][19].ToString();
                    textkinmail.Text = employeedata.Rows[0][20].ToString(); 
                    textkinmob.Text = employeedata.Rows[0][21].ToString();
                    
                    










                }

            }









        }


        public void DatafilldesignationData(DataTable employeecontractdata)
        {
            if (employeecontractdata != null)
            {
                if (employeecontractdata.Rows.Count != 0)
                {
                }
            }
        }





    }
}

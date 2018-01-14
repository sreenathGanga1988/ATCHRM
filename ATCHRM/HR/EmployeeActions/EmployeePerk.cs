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
    public partial class EmployeePerkForm : Form
    {
        Transactions.PerkTransaction prktrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empreg = null;
        int deptflag = 0;
        int locationflag = 0;
        public EmployeePerkForm()
        {
            InitializeComponent();
            prktrans = new Transactions.PerkTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            depttrans = new Transactions.DepartmentTransaction();
            empreg = new Transactions.EmployeeRegTransaction();
        }
        public void fillperk()
        {
            try
            {
                DataTable dt = prktrans.GetAllPerkandAmount();
                tbl_perk.RowCount = 1;
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tbl_perk.Rows.Add();

                            tbl_perk.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                            tbl_perk.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                            tbl_perk.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                            tbl_perk.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                            tbl_perk.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();



                        }
                    }
                }
            }
            catch (Exception EXP)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(EXP);

            }
        }









        public void insertemployeeperk()
        {

            if (tbl_perk.Rows.Count > 0)
            {
                for (int i = 0; i < tbl_perk.Rows.Count - 1; i++)
                {
                    int perkpk = 0;
                    float amount = 0;
                    float taxablepercent = 0;
                    float taxableamount = 0;
                    int empid = int.Parse(cmb_empcode.SelectedValue.ToString());
                    perkpk = int.Parse(tbl_perk.Rows[i].Cells[0].Value.ToString());
                    taxablepercent = float.Parse(tbl_perk.Rows[i].Cells[3].Value.ToString());

                    amount = float.Parse(tbl_perk.Rows[i].Cells[4].Value.ToString());

                    taxableamount = (amount / 100) * taxablepercent;
                    empreg.insertperk(empid, perkpk, amount, taxableamount);
                }
            }

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
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empreg.getEmpcode(Program.LOCTNPK , dept, desg);
            cmb_empcode.DataSource = dt;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
        }

        private void EmployeePerk_Load(object sender, EventArgs e)
        {
            fillperk();
            locationListLoad();
            DeptcomboLoad();
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
            {

                 MessageBox.Show ("Enter the Branch location");
               

            }
            else
            {
                if (locationflag != 0 && deptflag != 0)
                {
                    employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                }
            }
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptflag++;
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            locationflag++;
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            insertemployeeperk();
            MessageBox.Show("Done");
        }
    }
}
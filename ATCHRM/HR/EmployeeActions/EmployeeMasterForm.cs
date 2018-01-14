using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop;
namespace ATCHRM.HR.NewFolder1
{
    public partial class EmployeeMasterForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DataExporter DTPEXPTR = null;
        DataTable dt = new DataTable();
        int deptclickflag = 0;
        public EmployeeMasterForm()
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            locationListLoad();
            dataGridView1.RowTemplate.Height = 19;
            //dataGridView1.ColumnCount = 14;
            //dataGridView1.Rows.Add();
            //dataGridView1.Rows.Add();

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

        private void button3_Click(object sender, EventArgs e)
        {

            if (Program.UserType == "A")
            {

                if (cmb_location.Text == "")
                {
                    dt = empreg.getAllemployeedataofLocation(0);
                }
                else
                {
                    dt = empreg.getAllemployeedataofLocation(int.Parse(cmb_location.SelectedValue.ToString()));
                }
            }
            else
            {
                if (cmb_location.Text != "")
                {
                    dt = empreg.getAllemployeedataofLocation(int.Parse(cmb_location.SelectedValue.ToString()));

                }
                else
                {
                    dt = empreg.getAllemployeedataofLocation(int.Parse(Program.LOCTNPK.ToString()));
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Frozen = true;

        }

        private void rbt_department_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_department.Checked == true)
            {
                grp_dept.Enabled = true;
                DeptcomboLoad();
            }
            else
            {
                grp_dept.Enabled = false;
            }



        }


        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }



        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cmb_dept.Text.Trim() == "")
                {

                    dataGridView1.DataSource = dt;
                }

                else
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = " DepartmentName like '%" + cmb_dept.Text.Trim() + "%' ";

                }


                dataGridView1.Columns[5].Frozen = true;
            }
            catch (Exception) { }

        }

        public void getallDesignation()
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

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_designation.Text == null || cmb_designation.Text == "")
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = " DepartmentName like '%" + cmb_dept.Text.Trim() + "%' ";

                }
                else if (cmb_dept.Text == null || cmb_dept.Text == "")
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = " DesignationName like '%" + cmb_designation.Text.Trim() + "%' ";
                }
                else
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = " DesignationName like '%" + cmb_designation.Text.Trim() + "%'  and  DepartmentName like '%" + cmb_dept.Text.Trim() + "%' ";
                }
                dataGridView1.Columns[5].Frozen = true;
            }
            catch (Exception)
            {


            }
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptclickflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            if (deptclickflag != 0)
            {

                getallDesignation();


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_employeeregistration_Click(object sender, EventArgs e)
        {

            Master.NewFolder1.EmployeePersonalForm empreg = new Master.NewFolder1.EmployeePersonalForm();
            empreg.MdiParent = this.MdiParent;
            empreg.Show();
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            Transactions.DataExporter dxp = new Transactions.DataExporter();
            dxp.exporttoexcel(dataGridView1);

        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbt_empdetail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_Nid_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = " NationalId like '%" + txt_Nid.Text.Trim() + "%' ";
                }
            }
            catch (Exception)
            {


            }
        }



        private void txt_empname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = " empname like '%" + txt_empname.Text.Trim() + "%' ";
                }
            }
            catch (Exception)
            {


            }
        }

        private void txt_Nid_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.dataGridView1);
        }

        private void txt_empname_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbt_Status_CheckedChanged(object sender, EventArgs e)
        {

        }




        /// <summary>
        /// UNhold the employee away from payroll
        /// </summary>
        /// <param name="rowindex"></param>
        public void UnHoldEmployeePayroll(int rowindex)
        {
            if (MessageBox.Show("Are You Sure You want to UnHold the Payroll of employee " + dataGridView1.Rows[rowindex].Cells[1].Value.ToString(), "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Marking the Employee Payroll UnHold will  Add  Employee to next Payroll  Are you Sure? ", "ATCHRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    int empid = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());

                    if (empid != 0)
                    {
                        empreg.unHoldPayrollOfEmployee(empid);
                        ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    }
                }

            }
        }

        /// <summary>
        /// hold the employee away from payroll
        /// </summary>
        /// <param name="rowindex"></param>
        public void HoldEmployeePayroll(int rowindex)
        {
            if (MessageBox.Show("Are You Sure You want to Hold the Payroll of employee " + dataGridView1.Rows[rowindex].Cells[1].Value.ToString(), "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Marking the Employee Payroll Hold will  Remove Employee from next Payroll  Are you Sure? ", "ATCHRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    int empid = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());

                    if (empid != 0)
                    {
                        empreg.HoldPayrollOfEmployee(empid);
                        ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    }
                }

            }
        }
        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                int rowindex = dataGridView1.CurrentRow.Index;


                if (rowindex != 0)
                {

                    if (MessageBox.Show("Are You Sure You want to delete All employee Details of the " + dataGridView1.Rows[rowindex].Cells[1].Value.ToString(), "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {


                        if (MessageBox.Show("Are You Sure Have Made A Back Up of Data" + cmb_location.Text, "ATCHRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int empid = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());

                            if (empid != 0)
                            {
                                empreg.DeleteEmployeeFromDB(empid, 0);
                                ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                            }

                        }
                    }
                }


            }
        }

        private void holdPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                int rowindex = dataGridView1.CurrentRow.Index;
                if (rowindex != 0)
                {
                    HoldEmployeePayroll(rowindex);
                }
            }
        }

        private void unHoldPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                int rowindex = dataGridView1.CurrentRow.Index;
                if (rowindex != 0)
                {
                    UnHoldEmployeePayroll(rowindex);
                }
            }

        }

        private void editPersonalDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                int rowindex = dataGridView1.CurrentRow.Index;


                if (rowindex != 0)
                {
                    int empid = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());

                    if (empid != 0)
                    {
                        HR.NewFolder1.AddEmpEditForm frm = new AddEmpEditForm(empid, "Personal");
                        frm.Show();
                    }
                }
            }
        }

        private void blackListEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                int rowindex = dataGridView1.CurrentRow.Index;


                if (rowindex != 0)
                {
                    int empid = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());

                    if (empid != 0)
                    {
                        EmployeeDeactivationForm frm = new EmployeeDeactivationForm(empid);
                        frm.Show();
                    }
                }
                ;
            }









        }
    }
}
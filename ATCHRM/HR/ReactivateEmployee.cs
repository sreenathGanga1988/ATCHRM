using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR
{
    public partial class ReactivateEmployee : Form
    {
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        public ReactivateEmployee()
        {
            empreg = new Transactions.EmployeeRegTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if(cmb_location.Text.Trim()!="")
            {
            DataTable deactivateddata = empreg.getallDeactivatedEmployees(int.Parse(cmb_location.SelectedValue.ToString()));
            DataTable reactivateddata = empreg.getallReactivatedEmployees(int.Parse(cmb_location.SelectedValue.ToString()));

            if (deactivateddata.Rows.Count !=0)
                {
            dataGridView1.DataSource = deactivateddata;
            dataGridView1.Columns[5].Frozen = true;
                }
            if (reactivateddata.Rows.Count != 0)
            {
                dataGridView2.DataSource = reactivateddata;
                dataGridView2.Columns[5].Frozen = true;
            }
              
            }
        }

        private void ReactivateEmployee_Load(object sender, EventArgs e)
        {
            locationListLoad();
        }

        private void reactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                int rowindex = dataGridView1.CurrentRow.Index;
                if (rowindex != 0)
                {
                    ReactivateEmployeefun(rowindex);
                }
            }
        }




        /// <summary>
        /// hold the employee away from payroll
        /// </summary>
        /// <param name="rowindex"></param>
        public void ReactivateEmployeefun(int rowindex)
        {
            if (MessageBox.Show("Are You Sure You want to Reactivate  employee " + dataGridView1.Rows[rowindex].Cells[1].Value.ToString(), "ATCHRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Marking the Employee Active  will  Add  Employee to  next Payroll  Are you Sure? ", "ATCHRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    int empid = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());

                    if (empid != 0)
                    {
                        empreg.ReactivateEmployee(empid);
                        Actionlog.actiondone("Employee Reactivation", "of Empid " + empid + " Done By to " + Program.UserName + "",empid);
                        ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    }
                }

            }
        }
    }
}

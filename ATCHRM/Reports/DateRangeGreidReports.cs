using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ATCHRM.Reports
{
    public partial class DateRangeGreidReports : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DataExporter DTPEXPTR = null;
        Transactions.ReportTransaction rpttrans = null;
        DataTable dt = new DataTable();
        int deptclickflag = 0;
        public DateRangeGreidReports()
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            rpttrans = new Transactions.ReportTransaction();
            locationListLoad();
            tbl_attendancedata.RowTemplate.Height = 19;
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

        private void attendanceAfterConfirmOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttrans.GetAllPayBackDetails(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);
            foreach (DataColumn col in dt.Columns)
            {
                col.ReadOnly = false;
            }
            tbl_attendancedata.DataSource = dt;
            Updatethebalance();
        }

        public void Updatethebalance()
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count-1; i++)
            {

                tbl_attendancedata.Rows[i].Cells[7].Value = float.Parse(tbl_attendancedata.Rows[i].Cells[5].Value.ToString()) - float.Parse(tbl_attendancedata.Rows[i].Cells[6].Value.ToString());

            }
        }

        private void beforeCloseRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void synchronizeabscnet_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttrans.GetAllOTandUOTBeforeCloseRegister (int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);
            foreach (DataColumn col in dt.Columns)
            {
                col.ReadOnly = false;
            }
            tbl_attendancedata.DataSource = dt;
          
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tbl_attendancedata);
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}

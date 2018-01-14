using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Reports
{
    public partial class EmployeeRawDataForm : Form
    {
        Transactions.DataExporter DTPEXPTR = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.AttendanceManagementTransaction attndtrns = null;
        public EmployeeRawDataForm()
        {
            InitializeComponent();

            cmptransaction = new Transactions.CompanyBranchTransactions();
            attndtrns = new Transactions.AttendanceManagementTransaction();
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt= attndtrns.GetRawSwipeRecordBetweenDates (dtp_from.Value.Date ,dtp_to.Value.Date,int.Parse (cmb_location.SelectedValue.ToString ()));
            tbl_rawdata.DataSource = dt;
            MessageBox.Show(dt.Rows.Count.ToString());
        }

        private void EmployeeRawDataForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tbl_rawdata);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Outstatus  .Text.Trim()!= "")
                {

                    ((DataTable)tbl_rawdata.DataSource).DefaultView.RowFilter = " [Out status] like '%" + cmb_Outstatus.Text.Trim() + "%' ";

                   
                }

               
            }
            catch (Exception) { }
        }

    }
}

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ATCHRM.HR
{
    public partial class ContractEndingEmployees : Form
    {
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Datalayer.EmployeeContractDatabean empcontrctdatbean = null;
        Transactions.AnualContractrenewal annulcntrct = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.ReportTransaction rpttrans = null;
        int deptchangeflag = 0;
        public ContractEndingEmployees()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            annulcntrct = new Transactions.AnualContractrenewal();
            // employecodeload(Program.LOCTNPK, 0, 0);
            rpttrans = new Transactions.ReportTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
        }

        private void ContractEndingEmployees_Load(object sender, EventArgs e)
        {

            locationListLoad();
            DeptcomboLoad();
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
        /// <summary>
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = empregtrans.getcontractofallemployeeofadeptandlocation(int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_location.SelectedValue.ToString()));
           
            tbL_contract.DataSource = dt;
            UltraGridBand band = this.tbL_contract.DisplayLayout.Bands[0];
            this.tbL_contract.Text = "Contract Data";
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

        private void synchronizeabscnet_Click(object sender, EventArgs e)
        {
            if (tbL_contract.Rows.Count > 1)
            {
                if (this.tbL_contract.Text == "Contract Data")
                {
                    ((DataTable)tbL_contract.DataSource).DefaultView.RowFilter = " Endtime >='" + dtp_fromdate.Value.Date + "' and Endtime <='" + dtp_todate.Value.Date + "' ";
                }else
                {
                    MessageBox.Show("Click Show Contract Details");
                }
            }
        }

        private void attendanceAfterConfirmOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttrans.GetAllPayBackDetails(int.Parse(cmb_location.SelectedValue.ToString()), dtp_fromdate.Value.Date, dtp_todate.Value.Date);
            foreach (DataColumn col in dt.Columns)
            {
                col.ReadOnly = false;
            }
            tbL_contract.DataSource = dt;
            Updatethebalance();
            UltraGridBand band = this.tbL_contract.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            
        }
        public void Updatethebalance()
        {
            for (int i = 0; i < tbL_contract.Rows.Count - 1; i++)
            {

                tbL_contract.Rows[i].Cells[7].Value = float.Parse(tbL_contract.Rows[i].Cells[5].Value.ToString()) - float.Parse(tbL_contract.Rows[i].Cells[6].Value.ToString());

            }
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Program.OurLogSource + "Actions.xmllog";
            try
            {
                //XmlReader xmlFile;
                //xmlFile = XmlReader.Create(filename, new XmlReaderSettings());
                //DataSet ds = new DataSet();
                //ds.ReadXml(xmlFile);
                //xmlFile.Close();
                //tbL_contract.DataSource = ds.Tables[0];
                //tbl_attendancedata.DataMember = "LogInfo";


                
                ReadLogfileXml(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }
      

        private void ReadLogfileXml(string filename)
        {
            using (XmlLogfileStream logfileStream = new XmlLogfileStream(filename))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(logfileStream);
                tbL_contract.DataSource = ds;
                tbL_contract.DataMember = ds.Tables[0].TableName;
                UltraGridBand band = this.tbL_contract.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.DataExporter DTPEXPTR = null;
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.ExportUltraGrid(this.tbL_contract);
        }
    }
}

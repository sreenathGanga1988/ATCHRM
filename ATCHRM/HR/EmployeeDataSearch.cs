using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATCHRM.Datalayer.ReportDatasetTableAdapters;
namespace ATCHRM.HR
{
    public partial class EmployeeDataSearch : Form
    {
        public EmployeeDataSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datalayer.ReportDatasetTableAdapters.EmployeePersonalMaster_tblTableAdapter prsnldat = new EmployeePersonalMaster_tblTableAdapter();
            Datalayer.ReportDatasetTableAdapters.EmpContract_tblTableAdapter  cntrctdata = new EmpContract_tblTableAdapter ();
            Datalayer.ReportDatasetTableAdapters.EmployeeDesignation_tblTableAdapter desgdata = new EmployeeDesignation_tblTableAdapter();
            Datalayer.ReportDatasetTableAdapters.EmployeShift_tblTableAdapter empshift = new EmployeShift_tblTableAdapter();
            Datalayer.ReportDatasetTableAdapters.EmpContractDetail_tblTableAdapter cntrctdetdata = new EmpContractDetail_tblTableAdapter();
            Datalayer.ReportDatasetTableAdapters.EmployeeSalaryDetail_tblTableAdapter empsaldetail = new EmployeeSalaryDetail_tblTableAdapter();
            prsnldat.Connection.ConnectionString = Program.ConnStr;
            cntrctdata.Connection.ConnectionString = Program.ConnStr;
            empshift.Connection.ConnectionString = Program.ConnStr;
            cntrctdetdata.Connection.ConnectionString = Program.ConnStr;
            desgdata.Connection.ConnectionString = Program.ConnStr;
            empsaldetail.Connection.ConnectionString = Program.ConnStr;
           
           
            dataGridView1.DataSource = prsnldat.GetDataByEmpid(int.Parse(textBox1.Text.Trim ()));
            dataGridView2.DataSource = cntrctdata.GetDataByEmpid(int.Parse(textBox1.Text.Trim()));
            dataGridView3.DataSource = desgdata.GetDataByEmpid(int.Parse(textBox1.Text.Trim()));
            dataGridView4.DataSource = empshift .GetDataBy (int.Parse(textBox1.Text.Trim()));
            dataGridView5.DataSource = cntrctdetdata.GetDataBy(int.Parse(textBox1.Text.Trim()));
            dataGridView6.DataSource = empsaldetail.GetDataByEmpid(int.Parse(textBox1.Text.Trim()));



        }
    }
}

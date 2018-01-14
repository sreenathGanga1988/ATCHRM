using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace ATCHRM.Approvals
{
    public partial class ContractApprovalForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.Helper HLPR = null;
        int lctnflag = 0;
        public ContractApprovalForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            HLPR = new Transactions.Helper();
        } 
        
        /// <summary>
        /// loads the location 
        /// </summary>
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
          //  DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = HLPR.GetComboBoxedDataTable(cmptransaction.getAllBranchLocationDetails(),
    "SL", "LOCATION", "0", "ALL LOCATION");
           // cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";

            cmb_location.SelectedValue = Program.LOCTNPK;
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            loademployee();
        }
        public void loademployee()
        {
            if (lctnflag > 0)
            {
                if (cmb_location.Text != "ALL LOCATION")
                {
                    DataTable dt = empregtrans.GetAllEmployeeCodeForApproval(int.Parse(cmb_location.SelectedValue.ToString()));
                    cmb_EmpCode.DataSource = dt;
                    cmb_EmpCode.DisplayMember = "empno";
                    cmb_EmpCode.ValueMember = "empid";
                }
                else
                {
                    DataTable dt = empregtrans.GetAllEmployeeCodeForApproval(0);
                }
            }
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflag++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //D:\Reports_ATCHRM


            ConnectionInfo crconnectioninfo = new ConnectionInfo();
            ReportDocument cryrpt = new ReportDocument();
            TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();

            Tables CrTables;

            //crconnectioninfo.ServerName = "SREENATH-IT\\SQLEXPRESS";
            //crconnectioninfo.DatabaseName = "ATCHRM";
            //crconnectioninfo.UserID = "sa";
            //crconnectioninfo.Password = "sreenath";


            crconnectioninfo.ServerName = Program.Server ;
            crconnectioninfo.DatabaseName = Program.database ;
            crconnectioninfo.UserID = Program.dbUsername ;
            crconnectioninfo.Password = Program.dbPassword ;


            cryrpt.Load(Program.OurReportSource +"\\contract.rpt");

            CrTables = cryrpt.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }


            cryrpt.RecordSelectionFormula = "{EmployeePersonalMaster_tbl.empid}=" + int.Parse(cmb_EmpCode.SelectedValue.ToString());
            cryrpt.Refresh();




            crystalReportViewer1 .ReportSource =cryrpt;






        }

        private void ContractApprovalForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
        }

        private void btn_printPreview_Click(object sender, EventArgs e)
        {
            try
            {
                empregtrans.MarkEmployeeActive(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                loademployee();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                empregtrans.REJECTcONTRACT(int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                loademployee();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }
    }
}

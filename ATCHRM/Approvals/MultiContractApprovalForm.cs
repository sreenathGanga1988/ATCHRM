using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Approvals
{
    public partial class MultiContractApprovalForm : Form
    {
        int ApprovalLevel = 0;
        Datalayer.EmployeeContractDatabean empcontrctdatbean = null;
        Transactions.ApprovalTransaction apprvltrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.AnualContractrenewal annulcntrct = null;
        public MultiContractApprovalForm()
        {
            InitializeComponent();
        }

        public MultiContractApprovalForm(int levelnum)
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            apprvltrans = new Transactions.ApprovalTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            annulcntrct = new Transactions.AnualContractrenewal();
            ApprovalLevel = levelnum;
            locationListLoad();
          
        }
        private void MultiContractApprovalForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filldatagridview();
        }

        public void filldatagridview()
        {
            
            //  tbl_ApprovalData.Columns.Clear();
            tbl_Approval.DataSource = null;
            DataTable dt = apprvltrans.getAllEmployeeRenewalApplications(int.Parse( cmb_location.SelectedValue.ToString ()), ApprovalLevel);
            tbl_Approval.DataSource = dt;
        }
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            //  DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = cmptransaction.getAllBranchLocationDetails();
            // cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";

            cmb_location.SelectedValue = Program.LOCTNPK;
        }
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
          
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_Approval.Rows.Count; i++)
            {

                if (Convert.ToBoolean(tbl_Approval.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int ContractAppid = int.Parse(tbl_Approval.Rows[i].Cells["ContractAppid"].Value.ToString());



                    using (SqlServerLinqDataContext cntxt= new SqlServerLinqDataContext (Program.ConnStr))
                    {


                        var q = from empct in cntxt.EmpContractChangeApp_tbls
                                where empct.ContractAppid == ContractAppid
                                select empct;

                        foreach (var element in q)
                        {

                            if(ApprovalLevel==1)
                            {


                                element.IsLevel1 = 'A';
                                element.Level1User_PK = Program.USERPK;
                                element.Level1Date = DateTime.Now;
                            }
                            else if (ApprovalLevel == 2)
                            {
                                element.IsLevel2 = 'A';
                                element.Level2User_PK = Program.USERPK;
                                element.Level2Date = DateTime.Now;
                            }
                            else if (ApprovalLevel == 3)
                            {
                                element.IsLevel3 = 'A';
                                element.Level3User_PK = Program.USERPK;
                                element.Level3Date = DateTime.Now;





                            }


                        }

                        cntxt.SubmitChanges();

                    }
                    if (ApprovalLevel == 3)
                    {

                        empcontrctdatbean = new Datalayer.EmployeeContractDatabean();
                        empcontrctdatbean.Empid = int.Parse(tbl_Approval.Rows[i].Cells["EmpId"].Value.ToString());
                        empcontrctdatbean.Actualjoinigdate = DateTime.Parse(tbl_Approval.Rows[i].Cells["ActualJoiningDate"].Value.ToString());
                        empcontrctdatbean.Contractype = tbl_Approval.Rows[i].Cells["ContractType"].Value.ToString();
                        empcontrctdatbean.Startime = DateTime.Parse(tbl_Approval.Rows[i].Cells["Startdate"].Value.ToString());
                        empcontrctdatbean.Endtime = DateTime.Parse(tbl_Approval.Rows[i].Cells["Endtime"].Value.ToString());
                        empcontrctdatbean.Extendeddate = DateTime.Parse(tbl_Approval.Rows[i].Cells["Endtime"].Value.ToString());
                        empcontrctdatbean.ContractchangeAppid1 = 0;

                        empregtrans.insertEmployeeContractdetails(empcontrctdatbean, "Contract Change");

                        annulcntrct.insertAnnualContractforexistingEmployee(empcontrctdatbean.Empid);

                    }

                   
                }
                
            }

            MessageBox.Show("Approved");
        }

        private void tbl_Approval_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            tbl_Approval.DisplayLayout.Bands[0].ResetColumns();
            tbl_Approval.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // tbl_attendancedata.DisplayLayout.Bands[0].Override.AllowUpdate = DefaultableBoolean.False;
            tbl_Approval.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);


            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
        }

        private void tbl_Approval_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            UltraGrid ug = sender as UltraGrid;

            ug.ActiveRow.Update();
            ug.PerformAction(UltraGridAction.ExitEditMode);
        }

        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_Approval.Rows.Count ; i++)
                {
                    tbl_Approval.Rows[i].Cells["Selecter"].Value = true;
                    tbl_Approval.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_Approval.Rows.Count ; i++)
                {
                    tbl_Approval.Rows[i].Cells["Selecter"].Value = false;
                    tbl_Approval.Rows[i].Selected = false;

                }
            }
        }
    }
}

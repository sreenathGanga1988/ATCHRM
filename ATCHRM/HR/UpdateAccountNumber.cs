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
    public partial class UpdateAccountNumber : Form
    {
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        public UpdateAccountNumber()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
           ;
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
            shownbankdata();
        }





        public void shownbankdata()
        {
            if (cmb_location.Text.Trim() != "")
            {
                DataTable bankdata = empreg.getemployeedetailswithBankDetails(int.Parse(cmb_location.SelectedValue.ToString()));


                if (bankdata.Rows.Count != 0)
                {
                    tbl_bankdata.DataSource = bankdata;
                    tbl_bankdata.Columns[5].Frozen = true;
                }
            }
        }
        private void UpdateAccountNumber_Load(object sender, EventArgs e)
        {
            locationListLoad();
        }

        private void tbl_bankdata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_bankdata.IsCurrentCellDirty)
            {
                tbl_bankdata.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            int actiondonerows = 0;
            for (int i = 0; i < tbl_bankdata.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_bankdata.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empreg.updateAccountnum(int.Parse(tbl_bankdata.Rows[i].Cells[1].Value.ToString()), tbl_bankdata.Rows[i].Cells[17].Value.ToString());
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated Bank details of "+actiondonerows.ToString()+" Employees");
                shownbankdata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchNewEmployeeID();
        }


       public void SearchNewEmployeeID()
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                searchGridview(tbl_bankdata, 1, txt_empid.Text.Trim());
            }
        }
       public void searchGridview(DataGridView datagrid, int searchrowindex, String searchvalue)
       {
           int rowIndex = -1;
           foreach (DataGridViewRow row in datagrid.Rows)
           {
               if (row.Index != datagrid.RowCount - 1)
               {
                   if (row.Cells[searchrowindex].Value.ToString().Equals(searchvalue))
                   {

                       rowIndex = row.Index;
                       datagrid.FirstDisplayedScrollingRowIndex = rowIndex;
                       datagrid.Rows[rowIndex].Selected = true;
                   }
               }
           }
       }

       private void reactivateToolStripMenuItem_Click(object sender, EventArgs e)
       {
           if (tbl_bankdata.RowCount > 0)
           {

               int rowindex = tbl_bankdata.CurrentRow.Index;
               if (rowindex >= 0)
               {
                   Changeemployeebank(rowindex);
               }
           }
       }

       public void Changeemployeebank(int rowindex)
       {
            int empid = int.Parse(tbl_bankdata.Rows[rowindex].Cells[1].Value.ToString());
           String Currentbank = "";
           String currentaccountnum="";
           try
           {

              
               
               Currentbank = tbl_bankdata.Rows[rowindex].Cells[16].Value.ToString();
               currentaccountnum = tbl_bankdata.Rows[rowindex].Cells[17].Value.ToString();

           }
           catch (Exception)
           {
               
              
           }

                   if (empid != 0)
                   {
                       HR.EmployeeActions.ChangeEmployeeBank chng = new EmployeeActions.ChangeEmployeeBank(empid, Currentbank, currentaccountnum);
                 //     chng.Parent = this.MdiParent ;
                      chng.StartPosition = FormStartPosition.CenterParent;
                      chng.ShowDialog();
                   }
               }

        
    }
}

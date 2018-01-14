using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.SwipeAction
{
    public partial class NightShiftDetail : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.ShiftTransactionNewform shftransaction = null;
        SwipeAction.NightShifttransaction ngfts = null;
        public NightShiftDetail()
        {
            InitializeComponent();
            ngfts = new NightShifttransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            shftransaction = new Transactions.ShiftTransactionNewform();
           
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = ngfts.getallnightswipe(int.Parse (cmb_location.SelectedValue.ToString ()), dtp_fromdate.Value.Date ,dtp_todate.Value.Date, int.Parse (cmb_toshift.SelectedValue.ToString ()));
                      
            dataGridView1.DataSource = dt;
        }


        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        private void btn_approval_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                

                new SwipeActions().MarkSwipe(dataGridView1.Rows[i].Cells[0].Value.ToString(), DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()));

            }
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
        public void shiftcomboload()
        {
            DataTable dt = shftransaction.getAllShiftName();

            cmb_toshift.DataSource = dt;
            cmb_toshift.DisplayMember = "ShiftName";
            cmb_toshift.ValueMember = "ShiftPk";
        }

        private void NightShiftDetail_Load(object sender, EventArgs e)
        {
            locationListLoad();
            shiftcomboload();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace ATCHRM.HR
{
    public partial class DeserteeEmployee : Form
    {
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        public DeserteeEmployee()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            locationListLoad();
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
            DataTable dt = empreg.getalldesertyemployee(dateTimePicker1.Value.Date);
           ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.ultraGrid1.Text = "Desertees";
        }
    }
}

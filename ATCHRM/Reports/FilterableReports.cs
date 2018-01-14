using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
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
    public partial class FilterableReports : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DataExporter DTPEXPTR = null;
        Transactions.ReportTransaction rpttrans = null;
        Transactions.Adjuster.OtRulerTransaction ottran = null;
        DataTable dt = new DataTable();
        int deptclickflag = 0;
      
        public FilterableReports()
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            rpttrans = new Transactions.ReportTransaction();
            ottran = new Transactions.Adjuster.OtRulerTransaction();
            loadadjuster();
        }
        public void loadadjuster()
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
            var q = from admst in cntxt.AdjusterMaster_tbls
                    where admst.BranchLctnPk == Program.LOCTNPK
                    select admst;

            Cmb_Adjuster.DataSource = q;
            Cmb_Adjuster.DisplayMember = "AdjusterCode";
            Cmb_Adjuster.ValueMember = "AdjusterID";


        }

       

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
         //   e.Layout.Override.FilterUIType = FilterUIType.co;
        }

        private void finalAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ottran.getadjusteddata(int.Parse (Cmb_Adjuster.SelectedValue.ToString ()));
          
           ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Columns["In_time"].Format = "dd/MM/yyyy HH:mm:ss";
            band.Columns["Out_time"].Format = "dd/MM/yyyy HH:mm:ss";
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            ultraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle =
            RowSelectorHeaderStyle.ColumnChooserButton;
            ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            ultraGrid1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);

        }

        private void croppedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ottran.getadjustedCroppedData();
           
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            ultraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle =
            RowSelectorHeaderStyle.ColumnChooserButton;
            ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            ultraGrid1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);

        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.ExportUltraGrid (this.ultraGrid1);
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ottran.getadjustedDetailsConsol(int.Parse(Cmb_Adjuster.SelectedValue.ToString()));
            
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            ultraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle =
            RowSelectorHeaderStyle.ColumnChooserButton;
            ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            ultraGrid1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
        }
    }
}

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Reports
{
    public partial class EmpoloyeeDetailsReport : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DataExporter DTPEXPTR = null;
        Transactions.Helper HLPR = null;
        DataTable dt = new DataTable();
        int deptclickflag = 0;
        public EmpoloyeeDetailsReport()
        {
            InitializeComponent();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            HLPR = new Transactions.Helper();
            locationListLoad();
          
        }
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();

            DataTable dt1 = HLPR.GetComboBoxedDataTable(dt,
    "SL", "LOCATION", "0", "ALL LOCATION");
            cmb_location.DataSource = dt1;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";
            cmb_location.SelectedValue = Program.LOCTNPK;
        }

        private void EmpoloyeeDetailsReport_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (Program.UserType == "A")
            {

                if (cmb_location.Text == "")
                {
                    dt = empreg.getAllemployeedataofLocation(0);
                }
                else
                {
                    dt = empreg.getallemployeedataforexport(int.Parse(cmb_location.SelectedValue.ToString()));
                }
            }
            else
            {
                if (cmb_location.Text != "")
                {
                    dt = empreg.getallemployeedataforexport(int.Parse(cmb_location.SelectedValue.ToString()));

                }
                else if (cmb_location.Text == "ALL LOCATION")
                {
                    dt = empreg.getallemployeedataforexport(0);
                }
                else
                {
                    dt = empreg.getallemployeedataforexport(int.Parse(Program.LOCTNPK.ToString()));
                }
            }



            System.Data.DataColumn Shiftintime = new System.Data.DataColumn("Basic", typeof(System.String));
            Shiftintime.DefaultValue = "0";
            dt.Columns.Add(Shiftintime);
            System.Data.DataColumn Shiftoutime = new System.Data.DataColumn("HRA", typeof(System.String));
            Shiftoutime.DefaultValue = "0";
            dt.Columns.Add(Shiftoutime);

            System.Data.DataColumn Shiftduration = new System.Data.DataColumn("SA", typeof(System.String));
            Shiftduration.DefaultValue = "0";
            dt.Columns.Add(Shiftduration);

            System.Data.DataColumn Shiftname = new System.Data.DataColumn("Others", typeof(System.String));
            Shiftname.DefaultValue = "0";
            dt.Columns.Add(Shiftname);

            tbl_attendancedata.DataSource = dt;



          tbl_attendancedata.DataSource = dt;
          this.tbl_attendancedata.Text = "Employee Details";
            UltraGridBand band = this.tbl_attendancedata.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            tbl_attendancedata.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
            tbl_attendancedata.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            tbl_attendancedata.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);









           
        }




        /// <summary>
        /// get the actual shift in and outtime of all employee who had UOT
        /// </summary>
        public void fillShiftdataforUOT()
        {
            for (int i = 0; i < tbl_attendancedata.Rows.Count - 1; i++)
            {
                DataTable salarydata = empreg.GetemployeeSalaryComponentforExporting(int.Parse(tbl_attendancedata.Rows[i].Cells[0].Value.ToString()));

                if (salarydata != null)
                {
                    if (salarydata.Rows.Count != 0)
                    {
                        float others = 0;
                        float basic = 0;
                        float Hra = 0;
                        float SpecialAllowance = 0;
                        for (int j = 0; j < salarydata.Rows.Count; j++)
                        {
                            int salarypk = int.Parse ( salarydata.Rows[j][0].ToString());
                            
                            
                            

                            if (salarypk == 70)
                            {
                                basic = basic + float.Parse ( salarydata.Rows[j][1].ToString());
                            }
                            else if(salarypk == 71)
                            {
                                Hra = Hra+float.Parse(salarydata.Rows[j][1].ToString());
                            }
                            else if (salarypk == 72)
                            {
                                SpecialAllowance = SpecialAllowance + float.Parse(salarydata.Rows[j][1].ToString());
                            }
                            else
                            {
                                others = others + float.Parse(salarydata.Rows[j][1].ToString());
                            }

                           
                        }

                        tbl_attendancedata.Rows[i].Cells[22].Value = basic;
                        tbl_attendancedata.Rows[i].Cells[23].Value = Hra;
                        tbl_attendancedata.Rows[i].Cells[24].Value = SpecialAllowance;
                        tbl_attendancedata.Rows[i].Cells[25].Value = others;

                    }
                }





            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            fillShiftdataforUOT();
           
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            Transactions.DataExporter DTPEXPTR = null;
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.ExportUltraGrid(this.tbl_attendancedata);
        }




        public void fillemployeebankdata()
        {
            DataTable dt = empreg.getAllEmployeebankDetail(int.Parse(cmb_location.SelectedValue.ToString()));
            tbl_attendancedata.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()),"Hold Employees");
            tbl_attendancedata.DataSource = dt;
          UltraGridBand band = this.tbl_attendancedata.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.tbl_attendancedata.Text = "Hold Employees";
            tbl_attendancedata.DisplayLayout.Override.RowSelectorHeaderStyle =
             RowSelectorHeaderStyle.ColumnChooserButton;
            tbl_attendancedata.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            tbl_attendancedata.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
        }
    
    
    }





}

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

namespace ATCHRM.Action
{
    public partial class AttendanceManagerForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.AttendanceManagementTransaction attndncebran = null;
        Transactions.ReportTransaction rpttrans = null;
        Transactions.DataExporter DTPEXPTR = null;  
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        Transactions.Adjuster.OtRulerTransaction ottran = null;
        public AttendanceManagerForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            attndncebran = new Transactions.AttendanceManagementTransaction();
            ottran = new Transactions.Adjuster.OtRulerTransaction();
            rpttrans = new Transactions.ReportTransaction();
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
       

        /// <summary>
        /// get all the designation
        /// against a given dept
        /// </summary>
    
        /// <summary>
        /// get the employee code of the persons
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
      
        /// <summary>
        ///restrict the acess to other loacation
        /// </summary>

        public void resrictacess()
        {
            try
            {
                if (lctnflg != 0)
                {
                    if (Program.UserType == "A" || Program.UserType == "M")
                    {

                    }
                    else
                    {

                        if (int.Parse(cmb_location.SelectedValue.ToString()) != Program.LOCTNPK)
                        {
                             ATCHRM.Controls.ATCHRMMessagebox.Show("You Are Not Allowed to Acess This Location Data");
                            cmb_location.SelectedValue = Program.LOCTNPK;
                        }



                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflg++;
        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void AttendanceManagerForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
          //  DeptcomboLoad();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


       

       

        private void tbl_attendancedata_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = ottran.Getdataforaction(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            band.Columns["Intime"].Format = "dd/MM/yyyy HH:mm:ss";
            band.Columns["Outtime"].Format = "dd/MM/yyyy HH:mm:ss";
            MessageBox.Show("Done");
        }

        private void finalAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = attndncebran.GetLeaveDataBetweenDates(dtp_from.Value.Date, dtp_to.Value.Date, int.Parse(cmb_location.SelectedValue.ToString()));
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            MessageBox.Show("Done");
        }

        private void rawSwipeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = attndncebran.GetRawSwipeRecordBetweenDates(dtp_from.Value.Date, dtp_to.Value.Date, int.Parse(cmb_location.SelectedValue.ToString()));
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            band.Columns["In time"].Format = "dd/MM/yyyy HH:mm:ss";
            band.Columns["Out time"].Format = "dd/MM/yyyy HH:mm:ss";
            MessageBox.Show("Done");
        }

        private void synchronizeabscnet_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttrans.GetAllOTandUOTBeforeCloseRegister(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);
            foreach (DataColumn col in dt.Columns)
            {
                col.ReadOnly = false;
            }
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            MessageBox.Show("Done");
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.ExportUltraGrid(this.ultraGrid1);
        }

        private void actionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = attndncebran.GetActionDoneBetweendates(dtp_from.Value.Date, dtp_to.Value.Date,int.Parse(cmb_location.SelectedValue.ToString()));
            foreach (DataColumn col in dt.Columns)
            {
                col.ReadOnly = false;
            }
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            MessageBox.Show("Done");
        }











    }
}

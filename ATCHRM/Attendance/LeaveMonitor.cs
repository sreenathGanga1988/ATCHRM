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

namespace ATCHRM.Attendance
{
    public partial class LeaveMonitor : Form
    {
        public LeaveMonitor()
        {
            InitializeComponent();
        }

        private void showAllLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);


            var DataEmpLeavetaken = from leavetaken in cntxt.EmployeeLeaveTaken_tbls
                                    where (leavetaken.dateofleave >= dtp_from.Value.Date && leavetaken.dateofleave <= dtp_to.Value.Date)
                                    select leavetaken;


            var EmployeeSwipeDataBank= from swipedatabnk in cntxt.EmpSwipedataBank_tbls
                                       where (swipedatabnk.SwipeDate >= dtp_from.Value.Date && swipedatabnk.SwipeDate <= dtp_to.Value.Date)
                                       select swipedatabnk;

            var Adjstrdata = from adjstrdetil in cntxt.Adjuster_Details
                             where (adjstrdetil.Swipe_Date >= dtp_from.Value.Date && adjstrdetil.Swipe_Date <= dtp_to.Value.Date)
                             select adjstrdetil;





            tbl_empleavetaken.DataSource = DataEmpLeavetaken;
            tbl_swipedatabank.DataSource = EmployeeSwipeDataBank;
            tbl_adjstrdetail.DataSource = Adjstrdata;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LeaveMonitor_Load(object sender, EventArgs e)
        {
            UltraGridBand band = this.tbl_empleavetaken.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.tbl_empleavetaken.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
            this.tbl_empleavetaken.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;


            UltraGridBand band1 = this.tbl_swipedatabank.DisplayLayout.Bands[0];
            band1.Override.AllowRowFiltering = DefaultableBoolean.True;
            band1.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.tbl_swipedatabank.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
            this.tbl_swipedatabank.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;

            UltraGridBand band12 = this.tbl_adjstrdetail.DisplayLayout.Bands[0];
            band12.Override.AllowRowFiltering = DefaultableBoolean.True;
            band12.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.tbl_adjstrdetail.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
            this.tbl_adjstrdetail.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;

            UltraGridBand band123 = this.tbl_swipedaily.DisplayLayout.Bands[0];
            band123.Override.AllowRowFiltering = DefaultableBoolean.True;
            band123.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.tbl_swipedaily.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
            this.tbl_swipedaily.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;

            UltraGridBand band1234 = this.tbl_adjstrconsol.DisplayLayout.Bands[0];
            band1234.Override.AllowRowFiltering = DefaultableBoolean.True;
            band1234.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.tbl_adjstrconsol.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
            this.tbl_adjstrconsol.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;

            UltraGridBand band12345 = this.tbl_actionlog.DisplayLayout.Bands[0];
            band12345.Override.AllowRowFiltering = DefaultableBoolean.True;
            band12345.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            this.tbl_actionlog.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
            this.tbl_actionlog.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;

        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);


            var DataEmpLeavetaken = from leavetaken in cntxt.EmployeeLeaveTaken_tbls
                                    where (leavetaken.dateofleave >= dtp_from.Value.Date && leavetaken.dateofleave <= dtp_to.Value.Date) && leavetaken.empid==int.Parse (textBox1.Text)
                                    select leavetaken;


            var EmployeeSwipeDataBank = from swipedatabnk in cntxt.EmpSwipedataBank_tbls
                                        where (swipedatabnk.SwipeDate >= dtp_from.Value.Date && swipedatabnk.SwipeDate <= dtp_to.Value.Date) && swipedatabnk.empid == int.Parse(textBox1.Text)
                                        select swipedatabnk;

            var Adjstrdata = from adjstrdetil in cntxt.Adjuster_Details
                             where (adjstrdetil.Swipe_Date >= dtp_from.Value.Date && adjstrdetil.Swipe_Date <= dtp_to.Value.Date) && adjstrdetil.Emp_Id == int.Parse(textBox1.Text)
                             select adjstrdetil;

            var swipedata= from Swipedaily in cntxt.EmployeSwipeDaily_tbls
                           where (Swipedaily.Date >= dtp_from.Value.Date && Swipedaily.Date <= dtp_to.Value.Date) && Swipedaily.empid == int.Parse(textBox1.Text)
                           select Swipedaily;

            var adjstConsole = from adjstcons in cntxt.AdjusterConsil_tbls
                               where adjstcons.Empid == int.Parse(textBox1.Text)
                               select adjstcons;
            var log=     from actionlog in cntxt.ActionLog_tbls
                         where actionlog.Empid == int.Parse(textBox1.Text)
                         select actionlog;

            tbl_empleavetaken.DataSource = DataEmpLeavetaken;
            tbl_swipedatabank.DataSource = EmployeeSwipeDataBank;
            tbl_adjstrdetail.DataSource = Adjstrdata;
            tbl_swipedaily.DataSource = swipedata;
            tbl_adjstrconsol.DataSource = adjstConsole;
            tbl_actionlog.DataSource = log;
        }
    }
}

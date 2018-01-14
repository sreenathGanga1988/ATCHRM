using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Administrator
{
    public partial class AttendanceDescrepancyReport : Form
    {
        Transactions.LeaveandAdvanceAppTransaction tran = null;
        public AttendanceDescrepancyReport()
        {
            InitializeComponent();
            tran = new Transactions.LeaveandAdvanceAppTransaction();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = tran.getAllLeaveTakenDetails(dtp_frm.Value.Date);
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
        }

        private void finalAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = tran.GetAllLeaveApplication();
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            ultraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
        }

        private void croppedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ultraGrid1.ActiveRow.Index;
            if (ultraGrid1.Rows[index].Cells["Appnum"].Value.ToString().Trim() != "" && ultraGrid1.Rows[index].Cells["Reason"].Value.ToString().Trim() == "A" && ultraGrid1.Rows[index].Cells["Istaken"].Value.ToString().Trim() == "Y")
            {
                MarkAbscentiesLeaveIfApplied();
            }
            else
            {
                MessageBox.Show("UnAuthorised Apply");
            }
        }



        public void MarkAbscentiesLeaveIfApplied()
        {
            int leavepk = 0;
            String Leavecode = "A";
            int LeaveApppk=0;


            DataTable dt = tran.getleaveDetailsOfAplication(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Appnum"].Value.ToString().Trim(), int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Empid"].Value.ToString()));

if(dt!=null)
{
    if(dt.Rows.Count >0)
    {
        leavepk=int.Parse (dt.Rows[0]["LeavePk"].ToString ());
        Leavecode=dt.Rows[0]["LeaveCode"].ToString ().ToString ();
        LeaveApppk=int.Parse (dt.Rows[0]["LeaveAppPk"].ToString ());
    }
}






if(Leavecode!="A")
{



            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);


           
            
            
            
            var q = from leavetaken in cntxt.EmployeeLeaveTaken_tbls
                    where leavetaken.Leaveid == int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["LeaveId"].Value.ToString())
                    select leavetaken;
            foreach (var v in q)
            {
                v.Reason = Leavecode ;
                v.LeavePk  = leavepk;
                v.LeaveAppPk=LeaveApppk;
                v.AddedVia = "Late Application";
              
                cntxt.SubmitChanges();
            }

            updateswipedatabank(Leavecode);
        }
        }



        public void updateswipedatabank(String Leavecode)
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
            var q1 = from swipedatabnk in cntxt.EmpSwipedataBank_tbls
                     where swipedatabnk.empid == int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Empid"].Value.ToString()) && swipedatabnk.SwipeDate == DateTime.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["dateofleave"].Value.ToString())
                     select swipedatabnk;
            foreach (var v1 in q1)
            {
                if (v1.ApprInstatus.Trim() == "A")
                {
                    v1.ApprInstatus = Leavecode;
                }
                if (v1.ApprOutStatus.Trim() == "A")
                {
                    v1.ApprOutStatus = Leavecode;
                }
                cntxt.SubmitChanges();
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable dt = tran.GetAllEmployeesnotinSwipedataBank(dtp_frm.Value.Date);
        }

        private void employeeleaveTakenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
            var q = from emplvtaken in cntxt.EmployeeLeaveTaken_tbls
                    where emplvtaken.dateofleave > dtp_frm.Value.Date
                    select emplvtaken;

            Transactions.ControlSetupper.UltraGridNormalSetup(ultraGrid1);
            ultraGrid1.DataSource = q;
        }

        private void updateOnSwipeDatabankAndAdjusterDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["AddedVia"].Value.ToString() == " Late Application" || ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["AddedVia"].Value.ToString() == " LateApplication")
            {
                int empid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Empid"].Value.ToString());
                DateTime dateofleave= DateTime.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["dateofleave"].Value.ToString());

                updateadjuster(empid, dateofleave);
                Updateswipedatabank(empid, dateofleave);

                




            }
        }

  
    
    
    
    public void updateadjuster(int empid, DateTime dateofleave)
    {
        using (SqlServerLinqDataContext cntxt1 = new SqlServerLinqDataContext(Program.ConnStr))
        {

            var q1 = from adjstr in cntxt1.Adjuster_Details
                     where adjstr.Emp_Id == empid && adjstr.Swipe_Date == dateofleave
                     select adjstr;

            foreach (var v2 in q1)
            {
                if (v2.IN_Status.Trim() == "A")
                {
                   updateadjusterInstatus(empid,dateofleave );
                }
                if (v2.Out_Status.Trim() == "A")
                {
                    updateadjusterOutStatus(empid, dateofleave);
                }
               
            }
          //  cntxt1.SubmitChanges();
        }
    }
    public void updateadjusterInstatus(int empid, DateTime dateofleave)
    {
        SqlConnection con = new SqlConnection(Program.ConnStr);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE       Adjuster_Details
SET                IN_Status = @instatus
WHERE        (Emp_Id = @empid) AND (Swipe_Date = @SwipeDate)", con);


            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@SwipeDate", dateofleave);
            cmd.Parameters.AddWithValue("@instatus", ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Reason"].Value.ToString());
            cmd.Parameters.AddWithValue("@outstatus", ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Reason"].Value.ToString());

            cmd.ExecuteNonQuery();



        }catch (Exception )
        {

        }
    }

    public void updateadjusterOutStatus(int empid, DateTime dateofleave)
    {
        SqlConnection con = new SqlConnection(Program.ConnStr);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE       Adjuster_Details
SET                Out_status = @outstatus
WHERE        (Emp_Id = @empid) AND (Swipe_Date = @SwipeDate)", con);


            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@SwipeDate", dateofleave);

            cmd.Parameters.AddWithValue("@outstatus", ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Reason"].Value.ToString());

            cmd.ExecuteNonQuery();



        }
        catch (Exception)
        {

        }
    }
   

    public void Updateswipedatabank(int empid, DateTime dateofleave)
    {
        SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);

        var q = from swpdata in cntxt.EmpSwipedataBank_tbls
                where swpdata.empid == empid && swpdata.SwipeDate == dateofleave
                select swpdata;

        foreach (var v1 in q)
        {
            if (v1.ApprInstatus.Trim() == "A")
            {
                v1.ApprInstatus = ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Reason"].Value.ToString();
            }
            if (v1.ApprOutStatus.Trim() == "A")
            {
                v1.ApprOutStatus = ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["Reason"].Value.ToString();
            }
            cntxt.SubmitChanges();
        }

    }

    private void ultraGrid1_CellChange(object sender, CellEventArgs e)
    {
        UltraGrid ug = sender as UltraGrid;

        ug.ActiveRow.Update();
        ug.PerformAction(UltraGridAction.ExitEditMode);
    }
    
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Attendance
{
    public partial class OverOTEmployee : Form
    {
        Transactions.Adjuster.AdjusterTranscation adjstrtrans = null;
        Transactions.DataExporter DTPEXPTR = null;
        DataTable distinctValues = new DataTable();
        Transactions.Adjuster.OtRulerTransaction ottrans = null;
        public OverOTEmployee()
        {
            InitializeComponent();
            adjstrtrans = new Transactions.Adjuster.AdjusterTranscation();
            ottrans = new Transactions.Adjuster.OtRulerTransaction();
        }

        private void OverOTEmployee_Load(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Cmb_Adjuster.Text != "")
            {
                btn_approval.Enabled = true;
                btn_leaveupdate.Enabled = false;
                DataTable dt = adjstrtrans.GetOverOTEmployees(int.Parse(Cmb_Adjuster.SelectedValue.ToString()));
                tbl_DailyTime.DataSource = dt;
                DataView view = new DataView(dt);


                distinctValues = view.ToTable(true, "emp_id");
                //distinctValues.Columns.Add("ExtraMinutes", typeof(int));
                DataColumn col = new DataColumn();
                col.ColumnName = "ExtraMinutes";
                col.AllowDBNull = false;
                col.DataType = System.Type.GetType("System.Int32");
                col.DefaultValue = 0;
                distinctValues.Columns.Add(col);
                DataColumn col2 = new DataColumn();
                col2.ColumnName = "LessMinutes";
                col2.AllowDBNull = false;
                col2.DataType = System.Type.GetType("System.Int32");
                col2.DefaultValue = 0;
                distinctValues.Columns.Add(col2);
                foreach (DataColumn colm in dt.Columns)
                    colm.ReadOnly = false;
            }
        }

        private void btn_approval_Click(object sender, EventArgs e)
        {
            distinctValues = cropvalue();
            distinctValues = cropvalue();// two times to ensure previous date also handled
            if (distinctValues.Rows.Count != 0)
            {
                int adjusterid = int.Parse(Cmb_Adjuster.SelectedValue.ToString());

                for (int i = 0; i < distinctValues.Rows.Count; i++)
                {
                    adjstrtrans.adjustCroppedOT(int.Parse(distinctValues.Rows[i]["Emp_id"].ToString()), adjusterid, 15, int.Parse(distinctValues.Rows[i]["ExtraMinutes"].ToString()));


                }
            }
            MessageBox.Show("DONE");
        }




        public DataTable cropvalue()
        {

            int totalrowcount = tbl_DailyTime.RowCount;
            for (int i = 0; i < totalrowcount - 1; i++)
            {

                if (tbl_DailyTime.Rows[i].Cells["Out_Status"].Value.ToString().Trim() == "OT1.5")
                {
                    if (int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString()) > 0)
                    {
                        int empid = int.Parse(tbl_DailyTime.Rows[i].Cells["emp_id"].Value.ToString());
                        int adjustdetid = int.Parse(tbl_DailyTime.Rows[i].Cells["Adjuster_Det_Id"].Value.ToString());
                        DataRow[] HRow = distinctValues.Select("emp_id=" + empid + "");

                        HRow[0]["ExtraMinutes"] = int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString()) + int.Parse(HRow[0]["ExtraMinutes"].ToString());

                        DateTime outime = DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Out_Time"].Value.ToString());
                        int outvalue = int.Parse(tbl_DailyTime.Rows[i].Cells["Out_Value"].Value.ToString());
                        int extraminute = int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString());

                        tbl_DailyTime.Rows[i].Cells["Out_Time"].Value = outime.AddMinutes(-extraminute);
                        tbl_DailyTime.Rows[i].Cells["Out_Value"].Value = outvalue - extraminute;
                        tbl_DailyTime.Rows[i].Cells["Extratime"].ReadOnly = false;
                        tbl_DailyTime.Rows[i].Cells["Extratime"].Value = 0;
                        tbl_DailyTime.Rows[i].Cells["Adjust_Dura"].Value = int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString()) - extraminute;
                        adjstrtrans.adjustadjusterotvalues(empid, adjustdetid, DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Out_Time"].Value.ToString()),
                            int.Parse(tbl_DailyTime.Rows[i].Cells["Out_Value"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["Adjust_Dura"].Value.ToString()));

                    }
                    else if (int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString()) < 0)
                    {
                        int empid = int.Parse(tbl_DailyTime.Rows[i].Cells["emp_id"].Value.ToString());
                        int adjustdetid = int.Parse(tbl_DailyTime.Rows[i].Cells["Adjuster_Det_Id"].Value.ToString());
                        DataRow[] HRow = distinctValues.Select("emp_id=" + empid + "");
                        DateTime outime = DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Out_Time"].Value.ToString());
                        int outvalue = int.Parse(tbl_DailyTime.Rows[i].Cells["Out_Value"].Value.ToString());
                        int lessminute = int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString());

                        DataRow[] HRow1 = distinctValues.Select("emp_id=" + empid + "");
                        if (int.Parse(HRow1[0]["ExtraMinutes"].ToString()) > 0)
                        {
                            HRow1[0]["ExtraMinutes"] = int.Parse(HRow[0]["ExtraMinutes"].ToString()) + int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString());
                            HRow1[0]["LessMinutes"] = int.Parse(HRow[0]["LessMinutes"].ToString()) + int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString());

                            tbl_DailyTime.Rows[i].Cells["Out_Time"].Value = outime.AddMinutes(lessminute);
                            tbl_DailyTime.Rows[i].Cells["Out_Value"].Value = outvalue + lessminute;
                            tbl_DailyTime.Rows[i].Cells["Extratime"].ReadOnly = false;
                            tbl_DailyTime.Rows[i].Cells["Extratime"].Value = 0;
                            tbl_DailyTime.Rows[i].Cells["Adjust_Dura"].Value = int.Parse(tbl_DailyTime.Rows[i].Cells["Extratime"].Value.ToString()) + lessminute;
                            adjstrtrans.adjustadjusterotvalues(empid, adjustdetid, DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Out_Time"].Value.ToString()),
                          int.Parse(tbl_DailyTime.Rows[i].Cells["Out_Value"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["Adjust_Dura"].Value.ToString()));
                        }
                    }



                }


            }


            return distinctValues;
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tbl_DailyTime);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = ottrans.GetAddjustedOFFDaysnotRegister();
            tbl_DailyTime.DataSource = dt;
            btn_approval.Enabled = false;
            btn_leaveupdate.Enabled = true;
        }

        private void btn_leaveupdate_Click(object sender, EventArgs e)
        {
            int totalrowcount = tbl_DailyTime.RowCount;
            for (int i = 0; i < totalrowcount - 1; i++)
            {

                if (tbl_DailyTime.Rows[i].Cells["Out_Status"].Value.ToString().Trim() == "A" && tbl_DailyTime.Rows[i].Cells["in_Status"].Value.ToString().Trim() == "A")
                {


                    using (SqlConnection con = new SqlConnection(Program.ConnStr))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeLeaveTaken_tbl " +
             "     (Istaken, empid, dateofleave, LeavePk, Reason, Userpk, Dateadded, AddedVia) " +
 " VALUES     (N'Y',@EMPID,@DATELEAVE, 0, 'A',@USERPK,@DATEADDED,'AdjstrCorrection')", con))
                        {

                            cmd.Parameters.AddWithValue("@EMPID", int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));
                            cmd.Parameters.AddWithValue("@DATELEAVE", DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Swipe_Date"].Value.ToString()));
                            cmd.Parameters.AddWithValue("@USERPK", Program.USERPK);
                            cmd.Parameters.AddWithValue("@DATEADDED", Program.Datetoday);
                            cmd.ExecuteNonQuery();

                        }
                    }

                }

            }
            MessageBox.Show("Success");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = ottrans.GetAddjustedAbscentiesnotRegister();
            tbl_DailyTime.DataSource = dt;
            btn_approval.Enabled = false;
            btn_leaveupdate.Enabled = true;
            Btn_Abcenties.Enabled = true;
        }



















        private void Btn_Abcenties_Click(object sender, EventArgs e)
        {
            int totalrowcount = tbl_DailyTime.RowCount;
            for (int i = 0; i < totalrowcount - 1; i++)
            {

                if (tbl_DailyTime.Rows[i].Cells["Out_Status"].Value.ToString().Trim() == "A" && tbl_DailyTime.Rows[i].Cells["in_Status"].Value.ToString().Trim() == "A")
                {
                    DataTable newdata = checkifEmployeeleavetakenAvailable(DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Swipe_Date"].Value.ToString()), int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));
                    if (newdata != null)
                    {
                        if (newdata.Rows.Count > 0)
                        {
                            if (newdata.Rows[0]["Reason"].ToString().Trim() == "A")
                            {
                                int leavid = int.Parse(newdata.Rows[0]["Leaveid"].ToString());

                                SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
                                var q = from frm in cntxt.EmployeeLeaveTaken_tbls
                                        where frm.Leaveid == leavid
                                        select frm;


                                foreach (var element in q)
                                {
                                    element.Istaken = "Y";
                                    cntxt.SubmitChanges();
                                }


                            }
                            else
                            {
                                MessageBox.Show("Multiple leave Found for   empid" + int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()) + " in" + DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Swipe_Date"].Value.ToString()));
                            }

                        }
                        else
                        {
                            using (SqlConnection con = new SqlConnection(Program.ConnStr))
                            {
                                con.Open();
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeLeaveTaken_tbl " +
                     "     (Istaken, empid, dateofleave, LeavePk, Reason, Userpk, Dateadded, AddedVia) " +
         " VALUES     (N'Y',@EMPID,@DATELEAVE, 0, 'A',@USERPK,@DATEADDED,'AdjstrCorrection')", con))
                                {

                                    cmd.Parameters.AddWithValue("@EMPID", int.Parse(tbl_DailyTime.Rows[i].Cells["empid"].Value.ToString()));
                                    cmd.Parameters.AddWithValue("@DATELEAVE", DateTime.Parse(tbl_DailyTime.Rows[i].Cells["Swipe_Date"].Value.ToString()));
                                    cmd.Parameters.AddWithValue("@USERPK", Program.USERPK);
                                    cmd.Parameters.AddWithValue("@DATEADDED", Program.Datetoday);
                                    cmd.ExecuteNonQuery();

                                }
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Data");
                    }
                }
            }
        }



        public DataTable checkifEmployeeleavetakenAvailable(DateTime leavedate, int empid)
        {
            Boolean present = false;

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT   * FROM  EmployeeLeaveTaken_tbl WHERE        empid = @empid AND dateofleave=@datetime", con);

                command.Parameters.AddWithValue("@empid", empid);
                command.Parameters.AddWithValue("@datetime", leavedate);

                SqlDataReader reader = command.ExecuteReader();


                dt.Load(reader);
                con.Close();

                return dt;
            }



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



     
    }
}
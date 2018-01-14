using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ATCHRM.Applications
{
    public partial class LeaveConfirmForm : Form
    {
        int levelnum = 0;
        
        public LeaveConfirmForm( )
        {
            InitializeComponent();
        }


        public LeaveConfirmForm(int LeaveAppid)
        {
            InitializeComponent();
            instializecomponent(LeaveAppid);
        }

        public LeaveConfirmForm(int LeaveAppid, int actionlevel)
        {
            InitializeComponent();
            instializecomponent(LeaveAppid);
            levelnum = actionlevel;
        }


        public void instializecomponent(int LeaveAppid)
        {
            DataTable dt = getLeaveexistingApproval(LeaveAppid);

            if (dt.Rows.Count != 0)
            {

                tbl_application.DataSource = dt;
                dtpfrom.Value = DateTime.Parse(dt.Rows[0][4].ToString());
                dtrp_to .Value = DateTime.Parse(dt.Rows[0][5].ToString());
            }


        }
        private void dtpfrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpfrom.Value.Date > dtrp_to.Value.Date)
            {
                lblStatus.Text = "Enter An Valid from date ";
                txtDays.Text = "0";

            }
            else
            {
                TimeSpan dt = dtrp_to.Value.Date - dtpfrom.Value.Date;
                txtDays.Text = dt.Days.ToString();
                lblStatus.Text = " ";
                cmb_daytype.Text = "Day";
            }
        }

        private void dtrp_to_ValueChanged(object sender, EventArgs e)
        {

            if (dtpfrom.Value.Date > dtrp_to.Value.Date)
            {
                lblStatus.Text = "Enter An Valid from date ";
                txtDays.Text = "0";

            }
            else
            {
                TimeSpan dt = dtrp_to.Value.Date - dtpfrom.Value.Date;
                txtDays.Text = dt.Days.ToString();
                lblStatus.Text = " ";
                cmb_daytype.Text = "Day";
            }
        }

        private void btn_Proceed_Click(object sender, EventArgs e)
        {


           try 
	{
        updateleavedetails();
	}
	 catch (Exception exp)
        {
            ErrorLogger er = new ErrorLogger();
            er.createErrorLog(exp);
    //         ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
            this.Dispose();
        }
           
        }



    








        /// <summary>
        /// mark entries on the employee leave taken against an application
        /// </summary>
        public void confirmleavedates()
        {


            if (validationControl())
            {
                SqlConnection con = new SqlConnection(Program.ConnStr);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertEmployeeLeaves_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fromdate", dtpfrom.Value.Date);
                    cmd.Parameters.AddWithValue("@todate", dtrp_to.Value.Date);
                    cmd.Parameters.AddWithValue("@empid", tbl_application.Rows[0].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@leaveapp", tbl_application.Rows[0].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@leavePK", tbl_application.Rows[0].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@leaveAprvlPK", tbl_application.Rows[0].Cells[1].Value);

                    cmd.ExecuteNonQuery();

                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    this.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();

                }


            }




        }

        public void updateleavedetails()
        {
            if (validationControl())
            {
                SqlConnection con = new SqlConnection(Program.ConnStr);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE    LeaveApplicationMaster "+
"SET              Fromdate = @fromdate, Todate = @todate, Duration = @duration " +
" WHERE     (LeaveAppPk = @leaveapp)", con);
      

                    cmd.Parameters.AddWithValue("@fromdate", dtpfrom.Value.Date);
                    cmd.Parameters.AddWithValue("@todate", dtrp_to.Value.Date);
                    cmd.Parameters.AddWithValue("@duration",int.Parse ( txtDays.Text));
                    cmd.Parameters.AddWithValue("@leaveapp", tbl_application.Rows[0].Cells[0].Value);
                  
                    cmd.ExecuteNonQuery();


                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    this.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();

                }


            }

        }





        public Boolean validationControl()
        {
            Boolean sucess = false;
            if(int.Parse(txtDays.Text )>int.Parse(tbl_application.Rows[0].Cells[7].Value.ToString ()))
            {
                lblStatus.Text = "Confirmed Days Cannot be more than Approved Days";
                    sucess=false;
            }
            else if (txtDays.Text == null || txtDays.Text == "" || txtDays.Text == "0")
            {
                lblStatus.Text = "Confirmed Days Cannot be Zero";
                    sucess=false;
            
            }

        else {
        sucess=true ;
               }
            return sucess;
        }
        /// <summary>
        /// GetAll Approvaldata
        /// </summary>
        /// <param name="recapppk"></param>
        /// <returns></returns>
        public DataTable getLeaveexistingApproval(int appPK)
        {
           

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     LeaveApplicationMaster.LeaveAppPk, LeaveApprovalMaster_tbl.ApprovalPk, LeaveApplicationMaster.Empid, LeaveApplicationMaster.LeavePK,  " +
           "           LeaveApplicationMaster.Fromdate, LeaveApplicationMaster.Todate, LeaveApprovalMaster_tbl.IsCompleted ,DATEDIFF ( DAY ,  LeaveApplicationMaster.Fromdate,LeaveApplicationMaster.Todate  ) as day" +
 " FROM         LeaveApplicationMaster INNER JOIN " +
       "               LeaveApprovalMaster_tbl ON LeaveApplicationMaster.LeaveAppPk = LeaveApprovalMaster_tbl.LeaveAppPk " +
 " WHERE     (LeaveApplicationMaster.LeaveAppPk = @Param1) AND (LeaveApprovalMaster_tbl.IsCompleted = N'N')", con);
                cmd.Parameters.AddWithValue("@Param1", appPK);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);

                return dt;
                }
            
            catch (Exception)
            {

                throw;


            }
            finally
            {
                con.Close();
            }
        
        }




        public void addactionLeevel2()
        {
            if (levelnum == 2)
            {
                updateleavedetails();
                confirmleavedates();
            }



        }
    
    
    
    
    
    
    
    
    }
}

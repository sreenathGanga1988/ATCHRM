using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ATCHRM.Administrator
{
    public partial class AdministraionForm : Form
    {
        Transactions.NotificationTransaction ntsfctn = new Transactions.NotificationTransaction();
        Transactions.PayrollTransaction.MainPayrollTransaction mantran = new Transactions.PayrollTransaction.MainPayrollTransaction();
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
      
        public AdministraionForm()
        {
            empregtrans = new Transactions.EmployeeRegTransaction();
            InitializeComponent();
            //  loaduserlist();
            ntsfctn = new Transactions.NotificationTransaction();
            fillallnotificationData();
            cmptransaction = new Transactions.CompanyBranchTransactions();
        }





        # region dummy

        public void executequery(String query)
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection(Program.ConnStr))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("ClearUpFromCloseregister_sp", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();
            //     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            //    con.Close();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection(Program.ConnStr))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("delete from EmpSwipedataBank_tbl ", con);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.ExecuteNonQuery();
            //     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            //     Actionlog.actiondone("Total SwipeDataBankData Deleted", "@" + Program.Server + "");
            //    con.Close();
            //}
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.notifyIcon1.BalloonTipText = "Whatever";
            this.notifyIcon1.BalloonTipTitle = "Title";
            //  this.notifyIcon1.Icon = new Icon("icon.ico");
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(3);
            Actionlog.actiondone("Total SwipeDataBankData Deleted", "@" + Program.Server + "",0);
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public void loaduserlist()
        {
            DataTable dt = getUserNames();
            cmb_Userid.DataSource = dt;
            cmb_Userid.DisplayMember = "UserId";
            cmb_Userid.ValueMember = "UserPK";
        }


        public void loadallemail()
        {
            DataTable dt = getAllEmail();
            cmb_emailsend.DataSource = dt;

            cmb_emailsend.DisplayMember = "Email";
            cmb_emailsend.ValueMember = "Userid";

        }

        public void loaduserlist1()
        {
            DataTable dt = getUserNames();
            cmb_userid1.DataSource = dt;
            cmb_userid1.DisplayMember = "UserId";
            cmb_userid1.ValueMember = "UserPK";
        }
        //get Al username
        public DataTable getUserNames()
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT UserPK, UserId FROM  UserMaster_tbl", con);



                SqlDataReader reader = cmd.ExecuteReader();
                DataTable userdata1 = new DataTable();

                userdata1.Load(reader);
                return userdata1;

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




        //get All email
        public DataTable getAllEmail()
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT     Email, Userid FROM   UserNotificationEmail_tbl", con);



                SqlDataReader reader = cmd.ExecuteReader();
                DataTable userdata1 = new DataTable();

                userdata1.Load(reader);
                return userdata1;

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



        public void fillallnotificationData()
        {
            DataTable dt = null;
            dt = new DataTable();
            dt = ntsfctn.getNotificationavailablelist();

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                tbl_AllData.Rows.Add();
                tbl_AllData.Rows[i].Cells[0].Value = dt.Rows[i][0];
                tbl_AllData.Rows[i].Cells[1].Value = dt.Rows[i][1];

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbl_AllData.RowCount != 0)
                {
                    int rowindex = tbl_AllData.CurrentRow.Index;

                    if (rowindex != tbl_AllData.Rows.Count)
                    {

                        tbl_AvailableData.Rows.Add();

                        int destinationrow = tbl_AvailableData.Rows.Count - 2;
                        for (int i = 0; i < tbl_AllData.ColumnCount; i++)
                        {
                            tbl_AvailableData.Rows[destinationrow].Cells[i].Value = tbl_AllData.Rows[rowindex].Cells[i].Value;
                        }



                        if (tbl_AllData.Rows[rowindex].Cells[0] != null || tbl_AllData.Rows[rowindex].Cells[0].Value != null || tbl_AllData.Rows[rowindex].Cells[0].Value.ToString() != "")
                        {

                            tbl_AllData.Rows.Remove(tbl_AllData.Rows[rowindex]);


                        }





                    }
                }
            }
            catch (Exception)
            {


            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbl_AvailableData.Rows.Count != 0)
                {


                    int rowindex = tbl_AvailableData.CurrentRow.Index;

                    if (rowindex != tbl_AvailableData.Rows.Count)
                    {

                        tbl_AllData.Rows.Add();

                        int destinationrow = tbl_AllData.Rows.Count - 2;
                        for (int i = 0; i < tbl_AvailableData.ColumnCount; i++)
                        {


                            tbl_AllData.Rows[destinationrow].Cells[i].Value = tbl_AvailableData.Rows[rowindex].Cells[i].Value;

                        }


                        if (tbl_AvailableData.Rows[rowindex].Cells[0] != null || tbl_AvailableData.Rows[rowindex].Cells[0].Value != null || tbl_AvailableData.Rows[rowindex].Cells[0].Value.ToString() != "")
                        {

                            tbl_AvailableData.Rows.Remove(tbl_AvailableData.Rows[rowindex]);


                        }

                    }
                }

            }
            catch (Exception)
            {


            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_AvailableData.Rows.Count - 1; i++)
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO UserNotification_tbl  " +
                        "  (UserPk, NotificationId, NotificationType)  " +
    "VALUES     (@Param1,@Param2,@Param3)  ", con);

                    cmd.Parameters.AddWithValue("@Param1", Program.USERPK);
                    cmd.Parameters.AddWithValue("@Param2", int.Parse(tbl_AvailableData.Rows[i].Cells[0].Value.ToString()));

                    cmd.Parameters.AddWithValue("@Param3", tbl_AvailableData.Rows[i].Cells[1].Value.ToString());


                    cmd.ExecuteNonQuery();

                }
            }
             ATCHRM.Controls.ATCHRMMessagebox.Show("Done ");
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection(Program.ConnStr))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("RevertAdjuster_sp", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();
            //     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int diffDays = (dtp_from.Value.Date - dtp_to.Value.Date).Days;
            double diffDays1 = (dtp_to.Value.Date - dtp_from.Value.Date).TotalDays;
             ATCHRM.Controls.ATCHRMMessagebox.Show(diffDays.ToString());
             ATCHRM.Controls.ATCHRMMessagebox.Show(diffDays1.ToString());

        }














        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                loaduserlist1();
                loadallemail();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                loaduserlist();

            }
            else if (tabControl1.SelectedTab == DeleteAllEmployee)
            {
                locationListLoad();
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
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (textBox1.Text.Length > 0)
            {
                if (!rEMail.IsMatch(textBox1.Text))
                {
                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserNotificationEmail_tbl(Userid, Email) VALUES     (@Param1,@Param2) ", con);


                cmd.Parameters.AddWithValue("@Param1", int.Parse(cmb_userid1.SelectedValue.ToString()));

                cmd.Parameters.AddWithValue("@Param2", textBox1.Text.ToString());


                cmd.ExecuteNonQuery();
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                ntsfctn.sendmail();
            }
        }

        private void AdministraionForm_Load(object sender, EventArgs e)
        {
            double year = DateTime.Now.Year - 1;
            comboBox2.Text = (year).ToString();
            for (int i = 0; i < 10; i++)
            {
                comboBox2.Items.Add((year + i).ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                Point p = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                p.Offset(dataGridView1.Location);
                dt_drp.Location = p;

                try
                {
                    dt_drp.Value = Convert.ToDateTime(dataGridView1.CurrentCell.Value);
                }
                catch (Exception)
                {
                }
                dt_drp.Size = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;

                dt_drp.Visible = true;
                dt_drp.Select();

            }
        }

        private void dt_drp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell.Value = dt_drp.Value.Date;
            }
            catch (Exception)
            {


            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.CurrentRow.Cells[0].Value = comboBox2.Text;

           


        }






        static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }



        public void calculatedays()
        {
            try
            {
                DateTime fromdate = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());

                try 
	{
        DateTime todate = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());


        //int diffDays = (todate.Date - fromdate.Date).Days;
        TimeSpan duration = todate.Date - fromdate.Date;
        int diffDays = duration.Days + 1;

        dataGridView1.CurrentRow.Cells[4].Value = diffDays.ToString();
	}
	catch (Exception)
	{
		
	
	}
            }
            catch (Exception)
            {
                
                
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - 1 > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    mantran.insertpayrollcalender(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));

                }
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("No row found");
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            //{
            //    calculatedays();

            //}

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ATCHRM.Controls.ATCHRMMessagebox.Show(CountDays(DayOfWeek.Sunday, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date).ToString());
        }
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            dataGridView2 .DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            dataGridView2.DataSource = dt;
           
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab ==tabPage5)
            {
                employecodeload(Program.LOCTNPK, 0, 0);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
            {
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeApplicableLeave_tbl "+
                     "    (empid, LeavePk, Isenchasable, EnchasableDays, Allowedleave) "+
" VALUES        (@Param1,@Param2,@Param3,@Param4,@Param5) ", con);

                    cmd.Parameters.AddWithValue("@Param1",int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()));
                    cmd.Parameters.AddWithValue("@Param2", 35);
                    
                    cmd.Parameters.AddWithValue("@Param3", 0);
                    
                    cmd.Parameters.AddWithValue("@Param4", 0);

                    cmd.Parameters.AddWithValue("@Param5", 365);


                    cmd.ExecuteNonQuery();

                }
            }
             ATCHRM.Controls.ATCHRMMessagebox.Show("Done ");
            }

        private void button15_Click(object sender, EventArgs e)
        {
            Approvals.DateForm dataform = new Approvals.DateForm();
            dataform.ShowDialog();
            DateTime effectivedate;


            try
            {
                effectivedate = DateTime.Parse(dataform.UserSelectedDate.ToString()).Date;
                using (SqlConnection con = new SqlConnection(Program.ConnStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ClearUpFromCloseregister_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dateofdeletion", effectivedate);
                    cmd.Parameters.AddWithValue("@BranchlctnPk", Program.LOCTNPK);
                    cmd.ExecuteNonQuery();
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    con.Close();
                    Actionlog.actiondone("Reverted Close register", "of BranclctnPK  " + Program.LOCTNPK + " forDate " + effectivedate + " @"+Program.Server +"",0);
                }

            }
            catch (Exception)
            {

                effectivedate = DateTime.Now.Date;
            }



           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);
            CloseRegisterRecord_tbl clstbl = new CloseRegisterRecord_tbl();
            clstbl.BranchlctnPK = int.Parse(Program.LOCTNPK.ToString () );
            clstbl.CloseRegisterDate = dtp_from.Value;
            clstbl.DoneBy = Program.USERPK;
            clstbl.AddedDate = DateTime.Now.Date;
            cntxt.CloseRegisterRecord_tbls.InsertOnSubmit(clstbl);
            cntxt.SubmitChanges(); 

            MessageBox.Show("Done");
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You want to delete All employee Details of the "+cmb_location.Text , "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                if (MessageBox.Show("Are You Sure Have Made A Back Up of Data" + cmb_location.Text, "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    empregtrans.DeleteEmployeeFromDB(0, int.Parse(cmb_location.SelectedValue.ToString()));
                    ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

                   ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                }
            }
            
        }



        private TreeNode[] CreateTreeNodesForMenuItems(ToolStripMenuItem menuItem)
        {
             MainForm mn = new MainForm();
            

            List<TreeNode> nodes = new List<TreeNode>();

            

            return nodes.ToArray();
        }


        public void getmenustripitems()
        {
            Form frm = (Form)this.MdiParent;
            MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];
            //MenuItem mi  = null;
            foreach (ToolStripMenuItem tsmi in ms.Items)
            {
                TreeNode tn = new TreeNode(tsmi.Text);
                // ToolStripDropDownItem   mi = tsmi.DropDownItems;
                getChildNodes(tsmi, tn);
                treeView1.Nodes.Add(tn);
            }
        }
        private void getChildNodes(ToolStripDropDownItem mi, TreeNode tn)
        {
            foreach (ToolStripDropDownItem item in mi.DropDownItems)
            {
                TreeNode node = new TreeNode(item.Text);
                tn.Nodes.Add(node);
                getChildNodes(item, node);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            getmenustripitems();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }












    }
}
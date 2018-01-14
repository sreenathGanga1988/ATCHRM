using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class UserRightForm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
       
        Transactions.DepartmentTransaction depttrans = null;
     
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.Helper hlpr = null;
        int flag = 0;
        public UserRightForm()
        {
            InitializeComponent();
            showallMenu();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            hlpr = new Transactions.Helper();
            DeptcomboLoad();
            locationListLoad();
            //employecodeload();
        }

        public void userprivillege()
        {
            
        }


        public void showallMenu()
        {
            List<ToolStripMenuItem> myItems = getitems();

            for (int i = 0; i < myItems.Count - 1; i++)
            {
                checkedListBox1.Items.Add(myItems[i].Text);



            }

        }
        public static List <ToolStripMenuItem> getitems()
        {
            List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();

            MainForm mn = new MainForm();
            foreach (ToolStripMenuItem i in mn.menuStrip1.Items  )
            {
                GetMenuItems(i, myItems);
            }
            return myItems;
        }



        private static void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items)
        {
            items.Add(item);
            foreach (ToolStripItem i in item.DropDownItems)
            {
                if (i is ToolStripMenuItem)
                {
                    GetMenuItems((ToolStripMenuItem)i, items);
                }
            }
        }


        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
         //   cmb_location.DataSource = dt;
            cmb_location.DataSource = hlpr.GetComboBoxedDataTable(dt,
     "SL", "LOCATION", "0", "ALL LOCATION");

            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";
            cmb_location.SelectedValue = Program.LOCTNPK;
        }
        public void employecodeload(int branchlocation, int dept ,int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empreg.getEmpcode(branchlocation, dept,desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }


        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter ValidEmp Code";
                cmb_EmpCode.Focus();
                cmb_EmpCode.Visible = true;
            }
            else if (cmb_type.Text == null || cmb_type.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid User Type";
                cmb_type.Focus();
                cmb_type.Visible = true;
            }
            else if (txt_Username.Text == null || txt_Username.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Userid";
                txt_Username.Focus();
                txt_Username.Visible = true;
            }
            else if (txt_password.Text == null || txt_password.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Password";
                txt_password.Focus();
                txt_password.Visible = true;
            }
            else if (txt_confirmPassword.Text == null || txt_confirmPassword.Text.Trim() == "")
            {
                lblStatus.Text = "Confirm Password ";
                txt_confirmPassword.Focus();
                txt_confirmPassword.Visible = true;
            }
            else if (txt_confirmPassword.Text.Trim() != txt_password.Text.Trim ())
            {
                lblStatus.Text = "Confirm Password and Password Didnt Match ";
                txt_confirmPassword.Focus();
                txt_confirmPassword.Text = "";
                txt_password.Text = "";
                txt_confirmPassword.Visible = true;
            }




            else
            {
                sucess = true;
            }

            return sucess;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidationControl())
            {




            int userid=  insertUserData();
        //    insertusermenuStatus(userid);

             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");







            }
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag != 0)
            {
                if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter the Branch location";

                }
                else
                {
                    employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                }
            }
        }


        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag != 0)
            {
                if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
                {
                    lblStatus.Text = "Enter the Branch location";

                }
                else if (cmb_dept.Text == "" || cmb_dept.Text.Trim() == "")
                {
                    employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), 0, 0);
                }
                else
                {
                    employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
                }
            }
        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            flag = 1;
        }







        public int  insertUserData()
        {
            String usertype = "U";
            int userid;
            if (cmb_type.Text.Trim() == "Admin")
            {
                usertype = "A";
            }
            else if (cmb_type.Text.Trim() == "Management")
            {
                usertype = "M";
            }
            else if (cmb_type.Text.Trim() == "Power User")
            {
                usertype = "P";
            }
            else
            {
                usertype = "U";
            }




            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {

                   
                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand("  INSERT INTO UserMaster_tbl (UserId, UserPassword, Empid, Usertype, BranchLocationPk, DateAdded, AddedBy,EmpName) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8);SELECT SCOPE_IDENTITY() ", sqlConnection1))
                    {
                       

                        command.Parameters.AddWithValue("@Param1", txt_Username.Text.Trim());
                        command.Parameters.AddWithValue("@Param2", txt_password.Text.Trim());
                        command.Parameters.AddWithValue("@Param3", int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                        command.Parameters.AddWithValue("@Param4", usertype);
                        command.Parameters.AddWithValue("@Param5", int.Parse(cmb_location.SelectedValue.ToString()));
                        
                        command.Parameters.AddWithValue("@Param7", Program.USERPK);
                        command.Parameters.AddWithValue("@Param6", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@Param8",cmb_empnme.Text);
                        userid = int.Parse(command.ExecuteScalar().ToString());

                    }

                    sqlConnection1.Close();

               //     insertleaveandSalComp(id, dsgdatabean);

                }

                return userid;
          
            
            }
            catch (Exception exp)
            {

                throw exp;
            }

        }



        public void markesistingprivellage(int userid)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {


                sqlConnection1.Open();


                using (SqlCommand command = new SqlCommand(@" SELECT        User_Rights.Form_name
FROM            User_Rights INNER JOIN
                         UserMaster_tbl ON User_Rights.User_Id = UserMaster_tbl.empid
WHERE        (User_Rights.Access_Right = 'Y') AND (UserMaster_tbl.Empid = @Param2)", sqlConnection1))
                {


                    command.Parameters.AddWithValue("@Param2", int.Parse(cmb_EmpCode.SelectedValue.ToString()));


                    SqlDataReader reader = command.ExecuteReader();
                    DataTable DT = new DataTable();

                    DT.Load(reader);

                    if (DT != null)
                    {
                        if(DT.Rows.Count!=0)
                        {

                            for (int i = 0; i < DT.Rows.Count; i++)
                            {
                                for (int x = 0; x < checkedListBox1.Items.Count; x++)                               
                                   
                                {
                                    if (checkedListBox1.Items[x].ToString() == DT.Rows[i][0].ToString())
                                    {
                                        checkedListBox1.SetItemChecked(x, true);
                                    }
                                   
                                }


                            }

                        }
                    }


                }

                sqlConnection1.Close();

                //     insertleaveandSalComp(id, dsgdatabean);

            }
        }



       

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_EmpCode.Text != "")
            {


                GridViewmModels.ClsDatabase.Set_Data("delete from User_Rights where user_id=" + cmb_EmpCode.SelectedValue + "");
                foreach (object itemchkd in checkedListBox1.CheckedItems)
                {
                    GridViewmModels.ClsDatabase.Set_Data("insert into User_Rights (user_id,form_name,access_right) values "
                               + " (" + cmb_EmpCode.SelectedValue + ",'" + itemchkd.ToString() + "','Y')");
                }


                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                this.Close();

            }
            else
            {
                lblStatus.Text = "Enter A Employee Code";
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==false )
            {
                for (int x = 0; x < checkedListBox1.Items.Count; x++)
                {
                    checkedListBox1.SetItemChecked(x, false);
                }

           }
            else 
            {
                for (int x = 0; x < checkedListBox1.Items.Count; x++)
                {
                    checkedListBox1.SetItemChecked(x, true);
                }
           }
            
            
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type.Text == "Admin" || cmb_type.Text == "Power User")
            {
                cmb_location.SelectedValue = 0;
                cmb_location.Enabled = false;
            }
            else
            {
                cmb_location.Enabled = true;
            }
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            getuserid();
            getusername();
        }




        public void getusername()
        {
             try
            {
                DataTable dtuserid = null;
                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand(" SELECT     empno, First_name FROM         EmployeePersonalMaster_tbl  WHERE     (empid = @Param1) ", sqlConnection1))
                    {


                        command.Parameters.AddWithValue("@Param1", int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                     

                        SqlDataReader reader = command.ExecuteReader();
                        dtuserid = new DataTable();

                        dtuserid.Load(reader);


                    }

                    sqlConnection1.Close();

                    //     insertleaveandSalComp(id, dsgdatabean);

                }


                cmb_empnme .Text = dtuserid.Rows[0][1].ToString();


            }
            catch (Exception)
            {
                
                
            }
        }

        public void getuserid()
        {
            try
            {
                DataTable dtuserid = null;
                using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
                {


                    sqlConnection1.Open();


                    using (SqlCommand command = new SqlCommand(" SELECT     UserId, UserPassword FROM    UserMaster_tbl WHERE     (Empid = @Param1) AND (BranchLocationPk = @Param2) ", sqlConnection1))
                    {


                        command.Parameters.AddWithValue("@Param1", int.Parse(cmb_EmpCode.SelectedValue.ToString()));
                        command.Parameters.AddWithValue("@Param2", int.Parse(cmb_location.SelectedValue.ToString()));

                        SqlDataReader reader = command.ExecuteReader();
                        dtuserid = new DataTable();

                        dtuserid.Load(reader);


                    }

                    sqlConnection1.Close();

                    //     insertleaveandSalComp(id, dsgdatabean);

                }


                txt_Username.Text = dtuserid.Rows[0][0].ToString();


            }
            catch (Exception)
            {
                
                
            }
           
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserlistForm usrfrm = new UserlistForm();
            usrfrm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           markesistingprivellage(0);

         }
       

        private void UserRightForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Try.UserRightrenewFrm usrfrm = new Try.UserRightrenewFrm();
            usrfrm.ShowDialog();
        }





    }
}

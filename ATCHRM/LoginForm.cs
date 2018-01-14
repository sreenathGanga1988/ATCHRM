using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM
{
    public partial class LoginForm : Form
    {
        Transactions.DatabasePicker databasepcker = null;
         private const int CP_NOCLOSE_BUTTON = 0x200;
         DataTable userdata = null;
         int typeflag= 0;
        public LoginForm()
        {
            InitializeComponent();
           databasepcker = new Transactions.DatabasePicker();
          
        }

        // source code 
// Code Snippet

 protected override CreateParams CreateParams
 {
     get
     {
        CreateParams myCp = base.CreateParams;
        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON ;
        return myCp;
     }
 } 





  private void btn_Login_Click(object sender, EventArgs e)
        {
            if (validationcontrolsof())
            {

                if (cmb_Userid.Text.Trim() == "Admin" && txt_Password.Text.Trim() == "Admin")
                {
                    Program.USERPK = 1;
                    Program.UserType = "A";
                    Program.UserName = cmb_Userid.Text;
                    Program.LOCTNPK = 0;
                    Program.LOCATIONCODE = "ADMIN";
                    this.Close();
                    MainForm cmform = new MainForm();
                    cmform.Show();
                    

                }
                else
                {

                    userdata = getloginvalues();

                    if (userdata != null)
                    {
                        if (userdata.Rows.Count != 0)
                        {

                            Program.USERPK =int.Parse ( userdata.Rows[0][0].ToString ());
                            Program.UserType = userdata.Rows[0][3].ToString();
                            Program.UserName = userdata.Rows[0][1].ToString();
                            Program.LOCTNPK = int.Parse(userdata.Rows[0][4].ToString());
                            Program.LOCATIONCODE = userdata.Rows[0][5].ToString();
                            Program.EmpName = userdata.Rows[0][6].ToString();
                            Program.usernampk = Convert.ToInt32(cmb_Userid.SelectedValue);
                         //   Program.Datetoday = DateTime.Parse(userdata.Rows[0][5].ToString());
                            if (Program.Logintype == "Remote")
                            {
                                Loginlog lg = new Loginlog();
                                lg.loginnow(Program.UserName, Program.Datetoday, "in");
                            }
                            this.Hide();
                          MainForm cmform = new MainForm();
                          cmform.Show();
                        }
                        else
                        {
                            lbl_Status.Text ="Enter Correct UserId and Password ";
                        }
                    }
                    else
                    {
                        lbl_Status.Text = "Enter Correct Credentials ";
                    }
                }


            }
           
            

        }

 

  public void loaduserlist()
  {
      DataTable dt = getUserNames();
      cmb_Userid.DataSource = dt;
      cmb_Userid.DisplayMember = "UserId";
      cmb_Userid.ValueMember = "UserPK";
  }

  public void geteserverdate()
  {
      try
      {
          SqlConnection con = new SqlConnection(Program.ConnStr);
          con.Open();
          SqlCommand cmd = new SqlCommand("Select Getdate() ", con);
          SqlDataReader reader = cmd.ExecuteReader();
          DataTable datetable = new DataTable();

          datetable.Load(reader);
          con.Close();
          Program.Datetoday = DateTime.Parse(datetable.Rows[0][0].ToString());
      }
      catch (Exception exp )
      {

           ATCHRM.Controls.ATCHRMMessagebox.Show("Central Database Seems Down  Please Contact IT");
          try
          {
              ErrorLogger er = new ErrorLogger();
              er.createErrorLog(exp);
               ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
              Application.Exit();
          }
          catch (Exception )
          {
              
              Application.Exit();
          }
      }

  }
        
        
        
        
        
        public Boolean  validationcontrolsof()
        {
            Boolean sucess = false;
            if (cmb_Userid.Text.Trim() == null || cmb_Userid.Text.Trim() == "")
            {
                lbl_Status.Text = "Enter Valid UserName";
            }
            else if (txt_Password.Text.Trim() == null || txt_Password.Text.Trim() == "")
            {
                lbl_Status.Text = "Enter Password ";
            }

            else           
            
            {
                sucess = true;
            }


            return sucess;

        }
        
        
        
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public DataTable getloginvalues()
        {
            DataTable userdata1 = null;
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT     UserMaster_tbl.UserPK, UserMaster_tbl.UserId, UserMaster_tbl.Empid, UserMaster_tbl.Usertype, UserMaster_tbl.BranchLocationPk, BranchLocartionMaster_tbl.BranchLocationCode ,UserMaster_tbl.EmpName " +
                                                  "FROM UserMaster_tbl INNER JOIN  BranchLocartionMaster_tbl ON UserMaster_tbl.BranchLocationPk = BranchLocartionMaster_tbl.BranchlLocationPk  WHERE  (UserMaster_tbl.UserId = @Param1) AND (UserMaster_tbl.UserPassword = @Param2)", con);


                cmd.Parameters.AddWithValue("@Param1" ,cmb_Userid.Text.Trim() );
                cmd.Parameters.AddWithValue( "@Param2",txt_Password.Text.Trim () );
                SqlDataReader reader = cmd.ExecuteReader();
               userdata1 = new DataTable();

                userdata1.Load(reader);
                return userdata1;

            }
            catch (Exception exp)
            {
                
                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Designation Name");
                }


                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
             
                this.Dispose();

                return userdata1;
            }
            finally
            {          con.Close();
                
      
            }






        }










        public DataTable getUserNames()
        {
              DataTable userdata1 = new DataTable();

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT UserPK, UserId FROM  UserMaster_tbl", con);


               
                SqlDataReader reader = cmd.ExecuteReader();
              
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeflag!=0)
            {
                if (comboBox1.Text != "")
                {
                    Program.Logintype = comboBox1.Text.Trim ();

                    databasepcker.SetConnctionString();
                    geteserverdate();
                    loaduserlist();
                    if(comboBox1.Text.Trim ()=="Office")
                    {
                        cmb_Userid.Visible = false;
                        txt_user.Visible = true;
                    }
                    else
                    {
                        cmb_Userid.Visible = true;
                        txt_user.Visible = false;
                    }
                }
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            typeflag = 1;
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            //cmb_Userid.SelectedText = txt_user.Text;

            cmb_Userid.SelectedIndex = cmb_Userid.FindStringExact(txt_user.Text);
        }

        private void cmb_Userid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


            
    
    }
}

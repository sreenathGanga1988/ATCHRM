using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
namespace ATCHRM.HR
{
    public partial class BiodataForm : Form
    {
        string biodatapath = Application.StartupPath + "\\Biodatas";
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        String typeoffile = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int expflag = 0;
          int   nationflag=0;
        int viewflag = 0;
        DataTable cvdata = null;
        public BiodataForm()
        {
            InitializeComponent();

            depttrans = new Transactions.DepartmentTransaction();

            dsgtrans = new Transactions.DesignationTransaction();

        }
        public BiodataForm(int show)
        {
            InitializeComponent();

            depttrans = new Transactions.DepartmentTransaction();
            viewflag = 1;
            dsgtrans = new Transactions.DesignationTransaction();
            cmb_Cv.Visible = true;
            btn_Save.Text = "View";
            txt_path.Visible = false;
            button1.Enabled = false;
        }

        /// <summary>
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        /// <summary>
        /// get all the designation
        /// against a given dept
        /// </summary>
        public void getallDesignation()
        {

            if (deptchangeflag != 0)
            {


                if (cmb_dept.SelectedValue != null)
                {


                    cmb_designation.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_dept.SelectedValue.ToString()));

                    cmb_designation.DisplayMember = "DESGN";
                    cmb_designation.ValueMember = "SL";
                    cmb_designation.DataSource = dt;
                }

            }
        }











        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " PDF files, Word files|*.pdf;*.doc;*.docx";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txt_path .Text  = openFileDialog1.FileName;
        
             typeoffile=         Path.GetExtension(openFileDialog1.FileName).ToString();

            }
        }

      

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();
        }

        private void BiodataForm_Load(object sender, EventArgs e)
        {
            DeptcomboLoad();
        }

        /// <summary>
        /// vaildates the loaction controls while adding new 
        /// location
        /// </summary>
        /// <returns></returns>
        public Boolean validatelocation()
        {
            Boolean sucess = false;

            if (cmb_dept.Text == null || cmb_dept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  Department";
                cmb_dept.Focus();

            }
            else if (cmb_designation.Text == null || cmb_designation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Designation";
                cmb_designation.Focus();

            }
            else if (cmb_experience.Text == null || cmb_experience.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Experience ";
                cmb_experience.Focus();

            }
            else if (comboNation.Text == null || comboNation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Nationality ";
                comboNation.Focus();

            }
            else if (txt_path.Text == null || txt_path.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Path ";
                txt_path.Focus();

            }

            else
            {
                sucess = true;

            }

            return sucess;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (viewflag == 0)
            {
                if (validatelocation())
                {

                    uploadAction();

                }
            }
            else
            {
                String fllctn=searchaction ();

                Process.Start(fllctn);
            }



        //    File.Copy(txt_path.Text, biodatapath + "\\asd.doc");
        }



        public void uploadAction()
        {
            int id = 0;
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {


                sqlConnection1.Open();


                using (SqlCommand command = new SqlCommand(" INSERT INTO BiodatastoreMaster_tbl(Deptpk, DesgnPk, Experience, DateAdded, AddedLocation,Nationality) VALUES(@Param1,@Param2,@Param3,@Param4,@Param5,@Param7);SELECT SCOPE_IDENTITY()", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param1", int.Parse (cmb_dept.SelectedValue.ToString ()));
                    command.Parameters.AddWithValue("@Param2", int.Parse(cmb_designation .SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Param3", cmb_experience.Text.ToString ());
                    command.Parameters.AddWithValue("@Param4", DateTime.Now.Date);
                    command.Parameters.AddWithValue("@Param5", Program.LOCTNPK );
                    command.Parameters.AddWithValue("@Param7", comboNation.Text );
                    id = int.Parse(command.ExecuteScalar().ToString());


                    String cvid = "CV-" + id.ToString();
                    File.Copy(txt_path.Text, biodatapath + "\\"+cvid+typeoffile );
                    String newpath= biodatapath + "\\"+cvid+typeoffile;


                    SqlCommand cmd = new SqlCommand("UPDATE    BiodatastoreMaster_tbl SET  BiodataLocation = @Param6 ,biodatanum = @param8 WHERE     (Biodataid = @Param7)", sqlConnection1);

                    cmd.Parameters.AddWithValue("@Param6", newpath);
                    cmd.Parameters.AddWithValue("@Param7", id);
                    cmd.Parameters.AddWithValue("@param8", cvid);
                    cmd.ExecuteNonQuery();
                    // ATCHRM.Controls.ATCHRMMessagebox.Show("CV  Saved CV num # " + cvid);
                }

                sqlConnection1.Close();



            }


        }

        public DataTable  getcvLoad()
        {

          

                SqlConnection con = new SqlConnection(Program.ConnStr);
                try
                {

                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT     Biodataid, biodatanum, Nationality, Experience FROM BiodatastoreMaster_tbl WHERE     (Deptpk = @Param1) AND (DesgnPk = @Param2)", con);

                    command.Parameters.AddWithValue("@Param1", int.Parse(cmb_dept.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Param2", int.Parse(cmb_designation.SelectedValue.ToString()));
                    SqlDataReader reader = command.ExecuteReader();
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


        public String  searchaction()
        {
            String filelocation=null;
            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {

                con.Open();
                SqlCommand command = new SqlCommand("SELECT     BiodataLocation FROM         BiodatastoreMaster_tbl WHERE     (Biodataid = @Param1)", con);

                command.Parameters.AddWithValue("@Param1", int.Parse(cmb_Cv .SelectedValue.ToString()));
               
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();

                if (reader.Read())
                {
                    filelocation = reader[0].ToString();

                }

                return filelocation;
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

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewflag == 1)
            {
                if (desgflag != 0)
                {

                    cvdata = getcvLoad();

                    loadcvcombo(cvdata);
                }
            }
        }




        public void loadcvcombo(DataTable dt)
        {
            cmb_Cv.DataSource = dt;
            cmb_Cv.DisplayMember = "biodatanum";
            cmb_Cv.ValueMember = "Biodataid";
        }

        private void comboNation_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(viewflag ==1){
              if(nationflag!=0)
              {
                    DataTable dt = cvdata.Clone();


                    if (cvdata == null || cvdata.Rows.Count == 0)
                    {
                        cvdata = getcvLoad();
                    }

                    DataRow[] result = cvdata.Select("Nationality='" + comboNation .Text.Trim() + "' ");



                    foreach (DataRow row in result)
                    {

                        dt.Rows.Add(row.ItemArray);
                    }


                    loadcvcombo(dt);
          }
          }
        }

        private void cmb_experience_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewflag == 1)
            {

                if(expflag !=0){

                DataTable dt = cvdata.Clone();


                if (cvdata == null || cvdata.Rows.Count == 0)
                {
                    cvdata = getcvLoad();
                }

                DataRow[] result = cvdata.Select("Experience='" + cmb_experience.Text.Trim() + "' ");



                foreach (DataRow row in result)
                {

                    dt.Rows.Add(row.ItemArray);
                }


                loadcvcombo(dt);
            }
        }
        }

        private void comboNation_MouseClick(object sender, MouseEventArgs e)
        {
            nationflag++;
        }

        private void cmb_experience_MouseClick(object sender, MouseEventArgs e)
        {
            expflag++;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}

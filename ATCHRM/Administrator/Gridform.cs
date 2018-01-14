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
    public partial class Gridform : Form
    {
        public Gridform()
        {
            InitializeComponent();
            Bind();
        }



        public Gridform(int i)
        {
            InitializeComponent();
            groupBox1.Enabled = true;
          
        }

        private void Gridform_Load(object sender, EventArgs e)
        {
           
        }

        private void Bind()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from PayrollCalenderMaster_tbl", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
               // dataGridView1.DataSource = dt;
                con.Close();
            }
        }


        private void datebinBind(DateTime frmdate, DateTime todate)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("getAllDaysBetweenTwoDate ", con);

                cmd.Parameters.AddWithValue("@FromDate", frmdate);
                cmd.Parameters.AddWithValue("@ToDate", todate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

               // dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datebinBind(dtp_frm.Value.Date, dtp_to.Value.Date);
        }
    }
}

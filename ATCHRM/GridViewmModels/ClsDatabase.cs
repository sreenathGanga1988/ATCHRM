using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ATCHRM.GridViewmModels
{
     class ClsDatabase
    {
       public static  SqlConnection con;
        public  static void Conn_Data()
        {
         //   con = new SqlConnection(@"Data Source=sreenath-it\SQLEXPRESS;Initial Catalog=ATCHRM;User ID=sa;Password=sreenath");
            con = new SqlConnection(Program.ConnStr);
           con.Open();
        }
        public static void Set_Data(String qry)
        {
            Conn_Data();
            SqlCommand com = new SqlCommand();
            com.Connection=con;
            com.CommandText = qry;
            com.ExecuteNonQuery();
            con.Close();
        }

        public static DataSet  Get_Data(String qry)
        {
            Conn_Data();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = qry;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public static int Main_id(string colm, string tab, string cndtn)
        {
            int mainid = 0;
            string sg = "";
            if (cndtn == "")
            {
                sg = "select max(" + colm + ") from " + tab + "";
            }
            else
            {
                sg = "select max(" + colm + ") from " + tab + " where "+ cndtn +"";
            }

            DataSet ds = Get_Data(sg);

            if (ds.Tables[0].Rows[0][0]==DBNull.Value )
            {
                mainid = 1000;
            }
            else
            {
                mainid = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;
            }
            return mainid;
        }
         
        public static void Combo_Fill(string query, string id, string desc,ComboBox cmb)
        {
            DataSet ds = Get_Data(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = desc;
                cmb.ValueMember = id;
                cmb.SelectedIndex = -1;
            }
        }
    }

}

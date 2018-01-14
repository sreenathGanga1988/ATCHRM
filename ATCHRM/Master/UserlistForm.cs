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
    public partial class UserlistForm : Form
    {
        public UserlistForm()
        {
            InitializeComponent();
        }

        private void UserlistForm_Load(object sender, EventArgs e)
        {
            tbl_userlist.DataSource = getuserlist();
        }


        /// <summary>
        /// get the users list and password
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="BranchlocationPK"></param>
        /// <returns></returns>
        public DataTable getuserlist()
        {

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT        UserMaster_tbl.UserPK AS ID, EmployeePersonalMaster_tbl.empno AS [Emp NO], UserMaster_tbl.UserId AS [User ID], UserMaster_tbl.UserPassword AS Password, 
                         DepartmentMaster_tbl.DepartmentName AS Dept, BranchLocartionMaster_tbl.BranchLocationName
FROM            UserMaster_tbl INNER JOIN
                         EmployeePersonalMaster_tbl ON UserMaster_tbl.Empid = EmployeePersonalMaster_tbl.empid INNER JOIN
                         EmployeeDesignation_tbl ON EmployeePersonalMaster_tbl.empid = EmployeeDesignation_tbl.empid INNER JOIN
                         DepartmentMaster_tbl ON EmployeeDesignation_tbl.DepartmeentPk = DepartmentMaster_tbl.DepartmentPK INNER JOIN
                         BranchLocartionMaster_tbl ON EmployeeDesignation_tbl.BranchLocationPK = BranchLocartionMaster_tbl.BranchlLocationPk", con);

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

    }
}

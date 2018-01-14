using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class DepartmentMasterForm : Form
    {
        Datalayer.DepartmentDatabean dptbean = null;
        Transactions.DeptTransaction depttrans = null;
        Transactions.Helper HLPR = null;
        Datalayer.SubDepartmentID subdptbean = null;
        DataTable deptmentdata = null;
        DataTable subdeptmentdata = null;
        public DepartmentMasterForm()
        {
            InitializeComponent();
            depttrans = new Transactions.DeptTransaction();
            HLPR = new Transactions.Helper();
            gridviewsetup();
            

        }
        # region deptinsert
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_deptname.Text.Trim() == null || txt_deptname.Text.Trim() == "")
            {
                lblStatus.Text="Enter the Department Name";
            }
            else if (!ifdeptmentpresent())
            {
                lblStatus.Text = " Department Name Exists";
            }
            else
            {

                dptbean = new Datalayer.DepartmentDatabean();

                dptbean.DepartmentName = txt_deptname.Text;

                depttrans.InsertDepartment(dptbean);

                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                gridviewsetup(); 
            }

        }





        public Boolean  ifdeptmentpresent()
        {
            Boolean isok = true ;
            for (int i = 0; i < tbl_displaydata.Rows.Count-1; i++)
            {

                if (txt_deptname.Text.Trim() == tbl_displaydata.Rows[i].Cells[1].Value.ToString())
                {
                    isok = false;
                }
            }
            return isok;
        }

        //public void getdatafordisplay()
        //{
        //    DataTable dt = depttrans.getAllDept();
        //    tbl_displaydata.DataSource = dt;
        //}




        public void gridviewsetup()
        {

            if (tb_department.SelectedTab == dept_tab)
            {
                deptmentdata = depttrans.getAllDept();
                tbl_displaydata.DataSource = deptmentdata;




            }
            else if (tb_department.SelectedTab == Sub_tab)
            {
                loadcombo();
                subdeptmentdata = depttrans.getAllSubDept();
                tbl_displaydata.DataSource = subdeptmentdata;
            }


            
        }

        # endregion


        public Boolean ifsubdeptmentpresent()
        {
            Boolean isok = true;
            for (int i = 0; i > tbl_displaydata.Rows.Count; i++)
            {

                if (cmb_dept.Text.Trim() == tbl_displaydata.Rows[i].Cells[1].Value.ToString() && txt_subdept .Text.Trim() == tbl_displaydata.Rows[i].Cells[2].Value.ToString())
                {
                    isok = false;
                }
            }
            return isok;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (txt_subdept.Text.Trim() == null || txt_subdept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Sub Department Name";
                txt_subdept.Focus();
            }
            else if (cmb_dept.SelectedValue == null || cmb_dept.Text.Trim() == null || cmb_dept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the  Department Name";
                cmb_dept.Focus();
            }

            else if (!ifsubdeptmentpresent())
            {
                lblStatus.Text = " Sub Department Name Exists for This Department";
            }
           
            else
            {
                subdptbean = new Datalayer.SubDepartmentID();
                subdptbean.Deptid = int.Parse(cmb_dept.SelectedValue.ToString());
                subdptbean.Subdeptname1 = txt_subdept.Text;

                depttrans.InsertSubDepartment(subdptbean);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

                gridviewsetup(); 
            }

            
        }




        public void loadcombo()
        {
           // cmb_dept.DataSource =      depttrans.getAllDept();

            cmb_dept.DataSource = HLPR.GetComboBoxedDataTable(depttrans.getAllDept(),
     "SL", "DEPT", "0", "ALL DEPT");
            cmb_dept.DisplayMember = "DEPT";
            cmb_dept.ValueMember  = "SL";
        }

        private void tb_department_TabIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void tb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridviewsetup();
            for (int i = 0; i < tbl_displaydata.Rows.Count; i++)
            {
                for (int j = 0; j < tbl_displaydata.Columns.Count; j++)
                {
                    tbl_displaydata.Rows[i].Cells[j].Style.BackColor = Color.MistyRose;
                  //  tbl_displaydata.Rows[i].Cells[1].Style.BackColor = Color.MistyRose;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           toolTip1.Show("You have pending jobs", this,lblStatus.Location );
        //   this.Close();
           
        }

        Boolean clk = false;
        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tbl_displaydata.DataSource = ""; 

            try
            {
                if (clk == true)
                {
                    if (cmb_dept.Text.Trim() == "" || cmb_dept.Text.Trim() == null)
                    {
                        tbl_displaydata.DataSource = null;
                        tbl_displaydata.DataSource = subdeptmentdata;
                        tbl_displaydata.Columns[0].Visible = false;
                    }

                    else if (cmb_dept.Text.Trim() == "ALL DEPT" || cmb_dept.Text.Trim() == null)
                    {
                        // tbl_displaydata.DataSource = null;

                        //tbl_displaydata.DataSource = subdeptmentdata;
                        // tbl_displaydata.Columns[0].Visible = false;
                        gridviewsetup();
                    }

                    else
                    {
                        tbl_displaydata.DataSource = subdeptmentdata;
                        ((DataTable)tbl_displaydata.DataSource).DefaultView.RowFilter = " Dept like '" + cmb_dept.Text.Trim() + "%' ";

                    }

                }

            }
            catch (Exception)
            {

            }
            clk = false;
        }

        private void cmb_dept_Click(object sender, EventArgs e)
        {
            clk = true;
        }

        private void DepartmentMasterForm_Load(object sender, EventArgs e)
        {

        }








        







    }
}

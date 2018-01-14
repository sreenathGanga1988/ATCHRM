using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace ATCHRM.Master
{
    public partial class DesignationMasterForm : Form
    {
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DataExporter DTPEXPTR = null;
        Transactions.Helper HLPR = null;
        int deptflag = 0;
        int desigflag = 0;
        int levelflg = 0;
        DataTable dt = null;
     //   int empflag = 0;
        public DesignationMasterForm()
        {
            InitializeComponent();
            dsgtrans = new Transactions.DesignationTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            tbl_DestinationData.RowTemplate.Height = 18;
            HLPR = new Transactions.Helper();
            getallDeparment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void DesignationMasterForm_Load(object sender, EventArgs e)
        {
           
          dt  = dsgtrans.getAllDesignationData();
            tbl_DestinationData.DataSource = dt;
            tbl_DestinationData.Columns[0].Visible = false;
        }


        /// <summary>
        ///will get all thew department from the database and will 
        ///display it in combobox
        /// </summary>
        public void getallDeparment()
        {
            DataTable dt = depttrans.getDeptName();
          
       //     cmb_department.ComboBox .DataSource  = dt;
            cmb_department.ComboBox.DataSource = HLPR.GetComboBoxedDataTable(dt,
    "DepartmentPK", "DepartmentName", "0", "ALL DEPT");
            cmb_department.ComboBox.DisplayMember = "DepartmentName";
            cmb_department.ComboBox.ValueMember = "DepartmentPK";
        }





        /// <summary>
        /// get all designation against department
        /// </summary>
        public void getallDesignation()
        {
            if (cmb_department.ComboBox.SelectedValue != null)
            {






                cmb_designation.ComboBox .DataSource = null;
                DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_department.ComboBox.SelectedValue.ToString()));

                DataTable dt1 = HLPR.GetComboBoxedDataTable(dt,
      "SL", "DESGN", "0", "ALL DESIG");

                cmb_designation.ComboBox.DisplayMember = "DESGN";
                cmb_designation.ComboBox.ValueMember = "SL";
                cmb_designation.ComboBox.DataSource = dt1;


                
            }
        }









        private void btn_submitt_Click(object sender, EventArgs e)
        {
            Master.DesignationForm dsgntnform = new Master.DesignationForm();
            dsgntnform.MdiParent = this.MdiParent;
            dsgntnform.Show();
            this.Close();
        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

      

        private void btn_exportExcel_Click_1(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tbl_DestinationData);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dt = dsgtrans.getAllDesignationData();
            tbl_DestinationData.DataSource = dt;
            tbl_DestinationData.Columns[0].Visible = false;
        }

        private void chkSearch_CheckedChanged_1(object sender, EventArgs e)
        {
            getallDeparment();
        }

        private void cmb_department_SelectedIndexChanged(object sender, EventArgs e)
        {

            departmentfilter();  
            
        }






        public void departmentfilter()
        {
            try
            {
                if (cmb_department.Text.Trim() == "" || cmb_department.Text.Trim() == null)
                {

                    tbl_DestinationData.DataSource = dt;
                    tbl_DestinationData.Columns[0].Visible = false;

                }

                else if (cmb_department.Text.Trim() == "ALL DEPT" || cmb_department.Text.Trim() == null)
                {
                    //   tbl_DestinationData.DataSource = dt;
                    //   tbl_DestinationData.Columns[0].Visible = false;

                    ((DataTable)tbl_DestinationData.DataSource).DefaultView.RowFilter = "";
                }

                else
                {
                    ((DataTable)tbl_DestinationData.DataSource).DefaultView.RowFilter = " Dept like '" + cmb_department.Text.Trim() + "%' ";

                }

                getallDesignation();

            }
            catch (Exception)
            {

            }


        }



        public void designfilter()
        {
            if (desigflag != 0)
            {

                if (cmb_designation.Text.Trim() == "ALL DESIG" || cmb_department.Text.Trim() == null)
                {
                    //   tbl_DestinationData.DataSource = dt;
                    //   tbl_DestinationData.Columns[0].Visible = false;
                    desigflag = 0;
                    departmentfilter();
                }
                else
                {
                    tbl_DestinationData.DataSource = dt;
                    tbl_DestinationData.Columns[0].Visible = false;
                    ((DataTable)tbl_DestinationData.DataSource).DefaultView.RowFilter = " Designation like '%" + cmb_designation.Text.Trim() + "%'  and  Dept like '%" + cmb_department.Text.Trim() + "%' ";

                }
            } desigflag = 0;


        }




        private void tbl_DestinationData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ArrayList arrylst = new ArrayList();
            if (e.RowIndex >= 0)
            {
                arrylst.Add(tbl_DestinationData.Rows[e.RowIndex].Cells[1].Value.ToString());
                arrylst.Add(tbl_DestinationData.Rows[e.RowIndex].Cells[2].Value.ToString());
                arrylst.Add(tbl_DestinationData.Rows[e.RowIndex].Cells[3].Value.ToString());
                arrylst.Add(tbl_DestinationData.Rows[e.RowIndex].Cells[4].Value.ToString());
                arrylst.Add(tbl_DestinationData.Rows[e.RowIndex].Cells[5].Value.ToString());
                arrylst.Add(tbl_DestinationData.Rows[e.RowIndex].Cells[6].Value.ToString());

                Master.DesignationForm dsgfrm = new DesignationForm( arrylst ,int.Parse (tbl_DestinationData.Rows[e.RowIndex ].Cells [0].Value .ToString ()));
                dsgfrm.MdiParent = this.MdiParent;
                dsgfrm.StartPosition = FormStartPosition.CenterScreen;
                dsgfrm.Show();
            }
        }

        private void cmb_department_Click(object sender, EventArgs e)
        {
            deptflag++;
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }

        private void cmb_designation_Click(object sender, EventArgs e)
        {
            desigflag++;
        }

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            designfilter();
            }

        private void toolStripComboBox2_Click_1(object sender, EventArgs e)
        {
            levelflg ++;
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (levelflg != 0)
            {
                if (cmb_designation.Text.Trim() == "ALL DESIG" && cmb_department.Text.Trim() == "ALL DEPT")
                {
                    tbl_DestinationData.DataSource = dt;
                    tbl_DestinationData.Columns[0].Visible = false;
                    ((DataTable)tbl_DestinationData.DataSource).DefaultView.RowFilter = " GradeLevel like '%" + cmb_level.Text.Trim() + "%'";
                }
               else  if (cmb_designation.Text.Trim() == "ALL DESIG" || cmb_department.Text.Trim() == null)
                {
                    //   tbl_DestinationData.DataSource = dt;
                    //   tbl_DestinationData.Columns[0].Visible = false;
                    levelflg = 0;
                    designfilter();
                }
               
                else
                {
                  tbl_DestinationData.DataSource = dt;
                   tbl_DestinationData.Columns[0].Visible = false;
                    ((DataTable)tbl_DestinationData.DataSource).DefaultView.RowFilter = " Designation like '%" + cmb_designation.Text.Trim() + "%'  and  Dept like '%" + cmb_department.Text.Trim() + "%' and  GradeLevel like '%" + cmb_level .Text.Trim() + "%'";

                }



            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_randomSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    ((DataTable)tbl_DestinationData.DataSource).DefaultView.RowFilter = " Designation like  '%" + txt_randomSearch .Text.Trim() + "%' ";
                }
            }
            catch (Exception)
            {


            }
        }

           
        
       
       

       

     


    }
}

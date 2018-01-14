using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR.Rules
{
    public partial class DesignationOT : Form
    {
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.Helper HLPR = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        DataTable dt = null;
        int desigflag = 0;
        int deptflag = 0;
        public DesignationOT()
        {
            InitializeComponent();
            dsgtrans = new Transactions.DesignationTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            tbl_DestinationData.RowTemplate.Height = 18;
            HLPR = new Transactions.Helper();
            getallDeparment();
        }

        private void DesignationOT_Load(object sender, EventArgs e)
        {
            dt = dsgtrans.getAllDesignationData();
            tbl_DestinationData.DataSource = dt;
        //    tbl_DestinationData.Columns[0].Visible = false;
        }

        public void loaddata()
        {
            dt = dsgtrans.getAllDesignationData();
            tbl_DestinationData.DataSource = dt;
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






                cmb_designation.ComboBox.DataSource = null;
                DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_department.ComboBox.SelectedValue.ToString()));

                DataTable dt1 = HLPR.GetComboBoxedDataTable(dt,
      "SL", "DESGN", "0", "ALL DESIG");

                cmb_designation.ComboBox.DisplayMember = "DESGN";
                cmb_designation.ComboBox.ValueMember = "SL";
                cmb_designation.ComboBox.DataSource = dt1;



            }
        }

        private void cmb_department_Click(object sender, EventArgs e)
        {
            deptflag++;
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

        private void cmb_designation_Click(object sender, EventArgs e)
        {
            desigflag++;
        }

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            designfilter(); ;
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
                   // tbl_DestinationData.Columns[0].Visible = false;
                    ((DataTable)tbl_DestinationData.DataSource).DefaultView.RowFilter = " Designation like '%" + cmb_designation.Text.Trim() + "%'  and  Dept like '%" + cmb_department.Text.Trim() + "%' ";

                }
            } desigflag = 0;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < tbl_DestinationData.Rows.Count - 1; i++)
                {
                    tbl_DestinationData.Rows[i].Cells[0].Value = true;
                    tbl_DestinationData.Rows[i].Selected = true;

                }

            }
            else
            {
                for (int i = 0; i < tbl_DestinationData.Rows.Count - 1; i++)
                {
                    tbl_DestinationData.Rows[i].Cells[0].Value = false;
                    tbl_DestinationData.Rows[i].Selected = false;

                }
            }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            int actiondonerows = 0;
            for (int i = 0; i < tbl_DestinationData.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_DestinationData.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empregtrans.MarkOTApplicableforDesignation (int.Parse(tbl_DestinationData.Rows[i].Cells[1].Value.ToString()), true);
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                loaddata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Designation Selected ");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             int actiondonerows = 0;
            for (int i = 0; i < tbl_DestinationData.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_DestinationData.Rows[i].Cells[0].Value) == true)
                {
                    actiondonerows++;
                    empregtrans.MarkOTApplicableforDesignation (int.Parse(tbl_DestinationData.Rows[i].Cells[1].Value.ToString()), false );
                }

            }
            if (actiondonerows > 0)
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("Updated ");
                loaddata();
            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No Designation  Selected ");
            }
        }

        private void tbl_DestinationData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_DestinationData.IsCurrentCellDirty)
            {
                tbl_DestinationData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        
    }
}

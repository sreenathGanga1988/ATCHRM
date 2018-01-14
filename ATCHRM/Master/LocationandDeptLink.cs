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
    public partial class LocationandDeptLink : Form
    {
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        public LocationandDeptLink()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            locationListLoad();
            DeptcomboLoad();
        }


        /// <summary>
        /// loads the location 
        /// </summary>
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";

            cmb_location.SelectedValue = Program.LOCTNPK;
        }
        /// <summary>
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getAllLocDeptName ();
            dataGridView1.DataSource = dt;  
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {


                    int deptpk=int.Parse (dataGridView1.Rows[i].Cells["DepartmentPK"].Value.ToString ());
                    int loctnpk=int.Parse (cmb_location.SelectedValue.ToString ());

                  if (DoesDataExist(deptpk,loctnpk ))
    {

        SqlServerLinqDataContext db = new SqlServerLinqDataContext(Program.ConnStr );

                      DepartmentLocation_tbl tbl= new DepartmentLocation_tbl ();
                      tbl.BranchLctnPK=loctnpk;
                      tbl.DeptPK=deptpk;
                      tbl.AddedBy=Program.USERPK;
                     

        db.DepartmentLocation_tbls.InsertOnSubmit(tbl);

        db.SubmitChanges();


    }

   
                }
            }
            MessageBox.Show("Done");
        }




        
        private bool DoesDataExist(int deptpk,int locationpk)
        {

            SqlServerLinqDataContext db = new SqlServerLinqDataContext(Program.ConnStr );

            var query = from data in db.DepartmentLocation_tbls

                        where data.DeptPK==deptpk  && data.BranchLctnPK==locationpk

                        select data;

            // return false if the item already exists

            if (query.Any())

                return false;

            else

                return true;

        }
    }
}

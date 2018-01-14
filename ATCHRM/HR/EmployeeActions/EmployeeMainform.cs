using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ATCHRM.Master.NewFolder1
{
    public partial class EmployeeMainform : Form
    {
        Transactions.AttendanceManagementTransaction atndncemngmnt = null;
        DataTable allemployedata = null;

        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.EmployeeRegTransaction empreg = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DataExporter DTPEXPTR = null;
        DataTable dt = new DataTable();
        int deptclickflag = 0;
        int lctnflag = 0;

        public EmployeeMainform()
        {
            InitializeComponent();
            atndncemngmnt = new Transactions.AttendanceManagementTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            empreg = new Transactions.EmployeeRegTransaction();
            depttrans = new Transactions.DepartmentTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            locationListLoad();
            dataGridView1.RowTemplate.Height = 19;
            dataGridView2.RowTemplate.Height = 19;
            dataGridView3.RowTemplate.Height = 19;
            dataGridView4.RowTemplate.Height = 19;
            //   loadprogressbar();
        }

        /// <summary>
        ///restrict the acess to other loacation
        /// </summary>
        public void resrictacess()
        {
            try
            {
                if (lctnflag != 0)
                {
                    if (Program.UserType == "A" || Program.UserType == "M")
                    {

                    }
                    else
                    {

                        if (int.Parse(cmb_location.SelectedValue.ToString()) != Program.LOCTNPK)
                        {
                             ATCHRM.Controls.ATCHRMMessagebox.Show("You Are Not Allowed to Acess This Location Data");
                            cmb_location.SelectedValue = Program.LOCTNPK;
                        }



                    }
                }
            }
            catch (Exception)
            {


            }
        }
        public void locationListLoad()
        {
            cmb_location.DataSource = null;
            DataTable dt = cmptransaction.getAllBranchLocationDetails();
            cmb_location.DataSource = dt;
            cmb_location.DisplayMember = "LOCATION";
            cmb_location.ValueMember = "SL";
            cmb_location.SelectedValue = Program.LOCTNPK;
        }
        private void btn_addnew_Click_1(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).addnewemployeeformOpen();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


        }



        public void fillmapindata()
        {
            if (Program.UserType == "A")
            {

                if (cmb_location.Text == "")
                {
                    dt = empreg.getAllemployeedataofLocation(0);
                }
                else
                {
                    dt = empreg.getAllemployeedataofLocation(int.Parse(cmb_location.SelectedValue.ToString()));
                }
            }
            else
            {
                if (cmb_location.Text != "")
                {
                    dt = empreg.getAllemployeedataofLocation(int.Parse(cmb_location.SelectedValue.ToString()));

                }
                else
                {
                    dt = empreg.getAllemployeedataofLocation(int.Parse(Program.LOCTNPK.ToString()));
                }
            }
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[5].Frozen = true;
            }

        }
        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {

            resrictacess();

        }
        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflag++;
        }

        public void gridviewsetup()
        {

            if (tb_control1.SelectedIndex == 0)
            {
                fillmapindata();
            }
            else if (tb_control1.SelectedIndex == 1)
            {
                DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Deactivated");
                if (dt.Rows.Count != 0)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[5].Frozen = true;
                }
            }
            else if (tb_control1.SelectedIndex == 2)
            {
                DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Pending");
                if (dt.Rows.Count != 0)
                {

                    dataGridView3.DataSource = dt;
                    dataGridView3.Columns[5].Frozen = true;
                }

            }
            else if (tb_control1.SelectedIndex == 3)
            {
                DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Reject");
                if (dt.Rows.Count != 0)
                {
                    dataGridView4.DataSource = dt;
                    dataGridView4.Columns[5].Frozen = true;
                }
            }
            else if (tb_control1.SelectedIndex == 4)
            {
                DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Detail Pending");
                if (dt.Rows.Count != 0)
                {
                    dataGridView5.DataSource = dt;
                    //      dataGridView5.Columns[5].Frozen = true;
                    highlighter();


                }

            }
            else if (tb_control1.SelectedIndex == 5)
            {
                DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Duplicating Entry");
                if (dt.Rows.Count != 0)
                {
                    dataGridView6.DataSource = dt;
                    //      dataGridView5.Columns[5].Frozen = true;
                    //highlighter();


                }

            }


            else if (tb_control1.SelectedIndex == 6)
            {
                DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Submission Pending");
                if (dt.Rows.Count != 0)
                {
                    dataGridView7.DataSource = dt;
                    //      dataGridView5.Columns[5].Frozen = true;
                    //highlighter();


                }

            }



            else if (tb_control1.SelectedIndex == 7)
            {
                showTemperoryEmployee();

            }
            else if (tb_control1.SelectedIndex == 8)
            {
                showHoldEmployee();

            }

        }




        public void showHoldEmployee()
        {
             DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Hold Employees");
             if (dt.Rows.Count != 0)
             {
                 dataGridView9 .DataSource = dt;
             }
        }




        public void showTemperoryEmployee()
        {
            DataTable dt = empreg.getemployeedata(int.Parse(cmb_location.SelectedValue.ToString()), "Temporary Employees");
            if (dt.Rows.Count != 0)
            {
                dataGridView8.DataSource = dt;
                //      dataGridView5.Columns[5].Frozen = true;
                //highlighter();


            }
        }
        private void tb_control1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridviewsetup();

        }

        private void EmployeeMainform_Load(object sender, EventArgs e)
        {
            gridviewsetup();
        }

        private void CreateUnboundButtonColumn()
        {
            // Initialize the button column.
            DataGridViewButtonColumn buttonColumn =
               new DataGridViewButtonColumn();
            buttonColumn.Name = "Update";
            buttonColumn.HeaderText = "Update";
            buttonColumn.Text = "Update";

            // Use the Text property for the button text for all cells rather 
            // than using each cell's value as the text for its own button.
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the button column to the control.

            dataGridView5.Columns.Insert(12, buttonColumn);

        }
        public void highlighter()
        {

            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {



                if (dataGridView5.Rows[i].Cells[6].Value.ToString() == null || dataGridView5.Rows[i].Cells[6].Value.ToString() == "" || dataGridView5.Rows[i].Cells[6].Value.ToString() == "Pending" || dataGridView5.Rows[i].Cells[6].Value.ToString() == "PENDING")
                {
                    this.dataGridView5.Rows[i].Cells[6].Style.BackColor = Color.Yellow;
                }
                if (dataGridView5.Rows[i].Cells[7].Value.ToString() == null || dataGridView5.Rows[i].Cells[7].Value.ToString() == "" || dataGridView5.Rows[i].Cells[7].Value.ToString() == "Pending" || dataGridView5.Rows[i].Cells[7].Value.ToString() == "PENDING")
                {
                    this.dataGridView5.Rows[i].Cells[7].Style.BackColor = Color.Yellow;
                }

                if (dataGridView5.Rows[i].Cells[8].Value.ToString() == null || dataGridView5.Rows[i].Cells[8].Value.ToString() == "" || dataGridView5.Rows[i].Cells[8].Value.ToString() == "Pending" || dataGridView5.Rows[i].Cells[8].Value.ToString() == "PENDING")
                {
                    this.dataGridView5.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
                }

                if (dataGridView5.Rows[i].Cells[9].Value.ToString() == null || dataGridView5.Rows[i].Cells[9].Value.ToString() == "" || dataGridView5.Rows[i].Cells[9].Value.ToString() == "Pending" || dataGridView5.Rows[i].Cells[8].Value.ToString() == "PENDING")
                {
                    this.dataGridView5.Rows[i].Cells[9].Style.BackColor = Color.Yellow;
                }


                if (dataGridView5.Rows[i].Cells[10].Value.ToString() == null || dataGridView5.Rows[i].Cells[10].Value.ToString() == "" || dataGridView5.Rows[i].Cells[10].Value.ToString() == "Pending" || dataGridView5.Rows[i].Cells[8].Value.ToString() == "PENDING")
                {
                    this.dataGridView5.Rows[i].Cells[10].Style.BackColor = Color.Yellow;
                }

             
                dataGridView5.Columns[11].Visible = false;
                dataGridView5.Columns[1].Visible = false;


            }









        }
        int chos = 0;
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (chos == 0)
            {
                MessageBox.Show("Nothing Selected", "ATCHRM MASTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Are You Sure To Remove From List", "ATC HRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    if (Convert.ToString(dataGridView5.Rows[i].Cells[0].Value) == "✓")
                    {
                        empreg.removefromPENDINDETAILlist(int.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString()));
                    }
                }

                gridviewsetup();

            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToString(dataGridView5.Rows[e.RowIndex].Cells[0].Value) == "")
                    {
                        chos = 1;
                        dataGridView5.Rows[e.RowIndex].Cells[0].Value = "✓";
                        dataGridView5.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else if (Convert.ToString(dataGridView5.Rows[e.RowIndex].Cells[0].Value) == "✓")
                    {
                        chos = 0;
                        dataGridView5.Rows[e.RowIndex].Cells[0].Value = "";
                        dataGridView5.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

                    }

                }
                else if (e.ColumnIndex == 12)
                {


                }
            }
        }



        public Boolean validatetoupdate(int k)
        {
            Boolean sucess = false;

            int i = k;

            if (dataGridView5.Rows[i].Cells[8].Value.ToString().Trim() != null || dataGridView5.Rows[i].Cells[8].Value.ToString().Trim().Trim() != "" || dataGridView5.Rows[i].Cells[8].Value.ToString().Trim() != "Pending" || dataGridView5.Rows[i].Cells[8].Value.ToString().Trim() != "PENDING")
            {
                sucess = true;

            }
            else
            {
                this.dataGridView5.Rows[i].Cells[8].Style.BackColor = Color.Red;
                this.dataGridView5.Rows[i].Cells[8].Value = "Pending";
            }
            if (dataGridView5.Rows[i].Cells[9].Value.ToString().Trim() != null || dataGridView5.Rows[i].Cells[9].Value.ToString().Trim() != "" || dataGridView5.Rows[i].Cells[9].Value.ToString().Trim() != "Pending" || dataGridView5.Rows[i].Cells[8].Value.ToString().Trim() != "PENDING")
            {
                sucess = true;
            }
            else
            {
                this.dataGridView5.Rows[i].Cells[9].Style.BackColor = Color.Red;
                this.dataGridView5.Rows[i].Cells[9].Value = "Pending";
            }

            if (dataGridView5.Rows[i].Cells[10].Value.ToString().Trim() != null || dataGridView5.Rows[i].Cells[10].Value.ToString().Trim() != "" || dataGridView5.Rows[i].Cells[10].Value.ToString().Trim() != "Pending" || dataGridView5.Rows[i].Cells[8].Value.ToString().Trim() != "PENDING")
            {
                sucess = true;
            }
            else
            {
                this.dataGridView5.Rows[i].Cells[10].Style.BackColor = Color.Red;
                this.dataGridView5.Rows[i].Cells[10].Value = "Pending";
            }

            return sucess;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            UpdateAction();
        }





        public void UpdateAction()
        {
            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView5.Rows[i].Cells[0].Value) == "✓")
                {
                    if (validatetoupdate(i))
                    {

                        int empid = 0;
                        String incomtaxno = "Pending";
                        String NSSf = "Pending";
                        String NHIFnum = "Pending";
                        String NationalID = "Pending";
                        empid = int.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString());
                        NationalID = dataGridView5.Rows[i].Cells[7].Value.ToString();
                        incomtaxno = dataGridView5.Rows[i].Cells[8].Value.ToString();
                        NSSf = dataGridView5.Rows[i].Cells[9].Value.ToString();
                        NHIFnum = dataGridView5.Rows[i].Cells[10].Value.ToString();
                        empreg.updatemandatory(empid, incomtaxno, NSSf, NHIFnum, NationalID);

                        gridviewsetup();
                    }
                }
            }

        }

        private void dataGridView5_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView5.IsCurrentCellDirty)
            {
                dataGridView5.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToString(dataGridView7.Rows[e.RowIndex].Cells[0].Value) == "")
                    {
                        chos = 1;
                        dataGridView7.Rows[e.RowIndex].Cells[0].Value = "✓";
                        dataGridView7.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else if (Convert.ToString(dataGridView7.Rows[e.RowIndex].Cells[0].Value) == "✓")
                    {
                        chos = 0;
                        dataGridView7.Rows[e.RowIndex].Cells[0].Value = "";
                        dataGridView7.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

                    }

                }
                else if (e.ColumnIndex == 12)
                {


                }
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {



            DialogResult result = MessageBox.Show("Are you sure that you want to  sumbit  all  selected employee  details for approval ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Submitaction();
            }
            else if (result == DialogResult.No)
            {
            }

        }

        public void Submitaction()
        {
            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView7.Rows[i].Cells[0].Value) == "✓")
                {

                    empreg.MarkEmployeeDataFilled(int.Parse(dataGridView7.Rows[i].Cells[1].Value.ToString()));

                }
            }

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView7.Rows[i].Cells[0].Value) == "✓")
                {
                    dataGridView7.Rows[i].Cells[0].Value = "";
                    dataGridView7.Rows[i].DefaultCellStyle.BackColor = Color.White;

                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView7.Rows[i].Cells[0].Value) == "✓")
                {
                    dataGridView7.Rows[i].Cells[0].Value = "";
                    dataGridView7.Rows[i].DefaultCellStyle.BackColor = Color.White;

                }
            }

        }

        

        private void dataGridView8_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView8 .IsCurrentCellDirty)
            {
                dataGridView8.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView8.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView8.Rows[i].Cells[0].Value) == true)
                {

                    empreg.changeEmployeeContractype(int.Parse(dataGridView8.Rows[i].Cells[1].Value.ToString()), "Permanent");

                }
            }
             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            showTemperoryEmployee();

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView8.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView8.Rows[i].Cells[0].Value) == true)
                {

                    empreg.changeEmployeeContractype(int.Parse(dataGridView8.Rows[i].Cells[1].Value.ToString()), "Contractual");

                }
            }
             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            showTemperoryEmployee();

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView8.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView8.Rows[i].Cells[0].Value) == true)
                {

                    empreg.REJECTcONTRACT(int.Parse(dataGridView8.Rows[i].Cells[1].Value.ToString()));

                }
            }
             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            showTemperoryEmployee();
        }


        //  }

    }
}

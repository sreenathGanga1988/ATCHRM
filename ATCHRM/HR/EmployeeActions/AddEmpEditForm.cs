using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR.NewFolder1
{
    public partial class AddEmpEditForm : Form
    {
        Transactions.EmployeeRegTransaction reg = new Transactions.EmployeeRegTransaction();
        public AddEmpEditForm()
        {
            InitializeComponent();
        }
        public AddEmpEditForm(DataGridViewRow dt,DataGridViewColumnCollection cls)
        {
            InitializeComponent();
           
    
            
        }



        public AddEmpEditForm(int empid,String editType)
        {
            InitializeComponent();
            reg = new Transactions.EmployeeRegTransaction();
            tbl_dgv.RowTemplate.Height = 30;
            if (editType == "Personal")
            {
                SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr );

                var q = from e in cntxt.EmployeePersonalMaster_tbls
                            where e.Status != "Y" && e.empid == empid 
                            select new { e.empid ,e.PassportNo,e.NationalId,e.NHIFnum ,e.NSSFnum ,e.First_name,e.Last_Name,e.Matialstatus,e.Tel_No ,e.Address_Prime ,e.Address_Second ,e.Mobile_No};

                int i = 0;
                foreach (var element in q)
                {

                   
                        tbl_dgv.Rows.Add();
                        tbl_dgv.Rows[i].Cells[0].Value = element.empid;
                        tbl_dgv.Rows[i].Cells[0].ReadOnly = true;
                        tbl_dgv.Rows[i].Cells[1].Value = element.PassportNo;
                        tbl_dgv.Rows[i].Cells[2].Value = element.NationalId;
                        tbl_dgv.Rows[i].Cells[3].Value = element.NHIFnum;
                        tbl_dgv.Rows[i].Cells[4].Value = element.NSSFnum;
                        tbl_dgv.Rows[i].Cells[5].Value = element.First_name ;
                        tbl_dgv.Rows[i].Cells[6].Value = element.Last_Name;
                        tbl_dgv.Rows[i].Cells[7].Value = element.Matialstatus;
                        tbl_dgv.Rows[i].Cells[8].Value = element.Tel_No;
                        tbl_dgv.Rows[i].Cells[9].Value = element.Address_Prime ;
                        tbl_dgv.Rows[i].Cells[10].Value = element.Address_Second ;
                        tbl_dgv.Rows[i].Cells[11].Value = element.Mobile_No; 


                        ++i;
                        
                    }
                }

                tbl_dgv.ReadOnly = false;
                tbl_dgv.Columns[0].ReadOnly = true;
                tbl_dgv.Columns[1].ReadOnly = true;
                tbl_dgv.Columns[2].ReadOnly = true;
                tbl_dgv.Columns[3].ReadOnly = true;
                tbl_dgv.Columns[4].ReadOnly = true;

            }

        public void updateaction(int empid)
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);

            var q = from e in cntxt.EmployeePersonalMaster_tbls
                    where e.empid == empid
                    select e;
            foreach (var element in q)
            {
                element.First_name = tbl_dgv.Rows[0].Cells[5].Value.ToString();
                element.Last_Name = tbl_dgv.Rows[0].Cells[6].Value.ToString();
                element.Matialstatus = tbl_dgv.Rows[0].Cells[7].Value.ToString();
                element.Tel_No = tbl_dgv.Rows[0].Cells[8].Value.ToString();
                element.Address_Prime = tbl_dgv.Rows[0].Cells[9].Value.ToString();
                element.Address_Second = tbl_dgv.Rows[0].Cells[10].Value.ToString();
                element.Mobile_No = tbl_dgv.Rows[0].Cells[11].Value.ToString();
                cntxt.SubmitChanges();
            }
            MessageBox.Show("Done");
        }


        public void prevoioustrack()
        {
           
            string NID=tbl_dgv.Rows[0].Cells[2].Value.ToString ().Trim ();

            if (NID != "")
            {
                DataTable dt = new DataTable();
                dt = reg.isEmployeePresent(NID);

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("This NID Have " + dt.Rows.Count + "   Previous Track Records Confirm Whether to Continue with Registration ", "Attention ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                        }
                       
                    }
                }
            }
        }


        public void validationcontrol()
        {
           
            if (tbl_dgv.Rows[0].Cells[5].Value.ToString() == null || tbl_dgv.Rows[0].Cells[5].Value.ToString() == "")
            {
                tbl_dgv.Rows[0].Cells[5].Value = "NP";
            }


            if (tbl_dgv.Rows[0].Cells[6].Value.ToString() == null || tbl_dgv.Rows[0].Cells[6].Value.ToString() == "")
            {
                tbl_dgv.Rows[0].Cells[6].Value = "NP";

            }
            if (tbl_dgv.Rows[0].Cells[7].Value.ToString() == null || tbl_dgv.Rows[0].Cells[7].Value.ToString() == "")
            {

                tbl_dgv.Rows[0].Cells[7].Value = "NP";
            }
            if (tbl_dgv.Rows[0].Cells[8].Value == null || tbl_dgv.Rows[0].Cells[8].Value.ToString() == "")
            {
                tbl_dgv.Rows[0].Cells[8].Value = "NP";


            } if (tbl_dgv.Rows[0].Cells[9].Value == null || tbl_dgv.Rows[0].Cells[9].Value.ToString() == "")
            {
                tbl_dgv.Rows[0].Cells[9].Value = "NP";

            }


            if (tbl_dgv.Rows[0].Cells[10].Value == null || tbl_dgv.Rows[0].Cells[10].Value.ToString() == "")
            {
                tbl_dgv.Rows[0].Cells[10].Value = "NP";

            }
            if (tbl_dgv.Rows[0].Cells[11].Value == null || tbl_dgv.Rows[0].Cells[11].Value.ToString() == "")
            {
                tbl_dgv.Rows[0].Cells[11].Value = "NP";

            }
            
           
        }









        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            validationcontrol();
            updateaction(int.Parse(tbl_dgv.Rows[0].Cells[0].Value.ToString()));
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    
      





    }
}

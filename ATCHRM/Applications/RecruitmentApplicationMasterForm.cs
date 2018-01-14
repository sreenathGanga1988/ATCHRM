using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class RecruitmentApplicationMasterForm : Form
    {

        DataTable masterrecruitdata = new DataTable();
        DataTable applicationsdone = new DataTable();
        Transactions.RecruitApplicationTransaction rcrtapptrans = new Transactions.RecruitApplicationTransaction();
        public RecruitmentApplicationMasterForm()
        {
            InitializeComponent();
            rcrtapptrans = new Transactions.RecruitApplicationTransaction();
            loaddatatable();
            cmb_action.SelectedIndex = 0;
        }


        public void loaddatatable()
        {
            rcrtapptrans = new Transactions.RecruitApplicationTransaction();
            masterrecruitdata = rcrtapptrans.GetAllApllicationStatus();
            applicationsdone = rcrtapptrans.getallnonApprovedRecruitmentData ();
        }

        public void filterdata()
        {
            for (int i = 0; i < tbl_recruitmentdata.Rows.Count - 2; i++)
            {

                if (tbl_recruitmentdata.Rows[i].Cells[5].Value.ToString() != tbl_recruitmentdata.Rows[i].Cells[10].Value.ToString())
                {
                    tbl_recruitmentdata.Rows.RemoveAt(i);
                }
            }
        }

        public void filldatagrid()
        {
            loaddatatable();
            if (cmb_action.Text.Trim() == "Approved Applications")
            {

                if (masterrecruitdata != null)
                {
                    tbl_recruitmentdata.Rows.Clear();
                    tbl_recruitmentdata.DataSource = null;
                    for (int i = 0; i < masterrecruitdata.Rows.Count; i++)
                    {
                        tbl_recruitmentdata.Rows.Add();
                        tbl_recruitmentdata.Rows[i].Cells[0].Value = masterrecruitdata.Rows[i][0];
                        tbl_recruitmentdata.Rows[i].Cells[1].Value = masterrecruitdata.Rows[i][1];
                        tbl_recruitmentdata.Rows[i].Cells[2].Value = masterrecruitdata.Rows[i][2];
                        tbl_recruitmentdata.Rows[i].Cells[3].Value = masterrecruitdata.Rows[i][3];
                        tbl_recruitmentdata.Rows[i].Cells[4].Value = masterrecruitdata.Rows[i][4];
                        tbl_recruitmentdata.Rows[i].Cells[5].Value = masterrecruitdata.Rows[i][5];
                        tbl_recruitmentdata.Rows[i].Cells[6].Value = masterrecruitdata.Rows[i][6];
                        tbl_recruitmentdata.Rows[i].Cells[7].Value = masterrecruitdata.Rows[i][7];
                        tbl_recruitmentdata.Rows[i].Cells[8].Value = masterrecruitdata.Rows[i][8];


                    }
                }
            }
            else if (cmb_action.Text.Trim() == "Not Approved Application")
            {
                if (applicationsdone != null)
                {
                    tbl_recruitmentdata.Rows.Clear();
                    tbl_recruitmentdata.DataSource = null;
                    for (int i = 0; i < applicationsdone.Rows.Count; i++)
                    {                      
                        tbl_recruitmentdata.Rows.Add();
                        tbl_recruitmentdata.Rows[i].Cells[0].Value = applicationsdone.Rows[i][0];//sl
                        tbl_recruitmentdata.Rows[i].Cells[1].Value = applicationsdone.Rows[i][1];//aapnum
                        tbl_recruitmentdata.Rows[i].Cells[2].Value = applicationsdone.Rows[i][2];//desg
                        tbl_recruitmentdata.Rows[i].Cells[3].Value = applicationsdone.Rows[i][3];//dept
                        tbl_recruitmentdata.Rows[i].Cells[4].Value = applicationsdone.Rows[i][4];//branch
                        tbl_recruitmentdata.Rows[i].Cells[5].Value = applicationsdone.Rows[i][5];//vaccancy
                        tbl_recruitmentdata.Rows[i].Cells[6].Value = applicationsdone.Rows[i][6];  //
                        tbl_recruitmentdata.Rows[i].Cells[7].Value = applicationsdone.Rows[i][7];//
                        tbl_recruitmentdata.Rows[i].Cells[8].Value = applicationsdone.Rows[i][8];//
                        tbl_recruitmentdata.Rows[i].Cells[9].Value = applicationsdone.Rows[i][9];
                        tbl_recruitmentdata.Rows[i].Cells[10].Value = applicationsdone.Rows[i][12];



                    }
                filterdata();
                }

            }
        }

     

        public void  Gridcoloumns()
        {
           
            if (cmb_action.Text.Trim() == "Approved Applications")
            {



                tbl_recruitmentdata.Columns.Clear();
                tbl_recruitmentdata.Rows.Clear();
                tbl_recruitmentdata.Columns.Add("0", "SL");
                tbl_recruitmentdata.Columns.Add("1", "Applicaqtion #");
                tbl_recruitmentdata.Columns.Add("2", "Designation ");
                tbl_recruitmentdata.Columns.Add("3", "Department ");
                tbl_recruitmentdata.Columns.Add("4", "Location ");
                tbl_recruitmentdata.Columns.Add("5", "Applied Vaccancies");
                tbl_recruitmentdata.Columns.Add("6", "L1 Approved");
                tbl_recruitmentdata.Columns.Add("7", "L2 Approved");
                tbl_recruitmentdata.Columns.Add("8", "L3 Approved");
                tbl_recruitmentdata.Columns.Add("9", "Is Completed");
            }
            else if (cmb_action.Text.Trim() == "Not Approved Application")
            {




                tbl_recruitmentdata.Columns.Clear();
                tbl_recruitmentdata.Rows.Clear();
                tbl_recruitmentdata.Columns.Add("1", "SL");
                tbl_recruitmentdata.Columns.Add("2", "Applicaqtion #");
                tbl_recruitmentdata.Columns.Add("3", "Recruitment Location");
                tbl_recruitmentdata.Columns.Add("4", "Designation");
                tbl_recruitmentdata.Columns.Add("5", "Department ");
                tbl_recruitmentdata.Columns.Add("6", "Applied Vaccancies");
                tbl_recruitmentdata.Columns.Add("7", "Contract");
                tbl_recruitmentdata.Columns.Add("8", "Description");
                tbl_recruitmentdata.Columns.Add("9", "Interviewed By");
                tbl_recruitmentdata.Columns.Add("10", "ExpectedJoining Date");
                tbl_recruitmentdata.Columns.Add("11", "Balance");

            }

        }

       

        private void cmb_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gridcoloumns();
            if (cmb_action.Text.Trim() == "Approved Applications")
            {

               
              
                filldatagrid();
            }
            else if (cmb_action.Text.Trim() == "Not Approved Application")
            {

                filldatagrid();
            }

        }

        private void btm_submitt_Click(object sender, EventArgs e)
        {
            Applications.RecruitmentApplicationForm rctrmntform = new Applications.RecruitmentApplicationForm();
            rctrmntform.MdiParent = this.MdiParent;
            this.Close();
            rctrmntform.Show();
        }

        private void RecruitmentApplicationMasterForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            tbl_recruitmentdata.Columns.Clear();
            tbl_recruitmentdata.Rows.Clear();
            tbl_recruitmentdata.Columns.Add("1", "SL");
            tbl_recruitmentdata.Columns.Add("2", "Applicaqtion #");
            tbl_recruitmentdata.Columns.Add("3", "Recruitment Location");
            tbl_recruitmentdata.Columns.Add("4", "Designation");
            tbl_recruitmentdata.Columns.Add("5", "Department ");
            tbl_recruitmentdata.Columns.Add("6", "Applied Vaccancies");
            tbl_recruitmentdata.Columns.Add("7", "Contract");
            tbl_recruitmentdata.Columns.Add("8", "Description");
            tbl_recruitmentdata.Columns.Add("9", "Interviewed By");
            tbl_recruitmentdata.Columns.Add("10", "ExpectedJoining Date");
            tbl_recruitmentdata.Columns.Add("11", "Balance");

            if (applicationsdone != null)
            {
                tbl_recruitmentdata.Rows.Clear();
                tbl_recruitmentdata.DataSource = null;
                for (int i = 0; i < applicationsdone.Rows.Count; i++)
                {
                    tbl_recruitmentdata.Rows.Add();
                    tbl_recruitmentdata.Rows[i].Cells[0].Value = applicationsdone.Rows[i][0];//sl
                    tbl_recruitmentdata.Rows[i].Cells[1].Value = applicationsdone.Rows[i][1];//aapnum
                    tbl_recruitmentdata.Rows[i].Cells[2].Value = applicationsdone.Rows[i][2];//desg
                    tbl_recruitmentdata.Rows[i].Cells[3].Value = applicationsdone.Rows[i][3];//dept
                    tbl_recruitmentdata.Rows[i].Cells[4].Value = applicationsdone.Rows[i][4];//branch
                    tbl_recruitmentdata.Rows[i].Cells[5].Value = applicationsdone.Rows[i][5];//vaccancy
                    tbl_recruitmentdata.Rows[i].Cells[6].Value = applicationsdone.Rows[i][6];  //
                    tbl_recruitmentdata.Rows[i].Cells[7].Value = applicationsdone.Rows[i][7];//
                    tbl_recruitmentdata.Rows[i].Cells[8].Value = applicationsdone.Rows[i][8];//
                    tbl_recruitmentdata.Rows[i].Cells[9].Value = applicationsdone.Rows[i][9];
                    tbl_recruitmentdata.Rows[i].Cells[10].Value = applicationsdone.Rows[i][12];



                }
                filterdata();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Applications.NonApprovedRecruitmentApllicationForm lvapp = new NonApprovedRecruitmentApllicationForm();
            lvapp.MdiParent = this.MdiParent;
            lvapp.Show();
        }


     










    }
}

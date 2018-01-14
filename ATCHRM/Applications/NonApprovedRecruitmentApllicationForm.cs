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
    public partial class NonApprovedRecruitmentApllicationForm : Form
    {
        DataTable masterrecruitdata = new DataTable();
        DataTable applicationsdone = new DataTable();
        Transactions.RecruitApplicationTransaction rcrtapptrans = new Transactions.RecruitApplicationTransaction();
        public NonApprovedRecruitmentApllicationForm()
        {
            InitializeComponent();
            setdatagridview();
        }
        public void loaddatatable()
        {
            rcrtapptrans = new Transactions.RecruitApplicationTransaction();
            masterrecruitdata = rcrtapptrans.getallApprovedRecruitmentAppData();
            applicationsdone = rcrtapptrans.getallnonApprovedRecruitmentData();
        }

        public void setdatagridview()
        {
            //loaddatatable();
            //tbl_recruitmentdata.Columns.Clear();
            //tbl_recruitmentdata.Rows.Clear();
            //tbl_recruitmentdata.Columns.Add("1", "SL");
            //tbl_recruitmentdata.Columns.Add("2", "Applicaqtion #");
            //tbl_recruitmentdata.Columns.Add("3", "Recruitment Location");
            //tbl_recruitmentdata.Columns.Add("4", "Designation");
            //tbl_recruitmentdata.Columns.Add("5", "Department ");
            //tbl_recruitmentdata.Columns.Add("6", "Applied Vaccancies");
            //tbl_recruitmentdata.Columns.Add("7", "Contract");
            //tbl_recruitmentdata.Columns.Add("8", "Description");
            //tbl_recruitmentdata.Columns.Add("9", "Interviewed By");
            //tbl_recruitmentdata.Columns.Add("10", "ExpectedJoining Date");
            //tbl_recruitmentdata.Columns.Add("11", "Balance");

            //if (applicationsdone != null)
            //{
            //    tbl_recruitmentdata.Rows.Clear();
            //    tbl_recruitmentdata.DataSource = null;
            //    for (int i = 0; i < applicationsdone.Rows.Count; i++)
            //    {
            //        tbl_recruitmentdata.Rows.Add();
            //        tbl_recruitmentdata.Rows[i].Cells[0].Value = applicationsdone.Rows[i][0];//sl
            //        tbl_recruitmentdata.Rows[i].Cells[1].Value = applicationsdone.Rows[i][1];//aapnum
            //        tbl_recruitmentdata.Rows[i].Cells[2].Value = applicationsdone.Rows[i][2];//desg
            //        tbl_recruitmentdata.Rows[i].Cells[3].Value = applicationsdone.Rows[i][3];//dept
            //        tbl_recruitmentdata.Rows[i].Cells[4].Value = applicationsdone.Rows[i][4];//branch
            //        tbl_recruitmentdata.Rows[i].Cells[5].Value = applicationsdone.Rows[i][5];//vaccancy
            //        tbl_recruitmentdata.Rows[i].Cells[6].Value = applicationsdone.Rows[i][6];  //
            //        tbl_recruitmentdata.Rows[i].Cells[7].Value = applicationsdone.Rows[i][7];//
            //        tbl_recruitmentdata.Rows[i].Cells[8].Value = applicationsdone.Rows[i][8];//
            //        tbl_recruitmentdata.Rows[i].Cells[9].Value = applicationsdone.Rows[i][9];
            //        tbl_recruitmentdata.Rows[i].Cells[10].Value = applicationsdone.Rows[i][12];



            //    }
            //    filterdata();
            //}

            loaddatatable();

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
            tbl_recruitmentdata.Columns[9].Visible = false;
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
    
    
    }
}

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
    public partial class RecruitmentCodeForm : Form
    {
        DataTable masterrecruitdata = new DataTable();
        Transactions.RecruitApplicationTransaction rcrtapptrans = new Transactions.RecruitApplicationTransaction();
        public RecruitmentCodeForm()
        {
            InitializeComponent();
            rcrtapptrans = new Transactions.RecruitApplicationTransaction();
           
        }
        public void loaddatatable()
        {
            rcrtapptrans = new Transactions.RecruitApplicationTransaction();
            masterrecruitdata = rcrtapptrans.getallRecruitmentCodeandApplication ();
        }

        public void Gridcoloumns()
        {

          

             //   tbl_recruitmentcode.Columns.Clear();
                tbl_recruitmentcode.Rows.Clear();
                tbl_recruitmentcode.Columns.Add("0", "SL");
                tbl_recruitmentcode.Columns.Add("1", "RecruitmentCode#");
                tbl_recruitmentcode.Columns.Add("2", "Designation ");
                tbl_recruitmentcode.Columns.Add("3", "Department ");
                tbl_recruitmentcode.Columns.Add("4", "Location ");
                tbl_recruitmentcode.Columns.Add("5", "Applied  Date");
                tbl_recruitmentcode.Columns.Add("6", "Code status");
                tbl_recruitmentcode.Columns.Add("7", "Contract Type");
                tbl_recruitmentcode.Columns.Add("8", "Interviewed By");
                tbl_recruitmentcode.Columns.Add("9", "Application num");
                tbl_recruitmentcode.Columns[1].Visible = false;

        }

        public void filldatagrid(DataTable masterrecruitdata)
        {
            if (masterrecruitdata != null)
            {
                tbl_recruitmentcode.Rows.Clear();
                tbl_recruitmentcode.DataSource = null;
                for (int i = 0; i < masterrecruitdata.Rows.Count; i++)
                {
                    tbl_recruitmentcode.Rows.Add();
                    tbl_recruitmentcode.Rows[i].Cells[1].Value = masterrecruitdata.Rows[i][0];
                    tbl_recruitmentcode.Rows[i].Cells[2].Value = masterrecruitdata.Rows[i][1];
                    tbl_recruitmentcode.Rows[i].Cells[3].Value = masterrecruitdata.Rows[i][2];
                    tbl_recruitmentcode.Rows[i].Cells[4].Value = masterrecruitdata.Rows[i][3];
                    tbl_recruitmentcode.Rows[i].Cells[5].Value = masterrecruitdata.Rows[i][4];
                    tbl_recruitmentcode.Rows[i].Cells[6].Value = masterrecruitdata.Rows[i][5];
                    tbl_recruitmentcode.Rows[i].Cells[7].Value = masterrecruitdata.Rows[i][6];
                    tbl_recruitmentcode.Rows[i].Cells[8].Value = masterrecruitdata.Rows[i][7];
                    tbl_recruitmentcode.Rows[i].Cells[9].Value = masterrecruitdata.Rows[i][8];
                    tbl_recruitmentcode.Rows[i].Cells[10].Value = masterrecruitdata.Rows[i][9];

                }
            }

        }

        private void RecruitmentCodeForm_Load(object sender, EventArgs e)
        {
            loaddatatable();
            Gridcoloumns();
            filldatagrid(masterrecruitdata);
        }

        private void tbl_recruitmentcode_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_recruitmentcode.IsCurrentCellDirty)
            {
                tbl_recruitmentcode.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cmb_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterdata();
        }


        public void filterdata()
        {

            if (cmb_action.Text!= null)
            {
                DataTable dt = masterrecruitdata.Clone();


                if (masterrecruitdata == null || masterrecruitdata.Rows.Count == 0)
                {
                    masterrecruitdata = rcrtapptrans.getallRecruitmentCodeandApplication();
                }

  
                if(cmb_action.Text.Trim()=="Available")
                {
                    DataRow[] result = masterrecruitdata.Select("Status='W' ");
                    foreach (DataRow row in result)
                    {
                        //DataRow newRow = dt.NewRow();
                        //newRow.ItemArray = row.ItemArray;
                        dt.Rows.Add(row.ItemArray);
                    }
                }
                else if (cmb_action.Text.Trim() == "Assigned")
                {
                    DataRow[] result = masterrecruitdata.Select("Status='A' ");
                    foreach (DataRow row in result)
                    {
                        //DataRow newRow = dt.NewRow();
                        //newRow.ItemArray = row.ItemArray;
                        dt.Rows.Add(row.ItemArray);
                    }
                }
                else if (cmb_action.Text.Trim() == "Used")
                {
                    DataRow[] result = masterrecruitdata.Select("Status='U' ");
                    foreach (DataRow row in result)
                    {
                        //DataRow newRow = dt.NewRow();
                        //newRow.ItemArray = row.ItemArray;
                        dt.Rows.Add(row.ItemArray);
                    }
                }
              



              

                filldatagrid(dt);






            }

        }

        private void tbl_recruitmentcode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tbl_recruitmentcode.Rows.Count != 0)
                {

                    int reccodeid = int.Parse(tbl_recruitmentcode.Rows[e.RowIndex].Cells[1].Value.ToString());
                    GetMyResult = reccodeid.ToString();
                    this.Close();
                }
            }
            catch (Exception)
            {
                
                this.Close();
            }
        }



        public String GetMyResult;

        public String GetMyResult1
        {
            get { return GetMyResult; }
            set { GetMyResult = value; }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    
    
    
    
    
    
    
    
    
    
    }
}

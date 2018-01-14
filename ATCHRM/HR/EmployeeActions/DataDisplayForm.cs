using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATCHRM.HR.NewFolder1
{
    public partial class DataDisplayForm : Form
    {
        Transactions.EmployeeRegTransaction empreg = null;
        public DataDisplayForm()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
        }

        public DataDisplayForm(String  nationalID)
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();


            btn_dsply.Text = "Get Approval for re employing";
            getEmployeeprevoioustrack(nationalID);
        }

        public DataDisplayForm(String Actiontype,int logger)
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
            btn_dsply.Text = "Approve";
            getPendingNIDApproval();
        }

        /// <summary>
        /// get all the pending Approval for NID
        /// </summary>
        public void getPendingNIDApproval()
        {
            DataTable dt = empreg.getAllPendingNationalIDApproval();
            tbldata.DataSource = dt;
        }


        public void getEmployeeprevoioustrack(String nationalID)
        {
            DataTable dt = empreg.getnationalidePLOYEE(nationalID);
            tbldata.DataSource = dt;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (btn_dsply.Text == "Get Approval for re employing")
            {
                sendNIDforApproval();
            }
            else
            {
                ApproveNIDReuse();
            }
           
        }


        public void ApproveNIDReuse()
        {
            Boolean wanttodeactivate = false;
            if (tbldata.Rows.Count > 0)
            {

                for (int i = 0; i < tbldata.Rows.Count-1; i++)
                {
                    if (tbldata.Rows[i].Cells[4].Value.ToString().Trim() == "A")
                    {
                        DialogResult dialogResult = MessageBox.Show("It is recommended to deactivate the Existing employee before using the NationID again. Do you want to Continue without Deactivating ", "Attention ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            wanttodeactivate = true;
                        }

                    }
                }

                if (!wanttodeactivate)
                {

                    if (tbldata.SelectedRows.Count != 0)
                    {
                        int rowindex = tbldata.CurrentRow.Index;
                        int appid = int.Parse(tbldata.Rows[rowindex].Cells[0].Value.ToString());
                        int empid = int.Parse(tbldata.Rows[rowindex].Cells[1].Value.ToString());
                        empreg.updateNIDStatus(appid);
                        MessageBox.Show("Done");
                    }
                }
            }
        }



        /// <summary>
        /// if an NId has to be ebntered Again its send to approval
        /// </summary>
        public void sendNIDforApproval()
        {
            if (tbldata.Rows.Count != 0)
            {
                int count = tbldata.Rows.Count - 1;
                for (int i = 0; i < tbldata.Rows.Count - 1; i++)
                {
                    if (tbldata.Rows[i].Cells[2].Value.ToString().Trim() == "A")
                    {

                        int empid = int.Parse(tbldata.Rows[0].Cells[0].Value.ToString());

                        String nationalid = tbldata.Rows[0].Cells[10].Value.ToString().Trim();
                        empreg.InsertApplicationNID(empid, count, nationalid);
                        MessageBox.Show("Done");
                        getPendingNIDApproval();
                    }




                }
            }
        }
    }
}

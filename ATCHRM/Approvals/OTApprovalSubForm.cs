using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Approvals
{
    public partial class OTApprovalSubForm : Form
    {
        private readonly Approvals.LevelApprovalForm_1 _form1;
        private readonly Approvals.LevelApprovalForm_2 _form2;
        Transactions.OvertimeandShiftTransaction ovttrans = null;
        Transactions.ApprovalTransaction apprvlTransaction = null;
        int levelnumber = 0;
        int otpk = 0;
        public OTApprovalSubForm()
        {
            InitializeComponent();
            ovttrans = new Transactions.OvertimeandShiftTransaction();
        }


        public OTApprovalSubForm(Approvals.LevelApprovalForm_1 form1, int otPK, int levelnum)
    {
        _form1 = form1;
              InitializeComponent();
            ovttrans = new Transactions.OvertimeandShiftTransaction();
            apprvlTransaction = new Transactions.ApprovalTransaction();
            levelnumber = levelnum;
            otpk = otPK;
            showOvertimedata(otPK);
    }

        public OTApprovalSubForm(Approvals.LevelApprovalForm_2 form, int otPK, int levelnum)
        {
            _form2 = form;
            InitializeComponent();
            ovttrans = new Transactions.OvertimeandShiftTransaction();
            apprvlTransaction = new Transactions.ApprovalTransaction();
            levelnumber = levelnum;
            otpk = otPK;
            showOvertimedata(otPK);
        }


        public OTApprovalSubForm(int otPK , int levelnum)
        {
            InitializeComponent();
            ovttrans = new Transactions.OvertimeandShiftTransaction();
            apprvlTransaction = new Transactions.ApprovalTransaction();
            levelnumber = levelnum;
            otpk = otPK;
            showOvertimedata(otPK);
        }



        public void showOvertimedata(int otPK)
        {
            DataTable dt = new DataTable();

            tbl_otdetails.RowCount = 1;
            dt = ovttrans.getOTdetails(otPK);


        //    tbl_otdetails.Columns[0].Visible = true;
            tbl_otdetails.Columns[13].Visible = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_otdetails.Rows.Add();
                tbl_otdetails.Rows[i].Cells[1].Value = dt.Rows[i][0];

                tbl_otdetails.Rows[i].Cells[2].Value = dt.Rows[i][1];
                tbl_otdetails.Rows[i].Cells[3].Value = dt.Rows[i][2];
                tbl_otdetails.Rows[i].Cells[4].Value = dt.Rows[i][3];
                tbl_otdetails.Rows[i].Cells[5].Value = dt.Rows[i][4];
                tbl_otdetails.Rows[i].Cells[6].Value = dt.Rows[i][5];
                tbl_otdetails.Rows[i].Cells[7].Value = dt.Rows[i][6];   
                tbl_otdetails.Rows[i].Cells[8].Value = dt.Rows[i][7];
                tbl_otdetails.Rows[i].Cells[9].Value = dt.Rows[i][8];
                tbl_otdetails.Rows[i].Cells[10].Value = dt.Rows[i][9];
                tbl_otdetails.Rows[i].Cells[11].Value = dt.Rows[i][10];
                tbl_otdetails.Rows[i].Cells[12].Value = dt.Rows[i][11];
                tbl_otdetails.Rows[i].Cells[13].Value = dt.Rows[i][12];


            }
        }

        private void tbl_otdetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_otdetails.IsCurrentCellDirty)
            {
                tbl_otdetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void chk_Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Selection.Checked == true)
            {
                for (int i = 0; i < tbl_otdetails.Rows.Count - 1; i++)
                {
                    tbl_otdetails.Rows[i].Cells[0].Value = true;
                    tbl_otdetails.Rows[i].Selected = true;
                   // tbl_ApprovalData.Columns[13].ReadOnly = false;
                }

            }
            else
            {
                for (int i = 0; i < tbl_otdetails.Rows.Count - 1; i++)
                {
                    tbl_otdetails.Rows[i].Cells[0].Value = false;
                    tbl_otdetails.Rows[i].Selected = false;
                  //  tbl_ApprovalData.Columns[13].ReadOnly = true; ;
                }
            }
        }

        private void tbl_otdetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                
                if (Convert.ToBoolean(tbl_otdetails.Rows[e.RowIndex].Cells[0].Value) == true)
                {
                    tbl_otdetails.Rows[e.RowIndex].Selected = true;
                }
                else
                {
                    tbl_otdetails.Rows[e.RowIndex].Selected = false;
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            updatethedatagridfor1();
            this.Close();
        }

        private void btn_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tbl_otdetails.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tbl_otdetails.Rows[i].Cells[0].Value) == true)
                    {
                        apprvlTransaction.deleteOtEmployee(int.Parse(tbl_otdetails.Rows[i].Cells[1].Value.ToString()), int.Parse(tbl_otdetails.Rows[i].Cells[2].Value.ToString()), levelnumber);
                    }

                }
                showOvertimedata(otpk);
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }




        public void updatethedatagridfor1()
        {

            if (_form1 != null)
            {

                _form1.showotappdata();
            }
            else if (_form2 != null)
            {
                _form2.showotappdaat();

            }
        }

        private void OTApprovalSubForm_Load(object sender, EventArgs e)
        {

        }

    }
}

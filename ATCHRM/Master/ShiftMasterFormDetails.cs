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
    public partial class ShiftMasterFormDetails : Form
    {
        Transactions.ShiftTransaction trans = null;
        public ShiftMasterFormDetails()
        {
            InitializeComponent();
            trans = new Transactions.ShiftTransaction();
            datagrdviewsetup();
        }



        public void getallshiftdata()
        {

        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_approval_Click(object sender, EventArgs e)
        {
            Master.ShiftDetailsMasterForm shftdetails = new Master.ShiftDetailsMasterForm();
            shftdetails.MdiParent = this.MdiParent;
            shftdetails.Show();
        }

        public void datagrdviewsetup()
        {
            tbl_shiftdata.DataSource = trans.getallshiftdaataforjustdisplay();
            
            tbl_shiftdata.Columns[0].Visible = false;
            //tbl_shiftdata.Columns[2].Visible = false;
            //tbl_shiftdata.Columns[3].Visible = false;
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            Master.shiftmasterform shftform = new Master.shiftmasterform();
            shftform.MdiParent = this.MdiParent ;
            shftform.StartPosition = FormStartPosition.CenterScreen;
            shftform.Show();
        }

        private void tbl_shiftdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //    gettALLShiftDetailsofSpecificShift

            if (e.RowIndex >= 0)
            {
                DataTable dt = trans.gettALLShiftDetailsofSpecificShift(int.Parse(tbl_shiftdata.Rows[e.RowIndex].Cells[0].Value.ToString()));
           
            Master.ShiftDetailsMasterForm shftform = new Master.ShiftDetailsMasterForm(dt );
            shftform.MdiParent = this.MdiParent;
            shftform.StartPosition = FormStartPosition.CenterScreen;
            shftform.Show();
            }
        }

        private void deactivateShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateaction(int.Parse(tbl_shiftdata.Rows[tbl_shiftdata.CurrentRow.Index].Cells["Sl"].Value.ToString()));
        }



        public void updateaction(int empid)
        {
            SqlServerLinqDataContext cntxt = new SqlServerLinqDataContext(Program.ConnStr);

            var q = from e in cntxt.ShiftMasterNew_tbls
                    where e.ShiftPK  == empid
                    select e;
            foreach (var element in q)
            {
                element.IsActive  = "D";
                
                cntxt.SubmitChanges();
            }
            MessageBox.Show("Deactivated");
        }
    
    
    
    
    }
}

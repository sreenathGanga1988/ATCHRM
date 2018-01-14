using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Attendance
{
   
    public partial class AdjusterForm : Form
    {
        Datalayer.AdjusterDatabean adjstbean = null;
        Transactions.Adjuster.AdjusterTranscation adjstrtrans = null;
        Transactions.CompanyBranchTransactions cmptransaction = null;
        int lctnflag = 0;
        Transactions.DataExporter DTPEXPTR = null;
        public AdjusterForm()
        {
            InitializeComponent();
            adjstrtrans = new Transactions.Adjuster.AdjusterTranscation();
            cmptransaction = new Transactions.CompanyBranchTransactions();
        
        }

        public void filldata(int branchlctnpk,DateTime fromdate,DateTime todate )
        {
            DataTable swipedata = adjstrtrans.GetNonAdjustedData(branchlctnpk, fromdate, todate);

            tblNonAdjusterdata.RowCount = 1;
            for (int i = 0; i < swipedata.Rows.Count; i++)
            {
                tblNonAdjusterdata.Rows.Add();
                tblNonAdjusterdata.Rows[i].Cells[0].Value = swipedata.Rows[i][0];

                tblNonAdjusterdata.Rows[i].Cells[1].Value = swipedata.Rows[i][1];
                tblNonAdjusterdata.Rows[i].Cells[2].Value = swipedata.Rows[i][2];
                tblNonAdjusterdata.Rows[i].Cells[3].Value = swipedata.Rows[i][3];
                 tblNonAdjusterdata.Rows[i].Cells[4].Value = swipedata.Rows[i][4];
                tblNonAdjusterdata.Rows[i].Cells[5].Value = swipedata.Rows[i][5];
                tblNonAdjusterdata.Rows[i].Cells[6].Value = swipedata.Rows[i][6];

                tblNonAdjusterdata.Rows[i].Cells[7].Value = swipedata.Rows[i][7];
                tblNonAdjusterdata.Rows[i].Cells[8].Value = swipedata.Rows[i][8];
                tblNonAdjusterdata.Rows[i].Cells[9].Value = swipedata.Rows[i][9];

                tblNonAdjusterdata.Rows[i].Cells[10].Value = swipedata.Rows[i][10];

                tblNonAdjusterdata.Rows[i].Cells[11].Value = swipedata.Rows[i][11];
                tblNonAdjusterdata.Rows[i].Cells[12].Value = 0;
                tblNonAdjusterdata.Rows[i].Cells[13].Value = swipedata.Rows[i][12];

                getdurationdone(i);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                filldata(Program.LOCTNPK, dtp_from.Value.Date, dtp_to.Value.Date);

                lblStatus.Text = tblNonAdjusterdata.Rows.Count.ToString();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
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

        public void getdurationdone(int i)
        {
            

                DateTime a = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());

                DateTime b = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString());

                tblNonAdjusterdata.Rows[i].Cells[12].Value = Math.Truncate(b.Subtract(a).TotalMinutes);

                tblNonAdjusterdata.Rows[i].Cells[15].Value = Math.Truncate(float.Parse(tblNonAdjusterdata.Rows[i].Cells[12].Value.ToString()) - float.Parse(tblNonAdjusterdata.Rows[i].Cells[14].Value.ToString()));




           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                adjstbean = new Datalayer.AdjusterDatabean();

                adjstbean.BranchlctnPk = int.Parse(cmb_location.SelectedValue.ToString());
                adjstbean.Fromdate = dtp_from.Value.Date;
                adjstbean.Todate = dtp_to.Value.Date;
                if (!adjstrtrans.checkifactiondone(dtp_from.Value.Date, dtp_to.Value.Date))
                {
                    adjstrtrans.insertAdjusterdata(adjstbean);
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                }
                else
                {

                     ATCHRM.Controls.ATCHRMMessagebox.Show("Adjuster for these date already Done");
                }

            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }

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

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {
            lctnflag++;
        }

        private void AdjusterForm_Load(object sender, EventArgs e)
        {
            locationListLoad();
        }





        

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tblNonAdjusterdata);
        }

        private void btn_approval_Click(object sender, EventArgs e)
        {

        }
    }
}

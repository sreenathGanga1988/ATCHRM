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
    public partial class PayrollCalender : Form
    {
        Transactions.PayrollTransaction.MainPayrollTransaction mantran = new Transactions.PayrollTransaction.MainPayrollTransaction();
        public PayrollCalender()
        {
            InitializeComponent();
        }

        private void PayrollCalender_Load(object sender, EventArgs e)
        {
            double year = DateTime.Now.Year - 1;
            comboBox2.Text = (year).ToString();
            for (int i = 0; i < 10; i++)
            {
                comboBox2.Items.Add((year + i).ToString());
            }
        }

        private void dt_drp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell.Value = dt_drp.Value.Date;
            }
            catch (Exception)
            {


            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.CurrentRow.Cells[0].Value = comboBox2.Text;
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                calculatedays();

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - 1 > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    mantran.insertpayrollcalender(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()), int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));

                }
                ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

            }
            else
            {
                ATCHRM.Controls.ATCHRMMessagebox.Show("No row found");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

            Administrator.Gridform grd = new Administrator.Gridform(1);
            grd.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                Point p = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                p.Offset(dataGridView1.Location);
                dt_drp.Location = p;

                try
                {
                    dt_drp.Value = Convert.ToDateTime(dataGridView1.CurrentCell.Value);
                }
                catch (Exception)
                {
                }
                dt_drp.Size = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;

                dt_drp.Visible = true;
                dt_drp.Select();

            }
        }




        static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }



        public void calculatedays()
        {
            try
            {
                DateTime fromdate = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());

                try
                {
                    DateTime todate = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());


                    //int diffDays = (todate.Date - fromdate.Date).Days;
                    TimeSpan duration = todate.Date - fromdate.Date;
                    int diffDays = duration.Days + 1;

                    dataGridView1.CurrentRow.Cells[4].Value = diffDays.ToString();
                }
                catch (Exception)
                {


                }
            }
            catch (Exception)
            {


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Administrator.Gridform grd = new Administrator.Gridform();
            grd.Show();
        }
    
    
    
    
    
    
    
    
    }
}

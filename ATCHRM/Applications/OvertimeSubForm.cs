using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace ATCHRM.Applications
{
    public partial class OvertimeSubForm : Form
    {
       
        public OvertimeSubForm()
        {
            InitializeComponent();
        }

        public OvertimeSubForm(ArrayList leaveaaray, ArrayList lhaaray)
        {
            InitializeComponent();
            loadlistview(leaveaaray, lhaaray);
        }





        public void loadlistview(ArrayList leaveaaray, ArrayList lhaaray)
        {

          //   lbl_leave.Text = leaveemp.ToString();
             //  lbl_lh.Text = lhemployee.ToString();
         //   loadlistview();
            
            int counterOfArraylist = leaveaaray .Count;

            for (int i = 0; i < counterOfArraylist; i++)
            {
                tbl_Abscent.Rows.Add();
                tbl_Abscent.Rows[i].Cells [0].Value  = leaveaaray[i].ToString();

            }
        

           
            int counteroflh = lhaaray .Count;
          
            for (int i = 0; i < counteroflh; i++)
            {
                tbl_LH.Rows.Add();
                tbl_LH .Rows[i].Cells[0].Value = lhaaray[i].ToString();

            }

            lbl_leave.Text = counterOfArraylist.ToString();
            lbl_lh.Text = counteroflh.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }









    }
}

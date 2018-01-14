using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Action
{
    public partial class ActionReasonForm : Form
    {
        public ActionReasonForm()
        {
            InitializeComponent();
        }
        public ActionReasonForm( int action ,String actiontype , int employeenum)
        {
            InitializeComponent();
            switch (action)
            {
                case 1 :
                              this.Text = "Mark Abscent";
                            lblHeading.Text = "Marking XXXX of Employee XXX to "+actiontype ;
                              break;
                case 2:
                              lblHeading.Text = "Marking XXXX of Employee XXX to "+actiontype ;
                              this.Text = "Mark Present"; 
                              break;
                case 3:
                              lblHeading.Text = "Marking XXXX of Employee XXX to " + actiontype;
                              this.Text = "Mark Leave"; 
                              break;
                case 4:
                              lblHeading.Text = "Marking " + employeenum + " Employees as  " + actiontype;
                              this.Text = "Make Leave"; 
                              break;
                        

               
                       
            }

            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            rht_reason.Text = "No Reason Provided";
            this.Close();
        }
    }
}

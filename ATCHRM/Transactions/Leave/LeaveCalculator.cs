using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Transactions.Leave
{
    public partial class LeaveCalculator : Form
    {
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.LeaveTransaction lvtransaction = null;
        public LeaveCalculator()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            employecodeload(0, 0, 0);


            lvtransaction = new Transactions.LeaveTransaction();
        }






        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_empcode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_empcode.DataSource = dt;
            cmb_empcode.DisplayMember = "empno";
            cmb_empcode.ValueMember = "empid";
        }

        public void leavecomboLoad(int empid)
        {
            DataTable dt = lvtransaction.LeaveApplicabletoEmployee(empid);
            cmb_leave.DataSource = dt;
            cmb_leave.DisplayMember = "LEAVE";
            cmb_leave.ValueMember = "SL";
        }

        private void cmb_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                   
           int     empid = int.Parse(cmb_empcode.SelectedValue.ToString());
           leavecomboLoad(empid);
            }
            catch (Exception)
            {


            }
        }

        private void cmb_leave_SelectedIndexChanged(object sender, EventArgs e)
        {

        }











    }
}

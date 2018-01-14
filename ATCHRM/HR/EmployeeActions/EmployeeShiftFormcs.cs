using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.HR.NewFolder1
{
    public partial class EmployeeShiftFormcs : Form
    {
        Transactions.ShiftTransactionNewform  shfttransaction = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Datalayer.EmployeeShiftDatabean shftdatbean = null;
        int flag = 0;
        int changeappid = 0;
        int changeshiftid = 0;
        String applicationType = null;
        public EmployeeShiftFormcs()
        {
            InitializeComponent();
            shfttransaction = new Transactions.ShiftTransactionNewform();
            empregtrans = new Transactions.EmployeeRegTransaction();
            employecodeload(Program.LOCTNPK, 0, 0);
            shiftcomboload("Start");
        }



        /// <summary>
        /// when form opened at the registration process
        /// </summary>
        /// <param name="Empnum"></param>
        /// <param name="emppk"></param>
        public EmployeeShiftFormcs(String Empnum ,int emppk)
        {
            InitializeComponent();
            shfttransaction = new Transactions.ShiftTransactionNewform();
            empregtrans = new Transactions.EmployeeRegTransaction();
            cmb_EmpCode.Text = Empnum;
            lbl_emppk.Text = emppk.ToString ();
            shiftcomboload("Start");
        }

        /// <summary>
        /// when page opened as shift change application
        /// </summary>
        /// <param name="Empnum"></param>
        /// <param name="emppk"></param>
        /// <param name="applicationstring"></param>
        /// <param name="applicationid"></param>
        public EmployeeShiftFormcs(String Empnum, int emppk, String applicationstring, int applicationid)
        {
            InitializeComponent();
            shfttransaction = new Transactions.ShiftTransactionNewform();
            empregtrans = new Transactions.EmployeeRegTransaction();
            cmb_EmpCode.Text = Empnum;
            lbl_emppk.Text = emppk.ToString();
            applicationType = applicationstring;
            if (applicationstring != "Shift Change")
            {
                btn_Skip.Enabled = true;
                shiftcomboload("Start");

            }
            else
            {

                changeappid = applicationid;

             

                shiftcomboload("Change");
            }
       


        }
        /// <summary>
        /// loads the employee detail of a location
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";


            lbl_emppk.Text = cmb_EmpCode.SelectedValue.ToString();
        }
/// <summary>
/// validates the fornm 
/// </summary>
/// <returns></returns>
        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the EmployeeCode ";
                cmb_EmpCode.Focus();


            }

            else if (Cmb_shift.Text == null || Cmb_shift.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Shift Applicable ";
                Cmb_shift.Focus();
            }


            else
            {
                sucess = true;
            }
            return sucess;
        }


        /// <summary>
        /// LOAD ALL THE SHIFT DATA
        /// </summary>
        public void shiftcomboload(String type)
        {
            DataTable dt = shfttransaction.getAllShiftName ();

            Cmb_shift.DataSource = dt;
            Cmb_shift.DisplayMember = "ShiftName";
            Cmb_shift.ValueMember = "ShiftPK";

            if (type == "Change")
            {
                int toshift = empregtrans.getanShiftChangeapplication(changeappid);
                Cmb_shift.SelectedValue = toshift;
                Cmb_shift.Enabled = false;
                lbl_shiftPK.Text = toshift.ToString();
            }
            else
            {
                lbl_shiftPK.Text = Cmb_shift.SelectedValue.ToString();
            }

        }

        private void EmployeeShiftFormcs_Load(object sender, EventArgs e)
        {
           
        }

        private void Cmb_shift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag != 0)
            {
                DataTable dt = shfttransaction.getsShiftByPK(int.Parse(Cmb_shift.SelectedValue.ToString()));
                fillothercontrols(dt);
                lbl_shiftPK.Text = Cmb_shift.SelectedValue.ToString();
            }
        }




        public void fillothercontrols(DataTable dt)
        {
            if (dt.Rows.Count != 0)
            {

                for (int i = 0; i < 7; i++)
                {

                    if (dt.Rows[i][1].ToString() == "Monday")
                    {
                        dtpIn_Monday.Value=DateTime.Parse (dt.Rows[i][3].ToString ());
                           dtp_Monday.Value=DateTime.Parse (dt.Rows[i][4].ToString ());
                           cmbDayType_Monday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString().Trim () == "Tuesday")
                    {
                        dtpIn_Tuesday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Tuesday  .Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Tuesday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString() == "Wednesday")
                    {
                        dtpIn_Wednesday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Wednesday .Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Wednesday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString() == "Thursday")
                    {
                        dtpIn_Thursday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Thursday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Thursday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString() == "Friday")
                    {
                        dtpIn_Friday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Friday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Friday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString() == "Saturday")
                    {
                        dtpIn_Saturday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Saturday .Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Saturday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString() == "Sunday")
                    {
                        dtpIn_Sunday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Sunday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Sunday.Text = dt.Rows[i][2].ToString();

                        
                    }

                }

            }
        }

        private void Cmb_shift_MouseClick(object sender, MouseEventArgs e)
        {
            flag++;
        }

        private void btn_submmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (validationcontrol())
                {
                    if (changeappid == 0)
                    {
                        shftdatbean = new Datalayer.EmployeeShiftDatabean();
                        shftdatbean.Empid = int.Parse(lbl_emppk.Text);
                        shftdatbean.ShiftPk1 = int.Parse(Cmb_shift.SelectedValue.ToString());

                        shftdatbean.Effectivedate = dtp_fromdate.Value.Date;
                        empregtrans.insertEmpShiftDetails(shftdatbean);
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    }
                    else
                    {
                        shftdatbean = new Datalayer.EmployeeShiftDatabean();
                        shftdatbean.Empid = int.Parse(lbl_emppk.Text);
                        shftdatbean.ShiftPk1 = int.Parse(Cmb_shift.SelectedValue.ToString());
                        shftdatbean.Effectivedate = dtp_fromdate.Value.Date;
                        empregtrans.updateshift(shftdatbean, changeappid);
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                        this.Close();
                    }

                }
            }
            catch (Exception exp)
            {
                
                   if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
            }


            ErrorLogger er = new ErrorLogger();
            er.createErrorLog(exp);
           //  ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
            this.Dispose();
            }
        }

        private void btn_Skip_Click(object sender, EventArgs e)
        {
            Master.NewFolder1.LeaveForm lvfrm = new Master.NewFolder1.LeaveForm(cmb_EmpCode.Text, int.Parse(lbl_emppk.Text), applicationType, changeshiftid);
            lvfrm.MdiParent = this.MdiParent;
            lvfrm.Show();
            this.Close();
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_emppk.Text = cmb_EmpCode.SelectedValue.ToString();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void Cmb_shift_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = shfttransaction.getsShiftByPK(int.Parse(Cmb_shift.SelectedValue.ToString()));
                fillothercontrols(dt);
                lbl_shiftPK.Text = Cmb_shift.SelectedValue.ToString();

            }
            catch (Exception)
            {
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
         Master.NewFolder1 .   LeaveForm lvfrm = new  Master.NewFolder1 .   LeaveForm (cmb_EmpCode .Text, int.Parse(lbl_emppk.Text));
            lvfrm.Show();
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

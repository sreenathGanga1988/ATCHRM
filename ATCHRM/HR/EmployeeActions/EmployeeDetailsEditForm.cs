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
    public partial class EmployeeDetailsEditForm : Form
    {
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.Approvalview.shiftchangeview cntrctapprview = null;
        Datalayer.EmployeeShiftDatabean shftdatbean = null;
        int empflag = 0;
        public EmployeeDetailsEditForm()
        {
            InitializeComponent();
            empregtrans = new Transactions.EmployeeRegTransaction();
            dsgtrans = new Transactions.DesignationTransaction();
            employecodeload(Program.LOCTNPK, 0, 0);
            cntrctapprview = new Transactions.Approvalview.shiftchangeview();
        }


      



        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empflag != 0)
            {
                if (cmb_EmpCode.Text != null || cmb_EmpCode.Text != "")
                {
                    
                        cmb_aaplicationnum.DataSource = null;
                        DataTable dt = dsgtrans.getAllApproveDApplication(int.Parse(cmb_EmpCode.SelectedValue.ToString()), cmb_applicationType.Text.Trim());

                        if (dt != null)
                        {
                            if (dt.Rows.Count != 0)
                            {
                                cmb_aaplicationnum.DataSource = dt;
                                cmb_aaplicationnum.DisplayMember = "Appnumber";
                                cmb_aaplicationnum.ValueMember = "AppPK";
                            }
                        }

                        
                    }
                }
           

        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            empflag++;
        }

        private void btn_Proceed_Click(object sender, EventArgs e)
        {
            if (cmb_aaplicationnum.Text.Trim() != "")
            {
                if (cmb_applicationType.Text.Trim() == "Designation Change")
                {

                    Master.NewFolder1.PositionForm pstnForm = null;
                    pstnForm = new Master.NewFolder1.PositionForm(int.Parse(cmb_EmpCode.SelectedValue.ToString()), cmb_applicationType.Text.Trim(), int.Parse(cmb_aaplicationnum.SelectedValue.ToString()));
                    pstnForm.MdiParent = this.MdiParent;
                    pstnForm.Show();

                }
                else if (cmb_applicationType.Text.Trim() == "Contract Change")
                {
                    Master.NewFolder1.ContractForm cntrctfrm = new Master.NewFolder1.ContractForm(int.Parse(cmb_EmpCode.SelectedValue.ToString()), int.Parse(cmb_aaplicationnum.SelectedValue.ToString()), 0, cmb_applicationType.Text.Trim());
                    cntrctfrm.MdiParent = this.MdiParent;
                    cntrctfrm.Show();
                }

                else if (cmb_applicationType.Text.Trim() == "Leave Application Change")
                {
                    Applications.LeaveConfirmForm lvconfirmfrm = new Applications.LeaveConfirmForm(int.Parse(cmb_aaplicationnum.SelectedValue.ToString()));
                    lvconfirmfrm.MdiParent = this.MdiParent;
                    lvconfirmfrm.Show();
                }

            }
            else
            {
                if (cmb_applicationType.Text.Trim() == "Shift Change")
                {

                    Approvals.DateForm dataform = new Approvals.DateForm();
                    dataform.ShowDialog();
                    DateTime  effectivedate ;


                    try
                    {
                        effectivedate = DateTime .Parse(dataform.UserSelectedDate.ToString ()).Date ;
                    }
                    catch (Exception)
                    {

                        effectivedate = DateTime.Now.Date;
                    }

                    for (int i = 0; i < tbl_data.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(tbl_data.Rows[i].Cells[0].Value) == true)
                        {
                            //int empid = 0;
                            int appnum = 0;
                            //String empcode = "";
                            //int toshiftpk = 0;
                            //int userpk = 0;
                            appnum = int.Parse(tbl_data.Rows[i].Cells[1].Value.ToString());


                           

                            shftdatbean = new Datalayer.EmployeeShiftDatabean();
                            shftdatbean.Empid = int.Parse(tbl_data.Rows[i].Cells[3].Value.ToString());
                            shftdatbean.ShiftPk1 = int.Parse(tbl_data.Rows[i].Cells[9].Value.ToString());
                            shftdatbean.Effectivedate = effectivedate;


                            empregtrans.updateshift(shftdatbean, appnum);
                          //  empid = int.Parse(tbl_data.Rows[i].Cells[3].Value.ToString());
                   
                          //  empcode = tbl_data.Rows[i].Cells[4].Value.ToString();
                            //toshiftpk = int.Parse(tbl_data.Rows[i].Cells[9].Value.ToString());
                            //userpk = Program.USERPK;
                            
                          //  HR.NewFolder1.EmployeeShiftFormcs shftfrm = new HR.NewFolder1.EmployeeShiftFormcs(empcode, empid, cmb_applicationType.Text, appnum);
                          //// shftfrm.MdiParent = this.MdiParent;
                          //  shftfrm.ShowDialog ();
                        }
                    }
                    loadshiftchange();
                }

            }
            }

        private void cmb_applicationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_applicationType.Text.Trim() == "Shift Change")
            {
                cmb_EmpCode.Enabled = false;
                cmb_aaplicationnum.Enabled = false;
                loadshiftchange();
            }
            else
            {
                cmb_EmpCode.Enabled = true;
                cmb_aaplicationnum.Enabled = true;
                tbl_data.DataSource = null;
            }
        }

        private void EmployeeDetailsEditForm_Load(object sender, EventArgs e)
        {

        }


        public void loadshiftchange()
        {
            tbl_data.DataSource = null;
            DataTable dt = cntrctapprview.getallshiftchangeapplicationapproved ();
            tbl_data.DataSource = dt;


        }

        private void tbl_data_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_data .IsCurrentCellDirty)
            {
                tbl_data.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }






        


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace ATCHRM
{


    public partial class MainForm : Form
    {
        Timer timer1 = new Timer();
        public delegate void ScrollTextboxCallback(string t);
       
          

        Transactions.NotificationTransaction nftrans = null;
        DataTable pendingdata = null;
        public MainForm(int i)
        {
            InitializeComponent();
        }
        public MainForm()
        {
            try
            {

                nftrans = new Transactions.NotificationTransaction();
                InitializeComponent();
                loginmain();

                this.IsMdiContainer = true;
                intialsetupform();
                lblUsername.Text = Program.UserName;
                lbl_date.Text = Program.Datetoday.ToString("dd/MM/yyyy");
                lbl_loc.Text = Program.LOCATIONCODE;
                lbl_server.Text = "Connected to " +Program.Server.ToString();
                nftrans = new Transactions.NotificationTransaction();
                lbl_Logintype.Text = Program.Logintype;
                timersetting();
            }
            catch (Exception exp)
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.ToString());
    
            }
      
        }            
      

       public void loginmain()
        { 
            //LoginForm loginform = new LoginForm();
            //loginform.StartPosition = FormStartPosition.CenterScreen;
          //  loginform.ShowDialog();
            if (Program.Logintype != "Remote")
            {
                getitems();
            }
        }
   
        
        # region intial setup
       public void intialsetupform()
       {
           this.WindowState = FormWindowState.Maximized;

       }

       private static Boolean Get_Menu(int userid, string fnam)
       {
           Boolean frmnam = false;
           DataSet ds = GridViewmModels.ClsDatabase.Get_Data("select access_right from User_Rights where "
           +" user_id=(select empid from usermaster_tbl where userpk= " + userid + ") and form_name='" + fnam + "'");
           if (ds.Tables[0].Rows.Count > 0)
           {
             frmnam = true;
           }
           return frmnam;
       }

       public void GetMenuItems(ToolStripMenuItem item)
    {
        int id = Program.USERPK;
        GridViewmModels.ClsDatabase.Set_Data("delete from Message_Alert where user_id=" + id + "");
        foreach (ToolStripItem i in item.DropDownItems)
        {
            if (i is ToolStripMenuItem)
            {
                
                if (Get_Menu(id, i.Text) == true)
                {
                    i.Visible = true;
                    if ((i.Text == "level1ToolStripMenuItem") || (i.Text == "level2ToolStripMenuItem") || (i.Text == "level3ToolStripMenuItem") || (i.Text == "lHLevel1ToolStripMenuItem") || (i.Text == "lHLevel2ToolStripMenuItem") || (i.Text == "lHLevel3ToolStripMenuItem") || (i.Text == "actionApproval1ToolStripMenuItem") || (i.Text == "actionApproval2ToolStripMenuItem") || (i.Text == "actionApproval3ToolStripMenuItem"))
                    {
                        GridViewmModels.ClsDatabase.Set_Data("insert into Message_Alert (Menu_Name,User_Id) values('" + i.Text + "'," + id + ")");
                    }
                }
                else
                {
                    i.Visible = false;
                }
                GetMenuItems((ToolStripMenuItem)i);

            }
        }
    }
       
        public   void getitems()

        {
            foreach (ToolStripMenuItem i in menuStrip1.Items)
            {
                GetMenuItems(i);
            }
    }
       public static Form IsFormAlreadyOpen(Type FormType)
       {
           foreach (Form OpenForm in Application.OpenForms)
           {
               if (OpenForm.GetType() == FormType)
                   return OpenForm;
           }

           return null;
       }

  private bool IsAlreadyOpen(Type formType)

{

    bool isOpen = false;

 

    foreach (Form f in Application.OpenForms)

    {

        if (f.GetType() == formType)

        {

            f.BringToFront();

            f.WindowState = FormWindowState.Normal;

            isOpen = true;

        }

    }


    return isOpen;

}

  

     
#endregion

        

        # region functionregion
        public void employeeappeditformopen()
        {
            HR.NewFolder1.EmployeeDetailsEditForm empdteditfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.EmployeeDetailsEditForm));
            if (isFormOpen == false)
            {
                empdteditfrm = new HR.NewFolder1.EmployeeDetailsEditForm();
                empdteditfrm.MdiParent = this;
                empdteditfrm.StartPosition = FormStartPosition.CenterScreen;
                empdteditfrm.Show();
            }
        }
        public void addnewemployeeformOpen()
        {
            HR.NewFolder1.EmployeContactEntryForm empreg = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.EmployeContactEntryForm));
            if (isFormOpen == false)
            {
                empreg = new HR.NewFolder1.EmployeContactEntryForm();
                empreg.MdiParent = this;
                empreg.StartPosition = FormStartPosition.CenterScreen;
                empreg.Show();
            }
        }
        public void leaveapplicationopen()
        {
            Applications.FrmLeave lvappfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.LeaveApplicationForm));
            if (isFormOpen == false)
            {
                lvappfrm = new Applications.FrmLeave();
                lvappfrm.MdiParent = this;
                lvappfrm.StartPosition = FormStartPosition.CenterScreen;
                lvappfrm.Show();
            }

        }


        public void Leaveencashment()
        {
            Applications.LeaveEncashmentMaster lvenfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.LeaveEncashmentMaster));
            if (isFormOpen == false)
            {
                lvenfrm = new Applications.LeaveEncashmentMaster();
                lvenfrm.MdiParent = this;
                lvenfrm.StartPosition = FormStartPosition.CenterScreen;
                lvenfrm.Show();
            }

        }





        /// <summary>
        /// get the recruitment form
        /// </summary>

        public void recruitmentApplicationopen()
        {
            Applications.FrmRecruit rcrtmaster = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.FrmRecruit));
            if (isFormOpen == false)
            {
                rcrtmaster = new Applications.FrmRecruit();
                rcrtmaster.MdiParent = this;
                rcrtmaster.StartPosition = FormStartPosition.CenterScreen;
                rcrtmaster.Show();
            }
        }


        /// <summary>
        /// get the recruitment form
        /// </summary>

        public void newrecruitment()
        {
            Applications.RecruitmentApplicationForm rcrtmaster = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.RecruitmentApplicationForm));
            if (isFormOpen == false)
            {
                rcrtmaster = new Applications.RecruitmentApplicationForm();
                rcrtmaster.MdiParent = this;
                rcrtmaster.StartPosition = FormStartPosition.CenterScreen;
                rcrtmaster.Show();
            }
        }

        /// <summary>
        /// lhr approval level starts here
        /// </summary>
        /// <param name="n"></param>

        public void lhrapprovalformopen(int n)
        {

            Approvals.LHRApproval lvlform1 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.LHRApproval));
            if (isFormOpen == false)
            {
                lvlform1 = new Approvals.LHRApproval(n);
                lvlform1.MdiParent = this;
                lvlform1.StartPosition = FormStartPosition.CenterScreen;
                lvlform1.Show();
            }





        }

        /// <summary>
        /// open the biodata form to add new biodata or to view new biodata
        /// if n=0; add
        /// else view
        /// /// </summary>
        /// <param name="n"></param>
        public void biodataformopen(int n)
        {

            if (n == 0)
            {
                HR.BiodataForm biodatafrm = null;
                bool isFormOpen = IsAlreadyOpen(typeof(HR.BiodataForm));
                if (isFormOpen == false)
                {
                    biodatafrm = new HR.BiodataForm();
                    biodatafrm.MdiParent = this;
                    biodatafrm.StartPosition = FormStartPosition.CenterScreen;
                    biodatafrm.Show();
                }

            }
            else
            {
                HR.BiodataForm biodatafrm = null;
                bool isFormOpen = IsAlreadyOpen(typeof(HR.BiodataForm));
                if (isFormOpen == false)
                {
                    biodatafrm = new HR.BiodataForm(1);
                    biodatafrm.MdiParent = this;
                    biodatafrm.StartPosition = FormStartPosition.CenterScreen;
                    biodatafrm.Show();
                }


            }
        }

        /// <summary>
        /// action approval for all levels of approval
        /// </summary>
        /// <param name="n"></param>
        public void actionapprovallevelopen(int n)
        {

            Action.ActionApprovalLevel1 actnapprvlfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Action.ActionApprovalLevel1));
            if (isFormOpen == false)
            {
                actnapprvlfrm = new Action.ActionApprovalLevel1(n);
                actnapprvlfrm.MdiParent = this;
                actnapprvlfrm.StartPosition = FormStartPosition.CenterScreen;
                actnapprvlfrm.Show();
            }

        }


        /// <summary>
        /// get the gatepass formn
        /// </summary>

        public void gatepassformopen()
        {
            Applications.GatePassForm gatepssfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.GatePassForm));
            if (isFormOpen == false)
            {
                gatepssfrm = new Applications.GatePassForm();
                gatepssfrm.MdiParent = this;
                gatepssfrm.StartPosition = FormStartPosition.CenterScreen;
                gatepssfrm.Show();
            }


        }


        /// <summary>
        /// employeedetail
        /// </summary>
        public void employeedetailopen()
        {



            Master.NewFolder1.EmployeeMainform empdteditfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.NewFolder1.EmployeeMainform));
            if (isFormOpen == false)
            {
                empdteditfrm = new Master.NewFolder1.EmployeeMainform();
                empdteditfrm.MdiParent = this;
                empdteditfrm.StartPosition = FormStartPosition.CenterScreen;
                empdteditfrm.Show();
            }

        }


        public void SHOWOLD()
        {

            HR.NewFolder1.EmployeeMasterForm empmasterform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.EmployeeMasterForm));
            if (isFormOpen == false)
            {
                empmasterform = new HR.NewFolder1.EmployeeMasterForm();
                empmasterform.MdiParent = this;
                empmasterform.StartPosition = FormStartPosition.CenterScreen;
                empmasterform.Show();
            }

        }

        public void designationchangformOpen()
        {
            Applications.DesignationChangeApplication dsgchangeapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.DesignationChangeApplication));
            if (isFormOpen == false)
            {
                dsgchangeapp = new Applications.DesignationChangeApplication();
                dsgchangeapp.MdiParent = this;
                dsgchangeapp.StartPosition = FormStartPosition.CenterScreen;
                dsgchangeapp.Show();
            }
        }


        public void advanceapplicaionopen()
        {
            Applications.AdvanceMasterForm advanceform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.AdvanceMasterForm));
            if (isFormOpen == false)
            {
                advanceform = new Applications.AdvanceMasterForm();

                advanceform.MdiParent = this;
                advanceform.StartPosition = FormStartPosition.CenterScreen;
                advanceform.Show();
            }
        }
        public void otapplicationopen()
        {
            Applications.FrmOtShow frmot = null;

            bool isFormOpen = IsAlreadyOpen(typeof(Applications.FrmOtShow));
            if (isFormOpen == false)
            {
                frmot = new Applications.FrmOtShow(); ;
                frmot.MdiParent = this;
                frmot.StartPosition = FormStartPosition.CenterScreen;
                frmot.Show();
            }



        }

        public void actionformopen()
        {
            Action.ActionMasterForm actnfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Action.ActionMasterForm));
            if (isFormOpen == false)
            {
                actnfrm = new Action.ActionMasterForm();
                actnfrm.MdiParent = this;
                actnfrm.StartPosition = FormStartPosition.CenterScreen;
                actnfrm.Show();
            }


        }
        public void contractreneewalappopen()
        {
            Applications.ContractRenewalForm cntrctrnwl = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.ContractRenewalForm));
            if (isFormOpen == false)
            {
                cntrctrnwl = new Applications.ContractRenewalForm();
                cntrctrnwl.MdiParent = this;
                cntrctrnwl.StartPosition = FormStartPosition.CenterScreen;
                cntrctrnwl.Show();
            }
        }

        public void shiftchangeappopen()
        {
            Applications.ShiftChangeApplication shftchangeapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.ShiftChangeApplication));
            if (isFormOpen == false)
            {
                shftchangeapp = new Applications.ShiftChangeApplication();
                shftchangeapp.MdiParent = this;
                shftchangeapp.StartPosition = FormStartPosition.CenterScreen;
                shftchangeapp.Show();
            }
        }

        public void groupshiftchangeopen()
        {
            Applications.GroupshiftchangeForm shftchangeapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.GroupshiftchangeForm));
            if (isFormOpen == false)
            {
                shftchangeapp = new Applications.GroupshiftchangeForm();
                shftchangeapp.MdiParent = this;
                shftchangeapp.StartPosition = FormStartPosition.CenterScreen;
                shftchangeapp.Show();
            }
        }





        public void DeactivationApproval(int n)
        {

            Approvals.EmployeeDeactivationApproval lvlform1 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.EmployeeDeactivationApproval));
            if (isFormOpen == false)
            {
                lvlform1 = new Approvals.EmployeeDeactivationApproval(n);
                lvlform1.MdiParent = this;
                lvlform1.StartPosition = FormStartPosition.CenterScreen;
                lvlform1.Show();
            }

        }

        public void designationchange()
        {
            Applications.DesignationChangeMaster dsgchangeapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.DesignationChangeMaster));
            if (isFormOpen == false)
            {
                dsgchangeapp = new Applications.DesignationChangeMaster();
                dsgchangeapp.MdiParent = this;
                dsgchangeapp.StartPosition = FormStartPosition.CenterScreen;
                dsgchangeapp.Show();
            }
        }



        public void contractchange()
        {// contractreneewalappopen();
            Applications.ContractRenewalMaster cntrctrnwl = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.ContractRenewalMaster));
            if (isFormOpen == false)
            {
                cntrctrnwl = new Applications.ContractRenewalMaster();
                cntrctrnwl.MdiParent = this;
                cntrctrnwl.StartPosition = FormStartPosition.CenterScreen;
                cntrctrnwl.Show();
            }
        }

        public void shiftchange()
        {
            Applications.ShiftChangeMaster shftchangeapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.ShiftChangeMaster));
            if (isFormOpen == false)
            {
                shftchangeapp = new Applications.ShiftChangeMaster();
                shftchangeapp.MdiParent = this;
                shftchangeapp.StartPosition = FormStartPosition.CenterScreen;
                shftchangeapp.Show();
            }
        }

        public void employeedeactivate()
        {
            HR.NewFolder1.EmployeeDeactivationForm empdeactform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.EmployeeDeactivationForm));
            if (isFormOpen == false)
            {
                empdeactform = new HR.NewFolder1.EmployeeDeactivationForm();
                empdeactform.MdiParent = this;
                empdeactform.StartPosition = FormStartPosition.CenterScreen;
                empdeactform.Show();
            }

        }

        public void WarningFormOpen()
        {

            Applications.WarningMasterForm cnfrm = new Applications.WarningMasterForm();
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.WarningMasterForm));
            if (isFormOpen == false)
            {
                cnfrm = new Applications.WarningMasterForm();
                cnfrm.MdiParent = this;
                cnfrm.StartPosition = FormStartPosition.CenterScreen;
                cnfrm.Show();
            }

        }



        public void WarningFormOpen12(String warningtype)
        {

            Applications.VerbalWarning cnfrm = new Applications.VerbalWarning();
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.VerbalWarning));
            if (isFormOpen == false)
            {
                cnfrm = new Applications.VerbalWarning(warningtype);
                cnfrm.MdiParent = this;
                cnfrm.StartPosition = FormStartPosition.CenterScreen;
                cnfrm.Show();
            }

        }


        public void AppreciationApproval(int levelnum)
        {

            Approvals.AppreciatioandWarningcs cnfrm = new Approvals.AppreciatioandWarningcs();
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.AppreciatioandWarningcs));
            if (isFormOpen == false)
            {
                cnfrm = new Approvals.AppreciatioandWarningcs(levelnum);
                cnfrm.MdiParent = this;
                cnfrm.StartPosition = FormStartPosition.CenterScreen;
                cnfrm.Show();
            }

        }


        public void WarningApproval(int levelnum)
        {

            Approvals.WarningApproval cnfrm = new Approvals.WarningApproval();
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.WarningApproval));
            if (isFormOpen == false)
            {
                cnfrm = new Approvals.WarningApproval(levelnum);
                cnfrm.MdiParent = this;
                cnfrm.StartPosition = FormStartPosition.CenterScreen;
                cnfrm.Show();
            }

        }

        # endregion


        # region Click event







        private void workLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.WorkLimitForm wrklimitfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.WorkLimitForm));
            if (isFormOpen == false)
            {
                wrklimitfrm = new Master.WorkLimitForm();

                wrklimitfrm.MdiParent = this;
                wrklimitfrm.StartPosition = FormStartPosition.CenterScreen;
                wrklimitfrm.Show();
            }
        }

        private void companyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.CompanyMasterForm cmpnymasterform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.CompanyMasterForm));
            if (isFormOpen == false)
            {
                cmpnymasterform = new Master.CompanyMasterForm();
                cmpnymasterform.StartPosition = FormStartPosition.CenterScreen;

                cmpnymasterform.MdiParent = this;
                cmpnymasterform.Show();
            }
        }

        private void branchesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.BranchMasterForm branchmasterform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.BranchMasterForm));
            if (isFormOpen == false)
            {
                branchmasterform = new Master.BranchMasterForm();
                branchmasterform.MdiParent = this;
                branchmasterform.StartPosition = FormStartPosition.CenterScreen;
                branchmasterform.Show();
            }

        }

        private void shiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.ShiftMasterFormDetails shftform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.ShiftMasterFormDetails));
            if (isFormOpen == false)
            {
                shftform = new Master.ShiftMasterFormDetails();
                shftform.MdiParent = this;
                shftform.StartPosition = FormStartPosition.CenterScreen;
                shftform.Show();
            }
        }

        private void offDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Master.HolidayCalendarForm hldycalfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.HolidayCalendarForm));
            if (isFormOpen == false)
            {
                hldycalfrm = new Master.HolidayCalendarForm();
                hldycalfrm.MdiParent = this;
                hldycalfrm.StartPosition = FormStartPosition.CenterScreen;
                hldycalfrm.Show();
            }
        }

        private void designationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.DesignationMasterForm dsgmasterform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.DesignationMasterForm));
            if (isFormOpen == false)
            {
                dsgmasterform = new Master.DesignationMasterForm();
                dsgmasterform.MdiParent = this;
                dsgmasterform.StartPosition = FormStartPosition.CenterScreen;
                dsgmasterform.Show();
            }
        }

        private void salaryComponentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.SalaryComponentMaster salcompmaster = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.SalaryComponentMaster));
            if (isFormOpen == false)
            {
                salcompmaster = new Master.SalaryComponentMaster();
                salcompmaster.MdiParent = this;
                salcompmaster.StartPosition = FormStartPosition.CenterScreen;
                salcompmaster.Show();
            }
        }

        private void banksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.BankMasterForm bnkmstrfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.BankMasterForm));
            if (isFormOpen == false)
            {

                bnkmstrfrm = new Master.BankMasterForm();
                bnkmstrfrm.MdiParent = this;
                bnkmstrfrm.StartPosition = FormStartPosition.CenterScreen;
                bnkmstrfrm.Show();
            }

        }

        private void leavesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Master.LeaveForm leaveform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.LeaveForm));
            if (isFormOpen == false)
            {
                leaveform = new Master.LeaveForm();
                leaveform.MdiParent = this;
                leaveform.StartPosition = FormStartPosition.CenterScreen;
                leaveform.Show();
            }
        }

        private void presentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.DailyCloseregister dailymasterfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.DailyCloseregister));
            if (isFormOpen == false)
            {
                dailymasterfrm = new Attendance.DailyCloseregister();
                dailymasterfrm.MdiParent = this;
                dailymasterfrm.StartPosition = FormStartPosition.CenterScreen;
                dailymasterfrm.Show();
            }
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SHOWOLD();
        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeedetailopen();
        }

        private void userRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.UserRightForm man = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.UserRightForm));
            if (isFormOpen == false)
            {
                man = new Master.UserRightForm();
                man.MdiParent = this.MdiParent;
                man.StartPosition = FormStartPosition.CenterScreen;
                man.Show();
            }
        }

        private void oTApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ApplicationReportForm apprptfrm = new Reports.ApplicationReportForm();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.ApplicationReportForm));
            if (isFormOpen == false)
            {
                apprptfrm = new Reports.ApplicationReportForm();
                apprptfrm.MdiParent = this;
                apprptfrm.StartPosition = FormStartPosition.CenterScreen;
                apprptfrm.Show();
            }
        }

        private void try2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    Action.tryform tryfrm = new Action.tryform();
            //tryfrm.Show();
            //HR.NewFolder1.EmployeeShiftFormcs empshft = new HR.NewFolder1.EmployeeShiftFormcs();
            //empshft.Show();

            //Master.ShiftDetailsMasterForm shftdetails = new Master.ShiftDetailsMasterForm();
            //shftdetails.Show();
        }

        private void actionApproval2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionapprovallevelopen(2);

        }

        private void actionApproval3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionapprovallevelopen(3);

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "MainForm")
                    Application.OpenForms[i].Close();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // Use this since we are a WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Use this since we are a console app

                System.Environment.Exit(1);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void lHLevel1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lhrapprovalformopen(1);
        }

        private void lHLevel2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lhrapprovalformopen(2);
        }

        private void lHLevel3ToolStripMenuItem_Click(object sender, EventArgs e)
        {



            lhrapprovalformopen(3);
        }

        private void employeeInOutExceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.EmpInoutExceptionfrm inoutfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.EmpInoutExceptionfrm));
            if (isFormOpen == false)
            {
                inoutfrm = new Attendance.EmpInoutExceptionfrm();
                inoutfrm.MdiParent = this;
                inoutfrm.StartPosition = FormStartPosition.CenterScreen;
                inoutfrm.Show();
            }
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Aquamarine;
        }



        private void try3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Action.tryform tryfrm = new Action.tryform();
            tryfrm.Show();
        }

        private void hrToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
            //  this.Close();
        }

        private void adjusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.EmpInoutExceptionfrm frm = new Attendance.EmpInoutExceptionfrm();
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.EmpInoutExceptionfrm));

            if (isFormOpen == false)
            {
                frm = new Attendance.EmpInoutExceptionfrm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }









        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                Form activeChild = this.ActiveMdiChild;

                if (activeChild != null)
                {
                    activeChild.Close();
                }
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void wrkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Master.WorkLimitForm wrklimitfrm = null;
            //bool isFormOpen = IsAlreadyOpen(typeof(Master.WorkLimitForm));
            //if (isFormOpen == false)
            //{
            //    wrklimitfrm = new Master.WorkLimitForm();

            //    wrklimitfrm.MdiParent = this;
            //    wrklimitfrm.StartPosition = FormStartPosition.CenterScreen;
            //    wrklimitfrm.Show();
            //}



         
        }

        private void leaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           

        }

        private void try3ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Master.NewFolder1.ContractForm cntrctfrm = new Master.NewFolder1.ContractForm();
            cntrctfrm.Show();
        }

        private void departmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.LevelApprovalForm_1 lvlform1 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.LevelApprovalForm_1));
            if (isFormOpen == false)
            {
                lvlform1 = new Approvals.LevelApprovalForm_1();
                lvlform1.MdiParent = this;
                lvlform1.StartPosition = FormStartPosition.CenterScreen;
                lvlform1.Show();
            }
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.LevelApprovalForm_2 lvlform2 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.LevelApprovalForm_2));
            if (isFormOpen == false)
            {
                lvlform2 = new Approvals.LevelApprovalForm_2();
                lvlform2.MdiParent = this;
                lvlform2.StartPosition = FormStartPosition.CenterScreen;
                lvlform2.Show();
            }
        }

        private void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.LevelApprovalForm_3 lvlform3 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.LevelApprovalForm_3));
            if (isFormOpen == false)
            {
                lvlform3 = new Approvals.LevelApprovalForm_3();
                lvlform3.MdiParent = this;
                lvlform3.StartPosition = FormStartPosition.CenterScreen;
                lvlform3.Show();
            }
        }

        private void actionApproval1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionapprovallevelopen(1);
        }

        private void actionApproval2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            actionapprovallevelopen(2);
        }

        private void actionApproval3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            actionapprovallevelopen(3);
        }

        private void try3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void actionManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionformopen();
        }

        private void correctionApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.CorrectionApprovalMaster lvlform2 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.CorrectionApprovalMaster));
            if (isFormOpen == false)
            {
                lvlform2 = new Approvals.CorrectionApprovalMaster();
                lvlform2.MdiParent = this;
                lvlform2.StartPosition = FormStartPosition.CenterScreen;
                lvlform2.Show();
            }
        }

        private void level1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Approvals.GatePassApprovalFormcs lvlform2 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.GatePassApprovalFormcs));
            if (isFormOpen == false)
            {
                lvlform2 = new Approvals.GatePassApprovalFormcs(1);
                lvlform2.MdiParent = this;
                lvlform2.StartPosition = FormStartPosition.CenterScreen;
                lvlform2.Show();
            }

        }

        private void gatePassLevel2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.GatePassApprovalFormcs lvlform2 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.GatePassApprovalFormcs));
            if (isFormOpen == false)
            {
                lvlform2 = new Approvals.GatePassApprovalFormcs(2);
                lvlform2.MdiParent = this;
                lvlform2.StartPosition = FormStartPosition.CenterScreen;
                lvlform2.Show();
            }
        }





        //private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        //{
        //    //StringFormat sf = new StringFormat();
        //    //sf.LineAlignment = StringAlignment.Center;
        //    //sf.Alignment = StringAlignment.Center;

        //    //using (e.Graphics)
        //    //{
        //    //    Font f = new Font("Arial", 9.0f);
        //    //    e.DrawBackground();
        //    //    e.DrawBorder();
        //    //    e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(10, 10));
        //    //}
        //}




        private void contractApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void payrollToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            Reports.FrmPayroll lvlform2 = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.FrmPayroll));
            if (isFormOpen == false)
            {
                lvlform2 = new Reports.FrmPayroll();
                lvlform2.MdiParent = this;
                lvlform2.StartPosition = FormStartPosition.CenterScreen;
                lvlform2.Show();
            }





        }

        private void swipeRulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.SwipeRulesForm swiperulesform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.SwipeRulesForm));
            if (isFormOpen == false)
            {
                swiperulesform = new Master.SwipeRulesForm();
                swiperulesform.MdiParent = this;
                swiperulesform.StartPosition = FormStartPosition.CenterScreen;
                swiperulesform.Show();
            }
        }

        private void formulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.FormulaEditorForm formulaeditor = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.FormulaEditorForm));
            if (isFormOpen == false)
            {
                formulaeditor = new Master.FormulaEditorForm();
                formulaeditor.MdiParent = this;
                formulaeditor.StartPosition = FormStartPosition.CenterScreen;
                formulaeditor.Show();
            }
        }

        private void recruitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recruitmentApplicationopen();
        }

        private void oTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            otapplicationopen();
        }

        private void lHRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Applications.FrmLHRStatus Lhrform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.FrmLHRStatus));
            if (isFormOpen == false)
            {
                Lhrform = new Applications.FrmLHRStatus();
                Lhrform.MdiParent = this;
                Lhrform.StartPosition = FormStartPosition.CenterScreen;
                Lhrform.Show();
            }
        }

        private void leaveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            leaveapplicationopen();
        }

        private void leaveEncashmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leaveencashment();
        }

        private void advanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            advanceapplicaionopen();
        }

        private void gatepassToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Applications.GatepassMaster gatepssfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.GatepassMaster));
            if (isFormOpen == false)
            {
                gatepssfrm = new Applications.GatepassMaster();
                gatepssfrm.MdiParent = this;
                gatepssfrm.StartPosition = FormStartPosition.CenterScreen;
                gatepssfrm.Show();
            }
        }

        private void attendanceViewerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void leavesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Attendance.EmployeeLeaveAndOFf leaveform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.EmployeeLeaveAndOFf));
            if (isFormOpen == false)
            {
                leaveform = new Attendance.EmployeeLeaveAndOFf();
                leaveform.MdiParent = this;
                leaveform.StartPosition = FormStartPosition.CenterScreen;
                leaveform.Show();
            }
        }

        private void processPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll.IndividualPayrollForm indvpayrllfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Payroll.IndividualPayrollForm));
            if (isFormOpen == false)
            {
                indvpayrllfrm = new Payroll.IndividualPayrollForm();
                indvpayrllfrm.MdiParent = this;
                indvpayrllfrm.StartPosition = FormStartPosition.CenterScreen;
                indvpayrllfrm.Show();
            }
        }

        private void salaryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Master.NewFolder1.SalaryForm salfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.NewFolder1.SalaryForm));
            if (isFormOpen == false)
            {
                salfrm = new Master.NewFolder1.SalaryForm(184);
                salfrm.StartPosition = FormStartPosition.CenterScreen;
                salfrm.MdiParent = this;

                salfrm.Show();
            }
        }

        private void appreciationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HR.AppreciationSubForm appreciationform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.AppreciationSubForm));
            if (isFormOpen == false)
            {
                appreciationform = new HR.AppreciationSubForm();
                appreciationform.MdiParent = this;
                appreciationform.StartPosition = FormStartPosition.CenterScreen;
                appreciationform.Show();
            }
        }

        private void employeeContractToolStripMenuItem_Click(object sender, EventArgs e)
        {

            HR.EmployyeDetialsShowForm showfrm = new HR.EmployyeDetialsShowForm();
            bool isFormOpen = IsAlreadyOpen(typeof(HR.EmployyeDetialsShowForm));
            if (isFormOpen == false)
            {
                showfrm = new HR.EmployyeDetialsShowForm();
                showfrm.MdiParent = this;
                showfrm.StartPosition = FormStartPosition.CenterScreen;
                showfrm.Show();
            }
        }

        private void employeeEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeeappeditformopen();
        }

        private void designationChangeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            designationchange();
        }

        private void contractPeriodToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            contractchange();
        }

        private void shiftChangeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            shiftchange();
        }

        private void deactivationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //employeedeactivate();


            Applications.FrmDeactivation frmgtpass = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.FrmDeactivation));
            if (isFormOpen == false)
            {
                frmgtpass = new Applications.FrmDeactivation();
                frmgtpass.MdiParent = this;
                frmgtpass.StartPosition = FormStartPosition.CenterScreen;
                frmgtpass.Show();
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            employeedetailopen();
        }


        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            biodataformopen(0);
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            biodataformopen(1);
        }

        private void closingPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Approvals.PayrollConfirmation 
            Approvals.PayrollConfirmation cnfrm = new Approvals.PayrollConfirmation();
            bool isFormOpen = IsAlreadyOpen(typeof(HR.EmployyeDetialsShowForm));
            if (isFormOpen == false)
            {
                cnfrm = new Approvals.PayrollConfirmation();
                cnfrm.MdiParent = this;
                cnfrm.StartPosition = FormStartPosition.CenterScreen;
                cnfrm.Show();
            }
        }

        private void recruitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           

          
 
        }

        private void factoryHRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeactivationApproval(1);
        }

        private void factoryGMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeactivationApproval(2);
        }

        private void fInanceControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeactivationApproval(3);
        }

        private void verbalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarningFormOpen12("Verbal");
        }

        private void writtenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarningFormOpen();
        }


        private void factoryHRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AppreciationApproval(1);
        }

        private void factoryGMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AppreciationApproval(2);
        }

        private void factoryHRToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            WarningApproval(1);
        }

        private void factoryGMToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            WarningApproval(2);
        }

        private void userNotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





        # endregion




        # region Quicklounch


        public void quicklounch(String Codeword)
        {

            if (Codeword.Trim() == "LAPP")
            {
                //leaveapplication form
                leaveapplicationopen();
            }
            else if (Codeword.Trim() == "AAPP")
            {
                //advance application form
                advanceapplicaionopen();
            }
            else if (Codeword.Trim() == "SAPP")
            {
                //shift change applicatiom
                shiftchangeappopen();
            }
            else if (Codeword.Trim() == "RAPP")
            {
                //recruitment apllication
                recruitmentApplicationopen();
            }
            else if (Codeword.Trim() == "DAPP")
            {
                //designation change
                designationchangformOpen();
            }
            else if (Codeword.Trim() == "CAPP")
            {
            }
            else if (Codeword.Trim() == "GAPP")
            {
                ///gatepass Application
                gatepassformopen();

            }
            else if (Codeword.Trim() == "ADE")
            {
                SHOWOLD();
            }
            else if (Codeword.Trim() == "ACTN")
            {
                //actionformopen
                actionformopen();
            }
            else if (Codeword.Trim() == "EMPD")
            {
                //emp details 
                employeedetailopen();
            }
            else if (Codeword.Trim() == "EED")
            {
                EmployeeEditFormShow();
            }
            else if (Codeword.Trim() == "OTAPP")
            {
                // ot application
                otapplicationopen();
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {


                quicklounch(textBox1.Text.Trim());

            }
        }

        # endregion


        # region Notificatin


        public void fillnotification()
        {

            // ...

            int pending = 0;
            if (Program.USERPK != 0)
            {
                String message = "";
                pendingdata = nftrans.getnotification();
                pending = pendingdata.Rows.Count;


                message = "You Have  " + pending + " Applications Pending For Approval";


                //    toolTip1.Show(message , this, panel3.Location);
                toolTip1.Show(message, this, 2000);
                 // showaPendingApplication(dt);

            }
        }




        public void timersetting()
        {
            timer1 = new Timer();
            timer1.Interval = 1000*60 ; //1000ms = 1sec
            //    timer1.Interval = 4000 ; //1000ms = 1sec
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }







        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
               // fillnotification();
                backgroundWorker1.RunWorkerAsync();
                
            }
            catch (Exception)
            {


            }
        }



        # endregion

        private void adjusterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Approvals.AdjusterApprovalRemoval adjstr = new Approvals.AdjusterApprovalRemoval();
            //bool isFormOpen = IsAlreadyOpen(typeof(Applications.FrmDeactivation));
            //if (isFormOpen == false)
            //{
            //    adjstr = new Approvals.AdjusterApprovalRemoval();
            //    adjstr.MdiParent = this;
            //    adjstr.StartPosition = FormStartPosition.CenterScreen;
            //    adjstr.Show();
            //}

        }

        private void empDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void systemAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrator.AdministraionForm admnform = new Administrator.AdministraionForm();
            admnform.Show();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void confirmApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeeappeditformopen();
        }

        private void contractRenewalToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void attendanceApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.AdjusterApprovalRemoval adjstr = new Approvals.AdjusterApprovalRemoval();
            bool isFormOpen = IsAlreadyOpen(typeof(Applications.FrmDeactivation));
            if (isFormOpen == false)
            {
                adjstr = new Approvals.AdjusterApprovalRemoval();
                adjstr.MdiParent = this;
                adjstr.StartPosition = FormStartPosition.CenterScreen;
                adjstr.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void aBCToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aBCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void leaveRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void otApplicationDeptwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.OtApplicationBriefForm  otrptform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.OtApplicationBriefForm));
            if (isFormOpen == false)
            {
                otrptform = new Reports.OtApplicationBriefForm();
                otrptform.MdiParent = this;
                otrptform.StartPosition = FormStartPosition.CenterScreen;
                otrptform.Show();
            }
        }

        private void yearlyContractRenewalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeEditFormShow();
        }









        public void EmployeeEditFormShow()
        {
            HR.EmployyeDetialsShowForm showfrm = new HR.EmployyeDetialsShowForm();
            bool isFormOpen = IsAlreadyOpen(typeof(HR.EmployyeDetialsShowForm));
            if (isFormOpen == false)
            {
                showfrm = new HR.EmployyeDetialsShowForm();
                showfrm.MdiParent = this;
                showfrm.StartPosition = FormStartPosition.CenterScreen;
                showfrm.Show();
            }
        }







        private void saklaryRevisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HR.NewFolder1.EmployeeSalaryDetailsEditForm showfrm = new HR.NewFolder1.EmployeeSalaryDetailsEditForm();
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.EmployeeSalaryDetailsEditForm));
            if (isFormOpen == false)
            {
                showfrm = new HR.NewFolder1.EmployeeSalaryDetailsEditForm();
                showfrm.MdiParent = this;
                showfrm.StartPosition = FormStartPosition.CenterScreen;
                showfrm.Show();
            }
        }

        private void perksToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Master .PerkForm showfrm = new  Master .PerkForm();
             bool isFormOpen = IsAlreadyOpen(typeof(Master.PerkForm));
            if (isFormOpen == false)
            {
                showfrm = new Master.PerkForm();
                showfrm.MdiParent = this;
                showfrm.StartPosition = FormStartPosition.CenterScreen;
                showfrm.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime result;
            if (DateTime.TryParse("31/1/2010", System.Globalization.CultureInfo.GetCultureInfo("en-gb"),
                System.Globalization.DateTimeStyles.None, out result))
                this.Text = "ATCHRM-Ver :" + Application.ProductVersion.ToString() ;
            //  MessageBox.Show( Application.ProductVersion.ToString ());
            else
                MessageBox.Show("DateTime Not in Correct format Please Adjust");

            Administrator.NotificationForm  frm = new Administrator.NotificationForm();

            frm.ShowDialog();
        }

        private void employeeDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports.EmployeeSalaryComponent showfrm = new Reports.EmployeeSalaryComponent();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.EmployeeSalaryComponent));
            if (isFormOpen == false)
            {
                showfrm = new Reports.EmployeeSalaryComponent();
                showfrm.MdiParent = this;
                showfrm.StartPosition = FormStartPosition.CenterScreen;
                showfrm.Show();
            }
        }

        private void employeeLocationToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void attToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Action.AttendanceManagerForm attendancemngr = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Action.AttendanceManagerForm));
            if (isFormOpen == false)
            {
                attendancemngr = new Action.AttendanceManagerForm();
                attendancemngr.MdiParent = this;
                attendancemngr.StartPosition = FormStartPosition.CenterScreen;

                attendancemngr.Show();
            }
        }

        private void employeePerkToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void contractEndingEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void qualificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.QualificationMasterForm shftform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.QualificationMasterForm));
            if (isFormOpen == false)
            {
                shftform = new Master.QualificationMasterForm();
                shftform.MdiParent = this;
                shftform.StartPosition = FormStartPosition.CenterScreen;
                shftform.Show();
            }
        }

        private void leaveAbscentRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.EmployeeLeaveAndOFf leaveform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.EmployeeLeaveAndOFf));
            if (isFormOpen == false)
            {
                leaveform = new Attendance.EmployeeLeaveAndOFf();
                leaveform.MdiParent = this;
                leaveform.StartPosition = FormStartPosition.CenterScreen;
                leaveform.Show();
            }
        }

        private void leaveRegisterOfAnEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Reports .LeaveMasterOfEmployee lvmaster = null;
           bool isFormOpen = IsAlreadyOpen(typeof(Reports.LeaveMasterOfEmployee));
            if (isFormOpen == false)
            {
                lvmaster = new Reports.LeaveMasterOfEmployee();
                lvmaster.MdiParent = this;
                lvmaster.StartPosition = FormStartPosition.CenterScreen;
                lvmaster.Show();
            }
        }

        private void dateRangeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.DateRangeReports lvmaster = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.DateRangeReports));
            if (isFormOpen == false)
            {
                lvmaster = new Reports.DateRangeReports();
                lvmaster.MdiParent = this;
                lvmaster.StartPosition = FormStartPosition.CenterScreen;
                lvmaster.Show();
            }
        }

        private void employeeBankDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void leaveApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void oTSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.OtApplicationBriefForm otrptform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.OtApplicationBriefForm));
            if (isFormOpen == false)
            {
                otrptform = new Reports.OtApplicationBriefForm("OTSummary");
                otrptform.MdiParent = this;
                this.Text = "OT Summary";
                otrptform.StartPosition = FormStartPosition.CenterScreen;
                otrptform.Show();
            }
        }

        private void statusSwipeDailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void statusAfterAdjusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusBeforeAdjusterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {

        }

        private void dateRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void betweenAPeriodReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.DateRangeGreidReports olrawdatfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.DateRangeGreidReports));
            if (isFormOpen == false)
            {
                olrawdatfrm = new Reports.DateRangeGreidReports();
                olrawdatfrm.MdiParent = this;

                olrawdatfrm.StartPosition = FormStartPosition.CenterScreen;
                olrawdatfrm.Show();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            nftrans.geteserverdate();

        }

        private void toolStripSeparator70_Click(object sender, EventArgs e)
        {

        }

        private void totalPayrollDeptwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.PayrollReportForm  olrawdatfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.PayrollReportForm));
            if (isFormOpen == false)
            {
                olrawdatfrm = new Reports.PayrollReportForm();
                olrawdatfrm.MdiParent = this;

                olrawdatfrm.StartPosition = FormStartPosition.CenterScreen;
                olrawdatfrm.Show();
            }
        }

        private void newLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void duplicateEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HR.NewFolder1.DataDisplayForm  frm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.DataDisplayForm));
            if (isFormOpen == false)
            {
                frm = new HR.NewFolder1.DataDisplayForm("Approval",1);
                frm.MdiParent = this;

                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void payrollCalendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.PayrollCalender prcl = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.QualificationMasterForm));
            if (isFormOpen == false)
            {
                prcl = new Master.PayrollCalender();
                prcl.MdiParent = this;
                prcl.StartPosition = FormStartPosition.CenterScreen;
                prcl.Show();
            }
        }

        private void employeePerkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HR.NewFolder1.EmployeePerkForm attendancemngr = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.EmployeePerkForm));
            if (isFormOpen == false)
            {
                attendancemngr = new HR.NewFolder1.EmployeePerkForm();
                attendancemngr.MdiParent = this;
                attendancemngr.StartPosition = FormStartPosition.CenterScreen;

                attendancemngr.Show();
            }
        }

        private void designationOTAssignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HR.Rules .DesignationOT desg = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.Rules .DesignationOT ));
            if (isFormOpen == false)
            {
                desg = new HR.Rules.DesignationOT();
                desg.MdiParent = this;
                desg.StartPosition = FormStartPosition.CenterScreen;

                desg.Show();
            }
        }

        private void backDateCloseRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.MissedOutCloseregisterfrm dailymasterfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.MissedOutCloseregisterfrm));
            if (isFormOpen == false)
            {
                dailymasterfrm = new Attendance.MissedOutCloseregisterfrm();
                dailymasterfrm.MdiParent = this;
                dailymasterfrm.StartPosition = FormStartPosition.CenterScreen;
                dailymasterfrm.Show();
            }

        }

        private void closeRegistarNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.MissedOutCloseregisterfrm dailymasterfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.MissedOutCloseregisterfrm));
            if (isFormOpen == false)
            {
                dailymasterfrm = new Attendance.MissedOutCloseregisterfrm();
                dailymasterfrm.MdiParent = this;
                dailymasterfrm.StartPosition = FormStartPosition.CenterScreen;
                dailymasterfrm.Show();
            }
        }

        private void rENEW1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void nightShiftDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwipeAction .NightShiftDetail  dailymasterfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(SwipeAction.NightShiftDetail));
            if (isFormOpen == false)
            {
                dailymasterfrm = new SwipeAction.NightShiftDetail();
                dailymasterfrm.MdiParent = this;
                dailymasterfrm.StartPosition = FormStartPosition.CenterScreen;
                dailymasterfrm.Show();
            }
        }

        private void reactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HR.ReactivateEmployee rectemp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.ReactivateEmployee));
            if (isFormOpen == false)
            {
                rectemp = new HR.ReactivateEmployee();
                rectemp.MdiParent = this;
                rectemp.StartPosition = FormStartPosition.CenterScreen;
                rectemp.Show();
            }
        }

        private void bankAccountUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HR.UpdateAccountNumber upacc = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.UpdateAccountNumber));
            if (isFormOpen == false)
            {
                upacc = new HR.UpdateAccountNumber();
                upacc.MdiParent = this;
                upacc.StartPosition = FormStartPosition.CenterScreen;
                upacc.Show();
            }
        }

        private void deserteeReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void overOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newAdjusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.MasterOTRuler dstre = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.MasterOTRuler));
            if (isFormOpen == false)
            {
                dstre = new Attendance.MasterOTRuler();
                dstre.MdiParent = this;
                dstre.StartPosition = FormStartPosition.CenterScreen;
                dstre.Show();
            }
        }

        private void newCloseRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.NewCloseregister  dstre = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.NewCloseregister));
            if (isFormOpen == false)
            {
                dstre = new Attendance.NewCloseregister();
                dstre.MdiParent = this;
                dstre.StartPosition = FormStartPosition.CenterScreen;
                dstre.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void adjusterReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.FilterableReports dailymasterfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.FilterableReports));
            if (isFormOpen == false)
            {
                dailymasterfrm = new Reports.FilterableReports();
                dailymasterfrm.MdiParent = this;
               
                dailymasterfrm.StartPosition = FormStartPosition.CenterScreen;
                dailymasterfrm.Show();
            }
        }

        private void attendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Action.AttendanceManagerForm attendancemngr = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Action.AttendanceManagerForm));
            if (isFormOpen == false)
            {
                attendancemngr = new Action.AttendanceManagerForm();
                attendancemngr.MdiParent = this;
                attendancemngr.StartPosition = FormStartPosition.CenterScreen;

                attendancemngr.Show();
            }
        }

        private void overOTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Attendance.OverOTEmployee dstre = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.OverOTEmployee));
            if (isFormOpen == false)
            {
                dstre = new Attendance.OverOTEmployee();
                dstre.MdiParent = this;
                dstre.StartPosition = FormStartPosition.CenterScreen;
                dstre.Show();
            }
        }

        private void deserteeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void remain1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Action.Tryform2 tryform2 = new Action.Tryform2();
            tryform2.Show();
        }

        private void remain3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


            Administrator.AttendanceDescrepancyReport frm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Administrator.AttendanceDescrepancyReport));
            if (isFormOpen == false)
            {
                frm = new Administrator.AttendanceDescrepancyReport();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;

                frm.Show();
            }
        }

        private void remain2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


            HR.NewFolder1.EmployeeDetailsEditForm edtform = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.NewFolder1.EmployeeDetailsEditForm));
            if (isFormOpen == false)
            {
                edtform = new  HR.NewFolder1.EmployeeDetailsEditForm();
                edtform.MdiParent = this;
                edtform.StartPosition = FormStartPosition.CenterScreen;

                edtform.Show();
            }


        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            HR.ContractEndingEmployees cntrctmanager = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.ContractEndingEmployees));
            if (isFormOpen == false)
            {
                cntrctmanager = new HR.ContractEndingEmployees();
                cntrctmanager.MdiParent = this;
                cntrctmanager.StartPosition = FormStartPosition.CenterScreen;

                cntrctmanager.Show();
            }
        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void administrativeReportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void employeeBankSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.EmpoloyeeDetailsReport olrawdatfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.EmpoloyeeDetailsReport));
            if (isFormOpen == false)
            {
                olrawdatfrm = new Reports.EmpoloyeeDetailsReport();
                olrawdatfrm.MdiParent = this;

                olrawdatfrm.StartPosition = FormStartPosition.CenterScreen;
                olrawdatfrm.Show();
            }
        }

        private void deserteesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HR.DeserteeEmployee dstre = null;
            bool isFormOpen = IsAlreadyOpen(typeof(HR.DeserteeEmployee));
            if (isFormOpen == false)
            {
                dstre = new HR.DeserteeEmployee();
                dstre.MdiParent = this;
                dstre.StartPosition = FormStartPosition.CenterScreen;
                dstre.Show();
            }
        }

        private void quickSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ATCHRM.HR.EmployeeDataSearch empsearch = null;
            bool isFormOpen = IsAlreadyOpen(typeof( ATCHRM.HR.EmployeeDataSearch));
            if (isFormOpen == false)
            {
                empsearch = new ATCHRM.HR.EmployeeDataSearch();
                empsearch.MdiParent = this;
                empsearch.StartPosition = FormStartPosition.CenterScreen;
                empsearch.Show();
            }
            
        }

        private void payrollMasterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ATCHRM.Payroll.PayrollReportcs empsearch = null;
                bool isFormOpen = IsAlreadyOpen(typeof(ATCHRM.Payroll.PayrollReportcs));
            if (isFormOpen == false)
            {
                empsearch = new ATCHRM.Payroll.PayrollReportcs();
                empsearch.MdiParent = this;
                empsearch.StartPosition = FormStartPosition.CenterScreen;
                empsearch.Show();
            }
        }

        private void remain4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Action.NewAction frm = new Action.NewAction();
            frm.Show();
        }

        private void contractReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Reports.MultiReporter frm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.MultiReporter));
            if (isFormOpen == false)
            {
                frm = new Reports.MultiReporter();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void closeRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newDeptSubDeptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.DepartmentMasterForm deptmstrfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.DepartmentMasterForm));
            if (isFormOpen == false)
            {
                deptmstrfrm = new Master.DepartmentMasterForm();

                deptmstrfrm.MdiParent = this;
                deptmstrfrm.StartPosition = FormStartPosition.CenterScreen;
                deptmstrfrm.Show();
            }
        }

        private void deptLocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.LocationandDeptLink  deptmstrfrm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Master.LocationandDeptLink));
            if (isFormOpen == false)
            {
                deptmstrfrm = new Master.LocationandDeptLink();

                deptmstrfrm.MdiParent = this;
                deptmstrfrm.StartPosition = FormStartPosition.CenterScreen;
                deptmstrfrm.Show();
            }
        }

        private void leaveMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance .LeaveMonitor lvmonitor = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Attendance.LeaveMonitor));
            if (isFormOpen == false)
            {
                lvmonitor = new Attendance.LeaveMonitor();

                lvmonitor.MdiParent = this;
                lvmonitor.StartPosition = FormStartPosition.CenterScreen;
                lvmonitor.Show();
            }
        }

        private void nIDStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.NIDStatusForm frm = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.NIDStatusForm));
            if (isFormOpen == false)
            {
                frm = new Reports.NIDStatusForm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void singleContractApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.ContractApprovalForm cntrctapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.ContractApprovalForm));
            if (isFormOpen == false)
            {
                cntrctapp = new Approvals.ContractApprovalForm();
                cntrctapp.MdiParent = this;
                cntrctapp.StartPosition = FormStartPosition.CenterScreen;
                cntrctapp.Show();
            }
        }

        private void multiContractApprovalFHRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.MultiContractApprovalForm cntrctapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.MultiContractApprovalForm));
            if (isFormOpen == false)
            {
                cntrctapp = new Approvals.MultiContractApprovalForm(1);
                cntrctapp.MdiParent = this;
                cntrctapp.StartPosition = FormStartPosition.CenterScreen;
                cntrctapp.Show();
            }
        }

        private void multiContractApprovalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Approvals.MultiContractApprovalForm cntrctapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.MultiContractApprovalForm));
            if (isFormOpen == false)
            {
                cntrctapp = new Approvals.MultiContractApprovalForm(2);
                cntrctapp.MdiParent = this;
                cntrctapp.StartPosition = FormStartPosition.CenterScreen;
                cntrctapp.Show();
            }
        }

        private void multiContractApprovalFCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approvals.MultiContractApprovalForm cntrctapp = null;
            bool isFormOpen = IsAlreadyOpen(typeof(Approvals.MultiContractApprovalForm));
            if (isFormOpen == false)
            {
                cntrctapp = new Approvals.MultiContractApprovalForm(3);
                cntrctapp.MdiParent = this;
                cntrctapp.StartPosition = FormStartPosition.CenterScreen;
                cntrctapp.Show();
            }
        }


    }
}

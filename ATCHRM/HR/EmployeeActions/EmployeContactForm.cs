using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient ;
namespace ATCHRM.HR.NewFolder1
{
    public partial class EmployeContactEntryForm : Form
    {
        Datalayer.EmployeePersonaldatabean empdb = null;
        Transactions.RecruitApplicationTransaction rcrtappltransaction = null;
        Transactions.Locationtransaction lctn = null;
        Transactions.EmployeeRegTransaction reg = null;
        Transactions.ShiftTransactionNewform shfttransaction = null;
        Transactions.SubDepartmentTransaction subdepttrans = null;
        Datalayer.EmployeeDesignationDataBean empdsgbean = null;
        Datalayer.EmployeeContractDatabean empcontrctdatbean = null;
        Datalayer.EmployeeShiftDatabean shftdatbean = null;
        Datalayer.employeesalarydatabean empsaldatabean = null;
        Transactions.currencytransaction crncytrans = null;
        Transactions.BankTransactions bnktransctn = null;
        Transactions.PerkTransaction prktrans = null;
        DataTable employyeapplicableleave = null;
        Transactions.DeptTransaction dptrans =null;
        DataTable dTable = new DataTable();
        int recruitmentid = 0;
        DataTable dt = null;
        int empid = 0;
        int clickcomboflag = 0;
        int shftflag = 0;
        String emp_code = "";
        Transactions.AnualContractrenewal annul = null;
        public EmployeContactEntryForm()
        {
            InitializeComponent();
            rcrtappltransaction = new Transactions.RecruitApplicationTransaction();
            lctn = new Transactions.Locationtransaction();
            reg = new Transactions.EmployeeRegTransaction();
            shfttransaction = new Transactions.ShiftTransactionNewform();
            annul = new Transactions.AnualContractrenewal();
            crncytrans = new Transactions.currencytransaction();
            bnktransctn = new Transactions.BankTransactions();
            subdepttrans = new Transactions.SubDepartmentTransaction();
            prktrans = new Transactions.PerkTransaction();
            dptrans = new Transactions.DeptTransaction();
            countrylistload();
            recruitmentCodeLoad();
            LoadQualification();

            cmb_Recruitmentcode.SelectedIndex = -1;
        }

        public EmployeContactEntryForm(int recid)
        {
            InitializeComponent();
            rcrtappltransaction = new Transactions.RecruitApplicationTransaction();
            lctn = new Transactions.Locationtransaction();
            reg = new Transactions.EmployeeRegTransaction();
            shfttransaction = new Transactions.ShiftTransactionNewform();
            annul = new Transactions.AnualContractrenewal();
            crncytrans = new Transactions.currencytransaction();
            bnktransctn = new Transactions.BankTransactions();
            countrylistload();
            recruitmentCodeLoad();
            prktrans = new Transactions.PerkTransaction();
            cmb_Recruitmentcode.SelectedValue = recid;
        }


        /////////////////////////////////////////////////Personal Region///////////////////////////////////////////////////////////



        # region employeepersomnal








        /// <summary>
        /// loads employe code
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = reg.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";
        }






        /// <summary>
        /// reloads the country to comobox
        /// </summary>
        public void countrylistload()
        {
            dt = lctn.getcountry();
            cmb_Country.DataSource = dt;
            cmb_Country.DisplayMember = "CountryName";
        }
        /// <summary>
        /// loads the recruit ment codes that are not used by others or that is assigned n
        /// now to somebody for editing
        /// </summary>
        public void recruitmentCodeLoad()
        {
            DataTable recruittable = new DataTable();
            recruittable = rcrtappltransaction.getAllRecruitmentCode();
            cmb_Recruitmentcode.DataSource = recruittable;

            cmb_Recruitmentcode.DisplayMember = "EmpInternalCode";
            cmb_Recruitmentcode.ValueMember = "RecruitmentCodePK";
        }




        public void LoadQualification()
        {
            cmb_education.DataSource = dptrans.GetallQualification();
            cmb_education.DisplayMember = "QUALIFICATION";
            cmb_education.ValueMember = "SL";
        }


        public Boolean stopduplicateentry()
        {
            Boolean isnotpresent = true;
              DataTable dt = new DataTable();
            dt = reg.isEmployeePresent(textNidConfrm.Text);

            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = reg.isDuplicateNationIDAllowedfor(textNidConfrm.Text);
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count != 0)
                        {
                            isnotpresent = false;
                        }
                    }
                }
            }
            return isnotpresent;
        }
        /// <summary>
        /// check whether NID Already exist
        /// </summary>
        public void prevoioustrack()
        {
            DataTable dt = new DataTable();
            dt = reg.isEmployeePresent(textNidConfrm.Text);

            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("This NID Have " + dt.Rows.Count + "   Previous Track Records Confirm Whether to Continue with Registration ", "Attention ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DialogResult dialogResult1 = MessageBox.Show("Do You Want to ReEmployee This Person ? ", "Attention ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            HR.NewFolder1.DataDisplayForm dfrm = new DataDisplayForm(textNidConfrm.Text);
                            dfrm.ShowDialog();
                         
                        }
                        else
                        {
                            this.Close();
                        }

                    }
                    else
                    {
                        reg.releaseRecruitmentcode(int.Parse(cmb_Recruitmentcode.SelectedValue.ToString()));
                        this.Close();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Applications.RecruitmentCodeForm rctcodefrm = new Applications.RecruitmentCodeForm();
            //rctcodefrm.MdiParent = this.MdiParent;
            //rctcodefrm.Show();

            using (Applications.RecruitmentCodeForm formOptions = new Applications.RecruitmentCodeForm())
            {
                formOptions.ShowDialog();

                string result = formOptions.GetMyResult1;
                if (result != null)
                {
                    cmb_Recruitmentcode.SelectedValue = int.Parse(result);
                }
            }
        }

        private void btn_AddCountry_Click(object sender, EventArgs e)
        {
            Master.LocationMasterForm lctnmasterform = new Master.LocationMasterForm("Country");
            lctnmasterform.Show();
            countrylistload();
        }

        private void btn_AddState_Click(object sender, EventArgs e)
        {
            Master.LocationMasterForm lctnmasterform = new Master.LocationMasterForm("State");
            lctnmasterform.Show();
            countrylistload();
        }

        private void btn_AddCity_Click(object sender, EventArgs e)
        {

            Master.LocationMasterForm lctnmasterform = new Master.LocationMasterForm("City");
            lctnmasterform.Show();
            countrylistload();
        }

        private void comboNation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboNation.Text != "KENYA")
            {
                textNid.Text = "expat";
                textNidConfrm.Text = "expat";
                textpp.Focus();
                detailopanel.Enabled = true;
              //  groupBox2.Visible = false;
              
            }
            else
            {
                textNid.Focus();
                textpp.Visible = true;

            }

        }



        private void comboNation_Leave(object sender, EventArgs e)
        {
            if (comboNation.SelectedIndex == -1)
            {
                label27.Visible = true;
                // ATCHRM.Controls.ATCHRMMessagebox.Show("Pls Choose Nationality");
                groupContact.Enabled = false;
                detailopanel.Enabled = false;
                textNid.Enabled = false;
                comboNation.Focus();
            }
            else
            {
                label27.Visible = false;
                groupContact.Enabled = true;
                detailopanel.Enabled = true;
               
                textNid.Enabled = true;
            }
        }



        private void textNid_Leave(object sender, EventArgs e)
        {
            
        }


        private void textNidConfrm_Leave(object sender, EventArgs e)
        {
            if (textNidConfrm.Text != textNid.Text)
            {
                groupContact.Enabled = false;
                detailopanel.Enabled = false;
                textNidConfrm.Focus();
                label29.Visible = true;
              
            }
            else if (textNidConfrm.Text == textNid.Text)
            {
                label29.Visible = false;
                //Here We can write the code to check weather the NID is existing or not
                groupContact.Enabled = true;
                detailopanel.Enabled = true;
             
                textNid.ReadOnly = true;
                prevoioustrack();
                comboGender .Focus();

            }
        }

        private void textNidConfrm_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = lctn.getstatebycountry(cmb_Country.Text);
            cmb_State.DataSource = dt;
            cmb_State.DisplayMember = "StateName";
        }

        private void cmb_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = lctn.getcitybycountry(cmb_Country.Text, cmb_State.Text);
            cmb_City.DataSource = dt;
            cmb_City.DisplayMember = "CitName";
            cmb_City.ValueMember = "LocationPk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationControl())
                {
                    empid = Save_Data();
                    reg.UsingRecruitmentcode(recruitmentid);
                    clearcontrolonmaster();
                    if (empid != 0)
                    {
                        MessageBox.Show("Employee " + emp_code + " Registered", "ATCHRM");



                    }
                    else
                    {
                        MessageBox.Show("Employee Not  Registered error in system", "ATCHRM");
                    }

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
        /// Stops the duplicates in KRA,NSSF,NHIF,NID,ACC
        /// </summary>
        public Boolean  StopAnyDuplication()
        {
            Boolean isnotpresent = true;
          
            
                    DataTable dt1 = new DataTable();
                    dt1 = reg.isDuplicateFoundFor(textNid.Text, textpp.Text, txt_nssf.Text, txt_nhif.Text, txt_incometaxnum.Text);
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count != 0)
                        {
                            isnotpresent = false;
                            if (dt1.Rows[0]["NationalId"].ToString().Trim() == textNid.Text.Trim())
                            {
                                MessageBox.Show("Duplicate NID");
                                isnotpresent = false;
                            }
                            if (dt1.Rows[0]["PassportNo"].ToString().Trim() == textpp.Text.Trim())
                            {
                                MessageBox.Show("Duplicate Passportnum");
                                isnotpresent = false;
                            }
                            if (dt1.Rows[0]["NSSFnum"].ToString().Trim() == txt_nssf.Text.Trim())
                            {
                                MessageBox.Show("Duplicate NSSF");
                                isnotpresent = false;

                            }
                            if (dt1.Rows[0]["NHIFnum"].ToString().Trim() == txt_nhif.Text.Trim())
                            {
                                MessageBox.Show("Duplicate NHIF");
                                isnotpresent = false;
                            }
                            if (dt1.Rows[0]["Incometaxnum"].ToString().Trim() == txt_incometaxnum.Text.Trim())
                            {
                                MessageBox.Show("Duplicate KRA");
                                isnotpresent = false;

                            }
                        }
                    }
           
            return isnotpresent;

        }

        public Boolean IsBlacklisted()
        {
            Boolean isblklist = false;
            isblklist = reg.IsBlacklisted(textNid.Text.Trim ());
           
                return isblklist;
        }
        
        
        private int Save_Data()
        {
            int emppk = 0;
            try
            {


                reg = new Transactions.EmployeeRegTransaction();
                empdb = new Datalayer.EmployeePersonaldatabean();


                empdb.Nationality = comboNation.Text;
                empdb.Nid = textNid.Text;
                empdb.PPnum1 = textpp.Text;
                empdb.Gender = comboGender.Text;
                empdb.Status = combostatus.Text;
                empdb.Firstname = textfname.Text;
                empdb.Lastname = textlname.Text;
                empdb.Adress1 = richTextaddr1.Text;
                empdb.Adress2 = richTextaddr2.Text;

                empdb.LctnPk = Convert.ToInt32(cmb_City.SelectedValue);
                empdb.Telphone = textcontel.Text;
                empdb.Mobile = textconmob.Text;
                empdb.Email = textconemail.Text;
                empdb.Refname = textrefname.Text;
                empdb.Refdetails = richTextrefdetails.Text;
                empdb.Refmobile = textrefmob.Text;
                empdb.Refemail = textrefmail.Text;
                empdb.Beneficaryname = textkinnme.Text;
                empdb.Benificiaryrelation = combokinrel.Text;
                empdb.Beneficiarymobile = textkinmob.Text;
                empdb.Beneficiaryemail = textkinmail.Text;
                empdb.Dob = Dtp_dateofBirth1.Value.Date;
                empdb.NSSF1 = txt_nssf.Text;
                empdb.NHIF1 = txt_nhif.Text;
                empdb.INCometaxnum1 = txt_incometaxnum.Text;
                empdb.KinsNID = txt_KinsNid.Text;
                empdb.Oldempid1 = txt_oldid.Text;
                empdb.RecId = int.Parse(cmb_Recruitmentcode.SelectedValue.ToString());



                try
                {
                    empdb.Highesteducation = int.Parse(cmb_education.SelectedValue.ToString());
                }
                catch (Exception)
                {
                    empdb.Highesteducation = 0;
                   
                }

                emp_code = reg.Emp_id();
                empdb.Empcode = reg.Emp_id();
                emppk = reg.insertEmpPersonalDetails(empdb);
                reg.AssignRecruitmentcode(int.Parse(cmb_Recruitmentcode.SelectedValue.ToString()));



            }
            catch (Exception exp)
            {

                if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Enter a Unique Component Name");
                }

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);
                 ATCHRM.Controls.ATCHRMMessagebox.Show(exp.Message.ToString());
                this.Dispose();
            }
            return emppk;
        }

        public void clearcontrolonmaster()
        {
            comboNation.Text = "";
            textpp.Text = "";
            comboGender.Text = "";
            textfname.Text = "";
            textlname.Text = "";
            richTextaddr1.Text = "";
        }

        /// <summary>
        /// Validates all the controls to ensure  
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (comboNation.Text == null || comboNation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Nationality";
                comboNation.Focus();
                label27.Visible = true;
            }
            else if (textNid.Text == null || textNid.Text.Trim() == "")
            {
                lblStatus.Text = "Enter NID";
                textNid.Focus();
                lbl_Companyname.Visible = true;
            }

            else if (textpp.Text == null || textpp.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid  CalculationMode ";
                textpp.Focus();
                label29.Visible = true;
            }


            else if (comboGender.Text == null || comboGender.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Gender";
                comboGender.Focus();
                label67.Visible = true;
            }
            else if (combostatus.Text == null || combostatus.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Status";
                combostatus.Focus();
                label31.Visible = true;
            }
            else if (textfname.Text == null || textfname.Text.Trim() == "")
            {
                lblStatus.Text = "Enter First Name";
                textfname.Focus();
                label71.Visible = true;
            }
            else if (textlname.Text == null || textlname.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Last Name";
                textlname.Focus();
                label70.Visible = true;
            }
            else if (richTextaddr1.Text == null || richTextaddr1.Text.Trim() == "")
            {
                lblStatus.Text = "Enter The Address";
                richTextaddr1.Focus();

            }
            else if (IsBlacklisted())
            {
                MessageBox.Show("BlackListed Employee");
            }
            else if (!StopAnyDuplication())
            {
                
            }
                
            else
            {
                sucess = true;
            }

            return sucess;

        }

        # endregion

        ///////////////////////////////////////////// Contract and Others////////////////////////////////////////////////////////////



        public void fillemployeecontract(int recruitmentid)
        {
            DataTable dt = new DataTable();
            dt = reg.getcontracttypeofarecruitment(recruitmentid);
            if (dt != null)
            {



                cmb_contracttype.Text = dt.Rows[0][1].ToString();

                dtp_fromdate.Value = DateTime.Parse(dt.Rows[0][2].ToString());
                dtp_joiningdata.Value = dtp_fromdate.Value;
            }
        }

        private void dtp_fromdate_ValueChanged(object sender, EventArgs e)
        {
            dtp_joiningdata.Value = dtp_fromdate.Value;
        }
        ////////////////////////////////////////////Common Area///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cmb_Recruitmentcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                recruitmentid = int.Parse(cmb_Recruitmentcode.SelectedValue.ToString());
                pnl_prsnl.Enabled = true;
            }
            catch (Exception)
            {
                pnl_prsnl.Enabled = false;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tb_contract)
            {
                try
                {
                    if (empid == 0)
                    {
                        employecodeload1();
                    }
                    else
                    {
                        cmb_EmpCode.Text = emp_code;
                        cmb_EmpCode.Enabled = false;

                        fillcontrol(empid, "ADD");
                        fillemployeecontract(recruitmentid);
                        fillLeaveApplicable(recruitmentid);
                    }
                }
                catch (Exception)
                {


                }
            }
            else if (tabControl1.SelectedTab == Shift)
            {
                shiftcomboload("NA");

            }
            else if (tabControl1.SelectedTab == salary)
            {
                if (empid != 0)
                {
                    fillperk();
                    employeedtasetup();
                    
                }
            }
        }




        /// <summary>
        /// loads the employee who are not fully active
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        public void employecodeload1()
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = reg.nonactiveemployee();
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";


            lbl_emppk.Text = cmb_EmpCode.SelectedValue.ToString();
        }



        /////////////////////////////////////////////////Position Region ////////////////////////////////////////////////////////////////////////

        public void fillcontrol(int empid, String action)
        {
            try
            {
                DataTable dt = reg.getEmployeDesignationandLocation(empid, action);
                if (dt != null)
                {

                    // lbl_emppk.Text = dt.Rows[0][1].ToString();
                    cmb_designation.Text = dt.Rows[0][2].ToString();
                    lbl_desingnsation.Text = dt.Rows[0][3].ToString();
                    cmb_dept.Text = dt.Rows[0][4].ToString();
                    lbl_dept.Text = dt.Rows[0][5].ToString();
                    cmb_Location.Text = dt.Rows[0][6].ToString();
                    lbl_LocationPk.Text = dt.Rows[0][7].ToString();
                    cmb_Branch.Text = dt.Rows[0][8].ToString();
                    lbl_branchPk.Text = dt.Rows[0][9].ToString();
                    loadsubdept(int.Parse(lbl_dept.Text));

                }
            }
            catch (Exception)
            {


            }
        }





        public void loadsubdept(int deptid)
        {
            DataTable dt = subdepttrans.getSubdepartment(deptid);
            cmb_subdept.DataSource = dt;
            cmb_subdept.DisplayMember = "SubDeptName";
            cmb_subdept.ValueMember = "SubDeptPK";
        }

        ///////////////////////////////////////////Leave Control //////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// fill all the leave applicable for that person
        /// </summary>
        /// <param name="eimpid"></param>
        public void fillLeaveApplicable(int recruitmentid)
        {
            //   eimpid = 92;
            employyeapplicableleave = reg.getTheApplicableleaveforrecruitment(recruitmentid);

            if (employyeapplicableleave != null)
            {
                tbl_Leavedata.DataSource = employyeapplicableleave;
                tbl_Leavedata.Columns[0].Visible = false;
                tbl_Leavedata.Columns[3].Visible = false;
                tbl_Leavedata.Columns[4].Visible = false;
                tbl_Leavedata.Columns[5].Visible = false;
                // tbl_Leavedata.Columns[6].Visible = false;
                tbl_Leavedata.Columns[10].Visible = false;
                tbl_Leavedata.Columns[8].Visible = false;

            }


        }


        



        /////////////////////////////////////////Employee Shift////////////////////////////////////////////////////////////////////





        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_shift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shftflag != 0)
            {
                DataTable dt = shfttransaction.getsShiftByPK(int.Parse(Cmb_shift.SelectedValue.ToString()));
                fillothercontrols(dt);
                lbl_shiftPK.Text = Cmb_shift.SelectedValue.ToString();
            }
            shftflag = 0;
        }

        private void Cmb_shift_MouseClick(object sender, MouseEventArgs e)
        {
            shftflag++;
        }

        /// <summary>
        /// LOAD ALL THE SHIFT DATA
        /// </summary>
        public void shiftcomboload(String type)
        {
            DataTable dt = shfttransaction.getAllShiftName();

            Cmb_shift.DataSource = dt;
            Cmb_shift.DisplayMember = "ShiftName";
            Cmb_shift.ValueMember = "ShiftPK";


            lbl_shiftPK.Text = Cmb_shift.SelectedValue.ToString();


        }



        public void fillothercontrols(DataTable dt)
        {
            if (dt.Rows.Count != 0)
            {

                for (int i = 0; i < 7; i++)
                {

                    if (dt.Rows[i][1].ToString() == "Monday")
                    {
                        dtpIn_Monday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtp_Monday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Monday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString().Trim() == "Tuesday")
                    {
                        dtpIn_Tuesday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Tuesday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
                        cmbDayType_Tuesday.Text = dt.Rows[i][2].ToString();

                    }
                    else if (dt.Rows[i][1].ToString() == "Wednesday")
                    {
                        dtpIn_Wednesday.Value = DateTime.Parse(dt.Rows[i][3].ToString());
                        dtpOut_Wednesday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
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
                        dtpOut_Saturday.Value = DateTime.Parse(dt.Rows[i][4].ToString());
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                addaction();
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }








        public Boolean validationcontrolforDesignation()
        {
            Boolean sucess = false;


            if (cmb_Branch.Text == null || cmb_Branch.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Branch ";
                cmb_Branch.Focus();
            }
            else if (cmb_Location.Text == null || cmb_Location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Location  ";
                cmb_Location.Focus();
            }
            else if (cmb_dept.Text == null || cmb_dept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Deignation  ";
                cmb_dept.Focus();
            }
            else if (cmb_subdept.Text == null || cmb_subdept.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Sub Dept  ";
                cmb_subdept.Focus();
            }
            else if (cmb_designation.Text == null || cmb_designation.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Deignation  ";
                cmb_designation.Focus();
            }

            else
            {
                sucess = true;
            }
            return sucess;
        }


        public Boolean validationControlforContract()
        {
            Boolean sucess = false;
            if (cmb_contracttype.Text == null || cmb_contracttype.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Contract Type ";
                cmb_contracttype.Focus();
            }
            else if (dtp_fromdate.Value.Date == dtp_todate.Value.Date)
            {
                lblStatus.Text = "End Date and Start Date  are Same";

            }
            else
            {
                sucess = true;
            }
            return sucess;
        }









        public void addaction()
        {

            if (empid != 0)
            {
                empdsgbean = new Datalayer.EmployeeDesignationDataBean();
                if (validationcontrolforDesignation())
                {
                    if (validationControlforContract())
                    {

                        empdsgbean.Empid = empid;
                        empdsgbean.Deptid = int.Parse(lbl_dept.Text);
                        empdsgbean.Lctnid = int.Parse(lbl_LocationPk.Text);
                        empdsgbean.Desgid = int.Parse(lbl_desingnsation.Text);
                        empdsgbean.SubdeptPk = int.Parse(cmb_subdept.SelectedValue.ToString());
                        reg.insertEmployeeDesignation(empdsgbean, "ADD");

                        empcontrctdatbean = new Datalayer.EmployeeContractDatabean();
                        empcontrctdatbean.Empid = empid;
                        empcontrctdatbean.Contractype = cmb_contracttype.Text;
                        empcontrctdatbean.Startime = dtp_fromdate.Value.Date;
                        empcontrctdatbean.Endtime = dtp_todate.Value.Date;
                        empcontrctdatbean.Extendeddate = empcontrctdatbean.Endtime;
                        empcontrctdatbean.Actualjoinigdate = dtp_joiningdata.Value.Date;
                        reg.insertEmployeeContractdetails(empcontrctdatbean, "Add");
                        annul.insertAnnualContractforexistingEmployee(empcontrctdatbean.Empid);
                        if (addleave())
                        {

                             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");




                        }







                    }
                }
            }


        }



        /// <summary>
        /// add leave against a employye
        /// </summary>
        /// <returns></returns>
        public Boolean addleave()
        {
            Boolean sucess = true;

            if (tbl_Leavedata.RowCount != 0)
            {

                SqlConnection con = new SqlConnection(Program.ConnStr);
                try
                {
                    con.Open();

                    for (int i = 0; i < tbl_Leavedata.RowCount - 1; i++)
                    {

                        SqlCommand cmd = new SqlCommand(" INSERT INTO EmployeeApplicableLeave_tbl (empid, LeavePk, Isenchasable, EnchasableDays, Allowedleave) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5) ", con);

                        cmd.Parameters.AddWithValue("@Param1", empid);
                        cmd.Parameters.AddWithValue("@Param2", int.Parse(tbl_Leavedata.Rows[i].Cells[0].Value.ToString()));

                        cmd.Parameters.AddWithValue("@Param3", int.Parse(tbl_Leavedata.Rows[i].Cells[3].Value.ToString()));
                        cmd.Parameters.AddWithValue("@Param4", int.Parse(tbl_Leavedata.Rows[i].Cells[6].Value.ToString()));
                        cmd.Parameters.AddWithValue("@Param5", int.Parse(tbl_Leavedata.Rows[i].Cells[7].Value.ToString()));

                        cmd.ExecuteNonQuery();

                    }


                }
                catch (Exception exp)
                {
                    sucess = false;


                    ErrorLogger er = new ErrorLogger();
                    er.createErrorLog(exp);
                }
                finally
                {
                    con.Close();

                }



            }





            return sucess;
        }






        ///////////////////////////////////////////////////////////////Shift Form//////////////////////////////////




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (empid != 0)
                {
                    if (validationcontrolforshift())
                    {

                        shftdatbean = new Datalayer.EmployeeShiftDatabean();
                        shftdatbean.Empid = empid;
                        shftdatbean.ShiftPk1 = int.Parse(Cmb_shift.SelectedValue.ToString());

                        shftdatbean.Effectivedate = dtp_fromdate.Value.Date;
                        reg.insertEmpShiftDetails(shftdatbean);
                         ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

                    }
                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// validates the fornm 
        /// </summary>
        /// <returns></returns>
        public Boolean validationcontrolforshift()
        {
            Boolean sucess = false;

            if (empid == 0)
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

        private void cmb_EmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Recruitmentcode.Text.Trim() == null || cmb_Recruitmentcode.Text.Trim() == "")
                {
                    if (recruitmentid == 0)
                    {
                        empid = int.Parse(cmb_EmpCode.SelectedValue.ToString());
                        DataTable dt = reg.getRecruidmentCodeandIDofEmployee(empid);
                        recruitmentid = int.Parse(dt.Rows[0][0].ToString());

                        fillcontrol(empid, "ADD");
                        fillemployeecontract(recruitmentid);
                        fillLeaveApplicable(recruitmentid);
                        displayemployeephoto();
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void detailopanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_submmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (empid != 0)
                {
                    if (reg.IsEmployeedetailsComplete(empid))
                    {
                        reg.MarkEmployeeDataFilled(empid);
                        MessageBox.Show("Employee " + emp_code + " Registeration Completed", "ATCHRM");
                    }
                }
                else
                {
                     ATCHRM.Controls.ATCHRMMessagebox.Show("No Employee Selected");
                }
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }








        ///////////////////////////////////////////////////////////////////Salary Component////////////////////////////////////////////////////////



        public void employeedtasetup()
        {
            fillcurrency();
            fillBank();
            employecodechangedevent();

        }

        /// <summary>
        /// will get all thecurrency data 
        /// and will enter it to combobox
        /// 
        /// </summary>
        public void fillcurrency()
        {

            DataTable dt = crncytrans.getCurrencyName();
            cmb_currency.DataSource = dt;
            cmb_currency.DisplayMember = "NameAdr";
            cmb_currency.ValueMember = "pk";

        }


        /// <summary>
        /// will get all Bank data 
        /// and will enter it to combobox
        /// 
        /// </summary>
        public void fillBank()
        {

            DataTable dt = bnktransctn.getallbanknameandcode();
            cmb_bank.DataSource = dt;
            cmb_bank.DisplayMember = "bnkname";
            cmb_bank.ValueMember = "pk";

        }

        public void employecodechangedevent()
        {

            try
            {
                if (empid != 0)
                {
                    //    lbl_empid.Text = cmb_EmpCode.SelectedValue.ToString();


                    DataTable basicsal = reg.getBasicDesgSal(empid);

                    if (basicsal.Rows.Count != 0)
                    {
                        txt_basicsal.Text = basicsal.Rows[0][0].ToString();
                        lbl_currency.Text = basicsal.Rows[0][2].ToString();
                        txt_basicsal.ReadOnly = true;
                        txt_appsal.Text = basicsal.Rows[0][0].ToString();
                        salcomponentdata(empid);
                        cmb_currency.SelectedValue = basicsal.Rows[0][1].ToString();
                    }


                }
            }
            catch (Exception)
            {


            }
        }



        public void gridviewsetup()
        {

            tbl_disbursement.Columns.Add("1", "SL");
            tbl_disbursement.Columns.Add("1", "COMPONENT");
            tbl_disbursement.Columns.Add("1", "TYPE");
            tbl_disbursement.Columns.Add("1", "CALCULATION");
            tbl_disbursement.Columns.Add("1", "CRITERIA ");
            tbl_disbursement.Columns.Add("1", "AMOUNT");
            tbl_disbursement.Columns.Add("1", "Filtertype");
            tbl_disbursement.Columns[6].Visible = false;
            tbl_disbursement.RowTemplate.Height = 18;


            tbl_deduction.Columns.Add("1", "SL");
            tbl_deduction.Columns.Add("1", "COMPONENT");
            tbl_deduction.Columns.Add("1", "TYPE");
            tbl_deduction.Columns.Add("1", "CALCULATION");
            tbl_deduction.Columns.Add("1", "CRITERIA ");
            tbl_deduction.Columns.Add("1", "AMOUNT");
            tbl_deduction.Columns.Add("1", "Filtertype");
            tbl_deduction.Columns[6].Visible = false;
            tbl_deduction.RowTemplate.Height = 18;

            tbl_SalComponentmain.Columns.Add("1", "SL");
            tbl_SalComponentmain.Columns.Add("1", "COMPONENT");
            tbl_SalComponentmain.Columns.Add("1", "TYPE");
            tbl_SalComponentmain.Columns.Add("1", "CALCULATION");
            tbl_SalComponentmain.Columns.Add("1", "CRITERIA ");
            tbl_SalComponentmain.Columns.Add("1", "AMOUNT");
            tbl_SalComponentmain.Columns.Add("1", "Filtertype");
            tbl_SalComponentmain.Columns[6].Visible = false;
            tbl_SalComponentmain.RowTemplate.Height = 18;


        }


        public void salcomponentdata(int empid)
        {
            gridviewsetup();
            tbl_deduction.Rows.Clear();
            tbl_deduction.DataSource = null;
            tbl_disbursement.Rows.Clear();
            tbl_disbursement.DataSource = null;


            tbl_SalComponentmain.Rows.Clear();
            tbl_SalComponentmain.DataSource = null;
            DataTable exceptioncomponent = reg.getSalaryComponentNotInDesg(empid);
            DataTable dt = reg.getAllSalCompData(empid);
            if (dt.Rows.Count != 0)
            {
                int j = 0;
                int k = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "Deduction")
                    {
                        tbl_deduction.Rows.Add();

                        tbl_deduction.Rows[j].Cells[0].Value = dt.Rows[i][0];
                        tbl_deduction.Rows[j].Cells[1].Value = dt.Rows[i][1];
                        tbl_deduction.Rows[j].Cells[2].Value = dt.Rows[i][2];
                        tbl_deduction.Rows[j].Cells[3].Value = dt.Rows[i][4];
                        tbl_deduction.Rows[j].Cells[4].Value = dt.Rows[i][5];
                        tbl_deduction.Rows[j].Cells[5].Value = dt.Rows[i][6];
                        tbl_deduction.Rows[j].Cells[6].Value = dt.Rows[i][3];
                        j++;

                    }
                    else if (dt.Rows[i][3].ToString() == "Disbursement")
                    {

                        tbl_disbursement.Rows.Add();
                        tbl_disbursement.Rows[k].Cells[0].Value = dt.Rows[i][0];
                        tbl_disbursement.Rows[k].Cells[1].Value = dt.Rows[i][1];
                        tbl_disbursement.Rows[k].Cells[2].Value = dt.Rows[i][2];
                        tbl_disbursement.Rows[k].Cells[3].Value = dt.Rows[i][4];
                        tbl_disbursement.Rows[k].Cells[4].Value = dt.Rows[i][5];
                        tbl_disbursement.Rows[k].Cells[5].Value = dt.Rows[i][6];
                        tbl_disbursement.Rows[k].Cells[6].Value = dt.Rows[i][3];
                        k++;
                    }
                }


                for (int p = 0; p < exceptioncomponent.Rows.Count; p++)
                {


                    tbl_SalComponentmain.Rows.Add();

                    tbl_SalComponentmain.Rows[p].Cells[0].Value = exceptioncomponent.Rows[p][0];
                    tbl_SalComponentmain.Rows[p].Cells[1].Value = exceptioncomponent.Rows[p][1];
                    tbl_SalComponentmain.Rows[p].Cells[2].Value = exceptioncomponent.Rows[p][2];
                    tbl_SalComponentmain.Rows[p].Cells[3].Value = exceptioncomponent.Rows[p][4];
                    tbl_SalComponentmain.Rows[p].Cells[4].Value = exceptioncomponent.Rows[p][5];
                    tbl_SalComponentmain.Rows[p].Cells[5].Value = exceptioncomponent.Rows[p][6];
                    tbl_SalComponentmain.Rows[p].Cells[6].Value = exceptioncomponent.Rows[p][3];

                }





            }


        }

        private void cocmb_paymentmde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cocmb_paymentmde.Text == "Bank Transfer")
            {
                this.groupBox10.Visible = true;

            }
            if (cocmb_paymentmde.Text == "Check Payment")
            {
                this.groupBox10.Visible = false;
            }
            if (cocmb_paymentmde.Text == "Cash")
            {
                this.groupBox10.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                dTable = new DataTable();
                DataColumn auto = new DataColumn("empid", typeof(System.Int32));
                dTable.Columns.Add(auto);

                DataColumn salcompK = new DataColumn("salcompK", typeof(string));
                dTable.Columns.Add(salcompK);

                DataColumn amount = new DataColumn("Amount", typeof(string));
                dTable.Columns.Add(amount);

                DataRow row = null;


                if (validationcontrolforsal())
                {

                    empsaldatabean = new Datalayer.employeesalarydatabean();


                    for (int i = 0; i < tbl_deduction.Rows.Count - 1; i++)
                    {
                        row = dTable.NewRow();
                        row["empid"] = empid;
                        row["salcompK"] = int.Parse(tbl_deduction.Rows[i].Cells[0].Value.ToString());
                        row["amount"] = int.Parse(tbl_deduction.Rows[i].Cells[5].Value.ToString());
                        dTable.Rows.Add(row);
                    }

                    for (int i = 0; i < tbl_disbursement.Rows.Count - 1; i++)
                    {
                        row = dTable.NewRow();
                        row["empid"] = empid;
                        row["salcompK"] = int.Parse(tbl_disbursement.Rows[i].Cells[0].Value.ToString());
                        row["amount"] = int.Parse(tbl_disbursement.Rows[i].Cells[5].Value.ToString());
                        dTable.Rows.Add(row);
                    }
                    empsaldatabean.Empid = empid;

                    empsaldatabean.Approvedsal = int.Parse(txt_appsal.Text.ToString());
                    empsaldatabean.Currencypk = int.Parse(cmb_currency.SelectedValue.ToString());
                    empsaldatabean.Paymentmode = cocmb_paymentmde.Text;

                    if (cocmb_paymentmde.Text == "Bank Transfer")
                    {
                        empsaldatabean.Bankpk = int.Parse(cmb_bank.SelectedValue.ToString());
                        empsaldatabean.Accountnum = txtaccountnum.Text.ToString();
                    }
                    else
                    {
                        empsaldatabean.Bankpk = 0;
                        empsaldatabean.Accountnum = "0";
                    }

                     
                    empsaldatabean.Applicablesalcomponent = dTable;
                    insertemployeeperk();
                    reg.insertemployesalarydata(empsaldatabean);
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    //   this.Close();

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
        /// validates the controls
        /// </summary>
        /// <returns></returns>
        public Boolean validationcontrolforsal()
        {
            Boolean sucess = false;

            if (cmb_EmpCode.Text == null || cmb_EmpCode.Text.Trim() == "")
            {
                lblStatus.Text = "Enter EmpCode";
                cmb_EmpCode.Focus();
                cmb_EmpCode.Visible = true;

            }


            else if (txt_appsal.Text == null || txt_appsal.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Approved Salary";
                txt_appsal.Focus();
                txt_appsal.Visible = true;

            }
            else if (cmb_currency.Text == null || cmb_currency.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Currency";
                cmb_currency.Focus();
                cmb_currency.Visible = true;

            }
            else if (cocmb_paymentmde.Text == null || cocmb_paymentmde.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Payment Mode";
                cocmb_paymentmde.Focus();


            }
            else if (cocmb_paymentmde.Text == "Bank Transfer" && txtaccountnum.Text == "")
            {
                lblStatus.Text = "Enter Account Details";
                cocmb_paymentmde.Focus();
            }
            if (cocmb_paymentmde.Text == "Bank Transfer" && reg.IfDuplicateAccountfound(empid, txtaccountnum.Text))
            {
                MessageBox.Show("AccountnumberAlready Exist");
            }
            else
            {
                sucess = true;
            }


            return sucess;
        }

        private void roundedGroupBox15_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txt_age.Text = getAgeInYears().ToString();
        }


        public int getAgeInYears()
        {
            TimeSpan tsAge = DateTime.Now.Subtract(Dtp_dateofBirth1.Value.Date);

            return new DateTime(tsAge.Ticks).Year - 1;
        }

//////////////////////////////////////////Photographs-Employeee//////////////////////////////////////////////////


/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>




        public void displayemployeephoto()
        {
            if (empid != 0)
            {
                pct_emp.Image = new Bitmap(reg.getEmployeehotographLocation(empid));
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = System.IO.Path.GetFullPath(open.FileName);
                pct_emp.Image = new Bitmap(open.FileName);
                this.pct_emp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            }



        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (empid != 0)
            {
                String filename = Program.OurImagelocation+"//"+ empid.ToString() +".jpeg";
                this.pct_emp.Image.Save(filename, ImageFormat.Jpeg);


                reg.insertPhotograph(filename, empid);
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            }
            else
            {
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Employee not selected");

            }
        }

       




        public void insertemployeeperk()
        {

            if (tbl_perk.Rows.Count > 0)
            {
                for (int i = 0; i < tbl_perk.Rows.Count-1; i++)
                {
                    int  perkpk = 0;
                    float amount = 0;
                    float taxablepercent = 0;
                    float taxableamount = 0;

                    perkpk = int.Parse(tbl_perk.Rows[i].Cells[0].Value .ToString());
                    taxablepercent = float.Parse(tbl_perk.Rows[i].Cells[3].Value.ToString());
                   
                    amount = float.Parse(tbl_perk.Rows[i].Cells[4].Value.ToString());

                    taxableamount = (amount / 100) * taxablepercent;
                    reg.insertperk(empid, perkpk, amount, taxableamount);
                }
            }

        }



       



        public void fillperk()
        {
            try
            {
                DataTable dt = prktrans.GetAllPerkandAmount();
                tbl_perk.RowCount = 1;
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tbl_perk.Rows.Add();

                            tbl_perk.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                            tbl_perk.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                            tbl_perk.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                            tbl_perk.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                            tbl_perk.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();



                        }
                    }
                }
            }
            catch (Exception EXP)
            {

                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(EXP);

            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //{
            //    pnl_perk.Visible = true;
            //    fillperk();
            //}
            //else
            //{
            //    pnl_perk.Visible = false;
            //    fillperk();
            //}
            pnl_perk.Visible = checkBox1.Checked;
            
        }

        private void EmployeContactForm_Load_1(object sender, EventArgs e)
        {

        }

        private void txt_nhif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar)     // Allowing only any letter OR Digit

           || e.KeyChar == '\b')                 // Allowing BackSpace character
            {

                e.Handled = false;

            }

            else
            {

                e.Handled = true;

            }
        }

        private void txt_nssf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar)     // Allowing only any letter OR Digit

           || e.KeyChar == '\b')                 // Allowing BackSpace character
            {

                e.Handled = false;

            }

            else
            {

                e.Handled = true;

            }
        }

        private void txt_incometaxnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar)     // Allowing only any letter OR Digit

           || e.KeyChar == '\b')                 // Allowing BackSpace character
            {

                e.Handled = false;

            }

            else
            {

                e.Handled = true;

            }
        }

        private void textNid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar)     // Allowing only any letter OR Digit

           || e.KeyChar == '\b')                 // Allowing BackSpace character
            {

                e.Handled = false;

            }

            else
            {

                e.Handled = true;

            }
        }

        private void textNidConfrm_Leave_1(object sender, EventArgs e)
        {
            if (textNidConfrm.Text != textNid.Text)
            {
                groupContact.Enabled = false;
                detailopanel.Enabled = false;
                textNidConfrm.Focus();
                label29.Visible = true;

            }
            else if (textNidConfrm.Text == textNid.Text)
            {
                label29.Visible = false;
                //Here We can write the code to check weather the NID is existing or not
                groupContact.Enabled = true;
                detailopanel.Enabled = true;
               
                textNid.ReadOnly = true;
               // prevoioustrack();
                comboGender.Focus();

            }
        }

        private void textpp_TextChanged(object sender, EventArgs e)
        {
            if(comboNation.Text.Trim ()!="Kenya")
            {
                textNid.Text = textpp.Text;
            }
        }
    }
}
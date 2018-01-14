using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


using System.Threading;
namespace ATCHRM.Attendance
{
    public partial class EmpInoutExceptionfrm : Form
    {
        Transactions.CompanyBranchTransactions cmptransaction = null;
        Transactions.DesignationTransaction dsgtrans = null;
        Transactions.DepartmentTransaction depttrans = null;
        Transactions.EmployeeRegTransaction empregtrans = null;
        Transactions.Adjuster.AdjusterTranscation adjstrtrans = null;
        Datalayer.AdjusterDatabean adjstbean = null;
        int deptchangeflag = 0;
        int desgflag = 0;
        int lctnflg = 0;
        int empflg = 0;
        Transactions.DataExporter DTPEXPTR = null;
        DataTable empsaldata = null;
        DataTable emppayroll2data = null;
        public EmpInoutExceptionfrm()
        {
            InitializeComponent();
            depttrans = new Transactions.DepartmentTransaction();
            cmptransaction = new Transactions.CompanyBranchTransactions();
            dsgtrans = new Transactions.DesignationTransaction();
            empregtrans = new Transactions.EmployeeRegTransaction();
            adjstrtrans = new Transactions.Adjuster.AdjusterTranscation();
            makeDatatable();
            // CurrencyDataController.DisableThreadingProblemsDetection = true;
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
        /// <summary>
        /// loads the department
        /// </summary>
        public void DeptcomboLoad()
        {
            DataTable dt = depttrans.getDeptName();
            cmb_dept.DataSource = dt;
            cmb_dept.DisplayMember = "DepartmentName";
            cmb_dept.ValueMember = "DepartmentPK";
        }

        /// <summary>
        /// get all the designation
        /// against a given dept
        /// </summary>
        public void getallDesignation()
        {

            if (deptchangeflag != 0)
            {


                if (cmb_dept.SelectedValue != null)
                {


                    cmb_designation.DataSource = null;
                    DataTable dt = dsgtrans.getDesignationNameBYDept(int.Parse(cmb_dept.SelectedValue.ToString()));

                    cmb_designation.DisplayMember = "DESGN";
                    cmb_designation.ValueMember = "SL";
                    cmb_designation.DataSource = dt;
                }

            }
        }

        /// <summary>
        /// get the employee code of the persons
        /// </summary>
        /// <param name="branchlocation"></param>
        /// <param name="dept"></param>
        /// <param name="desg"></param>
        /// 
        int[] emp_id;
        public void employecodeload(int branchlocation, int dept, int desg)
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empregtrans.getEmpcode(branchlocation, dept, desg);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "empno";
            cmb_EmpCode.ValueMember = "empid";

            emp_id = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                emp_id[i] = Convert.ToInt32(dt.Rows[i][0]);
            }
        }

        /// <summary>
        ///restrict the acess to other loacation
        /// </summary>

        public void resrictacess()
        {
            try
            {
                if (lctnflg != 0)
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




        private void EmpInoutExceptionfrm_Load(object sender, EventArgs e)
        {
            locationListLoad();
            DeptcomboLoad();
        }

        private void cmb_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_location.Text == "" || cmb_location.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Branch location";

            }
            else if (cmb_dept.Text == "" || cmb_dept.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), 0, 0);
            }
            else if (cmb_designation.Text == "" || cmb_designation.Text.Trim() == "")
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), 0);
            }
            else
            {
                employecodeload(int.Parse(cmb_location.SelectedValue.ToString()), int.Parse(cmb_dept.SelectedValue.ToString()), int.Parse(cmb_designation.SelectedValue.ToString()));
            }
        }

        private void cmb_EmpCode_MouseClick(object sender, MouseEventArgs e)
        {
            empflg++;
        }

        private void cmb_dept_Click(object sender, EventArgs e)
        {

        }

        private void cmb_location_MouseClick(object sender, MouseEventArgs e)
        {

            lctnflg++;
        }

        private void cmb_designation_MouseClick(object sender, MouseEventArgs e)
        {
            desgflag++;
        }

        void Test()
        {
            try
            {
                DateTime dt_from = DateTime.MinValue;
                DateTime dt_to = DateTime.MinValue;

                if (cmb_location.InvokeRequired)
                    cmb_location.Invoke(new MethodInvoker(delegate
                    {
                        employecodeload(int.Parse(Convert.ToString(cmb_location.SelectedValue)), 0, 0);
                    }));

                if (dtp_from.InvokeRequired)
                {
                    dtp_from.Invoke(new MethodInvoker(delegate
                    {


                        dt_from = dtp_from.Value.Date;




                    }));

                    if (dtp_to.InvokeRequired)
                    {
                        dtp_to.Invoke(new MethodInvoker(delegate
                        {

                            dt_to = dtp_to.Value.Date;

                        }));
                    }

                }


                filldata(Program.LOCTNPK, dt_from, dt_to);

                getdurationdone();

            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }

        }
        DateTime Getdatetime(DateTimePicker pt)
        {
            DateTime st = DateTime.MinValue;
            if (pt.InvokeRequired)
            {
                pt.Invoke(new MethodInvoker(delegate
                {
                    st = pt.Value.Date;
                }));
            }
            else
            {
                st = pt.Value.Date;
            }
            return st;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_Synchronise.Enabled = false;
            DateTime dtfrom = dtp_from.Value.Date;
            DateTime dtTO = dtp_to.Value.Date;


            try
            {
                DateTime dt_from = DateTime.MinValue;
                DateTime dt_to = DateTime.MinValue;


                employecodeload(int.Parse(Convert.ToString(cmb_location.SelectedValue)), 0, 0);




                dt_from = dtp_from.Value.Date;







                dt_to = dtp_to.Value.Date;





                filldata(Program.LOCTNPK, dt_from, dt_to);

                getdurationdone();

            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }




            lblStatus.Text = tblNonAdjusterdata.Rows.Count.ToString();

            //try
            //{


            //            employecodeload(int.Parse(Convert.ToString(cmb_location.SelectedValue)), 0, 0);


            //    filldata(Program.LOCTNPK, dtp_from.Value.Date, dtp_to.Value.Date);

            //    getdurationdone();
            //    lblStatus.Text = tblNonAdjusterdata.Rows.Count.ToString();
            //}
            //catch (Exception exp)
            //{
            //    ErrorLogger er = new ErrorLogger();
            //    er.createErrorLog(exp);

            //    this.Dispose();
            //}








        }

        ///// <summary>
        ///// fill data orginal changed by roymon 
        ///// </summary>
        ///// <param name="branchlctnpk"></param>
        ///// <param name="fromdate"></param>
        ///// <param name="todate"></param>
        //public void filldata(int branchlctnpk, DateTime fromdate, DateTime todate)
        //{


        //    try
        //    {
        //        DataTable swipedata = adjstrtrans.GetNonAdjustedData(branchlctnpk, fromdate, todate);
        //        //DataTable swipedata = adjstrtrans.GetNonAdjustedDataforemployee(branchlctnpk, fromdate, todate, int.Parse(cmb_EmpCode.SelectedValue.ToString()));

        //        tblNonAdjusterdata.RowCount = 1;
        //        for (int i = 0; i < swipedata.Rows.Count; i++)
        //        {

        //            tblNonAdjusterdata.Rows.Add();
        //            tblNonAdjusterdata.Rows[i].Cells[0].Value = swipedata.Rows[i][0];

        //            tblNonAdjusterdata.Rows[i].Cells[1].Value = swipedata.Rows[i][1];
        //            tblNonAdjusterdata.Rows[i].Cells[2].Value = swipedata.Rows[i][2];
        //            tblNonAdjusterdata.Rows[i].Cells[3].Value = swipedata.Rows[i][3];
        //            tblNonAdjusterdata.Rows[i].Cells[4].Value = swipedata.Rows[i][4];
        //            tblNonAdjusterdata.Rows[i].Cells[5].Value = swipedata.Rows[i][5];
        //            tblNonAdjusterdata.Rows[i].Cells[6].Value = swipedata.Rows[i][6];

        //            tblNonAdjusterdata.Rows[i].Cells[7].Value = swipedata.Rows[i][7];
        //            tblNonAdjusterdata.Rows[i].Cells[8].Value = swipedata.Rows[i][8];
        //            tblNonAdjusterdata.Rows[i].Cells[9].Value = swipedata.Rows[i][9];

        //            tblNonAdjusterdata.Rows[i].Cells[10].Value = swipedata.Rows[i][10];

        //            tblNonAdjusterdata.Rows[i].Cells[11].Value = swipedata.Rows[i][11];
        //            tblNonAdjusterdata.Rows[i].Cells[12].Value = 0;
        //            tblNonAdjusterdata.Rows[i].Cells[13].Value = swipedata.Rows[i][12];
        //            tblNonAdjusterdata.Rows[i].Cells[14].Value = swipedata.Rows[i][13];

        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }

        //}




        public void filldata(int branchlctnpk, DateTime fromdate, DateTime todate)
        {


            try
            {
                DataTable swipedata = adjstrtrans.GetNonAdjustedData(branchlctnpk, fromdate, todate);
                //DataTable swipedata = adjstrtrans.GetNonAdjustedDataforemployee(branchlctnpk, fromdate, todate, int.Parse(cmb_EmpCode.SelectedValue.ToString()));

                //   progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Maximum = (swipedata.Rows.Count == 0 ? 0 : swipedata.Rows.Count - 1); }));
                foreach (DataColumn col in swipedata.Columns)
                {
                    col.ReadOnly = false;
                }
                tblNonAdjusterdata.DataSource = swipedata;

                //changed by sreenath
                //tblNonAdjusterdata.RowCount = 1;
                //for (int i = 0; i < swipedata.Rows.Count; i++)
                //{
                //    tblNonAdjusterdata.Invoke(new MethodInvoker(delegate { tblNonAdjusterdata.Rows.Add(new DataGridViewRow()); }));

                //    progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value =i; }));
                //    tblNonAdjusterdata.Rows[i].Cells[0].Value = swipedata.Rows[i][0];

                //    tblNonAdjusterdata.Rows[i].Cells[1].Value = swipedata.Rows[i][1];
                //    tblNonAdjusterdata.Rows[i].Cells[2].Value = swipedata.Rows[i][2];
                //    tblNonAdjusterdata.Rows[i].Cells[3].Value = swipedata.Rows[i][3];
                //    tblNonAdjusterdata.Rows[i].Cells[4].Value = swipedata.Rows[i][4];
                //    tblNonAdjusterdata.Rows[i].Cells[5].Value = swipedata.Rows[i][5];
                //    tblNonAdjusterdata.Rows[i].Cells[6].Value = swipedata.Rows[i][6];

                //    tblNonAdjusterdata.Rows[i].Cells[7].Value = swipedata.Rows[i][7];
                //    tblNonAdjusterdata.Rows[i].Cells[8].Value = swipedata.Rows[i][8];
                //    tblNonAdjusterdata.Rows[i].Cells[9].Value = swipedata.Rows[i][9];

                //    tblNonAdjusterdata.Rows[i].Cells[10].Value = swipedata.Rows[i][10];

                //    tblNonAdjusterdata.Rows[i].Cells[11].Value = swipedata.Rows[i][11];
                //    tblNonAdjusterdata.Rows[i].Cells[12].Value = 0;
                //    tblNonAdjusterdata.Rows[i].Cells[13].Value = swipedata.Rows[i][12];
                //    tblNonAdjusterdata.Rows[i].Cells[14].Value = swipedata.Rows[i][13];

                //}
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }

        }

        /// <summary>
        /// used to calculate the duration and the difference between maximum allowed and the worked duration
        /// </summary>
        /// <param name="i"></param>
        public void calculateduration(int i)
        {
            DateTime a = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());

            DateTime b = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString());

            tblNonAdjusterdata.Rows[i].Cells[12].Value = Math.Truncate(b.Subtract(a).TotalMinutes);
            double difference = Math.Truncate(float.Parse(tblNonAdjusterdata.Rows[i].Cells[12].Value.ToString()) - float.Parse(tblNonAdjusterdata.Rows[i].Cells[14].Value.ToString()));


            tblNonAdjusterdata.Rows[i].Cells[15].Value = Math.Truncate(float.Parse(tblNonAdjusterdata.Rows[i].Cells[12].Value.ToString()) - float.Parse(tblNonAdjusterdata.Rows[i].Cells[14].Value.ToString()));

        }




        public void synchroniseInandOuttime(int i)
        {
            if (DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString()) >= DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString()))
            {
                tblNonAdjusterdata.Rows[i].Cells[6].Value = tblNonAdjusterdata.Rows[i].Cells[5].Value;
            }
            else
            {
                tblNonAdjusterdata.Rows[i].Cells[5].Value = tblNonAdjusterdata.Rows[i].Cells[6].Value;
            }
        }
        public void getdurationdone()
        {
            string[] halfdayleaves = { "SHD", "HPL" };
         string[] leaves = { "PL", "SL", "UPL", "UPL", "ML" };
            String[] otandpresent = { "P", "OT", "OT1.5", "UOT" };


           

            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {



                 String instatus = tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim() ;
                 String Outstatus = tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim();




                //if booth are A
                 if (instatus == "A" && Outstatus == "A")
                {
                    synchroniseInandOuttime(i);

                    calculateduration(i);
                }
               


                    // if both are not same status
                 else if (instatus != Outstatus)
                {
                    //if instatus is A and outstatus is different
                    if (instatus == "A")
                    {
                        //if instatus is A and Outstatus is 
                        if (instatus == "A" && leaves.Contains(Outstatus))
                        {
                            synchroniseInandOuttime(i);

                            calculateduration(i);
                        }
                        
                        if (tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString().Trim() == "01/01/2000 00:00:00")
                        {
                            //// if the outstatus is any halfdays set the intime also to the same
                            if (halfdayleaves.Contains(Outstatus ))
                            {
                                tblNonAdjusterdata.Rows[i].Cells[5].Value = tblNonAdjusterdata.Rows[i].Cells[6].Value;



                            }


                                //if outstatus is a leave set the intime also the same
                            else if (leaves.Contains(Outstatus))
                            {
                                tblNonAdjusterdata.Rows[i].Cells[5].Value = tblNonAdjusterdata.Rows[i].Cells[6].Value;

                                calculateduration(i);



                            }
                                //if outstatus=LH
                            else if (Outstatus=="LH")
                            {
                                double outvalue = double.Parse(tblNonAdjusterdata.Rows[i].Cells[10].Value.ToString());
                                DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString());

                                TimeSpan losttime = new TimeSpan(0, int.Parse(outvalue.ToString()), 0);
                                DateTime swipeout = outime.Add(losttime);
                                double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());
                                if (sahiftduration > 0)
                                {
                                    double halfdaytime = Math.Truncate(sahiftduration / 2);
                                    TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                    tblNonAdjusterdata.Rows[i].Cells[5].Value = outime.Subtract(t1);
                                    calculateduration(i);
                                }

                            }
                                //if ouutstatus is P or OT
                            else if (otandpresent.Contains(Outstatus))
                            {
                                //if outstatus is P and instatus is A
                                if (Outstatus == "P")
                                {


                                    double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());

                                    if (sahiftduration > 0)
                                    {
                                        double outvalue = double.Parse(tblNonAdjusterdata.Rows[i].Cells[10].Value.ToString());
                                        DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString());
                                        double halfdaytime = Math.Truncate(sahiftduration / 2);
                                        TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                        tblNonAdjusterdata.Rows[i].Cells[5].Value = outime.Subtract(t1);
                                        calculateduration(i);



                                    }
                                }
                                    //if its OT
                                else
                                {
                                    double outvalue = double.Parse(tblNonAdjusterdata.Rows[i].Cells[10].Value.ToString());
                                    DateTime outime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString());
                                    double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());
                                    if (sahiftduration > 0)
                                    {
                                        TimeSpan t2 = new TimeSpan(0, int.Parse(outvalue.ToString()), 0);
                                        DateTime swipeout = outime.Subtract(t2);
                                        double halfdaytime = Math.Truncate(sahiftduration / 2);
                                        TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                        tblNonAdjusterdata.Rows[i].Cells[5].Value = swipeout.Subtract(t1);


                                        calculateduration(i);
                                    }
                                }
                            }

                        }

                    }

                        //if outstatus is A
                    else if (Outstatus == "A")
                    {
                        if (tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString().Trim() == "01/01/2000 00:00:00")
                        {
                            //// if the INSTATUS is any halfdays set the intime also to the same
                            if (halfdayleaves.Contains(instatus ))
                            {
                                tblNonAdjusterdata.Rows[i].Cells[6].Value = tblNonAdjusterdata.Rows[i].Cells[5].Value;

                            }
                            //if instatus is P
                            if (instatus  == "P")
                            {
                                double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());
                                if (sahiftduration > 0)
                                {
                                    DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());
                                    double halfdaytime = Math.Truncate(sahiftduration / 2);
                                    TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                    tblNonAdjusterdata.Rows[i].Cells[6].Value = intime.Add(t1);
                                    calculateduration(i);
                                }
                                
                            }
                            if (instatus  == "LH")
                            {
                                double sahiftduration = double.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());

                                if (sahiftduration > 0)
                                {
                                    DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());
                                    double halfdaytime = Math.Truncate(sahiftduration / 2);
                                    TimeSpan t1 = new TimeSpan(0, int.Parse(halfdaytime.ToString()), 0);
                                    tblNonAdjusterdata.Rows[i].Cells[6].Value = intime.Add(t1);
                                    calculateduration(i);
                                }

                            }
                        }


                    }
                }




                if (int.Parse(tblNonAdjusterdata.Rows[i].Cells[15].Value.ToString()) > 0)
                {
                    this.tblNonAdjusterdata.Rows[i].Cells[15].Style.BackColor = Color.BurlyWood;
                }



            }
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            getallDesignation();

        }

        private void cmb_dept_MouseClick(object sender, MouseEventArgs e)
        {
            deptchangeflag++;
        }



        public void getotdata(int a)
        {
            int ot = 0;
            int offot = 0;
            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {


                if (tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim() == "OT1.5")
                {
                    ot = ot + int.Parse(tblNonAdjusterdata.Rows[i].Cells[10].Value.ToString());
                }
                else if (tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim() == "OT2.0")
                {
                    offot = offot + int.Parse(tblNonAdjusterdata.Rows[i].Cells[10].Value.ToString());
                }
            }

            if (a == 1)
            {
                lblot.Text = ot.ToString();
                lbloffot.Text = offot.ToString();
            }
            else
            {
                adjstedot.Text = ot.ToString();
                adjstedoffot.Text = offot.ToString();
            }


        }

        public DateTime adjustEarlySwipe(DateTime dt, string stype)
        {
            int dur = 0;
            DateTime newadjstedtime;
            if (stype == "In")
            {
                dur = -25;

                DateTime allowedduration = dt;
                //      DateTime allowedduration = Shifttime.AddMinutes(-30);

                DateTime Shifttime = allowedduration.AddMinutes(dur);
                TimeSpan timeSpan = allowedduration - Shifttime;
                var randomTest = new Random();
                TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                newadjstedtime = allowedduration - newSpan;
            }
            else
            {
                dur = 25;

                DateTime allowedduration = dt;
                //      DateTime allowedduration = Shifttime.AddMinutes(-30);

                DateTime Shifttime = allowedduration.AddMinutes(dur);
                TimeSpan timeSpan = Shifttime - allowedduration;
                var randomTest = new Random();
                TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                newadjstedtime = allowedduration + newSpan;

            }
            return newadjstedtime;

        }

        int adjustrid = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            // int id = GridViewmModels.ClsDatabase.Main_id("adjusterid", "AdjusterMaster_tbl", "");
            try
            {
                int id = 0;
                adjustrid = id;
                adjstbean = new Datalayer.AdjusterDatabean();

                adjstbean.BranchlctnPk = int.Parse(cmb_location.SelectedValue.ToString());
                adjstbean.Fromdate = dtp_from.Value.Date;
                adjstbean.Todate = dtp_to.Value.Date;
                adjstbean.Aid = id;
                if (!adjstrtrans.checkifactiondone(dtp_from.Value.Date, dtp_to.Value.Date))
                {
                    id = adjstrtrans.insertAdjusterdata(adjstbean);
                    adjustrid = id;

                }
                else
                {

                    ATCHRM.Controls.ATCHRMMessagebox.Show("Adjuster for these date already Done");
                    return;
                }
                cropValue();
                getdurationdone();
                int lh = 0, ot = 0, ofot = 0, lhr = 0, uot = 0;

                for (int i = 0; i < tblNonAdjusterdata.Rows.Count - 1; i++)
                {
                    lh = 0; lhr = 0; ot = 0; uot = 0; ofot = 0;

                    DateTime inst = Convert.ToDateTime(tblNonAdjusterdata.Rows[i].Cells[5].Value);
                    DateTime outst = Convert.ToDateTime(tblNonAdjusterdata.Rows[i].Cells[6].Value);
                    if (tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim() == "P")
                    {
                        inst = adjustEarlySwipe(Convert.ToDateTime(tblNonAdjusterdata.Rows[i].Cells[5].Value), "In");
                    }
                    if (tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim() == "P")
                    {
                        outst = adjustEarlySwipe(Convert.ToDateTime(tblNonAdjusterdata.Rows[i].Cells[6].Value), "Out");
                    }


                    int iddet = GridViewmModels.ClsDatabase.Main_id("adjuster_det_id", "Adjuster_details", "adjuster_id=" + id + "");
                    GridViewmModels.ClsDatabase.Set_Data(" insert into Adjuster_Details(Adjuster_id, Adjuster_Det_Id, Swipe_Id, Emp_Id,"
                    + " Swipe_Date, Week_Day, Day_Status, In_Time, Out_Time, IN_Status, Out_Status, in_Value, Out_Value, Adjust_Stat, "
                   + " Adjust_Dura, Shift_Dura, Allow_Dura, Value_Diff) values(" + id + "," + iddet + "," + tblNonAdjusterdata.Rows[i].Cells[0].Value + ","
                    + " " + tblNonAdjusterdata.Rows[i].Cells[1].Value + ",'" + Convert.ToDateTime(tblNonAdjusterdata.Rows[i].Cells[2].Value).ToString("dd/MMM/yyyy HH:mm:ss tt").Trim() + "',"
                    + " '" + Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[3].Value).Trim() + "','" + Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[4].Value).Trim() + "',"
                    + " '" + inst.ToString("dd/MMM/yyyy HH:mm:ss tt") + "',"
                    + " '" + outst.ToString("dd/MMM/yyyy HH:mm:ss tt") + "',"
                    + " '" + Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[7].Value).Trim() + "','" + Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[8].Value).Trim() + "',"
                    + " " + tblNonAdjusterdata.Rows[i].Cells[9].Value + "," + tblNonAdjusterdata.Rows[i].Cells[10].Value + ","
                    + " '" + Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[11].Value).Trim() + "'," + tblNonAdjusterdata.Rows[i].Cells[12].Value + ","
                    + " " + tblNonAdjusterdata.Rows[i].Cells[13].Value + "," + tblNonAdjusterdata.Rows[i].Cells[14].Value + ","
                    + " " + Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[15].Value).Trim() + ")");
                    if ((Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[7].Value).Trim() == "LH"))
                    {
                        lh = Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[9].Value);
                    }
                    if ((Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[8].Value).Trim() == "LH"))
                    {
                        lh = Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[10].Value);
                    }
                    if ((Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[7].Value).Trim() == "LH") && (Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[8].Value).Trim() == "LH"))
                    {
                        lh = Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[9].Value) + Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[10].Value);
                    }

                    if ((Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[8].Value).Trim() == "OT1.5") || (tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim() == "OT"))
                    {
                        ot = Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[10].Value);
                    }
                    if ((Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[8].Value).Trim() == "OT2.0"))
                    {
                        ofot = Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[10].Value);
                    }

                    if ((Convert.ToString(tblNonAdjusterdata.Rows[i].Cells[8].Value).Trim() == "UOT"))
                    {
                        uot = Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[10].Value);
                    }

                    Final_databank(Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[1].Value), ot, uot, ofot, lh, lhr, 1000);
                    Adjuster_Bal(Convert.ToInt32(tblNonAdjusterdata.Rows[i].Cells[1].Value), 0, 0, 0, id);
                }
                ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            }
            catch (Exception exp)
            {
                ErrorLogger er = new ErrorLogger();
                er.createErrorLog(exp);

                this.Dispose();
            }
        }
        public void cropValue()
        {
            //create an emplyee araaylist
            ArrayList emaarry = new ArrayList();


            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {

                int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString());
                if (emaarry.Contains(empid))
                {
                }
                else
                {
                    //add the employee to arraylist
                    emaarry.Add(empid);
                    actiontake(empid);
                }


            }
        }




        public void makeDatatable()
        {
            empsaldata = new DataTable();
            emppayroll2data = new DataTable();
            DataColumn empid = new DataColumn("empid", typeof(System.Int32));



            DataColumn OffOT = new DataColumn("OffOT", typeof(System.Int32));

            DataColumn OT = new DataColumn("OT", typeof(DateTime));

            DataColumn LHR = new DataColumn("LHR", typeof(String));

            DataColumn UOT = new DataColumn("UOT", typeof(String));


            DataColumn LH = new DataColumn("LH", typeof(System.Int32));

            DataColumn Adjusterid = new DataColumn("Adjusterid", typeof(System.Int32));




            empsaldata.Columns.Add(empid);
            empsaldata.Columns.Add(OffOT);
            empsaldata.Columns.Add(OT);

            empsaldata.Columns.Add(LHR);
            empsaldata.Columns.Add(UOT);
            empsaldata.Columns.Add(LH);
            empsaldata.Columns.Add(Adjusterid);


            emppayroll2data = empsaldata.Clone();


        }
        //14 Apr
        int[] itrempid = new int[100];
        int[] itrrowid = new int[100];
        int[] itrAvaildur = new int[100];
        int[] itrOFFAvaildur = new int[100];
        int[] itremOtDur = new int[100];
        string[] ITRoT = new string[100];
        int[] itremOFFDur = new int[100];
        //14 Apr

        public void actiontake(int empid)
        {


            int OTDuration = 0;
            int OFFOTDuration = 0;



            // for(int kl=0;kl<emp_id.Length;kl++)
            // {
            emp_id[0] = empid;
            int kl = 0;
            int indx = 0;
            ITRoT = new string[tblNonAdjusterdata.Rows.Count];
            itrempid = new int[tblNonAdjusterdata.Rows.Count];
            itrrowid = new int[tblNonAdjusterdata.Rows.Count];
            itrAvaildur = new int[tblNonAdjusterdata.Rows.Count];
            itremOtDur = new int[tblNonAdjusterdata.Rows.Count];
            itremOFFDur = new int[tblNonAdjusterdata.Rows.Count];
            itrOFFAvaildur = new int[tblNonAdjusterdata.Rows.Count];

            for (int j = 0; j < tblNonAdjusterdata.RowCount - 1; j++)
            {
                // iterates through the table rows
                itrempid[indx] = Convert.ToInt32(tblNonAdjusterdata.Rows[j].Cells[1].Value);
                int availabledifference = (int)Math.Ceiling(float.Parse(tblNonAdjusterdata.Rows[j].Cells[15].Value.ToString()));

                if (availabledifference > 0)
                {
                    if (((tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "OT1.5") || (tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "OT")) && (Convert.ToInt32(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[1].Value)) == emp_id[kl]))
                    {

                        OTDuration = OTDuration + availabledifference;
                        DateTime newswipeoutime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes((0 - availabledifference));
                        tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                        tblNonAdjusterdata.Rows[j].Cells[6].Value = newswipeoutime;
                        tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) - availabledifference;
                        tblNonAdjusterdata.Rows[j].Cells[15].ReadOnly = false;
                        tblNonAdjusterdata.Rows[j].Cells[15].Value = "0";
                        itremOtDur[indx] = availabledifference;
                        //  itremOtDur[indx] = OTDuration;
                        itrAvaildur[indx] = availabledifference;
                        ITRoT[indx] = "OT1.5";
                    }
                    else if ((tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "OT2.0") && (Convert.ToInt32(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[1].Value).Trim()) == emp_id[kl]))
                    {

                        OFFOTDuration = OFFOTDuration + availabledifference;
                        DateTime newswipeoutime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes((0 - availabledifference));
                        tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT2.0";
                        tblNonAdjusterdata.Rows[j].Cells[6].Value = newswipeoutime;
                        tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) - availabledifference;
                        tblNonAdjusterdata.Rows[j].Cells[15].ReadOnly = false;
                        tblNonAdjusterdata.Rows[j].Cells[15].Value = "0";

                        //itremOFFDur[indx] = OFFOTDuration;
                        itremOFFDur[indx] = availabledifference;
                        itrOFFAvaildur[indx] = availabledifference;
                        ITRoT[indx] = "OT2.0";
                    }

                    itrrowid[indx] = j;

                }
                indx = indx + 1;
            }

            Iteration_Table(empid);


            //function for 
            //}
        }

        private void Adjuster_Bal(int empid, int otdur, int avldur, int ofotdur, int id)
        {
            // int id = GridViewmModels.ClsDatabase.Main_id("adjusterid", "AdjusterMaster_tbl", "");
            int iddet = GridViewmModels.ClsDatabase.Main_id("Adjust_det_Id", "Adjuster_Cropped", "Adjust_Id=" + id + "");
            DataSet ds = GridViewmModels.ClsDatabase.Get_Data("select * from Adjuster_Cropped where Adjust_Id=" + id + " AND emp_id=" + empid + "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //GridViewmModels.ClsDatabase.Set_Data("update Adjuster_Cropped set ot_dura=ot_dura+" + otdur + ","
                //+ " offot_dur=offot_dur+" + ofotdur + ",avail_bal=avail_bal+" + avldur + " "
                //+ " where emp_id=" + empid + " and emp_loc=" + Convert.ToInt32(cmb_location.SelectedValue) + "");


                GridViewmModels.ClsDatabase.Set_Data("update Adjuster_Cropped set ot_dura=ot_dura+" + otdur + ","
                + " offot_dur=offot_dur+" + ofotdur + ",avail_bal=avail_bal+" + avldur + " "
                + " where emp_id=" + empid + " and Adjust_Id=" + id + "");
            }
            else
            {
                if (id > 0)
                {
                    GridViewmModels.ClsDatabase.Set_Data("insert into Adjuster_Cropped ( Adjust_Id,Adjust_det_Id,emp_id,emp_loc,adjust_date,ot_dura,"
                   + " offot_dur,avail_bal)"
                   + " values(" + id + "," + iddet + "," + empid + "," + Convert.ToInt32(cmb_location.SelectedValue) + ""
                   + " ,'" + Convert.ToDateTime(dtp_to.Value).ToString("dd/MMM/yyyy HH:mm:ss tt") + "'," + otdur + "," + ofotdur + "," + avldur + ")");
                }
            }

        }

        private void Final_databank(int empid, int otdur, int uot, int ofotdur, int lh, int lhr, int adjid)
        {
            // int id = GridViewmModels.ClsDatabase.Main_id("adjusterid", "AdjusterMaster_tbl", "");

            DataSet ds = GridViewmModels.ClsDatabase.Get_Data("select * from FinalEmployeeDuty_tbl where Adjust_Id=" + adjid + " AND empid=" + empid + "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridViewmModels.ClsDatabase.Set_Data("update FinalEmployeeDuty_tbl set ot=ot+" + otdur + ","
                + " offot=offot+" + ofotdur + ",uot=uot+" + uot + ",lh=lh+" + lh + ",lhr=lhr+" + lhr + " "
                + " where empid=" + empid + "");
            }
            else
            {
                if (adjid > 0)
                {
                    GridViewmModels.ClsDatabase.Set_Data("insert into FinalEmployeeDuty_tbl ( Adjust_Id,empid,ot,"
                   + " offot,uot,lh,lhr)"
                   + " values(" + adjid + "," + empid + "," + otdur + "," + ofotdur + "," + uot + ""
                   + " ," + lh + "," + lhr + ")");
                }
            }

        }
        private void btn_exportExcel_Click(object sender, EventArgs e)
        {

            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.exporttoexcel(this.tblNonAdjusterdata);
        }

        private void tblNonAdjusterdata_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {

                    getdurationdone();
                }
            }
            catch (Exception)
            {


            }
        }

        private void Iteration_Clean(int empid)
        {
            int OTDuration = 0;
            int OFFOTDuration = 0;

            int avldiff = 0;
            for (int j = 0; j < tblNonAdjusterdata.RowCount - 1; j++)
            {
                // iterates through the table rows
                string itrvals = Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[15].Value);
                int availabledifference = 0;
                if (itrvals != "")
                {
                    availabledifference = (int)Math.Ceiling(float.Parse(itrvals));
                }
                if (availabledifference > 0)
                {
                    if ((Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[8].Value).Trim() == "OT1.5") && (Convert.ToInt32(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[1].Value).Trim()) == empid))
                    {
                        OTDuration = OTDuration + availabledifference;
                        DateTime newswipeoutime = DateTime.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[6].Value)).AddMinutes((0 - availabledifference));
                        tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                        tblNonAdjusterdata.Rows[j].Cells[6].Value = newswipeoutime;
                        tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[10].Value)) - availabledifference;
                        tblNonAdjusterdata.Rows[j].Cells[15].Value = "0";

                    }
                    else if ((Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[8].Value).Trim() == "OT2.0") && (Convert.ToInt32(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[1].Value).Trim()) == empid))
                    {
                        OFFOTDuration = OFFOTDuration + availabledifference;
                        DateTime newswipeoutime = DateTime.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[6].Value)).AddMinutes((0 - availabledifference));
                        tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT2.0";
                        tblNonAdjusterdata.Rows[j].Cells[6].Value = newswipeoutime;
                        tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[10].Value)) - availabledifference;
                        tblNonAdjusterdata.Rows[j].Cells[15].Value = "0";

                    }
                }
                else
                {
                    if ((Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[7].Value).Trim() != "LH"))
                    {
                        if ((Convert.ToInt32(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[1].Value).Trim()) == empid) && (Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[8].Value).Trim() == "P" || Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[8].Value).Trim() == "OT1.5"))
                        {

                            if (OTDuration > 0)
                            {


                                if ((OTDuration - Math.Abs(availabledifference)) > 0)
                                {
                                    OTDuration = OTDuration - Math.Abs(availabledifference);

                                    DateTime newtime = DateTime.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[6].Value)).AddMinutes(Math.Abs(availabledifference));

                                    tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                                    tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                    tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[10].Value)) + Math.Abs(availabledifference);

                                }
                                else
                                {
                                    DateTime newtime = DateTime.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[6].Value)).AddMinutes(OTDuration);
                                    tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                                    tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                    tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[10].Value)) + OTDuration;
                                    OTDuration = 0;
                                }

                            }
                        }

                    }

                    else if (tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "OT2.0")
                    {


                        if (OFFOTDuration > 0)
                        {


                            if ((OFFOTDuration - Math.Abs(availabledifference)) > 0)
                            {

                                OFFOTDuration = OFFOTDuration - Math.Abs(availabledifference);

                                DateTime newtime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes(Math.Abs(availabledifference));

                                tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                                tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) + Math.Abs(availabledifference);

                            }
                            else
                            {

                                DateTime newtime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes(OFFOTDuration);
                                tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                                tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) + OFFOTDuration;
                                OFFOTDuration = 0;

                            }




                        }

                    }


                }

            }
            Adjuster_Bal(empid, OTDuration, avldiff, OFFOTDuration, adjustrid);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            getotdata(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getotdata(2);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sg = "";
            for (int i = 0; i < itrrowid.Length; i++)
            {
                sg = sg + "-" + itrempid[i];
            }
            ATCHRM.Controls.ATCHRMMessagebox.Show(sg);
        }

        private int oFFotDura()
        {
            int Ofotdur = 0;
            for (int i = 0; i < itremOFFDur.Length; i++)
            {
                if (itremOFFDur[i] > 0)
                {
                    Ofotdur = itremOFFDur[i];
                    itremOFFDur[i] = 0;
                    i = itremOFFDur.Length;
                }
            }

            return Ofotdur;
        }


        private int otDura()
        {
            int otdur = 0;
            for (int i = 0; i < itrrowid.Length; i++)
            {
                if (itremOtDur[i] > 0)
                {
                    otdur = itremOtDur[i];
                    itremOtDur[i] = 0;
                    i = itrrowid.Length;
                }
            }

            return otdur;
        }
        private int Avail_dura()
        {
            int otdur = 0;
            for (int i = 0; i < itrrowid.Length; i++)
            {
                if (itrAvaildur[i] > 0)
                {
                    otdur = itrAvaildur[i];
                    itrAvaildur[i] = 0;
                    i = itrrowid.Length;
                }
            }

            return otdur;
        }

        private int OFFAvail_dura()
        {
            int otdur = 0;
            for (int i = 0; i < itrrowid.Length; i++)
            {
                if (itrOFFAvaildur[i] > 0)
                {
                    otdur = itrOFFAvaildur[i];
                    itrOFFAvaildur[i] = 0;
                    i = itrrowid.Length;
                }
            }

            return otdur;
        }

        private void Iteration_Table(int empid)
        {
            int OTDuration = 0;
            int OFFOTDuration = 0;

            int availabledifference = 0;

            for (int j = 0; j < tblNonAdjusterdata.Rows.Count - 1; j++)
            {
                if (Convert.ToString(tblNonAdjusterdata.Rows[j].Cells[7].Value).Trim() != "LH")
                {
                    if ((Convert.ToInt32(tblNonAdjusterdata.Rows[j].Cells[1].Value) == empid) && ((tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "P" || tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "OT1.5") || (tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "OT")))
                    {
                        OTDuration = otDura();
                        availabledifference = Avail_dura();
                        if (OTDuration > 0)
                        {
                            if ((OTDuration - Math.Abs(availabledifference)) > 0)
                            {
                                OTDuration = OTDuration - Math.Abs(availabledifference);

                                DateTime newtime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes(Math.Abs(availabledifference));

                                tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                                tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) + Math.Abs(availabledifference);
                                if (Convert.ToInt32(tblNonAdjusterdata.Rows[j].Cells[15].Value) > 0)
                                {
                                    Iteration_Clean(empid);
                                }
                            }
                            else
                            {
                                DateTime newtime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes(OTDuration);
                                tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT1.5";
                                tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) + OTDuration;
                                OTDuration = 0;
                                if (Convert.ToInt32(tblNonAdjusterdata.Rows[j].Cells[15].Value) > 0)
                                {
                                    Iteration_Clean(empid);
                                }
                            }

                        }


                    }


                    else if ((Convert.ToInt32(tblNonAdjusterdata.Rows[j].Cells[1].Value) == empid) && ((tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "P" || tblNonAdjusterdata.Rows[j].Cells[8].Value.ToString().Trim() == "OT2.0")))
                    {

                        OFFOTDuration = oFFotDura();
                        availabledifference = OFFAvail_dura();

                        if (OFFOTDuration > 0)
                        {


                            if ((OFFOTDuration - Math.Abs(availabledifference)) > 0)
                            {

                                OFFOTDuration = OFFOTDuration - Math.Abs(availabledifference);

                                DateTime newtime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes(Math.Abs(availabledifference));

                                tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT2.0";
                                tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) + Math.Abs(availabledifference);
                                if (Convert.ToInt32(tblNonAdjusterdata.Rows[j].Cells[15].Value) > 0)
                                {
                                    Iteration_Clean(empid);
                                }
                            }
                            else
                            {

                                DateTime newtime = DateTime.Parse(tblNonAdjusterdata.Rows[j].Cells[6].Value.ToString()).AddMinutes(OFFOTDuration);
                                tblNonAdjusterdata.Rows[j].Cells[8].Value = "OT2.0";
                                tblNonAdjusterdata.Rows[j].Cells[6].Value = newtime;
                                tblNonAdjusterdata.Rows[j].Cells[10].Value = int.Parse(tblNonAdjusterdata.Rows[j].Cells[10].Value.ToString()) + OFFOTDuration;
                                OFFOTDuration = 0;
                                if (Convert.ToInt32(tblNonAdjusterdata.Rows[j].Cells[15].Value) > 0)
                                {
                                    Iteration_Clean(empid);
                                }
                            }


                        }
                    }
                }

            }

        }

        private void btn_approval_Click(object sender, EventArgs e)
        {

        }

        private void tblNonAdjusterdata_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
         //   ((DataTable)tblNonAdjusterdata.DataSource).AcceptChanges();
        }

        private void tblNonAdjusterdata_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
        //  ((DataTable)tblNonAdjusterdata.DataSource).AcceptChanges();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            correctingOTEntries();
        }




        /// <summary>
        /// if out state is OT and there is a mistake  this correct that
        /// </summary>
        public void correctingOTEntries()
        {
            int flag = 0;
            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {
                String outstatus = tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim();

                if (outstatus == "OT" || outstatus == "OT1.5")
                {
                    int outvalue = int.Parse(tblNonAdjusterdata.Rows[i].Cells[10].Value.ToString());
                    int shiftduration = int.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());


                    if (instatus == "LH")
                    {
                        int invalue = int.Parse(tblNonAdjusterdata.Rows[i].Cells[9].Value.ToString());
                        TimeSpan t1 = new TimeSpan(0, int.Parse(invalue.ToString()), 0);
                        DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());
                        intime = intime.Subtract(t1);
                        int totaldone = outvalue + shiftduration;
                        


                        TimeSpan t12 = new TimeSpan(0, int.Parse(totaldone.ToString()), 0);

                        tblNonAdjusterdata.Rows[i].Cells[6].Value = intime.Add(t12);

                        calculateduration(i);

                    }
                    else if (instatus == "A")
                    {

                    }
                    else if (instatus == "P" && (outstatus == "OT1.5"||outstatus == "OT"))
                    {
                        if (DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString()) > DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString()))
                        {


                            int totaldone = outvalue + shiftduration;
                            DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());


                            TimeSpan t1 = new TimeSpan(0, int.Parse(totaldone.ToString()), 0);

                            tblNonAdjusterdata.Rows[i].Cells[6].Value = intime.Add(t1);

                            calculateduration(i);
                            tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                            flag++;
                        }
                    }

                }


                correctNegativeenteries(i);
            }
          //  MessageBox.Show(flag.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public void correctNegativeenteries(int i)
        {

            if (DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString()) > DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString()))
            {

                String outstatus = tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim();

                if (instatus== "P")
                {
                    if (outstatus == "P")
                    {
                        int shiftduration = int.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());
                        DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());


                        TimeSpan t1 = new TimeSpan(0, int.Parse(shiftduration.ToString()), 0);
                        tblNonAdjusterdata.Rows[i].Cells[6].Value = intime.Add(t1);
                        tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Aqua  ;
                        calculateduration(i);

                    }
                    else if (outstatus == "LH")
                    {
                        int outvalue = int.Parse(tblNonAdjusterdata.Rows[i].Cells[10].Value.ToString());
                        int shiftduration = int.Parse(tblNonAdjusterdata.Rows[i].Cells[13].Value.ToString());
                        DateTime intime = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString());
                        
                        int totaldone = shiftduration - outvalue;



                        TimeSpan t12 = new TimeSpan(0, int.Parse(totaldone.ToString()), 0);

                        tblNonAdjusterdata.Rows[i].Cells[6].Value = intime.Add(t12);

                        tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Plum ;
                        calculateduration(i);

                    }
                }
                else if (instatus == "LH")
                {

                    if (outstatus == "P")
                    {


                    }






                }


            }







        }








        public Boolean IsdataCorrect()
        {
            Boolean correct = false;

            ErrorLogger lg = new ErrorLogger();
            string[] halfdayleaves = { "SHD", "HPL" };
            string[] leaves = { "PL", "SL", "UPL", "UPL", "ML" };
            String[] otandpresent = { "P", "OT", "OT1.5", "UOT" ,"LH"};


            int errorflag = 0;



            for (int i = 0; i < tblNonAdjusterdata.Rows.Count-1; i++)
            {


                String outstatus = tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim();



                #region LeaveonOnside

                if (otandpresent.Contains(instatus) && leaves.Contains(outstatus))
                   {
                       errorflag++;

                       tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                      lg.adjusterloger(int.Parse (tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString ()) , DateTime.Parse (tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()),"Half Day TYpe Leave on OUT Section");
                    
                   }
                else if (otandpresent.Contains(outstatus) && leaves.Contains(instatus))
                {
                    errorflag++;
                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()), "Half Day TYpe Leave on IN Section");
                }


                #endregion

                # region datemistake()
                if ((tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString().Trim() == "01/01/2000 00:00:00") || (tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString().Trim() == "01/01/2000" || tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString().Trim() == "01/01/2000 00:00:00"))
                {
                    if (!(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString().Trim() == tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString().Trim()))
                    {
                       // errorflag++;
                        tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Blue ;
                        lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()),"One Unhandled Leave or Abscent Data");
                    }
                }
                else if(DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[5].Value.ToString()) > DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[6].Value.ToString()))
                {
                  //  errorflag++;
                    tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Yellow ;
                     lg.adjusterloger(int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString()), DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()),"SwipeIn Time Greater Than Swipe Out time ");
                }
                #endregion
            }




            if (errorflag == 0)
            {
                correct = true;

               
            }
            else
            {
                correct = false;
                String msg = errorflag.ToString() + "    Unhandled Exceptions Found in Given  Data ";

                MessageBoxDemo.frmShowMessage.Show(msg, "Adjuster Error ", MessageBoxDemo.enumMessageIcon.Error, MessageBoxDemo.enumMessageButton.OK);
            }





            return correct;

        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            if (IsdataCorrect())
            {
                Leaveadderer();
                
             //   loadholidays();
                btn_Synchronise.Enabled = true;
            }
            else
            {
                btn_Synchronise.Enabled = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            correctingOTEntries();
        }





        /// <summary>
        /// check if there is a leave marked in the Employee leaveTaken of an employee
        /// eventhough he is Present on both Sides
        /// </summary>
        public void CheckWhetherPresentiesLeaveisMarked()
        {
           
            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {
                String outstatus = tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim();
                string[] Leave = { "A", "HPL", "PL", "SL", "ML", "UPL", "SHD", "HD", "OSD", "FL" };

                if (!Leave.Contains(instatus) && ! Leave.Contains(outstatus))
                {
                    int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString());
                    DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()).Date;
                    adjstrtrans.RemoveAbscentdataofEmployees(empid, dateofleave, instatus, outstatus);
                  

                }

            } 


        }




        public void Leaveadderer()
        {

            int k = 0;
            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {
                String outstatus = tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim();


                string[] Leave = { "A", "HPL","PL", "SL", "ML","UPL","SHD","HD","OSD","FL" };

                if (Leave.Contains(instatus) && Leave.Contains(outstatus))
                {
                    int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString());
                    DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()).Date;
                    
                    adjstrtrans.insertPendingLeavesofEmployees(empid, dateofleave, instatus, outstatus);
                    k++;


                }
                else if ((instatus == "P" && Leave.Contains(outstatus)) || (Leave.Contains(instatus) && outstatus == "P"))
                {
                    int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString());
                    DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()).Date;
                    adjstrtrans.insertPendingLeavesofEmployees(empid, dateofleave, instatus, outstatus);
                }
                else if ((instatus == "LH" && Leave.Contains(outstatus)) || (Leave.Contains(instatus) && outstatus == "LH"))
                {
                    int empid = int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString());
                    DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()).Date;
                    if (instatus == "LH")
                    {
                        //consider lh as p to mark half day leave
                        instatus = "P";
                    }
                    else
                    {//consider lh as p to mark half day leave
                        outstatus = "P";
                    }
                    adjstrtrans.insertPendingLeavesofEmployees(empid, dateofleave, instatus, outstatus);
                }

                
            }

            if (k > 0)
            {

                String msg = k.ToString() + "   Leaves Found in Given  Data ";

                MessageBoxDemo.frmShowMessage.Show(msg, "Adjuster Error ", MessageBoxDemo.enumMessageIcon.Error, MessageBoxDemo.enumMessageButton.OK);
            }
            else
            {
            }


        }


        public void loadholidays()
        {
            DataTable dt = adjstrtrans.GetAllHolidayodLocation(int.Parse(cmb_location.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);
            int holicount = dt.Rows.Count;
                    
            
            for (int i = 0; i < tblNonAdjusterdata.RowCount - 1; i++)
            {
                String outstatus = tblNonAdjusterdata.Rows[i].Cells[8].Value.ToString().Trim();
                String instatus = tblNonAdjusterdata.Rows[i].Cells[7].Value.ToString().Trim();


                if (outstatus == "A" && instatus == "A")
                {
                     DateTime dateofleave = DateTime.Parse(tblNonAdjusterdata.Rows[i].Cells[2].Value.ToString()).Date;


                    for (int k = 0; k < holicount; k++)
                    {
                        DateTime holidaydate = DateTime.Parse(dt.Rows[k][0].ToString());
                        String Holidayname = dt.Rows[k][1].ToString();
                        if (holidaydate == dateofleave)
                        {
                            tblNonAdjusterdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            tblNonAdjusterdata.Rows[i].Cells[4].Value = Holidayname;

                            adjstrtrans.updateadjusterforHolidays(int.Parse(tblNonAdjusterdata.Rows[i].Cells[1].Value.ToString()),
                                int.Parse(tblNonAdjusterdata.Rows[i].Cells[0].Value.ToString()), dateofleave, Holidayname);
                        }
                    }

                }


            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            loadholidays();
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CheckWhetherPresentiesLeaveisMarked();
        }


    }
}

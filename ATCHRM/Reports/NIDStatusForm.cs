using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Reports
{
    public partial class NIDStatusForm : Form
    {
        public NIDStatusForm()
        {
            InitializeComponent();
            this.Text = this.Text + DateTime.Now.ToShortDateString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbl_Blacklist.Text = "";
            lbl_empname.Text = "";
            int isblacklistedflag=0; int notblacklistflag=0;
            
            if(ValidationControl ())
            {

                using (SqlServerLinqDataContext cntxt= new SqlServerLinqDataContext (Program.ConnStr ))
                {

                    var q = from empdetail in cntxt.EmployeePersonalMaster_tbls
                            where empdetail.NationalId.Trim() == txt_nid.Text.Trim()
                            select empdetail;

                    foreach (var emp in q)
                    {
                        if(emp.IsBlackListed.Trim ()=="Y")
                        {
                            isblacklistedflag++;
                        }
                        else
                        {
                            notblacklistflag++;
                        }
                        if (emp.Status.Trim() == "A")
                        {
                            lbl_empstatus.Text="Active Employee";
                        }
                        else if (emp.Status.Trim() == "H")
                        {
                            lbl_empstatus.Text = "Hold Employee";
                        }
                        else if (emp.Status.Trim() == "D")
                        {
                            lbl_empstatus.Text = "Deactivated Employee";
                        }

                        lbl_empname.Text = emp.First_name +" " +emp.Last_Name;
                    }

                }


                if (isblacklistedflag > 0 && notblacklistflag<=0)
                {
                    lbl_Blacklist.Text = "THIS NID IS NOT OK FOR RECRUITMENT";
                    lbl_Blacklist.ForeColor = Color.Red;
                    btn_prnt.Enabled = true;
                }
                else if (isblacklistedflag <= 0 && notblacklistflag > 0)
                {
                    lbl_Blacklist.Text = "THIS NID IS OK FOR RECRUITMENT";
                    lbl_Blacklist.ForeColor = Color.Green;
                    btn_prnt.Enabled = true ;
                }
                else if (isblacklistedflag == 0 && notblacklistflag == 0)
                {
                    lbl_Blacklist.Text = "THIS NID IS OK FOR RECRUITMENT";
                    lbl_Blacklist.ForeColor = Color.Green;
                    lbl_empstatus.Text = "";
                    btn_prnt.Enabled = true;
                }
                else if (isblacklistedflag >0 && notblacklistflag > 0)
                {
                    lbl_Blacklist.Text = "Multiple records Found Please Contact HR Dept";
                    lbl_Blacklist.ForeColor = Color.YellowGreen;
                    lbl_empstatus.Text = "";
                    btn_prnt.Enabled = true;
                }
                lblUsername.Text = Program.UserName;
                lbl_date.Text = DateTime.Now.ToShortTimeString ();
            }
        }


        public Boolean ValidationControl()
        {
            Boolean sucess = false;



            if (txt_nid.Text == null || txt_nid.Text.Trim() == "")
            {
                lbl_status.Text = "Enter NID";
                lbl_Blacklist.Text = "";
                txt_nid.Focus();
                lbl_empstatus.Text = "";
                lbl_status.Visible = true;
                btn_prnt.Enabled = false;
            }
            else if (txt_confirmNid.Text == null || txt_confirmNid.Text.Trim() == "")
            {
                lbl_status.Text = "Confirm NID";
                lbl_Blacklist.Text = "";
                txt_confirmNid.Focus();
                lbl_empstatus.Text = "";
                lbl_status.Visible = true;
                btn_prnt.Enabled = false;
            }

            else if (txt_confirmNid.Text.Trim() != txt_nid.Text.Trim())
            {
                lbl_status.Text = "Confirm NID and NID not matching";
                lbl_Blacklist.Text = "";
                lbl_empstatus.Text = "";
                txt_confirmNid.Focus();
                lbl_status.Visible = true;
                btn_prnt.Enabled = false;
            }


           

            else
            {
                sucess = true;
            }

            return sucess;

        }

        private void lbl_Blacklist_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
	pd.PrintPage += new PrintPageEventHandler(PrintImage);
    pd.Print();
        }
        void PrintImage(object o, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = this.Width;
            int height = this.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);

            Bitmap img = new Bitmap(width, height);

            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CustomReportViewer crvvwr = new CustomReportViewer("NIDStatus",txt_nid.Text,lbl_empname.Text.Trim (),lbl_Blacklist.Text.Trim ());
            crvvwr.Show();
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class SwipeRulesForm : Form
    {
        Datalayer.SwipeRuleDatabean swpedatabean = null;
        public SwipeRulesForm()
        {
            InitializeComponent();
        }

        private void SwipeRulesForm_Load(object sender, EventArgs e)
        {
            cmb_earlycheckinfailed.SelectedIndex = 0;
            cmb_checkinvalid.SelectedIndex = 0;
            cmb_earlycheckoutfailed.SelectedIndex = 0;
            cmb_latecheckinfailed.SelectedIndex = 0;
            cmb_latecheckoutfailed.SelectedIndex = 0;
        
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// validates the controls
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean validationControl()
        {
            Boolean sucess = false;
            if (txt_from.Text == null || txt_from.Text.Trim() == "")
            {
                lblStatus .Text = "Enter the Check in Start Time";
                txt_from.Focus();

            }

            else if (cmb_inrule.Text == null || cmb_inrule.Text.Trim() == "")
            {
                lblStatus.Text = "Check in is xx minute .....................";
                cmb_inrule.Focus();
            }

            else if (cmb_checkinvalid.Text == null || cmb_checkinvalid.Text.Trim() == "")
            {
                lblStatus.Text = "Enter whether First swipe or last swipe to be taken for Checkin Rule";
                cmb_checkinvalid.Focus();
            }
            else if (txt_To.Text == null || txt_To.Text.Trim() == "")
            {
                lblStatus.Text =" Enter the Check in End Time";
                txt_To.Focus();
            }

            else if (cmb_outrule.Text == null || cmb_outrule.Text.Trim() == "")
            {
                lblStatus.Text = "Check in is xx minute .....................";
                cmb_outrule.Focus();
            }




               else if (txt_earlychek.Text == null || txt_earlychek.Text.Trim() == "")
            {
                lblStatus.Text = "Early Check IN Allowed Upto";
                txt_earlychek.Focus();
            }




            else if (txt_latecheckin.Text == null || txt_latecheckin.Text.Trim() == "")
            {
                lblStatus.Text = "Late  Check IN  Allowed Upto";
                txt_latecheckin.Focus();
            }





            else if (txt_earlycheckout.Text == null || txt_earlycheckout.Text.Trim() == "")
            {
                lblStatus.Text = "Early Check  OUT Allowed Upto";
                txt_earlycheckout.Focus();
            }




            else if (txt_latecheckout.Text == null || txt_latecheckout.Text.Trim() == "")
            {
                lblStatus.Text = "Late  Check OUT Allowed Upto";
                txt_latecheckout.Focus();
            }







            else if (cmb_earlycheckinfailed.Text == null || cmb_earlycheckinfailed.Text.Trim() == "")
            {
                lblStatus.Text = "Early Check INFailed then.......";
                cmb_earlycheckinfailed.Focus();
            }




            else if (cmb_latecheckinfailed.Text == null || cmb_latecheckinfailed.Text.Trim() == "")
            {
                lblStatus.Text = "Late  Check IN  Failed then.......";
                cmb_latecheckinfailed.Focus();
            }





            else if (cmb_earlycheckoutfailed.Text == null || cmb_earlycheckoutfailed.Text.Trim() == "")
            {
                lblStatus.Text = "Early Check  OUT  Failed then.......";
                cmb_earlycheckoutfailed.Focus();
            }




            else if (cmb_latecheckoutfailed.Text == null || cmb_latecheckoutfailed.Text.Trim() == "")
            {
                lblStatus.Text = "Late  Check OUT Failed then.......";
                cmb_latecheckoutfailed.Focus();
            }


            else
            {
                sucess = true;
            }
            return sucess;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addaction(fetchdata());
             ATCHRM.Controls.ATCHRMMessagebox.Show(" Rule  Added and Enabled");
          
        }


        public void SHOWVALUE()
        {

         

        }


        public void addaction(Datalayer.SwipeRuleDatabean swdatabean)
        {


      

            SqlConnection con = new SqlConnection(Program.ConnStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SwipeRuleInsertion_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Param1", swdatabean.Checkinvalisswipe);
                cmd.Parameters.AddWithValue("@Param2", swdatabean.Checkinfrom);
                cmd.Parameters.AddWithValue("@Param3", swdatabean.Checkinto);
                cmd.Parameters.AddWithValue("@Param4", swdatabean.Checkinfromcriteria);
                cmd.Parameters.AddWithValue("@Param5", swdatabean.Checkintocriteria);

                cmd.Parameters.AddWithValue("@Param6", swdatabean.EarlyCheckInupto1);
                cmd.Parameters.AddWithValue("@Param7", swdatabean.LateCheckInupto1);
                cmd.Parameters.AddWithValue("@Param8", swdatabean.EarlyCheckoutUPTO1);
                cmd.Parameters.AddWithValue("@Param9", swdatabean.LateCheckInupto1);

                cmd.Parameters.AddWithValue("@Param10", swdatabean.EarlyCheckInfailaction1 );
                cmd.Parameters.AddWithValue("@Param11", swdatabean.LateCheckInfailaction1);
                cmd.Parameters.AddWithValue("@Param12", swdatabean.EarlyCheckoutfailaction1);
                cmd.Parameters.AddWithValue("@Param13", swdatabean.LateCheckOutfailAction1);
                  cmd.Parameters.AddWithValue("@Param14", swdatabean.Isactive);
                cmd.Parameters.AddWithValue("@Param16", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Param15", Program.USERPK);
                cmd.ExecuteNonQuery();

              
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();

            }



        


        }






        public Datalayer.SwipeRuleDatabean fetchdata()
        {

            if (validationControl())
            {
                swpedatabean = new Datalayer.SwipeRuleDatabean();

                swpedatabean.Checkinvalisswipe = cmb_checkinvalid.Text;
                swpedatabean.Checkinfrom = int.Parse(txt_from.Text);
                swpedatabean.Checkinto = int.Parse(txt_To.Text);

                //changed by sreenath in 11-02-2013
                //swpedatabean.Checkintocriteria = cmb_inrule.Text;
                //swpedatabean.Checkinfromcriteria = cmb_outrule.Text;

                swpedatabean.Checkintocriteria = cmb_outrule.Text;
                swpedatabean.Checkinfromcriteria = cmb_inrule.Text;

                swpedatabean.EarlyCheckInupto1 = int.Parse(txt_earlychek.Text);
                swpedatabean.LateCheckInupto1 = int.Parse(txt_latecheckin.Text);
                swpedatabean.EarlyCheckoutUPTO1 = int.Parse(txt_earlycheckout.Text);
                swpedatabean.LateCheckInupto1 = int.Parse(txt_latecheckout.Text);
                swpedatabean.EarlyCheckInfailaction1 = "EARLY";

                swpedatabean.LateCheckInfailaction1 = "LH";
                swpedatabean.EarlyCheckoutfailaction1 = "LH";
                swpedatabean.LateCheckOutfailAction1 = "UOT";
                swpedatabean.Isactive = "Active";

            }

            return swpedatabean;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_outrule_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Text = cmb_outrule.Text;
        }

        private void txt_To_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Text = (int.Parse(txt_To.Text) + 1).ToString ();
        }

        private void txt_from_TextChanged(object sender, EventArgs e)
        {
             textBox2.Text = "";
            textBox2.Text = (int.Parse(txt_from.Text) - 1).ToString ();
        }

        private void cmb_inrule_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Text = cmb_inrule.Text;
        }

        private void cmb_earlycheckinfailed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_latecheckinfailed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

       








       
    }
}

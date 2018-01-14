using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATCHRM.Master
{
    public partial class SalaryComponentForm : Form
    {
        Datalayer.SalaryCompDataBean salcompdatbean = null;
        Transactions.SalaryCompTransaction salcomptrans = null;
        public SalaryComponentForm()
        {
            InitializeComponent();
            salcomptrans = new Transactions.SalaryCompTransaction();
            DeptcomboLoad();
            txt_amount.Text = "0";
        }
        /// <summary>
        /// function displays the nextcombobox cmb_typeselected asper selection from the cmb_componenttype
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_componenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_componenttype.Text.Trim() == "Disbursement")
            {
                pnl_componenttypechange.Visible = true;
                lbltype.Text = "Disbursement Type";
                cmb_typeselected.Items.Clear();
                cmb_typeselected.Items.Add("OT");
                cmb_typeselected.Items.Add("OTHERS");
               

            }
            else if (cmb_componenttype.Text.Trim() == "Deduction")
            {
                pnl_componenttypechange.Visible = true;
                lbltype.Text = "Deduction Type";
                cmb_typeselected.Items.Clear();
                cmb_typeselected.Items.Add("LH");
                cmb_typeselected.Items.Add("OTHERS");
               
            }
            else
            {
                lblStatus.Text = "Enter the Valid Component type";
            }
        }

        private void cmb_calculationtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_calculationtype.Text.Trim() == "Manually")
            {
                pnl_calculationtype.Visible = true;
                lblformulatype.Text = "Manually";
                cmb_calculatiotypeselected.Items.Clear();
                cmb_calculatiotypeselected.Items.Add("Amount Fixed For All Employee");
                cmb_calculatiotypeselected.Items.Add("Amount Variable For Each Employee");
                cmb_calculatiotypeselected.Items.Add("Amount Variable For Each Designation");
                
                 grpformul.Visible = false;
            

            }
            else if (cmb_calculationtype.Text.Trim() == "Formula")
            {
                pnl_calculationtype.Visible = true;
                lblformulatype.Text = "Applicable For";
                pnl_iffixed.Visible = false;
                cmb_calculatiotypeselected.Text = "";
                cmb_calculatiotypeselected.Items.Clear();
                cmb_calculatiotypeselected.Items.Add("Amount Fixed For All Employee");
                cmb_calculatiotypeselected.Items.Add("Amount Variable For Each Employee");
                cmb_calculatiotypeselected.Items.Add("Amount Variable For Each Designation");
                grpformul.Visible = true;
            }
            else
            {
                lblStatus.Text = "Enter the Valid Calculation type";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_calculatiotypeselected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_calculatiotypeselected.Text  == "Amount Fixed For All Employee")
            {
                if (cmb_calculationtype.Text.Trim() == "Manually")
                {
                    pnl_iffixed.Visible = true;
                   grpformul.Visible = false;
                }
                else if (cmb_calculationtype.Text.Trim() == "Formula")
                {
             
                    pnl_iffixed.Visible = false;
                }



                

            }
            else
            {
                
                pnl_iffixed.Visible = false;
            }
        }

      

        public Boolean validationcontrol() 
        {
            Boolean sucess = false;

           if(cmb_componenttype.Text==null|| cmb_componenttype.Text==""){
               
               
               lblStatus.Text = "Enter the Component type";
               cmb_componenttype.Focus();

           }

           else if (cmb_typeselected.Text == null || cmb_typeselected.Text == "")
           {


               lblStatus.Text = "Enter the Component Sub  type";
               cmb_typeselected.Focus();
           }

           else if (txt_componentname.Text == null || txt_componentname.Text == "")
           {


               lblStatus.Text = "Enter the Component Name";
               txt_componentname.Focus();
           }
           else if (cmb_calculationtype.Text == null || cmb_calculationtype.Text == "")
           {


               lblStatus.Text = "Enter the Calculation Type";
               cmb_calculationtype.Focus();
           }
           else if (cmb_calculatiotypeselected.Text == null || cmb_calculatiotypeselected.Text == "")
           {


               lblStatus.Text = "Enter the Calculation Type Sub";
               cmb_calculatiotypeselected.Focus();
           }
           else if (txt_amount.Text == null || txt_amount.Text == "")
           {
               if (cmb_calculationtype.Text == "Manually")
               {
                   lblStatus.Text = "Enter the Amount ";
                   txt_amount.Focus();
                   txt_amount.Text = "0";
               }
               else if (cmb_calculationtype.Text == "Formula")
               {
                   lblStatus.Text = "Enter the Amount ";
                   txt_amount.Focus();
                   txt_amount.Text = "0";

               }

           }
           else
           {
               sucess = true;


           }
           if (sucess)
           {

               if (cmb_calculationtype.Text.Trim() == "Formula")
               {
                   if (cmb_Formula.Text.Trim() == null || cmb_Formula.Text.Trim() == "")
                   {


                       try
                       {
                           int k = int.Parse(cmb_Formula.SelectedValue.ToString());
                       }
                       catch (Exception)
                       {
                           lblStatus.Text = "Enter the Formula ";
                           cmb_calculationtype.Focus();
                           cmb_calculationtype.Text = "";
                           sucess = false;
                       }



                       lblStatus.Text = "Enter the Formula ";
                       cmb_calculationtype.Focus();
                       cmb_calculationtype.Text = "";
                       sucess = false;


                   }

                   else
                   {
                       sucess = true;
                   }


               }
           }


           return sucess;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (validationcontrol())
                {
                    salcompdatbean = new Datalayer.SalaryCompDataBean();

                    int calpk = int.Parse(salcomptrans.getcalculationpk(cmb_calculationtype.Text, cmb_calculatiotypeselected.Text).Rows[0][0].ToString());
                    int comptype = int.Parse(salcomptrans.getComponentTypepk(cmb_typeselected.Text, cmb_componenttype.Text).Rows[0][0].ToString());
                    salcompdatbean.SalcompName = txt_componentname.Text;
                    salcompdatbean.Calculationtype = calpk;
                    salcompdatbean.Componenttypepk = comptype;
                    salcompdatbean.Amount1 = int.Parse(txt_amount.Text);

                    if (cmb_calculationtype.Text.Trim() == "Manually")
                    {
                        salcompdatbean.Formulapk = 0;
                    }
                    else if (cmb_calculationtype.Text.Trim() == "Formula")
                    {
                        salcompdatbean.Formulapk = int.Parse(cmb_Formula.SelectedValue.ToString());

                    }

                    salcomptrans.insertSalComp(salcompdatbean);
                     ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
                    clearControl();

                }
            }
            catch (Exception exp ) 
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
        }



        public void clearControl()
        {
            txt_amount.Text = "0";
            cmb_calculationtype.Text = "";
            cmb_componenttype.Text = "";
            cmb_typeselected.Text = "";
            cmb_calculatiotypeselected.Text = "";
            txt_componentname.Text = "";

        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float f = float.Parse(txt_amount .Text);
            }
            catch (Exception )
            {

                lblStatus.Text = "Enter Valid Number as Days Again";
                txt_amount.Text = "0";
            }
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumberValidation(sender, e))
            {

                lblStatus.Text = "Enter Valid Number as Days";
                txt_amount.Text = "0";
            }
            else
            {
                lblStatus.Text = " ";
            }
        }

        public Boolean NumberValidation(object sender, KeyPressEventArgs e)
        {
            Boolean VALID = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46)
            {
                VALID = false;
            }
            else
            {
                VALID = true;
            }
            return VALID;
        }

        public void DeptcomboLoad()
        {
            DataTable dt = salcomptrans.getallformula ();
            cmb_Formula .DataSource = dt;
            cmb_Formula.DisplayMember = "Form_Name";
            cmb_Formula.ValueMember = "Form_Det_Id";
        }

        private void pnl_iffixed_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    
    }
}

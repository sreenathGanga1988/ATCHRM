using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class PerkForm : Form
    {
        Datalayer.PerkDataBean prkbean = null;
        Transactions.PerkTransaction prktrans = null;
        public PerkForm()
        {
            InitializeComponent();
            prktrans = new Transactions.PerkTransaction();
           
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            try
            {
                if (validationcontrol())
                {
                    if (btn_submitt.Text.Trim () == "Add")
                    {

                        prktrans.InsertPerkTransaction(fetchdata("Add"));
                        MessageBox.Show("Done");
                        
                    }
                    else
                    {
                        prktrans.UpdatePerk(fetchdata("Update"));

                    }
                    filldatagridview();
                }
            }
            catch (Exception EXP)
            {

                ErrorLogger ER = new ErrorLogger();
                ER.createErrorLog(EXP);
            }

        }


        public Datalayer.PerkDataBean fetchdata(String acttype)
        {
            prkbean = new Datalayer.PerkDataBean();
            prkbean.PerkCode1 = txt_code.Text;
            prkbean.Taxablepercentage = float.Parse(txt_taxable.Text);
            prkbean.PerkName1 = txt_name.Text;

            if (acttype.Trim() == "Add")
            {
                prkbean.PerkPK = 0;
            }
            else
            {
                prkbean.PerkPK = int.Parse(lbl_pk.Text); 
            }

            return prkbean;
        }

        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (txt_code.Text == null || txt_code.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Bank Name";
                txt_code.Focus();
                lbl_Bankname.Visible = true;

            }


            else if (txt_name.Text == null || txt_name.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Branch Name";
                txt_name.Focus();
                lbl_BranchName.Visible = true;

            }
            else if (txt_taxable.Text == null || txt_taxable.Text.Trim() == "")
            {
                lblStatus.Text = "Enter Valid Adress";
                txt_taxable.Focus();
                lbl_Adress1.Visible = true;

            }
            else if (isCodeandNamepresent())
            {
                lblStatus.Text = "Code or Name Already Present";
            }




            else
            {
                sucess = true;
            }


            return sucess;
        }

        public void cancelaction()
        {
            lbl_pk.Text = "";
            btn_submitt.Text = "Add";
            txt_code.Text = "";
            txt_name .Text = "";
            txt_taxable .Text = "0";
        }
       
        public Boolean  isCodeandNamepresent()
        {
            Boolean ispresent = false;
            if (btn_submitt.Text.Trim()!= "Update")
            {
                for (int i = 0; i < tbl_perk.Rows.Count - 1; i++)
                {
                    if ((txt_code.Text.Trim() == tbl_perk.Rows[i].Cells[1].Value.ToString().Trim()) || (txt_name.Text.Trim() == tbl_perk.Rows[i].Cells[2].Value.ToString().Trim()))
                    {
                        ispresent = true;
                    }

                }
            }
            return ispresent;
        }


        public void filldatagridview()
        {
            DataTable dt = prktrans.GetAllPerk();

            tbl_perk.DataSource = dt;


        }

        private void PerkForm_Load(object sender, EventArgs e)
        {
            filldatagridview();
        }

        private void tbl_perk_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rownum = e.RowIndex;

            lbl_pk.Text = tbl_perk.Rows[rownum].Cells[0].Value .  ToString();
            txt_code.Text = tbl_perk.Rows[rownum].Cells[1].Value.ToString();
            txt_name.Text = tbl_perk.Rows[rownum].Cells[2].Value.ToString();
            txt_taxable.Text = tbl_perk.Rows[rownum].Cells[3].Value.ToString();
            btn_submitt.Text = "Update";
           
        }

        private void txt_taxable_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (float.Parse(txt_taxable.Text) > 100)
                {
                    txt_taxable.Text = "0";
                }
            }
            catch (Exception)
            {

                txt_taxable.Text = "0";
            }
        }

        private void txt_taxable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txt_taxable.Text) > 100)
                {
                  //  txt_taxable.Text = "0";
                }
            }
            catch (Exception)
            {

                txt_taxable.Text = "0";
            }
        }

        private void txt_taxable_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (float.Parse(txt_taxable.Text) > 100)
                {
                    txt_taxable.Text = "0";
                }
            }
            catch (Exception)
            {

                txt_taxable.Text = "0";
            }
        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            cancelaction();
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
            if (txt_code .Text.Length > 3)
            {
                txt_code.Text = txt_code.Text.Substring(0, 3);
            }
        }
    }
}

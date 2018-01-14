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
    public partial class QualificationMasterForm : Form
    {
        Transactions.DeptTransaction dpttrans = null;
        public QualificationMasterForm()
        {
            InitializeComponent();
            dpttrans = new Transactions.DeptTransaction();
            loadQualification();
            gridviewsetup();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            insertqualification();
        }




        public void loadQualification()
        {
            DataTable dt = dpttrans.GetallQualificationLEVEL();

            cmb_level.DataSource = dt;
            cmb_level.DisplayMember = "Qual";
            cmb_level.ValueMember = "SL";
        }
    



         public Boolean isQualificationpresent()
        {
            Boolean isok = true;
            for (int i = 0; i< tbl_displaydata.Rows.Count-1; i++)
            {

                if (txt_qualifaction.Text.Trim() == tbl_displaydata.Rows[i].Cells[1].Value.ToString().Trim ())
                {
                    isok = false;
                }
            }
            return isok;
        }

        public void insertqualification()
        {
             if (txt_qualifaction.Text.Trim() == null || txt_qualifaction.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the Qualification Name";
                txt_qualifaction.Focus();
            }
            else if (cmb_level.SelectedValue == null || cmb_level.Text.Trim() == null || cmb_level.Text.Trim() == "")
            {
                lblStatus.Text = "Enter the  Qualification Level";
                cmb_level.Focus();
            }

             else if (!isQualificationpresent())
            {
                lblStatus.Text = " Qualificatio Name Exists for This Department";
            }
           
            else
            {


                dpttrans.InsertQualification (txt_qualifaction.Text.Trim () ,int.Parse (cmb_level.SelectedValue.ToString ()));
                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done");

                gridviewsetup(); 
            }

            
        }




        public void gridviewsetup()
        {
            DataTable dt = dpttrans.GetallQualification();
            tbl_displaydata.DataSource = dt;
        }
    }
}

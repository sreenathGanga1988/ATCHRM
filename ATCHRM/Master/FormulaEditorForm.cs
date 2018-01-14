using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class FormulaEditorForm : Form
    {
        Transactions.SalaryCompTransaction salcomptrans =null;
        public FormulaEditorForm()
        {
            InitializeComponent();
            salcomptrans= new Transactions.SalaryCompTransaction();
           
            getallformula();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "1";
        }

        private void btn_num2_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "2";
        }

        private void btn_numClear_Click(object sender, EventArgs e)
        {
            txt_CalNum.Text = "";
        }

        private void btn_num3_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "3";
        }

        private void btn_num4_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "4";
        }

        private void btn_num5_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "5";
        }

        private void btn_num6_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "6";
        }

        private void btn_num7_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
   
            txt_CalNum.Text = g + "7";
        }

        private void btn_num8_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "8";
        }

        private void btn_num9_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "9";
        }

        private void btn_num0_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + "0";
        }

        private void btn_numdecimal_Click(object sender, EventArgs e)
        {
            String g = txt_CalNum.Text;
            txt_CalNum.Text = g + ".";
        }

        private void lbl_addoperend_Click(object sender, EventArgs e)
        {
            if (cmb_feildName.Text != null || cmb_feildName.Text.Trim() != "")
            {
                String formula = txt_formulaTest.Text;

                txt_formulaTest.Text = formula + cmb_feildName.Text.ToLower();
                cmb_feildName.SelectedItem = null;
            }
            else
            {
                lblStatus.Text = "Enter Feild";
            }
        }

        private void lbl_addOperator_Click(object sender, EventArgs e)
        {
            if (cmb_Operator.Text != null || cmb_Operator.Text.Trim() != "")
            {
                String formula = txt_formulaTest.Text;

                txt_formulaTest.Text = formula + cmb_Operator.Text.ToLower();
                cmb_Operator.SelectedItem  = null;
            }
            else
            {
                lblStatus.Text = "Enter Operator";
            }
        }

        private void btn_numADD_Click(object sender, EventArgs e)
        {
            if (txt_CalNum.Text != null || txt_CalNum.Text != "")
            {
                String formula = txt_formulaTest.Text;
                txt_formulaTest.Text = formula + txt_CalNum.Text.Trim();
                txt_CalNum.Text = "";
            }
        }

        private void btn_formulaSubmit_Click(object sender, EventArgs e)
        {
            if (validationcontrol())
            {


                String lastformula = rht_mainFormula.Text.Trim();
                rht_mainFormula.Text = lastformula + txt_formulaTest.Text.Trim();
                txt_formulaTest.Text = "";
                lblStatus.Text = "";

            }
          
        }


        /// <summary>
        /// Loads the chomobox with sal components
        /// and sety test values to salcomname
        /// and value to salcompk
        /// </summary>
        public void loadsalCompCombo()
        {

           
                DataTable dt = salcomptrans.getSalcomponentandPK();
                cmb_feildName.DataSource=dt;

                cmb_feildName.DisplayMember = "ComponentName";
                cmb_feildName.ValueMember = "salcompPk";

               

            

        }

        private void FormulaEditorForm_Load(object sender, EventArgs e)
        {
            loadsalCompCombo();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.ConnStr);
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            int id = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.CommandText = "select * from Formula_Master_tbl where Form_Type='" + cmb_Formulatype.Text + "'";
            da.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows.Count) == 0)
            {
                com.CommandText = "insert into Formula_Master_tbl (Form_Type) values('" + cmb_Formulatype.Text + "')";
                com.ExecuteNonQuery();
                DataSet ds1 = new DataSet();
                com.CommandText = "select max(Form_id) from Formula_Master_tbl";
                da.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    id = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
                }
            }
            else
            {
                id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            ds.Clear();
            int op = 0, oper = 0;
            char[] char1 = { '(', ')', '*', '/', '+', '-', '%' };
            String[] sg = rht_mainFormula.Text.Split(char1);
            op = sg.Length;
            oper = sg.Length - 1;

            
            
            com.CommandText = "insert into Formula_details_tbl (Form_id,Form_Operands ,Form_Operator ,Form_Data ,Form_Name) "
                + " values(" + id + "," + op + "," + oper + ",'" + rht_mainFormula.Text + "','" + txt_formulaName.Text + "') ";
            com.ExecuteNonQuery();
             ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            rht_mainFormula.Text = "";
            getallformula();
        }

        public Boolean validationcontrol()
        {
            Boolean sucess = false;
            if (txt_formulaName.Text.Trim() == null || txt_formulaName.Text.Trim() == "")
            {
               txt_formulaName.Text = "";
                txt_formulaName.Focus();
                
                    lblStatus.Text = "Enter Formula Name ";
               
            }
            else if (cmb_Formulatype.Text.Trim() == null || cmb_Formulatype.Text.Trim() == "")
            {
                cmb_Formulatype.Focus();

                lblStatus.Text = "Enter Formula Type  ";
            }
            else if (txt_formulaTest.Text.Trim() == null || txt_formulaTest.Text.Trim() == "")
            {
                cmb_Formulatype.Focus();

                lblStatus.Text = "Enter Formula First   ";
            }
            else
            {
                sucess = true;
            }


            return sucess;
            
        }

        public void getallformula()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Program.ConnStr);

            try
            {


                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Formula_Master_tbl.Form_Type, Formula_details_tbl.Form_Data, Formula_details_tbl.Form_Name, Formula_details_tbl.Form_Det_Id  "
                    + " FROM    Formula_Master_tbl INNER JOIN  Formula_details_tbl ON Formula_Master_tbl.Form_id = Formula_details_tbl.Form_id ", con);
                SqlDataReader reader = cmd.ExecuteReader();


                dt.Load(reader);

                
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();

            }


            tb_lFormula.DataSource = dt;
           
                tb_lFormula.Columns[3].Visible = false;
           
        }

        private void tb_lFormula_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rht_mainFormula.Text = tb_lFormula.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmb_Formulatype.Text = tb_lFormula.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_formulaName.Text = tb_lFormula.Rows[e.RowIndex].Cells[2].Value.ToString();
            btn_Save.Enabled = false ;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clearcontrol();
        }

        public void clearcontrol()
        {
            btn_Save.Enabled  = true;
            rht_mainFormula.Text = "";
            txt_formulaName.Text = "";
            cmb_Formulatype.Text = "";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

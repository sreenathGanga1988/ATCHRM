using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master.NewFolder1
{
    public partial class LeaveForm : Form
    {
        Transactions.EmployeeRegTransaction empregtran = new Transactions.EmployeeRegTransaction();
        DataTable employyeapplicableleave = null;
        public LeaveForm()
        {
            InitializeComponent();
            empregtran = new Transactions.EmployeeRegTransaction();
        }
        public LeaveForm(String empnum,int empid )
        {
            InitializeComponent();
            empregtran = new Transactions.EmployeeRegTransaction();
            fillcontrol(empid);
            cmb_empCode.Text = empnum;
            lbl_emppk.Text = empid.ToString();
            gridviewsetup();
        }
        public LeaveForm(String empnum, int empid ,String applicationstring  , int applicationid)
        {
            InitializeComponent();
            empregtran = new Transactions.EmployeeRegTransaction();
            fillcontrol(empid);
            cmb_empCode.Text = empnum;
            lbl_emppk.Text = empid.ToString();
            gridviewsetup();
        }


        /// <summary>
        /// fill all the leave applicable for that person
        /// </summary>
        /// <param name="eimpid"></param>
        public void fillcontrol(int eimpid)
        {
         //   eimpid = 92;
            employyeapplicableleave = empregtran.getEmployeleavesApplicable(eimpid);

            if (employyeapplicableleave != null)
            {
                tbl_Leavedata.DataSource = employyeapplicableleave;
              
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (addleave())
            {

                 ATCHRM.Controls.ATCHRMMessagebox.Show("Done --->"+cmb_empCode.Text );

               


            }


         








           
        }






        public Boolean addleave()
        {
            Boolean sucess= true;

              if (tbl_Leavedata.RowCount!=0)
            
            {
               
                SqlConnection con = new SqlConnection(Program.ConnStr);
                try
                {
                    con.Open();

                    for (int i = 0; i < tbl_Leavedata.RowCount-1 ; i++)
                    {
                        
                        SqlCommand cmd = new SqlCommand(" INSERT INTO EmployeeApplicableLeave_tbl (empid, LeavePk, Isenchasable, EnchasableDays, Allowedleave) VALUES     (@Param1,@Param2,@Param3,@Param4,@Param5) ", con);

                        cmd.Parameters.AddWithValue("@Param1",int.Parse (lbl_emppk.Text )  );
                        cmd.Parameters.AddWithValue("@Param2", int.Parse (tbl_Leavedata.Rows[i].Cells[0].Value.ToString ()));

                        cmd.Parameters.AddWithValue("@Param3", int.Parse (tbl_Leavedata.Rows[i].Cells[3].Value.ToString ()));
                        cmd.Parameters.AddWithValue("@Param4", int.Parse (tbl_Leavedata.Rows[i].Cells[6].Value.ToString ()));
                        cmd.Parameters.AddWithValue("@Param5", int.Parse (tbl_Leavedata.Rows[i].Cells[7].Value.ToString ()));

                        cmd.ExecuteNonQuery();

                    }

                   
                }
                catch (Exception)
                {
                    sucess = false;
                    
                   
                    throw;
                }
                finally
                {
                    con.Close();
      
                }



            }





              return sucess;
        }


        /// <summary>
        /// set up the grid view for leave carry over
        /// </summary>
        public void gridviewsetup()
        {
            cmbrecureleave.DataSource = employyeapplicableleave;

            cmbrecureleave.DisplayMember = "LeaveName";
            cmbrecureleave.ValueMember = "LeavePk";


            
            
      


        }

        private void tbl_leaveForward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dataTable = null;
            if (e.ColumnIndex == 1)
            {
                if (tbl_leaveForward.Rows[e.RowIndex].Cells[1].Value != null)
                {

                    DataRow[] result = employyeapplicableleave.Select("LeavePk = " + int.Parse(tbl_leaveForward.Rows[e.RowIndex].Cells[1].Value.ToString()) + "");
                 // if(if dat){
                    foreach (DataRow row in result)
                    {
                        dataTable.ImportRow(row);
                    }
                }
               // }
            }
        }

        private void tbl_leaveForward_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cmb_empCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clk == 1)
            {
                empregtran = new Transactions.EmployeeRegTransaction();
                fillcontrol(Convert.ToInt32(cmb_empCode.SelectedValue));
                //cmb_empCode.Text = empnum;
                lbl_emppk.Text = Convert.ToInt32(cmb_empCode.SelectedValue).ToString();
                gridviewsetup();
            }
            clk = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LeaveForm_Load(object sender, EventArgs e)
        {
            GridViewmModels.ClsDatabase.Combo_Fill("select empid,empno from EmployeePersonalMaster_tbl", "empid", "empno", cmb_empCode);
        }

        int clk = 0;
        private void cmb_empCode_Click(object sender, EventArgs e)
        {
            clk = 1;
        }

        private void btn_submmit_Click(object sender, EventArgs e)
        {

        }




    }
}

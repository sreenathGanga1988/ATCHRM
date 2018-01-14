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
    
    public partial class SalaryComponentMaster : Form
    {
        Transactions.SalaryCompTransaction salcomptrans= null;
        
        public SalaryComponentMaster()
        {
            InitializeComponent();
            salcomptrans = new Transactions.SalaryCompTransaction();
            tbl_SalCompData.RowTemplate.Height = 18;
            filldatagrid();
        }


        public void filldatagrid()
        {
            DataTable dt = salcomptrans.getAllSalCompData();

            tbl_SalCompData.DataSource = dt;
            tbl_SalCompData.Columns[0].Visible = false;

        }

      

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            Master.SalaryComponentForm salcmpntform = new Master.SalaryComponentForm();
            salcmpntform.MdiParent = this.MdiParent;
            salcmpntform.Show();
            filldatagrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            filldatagrid();
        }

        private void btn_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
    }
}

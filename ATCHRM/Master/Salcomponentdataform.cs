using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Master
{
    public partial class Salcomponentdataform : Form
    {
        public Salcomponentdataform()
        {
            InitializeComponent();
        }
        String _Amount;

        public String Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Amount = textBox1.Text;

            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

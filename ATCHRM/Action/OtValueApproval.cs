using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Action
{
    public partial class OtValueApproval : Form
    {
        public OtValueApproval()
        {
            InitializeComponent();
        }
        public OtValueApproval(String type)
        {
            InitializeComponent();

            if (type == "LH")
            {
                this.Text = "LH Value";
                label1.Text = "Enter LH Value";
            }
            else if(type == "OT")
            {
                this.Text = "OT Value";
                label1.Text = "Enter OT Value";
            }
            else if (type == "OT")
            {
                this.Text = "OT Value";
            }
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
    }
}

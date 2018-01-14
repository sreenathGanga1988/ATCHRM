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
    public partial class UserAuthenication : Form
    {
        public UserAuthenication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() =="Hiren")
            {
                isauthenicated = true;
                this.Close();
            }
            else
            {
                isauthenicated = false;
                MessageBox.Show("Not Authenicated User");
            }
        }


        Boolean isauthenicated = false;

        public Boolean Isauthenicated
        {
            get { return isauthenicated; }
            set { isauthenicated = value; }
        }


    }







}

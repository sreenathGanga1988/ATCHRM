using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
namespace ATCHRM.Action
{
    public partial class Tryform2 : Form
    {
        Transactions.NotificationTransaction nftrans = null;

   //     private AutoResetEvent _resetEvent = new AutoResetEvent(false);
     public   string strString = "";
       
       

        public Tryform2()
        {
            InitializeComponent();

            nftrans = new Transactions.NotificationTransaction();

         //   maintimerscrollsetting();

             
          //   timer2.Start();
        }

        private void Tryform2_Load(object sender, EventArgs e)
        {

        }


       









    }
}

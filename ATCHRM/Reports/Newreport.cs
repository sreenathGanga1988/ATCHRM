using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Reports
{
    public partial class Newreport : Form
    {
        public Newreport()
        {
            InitializeComponent();
            Transactions.ControlSetupper.UltraGridNormalSetup(this.ultraGrid1);
        }
    }
}

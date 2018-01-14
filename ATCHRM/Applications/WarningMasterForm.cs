using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Applications
{
    public partial class WarningMasterForm : Form
    {
        public WarningMasterForm()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).WarningFormOpen12("Writing"); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Administrator
{
    public partial class Ultrafridform : Form
    {
        public Ultrafridform()
        {
            InitializeComponent();
        }
        public Ultrafridform(DataTable dt)
        {
            InitializeComponent();
            ultraGrid1.DataSource = dt;
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactions.DataExporter DTPEXPTR = null;
            DTPEXPTR = new Transactions.DataExporter();
            DTPEXPTR.ExportUltraGrid(this.ultraGrid1);
        }
    }
}

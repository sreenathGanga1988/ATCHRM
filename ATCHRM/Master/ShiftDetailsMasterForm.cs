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
    public partial class ShiftDetailsMasterForm : Form
    {
        Transactions.ShiftTransaction trans= null;
        public ShiftDetailsMasterForm()
        {
            InitializeComponent();
            trans = new Transactions.ShiftTransaction();
            datagrdviewsetup();
        }
        public ShiftDetailsMasterForm(DataTable dt)
        {
            InitializeComponent();
            trans = new Transactions.ShiftTransaction();
            tbl_shiftdata.DataSource = dt;
            tbl_shiftdata.Columns[0].Visible = false;
        }

        public void datagrdviewsetup()
        {
            tbl_shiftdata.DataSource = trans.gettALLShiftDetails();
            tbl_shiftdata.Columns[0].Visible = false;
          
        }
    }
}

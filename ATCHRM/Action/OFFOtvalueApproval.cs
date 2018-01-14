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
    public partial class OFFOtvalueApproval : Form
    {
        public OFFOtvalueApproval()
        {
            InitializeComponent();
        }
        public OFFOtvalueApproval(DateTime dt)
        {
            InitializeComponent();
            dtp_intime.Value = dt;
        }


        String _outtime;

        public String OutTime
        {
            get { return _outtime; }
            set { _outtime = value; }
        }
        DateTime intime;

        public DateTime Intime
        {
            get { return intime; }
            set { intime = value; }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            _outtime = mtxt_ottime.Text;
            intime = DateTime.Parse(dtp_intime.Value.ToString());

            Close();
        }
    }
}

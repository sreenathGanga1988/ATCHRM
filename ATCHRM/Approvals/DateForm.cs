using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Approvals
{
    public partial class DateForm : Form
    {
        public DateForm()
        {
            InitializeComponent();
        }

        DateTime _UserSelectedDate;

        public DateTime UserSelectedDate
        {
            get { return _UserSelectedDate; }
            set { _UserSelectedDate = value; }
        }

        private void btn_submitt_Click(object sender, EventArgs e)
        {
            _UserSelectedDate = dtp_date.Value.Date;
            Close();
        }

    }
}

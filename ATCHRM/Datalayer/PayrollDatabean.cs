using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCHRM.Datalayer
{
    class PayrollDatabean
    {


        int payroolid = 0;

        public int Payroolid
        {
            get { return payroolid; }
            set { payroolid = value; }
        }
        DateTime payrollfromdate;

        public DateTime Payrollfromdate
        {
            get { return payrollfromdate; }
            set { payrollfromdate = value; }
        }
        DateTime payrollEndDate;

        public DateTime PayrollEndDate
        {
            get { return payrollEndDate; }
            set { payrollEndDate = value; }
        }
        int BranchlocationPK;

        public int BranchlocationPK1
        {
            get { return BranchlocationPK; }
            set { BranchlocationPK = value; }
        }

        String payrollmonth;

        public String Payrollmonth
        {
            get { return payrollmonth; }
            set { payrollmonth = value; }
        }
        DateTime payrolltodate;

        public DateTime Payrolltodate
        {
            get { return payrolltodate; }
            set { payrolltodate = value; }
        }
        int empcount = 0;

        public int Empcount
        {
            get { return empcount; }
            set { empcount = value; }
        }
        int deptid;

        public int Deptid
        {
            get { return deptid; }
            set { deptid = value; }
        }

        int payrolldaysofmonth = 0;

        public int Payrolldaysofmonth
        {
            get { return payrolldaysofmonth; }
            set { payrolldaysofmonth = value; }
        }

        
    }

    
}

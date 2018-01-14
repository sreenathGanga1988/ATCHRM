using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data ;
namespace ATCHRM.Datalayer
{
    class OvertimeDatabean
    {





    }


    class OvertimeApplicationDatabean
    {
        int OtAppPk;

        public int OtAppPk1
        {
            get { return OtAppPk; }
            set { OtAppPk = value; }
        }
        int Duration;

        public int Duration1
        {
            get { return Duration; }
            set { Duration = value; }
        }
        DateTime Otdate;

        public DateTime Otdate1
        {
            get { return Otdate; }
            set { Otdate = value; }
        }
        String reason = null;

        public String Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        int deptpk;

        public int Deptpk
        {
            get { return deptpk; }
            set { deptpk = value; }
        }
        String OtAppnum = null;

        public String OtAppnum1
        {
            get { return OtAppnum; }
            set { OtAppnum = value; }
        }
        int dateadded;

        public int Dateadded
        {
            get { return dateadded; }
            set { dateadded = value; }
        }

        int BranchPK;

        public int BranchPK1
        {
            get { return BranchPK; }
            set { BranchPK = value; }
        }
        DataTable empadded = null;

        public DataTable Empadded
        {
            get { return empadded; }
            set { empadded = value; }
        }



    }

}

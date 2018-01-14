using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ATCHRM.Datalayer
{
    class RecruitAppDatabean
    {
        int recruitmentpk;

        public int Recruitmentpk
        {
            get { return recruitmentpk; }
            set { recruitmentpk = value; }
        }
        int branchLocationpk;

        public int BranchLocationpk
        {
            get { return branchLocationpk; }
            set { branchLocationpk = value; }
        }
        int designationpk;

        public int Designationpk
        {
            get { return designationpk; }
            set { designationpk = value; }
        }
        int vaccancynum;

        public int Vaccancynum
        {
            get { return vaccancynum; }
            set { vaccancynum = value; }
        }
        String contracttype = null;

        public String Contracttype
        {
            get { return contracttype; }
            set { contracttype = value; }
        }
        int isinterviewed;

        public int Isinterviewed
        {
            get { return isinterviewed; }
            set { isinterviewed = value; }
        }
        String interviewer = null;

        public String Interviewer
        {
            get { return interviewer; }
            set { interviewer = value; }
        }
        DateTime joiningdate;

        public DateTime Joiningdate
        {
            get { return joiningdate; }
            set { joiningdate = value; }
        }
        String Description = null;

        public String Description1
        {
            get { return Description; }
            set { Description = value; }
        }

        String iscompleted;

        public String Iscompleted
        {
            get { return iscompleted; }
            set { iscompleted = value; }
        }
    }

    class LeaveAppDatabean
    {
        int leaveappid;

        public int Leaveappid
        {
            get { return leaveappid; }
            set { leaveappid = value; }
        }
        int Leavepk;

        public int Leavepk1
        {
            get { return Leavepk; }
            set { Leavepk = value; }
        }
        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        DateTime fromdate;

        public DateTime Fromdate
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        DateTime todate;

        public DateTime Todate
        {
            get { return todate; }
            set { todate = value; }
        }
        int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        String Durationtype;

        public String Durationtype1
        {
            get { return Durationtype; }
            set { Durationtype = value; }
        }
        String mobilenum = null;

        public String Mobilenum
        {
            get { return mobilenum; }
            set { mobilenum = value; }
        }
        String Telephonenum = null;

        public String Telephonenum1
        {
            get { return Telephonenum; }
            set { Telephonenum = value; }
        }
        int balance = 0;

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

    }

    class AdvanceAppDatabean
    {

        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        int advanceAppPk;

        public int AdvanceAppPk
        {
            get { return advanceAppPk; }
            set { advanceAppPk = value; }
        }
        int currencypk;

        public int Currencypk
        {
            get { return currencypk; }
            set { currencypk = value; }
        }
        float Amount;

        public float Amount1
        {
            get { return Amount; }
            set { Amount = value; }
        }

        DataTable paybackdate;

        public DataTable Paybackdate
        {
            get { return paybackdate; }
            set { paybackdate = value; }
        }



        int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }


        String Tobepayedby;

        public String Tobepayedby1
        {
            get { return Tobepayedby; }
            set { Tobepayedby = value; }
        }
        String durationtype = null;

        public String Durationtype
        {
            get { return durationtype; }
            set { durationtype = value; }
        }
        float Instalmentof;

        public float Instalmentof1
        {
            get { return Instalmentof; }
            set { Instalmentof = value; }
        }
        String reason;

        public String Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        DateTime dateadded;

        public DateTime Dateadded
        {
            get { return dateadded; }
            set { dateadded = value; }
        }
        String iscompleted = null;

        public String Iscompleted
        {
            get { return iscompleted; }
            set { iscompleted = value; }
        }

    }


    class LeaveEnchasementAppDatabean
    {
        int leavepk;

        public int Leavepk
        {
            get { return leavepk; }
            set { leavepk = value; }
        }
        int contractid;

        public int Contractid
        {
            get { return contractid; }
            set { contractid = value; }
        }
        int levenchasid;

        public int Levenchasid
        {
            get { return levenchasid; }
            set { levenchasid = value; }
        }
        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        String currentyear;

        public String Currentyear
        {
            get { return currentyear; }
            set { currentyear = value; }
        }

        int enchaseduration;

        public int Enchaseduration
        {
            get { return enchaseduration; }
            set { enchaseduration = value; }
        }
        String durationtype = "";

        public String Durationtype
        {
            get { return durationtype; }
            set { durationtype = value; }
        }
        String Appnum = null;

        public String Appnum1
        {
            get { return Appnum; }
            set { Appnum = value; }
        }
           }


    
}

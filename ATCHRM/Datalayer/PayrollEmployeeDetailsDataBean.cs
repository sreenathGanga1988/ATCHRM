using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ATCHRM.Datalayer
{
   public  class PayrollEmployeeDetailsDataBean
    {

        private ArrayList empdataarray;

        public ArrayList Empdataarray
        {
            get { return empdataarray; }
            set { empdataarray = value; }
        }




        int Pay_Id = 0;
        public int Pay_Id1
        {
            get { return Pay_Id; }
            set { Pay_Id = value; }
        }

        int Pay_Det_Id = 0;
        public int Pay_Det_Id1
        {
            get { return Pay_Det_Id; }
            set { Pay_Det_Id = value; }
        }

        int Emp_Id = 0;
        public int empid
        {
            get { return Emp_Id; }
            set { Emp_Id = value; }
        }

        float Leave_Days = 0;
        public float Leave_Days1
        {
            get { return Leave_Days; }
            set { Leave_Days = value; }
        }

        float  Absent_No = 0;
        public float Abscent_no
        {
            get { return Absent_No; }
            set { Absent_No = value; }
        }

        float holidayno = 0;
        public float Holidayno
        {
            get { return holidayno; }
            set { holidayno = value; }
        }



        float halfdayleave = 0;

        public float Halfdayleave
        {
            get { return halfdayleave; }
            set { halfdayleave = value; }
        }
        float halfdayabscent = 0;

        public float Halfdayabscent
        {
            get { return halfdayabscent; }
            set { halfdayabscent = value; }
        }

        float totalabscent = 0;

        public float Totalabscent
        {
            get { return totalabscent; }
            set { totalabscent = value; }
        }



        int paidleaves = 0;

        public int Paidleaves
        {
            get { return paidleaves; }
            set { paidleaves = value; }
        }
        

        int offdays = 0;

        public int Offdays
        {
            get { return offdays; }
            set { offdays = value; }
        }

        int Department_Id = 0;
        public int Department_Id1
        {
            get { return Department_Id; }
            set { Department_Id = value; }
        }


        int basic = 0;

        public int Basic
        {
            get { return basic; }
            set { basic = value; }
        }
        int hra = 0;

        public int Hra
        {
            get { return hra; }
            set { hra = value; }
        }
        int nssf = 0;

        public int Nssf
        {
            get { return nssf; }
            set { nssf = value; }
        }
        int nhif = 0;

        public int Nhif
        {
            get { return nhif; }
            set { nhif = value; }
        }
        int othours = 0;

        public int Othours
        {
            get { return othours; }
            set { othours = value; }
        }
        int offothours = 0;

        public int Offothours
        {
            get { return offothours; }
            set { offothours = value; }
        }

        int specialallowance = 0;

        public int Specialallowance
        {
            get { return specialallowance; }
            set { specialallowance = value; }
        }

        int payrolldays = 0;

        public int Payrolldays
        {
            get { return payrolldays; }
            set { payrolldays = value; }
        }

        int LeaveonOffday = 0;

        public int LeaveonOffday1
        {
            get { return LeaveonOffday; }
            set { LeaveonOffday = value; }
        }



        int leaveonholiday;

        public int Leaveonholiday
        {
            get { return leaveonholiday; }
            set { leaveonholiday = value; }
        }

        DateTime Payrollfromdate;

        public DateTime PayrollFromDate
        {
            get { return Payrollfromdate; }
            set { Payrollfromdate = value; }
        }
        DateTime payrolltodate;

        public DateTime payrollToDate
        {
            get { return payrolltodate; }
            set { payrolltodate = value; }
        }


        DateTime EmpContractStartdate;

        public DateTime EmpContractStartdate1
        {
            get { return EmpContractStartdate; }
            set { EmpContractStartdate = value; }
        }

        DateTime EmpContractToDate;

        public DateTime EmpContractToDate1
        {
            get { return EmpContractToDate; }
            set { EmpContractToDate = value; }
        }

        DateTime ActualJoiningDate;

        public DateTime ActualJoiningDate1
        {
            get { return ActualJoiningDate; }
            set { ActualJoiningDate = value; }
        }

        Boolean isOtapplicable = false;

        public Boolean IsOtapplicable
        {
            get { return isOtapplicable; }
            set { isOtapplicable = value; }
        }

        int payrollofthemonth = 0;

        public int Payrollofthemonth
        {
            get { return payrollofthemonth; }
            set { payrollofthemonth = value; }
        }


        String ContractType = "";

        public String ContractType1
        {
            get { return ContractType; }
            set { ContractType = value; }
        }
    }
}

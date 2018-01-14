using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ATCHRM.Datalayer
{
    class EmployeeDatabean
    {

    }

    class EmployeePersonaldatabean
    {
        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        String empcode = null;
        String Oldempid = null;

        public String Oldempid1
        {
            get { return Oldempid; }
            set { Oldempid = value; }
        }   DateTime dob;

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        String NSSF = null;

        public String NSSF1
        {
            get { return NSSF; }
            set { NSSF = value; }
        }
        String NHIF = null;

        public String NHIF1
        {
            get { return NHIF; }
            set { NHIF = value; }
        }

        String kinsNID;

        public String KinsNID
        {
            get { return kinsNID; }
            set { kinsNID = value; }
        }

        String isDeactivated;

        public String IsDeactivated
        {
            get { return isDeactivated; }
            set { isDeactivated = value; }
        }

        int highesteducation = 0;

        public int Highesteducation
        {
            get { return highesteducation; }
            set { highesteducation = value; }
        }











        String INCometaxnum = null;

        public String INCometaxnum1
        {
            get { return INCometaxnum; }
            set { INCometaxnum = value; }
        }
        public String Empcode
        {
            get { return empcode; }
            set { empcode = value; }
        }
        int recruitmrentCodepk;

        public int RecruitmrentCodepk
        {
            get { return recruitmrentCodepk; }
            set { recruitmrentCodepk = value; }
        }

        String nationality = null;

        public String Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }
        String nid = null;

        public String Nid
        {
            get { return nid; }
            set { nid = value; }
        }
        String PPnum = null;

        public String PPnum1
        {
            get { return PPnum; }
            set { PPnum = value; }
        }
        String gender = null;

        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        String status = null;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        String firstname = null;

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        String lastname = null;

        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        String adress1 = null;

        public String Adress1
        {
            get { return adress1; }
            set { adress1 = value; }
        }
        String adress2 = null;

        public String Adress2
        {
            get { return adress2; }
            set { adress2 = value; }
        }
        
        int lctnPk;

        public int LctnPk
        {
            get { return lctnPk; }
            set { lctnPk = value; }
        }
        String telphone = null;

        public String Telphone
        {
            get { return telphone; }
            set { telphone = value; }
        }
        String mobile = null;

        public String Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        String email = null;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        String refname = null;

        public String Refname
        {
            get { return refname; }
            set { refname = value; }
        }
        String refdetails = null;

        public String Refdetails
        {
            get { return refdetails; }
            set { refdetails = value; }
        }
        String refmobile = null;

        public String Refmobile
        {
            get { return refmobile; }
            set { refmobile = value; }
        }
        String beneficaryname = null;

        public String Beneficaryname
        {
            get { return beneficaryname; }
            set { beneficaryname = value; }
        }

        String benificiaryrelation = null;

        public String Benificiaryrelation
        {
            get { return benificiaryrelation; }
            set { benificiaryrelation = value; }
        }
        String beneficiarymobile = null;

        public String Beneficiarymobile
        {
            get { return beneficiarymobile; }
            set { beneficiarymobile = value; }
        }
        String beneficiaryemail = null;

        public String Beneficiaryemail
        {
            get { return beneficiaryemail; }
            set { beneficiaryemail = value; }
        }
        String refemail;

        public String Refemail
        {
            get { return refemail; }
            set { refemail = value; }
        }
        int recId;

        public int RecId
        {
            get { return recId; }
            set { recId = value; }
        }

    }

    class EmployeeContractDatabean
    {
        int empid;
       
        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        String empcode = null;

        public String Empcode
        {
            get { return empcode; }
            set { empcode = value; }
        }
        String contractype = null;
     
        public String Contractype
        {
            get { return contractype; }
            set { contractype = value; }
        }
        DateTime startime;


        DateTime actualjoinigdate;

        public DateTime Actualjoinigdate
        {
            get { return actualjoinigdate; }
            set { actualjoinigdate = value; }
        }

        public DateTime Startime
        {
            get { return startime; }
            set { startime = value; }
        }
        DateTime endtime;

        public DateTime Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }
        DateTime extendeddate;

        public DateTime Extendeddate
        {
            get { return extendeddate; }
            set { extendeddate = value; }
        }
        int ContractchangeAppid = 0;

        public int ContractchangeAppid1
        {
            get { return ContractchangeAppid; }
            set { ContractchangeAppid = value; }
        }

    }


    class EmployeeDesignationDataBean
    {

        int empdesgid;

        public int Empdesgid
        {
            get { return empdesgid; }
            set { empdesgid = value; }
        }
        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        int desgid;

        public int Desgid
        {
            get { return desgid; }
            set { desgid = value; }
        }
        int lctnid;

        public int Lctnid
        {
            get { return lctnid; }
            set { lctnid = value; }
        }
        int deptid;

        public int Deptid
        {
            get { return deptid; }
            set { deptid = value; }
        }
        String reason = null;

        public String Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        int desgchangeAppid = 0;

        public int DesgchangeAppid
        {
            get { return desgchangeAppid; }
            set { desgchangeAppid = value; }
        }

        int subdeptPk = 0;

        public int SubdeptPk
        {
            get { return subdeptPk; }
            set { subdeptPk = value; }
        }
    }


    class EmployeeShiftDatabean
    {
        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        int ShiftPk;

        public int ShiftPk1
        {
            get { return ShiftPk; }
            set { ShiftPk = value; }
        }
        String WeeklyOff;

        public String WeeklyOff1
        {
            get { return WeeklyOff; }
            set { WeeklyOff = value; }
        }
        DateTime effectivedate;

        public DateTime Effectivedate
        {
            get { return effectivedate; }
            set { effectivedate = value; }
        }
        TimeSpan startime;

        public TimeSpan Startime
        {
            get { return startime; }
            set { startime = value; }
        }
        TimeSpan endtime;

        public TimeSpan Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }

     

    }


    class employeesalarydatabean
    {
        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        float approvedsal;

        public float Approvedsal
        {
            get { return approvedsal; }
            set { approvedsal = value; }
        }
        String paymentmode;

        public String Paymentmode
        {
            get { return paymentmode; }
            set { paymentmode = value; }
        }
        int bankpk;

        public int Bankpk
        {
            get { return bankpk; }
            set { bankpk = value; }
        }
        String accountnum;

        public String Accountnum
        {
            get { return accountnum; }
            set { accountnum = value; }
        }

        DataTable applicablesalcomponent = null;


        int currencypk;

        public int Currencypk
        {
            get { return currencypk; }
            set { currencypk = value; }
        }
        public DataTable Applicablesalcomponent
        {
            get { return applicablesalcomponent; }
            set { applicablesalcomponent = value; }
        }

    }




    class contractannualrenewal
    {


        int contractid;

        public int Contractid
        {
            get { return contractid; }
            set { contractid = value; }
        }
        int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }
        String CurrentYear;

        public String CurrentYear1
        {
            get { return CurrentYear; }
            set { CurrentYear = value; }
        }
        DateTime Fromdate;

        public DateTime Fromdate1
        {
            get { return Fromdate; }
            set { Fromdate = value; }
        }
        DateTime Todate;

        public DateTime Todate1
        {
            get { return Todate; }
            set { Todate = value; }
        }
        DateTime renewedDate;

        public DateTime RenewedDate
        {
            get { return renewedDate; }
            set { renewedDate = value; }
        }


      

        DateTime actualjoiningdate;

        public DateTime Actualjoiningdate
        {
            get { return actualjoiningdate; }
            set { actualjoiningdate = value; }
        }

    }
}

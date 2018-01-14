using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ATCHRM.Datalayer
{
     public class LeaveDataBean
    {
        int leavepk;
        String leavename = null;
        String leavecaltype = null;
        String description = null;
        int ismaleapp;
        int isfemaleapp;
        int isencashable;
        int enchasabledays;
        String LeaveCode = null;
        String CalculateUpto = null;
        int isCarryFowardable;
        String ConsiderAlso = null;

        public String ConsiderAlso1
        {
            get { return ConsiderAlso; }
            set { ConsiderAlso = value; }
        }
        public int IsCarryFowardable
        {
            get { return isCarryFowardable; }
            set { isCarryFowardable = value; }
        }
        public String CalculateUpto1
        {
            get { return CalculateUpto; }
            set { CalculateUpto = value; }
        }
        public String LeaveCode1
        {
            get { return LeaveCode; }
            set { LeaveCode = value; }
        }
        public int Leavepk
        {
            get { return leavepk; }
            set { leavepk = value; }
        }
        int allowedleave;

        public int Allowedleave
        {
            get { return allowedleave; }
            set { allowedleave = value; }
        }
        public String Leavename
        {
            get { return leavename; }
            set { leavename = value; }
        }
       
        public String Leavecaltype
        {
            get { return leavecaltype; }
            set { leavecaltype = value; }
        }
      
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        
        public int Ismaleapp
        {
            get { return ismaleapp; }
            set { ismaleapp = value; }
        }
       
        public int Isfemaleapp
        {
            get { return isfemaleapp; }
            set { isfemaleapp = value; }
        }
       

        public int Isencashable
        {
            get { return isencashable; }
            set { isencashable = value; }
        }
      
       

        public int Enchasabledays
        {
            get { return enchasabledays; }
            set { enchasabledays = value; }
        }
    }



     public class HolidayDayDataBean
     {
         int holydayid;
        
         public int Holydayid
         {
             get { return holydayid; }
             set { holydayid = value; }
         }
         String holidayname = null;

         public String Holidayname
         {
             get { return holidayname; }
             set { holidayname = value; }
         }
         DateTime holidaydate;

         public DateTime Holidaydate
         {
             get { return holidaydate; }
             set { holidaydate = value; }
         }
         String holidaytype = null;

         public String Holidaytype
         {
             get { return holidaytype; }
             set { holidaytype = value; }
         }
         String holidaydescrption = null;

         public String Holidaydescrption
         {
             get { return holidaydescrption; }
             set { holidaydescrption = value; }
         }
         



     }




     public class EmployeeleaveCalculationDatabean
     {

         int empid = 0;
         int leavepk = 0;

         public int Leavepk
         {
             get { return leavepk; }
             set { leavepk = value; }
         }
         DataTable empsubcontracttable = null;



         DataTable leavedata = null;

         public DataTable Leavedata
         {
             get { return leavedata; }
             set { leavedata = value; }
         }
         public DataTable Empsubcontracttable
         {
             get { return empsubcontracttable; }
             set { empsubcontracttable = value; }
         }
         public int Empid
         {
             get { return empid; }
             set { empid = value; }
         }
         int Contractid = 0;

         public int Contractid1
         {
             get { return Contractid; }
             set { Contractid = value; }
         }
         String CurrentContractyear = "";

         public String CurrentContractyear1
         {
             get { return CurrentContractyear; }
             set { CurrentContractyear = value; }
         }
         String ContractType = "";

         public String ContractType1
         {
             get { return ContractType; }
             set { ContractType = value; }
         }

         int OverAllLeaveApplicable ;

         public int OverAllLeaveApplicable1
         {
             get { return OverAllLeaveApplicable; }
             set { OverAllLeaveApplicable = value; }
         }


         String leavecalculationType = null;

         public String LeavecalculationType
         {
             get { return leavecalculationType; }
             set { leavecalculationType = value; }
         }

         int iscarryforwardable = 0;
         int allowedleave = 0;

         public int Allowedleave
         {
             get { return allowedleave; }
             set { allowedleave = value; }
         }

         public int Iscarryforwardable
         {
             get { return iscarryforwardable; }
             set { iscarryforwardable = value; }
         }
         String LeaveCode = null;
         String CalculateUpto = null;
         int isCarryFowardable;
         String ConsiderAlso = null;

         public String ConsiderAlso1
         {
             get { return ConsiderAlso; }
             set { ConsiderAlso = value; }
         }
         public int IsCarryFowardable
         {
             get { return isCarryFowardable; }
             set { isCarryFowardable = value; }
         }
         public String CalculateUpto1
         {
             get { return CalculateUpto; }
             set { CalculateUpto = value; }
         }
         public String LeaveCode1
         {
             get { return LeaveCode; }
             set { LeaveCode = value; }
         }
     }




}

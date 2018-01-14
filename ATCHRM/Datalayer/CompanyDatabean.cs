using System;
using System.Collections.Generic;

using System.Text;

namespace ATCHRM.Datalayer
{
  public   class CompanyDatabean
    {
        int companypk;
        int branchpk;

        public int Branchpk
        {
            get { return branchpk; }
            set { branchpk = value; }
        }
        String companyname = null;
        String companycode = null;

        public int Companypk
        {
            get { return companypk; }
            set { companypk = value; }
        }
        

        public String Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }
       

        public String Companycode
        {
            get { return companycode; }
            set { companycode = value; }
        }

        String Adress1 = null;

        public String Adress11
        {
            get { return Adress1; }
            set { Adress1 = value; }
        }
        String Adress2 = null;

        public String Adress21
        {
            get { return Adress2; }
            set { Adress2 = value; }
        }
        int locationpk;

        public int Locationpk
        {
            get { return locationpk; }
            set { locationpk = value; }
        }
        String email = null;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        String phoneno = null;

        public String Phoneno
        {
            get { return phoneno; }
            set { phoneno = value; }
        }

        String zipcode = null;

        public String Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        String Faxno = null;

        public String Faxno1
        {
            get { return Faxno; }
            set { Faxno = value; }
        }

    }
   
    class BranchDataBean
    {
        int branchpk;

       
        int companypk;
        String branchName = null;
        String faxno = null;
        String email = null;
        String phoneno = null;
        String zipcode = null;
        String adress1 = null;
        public int Branchpk
        {
            get { return branchpk; }
            set { branchpk = value; }
        }
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
        int lctnpk;

        public int Companypk
        {
            get { return companypk; }
            set { companypk = value; }
        }    

        public String BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }
    

        public String Faxno
        {
            get { return faxno; }
            set { faxno = value; }
        }
      

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
     

        public String Phoneno
        {
            get { return phoneno; }
            set { phoneno = value; }
        }
     

        public String Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
    

        public int Lctnpk
        {
            get { return lctnpk; }
            set { lctnpk = value; }
        }


    }

    class locationBranchDatabean
    {
        int branchpk;

        public int Branchpk
        {
            get { return branchpk; }
            set { branchpk = value; }
        }
        int locationpk;

        public int Locationpk
        {
            get { return locationpk; }
            set { locationpk = value; }
        }
        String branchname = null;

        public String Branchname
        {
            get { return branchname; }
            set { branchname = value; }
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
        int lctnpk;

        public int Lctnpk
        {
            get { return lctnpk; }
            set { lctnpk = value; }
        }
        String phoneno = null;

        public String Phoneno
        {
            get { return phoneno; }
            set { phoneno = value; }
        }
        String email = null;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        String faxno = null;

        public String Faxno1
        {
            get { return faxno; }
            set { faxno = value; }
        }

        public String Faxno
        {
            get { return faxno; }
            set { faxno = value; }
        }
        String zipcode = null;

        public String Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        String llocationcode = null;

        public String Llocationcode
        {
            get { return llocationcode; }
            set { llocationcode = value; }
        }
    }

   public  class BankDataBean
    {
        int bankpk;
        int lctnpk;
        int userpk;
        DateTime dateadded;
        String bankName = null;
        String bankbranchName = null;
        String branchcode = null;
        String adress1 = null;
        String adress2 = null;
        String zipcode = null;
        String phonenum = null;
        String faxnum = null;
        String email = null;
        String swiftcode = null;
        public int Bankpk
        {
            get { return bankpk; }
            set { bankpk = value; }
        }
    
        public int Lctnpk
        {
            get { return lctnpk; }
            set { lctnpk = value; }
        }
        
        public int Userpk
        {
            get { return userpk; }
            set { userpk = value; }
        }
    
        public DateTime Dateadded
        {
            get { return dateadded; }
            set { dateadded = value; }
        }
       
        public String BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }

      
        public String BankbranchName
        {
            get { return bankbranchName; }
            set { bankbranchName = value; }
        }

       
        public String Branchcode
        {
            get { return branchcode; }
            set { branchcode = value; }
        }
        
        public String Adress1
        {
            get { return adress1; }
            set { adress1 = value; }
        }
      
        public String Adress2
        {
            get { return adress2; }
            set { adress2 = value; }
        }
      
        public String Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
       
        public String Phonenum
        {
            get { return phonenum; }
            set { phonenum = value; }
        }
        
        public String Faxnum
        {
            get { return faxnum; }
            set { faxnum = value; }
        }
      
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
      

        public String Swiftcode
        {
            get { return swiftcode; }
            set { swiftcode = value; }
        }

       
      
       
    }


   public class DepartmentDatabean
   {
       int deptid = 0;

       public int Deptid
       {
           get { return deptid; }
           set { deptid = value; }
       }

       String departmentName;

       public String DepartmentName
       {
           get { return departmentName; }
           set { departmentName = value; }
       }


   }



   public class SubDepartmentID
   {

       string subdeptid;

       public string Subdeptid
       {
           get { return subdeptid; }
           set { subdeptid = value; }
       }
       int deptid;

       public int Deptid
       {
           get { return deptid; }
           set { deptid = value; }
       }

       String Subdeptname;

       public String Subdeptname1
       {
           get { return Subdeptname; }
           set { Subdeptname = value; }
       }
   }
}

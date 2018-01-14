using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
namespace ATCHRM.Datalayer
{
    class DesignationDatabean
    {
        ApplicableSalaryCompDesg appsal = null;

        public ApplicableSalaryCompDesg Appsal
        {
            get { return appsal; }
            set { appsal = value; }
        }

        int subdeptPk = 0;

        public int SubdeptPk
        {
            get { return subdeptPk; }
            set { subdeptPk = value; }
        }


        String DesignationName = null;

        public String DesignationName1
        {
            get { return DesignationName; }
            set { DesignationName = value; }
        }
        String Description = null;

        public String Description1
        {
            get { return Description; }
            set { Description = value; }
        }
        String Levelno = null;

        public String Levelno1
        {
            get { return Levelno; }
            set { Levelno = value; }
        }
        int designationpk;

        public int Designationpk
        {
            get { return designationpk; }
            set { designationpk = value; }
        }

        int departmentpk;

        public int Departmentpk
        {
            get { return departmentpk; }
            set { departmentpk = value; }
        }
        int basicsal;

        public int Basicsal
        {
            get { return basicsal; }
            set { basicsal = value; }
        }
        int currencypk;

        public int Currencypk
        {
            get { return currencypk; }
            set { currencypk = value; }
        }

        int desgtype = 0;

        public int Desgtype
        {
            get { return desgtype; }
            set { desgtype = value; }
        }

       


    }


    public class ApplicableSalaryCompDesg
    {
        ArrayList Salcompid = null;
        ArrayList applicableleave = null;

        public ArrayList Applicableleave
        {
            get { return applicableleave; }
            set { applicableleave = value; }
        }
        public ArrayList Salcompid1
        {
            get { return Salcompid; }
            set { Salcompid = value; }
        }
        ArrayList saCompAmount = null;

       public ArrayList SaCompAmount
        {
            get { return saCompAmount; }
            set { saCompAmount = value; }
        }
    }

}

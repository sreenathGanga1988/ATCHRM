using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCHRM.Datalayer
{
    class SalaryCompDataBean
    {
        int salcomppk;

        public int Salcomppk
        {
            get { return salcomppk; }
            set { salcomppk = value; }
        }
        String salcompName = null;

        public String SalcompName
        {
            get { return salcompName; }
            set { salcompName = value; }
        }
        int calculationtype;

        public int Calculationtype
        {
            get { return calculationtype; }
            set { calculationtype = value; }
        }
        float Amount = 0;

        public float Amount1
        {
            get { return Amount; }
            set { Amount = value; }
        }


        int formulapk = 0;

        public int Formulapk
        {
            get { return formulapk; }
            set { formulapk = value; }
        }
        int componenttypepk;

        public int Componenttypepk
        {
            get { return componenttypepk; }
            set { componenttypepk = value; }
        }
    }


   public  class PerkDataBean
    {
        int perkPK = 0;

        public int PerkPK
        {
            get { return perkPK; }
            set { perkPK = value; }
        }

        String PerkCode = "";

        public String PerkCode1
        {
            get { return PerkCode; }
            set { PerkCode = value; }
        }

        String PerkName = "";


        float taxablepercentage = 0;

        public float Taxablepercentage
        {
            get { return taxablepercentage; }
            set { taxablepercentage = value; }
        }


        public String PerkName1
        {
            get { return PerkName; }
            set { PerkName = value; }
        }

    }
}

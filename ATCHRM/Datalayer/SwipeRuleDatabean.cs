using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCHRM.Datalayer
{
   public  class SwipeRuleDatabean
    {

        string checkinvalisswipe = null;

        public string Checkinvalisswipe
        {
            get { return checkinvalisswipe; }
            set { checkinvalisswipe = value; }
        }
        int checkinfrom;

        public int Checkinfrom
        {
            get { return checkinfrom; }
            set { checkinfrom = value; }
        }
        int checkinto;

        public int Checkinto
        {
            get { return checkinto; }
            set { checkinto = value; }
        }
        String checkinfromcriteria = null;

        public String Checkinfromcriteria
        {
            get { return checkinfromcriteria; }
            set { checkinfromcriteria = value; }
        }
       String checkintocriteria = null;

       public String Checkintocriteria
       {
           get { return checkintocriteria; }
           set { checkintocriteria = value; }
       }

       int EarlyCheckInupto = 0;

       public int EarlyCheckInupto1
       {
           get { return EarlyCheckInupto; }
           set { EarlyCheckInupto = value; }
       }
   int LateCheckInupto = 0;

   public int LateCheckInupto1
   {
       get { return LateCheckInupto; }
       set { LateCheckInupto = value; }
   }


   int EarlyCheckoutUPTO = 0;

   public int EarlyCheckoutUPTO1
   {
       get { return EarlyCheckoutUPTO; }
       set { EarlyCheckoutUPTO = value; }
   }

   int LateCheckOutupto = 0;

   public int LateCheckOutupto1
   {
       get { return LateCheckOutupto; }
       set { LateCheckOutupto = value; }
   }

   String EarlyCheckInfailaction = null;

   public String EarlyCheckInfailaction1
   {
       get { return EarlyCheckInfailaction; }
       set { EarlyCheckInfailaction = value; }
   }

String LateCheckInfailaction = null;

public String LateCheckInfailaction1
{
    get { return LateCheckInfailaction; }
    set { LateCheckInfailaction = value; }
}


String EarlyCheckoutfailaction = null;

public String EarlyCheckoutfailaction1
{
    get { return EarlyCheckoutfailaction; }
    set { EarlyCheckoutfailaction = value; }
}

String LateCheckOutfailAction = null;

public String LateCheckOutfailAction1
{
    get { return LateCheckOutfailAction; }
    set { LateCheckOutfailAction = value; }
}

String isactive = "Active";

public String Isactive
{
    get { return isactive; }
    set { isactive = value; }
}
int userpk;

public int Userpk
{
    get { return userpk; }
    set { userpk = value; }
}

DateTime dateadded;

public DateTime Dateadded
{
    get { return dateadded; }
    set { dateadded = value; }
}

    }
}

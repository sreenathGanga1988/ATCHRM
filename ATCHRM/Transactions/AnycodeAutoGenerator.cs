using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCHRM.Transactions
{
   public  class AnycodeAutoGenerator
    {
       public String  RecruitmentApplicationcodegenerator(int RecruitmentAppPk , String contractype)
       {
           String applicationnum = null;

           if (contractype =="Temporary")
           {
               if (RecruitmentAppPk < 10)
               {
                   applicationnum = "TM-0000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10 && RecruitmentAppPk < 100)
               {
                   applicationnum = "TM-000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100 && RecruitmentAppPk < 1000)
               {
                   applicationnum = "TM-00" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 1000 && RecruitmentAppPk < 10000)
               {
                   applicationnum = "TM-0" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10000 && RecruitmentAppPk < 100000)
               {
                   applicationnum = "TM-" + RecruitmentAppPk.ToString();
               }
               else
               {
                   applicationnum = "TM-" + RecruitmentAppPk.ToString();
               }
           }
           else
           {
               if (RecruitmentAppPk < 10)
               {
                   applicationnum = "RA-0000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10 && RecruitmentAppPk < 100)
               {
                   applicationnum = "RA-000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100 && RecruitmentAppPk < 1000)
               {
                   applicationnum = "RA-00" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 1000 && RecruitmentAppPk < 10000)
               {
                   applicationnum = "RA-0" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10000 && RecruitmentAppPk < 100000)
               {
                   applicationnum = "RA-" + RecruitmentAppPk.ToString();
               }
               else
               {
                   applicationnum = "RA-" + RecruitmentAppPk.ToString();
               }

           }
         

          


           return applicationnum;
       }

       public String LeaveApplicationcodegeneLAtor(int LeaveAppid)
       {
           String applicationnum = null;

           if (LeaveAppid < 10)
           {
               applicationnum = "LA-0000" + LeaveAppid.ToString();
           }
           else if (LeaveAppid >= 10 && LeaveAppid < 100)
           {
               applicationnum = "LA-000" + LeaveAppid.ToString();
           }
           else if (LeaveAppid >= 100 && LeaveAppid < 1000)
           {
               applicationnum = "LA-00" + LeaveAppid.ToString();
           }
           else if (LeaveAppid >= 1000 && LeaveAppid < 10000)
           {
               applicationnum = "LA-0" + LeaveAppid.ToString();
           }
           else if (LeaveAppid >= 10000 && LeaveAppid < 100000)
           {
               applicationnum = "LA-" + LeaveAppid.ToString();
           }
           else
           {
               applicationnum = "LA-" + LeaveAppid.ToString();
           }


           return applicationnum;
       }
       public String ContractRenewalCodeGenerator(int Contractrenewalid)
       {
           String applicationnum = null;

           if (Contractrenewalid < 10)
           {
               applicationnum = "CRA-0000" + Contractrenewalid.ToString();
           }
           else if (Contractrenewalid >= 10 && Contractrenewalid < 100)
           {
               applicationnum = "CRA-000" + Contractrenewalid.ToString();
           }
           else if (Contractrenewalid >= 100 && Contractrenewalid < 1000)
           {
               applicationnum = "CRA-00" + Contractrenewalid.ToString();
           }
           else if (Contractrenewalid >= 1000 && Contractrenewalid < 10000)
           {
               applicationnum = "CRA-0" + Contractrenewalid.ToString();
           }
           else if (Contractrenewalid >= 10000 && Contractrenewalid < 100000)
           {
               applicationnum = "CRA-" + Contractrenewalid.ToString();
           }
           else
           {
               applicationnum = "CRA-" + Contractrenewalid.ToString();
           }


           return applicationnum;
       }
       /// <summary>
       /// EMONUM GENERATOR
       /// </summary>
       /// <param name="Branch"></param>
       /// <param name="RecruitmentAppPk"></param>
       /// <returns></returns>
       public String EmployeeInternalcodegenerator( String Branch,  int RecruitmentAppPk)
       {

           int Num = 0;
           if (Branch != "")
           {
               Num = Branch.Length;
           }

           if ((Num < 3) && (Num > 0))
           {
               switch (Num)
               {
                   case 1:
                       Branch = Branch + "xx";

                       break;
                   case 2:

                       Branch = Branch + "x";
                       break;
                   case 0:

                       Branch = Branch + "xxx";
                       break;

                   default:

                       break;

               }
               Branch = Branch.Substring(0, 3);
           }


           String Empnum = null;
           if (Branch != "")
           {
               if (RecruitmentAppPk < 10)
               {
                   Empnum = Branch + "-0000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10 && RecruitmentAppPk < 100)
               {
                   Empnum = Branch + "-000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100 && RecruitmentAppPk < 1000)
               {
                   Empnum = Branch + "-00" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 1000 && RecruitmentAppPk < 10000)
               {
                   Empnum = Branch + "-0" + RecruitmentAppPk.ToString();
               }
               // change by Ankush else if (RecruitmentAppPk >= 10000 && RecruitmentAppPk < 100000 ) DATED 09062016
               else if (RecruitmentAppPk >= 10000)
               {
                   Empnum = Branch + RecruitmentAppPk.ToString();
               }
           }
           else if (Branch == "")
           {
               if (RecruitmentAppPk < 10)
               {
                   Empnum = "00000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10 && RecruitmentAppPk < 100)
               {
                   Empnum = "0000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100 && RecruitmentAppPk < 1000)
               {
                   Empnum = "000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 1000 && RecruitmentAppPk < 10000)
               {
                   Empnum = "00" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10000 && RecruitmentAppPk < 100000)
               {
                   Empnum = "0" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100000 && RecruitmentAppPk < 1000000)
               {
                   Empnum = RecruitmentAppPk.ToString();
               }
               else
               {
                   Empnum = RecruitmentAppPk.ToString();

               }
           }


           return Empnum;
       }








       public String RecruitmentCodeGenerator(String Branch, int RecruitmentAppPk ,String contracttype)
       {

           int Num = 0;
           if (Branch != "")
           {
               Num = Branch.Length;
           }

           if ((Num < 3) && (Num > 0))
           {
               switch (Num)
               {
                   case 1:
                       Branch = Branch + "xx";

                       break;
                   case 2:

                       Branch = Branch + "x";
                       break;
                   case 0:

                       Branch = Branch + "xxx";
                       break;

                   default:

                       break;

               }
               Branch = Branch.Substring(0, 3);
           }



           if (contracttype == "Temporary")
           {
               Branch = Branch + "-" + "TMP";
           }
                     String Empnum = null;
           if (Branch != "")
           {
               if (RecruitmentAppPk < 10)
               {
                   Empnum = Branch + "-0000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10 && RecruitmentAppPk < 100)
               {
                   Empnum = Branch + "-000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100 && RecruitmentAppPk < 1000)
               {
                   Empnum = Branch + "-00" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 1000 && RecruitmentAppPk < 10000)
               {
                   Empnum = Branch + "-0" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10000 && RecruitmentAppPk < 100000)
               {
                   Empnum = Branch + RecruitmentAppPk.ToString();
               }else
               {
                   Empnum = Branch + RecruitmentAppPk.ToString();
               }
           }
           else if (Branch == "")
           {
               if (RecruitmentAppPk < 10)
               {
                   Empnum = "00000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10 && RecruitmentAppPk < 100)
               {
                   Empnum = "0000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100 && RecruitmentAppPk < 1000)
               {
                   Empnum = "000" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 1000 && RecruitmentAppPk < 10000)
               {
                   Empnum = "00" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 10000 && RecruitmentAppPk < 100000)
               {
                   Empnum = "0" + RecruitmentAppPk.ToString();
               }
               else if (RecruitmentAppPk >= 100000 && RecruitmentAppPk < 1000000)
               {
                   Empnum = RecruitmentAppPk.ToString();
               }
               else
               {
                   Empnum = RecruitmentAppPk.ToString();
               }
           }










           return Empnum;
       }
       
       
       
       
       
       
       
       
       
       /// <summary>
       /// ADVANCEMENT CODE GENERATOR
       /// </summary>
       /// <param name="AdvanceAppid"></param>
       /// <returns></returns>
       public String AdvanceApplicationcodegeneLAtor(int AdvanceAppid)
       {
           String applicationnum = null;

           if (AdvanceAppid < 10)
           {
               applicationnum = "ADA-0000" + AdvanceAppid.ToString();
           }
           else if (AdvanceAppid >= 10 && AdvanceAppid < 100)
           {
               applicationnum = "ADA-000" + AdvanceAppid.ToString();
           }
           else if (AdvanceAppid >= 100 && AdvanceAppid < 1000)
           {
               applicationnum = "ADA-00" + AdvanceAppid.ToString();
           }
           else if (AdvanceAppid >= 1000 && AdvanceAppid < 10000)
           {
               applicationnum = "ADA-0" + AdvanceAppid.ToString();
           }
           else if (AdvanceAppid >= 10000 && AdvanceAppid < 100000)
           {
               applicationnum = "ADA-" + AdvanceAppid.ToString();
           }


           return applicationnum;
       }
       /// <summary>
       /// OTT APPLICATIONCODE
       /// </summary>
       /// <param name="OtAppPK"></param>
       /// <returns></returns>
       public String OTApplicationcodegenerator(int OtAppPK)
       {

           String applicationnum = null;
           

           if (OtAppPK < 10)
           {
               applicationnum = " OTA-0000" + OtAppPK.ToString();
           }
           else if (OtAppPK >= 10 && OtAppPK < 100)
           {
               applicationnum = " OTA-000" + OtAppPK.ToString();
           }
           else if (OtAppPK >= 100 && OtAppPK < 1000)
           {
               applicationnum = " OTA-00" + OtAppPK.ToString();
           }
           else if (OtAppPK >= 1000 && OtAppPK < 10000)
           {
               applicationnum = " OTA-0" + OtAppPK.ToString();
           }
           else if (OtAppPK >= 10000 && OtAppPK < 100000)
           {
               applicationnum = " OTA-" + OtAppPK.ToString();
           }else
           {
               applicationnum = " OTA-" + OtAppPK.ToString();
           }


           return applicationnum;


       }
       /// <summary>
       /// CREATES DESGAPPCODE
       /// </summary>
       /// <param name="DsgAppPk"></param>
       /// <returns></returns>
       public String DesgApplicationcodegenerator(int DsgAppPk)
       {

           String applicationnum = null;


           if (DsgAppPk < 10)
           {
               applicationnum = "DSGA-0000" + DsgAppPk.ToString();
           }
           else if (DsgAppPk >= 10 && DsgAppPk < 100)
           {
               applicationnum = "DSGA-000" + DsgAppPk.ToString();
           }
           else if (DsgAppPk >= 100 && DsgAppPk < 1000)
           {
               applicationnum = "DSGA-00" + DsgAppPk.ToString();
           }
           else if (DsgAppPk >= 1000 && DsgAppPk < 10000)
           {
               applicationnum = "DSGA-0" + DsgAppPk.ToString();
           }
           else if (DsgAppPk >= 10000 && DsgAppPk < 100000)
           {
               applicationnum = "DSGA-" + DsgAppPk.ToString();
           }


           return applicationnum;


       }
       /// <summary>
       /// CREAT SHIFT TRANSFER CODE
       /// </summary>
       /// <param name="shifttransferappPK"></param>
       /// <returns></returns>
       public String ShiftTransferApplicationCodeGenerator( int shifttransferappPK)
       {


           String applicationnum = null;


           if (shifttransferappPK < 10)
           {
               applicationnum = "SFTA-0000" + shifttransferappPK.ToString();
           }
           else if (shifttransferappPK >= 10 && shifttransferappPK < 100)
           {
               applicationnum = "SFTA-000" + shifttransferappPK.ToString();
           }
           else if (shifttransferappPK >= 100 && shifttransferappPK < 1000)
           {
               applicationnum = "SFTA-00" + shifttransferappPK.ToString();
           }
           else if (shifttransferappPK >= 1000 && shifttransferappPK < 10000)
           {
               applicationnum = "SFTA-0" + shifttransferappPK.ToString();
           }
           else if (shifttransferappPK >= 10000 && shifttransferappPK < 100000)
           {
               applicationnum = "SFTA-" + shifttransferappPK.ToString();
           }


           return applicationnum;

           
       }

       /// <summary>
       /// CREAT GATEPASSCODE
       /// </summary>
       /// <param name="gatepassid"></param>
       /// <returns></returns>
       public String GatepassCodeGenerator(int gatepassid)
       {
           String applicationnum = null;


           if (gatepassid < 10)
           {
               applicationnum = "GP-00000" + gatepassid.ToString();
           }
           else if (gatepassid >= 10 && gatepassid < 100)
           {
               applicationnum = "GP-0000" + gatepassid.ToString();
           }
           else if (gatepassid >= 100 && gatepassid < 1000)
           {
               applicationnum = "GP-000" + gatepassid.ToString();
           }
           else if (gatepassid >= 1000 && gatepassid < 10000)
           {
               applicationnum = "GP-00" + gatepassid.ToString();
           }
           else if (gatepassid >= 10000 && gatepassid < 100000)
           {
               applicationnum = "GP-0" + gatepassid.ToString();
           }

           else if (gatepassid >= 10000 && gatepassid < 100000)
           {
               applicationnum = "GP-" + gatepassid.ToString();
           }


           return applicationnum;

       }
       /// <summary>
       /// CREATE LHR APPLICATION CODE
       /// </summary>
       /// <param name="Appid"></param>
       /// <returns></returns>
       public String LHRApplicationCodeGenerator(int Appid)
       {
           String applicationnum = null;


           if (Appid < 10)
           {
               applicationnum = "LHRA-00000" + Appid.ToString();
           }
           else if (Appid >= 10 && Appid < 100)
           {
               applicationnum = "LHRA-0000" + Appid.ToString();
           }
           else if (Appid >= 100 && Appid < 1000)
           {
               applicationnum = "LHRA-000" + Appid.ToString();
           }
           else if (Appid >= 1000 && Appid < 10000)
           {
               applicationnum = "LHRA-00" + Appid.ToString();
           }
           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "LHRA-0" + Appid.ToString();
           }

           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "LHRA-" + Appid.ToString();
           }


           return applicationnum;

       }


       /// <summary>
       /// reject LhR Application code
       /// </summary>
       /// <param name="Appid"></param>
       /// <returns></returns>
       public String RejectLHApplication(int Appid)
       {
           String applicationnum = null;


           if (Appid < 10)
           {
               applicationnum = "RLH-00000" + Appid.ToString();
           }
           else if (Appid >= 10 && Appid < 100)
           {
               applicationnum = "RLH-0000" + Appid.ToString();
           }
           else if (Appid >= 100 && Appid < 1000)
           {
               applicationnum = "RLH-000" + Appid.ToString();
           }
           else if (Appid >= 1000 && Appid < 10000)
           {
               applicationnum = "RLH-00" + Appid.ToString();
           }
           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "RLH-0" + Appid.ToString();
           }

           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "RLH-" + Appid.ToString();
           }


           return applicationnum;
       }


       /// <summary>
       /// lEAVE Encashment Application code
       /// </summary>
       /// <param name="Appid"></param>
       /// <returns></returns>
       public String LeaveencashApplicationCode(int Appid)
       {
           String applicationnum = null;


           if (Appid < 10)
           {
               applicationnum = "LVEN-00000" + Appid.ToString();
           }
           else if (Appid >= 10 && Appid < 100)
           {
               applicationnum = "LVEN-0000" + Appid.ToString();
           }
           else if (Appid >= 100 && Appid < 1000)
           {
               applicationnum = "LVEN-000" + Appid.ToString();
           }
           else if (Appid >= 1000 && Appid < 10000)
           {
               applicationnum = "LVEN-00" + Appid.ToString();
           }
           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "LVEN-0" + Appid.ToString();
           }

           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "LVEN-" + Appid.ToString();
           }


           return applicationnum;
       }


       /// <summary>
       /// GET THE ADJUISTER CODE
       /// </summary>
       /// <param name="Appid"></param>
       /// <returns></returns>
       public String GETAdjusterCode(int Appid)
       {
           String applicationnum = null;


           if (Appid < 10)
           {
               applicationnum = "ATND-00000" + Appid.ToString();
           }
           else if (Appid >= 10 && Appid < 100)
           {
               applicationnum = "ATND-0000" + Appid.ToString();
           }
           else if (Appid >= 100 && Appid < 1000)
           {
               applicationnum = "ATND-000" + Appid.ToString();
           }
           else if (Appid >= 1000 && Appid < 10000)
           {
               applicationnum = "ATND-00" + Appid.ToString();
           }
           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "ATND-0" + Appid.ToString();
           }

           else if (Appid >= 10000 && Appid < 100000)
           {
               applicationnum = "ATND-" + Appid.ToString();
           }


           return applicationnum;
       }
   
   
   
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCHRM.Datalayer
{
   public class ShiftDataBean
    {
        int shiftpk;
        int noOfBreak;
        String ShiftName = null;
        DateTime starttime;
        DateTime endTime;



        public int Shiftpk
        {
            get { return shiftpk; }
            set { shiftpk = value; }
        }
     

       public int NoOfBreak
       {
           get { return noOfBreak; }
           set { noOfBreak = value; }
       }
   
       public String ShiftName1
       {
           get { return ShiftName; }
           set { ShiftName = value; }
       }
    
       public DateTime Starttime
       {
           get { return starttime; }
           set { starttime = value; }
       }


       public DateTime EndTime
       {
           get { return endTime; }
           set { endTime = value; }
       }
       private TimeSpan startofshift;

       public TimeSpan Startofshift
       {
           get { return startofshift; }
           set { startofshift = value; }
       }
       private TimeSpan endofshift;

       public TimeSpan Endofshift
       {
           get { return endofshift; }
           set { endofshift = value; }
       }


       TimeSpan ShftDuration;

       public TimeSpan ShftDuration1
       {
           get { return ShftDuration; }
           set { ShftDuration = value; }
       }
    }
   public class ShiftBreakDataBean
   {

       int breakpk;

       public int Breakpk
       {
           get { return breakpk; }
           set { breakpk = value; }
       }
       int shiftpk;

       public int Shiftpk
       {
           get { return shiftpk; }
           set { shiftpk = value; }
       }
       String breakname = null;

       public String Breakname
       {
           get { return breakname; }
           set { breakname = value; }
       }
       String Duration = null;

       public String Duration1
       {
           get { return Duration; }
           set { Duration = value; }
       }
       String uom = null;

       public String Uom
       {
           get { return uom; }
           set { uom = value; }
       }


   }
}

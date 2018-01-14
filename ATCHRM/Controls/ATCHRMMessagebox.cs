using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ATCHRM.Controls
{
   public class ATCHRMMessagebox
    {







       public static void Show(String Messagetype)
       {
           if (Messagetype == "Done")
           {
               MessageBoxDemo.frmShowMessage.Show("Done", "Action Completed", MessageBoxDemo.enumMessageIcon.Done, MessageBoxDemo.enumMessageButton.OKCancel);

           }
           else if (Messagetype == "Sucess")
           {
               MessageBoxDemo.frmShowMessage.Show("Sucess", "Action Completed", MessageBoxDemo.enumMessageIcon.Done, MessageBoxDemo.enumMessageButton.OKCancel);
           }

           else
           {
               MessageBoxDemo.frmShowMessage.Show(Messagetype.ToString());
           }



       }





    }
}

using System;
using System.Collections.Generic;

using System.Windows.Forms;
using ATCHRM.Properties;
using System.IO;

namespace ATCHRM
{
    /// <summary>
    /// entry point
    /// </summary>

  
    static class Program
    {     
      
        public static String ConnStr = "";
        public static String OurReportSource = "";
        public static String OurLogSource = "";
        public static String OurImagelocation = "";
        public static String database = "";
        public static String  Server = "";
        public static String dbUsername = "";
        public static String dbPassword = "";
     
        //  used for getting connectionstring
   // public static String ConnStr = Settings.Default.AtcHrmConnectionString;  
     //   dummy database
       // public static String ConnStr = Settings.Default.AtcHrmConnectionStringdummy;
       
        public static int USERPK;
        public static String UserType;
        public static int LOCTNPK;
        public static String UserName;
        public static String LOCATIONCODE;
        public static String EmpName;
        public static DateTime Datetoday=DateTime.Now ;
        public static String Logintype = "";
     

        public static Transactions.DatabasePicker databasepcker = null;
        public static int usernampk;



        [STAThread]


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            databasepcker = new Transactions.DatabasePicker();

         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //databasepcker.SetConnctionString();
          Application.Run(new LoginForm ());
       //   Application.Run(new encrypter ());
        
        }


    
    }
}

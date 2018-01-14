using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;



namespace ATCHRM
{
  
   public  class ErrorLogger
    {
   private String sLogFormat;
   private string sErrorTime;

    public ErrorLogger()
        {

            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;
           

           

         }

    public void adjusterloger(int empid ,DateTime dateofAction , String  ErrorType)
    {
        String apppath = Program.OurLogSource + "Adjstrlog.txt";
        String messg = "";

        messg = "Action Pending on EmployeeNumber " + empid + "For Date " + dateofAction.ToString()+ " " +ErrorType ;
        File.AppendAllText(apppath, messg + Environment.NewLine);

        File.AppendAllText(apppath, "********"+Program.Datetoday +"***************" + Environment.NewLine);
    }


       /// <summary>
       /// split the exception received
       /// and write it to the log file
       /// </summary>
       /// <param name="exp"></param>

    public void createErrorLog(Exception exp)

      {
          MessageBoxDemo.frmShowMessage.Show(exp.Message.ToString(),"ATCHRM Error ", MessageBoxDemo.enumMessageIcon.Error, MessageBoxDemo.enumMessageButton.OK);
          if (exp.Message.Substring(0, 24) == "Violation of UNIQUE KEY ")
          {
               MessageBoxDemo.frmShowMessage.Show("Enter a Unique Component Name", "ATCHRM Duplication ", MessageBoxDemo.enumMessageIcon.Error , MessageBoxDemo.enumMessageButton.OK );
             
          }

       // String apppath = Application.StartupPath + "\\log.txt";
          String apppath = Program.OurLogSource + "log.txt";

        String source = exp.Source;
        String trace = exp.StackTrace;

   
        string sErrMsg =  source +  trace;
      
        //  StreamWriter sw = new StreamWriter(sPathName + sErrorTime, true);

        File.AppendAllText(apppath, sLogFormat+ Environment.NewLine + sErrMsg + Environment.NewLine);

        File.AppendAllText(apppath,exp.ToString() + Environment.NewLine);

        File.AppendAllText(apppath, "********************************************************************************************************" + Environment.NewLine);

    }



    public void createErrorLog(Exception exp , String message)
    {
     
        // String apppath = Application.StartupPath + "\\log.txt";
        String apppath = Program.OurLogSource + "log.txt";

        String source = exp.Source;
        String trace = exp.StackTrace;


        string sErrMsg = source + trace;

        //  StreamWriter sw = new StreamWriter(sPathName + sErrorTime, true);
        File.AppendAllText(apppath, message.ToString() + Environment.NewLine);
        File.AppendAllText(apppath, sLogFormat + Environment.NewLine + sErrMsg + Environment.NewLine);        

        File.AppendAllText(apppath, "********************************************************************************************************" + Environment.NewLine);

    }


}
   public class Loginlog
   {
     


       public void loginnow( String Username , DateTime nowtime,String inorout)
       {
           String apppath = Program.OurLogSource + "LoginLog.txt";
           String messg = "";
           String systemname = System.Environment.MachineName;
           if (inorout == "in")
           {
                messg = Username + "Logged In at " + nowtime + "from " + systemname;
           }
           else
           {
                messg = Username + "Logged Out at  " + nowtime + " from  " + systemname;
           }


           File.AppendAllText(apppath, messg + Environment.NewLine);

           File.AppendAllText(apppath, "*********************************************************************************************" + Environment.NewLine);
       }
       
   }

    public static class Actionlog
{
        //public static void actiondone(String ActionType, String Action)
        //{
        //    string filename = Program.OurLogSource + "Actions.xmllog";
        //    StringBuilder sbuilder = new StringBuilder();
        //    using (StringWriter sw = new StringWriter(sbuilder))
        //    {
        //        using (XmlTextWriter w = new XmlTextWriter(sw))
        //        {
        //            w.WriteStartElement("LogInfo");
        //            w.WriteElementString("Time", DateTime.Now.ToString());
        //            w.WriteElementString("Type", ActionType);
        //            w.WriteElementString("User", Program.UserName);
        //            w.WriteElementString("Info", Action);
        //            w.WriteEndElement();
        //        }
        //    }
        //    using (StreamWriter w = new StreamWriter(filename, true, Encoding.UTF8))
        //    {
        //        w.WriteLine(sbuilder.ToString());
        //    }

        //}


        public static void actiondone(String ActionType, String Action,int empid)
        {
        using (SqlServerLinqDataContext cntxt= new SqlServerLinqDataContext (Program.ConnStr))
        {
            ActionLog_tbl actnlogtbl = new ActionLog_tbl();
            actnlogtbl.Empid = empid;
            actnlogtbl.ActionType = ActionType.Trim();
            actnlogtbl.Description = Action.Trim();
            actnlogtbl.UserPk = Program.USERPK;
            cntxt.ActionLog_tbls.InsertOnSubmit(actnlogtbl);
            cntxt.SubmitChanges(); 

        }
        }

}


    public class XmlLogfileStream : Stream
    {
        FileStream _fileStream = null;
        private bool _firstTime = true;
        private bool _closingTagRead = false;

        public XmlLogfileStream(string filename)
        {
            _fileStream = new FileStream(filename, FileMode.Open);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_closingTagRead) return 0; // file completely read
            if (_firstTime)  // nothing read so far, therefore provide the opening tag
            {
                _firstTime = false;
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("<x>");
                //
                // this code is not foolprof. Here I return "<x>" in one go, even if buffer does not provide enough space. Therefore the assert.
                // From experience I know that the buffer is always big enough.
                //
                Debug.Assert(data.Length <= count);
                for (int idx = 0; idx < data.Length; idx++)
                    buffer[offset + idx] = data[idx];
                return data.Length;
            }
            int bytesRead = _fileStream.Read(buffer, offset, count);
            if (bytesRead == 0 && !_closingTagRead)   // all contents of file read, but closing tag not provided yet
            {
                _closingTagRead = true;
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("</x>");
                Debug.Assert(data.Length <= count);
                for (int idx = 0; idx < data.Length; idx++)
                    buffer[offset + idx] = data[idx];
                return data.Length;
            }
            return bytesRead;
        }

        protected override void Dispose(bool disposing)
        {
            if (_fileStream != null)
            {
                _fileStream.Dispose();
                _fileStream = null;
            }
            base.Dispose(disposing);
        }
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // 
        // the foollowing methods nned to be overridden, equired by base class
        // just do default processing calling default implementations of FileStream

        public override bool CanRead
        {
            get { return _fileStream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _fileStream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override long Length
        {
            get { return _fileStream.Length; }
        }
        public override long Position
        {
            get
            {
                return _fileStream.Position;
            }
            set
            {
                _fileStream.Position = value;
            }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _fileStream.Seek(offset, origin);
        }
        public override void Flush()
        {
            _fileStream.Flush();
        }
        public override void SetLength(long value)
        {
            _fileStream.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}

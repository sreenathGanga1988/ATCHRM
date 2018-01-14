using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace ATCHRM.Transactions
{
    class DatabasePicker
    {

        private const string FILE_NAME = "C:\\DBkey.txt";

        public void SetConnctionString()
        {

            if (!File.Exists(FILE_NAME))
            {

                DialogResult dialogResult = MessageBox.Show("Database configuration file not found  Do you want to Reset it ? ", "Database Key not Found", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();

                    openFileDialog1.InitialDirectory = "c:\\";
                    openFileDialog1.Filter = "Text|*.txt|All|*.*";
                    openFileDialog1.RestoreDirectory = true;




                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            String Sourcefile = openFileDialog1.FileName;
                            File.Copy(Sourcefile, "c:\\DBkey.txt");
                            MessageBox.Show("Data Key Recieved", "Data Key");
                            SetConnctionString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Data Key");
                        }

                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }

                              
            }

            else
            {


              

                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader("c:\\DBkey.txt");

                string[] lines = File.ReadAllLines("c:\\DBkey.txt"); //File is in System.IO
              //  for atraco
                string firstLine = ""; //constring
                string secondline = ""; //reportlocation
                string ThirdLine = ""; //log
                string FourthLine = ""; //images
                string fifthline = ""; //servername
                string sixthline = ""; //databasename
                string seventhline = ""; //userid
                string eightline = "";//password
                if (Program.Logintype == "Office")
                {
                     firstLine = lines[1]; //constring
                     secondline = lines[2]; //reportlocation
                     ThirdLine = lines[3]; //log
                     FourthLine = lines[4]; //images
                     fifthline = lines[5]; //servername
                    sixthline = lines[6]; //databasename
                     seventhline = lines[7]; //userid
                     eightline = lines[8];//password
                }
                else
                {
                    firstLine = lines[10]; //constring
                    secondline = lines[11]; //reportlocation
                    ThirdLine = lines[12]; //log
                    FourthLine = lines[13]; //images
                    fifthline = lines[14]; //servername
                    sixthline = lines[15]; //databasename
                    seventhline = lines[16]; //userid
                    eightline = lines[17];

                }
             //   for Kenya
                
                //string firstLine = lines[0]; //constring
                //string secondline = lines[1]; //reportlocation
                //string ThirdLine = lines[2]; //log
                //string FourthLine = lines[3]; //images
                //string fifthline = lines[4]; //servername
                //string sixthline = lines[5]; //databasename
                //string seventhline = lines[6]; //userid
                //string eightline = lines[7];//password
               

            //     ATCHRM.Controls.ATCHRMMessagebox.Show(firstLine);

                Program.ConnStr = firstLine;
                Program.OurReportSource = secondline;
                Program.OurLogSource = ThirdLine;
                Program.OurImagelocation = FourthLine;
                Program.Server = fifthline;
                Program.database = sixthline;
                Program.dbUsername = seventhline;
                Program.dbPassword = eightline;
            }


        }





    }
}

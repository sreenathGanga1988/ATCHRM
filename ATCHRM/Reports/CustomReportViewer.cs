using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Reports
{
    public partial class CustomReportViewer : Form
    {
        public CustomReportViewer()
        {
            InitializeComponent();
        }

        public CustomReportViewer(String Reporttype,String NID ,String Name,String Message)
        {
            InitializeComponent();
            loadNidReport(NID, Name, Message);
        }

        public void loadNidReport(String NID,String Name,String Message)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Program.OurReportSource + "\\NIDStatus.rpt");
           
            ParameterFields parameterstoreport = new ParameterFields();
            ParameterField pfNID = new ParameterField();
            pfNID.ParameterFieldName = "NID"; 
            ParameterDiscreteValue dcItemYr = new ParameterDiscreteValue();
            dcItemYr.Value = NID;
            pfNID.CurrentValues.Add(dcItemYr);
            parameterstoreport.Add(pfNID);




            ParameterField pfname = new ParameterField();
            pfname.ParameterFieldName = "Name"; //year is Crystal Report Parameter name.
            ParameterDiscreteValue dcitenmname = new ParameterDiscreteValue();
            dcitenmname.Value = Name;
            pfname.CurrentValues.Add(dcitenmname);
            parameterstoreport.Add(pfname);




            ParameterField pfmssg = new ParameterField();
            pfmssg.ParameterFieldName = "Message"; //year is Crystal Report Parameter name.
            ParameterDiscreteValue dctitmsg = new ParameterDiscreteValue();
            dctitmsg.Value = Message;
            pfmssg.CurrentValues.Add(dctitmsg);
            parameterstoreport.Add(pfmssg);


            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.ParameterFieldInfo = parameterstoreport;
         
            ReportParameter();
           
        }
        private void ReportParameter()
        {

            //crystalReportViewer1.RefreshReport();

            

        }
    }
}

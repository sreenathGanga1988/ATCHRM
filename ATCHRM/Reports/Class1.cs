using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace ATCHRM.Reports
{
    class Logonvalues
    {







        public ReportDocument getpeport(String ReportLocation)
        {
            ConnectionInfo crconnectioninfo = new ConnectionInfo();
            ReportDocument cryrpt = new ReportDocument();
            TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();

            Tables CrTables;
            cryrpt.Load(ReportLocation);
            cryrpt.DataSourceConnections.Clear();
            //crconnectioninfo.ServerName = "SREENATH-IT\\SQLEXPRESS";
            //crconnectioninfo.DatabaseName = "ATCHRM";
            //crconnectioninfo.UserID = "sa";
            //crconnectioninfo.Password = "sreenath";

            crconnectioninfo.ServerName = Program.Server;
            crconnectioninfo.DatabaseName = Program.database;
            crconnectioninfo.UserID = Program.dbUsername ;
            crconnectioninfo.Password = Program.dbPassword;

           

            CrTables = cryrpt.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }

            return cryrpt;
        }







    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data;
namespace ATCHRM.Transactions
{
     public class DataExporter
    {

        public void exporttoexcel(System.Windows.Forms.DataGridView dataGridView1 )
        {

            try
            {
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


                // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // see the excel sheet behind the program
                app.Visible = true;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                        {
                            worksheet.Cells[i + 2, j + 1] = 0;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }

                    }
                }


                // save the application
                //   workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                // Exit from the application
                app.Quit();
            }
            catch (Exception)
            {
                
              
            }

        }

         public void ExportUltraGrid(Infragistics.Win.UltraWinGrid.UltraGrid  ultragrid)
        {
            if (ultragrid.Rows.Count > 65000)
            {
                MessageBox.Show("Data Greater than Excel MaximumSize");
                System.Windows.Forms.DataGridView dataGridView1 = new DataGridView();
                DataTable dr = (DataTable)ultragrid.DataSource;
                dataGridView1.DataSource = dr;
                exporttoexcel(dataGridView1);

            }
            else
            {
                Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ugrdexp = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter();
                SaveFileDialog svdialog = new SaveFileDialog();
                svdialog.Title = "Save As Excel";
                svdialog.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
                //svdialog.DefaultExt = ".xlsx";
                svdialog.ShowDialog();
                if (svdialog.FileName != "")
                {

                    ugrdexp.Export(ultragrid, svdialog.FileName);
                    MessageBox.Show("Exported");
                }
            }

        }


    
     
     }
}

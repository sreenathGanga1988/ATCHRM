using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM
{
    class MergeDatagridview:System.Windows.Forms.DataGridView 
    {
        private System.Windows.Forms.DataGridView Datagridview1;

        protected override void OnCellFormatting(System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
           base.OnCellFormatting(e);
            if ((e.RowIndex == 0) || (e.ColumnIndex < 0))
            {
                return;
            }
            if ((e.ColumnIndex == 1) || (e.ColumnIndex == 2) || (e.ColumnIndex == 3) || (e.ColumnIndex ==4))
            {
                if(IsRepeatedCellValue(e.RowIndex,e.ColumnIndex))
                {
                    e.Value=string.Empty;
                    e.FormattingApplied = true; 
                }
            }
       
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex ==4)
            {
                if (IsRepeatedCellValue(e.RowIndex, e.ColumnIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
                }
            }
            else
            {
 e.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
            }
        }

   
private void InitializeComponent()
{
   this.Datagridview1=new DataGridView();
   ((System.ComponentModel.ISupportInitialize)(this.Datagridview1 )).BeginInit();
   this.SuspendLayout();

   this.Datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
   this.Datagridview1.Location = new System.Drawing.Point(168, 55);
   this.Datagridview1.Name = "DataGridView1";
   this.Datagridview1.Size = new System.Drawing.Size(240, 150);
   this.Datagridview1.TabIndex = 1;
  

}
        

        private Boolean IsRepeatedCellValue(int rowindx, int colindx)
        {
            DataGridViewCell curcel;
            curcel = Rows[rowindx].Cells[colindx];
            DataGridViewCell PrevCel;
            PrevCel = Rows[rowindx - 1].Cells[colindx];
            if ((curcel.Value == PrevCel.Value) || (Convert.ToString(curcel.Value) != "" && Convert.ToString(PrevCel.Value) != "") && Convert.ToString(curcel.Value) ==Convert.ToString(PrevCel.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
   
    
}

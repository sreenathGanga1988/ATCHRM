using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
namespace ATCHRM.Transactions
{
   public static class ControlSetupper
    {
       public static void UltraGridNormalSetup(UltraGrid ultraGrid1)
       {
           UltraGridBand band = ultraGrid1.DisplayLayout.Bands[0];
           band.Override.AllowRowFiltering = DefaultableBoolean.True;
           band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
          ultraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;
          ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
          ultraGrid1 .Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
          ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
       }
    }


}

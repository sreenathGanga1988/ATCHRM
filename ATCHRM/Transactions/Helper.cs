using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace ATCHRM.Transactions
{
    /// <summary>
    /// helps to clearcontrols
    /// </summary>
   class Helper
    {
        public  void ClearFormControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control != null)
                {
                    checkcontrol1(control);
                }
            }
        }


        public void checkcontrol1(Control control)
        {
            try
            {
                CHECKCLEAR(control);


                foreach (Control child in control.Controls)
                {
                    checkcontrol1(child);
                }
            }
            catch (Exception)
            {
                
               
            }
                
            }



        public void CHECKCLEAR(Control control)
        {
            if (control is TextBox)
            {
                TextBox txtbox = (TextBox)control;
                txtbox.Text = string.Empty;
            }
            else if (control is CheckBox)
            {
                CheckBox chkbox = (CheckBox)control;
                chkbox.Checked = false;
            }
            else if (control is RadioButton)
            {
                RadioButton rdbtn = (RadioButton)control;
                rdbtn.Checked = false;
            }
            else if (control is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)control;
                dtp.Value = DateTime.Now;
            }
            else if (control is ComboBox)
            {
                ComboBox cmb = (ComboBox)control;
                cmb.SelectedIndex = -1;
            }
            else if (control is RichTextBox )
            {
                RichTextBox rht = (RichTextBox)control;
                
                rht.Text = string.Empty;
            }

            else if (control is Label )
            {
                Label lbl = (Label)control;

               if(lbl.Name=="lblstatus")
               {
                   lbl.Text = "*";
               }
               else if (lbl.Name == "StatusInformation")
               {
                   lbl.Text = "*";
               }
            }
        }



        public int calculateselected(DataGridView dsgview)
        {

            int flag = 0;
            for (int i = 0; i < dsgview.Rows.Count ; i++)
            {
                if (Convert.ToBoolean(dsgview.Rows[i].Cells[0].Value) == true)
                {
                    flag++;
                }
            
            
            }
            return flag;
        }




        public  DataTable GetComboBoxedDataTable
          (DataTable oldDataTable, string valueColumn, string textColumn,
          string topRowValue, string topRowText)
        {
            DataTable newDataTable = new DataTable();
            newDataTable.Columns.Add(valueColumn);
            newDataTable.Columns.Add(textColumn);

            foreach (DataRow oldDR in oldDataTable.Rows)
            {
                DataRow newDR = newDataTable.NewRow();
                newDR[0] = oldDR[valueColumn].ToString();
                newDR[1] = oldDR[textColumn].ToString();
                newDataTable.Rows.InsertAt(newDR, newDataTable.Rows.Count);
            }

            // Add your 'Select an item' option at the top
            DataRow dr = newDataTable.NewRow();
            dr[0] = topRowValue;
            dr[1] = topRowText;
            newDataTable.Rows.InsertAt(dr, 0);

            return newDataTable;
        }



        public Boolean isdateaccesible(DateTime actualdate , DateTime selecteddate)
        {
            Boolean issuccess = true;

            DateTime backlimit = actualdate.AddDays(-3);

            DateTime uplimit = actualdate;



            if (selecteddate >= backlimit && selecteddate <= uplimit)
            {
                issuccess = true;
            }
            else
            {
                issuccess = false;

            }

            return issuccess;
        }



        //public int comboboxfilter(int comboboxnum,ComboBox cmbbox1, ComboBox cmbbox2, ComboBox cmbbox3)
        //{
        //    int filter = 0;


        //    if (cmbbox1 != null)
        //    {

        //    }
        //    else if


        //    return filter;
        //}

     



  
  }
}

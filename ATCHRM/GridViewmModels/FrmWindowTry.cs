using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace ATCHRM.GridViewmModels
{
    public partial class FrmWindowTry : Form
    {
        DataSet salcomp;
        public FrmWindowTry()
        {
            InitializeComponent();
        }

        private void FrmWindowTry_Load(object sender, EventArgs e)
        {
            salcomp = ClsDatabase.Get_Data("select salcomppk,componentname from SalComponentMaster_tbl");
            ClsDatabase.Combo_Fill("select empid,empno from EmployeePersonalMaster_tbl", "empid", "empno", comboBox1);
            ClsDatabase.Combo_Fill("select form_det_id,form_name from Formula_details_tbl", "form_det_id", "form_name", comboBox2);
        }

        static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
        private string Formula_Value(string expression,int empid)
        {
            string  valu ="";
            char[] symb = { '+', '-', '*', '/', '%', '(', ')' };
            string[] var = expression.Split(symb);
            for (int i = 0; i < var.Length; i++)
            {
                if (salcomp.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < salcomp.Tables[0].Rows.Count; j++)
                    {
                        if (var[i] == Convert.ToString(salcomp.Tables[0].Rows[j][1]))
                        {
                            DataSet comp = ClsDatabase.Get_Data("select amount from EmployeesalCompApplicable_tbl where salcomppk="
                                + ""+ salcomp.Tables[0].Rows[j][0]+" and empid="+ empid +"");
                            if (comp.Tables[0].Rows.Count > 0)
                            {
                                expression = expression.Replace(var[i], Convert.ToString(comp.Tables[0].Rows[0][0]));
                            }
                            else
                            {
                                expression = expression.Replace(var[i],"0");
                            }
                        }
                    }
                }
             }
            valu = expression;
            return valu;
        }
        private void Final_Value()
        {
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataSet ds = ClsDatabase.Get_Data("select form_data from Formula_details_tbl where form_det_id=" + comboBox2.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    label1.Text = Formula_Value(Convert.ToString(ds.Tables[0].Rows[0][0]),Convert.ToInt32(comboBox1.SelectedValue ));
                    string form = Formula_Value(Convert.ToString(ds.Tables[0].Rows[0][0]), Convert.ToInt32(comboBox1.SelectedValue));
                    label2.Text = Convert.ToString(Evaluate(label1.Text));

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double val = 0.0;
            val = Convert.ToDouble(textBox3.Text) / 2;
            textBox2.Text = "" + val;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ATCHRM.Try
{
    public partial class UserRightrenewFrm : Form
    {
        Transactions.EmployeeRegTransaction empreg = null;
        public UserRightrenewFrm()
        {
            InitializeComponent();
            empreg = new Transactions.EmployeeRegTransaction();
        }

        private void getChildNodes(ToolStripDropDownItem mi, TreeNode tn)
        {
            foreach (object item in mi.DropDownItems)
            {
                // if toolstrip item is  spearator leave it
                if (item.GetType() == typeof(ToolStripSeparator))
                {
                    continue;
                }

                //else create a new node of same name
                TreeNode node = new TreeNode(((ToolStripDropDownItem)item).Text);
                //add it to node
                tn.Nodes.Add(node);
                //try to check foir more child node for the node
                getChildNodes(((ToolStripDropDownItem)item), node);
            }
        }

        private void try1_Load(object sender, EventArgs e)
        {
            loadtreeview();

            employecodeload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getexistingprivillege();  
        }


        public void loadtreeview()
        {
            //creates the instance of MDI parent 
            MainForm frm = new MainForm(1);
            //for each menusdtrip items
            foreach (ToolStripMenuItem tsmi in frm.menuStrip1.Items)
            {
                // create a new treenode with the menitem string as name
                TreeNode tn = new TreeNode(tsmi.Text);
                //try to get the  child nodes
                getChildNodes(tsmi, tn);
                treeView1.Nodes.Add(tn);
            }
        }

        
        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        public void getexistingprivillege()
        {
           
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {


                sqlConnection1.Open();


                using (SqlCommand command = new SqlCommand(@" SELECT        User_Rights.Form_name
FROM            User_Rights INNER JOIN
                         UserMaster_tbl ON User_Rights.User_Id = UserMaster_tbl.empid
WHERE        (User_Rights.Access_Right = 'Y') AND (UserMaster_tbl.Empid = @Param2)", sqlConnection1))
                {


                    command.Parameters.AddWithValue("@Param2", int.Parse(cmb_EmpCode.SelectedValue .ToString()));


                    SqlDataReader reader = command.ExecuteReader();
                    DataTable DT = new DataTable();

                    DT.Load(reader);

                    if (DT != null)
                    {
                        if(DT.Rows.Count!=0)
                        {

                            for (int i = 0; i < DT.Rows.Count; i++)
                            {
                                for (int x = 0; x < treeView1 .Nodes .Count; x++)                               
                                   
                                {
                                    if (treeView1 .Nodes [x].Text .ToString () == DT.Rows[i][0].ToString())
                                    {
                                        treeView1 .Nodes[x].Checked=true;
                                    }
                                   
                                }


                            }

                        }
                    }


                }

                sqlConnection1.Close();

               

            }
        }




        public void employecodeload()
        {
            cmb_EmpCode.DataSource = null;
            DataTable dt = empreg.getEmpcodeandUseriid(Program.LOCTNPK);
            cmb_EmpCode.DataSource = dt;
            cmb_EmpCode.DisplayMember = "UserId";
            cmb_EmpCode.ValueMember = "empid";
        }

        public void insertRights()
        {
            if (cmb_EmpCode.Text != "")
            {

                //deletes the existing rights
                GridViewmModels.ClsDatabase.Set_Data("delete from User_Rights where user_id=" + cmb_EmpCode.SelectedValue + "");

                CallNodesSelector();
            }


            ATCHRM.Controls.ATCHRMMessagebox.Show("Done");
            this.Close();

        }

        /// <summary>
        /// function to get the child nodes of treeview
        /// </summary>
        private void CallNodesSelector()
        {
            TreeNodeCollection nodes = this.treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                GetNodeRecursive(n);
            }
        }
        private void GetNodeRecursive(TreeNode treeNode)
        {
            //select only the checked nodes
            if (treeNode.Checked == true)
            {

                string checkedValue = treeNode.Text.ToString();
                //insert into the database
                GridViewmModels.ClsDatabase.Set_Data("insert into User_Rights (user_id,form_name,access_right) values "
                           + " (" + cmb_EmpCode.SelectedValue + ",'" + checkedValue + "','Y')");
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {

                
                //get the childnode again
                GetNodeRecursive(tn);

            }

        }

   
        

        private void btn_submmit_Click(object sender, EventArgs e)
        {
            insertRights();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
    
    
    
    
    
    
}

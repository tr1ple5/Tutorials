using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=dc-sql1-dr;Database=DerrickTest;User Id=ta;Password=2323";
                string conferenceSql = "SELECT * from tbl_NbaConference";
                string nbaTeamsSql = "Select * from tbl_NbaTeams";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand(conferenceSql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();

                //open connection
                con.Open();
                adapter.Fill(ds, "NbaConference");
                adapter.SelectCommand.CommandText = nbaTeamsSql;
                adapter.Fill(ds, "NbaTeams");
                con.Close();

                DataColumn parentCol = ds.Tables["NbaConference"].Columns["ConferenceId"];
                DataColumn childCol = ds.Tables["NbaTeams"].Columns["ConferenceId"];
                DataRelation relation = new DataRelation("Con_Team", parentCol, childCol);
                ds.Relations.Add(relation);

                foreach (DataRow parent in ds.Tables["NbaConference"].Rows)
                {
                    TreeNode nodeParent = treeView1.Nodes.Add(parent["ConferenceName"].ToString());
                    foreach (DataRow child in parent.GetChildRows(relation))
                    {
                        nodeParent.Nodes.Add(child["TeamName"].ToString());
                    }
                }
             
               
            }
            catch(Exception ex) 
            {
                throw ex;
            }
           
         
        }
    }
}

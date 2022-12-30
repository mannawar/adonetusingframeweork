using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration;

namespace adonetusingframeweork
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                //SqlCommand cmd = new SqlCommand("select * from AspNetUsers", con);
                //con.Open();
                //SqlDataReader rdr = cmd.ExecuteReader();
                //GridView1.DataSource = rdr;
                //GridView1.DataBind();

                //SqlCommand cmd = new SqlCommand("select Count(UserName) from AspNetUsers", con);
                //con.Open();
                //int TotalCount = (int)cmd.ExecuteScalar();
                //Response.Write("Total Rows="+ TotalCount.ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "Delete from tblProducts where Id =5";
                int TotalRowsDeleted = cmd.ExecuteNonQuery();
                Response.Write("Total Rows Deleted=" + TotalRowsDeleted.ToString() + "<br/>");

                cmd.CommandText = "Insert into tblProducts Values(4, 'Tabs', 300, 1000)";
                int TotalRowsAdded = cmd.ExecuteNonQuery();
                Response.Write("Total Rows Added=" + TotalRowsAdded.ToString() + "<br/>");

                cmd.CommandText = "update tblProducts set unitPrice=1800 where Id = 2";
                int TotalRowsUpdated = cmd.ExecuteNonQuery();
                Response.Write("Total Rows Added=" + TotalRowsUpdated.ToString() + "<br/>");

            }
            //OracleConnection con = new OracleConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=EmployeeDB;Integrated Security=True;");
            //OracleCommand cmd = new OracleCommand("select * from AspNetUsers", con);
            //con.Open();
            //OracleDataReader rdr = cmd.ExecuteReader();
            //GridView1.DataSource = rdr;
            //GridView1.DataBind();
            //con.Close();
        }
    }
}
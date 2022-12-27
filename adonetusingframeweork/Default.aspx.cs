using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace adonetusingframeweork
{
    public partial class _Default : Page
    {
        [Obsolete]
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=EmployeeDB;Integrated Security=True;");
            //SqlCommand cmd = new SqlCommand("select * from AspNetUsers", con);
            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //GridView1.DataSource = rdr;
            //GridView1.DataBind();
            //con.Close();

            OracleConnection con = new OracleConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=EmployeeDB;Integrated Security=True;");
            OracleCommand cmd = new OracleCommand("select * from AspNetUsers", con);
            con.Open();
            OracleDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            con.Close();
        }
    }
}
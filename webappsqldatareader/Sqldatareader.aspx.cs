using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adonetusingframeweork
{
    public partial class Sqldatareader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from tblProductInventory; select* from tblProductCategories", con);
                con.Open();
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    ProductGridView.DataSource = rdr;
                    ProductGridView.DataBind();

                    while(rdr.NextResult())
                    {
                        CategoryGridView.DataSource = rdr;
                        CategoryGridView.DataBind();
                    }

                }
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webappsqldatareader
{
    public partial class Sqlcachedataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tblProducts", con);
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    Cache["Data"] = ds;

                    gvProducts.DataSource = ds;
                    gvProducts.DataBind();
                }
                lblMessage.Text = "Data loaded from Database";
            }
            else
            {
                gvProducts.DataSource = (DataSet)Cache["Data"];
                gvProducts.DataBind();
                lblMessage.Text = "Data loaded from Cache";
            }
        }
        protected void btnClearCache_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");
                lblMessage.Text = "Data cleared in cache";
            }
            else
            {
                lblMessage.Text = "No Data in cache";
            }
        }
    }
}
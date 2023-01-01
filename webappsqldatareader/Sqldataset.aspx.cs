using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace webappsqldatareader
{
    public partial class Sqldataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("spGetData", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                da.Fill(ds);

                ds.Tables[0].TableName = "Product";
                ds.Tables[1].TableName = "Category";


                ProductGridView.DataSource = ds.Tables["Product"];
                ProductGridView.DataBind();

                ProductCategoryGridView.DataSource = ds.Tables["Category"];
                ProductCategoryGridView.DataBind();
            }
        }
    }
}
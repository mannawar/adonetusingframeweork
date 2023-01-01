using System;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace webappsqldatareader
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Id, Name, UnitPrice from tblProducts", con);
                //SqlDataReader rdr = new SqlDataReader(); //cannot create an instance of SqlDatareader 
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("Id");
                    table.Columns.Add("Name");
                    table.Columns.Add("UnitPrice");
                    table.Columns.Add("DiscountedPrice");

                    while (rdr.Read())
                    {
                        DataRow dataRow = table.NewRow();

                        int OriginalPrice = Convert.ToInt32(rdr["unitPrice"]);
                        double DiscountedPrice = OriginalPrice * 0.9;

                        dataRow["Id"] = rdr["Id"];
                        dataRow["Name"] = rdr["Name"];
                        dataRow["UnitPrice"] = OriginalPrice;
                        dataRow["DiscountedPrice"] = DiscountedPrice;

                        table.Rows.Add(dataRow);
                    }
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }

            }
        }
    }
}
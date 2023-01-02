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
    public partial class Stronglytypeddataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string SelectQuery = "select * from tblStudents";
            SqlDataAdapter da = new SqlDataAdapter(SelectQuery, con);

            DataSet dataset = new DataSet();
            da.Fill(dataset, "Students");
            Session["DATASET"] = dataset;

            GridView1.DataSource = from dataRow in dataset.Tables["Students"].AsEnumerable()
                                   select new Student
                                   {
                                       ID = Convert.ToInt32(dataRow["ID"]),
                                       Name = dataRow["Name"].ToString(),
                                       Gender = dataRow["Gender"].ToString(),
                                       TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
                                   };

            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = (DataSet)Session["DATASET"];

            if(string.IsNullOrEmpty(TextBox1.Text))
            {
                GridView1.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dataRow["ID"]),
                                           Name = dataRow["Name"].ToString(),
                                           Gender = dataRow["Gender"].ToString(),
                                           TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
                                       };

                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
                                       where dataRow["Name"].ToString().ToUpper().StartsWith(TextBox1.Text.ToUpper())
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dataRow["ID"]),
                                           Name = dataRow["Name"].ToString(),
                                           Gender = dataRow["Gender"].ToString(),
                                           TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
                                       };

                GridView1.DataBind();
            }
        }
    }
}
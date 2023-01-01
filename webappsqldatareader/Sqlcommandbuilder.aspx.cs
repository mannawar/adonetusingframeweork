using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;

namespace webappsqldatareader
{
    public partial class Sqlcommandbuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            string sqlQuery = "select * from tblStudents where ID=" + txtStudentID.Text;
            //SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            //Set the SelectCommand Property of SqlDataAdapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(sqlQuery, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Students");

            ViewState["SQL_QUERY"] = sqlQuery;
            ViewState["DATASET"] = ds;

            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                txtStudentName.Text = dr["Name"].ToString();
                ddlGender.SelectedValue = dr["Gender"].ToString();
                txtTotalMarks.Text = dr["TotalMarks"].ToString();
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No Students with Id = " + txtStudentID.Text;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            //Create an instance of SqlCommandBuilderClass and associate the SqlDataAdapter object using DataAdapter property
            SqlCommandBuilder builder = new SqlCommandBuilder();
            builder.DataAdapter = da;

            DataSet ds = (DataSet)ViewState["DATASET"];

            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                dr["Name"] = txtStudentName.Text;
                dr["Gender"] = ddlGender.SelectedValue;
                dr["TotalMarks"] = txtTotalMarks.Text;

            }
            int rowsUpdated = da.Update(ds, "Students");

            if(rowsUpdated > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = rowsUpdated + " rows updated";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No rows updated";
            }
            lblInsert.Text = builder.GetInsertCommand().CommandText;
            lblUpdate.Text = builder.GetUpdateCommand().CommandText;
            lblDelete.Text = builder.GetDeleteCommand().CommandText;

        }
    }
}
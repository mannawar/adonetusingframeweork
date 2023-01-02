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
    public partial class Disconnecteddataaccess : System.Web.UI.Page
    {
        public void GetDataFromDB()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string strSelectQuery = "select * from tblStudents";
            SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Students");

            ds.Tables["Students"].PrimaryKey = new DataColumn[] { ds.Tables["Students"].Columns["ID"] };
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            lblStatus.Text = "Data Loaded from database";
        }

        private void GetDataFromCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetDataFromDB_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetDataFromCache();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            ds.Tables["Students"].Rows.Find(e.Keys["ID"]).Delete();
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr["Name"] = e.NewValues["Name"];
                dr["Gender"] = e.NewValues["Gender"];
                dr["TotalMarks"] = e.NewValues["TotalMarks"];
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GridView1.EditIndex = -1;
                GetDataFromCache();
            }
        }
        protected void btnUpdateDatabaseTable_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);

            string strSelectQuery = "select * from tblStudents";

            SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);

            DataSet ds = (DataSet)Cache["DATASET"];

            string strUpdateCommand = "Update tblStudents set Name=@Name, Gender=@Gender, TotalMarks = @TotalMarks where ID=@ID";

            SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);


            updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            updateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 50, "Gender");
            updateCommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
            updateCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            da.UpdateCommand = updateCommand;

            string strdeleteCommand = "Delete from tblStudents where ID=@ID";

            SqlCommand deleteCommand = new SqlCommand(strdeleteCommand, con);

            deleteCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            da.DeleteCommand = deleteCommand;

            da.Update(ds, "Students");

            lblStatus.Text = "Updated database";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            //DataRow newDataRow = ds.Tables["Students"].NewRow();
            //newDataRow["ID"] = 101;
            ////ds.Tables["Students"].Rows.Add(newDataRow);

            //foreach(DataRow dr in ds.Tables["Students"].Rows)
            //{
            //    if(dr.RowState == DataRowState.Deleted)
            //    {
            //        Response.Write(dr["ID", DataRowVersion.Original].ToString() + "-" + dr.RowState.ToString() + "<br />");
            //    }
            //    else
            //    {
            //        Response.Write(dr["ID"].ToString() + "-" + dr.RowState.ToString() + "<br />");
            //    }

            //}
            //Response.Write(newDataRow.RowState.ToString());

            //RejectChanges method
            //if(ds.HasChanges())
            //{
            //    ds.RejectChanges();
            //Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            //GetDataFromCache();
            //    lblStatus.Text = "Changes undone";
            //    lblStatus.ForeColor = System.Drawing.Color.Green;
            //}
            //else
            //{
            //    lblStatus.Text = "Changes done";
            //    lblStatus.ForeColor = System.Drawing.Color.Red;
            //}

            //AcceptChanges method
            ds.AcceptChanges();
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();
        }
    }
}
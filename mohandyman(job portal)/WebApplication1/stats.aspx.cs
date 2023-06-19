using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using Microsoft.Ajax.Utilities;

namespace WebApplication1
{
    public partial class stats : System.Web.UI.Page
    {
        private string _conString =
    WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prodstats();
                userstats();
                catstats();
            }
        }
        private void prodstats()
        {

            SqlConnection dbcon = new SqlConnection(_conString);
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = "productcount";
            scmd.Connection = dbcon;
            dbcon.Open();
            hyprod.Text = scmd.ExecuteScalar().ToString();
            dbcon.Close();

        }
        private void userstats()
        {

            SqlConnection dbcon = new SqlConnection(_conString);
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = "usercount";
            scmd.Connection = dbcon;
            dbcon.Open();
            hyuser.Text = scmd.ExecuteScalar().ToString();
            dbcon.Close();

        }

        private void catstats()
        {

            SqlConnection dbcon = new SqlConnection(_conString);
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = "catcount";
            scmd.Connection = dbcon;
            dbcon.Open();
            hycat.Text = scmd.ExecuteScalar().ToString();
            dbcon.Close();

        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class viewreserveproduct : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("~/home");
            }
            else
            {

                if (!Page.IsPostBack)
                {
                    getprodreserve();

                }

            }
           

        }

        private void getprodreserve()
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand scmd = new SqlCommand();
            scmd.CommandText = "SELECT * FROM tblproductUser INNER JOIN tblproduct ON tblproductUser.product_id = tblproduct.product_id INNER JOIN tbluser ON tblproductUser.user_id = tbluser.user_id  WHERE tblproductUser.user_id='" + Session["userid"] + "'";
            scmd.Parameters.AddWithValue("user_id", Convert.ToInt32(Session["userid"]));
            scmd.Connection = con;
            // Create DataAdapter named dad (Refer to slide 7)
            SqlDataAdapter da = new SqlDataAdapter(scmd);
            //Create DataSet/DataTable named dtMovies
            DataTable dt = new DataTable();
            //Populate the datatable using the Fill()
            using (da)
            {
                da.Fill(dt);
            }
            //Bind datatable to gridview
            GrdView1.DataSource = dt;
            GrdView1.DataBind();
        }

 

        protected void GrdView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GrdView1.PageIndex = e.NewPageIndex;
            getprodreserve();

        }
    }
}
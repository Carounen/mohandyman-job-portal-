using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace WebApplication1
{

    public partial class details : System.Web.UI.Page
    {

        private string _conString =
    WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getdetails();
            }
        }

        private void getdetails()
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);


            // Create Command
            SqlCommand scmd = new SqlCommand();

            int qs = Convert.ToInt32(Request.QueryString["id"]);

            scmd.CommandText = "SELECT * FROM tblProduct where product_id = " + qs;
            scmd.Connection = con;
            // Create DataAdapter named dad (Refer to slide 7)
            SqlDataAdapter da = new SqlDataAdapter(scmd);
            //Create DataSet/DataTable named dtProduct
            DataTable dt = new DataTable();
            //Populate the datatable using the Fill()
            using (da)
            {
                da.Fill(dt);
            }

            //Bind datatable to gridview

            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();

        }

       
    }

}
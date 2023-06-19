using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class addprod : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindproductData();
                BindCategory();
                ListItem li = new ListItem("Select Category", "-1");
                ddlcat.Items.Insert(0, li);

            }

        }

        private void BindCategory()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblcategory";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dt = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);
            }
            //Set the DataTable as the DataSource
            ddlcat.DataSource = dt;
            //assign the FIELD values to the dropdown
            ddlcat.DataTextField = "category";
            ddlcat.DataValueField = "category_id";
            ddlcat.DataBind();
        }


        private void BindproductData()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tblproduct";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dt = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);
            }

            //Set the DataTable as the DataSource
           
        }


        protected void btnAddproduct_Click(object sender, EventArgs e)
        {
            String filen = "avatar.jpg";
            String fileshe = "avatar2.jpg";
            //check if the fileupload contains a file before uploading
            if (picture.HasFile)
            {
                filen = Path.GetFileName(picture.PostedFile.FileName);
                picture.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }

            //check if the fileupload contains a file before uploading
            /*if (fuschedule.HasFile)
            {
                fileshe = Path.GetFileName(fuschedule.PostedFile.FileName);
                fuschedule.PostedFile.SaveAs(Server.MapPath("~/images/") +
                fileshe);
            }*/
            Boolean IsAdded = false;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //add INSERT statement to create new movie
            cmd.CommandText = "insert into tblproduct (product_name,status,cost,brand,usage_time,description,expiry_date,pictures,document,location_of_prod,category_id,user_id) values (@pname,@status,@cost, @brand,@usage_time,@desc,@expd, @pic,@doc,@loc,@cid,@uid)";
            //create Parameterized query to prevent sql injection by
            cmd.Parameters.AddWithValue("@cid", ddlcat.SelectedValue);
            cmd.Parameters.AddWithValue("@pname", txtproductname.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtdesc.Text.Trim());
            cmd.Parameters.AddWithValue("@brand", txtbrand.Text.Trim());
            cmd.Parameters.AddWithValue("@cost", txtcost.Text.Trim());
            cmd.Parameters.AddWithValue("@usage_time", use.Text.Trim());
            cmd.Parameters.AddWithValue("@expd", txtexp.Text.Trim());
            cmd.Parameters.AddWithValue("@loc", txtloc.Text.Trim());
            cmd.Parameters.AddWithValue("@pic", filen);
            cmd.Parameters.AddWithValue("@doc", "../../images/" + fileshe);
            cmd.Parameters.AddWithValue("@status", chkstatus.Checked);
            cmd.Parameters.AddWithValue("@uid", Session["userid"]);

            cmd.Connection = con;
            con.Open();
            //use Command method to execute INSERT statement and return
            //Boolean true if number of records inserted is greater than zero
            IsAdded = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsAdded)
            {
                lblMsg.Text = txtproductname.Text + " product added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData()
                BindproductData();
            }
            else
            {
                lblMsg.Text = "Error while adding product " + txtproductname.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
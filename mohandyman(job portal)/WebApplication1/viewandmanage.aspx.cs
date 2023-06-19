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
using static System.Net.WebRequestMethods;
using System.Threading;
namespace WebApplication1
{
    public partial class viewandmanage : System.Web.UI.Page
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
                    BindproductData();
                    BindCategory();
                    ListItem li = new ListItem("Select Category", "-1");
                    ddlcat.Items.Insert(0, li);

                }

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
            cmd.CommandText = "SELECT * FROM tblproduct where user_id = '" + Session["userid"] + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dt = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);
            }

            //Set the DataTable as the DataSource
            gvs.DataSource = dt;
            gvs.DataBind();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //check whether the moviename textbox is empty
            if (string.IsNullOrWhiteSpace(txtproductname.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Boolean IsUpdated = false;
            //get the movieid from the textbox
            int product_id = Convert.ToInt32(txtproductId.Text);
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add UPDATE statement to update the movie
            cmd.CommandText = "update tblproduct set product_name=@pname,status=@status,cost=@cost,brand=@brand,usage_time=@usage_time,description=@desc,expiry_date=@expd,pictures=@pic,location_of_prod=@loc where product_id=@pid";
            //Create the parameterized queries
            cmd.Parameters.AddWithValue("@pid", product_id);
            cmd.Parameters.AddWithValue("@pname", txtproductname.Text.Trim());

            cmd.Parameters.AddWithValue("@desc", txtdesc.Text.Trim());
            cmd.Parameters.AddWithValue("@brand", txtbrand.Text.Trim());
            cmd.Parameters.AddWithValue("@cost", txtcost.Text.Trim());
            cmd.Parameters.AddWithValue("@usage_time", use.Text.Trim());
            cmd.Parameters.AddWithValue("@expd", txtexp.Text.Trim());
            cmd.Parameters.AddWithValue("@loc", txtloc.Text.Trim());


            String filen = images.ImageUrl.Substring(8);


            if (picture.HasFile)
            {
                filen = Path.GetFileName(picture.PostedFile.FileName);
                picture.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }



            cmd.Parameters.AddWithValue("@pic", filen);

            cmd.Parameters.AddWithValue("@status", chkstatus.Checked);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute UPDATE statement and return
            //boolean if number of records UPDATED is greater than zero
            IsUpdated = cmd.ExecuteNonQuery() > 0;

            con.Close();
            if (IsUpdated)
            {
                lblMsg.Text = txtproductname.Text + " product updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the
                BindproductData();
            }
            else
            {
                lblMsg.Text = "Error while updating product " + txtproductname.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();



        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            //check whether the txtmoviename textbox is empty
            if (string.IsNullOrWhiteSpace(txtproductname.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Boolean IsDeleted = false;
            //get the movieid from the textbox
            int productid = Convert.ToInt32(txtproductId.Text);
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add DELETE statement to delete the selected movie
            cmd.CommandText = " delete from tblproduct where product_id=@pid ";
            //Create a parametererized query
            cmd.Parameters.AddWithValue("@pid", productid);
            cmd.Connection = con;
            con.Open();
            //use Command method to execute DELETE statement and return
            //Boolean True if number of records DELETED is greater than zero
            IsDeleted = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsDeleted)
            {
                lblMsg.Text = txtproductname.Text + " product deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the
                BindproductData();
            }

            else
            {
                lblMsg.Text = "Error while deleting product " + txtproductname.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        protected void gvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            images.Visible = true;


            txtproductId.Text =
            (gvs.DataKeys[gvs.SelectedIndex].Value.ToString());

            txtproductname.Text =
            ((Label)gvs.SelectedRow.FindControl("lblproductName")).Text;

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            //cmd.Parameters.AddWithValue("@mid", txtproductId.Text);
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tblproduct where user_id ='" + Session["userid"] + "'";
            cmd.Parameters.AddWithValue("user_id", Convert.ToInt32(Session["userid"]));
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())

            {
                //retrieving FIELD values and assign the form controls

                ddlcat.SelectedValue = dr["category_id"].ToString();

                txtcost.Text = dr["cost"].ToString();
                txtdesc.Text = dr["description"].ToString();
                txtbrand.Text = dr["brand"].ToString();
                use.Text = dr["usage_time"].ToString();
                txtexp.Text = dr["expiry_date"].ToString();
                txtloc.Text = dr["location_of_prod"].ToString();

                chkstatus.Checked = (Boolean)dr["status"];
                images.ImageUrl = "~/images/" + dr["pictures"].ToString();


            }
            con.Close();
 
            btnupdate.Visible = true;
            btndelete.Visible = true;

            btncancel.Visible = true;
        }

        private void ResetAll()

        {
      
            btncancel.Visible = false;
            btnupdate.Visible = true;
            btndelete.Visible = true;
            ddlcat.SelectedIndex = 0;
            txtproductname.Text = "";
            txtcost.Text = "";
            txtdesc.Text = "";
            txtbrand.Text = "";
            use.Text = "";
            txtexp.Text = "";


            chkstatus.Checked = false;
            images.ImageUrl = "";

        }
    }
}
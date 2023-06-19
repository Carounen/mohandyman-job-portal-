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
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class managecategory : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_name"] == null)
            {
                Response.Redirect("~/home");
            }
            else
            {

                if (!Page.IsPostBack)
                {
                    Bindcat();
                    
                   

                }

            }
        }


        private void Bindcat()
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
            gvs.DataSource = dt;
            gvs.DataBind();
        }

        protected void btnAddcategory_Click(object sender, EventArgs e)
        {


            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd2 = new SqlCommand();

            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
           
            cmd2.CommandText = "select * from tblcategory where category=@un";
            cmd2.Parameters.AddWithValue("@un", txtcatname.Text.Trim());
            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd2.ExecuteReader();
            //Check if username already exists in the DB
            if (dr.HasRows)
            {
                lblMsg.Text = "Category Already Exist, Please Choose Another";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                txtcatname.Focus();
            }
            else
            {
                //Ensure the DataReader is closed
                dr.Close();

                Boolean IsAdded = false;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                //add INSERT statement to create new movie
                cmd.CommandText = "insert into tblcategory (category) values (@cat)";
                //create Parameterized query to prevent sql injection by

                cmd.Parameters.AddWithValue("@cat", txtcatname.Text.Trim());


                cmd.Connection = con;
               
                //use Command method to execute INSERT statement and return
                //Boolean true if number of records inserted is greater than zero
                IsAdded = cmd.ExecuteNonQuery() > 0;
                con.Close();
                if (IsAdded)
                {
                    lblMsg.Text = txtcatname.Text + " category added successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    //Refresh the GridView by calling the BindMovieData()
                    Bindcat();
                }
                else
                {
                    lblMsg.Text = "Error while adding category " + txtcatname.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                ResetAll();

            }

        }

            protected void btnupdate_Click(object sender, EventArgs e)
            {
            
                //check whether the moviename textbox is empty
                if (string.IsNullOrWhiteSpace(txtcatname.Text))
                {
                    lblMsg.Text = "Please select record to update";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

          
            Boolean IsUpdated = false;
                //get the movieid from the textbox
                int category_id = Convert.ToInt32(txtcatId.Text);
                SqlConnection con = new SqlConnection(_conString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            //Add UPDATE statement to update the movie
            cmd.CommandText = "update tblcategory set category=@cname where category_id=@cid";
                //Create the parameterized queries
                cmd.Parameters.AddWithValue("@cid", category_id);
                cmd.Parameters.AddWithValue("@cname", txtcatname.Text.Trim());




                con.Open();
                //use Command method to execute UPDATE statement and return
                //boolean if number of records UPDATED is greater than zero
                IsUpdated = cmd.ExecuteNonQuery() > 0;

                con.Close();
                if (IsUpdated)
                {
                    lblMsg.Text = txtcatname.Text + " category updated successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    //Refresh the GridView by calling the
                    Bindcat();
                }
                else
                {
                    lblMsg.Text = "Error while updating category " + txtcatname.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                ResetAll();



            }

            protected void btndelete_Click(object sender, EventArgs e)
            {
                //check whether the txtmoviename textbox is empty
                if (string.IsNullOrWhiteSpace(txtcatname.Text))
                {
                    lblMsg.Text = "Please select record to delete";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                Boolean IsDeleted = false;
                //get the movieid from the textbox
                int category_id = Convert.ToInt32(txtcatId.Text);
                SqlConnection con = new SqlConnection(_conString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                //Add DELETE statement to delete the selected movie
                cmd.CommandText = " delete from tblcategory where category_id=@cid ";
                //Create a parametererized query
                cmd.Parameters.AddWithValue("@cid", category_id);
                cmd.Connection = con;
                con.Open();
                //use Command method to execute DELETE statement and return
                //Boolean True if number of records DELETED is greater than zero
                IsDeleted = cmd.ExecuteNonQuery() > 0;
                con.Close();
                if (IsDeleted)
                {
                    lblMsg.Text = txtcatname.Text + " category deleted successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    //Refresh the GridView by calling the
                    Bindcat();
                }

                else
                {
                    lblMsg.Text = "Error while deleting category " + txtcatname.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                ResetAll();
            }

            protected void btncancel_Click(object sender, EventArgs e)
            {

                ResetAll();
            }





            private void ResetAll()

            {
                btnAddcategory.Visible = true;
                btncancel.Visible = false;
                btnupdate.Visible = true;
                btndelete.Visible = true;

                txtcatname.Text = "";


            }





            protected void gvs_SelectedIndexChanged(object sender, EventArgs e)
            {

                lblMsg.Text = "";



                txtcatId.Text =
                (gvs.DataKeys[gvs.SelectedIndex].Value.ToString());

                txtcatname.Text =
                ((Label)gvs.SelectedRow.FindControl("lblcat")).Text;

                SqlConnection con = new SqlConnection(_conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //create the movieid parameter
                cmd.Parameters.AddWithValue("@cid", txtcatId.Text);
                //assign the parameter to the sql statement
                cmd.CommandText = "SELECT * FROM tblcategory where category_id = @cid";
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())

                {
                    //retrieving FIELD values and assign the form controls



                    txtcatname.Text = dr["category"].ToString();

                }
                con.Close();
                btnAddcategory.Visible = false;
                btnupdate.Visible = true;
                btndelete.Visible = true;

                btncancel.Visible = true;

            }
        
    }
}
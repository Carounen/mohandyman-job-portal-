using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class manageuser : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BinduserData();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //check whether the moviename textbox is empty
            if (string.IsNullOrWhiteSpace(txtuser.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Boolean IsUpdated = false;
            //get the movieid from the textbox
            int use_id = Convert.ToInt32(user_id.Text);
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Add UPDATE statement to update the movie
            cmd.CommandText = "update tbluser set username=@uname,email=@email,profile_image=@pic where user_id=@uid";
            //Create the parameterized queries
            cmd.Parameters.AddWithValue("@uid", use_id);
            cmd.Parameters.AddWithValue("@uname", txtuser.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtuser.Text.Trim());

           


            String filen = images.ImageUrl.Substring(8);


            if (picture.HasFile)
            {
                filen = Path.GetFileName(picture.PostedFile.FileName);
                picture.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }



            cmd.Parameters.AddWithValue("@pic", filen);

       
            cmd.Connection = con;
            con.Open();
            //use Command method to execute UPDATE statement and return
            //boolean if number of records UPDATED is greater than zero
            IsUpdated = cmd.ExecuteNonQuery() > 0;

            con.Close();
            if (IsUpdated)
            {
                lblMsg.Text = txtuser.Text + " updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the
                BinduserData();
            }
            else
            {
                lblMsg.Text = "Error while updating product " + txtuser.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {



            try
            {

                //check whether the txtmoviename textbox is empty
                if (string.IsNullOrWhiteSpace(txtuser.Text))
                {
                    lblMsg.Text = "Please select record to delete";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                Boolean IsDeleted = false;
                //get the movieid from the textbox
                int use_id = Convert.ToInt32(user_id.Text);
                SqlConnection con = new SqlConnection(_conString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                //Add DELETE statement to delete the selected movie
                cmd.CommandText = " delete from tbluser where user_id=@pid ";
                //Create a parametererized query
                cmd.Parameters.AddWithValue("@pid", use_id);
                cmd.Connection = con;
                con.Open();
                //use Command method to execute DELETE statement and return
                //Boolean True if number of records DELETED is greater than zero
                IsDeleted = cmd.ExecuteNonQuery() > 0;
                con.Close();
                if (IsDeleted)
                {
                    lblMsg.Text = txtuser.Text + " user deleted successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    //Refresh the GridView by calling the
                    BinduserData();
                }

                else
                {
                    lblMsg.Text = "Error while deleting user " + txtuser.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }


        }







        private void BinduserData()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbluser";
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








        protected void gvs_SelectedIndexChanged(object sender, EventArgs e)
        {


            lblMsg.Text = "";
            images.Visible = true;


            user_id.Text =
            (gvs.DataKeys[gvs.SelectedIndex].Value.ToString());

            txtuser.Text =
            ((Label)gvs.SelectedRow.FindControl("lbluserName")).Text;

            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@mid", user_id.Text);
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT * FROM tbluser where user_id = @mid";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())

            {
                //retrieving FIELD values and assign the form controls

                txtuser.Text = dr["username"].ToString();
                txtemail.Text = dr["email"].ToString();
              

             
                images.ImageUrl = "~/images/" + dr["profile_image"].ToString();


            }
            con.Close();
          
            btnupdate.Visible = true;
            btndelete.Visible = true;
        

        }






    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class home : System.Web.UI.MasterPage
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                pnllog.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnllog);
                lgregis.CssClass = "nav navbar-nav navbar-right";
                lbllgged.CssClass = "btn btn-outline-success text-black";
                //add the session name
                lbllgged.Text = "Welcome " + Session["username"];
                btnlgout.Visible = true;
                pnlprofile.Visible = true;
                add.Visible = true;
                xx.Visible = true;  
                A6.Visible = true;
                a8.Visible = true;
                hyregister.Visible = false;
       
                //Retrieve the User Id Session
                //int user_id = Convert.ToInt32( );
                //hyuser.Attributes["href"]=ResolveUrl("~/tutorials/week5/updateprofile?id="+user_id + "");

            }

            else
            {
                add.Visible = false;
                xx.Visible = false;
                A6.Visible = false;
                a8.Visible = false; 
               

            }


            if (!IsPostBack)
            {
                if (Request.Cookies["Admin_name"] != null &&
                Request.Cookies["password"] != null)
                {
                    adminlogin.Username = Request.Cookies["Admin_name"].Value;
                    adminlogin.Password = Request.Cookies["password"].Value;
                }
            }
            //Disable/Enable some menu items
            if (Session["Admin_name"] != null)
            {
                hyregister.Visible = false;
                lgregis.CssClass = "nav navbar-nav navbar-right";
                lbllgged.CssClass = "btn btn-outline-success text-black";
                lbllgged.Text = "Welcome " + Session["Admin_name"];
                btnlgout.Visible = true;
              
                mprod.Visible = true;
                muser.Visible = true;
                a1.Visible = true; 
                a2.Visible = true;
                a3.Visible = true;  
                a4.Visible = true; 
                a5.Visible= true;   
                A7.Visible= true;
                Pane.Visible = true;
               

                Page.Controls.Remove(pnlprofile);
                pnllog.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnllog);
            }
         else 
            {

                mprod.Visible = false;
                muser.Visible = false;
                a1.Visible=false;
                a2.Visible=false;
                Pane.Visible = false;   
                  
            }


        }

        protected void txtmovieid_TextChanged(object sender, EventArgs e)
        {

            //Add the following codes in a TextChanged event
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@mid", txtmovieid.Text.Trim());
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT product_name, status,pictures brand FROM tblproduct where product_name=@mid";
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

        protected void btnlgout_Click(object sender, EventArgs e)
        {

            lgout();
           

        }

        void lgout()
        {
            if (Session["username"] != null || Session["admin_name"] != null)
            {
                //Remove all session
                Session.Clear();
                //Destroy all Session objects
                Session.Abandon();
                //Redirect to homepage or login page
                Response.Redirect("login");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //admin login form
            string username = adminlogin.Username;
            string password = adminlogin.Password;
            bool chk = adminlogin.Chk;
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //searching for a record containing matching username & password with
            //an active status
            cmd.CommandText = " select * from tbladmin where Admin_name=@Aname and password=@pass";
            //create two parameterized query for the above select statement
            //use above variables
            cmd.Parameters.AddWithValue("@Aname", username);
            cmd.Parameters.AddWithValue("@pass", password);
          
            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            // check if the DataReader contains a record
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    //create a memory cookie to store username and pwd
                    Response.Cookies["Aname"].Value = username;
                    Response.Cookies["pass"].Value = password;

                    if (chk)
                    {
                        //if checkbox is checked, make cookies persistent
                        Response.Cookies["Aname"].Expires = DateTime.Now.AddDays(100);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(100);
                    }
                    else
                    {
                        //delete the cookies if checkbox is unchecked
                        //delete content of password field
                        Response.Cookies["Aname"].Expires = DateTime.Now.AddDays(-100);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-100);
                    }
                    //create and save adminuname in a session variable
                    //create and save username in a session variable
                    Session["Admin_name"] = username;
                    //create and save userid in a session variable
                    Session["Admin_id"] = dr["Admin_id"].ToString();
                    //redirect to the corresponding page
                    Response.Redirect("home.aspx");
                    //redirect to the dashboard page
                }
                con.Close();
            }
            else
            {
                //delete content of password field
                lblmsg.Style.Add("margin-left", "10%");
                lblmsg.ForeColor = System.Drawing.Color.Red;
                username = "Admin_name";
                password = "password";
                lblmsg.Text = "You are not registered or your account has been suspended!";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop",
"adminModal();", true);
            }
        

    }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class home1 : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCategory();
            TextBox1_TextChanged1(sender, null);
        }


        private void LoadCategory()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_conString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * from tblcategory", _conString);
                    da.Fill(dt);

                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "category";
                    ddlCategory.DataValueField = "category_id";
                    ddlCategory.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message); 
                }
            }
            ddlCategory.Items.Insert(0, new ListItem("Select category", "-1"));
        }

      

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                LinkButton btn = (LinkButton)sender;
                int x = Convert.ToInt32(btn.CommandArgument.ToString());

                if (chkexist(x))
                {
                    lblmsg.Text = "Already sent request for this Product!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    btn.Text = "Already sent request for this Product!";
                    btn.CssClass = "btn btn-danger";
                }
                else
                {
                    SqlConnection con = new SqlConnection(_conString);
                    SqlCommand cmd = new SqlCommand();
                    //add INSERT statement to request access to product
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into tblproductUser(product_id, user_id,AccessDate, Status) " + "values (@mid, @uid, @dateaccess, @status)";
                    cmd.Parameters.AddWithValue("@uid", Session["userid"]);
                    cmd.Parameters.AddWithValue("@mid", x);
                    cmd.Parameters.AddWithValue("@dateaccess", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    btn.Text = "Request sent";
                    lblmsg.Text = "Request sent!";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    btn.CssClass = "btn btn-success";
                }
            }
        }

        private Boolean chkexist(int x)
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //search for user
            cmd.CommandText = "select * from tblproductUser where product_id=@mid and user_id = @uid";
            cmd.Connection = con;
            //create a parameterized query
            cmd.Parameters.AddWithValue("@uid", Session["userid"]);
            cmd.Parameters.AddWithValue("@mid", x);
            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            //Check if user subscription already exists in the table
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {
            String CatIDs = ddlCategory.SelectedValue;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            String sqlParam = "";
            String sqlParamCat = "";

            if (TextBox1.Text.Trim() != null)
                sqlParam = " and product_name LIKE '%' + @mname + '%'";
            if (CatIDs != "-1")
                sqlParamCat = " and tblproduct.category_id = @CatID";
            cmd.CommandText = "SELECT product_id, product_name, description, cost, pictures FROM tblproduct WHERE status = 1 " + sqlParam +
sqlParamCat;
            cmd.Parameters.AddWithValue("@mname", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@CatID", CatIDs);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            lvproduct.DataSource = table;
            lvproduct.DataBind();
        }

        protected void lvproduct_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvproduct.FindControl("DataPager1") as
DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            TextBox1_TextChanged1(TextBox1, null);
        }
    }
    }

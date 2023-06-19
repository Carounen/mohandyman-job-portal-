using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace WebApplication1
{
    public partial class approvereserve : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_name"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                getuserproductdetails();
            }
        }

        void getuserproductdetails()
        {
            SqlConnection con = new SqlConnection(_conString);
            con.Open();
            SqlCommand ccmd = con.CreateCommand();
            ccmd.CommandType = CommandType.Text;
            ccmd.CommandText = "Select tu.user_id as user_id, ";
            ccmd.CommandText += "tu.f_name as fname, ";
            ccmd.CommandText += "tu.l_name as lname, ";
            ccmd.CommandText += "tu.username as uname, ";
            ccmd.CommandText += "tu.profile_image as image, ";
            ccmd.CommandText += "tu.status as ustatus, ";
            ccmd.CommandText += "tum.product_id as pid, ";
            ccmd.CommandText += "tum.AccessDate as accdate, ";
            ccmd.CommandText += "tum.Status as tumstatus, ";
            ccmd.CommandText += "tm.product_name as pname, ";
            ccmd.CommandText += "tm.status as mstatus ";
            ccmd.CommandText += "from tbluser tu, tblproductUser tum, tblproduct tm ";
            ccmd.CommandText += "where tu.user_id = tum.user_id ";
            ccmd.CommandText += "and tum.product_id = tm.product_id ";
            ccmd.CommandText += "and tu.status = '1' ";
            ccmd.CommandText += "and tm.status = '1' ";

           
            SqlDataAdapter sqlda = new SqlDataAdapter(ccmd.CommandText, con);
            DataTable dta = new DataTable();
            sqlda.Fill(dta);
            con.Close();
            gvs.DataSource = dta;
            gvs.DataBind();

        }
            protected void lnkdeny_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow grvRow = (GridViewRow)lnk.NamingContainer;
            HiddenField hf = grvRow.FindControl("hidmov") as HiddenField;
            int mov_id = Convert.ToInt32(hf.Value);
            int user_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(_conString);
con.Open();
            SqlCommand ucmd = con.CreateCommand();
            ucmd.CommandType = CommandType.Text;
            ucmd.CommandText = "update tblproductUser set status='0' Where user_id ='"
            + user_id + "' and product_id ='" + mov_id + "'";
            ucmd.ExecuteNonQuery();
            con.Close();
            getuserproductdetails();
        }

        protected void lnkgrant_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow grvRow = (GridViewRow)lnk.NamingContainer;
            HiddenField hf = grvRow.FindControl("hidmov") as HiddenField;
            int mov_id = Convert.ToInt32(hf.Value);
            int user_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(_conString);
            con.Open();
            SqlCommand ucmd = con.CreateCommand();
            ucmd.CommandType = CommandType.Text;
            ucmd.CommandText = "update tblproductUser set Status='1' Where user_id ='"
            + user_id + "' and product_id ='" + mov_id + "'";
            ucmd.ExecuteNonQuery();
            con.Close();
            getuserproductdetails();
        }

        protected void gvs_PreRender(object sender, EventArgs e)
        {
            if (gvs.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvs.UseAccessibleHeader = true;
                //This will add the <thead> and <tbody> elements
                gvs.HeaderRow.TableSection =
                TableRowSection.TableHeader;
            }
        }





       



    }
}
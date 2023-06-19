using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Scripts
{
    public partial class viewcategory : System.Web.UI.Page
    {



        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"]
.ConnectionString;



        protected void Page_Load(object sender, EventArgs e)
        {



            SqlConnection dbcon = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblcategory";
            cmd.Connection = dbcon;
            dbcon.Open();


            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["category"].ToString();
                   
                BulletedList1.Items.Add(li);

            }

            dbcon.Close();

        }
    }
}
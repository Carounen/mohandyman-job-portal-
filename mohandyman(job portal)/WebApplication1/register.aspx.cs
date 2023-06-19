using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using System.Net;
using Antlr.Runtime.Tree;
using System.Threading.Tasks;

namespace WebApplication1
{
    public partial class register : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkreset_Click(object sender, EventArgs e)
        {
            first.Text = "";
            Last.Text = "";
            txtuse.Text = "";
            txtpas.Text = "";
            txtc.Text = "";

        }

        protected void lexit_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/home.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length >= 7 && args.Value.Length <= 12)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                String filen = "avatar.jpg";

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
                cmd.CommandText = "insert into tbluser (f_name,l_name,address,dob,phone_num,password,username,email,profile_image,status) values (@fname,@lname,@add, @dob,@phone_num,@pass,@usern, @email,@pimage,@status)";
                //create Parameterized query to prevent sql injection by

                cmd.Parameters.AddWithValue("@fname", first.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", Last.Text.Trim());
                cmd.Parameters.AddWithValue("@add", address.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", DOB.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_num", pnum.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", Encrypt(txtpas.Text));
                cmd.Parameters.AddWithValue("@usern", txtuse.Text.Trim());
                cmd.Parameters.AddWithValue("@pimage", filen);
                cmd.Parameters.AddWithValue("@email", mail.Text.Trim());

                cmd.Parameters.AddWithValue("@status", 1);

                cmd.Connection = con;
                con.Open();
                //use Command method to execute INSERT statement and return
                //Boolean true if number of records inserted is greater than zero
                IsAdded = cmd.ExecuteNonQuery() > 0;
                sendemail();
                Response.Redirect("login.aspx");
                con.Close();
                if (IsAdded)
                {
                    lblMsg.Text = first.Text + " Register successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Orange;


                }
                else
                {
                    lblMsg.Text = "Error while registering " + first.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }

            catch/*(Exception ex)*/ { 
            
            }
        }

        public string Encrypt(string clearText)
        {
            // defining encrytion key
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new
                byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65,
0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    // encoding using key
                    using (CryptoStream cs = new CryptoStream(ms,
                    encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private void sendemail()
        {

            SmtpSection smtpSection =
            (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            using (MailMessage m = new MailMessage(smtpSection.From, mail.Text.Trim()))
            {
                SmtpClient sc = new SmtpClient();
                try
                {
                    m.Subject = "Resgistration successful";
                    m.IsBodyHtml = true;
                    StringBuilder msgBody = new StringBuilder();
                    msgBody.Append("Dear " + txtuse.Text + ", your registration is successful, thank you for signing up on vide grenier.");
                    //msgBody.Append(txtbody.Text.Trim());

                    msgBody.Append("<a href='https://" +
                    HttpContext.Current.Request.Url.Authority + "/login.aspx '>Click here to login to...</ a > ");
                    m.Body = msgBody.ToString();
                    sc.Host = smtpSection.Network.Host;
                    sc.EnableSsl = smtpSection.Network.EnableSsl;
                    NetworkCredential networkCred = new
                    NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    sc.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                    sc.Credentials = networkCred;
                    sc.Port = smtpSection.Network.Port;
                    sc.Send(m);
                    Response.Write("Email Sent successfully");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }

}
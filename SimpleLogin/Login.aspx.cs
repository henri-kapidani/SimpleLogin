using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleLogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            string connString = ConfigurationManager.ConnectionStrings["DbLoginConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand registerUser = new SqlCommand($"select Id from Users where Username='{username}' and Password='{password}'", conn);
                string UserId = registerUser.ExecuteScalar().ToString();
                Session["UserId"] = UserId;
            }
            catch
            {
                Response.Write("qualcosa non va");
            }
            finally
            {
                conn.Close();
            }
            
            Response.Redirect("Home.aspx");
        }
    }
}
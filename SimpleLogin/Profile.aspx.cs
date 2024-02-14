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
    public partial class Profile : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["DbLoginConnectionString"].ToString();
        private SqlConnection conn;
        private string UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = Session["UserId"].ToString();
            conn = new SqlConnection(connString);

            if (!IsPostBack)
            {
                try
                {
                    // aprire la connessione
                    conn.Open();
                    // creare il comando sql dicendo casa va fatto e chi lo deve fare
                    SqlCommand getLoggedUserDetails = new SqlCommand($"select * from Users where Id={UserId}", conn);
                    // eseguire il comando sql
                    SqlDataReader user = getLoggedUserDetails.ExecuteReader();

                    if (user.HasRows)
                    {
                        user.Read();
                        TxtUsername.Text = user["Username"].ToString();
                        TxtPassword.Text = user["Password"].ToString();
                    }

                    ViewState["PreviousUsername"] = user["Username"];
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            conn.Open();
            string sqlString = $"update Users set Username='{username}', Password='{password}' where Id={UserId}";
            SqlCommand updateUserDetails = new SqlCommand(sqlString, conn);
            // eseguire il comando sql
            int affectedRows = updateUserDetails.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                Response.Write("errore");
            } else
            {
                ViewState["PreviousUsername"] = TxtUsername.Text;
                Response.Write("success");
            }

            Response.Write(sqlString);

            conn.Close();
        }
    }
}
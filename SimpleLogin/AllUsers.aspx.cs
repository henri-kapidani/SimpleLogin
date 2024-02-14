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
    public partial class AllUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DbLoginConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            // verificare la connessione
            try
            {
                conn.Open();
                SqlCommand getAllUsers = new SqlCommand("select Id, Username from Users", conn);
                SqlDataReader user = getAllUsers.ExecuteReader();

                if (user.HasRows)
                {
                    while (user.Read())
                    {
                        LstUsers.Items.Add(user["Username"].ToString());
                    }
                }

            } catch
            {
                Response.Write("errore");
            }
        }
    }
}
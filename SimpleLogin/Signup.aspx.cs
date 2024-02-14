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
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            // salvare i dati dell'utente nel db
            // connettersi al db
            string connString = ConfigurationManager.ConnectionStrings["DbLoginConnectionString"].ToString();

            SqlConnection conn = new SqlConnection(connString);

            // verificare la connessione
            try
            {
                conn.Open();
                SqlCommand registerUser = new SqlCommand($"insert into Users (Username, Password) values ('{username}', '{password}')", conn);
                int affectedRows = registerUser.ExecuteNonQuery();

                if (affectedRows != 0)
                {
                    Response.Write("Riga inserita con successo: " + affectedRows);
                } else
                {
                    Response.Write("C'è qualcosa di strano");
                }

                // eseguire l'insert nella tabella degli Users
            }
            catch
            {
                // gestire l'errore
                Response.Write("qualcosa non va");
            } finally
            {
                conn.Close();
            }
        }
    }
}
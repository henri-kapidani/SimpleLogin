using System;
using System.Collections.Generic;
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
            // ridirezionare a Home se il cookie è presente
            // con i cookies
            //if (Request.Cookies["login"] != null)
            //{
            //    Response.Redirect("Home.aspx");
            //}

            // con la session
            if (Session["username"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            // settare il cookie
            //HttpCookie loginCookie = new HttpCookie("login");
            //loginCookie["username"] = TxtUsername.Text;
            //Response.Cookies.Add(loginCookie);

            // con la session
            // settare il campo login nella sessione associata all'utente
            Session["username"] = TxtUsername.Text;

            // ridirezionare ad home
            Response.Redirect("Home.aspx");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleLogin
{
    public partial class LoggedTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ridirezionare a Login se il cookie non è presente
            // con cookies
            //if (Request.Cookies["login"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            //LblUsername.Text = Request.Cookies["login"]["username"];

            // con Session
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            LblUsername.Text = Session["username"].ToString();
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            // rimuovere il cookie
            //HttpCookie loginCookie = new HttpCookie("login");
            //loginCookie.Expires = DateTime.Now.AddDays(-1D);
            //Response.Cookies.Add(loginCookie);

            // rimuovere "username" dalla Session
            Session.Remove("username");

            // riderezionare a Login
            Response.Redirect("Login.aspx");
        }
    }
}
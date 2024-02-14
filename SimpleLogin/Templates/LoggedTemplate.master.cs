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
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            LblUsername.Text = Session["UserId"].ToString();
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserId");
            Response.Redirect("Login.aspx");
        }
    }
}
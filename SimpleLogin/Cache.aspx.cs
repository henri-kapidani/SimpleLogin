using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleLogin
{
    public partial class Cache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["nowDate"] == null)
            {
                Cache["nowDate"] = DateTime.Now.ToString();
            }

            string nowDate = Cache["nowDate"].ToString();

            Response.Write(nowDate);
        }
    }
}
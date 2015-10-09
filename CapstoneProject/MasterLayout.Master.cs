using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
  public partial class MasterLayout : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Url.AbsolutePath.ToLowerInvariant().Contains("logon"))
        {
           btnLogout.Visible = false;
           btnHome.Visible = false;
        }
        else
        {
            btnLogout.Visible = true;
            btnHome.Visible = true;
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        string cookieName = System.Web.Security.FormsAuthentication.FormsCookieName;
        HttpCookie authCookie = Context.Request.Cookies[cookieName];
        authCookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(authCookie);

        Response.Redirect("Logon.aspx");
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
  public partial class MasterLayout : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Url.AbsolutePath.ToLowerInvariant().Contains("logon"))
        {
                //btnLogout.Visible = false;
                //btnHome.Visible = false;

                
            }
        else
        {
                //btnLogout.Visible = true;
                //btnHome.Visible = true;
                MasterLayout site = this.Master as MasterLayout;
                if (site != null)
                {

                    LinkButton btnLogout = new LinkButton();
                    btnLogout.Click += btnLogout_Click;
                    btnLogout.CssClass = "btn webAppNavBtn";
                    btnLogout.Text = "Logout";

                    HtmlGenericControl liLogout = new HtmlGenericControl("li");
                    liLogout.Controls.Add(btnLogout);

                    LinkButton btnHome = new LinkButton();
                    btnHome.Click += btnHome_Click;
                    btnHome.CssClass = "btn webAppNavBtn";
                    btnHome.Text = "Home";

                    HtmlGenericControl liHome = new HtmlGenericControl("li");
                    liHome.Controls.Add(btnHome);

                    HtmlGenericControl ul = new HtmlGenericControl("ul");
                    ul.Attributes.Add("class", "nav navbar-nav navbar-right");
                    ul.Controls.Add(liLogout);
                    ul.Controls.Add(liHome);

                    Panel navPanel = site.FindControl("navBtns") as Panel;
                    navPanel.Controls.Add(ul);
                }

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
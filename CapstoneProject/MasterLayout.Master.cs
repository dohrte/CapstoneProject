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
        if (HttpContext.Current.Request.Url.AbsolutePath.ToLowerInvariant().Contains("logon") ||
                HttpContext.Current.Request.Url.AbsolutePath.ToLowerInvariant().Contains("requestacct"))
        {
                btnLogout.Visible = false;
                btnHome.Visible = false;

                
            }
        else
        {
                btnLogout.Visible = true;
                btnHome.Visible = true;
            }

            this.ShowButtons();
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

        protected void ShowButtons()
        {
            var ad = ActiveDirectoryAction.Instance;
            string[] roles = ad.GetUsersWebAppRoles(Context.User.Identity.Name);

            btnAdmin.Visible = false;
            btnCreateComp.Visible = false;

            //based on role show buttons
            foreach (string role in roles)
            {
                switch (role)
                {
                    case "Admins":
                        btnAdmin.Visible = true;
                        break;
                    case "Faculty":
                        break;
                    case "JoinToComputer":
                        btnCreateComp.Visible = true;
                        break;
                    case "Lab Administrator":
                        break;
                    case "Staff":
                        break;
                    case "Student":
                        break;
                    case "Technician":
                        break;
                }
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("page1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("page2.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void btnAcctDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetail.aspx");
        }

        protected void btnCreateComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateComp.aspx");
        }

        protected void btnGrpManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("GroupManagment.aspx");
        }

        protected void FormLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("JoinCompForm.aspx");
        }

        protected void FormLinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShareAccessForm.aspx");
        }
    }
}
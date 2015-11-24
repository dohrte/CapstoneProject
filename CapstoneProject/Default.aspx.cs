using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string msg = "Hello, " + Context.User.Identity.Name + " you have been authenticated! You are now allowed to use this application.";
            MessageOfTheDay motd = new MessageOfTheDay(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["messageOfTheDayPath"]));
            if (motd.ShowMotd)
            {
                msgOfTheDay.Controls.Clear();
                motd = new MessageOfTheDay(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["messageOfTheDayPath"]));
                msgOfTheDay.Controls.Add(motd.GetMotdPanel());
            }

            this.ShowButtons();
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
    }
}
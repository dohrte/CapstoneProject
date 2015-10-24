using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ad = ActiveDirectoryAction.Instance;

            foreach (string role in ad.GetUsersWebAppRoles(Context.User.Identity.Name))
            {
                display1.Text += role;
            }
             
            display2.Text = "show shares that user has access to";
        }
    }
}
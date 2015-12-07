using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
    public partial class LogonMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsolutePath.ToLowerInvariant().Contains("requestacct"))
            {
                ShowForgotModal.Visible = false;
                ShowLoginModal.Visible = false;
                btnRequest.Visible = false;
                BackToMain.Visible = true;
            }
            else
            {
                BackToMain.Visible = false;
            }
        }

        protected void btnRequestAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestAcct.aspx");
        }

        protected void BackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
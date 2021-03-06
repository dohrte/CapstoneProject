﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch(Exception ex)
            {

                Session.Abandon();
                string cookieName = System.Web.Security.FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = Context.Request.Cookies[cookieName];
                authCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(authCookie);

                Response.Redirect("Logon.aspx");
            }
                
            

            //MasterLayout site = this.Master as MasterLayout;
            //if (site != null)
            //{
            //    LinkButton btnRequestAccount = new LinkButton();
            //    btnRequestAccount.Click += btnRequestAccount_Click;
            //    btnRequestAccount.CssClass = "btn webAppNavBtn";
            //    btnRequestAccount.Text = "New Account";
            //    btnRequestAccount.ID = "btnRequest";

            //    HtmlGenericControl liRequestAccount = new HtmlGenericControl("li");
            //    liRequestAccount.Controls.Add(btnRequestAccount);

            //    HtmlGenericControl liLogin = new HtmlGenericControl("li");
            //    liLogin.InnerHtml = "<button class='btn webAppNavBtn' data-toggle='modal' data-target='#loginPage' >Login</button>";
               
                
            //    HtmlGenericControl liForgot = new HtmlGenericControl("li");
            //    liForgot.InnerHtml = "<button class='btn webAppNavBtn' data-toggle='modal' data-target='#forgotPage' >Forgot Password</button>";
                
            //    HtmlGenericControl ul = new HtmlGenericControl("ul");
            //    ul.Attributes.Add("class", "nav navbar-nav navbar-right");
            //    ul.Controls.Add(liLogin);
            //    ul.Controls.Add(liForgot);
            //    ul.Controls.Add(liRequestAccount);
                
            //    Panel navPanel = site.FindControl("navBtns") as Panel;
            //    navPanel.Controls.Add(ul);                
            //}
        }

       
        protected void Login_Click(object sender, EventArgs e)
        {
            LdapAuthentication adAuth = new LdapAuthentication();
            try
            {
                if (true == adAuth.IsAuthenticated(txtUsername.Text, txtPassword.Text))
                {
                    //string groups = adAuth.GetGroups(txtDomain.Text, txtUsername.Text, txtPassword.Text);
                    string userData ="";

                    //Create the ticket, and add the groups.
                    bool isCookiePersistent = true; // chkPersist.Checked;
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(5), isCookiePersistent, userData);

                    //Encrypt the ticket.
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    //Create a cookie, and then add the encrypted ticket to the cookie as data.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    //if (true == isCookiePersistent)
                     //   authCookie.Expires = authTicket.Expiration;


                    //expire the cookie in five minutes
                    authCookie.Expires = DateTime.Now.AddMinutes(5);


                    //Add the cookie to the outgoing cookies collection.
                    Response.Cookies.Add(authCookie);

                    //You can redirect now.
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text, false));
                }
                else
                {
                    errorLabel.Text = "Authentication did not succeed. Check user name and password.";
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Error authenticating. " + ex.Message;
            }
        }

        protected void btnRequestAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestAcct.aspx");
        }

        
    }
}
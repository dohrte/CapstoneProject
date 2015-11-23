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

            //display2.Text = "show shares that user has access to";
            this.populateDetails();
        }

        protected void populateDetails()
        {
            var ad = ActiveDirectoryAction.Instance;
            var uDetails = ad.GetUserAcctInfo(Context.User.Identity.Name);
            this.fillRoleList(ad.GetUsersWebAppRoles(Context.User.Identity.Name));
            this.fillShareList(uDetails["cn"]);
            this.fillMembershipList(ad.GetMemberOf(Context.User.Identity.Name).ToArray());
            
        }

        protected void fillShareList(string name)
        {
            

            UTSDatabaseInterface db = new UTSDatabaseInterface();
            List<Tuple<string, string, string>> details = db.GetUTSUsers(name);


            foreach(Tuple<string, string, string> item in details)
            {
                TableRow row = new TableRow();
                //ShareName, Share_GroupGroupPermissions, GroupsName
                TableCell c1 = new TableCell();
                c1.Text = item.Item1.Substring(item.Item1.LastIndexOf(@"\") + 1); 
                row.Cells.Add(c1);
                TableCell c2 = new TableCell();
                c2.Text = item.Item2;
                row.Cells.Add(c2);
                TableCell c3 = new TableCell();
                c3.Text = item.Item3;
                row.Cells.Add(c3);

                shareTable.Rows.Add(row);
            }
        }

        protected void fillRoleList(string[] roles)
        {
            roleList.DataSource = roles;
            roleList.DataBind();

        }

        protected void fillMembershipList(string[] memOfList)
        {
            membershipList.DataSource = memOfList;
            membershipList.DataBind();
        }
    }
}
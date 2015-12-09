using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
    public partial class UserDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //var ad = ActiveDirectoryAction.Instance;

            //foreach (string role in ad.GetUsersWebAppRoles(Context.User.Identity.Name))
            //{
            //    display1.Text += role;
            //}

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
            //clear the share list
            shareListView.DataSource = null;
            shareListView.DataBind();

            DataTable shareTable = new DataTable();
            shareTable.Columns.Add("shareName");
            shareTable.Columns.Add("permissions");
            shareTable.Columns.Add("grpName");


            UTSDatabaseInterface db = new UTSDatabaseInterface();
            List<Tuple<string, string, string>> details = db.GetUTSUsers(name);

            if (details != null)
            {
                foreach (Tuple<string, string, string> item in details)
                {
                    StringBuilder perms = new StringBuilder();
                    if (item.Item2.Contains("r"))
                    {
                        perms.Append("Read");
                        if(item.Item2.IndexOf("r")+1 != item.Item2.Length)
                        {
                            perms.Append(", ");
                        }
                    }

                    if (item.Item2.Contains("w"))
                    {
                        perms.Append("Write");
                        if (item.Item2.IndexOf("w")+1 != item.Item2.Length)
                        {
                            perms.Append(", ");
                        }
                    }

                    if (item.Item2.Contains("x"))
                    {
                        perms.Append("Execute");
                        if (item.Item2.IndexOf("x")+1 != item.Item2.Length)
                        {
                            int i = item.Item2.IndexOf("x") + 1;
                            perms.Append(", ");
                        }
                    }

                    DataRow row = shareTable.NewRow();
                    row["shareName"] = item.Item1.Substring(item.Item1.LastIndexOf(@"\") + 1);
                    row["permissions"] = perms.ToString();
                    row["grpName"] = item.Item3;

                    shareTable.Rows.Add(row);
                }

                shareListView.DataSource = shareTable;
                shareListView.DataBind();
            }
            else
            {
                //show no shares message
                noSharesMsg.Text = "You currently do not have access to any shares.";
                noSharesMsg.Visible = true;
                shareListView.Visible = false;
            }

            

            //foreach (Tuple<string, string, string> item in details)
            //{
            //TableRow row = new TableRow();
            ////ShareName, Share_GroupGroupPermissions, GroupsName
            //TableCell c1 = new TableCell();
            //c1.Text = item.Item1.Substring(item.Item1.LastIndexOf(@"\") + 1); 
            //row.Cells.Add(c1);
            //TableCell c2 = new TableCell();
            //c2.Text = item.Item2;
            //row.Cells.Add(c2);
            //TableCell c3 = new TableCell();
            //c3.Text = item.Item3;
            //row.Cells.Add(c3);

            //shareTable.Rows.Add(row);
            //}
        }

        protected void fillRoleList(string[] roles)
        {
            roleList.DataSource = roles;
            roleList.DataBind();

        }

        protected void fillMembershipList(string[] memOfList)
        {
            List<string> lst = new List<string>();

            foreach (string grp in memOfList)
            {
                int start = grp.IndexOf(@"=") + 1;
                int end = grp.IndexOf(@",") - start;

                string dn = grp.Substring(start, end);
                lst.Add(dn);
            }

            membershipList.DataSource = lst;
            membershipList.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CapstoneProject
{
  public partial class GroupManagment : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //populate groupmanaged list
      //this will come from AD
    }

    protected void adUser_btn_Click(object sender, EventArgs e)
    {
      //validate user

      //adduser
    }

    protected void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      //on selected item in groups managed list update the other displays

      //shares that the group has access to will come from DB

      //members will come from AD
      //show groups that are members?
      //if user is memeber of other group that is not managed be viewing user remove functionality should be disabled
    }

    public void AddUserToGroup(string userId, string groupName)
    {
      try
      {
        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "COMPANY"))
        {
          GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
          group.Members.Add(pc, IdentityType.UserPrincipalName, userId);
          group.Save();
        }
      }
      catch (System.DirectoryServices.DirectoryServicesCOMException E)
      {
        //doSomething with E.Message.ToString(); 

      }
    }

    public void RemoveUserFromGroup(string userId, string groupName)
    {
      try
      {
        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "COMPANY"))
        {
          GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
          group.Members.Remove(pc, IdentityType.UserPrincipalName, userId);
          group.Save();
        }
      }
      catch (System.DirectoryServices.DirectoryServicesCOMException E)
      {
        //doSomething with E.Message.ToString(); 

      }
    }
  }
}
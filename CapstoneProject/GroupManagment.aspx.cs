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

        var ad = ActiveDirectoryAction.Instance;


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

    protected void groupsListBox_Init(object sender, EventArgs e)
    {
        groupsListBox.Items.Clear();
        List<ListItem> grpList = new List<ListItem>();
        var ad = ActiveDirectoryAction.Instance;
        string[] mangList = ad.GetGroupsManagedList(Context.User.Identity.Name);

        if (mangList.Length > 0)
        {
            foreach (string group in mangList)
            {
                ListItem grp = new ListItem(group, group);
                grp.Attributes.Add("class", "list-group-item");
                grpList.Add(grp);
            }

            groupsListBox.Items.AddRange(grpList.ToArray());
            groupsListBox.SelectionMode = ListSelectionMode.Single;
        }

        
    }

    
  }
}
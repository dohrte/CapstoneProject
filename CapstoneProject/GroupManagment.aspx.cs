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

            //bind groupslistbox.selectindexchange to manageDetail updatePanel
            //manageDetail.Triggers.Add(new AsyncPostBackTrigger()
            //{
            //    ControlID = groupsListBox.UniqueID,
            //    EventName = "SelectedIndexChanged"
            //});

            //bind submit button to manageDetail updatePanel

        }

    protected void adUser_btn_Click(object sender, EventArgs e)
    {
            var ad = ActiveDirectoryAction.Instance;


            //validate user

            //adduser
            ad.AddUserToGroup(addUserID_textBox.Text, groupsListBox.SelectedValue);

    }

    protected void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
            //on selected item in groups managed list update the other displays
            ListBox input = (ListBox)sender;
           
            //shares that the group has access to will come from DB

            //members will come from AD
            var ad = ActiveDirectoryAction.Instance;
            string[] grpMems = ad.GetMemberList(input.SelectedItem.Text);

            if(grpMems.Length > 0)
            {
                memeberListBox.Items.AddRange(this.CreateListItems(grpMems).ToArray());
            }
            
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
            groupsListBox.Items.AddRange(this.CreateListItems(mangList).ToArray());
            groupsListBox.SelectionMode = ListSelectionMode.Single;
        }
        groupsListBox.SelectedIndex = -1;
        
    }


        private List<ListItem> CreateListItems(string[] items)
        {
            List<ListItem> list = new List<ListItem>();

            foreach (string item in items)
            {
                ListItem lItem = new ListItem(item, item);
                lItem.Attributes.Add("class", "list-group-item");
                list.Add(lItem);
            }

            return list;
        }
    
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CapstoneProject
{
    struct MemberItem
    {
        public string name;

        public string Name
        {
            get { return name; }
            set { }
        }

        public MemberItem(string n)
        {
            name = n;
        }
        
    }
  public partial class GroupManagment : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
            //populate groupmanaged list
            //this will come from AD      
            string x = "what";
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
            if (ad.UserExist(addUserID_textBox.Text))
            {
                //adduser
                ad.AddUserToGroup(addUserID_textBox.Text, groupsListBox.SelectedValue);
                addUserID_textBox.Text = string.Empty;
            }
            else
            {
                addUser_Error.Text = "Invalid userID.";
            }

            memberListView.DataSource = this.GenerateListData(ad.GetMemberList(groupsListBox.SelectedItem.Text));
            memberListView.DataBind();
        }

    protected void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
            //on selected item in groups managed list update the other displays
            ListBox input = (ListBox)sender;

            var ad = ActiveDirectoryAction.Instance;
            memberListView.DataSource = this.GenerateListData(ad.GetMemberList(input.SelectedItem.Text));
            memberListView.DataBind();

            addUserID_textBox.Text = string.Empty;

            //show groups that are members?
            //if user is memeber of other group that is not managed be viewing user remove functionality should be disabled
        }

        private List<MemberItem> GenerateListData(string[] mems)
        {
            List<MemberItem> list = new List<MemberItem>();

            foreach (string mem in mems)
            {
                list.Add(new MemberItem(mem));
            }

            return list;
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
        //groupsListBox.SelectedIndex = -1;
        
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

        protected void btnRemoveUser_Click(object sender, EventArgs e)
        {
            var ad = ActiveDirectoryAction.Instance;
            LinkButton s = (LinkButton) sender;
            if (s.CommandName.Equals("Remove"))
            {
               ad.RemoveUserFromGroup(s.CommandArgument, groupsListBox.SelectedItem.Text);
            }

            memberListView.DataSource = this.GenerateListData(ad.GetMemberList(groupsListBox.SelectedItem.Text));
            memberListView.DataBind();
        }

  }
}
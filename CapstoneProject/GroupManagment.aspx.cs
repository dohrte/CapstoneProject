using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
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
        private UTSDatabaseInterface IDatabase;
        private string selectedGroup;

        protected void Page_Load(object sender, EventArgs e)
        {
            IDatabase = new UTSDatabaseInterface();

            if (IsPostBack)
            {
                //grpNameLbl.Text = grpNameLbl.Text;
            }
            else
            {
                //populate groupmanaged list
                grpView.Visible = false;
                groupsListView.DataSource = null;
                groupsListView.DataBind();

                DataTable grpTable = new DataTable();
                grpTable.Columns.Add("groupName", typeof(string));

                var ad = ActiveDirectoryAction.Instance;
                string[] mangList = ad.GetGroupsManagedList(Context.User.Identity.Name);

                if (mangList.Length > 0)
                {
                    foreach (string name in mangList)
                    {
                        DataRow row = grpTable.NewRow();
                        row["groupName"] = name;
                        grpTable.Rows.Add(row);
                    }
                    groupsListView.DataSource = grpTable;
                    groupsListView.DataBind();
                }
            }

            
           
        }

        protected void adUser_btn_Click(object sender, EventArgs e)
        {
            var ad = ActiveDirectoryAction.Instance;

            //validate user
            if (ad.UserExist(addUserID_textBox.Text))
            {
                //adduser
                //ad.AddUserToGroup(addUserID_textBox.Text, groupsListBox.SelectedValue);
                ad.AddUserToGroup(addUserID_textBox.Text, grpNameLbl.Text);
                addUserID_textBox.Text = string.Empty;
            }
            else
            {
                addUser_Error.Text = "Please enter a valid UserID";
                addUser_Error.Visible = true;
            }

            //memberListView.DataSource = this.GenerateListData(ad.GetMemberList(groupsListBox.SelectedItem.Text));
            memberListView.DataSource = this.GenerateListData(ad.GetMemberList(grpNameLbl.Text));
            memberListView.DataBind();
            }

        //protected void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    sharesListView.DataSource = null;
        //    sharesListView.DataBind();
        //    //on selected item in groups managed list update the other displays
        //    ListBox input = (ListBox)sender;

        //    DataTable sharesInfo = new DataTable();
        //    sharesInfo.Columns.Add("sharename", typeof(string));
        //    sharesInfo.Columns.Add("perms", typeof(string));

        //    List<Tuple<string, string>> sList = IDatabase.GetUTSGroups(input.SelectedItem.Text).shares;

        //    if (sList != null)
        //    {
        //        foreach (Tuple<string, string> share in sList)
        //        {
        //            DataRow row = sharesInfo.NewRow();
        //            string[] rowArray = { share.Item1, share.Item2 };
        //            row.ItemArray = rowArray;
        //            sharesInfo.Rows.Add(row);
        //        }
        //        sharesListView.DataSource = sharesInfo;
        //        sharesListView.DataBind();
        //    }
        //    else
        //    {
                
        //    }



        //    var ad = ActiveDirectoryAction.Instance;
        //    memberListView.DataSource = this.GenerateListData(ad.GetMemberList(input.SelectedItem.Text));
        //    memberListView.DataBind();

        //    addUserID_textBox.Text = string.Empty;

        //    //show groups that are members?
        //    //if user is memeber of other group that is not managed be viewing user remove functionality should be disabled
        //}

        private List<MemberItem> GenerateListData(string[] mems)
        {
            List<MemberItem> list = new List<MemberItem>();

            foreach (string mem in mems)
            {
                list.Add(new MemberItem(mem));
            }

            return list;
        }

    //    protected void groupsListBox_Init(object sender, EventArgs e)
    //{
    //    groupsListBox.Items.Clear();
    //    List<ListItem> grpList = new List<ListItem>();
    //    var ad = ActiveDirectoryAction.Instance;
    //    string[] mangList = ad.GetGroupsManagedList(Context.User.Identity.Name);

    //    if (mangList.Length > 0)
    //    {
    //        groupsListBox.Items.AddRange(this.CreateListItems(mangList).ToArray());
    //        groupsListBox.SelectionMode = ListSelectionMode.Single;
    //    }
    //    //groupsListBox.SelectedIndex = -1;
        
    //}


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
                //ad.RemoveUserFromGroup(s.CommandArgument, groupsListBox.SelectedItem.Text);
                ad.RemoveUserFromGroup(s.CommandArgument, grpNameLbl.Text);
            }

            //memberListView.DataSource = this.GenerateListData(ad.GetMemberList(groupsListBox.SelectedItem.Text));
            memberListView.DataSource = this.GenerateListData(ad.GetMemberList(grpNameLbl.Text));
            memberListView.DataBind();
        }

        protected void groupsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            sharesListView.DataSource = null;
            sharesListView.DataBind();
            //on selected item in groups managed list update the other displays

            DataTable sharesInfo = new DataTable();
            sharesInfo.Columns.Add("sharename", typeof(string));
            sharesInfo.Columns.Add("perms", typeof(string));

            List<Tuple<string, string>> sList = IDatabase.GetUTSGroups(e.CommandArgument.ToString()).shares;

            if (sList != null)
            {
                foreach (Tuple<string, string> share in sList)
                {
                    DataRow row = sharesInfo.NewRow();
                    string[] rowArray = { share.Item1, share.Item2 };
                    row.ItemArray = rowArray;
                    sharesInfo.Rows.Add(row);
                }
                sharesListView.DataSource = sharesInfo;
                sharesListView.DataBind();
            }
            else
            {

            }



            var ad = ActiveDirectoryAction.Instance;
            memberListView.DataSource = this.GenerateListData(ad.GetMemberList(e.CommandArgument.ToString()));
            memberListView.DataBind();

            addUserID_textBox.Text = string.Empty;
            selectedGroup = e.CommandArgument.ToString();
            grpNameLbl.Text = e.CommandArgument.ToString();
            grpView.Visible = true;

            //show groups that are members?
            //if user is memeber of other group that is not managed be viewing user remove functionality should be disabled

        }

        protected void memberListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var ad = ActiveDirectoryAction.Instance;
            
            if (e.CommandName.Equals("Remove"))
            {
                //ad.RemoveUserFromGroup(s.CommandArgument, groupsListBox.SelectedItem.Text);
                ad.RemoveUserFromGroup(e.CommandArgument.ToString(), grpNameLbl.Text);
            }

            //memberListView.DataSource = this.GenerateListData(ad.GetMemberList(groupsListBox.SelectedItem.Text));
            memberListView.DataSource = this.GenerateListData(ad.GetMemberList(grpNameLbl.Text));
            memberListView.DataBind();
        }

        [WebMethod]
        protected static string newUserValidator_ServerValidate(string name)
        {
            var ad = ActiveDirectoryAction.Instance;

            return name;
        }

    }
}
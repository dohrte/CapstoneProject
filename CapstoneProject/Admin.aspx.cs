using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CapstoneProject
{
    public partial class Admin : System.Web.UI.Page
    {
        MessageOfTheDay motd;// = new MessageOfTheDay(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["messageOfTheDayPath"]));
        Department dept;
        Building bldg;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetCurrentMsg();


            dept = new Department();
            bldg = new Building();
            if (!IsPostBack)
            {
                this.MakeDeptList();
                this.MakeBldgList();
            }

            //this.SetCurrentMsg();
            //currentMessageLabel.Text = motd.getMessage();
        }

        protected void publishBtn_Click(object sender, EventArgs e)
        {
            //get input
            string mText = Textbox1.Text;
            Textbox1.Text = string.Empty;

            int mType = Convert.ToInt32(mTypeRadioButtonList.SelectedItem.Value);
            //int mType = 2;

            //write to motd file
            motd.SetMessage(mText, mType);
            this.SetCurrentMsg();
        }

        protected void SetCurrentMsg()
        {
            curMsgPanel.Controls.Clear();
            motd = new MessageOfTheDay(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["messageOfTheDayPath"]));
            curMsgPanel.Controls.Add(motd.GetMotdPanel());

            if (motd.ShowMotd && !IsPostBack)
            {
                showMotdCheckBox.Checked = true;
            }
        }

        protected void MakeDeptList()
        {
            deptListView.DataSource = dept.GetDepartment();
            deptListView.DataBind();
        }

        protected void addDept_btn_Click(object sender, EventArgs e)
        {
            dept.SetDepartment(deptName.Text, deptAbbr.Text);
            deptName.Text = string.Empty;
            deptAbbr.Text = string.Empty;

            this.MakeDeptList();
        }

        protected void deptListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "RemoveDept":
                    dept.DeleteDepartment(Convert.ToInt32(e.CommandArgument));
                    break;
                case "UpdateDept":
                    TextBox udn = e.Item.FindControl("updateDeptName") as TextBox;
                    TextBox uda = e.Item.FindControl("updateDeptAbbr") as TextBox;
                    dept.UpdateDepartment(Convert.ToInt32(e.CommandArgument), udn.Text, uda.Text);
                    break;
            }

            this.MakeDeptList();
        }

        protected void MakeBldgList()
        {
            bldgListView.DataSource = bldg.GetBuilding();
            bldgListView.DataBind();
        }


        protected void addBldg_btn_Click(object sender, EventArgs e)
        {
            bldg.SetBuilding(addBldgName.Text, addBldgAbbr.Text);
            addBldgName.Text = string.Empty;
            addBldgAbbr.Text = string.Empty;

            this.MakeBldgList();
        }

        protected void bldgListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "RemoveBldg":
                    bldg.DeleteBuilding(Convert.ToInt32(e.CommandArgument));
                    break;
                case "UpdateBldg":
                    TextBox ubn = e.Item.FindControl("updateBldgName") as TextBox;
                    TextBox uba = e.Item.FindControl("updateBldgAbbr") as TextBox;
                    bldg.UpdateBuilding(Convert.ToInt32(e.CommandArgument), ubn.Text, uba.Text);
                    break;
            }

            this.MakeBldgList();
        }

        protected void showMotdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showMotdCheckBox.Checked)
            {
                motd.ShowMotd = true;
            }
            else
            {
                motd.ShowMotd = false;
            }
        }
    }
}
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetCurrentMsg();

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
        }
    }
}
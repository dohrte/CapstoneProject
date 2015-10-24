using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
    public partial class RequestAcct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if (IsPostBack)
          {
            requestForm.Visible = false;
            messagePanel.Visible = true;
          }
          else
          {
            messagePanel.Visible = false;
            requestForm.Visible = true;
          }
        }

        protected void requestSubmit_Click(object sender, EventArgs e)
        {
          Emailer emailer = new Emailer();
          //gather form details into email body 
          string eSubj = "Access Request from " + fNameBox.Text + " " + lNamebox.Text;
          
          //gather the check boxes that are checked
          var checked_texts = this.Controls.OfType<CheckBox>()
                                        .Where(c => c.Checked)
                                        .Select(c => c.Text);

          StringBuilder eContent = new StringBuilder();
          eContent.AppendLine(string.Format("{0} {1} is requesting access to the web application.", fNameBox.Text, lNamebox.Text));
          eContent.AppendLine(string.Format("Users email: {0}", emailBox.Text));
          eContent.AppendLine(string.Format("Supervisor: {0}", supervisorBox.Text));
          eContent.AppendLine();
          eContent.AppendLine("The type of access requested:");

          foreach (string acctType in checked_texts)
          {
            eContent.AppendLine(acctType);
          }

          eContent.AppendLine();
          eContent.AppendLine(string.Format("Request reason: {0}", reasonBox.Text));


          emailer.SendAcctRequest(eSubj, eContent.ToString());
        }
    }
}
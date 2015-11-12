using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapstoneProject
{
    public partial class page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            int num = Convert.ToInt32(input.Text);
            display.Text = svc.GetData(num);
        }
    }
}
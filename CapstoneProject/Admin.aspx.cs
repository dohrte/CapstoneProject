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
        string split = "-----";
        string str = "";
        string updateTxt = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void publishBtn_Click(object sender, EventArgs e)
        {
            string theText = Textbox1.Text;
            int index = updateTxt.IndexOf(split);

            if (index > 0)
                updateTxt = updateTxt.Substring(0, index);

            str = theText + "\n" + split + "\n" + updateTxt;
            System.IO.File.WriteAllText(System.Web.Configuration.WebConfigurationManager.AppSettings["messageOfTheDayPath"], str);
            updateTxt = str;
            Label1.Text = updateTxt;


        }
        public string getMessage() {
            string txt = "";

            using (var reader = new StreamReader(System.Web.Configuration.WebConfigurationManager.AppSettings["messageOfTheDayPath"]))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (reader.ReadLine() == "-----")
                    {
                        break;
                    }
                    txt += line + "\n";
                }
                reader.Close();
            }
            return txt;

        }
    }
}
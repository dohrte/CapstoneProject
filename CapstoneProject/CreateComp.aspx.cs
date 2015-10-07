using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CapstoneProject
{
    public partial class CreateComp : System.Web.UI.Page
    {
        private string buildingList = System.Web.Configuration.WebConfigurationManager.AppSettings["buildingListPath"];
        private string deptList = System.Web.Configuration.WebConfigurationManager.AppSettings["deptListPath"];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitLists();
        }

        private void InitLists()
        {
            buildingDropList.Items.AddRange(listGen.GetItemList(buildingList).ToArray());
            ListItem[] listOfDepts = listGen.GetItemList(deptList).ToArray();
            deptDropList.Items.AddRange(listOfDepts);
            custDeptDropList.Items.AddRange(listOfDepts);
        }



        protected void createButton_Click(object sender, EventArgs e)
        {
            int num;
            //validate room num has been set to int value
            if (Int32.TryParse(rmNum.Text, out num))
            {
                this.DoComputerCreation(buildingDropList.SelectedValue + rmNum.Text + deptDropList.SelectedValue, deptDropList.SelectedItem.Text, false);  
            }
            else
            {
                NumErrorLabel.Text = "<span class=\"label label-danger\">Please enter a valid number.</span>"; 
            }
            
           
        }

        protected void createCustomButton_Click(object sender, EventArgs e)
        {
            if(compNameTextBox.Text.Trim().Equals(string.Empty))
            {
                //show error for null value
                cusNameErrLabel.Text = "<span class=\"label label-danger\">Please enter a name.</span>";
            }
            else
            {
                this.DoComputerCreation(compNameTextBox.Text, custDeptDropList.SelectedItem.Text, true);                
            }
            
        }

        protected void resetForm()
        {
            //auto form
            buildingDropList.SelectedIndex = 0;
            rmNum.Text = string.Empty;
            deptDropList.SelectedIndex = 0;
            NumErrorLabel.Text = string.Empty;

            //custom form
            custDeptDropList.SelectedIndex = 0;
            compNameTextBox.Text = string.Empty;
            cusNameErrLabel.Text = string.Empty;
        }

        private void DoComputerCreation(string compName, string deptName, bool custom)
        {
            var adAction = ActiveDirectoryAction.Instance;
            //call create comp function
            bool error;

            string stu;
            stu = "";

            string resultMessage = adAction.CreateComputerObject(compName, deptName, custom, out error);
            //send eamil??


            string ulContent = listItems.Text;
            if (error)
            {
                //ActionList.Items.Add(resultMessage);
                
                listItems.Text = "<li class=\"alertListItems\"><span class=\"alert alert-danger\">" + resultMessage + "</span></li>" + ulContent;
            }
            else
            {
                //show success message
                listItems.Text = "<li class=\"alertListItems\"><span class=\"alert alert-success\">Computer " + resultMessage + " created. In OU: " + deptName + "</span></li>" + ulContent;
                //reset form
                this.resetForm();
            }
        }

    }
}
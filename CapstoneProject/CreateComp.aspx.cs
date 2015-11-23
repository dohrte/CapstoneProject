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
        //private string buildingList = System.Web.Configuration.WebConfigurationManager.AppSettings["buildingListPath"];
        //private string deptList = System.Web.Configuration.WebConfigurationManager.AppSettings["deptListPath"];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitLists();
        }

        //private void InitLists()
        //{
        //    this method will be used in production and read from tables in the database
        //}



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


            string resultMessage = adAction.CreateComputerObject(compName, deptName, custom, out error);
            


            string ulContent = listItems.Text;
            if (error)
            {
                //ActionList.Items.Add(resultMessage);
                //send eamil??
                //log write
                
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

        private void InitLists()
        {
            Department dept = new Department();
            Building bldg = new Building();

            deptDropList.DataSource = dept.GetDepartment();
            deptDropList.DataTextField = "DepartmentName";
            deptDropList.DataValueField = "DepartmentAbbreviation";
            deptDropList.DataBind();

            custDeptDropList.DataSource = dept.GetDepartment();
            custDeptDropList.DataTextField = "DepartmentName";
            custDeptDropList.DataValueField = "DepartmentAbbreviation";
            custDeptDropList.DataBind();

            buildingDropList.DataSource = bldg.GetBuilding();
            buildingDropList.DataTextField = "BuildingName";
            buildingDropList.DataValueField = "BuildingAbbreviation";
            buildingDropList.DataBind();
            
        }



        //used for testing and dev, not for production
        //private void InitLists()
        //{
        //    List<ListItem> buildingArray = new List<ListItem>();
        //    List<ListItem> deptList = new List<ListItem>();

        //    buildingArray.Add(new ListItem("Anibal House", "ANI"));
        //    buildingArray.Add(new ListItem("Baldwin Pavilion", "BP"));
        //    buildingArray.Add(new ListItem("Belgian Barn", "BB"));
        //    buildingArray.Add(new ListItem("Buildings and Grounds Maintenance", "BGM"));
        //    buildingArray.Add(new ListItem("Carriage House", "CH"));
        //    buildingArray.Add(new ListItem("Central Heating Plant", "CHP"));
        //    buildingArray.Add(new ListItem("Dodge Hall of Engineering", "DHE"));
        //    buildingArray.Add(new ListItem("Electrical Substation", "ES"));
        //    buildingArray.Add(new ListItem("Elliot Hall of Business & Technology", "EH"));
        //    buildingArray.Add(new ListItem("Engineering Center", "EC"));
        //    buildingArray.Add(new ListItem("Facilities Management", "FM"));
        //    buildingArray.Add(new ListItem("Fitzgerald House", "FTZ"));
        //    buildingArray.Add(new ListItem("George T. Mathews Apartments", "MSH"));
        //    buildingArray.Add(new ListItem("Golf Course Clubhouse", "GCC"));
        //    buildingArray.Add(new ListItem("Graham Health Center", "GHC"));
        //    buildingArray.Add(new ListItem("Hamilin Hall", "HAM"));
        //    buildingArray.Add(new ListItem("Hannah Hall of Science", "HHS"));
        //    buildingArray.Add(new ListItem("Hill House", "HIL"));
        //    buildingArray.Add(new ListItem("Human Health Building", "HHB"));
        //    buildingArray.Add(new ListItem("John Dodge House", "JDH"));
        //    buildingArray.Add(new ListItem("Knole Cottage", "KC"));
        //    buildingArray.Add(new ListItem("Kresge Library", "KL"));
        //    buildingArray.Add(new ListItem("Lowry Early Childhood Education Center", "CCC"));
        //    buildingArray.Add(new ListItem("Meadow Brook Art Gallery", "MBAG"));
        //    buildingArray.Add(new ListItem("Meadow Brook Greenhouse", "GRN"));
        //    buildingArray.Add(new ListItem("Meadow Brook Hall and Gardens", "MBH"));
        //    buildingArray.Add(new ListItem("Meadow Brook Music Festival Ticket Office", "MBMF"));
        //    buildingArray.Add(new ListItem("Meadow Brook Theatre", "MBT"));
        //    buildingArray.Add(new ListItem("North Foundation Hall", "NFH"));
        //    buildingArray.Add(new ListItem("O'Dowd Hall", "ODH'>O"));
        //    buildingArray.Add(new ListItem("Oakland Center", "OC"));
        //    buildingArray.Add(new ListItem("Oakland University Art Gallery", "OUAG"));
        //    buildingArray.Add(new ListItem("Pawley Hall", "PH"));
        //    buildingArray.Add(new ListItem("Police & Support Services Building", "PSS"));
        //    buildingArray.Add(new ListItem("Pryale House", "PRY"));
        //    buildingArray.Add(new ListItem("Recital Hall", "VRH"));
        //    buildingArray.Add(new ListItem("Recreation and Athletics Center", "RAC"));
        //    buildingArray.Add(new ListItem("Science & Engineering Building", "SEB"));
        //    buildingArray.Add(new ListItem("Sheep Barn", "SB"));
        //    buildingArray.Add(new ListItem("Shotwell-Gustafson Pavillion", "SGP"));
        //    buildingArray.Add(new ListItem("South Foundation Hall", "SFH"));
        //    buildingArray.Add(new ListItem("Storage Facility", "SF"));
        //    buildingArray.Add(new ListItem("Student Apartments", "USA"));
        //    buildingArray.Add(new ListItem("Studio Theatre", "VST"));
        //    buildingArray.Add(new ListItem("Sunset Terrace", "SST"));
        //    buildingArray.Add(new ListItem("Trumbull Terrace", "TT"));
        //    buildingArray.Add(new ListItem("Van Wagoner House", "VWH"));
        //    buildingArray.Add(new ListItem("Vandenberg Hall East", "EVB"));
        //    buildingArray.Add(new ListItem("Vandenberg Hall West", "WVB"));
        //    buildingArray.Add(new ListItem("Varner Hall", "VAR"));
        //    buildingArray.Add(new ListItem("Varner House", "VAH"));
        //    buildingArray.Add(new ListItem("Wilson Hall", "WH"));

        //    deptList.Add(new ListItem("Academic Affairs", "AA"));
        //    deptList.Add(new ListItem("Arts and Sciences", "AAS"));
        //    deptList.Add(new ListItem("Athletics", "ATH"));
        //    deptList.Add(new ListItem("Budget and Financial Planning", "BFP"));
        //    deptList.Add(new ListItem("Eye Research Institute", "ERI"));
        //    deptList.Add(new ListItem("Finance and Administration", "FA"));
        //    deptList.Add(new ListItem("Golf Course", "GC"));
        //    deptList.Add(new ListItem("Helpdesk", "HELP"));
        //    deptList.Add(new ListItem("Housing", "HOUS"));
        //    deptList.Add(new ListItem("Integrative Studies", "IS"));
        //    deptList.Add(new ListItem("Kresge Library", "KL"));
        //    deptList.Add(new ListItem("MBH", "MBH"));
        //    deptList.Add(new ListItem("OUWBSM", "OUWBSM"));
        //    deptList.Add(new ListItem("Registrar", "REG"));
        //    deptList.Add(new ListItem("SBA", "SBA"));
        //    deptList.Add(new ListItem("SECS", "SECS"));
        //    deptList.Add(new ListItem("SEHS", "SEHS"));
        //    deptList.Add(new ListItem("School of Health Sciences", "SHS"));
        //    deptList.Add(new ListItem("School of Nursing", "SON"));
        //    deptList.Add(new ListItem("Student Orgs", "STUORG"));
        //    deptList.Add(new ListItem("UTS", "UTS"));
        //    deptList.Add(new ListItem("University President", "UP"));
        //    deptList.Add(new ListItem("University Relations", "UR"));

        //    buildingDropList.Items.AddRange(buildingArray.ToArray());
        //    deptDropList.Items.AddRange(deptList.ToArray());
        //}

    }
}
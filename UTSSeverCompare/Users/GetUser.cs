using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1.Users
{
    class GetUser
    {
        SqlConnection sqlConnection = new SqlConnection("user id=swright;" +
                                                           "password=Abc123!!;" +
                                                           "server=SQLSERVER480;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=UTSDB; " +
                                                           "connection timeout=10");

        //public List<Users> GetADUsers()
        //{
        //    //try
        //    //{
        //    //    List<Users> lstADUsers = new List<Users>();
        //    //    string DomainPath = "LDAP://DC=xxxx,DC=com"
        //    //    DirectoryEntry searchRoot = new DirectoryEntry(DomainPath);
        //    //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    //    search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    //    search.PropertiesToLoad.Add("samaccountname");
        //    //    search.PropertiesToLoad.Add("mail");
        //    //    search.PropertiesToLoad.Add("usergroup");
        //    //    search.PropertiesToLoad.Add("displayname");//first name
        //    //    SearchResult result;
        //    //    SearchResultCollection resultCol = search.FindAll();
        //    //    if (resultCol != null)
        //    //    {
        //    //        for (int counter = 0; counter < resultCol.Count; counter++)
        //    //        {
        //    //            string UserNameEmailString = string.Empty;
        //    //            result = resultCol[counter];
        //    //            if (result.Properties.Contains("samaccountname") &&
        //    //                     result.Properties.Contains("mail") &&
        //    //                result.Properties.Contains("displayname"))
        //    //            {
        //    //                Users objSurveyUsers = new Users();
        //    //                objSurveyUsers.Email = (String)result.Properties["mail"][0] +
        //    //                  "^" + (String)result.Properties["displayname"][0];
        //    //                objSurveyUsers.UserName = (String)result.Properties["samaccountname"][0];
        //    //                objSurveyUsers.DisplayName = (String)result.Properties["displayname"][0];
        //    //                lstADUsers.Add(objSurveyUsers);
        //    //            }
        //    //        }
        //    //    }
        //    //    return lstADUsers;
        //    //}
        //    //catch (Exception ex)
        //    //{

        //}

        public DataTable GetUTSUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand getUsers = new SqlCommand("SELECT * FROM Users", sqlConnection);

                sqlConnection.Open();

                SqlDataReader myReader = getUsers.ExecuteReader();
                dt.Load(myReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            return dt;
        }
    }

    public class Users
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public bool isMapped { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
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
        string _path = "LDAP://capstone.uts.edu";
        private string _filterAttribute;

        public List<string> GetGroups()
        {
            DirectorySearcher search = new DirectorySearcher(_path);
            search.Filter = "(&(objectCategory=person)(objectClass=user)(memberOf=*))";
            //search.Filter = "(objectClass=group)";
            search.PropertiesToLoad.Add("memberOf");
            search.PropertiesToLoad.Add("name");
            StringBuilder groupNames = new StringBuilder();
            List<string> users = new List<string>();

            try
            {
                SearchResultCollection result = search.FindAll();

                foreach(SearchResult r in result)
                {
                    users.Add(r.Properties["memberOf"][0].ToString());
                    //users.Add(r.Properties["name"][0].ToString());
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

     //   public ArrayList AttributeValuesMultiString(string attributeName,
     //string objectDn, ArrayList valuesCollection, bool recursive)
     //   {
     //       DirectoryEntry ent = new DirectoryEntry(objectDn);
     //       PropertyValueCollection ValueCollection = ent.Properties[attributeName];
     //       IEnumerator en = ValueCollection.GetEnumerator();

     //       while (en.MoveNext())
     //       {
     //           if (en.Current != null)
     //           {
     //               if (!valuesCollection.Contains(en.Current.ToString()))
     //               {
     //                   valuesCollection.Add(en.Current.ToString());
     //                   if (recursive)
     //                   {
     //                       AttributeValuesMultiString(attributeName, "LDAP://" +
     //                       en.Current.ToString(), valuesCollection, true);
     //                   }
     //               }
     //           }
     //       }
     //       ent.Close();
     //       ent.Dispose();
     //       return valuesCollection;
     //   }
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

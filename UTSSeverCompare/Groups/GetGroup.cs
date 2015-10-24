using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1.Groups
{
    class GetGroup
    {
        SqlConnection sqlConnection = new SqlConnection("user id=swright;" +
                                                           "password=Abc123!!;" +
                                                           "server=SQLSERVER480;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=UTSDB; " +
                                                           "connection timeout=10");

        public List<string> GetUTSGroups()
        {
            DataTable dt = new DataTable();
            List<string> allGroups = new List<string>();

            try
            {
                SqlCommand getUsers = new SqlCommand("SELECT * FROM Groups", sqlConnection);

                sqlConnection.Open();

                SqlDataReader myReader = getUsers.ExecuteReader();
                dt.Load(myReader);


                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
            
            foreach(DataRow row in dt.Rows)
            {
                allGroups.Add(row.ItemArray[1].ToString());
            }

            return allGroups;
        }

        public Dictionary<int, string> GetUTSGroupsDictonary()
        {
            DataTable dt = new DataTable();
            Dictionary<int, string> allGroups = new Dictionary<int, string>();

            try
            {
                SqlCommand getUsers = new SqlCommand("SELECT * FROM Groups", sqlConnection);

                sqlConnection.Open();

                SqlDataReader myReader = getUsers.ExecuteReader();
                dt.Load(myReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            foreach (DataRow row in dt.Rows)
            {
                allGroups.Add(Convert.ToInt32(row.ItemArray[0]), row.ItemArray[1].ToString());
            }

            return allGroups;
        }

        public List<string> GetADGroups()
        {
            UserPrincipal current_user = UserPrincipal.Current;

            PrincipalContext current_context = current_user.Context;

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            GroupPrincipal qbeUser = new GroupPrincipal(ctx);

            Principal userOrGroup = qbeUser as Principal;
            userOrGroup.Name = "*";

            PrincipalSearcher searcher = new PrincipalSearcher(userOrGroup);
            
            List<string> allGroups = new List<string>();

            // enumerate the results - you need to check what kind of principal you get back
            foreach (Principal found in searcher.FindAll())
            {
                // is it a UserPrincipal - do what you need to do with that...
                if (found is UserPrincipal)
                {
                    //  ......
                }
                else if (found is GroupPrincipal)
                {
                    allGroups.Add(found.Name);

                    //GroupPrincipal gp = found as GroupPrincipal;

                    //var data = gp.GetMembers();

                    // if it's a group - do whatever you need to do with a group....
                }
            }
            return allGroups;
        }

        public bool SetGroups(string groupName, string groupManager)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("INSERT INTO Groups (GroupsName, GroupsManager) VALUES ('" + groupName + "', '" + groupManager + "');", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateGroups()
        {
            List<string> utsGroups = GetUTSGroups();
            List<string> adGroups = GetADGroups();

            List<string> updatedGroupsData = adGroups.Except(utsGroups).ToList();

            foreach(string group in updatedGroupsData)
            {
                SetGroups(group, "");
            }
        }
    }
}

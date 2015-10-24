using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
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

        public List<string> GetAdUsers()
        {
            UserPrincipal current_user = UserPrincipal.Current;

            PrincipalContext current_context = current_user.Context;

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "capstone.uts.edu");
            
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "Domain Users");
            
            List<string> allUsers = new List<string>();
            
            foreach (Principal p in group.GetMembers())
            {
                allUsers.Add(p.Name);
            }

            return allUsers;
        }

        public List<string> GetUTSUsers()
        {
            DataTable dt = new DataTable();
            List<string> allUsers = new List<string>();

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

            foreach (DataRow row in dt.Rows)
            {
                allUsers.Add(row.ItemArray[1].ToString());
            }

            return allUsers;
        }

        public Dictionary<int, string> GetUTSUsersDictonary()
        {
            DataTable dt = new DataTable();
            Dictionary<int, string> allUsers = new Dictionary<int, string>();

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

            foreach (DataRow row in dt.Rows)
            {
                allUsers.Add(Convert.ToInt32(row.ItemArray[0]), row.ItemArray[1].ToString());
            }

            return allUsers;
        }

        public bool SetUsers(string userName)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("INSERT INTO Users (UsersName) VALUES ('" + userName + "');", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateUsers()
        {
            List<string> utsUsers = GetUTSUsers();
            List<string> adUsers = GetAdUsers();

            List<string> updatedUsersData = adUsers.Except(utsUsers).ToList();

            foreach (string user in updatedUsersData)
            {
                SetUsers(user);
            }
        }
    }
}

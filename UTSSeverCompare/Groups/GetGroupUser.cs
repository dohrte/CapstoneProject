using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsService1.Users;

namespace WindowsService1.Groups
{
    class GetGroupUser
    {
        SqlConnection sqlConnection = new SqlConnection("user id=swright;" +
                                                           "password=Abc123!!;" +
                                                           "server=SQLSERVER480;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=UTSDB; " +
                                                           "connection timeout=10");

        public DataTable GetUTSGroupsUser()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand getUsers = new SqlCommand("SELECT * FROM Groups_User", sqlConnection);

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

        public List<string> GetUsersForGroup(string groupName)
        {
            UserPrincipal current_user = UserPrincipal.Current;

            PrincipalContext current_context = current_user.Context;

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "capstone.uts.edu");

            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName);

            List<string> allUsers = new List<string>();
            if(group != null)
            {
                foreach (Principal p in group.GetMembers())
                {
                    allUsers.Add(p.Name);
                }
            }          

            return allUsers;
        }

        public bool SetGroupsUsers(int groupId, int userId)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand(@"IF NOT EXISTS(Select GroupsIDGroups_User, UserIDGroups_User
                                                           FROM Groups_User where GroupsIDGroups_User = @gropuId AND UserIDGroups_User = @userId)
                                                           BEGIN                                                        
                                                           INSERT INTO Groups_User(GroupsIDGroups_User, UserIDGroups_User) VALUES(@gropuId, @userId)
                                                           END", sqlConnection);

                mySetCommand.Parameters.AddWithValue("@gropuId", groupId);
                mySetCommand.Parameters.AddWithValue("@userId", userId);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GroupsUsersXrefUpdate()
        {
            GetGroup group = new GetGroup();
            GetUser user = new GetUser();

            List<int> utsUserIds = new List<int>();
            List<string> currentGroupUsers = new List<string>();
            Dictionary<int, string> utsGroups = new Dictionary<int, string>();            
            Dictionary<int, string> utsUsers = new Dictionary<int, string>();

            utsGroups = group.GetUTSGroupsDictonary();
            utsUsers = user.GetUTSUsersDictonary();

            foreach(var g in utsGroups)
            {
                utsUserIds.Clear();
                currentGroupUsers.Clear();

                currentGroupUsers = GetUsersForGroup(g.Value);

                if(currentGroupUsers != null && currentGroupUsers.Count != 0)
                {
                    foreach (String userName in currentGroupUsers)
                    {
                        if (utsUsers.ContainsValue(userName))
                        {
                            utsUserIds.Add(utsUsers.First(x => x.Value == userName).Key);
                        }
                    }
                }

                if (utsUserIds != null && utsUserIds.Count != 0)
                {
                    foreach (int id in utsUserIds)
                    {
                        SetGroupsUsers(g.Key, id);
                    }
                }                    
            }            
        }
    }
}

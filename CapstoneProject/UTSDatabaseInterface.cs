﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CapstoneProject
{
    public struct GroupProperties
    {
        public List<string> users;
        public List<Tuple<string, string>> shares;
    }

    public class UTSDatabaseInterface
    {
        SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);


        public GroupProperties GetUTSGroups(string groupName)
        {
            DataTable dtUsers = new DataTable();
            DataTable dtShares = new DataTable();
            GroupProperties group = new GroupProperties();
            try
            {
                SqlCommand getUsers = new SqlCommand(@"SELECT DISTINCT UsersName from Groups
                                                      JOIN Groups_User on GroupsID = GroupsIDGroups_User
                                                      JOIN USERS on UsersID = UserIDGroups_User
                                                      WHERE GroupsID IN (SELECT GroupsID from Groups WHERE GroupsName = '" + groupName + "')", sqlConnection);

                SqlCommand getShares = new SqlCommand(@"SELECT DISTINCT ShareName, Share_GroupGroupPermissions from Share
                                                        JOIN Share_Groups on Share_GroupShareID = ShareID
                                                        WHERE Share_GroupGroupID IN (SELECT GroupsID from Groups WHERE GroupsName = '" + groupName + "')", sqlConnection);

                sqlConnection.Open();

                SqlDataReader myReader = getUsers.ExecuteReader();
                dtUsers.Load(myReader);
                myReader = getShares.ExecuteReader();
                dtShares.Load(myReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            if (dtUsers.Rows.Count > 0)
            {
                group.users = new List<string>();
                foreach (DataRow row in dtUsers.Rows)
                {
                    group.users.Add(row[0].ToString());
                }
            }

            if (dtShares.Rows.Count > 0)
            {
                group.shares = new List<Tuple<string, string>>();
                foreach (DataRow row in dtShares.Rows)
                {
                    string sName = row[0].ToString();
                    sName = sName.Substring(sName.LastIndexOf(@"\") + 1);
                    group.shares.Add(new Tuple<string, string>(sName, row[1].ToString()));
                }
            }

            return group;
        }

        public List<Tuple<string, string, string>> GetUTShares(string shareName)
        {
            DataTable dtShares = new DataTable();
            List<Tuple<string, string, string>> shares = new List<Tuple<string, string,string>>();
            try
            {
                SqlCommand getShares = new SqlCommand(@"SELECT DISTINCT Share_GroupGroupPermissions, GroupsName, UsersName from Share
                                                       join Share_Groups on Share_GroupShareID = ShareID
                                                       join Groups on GroupsID = Share_GroupGroupID
                                                       join Groups_User on GroupsIDGroups_User = GroupsID
                                                       join USERS on UsersID = UserIDGroups_User
                                                       where ShareName = '" + shareName + "')", sqlConnection);
                
                sqlConnection.Open();

                SqlDataReader myReader = getShares.ExecuteReader();
                dtShares.Load(myReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            if (dtShares.Rows.Count > 0)
            {                
                foreach (DataRow row in dtShares.Rows)
                {
                    shares.Add(new Tuple<string, string, string>(row[0].ToString(), row[1].ToString(), row[2].ToString()));
                }
            }

            return shares;
        }

        public List<Tuple<string, string, string>> GetUTSUsers(string userName)
        {
            DataTable dtUsers = new DataTable();
            List<Tuple<string, string, string>> shares = new List<Tuple<string, string, string>>();
            try
            {
                SqlCommand getShares = new SqlCommand(@"SELECT DISTINCT ShareName, Share_GroupGroupPermissions, GroupsName from Share
                                                        join Share_Groups on Share_GroupShareID = ShareID
                                                        join Groups on GroupsID = Share_GroupGroupID
                                                        join Groups_User on GroupsIDGroups_User = GroupsID
                                                        join USERS on UsersID = UserIDGroups_User
                                                        where UsersName = '" + userName + "'", sqlConnection);

                sqlConnection.Open();

                SqlDataReader myReader = getShares.ExecuteReader();
                dtUsers.Load(myReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            if (dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    shares.Add(new Tuple<string, string, string>(row[0].ToString(), row[1].ToString(), row[2].ToString()));
                }
            }

            return shares;
        }

        public List<Tuple<int, DateTime, int, string, string>> ReadUTSLog()
        {
            DataTable dt = new DataTable();
            List<Tuple<int, DateTime, int, string, string>> logs = new List<Tuple<int, DateTime, int, string, string>>();

            try
            {
                SqlCommand getLogs = new SqlCommand(@"SELECT * FROM Log", sqlConnection);

                sqlConnection.Open();

                SqlDataReader myReader = getLogs.ExecuteReader();
                dt.Load(myReader);

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    logs.Add(new Tuple<int, DateTime, int, string, string>(Convert.ToInt32(row[0]), Convert.ToDateTime(row[1]), Convert.ToInt32(row[2]), row[3].ToString(), row[4].ToString()));
                }
            }

            return logs;
        }

        public bool InsertUTSLog(int userId, string type, string logMessage)
        {
            DataTable dt = new DataTable();

            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand(@"INSERT INTO Log (postingDate, userId, type, logMessage) VALUES ('" + DateTime.Now + "', '" + userId + "', '" + type + "', '" + logMessage + "');", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
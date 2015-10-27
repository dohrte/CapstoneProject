using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace CapstoneProject
{
    public struct ExecuteResult
    {
        public SearchResult singleResult;
        public SearchResultCollection collectionResult;
        public bool error;
        public const string errMsg = "An error occured communicating with Active Directory.";

        public bool IsNull()
        {
            if (this.singleResult == null && this.collectionResult == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
    
    public sealed class ActiveDirectoryAction : ActiveDirectoryInterface
    {
        private static readonly ActiveDirectoryAction instance = new ActiveDirectoryAction();
        private string connectionPrefix = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ActiveDirectory"].ConnectionString;
        private Object lockObj = new Object();

        private ActiveDirectoryAction()
        {

        }

        public static ActiveDirectoryAction Instance
        {
            get { return instance; }
        }
               
        /// <summary>
        /// Get the members of an AD group. Includes the
        /// members of any subgroups.
        /// </summary>
        /// <param name="groupName">string, AD group name</param>
        /// <returns>list of members as an array of strings</returns>
        public string[] GetMemberList(string groupName)
        {
            List<string> userList = new List<string>();
            this.GenerateMemberList(groupName, userList);
            return userList.ToArray<string>();
        }

        /// <summary>
        /// Get a list of shares managed by a user.
        /// </summary>
        /// <param name="userID">string, user name</param>
        /// <returns>list of groups as an array of strings</returns>
        public string[] GetGroupsManagedList(string userID)
        {
            List<string> groupList = new List<string>();

            string queryString = "(&(objectClass=group)(ManagedBy=CN=" + userID + ",CN=Users,DC=admnet,DC=oakland,DC=edu))";

            ExecuteResult result = this.ExecuteSearch(queryString, true);

            if (result.collectionResult.Count > 0)
            {
                foreach (SearchResult item in result.collectionResult)
                {
                    DirectoryEntry directoryObject = item.GetDirectoryEntry();
                    groupList.Add(directoryObject.Properties["CN"].Value.ToString());
                }
            }
                        
            return groupList.ToArray<string>();
        }

        /// <summary>
        /// Recursively populates list of group memebers.
        /// Will list all memebers, even those from subgroups.
        /// </summary>
        /// <param name="grpName"></param>
        /// <param name="memList"></param>
        private void GenerateMemberList(string grpName, List<string> memList)
        {
            string queryString = "(&(memberOf=" + this.GetDN(grpName) + ")(|(objectClass=user)(objectClass=group)))";

            ExecuteResult result = this.ExecuteSearch(queryString, true);

            if (result.collectionResult != null)
            {
                foreach (SearchResult item in result.collectionResult)
                {
                    DirectoryEntry directoryObject = item.GetDirectoryEntry();

                    string classType = directoryObject.SchemaClassName;
                    if (classType.Equals("group"))
                    {
                        this.GenerateMemberList(directoryObject.Properties["CN"].Value.ToString(), memList);
                    }
                    else
                    {
                        if (!memList.Contains(directoryObject.Properties["CN"].Value.ToString()))
                        {
                            memList.Add(directoryObject.Properties["CN"].Value.ToString());
                        }
                    }
                }
            }
            else
            {
                memList.Add("Unable to find a match for the name entered. Please check and retry.");
            }
        }

        /// <summary>
        /// Get the list of groups that the user is a member of
        /// </summary>
        /// <param name="userName">The users sAMAccountName</param>
        /// <returns>List of string objects representing the group names</returns>
        public List<string> GetMemberOf(string userName)
        {
            List<string> groups = new List<string>();

            string queryString = "(&(sAMAccountName=" + userName + ")(objectClass=user))";

            ExecuteResult result = this.ExecuteSearch(queryString, false);

            if (result.singleResult != null)
            {
                DirectoryEntry directoryObject = result.singleResult.GetDirectoryEntry();
                var grps = directoryObject.Properties["memberOf"];

                foreach (string i in grps)
                {
                   groups.Add(i);
                }
            }

            return groups;
        }

        /// <summary>
        /// Find if a user is a memeber of a particular group.
        /// </summary>
        /// <param name="userName">Ther CN or samAccountName</param>
        /// <param name="groupName">bool, true or false</param>
        /// <returns></returns>
        public bool IsMemberOf(string userName, string groupName)
        {
            bool isMember = false;

            var userDetail = this.GetUserAcctInfo(userName);

            string[] grpMems = this.GetMemberList(groupName);

            if (grpMems.Contains(userDetail["cn"]))
            {
                isMember = true;
            }

            return isMember;
        }
             
        /// <summary>
        /// Get the properties for a user object in active directory. 
        /// </summary>
        /// <param name="user">The users "cn" or "samaccountName"</param>
        /// <param name="properties">optional parameter, define the properties desired in a string array</param>
        /// <returns>A dictionary of key value pairs.</returns>
        public Dictionary<string, string> GetUserAcctInfo(string user, string[] properties = null)
        {
            Dictionary<string, string> userProps = new Dictionary<string, string>();
            
           string qString = "(&(objectClass=user)(|(CN=" + user + ")(sAMAccountName=" + user + ")))";

           ExecuteResult result = this.ExecuteSearch(qString, false);

            if (result.singleResult != null)
            {
                DirectoryEntry directoryObject = result.singleResult.GetDirectoryEntry();
                if (properties == null)
                {
                    foreach (string prop in directoryObject.Properties.PropertyNames)
                    {
                        userProps[prop] = directoryObject.Properties[prop].Value.ToString();
                    }
                }
                else
                {
                    foreach (string prop in properties)
                    {
                        userProps[prop] = directoryObject.Properties[prop].Value.ToString();
                    }
                }
            }

            return userProps;
        }

        /// <summary>
        /// returns the distinguishedName from AD based on name. 
        /// Works for groups or users.
        /// </summary>
        /// <param name="gName">the name associated with the user\group</param>
        /// <returns>string DistinguishedName</returns>
        private string GetDN(string gName)
        {
            string distinguishedName = string.Empty;
            string queryString = "(&(Name=" + gName + ")(|(objectClass=user)(objectClass=group)(objectClass=organizationalUnit)))";

            ExecuteResult result = this.ExecuteSearch(queryString, false);

            if (result.singleResult != null)
            {
                DirectoryEntry directoryObject = result.singleResult.GetDirectoryEntry();
                distinguishedName = directoryObject.Properties["distinguishedName"].Value.ToString();
            }
            else
            {
                Console.WriteLine("Unable to find a match for the name entered. Please check and retry.");
            }

            return distinguishedName;
        }

        /// <summary>
        /// Get the type of AD object, Group or user.
        /// </summary>
        /// <param name="objName">string, group or user name</param>
        /// <returns>string, {user,group, null}</returns>
        private string GetObjType(string objName)
        {
            string retType = "null";
            string queryString = "(&(Name=" + objName + ")(|(objectClass=user)(objectClass=group)))";

            ExecuteResult result = this.ExecuteSearch(queryString, false);

            if (result.singleResult != null)
            {
                DirectoryEntry directoryObject = result.singleResult.GetDirectoryEntry();
                
                var objClass = directoryObject.Properties["ObjectClass"];
                if (objClass.Contains("user"))
                {
                    retType = "user";
                }
                else if (objClass.Contains("group"))
                {
                    retType = "group";
                }
                else
                {
                    retType = "null";
                }
            }

            return retType;
        }

        /// <summary>
        /// Get information about the AD object. 
        /// </summary>
        /// <param name="inputName">string, AD Object name</param>
        /// <returns></returns>
        public Dictionary<string, string> GetAdObj(string inputName)
        {
            string queryString = "(&(|(Name=" + inputName + ")(CN=" + inputName + ")(sAMAccountName=" + inputName + "))(|(objectClass=user)(objectClass=group)))";
            
            Dictionary<string, string> retAdObj = new Dictionary<string, string>();
            ExecuteResult result = this.ExecuteSearch(queryString, false);
            
            if (result.IsNull())
            {
                retAdObj["Type"] = "null";
            }
            else
            {
                DirectoryEntry directoryObject = result.singleResult.GetDirectoryEntry();

                var objClass = directoryObject.Properties["ObjectClass"];
                if (objClass.Contains("user"))
                {
                    retAdObj["Type"] = "user";
                    retAdObj["CN"] = directoryObject.Properties["CN"].Value.ToString();
                    retAdObj["AdmnetID"] = directoryObject.Properties["sAMAccountName"].Value.ToString();
                }
                else if (objClass.Contains("group"))
                {
                    retAdObj["Type"] = "group";
                    retAdObj["CN"] = directoryObject.Properties["CN"].Value.ToString();
                    
                    if (directoryObject.Properties.Contains("ManagedBy"))
                    {
                        retAdObj["ManagedBy"] = directoryObject.Properties["ManagedBy"].Value.ToString();
                    }
                    else
                    {
                        retAdObj["ManagedBy"] = "***UNMANAGED***";
                    }
                }
                else
                {
                    retAdObj["Type"] = "null";
                }
            }

            return retAdObj;
        }

        /// <summary>
        /// Execute general search of active directory and return the results 
        /// in the form of an ExecuteResult struct. Optional parameter to specify the 
        /// location to search in.
        /// </summary>
        /// <param name="filterString">string, LDAP formatted filter</param>
        /// <param name="returnCollection">boolean, true if result will be a collection. false, if result is single item</param>
        /// <param name="connPrefix">Optional parameter, specified distinguished name to search within</param>
        /// <returns></returns>
        private ExecuteResult ExecuteSearch(string filterString, bool returnCollection, string connPrefix = null)
        {
            ExecuteResult execResult = new ExecuteResult();
            execResult.singleResult = null;
            execResult.collectionResult = null;
            bool errFlag = false;
            
            DirectoryEntry entry;
            if (connPrefix == null)
            {
                entry = new DirectoryEntry(connectionPrefix);
            }
            else
            {
                entry = new DirectoryEntry("LDAP://" + connPrefix);
            }
            
            DirectorySearcher mySearcher = new DirectorySearcher(entry);

            mySearcher.Filter = filterString;
            
            if (returnCollection)
            {
                SearchResultCollection CollectionResult = null;

                try
                {
                    CollectionResult = mySearcher.FindAll();
                }
                catch (Exception e)
                {
                    errFlag = true;
                    //Console.Write("search error. " + e.Message); //log file for errors
                }

                execResult.collectionResult = CollectionResult;

            }
            else
            {
                SearchResult singleResult = null;
                try
                {
                    singleResult = mySearcher.FindOne();
                }
                catch (Exception e)
                {
                    errFlag = true;
                    //Console.Write("search error. " + e.Message); //log file for errors
                }

                execResult.singleResult = singleResult;
            }

            execResult.error = errFlag;

            entry.Close();
            entry.Dispose();
            mySearcher.Dispose();

            return execResult;
        }



        // **** used by role provider ***********************************

        /// <summary>
        /// Get a list of roles for the web application.
        /// </summary>
        /// <returns>A string array of role names</returns>
        public string[] GetWebAppRoles()
        {
            List<string> memberOf = new List<string>();

            string queryString = "(objectClass=group)";
            string ouDistinguishedName = this.GetDN(System.Web.Configuration.WebConfigurationManager.AppSettings["RoleContainer"]);

            ExecuteResult result = this.ExecuteSearch(queryString, true, ouDistinguishedName);

            if (result.collectionResult != null)
            {
                foreach (SearchResult sResult in result.collectionResult)
                {
                    DirectoryEntry directoryObject = sResult.GetDirectoryEntry();
                    memberOf.Add(directoryObject.Properties["CN"].Value.ToString());
                }
            }
            else
            {
                Console.WriteLine("Unable to find a match for the name entered. Please check and retry.");
            }
            return memberOf.ToArray();
        }

        /// <summary>
        /// Get a list of roles for a specific user.
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <returns>string[] of role names</returns>
        public string[] GetUsersWebAppRoles(string username)
        {
            List<string> memberOf = new List<string>();

            foreach (string role in this.GetWebAppRoles())
            {
                if (this.IsMemberOf(username, role))
                {
                    memberOf.Add(role);
                }
            }
            return memberOf.ToArray();
        }

       

        // **** used by create computer object action ***********************************

        public string CreateComputerObject(string compName, string deptName, bool isCustom, out bool errFlag)
        {
            string fullCompName = string.Empty;
            string errMsg = string.Empty;
            errFlag = false;


            //Lock the check if exists and create function to confirm that duplicate entries will not happen.
            lock (lockObj)
            {

                if (this.DoesComputerNameExist(compName, deptName))
                {
                    //return already exists message
                    errFlag = true;
                    errMsg = "The computer name already exists.";
                }
                else
                {
                    if (isCustom)
                    {
                        //use custom name
                        fullCompName = compName;
                    }
                    else
                    {
                        //create computer name
                        //check current names
                        int compNum = this.GetComputerNumber(compName);

                        if (compNum.Equals(-1))
                        {
                            //report not successful
                            errFlag = true;
                            errMsg = "There was an error in creation of new computer object.";
                        }
                        else
                        {
                            fullCompName = compName + compNum;
                        }
                    }
                }

                if (errFlag)
                {
                    return errMsg;
                }
                else
                {
                    //get the OU dsName
                    //create adobject
                    DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + this.GetComputerOrganizationalUnit(deptName));
                    DirectoryEntry newComputer = dirEntry.Children.Add("CN=" + fullCompName, "computer");
                    newComputer.Properties["sAMAccountName"].Value = fullCompName + "$";
                    newComputer.Properties["UserAccountControl"].Value = 0x1000;

                    //commit and cleanup
                    newComputer.CommitChanges();
                    newComputer.Close();
                    newComputer.Dispose();
                    dirEntry.Close();
                    dirEntry.Dispose();

                    this.SetSecurityRights(fullCompName, this.GetComputerOrganizationalUnit(deptName));

                    return fullCompName;
                }
            }
        }

        /// <summary>
        /// Check if a computer name exists in the defined OU in active directory.
        /// </summary>
        /// <param name="compName">Computer name to check for.</param>
        /// <param name="ouName">OU to check with in.</param>
        /// <returns>Bool value, true if the name does exist else false.</returns>
        private bool DoesComputerNameExist(string compName, string ouName)
        {
            bool exist = false;
            compName = compName.ToUpperInvariant();
            DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + this.GetComputerOrganizationalUnit(ouName));

            DirectorySearcher ds = new DirectorySearcher(dirEntry);

            ds.Filter = @"(&(cn=" + compName + ")(objectClass=computer))";

            SearchResult singleResult = null;
            try
            {
                singleResult = ds.FindOne();
            }
            catch (Exception e)
            {
                //errFlag = true;
                //Console.Write("search error. " + e.Message); //log file for errors
            }

            if (singleResult != null)
            {
                exist = true;
            }

            return exist;
        }

        /// <summary>
        /// Generates a number based on the numbers already used in the computer object container.
        /// </summary>
        /// <param name="compName">The 3 part prefix to the computer number</param>
        /// <returns>-1 if error or positive integer value</returns>
        private int GetComputerNumber(string compName)
        {
            string queryString = "(& (name=" + compName + "*)(objectClass=computer) )";
            Regex regx = new Regex("" + compName + @"(?<extractedVal>\w+)", RegexOptions.IgnoreCase); ;
            int intVal;
            List<int> numList = new List<int>();

            ExecuteResult result = this.ExecuteSearch(queryString, true);

            if (result.collectionResult != null)
            {
                if (result.collectionResult.Count > 0)
                {
                    foreach (SearchResult item in result.collectionResult)
                    {
                        DirectoryEntry directoryObject = item.GetDirectoryEntry();

                        Match match = regx.Match(directoryObject.Properties["name"].Value.ToString());

                        if (Int32.TryParse(match.Groups["extractedVal"].Value, out intVal))
                        {
                            Console.WriteLine(intVal);
                            numList.Add(intVal);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("no existing computers");
                    numList.Add(0);
                }

                return numList.Max() + 1;
            }
            else
            {
                return -1;
            }


        }

        /// <summary>
        /// Set the security rights on a computer object to allow users in the JoinToComputer group to join to computer objects.
        /// </summary>
        /// <param name="compName">The computer object name to set permissions on</param>
        /// <param name="ouContainer">The container where the computer object resides.</param>
        private void SetSecurityRights(string compName, string ouContainer)
        {
            string qString = "(&(name=" + compName + ")(objectClass=computer))";
            ExecuteResult result = this.ExecuteSearch(qString, false, ouContainer);
            //TODO: add group to security 
            var computer = result.singleResult.GetDirectoryEntry();
            ActiveDirectorySecurity sdc = computer.ObjectSecurity;
            NTAccount Account = new NTAccount("capstone", "JoinToComputer");
            SecurityIdentifier sid = (SecurityIdentifier)Account.Translate(typeof(SecurityIdentifier));


            Guid userSchemaGuid = new Guid("BF967ABA-0DE6-11D0-A285-00AA003049E2");
            Guid computerSchemaGuid = new Guid("bf967a86-0de6-11d0-a285-00aa003049e2");

            Guid UserForceChangePassword = new Guid("00299570-246d-11d0-a768-00aa006e0529"); // ‘Reset password’ 
            Guid dnsHostNameGuid = new Guid("72e39547-7b18-11d1-adef-00c04fd8d5cd");  // ‘Validated write to DNS host name’
            Guid rwAccountRestrictions = new Guid("4c164200-20c0-11d0-a768-00aa006e0529"); // ‘Read and write account restrictions’
            Guid wServicePrincipalName = new Guid("f3a64788-5306-11d1-a9c5-0000f80367c1");   // ‘Validated write to service principal name’ 

            ActiveDirectoryAccessRule acctRestrictionsRW = new ActiveDirectoryAccessRule(Account, ActiveDirectoryRights.ReadProperty | ActiveDirectoryRights.WriteProperty, AccessControlType.Allow, rwAccountRestrictions, ActiveDirectorySecurityInheritance.None);
            sdc.AddAccessRule(acctRestrictionsRW);

            ActiveDirectoryAccessRule dnsHostNameEdit = new ActiveDirectoryAccessRule(Account, ActiveDirectoryRights.Self, AccessControlType.Allow, dnsHostNameGuid, ActiveDirectorySecurityInheritance.None);
            sdc.AddAccessRule(dnsHostNameEdit);
            ActiveDirectoryAccessRule valSPN = new ActiveDirectoryAccessRule(Account, ActiveDirectoryRights.Self, AccessControlType.Allow, wServicePrincipalName, ActiveDirectorySecurityInheritance.None);
            sdc.AddAccessRule(valSPN);

            ExtendedRightAccessRule erarResetPwd = new ExtendedRightAccessRule(Account, AccessControlType.Allow, UserForceChangePassword, ActiveDirectorySecurityInheritance.None, userSchemaGuid);
            sdc.AddAccessRule(erarResetPwd);

            /* may require the below line
             * 
             * Guid userAccountControlGuid = GUID('bf967a68-0de6-11d0-a285-00aa003049e2');
             *  ActiveDirectoryAccessRule userAccountControlEdit = new ActiveDirectoryAccessRule(Account, ActiveDirectoryRights.ReadProperty | ActiveDirectoryRights.WriteProperty, AccessControlType.Allow, userAccountControlGuid, ActiveDirectorySecurityInheritance.None);
             * sdc.AddAccessRule(userAccountControlEdit);
             * 
             * */

            //commit and cleanup
            computer.CommitChanges();
            computer.Close();
            computer.Dispose();


        }

        /// <summary>
        /// returns the distinguished name of the OU that is provided as a parameter
        /// </summary>
        /// <param name="ouName">Name of OU</param>
        /// <returns>Distinguished Name of the OU</returns>
        private string GetComputerOrganizationalUnit(string ouName)
        {
            string queryString = "(&(Name=" + ouName + ")(objectClass=organizationalUnit))";
            string ouDistinguishedName = string.Empty;

            ExecuteResult result = this.ExecuteSearch(queryString, true, this.GetDN("Capstone Computers"));

            if (result.collectionResult != null)
            {
                foreach (SearchResult sResult in result.collectionResult)
                {
                    DirectoryEntry directoryObject = sResult.GetDirectoryEntry();

                    string distName = directoryObject.Properties["distinguishedName"].Value.ToString();
                    //Console.WriteLine(distName);
                    if (distName.Contains("Capstone Computers"))
                    {
                        ouDistinguishedName = directoryObject.Properties["distinguishedName"].Value.ToString();
                    }
                }
            }
            else
            {
                Console.WriteLine("Unable to find a match for the name entered. Please check and retry.");
            }
            return ouDistinguishedName;
        }


        // **** used by group management ***********************************
        public void AddUserToGroup(string userId, string groupName)
        {
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "capstone"))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                    group.Members.Add(pc, IdentityType.UserPrincipalName, userId);
                    group.Save();
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //doSomething with E.Message.ToString(); 

            }
        }

        public void RemoveUserFromGroup(string userId, string groupName)
        {
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "capstone"))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                    group.Members.Remove(pc, IdentityType.UserPrincipalName, userId);
                    group.Save();
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //doSomething with E.Message.ToString(); 

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CapstoneProject
{
    /// <summary>
    /// This class will be used to set roles for users as it pertains to the web application.
    /// Roles will be based upon active directory group membership.
    /// A database will not be implemented to maintain the role membership.
    /// </summary>
    public class ActiveDirectoryRoleProvider : RoleProvider 
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }


        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        //need
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        //need
        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        //need
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        //need
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
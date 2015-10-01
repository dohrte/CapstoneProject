using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CapstoneProject.Roles
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

        
        public override string[] GetAllRoles()
        {
            var ad = ActiveDirectoryAction.Instance;
            return ad.GetWebAppRoles();
        }

        
        public override string[] GetRolesForUser(string username)
        {
            var ad = ActiveDirectoryAction.Instance;
            return ad.GetUsersWebAppRoles(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        
        public override bool IsUserInRole(string username, string roleName)
        {
            var adAction = ActiveDirectoryAction.Instance;

            bool result = false;

            result = adAction.IsMemberOf(username, roleName);
            return result;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        
        public override bool RoleExists(string roleName)
        {
            var adAction = ActiveDirectoryAction.Instance;
            string[] list = adAction.GetWebAppRoles();

            if (list.Contains(roleName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
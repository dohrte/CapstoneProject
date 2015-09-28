using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject
{
    /// <summary>
    /// Defines what ineractions are available between application and Active Directory
    /// </summary>
    interface ActiveDirectoryInterface
    {
        /// <summary>
        /// Returns a list of members of the specified group
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        string[] GetMemberList(string groupName);

        /// <summary>
        /// Returns a list of groups the defined user is a member of
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<string> GetMemberOf(string userName);

        /// <summary>
        /// Retruns a dictionary of key value attributes of the specified user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Dictionary<string, string> GetUserAcctInfo(string user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputName"></param>
        /// <returns></returns>
        Dictionary<string, string> GetAdObj(string inputName);

        /// <summary>
        /// Returns a list of groups managed by the specified user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        string[] GetGroupsManagedList(string userID);



    }
}

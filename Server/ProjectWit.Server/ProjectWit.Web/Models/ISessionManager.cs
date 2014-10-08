using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWit.Web.Models
{
    public interface ISessionManager
    {
        /// <summary>
        /// Updates the session key values
        /// </summary>
        /// <param name="user"></param>
        void SetSessions(ApplicationUser user);
        /// <summary>
        /// Reloads the current session key values
        /// </summary>
        /// <param name="userID"></param>
        void ReloadCurrentSession(string userID);
    }
}
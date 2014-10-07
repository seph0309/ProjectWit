using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWit.Web.Models
{
    public interface ISessionManagement
    {
        void SetSessions(ApplicationUser user);
        void ReloadCurrentSession(string userID);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;

namespace ProjectWit.Service
{
    public abstract class WitServiceBase
    {
        public Guid SessionID { get; set; }
        public string Browser { get; set; }
        public string DeviceType { get; set; }

        public bool AuthenticateUser(string userName, string password, string browser, string deviceType)
        {
            Browser = browser;
            DeviceType = deviceType;

            if (userName == null) return false;
            using (WITEntities db = new WITEntities())
            {
                var user = db.AspNetUsers.Where(m => m.UserName == userName.ToString()).Single();

                if (user != null)
                {
                    bool authenticatePassword = Wit_Cryptography.VerifyHashedPassword(user.PasswordHash, password);
                    if (authenticatePassword)
                    {
                        SessionID = GetSession(user.Id);
                        return true;
                    }
                }
                return false;
            }
        }

        private Guid GetSession(string userUID)
        {
            using(WITEntities db = new WITEntities())
            {
                //var _getSession = db.Wit_Session.Where(m => m.User_UID == new Guid(userUID)).ToList();
                var _getSession = (from col in db.Wit_Session
                                  where col.User_UID == new Guid(userUID)
                                   select new { Session_UID = col.Session_UID }).ToList();
                
                if (_getSession.Count >0)
                {
                    return _getSession[0].Session_UID;
                }
                else
                {
                    db.Wit_Session.Add(new Wit_Session { User_UID = new Guid(userUID), Browser = Browser, DeviceType = DeviceType });
                    db.SaveChanges();
                    return GetSession(userUID);
                }
            }
        }
    }
}
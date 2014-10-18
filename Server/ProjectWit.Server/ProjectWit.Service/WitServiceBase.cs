using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;

namespace ProjectWit.Service
{
    public abstract class WitServiceBase
    {
        public Guid sessionID { get; set; }

        public bool LoginUser(string userName, string password)
        {
            
            if (userName == null) return false;
            using (WITEntities db = new WITEntities())
            {
                //Error here
                var user = db.AspNetUsers.Where(m => m.UserName == userName.ToString()).Single();

                if (user != null)
                {
                    bool authenticatePassword = Wit_Cryptography.VerifyHashedPassword(user.PasswordHash, password);
                    if (authenticatePassword)
                    {
                        Guid gui = GetSession(user.Id);

                    }
                }
                return false;
            }
        }

        private Guid GetSession(string userUID)
        {
            using(WITEntities db = new WITEntities())
            {
                var _getSession = db.Wit_Session.Where(m => m.User_UID == new Guid(userUID)).ToList();
                if (_getSession.Count >0)
                {
                    return _getSession[0].Session_UID;
                }
                else
                {
                    db.Wit_Session.Add(new Wit_Session { User_UID = new Guid(userUID), Browser = "Chrome" });
                    db.SaveChanges();
                    return GetSession(userUID);
                }
            }
            return new Guid();
        }


    }
}
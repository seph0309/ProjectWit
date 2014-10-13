using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;

namespace ProjectWit.Service
{
    public abstract class WitServiceBase
    {
       
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
                    if (authenticatePassword) return true;
                }
                return false;
            }
        }


    }
}
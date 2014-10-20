using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class LoginServiceArgs
    {
        [DataMember]
        public Guid? SessionID { get; set; }
        [DataMember]
        public string Browser { get; set; }
        [DataMember]
        public string DeviceType { get; set; }
        [DataMember]
        public string CompanyUID;
        [DataMember]
        public bool IsAuthenticated { get; set; }
        [DataMember]
        public List<Wit_Category> wit_Category;
        [DataMember]
        public List<Wit_Item> wit_Item;

        private List<Wit_Category> GetCategories(string companyUID)
        {
            wit_Category = new List<Wit_Category>();
            
            //using(WITEntities db= new WITEntities())
            //{
            //   var cat = db.Wit_Category.Where(m => m.Company_UID == new Guid(companyUID)).ToList();
            //    foreach(Wit_Category category in cat)
            //    {
            //        wit_Category.Add(cat);
            //    }
            //}
            return wit_Category;
        }
        private string GetCompanyUID(string UserUID)
        {
            using (WITEntities db = new WITEntities())
            {
                var _comp = (from col in db.Wit_User
                              where col.User_UID == new Guid(UserUID)
                              select new { CompanyUID = col.Company_UID }).Single();
                return _comp.CompanyUID.ToString();
            }
        }
        public LoginServiceArgs()
        {
        }
        public LoginServiceArgs(string userName, string browser, string deviceType)
        {
            if (GetSession(userName, false) != null) IsAuthenticated = true;
        }

        public LoginServiceArgs(string userName, string password, string browser, string deviceType)
        {
            AuthenticateUser(userName, password, browser, deviceType);
            //Populate category and item
            GetCategories(CompanyUID);
        }

        private bool AuthenticateUser(string userName, string password, string browser, string deviceType)
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
                        CompanyUID = GetCompanyUID(user.Id);
                        SessionID = GetSession(user.Id, true);
                        return true;
                    }
                }
                return false;
            }
        }

        private Guid? GetSession(string userUID, bool saveWhenNoSession)
        {
            using (WITEntities db = new WITEntities())
            {
                var _getSession = (from col in db.Wit_Session
                                   where col.User_UID == new Guid(userUID)
                                   select new { Session_UID = col.Session_UID }).ToList();

                if (_getSession.Count > 0)
                {
                    IsAuthenticated = true;
                    return _getSession[0].Session_UID;
                }
                else
                {
                    if (saveWhenNoSession)
                    {
                        db.Wit_Session.Add(new Wit_Session { User_UID = new Guid(userUID), Browser = Browser, DeviceType = DeviceType });
                        db.SaveChanges();
                        return GetSession(userUID, false);
                    }
                    else return null;
                }
            }
        }
    }
}
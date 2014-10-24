using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class LoginServiceArgs: WitSessionServiceArgsBase
    {
    
        [DataMember(Order = 0)]
        public List<Wit_Category> Categories;
        [DataMember(Order = 1)]
        public List<Wit_Item> Items;

        private List<Wit_Category> GetCategories(string companyUID)
        {
            Categories = new List<Wit_Category>();
            Items= new List<Wit_Item>();

            using (WITEntities db = new WITEntities())
            {
                var cat = db.Wit_Category.Where(m => m.Company_UID == new Guid(companyUID)).ToList();
                foreach (Wit_Category category in cat)
                {
                    Categories.Add(new Wit_Category(category));
                    AddItem(category);
                }
            }
            return Categories;
        }

        private void AddItem(Wit_Category category)
        {
            foreach (Wit_Item item in category.Wit_Item)
            {
                Items.Add(new Wit_Item(item));
            }
        }

        private void InitializeCompanyUID(string UserUID)
        {
            using (WITEntities db = new WITEntities())
            {
                var _comp = (from col in db.Wit_User
                              where col.User_UID == new Guid(UserUID)
                              select new { CompanyUID = col.Company_UID }).FirstOrDefault();
                _companyUID = _comp.CompanyUID.ToString();
            }
        }
        public LoginServiceArgs()
        {
        }

        public LoginServiceArgs(string sessionID)
        {
            AuthenticateSession(sessionID);
            if (!IsAuthenticated) return;
            else
            {
                InitializeCompanyUID(_userUID);
                GetCategories(_companyUID);
            }
        }
        /// <summary>
        /// Checks if session exist in database
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public bool IsSessionActive(string sessionID)
        {
            AuthenticateSession(sessionID);
            return IsAuthenticated;
        }
        public LoginServiceArgs(string userName, string password, string browser, string deviceType)
        {
            if(AuthenticateUser(userName, password, browser, deviceType))
                //Populate category and item
                GetCategories(_companyUID);
        }
        public void TerminateSession(string sessionID)
        {
            if (Wit_Commons.IsStringGUID(sessionID))
            {
                if (TerminateSessionID(sessionID) > 0)
                    LogMessage.Add("Session Deleted");
                else
                    LogMessage.Add("Session does not exist");
            }
            else
                LogMessage.Add("Invalid Session");
        }
  
        private bool AuthenticateUser(string userName, string password, string browser, string deviceType)
        {
            Browser = browser;
            DeviceType = deviceType;

            if (userName == null) return false;
            using (WITEntities db = new WITEntities())
            {
                var user = db.AspNetUsers.Where(m => m.UserName == userName.ToString()).FirstOrDefault();

                if (user != null && !String.IsNullOrEmpty(password))
                {
                    bool authenticatePassword = Wit_Cryptography.VerifyHashedPassword(user.PasswordHash, password);
                    if (authenticatePassword)
                    {
                        InitializeCompanyUID(user.Id);
                        GenerateSession(user.Id);
                        return true;
                    }
                }
                LogMessage.Add("Wrong Username/Password");
                return false;
            }
        }
    }
}
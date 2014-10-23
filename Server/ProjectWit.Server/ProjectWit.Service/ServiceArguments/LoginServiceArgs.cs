using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class LoginServiceArgs: WitSessionServiceBase
    {
        [DataMember]
        public string CompanyUID;
        [DataMember]
        public List<Wit_Category> Categories;
        [DataMember]
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
            if(AuthenticateUser(userName, password, browser, deviceType))
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

                if (user != null && !String.IsNullOrEmpty(password))
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
    }
}